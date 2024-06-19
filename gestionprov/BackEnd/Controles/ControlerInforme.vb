Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Security.Cryptography
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Modelos

Public Class ControlerInforme
    Inherits ServidorSQl
    Dim controlProveedores As New ControlerProveedor
    Public salida As Long
    Public Pasar As Boolean
    Public Registro As ModeloRegistroRetIB
    Public CadenaSQL As String
    Public RstAux As DataTable
    Public RstOP As DataTable
    Public Acumulado As Double
    Public AuxNroIngBrutos As String
    Public Rst As New DataTable()
    Public FechaComp As String

    Dim queryRetenciones As String = "SELECT dbo.DetalleLiquidaciones.NroInterno, dbo.DetalleLiquidaciones.ImportePagado,                         dbo.OP.NroOP, " &
                             "dbo.OP.ImporteRetIB, dbo.OP.PorceBaseImponible, dbo.ComprobantesProveedores.DescCOmp, " &
                             "dbo.ComprobantesProveedores.TipoGrupo FROM dbo.OP INNER JOIN dbo.Liquidaciones ON " &
                             "dbo.OP.NroLiquidacion = dbo.Liquidaciones.NroLiquidacion INNER JOIN dbo.DetalleLiquidaciones ON " &
                             "dbo.Liquidaciones.NroLiquidacion = dbo.DetalleLiquidaciones.NroLiquidacion INNER JOIN " &
                             "dbo.ComprobantesProveedores ON dbo.DetalleLiquidaciones.NroInterno = dbo.ComprobantesProveedores.NroInterno " &
                             "AND dbo.OP.NroProveedor = dbo.ComprobantesProveedores.NroProveedor WHERE dbo.OP.NroOp = "

#Region "Panel Diario"

    Public Function ObtenerInsumosdelDia(ByRef tabla As DataTable, ByVal Fecha As String) As Integer
        '-----------------------------------------------------
        ' Descripción: Obtiene insumos ingresados en el día Fecha
        ' Parámetros : fecha y DataTable
        ' Output     : 1 se encontraron datos.
        '              0 No se encontraron datos.
        '             -1 Error al filtrar datos.
        '-----------------------------------------------------
        Try
            CadenaSQL = "SELECT ComprobantesProveedores.NroProveedor, ComprobantesProveedores.TipoComp, ComprobantesProveedores.NroComp," _
            & " ComprobantesOrdenes.CodInsumo, ComprobantesOrdenes.Cantidad," _
            & " ComprobantesOrdenes.Precio, ComprobantesOrdenes.DescInsumo," _
            & " ComprobantesOrdenes.Total, ComprobantesOrdenes.Gravado," _
            & " (CASE WHEN ComprobantesOrdenes.Gravado IS NULL" _
            & " THEN ComprobantesOrdenes.Total" _
            & " ELSE" _
            & " CASE WHEN ComprobantesOrdenes.Gravado = 0 THEN" _
            & " ComprobantesOrdenes.Total" _
            & " ELSE" _
            & " ComprobantesOrdenes.Gravado" _
            & " END" _
            & " END) AS TOTALNUEVO," _
            & " Proveedor.RSocial, ComprobantesProveedores.desccomp, ComprobantesProveedores.TipoGrupo, ComprobantesProveedores.NroCompAlfanumerico" _
            & " FROM ComprobantesOrdenes INNER JOIN ComprobantesProveedores ON ComprobantesOrdenes.NroInterno = ComprobantesProveedores.NroInterno INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor" _
            & " WHERE ComprobantesProveedores.FechaCarga >= @FechaInicio AND ComprobantesProveedores.FechaCarga <= @FechaFin" _
            & " ORDER BY Codinsumo"

            ' Crear parámetros
            Dim parametros() As SqlParameter = {
            New SqlParameter("@FechaInicio", SqlDbType.DateTime) With {.Value = Date.ParseExact(Fecha & " 00:00:01", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)},
            New SqlParameter("@FechaFin", SqlDbType.DateTime) With {.Value = Date.ParseExact(Fecha & " 23:59:59", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)}
        }

            tabla = ServidorSQl.GetTablaParam(CadenaSQL, parametros)

            If tabla Is Nothing Then
                Return -1
            ElseIf tabla.Rows.Count = 0 Then
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            MsgBox("Error al obtener datos de la base. " & ex.ToString)
            Return -1
        End Try
    End Function


    Public Function ObtenerComprobantesdelDia(ByRef tabla As DataTable, ByVal Fecha As String) As Integer
        '-----------------------------------------------------
        ' Descripción: Obtiene comprobantes ingresados en el día Fecha
        ' Parámetros : fecha y DataTable por ref.
        ' Output     : 1 se encontraron datos.
        '              0 No se encontraron datos.
        '             -1 Error al filtrar datos.
        '-----------------------------------------------------

        Try
            ' Crear parámetros
            Dim parametros() As SqlParameter = {
            New SqlParameter("@FechaInicio", SqlDbType.DateTime) With {.Value = Date.ParseExact(Fecha & " 00:00:01", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)},
            New SqlParameter("@FechaFin", SqlDbType.DateTime) With {.Value = Date.ParseExact(Fecha & " 23:59:59", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)}
        }

            CadenaSQL = "SELECT ComprobantesProveedores.TipoComp, ComprobantesProveedores.NroComp, ComprobantesProveedores.DescComp," _
            & " ComprobantesProveedores.FechaComp, ComprobantesProveedores.FechaVto, CONVERT (date, ComprobantesProveedores.FechaCarga) as FechaCarga," _
            & " ComprobantesProveedores.IvaProd, " _
            & " CASE WHEN ComprobantesProveedores.TipoGrupo = 11 THEN 0 ELSE ComprobantesProveedores.ImporteProd END AS ImporteProd," _
            & " ComprobantesProveedores.PercepIva, ComprobantesProveedores.PercepGan, ComprobantesProveedores.TotalPercepIB, ComprobantesProveedores.ImporteNoImp," _
            & " CASE WHEN ComprobantesProveedores.TipoGrupo = 11 THEN ComprobantesProveedores.TotalComprobante ELSE (ComprobantesProveedores.IvaProd + ComprobantesProveedores.ImporteProd + ComprobantesProveedores.PercepIva + ComprobantesProveedores.PercepGan + ComprobantesProveedores.TotalPercepIB + ComprobantesProveedores.ImporteNoImp) END AS TotalComprobante," _
            & " ComprobantesProveedores.NroInterno, ComprobantesProveedores.NroPRoveedor, Proveedor.RSocial, ComprobantesProveedores.TipoGrupo, ComprobantesProveedores.NroCompAlfanumerico" _
            & " FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor" _
            & " WHERE ComprobantesProveedores.FechaCarga >= @FechaInicio AND ComprobantesProveedores.FechaCarga <= @FechaFin" _
            & " ORDER BY ComprobantesProveedores.NroInterno"

            tabla = ServidorSQl.GetTablaParam(CadenaSQL, parametros)

            If tabla Is Nothing Then
                Return -1
            ElseIf tabla.Rows.Count = 0 Then
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            Throw ex
            Return -1
        End Try
    End Function


    Public Function ObtenerControlDiario(ByVal Fecha As String, ByRef tabla As DataTable) As Integer
        '-----------------------------------------------------
        ' Descripción: Obtiene comprobantes ingresados hasta el día Fecha y todavía no pasados a DOS
        ' Parámetros : fecha y DataTable por ref.
        ' Output     : 1 se encontraron datos.
        '              0 No se encontraron datos.
        '             -1 Error al filtrar datos.
        '-----------------------------------------------------

        Try
            ' Crear parámetros
            Dim parametros() As SqlParameter = {
            New SqlParameter("@FechaInicio", SqlDbType.DateTime) With {.Value = Date.ParseExact(Fecha & " 00:00:01", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)},
            New SqlParameter("@FechaFin", SqlDbType.DateTime) With {.Value = Date.ParseExact(Fecha & " 23:59:59", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)}
        }

            ' Asegúrate de que la conexión esté configurada correctamente en ServidorSQl.GetTablaParam
            CadenaSQL = "SELECT ComprobantesProveedores.TipoComp, ComprobantesProveedores.NroComp, ComprobantesProveedores.DescComp," _
            & " ComprobantesProveedores.FechaComp, ComprobantesProveedores.IvaProd, ComprobantesProveedores.ImporteProd," _
            & " ComprobantesProveedores.PercepIva, ComprobantesProveedores.PercepGan, ComprobantesProveedores.TotalPercepIB," _
            & " ComprobantesProveedores.ImporteNoImp, ComprobantesProveedores.IvaProd + ComprobantesProveedores.ImporteProd + ComprobantesProveedores.PercepIva + ComprobantesProveedores.PercepGan + ComprobantesProveedores.TotalPercepIB + ComprobantesProveedores.ImporteNoImp AS TotalComprobante," _
            & " ComprobantesProveedores.NroInterno, ComprobantesOrdenes.NroIngreso, ComprobantesOrdenes.CodInsumo, ComprobantesOrdenes.DescInsumo, ComprobantesProveedores.FechaVto," _
            & " ComprobantesProveedores.NroPRoveedor, Proveedor.RSocial, ComprobantesProveedores.TipoGrupo " _
            & " FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor" _
            & " LEFT OUTER JOIN ComprobantesOrdenes ON ComprobantesProveedores.NroInterno = ComprobantesOrdenes.NroInterno" _
            & " WHERE ComprobantesProveedores.FechaCarga >= @FechaInicio AND ComprobantesProveedores.FechaCarga <= @FechaFin" _
            & " AND (ComprobantesProveedores.MarcaAcumulado <> 'A') " _
            & " ORDER BY ComprobantesOrdenes.NroInterno"

            tabla = ServidorSQl.GetTablaParam(CadenaSQL, parametros)

            If tabla Is Nothing Then
                Return -1
            ElseIf tabla.Rows.Count = 0 Then
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            Throw ex
            Return -1
        End Try
    End Function

