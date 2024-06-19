Imports System.Globalization
Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class RptImpresoInsumosComprados
    Dim cultureAR As New CultureInfo("es-AR")
    Public periodo As String
    Private Sub ReportHeader1_Format(sender As Object, e As EventArgs) Handles ReportHeader1.Format
        lblDireccion.Text = "Lote 1 G - Malabrigo  Tel.03525-42065 - Fax 03525-421312" & Chr(13) &
          "CP 5223 - Colonia Caroya - Pcia. de Córdoba" & Chr(13) &
          "E-mail: info@joseguma.com - Site: www.joseguma.com"
        lblFecha.Text = periodo
    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format
        lblPie.Text = Date.Today.ToString("dd MMM yyyy")
    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        txtFechaComp.Text = Format(Fields!fechacomp.Value, "dd/MM/yyyy")
        txtCantidad.Text = String.Format(CDbl(txtCantidad.Text), "N0")
        txtPrecio.Text = String.Format(CDbl(txtPrecio.Text), "N2")
        txtTotal.Text = String.Format(CDbl(txtTotal.Text), "N2")
    End Sub

    Private Sub GroupFooter2_Format(sender As Object, e As EventArgs) Handles GroupFooter2.Format
        lblGroup2.Text = "TOTAL " & txtDescSubRubro.Text
        txtTotalGroup2.Text = String.Format(cultureAR, "{0:C}", CDbl(txtTotalGroup2.Text))
    End Sub

    Private Sub GroupFooter1_Format(sender As Object, e As EventArgs) Handles GroupFooter1.Format
        lblGroup1.Text = "TOTAL " & txtDescRubro.Text
        txtTotalGroup1.Text = String.Format(cultureAR, "{0:C}", CDbl(txtTotalGroup1.Text))
    End Sub

    Private Sub ReportFooter1_Format(sender As Object, e As EventArgs) Handles ReportFooter1.Format
        txtTotalGeneral.Text = String.Format(cultureAR, "{0:C}", CDbl(txtTotalGeneral.Text))
    End Sub
End Class
