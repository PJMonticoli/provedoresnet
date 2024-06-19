Imports System.Globalization
Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class RptImpresoListadoCuenta
    Dim cultureAR As New CultureInfo("es-AR")
    Dim Promedio As Double
    Dim Minimo As Double
    Dim Maximo As Double
    Dim FechaMin As String
    Dim FechaMax As String
    Dim totalfilas As Integer
    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format
        lblPie.Text = "Impreso el " & Date.Today.ToString("dd MMM yyyy")
    End Sub

    Private Sub ReportHeader1_Format(sender As Object, e As EventArgs) Handles ReportHeader1.Format
        lblDireccion.Text = "Lote 1 G - Malabrigo  Tel.03525-42065 - Fax 03525-421312" & Chr(13) &
                            "CP 5223 - Colonia Caroya - Pcia. de Córdoba" & Chr(13) &
                            "E-mail: info@joseguma.com - Site: www.joseguma.com"
    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format

        If Fields!precio.Value > Maximo Then
            Maximo = Fields!precio.Value
            FechaMax = Fields!FechaComp.Value
        End If

        If Fields!precio.Value < Minimo Then
            Minimo = Fields!precio.Value
            FechaMin = Fields!FechaComp.Value
        End If
        Promedio += Fields!precio.Value
        totalfilas += 1
        txtCantidad.Text = Format(Fields!cantidad.Value, "N0")
        txtTotal.Text = Format(Fields!total.Value, "N2")
        txtPUnitario.Text = Format(Fields!precio.Value, "N2")
        txtFechaComp.Text = Format(Fields!fechacomp.Value, "dd/MM/yyyy")
    End Sub

    Private Sub GroupFooter1_Format(sender As Object, e As EventArgs) Handles GroupFooter1.Format
        Promedio = Promedio / totalfilas
        lblPromedio.Text = "Promedio : " & Format(Promedio, "#,##0.000") & vbCrLf & "Mínimo : " & Format(Minimo, "0.000") & " - " & FechaMin & vbCrLf & "Máximo : " & Format(Maximo, "0.000") & " - " & FechaMax
    End Sub

    Private Sub GroupFooter2_Format(sender As Object, e As EventArgs) Handles GroupFooter2.Format
        txtCantidadFooter.Text = String.Format(CDbl(txtCantidadFooter.Text), "N2")
        txtTotalFooter.Text = String.Format(cultureAR, "{0:C}", CDbl(txtTotalFooter.Text))
    End Sub
End Class