#End Region

    Public Function ObtenerPercepcionGanancias(ByVal Mes As Integer, ByVal Anio As Integer, ByRef tabla As DataTable) As Integer
        '-----------------------------------------------------
        ' Descripción: Obtiene las retenciones de ganancias de un mes determinado cerrado
        ' Parámetros : mes y año por valor, DataTable por referencia
        ' Output     : 1 se encontraron datos.
        '              0 no se encontraron datos.
        '             -1 Error al buscar datos.
        '-----------------------------------------------------
        Try
            Dim MFecha As String = Mes.ToString("00") & "/" & Anio.ToString()

            CadenaSQL = "SELECT Proveedor.NroProveedor, Proveedor.RSocial, ComprobantesProveedores.DescComp, ComprobantesProveedores.TipoComp," _
                  & " ComprobantesProveedores.NroComp, ComprobantesProveedores.FechaComp, ComprobantesProveedores.NroInterno," _
                  & " (ComprobantesProveedores.PercepGan) as percepGan, Proveedor.Provincia" _
                  & " FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor" _
                  & " WHERE (ComprobantesProveedores.PercepGan) > 0 AND (ComprobantesProveedores.MESIMPUTACION = '" & MFecha & "')" _
                  & " ORDER BY ComprobantesProveedores.FechaComp, ComprobantesProveedores.NroProveedor"

            tabla = ServidorSQl.GetTabla(CadenaSQL)

            If tabla Is Nothing Then
                Return -1
            ElseIf tabla.Rows.Count = 0 Then
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            Throw ex
            Return -1
        End Try
    End Function


    Public Function ObtenerPercepcionGananciasDesdeHasta(ByVal MesImp As String, ByVal SeleccionoMes As Boolean, ByRef tabla As DataTable) As Integer
        '-----------------------------------------------------
        ' Descripción: Obtiene las retenciones de ganancias de un período de fecha determinado cerrado
        ' Parámetros : mes y año por valor, DataTable por referencia
        ' Output     : 1 se encontraron datos.
        '              0 no se encontraron datos.
        '             -1 Error al buscar datos.
        '-----------------------------------------------------
        Try
            CadenaSQL = "SELECT Proveedor.NroProveedor, Proveedor.RSocial, ComprobantesProveedores.DescComp, ComprobantesProveedores.TipoComp," _
              & " ComprobantesProveedores.NroComp, ComprobantesProveedores.FechaComp, ComprobantesProveedores.NroInterno," _
              & " (ComprobantesProveedores.PercepGan) as percepGan, Proveedor.Provincia" _
              & " FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor" _
              & " WHERE (ComprobantesProveedores.PercepGan) > 0 "


            CadenaSQL &= " AND (ComprobantesProveedores.MesImputacion IN (" & MesImp & ")) "


            CadenaSQL &= " ORDER BY ComprobantesProveedores.FechaComp, ComprobantesProveedores.NroProveedor"

            tabla = ServidorSQl.GetTabla(CadenaSQL)

            If tabla Is Nothing Then
                Return -1
            ElseIf tabla.Rows.Count = 0 Then
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            Throw ex
            Return -1
        End Try
    End Function


    Public Function ObtenerRetencionGanancias(ByVal SeleccionFechaIB As Boolean, ByVal Quincena1 As Boolean, ByVal Quincena2 As Boolean, ByVal Mes As Integer, ByVal Anio As Integer, ByRef tabla As DataTable, ByVal fechaDesde As String, ByVal fechaHasta As String) As Integer
        '-----------------------------------------------------
        ' Descripción: Obtiene las retenciones de ganancias de una quincena determinada
        ' Parámetros : mes, quincena y año por valor, DataTable por referencia
        ' Output     : 1 se encontraron datos.
        '              0 no se encontraron datos.
        '             -1 Error al buscar datos.
        '-----------------------------------------------------
        Dim Pasar As Boolean

        Try
            If SeleccionFechaIB = False Then
                CadenaSQL = "SELECT DISTINCT" &
            " dbo.OP.NroOP, dbo.NrosRetXOP.NroRet, dbo.NrosRetXOP.TipoRet, Prov.NroProveedor, Prov.RSocial, Prov.NroCUIT, TipoRet.Descripcion," &
            " dbo.OP.FechaCreacion, dbo.OP.ImporteRetIB, (CASE WHEN dbo.OP.ImporteNeto = 0 THEN 0 ELSE dbo.OP.ImporteRetIB / (dbo.OP.ImporteNeto * 0.8) * 100 END) AS Alicuota," &
            " dbo.OP.ImporteRetGan" &
            " FROM         dbo.OP INNER JOIN" &
            " dbo.NrosRetXOP ON dbo.OP.NroOP = dbo.NrosRetXOP.NroOp INNER JOIN" &
            " dbo.Proveedor Prov ON dbo.OP.NroProveedor = Prov.NroProveedor INNER JOIN" &
            " dbo.ValoresMinimosRetenciones TipoRet ON dbo.NrosRetXOP.TipoRet = TipoRet.CodTipoRet " &
            " WHERE (Year(OP.FechaCreacion) = " & Anio & " ) AND (Month(OP.FechaCreacion) = " & Mes & ") AND" &
            " (dbo.NrosRetXOP.TipoRet = 1)"
            Else  ' vengo por rango de fecha
                CadenaSQL = "SELECT DISTINCT" &
            " dbo.OP.NroOP, dbo.NrosRetXOP.NroRet, dbo.NrosRetXOP.TipoRet, Prov.NroProveedor, Prov.RSocial, Prov.NroCUIT, TipoRet.Descripcion," &
            " dbo.OP.FechaCreacion, dbo.OP.ImporteRetIB, (CASE WHEN dbo.OP.ImporteNeto = 0 THEN 0 ELSE dbo.OP.ImporteRetIB / (dbo.OP.ImporteNeto * 0.8) * 100 END) AS Alicuota," &
            " dbo.OP.ImporteRetGan" &
            " FROM         dbo.OP INNER JOIN" &
            " dbo.NrosRetXOP ON dbo.OP.NroOP = dbo.NrosRetXOP.NroOp INNER JOIN" &
            " dbo.Proveedor Prov ON dbo.OP.NroProveedor = Prov.NroProveedor INNER JOIN" &
            " dbo.ValoresMinimosRetenciones TipoRet ON dbo.NrosRetXOP.TipoRet = TipoRet.CodTipoRet " &
            " WHERE OP.FechaCreacion between '" & fechaDesde & "'  AND  '" & fechaHasta & "' AND" &
            " (dbo.NrosRetXOP.TipoRet = 1)"
            End If

            tabla = ServidorSQl.GetTabla(CadenaSQL)
            Dim tabla2 As New DataTable
            If SeleccionFechaIB Then
                tabla2.Columns.Add("NroProveedor", GetType(Integer))
                tabla2.Columns.Add("RazonSocial", GetType(String))
                tabla2.Columns.Add("NroOP", GetType(Integer))
                tabla2.Columns.Add("FechaComp", GetType(Date))
                tabla2.Columns.Add("Importe", GetType(Integer))
                tabla2.Columns.Add("NRete", GetType(Integer))
                tabla2.Columns.Add("Cuit", GetType(String))
                ' Si no se selecciona la fecha de la quincena, filtra los resultados
                For Each row As DataRow In tabla.Rows
                    Pasar = True
                    Dim FechaComp As String = Format(row("FechaCreacion"), "dd/MM/yyyy")
                    If Pasar Then
                        Dim newRow As DataRow = tabla2.NewRow()
                        newRow("NroProveedor") = Trim(row("NroProveedor"))
                        newRow("RazonSocial") = Trim(row("RSocial"))
                        newRow("NroOP") = row("NroOP")
                        newRow("FechaComp") = CDate(Format(row("FechaCreacion"), "dd/MM/yyyy"))
                        newRow("Importe") = row("ImporteRetGan")
                        newRow("NRete") = row("NroRet")
                        newRow("Cuit") = Trim(row("NroCuit"))
                        tabla2.Rows.Add(newRow)
                    End If

                Next
            Else
                tabla2.Columns.Add("NroProveedor", GetType(Integer))
                tabla2.Columns.Add("RazonSocial", GetType(String))
                tabla2.Columns.Add("NroOP", GetType(Integer))
                tabla2.Columns.Add("FechaComp", GetType(Date))
                tabla2.Columns.Add("Importe", GetType(Integer))
                tabla2.Columns.Add("NRete", GetType(Integer))
                tabla2.Columns.Add("Cuit", GetType(String))
                ' Si no se selecciona la fecha de la quincena, filtra los resultados
                For Each row As DataRow In tabla.Rows
                    Pasar = False
                    Dim FechaComp As String = Format(row("FechaCreacion"), "dd/MM/yyyy")

                    If Year(CDate(Left(FechaComp, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) = Anio Then
                        If Month(CDate(Left(FechaComp, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) = Mes Then
                            If Quincena1 AndAlso Day(CDate(Mid(FechaComp, 1, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) <= 15 Then
                                Pasar = True
                            Else
                                If Quincena1 Then
                                    Pasar = False
                                ElseIf Quincena2 AndAlso Day(CDate(Mid(FechaComp, 1, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) > 15 Then
                                    Pasar = True
                                Else
                                    Pasar = True
                                End If
                            End If
                            If Pasar Then
                                Dim newRow As DataRow = tabla2.NewRow()
                                newRow("NroProveedor") = Trim(row("NroProveedor"))
                                newRow("RazonSocial") = Trim(row("RSocial"))
                                newRow("NroOP") = row("NroOP")
                                newRow("FechaComp") = CDate(Format(row("FechaCreacion"), "dd/MM/yyyy"))
                                newRow("Importe") = row("ImporteRetGan")
                                newRow("NRete") = row("NroRet")
                                newRow("Cuit") = Trim(row("NroCuit"))
                                tabla2.Rows.Add(newRow)
                            End If
                        End If
                    End If
                Next
            End If
            tabla = tabla2

            If tabla.Rows.Count > 0 Then
                Return 1
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw ex
            Return -1
        End Try
    End Function


    Public Function ObtenerRetencionIBCordoba(ByVal SeleccionFechaIB As Boolean, ByVal Quincena1 As Boolean, ByVal Quincena2 As Boolean, ByVal Mes As Integer, ByVal Anio As Integer, ByRef rec As DataTable, ByVal fechaDesde As String, ByVal fechaHasta As String) As Long
        ' Inicializar DataTable
        rec = New DataTable()
        rec.Columns.Add("RazonSocial", GetType(String))
        rec.Columns.Add("NroProveedor", GetType(Double))
        rec.Columns.Add("IngBrutos", GetType(String))
        rec.Columns.Add("InscDir", GetType(String))
        rec.Columns.Add("ProdServ", GetType(String))
        rec.Columns.Add("BaseImp", GetType(Double))
        rec.Columns.Add("Alicuota", GetType(String))
        rec.Columns.Add("ImpRetenido", GetType(Double))
        rec.Columns.Add("Constancia", GetType(Double))
        rec.Columns.Add("NroOp", GetType(Integer))
        rec.Columns.Add("FechaOP", GetType(Date))

        '***************************************************
        ' Buscar comprobantes en la base de datos utilizando ServidorSQL
        If SeleccionFechaIB Then
            Dim CadenaSQL As String = If(CDate(fechaHasta) < CDate("01/11/2009"),
                                     "SELECT * FROM VistaRetencionesIIBBCbaAntes112009 WHERE FechaCreacion >= @fechaDesde AND FechaCreacion <= @fechaHasta",
                                     "SELECT * FROM VistaRetencionesIIBBCba WHERE FechaCreacion >= @fechaDesde AND FechaCreacion <= @fechaHasta")

            ' Ejecutar consulta utilizando ServidorSQL
            Dim parametrosConsulta As SqlParameter() = {
            New SqlParameter("@fechaDesde", fechaDesde),
            New SqlParameter("@fechaHasta", fechaHasta)
        }

            Dim RstAux As DataTable = ServidorSQl.GetTablaParam(CadenaSQL, parametrosConsulta)

            For Each row As DataRow In RstAux.Rows
                ' Lógica de procesamiento aquí
                Dim RstOP As DataTable = ObtenerRstOP(row("NroOP").ToString()) ' Debes definir la función ObtenerRstOP

                ' Procesar RstOP
                Dim Acumulado As Double = 0
                If RstOP IsNot Nothing AndAlso Not RstOP.Rows.Count = 0 Then
                    For Each opRow As DataRow In RstOP.Rows
                        If Not ((Convert.ToInt32(opRow("TipoGrupo")) = 6 And Convert.ToInt32(opRow("DescCOmp")) = 13) Or
                        (Convert.ToInt32(opRow("TipoGrupo")) = 4 And Convert.ToInt32(opRow("DescCOmp")) = 11) Or
                        (Convert.ToInt32(opRow("DescCOmp")) = 12) Or (Convert.ToInt32(opRow("DescCOmp")) = 5)) Then
                            Acumulado += Convert.ToDouble(opRow("importepagado"))
                        End If
                    Next
                End If

                ' Agregar datos al DataTable rec
                Dim newRow As DataRow = rec.NewRow()
                newRow("NroOp") = Trim(row("NroOP"))
                newRow("FechaOP") = Trim(row("FechaCreacion"))
                newRow("RazonSocial") = Trim(row("RSocial"))
                newRow("NroProveedor") = Convert.ToInt32(row("NroProveedor"))

                If Mid(UCase(Trim(row("IngBrutos"))), 1, 14) <> "NO SE POSEE" Then
                    newRow("IngBrutos") = Trim(row("IngBrutos"))
                    newRow("InscDir") = ""
                Else
                    Dim salida As Integer
                    Dim Rst As New DataTable()

                    salida = controlProveedores.buscarProveedor(Convert.ToInt32(row("NroProveedor")), Rst)
                    If salida = -1 Then
                        'GoTo ErrorArchivos
                    ElseIf salida = 0 Then
                        newRow("IngBrutos") = Trim(Registro.NroIB)
                        newRow("InscDir") = ""
                    Else
                        If Rst.Rows.Count > 0 Then
                            newRow("IngBrutos") = Left(Trim(Rst.Rows(0)("Direccion")), 12)
                            newRow("InscDir") = Trim(Rst.Rows(0)("Localidad"))
                        End If
                    End If
                End If

                ' Código adicional que solicitaste
                newRow("ProdServ") = Left(Trim(row("TipoCuit")), 50)
                newRow("BaseImp") = row("BaseImponible")

                If CDate(fechaDesde) <= CDate("01/11/2009") Then
                    newRow("Alicuota") = Format((row("ImporteRetIB") / (Acumulado * 0.8)) * 100, "0.00")
                Else
                    If Year(fechaDesde) = 2014 And Month(fechaDesde) = 11 And newRow("FechaOP") < CDate("16/11/2014") Then
                        If CInt(row("Alicuota")) = 7 Then
                            newRow("Alicuota") = Format("3.5", "#,##0.00")
                            newRow("ImpRetenido") = row("ImporteRetIB") / 2
                        Else
                            newRow("Alicuota") = Format(row("Alicuota"), "#,##0.00")
                            newRow("ImpRetenido") = row("ImporteRetIB")
                        End If
                    Else
                        newRow("Alicuota") = Format(row("Alicuota"), "#,##0.00")
                        newRow("ImpRetenido") = row("ImporteRetIB")
                    End If
                End If

                newRow("Constancia") = row("NroRet")
                rec.Rows.Add(newRow)
            Next
        Else
            CadenaSQL = If(Anio <= 2009 And Mes < 11,
    "SELECT * FROM VistaRetencionesIIBBCbaAntes112009 WHERE (Year(FechaCreacion) = @Anio) And (Month(FechaCreacion) = @Mes)",
    "SELECT * FROM VistaRetencionesIIBBCba WHERE (Year(FechaCreacion) = @Anio) And (Month(FechaCreacion) = @Mes)")

            Dim parametros As SqlParameter() = {
                New SqlParameter("@Anio", Anio),
                New SqlParameter("@Mes", Mes)
            }

            Dim RstAux As DataTable = ServidorSQl.GetTablaParam(CadenaSQL, parametros)

            For Each row As DataRow In RstAux.Rows
                Dim Pasar As Boolean = False
                Dim FechaComp As String = Format(row("FechaCreacion"), "dd/MM/yyyy")

                If Year(CDate(Left(FechaComp, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) = Anio Then
                    If Month(CDate(Left(FechaComp, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) = Mes Then
                        If Quincena1 And Day(CDate(Mid(FechaComp, 1, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) <= 15 Then
                            Pasar = True
                        Else
                            If Quincena1 Then
                                Pasar = False
                            ElseIf Quincena2 Then
                                Pasar = Day(CDate(Mid(FechaComp, 1, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) > 15
                            Else
                                Pasar = True
                            End If
                        End If

                        CadenaSQL = "SELECT dbo.DetalleLiquidaciones.NroInterno, dbo.DetalleLiquidaciones.ImportePagado, dbo.OP.NroOP, dbo.OP.ImporteRetIB, dbo.OP.PorceBaseImponible," &
                            "dbo.ComprobantesProveedores.DescCOmp, dbo.ComprobantesProveedores.TipoGrupo" &
                            " FROM dbo.OP INNER JOIN" &
                            " dbo.Liquidaciones ON dbo.OP.NroLiquidacion = dbo.Liquidaciones.NroLiquidacion INNER JOIN" &
                            " dbo.DetalleLiquidaciones ON dbo.Liquidaciones.NroLiquidacion = dbo.DetalleLiquidaciones.NroLiquidacion INNER JOIN" &
                            " dbo.ComprobantesProveedores ON dbo.DetalleLiquidaciones.NroInterno = dbo.ComprobantesProveedores.NroInterno AND" &
                            " dbo.OP.NroProveedor = dbo.ComprobantesProveedores.NroProveedor" &
                            " WHERE (dbo.OP.NroOp) = " & Val(row("NroOP"))

                        Dim RstOP As New DataTable()
                        Dim parametrosConsultaOP As SqlParameter() = {
                            New SqlParameter("@NroOP", Val(row("NroOP")))
                        }

                        RstOP = ServidorSQl.GetTablaParam("SELECT dbo.DetalleLiquidaciones.NroInterno, dbo.DetalleLiquidaciones.ImportePagado, dbo.OP.NroOP, dbo.OP.ImporteRetIB, dbo.OP.PorceBaseImponible," &
                            "dbo.ComprobantesProveedores.DescCOmp, dbo.ComprobantesProveedores.TipoGrupo" &
                            " FROM dbo.OP INNER JOIN" &
                            " dbo.Liquidaciones ON dbo.OP.NroLiquidacion = dbo.Liquidaciones.NroLiquidacion INNER JOIN" &
                            " dbo.DetalleLiquidaciones ON dbo.Liquidaciones.NroLiquidacion = dbo.DetalleLiquidaciones.NroLiquidacion INNER JOIN" &
                            " dbo.ComprobantesProveedores ON dbo.DetalleLiquidaciones.NroInterno = dbo.ComprobantesProveedores.NroInterno AND" &
                            " dbo.OP.NroProveedor = dbo.ComprobantesProveedores.NroProveedor" &
                            " WHERE (dbo.OP.NroOp) = @NroOP", parametrosConsultaOP)

                        If RstOP.Rows.Count > 0 Then
                            Dim Acumulado As Double = 0
                            For Each opRow As DataRow In RstOP.Rows
                                If (Not CBool(opRow("TipoGrupo") = 6 AndAlso opRow("DescCOmp") = 13)) AndAlso
                                    (Not CBool(opRow("TipoGrupo") = 4 AndAlso opRow("DescCOmp") = 11)) AndAlso
                                    (Not opRow("DescCOmp") = 12) AndAlso
                                    (Not opRow("DescCOmp") = 5) Then
                                    Acumulado += CDbl(opRow("ImportePagado"))
                                End If
                            Next
                        End If

                        If Pasar Then
                            Dim nuevaFila As DataRow = rec.NewRow()
                            nuevaFila("NroOP") = Trim(row("NroOP"))
                            nuevaFila("FechaOP") = Trim(row("FechaCreacion"))
                            nuevaFila("RazonSocial") = Trim(row("RSocial"))
                            nuevaFila("NroProveedor") = Val(row("NroProveedor"))
                            nuevaFila("IngBrutos") = Val(row("IngBrutos"))
                            nuevaFila("ProdServ") = Trim(row("TipoCuit"))
                            nuevaFila("BaseImp") = Val(row("BaseImponible"))
                            nuevaFila("Alicuota") = Val(row("Alicuota"))
                            nuevaFila("ImpRetenido") = Val(row("ImporteRetIB"))
                            nuevaFila("Constancia") = Val(row("NroRet"))

                            rec.Rows.Add(nuevaFila)
                        End If ' Pasar

                    End If ' Mes
                End If ' Año
            Next
        End If

        If rec.Rows.Count > 0 Then
            Return 1
        Else
            Return 0
        End If
    End Function




    Public Function ObtenerRetencionIBBsAs(ByVal SeleccionFechaIB As Boolean, ByVal Quincena1 As Boolean, ByVal Quincena2 As Boolean, ByVal Mes As Integer, ByVal Anio As Integer, ByRef rec As DataTable, ByVal fechaDesde As String, ByVal fechaHasta As String) As Integer

        Dim recRetencionesIB As DataTable
        Dim respuesta As Integer


        rec = New DataTable
        rec.Columns.Add("RazonSocial", GetType(String))
        rec.Columns.Add("NroProveedor", GetType(Double))
        rec.Columns.Add("IngBrutos", GetType(String))
        rec.Columns.Add("InscDir", GetType(String))
        rec.Columns.Add("ProdServ", GetType(String))
        rec.Columns.Add("BaseImp", GetType(Double))
        rec.Columns.Add("Alicuota", GetType(String))
        rec.Columns.Add("ImpRetenido", GetType(Double))
        rec.Columns.Add("Constancia", GetType(Double))
        rec.Columns.Add("NroOp", GetType(Integer))
        rec.Columns.Add("FechaOP", GetType(Date))
        If SeleccionFechaIB Then
            If CDate(fechaHasta) < CDate("01/11/2009") Then
                CadenaSQL = "SELECT * FROM VistaRetencionesIIBBBsAsAntes112009 " &
                             " WHERE FechaCreacion >= '" & fechaDesde & "' AND FechaCreacion <= '" & fechaHasta & "' "
            Else
                CadenaSQL = "SELECT * FROM VistaRetencionesIIBBBsAs " &
                             " WHERE FechaCreacion >= '" & fechaDesde & "' AND FechaCreacion <= '" & fechaHasta & "' "
            End If

            '***********************************************
            'Modificar la siguiente línea según la clase ServidorSql
            recRetencionesIB = ServidorSQl.GetTabla(CadenaSQL)
            '***********************************************

            For Each row As DataRow In recRetencionesIB.Rows
                Pasar = False

                CadenaSQL = "SELECT dbo.DetalleLiquidaciones.NroInterno, dbo.DetalleLiquidaciones.ImportePagado, dbo.OP.NroOP, " &
                             "dbo.OP.ImporteRetIB, dbo.OP.PorceBaseImponible, dbo.ComprobantesProveedores.DescCOmp, " &
                             "dbo.ComprobantesProveedores.TipoGrupo FROM dbo.OP INNER JOIN dbo.Liquidaciones ON " &
                             "dbo.OP.NroLiquidacion = dbo.Liquidaciones.NroLiquidacion INNER JOIN dbo.DetalleLiquidaciones ON " &
                             "dbo.Liquidaciones.NroLiquidacion = dbo.DetalleLiquidaciones.NroLiquidacion INNER JOIN " &
                             "dbo.ComprobantesProveedores ON dbo.DetalleLiquidaciones.NroInterno = dbo.ComprobantesProveedores.NroInterno " &
                             "AND dbo.OP.NroProveedor = dbo.ComprobantesProveedores.NroProveedor WHERE dbo.OP.NroOp = " & row("NroOP")

                '***********************************************
                'Modificar la siguiente línea según la clase ServidorSql
                Dim RstOP As DataTable = ServidorSQl.GetTabla(CadenaSQL)
                '***********************************************

                If RstOP.Rows.Count > 0 Then
                    Acumulado = 0
                    For Each opRow As DataRow In RstOP.Rows
                        If Not ((opRow("TipoGrupo") = 6 And opRow("DescCOmp") = 13) Or (opRow("TipoGrupo") = 4 And opRow("DescCOmp") = 11) Or (opRow("DescCOmp") = 12) Or (opRow("DescCOmp") = 5)) Then
                            Acumulado += Convert.ToDouble(opRow("ImportePagado"))
                        End If
                    Next
                End If

                Dim recRow As DataRow = rec.NewRow()
                recRow("NroOP") = Convert.ToInt32(row("NroOP"))
                recRow("RazonSocial") = Convert.ToString(row("RSocial"))
                recRow("NroProveedor") = Convert.ToDouble(row("NroProveedor"))
                If Mid(UCase(Convert.ToString(row("IngBrutos"))), 1, 13) <> "NO SE POSEE" Then
                    recRow("IngBrutos") = Trim(Convert.ToString(row("IngBrutos")))
                    recRow("InscDir") = ""
                Else
                    salida = controlProveedores.BuscarPorNroProveedor(Convert.ToInt32(row("NroProveedor")), Rst)
                    If salida = -1 Then
                        GoTo ErrorArchivos
                    ElseIf salida = 0 Then
                        recRow("IngBrutos") = Trim(Registro.NroIB)
                        recRow("InscDir") = ""
                    Else
                        recRow("IngBrutos") = Left(Trim(Convert.ToString(Rst.Rows(0)("Direccion"))), 12)
                        recRow("InscDir") = Trim(Convert.ToString(Rst.Rows(0)("Localidad")))
                    End If
                End If

                recRow("ProdServ") = Left(Trim(Convert.ToString(row("TipoCuit"))), 50)

                '***********************************************
                'Modificar la siguiente línea según la clase ServidorSql
                Dim recRetencionesIBRow As DataTable = New DataTable()
                respuesta = RecuperarIngresoBrutoDeOP(Convert.ToString(row("NroOP")), recRetencionesIBRow)
                '***********************************************

                If recRetencionesIBRow.Rows.Count > 0 Then
                    recRow("BaseImp") = Convert.ToDouble(recRetencionesIBRow.Rows(0)("Base"))
                    recRow("Alicuota") = Convert.ToString(recRetencionesIBRow.Rows(0)("Alicuota"))
                    recRow("ImpRetenido") = Convert.ToDouble(recRetencionesIBRow.Rows(0)("ImpPercepcion"))
                End If

                recRow("Constancia") = Convert.ToDouble(row("NroRet"))
                rec.Rows.Add(recRow)
            Next
        Else
            If Anio <= 2009 And Mes < 11 Then
                CadenaSQL = "SELECT * FROM VistaRetencionesIIBBBsAsAntes112009 " &
                             " WHERE Year(FechaCreacion) = " & Anio & " AND Month(FechaCreacion) = " & Mes
            Else
                CadenaSQL = "SELECT * FROM VistaRetencionesIIBBBsAs " &
                             " WHERE Year(FechaCreacion) = " & Anio & " AND Month(FechaCreacion) = " & Mes
            End If

            '***********************************************
            'Modificar la siguiente línea según la clase ServidorSql
            Dim RstAux As DataTable = ServidorSQl.GetTabla(CadenaSQL)
            '***********************************************

            For Each row As DataRow In RstAux.Rows
                Pasar = False

                Dim FechaComp As String = Format(Convert.ToDateTime(row("FechaCreacion")), "dd/MM/yyyy")

                If Year(CDate(Left(FechaComp, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) = Anio Then
                    If Month(CDate(Left(FechaComp, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) = Mes Then

                        If Quincena1 And Day(CDate(Mid(FechaComp, 1, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) <= 15 Then
                            Pasar = True
                        Else
                            If Quincena1 Then
                                Pasar = False
                            ElseIf Quincena2 Then
                                Pasar = Day(CDate(Mid(FechaComp, 1, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) > 15
                            Else
                                Pasar = True
                            End If
                        End If

                        CadenaSQL = "SELECT dbo.DetalleLiquidaciones.NroInterno, dbo.DetalleLiquidaciones.ImportePagado, " &
                                     "dbo.OP.NroOP, dbo.OP.ImporteRetIB, dbo.OP.PorceBaseImponible, dbo.ComprobantesProveedores.DescCOmp, " &
                                     "dbo.ComprobantesProveedores.TipoGrupo FROM dbo.OP INNER JOIN dbo.Liquidaciones ON " &
                                     "dbo.OP.NroLiquidacion = dbo.Liquidaciones.NroLiquidacion INNER JOIN dbo.DetalleLiquidaciones ON " &
                                     "dbo.Liquidaciones.NroLiquidacion = dbo.DetalleLiquidaciones.NroLiquidacion INNER JOIN " &
                                     "dbo.ComprobantesProveedores ON dbo.DetalleLiquidaciones.NroInterno = dbo.ComprobantesProveedores.NroInterno " &
                                     "AND dbo.OP.NroProveedor = dbo.ComprobantesProveedores.NroProveedor WHERE dbo.OP.NroOp = " & row("NroOP")

                        '***********************************************
                        'Modificar la siguiente línea según la clase ServidorSql
                        Dim RstOP As DataTable = ServidorSQl.GetTabla(CadenaSQL)
                        '***********************************************

                        If RstOP.Rows.Count > 0 Then
                            Acumulado = 0
                            For Each opRow As DataRow In RstOP.Rows
                                If Not ((opRow("TipoGrupo") = 6 And opRow("DescCOmp") = 13) Or (opRow("TipoGrupo") = 4 And opRow("DescCOmp") = 11) Or (opRow("DescCOmp") = 12) Or (opRow("DescCOmp") = 5)) Then
                                    Acumulado += Convert.ToDouble(opRow("ImportePagado"))
                                End If
                            Next
                        End If

                        If Pasar Then
                            Dim recRow As DataRow = rec.NewRow()
                            recRow("NroOP") = Convert.ToInt32(row("NroOP"))
                            recRow("RazonSocial") = Convert.ToString(row("RSocial"))
                            recRow("NroProveedor") = Convert.ToDouble(row("NroProveedor"))

                            If Mid(UCase(Convert.ToString(row("IngBrutos"))), 1, 14) <> "NO SE POSEE" Then
                                recRow("IngBrutos") = Trim(Convert.ToString(row("IngBrutos")))
                                recRow("InscDir") = ""
                            Else
                                salida = controlProveedores.BuscarPorNroProveedor(Convert.ToInt32(row("NroProveedor")), Rst)
                                If salida = -1 Then
                                    GoTo ErrorArchivos
                                ElseIf salida = 0 Then
                                    recRow("IngBrutos") = Trim(Registro.NroIB)
                                    recRow("InscDir") = ""
                                Else
                                    recRow("IngBrutos") = Left(Trim(Convert.ToString(Rst.Rows(0)("Direccion"))), 12)
                                    recRow("InscDir") = Trim(Convert.ToString(Rst.Rows(0)("Localidad")))
                                End If
                            End If

                            recRow("ProdServ") = Left(Trim(Convert.ToString(row("TipoCuit"))), 50)

                            '***********************************************
                            'Modificar la siguiente línea según la clase ServidorSql
                            Dim recRetencionesIBRow As DataTable = New DataTable()
                            respuesta = RecuperarIngresoBrutoDeOP(Convert.ToString(row("NroOP")), recRetencionesIBRow)
                            '***********************************************

                            If recRetencionesIBRow.Rows.Count > 0 Then
                                recRow("BaseImp") = Convert.ToDouble(recRetencionesIBRow.Rows(0)("Base"))
                                recRow("Alicuota") = Convert.ToString(recRetencionesIBRow.Rows(0)("Alicuota"))
                                recRow("ImpRetenido") = Convert.ToDouble(recRetencionesIBRow.Rows(0)("ImpPercepcion"))
                            End If

                            recRow("Constancia") = Convert.ToDouble(row("NroRet"))
                            rec.Rows.Add(recRow)
                        End If 'Pasar
                    End If 'Mes
                End If 'Año
            Next
        End If

        If rec.Rows.Count > 0 Then
            salida = 1
        Else
            salida = 0
        End If

        Return salida

ErrorArchivos:
        'Cerrar conexiones y manejar el error según tu lógica
        Return -1
    End Function


    Private Shared Function RecuperarIngresoBrutoDeOP(ByVal NroOP As Long, ByRef tabla As DataTable) As Integer
        Dim query As String
        On Error GoTo errores
        query = "select * from dbo.DetalleOPxIB where  nroop = " & NroOP
        tabla = ServidorSQl.GetTabla(query)
        If tabla Is Nothing Then
            GoTo errores
        ElseIf tabla Is Nothing Then
            RecuperarIngresoBrutoDeOP = 0
        Else
            RecuperarIngresoBrutoDeOP = 1
        End If
        Exit Function
errores:
        RecuperarIngresoBrutoDeOP = -1
    End Function



    Private Shared Function ObtenerRstOP(ByVal nroOP As String) As DataTable
        ' Ejemplo de creación de una DataTable ficticia para pruebas
        Dim dt As New DataTable()
        dt.Columns.Add("TipoGrupo", GetType(Integer))
        dt.Columns.Add("DescCOmp", GetType(Integer))
        dt.Columns.Add("importepagado", GetType(Double))

        ' Agregar datos ficticios
        dt.Rows.Add(6, 13, 100.0)
        dt.Rows.Add(4, 11, 150.0)
        dt.Rows.Add(12, 8, 200.0)

        Return dt
    End Function

    Public Function ObtenerRetencionIBSanLuis(ByVal SeleccionFechaIB As Boolean, ByVal Quincena1 As Boolean, ByVal Quincena2 As Boolean, ByVal Mes As Integer, ByVal Anio As Integer, ByRef rec As DataTable, ByVal fechaDesde As String, ByVal fechaHasta As String) As Integer
        Dim recRetencionesIB As DataTable
        Dim respuesta As Integer
        Dim rec1 As DataTable = New DataTable()
        rec.Columns.Add("RazonSocial", GetType(String))
        rec.Columns.Add("NroProveedor", GetType(Double))
        rec.Columns.Add("IngBrutos", GetType(String))
        rec.Columns.Add("InscDir", GetType(String))
        rec.Columns.Add("ProdServ", GetType(String))
        rec.Columns.Add("BaseImp", GetType(Double))
        rec.Columns.Add("Alicuota", GetType(String))
        rec.Columns.Add("ImpRetenido", GetType(Double))
        rec.Columns.Add("Constancia", GetType(Double))
        rec.Columns.Add("NroOp", GetType(Integer))
        rec.Columns.Add("FechaOP", GetType(Date))
        ' Lógica principal
        CadenaSQL = "SELECT * FROM VistaRetencionesIIBBSanLuis WHERE (Year(FechaCreacion) = " & Anio & ") And (Month(FechaCreacion) = " & Mes & ")"

        rec1 = ServidorSQl.GetTabla(CadenaSQL)

        If SeleccionFechaIB Then
            If CDate(fechaHasta) < CDate("01/11/2009") Then
                CadenaSQL = "SELECT * FROM VistaRetencionesIIBBSanLuisntes112009 " &
                             " WHERE FechaCreacion >= '" & fechaDesde & "' AND FechaCreacion <= '" & fechaHasta & "' "
            Else
                CadenaSQL = "SELECT * FROM VistaRetencionesIIBBSanLuis " &
                             " WHERE FechaCreacion >= '" & fechaDesde & "' AND FechaCreacion <= '" & fechaHasta & "' "
            End If

            '***********************************************
            'Modificar la siguiente línea según la clase ServidorSql
            recRetencionesIB = ServidorSQl.GetTabla(CadenaSQL)
            '***********************************************

            For Each row As DataRow In recRetencionesIB.Rows
                Pasar = False

                CadenaSQL = queryRetenciones & row("NroOP")

                '***********************************************
                'Modificar la siguiente línea según la clase ServidorSql
                Dim RstOP As DataTable = ServidorSQl.GetTabla(CadenaSQL)
                '***********************************************

                If RstOP.Rows.Count > 0 Then
                    Acumulado = 0
                    For Each opRow As DataRow In RstOP.Rows
                        If Not ((opRow("TipoGrupo") = 6 And opRow("DescCOmp") = 13) Or (opRow("TipoGrupo") = 4 And opRow("DescCOmp") = 11) Or (opRow("DescCOmp") = 12) Or (opRow("DescCOmp") = 5)) Then
                            Acumulado += Convert.ToDouble(opRow("ImportePagado"))
                        End If
                    Next
                End If

                Dim recRow As DataRow = rec.NewRow()
                recRow("NroOP") = Convert.ToInt32(row("NroOP"))
                recRow("RazonSocial") = Convert.ToString(row("RSocial"))
                recRow("NroProveedor") = Convert.ToDouble(row("NroProveedor"))
                If Mid(UCase(Convert.ToString(row("IngBrutos"))), 1, 13) <> "NO SE POSEE" Then
                    recRow("IngBrutos") = Trim(Convert.ToString(row("IngBrutos")))
                    recRow("InscDir") = ""
                Else
                    salida = controlProveedores.BuscarPorNroProveedor(Convert.ToInt32(row("NroProveedor")), Rst)
                    If salida = -1 Then
                        GoTo ErrorArchivos
                    ElseIf salida = 0 Then
                        recRow("IngBrutos") = Trim(Registro.NroIB)
                        recRow("InscDir") = ""
                    Else
                        recRow("IngBrutos") = Left(Trim(Convert.ToString(Rst.Rows(0)("Direccion"))), 12)
                        recRow("InscDir") = Trim(Convert.ToString(Rst.Rows(0)("Localidad")))
                    End If
                End If

                recRow("ProdServ") = Left(Trim(Convert.ToString(row("TipoCuit"))), 50)

                '***********************************************
                'Modificar la siguiente línea según la clase ServidorSql
                Dim recRetencionesIBRow As DataTable = New DataTable()
                respuesta = RecuperarIngresoBrutoDeOP(Convert.ToString(row("NroOP")), recRetencionesIBRow)
                '***********************************************

                If recRetencionesIBRow.Rows.Count > 0 Then
                    recRow("BaseImp") = Convert.ToDouble(recRetencionesIBRow.Rows(0)("Base"))
                    recRow("Alicuota") = Convert.ToString(recRetencionesIBRow.Rows(0)("Alicuota"))
                    recRow("ImpRetenido") = Convert.ToDouble(recRetencionesIBRow.Rows(0)("ImpPercepcion"))
                End If

                recRow("Constancia") = Convert.ToDouble(row("NroRet"))
                rec.Rows.Add(recRow)
            Next


        Else
            For Each auxRow As DataRow In rec1.Rows
                Pasar = False
                Dim FechaComp As String = Format(Convert.ToDateTime(auxRow("FechaCreacion")), "dd/MM/yyyy")
                If Quincena1 And Day(CDate(Mid(FechaComp, 1, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) <= 15 Then
                    Pasar = True
                Else
                    If Quincena1 Then
                        Pasar = False
                    ElseIf Quincena2 Then
                        Pasar = Day(CDate(Mid(FechaComp, 1, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) > 15
                    Else
                        Pasar = True
                    End If
                End If
                FechaComp = Format(Convert.ToDateTime(auxRow!FechaCreacion), "dd/MM/yyyy")

                If Year(CDate(Left(FechaComp, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) = Anio Then
                    If Month(CDate(Left(FechaComp, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) = Mes Then
                        If Pasar = True Then
                            ' Ejemplo de uso de DataRow para agregar datos a DataTable
                            Dim row As DataRow = rec.NewRow()
                            row("NroOp") = Trim(auxRow!NroOP)
                            row("RazonSocial") = Trim(auxRow!RSocial)
                            row("NroProveedor") = Val(auxRow!NroProveedor)
                            row("IngBrutos") = If(Mid(UCase(Trim(auxRow!IngBrutos)), 1, 14) <> "NO SE POSEE", Trim(Left(Trim(Replace(Replace(auxRow!IngBrutos, "-", ""), " ", "")) & Space(14), 14)), "")
                            row("InscDir") = If(Mid(UCase(Trim(auxRow!IngBrutos)), 1, 14) <> "NO SE POSEE", "", "")
                            row("ProdServ") = If(IsDBNull(auxRow!TipoCuit), "", Left(Trim(auxRow!TipoCuit), 50))
                            row("BaseImp") = If(IsDBNull(auxRow!BaseImponible), 0, Convert.ToDouble(auxRow!BaseImponible))
                            row("Alicuota") = If(IsDBNull(auxRow!Alicuota), "", Format(Convert.ToDouble(auxRow!Alicuota), "0.00"))
                            row("ImpRetenido") = If(IsDBNull(auxRow!ImporteRetIB), 0, Convert.ToDouble(auxRow!ImporteRetIB))
                            row("Constancia") = If(IsDBNull(auxRow!NroRet), 0, Convert.ToDouble(auxRow!NroRet))
                            rec.Rows.Add(row)
                        End If
                    End If
                End If
            Next

        End If

        ' Cierre de DataTables
        If rec.Rows.Count > 0 Then
            ObtenerRetencionIBSanLuis = 1
        Else
            ObtenerRetencionIBSanLuis = 0
        End If
        Exit Function

ErrorArchivos:
        ' Manejo de errores

    End Function

    Public Function ObtenerRetencionIBSantaFe(ByVal SeleccionFechaIB As Boolean, ByVal Quincena1 As Boolean, ByVal Quincena2 As Boolean, ByVal Mes As Integer, ByVal Anio As Integer, ByRef rec As DataTable, ByVal fechaDesde As String, ByVal fechaHasta As String) As Integer
        Dim recRetencionesIB As DataTable
        Dim respuesta As Integer
        Dim rec1 As DataTable = New DataTable()
        rec.Columns.Add("RazonSocial", GetType(String))
        rec.Columns.Add("NroProveedor", GetType(Double))
        rec.Columns.Add("IngBrutos", GetType(String))
        rec.Columns.Add("InscDir", GetType(String))
        rec.Columns.Add("ProdServ", GetType(String))
        rec.Columns.Add("BaseImp", GetType(Double))
        rec.Columns.Add("Alicuota", GetType(String))
        rec.Columns.Add("ImpRetenido", GetType(Double))
        rec.Columns.Add("Constancia", GetType(Double))
        rec.Columns.Add("NroOp", GetType(Integer))
        rec.Columns.Add("FechaOP", GetType(Date))
        CadenaSQL = "SELECT * FROM VistaExportacionRentasIIBBSantaFe " &
                "WHERE (YEAR(FechaCreacion) = " & Anio & ") AND (MONTH(FechaCreacion) = " & Mes & ")"

        rec1 = ServidorSQl.GetTabla(CadenaSQL)

        If SeleccionFechaIB Then
            If CDate(fechaHasta) < CDate("01/11/2009") Then
                CadenaSQL = "SELECT * FROM VistaRetencionesIIBBSantaFe112009 " &
                             " WHERE FechaCreacion >= '" & fechaDesde & "' AND FechaCreacion <= '" & fechaHasta & "' "
            Else
                CadenaSQL = "SELECT * FROM VistaRetencionesIIBBSantaFe " &
                             " WHERE FechaCreacion >= '" & fechaDesde & "' AND FechaCreacion <= '" & fechaHasta & "' "
            End If

            '***********************************************
            'Modificar la siguiente línea según la clase ServidorSql
            recRetencionesIB = ServidorSQl.GetTabla(CadenaSQL)
            '***********************************************

            For Each row As DataRow In recRetencionesIB.Rows
                Pasar = False

                CadenaSQL = "SELECT dbo.DetalleLiquidaciones.NroInterno, dbo.DetalleLiquidaciones.ImportePagado, dbo.OP.NroOP, " &
                             "dbo.OP.ImporteRetIB, dbo.OP.PorceBaseImponible, dbo.ComprobantesProveedores.DescCOmp, " &
                             "dbo.ComprobantesProveedores.TipoGrupo FROM dbo.OP INNER JOIN dbo.Liquidaciones ON " &
                             "dbo.OP.NroLiquidacion = dbo.Liquidaciones.NroLiquidacion INNER JOIN dbo.DetalleLiquidaciones ON " &
                             "dbo.Liquidaciones.NroLiquidacion = dbo.DetalleLiquidaciones.NroLiquidacion INNER JOIN " &
                             "dbo.ComprobantesProveedores ON dbo.DetalleLiquidaciones.NroInterno = dbo.ComprobantesProveedores.NroInterno " &
                             "AND dbo.OP.NroProveedor = dbo.ComprobantesProveedores.NroProveedor WHERE dbo.OP.NroOp = " & row("NroOP")

                '***********************************************
                'Modificar la siguiente línea según la clase ServidorSql
                Dim RstOP As DataTable = ServidorSQl.GetTabla(CadenaSQL)
                '***********************************************

                If RstOP.Rows.Count > 0 Then
                    Acumulado = 0
                    For Each opRow As DataRow In RstOP.Rows
                        If Not ((opRow("TipoGrupo") = 6 And opRow("DescCOmp") = 13) Or (opRow("TipoGrupo") = 4 And opRow("DescCOmp") = 11) Or (opRow("DescCOmp") = 12) Or (opRow("DescCOmp") = 5)) Then
                            Acumulado += Convert.ToDouble(opRow("ImportePagado"))
                        End If
                    Next
                End If

                Dim recRow As DataRow = rec.NewRow()
                recRow("NroOP") = Convert.ToInt32(row("NroOP"))
                recRow("RazonSocial") = Convert.ToString(row("RSocial"))
                recRow("NroProveedor") = Convert.ToDouble(row("NroProveedor"))
                If Mid(UCase(Convert.ToString(row("IngBrutos"))), 1, 13) <> "NO SE POSEE" Then
                    recRow("IngBrutos") = Trim(Convert.ToString(row("IngBrutos")))
                    recRow("InscDir") = ""
                Else
                    salida = controlProveedores.BuscarPorNroProveedor(Convert.ToInt32(row("NroProveedor")), Rst)
                    If salida = -1 Then
                    ElseIf salida = 0 Then
                        recRow("IngBrutos") = Trim(Registro.NroIB)
                        recRow("InscDir") = ""
                    Else
                        recRow("IngBrutos") = Left(Trim(Convert.ToString(Rst.Rows(0)("Direccion"))), 12)
                        recRow("InscDir") = Trim(Convert.ToString(Rst.Rows(0)("Localidad")))
                    End If
                End If

                recRow("ProdServ") = Left(Trim(Convert.ToString(row("TipoCuit"))), 50)

                '***********************************************
                'Modificar la siguiente línea según la clase ServidorSql
                Dim recRetencionesIBRow As DataTable = New DataTable()
                respuesta = RecuperarIngresoBrutoDeOP(Convert.ToString(row("NroOP")), recRetencionesIBRow)
                '***********************************************

                If recRetencionesIBRow.Rows.Count > 0 Then
                    recRow("BaseImp") = Convert.ToDouble(recRetencionesIBRow.Rows(0)("Base"))
                    recRow("Alicuota") = Convert.ToString(recRetencionesIBRow.Rows(0)("Alicuota"))
                    recRow("ImpRetenido") = Convert.ToDouble(recRetencionesIBRow.Rows(0)("ImpPercepcion"))
                End If

                recRow("Constancia") = Convert.ToDouble(row("NroRet"))
                rec.Rows.Add(recRow)
            Next


        Else
            For Each auxRow As DataRow In rec1.Rows
                Pasar = False
                Dim FechaComp As String = Format(Convert.ToDateTime(auxRow("FechaCreacion")), "dd/MM/yyyy")
                If Quincena1 And Day(CDate(Mid(FechaComp, 1, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) <= 15 Then
                    Pasar = True
                Else
                    If Quincena1 Then
                        Pasar = False
                    ElseIf Quincena2 Then
                        Pasar = Day(CDate(Mid(FechaComp, 1, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) > 15
                    Else
                        Pasar = True
                    End If
                End If
                FechaComp = Format(Convert.ToDateTime(auxRow!FechaCreacion), "dd/MM/yyyy")

                If Year(CDate(Left(FechaComp, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) = Anio Then
                    If Month(CDate(Left(FechaComp, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) = Mes Then
                        If Pasar = True Then
                            ' Ejemplo de uso de DataRow para agregar datos a DataTable
                            Dim row As DataRow = rec.NewRow()
                            row("NroOp") = Trim(auxRow!NroOP)
                            row("RazonSocial") = Trim(auxRow!RSocial)
                            row("NroProveedor") = Val(auxRow!NroProveedor)
                            row("IngBrutos") = If(Mid(UCase(Trim(auxRow!IngBrutos)), 1, 14) <> "NO SE POSEE", Trim(Left(Trim(Replace(Replace(auxRow!IngBrutos, "-", ""), " ", "")) & Space(14), 14)), "")
                            row("InscDir") = If(Mid(UCase(Trim(auxRow!IngBrutos)), 1, 14) <> "NO SE POSEE", "", "")
                            row("ProdServ") = If(IsDBNull(auxRow!TipoCuit), "", Left(Trim(auxRow!TipoCuit), 50))
                            row("BaseImp") = If(IsDBNull(auxRow!BaseImponible), 0, Convert.ToDouble(auxRow!BaseImponible))
                            row("Alicuota") = If(IsDBNull(auxRow!Alicuota), "", Format(Convert.ToDouble(auxRow!Alicuota), "0.00"))
                            row("ImpRetenido") = If(IsDBNull(auxRow!ImporteRetIB), 0, Convert.ToDouble(auxRow!ImporteRetIB))
                            row("Constancia") = If(IsDBNull(auxRow!NroRet), 0, Convert.ToDouble(auxRow!NroRet))
                            rec.Rows.Add(row)
                        End If
                    End If
                End If
            Next

        End If
        ' Cierre de DataTables
        If rec.Rows.Count > 0 Then
            ObtenerRetencionIBSantaFe = 1
        Else
            ObtenerRetencionIBSantaFe = 0
        End If
        Exit Function
    End Function

    Public Function ObtenerRetencionIBMisiones(ByVal SeleccionFechaIB As Boolean, ByVal Quincena1 As Boolean, ByVal Quincena2 As Boolean, ByVal Mes As Integer, ByVal Anio As Integer, ByRef rec As DataTable, ByVal fechaDesde As String, ByVal fechaHasta As String) As Integer
        Dim recRetencionesIB As DataTable
        Dim respuesta As Integer
        Dim rec1 As DataTable = New DataTable()
        rec.Columns.Add("RazonSocial", GetType(String))
        rec.Columns.Add("NroProveedor", GetType(Double))
        rec.Columns.Add("IngBrutos", GetType(String))
        rec.Columns.Add("InscDir", GetType(String))
        rec.Columns.Add("ProdServ", GetType(String))
        rec.Columns.Add("BaseImp", GetType(Double))
        rec.Columns.Add("Alicuota", GetType(String))
        rec.Columns.Add("ImpRetenido", GetType(Double))
        rec.Columns.Add("Constancia", GetType(Double))
        rec.Columns.Add("NroOp", GetType(Integer))
        rec.Columns.Add("FechaOP", GetType(Date))
        CadenaSQL = "SELECT * FROM VistaRetencionesIIBBMisiones " &
                    "WHERE (YEAR(FechaCreacion) = " & Anio & ") AND (MONTH(FechaCreacion) = " & Mes & ")"

        rec1 = ServidorSQl.GetTabla(CadenaSQL)

        If SeleccionFechaIB Then
            If CDate(fechaHasta) < CDate("01/11/2009") Then
                CadenaSQL = "SELECT * FROM VistaRetencionesIIBBMisiones112009 " &
                             " WHERE FechaCreacion >= '" & fechaDesde & "' AND FechaCreacion <= '" & fechaHasta & "' "
            Else
                CadenaSQL = "SELECT * FROM VistaRetencionesIIBBMisiones " &
                             " WHERE FechaCreacion >= '" & fechaDesde & "' AND FechaCreacion <= '" & fechaHasta & "' "
            End If

            'Modificar la siguiente línea según la clase ServidorSql
            recRetencionesIB = ServidorSQl.GetTabla(CadenaSQL)
            '***********************************************
            For Each row As DataRow In recRetencionesIB.Rows
                Pasar = False

                CadenaSQL = "SELECT dbo.DetalleLiquidaciones.NroInterno, dbo.DetalleLiquidaciones.ImportePagado, dbo.OP.NroOP, " &
                             "dbo.OP.ImporteRetIB, dbo.OP.PorceBaseImponible, dbo.ComprobantesProveedores.DescCOmp, " &
                             "dbo.ComprobantesProveedores.TipoGrupo FROM dbo.OP INNER JOIN dbo.Liquidaciones ON " &
                             "dbo.OP.NroLiquidacion = dbo.Liquidaciones.NroLiquidacion INNER JOIN dbo.DetalleLiquidaciones ON " &
                             "dbo.Liquidaciones.NroLiquidacion = dbo.DetalleLiquidaciones.NroLiquidacion INNER JOIN " &
                             "dbo.ComprobantesProveedores ON dbo.DetalleLiquidaciones.NroInterno = dbo.ComprobantesProveedores.NroInterno " &
                             "AND dbo.OP.NroProveedor = dbo.ComprobantesProveedores.NroProveedor WHERE dbo.OP.NroOp = " & row("NroOP")

                'Modificar la siguiente línea según la clase ServidorSql
                Dim RstOP As DataTable = ServidorSQl.GetTabla(CadenaSQL)


                If RstOP.Rows.Count > 0 Then
                    Acumulado = 0
                    For Each opRow As DataRow In RstOP.Rows
                        If Not ((opRow("TipoGrupo") = 6 And opRow("DescCOmp") = 13) Or (opRow("TipoGrupo") = 4 And opRow("DescCOmp") = 11) Or (opRow("DescCOmp") = 12) Or (opRow("DescCOmp") = 5)) Then
                            Acumulado += Convert.ToDouble(opRow("ImportePagado"))
                        End If
                    Next
                End If

                Dim recRow As DataRow = rec.NewRow()
                recRow("NroOP") = Convert.ToInt32(row("NroOP"))
                recRow("RazonSocial") = Convert.ToString(row("RSocial"))
                recRow("NroProveedor") = Convert.ToDouble(row("NroProveedor"))
                If Mid(UCase(Convert.ToString(row("IngBrutos"))), 1, 13) <> "NO SE POSEE" Then
                    recRow("IngBrutos") = Trim(Convert.ToString(row("IngBrutos")))
                    recRow("InscDir") = ""
                Else
                    salida = controlProveedores.BuscarPorNroProveedor(Convert.ToInt32(row("NroProveedor")), Rst)
                    If salida = -1 Then
                    ElseIf salida = 0 Then
                        recRow("IngBrutos") = Trim(Registro.NroIB)
                        recRow("InscDir") = ""
                    Else
                        recRow("IngBrutos") = Left(Trim(Convert.ToString(Rst.Rows(0)("Direccion"))), 12)
                        recRow("InscDir") = Trim(Convert.ToString(Rst.Rows(0)("Localidad")))
                    End If
                End If

                recRow("ProdServ") = Left(Trim(Convert.ToString(row("TipoCuit"))), 50)

                'Modificar la siguiente línea según la clase ServidorSql
                Dim recRetencionesIBRow As DataTable = New DataTable()
                respuesta = RecuperarIngresoBrutoDeOP(Convert.ToString(row("NroOP")), recRetencionesIBRow)


                If recRetencionesIBRow.Rows.Count > 0 Then
                    For Each row2 As DataRow In recRetencionesIBRow.Rows
                        If row2("codjurisdiccion").ToString = 914 Then
                            recRow("BaseImp") = Convert.ToDouble(row2("Base"))
                            recRow("Alicuota") = Convert.ToString(row2("Alicuota"))
                            recRow("ImpRetenido") = Convert.ToDouble(row2("ImpPercepcion"))
                        End If
                    Next
                End If

                recRow("Constancia") = Convert.ToDouble(row("NroRet"))
                rec.Rows.Add(recRow)
            Next

        Else
            For Each auxRow As DataRow In rec1.Rows
                Pasar = False
                Dim FechaComp As String = Format(Convert.ToDateTime(auxRow("FechaCreacion")), "dd/MM/yyyy")
                If Quincena1 And Day(CDate(Mid(FechaComp, 1, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) <= 15 Then
                    Pasar = True
                Else
                    If Quincena1 Then
                        Pasar = False
                    ElseIf Quincena2 Then
                        Pasar = Day(CDate(Mid(FechaComp, 1, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) > 15
                    Else
                        Pasar = True
                    End If
                End If
                FechaComp = Format(Convert.ToDateTime(auxRow!FechaCreacion), "dd/MM/yyyy")

                If Year(CDate(Left(FechaComp, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) = Anio Then
                    If Month(CDate(Left(FechaComp, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) = Mes Then
                        If Pasar = True Then
                            ' Ejemplo de uso de DataRow para agregar datos a DataTable
                            Dim row As DataRow = rec.NewRow()
                            row("NroOp") = Trim(auxRow!NroOP)
                            row("RazonSocial") = Trim(auxRow!RSocial)
                            row("NroProveedor") = Val(auxRow!NroProveedor)
                            row("IngBrutos") = If(Mid(UCase(Trim(auxRow!IngBrutos)), 1, 14) <> "NO SE POSEE", Trim(Left(Trim(Replace(Replace(auxRow!IngBrutos, "-", ""), " ", "")) & Space(14), 14)), "")
                            row("InscDir") = If(Mid(UCase(Trim(auxRow!IngBrutos)), 1, 14) <> "NO SE POSEE", "", "")
                            row("ProdServ") = If(IsDBNull(auxRow!TipoCuit), "", Left(Trim(auxRow!TipoCuit), 50))
                            row("BaseImp") = If(IsDBNull(auxRow!BaseImponible), 0, Convert.ToDouble(auxRow!BaseImponible))
                            row("Alicuota") = If(IsDBNull(auxRow!Alicuota), "", Format(Convert.ToDouble(auxRow!Alicuota), "0.00"))
                            row("ImpRetenido") = If(IsDBNull(auxRow!ImporteRetIB), 0, Convert.ToDouble(auxRow!ImporteRetIB))
                            row("Constancia") = If(IsDBNull(auxRow!NroRet), 0, Convert.ToDouble(auxRow!NroRet))
                            rec.Rows.Add(row)
                        End If
                    End If
                End If
            Next

        End If


        If rec.Rows.Count > 0 Then
            ObtenerRetencionIBMisiones = 1
        Else
            ObtenerRetencionIBMisiones = 0
        End If

        Exit Function
ErrorArchivos:
        ' Log.Error("ErrorArchivos")
        ObtenerRetencionIBMisiones = -1
    End Function
    Public Function ObtenerRetencionIBLaPampa(ByVal SeleccionFechaIB As Boolean, ByVal Quincena1 As Boolean, ByVal Quincena2 As Boolean, ByVal Mes As Integer, ByVal Anio As Integer, ByRef rec As DataTable, ByVal fechaDesde As String, ByVal fechaHasta As String) As Integer
        Dim recRetencionesIB As DataTable
        Dim respuesta As Integer
        Dim rec1 As DataTable = New DataTable()
        rec.Columns.Add("RazonSocial", GetType(String))
        rec.Columns.Add("NroProveedor", GetType(Double))
        rec.Columns.Add("IngBrutos", GetType(String))
        rec.Columns.Add("InscDir", GetType(String))
        rec.Columns.Add("ProdServ", GetType(String))
        rec.Columns.Add("BaseImp", GetType(Double))
        rec.Columns.Add("Alicuota", GetType(String))
        rec.Columns.Add("ImpRetenido", GetType(Double))
        rec.Columns.Add("Constancia", GetType(Double))
        rec.Columns.Add("NroOp", GetType(Integer))
        rec.Columns.Add("FechaOP", GetType(Date))
        CadenaSQL = "SELECT * FROM VistaRetencionesIIBBLaPampa" &
                    " WHERE (YEAR(FechaCreacion) = " & Anio & ") AND (MONTH(FechaCreacion) = " & Mes & ")"

        rec1 = ServidorSQl.GetTabla(CadenaSQL)
        If SeleccionFechaIB Then
            If CDate(fechaHasta) < CDate("01/11/2009") Then
                CadenaSQL = "SELECT * FROM VistaRetencionesIIBBLaPampa112009 " &
                             " WHERE FechaCreacion >= '" & fechaDesde & "' AND FechaCreacion <= '" & fechaHasta & "' "
            Else
                CadenaSQL = "SELECT * FROM VistaRetencionesIIBBLaPampa " &
                             " WHERE FechaCreacion >= '" & fechaDesde & "' AND FechaCreacion <= '" & fechaHasta & "' "
            End If

            'Modificar la siguiente línea según la clase ServidorSql
            recRetencionesIB = ServidorSQl.GetTabla(CadenaSQL)
            '***********************************************
            For Each row As DataRow In recRetencionesIB.Rows
                Pasar = False

                CadenaSQL = "SELECT dbo.DetalleLiquidaciones.NroInterno, dbo.DetalleLiquidaciones.ImportePagado, dbo.OP.NroOP, " &
                             "dbo.OP.ImporteRetIB, dbo.OP.PorceBaseImponible, dbo.ComprobantesProveedores.DescCOmp, " &
                             "dbo.ComprobantesProveedores.TipoGrupo FROM dbo.OP INNER JOIN dbo.Liquidaciones ON " &
                             "dbo.OP.NroLiquidacion = dbo.Liquidaciones.NroLiquidacion INNER JOIN dbo.DetalleLiquidaciones ON " &
                             "dbo.Liquidaciones.NroLiquidacion = dbo.DetalleLiquidaciones.NroLiquidacion INNER JOIN " &
                             "dbo.ComprobantesProveedores ON dbo.DetalleLiquidaciones.NroInterno = dbo.ComprobantesProveedores.NroInterno " &
                             "AND dbo.OP.NroProveedor = dbo.ComprobantesProveedores.NroProveedor WHERE dbo.OP.NroOp = " & row("NroOP")

                'Modificar la siguiente línea según la clase ServidorSql
                Dim RstOP As DataTable = ServidorSQl.GetTabla(CadenaSQL)


                If RstOP.Rows.Count > 0 Then
                    Acumulado = 0
                    For Each opRow As DataRow In RstOP.Rows
                        If Not ((opRow("TipoGrupo") = 6 And opRow("DescCOmp") = 13) Or (opRow("TipoGrupo") = 4 And opRow("DescCOmp") = 11) Or (opRow("DescCOmp") = 12) Or (opRow("DescCOmp") = 5)) Then
                            Acumulado += Convert.ToDouble(opRow("ImportePagado"))
                        End If
                    Next
                End If

                Dim recRow As DataRow = rec.NewRow()
                recRow("NroOP") = Convert.ToInt32(row("NroOP"))
                recRow("RazonSocial") = Convert.ToString(row("RSocial"))
                recRow("NroProveedor") = Convert.ToDouble(row("NroProveedor"))
                If Mid(UCase(Convert.ToString(row("IngBrutos"))), 1, 13) <> "NO SE POSEE" Then
                    recRow("IngBrutos") = Trim(Convert.ToString(row("IngBrutos")))
                    recRow("InscDir") = ""
                Else
                    salida = controlProveedores.BuscarPorNroProveedor(Convert.ToInt32(row("NroProveedor")), Rst)
                    If salida = -1 Then
                    ElseIf salida = 0 Then
                        recRow("IngBrutos") = Trim(Registro.NroIB)
                        recRow("InscDir") = ""
                    Else
                        recRow("IngBrutos") = Left(Trim(Convert.ToString(Rst.Rows(0)("Direccion"))), 12)
                        recRow("InscDir") = Trim(Convert.ToString(Rst.Rows(0)("Localidad")))
                    End If
                End If

                recRow("ProdServ") = Left(Trim(Convert.ToString(row("TipoCuit"))), 50)

                'Modificar la siguiente línea según la clase ServidorSql
                Dim recRetencionesIBRow As DataTable = New DataTable()
                respuesta = RecuperarIngresoBrutoDeOP(Convert.ToString(row("NroOP")), recRetencionesIBRow)


                If recRetencionesIBRow.Rows.Count > 0 Then
                    For Each row2 As DataRow In recRetencionesIBRow.Rows
                        If row2("codjurisdiccion").ToString = 914 Then
                            recRow("BaseImp") = Convert.ToDouble(row2("Base"))
                            recRow("Alicuota") = Convert.ToString(row2("Alicuota"))
                            recRow("ImpRetenido") = Convert.ToDouble(row2("ImpPercepcion"))
                        End If
                    Next
                End If

                recRow("Constancia") = Convert.ToDouble(row("NroRet"))
                rec.Rows.Add(recRow)
            Next

        Else
            For Each auxRow As DataRow In rec1.Rows
                Pasar = False
                Dim FechaComp As String = Format(Convert.ToDateTime(auxRow("FechaCreacion")), "dd/MM/yyyy")
                If Quincena1 And Day(CDate(Mid(FechaComp, 1, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) <= 15 Then
                    Pasar = True
                Else
                    If Quincena1 Then
                        Pasar = False
                    ElseIf Quincena2 Then
                        Pasar = Day(CDate(Mid(FechaComp, 1, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) > 15
                    Else
                        Pasar = True
                    End If
                End If
                FechaComp = Format(Convert.ToDateTime(auxRow!FechaCreacion), "dd/MM/yyyy")

                If Year(CDate(Left(FechaComp, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) = Anio Then
                    If Month(CDate(Left(FechaComp, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) = Mes Then
                        If Pasar = True Then
                            ' Ejemplo de uso de DataRow para agregar datos a DataTable
                            Dim row As DataRow = rec.NewRow()
                            row("NroOp") = Trim(auxRow!NroOP)
                            row("RazonSocial") = Trim(auxRow!RSocial)
                            row("NroProveedor") = Val(auxRow!NroProveedor)
                            row("IngBrutos") = If(Mid(UCase(Trim(auxRow!IngBrutos)), 1, 14) <> "NO SE POSEE", Trim(Left(Trim(Replace(Replace(auxRow!IngBrutos, "-", ""), " ", "")) & Space(14), 14)), "")
                            row("InscDir") = If(Mid(UCase(Trim(auxRow!IngBrutos)), 1, 14) <> "NO SE POSEE", "", "")
                            row("ProdServ") = If(IsDBNull(auxRow!TipoCuit), "", Left(Trim(auxRow!TipoCuit), 50))
                            row("BaseImp") = If(IsDBNull(auxRow!BaseImponible), 0, Convert.ToDouble(auxRow!BaseImponible))
                            row("Alicuota") = If(IsDBNull(auxRow!Alicuota), "", Format(Convert.ToDouble(auxRow!Alicuota), "0.00"))
                            row("ImpRetenido") = If(IsDBNull(auxRow!ImporteRetIB), 0, Convert.ToDouble(auxRow!ImporteRetIB))
                            row("Constancia") = If(IsDBNull(auxRow!NroRet), 0, Convert.ToDouble(auxRow!NroRet))
                            rec.Rows.Add(row)
                        End If
                    End If
                End If
            Next

        End If

        If rec.Rows.Count > 0 Then
            ObtenerRetencionIBLaPampa = 1
        Else
            ObtenerRetencionIBLaPampa = 0
        End If

        Exit Function
ErrorArchivos:
        ' Manejo del error
        ObtenerRetencionIBLaPampa = -1
    End Function

    Public Function ObtenerRetencionIBJujuy(ByVal SeleccionFechaIB As Boolean, ByVal Quincena1 As Boolean, ByVal Quincena2 As Boolean, ByVal Mes As Integer, ByVal Anio As Integer, ByRef rec As DataTable, ByVal fechaDesde As String, ByVal fechaHasta As String) As Integer
        Dim recRetencionesIB As DataTable
        Dim respuesta As Integer
        Dim rec1 As DataTable = New DataTable()
        rec.Columns.Add("RazonSocial", GetType(String))
        rec.Columns.Add("NroProveedor", GetType(Double))
        rec.Columns.Add("IngBrutos", GetType(String))
        rec.Columns.Add("InscDir", GetType(String))
        rec.Columns.Add("ProdServ", GetType(String))
        rec.Columns.Add("BaseImp", GetType(Double))
        rec.Columns.Add("Alicuota", GetType(String))
        rec.Columns.Add("ImpRetenido", GetType(Double))
        rec.Columns.Add("Constancia", GetType(Double))
        rec.Columns.Add("NroOp", GetType(Integer))
        rec.Columns.Add("FechaOP", GetType(Date))
        CadenaSQL = "SELECT * FROM VistaRetencionesIIBBJujuy" &
                    " WHERE (YEAR(FechaCreacion) = " & Anio & ") AND (MONTH(FechaCreacion) = " & Mes & ")"

        rec1 = ServidorSQl.GetTabla(CadenaSQL)
        If SeleccionFechaIB Then
            If CDate(fechaHasta) < CDate("01/11/2009") Then
                CadenaSQL = "SELECT * FROM VistaRetencionesIIBBJujuy112009 " &
                             " WHERE FechaCreacion >= '" & fechaDesde & "' AND FechaCreacion <= '" & fechaHasta & "' "
            Else
                CadenaSQL = "SELECT * FROM VistaRetencionesIIBBJujuy " &
                             " WHERE FechaCreacion >= '" & fechaDesde & "' AND FechaCreacion <= '" & fechaHasta & "' "
            End If

            'Modificar la siguiente línea según la clase ServidorSql
            recRetencionesIB = ServidorSQl.GetTabla(CadenaSQL)
            '***********************************************
            For Each row As DataRow In recRetencionesIB.Rows
                Pasar = False

                CadenaSQL = "SELECT dbo.DetalleLiquidaciones.NroInterno, dbo.DetalleLiquidaciones.ImportePagado, dbo.OP.NroOP, " &
                             "dbo.OP.ImporteRetIB, dbo.OP.PorceBaseImponible, dbo.ComprobantesProveedores.DescCOmp, " &
                             "dbo.ComprobantesProveedores.TipoGrupo FROM dbo.OP INNER JOIN dbo.Liquidaciones ON " &
                             "dbo.OP.NroLiquidacion = dbo.Liquidaciones.NroLiquidacion INNER JOIN dbo.DetalleLiquidaciones ON " &
                             "dbo.Liquidaciones.NroLiquidacion = dbo.DetalleLiquidaciones.NroLiquidacion INNER JOIN " &
                             "dbo.ComprobantesProveedores ON dbo.DetalleLiquidaciones.NroInterno = dbo.ComprobantesProveedores.NroInterno " &
                             "AND dbo.OP.NroProveedor = dbo.ComprobantesProveedores.NroProveedor WHERE dbo.OP.NroOp = " & row("NroOP")

                'Modificar la siguiente línea según la clase ServidorSql
                Dim RstOP As DataTable = ServidorSQl.GetTabla(CadenaSQL)


                If RstOP.Rows.Count > 0 Then
                    Acumulado = 0
                    For Each opRow As DataRow In RstOP.Rows
                        If Not ((opRow("TipoGrupo") = 6 And opRow("DescCOmp") = 13) Or (opRow("TipoGrupo") = 4 And opRow("DescCOmp") = 11) Or (opRow("DescCOmp") = 12) Or (opRow("DescCOmp") = 5)) Then
                            Acumulado += Convert.ToDouble(opRow("ImportePagado"))
                        End If
                    Next
                End If

                Dim recRow As DataRow = rec.NewRow()
                recRow("NroOP") = Convert.ToInt32(row("NroOP"))
                recRow("RazonSocial") = Convert.ToString(row("RSocial"))
                recRow("NroProveedor") = Convert.ToDouble(row("NroProveedor"))
                If Mid(UCase(Convert.ToString(row("IngBrutos"))), 1, 13) <> "NO SE POSEE" Then
                    recRow("IngBrutos") = Trim(Convert.ToString(row("IngBrutos")))
                    recRow("InscDir") = ""
                Else
                    salida = controlProveedores.BuscarPorNroProveedor(Convert.ToInt32(row("NroProveedor")), Rst)
                    If salida = -1 Then
                    ElseIf salida = 0 Then
                        recRow("IngBrutos") = Trim(Registro.NroIB)
                        recRow("InscDir") = ""
                    Else
                        recRow("IngBrutos") = Left(Trim(Convert.ToString(Rst.Rows(0)("Direccion"))), 12)
                        recRow("InscDir") = Trim(Convert.ToString(Rst.Rows(0)("Localidad")))
                    End If
                End If

                recRow("ProdServ") = Left(Trim(Convert.ToString(row("TipoCuit"))), 50)

                'Modificar la siguiente línea según la clase ServidorSql
                Dim recRetencionesIBRow As DataTable = New DataTable()
                respuesta = RecuperarIngresoBrutoDeOP(Convert.ToString(row("NroOP")), recRetencionesIBRow)


                If recRetencionesIBRow.Rows.Count > 0 Then
                    For Each row2 As DataRow In recRetencionesIBRow.Rows
                        If row2("codjurisdiccion").ToString = 910 Then
                            recRow("BaseImp") = Convert.ToDouble(row2("Base"))
                            recRow("Alicuota") = Convert.ToString(row2("Alicuota"))
                            recRow("ImpRetenido") = Convert.ToDouble(row2("ImpPercepcion"))
                        End If
                    Next
                End If

                recRow("Constancia") = Convert.ToDouble(row("NroRet"))
                rec.Rows.Add(recRow)
            Next

        Else
            For Each auxRow As DataRow In rec1.Rows
                Pasar = False
                Dim FechaComp As String = Format(Convert.ToDateTime(auxRow("FechaCreacion")), "dd/MM/yyyy")
                If Quincena1 And Day(CDate(Mid(FechaComp, 1, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) <= 15 Then
                    Pasar = True
                Else
                    If Quincena1 Then
                        Pasar = False
                    ElseIf Quincena2 Then
                        Pasar = Day(CDate(Mid(FechaComp, 1, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) > 15
                    Else
                        Pasar = True
                    End If
                End If
                FechaComp = Format(Convert.ToDateTime(auxRow!FechaCreacion), "dd/MM/yyyy")

                If Year(CDate(Left(FechaComp, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) = Anio Then
                    If Month(CDate(Left(FechaComp, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) = Mes Then
                        If Pasar = True Then
                            ' Ejemplo de uso de DataRow para agregar datos a DataTable
                            Dim row As DataRow = rec.NewRow()
                            row("NroOp") = Trim(auxRow!NroOP)
                            row("RazonSocial") = Trim(auxRow!RSocial)
                            row("NroProveedor") = Val(auxRow!NroProveedor)
                            row("IngBrutos") = If(Mid(UCase(Trim(auxRow!IngBrutos)), 1, 14) <> "NO SE POSEE", Trim(Left(Trim(Replace(Replace(auxRow!IngBrutos, "-", ""), " ", "")) & Space(14), 14)), "")
                            row("InscDir") = If(Mid(UCase(Trim(auxRow!IngBrutos)), 1, 14) <> "NO SE POSEE", "", "")
                            row("ProdServ") = If(IsDBNull(auxRow!TipoCuit), "", Left(Trim(auxRow!TipoCuit), 50))
                            row("BaseImp") = If(IsDBNull(auxRow!BaseImponible), 0, Convert.ToDouble(auxRow!BaseImponible))
                            row("Alicuota") = If(IsDBNull(auxRow!Alicuota), "", Format(Convert.ToDouble(auxRow!Alicuota), "0.00"))
                            row("ImpRetenido") = If(IsDBNull(auxRow!ImporteRetIB), 0, Convert.ToDouble(auxRow!ImporteRetIB))
                            row("Constancia") = If(IsDBNull(auxRow!NroRet), 0, Convert.ToDouble(auxRow!NroRet))
                            rec.Rows.Add(row)
                        End If
                    End If
                End If
            Next

        End If

        If rec.Rows.Count > 0 Then
            ObtenerRetencionIBJujuy = 1
        Else
            ObtenerRetencionIBJujuy = 0
        End If

        Return ObtenerRetencionIBJujuy
    End Function

    Public Function ObtenerRetencionIBMendoza(ByVal SeleccionFechaIB As Boolean, ByVal Quincena1 As Boolean, ByVal Quincena2 As Boolean, ByVal Mes As Integer, ByVal Anio As Integer, ByRef rec As DataTable, ByVal fechaDesde As String, ByVal fechaHasta As String) As Integer
        Dim recRetencionesIB As DataTable
        Dim respuesta As Integer
        Dim rec1 As DataTable = New DataTable()
        rec.Columns.Add("RazonSocial", GetType(String))
        rec.Columns.Add("NroProveedor", GetType(Double))
        rec.Columns.Add("IngBrutos", GetType(String))
        rec.Columns.Add("InscDir", GetType(String))
        rec.Columns.Add("ProdServ", GetType(String))
        rec.Columns.Add("BaseImp", GetType(Double))
        rec.Columns.Add("Alicuota", GetType(String))
        rec.Columns.Add("ImpRetenido", GetType(Double))
        rec.Columns.Add("Constancia", GetType(Double))
        rec.Columns.Add("NroOp", GetType(Integer))
        rec.Columns.Add("FechaOP", GetType(Date))
        CadenaSQL = "SELECT * FROM VistaRetencionesIIBBMendoza" &
                    " WHERE (YEAR(FechaCreacion) = " & Anio & ") AND (MONTH(FechaCreacion) = " & Mes & ")"

        rec1 = ServidorSQl.GetTabla(CadenaSQL)
        If SeleccionFechaIB Then
            If CDate(fechaHasta) < CDate("01/11/2009") Then
                CadenaSQL = "SELECT * FROM VistaRetencionesIIBBMendoza112009 " &
                             " WHERE FechaCreacion >= '" & fechaDesde & "' AND FechaCreacion <= '" & fechaHasta & "' "
            Else
                CadenaSQL = "SELECT * FROM VistaRetencionesIIBBMendoza " &
                             " WHERE FechaCreacion >= '" & fechaDesde & "' AND FechaCreacion <= '" & fechaHasta & "' "
            End If

            'Modificar la siguiente línea según la clase ServidorSql
            recRetencionesIB = ServidorSQl.GetTabla(CadenaSQL)
            '***********************************************
            For Each row As DataRow In recRetencionesIB.Rows
                Pasar = False

                CadenaSQL = "SELECT dbo.DetalleLiquidaciones.NroInterno, dbo.DetalleLiquidaciones.ImportePagado, dbo.OP.NroOP, " &
                             "dbo.OP.ImporteRetIB, dbo.OP.PorceBaseImponible, dbo.ComprobantesProveedores.DescCOmp, " &
                             "dbo.ComprobantesProveedores.TipoGrupo FROM dbo.OP INNER JOIN dbo.Liquidaciones ON " &
                             "dbo.OP.NroLiquidacion = dbo.Liquidaciones.NroLiquidacion INNER JOIN dbo.DetalleLiquidaciones ON " &
                             "dbo.Liquidaciones.NroLiquidacion = dbo.DetalleLiquidaciones.NroLiquidacion INNER JOIN " &
                             "dbo.ComprobantesProveedores ON dbo.DetalleLiquidaciones.NroInterno = dbo.ComprobantesProveedores.NroInterno " &
                             "AND dbo.OP.NroProveedor = dbo.ComprobantesProveedores.NroProveedor WHERE dbo.OP.NroOp = " & row("NroOP")

                'Modificar la siguiente línea según la clase ServidorSql
                Dim RstOP As DataTable = ServidorSQl.GetTabla(CadenaSQL)


                If RstOP.Rows.Count > 0 Then
                    Acumulado = 0
                    For Each opRow As DataRow In RstOP.Rows
                        If Not ((opRow("TipoGrupo") = 6 And opRow("DescCOmp") = 13) Or (opRow("TipoGrupo") = 4 And opRow("DescCOmp") = 11) Or (opRow("DescCOmp") = 12) Or (opRow("DescCOmp") = 5)) Then
                            Acumulado += Convert.ToDouble(opRow("ImportePagado"))
                        End If
                    Next
                End If

                Dim recRow As DataRow = rec.NewRow()
                recRow("NroOP") = Convert.ToInt32(row("NroOP"))
                recRow("RazonSocial") = Convert.ToString(row("RSocial"))
                recRow("NroProveedor") = Convert.ToDouble(row("NroProveedor"))
                If Mid(UCase(Convert.ToString(row("IngBrutos"))), 1, 13) <> "NO SE POSEE" Then
                    recRow("IngBrutos") = Trim(Convert.ToString(row("IngBrutos")))
                    recRow("InscDir") = ""
                Else
                    salida = controlProveedores.BuscarPorNroProveedor(Convert.ToInt32(row("NroProveedor")), Rst)
                    If salida = -1 Then
                    ElseIf salida = 0 Then
                        recRow("IngBrutos") = Trim(Registro.NroIB)
                        recRow("InscDir") = ""
                    Else
                        recRow("IngBrutos") = Left(Trim(Convert.ToString(Rst.Rows(0)("Direccion"))), 12)
                        recRow("InscDir") = Trim(Convert.ToString(Rst.Rows(0)("Localidad")))
                    End If
                End If

                recRow("ProdServ") = Left(Trim(Convert.ToString(row("TipoCuit"))), 50)

                'Modificar la siguiente línea según la clase ServidorSql
                Dim recRetencionesIBRow As DataTable = New DataTable()
                respuesta = RecuperarIngresoBrutoDeOP(Convert.ToString(row("NroOP")), recRetencionesIBRow)


                If recRetencionesIBRow.Rows.Count > 0 Then
                    For Each row2 As DataRow In recRetencionesIBRow.Rows
                        If row2("codjurisdiccion").ToString = 913 Then
                            recRow("BaseImp") = Convert.ToDouble(row2("Base"))
                            recRow("Alicuota") = Convert.ToString(row2("Alicuota"))
                            recRow("ImpRetenido") = Convert.ToDouble(row2("ImpPercepcion"))
                        End If
                    Next
                End If

                recRow("Constancia") = Convert.ToDouble(row("NroRet"))
                rec.Rows.Add(recRow)
            Next

        Else
            For Each auxRow As DataRow In rec1.Rows
                Pasar = False
                Dim FechaComp As String = Format(Convert.ToDateTime(auxRow("FechaCreacion")), "dd/MM/yyyy")
                If Quincena1 And Day(CDate(Mid(FechaComp, 1, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) <= 15 Then
                    Pasar = True
                Else
                    If Quincena1 Then
                        Pasar = False
                    ElseIf Quincena2 Then
                        Pasar = Day(CDate(Mid(FechaComp, 1, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) > 15
                    Else
                        Pasar = True
                    End If
                End If
                FechaComp = Format(Convert.ToDateTime(auxRow!FechaCreacion), "dd/MM/yyyy")

                If Year(CDate(Left(FechaComp, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) = Anio Then
                    If Month(CDate(Left(FechaComp, 2) & "/" & Mid(FechaComp, 4, 2) & "/" & Mid(FechaComp, 7, 4))) = Mes Then
                        If Pasar = True Then
                            ' Ejemplo de uso de DataRow para agregar datos a DataTable
                            Dim row As DataRow = rec.NewRow()
                            row("NroOp") = Trim(auxRow!NroOP)
                            row("RazonSocial") = Trim(auxRow!RSocial)
                            row("NroProveedor") = Val(auxRow!NroProveedor)
                            row("IngBrutos") = If(Mid(UCase(Trim(auxRow!IngBrutos)), 1, 14) <> "NO SE POSEE", Trim(Left(Trim(Replace(Replace(auxRow!IngBrutos, "-", ""), " ", "")) & Space(14), 14)), "")
                            row("InscDir") = If(Mid(UCase(Trim(auxRow!IngBrutos)), 1, 14) <> "NO SE POSEE", "", "")
                            row("ProdServ") = If(IsDBNull(auxRow!TipoCuit), "", Left(Trim(auxRow!TipoCuit), 50))
                            row("BaseImp") = If(IsDBNull(auxRow!BaseImponible), 0, Convert.ToDouble(auxRow!BaseImponible))
                            row("Alicuota") = If(IsDBNull(auxRow!Alicuota), "", Format(Convert.ToDouble(auxRow!Alicuota), "0.00"))
                            row("ImpRetenido") = If(IsDBNull(auxRow!ImporteRetIB), 0, Convert.ToDouble(auxRow!ImporteRetIB))
                            row("Constancia") = If(IsDBNull(auxRow!NroRet), 0, Convert.ToDouble(auxRow!NroRet))
                            rec.Rows.Add(row)
                        End If
                    End If
                End If
            Next

        End If

        If rec.Rows.Count > 0 Then
            ObtenerRetencionIBMendoza = 1
        Else
            ObtenerRetencionIBMendoza = 0
        End If

        Return ObtenerRetencionIBMendoza
    End Function



    Public Function ObtenerPercepcionesIVAMes(ByVal Mes As Integer, ByVal Anio As Integer, ByRef dt As DataTable) As Long
        Dim sql As String
        Dim MFecha As String
        On Error GoTo errores

        MFecha = Format(Mes, "00") & "/" & Anio

        ' Reemplazar Conect por tu método de obtención de DataTable (ServidorSql.GetTabla)
        dt = ServidorSQl.GetTabla("SELECT Proveedor.NroProveedor, Proveedor.RSocial, Proveedor.NroCUIT, ComprobantesProveedores.DescComp, ComprobantesProveedores.TipoComp, ComprobantesProveedores.NroComp, ComprobantesProveedores.FechaComp, " &
            "CASE WHEN ComprobantesProveedores.DescComp in (7,8,9,10,11,12,18,20,22) THEN -ComprobantesProveedores.PercepIva ELSE ComprobantesProveedores.PercepIva END AS PercepIva " &
            "FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor " &
            "WHERE (ComprobantesProveedores.PercepIva > 0) AND ((ComprobantesProveedores.mesimputacion) = '" & MFecha & "') " &
            "ORDER BY ComprobantesProveedores.FechaComp, ComprobantesProveedores.NroProveedor")

        If dt Is Nothing Then
            GoTo errores
        ElseIf dt.Rows.Count = 0 Then
            ObtenerPercepcionesIVAMes = 0
        Else
            ObtenerPercepcionesIVAMes = 1
        End If

        Exit Function
errores:
        ObtenerPercepcionesIVAMes = -1
    End Function


    Public Function ObtenerPercepcionesIVAMesImputacion(ByRef dt As DataTable, MesImp As String, SeleccionoMes As Boolean) As Long

        '-----------------------------------------------------
        'Descripción: obtiene las percepciones de iva de un período de fecha
        '             determinado
        'Parámetros : fecha Desde, fecha Hasta y recordset por referencia
        'Output     : 1 se encontraron datos.
        '             0 no se encontraron datos.
        '            -1 Error al buscar datos.
        '-----------------------------------------------------
        CadenaSQL = " SELECT Proveedor.NroProveedor, Proveedor.RSocial, Proveedor.NroCUIT, ComprobantesProveedores.DescComp, ComprobantesProveedores.TipoComp,ComprobantesProveedores.NroComp , ComprobantesProveedores.FechaComp, ComprobantesProveedores.PercepIva" _
        & " FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor " _
        & " Where (ComprobantesProveedores.PercepIva > 0) AND ComprobantesProveedores.MesImputacion  in (" & MesImp & ") " _
        & " ORDER BY ComprobantesProveedores.FechaComp, ComprobantesProveedores.NroProveedor "

        dt = ServidorSQl.GetTabla(CadenaSQL)
        If dt Is Nothing Then
        ElseIf dt.Rows.Count = 0 Then
            ObtenerPercepcionesIVAMesImputacion = 0
        Else
            ObtenerPercepcionesIVAMesImputacion = 1
        End If

        Exit Function

        ObtenerPercepcionesIVAMesImputacion = -1
    End Function

    Public Function ObtenerPercepcionesIBMes(ByVal Mes As Integer, ByVal Anio As Integer, ByRef dt As DataTable, ByVal ADUANA As Boolean) As Long
        Dim MFecha As String
        On Error GoTo errores

        MFecha = Format(Mes, "00") & "/" & Anio
        CadenaSQL = "SELECT ComprobantesProveedores.NroInterno, ComprobantesProveedores.NroProveedor, ComprobantesProveedores.TipoGrupo, ComprobantesProveedores.DescComp, ComprobantesProveedores.TipoComp, ComprobantesProveedores.NroComp, ComprobantesProveedores.FechaComp, Proveedor.RSocial, ComprobantesPercepcionesIB.Percepcion, Proveedor.NroCUIT, Bancos.dbo.Provincia.DescProvincia, ComprobantesProveedores.NroCompAlfanumerico, ComprobantesPercepcionesIB.BaseImponible as ImporteProd " &
              "FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor INNER JOIN ComprobantesPercepcionesIB ON ComprobantesProveedores.NroInterno = ComprobantesPercepcionesIB.NroInterno INNER JOIN Bancos.dbo.Provincia ON Bancos.dbo.Provincia.codProvincia = ComprobantesPercepcionesIB.Provincia "

        If ADUANA Then
            CadenaSQL = CadenaSQL & "WHERE (ComprobantesPercepcionesIB.Percepcion <> 0) AND ((ComprobantesProveedores.MESIMPUTACION) = '" & MFecha & "') AND (Proveedor.RSocial LIKE 'ADUANA%')"
        Else
            CadenaSQL = CadenaSQL & "WHERE (ComprobantesPercepcionesIB.Percepcion <> 0) AND ((ComprobantesProveedores.MESIMPUTACION) = '" & MFecha & "') AND (Proveedor.RSocial NOT LIKE 'ADUANA%')"
        End If

        CadenaSQL = CadenaSQL & "ORDER BY Bancos.dbo.Provincia.DescProvincia, Proveedor.RSocial"

        ' Reemplazar Conect por tu método de obtención de DataTable (ServidorSql.GetTabla)
        dt = ServidorSQl.GetTabla(CadenaSQL)

        If dt Is Nothing Then
            GoTo errores
        ElseIf dt.Rows.Count = 0 Then
            ObtenerPercepcionesIBMes = 0
        Else
            ObtenerPercepcionesIBMes = 1
        End If

        Exit Function
errores:
        ObtenerPercepcionesIBMes = -1
    End Function


    Public Function ObtenerPercepcionesIBMesImputacion(ByRef dt As DataTable, MesImp As String, ByVal ADUANA As Boolean) As Long
        On Error GoTo errores

        CadenaSQL = "SELECT ComprobantesProveedores.NroInterno, ComprobantesProveedores.NroProveedor, ComprobantesProveedores.TipoGrupo, ComprobantesProveedores.DescComp, ComprobantesProveedores.TipoComp, ComprobantesProveedores.NroComp, ComprobantesProveedores.FechaComp, Proveedor.RSocial, ComprobantesPercepcionesIB.Percepcion, Proveedor.NroCUIT, Bancos.dbo.Provincia.DescProvincia, ComprobantesProveedores.NroCompAlfanumerico, ComprobantesProveedores.ImporteProd " &
              "FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor INNER JOIN ComprobantesPercepcionesIB ON ComprobantesProveedores.NroInterno = ComprobantesPercepcionesIB.NroInterno INNER JOIN Bancos.dbo.Provincia ON Bancos.dbo.Provincia.codProvincia = ComprobantesPercepcionesIB.Provincia "

        'If ADUANA Then
        '    CadenaSQL = CadenaSQL & "WHERE (ComprobantesPercepcionesIB.Percepcion <> 0) AND (ComprobantesProveedores.MesImputacion IN (" & MesImp & ")) AND (Proveedor.RSocial LIKE 'ADUANA%')"
        'Else
        '    CadenaSQL = CadenaSQL & "WHERE (ComprobantesPercepcionesIB.Percepcion <> 0) AND (ComprobantesProveedores.MesImputacion IN (" & MesImp & ")) AND (Proveedor.RSocial NOT LIKE 'ADUANA%')"
        'End If
        If ADUANA Then
            CadenaSQL = CadenaSQL & " Where (ComprobantesPercepcionesIB.Percepcion <> 0) AND (ComprobantesProveedores.MesImputacion  in (" & MesImp & "))  AND (ComprobantesProveedores.MesImputacion  in (" & MesImp & ") AND (Proveedor.RSocial LIKE 'ADUANA%'))"
        Else
            CadenaSQL = CadenaSQL & " Where (ComprobantesPercepcionesIB.Percepcion <> 0) AND (ComprobantesProveedores.MesImputacion  in (" & MesImp & "))  AND (ComprobantesProveedores.MesImputacion  in (" & MesImp & ") AND (Proveedor.RSocial NOT LIKE 'ADUANA%'))"
        End If
        CadenaSQL = CadenaSQL & "ORDER BY Bancos.dbo.Provincia.DescProvincia, Proveedor.RSocial"

        ' Reemplazar Conect por tu método de obtención de DataTable (ServidorSql.GetTabla)
        dt = ServidorSQl.GetTabla(CadenaSQL)

        If dt Is Nothing Then
            GoTo errores
        ElseIf dt.Rows.Count = 0 Then
            ObtenerPercepcionesIBMesImputacion = 0
        Else
            ObtenerPercepcionesIBMesImputacion = 1
        End If

        Exit Function
errores:
        ObtenerPercepcionesIBMesImputacion = -1
    End Function


    Public Function ObtenerComprobantesdelMes(ByVal fecha As DateTime, ByVal fechaHasta As DateTime, ByRef dt As DataTable) As Long
        Dim var As String
        On Error GoTo errores

        var = fecha.ToString("MM/yyyy")

        CadenaSQL = "SELECT ComprobantesProveedores.TipoGrupo, ComprobantesProveedores.TipoComp,
                    (CASE
                        WHEN ComprobantesProveedores.TipoGrupo IN (1,2,3,4,5,6,9,10,11) THEN CONVERT(varchar(4), LEFT(ComprobantesProveedores.NroComp, (LEN(ComprobantesProveedores.NroComp)-8)))
                        WHEN ComprobantesProveedores.TipoGrupo IN (7,8) THEN '0000'
                    END) AS NroSucursal,
                    ComprobantesProveedores.NroComp, ComprobantesProveedores.DescComp, ComprobantesProveedores.FechaComp,
                    ComprobantesProveedores.FechaVto, CONVERT(date, ComprobantesProveedores.FechaCarga) AS FechaCarga,
                    ComprobantesProveedores.IvaProd,
                    (CASE ComprobantesProveedores.DescComp WHEN 23 THEN 0 ELSE ComprobantesProveedores.ImporteProd END) AS ImporteProd,
                    ComprobantesProveedores.PercepIva, ComprobantesProveedores.PercepGan, ComprobantesProveedores.TotalPercepIB,
                    ComprobantesProveedores.ImporteNoImp,
                    (CASE ComprobantesProveedores.DescComp WHEN 23 THEN ComprobantesProveedores.TotalComprobante
                        ELSE ComprobantesProveedores.IvaProd + ComprobantesProveedores.ImporteProd + ComprobantesProveedores.PercepIva +
                             ComprobantesProveedores.PercepGan + ComprobantesProveedores.TotalPercepIB + ComprobantesProveedores.ImporteNoImp
                    END) AS TotalComprobante,
                    ComprobantesProveedores.NroInterno, ComprobantesProveedores.NroProveedor, Proveedor.RSocial,
                    ComprobantesProveedores.NroCompAlfanumerico, Proveedor.CodTipoInsumosProveedor AS TipoInsumo
                FROM ComprobantesProveedores
                INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor
                WHERE mesimputacion ='" & var & "'
                ORDER BY ComprobantesProveedores.FechaCarga, ComprobantesProveedores.nrointerno
"

        ' Reemplazar Conect por tu método de obtención de DataTable (ServidorSql.GetTabla)
        dt = ServidorSQl.GetTabla(CadenaSQL)

        If dt Is Nothing Then
            GoTo errores
        ElseIf dt.Rows.Count = 0 Then
            ObtenerComprobantesdelMes = 0
        Else
            ObtenerComprobantesdelMes = 1
        End If

        Exit Function
errores:
        ObtenerComprobantesdelMes = -1
    End Function


    Public Function ObtenerComprobantesdelMesSinAnticipos(ByVal fecha As DateTime, ByVal fechaHasta As DateTime, ByRef dt As DataTable) As Long
        Dim var As String
        On Error GoTo errores

        var = fecha.ToString("MM/yyyy")

        CadenaSQL = "SELECT ComprobantesProveedores.TipoGrupo, ComprobantesProveedores.TipoComp," &
              " (CASE WHEN ComprobantesProveedores.TipoGrupo IN (1,2,3,4,5,6,11) THEN CONVERT(varchar(4), LEFT(ComprobantesProveedores.NroComp, (LEN(ComprobantesProveedores.NroComp)-8))) WHEN ComprobantesProveedores.TipoGrupo IN (7,8,9,10) THEN '0000' END) AS NroSucursal" &
              " , ComprobantesProveedores.NroComp, ComprobantesProveedores.DescComp, ComprobantesProveedores.FechaComp, ComprobantesProveedores.FechaVto, CONVERT (date, ComprobantesProveedores.FechaCarga) as FechaCarga, ComprobantesProveedores.IvaProd, " &
              " (SELECT CASE ComprobantesProveedores.DescComp " &
              " WHEN 23 THEN 0 ELSE ComprobantesProveedores.ImporteProd END) AS ImporteProd ," &
              " ComprobantesProveedores.PercepIva, ComprobantesProveedores.PercepGan, ComprobantesProveedores.TotalPercepIB, ComprobantesProveedores.ImporteNoImp, " &
              " (SELECT CASE ComprobantesProveedores.DescComp WHEN 23 THEN ComprobantesProveedores.TotalComprobante ELSE ComprobantesProveedores.IvaProd + ComprobantesProveedores.ImporteProd + ComprobantesProveedores.PercepIva + ComprobantesProveedores.PercepGan + ComprobantesProveedores.TotalPercepIB + ComprobantesProveedores.ImporteNoImp END) AS TotalComprobante" &
              " , ComprobantesProveedores.NroInterno, ComprobantesProveedores.NroProveedor , Proveedor.RSocial , ComprobantesProveedores.mesimputacion, ComprobantesProveedores.NroCompAlfanumerico,Proveedor.CodTipoInsumosProveedor AS TipoInsumo" &
              " FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor" &
              " WHERE mesimputacion ='" & var & "' AND DescComp NOT IN (11, 13, 15, 16) ORDER BY ComprobantesProveedores.FechaCarga, ComprobantesProveedores.nrointerno"

        ' Reemplazar Conect por tu método de obtención de DataTable (ServidorSql.GetTabla)
        dt = ServidorSQl.GetTabla(CadenaSQL)

        If dt Is Nothing Then
            GoTo errores
        ElseIf dt.Rows.Count = 0 Then
            ObtenerComprobantesdelMesSinAnticipos = 0
        Else
            ObtenerComprobantesdelMesSinAnticipos = 1
        End If

        Exit Function
errores:
        ObtenerComprobantesdelMesSinAnticipos = -1
    End Function

    Public Function ListadoInsumosPorCuenta(ByVal NroCuenta As Double, ByVal Mes As Integer, ByVal Anio As Integer, ByRef dt As DataTable) As Long
        Dim Fecha As String

        Fecha = Mes.ToString("00") & "/" & Anio
        On Error GoTo errores

        CadenaSQL = "SELECT ComprobantesProveedores.FechaComp," &
              " (CASE WHEN ComprobantesProveedores.TipoGrupo IN (1,2,3,4,5,6,9,11) THEN CONVERT(varchar(4), LEFT(ComprobantesProveedores.NroComp, (LEN(ComprobantesProveedores.NroComp)-8)))" &
              " WHEN ComprobantesProveedores.TipoGrupo IN (7,8) THEN '0000' END) AS prefijo, " &
              " RIGHT(RTRIM(CONVERT(VARCHAR(15), ComprobantesProveedores.NroComp)), 8) AS NumeroComp," &
              " RTRIM(dc.descripcion) + '-' + RTRIM(tc.descripcion) + '-' + " &
              " (CASE WHEN ComprobantesProveedores.TipoGrupo IN (1,2,3,4,5,6,9,11) THEN CONVERT(varchar(4), LEFT(ComprobantesProveedores.NroComp, (LEN(ComprobantesProveedores.NroComp)-8)))" &
              " WHEN ComprobantesProveedores.TipoGrupo IN (7,8) THEN '0000' END) + '-' + RIGHT(RTRIM(CONVERT(VARCHAR(15), ComprobantesProveedores.NroComp)), 8) AS NroComp," &
              " ComprobantesProveedores.NroInterno, ComprobantesOrdenes.DescInsumo, Proveedor.RSocial, Proveedor.NroProveedor," &
              " (CASE WHEN ComprobantesProveedores.TipoGrupo IN (3,6,8,10) THEN ComprobantesOrdenes.cantidad * -1 ELSE ComprobantesOrdenes.cantidad END) AS cantidad," &
              " (CASE WHEN ComprobantesProveedores.TipoGrupo IN (3,6,8,10) THEN ComprobantesOrdenes.precio * -1 ELSE ComprobantesOrdenes.precio END) AS Precio ," &
              " (CASE WHEN ComprobantesProveedores.TipoGrupo IN (3,6,8,10) THEN (ComprobantesOrdenes.cantidad * ComprobantesOrdenes.precio) * -1 ELSE (ComprobantesOrdenes.cantidad * ComprobantesOrdenes.precio) END) AS Total" &
              " FROM ComprobantesProveedores INNER JOIN ComprobantesOrdenes ON ComprobantesProveedores.NroInterno = ComprobantesOrdenes.NroInterno" &
              " INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor INNER JOIN Insumos ON ComprobantesOrdenes.CodInsumo = Insumos.codInsumo" &
              " , tiposcomprobantes TC, DescripcionComprobantes DC" &
              " WHERE comprobantesproveedores.mesimputacion='" & Fecha & "' AND insumos.codcuenta=" & NroCuenta &
              " AND comprobantesproveedores.tipocomp=TC.codigo AND ComprobantesProveedores.DescComp=DC.Codigo " &
              " ORDER BY fechacomp, Proveedor.nroproveedor"

        ' Reemplazar Conect por tu método de obtención de DataTable (ServidorSql.GetTabla)
        dt = ServidorSQl.GetTabla(CadenaSQL)

        If dt Is Nothing Then
            GoTo errores
        ElseIf dt.Rows.Count = 0 Then
            ListadoInsumosPorCuenta = 0
        Else
            ListadoInsumosPorCuenta = 1
        End If

        Exit Function
errores:
        ListadoInsumosPorCuenta = -1
    End Function

    Public Function ObtenerAsientoComprasNuevoNuevo(ByVal Mes As Integer, ByVal Anio As Integer, ByRef dt As DataTable, ByVal TiposComp As String) As Long
        Dim sql1 As String
        Dim Fecha As String
        Dim Agregado As Boolean
        Dim Bandera As Boolean
        Dim ultimaposicion As Long
        Dim i As Long
        Dim sumaF As Long
        Dim sumaC As Long

        Agregado = False
        Bandera = False

        ' Crear la estructura del DataTable
        dt = New DataTable()
        dt.Columns.Add("Codcuenta", GetType(String))
        dt.Columns.Add("DV", GetType(String))
        dt.Columns.Add("CodInsumo", GetType(Double))
        dt.Columns.Add("Descripcion", GetType(String))
        dt.Columns.Add("Totales", GetType(Double))

        On Error GoTo errores
        Fecha = Mes.ToString("00") & "/" & Anio

        sql1 = "SELECT SUM(Total) AS Totales, CodInsumo, Descripcion, codCuenta, DV" &
               " FROM (SELECT TOP 10000000 (ComprobantesOrdenes.precio*ComprobantesOrdenes.cantidad) as Total, ComprobantesOrdenes.CodInsumo, Insumos.Descripcion, Insumos.codCuenta,Insumos.DV FROM ComprobantesProveedores INNER JOIN ComprobantesOrdenes ON ComprobantesProveedores.NroInterno = ComprobantesOrdenes.NroInterno LEFT OUTER JOIN Insumos ON ComprobantesOrdenes.CodInsumo = Insumos.codInsumo" &
               " WHERE (ComprobantesProveedores.MesImputacion = '" & Fecha & "') " & TiposComp & "  " &
               " ) t GROUP BY codCuenta, DV, CodInsumo, Descripcion ORDER BY codCuenta DESC, DV, CodInsumo, Descripcion"

        ' Reemplazar Conect por tu método de obtención de DataTable (ServidorSql.GetTabla)
        dt = ServidorSQl.GetTabla(sql1)

        If dt Is Nothing Or dt.Rows.Count = 0 Then
            ObtenerAsientoComprasNuevoNuevo = 0
        Else
            ObtenerAsientoComprasNuevoNuevo = 1
        End If

        Exit Function
errores:
        ObtenerAsientoComprasNuevoNuevo = -1
    End Function

    Public Function ObtenerComprobantesDelMes27(ByVal Mes As Integer, ByVal Anio As Integer, ByRef dt As DataTable) As Long
        Dim var As String

        ' Crear la estructura del DataTable
        dt = New DataTable()
        dt.Columns.Add("RSocial", GetType(String))
        dt.Columns.Add("NroInterno", GetType(Integer))
        dt.Columns.Add("NroProveedor", GetType(Integer))
        dt.Columns.Add("DescComp", GetType(String))
        dt.Columns.Add("TipoComp", GetType(Integer))
        dt.Columns.Add("NroComp", GetType(Integer))
        dt.Columns.Add("FechaComp", GetType(Date))
        dt.Columns.Add("FechaVto", GetType(Date))
        dt.Columns.Add("CondicionPago", GetType(String))
        dt.Columns.Add("IvaProd", GetType(Double))
        dt.Columns.Add("ImporteProd", GetType(Double))
        dt.Columns.Add("PercepIva", GetType(Double))
        dt.Columns.Add("PercepGan", GetType(Double))
        dt.Columns.Add("TotalPercepIB", GetType(Double))
        dt.Columns.Add("ImporteNoImp", GetType(Double))
        dt.Columns.Add("TotalComprobante", GetType(Double))
        dt.Columns.Add("FechaCarga", GetType(Date))
        dt.Columns.Add("TipoGrupo", GetType(Integer))
        dt.Columns.Add("NroCompAlfanumerico", GetType(String))
        On Error GoTo errores
        var = Mes.ToString("00") & "/" & Anio
        CadenaSQL = "SELECT Proveedor.RSocial, ComprobantesProveedores.NroInterno, ComprobantesProveedores.NroProveedor, ComprobantesProveedores.DescComp, ComprobantesProveedores.TipoComp, ComprobantesProveedores.NroComp, ComprobantesProveedores.FechaComp, ComprobantesProveedores.FechaVto, ComprobantesProveedores.CondicionPago, ComprobantesProveedores.IvaProd, ComprobantesProveedores.ImporteProd, ComprobantesProveedores.PercepIva, ComprobantesProveedores.PercepGan, ComprobantesProveedores.TotalPercepIB, ComprobantesProveedores.ImporteNoImp, ComprobantesProveedores.TotalComprobante, CONVERT(date, ComprobantesProveedores.FechaCarga) as FechaCarga, -1 as TipoGrupo,ComprobantesProveedores.NroCompAlfanumerico" &
              " FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor" &
              " WHERE (ComprobantesProveedores.IvaProd >= 0.26 * ComprobantesProveedores.ImporteProd) AND (ComprobantesProveedores.IvaProd > 0) AND ComprobantesProveedores.imp25 = 0 AND mesimputacion ='" & var & "'  ORDER BY ComprobantesProveedores.FechaCarga, ComprobantesProveedores.nrointerno"

        ' Reemplazar Conect por tu método de obtención de DataTable (ServidorSql.GetTabla)
        dt = ServidorSQl.GetTabla(CadenaSQL)

        If dt Is Nothing Or dt.Rows.Count = 0 Then
            ObtenerComprobantesDelMes27 = 0
        Else
            ObtenerComprobantesDelMes27 = 1
        End If

        Exit Function
errores:
        ObtenerComprobantesDelMes27 = -1
    End Function

    Public Function ObtenerComprobantesDelMes75(ByVal Mes As Integer, ByVal Anio As Integer, ByRef dt As DataTable) As Long
        Dim var As String

        ' Crear la estructura del DataTable
        dt = New DataTable()
        dt.Columns.Add("RSocial", GetType(String))
        dt.Columns.Add("NroInterno", GetType(Integer))
        dt.Columns.Add("NroProveedor", GetType(Integer))
        dt.Columns.Add("DescComp", GetType(String))
        dt.Columns.Add("TipoComp", GetType(Integer))
        dt.Columns.Add("NroComp", GetType(Integer))
        dt.Columns.Add("FechaComp", GetType(Date))
        dt.Columns.Add("FechaVto", GetType(Date))
        dt.Columns.Add("CondicionPago", GetType(String))
        dt.Columns.Add("IvaProd", GetType(Double))
        dt.Columns.Add("ImporteProd", GetType(Double))
        dt.Columns.Add("PercepIva", GetType(Double))
        dt.Columns.Add("PercepGan", GetType(Double))
        dt.Columns.Add("TotalPercepIB", GetType(Double))
        dt.Columns.Add("ImporteNoImp", GetType(Double))
        dt.Columns.Add("Imp25", GetType(Double))
        dt.Columns.Add("TotalComprobante", GetType(Double))
        dt.Columns.Add("FechaCarga", GetType(Date))
        dt.Columns.Add("TipoGrupo", GetType(Integer))
        dt.Columns.Add("NroCompAlfanumerico", GetType(String))
        On Error GoTo errores
        var = Mes.ToString("00") & "/" & Anio
        CadenaSQL = "SELECT Proveedor.RSocial, ComprobantesProveedores.NroInterno, ComprobantesProveedores.NroProveedor, ComprobantesProveedores.DescComp, ComprobantesProveedores.TipoComp, ComprobantesProveedores.NroComp, ComprobantesProveedores.FechaComp, ComprobantesProveedores.FechaVto, ComprobantesProveedores.CondicionPago, ComprobantesProveedores.IvaProd, ComprobantesProveedores.ImporteProd, ComprobantesProveedores.PercepIva, ComprobantesProveedores.PercepGan, ComprobantesProveedores.TotalPercepIB, ComprobantesProveedores.ImporteNoImp, ComprobantesProveedores.Imp25, ComprobantesProveedores.TotalComprobante, CONVERT(date, ComprobantesProveedores.FechaCarga) as FechaCarga, -1 as TipoGrupo,ComprobantesProveedores.NroCompAlfanumerico" &
              " FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor" &
              " WHERE (ComprobantesProveedores.Imp25 <> 0) AND mesimputacion = '" & var & "' ORDER BY ComprobantesProveedores.FechaCarga, ComprobantesProveedores.nrointerno"

        ' Reemplazar Conect por tu método de obtención de DataTable (ServidorSql.GetTabla)
        dt = ServidorSQl.GetTabla(CadenaSQL)

        If dt Is Nothing Or dt.Rows.Count = 0 Then
            ObtenerComprobantesDelMes75 = 0
        Else
            ObtenerComprobantesDelMes75 = 1
        End If

        Exit Function
errores:
        ObtenerComprobantesDelMes75 = -1
    End Function

    Public Function ObtenerComprobantesDelMes75DesHas(ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByRef dt As DataTable) As Long

        ' Crear la estructura del DataTable
        dt = New DataTable()
        dt.Columns.Add("RSocial", GetType(String))
        dt.Columns.Add("NroInterno", GetType(Integer))
        dt.Columns.Add("NroProveedor", GetType(Integer))
        dt.Columns.Add("DescComp", GetType(String))
        dt.Columns.Add("TipoComp", GetType(Integer))
        dt.Columns.Add("NroComp", GetType(Integer))
        dt.Columns.Add("FechaComp", GetType(Date))
        dt.Columns.Add("FechaVto", GetType(Date))
        dt.Columns.Add("CondicionPago", GetType(String))
        dt.Columns.Add("IvaProd", GetType(Double))
        dt.Columns.Add("ImporteProd", GetType(Double))
        dt.Columns.Add("PercepIva", GetType(Double))
        dt.Columns.Add("PercepGan", GetType(Double))
        dt.Columns.Add("TotalPercepIB", GetType(Double))
        dt.Columns.Add("ImporteNoImp", GetType(Double))
        dt.Columns.Add("Imp25", GetType(Double))
        dt.Columns.Add("TotalComprobante", GetType(Double))
        dt.Columns.Add("FechaCarga", GetType(Date))
        dt.Columns.Add("TipoGrupo", GetType(Integer))
        dt.Columns.Add("NroCompAlfanumerico", GetType(String))
        On Error GoTo errores
        CadenaSQL = "SELECT Proveedor.RSocial, ComprobantesProveedores.NroInterno, ComprobantesProveedores.NroProveedor, ComprobantesProveedores.DescComp, 
                    ComprobantesProveedores.TipoComp, ComprobantesProveedores.NroComp, ComprobantesProveedores.FechaComp, ComprobantesProveedores.FechaVto, 
                    ComprobantesProveedores.CondicionPago, ComprobantesProveedores.IvaProd, ComprobantesProveedores.ImporteProd, ComprobantesProveedores.PercepIva, 
                    ComprobantesProveedores.PercepGan, ComprobantesProveedores.TotalPercepIB, ComprobantesProveedores.ImporteNoImp, ComprobantesProveedores.Imp25, 
                    ComprobantesProveedores.TotalComprobante, CONVERT(date, ComprobantesProveedores.FechaCarga) as FechaCarga, -1 as TipoGrupo,
                    ComprobantesProveedores.NroCompAlfanumerico" &
              " FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor" &
              " WHERE (ComprobantesProveedores.Imp25 <> 0) AND FechaComp >= '" & fechaDesde.ToString("yyyy-MM-dd") & "' AND FechaComp <= '" & fechaHasta.ToString("yyyy-MM-dd") & "' ORDER BY ComprobantesProveedores.FechaCarga, ComprobantesProveedores.nrointerno"

        ' Reemplazar Conect por tu método de obtención de DataTable (ServidorSql.GetTabla)
        dt = ServidorSQl.GetTabla(CadenaSQL)

        If dt Is Nothing Or dt.Rows.Count = 0 Then
            ObtenerComprobantesDelMes75DesHas = 0
        Else
            ObtenerComprobantesDelMes75DesHas = 1
        End If

        Exit Function
errores:
        ObtenerComprobantesDelMes75DesHas = -1
    End Function


    Public Function ObtenerCreditosMes(ByVal Mes As Integer, ByVal Anio As Integer, ByRef dt As DataTable) As Long
        Dim var As String

        ' Crear la estructura del DataTable
        dt = New DataTable()
        dt.Columns.Add("RSocial", GetType(String))
        dt.Columns.Add("NroInterno", GetType(Integer))
        dt.Columns.Add("NroProveedor", GetType(Integer))
        dt.Columns.Add("DescComp", GetType(Integer))
        dt.Columns.Add("TipoComp", GetType(Integer))
        dt.Columns.Add("NroComp", GetType(Integer))
        dt.Columns.Add("FechaComp", GetType(Date))
        dt.Columns.Add("FechaVto", GetType(Date))
        dt.Columns.Add("CondicionPago", GetType(String))
        dt.Columns.Add("IvaProd", GetType(Double))
        dt.Columns.Add("ImporteProd", GetType(Double))
        dt.Columns.Add("PercepIva", GetType(Double))
        dt.Columns.Add("PercepGan", GetType(Double))
        dt.Columns.Add("TotalPercepIB", GetType(Double))
        dt.Columns.Add("ImporteNoImp", GetType(Double))
        dt.Columns.Add("TotalComprobante", GetType(Double))
        dt.Columns.Add("FechaCarga", GetType(Date))
        dt.Columns.Add("TipoGrupo", GetType(Integer))
        dt.Columns.Add("NroCompAlfanumerico", GetType(String))
        On Error GoTo errores
        var = Format(Mes, "00") & "/" & Anio

        ' Reemplazar Conect por tu método de obtención de DataTable (ServidorSql.GetTabla)
        CadenaSQL = "SELECT Proveedor.RSocial, ComprobantesProveedores.NroInterno, ComprobantesProveedores.NroProveedor, ComprobantesProveedores.DescComp, ComprobantesProveedores.TipoComp, ComprobantesProveedores.NroComp, ComprobantesProveedores.FechaComp, ComprobantesProveedores.FechaVto, ComprobantesProveedores.CondicionPago, ComprobantesProveedores.IvaProd, ComprobantesProveedores.ImporteProd, ComprobantesProveedores.PercepIva, ComprobantesProveedores.PercepGan, ComprobantesProveedores.TotalPercepIB, ComprobantesProveedores.ImporteNoImp, ComprobantesProveedores.TotalComprobante, ComprobantesProveedores.FechaCarga, ComprobantesProveedores.TipoGrupo,ComprobantesProveedores.NroCompAlfanumerico" &
              " FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor" &
              " WHERE DescComp IN (7,8,9,10,11,12,18,20) AND mesimputacion = '" & var & "' ORDER BY ComprobantesProveedores.FechaCarga, ComprobantesProveedores.nrointerno"

        ' Reemplazar Conect por tu método de obtención de DataTable (ServidorSql.GetTabla)
        dt = ServidorSQl.GetTabla(CadenaSQL)

        If dt Is Nothing Or dt.Rows.Count = 0 Then
            ObtenerCreditosMes = 0
        Else
            ObtenerCreditosMes = 1
        End If

        Exit Function
errores:
        ObtenerCreditosMes = -1
    End Function

    Public Function ObtenerRemitosMesCurso(ByVal Mes As Integer, ByVal Anio As Integer, ByRef dt As DataTable) As Long
        Dim var As String

        ' Crear la estructura del DataTable
        dt = New DataTable()
        dt.Columns.Add("RSocial", GetType(String))
        dt.Columns.Add("NroInterno", GetType(Integer))
        dt.Columns.Add("NroProveedor", GetType(Integer))
        dt.Columns.Add("DescComp", GetType(Integer))
        dt.Columns.Add("TipoComp", GetType(Integer))
        dt.Columns.Add("NroComp", GetType(Integer))
        dt.Columns.Add("FechaComp", GetType(Date))
        dt.Columns.Add("FechaVto", GetType(Date))
        dt.Columns.Add("CondicionPago", GetType(String))
        dt.Columns.Add("IvaProd", GetType(Double))
        dt.Columns.Add("ImporteProd", GetType(Double))
        dt.Columns.Add("PercepIva", GetType(Double))
        dt.Columns.Add("PercepGan", GetType(Double))
        dt.Columns.Add("TotalPercepIB", GetType(Double))
        dt.Columns.Add("ImporteNoImp", GetType(Double))
        dt.Columns.Add("TotalComprobante", GetType(Double))
        dt.Columns.Add("FechaCarga", GetType(Date))
        dt.Columns.Add("TipoGrupo", GetType(Integer))
        dt.Columns.Add("NroCompAlfanumerico", GetType(String))
        On Error GoTo errores
        var = Format(Mes, "00") & "/" & Anio

        ' Reemplazar Conect por tu método de obtención de DataTable (ServidorSql.GetTabla)
        CadenaSQL = "SELECT Proveedor.RSocial, ComprobantesProveedores.NroInterno, ComprobantesProveedores.NroProveedor, ComprobantesProveedores.DescComp, ComprobantesProveedores.TipoComp, ComprobantesProveedores.NroComp, ComprobantesProveedores.FechaComp, ComprobantesProveedores.FechaVto, ComprobantesProveedores.CondicionPago, ComprobantesProveedores.IvaProd, ComprobantesProveedores.ImporteProd, ComprobantesProveedores.PercepIva, ComprobantesProveedores.PercepGan, ComprobantesProveedores.TotalPercepIB, ComprobantesProveedores.ImporteNoImp, ComprobantesProveedores.TotalComprobante, ComprobantesProveedores.FechaCarga, ComprobantesProveedores.TipoGrupo,ComprobantesProveedores.NroCompAlfanumerico" &
              " FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor" &
              " WHERE DescComp = 2 AND mesimputacion IS NULL ORDER BY ComprobantesProveedores.FechaCarga, ComprobantesProveedores.nrointerno"

        ' Reemplazar Conect por tu método de obtención de DataTable (ServidorSql.GetTabla)
        dt = ServidorSQl.GetTabla(CadenaSQL)

        If dt Is Nothing Or dt.Rows.Count = 0 Then
            ObtenerRemitosMesCurso = 0
        Else
            ObtenerRemitosMesCurso = 1
        End If

        Exit Function
errores:
        ObtenerRemitosMesCurso = -1
    End Function

    Public Function SeguirFacturasInternas(ByVal NroInterno As Double, ByRef dt As DataTable) As Long
        ' Crear la estructura del DataTable
        dt = New DataTable()
        dt.Columns.Add("TipoGrupo", GetType(Integer))
        dt.Columns.Add("NroInterno", GetType(Double))
        dt.Columns.Add("NroOC", GetType(String))
        dt.Columns.Add("NroParte", GetType(String))

        On Error GoTo errores

        ' Reemplazar Conect por tu método de obtención de DataTable (ServidorSql.GetTabla)
        CadenaSQL = "SELECT DISTINCT ComprobantesProveedores.tipogrupo,ComprobantesProveedores.NroInterno, NrosIngresoNrosOC.NroOC, DetalleIngresoInsumo.NroParte FROM ComprobantesProveedores INNER JOIN ComprobantesOrdenes ON ComprobantesProveedores.NroInterno = ComprobantesOrdenes.NroInterno INNER JOIN NrosIngresoNrosOC ON ComprobantesOrdenes.NroIngreso = NrosIngresoNrosOC.NroIngreso INNER JOIN DetalleIngresoInsumo ON NrosIngresoNrosOC.NroIngreso = DetalleIngresoInsumo.NroIngreso WHERE ComprobantesProveedores.Nrointerno = " & NroInterno

        ' Reemplazar Conect por tu método de obtención de DataTable (ServidorSql.GetTabla)
        dt = ServidorSQl.GetTabla(CadenaSQL)

        If dt Is Nothing Or dt.Rows.Count = 0 Then
            SeguirFacturasInternas = 0
        Else
            SeguirFacturasInternas = 1
        End If

        Exit Function

errores:
        SeguirFacturasInternas = -1
    End Function

    Public Function BuscarComprobantePorNroInterno(ByVal NroInterno As Long, ByRef dt As DataTable) As Long
        ' Crear la estructura del DataTable
        dt = New DataTable()
        dt.Columns.Add("TipoGrupo", GetType(Integer))
        dt.Columns.Add("TipoComp", GetType(String))
        dt.Columns.Add("NroComp", GetType(String))
        dt.Columns.Add("DescComp", GetType(String))
        dt.Columns.Add("FechaComp", GetType(Date))
        dt.Columns.Add("FechaVto", GetType(Date))
        dt.Columns.Add("FechaCarga", GetType(Date))
        dt.Columns.Add("IvaProd", GetType(Double))
        dt.Columns.Add("ImporteProd", GetType(Double))
        dt.Columns.Add("PercepIva", GetType(Double))
        dt.Columns.Add("PercepGan", GetType(Double))
        dt.Columns.Add("TotalPercepIB", GetType(Double))
        dt.Columns.Add("ImporteNoImp", GetType(Double))
        dt.Columns.Add("TotalComprobante", GetType(Double))
        dt.Columns.Add("NroInterno", GetType(Long))
        dt.Columns.Add("NroProveedor", GetType(String))
        dt.Columns.Add("RSocial", GetType(String))

        On Error GoTo errores

        ' Reemplazar Conect por tu método de obtención de DataTable (ServidorSql.GetTabla)
        Dim sql As String = "SELECT ComprobantesProveedores.Tipogrupo,ComprobantesProveedores.TipoComp, ComprobantesProveedores.NroComp, ComprobantesProveedores.DescComp,ComprobantesProveedores.FechaComp, ComprobantesProveedores.FechaVto, CONVERT (date, ComprobantesProveedores.FechaCarga) as FechaCarga,ComprobantesProveedores.IvaProd, ComprobantesProveedores.ImporteProd, ComprobantesProveedores.PercepIva,ComprobantesProveedores.PercepGan, ComprobantesProveedores.TotalPercepIB, ComprobantesProveedores.ImporteNoImp, ComprobantesProveedores.IvaProd + ComprobantesProveedores.ImporteProd + ComprobantesProveedores.PercepIva + ComprobantesProveedores.PercepGan + ComprobantesProveedores.TotalPercepIB + ComprobantesProveedores.ImporteNoImp AS TotalComprobante, ComprobantesProveedores.NroInterno, ComprobantesProveedores.NroPRoveedor , Proveedor.RSocial " _
            & " FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor" _
            & " WHERE ComprobantesProveedores.NroInterno=" & NroInterno & "  ORDER BY ComprobantesProveedores.FechaCarga, ComprobantesProveedores.nrointerno "

        ' Reemplazar Conect por tu método de obtención de DataTable (ServidorSql.GetTabla)
        dt = ServidorSQl.GetTabla(sql)

        If dt Is Nothing Or dt.Rows.Count = 0 Then
            BuscarComprobantePorNroInterno = 0
        Else
            BuscarComprobantePorNroInterno = 1
        End If

        Exit Function

errores:
        BuscarComprobantePorNroInterno = -1
    End Function

    Public Sub BuscarDatosDeParte(ByVal NroParte As Long)
        Dim items As DataTable = New DataTable()
        Dim Datos As DataTable = New DataTable()

        Select Case BuscarIngresos(NroParte, Datos, items)
            Case 0
                MsgBox("El Parte Buscado No Existe.", MsgBoxStyle.Information)

            Case 1
                ' Datos de IngresoInsumos
                Dim sql As String = "SELECT * FROM ObservacionesIngresoInsumos WHERE NroParte=" & NroParte
                Rst = ServidorSQl.GetTabla(sql)

            Case -1
                MsgBox("Se produjo un error al buscar el Parte Especificado.", MsgBoxStyle.Critical)
                Exit Sub
        End Select
    End Sub

    Private Shared Function BuscarIngresos(ByVal NroParte As Long, ByRef Datos As DataTable, ByRef items As DataTable) As Integer
        On Error GoTo errores

        Dim sqlDatos As String = "SELECT * FROM IngresoInsumos WHERE NroParte=" & NroParte
        Dim sqlItems As String = "SELECT DetalleIngresoInsumo.*, NrosIngresoNrosOC.NroOC AS NroOC FROM DetalleIngresoInsumo LEFT OUTER JOIN NrosIngresoNrosOC ON DetalleIngresoInsumo.NroIngreso = NrosIngresoNrosOC.NroIngreso WHERE detalleingresoinsumo.NroParte=" & NroParte

        Datos = ServidorSQl.GetTabla(sqlDatos)
        If Datos Is Nothing OrElse Datos.Rows.Count = 0 Then
            Return 0
        Else
            items = ServidorSQl.GetTabla(sqlItems)
            If items Is Nothing Then
                GoTo errores
            End If
            Return 1
        End If

        Exit Function
errores:
        Return -1
    End Function

    Public Function ValorTransporte(NroOrden As Long) As Boolean
        '------------------------------------------------------------------------
        'Descripción:
        '             En la impresión de O.C. muestra o no el label de transporte
        '             si el transporte es 120 (Marchetti Carlos Diego) lo muestra
        '
        'NroOrden   : Es la O.C que se está imprimiendo
        'Output     :
        '               True si se encontraron datos
        '               False si no se encontraron datos
        '               False Si hubo error al buscar datos
        '----------------------------------------------------------------

        CadenaSQL = "SELECT codtransporte FROM ordencompra WHERE codordencompra=" & NroOrden
        Dim resultTable As DataTable = ServidorSQl.GetTabla(CadenaSQL)

        If resultTable Is Nothing OrElse resultTable.Rows.Count = 0 Then
            Return False
        Else
            Dim codTransporte As Integer = Convert.ToInt32(resultTable.Rows(0)("codtransporte"))

            If codTransporte = 120 Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Public Function ObtenerComprobantesParaLiquidar(ByRef rec As DataTable, ByVal TipoCompPend As String, orden As Integer) As Long
        Try

            CadenaSQL = "Select ComprobantesProveedores.TipoGrupo , ComprobantesProveedores.condicionPago,ComprobantesProveedores.NroComp,ComprobantesProveedores.codestadoPago,ComprobantesProveedores.SaldoPendiente,ComprobantesProveedores.desccomp ,ComprobantesProveedores.NroProveedor as proveedor ,Proveedor.RSocial ,ComprobantesProveedores.NroInterno," _
            & " (case when ComprobantesProveedores.TipoGrupo in(1,2,3,4,5,6,9,10,11) then convert(varchar(4),left(ComprobantesProveedores.NroComp,(case when len(ComprobantesProveedores.NroComp) >=0 then len(ComprobantesProveedores.NroComp)-8 else 0 end))) when ComprobantesProveedores.TipoGrupo in(7,8) then '0000' end ) NroSucursal," _
            & " convert(varchar(8), right(ComprobantesProveedores.NroComp,8)) as NroFactura, ComprobantesProveedores.FechaComp, ComprobantesProveedores.FechaVto,  ComprobantesProveedores.TotalComprobante , (case when ComprobantesProveedores.SaldoPendiente = 0 then 0 Else (ComprobantesProveedores.TotalComprobante-ComprobantesProveedores.SaldoPendiente)END) as pagado  , 0 as importe,'' as observacion,0 as liq ," _
            & " (select sum(CP.totalcomprobante)  From comprobantesproveedores CP where CP.NroProveedor=ComprobantesProveedores.NroProveedor And CodEstadoPago=4) as TotalProveedor, TipoGrupo    ,codigosinsumosprovistos.descripcion as insumoprovisto ,codigosinsumosprovistos.codigo as codinsumoprovisto , ComprobantesProveedores.NroCompAlfanumerico , Proveedor.EsAduana,cpc.descripcion, CASE WHEN COALESCE(comprobantesproveedores.bloqueo, 0) = 1 THEN 1 ELSE 0 END AS bloqueo
              FROM ComprobantesProveedores
              INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor 
              inner join codigosinsumosprovistos on  codigosinsumosprovistos.codigo=proveedor.codtipoinsumosproveedor 
              INNER JOIN Proveedores.dbo.CondicionPagoComprobantes cpc on cpc.codigo = ComprobantesProveedores.condicionPago Where   "



            Select Case TipoCompPend
                Case "CompPendComun" ' CASO COMUN
                    CadenaSQL = CadenaSQL & "CobranzaGalicia = 0 and "
                Case "CompPendAlaOrden" 'DIF A LA ORDEN
                    CadenaSQL = CadenaSQL & "CobranzaGalicia = 1 and Proveedor.CodPapTipoPagoGaliciaDefault = 2 and "
                Case "CompPendNoAlaOrden"
                    CadenaSQL = CadenaSQL & "CobranzaGalicia = 1 and Proveedor.CodPapTipoPagoGaliciaDefault = 1 and "
                Case "TodosCompPend"
            End Select

            CadenaSQL = CadenaSQL & "ComprobantesProveedores.codestadopago in (4,3)  " _
            & " and" _
            & " ( ComprobantesProveedores.TotalComprobante -" _
            & " (" _
            & " case" _
            & " when (select sum(abs(importepagado)) from detalleliquidaciones where detalleliquidaciones.nrointerno=comprobantesproveedores.nrointerno) is null" _
            & " then" _
            & " 0" _
            & " Else" _
            & "     (case when (select sum(abs(importepagado)) from detalleliquidaciones where detalleliquidaciones.nrointerno=comprobantesproveedores.nrointerno) is null then  0 else (select sum(abs(importepagado)) from detalleliquidaciones where detalleliquidaciones.nrointerno=comprobantesproveedores.nrointerno) end)" _
            & " end)" _
            & " )>0"
            If orden = 0 Then
                CadenaSQL = CadenaSQL & " order by Comprobantesproveedores.nroproveedor, Comprobantesproveedores.fechacomp, Comprobantesproveedores.NroInterno"
            ElseIf orden = 2 Then
                CadenaSQL = CadenaSQL & " order by 'insumoprovisto',Comprobantesproveedores.nroproveedor,Comprobantesproveedores.fechacomp, Comprobantesproveedores.NroInterno"
            Else
                CadenaSQL = CadenaSQL & " order by Comprobantesproveedores.nroproveedor, ComprobantesProveedores.FechaVto, Comprobantesproveedores.NroInterno"
            End If

            rec = ServidorSQl.GetTabla(CadenaSQL)

            If rec Is Nothing OrElse rec.Rows.Count = 0 Then
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        End Try
    End Function


    Public Function ObtenerComprobantesParaLiquidarConXDiasFechaFact(ByRef rec As DataTable, ByVal TipoCompPend As String, ByVal DiasFecFact As Integer) As Long
        '-----------------------------------------------------
        'Descripción: Obtiene comprobantes que no fueron
        '           liquidados todavía con una fecha de factura inferior a X días.
        'Parámetros : DataTable para devolver datos
        'Output     : 1 ok, datos
        '            -1 Error al obtener datos.
        '             0 no se encontraron datos
        '-----------------------------------------------------
        Try

            CadenaSQL = "Select ComprobantesProveedores.TipoGrupo , ComprobantesProveedores.condicionPago,ComprobantesProveedores.NroComp,ComprobantesProveedores.codestadoPago,ComprobantesProveedores.SaldoPendiente,ComprobantesProveedores.desccomp ,ComprobantesProveedores.NroProveedor as proveedor ,Proveedor.RSocial ,ComprobantesProveedores.NroInterno," _
                & " (case when ComprobantesProveedores.TipoGrupo in(1,2,3,4,5,6,9,10,11) then convert(varchar(4),left(ComprobantesProveedores.NroComp,(case when len(ComprobantesProveedores.NroComp) >=0 then len(ComprobantesProveedores.NroComp)-8 else 0 end))) when ComprobantesProveedores.TipoGrupo in(7,8) then '0000' end ) NroSucursal," _
                & " convert(varchar(8), right(ComprobantesProveedores.NroComp,8)) as NroFactura, ComprobantesProveedores.FechaComp, ComprobantesProveedores.FechaVto,  ComprobantesProveedores.TotalComprobante , (case when ComprobantesProveedores.SaldoPendiente = 0 then 0 Else (ComprobantesProveedores.TotalComprobante-ComprobantesProveedores.SaldoPendiente)END) as pagado  , 0 as importe,'' as observacion,0 as liq ," _
                & " (select sum(CP.totalcomprobante)  From comprobantesproveedores CP where CP.NroProveedor=ComprobantesProveedores.NroProveedor And CodEstadoPago=4) as TotalProveedor, TipoGrupo    ,codigosinsumosprovistos.descripcion as insumoprovisto ,codigosinsumosprovistos.codigo as codinsumoprovisto , ComprobantesProveedores.NroCompAlfanumerico , Proveedor.EsAduana,cpc.descripcion 
                  FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor 
                  INNER JOIN codigosinsumosprovistos on  codigosinsumosprovistos.codigo=proveedor.codtipoinsumosproveedor 
                  INNER JOIN Proveedores.dbo.CondicionPagoComprobantes cpc on cpc.codigo = ComprobantesProveedores.condicionPago Where   "

            Select Case TipoCompPend
                Case "CompPendComun" ' CASO COMUN
                    CadenaSQL = CadenaSQL & "CobranzaGalicia = 0 and "
                Case "CompPendAlaOrden" 'DIF A LA ORDEN
                    CadenaSQL = CadenaSQL & "CobranzaGalicia = 1 and Proveedor.CodPapTipoPagoGaliciaDefault = 2 and "
                Case "CompPendNoAlaOrden"
                    CadenaSQL = CadenaSQL & "CobranzaGalicia = 1 and Proveedor.CodPapTipoPagoGaliciaDefault = 1 and "
                Case "TodosCompPend"
            End Select

            CadenaSQL = CadenaSQL & "ComprobantesProveedores.codestadopago in (4,3)  " _
                & " and" _
                & " ( ComprobantesProveedores.TotalComprobante -" _
                & " (" _
                & " case" _
                & " when (select sum(abs(importepagado)) from detalleliquidaciones where detalleliquidaciones.nrointerno=comprobantesproveedores.nrointerno) is null" _
                & " then" _
                & " 0" _
                & " Else" _
                & "     (case when (select sum(abs(importepagado)) from detalleliquidaciones where detalleliquidaciones.nrointerno=comprobantesproveedores.nrointerno) is null then  0 else (select sum(abs(importepagado)) from detalleliquidaciones where detalleliquidaciones.nrointerno=comprobantesproveedores.nrointerno) end)" _
                & " end)" _
                & " )>0" _
                & " and ComprobantesProveedores.FechaComp <= DATEADD(day,- " & DiasFecFact & ",GETDATE()) " _
                & " order by Comprobantesproveedores.nroproveedor, Comprobantesproveedores.fechacomp"

            rec = ServidorSQl.GetTabla(CadenaSQL)

            If rec Is Nothing OrElse rec.Rows.Count = 0 Then
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        End Try
    End Function


    Public Function ObtenerComprobantesDesdeHastaSinAnticipos(ByVal fechaDesde As String, ByVal fechaHasta As String, ByRef rec As DataTable) As Long
        '-----------------------------------------------------
        'Descripción: Obtiene comprobantes ingresados en el mes
        'Parámetros : fechaDesde, fechaHasta y DataTable por ref.
        'Output     : 1 se encontraron datos.
        '             0 No se encontraron datos.
        '            -1 Error al filtrar datos.
        '-----------------------------------------------------
        Try

            CadenaSQL = "SELECT ComprobantesProveedores.TipoGrupo, ComprobantesProveedores.TipoComp," _
                & " (CASE WHEN ComprobantesProveedores.TipoGrupo IN (1, 2, 3, 4, 5, 6, 9, 10, 11) THEN CONVERT(VARCHAR(4), LEFT(ComprobantesProveedores.NroComp, (LEN(ComprobantesProveedores.NroComp) - 8))) " _
                & " WHEN ComprobantesProveedores.TipoGrupo IN (7, 8) THEN '0000' END) AS NroSucursal," _
                & " ComprobantesProveedores.NroComp, ComprobantesProveedores.DescComp, ComprobantesProveedores.FechaComp," _
                & " ComprobantesProveedores.FechaVto, CONVERT(date, ComprobantesProveedores.FechaCarga) AS FechaCarga, " _
                & " ComprobantesProveedores.IvaProd, ComprobantesProveedores.ImporteProd, ComprobantesProveedores.PercepIva," _
                & " ComprobantesProveedores.PercepGan, ComprobantesProveedores.TotalPercepIB, ComprobantesProveedores.ImporteNoImp, " _
                & " ComprobantesProveedores.IvaProd + ComprobantesProveedores.ImporteProd + ComprobantesProveedores.PercepIva + " _
                & " ComprobantesProveedores.PercepGan + ComprobantesProveedores.TotalPercepIB + ComprobantesProveedores.ImporteNoImp AS TotalComprobante," _
                & " ComprobantesProveedores.NroInterno, ComprobantesProveedores.NroPRoveedor, Proveedor.RSocial, ComprobantesProveedores.mesimputacion," _
                & " ComprobantesProveedores.NroCompAlfanumerico, Proveedor.CodTipoInsumosProveedor AS TipoInsumo" _
                & " FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor" _
                & " WHERE ComprobantesProveedores.FechaCarga BETWEEN @FechaDesde AND @FechaHasta" _
                & " AND DescComp NOT IN (11, 13, 15, 16) AND MesImputacion IS NULL" _
                & " ORDER BY ComprobantesProveedores.FechaCarga, ComprobantesProveedores.nrointerno"

            Dim parametros As SqlParameter() = {
                New SqlParameter("@FechaDesde", fechaDesde),
                New SqlParameter("@FechaHasta", fechaHasta)
            }

            rec = ServidorSQl.GetTablaParam(CadenaSQL, parametros)

            If rec Is Nothing OrElse rec.Rows.Count = 0 Then
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        End Try
    End Function

    Public Function ObtenerDatosCompras(ByVal Desde As String, ByVal Hasta As String, ByRef rec As DataTable) As Long
        '-----------------------------------------------------
        'Descripción: Obtener detalle Comprobantes de compras
        'Parámetros : intérvalo de fecha, DataTable p/ datos
        'Output     : DataTable con Comprobantes
        '            0 No se encontraron datos .
        '            1 Encontró datos
        '            -1 Error al obtener datos
        '-----------------------------------------------------
        Try

            CadenaSQL = "SELECT ComprobantesProveedores.TipoGrupo, ComprobantesProveedores.CotizacionDolar, Proveedor.RSocial," _
                & " ComprobantesProveedores.NroInterno, ComprobantesProveedores.NroProveedor," _
                & " ComprobantesProveedores.FechaComp,ComprobantesProveedores.FechaVto," _
                & " ComprobantesProveedores.TotalComprobante,co.*,r.codrubro,r.descrubro,sr.codsubrubro,sr.descsubrubro" _
                & " FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor" _
                & " INNER JOIN ComprobantesOrdenes CO ON ComprobantesProveedores.NroInterno = CO.NroInterno" _
                & " INNER JOIN Insumos I ON I.CodInsumo = CO.CodInsumo" _
                & " INNER JOIN Rubros R ON I.CodArea = R.CodArea AND I.CodSubArea = R.CodSubArea AND I.CodRubro = R.CodRubro" _
                & " INNER JOIN SubRubros SR ON I.CodArea = SR.CodArea AND I.CodSubArea = SR.CodSubArea AND I.CodRubro = SR.CodRubro AND I.CodSubRubro = SR.CodSubRubro" _
                & " WHERE ComprobantesProveedores.FechaCarga BETWEEN @Desde AND @Hasta" _
                & " AND TipoGrupo IN (1, 2)" _
                & " ORDER BY R.DescRubro, SR.DescSubRubro, ComprobantesProveedores.FechaCarga, ComprobantesProveedores.NroInterno"

            Dim parametros As SqlParameter() = {
                New SqlParameter("@Desde", Desde & " 00:00:01"),
                New SqlParameter("@Hasta", Hasta & " 23:59:59")
            }

            rec = ServidorSQl.GetTablaParam(CadenaSQL, parametros)

            If rec Is Nothing OrElse rec.Rows.Count = 0 Then
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        End Try
    End Function

    Public Function BuscarTodosLosProveedores(ByRef DataTable As DataTable, ByVal orden As Boolean, ByVal Estado As String) As Long
        '-----------------------------------------------------
        'Descripción: Obtiene datos de todos los Proveedores
        'Parámetros : N° de proveedor
        '             DataTable por ref.
        'Output     : 1 se encontraron datos.
        '             0 no se encontraron datos
        '            -1 Error al obtener datos.
        '-----------------------------------------------------
        Try

            CadenaSQL = "SELECT REPLACE(DIRECCION,'§','º') AS DIRECCION, localidad, RSocial, NroProveedor, provincia, nrocuit, ingbrutos, CODPOSTAL, codtipoinsumosproveedor FROM Proveedor WHERE CodEstadoProveedor IN (" & Estado & ")"
            If orden Then
                CadenaSQL &= " ORDER BY Proveedor.NroProveedor"
            Else
                CadenaSQL &= " ORDER BY Proveedor.RSOCIAL"
            End If

            Dim parametros As SqlParameter() = {}

            DataTable = ServidorSQl.GetTablaParam(CadenaSQL, parametros)

            If DataTable Is Nothing OrElse DataTable.Rows.Count = 0 Then
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        End Try
    End Function


    Public Function ObtenerDatosPorTipoComprobante(ByVal TipoGrupo As Integer, ByVal MesImp As String, ByVal AnioImp As String, ByRef DataTable As DataTable, ByVal CodLetra As Integer) As Long
        '-----------------------------------------------------
        'Descripción: Obtener Comprobantes por Tipo de Comprobantes
        'Parámetros : Tipo de Comprobante
        'Output     : DataTable con Comprobantes
        '            0 No se encontraron datos.
        '            1 Encontró datos.
        '            -1 Error al obtener datos.
        '-----------------------------------------------------
        Try
            Dim tipoAutoriza As Integer
            Dim sumaTipoAutoriza As Integer
            tipoAutoriza = 0
            sumaTipoAutoriza = 0
            Dim Mes As String


            If Len(MesImp) = 2 Then
                Mes = "'" & MesImp & "/" & AnioImp & "'"
            Else
                Mes = "'0" & MesImp & "/" & AnioImp & "'"
            End If

            If CodLetra <> 0 Then
                CadenaSQL = "TipoComp = " & CodLetra & " and "
            Else
                CadenaSQL = ""
            End If

            If TipoGrupo <> 0 Then
                CadenaSQL &= " TipoGrupo = " & TipoGrupo & " and "
            Else
                CadenaSQL &= ""
            End If

            If Format(Trim(MesImp), "00") = Trim(Format(Now, "MM")) And Trim(AnioImp) = Trim(Format(Now, "yyyy")) Then
                CadenaSQL = "SELECT CONVERT(date, ComprobantesProveedores.FechaCarga) as FechaCarga, ComprobantesProveedores.TipoGrupo, case  when ComprobantesProveedores.CotizacionDolar = 0 
	                        then dbo.obtenerDolarSegunFecha (FechaCarga)
                            else ComprobantesProveedores.CotizacionDolar end as CotizacionDolar, Proveedor.RSocial, ComprobantesProveedores.NroInterno, ComprobantesProveedores.NroProveedor, ComprobantesProveedores.DescComp,ComprobantesProveedores.TipoComp, ComprobantesProveedores.NroComp, ComprobantesProveedores.FechaComp,ComprobantesProveedores.FechaVto, ComprobantesProveedores.CondicionPago, ComprobantesProveedores.IvaProd,ComprobantesProveedores.ImporteProd, ComprobantesProveedores.PercepIva, ComprobantesProveedores.PercepGan,ComprobantesProveedores.TotalPercepIB , ComprobantesProveedores.ImporteNoImp, ComprobantesProveedores.TotalComprobante,CONVERT(date, ComprobantesProveedores.FechaCarga) as FechaCarga, ComprobantesProveedores.NroCompAlfanumerico,Proveedor.CodTipoInsumosProveedor AS TipoInsumo " _
                    & " FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor" _
                    & " WHERE " & CadenaSQL & " ComprobantesProveedores.MesImputacion IS NULL  ORDER BY ComprobantesProveedores.FechaCarga,ComprobantesProveedores.nrointerno "

            Else
                CadenaSQL = "SELECT CONVERT(date, ComprobantesProveedores.FechaCarga) as FechaCarga, ComprobantesProveedores.TipoGrupo, case  when ComprobantesProveedores.CotizacionDolar = 0 
	                        then dbo.obtenerDolarSegunFecha (FechaCarga)
                            else ComprobantesProveedores.CotizacionDolar end as CotizacionDolar, Proveedor.RSocial, ComprobantesProveedores.NroInterno, ComprobantesProveedores.NroProveedor, ComprobantesProveedores.DescComp,ComprobantesProveedores.TipoComp, ComprobantesProveedores.NroComp, ComprobantesProveedores.FechaComp,ComprobantesProveedores.FechaVto, ComprobantesProveedores.CondicionPago, ComprobantesProveedores.IvaProd,ComprobantesProveedores.ImporteProd, ComprobantesProveedores.PercepIva, ComprobantesProveedores.PercepGan,ComprobantesProveedores.TotalPercepIB , ComprobantesProveedores.ImporteNoImp, ComprobantesProveedores.TotalComprobante,CONVERT(date, ComprobantesProveedores.FechaCarga) as FechaCarga, ComprobantesProveedores.NroCompAlfanumerico,Proveedor.CodTipoInsumosProveedor AS TipoInsumo" _
                    & " FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor" _
                    & " WHERE " & CadenaSQL & " ComprobantesProveedores.MesImputacion = " & Mes & "  ORDER BY ComprobantesProveedores.FechaCarga,ComprobantesProveedores.nrointerno "
            End If

            Dim parametros As SqlParameter() = {}

            DataTable = ServidorSQl.GetTablaParam(CadenaSQL, parametros)

            If DataTable Is Nothing OrElse DataTable.Rows.Count = 0 Then
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        End Try
    End Function

    Public Function ObtenerDatosPorTipoComprobantePorInsumo(ByVal TipoGrupo As Integer, ByVal MesImp As String, ByVal AnioImp As String, ByRef DataTable As DataTable, ByVal CodLetra As Integer) As Long
        Try
            Dim tipoAutoriza As Integer
            Dim sumaTipoAutoriza As Integer
            tipoAutoriza = 0
            sumaTipoAutoriza = 0
            Dim Mes As String

            If Len(MesImp) = 2 Then
                Mes = "'" & MesImp & "/" & AnioImp & "'"
            Else
                Mes = "'0" & MesImp & "/" & AnioImp & "'"
            End If

            If CodLetra <> 0 Then
                CadenaSQL = "ComprobantesProveedores.TipoComp = " & CodLetra & " and "
            Else
                CadenaSQL = ""
            End If

            If TipoGrupo <> 0 Then
                CadenaSQL &= " ComprobantesProveedores.TipoGrupo = " & TipoGrupo & " and "
            Else
                CadenaSQL &= ""
            End If

            If Format(Trim(MesImp), "00") = Trim(Format(Now, "MM")) And Trim(AnioImp) = Trim(Format(Now, "YYYY")) Then
                CadenaSQL = "SELECT DISTINCT
                           case  when ComprobantesProveedores.CotizacionDolar = 0 
	                        then dbo.obtenerDolarSegunFecha (FechaCarga)
                            else ComprobantesProveedores.CotizacionDolar end as CotizacionDolar, co.DescInsumo, co.CodInsumo, dbo.ComprobantesProveedores.TipoGrupo, dbo.Proveedor.RSocial,  dbo.ComprobantesProveedores.NroInterno, dbo.ComprobantesProveedores.NroProveedor, dbo.ComprobantesProveedores.DescComp, dbo.ComprobantesProveedores.TipoComp, dbo.ComprobantesProveedores.NroComp, dbo.ComprobantesProveedores.FechaComp, dbo.ComprobantesProveedores.FechaVto, dbo.ComprobantesProveedores.CondicionPago, dbo.ComprobantesProveedores.IvaProd, dbo.ComprobantesProveedores.ImporteProd, dbo.ComprobantesProveedores.PercepIva, dbo.ComprobantesProveedores.PercepGan, dbo.ComprobantesProveedores.TotalPercepIB, dbo.ComprobantesProveedores.ImporteNoImp, dbo.ComprobantesProveedores.TotalComprobante, CONVERT (date, ComprobantesProveedores.FechaCarga) as FechaCarga, dbo.ComprobantesProveedores.NroCompAlfanumerico ,Proveedor.CodTipoInsumosProveedor AS TipoInsumo" _
                        & " FROM ComprobantesProveedores
                        INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor
                        INNER JOIN ComprobantesOrdenes co ON co.NroInterno = ComprobantesProveedores.NroInterno
                        INNER JOIN Insumos i ON i.codInsumo = co.CodInsumo" _
                    & " WHERE " & CadenaSQL & " ComprobantesProveedores.MesImputacion is null  ORDER BY FechaCarga, ComprobantesProveedores.nrointerno"

            Else
                CadenaSQL = "SELECT DISTINCT
                            case  when ComprobantesProveedores.CotizacionDolar = 0 
	                        then dbo.obtenerDolarSegunFecha (FechaCarga)
                            else ComprobantesProveedores.CotizacionDolar end as CotizacionDolar, co.DescInsumo, co.CodInsumo, dbo.ComprobantesProveedores.TipoGrupo, dbo.Proveedor.RSocial, " _
        & " dbo.ComprobantesProveedores.NroInterno, dbo.ComprobantesProveedores.NroProveedor, dbo.ComprobantesProveedores.DescComp," _
        & " dbo.ComprobantesProveedores.TipoComp, dbo.ComprobantesProveedores.NroComp, dbo.ComprobantesProveedores.FechaComp," _
        & " dbo.ComprobantesProveedores.FechaVto, dbo.ComprobantesProveedores.CondicionPago, dbo.ComprobantesProveedores.IvaProd," _
        & " dbo.ComprobantesProveedores.ImporteProd, dbo.ComprobantesProveedores.PercepIva, dbo.ComprobantesProveedores.PercepGan," _
        & " dbo.ComprobantesProveedores.TotalPercepIB, dbo.ComprobantesProveedores.ImporteNoImp, dbo.ComprobantesProveedores.TotalComprobante," _
        & " CONVERT (date, ComprobantesProveedores.FechaCarga) as FechaCarga, dbo.ComprobantesProveedores.NroCompAlfanumerico,Proveedor.CodTipoInsumosProveedor AS TipoInsumo" _
                    & " FROM ComprobantesProveedores
                        INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor
                        INNER JOIN ComprobantesOrdenes co ON co.NroInterno = ComprobantesProveedores.NroInterno
                        INNER JOIN Insumos i ON i.codInsumo = co.CodInsumo" _
                    & " WHERE " & CadenaSQL & " ComprobantesProveedores.MesImputacion = " & Mes & "  ORDER BY FechaCarga, ComprobantesProveedores.nrointerno"

            End If

            Dim parametros As SqlParameter() = {}

            DataTable = ServidorSQl.GetTablaParam(CadenaSQL, parametros)

            If DataTable Is Nothing OrElse DataTable.Rows.Count = 0 Then
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        End Try
    End Function

    Public Function ObtenerComprobantesdelMesPeriodicoPorProveedor(ByRef DataTable As DataTable, MesImp As String, SeleccionoMes As Boolean) As Long
        '-----------------------------------------------------
        'Descripción: Obtiene comprobantes ingresados en el mes
        'Parámetros : fecha y DataTable por ref.
        'Output     : 1 se encontraron datos.
        '             0 No se encontraron datos.
        '            -1 Error al filtrar datos.
        'Modificado 11/05/2010 filtro por mes cerrado
        '-----------------------------------------------------
        Try


            CadenaSQL = "SELECT ComprobantesProveedores.TipoGrupo, ComprobantesProveedores.TipoComp, ComprobantesProveedores.NroComp," _
            & " (CASE WHEN ComprobantesProveedores.TipoGrupo IN (1,2,3,4,5,6,9,10,11) THEN CONVERT(varchar(4),LEFT(ComprobantesProveedores.NroComp,(LEN(ComprobantesProveedores.NroComp)-8))) WHEN ComprobantesProveedores.TipoGrupo IN (7,8) THEN '0000' END) AS NroSucursal" _
            & " , ComprobantesProveedores.DescComp,ComprobantesProveedores.FechaComp, ComprobantesProveedores.FechaVto, ComprobantesProveedores.FechaCarga,ComprobantesProveedores.IvaProd, ComprobantesProveedores.ImporteProd, ComprobantesProveedores.PercepIva,ComprobantesProveedores.PercepGan, ComprobantesProveedores.TotalPercepIB, ComprobantesProveedores.ImporteNoImp, ComprobantesProveedores.IvaProd + ComprobantesProveedores.ImporteProd + ComprobantesProveedores.PercepIva + ComprobantesProveedores.PercepGan + ComprobantesProveedores.TotalPercepIB + ComprobantesProveedores.ImporteNoImp AS TotalComprobante, ComprobantesProveedores.NroInterno, ComprobantesProveedores.NroPRoveedor , Proveedor.RSocial, ComprobantesProveedores.NroCompAlfanumerico " _
                & " FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor" _
                & " WHERE ComprobantesProveedores.MesImputacion IN (" & MesImp & ") " _
                & " ORDER BY ComprobantesProveedores.NroProveedor, ComprobantesProveedores.FechaCarga "

            Dim parametros As SqlParameter() = {}

            DataTable = ServidorSQl.GetTablaParam(CadenaSQL, parametros)

            If DataTable Is Nothing OrElse DataTable.Rows.Count = 0 Then
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        End Try
    End Function

    Public Function ObtenerComprobantesdelMesPeriodico(Fecha As Date, fechaHasta As Date, ByRef rec As DataTable) As Long
        '-----------------------------------------------------
        'Descripción: Obtiene comprobantes ingresados en el
        '             mes
        'Parámetros : fecha y recordset por ref.
        'Output     : 1 se encontraron datos.
        '             0 No se encontraron datos.
        '            -1 Error al filtrar datos.
        '   & " ComprobantesProveedores.IvaProd + ComprobantesProveedores.ImporteProd + ComprobantesProveedores.PercepIva + ComprobantesProveedores.PercepGan + ComprobantesProveedores.TotalPercepIB + ComprobantesProveedores.ImporteNoImp AS TotalComprobante, " _& " ComprobantesProveedores.ImporteProd, "

        'Modificado 11/05/2010 fitro por mes cerrado
        '-----------------------------------------------------
        Try
            Dim sql As String


            sql = "SELECT ComprobantesProveedores.TipoGrupo, ComprobantesProveedores.TipoComp, ComprobantesProveedores.NroComp, (case when ComprobantesProveedores.TipoGrupo in(1,2,3,4,5,6,9,10,11) then convert(varchar(4),left(ComprobantesProveedores.NroComp,(len(ComprobantesProveedores.NroComp)-8))) when ComprobantesProveedores.TipoGrupo in(7,8) then '0000' end ) NroSucursal" _
    & " , ComprobantesProveedores.DescComp,ComprobantesProveedores.FechaComp, ComprobantesProveedores.FechaVto, ComprobantesProveedores.FechaCarga,ComprobantesProveedores.IvaProd, " _
    & " (select case ComprobantesProveedores.DescComp when  23  then 0 else ComprobantesProveedores.ImporteProd end) as ImporteProd, " _
    & " ComprobantesProveedores.PercepIva,ComprobantesProveedores.PercepGan, ComprobantesProveedores.TotalPercepIB, ComprobantesProveedores.ImporteNoImp, " _
    & " (select case ComprobantesProveedores.DescComp when  23 then ComprobantesProveedores.TotalComprobante else ComprobantesProveedores.IvaProd + ComprobantesProveedores.ImporteProd + ComprobantesProveedores.PercepIva + ComprobantesProveedores.PercepGan + ComprobantesProveedores.TotalPercepIB + ComprobantesProveedores.ImporteNoImp end) as TotalComprobante, " _
    & " ComprobantesProveedores.NroInterno, ComprobantesProveedores.NroPRoveedor , Proveedor.RSocial, ComprobantesProveedores.NroCompAlfanumerico,Proveedor.CodTipoInsumosProveedor AS TipoInsumo " _
        & " FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor" _
        & " WHERE ComprobantesProveedores.fechaCarga between '" & Fecha & "' and '" & fechaHasta & "' order by ComprobantesProveedores.fechaCarga,ComprobantesProveedores.nrointerno "
            rec = ServidorSQl.GetTabla(sql)
            If rec Is Nothing OrElse rec.Rows.Count = 0 Then
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Return -1
        End Try
    End Function

    Public Function ObtenerInsumosIndustrialesConsuman(ByVal fechaDesde As String, ByVal fechaHasta As String, ByRef DataTable As DataTable) As Long
        '-----------------------------------------------------
        'Descripción: obtiene las Insumos Industriales Consuman
        '             Desde Hasta
        'Parámetros : mes, quincena y año por valor y DataTable por referencia
        'Output     : 1 se encontraron datos.
        '             0 no se encontraron datos.
        '            -1 Error al buscar datos.
        '-----------------------------------------------------
        Try


            CadenaSQL = "SELECT DISTINCT ComprobantesProveedores.nroCompAlfanumerico, ComprobantesProveedores.TipoComp, ComprobantesProveedores.NroComp, ComprobantesProveedores.DescComp,ComprobantesProveedores.FechaComp, ComprobantesProveedores.FechaVto, CONVERT(date, ComprobantesProveedores.FechaCarga) as FechaCarga, ComprobantesProveedores.IvaProd, " _
            & " (CASE WHEN ComprobantesProveedores.TipoGrupo = 11 THEN 0 ELSE ComprobantesProveedores.ImporteProd END) As ImporteProd" _
            & "  , ComprobantesProveedores.PercepIva,ComprobantesProveedores.PercepGan, ComprobantesProveedores.TotalPercepIB, ComprobantesProveedores.ImporteNoImp," _
            & "  (CASE WHEN ComprobantesProveedores.TipoGrupo = 11 THEN ComprobantesProveedores.TotalComprobante ELSE (ComprobantesProveedores.IvaProd + ComprobantesProveedores.ImporteProd + ComprobantesProveedores.PercepIva + ComprobantesProveedores.PercepGan + ComprobantesProveedores.TotalPercepIB + ComprobantesProveedores.ImporteNoImp) END) As TotalComprobante" _
            & "  , ComprobantesProveedores.NroInterno, ComprobantesProveedores.NroPRoveedor , Proveedor.RSocial, ComprobantesProveedores.TipoGrupo, ComprobantesProveedores.NroCompAlfanumerico" _
            & "  ,ComprobantesOrdenes.CodInsumo , ComprobantesOrdenes.Cantidad,ComprobantesOrdenes.Precio,  ComprobantesOrdenes.total , ComprobanteOrdenesPorDetalleConsuman.Numero, Insumos.Descripcion, InsumoPorMaterialConsuman.idSubRubroConsuman" _
            & "  FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor" _
            & "  INNER JOIN ComprobantesOrdenes ON ComprobantesOrdenes.NroInterno = ComprobantesProveedores.NroInterno" _
            & "  INNER JOIN ComprobanteOrdenesPorDetalleConsuman ON ComprobanteOrdenesPorDetalleConsuman.idMaterial = ComprobantesOrdenes.idMaterial and ComprobanteOrdenesPorDetalleConsuman.idDetalle= ComprobantesOrdenes.NroIngreso " _
            & "  INNER JOIN Insumos ON Insumos.codInsumo = ComprobantesOrdenes.CodInsumo " _
            & " INNER JOIN InsumoPorMaterialConsuman  ON InsumoPorMaterialConsuman.codInsumo = Insumos.codInsumo " _
            & "  WHERE ComprobantesProveedores.fechacarga>='" & fechaDesde & " 00:00:01' and ComprobantesProveedores.fechacarga<='" & fechaHasta & " 23:59:59' ORDER BY ComprobantesProveedores.NroInterno"

            Dim parametros As SqlParameter() = {}

            DataTable = ServidorSQl.GetTablaParam(CadenaSQL, parametros)

            If DataTable Is Nothing OrElse DataTable.Rows.Count = 0 Then
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        End Try
    End Function

    Public Function ObtenerRetencionGananciasDesHas(ByVal fechaDesde As String, ByVal fechaHasta As String, ByRef DataTable As DataTable) As Long
        '-----------------------------------------------------
        'Descripción: obtiene las retenciones de ganancias de una
        '             quincena determinada
        'Parámetros : mes, quincena y año por valor y DataTable por referencia
        'Output     : 1 se encontraron datos.
        '             0 no se encontraron datos.
        '            -1 Error al buscar datos.
        '-----------------------------------------------------
        Try
            Dim tabla As New DataTable ' esta contiene el rec de consulta

            'Armo tabla de devolucion
            DataTable.Columns.Add("NroProveedor", GetType(Integer))
            DataTable.Columns.Add("RazonSocial", GetType(String))
            DataTable.Columns.Add("NroOP", GetType(Integer))
            DataTable.Columns.Add("FechaComp", GetType(Date))
            DataTable.Columns.Add("Importe", GetType(Integer))
            DataTable.Columns.Add("NRete", GetType(Integer))
            DataTable.Columns.Add("Cuit", GetType(String))

            'Select Case DISTINCT" &
            '" dbo.OP.NroOP, dbo.NrosRetXOP.NroRet, dbo.NrosRetXOP.TipoRet, Prov.NroProveedor, Prov.RSocial, Prov.NroCUIT, TipoRet.Descripcion," &
            '" dbo.OP.FechaCreacion, dbo.OP.ImporteRetIB, (Case When dbo.OP.ImporteNeto = 0 Then 0 Else dbo.OP.ImporteRetIB / (dbo.OP.ImporteNeto * 0.8) * 100 End) As Alicuota," &
            '" dbo.OP.ImporteRetGan" &
            '" FROM         dbo.OP INNER JOIN" &
            '" dbo.NrosRetXOP On dbo.OP.NroOP = dbo.NrosRetXOP.NroOp INNER JOIN" &
            '" dbo.Proveedor Prov On dbo.OP.NroProveedor = Prov.NroProveedor INNER JOIN" &
            '" dbo.ValoresMinimosRetenciones TipoRet On dbo.NrosRetXOP.TipoRet = TipoRet.CodTipoRet
            CadenaSQL = "SELECT DISTINCT" _
            & " dbo.OP.NroOP, dbo.NrosRetXOP.NroRet, dbo.NrosRetXOP.TipoRet, Prov.NroProveedor, Prov.RSocial, Prov.NroCUIT, TipoRet.Descripcion," _
            & " dbo.OP.FechaCreacion, dbo.OP.ImporteRetIB, (CASE WHEN dbo.OP.ImporteNeto=0 THEN 0 ELSE" _
            & " dbo.OP.ImporteRetIB / (dbo.OP.ImporteNeto * 0.8) * 100 END) AS Alicuota " _
            & " , dbo.OP.ImporteRetGan" _
            & " FROM         dbo.OP INNER JOIN" _
            & " dbo.NrosRetXOP ON dbo.OP.NroOP = dbo.NrosRetXOP.NroOp INNER JOIN" _
            & " dbo.Proveedor Prov ON dbo.OP.NroProveedor = Prov.NroProveedor INNER JOIN" _
            & " dbo.ValoresMinimosRetenciones TipoRet ON dbo.NrosRetXOP.TipoRet = TipoRet.CodTipoRet " _
            & " WHERE OP.FechaCreacion >= '" & fechaDesde & "'  AND OP.FechaCreacion <= '" & fechaHasta & "' AND " _
            & " (dbo.NrosRetXOP.TipoRet = 1)"

            Dim parametros As SqlParameter() = {}

            tabla = ServidorSQl.GetTablaParam(CadenaSQL, parametros)

            For Each row As DataRow In tabla.Rows
                Dim newRow As DataRow = DataTable.NewRow()
                newRow("NroProveedor") = Trim(row("NroProveedor"))
                newRow("RazonSocial") = Trim(row("RSocial"))
                newRow("NroOP") = row("NroOP")
                newRow("FechaComp") = CDate(Format(row("FechaCreacion"), "dd/MM/yyyy"))
                newRow("Importe") = row("ImporteRetGan")
                newRow("NRete") = row("NroRet")
                newRow("Cuit") = Trim(row("NroCuit"))
                DataTable.Rows.Add(newRow)
            Next

            If DataTable Is Nothing OrElse DataTable.Rows.Count = 0 Then
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        End Try
    End Function

    Public Function ObtenerRetencionIBCordobaDesHas(ByVal fechaDesde As String, ByVal fechaHasta As String, ByRef rec As DataTable) As Integer
        Try
            ' Crear DataTable
            rec = New DataTable
            rec.Columns.Add("RazonSocial", GetType(String))
            rec.Columns.Add("NroProveedor", GetType(Double))
            rec.Columns.Add("IngBrutos", GetType(String))
            rec.Columns.Add("InscDir", GetType(String))
            rec.Columns.Add("ProdServ", GetType(String))
            rec.Columns.Add("BaseImp", GetType(Double))
            rec.Columns.Add("Alicuota", GetType(String))
            rec.Columns.Add("ImpRetenido", GetType(Double))
            rec.Columns.Add("Constancia", GetType(Double))
            rec.Columns.Add("NroOP", GetType(Integer))
            rec.Columns.Add("FechaOP", GetType(Date))

            ' Verificar fecha límite
            Dim CadenaSQL As String
            If CDate(fechaHasta) < CDate("01/11/2009") Then
                CadenaSQL = "SELECT * FROM VistaRetencionesIIBBCbaAntes112009 WHERE FechaCreacion >= @FechaDesde AND FechaCreacion <= @FechaHasta"
            Else
                CadenaSQL = "SELECT * FROM VistaRetencionesIIBBCba WHERE FechaCreacion >= @FechaDesde AND FechaCreacion <= @FechaHasta"
            End If

            ' Crear parámetros
            Dim parametros As SqlParameter() = {
            New SqlParameter("@FechaDesde", fechaDesde),
            New SqlParameter("@FechaHasta", fechaHasta)
        }

            ' Obtener datos
            Dim RstAux As DataTable = ServidorSQl.GetTablaParam(CadenaSQL, parametros)

            For Each drAux As DataRow In RstAux.Rows
                CadenaSQL = "SELECT dbo.DetalleLiquidaciones.NroInterno, ImportePagado, NroOP, ImporteRetIB, PorceBaseImponible, DescCOmp, TipoGrupo " &
                        "FROM dbo.DetalleLiquidaciones INNER JOIN dbo.OP ON dbo.DetalleLiquidaciones.NroLiquidacion = dbo.OP.NroLiquidacion " &
                        "INNER JOIN dbo.ComprobantesProveedores ON dbo.DetalleLiquidaciones.NroInterno = dbo.ComprobantesProveedores.NroInterno " &
                        "AND dbo.OP.NroProveedor = dbo.ComprobantesProveedores.NroProveedor " &
                        "WHERE dbo.OP.NroOp = @NroOp"

                ' Parámetro adicional para la segunda consulta
                Dim parametrosOP As SqlParameter() = {New SqlParameter("@NroOp", drAux("NroOP"))}

                ' Obtener datos relacionados
                Dim RstOP As DataTable = ServidorSQl.GetTablaParam(CadenaSQL, parametrosOP)

                If RstOP IsNot Nothing AndAlso RstOP.Rows.Count > 0 Then
                    Dim Acumulado As Double = 0

                    For Each drOP As DataRow In RstOP.Rows
                        ' Realizar operaciones con RstOP
                        If (CInt(drOP("TipoGrupo")) = 6 And CInt(drOP("DescCOmp")) = 13) _
                        Or (CInt(drOP("TipoGrupo")) = 4 And CInt(drOP("DescCOmp")) = 11) _
                        Or (CInt(drOP("DescCOmp")) = 12) Or (CInt(drOP("DescCOmp")) = 5) Then
                            Continue For
                        Else
                            Acumulado += CDbl(drOP("ImportePagado"))
                        End If
                    Next

                    ' Añadir datos al DataTable
                    Dim Registro As DataRow = rec.NewRow()
                    Registro("NroOP") = CInt(drAux("NroOP"))
                    Registro("FechaOP") = CDate(drAux("FechaCreacion"))
                    Registro("RazonSocial") = CStr(drAux("RSocial"))
                    Registro("NroProveedor") = CDbl(drAux("NroProveedor"))
                    Registro("IngBrutos") = CStr(drAux("IngBrutos"))
                    Registro("ProdServ") = CStr(drAux("TipoCuit"))
                    Registro("BaseImp") = CDbl(drAux("BaseImponible"))
                    Registro("Alicuota") = CStr(drAux("Alicuota"))
                    Registro("ImpRetenido") = CDbl(drAux("ImporteRetIB"))
                    Registro("Constancia") = CDbl(drAux("NroRet"))
                    rec.Rows.Add(Registro)
                End If
            Next

            If rec.Rows.Count > 0 Then
                ObtenerRetencionIBCordobaDesHas = 1
            Else
                ObtenerRetencionIBCordobaDesHas = 0
            End If

        Catch ex As Exception
            ' Manejar la excepción
            MsgBox("Error al obtener retenciones de I. Brutos de Cba. Detalles: " & ex.Message, MsgBoxStyle.Exclamation)
            ObtenerRetencionIBCordobaDesHas = -1
        End Try
    End Function

    Public Function ObtenerRetencionIBBsAsDesHas(ByVal fechaDesde As String, ByVal fechaHasta As String, ByRef rec As DataTable) As Integer
        '-----------------------------------------------------
        ' Descripción: Obtiene datos de retenciones de I.Brutos de Bs.As.
        ' Parámetros : fechaDesde, fechaHasta y DataTable por referencia.
        ' Output     : 1 si se encontraron datos, 0 si no se encontraron datos, -1 si hubo un error al filtrar datos.
        '-----------------------------------------------------

        Dim CadenaSQL As String
        Dim RstAux As DataTable
        Dim RstOP As DataTable
        Dim recRetencionesIB As DataTable
        Dim respuesta As Integer

        ' Inicializar DataTable
        rec = New DataTable()
        rec.Columns.Add("RazonSocial", GetType(String))
        rec.Columns.Add("NroProveedor", GetType(Double))
        rec.Columns.Add("IngBrutos", GetType(String))
        rec.Columns.Add("InscDir", GetType(String))
        rec.Columns.Add("ProdServ", GetType(String))
        rec.Columns.Add("BaseImp", GetType(Double))
        rec.Columns.Add("Alicuota", GetType(String))
        rec.Columns.Add("ImpRetenido", GetType(Double))
        rec.Columns.Add("Constancia", GetType(Double))
        rec.Columns.Add("NroOP", GetType(Integer))
        rec.Columns.Add("FechaOP", GetType(Date))

        Try
            If CDate(fechaHasta) < CDate("01/11/2009") Then
                CadenaSQL = "SELECT * FROM VistaRetencionesIIBBBsAsAntes112009 WHERE FechaCreacion >= '" & fechaDesde & "' AND FechaCreacion <= '" & fechaHasta & "'"
            Else
                CadenaSQL = "SELECT * FROM VistaRetencionesIIBBBsAs WHERE FechaCreacion >= '" & fechaDesde & "' AND FechaCreacion <= '" & fechaHasta & "'"
            End If

            ' Obtener datos principales
            RstAux = ServidorSQl.GetTabla(CadenaSQL)

            For Each drAux As DataRow In RstAux.Rows
                CadenaSQL = "SELECT dbo.DetalleLiquidaciones.NroInterno, dbo.DetalleLiquidaciones.ImportePagado, dbo.OP.NroOP, dbo.OP.ImporteRetIB, dbo.OP.PorceBaseImponible," &
                            " dbo.ComprobantesProveedores.DescCOmp , dbo.ComprobantesProveedores.TipoGrupo" &
                            " FROM dbo.OP INNER JOIN" &
                            " dbo.Liquidaciones ON dbo.OP.NroLiquidacion = dbo.Liquidaciones.NroLiquidacion INNER JOIN" &
                            " dbo.DetalleLiquidaciones ON dbo.Liquidaciones.NroLiquidacion = dbo.DetalleLiquidaciones.NroLiquidacion INNER JOIN" &
                            " dbo.ComprobantesProveedores ON dbo.DetalleLiquidaciones.NroInterno = dbo.ComprobantesProveedores.NroInterno AND" &
                            " dbo.OP.NroProveedor = dbo.ComprobantesProveedores.NroProveedor" &
                            " WHERE dbo.OP.NroOp = @NroOp"

                ' Parámetro adicional para la segunda consulta
                Dim parametrosOP As SqlParameter() = {New SqlParameter("@NroOp", drAux("NroOP"))}

                ' Obtener datos relacionados
                RstOP = ServidorSQl.GetTablaParam(CadenaSQL, parametrosOP)

                If RstOP IsNot Nothing AndAlso RstOP.Rows.Count > 0 Then
                    Dim Acumulado As Double = 0

                    For Each drOP As DataRow In RstOP.Rows
                        ' Realizar operaciones con RstOP
                        If (CInt(drOP("TipoGrupo")) = 6 And CInt(drOP("DescCOmp")) = 13) _
                        Or (CInt(drOP("TipoGrupo")) = 4 And CInt(drOP("DescCOmp")) = 11) _
                        Or (CInt(drOP("DescCOmp")) = 12) Or (CInt(drOP("DescCOmp")) = 5) Then
                            Continue For
                        Else
                            Acumulado += CDbl(drOP("ImportePagado"))
                        End If
                    Next

                    ' Añadir datos al DataTable
                    Dim Registro As DataRow = rec.NewRow()
                    Registro("NroOP") = If(Not IsDBNull(drAux("NroOP")), CInt(drAux("NroOP")), 0)
                    Registro("FechaOP") = If(Not IsDBNull(drAux("FechaCreacion")), CStr(drAux("FechaCreacion")), String.Empty)
                    Registro("RazonSocial") = If(Not IsDBNull(drAux("RSocial")), CStr(drAux("RSocial")), String.Empty)
                    Registro("NroProveedor") = If(Not IsDBNull(drAux("NroProveedor")), CDbl(drAux("NroProveedor")), 0)
                    If Mid(UCase(Trim(drAux("IngBrutos"))), 1, 13) <> "NO SE POSEE" Then
                        Registro("IngBrutos") = Trim(drAux("IngBrutos"))
                        Registro("InscDir") = ""
                    Else
                        ' Lógica para el caso de "NO SE POSEE"
                    End If
                    Registro("ProdServ") = Left(Trim(drAux("TipoCuit")), 50)

                    recRetencionesIB = New DataTable()
                    respuesta = RecuperarIngresoBrutoDeOP(Trim(drAux("NroOP")), recRetencionesIB)
                    If recRetencionesIB.Rows.Count > 0 Then
                        Registro("BaseImp") = If(Not IsDBNull(recRetencionesIB.Rows(0)("Base")), CDbl(recRetencionesIB.Rows(0)("Base")), 0)
                        Registro("Alicuota") = If(Not IsDBNull(recRetencionesIB.Rows(0)("Alicuota")), CStr(recRetencionesIB.Rows(0)("Alicuota")), String.Empty)
                        Registro("ImpRetenido") = If(Not IsDBNull(recRetencionesIB.Rows(0)("ImpPercepcion")), CDbl(recRetencionesIB.Rows(0)("ImpPercepcion")), 0)
                    End If

                    Registro("Constancia") = If(Not IsDBNull(drAux("NroRet")), CDbl(drAux("NroRet")), 0)
                    rec.Rows.Add(Registro)
                End If
            Next

            'CIERRO ARCHIVOS
            '*************************************************
            If rec.Rows.Count > 0 Then
                ObtenerRetencionIBBsAsDesHas = 1
            Else
                ObtenerRetencionIBBsAsDesHas = 0
            End If
            Return ObtenerRetencionIBBsAsDesHas

        Catch ex As Exception
            ' Manejar la excepción
            MsgBox("Error al obtener retenciones de IIBB Bs.As. Detalles: " & ex.Message, MsgBoxStyle.Exclamation)
            Return -1
        End Try
    End Function
    Public Function ObtenerRetencionIBSanLuisDesHas(ByVal fechaDesde As String, ByVal fechaHasta As String, ByRef rec As DataTable) As Long

        Try
            ' Crear DataTable
            rec = New DataTable
            rec.Columns.Add("RazonSocial", GetType(String))
            rec.Columns.Add("NroProveedor", GetType(Double))
            rec.Columns.Add("IngBrutos", GetType(String))
            rec.Columns.Add("InscDir", GetType(String))
            rec.Columns.Add("ProdServ", GetType(String))
            rec.Columns.Add("BaseImp", GetType(Double))
            rec.Columns.Add("Alicuota", GetType(String))
            rec.Columns.Add("ImpRetenido", GetType(Double))
            rec.Columns.Add("Constancia", GetType(Double))
            rec.Columns.Add("NroOP", GetType(Integer))
            rec.Columns.Add("FechaOP", GetType(Date))

            ' Verificar fecha límite
            Dim CadenaSQL As String
            If CDate(fechaHasta) < CDate("01/11/2009") Then
                CadenaSQL = "SELECT * FROM VistaRetencionesIIBBSanLuisAntes112009 WHERE FechaCreacion >= @FechaDesde AND FechaCreacion <= @FechaHasta"
            Else
                CadenaSQL = "SELECT * FROM VistaRetencionesIIBBSanLuis WHERE FechaCreacion >= @FechaDesde AND FechaCreacion <= @FechaHasta"
            End If

            ' Crear parámetros
            Dim parametros As SqlParameter() = {
            New SqlParameter("@FechaDesde", fechaDesde),
            New SqlParameter("@FechaHasta", fechaHasta)
        }

            ' Obtener datos
            Dim RstAux As DataTable = ServidorSQl.GetTablaParam(CadenaSQL, parametros)

            For Each drAux As DataRow In RstAux.Rows
                CadenaSQL = "SELECT dbo.DetalleLiquidaciones.NroInterno, ImportePagado, NroOP, ImporteRetIB, PorceBaseImponible, DescCOmp, TipoGrupo " &
                        "FROM dbo.DetalleLiquidaciones INNER JOIN dbo.OP ON dbo.DetalleLiquidaciones.NroLiquidacion = dbo.OP.NroLiquidacion " &
                        "INNER JOIN dbo.ComprobantesProveedores ON dbo.DetalleLiquidaciones.NroInterno = dbo.ComprobantesProveedores.NroInterno " &
                        "AND dbo.OP.NroProveedor = dbo.ComprobantesProveedores.NroProveedor " &
                        "WHERE dbo.OP.NroOp = @NroOp"

                ' Parámetro adicional para la segunda consulta
                Dim parametrosOP As SqlParameter() = {New SqlParameter("@NroOp", drAux("NroOP"))}

                ' Obtener datos relacionados
                Dim RstOP As DataTable = ServidorSQl.GetTablaParam(CadenaSQL, parametrosOP)

                If RstOP IsNot Nothing AndAlso RstOP.Rows.Count > 0 Then
                    Dim Acumulado As Double = 0

                    For Each drOP As DataRow In RstOP.Rows
                        ' Realizar operaciones con RstOP
                        If (CInt(drOP("TipoGrupo")) = 6 And CInt(drOP("DescCOmp")) = 13) _
                        Or (CInt(drOP("TipoGrupo")) = 4 And CInt(drOP("DescCOmp")) = 11) _
                        Or (CInt(drOP("DescCOmp")) = 12) Or (CInt(drOP("DescCOmp")) = 5) Then
                            Continue For
                        Else
                            Acumulado += CDbl(drOP("ImportePagado"))
                        End If
                    Next

                    ' Añadir datos al DataTable
                    Dim Registro As DataRow = rec.NewRow()
                    Registro("NroOP") = CInt(drAux("NroOP"))
                    Registro("FechaOP") = CDate(drAux("FechaCreacion"))
                    Registro("RazonSocial") = CStr(drAux("RSocial"))
                    Registro("NroProveedor") = CDbl(drAux("NroProveedor"))
                    Registro("IngBrutos") = CStr(drAux("IngBrutos"))
                    Registro("ProdServ") = CStr(drAux("TipoCuit"))
                    Registro("BaseImp") = CDbl(drAux("BaseImponible"))
                    Registro("Alicuota") = CStr(drAux("Alicuota"))
                    Registro("ImpRetenido") = CDbl(drAux("ImporteRetIB"))
                    Registro("Constancia") = CDbl(drAux("NroRet"))
                    rec.Rows.Add(Registro)
                End If
            Next

            If rec.Rows.Count > 0 Then
                ObtenerRetencionIBSanLuisDesHas = 1
            Else
                ObtenerRetencionIBSanLuisDesHas = 0
            End If

        Catch ex As Exception
            ' Manejar la excepción
            MsgBox("Error al obtener retenciones de I. Brutos de SanLuis. Detalles: " & ex.Message, MsgBoxStyle.Exclamation)
            ObtenerRetencionIBSanLuisDesHas = -1
        End Try
    End Function

    Public Function ObtenerRetencionIBSantaFeDesHas(ByVal fechaDesde As String, ByVal fechaHasta As String, ByRef DataTable As DataTable) As Long
        '-----------------------------------------------------
        'Descripción: Obtiene datos de retenciones de I.Brutos de Santa Fe
        'Parámetros : quincena, mes, año, período de fechas y DataTable por referencia
        'Output     : 1 se encontraron datos.
        '             0 No se encontraron datos.
        '            -1 Error al filtrar datos.
        '-----------------------------------------------------
        Try

            CadenaSQL = "SELECT * FROM VistaExportacionRentasIIBBSantaFe " _
            & "WHERE FechaCreacion >= @FechaDesde AND FechaCreacion <= @FechaHasta"

            Dim parametros As SqlParameter() = {
            New SqlParameter("@FechaDesde", fechaDesde),
            New SqlParameter("@FechaHasta", fechaHasta)
        }

            DataTable = ServidorSQl.GetTablaParam(CadenaSQL, parametros)

            If DataTable IsNot Nothing AndAlso DataTable.Rows.Count > 0 Then
                ' Trabajar con los datos del DataTable
                Dim rec As DataTable = New DataTable()
                rec.Columns.Add("RazonSocial", GetType(String))
                rec.Columns.Add("NroProveedor", GetType(Double))
                rec.Columns.Add("IngBrutos", GetType(String))
                rec.Columns.Add("InscDir", GetType(String))
                rec.Columns.Add("ProdServ", GetType(String))
                rec.Columns.Add("BaseImp", GetType(Double))
                rec.Columns.Add("Alicuota", GetType(String))
                rec.Columns.Add("ImpRetenido", GetType(Double))
                rec.Columns.Add("Constancia", GetType(Double))
                rec.Columns.Add("NroOp", GetType(Integer))
                rec.Columns.Add("FechaOP", GetType(Date))

                For Each fila As DataRow In DataTable.Rows
                    rec.Rows.Add(
                    Trim(fila("RSocial")),
                    Convert.ToDouble(fila("NroProveedor")),
                    If(Mid(UCase(Trim(fila("IngBrutos"))), 1, 14) <> "NO SE POSEE", Trim(Left(Trim(Replace(Replace(fila("IngBrutos"), "-", ""), " ", "")) & Space(14), 14)), ""),
                    "",
                    Left(Trim(fila("TipoCuit")), 50),
                    Convert.ToDouble(fila("BaseImponible")),
                    Format(fila("Alicuota"), "0.00"),
                    Convert.ToDouble(fila("ImporteRetIB")),
                    Convert.ToDouble(fila("NroRet")),
                    Convert.ToInt32(fila("NroOP")),
                    Convert.ToDateTime(fila("FechaCreacion"))
                )
                Next

                If rec.Rows.Count > 0 Then
                    DataTable = rec
                    Return 1
                Else
                    Return 0
                End If
            Else
                Return 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        End Try
    End Function


    Public Function ObtenerRetencionIBMisionesDesHas(ByVal fechaDesde As String, ByVal fechaHasta As String, ByRef rec As DataTable) As Long
        '-----------------------------------------------------
        ' Descripción: Obtiene datos de retenciones de I.Brutos de Misiones
        ' Parámetros : fechaDesde, fechaHasta y DataTable por referencia.
        ' Output     : 1 si se encontraron datos, 0 si no se encontraron datos, -1 si hubo un error al filtrar datos.
        '-----------------------------------------------------

        Dim CadenaSQL As String
        Dim RstAux As DataTable
        Dim RstOP As DataTable

        ' Inicializar DataTable
        rec = New DataTable()
        rec.Columns.Add("RazonSocial", GetType(String))
        rec.Columns.Add("NroProveedor", GetType(Double))
        rec.Columns.Add("IngBrutos", GetType(String))
        rec.Columns.Add("InscDir", GetType(String))
        rec.Columns.Add("ProdServ", GetType(String))
        rec.Columns.Add("BaseImp", GetType(Double))
        rec.Columns.Add("Alicuota", GetType(String))
        rec.Columns.Add("ImpRetenido", GetType(Double))
        rec.Columns.Add("Constancia", GetType(Double))
        rec.Columns.Add("NroOP", GetType(Integer))
        rec.Columns.Add("FechaOP", GetType(Date))

        Try
            CadenaSQL = "SELECT * FROM VistaRetencionesIIBBMisiones WHERE FechaCreacion >= '" & fechaDesde & "' AND FechaCreacion <= '" & fechaHasta & "'"
            ' Obtener datos principales
            RstAux = ServidorSQl.GetTabla(CadenaSQL)

            For Each drAux As DataRow In RstAux.Rows
                CadenaSQL = "SELECT dbo.DetalleLiquidaciones.NroInterno, dbo.DetalleLiquidaciones.ImportePagado, dbo.OP.NroOP, dbo.OP.ImporteRetIB, dbo.OP.PorceBaseImponible," &
                        " dbo.ComprobantesProveedores.DescCOmp , dbo.ComprobantesProveedores.TipoGrupo" &
                        " FROM dbo.OP INNER JOIN" &
                        " dbo.Liquidaciones ON dbo.OP.NroLiquidacion = dbo.Liquidaciones.NroLiquidacion INNER JOIN" &
                        " dbo.DetalleLiquidaciones ON dbo.Liquidaciones.NroLiquidacion = dbo.DetalleLiquidaciones.NroLiquidacion INNER JOIN" &
                        " dbo.ComprobantesProveedores ON dbo.DetalleLiquidaciones.NroInterno = dbo.ComprobantesProveedores.NroInterno AND" &
                        " dbo.OP.NroProveedor = dbo.ComprobantesProveedores.NroProveedor" &
                        " WHERE dbo.OP.NroOp = @NroOp"

                ' Parámetro adicional para la segunda consulta
                Dim parametrosOP As SqlParameter() = {New SqlParameter("@NroOp", drAux("NroOP"))}

                ' Obtener datos relacionados
                RstOP = ServidorSQl.GetTablaParam(CadenaSQL, parametrosOP)

                If RstOP IsNot Nothing AndAlso RstOP.Rows.Count > 0 Then
                    Dim Acumulado As Double = 0

                    For Each drOP As DataRow In RstOP.Rows
                        ' Realizar operaciones con RstOP
                        If (CInt(drOP("TipoGrupo")) = 6 And CInt(drOP("DescCOmp")) = 13) _
                    Or (CInt(drOP("TipoGrupo")) = 4 And CInt(drOP("DescCOmp")) = 11) _
                    Or (CInt(drOP("DescCOmp")) = 12) Or (CInt(drOP("DescCOmp")) = 5) Then
                            Continue For
                        Else
                            Acumulado += CDbl(drOP("ImportePagado"))
                        End If
                    Next

                    ' Añadir datos al DataTable
                    Dim Registro As DataRow = rec.NewRow()
                    Registro("NroOP") = If(Not IsDBNull(drAux("NroOP")), CInt(drAux("NroOP")), 0)
                    Registro("FechaOP") = If(Not IsDBNull(drAux("FechaCreacion")), CStr(drAux("FechaCreacion")), String.Empty)
                    Registro("RazonSocial") = If(Not IsDBNull(drAux("RSocial")), CStr(drAux("RSocial")), String.Empty)
                    Registro("NroProveedor") = If(Not IsDBNull(drAux("NroProveedor")), CDbl(drAux("NroProveedor")), 0)
                    If Mid(UCase(Trim(drAux("IngBrutos"))), 1, 14) <> "NO SE POSEE" Then
                        Registro("IngBrutos") = Trim(Left(Trim(Replace(Replace(drAux("IngBrutos").ToString(), "-", ""), " ", "")) & Space(14), 14))
                        Registro("InscDir") = ""
                    Else
                        ' Lógica para el caso de "NO SE POSEE"
                    End If
                    Registro("ProdServ") = Left(Trim(drAux("TipoCuit")), 50)
                    Registro("BaseImp") = If(Not IsDBNull(drAux("BaseImponible")), CDbl(drAux("BaseImponible")), 0)
                    Registro("Alicuota") = Format(If(Not IsDBNull(drAux("Alicuota")), CDbl(drAux("Alicuota")), 0), "0.00")
                    Registro("ImpRetenido") = If(Not IsDBNull(drAux("ImporteRetIB")), CDbl(drAux("ImporteRetIB")), 0)
                    Registro("Constancia") = If(Not IsDBNull(drAux("NroRet")), CDbl(drAux("NroRet")), 0)
                    rec.Rows.Add(Registro)
                End If
            Next

            'CIERRO ARCHIVOS
            '*************************************************
            If rec.Rows.Count > 0 Then
                ObtenerRetencionIBMisionesDesHas = 1
            Else
                ObtenerRetencionIBMisionesDesHas = 0
            End If
            Return ObtenerRetencionIBMisionesDesHas

        Catch ex As Exception
            ' Manejar la excepción
            MsgBox("Error al obtener retenciones de IIBB Misiones. Detalles: " & ex.Message, MsgBoxStyle.Exclamation)
            Return -1
        End Try
    End Function


    Public Function ObtenerRetencionIBLaPampaDesHas(ByVal fechaDesde As String, ByVal fechaHasta As String, ByRef rec As DataTable) As Long
        '-----------------------------------------------------
        'Descripción: Obtiene datos de retenciones de I.Brutos La Pampa
        'Parámetros : quincena, mes, año, periodo de fecha (byval) y DataTable por referencia
        'Output     : 1 se encontraron datos.
        '             0 No se encontraron datos.
        '            -1 Error al filtrar datos.
        '-----------------------------------------------------
        '-----------------------------------------------------
        ' Descripción: Obtiene datos de retenciones de I.Brutos de Misiones
        ' Parámetros : fechaDesde, fechaHasta y DataTable por referencia.
        ' Output     : 1 si se encontraron datos, 0 si no se encontraron datos, -1 si hubo un error al filtrar datos.
        '-----------------------------------------------------

        Dim CadenaSQL As String
        Dim RstAux As DataTable
        Dim RstOP As DataTable

        ' Inicializar DataTable
        rec = New DataTable()
        rec.Columns.Add("RazonSocial", GetType(String))
        rec.Columns.Add("NroProveedor", GetType(Double))
        rec.Columns.Add("IngBrutos", GetType(String))
        rec.Columns.Add("InscDir", GetType(String))
        rec.Columns.Add("ProdServ", GetType(String))
        rec.Columns.Add("BaseImp", GetType(Double))
        rec.Columns.Add("Alicuota", GetType(String))
        rec.Columns.Add("ImpRetenido", GetType(Double))
        rec.Columns.Add("Constancia", GetType(Double))
        rec.Columns.Add("NroOP", GetType(Integer))
        rec.Columns.Add("FechaOP", GetType(Date))

        Try
            CadenaSQL = "SELECT * FROM VistaRetencionesIIBBLaPampa WHERE FechaCreacion >= '" & fechaDesde & "' AND FechaCreacion <= '" & fechaHasta & "'"
            ' Obtener datos principales
            RstAux = ServidorSQl.GetTabla(CadenaSQL)

            For Each drAux As DataRow In RstAux.Rows
                CadenaSQL = "SELECT dbo.DetalleLiquidaciones.NroInterno, dbo.DetalleLiquidaciones.ImportePagado, dbo.OP.NroOP, dbo.OP.ImporteRetIB, dbo.OP.PorceBaseImponible," &
                        " dbo.ComprobantesProveedores.DescCOmp , dbo.ComprobantesProveedores.TipoGrupo" &
                        " FROM dbo.OP INNER JOIN" &
                        " dbo.Liquidaciones ON dbo.OP.NroLiquidacion = dbo.Liquidaciones.NroLiquidacion INNER JOIN" &
                        " dbo.DetalleLiquidaciones ON dbo.Liquidaciones.NroLiquidacion = dbo.DetalleLiquidaciones.NroLiquidacion INNER JOIN" &
                        " dbo.ComprobantesProveedores ON dbo.DetalleLiquidaciones.NroInterno = dbo.ComprobantesProveedores.NroInterno AND" &
                        " dbo.OP.NroProveedor = dbo.ComprobantesProveedores.NroProveedor" &
                        " WHERE dbo.OP.NroOp = @NroOp"

                ' Parámetro adicional para la segunda consulta
                Dim parametrosOP As SqlParameter() = {New SqlParameter("@NroOp", drAux("NroOP"))}

                ' Obtener datos relacionados
                RstOP = ServidorSQl.GetTablaParam(CadenaSQL, parametrosOP)

                If RstOP IsNot Nothing AndAlso RstOP.Rows.Count > 0 Then
                    Dim Acumulado As Double = 0

                    For Each drOP As DataRow In RstOP.Rows
                        ' Realizar operaciones con RstOP
                        If (CInt(drOP("TipoGrupo")) = 6 And CInt(drOP("DescCOmp")) = 13) _
                    Or (CInt(drOP("TipoGrupo")) = 4 And CInt(drOP("DescCOmp")) = 11) _
                    Or (CInt(drOP("DescCOmp")) = 12) Or (CInt(drOP("DescCOmp")) = 5) Then
                            Continue For
                        Else
                            Acumulado += CDbl(drOP("ImportePagado"))
                        End If
                    Next

                    ' Añadir datos al DataTable
                    Dim Registro As DataRow = rec.NewRow()
                    Registro("NroOP") = If(Not IsDBNull(drAux("NroOP")), CInt(drAux("NroOP")), 0)
                    Registro("FechaOP") = If(Not IsDBNull(drAux("FechaCreacion")), CStr(drAux("FechaCreacion")), String.Empty)
                    Registro("RazonSocial") = If(Not IsDBNull(drAux("RSocial")), CStr(drAux("RSocial")), String.Empty)
                    Registro("NroProveedor") = If(Not IsDBNull(drAux("NroProveedor")), CDbl(drAux("NroProveedor")), 0)
                    If Mid(UCase(Trim(drAux("IngBrutos"))), 1, 14) <> "NO SE POSEE" Then
                        Registro("IngBrutos") = Trim(Left(Trim(Replace(Replace(drAux("IngBrutos").ToString(), "-", ""), " ", "")) & Space(14), 14))
                        Registro("InscDir") = ""
                    Else
                        ' Lógica para el caso de "NO SE POSEE"
                    End If
                    Registro("ProdServ") = Left(Trim(drAux("TipoCuit")), 50)
                    Registro("BaseImp") = If(Not IsDBNull(drAux("BaseImponible")), CDbl(drAux("BaseImponible")), 0)
                    Registro("Alicuota") = Format(If(Not IsDBNull(drAux("Alicuota")), CDbl(drAux("Alicuota")), 0), "0.00")
                    Registro("ImpRetenido") = If(Not IsDBNull(drAux("ImporteRetIB")), CDbl(drAux("ImporteRetIB")), 0)
                    Registro("Constancia") = If(Not IsDBNull(drAux("NroRet")), CDbl(drAux("NroRet")), 0)
                    rec.Rows.Add(Registro)
                End If
            Next

            'CIERRO ARCHIVOS
            '*************************************************
            If rec.Rows.Count > 0 Then
                ObtenerRetencionIBLaPampaDesHas = 1
            Else
                ObtenerRetencionIBLaPampaDesHas = 0
            End If


        Catch ex As Exception
            ' Manejar la excepción
            MsgBox("Error al obtener retenciones de IIBB La Pampa. Detalles: " & ex.Message, MsgBoxStyle.Exclamation)
            Return -1
        End Try
    End Function
    Public Function ObtenerRetencionIBJujuyDesHas(ByVal fechaDesde As String, ByVal fechaHasta As String, ByRef rec As DataTable) As Long
        '-----------------------------------------------------
        'Descripción: Obtiene datos de retenciones de I.Brutos Jujuy
        'Parámetros : quincena, mes, año, periodo de fecha (byval) y DataTable por referencia
        'Output     : 1 se encontraron datos.
        '             0 No se encontraron datos.
        '            -1 Error al filtrar datos.
        '-----------------------------------------------------
        '-----------------------------------------------------
        ' Descripción: Obtiene datos de retenciones de I.Brutos de Misiones
        ' Parámetros : fechaDesde, fechaHasta y DataTable por referencia.
        ' Output     : 1 si se encontraron datos, 0 si no se encontraron datos, -1 si hubo un error al filtrar datos.
        '-----------------------------------------------------

        Dim CadenaSQL As String
        Dim RstAux As DataTable
        Dim RstOP As DataTable

        ' Inicializar DataTable
        rec = New DataTable()
        rec.Columns.Add("RazonSocial", GetType(String))
        rec.Columns.Add("NroProveedor", GetType(Double))
        rec.Columns.Add("IngBrutos", GetType(String))
        rec.Columns.Add("InscDir", GetType(String))
        rec.Columns.Add("ProdServ", GetType(String))
        rec.Columns.Add("BaseImp", GetType(Double))
        rec.Columns.Add("Alicuota", GetType(String))
        rec.Columns.Add("ImpRetenido", GetType(Double))
        rec.Columns.Add("Constancia", GetType(Double))
        rec.Columns.Add("NroOP", GetType(Integer))
        rec.Columns.Add("FechaOP", GetType(Date))

        Try
            CadenaSQL = "SELECT * FROM VistaRetencionesIIBBJujuy WHERE FechaCreacion >= '" & fechaDesde & "' AND FechaCreacion <= '" & fechaHasta & "'"
            ' Obtener datos principales
            RstAux = ServidorSQl.GetTabla(CadenaSQL)

            For Each drAux As DataRow In RstAux.Rows
                CadenaSQL = "SELECT dbo.DetalleLiquidaciones.NroInterno, dbo.DetalleLiquidaciones.ImportePagado, dbo.OP.NroOP, dbo.OP.ImporteRetIB, dbo.OP.PorceBaseImponible," &
                        " dbo.ComprobantesProveedores.DescCOmp , dbo.ComprobantesProveedores.TipoGrupo" &
                        " FROM dbo.OP INNER JOIN" &
                        " dbo.Liquidaciones ON dbo.OP.NroLiquidacion = dbo.Liquidaciones.NroLiquidacion INNER JOIN" &
                        " dbo.DetalleLiquidaciones ON dbo.Liquidaciones.NroLiquidacion = dbo.DetalleLiquidaciones.NroLiquidacion INNER JOIN" &
                        " dbo.ComprobantesProveedores ON dbo.DetalleLiquidaciones.NroInterno = dbo.ComprobantesProveedores.NroInterno AND" &
                        " dbo.OP.NroProveedor = dbo.ComprobantesProveedores.NroProveedor" &
                        " WHERE dbo.OP.NroOp = @NroOp"

                ' Parámetro adicional para la segunda consulta
                Dim parametrosOP As SqlParameter() = {New SqlParameter("@NroOp", drAux("NroOP"))}

                ' Obtener datos relacionados
                RstOP = ServidorSQl.GetTablaParam(CadenaSQL, parametrosOP)

                If RstOP IsNot Nothing AndAlso RstOP.Rows.Count > 0 Then
                    Dim Acumulado As Double = 0

                    For Each drOP As DataRow In RstOP.Rows
                        ' Realizar operaciones con RstOP
                        If (CInt(drOP("TipoGrupo")) = 6 And CInt(drOP("DescCOmp")) = 13) _
                    Or (CInt(drOP("TipoGrupo")) = 4 And CInt(drOP("DescCOmp")) = 11) _
                    Or (CInt(drOP("DescCOmp")) = 12) Or (CInt(drOP("DescCOmp")) = 5) Then
                            Continue For
                        Else
                            Acumulado += CDbl(drOP("ImportePagado"))
                        End If
                    Next

                    ' Añadir datos al DataTable
                    Dim Registro As DataRow = rec.NewRow()
                    Registro("NroOP") = If(Not IsDBNull(drAux("NroOP")), CInt(drAux("NroOP")), 0)
                    Registro("FechaOP") = If(Not IsDBNull(drAux("FechaCreacion")), CStr(drAux("FechaCreacion")), String.Empty)
                    Registro("RazonSocial") = If(Not IsDBNull(drAux("RSocial")), CStr(drAux("RSocial")), String.Empty)
                    Registro("NroProveedor") = If(Not IsDBNull(drAux("NroProveedor")), CDbl(drAux("NroProveedor")), 0)
                    If Mid(UCase(Trim(drAux("IngBrutos"))), 1, 14) <> "NO SE POSEE" Then
                        Registro("IngBrutos") = Trim(Left(Trim(Replace(Replace(drAux("IngBrutos").ToString(), "-", ""), " ", "")) & Space(14), 14))
                        Registro("InscDir") = ""
                    Else
                        ' Lógica para el caso de "NO SE POSEE"
                    End If
                    Registro("ProdServ") = Left(Trim(drAux("TipoCuit")), 50)
                    Registro("BaseImp") = If(Not IsDBNull(drAux("BaseImponible")), CDbl(drAux("BaseImponible")), 0)
                    Registro("Alicuota") = Format(If(Not IsDBNull(drAux("Alicuota")), CDbl(drAux("Alicuota")), 0), "0.00")
                    Registro("ImpRetenido") = If(Not IsDBNull(drAux("ImporteRetIB")), CDbl(drAux("ImporteRetIB")), 0)
                    Registro("Constancia") = If(Not IsDBNull(drAux("NroRet")), CDbl(drAux("NroRet")), 0)
                    rec.Rows.Add(Registro)
                End If
            Next

            'CIERRO ARCHIVOS
            '*************************************************
            If rec.Rows.Count > 0 Then
                ObtenerRetencionIBJujuyDesHas = 1
            Else
                ObtenerRetencionIBJujuyDesHas = 0
            End If


        Catch ex As Exception
            ' Manejar la excepción
            MsgBox("Error al obtener retenciones de IIBB Jujuy. Detalles: " & ex.Message, MsgBoxStyle.Exclamation)
            Return -1
        End Try
    End Function


    Public Function ObtenerMesImputacion(ByRef tabla As DataTable, ByVal oMeses As String, ByVal TodosMeses As Boolean) As Integer
        '------------------------------------------------------------------
        ' Buscar ObtenerMesImputacion
        ' Parámetros: Meses, selecciono Meses
        ' Por Referencia devuelve tabla con Fechas de Cierre de Comprobantes Proveedores
        ' Output :    -1 Error en la búsqueda
        '             0 no existe
        '             1 existe
        '------------------------------------------------------------------
        Try
            Dim CadenaSQL As String

            ' Si TodosMeses = True Then
            CadenaSQL = "SELECT distinct convert(datetime,'01/' + ComprobantesProveedores.MesImputacion) as MesImputacion" &
                         " FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor " &
                         " WHERE convert(datetime,'01/' + ComprobantesProveedores.MesImputacion) >= '01/01/2016' " &
                         " ORDER BY MesImputacion DESC"
            tabla = ServidorSQl.GetTablaParam(CadenaSQL, Nothing)

            If tabla IsNot Nothing AndAlso tabla.Rows.Count > 0 Then
                Return 1
            Else
                Return 0
            End If
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Public Function ObtenerDetalleOrdenPagoMensual(ByRef mes As Integer, ByRef anio As Integer, ByRef rec As DataTable) As Integer
        Try

            Dim rstprov As New DataTable
            rec = New DataTable
            rec.Columns.Add("CodProveedor", GetType(Integer))
            rec.Columns.Add("CodTipoProveedor", GetType(Integer))
            rec.Columns.Add("TipoProveedor", GetType(String))
            rec.Columns.Add("RSocial", GetType(String))
            rec.Columns.Add("TotalPagado", GetType(Double))

            Dim query As String = "SELECT dbo.Proveedor.NroProveedor, dbo.Proveedor.RSocial, SUM(dbo.OP.ImporteNeto) AS ImporteNeto, dbo.Proveedor.CodTipoInsumosProveedor " &
                         "FROM dbo.OP INNER JOIN dbo.Proveedor ON dbo.OP.NroProveedor = dbo.Proveedor.NroProveedor " &
                         "WHERE month(FechaCreacion) = " & mes & " AND year(FechaCreacion) = " & anio & " " &
                         "GROUP BY dbo.Proveedor.NroProveedor, dbo.Proveedor.RSocial, dbo.Proveedor.CodTipoInsumosProveedor order by convert(integer,CodTipoInsumosProveedor),convert(integer,dbo.proveedor.NroProveedor)  asc"

            rstprov = ServidorSQl.GetTabla(query)

            If rstprov IsNot Nothing AndAlso rstprov.Rows.Count > 0 Then
                ' Iterar sobre las filas del DataTable
                For Each row As DataRow In rstprov.Rows
                    Dim importeNeto As Double = If(row.IsNull("ImporteNeto"), 0, CDbl(row("ImporteNeto")))
                    If importeNeto <> 0 Then
                        ' Realizar tus operaciones
                        Dim newRow As DataRow = rec.NewRow()

                        newRow("CodProveedor") = CInt(row("NroProveedor"))
                        newRow("CodTipoProveedor") = CInt(Left(Trim(row("CodTipoInsumosProveedor").ToString()), 2))

                        ' Obtener el tipo de insumo del proveedor
                        Dim tipoProveedor As String = controlProveedores.ObtenertipoInsumoProveedor(CInt(row("NroProveedor")))
                        tipoProveedor = Left(tipoProveedor, 50)
                        newRow("TipoProveedor") = tipoProveedor

                        newRow("RSocial") = Left(Trim(row("RSocial").ToString()), 50)
                        newRow("TotalPagado") = importeNeto

                        ' Agregar la nueva fila al DataTable
                        rec.Rows.Add(newRow)
                    End If

                Next
                Return 1
            Else
                Return 0
            End If
        Catch ex As Exception
            ' Manejar la excepción
            MsgBox("Error al obtener detalles de órdenes de pago mensuales. Detalles: " & ex.Message, MsgBoxStyle.Exclamation)
            Return -1
        End Try
    End Function

    Public Function ObtenerInsumosdelMes(Fecha As String, fechaHasta As String, ByRef rec As DataTable) As Long
        Try
            Dim var As String = Format(Month(Fecha), "00") & "/" & Year(Fecha)
            CadenaSQL = "SELECT ComprobantesProveedores.NroProveedor, ComprobantesProveedores.TipoComp, ComprobantesProveedores.NroComp," _
            & " ComprobantesOrdenes.CodInsumo, ComprobantesOrdenes.Cantidad," _
             & " ComprobantesOrdenes.Precio, ComprobantesOrdenes.DescInsumo," _
            & " ComprobantesOrdenes.Total, ComprobantesOrdenes.Gravado," _
            & " (case when ComprobantesOrdenes.Gravado is null" _
            & " then ComprobantesOrdenes.total" _
            & " Else" _
             & " case when ComprobantesOrdenes.Gravado =0 then" _
              & " ComprobantesOrdenes.Total" _
             & " Else" _
              & " ComprobantesOrdenes.Gravado" _
             & " End" _
            & " end ) as TOTALNUEVO" _
            & " , Proveedor.RSocial, ComprobantesProveedores.desccomp, ComprobantesProveedores.TipoGrupo, ComprobantesProveedores.NroCompAlfanumerico" _
            & " FROM ComprobantesOrdenes INNER JOIN ComprobantesProveedores ON ComprobantesOrdenes.NroInterno = ComprobantesProveedores.NroInterno INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor" _
            & " Where mesimputacion ='" & var & "'" _
            & " order by Codinsumo"


            rec = ServidorSQl.GetTabla(CadenaSQL)

            If rec Is Nothing Then
                Return -1
            ElseIf rec.Rows.Count = 0 Then
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            Throw ex
            Return -1
        End Try
    End Function

    Public Function SumasParaAsientoCompras(ByVal Mes As Integer, ByVal Anio As Integer, ByVal TiposComp As Integer, ByRef rec As DataTable) As Long
        '-----------------------------------------------------
        'Descripción: obtiene las sumas de Iva y percepciones
        '             para el asiento compras de un mes determinado
        'Parámetros : mes por valor y recordset por referencia
        'Output     : 1 se encontraron datos.
        '             0 no se encontraron datos.
        '            -1 Error al buscar datos.
        '-----------------------------------------------------
        Dim rstemp As DataTable
        Dim MFecha = Format(Mes, "00") & "/" & Anio
        rec = New DataTable()
        rec.Columns.Add("PercepIB_F", GetType(Double))
        rec.Columns.Add("PercepIva_F", GetType(Double))
        rec.Columns.Add("IvaProd_F", GetType(Double))
        rec.Columns.Add("GanProd_F", GetType(Double))

        rec.Columns.Add("PercepIB_D", GetType(Double))
        rec.Columns.Add("PercepIva_D", GetType(Double))
        rec.Columns.Add("IvaProd_D", GetType(Double))
        rec.Columns.Add("GanProd_D", GetType(Double))

        rec.Columns.Add("PercepIB_C", GetType(Double))
        rec.Columns.Add("PercepIva_C", GetType(Double))
        rec.Columns.Add("IvaProd_C", GetType(Double))
        rec.Columns.Add("GanProd_C", GetType(Double))

        'TOTALES PARA FACTURAS
        rstemp = ServidorSQl.GetTabla("SELECT SUM(TotalPercepIB) AS PercepIB, SUM(PercepGan) AS PercepGan, SUM(PercepIva) AS percepiva, SUM(IvaPROD) AS ivaPROD From ComprobantesProveedores WHERE TipoGrupo = 1 AND (MesImputacion = '" & MFecha & "')")
        Dim row As DataRow

        If rstemp Is Nothing Then
        ElseIf rstemp.Rows.Count = 0 Then
            row = rec.NewRow()
            row("PercepIB_f") = 0
            row("PercepIva_f") = 0
            row("IvaProd_f") = 0
            row("GanProd_F") = 0
            rec.Rows.Add(row)

        Else
            row = rec.NewRow()
            row("PercepIB_f") = rstemp.Rows(0)("percepib")
            row("PercepIva_f") = rstemp.Rows(0)("PercepIva")
            row("IvaProd_f") = rstemp.Rows(0)("IvaProd")
            row("GanProd_F") = rstemp.Rows(0)("PercepGan")
            rec.Rows.Add(row)

        End If

        'TOTALES PARA DEBITOS
        rstemp = ServidorSQl.GetTabla("SELECT SUM(TotalPercepIB) AS PercepIB, SUM(PercepGan) AS PercepGan, SUM(PercepIva) AS percepiva,                                 SUM(IvaPROD) AS ivaPROD From ComprobantesProveedores WHERE TipoGrupo in (4,5,9,11) and                                          (MesImputacion = '" & MFecha & "')")

        If rstemp Is Nothing Then

        ElseIf rstemp.Rows.Count = 0 Then
            row("PercepIB_d") = 0
            row("PercepIva_d") = 0
            row("IvaProd_d") = 0
            row("GanProd_d") = 0
        Else
            row("PercepIB_d") = rstemp.Rows(0)("percepib")
            row("PercepIva_d") = rstemp.Rows(0)("PercepIva")
            row("IvaProd_d") = rstemp.Rows(0)("IvaProd")
            row("GanProd_d") = rstemp.Rows(0)("PercepGan")
        End If

        'TOTALES PARA CREDITOS
        rstemp = ServidorSQl.GetTabla("SELECT SUM(TotalPercepIB) AS PercepIB, SUM(PercepGan) AS PercepGan, SUM(PercepIva) AS percepiva,                                SUM(IvaPROD) AS ivaPROD From ComprobantesProveedores WHERE TipoGrupo in(3,6,10) 
                                       and (MesImputacion= '" & MFecha & "')")

        If rstemp Is Nothing Then
        ElseIf rstemp.Rows.Count = 0 Then
            row("PercepIB_c") = 0
            row("PercepIva_c") = 0
            row("IvaProd_c") = 0
            row("GanProd_C") = 0
        Else
            row("PercepIB_c") = rstemp.Rows(0)("percepib")
            row("PercepIva_c") = rstemp.Rows(0)("PercepIva")
            row("IvaProd_c") = rstemp.Rows(0)("IvaProd")
            row("GanProd_C") = rstemp.Rows(0)("PercepGan")
        End If
        SumasParaAsientoCompras = 1
        Exit Function
        SumasParaAsientoCompras = -1
    End Function


    Public Sub dtAutorizado(ByRef lista As DataTable, ByRef nrointerno As Integer)
        '/*revisar:llevar a clases
        CadenaSQL = " SELECT DISTINCT dbo.ComprobantesOrdenes.NroInterno" _
            & " FROM         dbo.ComprobantesProveedores INNER JOIN" _
            & " dbo.ComprobantesOrdenes ON dbo.ComprobantesProveedores.NroInterno = dbo.ComprobantesOrdenes.NroInterno" _
            & " WHERE     (dbo.ComprobantesProveedores.MarcaAcumulado = 'P') AND (dbo.ComprobantesProveedores.DescComp <> 2) AND" _
            & " (dbo.ComprobantesOrdenes.CodAutoriza <> 0) And dbo.ComprobantesOrdenes.NroInterno  in (" & nrointerno & ")"
        Dim tabla As DataTable = ServidorSQl.GetTabla(CadenaSQL)

        If tabla.Rows.Count > 0 Then
            Dim nuevaFila As DataRow = lista.NewRow()
            nuevaFila("NroInterno") = nrointerno
            lista.Rows.Add(nuevaFila)
        End If
    End Sub


    Public Function ObtenerDetalleOrdenPagoMensualConFechas(ByRef fechaDesde As String, ByRef fechaHasta As String, ByRef rec As DataTable) As Integer
        Try

            Dim rstprov As New DataTable
            rec = New DataTable
            rec.Columns.Add("CodProveedor", GetType(Integer))
            rec.Columns.Add("CodTipoProveedor", GetType(Integer))
            rec.Columns.Add("TipoProveedor", GetType(String))
            rec.Columns.Add("RSocial", GetType(String))
            rec.Columns.Add("TotalPagado", GetType(Double))
            ' Definir la consulta SQL con parámetros
            Dim query As String = "SELECT dbo.Proveedor.NroProveedor, dbo.Proveedor.RSocial, SUM(dbo.OP.ImporteNeto) AS ImporteNeto, dbo.Proveedor.CodTipoInsumosProveedor " &
                     "FROM dbo.OP INNER JOIN dbo.Proveedor ON dbo.OP.NroProveedor = dbo.Proveedor.NroProveedor " &
                     "WHERE FechaCreacion BETWEEN @FechaDesde AND @FechaHasta " &
                     "GROUP BY dbo.Proveedor.NroProveedor, dbo.Proveedor.RSocial, dbo.Proveedor.CodTipoInsumosProveedor ORDER BY CONVERT(INTEGER, CodTipoInsumosProveedor), CONVERT(INTEGER, dbo.Proveedor.NroProveedor) ASC"

            ' Crear los parámetros para la consulta
            Dim parametros As SqlParameter() = {
            New SqlParameter("@FechaDesde", fechaDesde),
            New SqlParameter("@FechaHasta", fechaHasta)
        }

            ' Obtener el DataTable utilizando GetTablaParam
            rstprov = GetTablaParam(query, parametros)

            If rstprov IsNot Nothing AndAlso rstprov.Rows.Count > 0 Then
                ' Iterar sobre las filas del DataTable
                For Each row As DataRow In rstprov.Rows
                    Dim importeNeto As Double = If(row.IsNull("ImporteNeto"), 0, CDbl(row("ImporteNeto")))
                    If importeNeto <> 0 Then
                        ' Realizar tus operaciones
                        Dim newRow As DataRow = rec.NewRow()

                        newRow("CodProveedor") = CInt(row("NroProveedor"))
                        newRow("CodTipoProveedor") = CInt(Left(Trim(row("CodTipoInsumosProveedor").ToString()), 2))

                        ' Obtener el tipo de insumo del proveedor
                        Dim tipoProveedor As String = controlProveedores.ObtenertipoInsumoProveedor(CInt(row("NroProveedor")))
                        tipoProveedor = Left(tipoProveedor, 50)
                        newRow("TipoProveedor") = tipoProveedor

                        newRow("RSocial") = Left(Trim(row("RSocial").ToString()), 50)
                        newRow("TotalPagado") = importeNeto

                        ' Agregar la nueva fila al DataTable
                        rec.Rows.Add(newRow)
                    End If

                Next
                Return 1
            Else
                Return 0
            End If
        Catch ex As Exception
            ' Manejar la excepción
            MsgBox("Error al obtener detalles de órdenes de pago mensuales. Detalles: " & ex.Message, MsgBoxStyle.Exclamation)
            Return -1
        End Try
    End Function
    Public Function BuscarTipoComprobante(ByRef dt As DataTable) As Long
        '-----------------------------------------------------
        'Descripción: Obtiene Descripcion por Tipo Comprobantes
        'Parámetros : dt por ref.
        'Output     : 0 no se encontraron desc.
        '             1 se encontraron desc.
        '            -1 Error al buscar desc.
        '-----------------------------------------------------
        On Error GoTo errores
        dt = ServidorSQl.GetTabla("select * from proveedores.dbo.GruposComprobantes order by NroTipo asc")
        If dt Is Nothing Then
            GoTo errores
        ElseIf dt.Rows.Count = 0 Then
            Return 0
        Else
            Return 1
        End If
        Exit Function
errores:
        Return -1
    End Function

    Public Function BuscarTipos(ByRef dt As DataTable) As Long
        '-----------------------------------------------------
        'Descripción: Busca los tipos de comprobantes
        '             que pueden existir
        'Parámetros : Recordset por referencia para llenarlo c/
        '             los tipos
        'Output     : 0 no se encontraron tipos
        '             1 se encontraron tipos
        '            -1 Error al buscar tipos
        '-----------------------------------------------------
        dt = ServidorSQl.GetTabla("select * from proveedores.dbo.TiposComprobantes order by codigo asc")
        If dt Is Nothing Then
        ElseIf dt.Rows.Count = 0 Then
            Return 0
        Else
            Return 1
        End If
        Exit Function

        Return -1
    End Function
End Class
