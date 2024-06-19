Imports System.Globalization
Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document
Imports GrapeCity.ActiveReports.Chart
Imports GrapeCity.ActiveReports.PageReportModel
Imports DataPoint = GrapeCity.ActiveReports.Chart.DataPoint
Imports GrapeCity.ActiveReports.ReportsCore.Tools

Public Class RptImpresoResumenOP
    Public periodo As String
    Public titulo As String
    Dim i As Integer
    Dim TotalGrupo As Double
    Dim TotalGeneral As Double
    Dim codTipoProv As String
    Dim tipoProv As String
    Dim cultureAR As New CultureInfo("es-AR")

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format
        lblPie.Text = "Impreso el " & Date.Today.ToString("dd MMM yyyy")
    End Sub

    Private Sub ReportHeader1_Format(sender As Object, e As EventArgs) Handles ReportHeader1.Format
        lblDireccion.Text = "Lote 1 G - Malabrigo  Tel.03525-42065 - Fax 03525-421312" & Chr(13) &
          "CP 5223 - Colonia Caroya - Pcia. de Córdoba" & Chr(13) &
          "E-mail: info@joseguma.com - Site: www.joseguma.com"
        lblFecha.Text = periodo
        lblTitulo.Text = titulo
    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        TotalGrupo = TotalGrupo + Fields!totalpagado.Value
        codTipoProv = CStr(Fields!codtipoproveedor.Value)
        tipoProv = CStr(Fields!tipoproveedor.Value)
        txtImporte.Text = Format(Fields!totalpagado.Value, "N2")
        TotalGeneral += Fields!totalpagado.Value
    End Sub

    Private Sub GroupFooter1_Format(sender As Object, e As EventArgs) Handles GroupFooter1.Format
        'txtTotalCuenta.Text = String.Format(cultureAR, "{0:C}", TotalGrupo)
    End Sub


    Private Sub ReportFooter1_Format(sender As Object, e As EventArgs) Handles ReportFooter1.Format
        txtTotalGeneral.Text = String.Format(cultureAR, "{0:C}", TotalGeneral)
    End Sub
End Class
