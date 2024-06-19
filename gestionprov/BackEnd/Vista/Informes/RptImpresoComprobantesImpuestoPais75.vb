Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class RptImpresoComprobantesImpuestoPais75
    Public periodo As String
    Dim totalImpProd As Double = 0
    Dim totalPerIva As Double = 0
    Dim totalPerGan As Double = 0
    Dim totalPerIB As Double = 0
    Dim totalImpNI As Double = 0
    Dim totalImpPais As Double = 0
    Dim totalGrl As Double = 0

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format


        ' Formato dos decimales despues de la coma
        txtFIP.Text = Format(Fields!importeprod.Value, "N2")
        txtPerIVA.Text = Format(Fields!percepiva.Value, "N2")
        txtPerGan.Text = Format(Fields!percepgan.Value, "N2")
        txtPerIB.Text = Format(Fields!totalpercepib.Value, "N2")
        txtImpNI.Text = Format(Fields!importenoimp.Value, "N2")
        txtTotal.Text = Format(Fields!totalcomprobante.Value, "N2")
        txtImpProd.Text = Format(Fields!importeprod.Value, "N2")
        txtTotalPerIva.Text = Format(Fields!percepiva.Value, "N2")
        txtTotalPerGan.Text = Format(Fields!percepgan.Value, "N2")
        txtTotalPerIB.Text = Format(Fields!totalpercepib.Value, "N2")
        txtTotalGrl.Text = Format(Fields!importenoimp.Value, "N2")
        txtImpPais.Text = Format(Fields!imp25.Value, "N2")
        ' Formatear las fechas y asignarlas a los controles de texto
        txtFechaComp.Text = Format(Fields!fechacomp.Value, "dd/MM/yyyy")
        txtFechaVto.Text = Format(Fields!fechavto.Value, "dd/MM/yyyy")

        Dim importeNoImpValue As Double
        Dim percepIvaValue As Double
        Dim percepganValue As Double
        Dim totalPerIBValue As Double
        Dim importeNoImpValue2 As Double
        Dim totalComprobanteValue As Double
        Dim totalImpPaisValue As Double

        Select Case Fields!DescComp.Value
            Case 7, 8, 9, 10, 11, 12, 18
                If Fields!TipoGrupo.Value = 3 Or Fields!TipoGrupo.Value = 6 Then

                    importeNoImpValue = Double.Parse(Fields!importeprod.Value.ToString())
                    percepIvaValue = Double.Parse(Fields!percepiva.Value.ToString())
                    percepganValue = Double.Parse(Fields!percepgan.Value.ToString())
                    totalPerIBValue = Double.Parse(Fields!totalpercepib.Value.ToString())
                    importeNoImpValue2 = Double.Parse(Fields!importenoimp.Value.ToString())
                    totalComprobanteValue = Double.Parse(Fields!totalComprobante.Value.ToString())
                    totalImpPaisValue = Double.Parse(Fields!imp25.Value.ToString())
                    totalImpProd -= importeNoImpValue
                    totalPerIva -= percepIvaValue
                    totalPerGan -= percepganValue
                    totalPerIB -= totalPerIBValue
                    totalImpNI -= importeNoImpValue2
                    totalImpPais -= totalImpPaisValue
                    totalGrl -= totalComprobanteValue

                Else
                    importeNoImpValue = Double.Parse(Fields!importeprod.Value.ToString())
                    percepIvaValue = Double.Parse(Fields!percepiva.Value.ToString())
                    percepganValue = Double.Parse(Fields!percepgan.Value.ToString())
                    totalPerIBValue = Double.Parse(Fields!totalpercepib.Value.ToString())
                    importeNoImpValue2 = Double.Parse(Fields!importenoimp.Value.ToString())
                    totalComprobanteValue = Double.Parse(Fields!totalComprobante.Value.ToString())
                    totalImpPaisValue = Double.Parse(Fields!imp25.Value.ToString())
                    totalImpProd -= importeNoImpValue
                    totalPerIva -= percepIvaValue
                    totalPerGan -= percepganValue
                    totalPerIB -= totalPerIBValue
                    totalImpNI -= importeNoImpValue2
                    totalImpPais -= totalImpPaisValue
                    totalGrl -= totalComprobanteValue
                End If
            Case Else
                importeNoImpValue = Double.Parse(Fields!importeprod.Value.ToString())
                percepIvaValue = Double.Parse(Fields!percepiva.Value.ToString())
                percepganValue = Double.Parse(Fields!percepgan.Value.ToString())
                totalPerIBValue = Double.Parse(Fields!totalpercepib.Value.ToString())
                importeNoImpValue2 = Double.Parse(Fields!importenoimp.Value.ToString())
                totalImpPaisValue = Double.Parse(Fields!imp25.Value.ToString())
                totalComprobanteValue = Double.Parse(Fields!totalComprobante.Value.ToString())
                totalImpProd += importeNoImpValue
                totalPerIva += percepIvaValue
                totalPerGan += percepganValue
                totalPerIB += totalPerIBValue
                totalImpPais += totalImpPaisValue
                totalImpNI += importeNoImpValue2
                totalGrl += totalComprobanteValue
        End Select

        txtImpProd.Text = Format(Fields!importeprod.Value, "N2")
        txtTotalPerIva.Text = Format(Fields!percepiva.Value, "N2")
        txtTotalPerGan.Text = Format(Fields!percepgan.Value, "N2")
        txtTotalPerIB.Text = Format(Fields!totalpercepib.Value, "N2")
        txtImpPais.Text = Format(Fields!imp25.Value, "N2")
        txtTotalGrl.Text = Format(Fields!importenoimp.Value, "N2")
    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format
        lblPie.Text = "Impreso el " & Date.Today.ToString("dd MMM yyyy")
    End Sub

    Private Sub ReportHeader1_Format(sender As Object, e As EventArgs) Handles ReportHeader1.Format
        lblDireccion.Text = "Lote 1 G - Malabrigo  Tel.03525-42065 - Fax 03525-421312" & Chr(13) &
          "CP 5223 - Colonia Caroya - Pcia. de Córdoba" & Chr(13) &
          "E-mail: info@joseguma.com - Site: www.joseguma.com"
        lblFecha.Text = periodo
    End Sub

    Private Sub ReportFooter1_Format(sender As Object, e As EventArgs) Handles ReportFooter1.Format
        ' Actualizar el contenido del control de texto para el total general
        txtImpProd.Text = Format(Convert.ToDouble(totalImpProd), "N2")
        txtTotalImpNI.Text = Format(Convert.ToDouble(totalImpNI), "N2")
        txtTotalGrl.Text = Format(Convert.ToDouble(totalGrl), "N2")
        txtTotalPerGan.Text = Format(Convert.ToDouble(totalPerGan), "N2")
        txtTotalPerIB.Text = Format(Convert.ToDouble(totalPerIB), "N2")
        txtTotalPerIva.Text = Format(Convert.ToDouble(totalPerIva), "N2")
        txtTotalImpPais.Text = Format(Convert.ToDouble(totalImpPais), "N2")
    End Sub

    Private Sub GroupHeader1_Format(sender As Object, e As EventArgs) Handles GroupHeader1.Format
        txtFechaCarga.Text = Format(Fields!fechacarga.Value, "dd/MM/yyyy")
    End Sub
End Class
