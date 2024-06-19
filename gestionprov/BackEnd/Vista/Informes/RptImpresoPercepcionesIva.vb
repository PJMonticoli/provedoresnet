Imports System.Globalization
Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class RptImpresoPercepcionesIva
    Public periodo As String
    Dim total As Double = 0
    Dim cultureAR As New CultureInfo("es-AR")
    Private Sub ReportHeader1_Format(sender As Object, e As EventArgs) Handles ReportHeader1.Format
        lblDireccion.Text = "Lote 1 G - Malabrigo  Tel.03525-42065 - Fax 03525-421312" & Chr(13) &
              "CP 5223 - Colonia Caroya - Pcia. de C�rdoba" & Chr(13) &
              "E-mail: info@joseguma.com - Site: www.joseguma.com"
        lblFecha.Text = periodo
    End Sub
    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format
        lblPie.Text = Date.Today.ToString("dd MMM yyyy")
    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        Select Case Fields!DescComp.Value
            Case 1
                txtTipo.Text = "Fac."
                total = total + Fields!percepiva.Value
            Case 2
                txtTipo.Text = "Rem."
                total = total + Fields!percepiva.Value
            Case 3, 4, 5, 6, 13, 14, 17, 19, 21
                txtTipo.Text = "Deb."
                total = total + Fields!percepiva.Value
            Case 7, 8, 9, 10, 11, 12, 18, 20, 22
                txtTipo.Text = "Cred."
                total = total + Fields!percepiva.Value
            Case 23, 24
                txtTipo.Text = "Des."
                total = total + Fields!percepiva.Value
        End Select

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



        txtImporte.Text = Format(Fields!percepiva.Value, "N2")
        txtFechaComp.Text = Format(Fields!fechacomp.Value, "dd/MM/yyyy")
        txtProveedor.Text = txtProveedor.Text & " - "

        ' Si la longitud es menor o igual a 8, formatear como se desea
        Dim nroComp As String = Fields!nroComp.Value.ToString()

        ' Eliminar espacios en blanco y guiones existentes
        Dim inputText As String = nroComp.Trim().Replace(" ", "").Replace("-", "")

        ' Asegurar que la longitud sea de 12 caracteres
        inputText = inputText.PadLeft(12, "0"c)

        ' Formatear seg�n el formato requerido "xxxx-xxxxxxxx"
        Dim parte1 As String = inputText.Substring(0, 4)
        Dim parte2 As String = inputText.Substring(4)

        ' Formatear txtPrefijo con el guion
        Dim prefijoFormateado As String = $"{parte1}-{parte2}"

        ' Asignar valores formateados a txtPrefijo
        txtPrefijo.Text = prefijoFormateado

    End Sub

    Private Sub ReportFooter1_Format(sender As Object, e As EventArgs) Handles ReportFooter1.Format
        txtTotal.Text = String.Format(cultureAR, "{0:C}", total)
    End Sub
End Class
