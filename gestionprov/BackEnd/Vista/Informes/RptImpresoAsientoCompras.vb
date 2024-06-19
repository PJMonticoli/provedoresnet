Imports System.Globalization
Imports Controles
Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Data
Imports GrapeCity.ActiveReports.Document
Imports GrapeCity.Viewer.Common
Imports Modelos

Public Class RptImpresoAsientoCompras
    Dim totalGeneral As Double = 0
    Dim controlInforme As ControlerInforme
    Public tabla As DataTable
    Dim cultureAR As New CultureInfo("es-AR")
    Dim total As Double = 0
    Dim totalcuenta As Double = 0
    Public titulo As String
    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format
        lblPie.Text = "Impreso el " & Date.Today.ToString("dd MMM yyyy")
    End Sub

    Private Sub ReportHeader1_Format(sender As Object, e As EventArgs) Handles ReportHeader1.Format
        lblDireccion.Text = "Lote 1 G - Malabrigo  Tel.03525-42065 - Fax 03525-421312" & Chr(13) &
                            "CP 5223 - Colonia Caroya - Pcia. de Córdoba" & Chr(13) &
                            "E-mail: info@joseguma.com - Site: www.joseguma.com"
        txtTipoComp.Text = titulo
    End Sub

    Private Sub ReportFooter1_Format(sender As Object, e As EventArgs) Handles ReportFooter1.Format
        txtDV.Text = "-" & txtDV.Text
        ' Actualizar el contenido del control de texto para el total general
        txtTotalGeneral.Text = totalGeneral.ToString("#,##0.00")
        If Trim(txtTipoComp.Text) = "FACTURAS, DEBITOS." Then
            If tabla.Rows.Count = 0 Then
                txtTotalPerIB.Text = Format(0, "0.00")
                txtTotalIVA.Text = Format(0, "0.00")
                txtTotalPerIVA.Text = Format(0, "0.00")
                txtTotalPerGan.Text = Format(0, "0.00")
            Else
                Shape4.Visible = True
                Shape5.Visible = True
                Shape6.Visible = True
                Shape7.Visible = True
                lblTotalIVA.Visible = True
                lblTotalPerIVA.Visible = True
                lblTotalPerGan.Visible = True
                lblTotalPerIB.Visible = True
                txtTotalIVA.Visible = True
                txtTotalPerIVA.Visible = True
                txtTotalPerGan.Visible = True
                txtTotalPerIB.Visible = True
                txtTotalIVA.Text = Format(GetDoubleValue(tabla.Rows(0)("IvaProd_f")) + GetDoubleValue(tabla.Rows(0)("IvaProd_d")) - GetDoubleValue(tabla.Rows(0)("IvaProd_c")), "#,##0.00")
                txtTotalPerIVA.Text = Format(GetDoubleValue(tabla.Rows(0)("PercepIva_f")) + GetDoubleValue(tabla.Rows(0)("PercepIva_d")) - GetDoubleValue(tabla.Rows(0)("PercepIva_c")), "#,##0.00")
                txtTotalPerIB.Text = Format(GetDoubleValue(tabla.Rows(0)("PercepIB_f")) + GetDoubleValue(tabla.Rows(0)("PercepIB_d")) - GetDoubleValue(tabla.Rows(0)("PercepIB_c")), "#,##0.00")
                txtTotalPerGan.Text = Format(GetDoubleValue(tabla.Rows(0)("GanProd_F")) + GetDoubleValue(tabla.Rows(0)("GanProd_d")) - GetDoubleValue(tabla.Rows(0)("GanProd_C")), "#,##0.00")
            End If

            tabla = Nothing
        Else
            Shape4.Visible = False
            Shape5.Visible = False
            Shape6.Visible = False
            Shape7.Visible = False
            lblTotalIVA.Visible = False
            lblTotalPerIVA.Visible = False
            lblTotalPerGan.Visible = False
            lblTotalPerIB.Visible = False
            txtTotalIVA.Visible = False
            txtTotalPerIVA.Visible = False
            txtTotalPerIB.Visible = False
            txtTotalPerGan.Visible = False
        End If
        txtTotalGeneral.Text = String.Format(cultureAR, "{0:C}", total)
    End Sub
    Private Function GetDoubleValue(value As Object) As Double
        If value Is DBNull.Value Then
            Return 0
        Else
            Return Convert.ToDouble(value)
        End If
    End Function

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        txtCodInsumo.Text = Mid(Fields!CodInsumo.Value, 1, 1) & "." & Mid(Fields!CodInsumo.Value, 2, 2) & "." & Mid(Fields!CodInsumo.Value, 4, 3) & "." & Mid(Fields!CodInsumo.Value, 7, 3) & "." & Mid(Fields!CodInsumo.Value, 10, 4) & "  -  "
        txtTotal.Text = String.Format(cultureAR, "{0:C}", Fields!totales.Value)
        total = total + Fields!totales.Value
        totalcuenta += Fields!totales.Value
    End Sub

    Private Sub GroupHeader1_Format(sender As Object, e As EventArgs) Handles GroupHeader1.Format
        txtDV.Text = "-" & txtDV.Text
    End Sub

    Private Sub GroupFooter1_Format(sender As Object, e As EventArgs) Handles GroupFooter1.Format
        txtTotalCuenta.Text = String.Format(cultureAR, "{0:C}", CDbl(txtTotalCuenta.Text))
    End Sub
End Class
