Imports System.Globalization
Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class RptImpresoControlDiario
    Public periodo As String
    Dim totaldiario As Double = 0

    Dim cultureAR As New CultureInfo("es-AR")
    Private Sub ReportHeader1_Format(sender As Object, e As EventArgs) Handles ReportHeader1.Format
        lblDireccion.Text = "Lote 1 G - Malabrigo  Tel.03525-42065 - Fax 03525-421312" & Chr(13) &
          "CP 5223 - Colonia Caroya - Pcia. de Córdoba" & Chr(13) &
          "E-mail: info@joseguma.com - Site: www.joseguma.com"
    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        txtInsumo.Text = Mid(Fields!codinsumo.Value.ToString, 1, 1) & "." & Mid(Fields!codinsumo.Value.ToString, 2, 2) & "." & Mid(Fields!codinsumo.Value.ToString, 4, 3) & "." & Mid(Fields!codinsumo.Value.ToString, 7, 3) & "." & Mid(Fields!codinsumo.Value.ToString, 10, 4) & " - " & Trim(Fields!descinsumo.Value.ToString)
    End Sub

    Private Sub GroupHeader1_Format(sender As Object, e As EventArgs) Handles GroupHeader1.Format
        Select Case Fields!TipoComp.Value
            Case 1
                txtComprobante.Text = "FP -"
            Case 2
                txtComprobante.Text = "R -"
            Case 3
                txtComprobante.Text = "DV -"
            Case 4
                txtComprobante.Text = "DC -"
            Case 5
                txtComprobante.Text = "DCR-"
            Case 6
                txtComprobante.Text = "DDP-"
            Case 7
                txtComprobante.Text = "CV -"
            Case 8
                txtComprobante.Text = "CC -"
            Case 9
                txtComprobante.Text = "CDP -"
            Case 10
                txtComprobante.Text = "CB -"
            Case 11
                txtComprobante.Text = "CA -"
            Case 12
                txtComprobante.Text = "CCR-"
            Case 13
                txtComprobante.Text = "DA -"
            Case 14
                txtComprobante.Text = "DB -"
            Case 15
                txtComprobante.Text = "AOP-"
            Case 16
                txtComprobante.Text = "OPA-"
            Case 17
                txtComprobante.Text = "DDC-"
            Case 18
                txtComprobante.Text = "CDC-"
            Case 19
                txtComprobante.Text = "DAI-"
            Case 20
                txtComprobante.Text = "CAI-"
            Case 21
                txtComprobante.Text = "DRC-"
            Case 22
                txtComprobante.Text = "CRC-"
            Case 23
                txtComprobante.Text = "DI-"
            Case 24
                txtComprobante.Text = "DE-"
        End Select

        Select Case Fields!TipoComp.Value
            Case 1
                txtComprobante.Text = txtComprobante.Text & "A-"
            Case 2
                txtComprobante.Text = txtComprobante.Text & "B-"
            Case 3
                txtComprobante.Text = txtComprobante.Text & "C-"
            Case 4
                txtComprobante.Text = txtComprobante.Text & "E-"
            Case 5
                txtComprobante.Text = txtComprobante.Text & "M-"
            Case 6
                txtComprobante.Text = txtComprobante.Text & "X-"
        End Select
        Dim nroComp As String = Fields!nroComp.Value.ToString()

        ' Eliminar espacios en blanco y guiones existentes
        Dim inputText As String = nroComp.Trim().Replace(" ", "").Replace("-", "")

        ' Asegurar que la longitud sea de 12 caracteres
        inputText = inputText.PadLeft(12, "0"c)

        ' Formatear según el formato requerido "xxxx-xxxxxxxx"
        Dim parte1 As String = inputText.Substring(0, 4)
        Dim parte2 As String = inputText.Substring(4)

        ' Formatear txtPrefijo con el guion
        Dim prefijoFormateado As String = $"{parte1}-{parte2}"
        txtComprobante.Text &= prefijoFormateado
        'Dim nroComp As String = Fields!NroComp.Value.ToString("000000000000")



        If Fields!TipoGrupo.Value = 3 Or Fields!TipoGrupo.Value = 6 Then
            totaldiario = totaldiario - Fields!totalcomprobante.Value
            txtTotal.Text = String.Format(cultureAR, "{0:C}", -1 * Fields!total.Value)
            txtIvaProd.Text = String.Format(cultureAR, "{0:C}", -1 * Fields!ivaprod.Value)
            txtImpProd.Text = String.Format(cultureAR, "{0:C}", -1 * Fields!importeprod.Value)
            txtPerIB.Text = String.Format(cultureAR, "{0:C}", -1 * Fields!totalpercepib.Value)
            txtPerGan.Text = String.Format(cultureAR, "{0:C}", -1 * Fields!percepgan.Value)
            txtImpNoImp.Text = String.Format(cultureAR, "{0:C}", -1 * Fields!importenoimp.Value)
        Else
            totaldiario = totaldiario + Fields!totalcomprobante.Value
            txtTotal.Text = String.Format(cultureAR, "{0:C}", Fields!totalcomprobante.Value)
            txtIvaProd.Text = String.Format(cultureAR, "{0:C}", Fields!ivaprod.Value)
            txtImpProd.Text = String.Format(cultureAR, "{0:C}", Fields!importeprod.Value)
            txtPerIB.Text = String.Format(cultureAR, "{0:C}", Fields!totalpercepib.Value)
            txtPerGan.Text = String.Format(cultureAR, "{0:C}", Fields!percepgan.Value)
            txtImpNoImp.Text = String.Format(cultureAR, "{0:C}", Fields!importenoimp.Value)
        End If

        txtFechaComp.Text = Format(Fields!fechacomp.Value, "dd/MM/yyyy")
        txtFechaVto.Text = Format(Fields!fechaVto.Value, "dd/MM/yyyy")
    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format
        lblPie.Text = Date.Today.ToString("dd MMM yyyy")
    End Sub

    Private Sub ReportFooter1_Format(sender As Object, e As EventArgs) Handles ReportFooter1.Format
        txtTotalDiario.Text = String.Format(cultureAR, "{0:C}", totaldiario)
    End Sub
End Class
