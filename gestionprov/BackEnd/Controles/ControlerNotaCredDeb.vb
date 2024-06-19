Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Contexts
Imports System.Web.UI.WebControls
Imports ClasesGlobal

Public Class ControlerNotaCredDeb
    Inherits ServidorSQl
    Dim CadenaSql As String
    Public Function ObtenerPrefijo(TipoComprobante As String) As Integer
        Dim Rst As DataTable
        Dim periodo As Long
        Dim orden As Integer
        Try
            periodo = CLng(Year(Now) & Format(Month(Now), "00"))
            orden = IIf(Day(Now) > 15, 2, 1)
            CadenaSql = "select Autorizandoen, case when autorizandoen = 1 then prefijo else " &
            " (case when (select caea from CtasCtesSQL.dbo.caeasolicitados where periodo =" & periodo & " and orden = " & orden & ") is null then prefijoCAI else prefijoCAEA end)end as prefijo" &
            ", case when autorizandoen = 1 then 1 else " &
            " (case when (select caea from CtasCtesSQL.dbo.caeasolicitados where periodo =" & periodo & " and orden = " & orden & ") is null then 2 else 3 end)end as OrigenFacturacion" &
            "  from CtasCtesSQL.dbo.usuariosprefijo where codusuario=" & VariablesGlobales.idusuario & " and codgestion = 6 and tipocomprobante ='" & TipoComprobante & "' "
            Rst = ServidorSQl.GetTabla(CadenaSql)
            If Rst.Rows.Count = 0 Then
                Return 0
            Else
                VariablesGlobales.OrigenFacturacion = Rst.Rows(0)!OrigenFacturacion
                ObtenerPrefijo = Rst.Rows(0)!prefijo
            End If
            Return ObtenerPrefijo
            Exit Function
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Public Function ObtenerUltimoCreditoDebito(ByVal Tipo As Integer) As Long
        '-----------------------------------------------------
        'Descripción: Obtiene el ultimo CREDITO o debito segun sea
        'Parámetros : Tipo de credito.
        'Output     : 1 se encontraron datos.
        '             0 No se encontraron datos.
        '            -1 Error al filtrar datos.
        '-----------------------------------------------------
        Dim rec As New DataTable
        CadenaSql = "Select Ultimonumero as mayor from CaiCreditosDebitos where TipoComprobante=" & Tipo
        rec = ServidorSQl.GetTabla(CadenaSql)
        If rec Is Nothing Then
            Return -1
        ElseIf rec.Rows.Count = 0 Then
            ObtenerUltimoCreditoDebito = 0
        Else
            ObtenerUltimoCreditoDebito = 1
        End If
    End Function

    Public Function BuscarCentroCostoXInsumo(ByVal insumo As String) As String
        '-----------------------------------------------------
        'Descripción: Busca C.C. deacuerdo al insumo
        'Parámetros : Insumo
        'Output     : "" = no se encontraron datos
        '             descripción si se encontraron datos
        '            Error
        '-----------------------------------------------------
        Dim rec As New DataTable
        CadenaSql = ("select * from Insumos where CodInsumo ='" & insumo & "' and Estado = 'S' ")
        rec = ServidorSQl.GetTabla(CadenaSql)
        If rec Is Nothing Then
            Return -1
        ElseIf rec.Rows.Count = 0 Then
            BuscarCentroCostoXInsumo = 0
        Else
            BuscarCentroCostoXInsumo = 1
        End If
    End Function

    Public Function ValidarNroFactura(ByVal NroProveedor As Long, ByVal NroFactura As String, ByVal TipoComprobante As Integer, ByVal LetraComprobante As Integer) As Long
        '---------------------------------------------------------------
        'Descripción: verifica si el nro de comprobamnte ya esta cargado
        'Parámetros : Nro de Proveedor, Nro de factura
        'Output     : 0 la factura no está cargada
        '             1 la factura ya esta cargada.
        '            -1 Error al buscar datos de factura.
        '-----------------------------------------------------
        Dim rec As New DataTable
        CadenaSql = ("select nrointerno from ComprobantesProveedores where tipocomp=" & LetraComprobante & " and desccomp=" & TipoComprobante & " and NroProveedor=" & NroProveedor & " and NroComp='" & NroFactura & "'")
        rec = ServidorSQl.GetTabla(CadenaSql)
        If rec Is Nothing Then
            Return -1
        ElseIf rec.Rows.Count = 0 Then
            ValidarNroFactura = 0
        Else
            ValidarNroFactura = 1
        End If
    End Function

    Public Function NuevoInterno(ByRef Proveedor As Long, ByRef DescCOmp As Long, ByRef Tipocomp As Long, ByRef NroComp As String, ByRef FechaComp As String, ByRef FechaCarga As String, ByRef FechaVtoComp As String, ByRef CondPago As Long, ByRef Observacion As String, ByRef IvaProd As String, ByRef ImporteProd As String, ByRef PercepIva As String, ByRef PercepGan As String, ByRef TotalPercepIB As String, ByRef ImporteNoImp As String, ByRef totalComp As String, ByVal CAI As String, ByVal CodBarra As String, ByVal Moneda As Integer, ByRef ItemsIB As DataTable, ByRef ItemsIngresos As DataTable, ByRef RstOC As DataTable, ByRef RstPS As DataTable, ByVal cotizacionDolar As String, ByVal cae As String, ByVal Pantalla As String, ByRef ChkPorCuentaTercero As Integer) As Long
        '-----------------------------------------------------
        'Descripción: Guarda un nuevo comprobante.
        'Parámetros : Todos los datos excepto NroInterno, el cual
        '             se genera automáticamente.
        'Output     : NroInterno generado
        '            -1 Error al guardar.
        '            -2 se alcanzó el nro máximo de nros
        '               internos, se debe hacer un reseed.
        '-----------------------------------------------------
        Dim Record As New DataTable
        Dim RstAux As New DataTable
        Dim Rst As New DataTable
        Dim tipoAutoriza As Integer
        Dim sumaTipoAutoriza As Integer
        Dim Grupo As Integer
        Dim oiva As String
        Dim oExento As String
        Dim oGravado As String
        Dim oTipoComp As String
        Dim oTNroComprobante As Double
        Dim oNroComprobante As Double
        Dim PrefijoAFacturar As Integer

        tipoAutoriza = 0
        sumaTipoAutoriza = 0
        If Pantalla = "CREDITODEBITOINT" Then
            Select Case DescCOmp
                Case 5, 14, 17, 19, 21 'Debitos Guma
                    Grupo = 10
                    oTipoComp = "D"
                Case 10, 12, 18, 20, 22 'Creditos Guma
                    Grupo = 9
                    oTipoComp = "C"

            End Select
        End If

        PrefijoAFacturar = 9997

        CadenaSql = "Select * from ctasctessql.dbo.Numeracion " &
        " where TipoComp like '" & oTipoComp & "' " &
        " AND Letra like 'X' " &
        " AND Prefijo= " & PrefijoAFacturar

        Rst = ServidorSQl.GetTabla(CadenaSql)

        If Rst Is Nothing Then
            MsgBox("Error al obtener numero para la creación del nuevo comprobante", vbCritical, "Error")
            Exit Function
            oTNroComprobante = 1
        Else
            For Each row As DataRow In Rst.Rows
                oTNroComprobante = Convert.ToInt32(row("numero")) + 1
                Dim a As String = PrefijoAFacturar & "00000000"
                oNroComprobante = Format(oTNroComprobante + Convert.ToInt64(a), "000000000000")
                Exit For
            Next
        End If
        Try
            CadenaSql = "INSERT INTO ComprobantesProveedores (NroProveedor, DescComp, TipoComp, NroComp, FechaComp, FechaCarga, FechaVto, CondicionPago, Observacion, IvaProd, ImporteProd, IvaFinan, ImporteFinan, PercepIva, PercepGan, TotalPercepIB, ImporteNoImp, TotalComprobante, codbarra, codestadopago, TipoGrupo, cotizaciondolar, porcuentadetercero) VALUES (" & Proveedor & "," & DescCOmp & ", " & Tipocomp & ", " & NroComp & ", '" & Format(CDate(FechaComp), "dd-MM-yyyy") & "', '" & Format(CDate(FechaCarga), "dd-MM-yyyy") & "', '" & Format(CDate(FechaVtoComp), "dd-MM-yyyy") & "', " & CondPago & ", '" & Left(Observacion, 200) & "', " & Val(Trim(IvaProd)) & ", " & Val(Trim(ImporteProd)) & ", 0, 0, " & Val(Trim(PercepIva)) & ", " & Val(Trim(PercepGan)) & ", " & Val(Trim(TotalPercepIB)) & ", " & Val(Trim(ImporteNoImp)) & ", " & Val(Trim(totalComp)) & ", '" & Left(CodBarra, 40) & "', 4, " & Grupo & ", " & Replace(cotizacionDolar, ",", ".") & ", " & Val(ChkPorCuentaTercero) & ")"
            If ServidorSQl.InsertTabla(CadenaSql) = 1 Then

                Record = ServidorSQl.GetTabla("select top 1 nrointerno from ComprobantesProveedores order by nrointerno desc")
                NuevoInterno = Convert.ToInt32(Record.Rows(0)("NroInterno"))

                If NuevoInterno = 100000000 Then
                    NuevoInterno = -2
                    Record = Nothing
                    RstAux = Nothing
                    Exit Function
                End If

                If ItemsIngresos IsNot Nothing AndAlso ItemsIngresos.Rows.Count > 0 Then
                    For Each row As DataRow In ItemsIngresos.Rows
                        If IsDBNull(row("Iva")) Then
                            oiva = "NULL"
                        Else
                            oiva = FormatoSQL(row("Iva").ToString())
                        End If

                        If IsDBNull(row("Gravado")) Then
                            oGravado = "NULL"
                        Else
                            oGravado = FormatoSQL(row("Gravado").ToString())
                        End If

                        If IsDBNull(row("Exento")) Then
                            oExento = "NULL"
                        Else
                            oExento = FormatoSQL(row("Exento").ToString())
                        End If

                        CadenaSql = "insert into ComprobantesOrdenes(NroInterno, NroIngreso, CodInsumo, Cantidad, Precio, DescInsumo, Total, CCosto, codautoriza, Iva, Gravado, Exento) values (" + NuevoInterno.ToString() + "," + row("nroingreso").ToString() + "," + row("codInsumo").ToString() + "," + FormatoSQL(row("cantidad").ToString()) + "," + FormatoSQL(Trim(row("precio").ToString())) + ",'" + Trim(Left(row("descinsumo").ToString(), 250)) + "'," + FormatoSQL(row("total").ToString()) + ", " + row("cc").ToString() + ", " + tipoAutoriza.ToString() + " , " + oiva + " , " + oGravado + ", " + oExento + ")"

                    Next
                End If
                If ServidorSQl.InsertTabla(CadenaSql) = 1 Then
                    If ServidorSQl.InsertTabla("Update ComprobantesProveedores set MarcaAcumulado='P' where NroInterno=" & NuevoInterno) = 1 Then
                        Return NuevoInterno
                    End If
                Else
                    Return -1
                    Exit Function
                End If
            Else
                Return -1
            End If
        Catch ex As Exception
            MsgBox("probando error", ex.Message)
        End Try
    End Function

    Public Function FormatoSQL(input As String) As String
        Return "'" & input.Replace("'", "''") & "'" '
    End Function


    Public Function AcumularComprobanteNuevo(NroInterno As Long) As Integer
        '-----------------------------------------------------
        'Descripción: Marca como 'I' al nuevo comprobante del sql
        'Parámetros : nro interno
        'Output     : 1 se actualizó con éxito.
        '            -1 Error al actualizar datos.
        '-----------------------------------------------------
        CadenaSql = "Update ComprobantesProveedores set MarcaAcumulado='I' where nrointerno = " & NroInterno
        Return ServidorSQl.InsertTabla(CadenaSql)
    End Function

    Public Function ObtenerNumeracion(ByRef rec As DataTable, ByRef prefijo As Integer, ByRef oTipoComp As String)
        CadenaSql = "Select * from ctasctessql.dbo.Numeracion " &
        " where TipoComp like '" & oTipoComp & "' " &
        " AND Letra like 'X' " &
        " AND Prefijo=" & prefijo

        rec = ServidorSQl.GetTabla(CadenaSql)
        If rec.Rows.Count = 0 Then
            Return -1
        Else
            Return 1
        End If
    End Function

    Public Function ObtenerNumeracionActualizada(ByRef prefijo As Integer, ByRef oTipoComp As String, ByRef oTNroComprobante As String)
        CadenaSql = "UPDATE ctasctessql.dbo.Numeracion SET numero = " & oTNroComprobante & " " &
    " where TipoComp like '" & oTipoComp & "' " &
        " AND Letra like 'X' " &
        " AND Prefijo=" & prefijo

        Return ServidorSQl.InsertTabla(CadenaSql)
    End Function
End Class
