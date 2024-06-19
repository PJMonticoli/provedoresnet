Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Runtime.Remoting.Contexts
Imports System.Web.UI.WebControls

Public Class ControlerCierre
    Inherits ServidorSQl
    Dim CadenaSql As String
    Public Function AcumularCierreDiarioNuevo(ByRef tabla As DataTable) As Integer

        CadenaSql = "SELECT ComprobantesProveedores.NroInterno,ComprobantesProveedores.NroProveedor, ComprobantesProveedores.DescComp,ComprobantesProveedores.TipoComp, ComprobantesProveedores.NroComp, ComprobantesProveedores.FechaComp,ComprobantesProveedores.FechaVto, ComprobantesProveedores.Observacion, ComprobantesProveedores.IvaProd,ComprobantesProveedores.ImporteProd, ComprobantesProveedores.PercepIva, ComprobantesProveedores.PercepGan,ComprobantesProveedores.TotalPercepIB, ComprobantesProveedores.ImporteNoImp, Proveedor.Provincia,CondicionPagoComprobantes.descripcion" _
            & " FROM ComprobantesProveedores INNER JOIN Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor INNER JOIN CondicionPagoComprobantes ON ComprobantesProveedores.CondicionPago = CondicionPagoComprobantes.codigo" _
            & " WHERE (ComprobantesProveedores.MarcaAcumulado = 'N' and ComprobantesProveedores.DescComp<>2)"

        tabla = ServidorSQl.GetTabla(CadenaSql)
        If tabla Is Nothing Then
            Return -1
        ElseIf tabla.Rows.Count = 0 Then
            Return 0
        Else
            Return 1
        End If
    End Function

    Public Function ActualizarAcumulacionComprobante(NroInterno As Long) As Long
        '-----------------------------------------------------
        'Descripción: Marca como pasado a DoS un registro del sql
        'Parámetros : nro interno
        'Output     : 1 se actualizó con éxito.
        '            -1 Error al actualizar datos.
        '-----------------------------------------------------
        On Error GoTo errores
        '*/revisar: transaccion
        CadenaSql = "UPDATE ComprobantesProveedores set MarcaAcumulado='A' WHERE NroInterno=" & NroInterno
        ServidorSQl.InsertTabla(CadenaSql)
        ActualizarAcumulacionComprobante = 1
        Exit Function
errores:
        ActualizarAcumulacionComprobante = -1
    End Function

    Public Function consultaCierreMes(ByRef DiaCierre As String, ByRef tabla As DataTable) As Integer
        CadenaSql = "SELECT ComprobantesProveedores.NroInterno, ComprobantesProveedores.NroComp , ComprobantesProveedores.DescComp, dbo.ComprobantesProveedores.FechaComp, dbo.ComprobantesProveedores.TotalComprobante, dbo.Proveedor.RSocial, " _
        & " dbo.Proveedor.NroProveedor , dbo.DescripcionComprobantes.Descripcion " _
        & " FROM         dbo.ComprobantesProveedores INNER JOIN" _
        & "     dbo.Proveedor ON dbo.ComprobantesProveedores.NroProveedor = dbo.Proveedor.NroProveedor INNER JOIN" _
        & "     dbo.DescripcionComprobantes ON dbo.ComprobantesProveedores.DescComp = dbo.DescripcionComprobantes.Codigo LEFT OUTER JOIN" _
        & "     dbo.ComprobantesOrdenes ON dbo.ComprobantesProveedores.NroInterno = dbo.ComprobantesOrdenes.NroInterno" _
        & " WHERE     (dbo.ComprobantesProveedores.DescComp IN (15, 16)) AND (dbo.ComprobantesOrdenes.CodInsumo IS NULL) and datediff(d,'" & DiaCierre & "',ComprobantesProveedores.fechacomp)<=0  " _
        & " ORDER BY dbo.Proveedor.NroProveedor, dbo.ComprobantesProveedores.NroInterno"
        tabla = ServidorSQl.GetTabla(CadenaSql)
    End Function


    Public Function ActualizarMesImputacion(ByVal Mes As Integer, ByVal Anio As Integer, ByVal ultimoDiaMes As Integer) As Long

        Dim MesImp As String
        Dim Diacierre As DateTime
        Dim rec As New DataTable

        Try
            MesImp = Format(Mes, "00") & "/" & Anio
            Diacierre = New DateTime(Anio, Mes, ultimoDiaMes)

            Dim parametros As New List(Of SqlParameter) From {
            New SqlParameter("@Diacierre", SqlDbType.DateTime) With {.Value = Diacierre},
            New SqlParameter("@MesImp", SqlDbType.VarChar) With {.Value = (MesImp)}
        }

            ' Consulta SQL con parámetro
            CadenaSql = "select * from ComprobantesProveedores " &
                    " Where  ComprobantesProveedores.mesimputacion is null and ComprobantesProveedores.fechacomp <= @Diacierre AND (ComprobantesProveedores.DescComp <> 2)"

            ' Obtener el DataTable con parámetros
            rec = ServidorSQl.GetTablaParam(CadenaSql, parametros.ToArray())

            If rec Is Nothing Then
                Throw New Exception("Error al ejecutar la consulta.")
            ElseIf rec.Rows.Count = 0 Then
                ActualizarMesImputacion = 0
            Else
                ' Limpiar la colección de parámetros antes de agregar nuevos parámetros
                parametros.Clear()

                ' Agregar nuevos parámetros
                parametros.AddRange({
                New SqlParameter("@Diacierre", SqlDbType.DateTime) With {.Value = Diacierre},
                New SqlParameter("@MesImp", SqlDbType.VarChar) With {.Value = (MesImp)}
            })

                ' Consulta SQL de actualización
                CadenaSql = "Update ComprobantesProveedores " &
                        " Set mesImputacion = @MesImp " &
                        " Where ComprobantesProveedores.mesimputacion is null and ComprobantesProveedores.fechacomp <= @Diacierre AND (ComprobantesProveedores.DescComp <> 2)"

                ' Ejecutar la actualización con parámetros
                ServidorSQl.InsertTablaParam(CadenaSql, parametros.ToArray())
                ActualizarMesImputacion = 1
            End If

        Catch ex As Exception
            MsgBox("Error en la función ActualizarMesImputacion: " & ex.Message)
            ActualizarMesImputacion = -1
        End Try

        Return ActualizarMesImputacion
    End Function





End Class
