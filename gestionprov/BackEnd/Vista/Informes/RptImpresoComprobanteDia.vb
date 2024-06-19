Imports System.Net.WebRequestMethods
Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document
Imports GrapeCity.ActiveReports.Extensibility.Rendering.Components.Map

Public Class RptImpresoComprobanteDia
    Public periodo As String
    Public flag As Integer
    Dim totalImpProd As Double = 0
    Dim totalIvaProd As Double = 0
    Dim totalPerIva As Double = 0
    Dim totalPerGan As Double = 0
    Dim totalPerIB As Double = 0
    Dim totalImpNI As Double = 0
    Dim totalGrl As Double = 0
    Public titulo As String
    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        Try

            Select Case CInt(txtComprobante.Text)
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

        Catch ex As Exception
            ' Manejar excepciones si es necesario
            MsgBox("Error al obtener datos de ado_dc. " & ex.ToString)
        End Try
        txtNroProveedor.Text = txtNroProveedor.Text & " - "

        Select Case txtTipoComp.Text
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

        txtComprobante.Text = txtComprobante.Text

        If txtnroCompAlfanumerico.Text.Length > 8 Then
            ' Si la longitud es mayor a 8, utilizar nroCompAlfanumerico directamente
            txtPrefijo.Text = txtPrefijo.Text & txtnroCompAlfanumerico.Text
        Else
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
        End If
        ' Formato dos decimales despues de la coma
        txtFIP.Text = Format(Fields!importeprod.Value, "N2")
        txtIvaProd.Text = Format(Fields!ivaprod.Value, "N2")
        txtPerIVA.Text = Format(Fields!percepiva.Value, "N2")
        txtPerGan.Text = Format(Fields!percepgan.Value, "N2")
        txtPerIB.Text = Format(Fields!totalpercepib.Value, "N2")
        txtImpNI.Text = Format(Fields!importenoimp.Value, "N2")
        txtTotal.Text = Format(Fields!totalcomprobante.Value, "N2")
        txtImpProd.Text = Format(Fields!importeprod.Value, "N2")
        txtTotalIvaProd.Text = Format(Fields!ivaprod.Value, "N2")
        txtTotalPerIva.Text = Format(Fields!percepiva.Value, "N2")
        txtTotalPerGan.Text = Format(Fields!percepgan.Value, "N2")
        txtTotalPerIB.Text = Format(Fields!totalpercepib.Value, "N2")
        txtTotalGrl.Text = Format(Fields!importenoimp.Value, "N2")
        ' Formatear las fechas y asignarlas a los controles de texto
        txtFechaComp.Text = Format(Fields!fechacomp.Value, "dd/MM/yyyy")
        txtFechaVto.Text = Format(Fields!fechavto.Value, "dd/MM/yyyy")

        '    'datafield       variable
        '    'importeprod => totalImpProd
        '    'ivaprod => totalIvaProd
        '    'percepiva => totalPerIva
        '    'percepgan => totalPerGan
        '    'totalpercepib => txtTotalPerIB
        '    'importenoimp => totalImpNI
        '    'totalComprobante => totalGrl
        Dim importeNoImpValue As Double
        Dim ivaProdValue As Double
        Dim percepIvaValue As Double
        Dim percepganValue As Double
        Dim totalPerIBValue As Double
        Dim importeNoImpValue2 As Double
        Dim totalComprobanteValue As Double

        Select Case flag
            Case 1 'Imprime reporte ImpresoComprobanteDia cuando es 1
                If Fields!TipoGrupo.Value = 3 Or Fields!TipoGrupo.Value = 6 Or Fields!TipoGrupo.Value = 8 Or Fields!TipoGrupo.Value = 10 Then
                    Dim impProdValue As Double
                    If Double.TryParse(txtImpProd.Text, impProdValue) Then
                        txtImpProd.Text = Format(impProdValue * -1, "#,##0.00")
                    Else
                        ' Manejar la situación en la que el texto no es un número válido
                        txtImpProd.Text = "0.00"
                    End If
                    importeNoImpValue = Double.Parse(Fields!importeprod.Value.ToString())
                    ivaProdValue = Double.Parse(Fields!ivaprod.Value.ToString())
                    percepIvaValue = Double.Parse(Fields!percepiva.Value.ToString())
                    percepganValue = Double.Parse(Fields!percepgan.Value.ToString())
                    totalPerIBValue = Double.Parse(Fields!totalpercepib.Value.ToString())
                    importeNoImpValue2 = Double.Parse(Fields!importenoimp.Value.ToString())
                    totalComprobanteValue = Double.Parse(Fields!totalComprobante.Value.ToString())
                    totalImpProd -= importeNoImpValue
                    totalIvaProd -= ivaProdValue
                    totalPerIva -= percepIvaValue
                    totalPerGan -= percepganValue
                    totalPerIB -= totalPerIBValue
                    totalImpNI -= importeNoImpValue2
                    totalGrl -= totalComprobanteValue
                Else

                    importeNoImpValue = Double.Parse(Fields!importeprod.Value.ToString())
                    ivaProdValue = Double.Parse(Fields!ivaprod.Value.ToString())
                    percepIvaValue = Double.Parse(Fields!percepiva.Value.ToString())
                    percepganValue = Double.Parse(Fields!percepgan.Value.ToString())
                    totalPerIBValue = Double.Parse(Fields!totalpercepib.Value.ToString())
                    importeNoImpValue2 = Double.Parse(Fields!importenoimp.Value.ToString())
                    totalComprobanteValue = Double.Parse(Fields!totalComprobante.Value.ToString())
                    totalImpProd += importeNoImpValue
                    totalIvaProd += ivaProdValue
                    totalPerIva += percepIvaValue
                    totalPerGan += percepganValue
                    totalPerIB += totalPerIBValue
                    totalImpNI += importeNoImpValue2
                    totalGrl += totalComprobanteValue
                End If
            Case 2  'Imprime reporte ImpresoComprobanteDia cuando es 2
                Select Case Fields!DescComp.Value
                    Case 7, 8, 9, 10, 11, 12, 18
                        If Fields!TipoGrupo.Value = 3 Or Fields!TipoGrupo.Value = 6 Then

                            importeNoImpValue = Double.Parse(Fields!importeprod.Value.ToString())
                            ivaProdValue = Double.Parse(Fields!ivaprod.Value.ToString())
                            percepIvaValue = Double.Parse(Fields!percepiva.Value.ToString())
                            percepganValue = Double.Parse(Fields!percepgan.Value.ToString())
                            totalPerIBValue = Double.Parse(Fields!totalpercepib.Value.ToString())
                            importeNoImpValue2 = Double.Parse(Fields!importenoimp.Value.ToString())
                            totalComprobanteValue = Double.Parse(Fields!totalComprobante.Value.ToString())
                            totalImpProd -= importeNoImpValue
                            totalIvaProd -= ivaProdValue
                            totalPerIva -= percepIvaValue
                            totalPerGan -= percepganValue
                            totalPerIB -= totalPerIBValue
                            totalImpNI -= importeNoImpValue2
                            totalGrl -= totalComprobanteValue

                        Else
                            importeNoImpValue = Double.Parse(Fields!importeprod.Value.ToString())
                            ivaProdValue = Double.Parse(Fields!ivaprod.Value.ToString())
                            percepIvaValue = Double.Parse(Fields!percepiva.Value.ToString())
                            percepganValue = Double.Parse(Fields!percepgan.Value.ToString())
                            totalPerIBValue = Double.Parse(Fields!totalpercepib.Value.ToString())
                            importeNoImpValue2 = Double.Parse(Fields!importenoimp.Value.ToString())
                            totalComprobanteValue = Double.Parse(Fields!totalComprobante.Value.ToString())
                            'totalImpProd += importeNoImpValue
                            'totalIvaProd += ivaProdValue
                            'totalPerIva += percepIvaValue
                            'totalPerGan += percepganValue
                            'totalPerIB += totalPerIBValue
                            'totalImpNI += importeNoImpValue2
                            'totalGrl += totalComprobanteValue
                            totalImpProd -= importeNoImpValue
                            totalIvaProd -= ivaProdValue
                            totalPerIva -= percepIvaValue
                            totalPerGan -= percepganValue
                            totalPerIB -= totalPerIBValue
                            totalImpNI -= importeNoImpValue2
                            totalGrl -= totalComprobanteValue
                        End If
                    Case Else
                        importeNoImpValue = Double.Parse(Fields!importeprod.Value.ToString())
                        ivaProdValue = Double.Parse(Fields!ivaprod.Value.ToString())
                        percepIvaValue = Double.Parse(Fields!percepiva.Value.ToString())
                        percepganValue = Double.Parse(Fields!percepgan.Value.ToString())
                        totalPerIBValue = Double.Parse(Fields!totalpercepib.Value.ToString())
                        importeNoImpValue2 = Double.Parse(Fields!importenoimp.Value.ToString())
                        totalComprobanteValue = Double.Parse(Fields!totalComprobante.Value.ToString())
                        totalImpProd += importeNoImpValue
                        totalIvaProd += ivaProdValue
                        totalPerIva += percepIvaValue
                        totalPerGan += percepganValue
                        totalPerIB += totalPerIBValue
                        totalImpNI += importeNoImpValue2
                        totalGrl += totalComprobanteValue
                End Select
            Case 3
                Select Case Fields!DescComp.Value
                    Case 7, 8, 9, 10, 11, 12, 18
                        If Fields!TipoGrupo.Value = 3 Or Fields!TipoGrupo.Value = 6 Then
                            importeNoImpValue = Double.Parse(Fields!importeprod.Value.ToString())
                            ivaProdValue = Double.Parse(Fields!ivaprod.Value.ToString())
                            percepIvaValue = Double.Parse(Fields!percepiva.Value.ToString())
                            percepganValue = Double.Parse(Fields!percepgan.Value.ToString())
                            totalPerIBValue = Double.Parse(Fields!totalpercepib.Value.ToString())
                            importeNoImpValue2 = Double.Parse(Fields!importenoimp.Value.ToString())
                            totalComprobanteValue = Double.Parse(Fields!totalComprobante.Value.ToString())
                            totalImpProd -= importeNoImpValue
                            totalIvaProd -= ivaProdValue
                            totalPerIva -= percepIvaValue
                            totalPerGan -= percepganValue
                            totalPerIB -= totalPerIBValue
                            totalImpNI -= importeNoImpValue2
                            totalGrl -= totalComprobanteValue

                        Else
                            importeNoImpValue = Double.Parse(Fields!importeprod.Value.ToString())
                            ivaProdValue = Double.Parse(Fields!ivaprod.Value.ToString())
                            percepIvaValue = Double.Parse(Fields!percepiva.Value.ToString())
                            percepganValue = Double.Parse(Fields!percepgan.Value.ToString())
                            totalPerIBValue = Double.Parse(Fields!totalpercepib.Value.ToString())
                            importeNoImpValue2 = Double.Parse(Fields!importenoimp.Value.ToString())
                            totalComprobanteValue = Double.Parse(Fields!totalComprobante.Value.ToString())
                            'totalImpProd += importeNoImpValue
                            'totalIvaProd += ivaProdValue
                            'totalPerIva += percepIvaValue
                            'totalPerGan += percepganValue
                            'totalPerIB += totalPerIBValue
                            'totalImpNI += importeNoImpValue2
                            'totalGrl += totalComprobanteValue
                            totalImpProd -= importeNoImpValue
                            totalIvaProd -= ivaProdValue
                            totalPerIva -= percepIvaValue
                            totalPerGan -= percepganValue
                            totalPerIB -= totalPerIBValue
                            totalImpNI -= importeNoImpValue2
                            totalGrl -= totalComprobanteValue
                        End If
                    Case Else
                        importeNoImpValue = Double.Parse(Fields!importeprod.Value.ToString())
                        ivaProdValue = Double.Parse(Fields!ivaprod.Value.ToString())
                        percepIvaValue = Double.Parse(Fields!percepiva.Value.ToString())
                        percepganValue = Double.Parse(Fields!percepgan.Value.ToString())
                        totalPerIBValue = Double.Parse(Fields!totalpercepib.Value.ToString())
                        importeNoImpValue2 = Double.Parse(Fields!importenoimp.Value.ToString())
                        totalComprobanteValue = Double.Parse(Fields!totalComprobante.Value.ToString())
                        totalImpProd += importeNoImpValue
                        totalIvaProd += ivaProdValue
                        totalPerIva += percepIvaValue
                        totalPerGan += percepganValue
                        totalPerIB += totalPerIBValue
                        totalImpNI += importeNoImpValue2
                        totalGrl += totalComprobanteValue
                End Select
            Case 4
                Select Case Fields!DescComp.Value
                    Case 7, 8, 9, 10, 11, 12, 18
                        If Fields!TipoGrupo.Value = 3 Or Fields!TipoGrupo.Value = 6 Then
                            importeNoImpValue = Double.Parse(Fields!importeprod.Value.ToString())
                            ivaProdValue = Double.Parse(Fields!ivaprod.Value.ToString())
                            percepIvaValue = Double.Parse(Fields!percepiva.Value.ToString())
                            percepganValue = Double.Parse(Fields!percepgan.Value.ToString())
                            totalPerIBValue = Double.Parse(Fields!totalpercepib.Value.ToString())
                            importeNoImpValue2 = Double.Parse(Fields!importenoimp.Value.ToString())
                            totalComprobanteValue = Double.Parse(Fields!totalComprobante.Value.ToString())
                            totalImpProd -= importeNoImpValue
                            totalIvaProd -= ivaProdValue
                            totalPerIva -= percepIvaValue
                            totalPerGan -= percepganValue
                            totalPerIB -= totalPerIBValue
                            totalImpNI -= importeNoImpValue2
                            totalGrl -= totalComprobanteValue

                        Else
                            importeNoImpValue = Double.Parse(Fields!importeprod.Value.ToString())
                            ivaProdValue = Double.Parse(Fields!ivaprod.Value.ToString())
                            percepIvaValue = Double.Parse(Fields!percepiva.Value.ToString())
                            percepganValue = Double.Parse(Fields!percepgan.Value.ToString())
                            totalPerIBValue = Double.Parse(Fields!totalpercepib.Value.ToString())
                            importeNoImpValue2 = Double.Parse(Fields!importenoimp.Value.ToString())
                            totalComprobanteValue = Double.Parse(Fields!totalComprobante.Value.ToString())
                            'totalImpProd += importeNoImpValue
                            'totalIvaProd += ivaProdValue
                            'totalPerIva += percepIvaValue
                            'totalPerGan += percepganValue
                            'totalPerIB += totalPerIBValue
                            'totalImpNI += importeNoImpValue2
                            'totalGrl += totalComprobanteValue
                            totalImpProd -= importeNoImpValue
                            totalIvaProd -= ivaProdValue
                            totalPerIva -= percepIvaValue
                            totalPerGan -= percepganValue
                            totalPerIB -= totalPerIBValue
                            totalImpNI -= importeNoImpValue2
                            totalGrl -= totalComprobanteValue
                        End If
                    Case Else
                        importeNoImpValue = Double.Parse(Fields!importeprod.Value.ToString())
                        ivaProdValue = Double.Parse(Fields!ivaprod.Value.ToString())
                        percepIvaValue = Double.Parse(Fields!percepiva.Value.ToString())
                        percepganValue = Double.Parse(Fields!percepgan.Value.ToString())
                        totalPerIBValue = Double.Parse(Fields!totalpercepib.Value.ToString())
                        importeNoImpValue2 = Double.Parse(Fields!importenoimp.Value.ToString())
                        totalComprobanteValue = Double.Parse(Fields!totalComprobante.Value.ToString())
                        totalImpProd += importeNoImpValue
                        totalIvaProd += ivaProdValue
                        totalPerIva += percepIvaValue
                        totalPerGan += percepganValue
                        totalPerIB += totalPerIBValue
                        totalImpNI += importeNoImpValue2
                        totalGrl += totalComprobanteValue
                End Select
        End Select

        txtImpProd.Text = Format(Fields!importeprod.Value, "N2")
        txtTotalIvaProd.Text = Format(Fields!ivaprod.Value, "N2")
        txtTotalPerIva.Text = Format(Fields!percepiva.Value, "N2")
        txtTotalPerGan.Text = Format(Fields!percepgan.Value, "N2")
        txtTotalPerIB.Text = Format(Fields!totalpercepib.Value, "N2")
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
        lblTitulo.Text = titulo
    End Sub

    Private Sub ReportFooter1_Format(sender As Object, e As EventArgs) Handles ReportFooter1.Format
        ' Actualizar el contenido del control de texto para el total general
        txtImpProd.Text = Format(Convert.ToDouble(totalImpProd), "#,##0.00")
        txtTotalIvaProd.Text = Format(Convert.ToDouble(totalIvaProd), "#,##0.00")
        txtTotalImpNI.Text = Format(Convert.ToDouble(totalImpNI), "#,##0.00")
        txtTotalGrl.Text = Format(Convert.ToDouble(totalGrl), "#,##0.00")
        txtTotalPerGan.Text = Format(Convert.ToDouble(totalPerGan), "#,##0.00")
        txtTotalPerIB.Text = Format(Convert.ToDouble(totalPerIB), "#,##0.00")
        txtTotalPerIva.Text = Format(Convert.ToDouble(totalPerIva), "#,##0.00")
    End Sub

    Private Sub GroupHeader1_Format(sender As Object, e As EventArgs) Handles GroupHeader1.Format
        txtFechaCarga.Text = Format(Fields!fechacarga.Value, "dd/MM/yyyy")
    End Sub
End Class
