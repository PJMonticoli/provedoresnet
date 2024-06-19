Imports System.Data.SqlClient

Public Class ControlerPDF
    Inherits ServidorSQl

    Public Function consultaPDF(ByVal NroInterno As Integer) As DataTable
        Dim CadenaSql As String = "SELECT * FROM proveedores.dbo.ComprobantesProveedores C INNER JOIN proveedores.dbo.Proveedor P ON P.NroProveedor = C.NroProveedor WHERE NroInterno = " & NroInterno
        Dim dt As New DataTable
        dt = ServidorSQl.GetTabla(CadenaSql)
        Return dt
    End Function
End Class
