Imports System.Globalization
Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document
Imports GrapeCity.ActiveReports.PageReportModel

Public Class RptImpresoRetencionesGan
    Public periodo As String
    Dim total As Double
    Dim cultureAR As New CultureInfo("es-AR")
    Private Sub ReportHeader1_Format(sender As Object, e As EventArgs) Handles ReportHeader1.Format
        lblDireccion.Text = "Lote 1 G - Malabrigo  Tel.03525-42065 - Fax 03525-421312" & Chr(13) &
         "CP 5223 - Colonia Caroya - Pcia. de Córdoba" & Chr(13) &
         "E-mail: info@joseguma.com - Site: www.joseguma.com"
        lblFecha.Text = periodo
    End Sub

    Private Sub GroupHeader1_Format(sender As Object, e As EventArgs) Handles GroupHeader1.Format
        txtImporte.Text = String.Format(Fields!Importe.Value)
        TxtFecha.Text = Format(Fields!fechaComp.Value, "dd/MM/yyyy")
        total = total + Fields!Importe.Value
    End Sub

    Private Sub ReportFooter1_Format(sender As Object, e As EventArgs) Handles ReportFooter1.Format
        txtTotalGeneral.Text = String.Format(cultureAR, "{0:C}", total)
    End Sub
End Class
