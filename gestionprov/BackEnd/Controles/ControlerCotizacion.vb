Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports Guna.UI2.WinForms

Public Class ControlerCotizacion

    Inherits ServidorSQl
    Public Function ObtenerCotizacionDolar(ByVal Fecha As Date, ByRef txt As Guna2TextBox) As Integer
        Dim query As String = "SELECT cotizacion FROM cotizacionesdolar WHERE fecha = @Fecha"
        Dim parametros As New List(Of SqlParameter)()
        parametros.Add(New SqlParameter("@Fecha", SqlDbType.Date) With {.Value = Fecha})

        Dim tabla As DataTable = ServidorSQl.GetTablaParam(query, parametros.ToArray())

        If tabla IsNot Nothing AndAlso tabla.Rows.Count > 0 Then
            ObtenerCotizacionDolar = 1
            txt.Text = Format(Convert.ToDecimal(tabla.Rows(0)("cotizacion")), "0.00")
        Else
            ObtenerCotizacionDolar = 0
        End If

        Return ObtenerCotizacionDolar
    End Function

End Class
