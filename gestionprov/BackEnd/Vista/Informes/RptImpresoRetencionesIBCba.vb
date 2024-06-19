Imports System.Globalization
Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class RptImpresoRetencionesIBCba
    Public periodo As String
    Public titulo As String
    Dim impretenido As Double = 0
    Dim cultureAR As New CultureInfo("es-AR")
    Private Sub ReportHeader1_Format(sender As Object, e As EventArgs) Handles ReportHeader1.Format
        lblDireccion.Text = "Lote 1 G - Malabrigo  Tel.03525-42065 - Fax 03525-421312" & Chr(13) &
                    "CP 5223 - Colonia Caroya - Pcia. de Córdoba" & Chr(13) &
                    "E-mail: info@joseguma.com - Site: www.joseguma.com"
        lblTitulo.Text = titulo
        lblFecha.Text = periodo
    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format
        lblPie.Text = "Impreso el " & Date.Today.ToString("dd MMM yyyy")
    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        If Fields!FechaOP.Value.ToString = "" Then
            txtFechaOP.Visible = False
            lblFechaHeader.Visible = False
            lblSeparador.Visible = False
            txtNroIncripcion.Location = New Point(2.495, 0)
        Else
            txtFechaOP.Text = Format(Fields!FechaOP.Value, "dd/MM/yyyy")
        End If
        txtImpRet.Text = Format(Fields!impretenido.Value, "N2")
        txtBaseImp.Text = Format(Fields!Baseimp.Value, "N2")
    End Sub
End Class
