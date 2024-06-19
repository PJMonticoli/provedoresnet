Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class RptImpresoComprobantesProveedores
    Private Sub ReportHeader1_Format(sender As Object, e As EventArgs) Handles ReportHeader1.Format
        lblDireccion.Text = "Lote 1 G - Malabrigo  Tel.03525-42065 - Fax 03525-421312" & Chr(13) &
         "CP 5223 - Colonia Caroya - Pcia. de Córdoba" & Chr(13) &
         "E-mail: info@joseguma.com - Site: www.joseguma.com"

    End Sub
End Class
