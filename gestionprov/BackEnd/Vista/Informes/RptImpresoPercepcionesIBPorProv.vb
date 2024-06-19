Imports System.Globalization
Imports System.Net.WebRequestMethods
Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document
Imports GrapeCity.Viewer.Common

Public Class RptImpresoPercepcionesIBPorProv
    Public periodo As String
    Dim total As Double = 0
    Dim TotalProv As Double = 0
    Dim cultureAR As New CultureInfo("es-AR")
    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format
        lblPie.Text = "Impreso el " & Date.Today.ToString("dd MMM yyyy")
    End Sub

    Private Sub ReportHeader1_Format(sender As Object, e As EventArgs) Handles ReportHeader1.Format
        lblDireccion.Text = "Lote 1 G - Malabrigo  Tel.03525-42065 - Fax 03525-421312" & Chr(13) &
                            "CP 5223 - Colonia Caroya - Pcia. de Córdoba" & Chr(13) &
                            "E-mail: info@joseguma.com - Site: www.joseguma.com"
        lblFecha.Text = periodo
    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        Dim Valor As Integer
        Valor = 1
        If Fields!TipoGrupo.Value = 1 Then
            txtTipo.Text = "Fac."
        ElseIf Fields!TipoGrupo.Value = 2 Then
            txtTipo.Text = "Rem."
        ElseIf Fields!TipoGrupo.Value = 5 Then
            txtTipo.Text = "Deb."
        ElseIf Fields!TipoGrupo.Value = 3 Then
            Valor = -1
            txtTipo.Text = "Cred."
        ElseIf Fields!TipoGrupo.Value = 11 Then
            txtTipo.Text = "Des."
        End If

        Select Case txtTipoComp.Text
            Case 1
                txtComprobante.Text = "A-"
            Case 2
                txtComprobante.Text = "B-"
            Case 3
                txtComprobante.Text = "C-"
            Case 4
                txtComprobante.Text = "E-"
            Case 5
                txtComprobante.Text = "M-"
            Case 6
                txtComprobante.Text = "X-"
        End Select


        txtImporte.Text = Format(Fields!Percepcion.Value, "N2")
        txtBase.Text = Format(Fields!ImporteProd.Value, "N2")
        txtFechaComp.Text = Format(Fields!fechacomp.Value, "dd/MM/yyyy")
        txtProveedor.Text = txtProveedor.Text & " - "

        ' Si la longitud es menor o igual a 8, formatear como se desea
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

        ' Asignar valores formateados a txtPrefijo
        txtPrefijo.Text = prefijoFormateado

        total = total + (Fields!Percepcion.Value * Valor)
        TotalProv = TotalProv + (Fields!Percepcion.Value * Valor)
    End Sub

    Private Sub GroupFooter1_Format(sender As Object, e As EventArgs) Handles GroupFooter1.Format
        txtTotalProvincia.Text = String.Format(cultureAR, "{0:C}", TotalProv)
        TotalProv = 0
    End Sub
    Private Sub ReportFooter1_Format(sender As Object, e As EventArgs) Handles ReportFooter1.Format
        txtTotal.Text = String.Format(cultureAR, "{0:C}", total)
    End Sub

End Class
