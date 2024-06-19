Imports System.Globalization
Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class RptImpresoComprobantePendiente
    Dim totalrem As Double = 0
    Dim totalgrupo As Double = 0
    Dim total As Double = 0
    Dim totalSaldoGral As Double = 0
    Dim AcumProdImporte As Double = 0
    Dim AcumTotalImporte As Double = 0
    Dim TotalCompProv As Double = 0
    Dim TotalCompNoAutorizados As Double = 0
    Public tabla As DataTable
    Dim cultureAR As New CultureInfo("es-AR")
    Dim i As Integer

    Private Sub ReportHeader1_Format(sender As Object, e As EventArgs) Handles ReportHeader1.Format
        lblDireccion.Text = "Lote 1 G - Malabrigo  Tel.03525-42065 - Fax 03525-421312" & Chr(13) &
          "CP 5223 - Colonia Caroya - Pcia. de Córdoba" & Chr(13) &
          "E-mail: info@joseguma.com - Site: www.joseguma.com"
    End Sub
    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        txtFechaComp.Text = Format(Fields!fechacomp.Value, "dd/MM/yyyy")
        txtFechaVto.Text = Format(Fields!fechavto.Value, "dd/MM/yyyy")
        Select Case Fields!DescComp.Value
            Case 1

                If Validarautorizado(Fields!nrointerno.Value) = 1 Then
                    'No autorizado
                    TotalCompNoAutorizados = TotalCompNoAutorizados + (Fields!TotalComprobante.Value - Fields!pagado.Value)
                    txtSaldo.Text = Format(((Fields!TotalComprobante.Value - Fields!pagado.Value) * -1), "#,##0.00")
                    Detail.BackColor = Color.FromArgb(192, 255, 255)
                Else
                    ' Autorizado 
                    If Fields!codestadopago.Value = 3 Then
                        If Fields!EsAduana.Value = 1 Then
                            txtComprobante.Text = "F-" & Fields!NroFactura.Value
                        End If
                        txtSaldo.Text = Format(((Fields!pagado.Value) * -1), "#,##0.00")
                        Detail.BackColor = Color.FromArgb(100, 220, 100)
                    Else
                        If Fields!EsAduana.Value = 1 Then
                            txtComprobante.Text = "F-" & Fields!NroFactura.Value
                        End If
                        ActualizarTotalesPos()
                        Detail.BackColor = Color.FromArgb(&HFFFFFF)
                    End If
                End If
            Case 2

                'txtComprobante.Text = "R-" & Format(Fields!nrosucursal.Value, "0000") & "-" & Format(Fields!NroFactura.Value, "00000000")
                AcumTotalImporte += Convert.ToDecimal(Fields!TotalComprobante.Value)
                TotalCompProv += Convert.ToDecimal(Fields!TotalComprobante.Value)
                totalgrupo += Convert.ToDecimal(Fields!TotalComprobante.Value - Fields!pagado.Value)
                txtSaldo.Text = Format((Convert.ToDecimal(Fields!TotalComprobante.Value - Fields!pagado.Value)) * -1, "#,##0.00")
                AcumProdImporte = AcumProdImporte + (Fields!TotalComprobante.Value * Math.Abs(DateDiff("d", Fields!FechaVto.Value, Date.Now)))
                totalrem += Convert.ToDecimal(Fields!TotalComprobante.Value)
                Detail.BackColor = Color.FromArgb(255, 255, 255)
            Case 3, 4, 5, 6, 13, 14, 17, 19, 21
                If Fields!codestadopago.Value <> 3 Then
                    If Validarautorizado(Fields!nrointerno.Value = 1) Then
                        'no autorizado
                        If Not IsDBNull(Fields!nroCompAlfanumerico.Value) Then
                            txtComprobante.Text = "F-" & Fields!nrocompAlfanumerico.Value

                        End If
                        TotalCompNoAutorizados = TotalCompNoAutorizados + (Fields!TotalComprobante.Value - Fields!pagado.Value)
                        Detail.BackColor = Color.FromArgb(15, 255, 252)
                    Else
                        'autorizado
                        If Fields!EsAduana.Value = 1 Then
                            txtComprobante.Text = "D-" & Fields!NroFactura.Value
                        End If
                        If (Left(Fields!NroComp.Value, 4) = 4000 And Fields!TipoGrupo.Value = 6) Or (Left(Fields!NroComp.Value, 4) = 9041 And Fields!TipoGrupo.Value = 6) Or (Left(Fields!NroComp.Value, 4) = 9042 And Fields!TipoGrupo.Value = 6) Or (Left(Fields!NroComp.Value, 4) = 9997 And Fields!TipoGrupo.Value = 10) Or (Left(Fields!NroComp.Value, 4) = 6021 And Fields!TipoGrupo.Value = 6) Or (Left(Fields!NroComp.Value, 4) = 6022 And Fields!TipoGrupo.Value = 6) Then
                            ActualizarTotalesNeg()
                        Else
                            ActualizarTotalesPos()
                        End If
                    End If

                Else
                    If Fields!EsAduana.Value = 1 Then
                        txtComprobante.Text = "D-" & Fields!NroFactura.Value
                    End If


                    If (Left(Fields!NroComp.Value, 4) = 4000 And Fields!TipoGrupo.Value = 6) Or (Left(Fields!NroComp.Value, 4) = 9041 And Fields!TipoGrupo.Value = 6) Or (Left(Fields!NroComp.Value, 4) = 9042 And Fields!TipoGrupo.Value = 6) Or (Left(Fields!NroComp.Value, 4) = 9997 And Fields!TipoGrupo.Value = 10) Then
                        txtSaldo.Text = Format(((Fields!TotalComprobante.Value * -1) * -1), "#,##0.00")
                    Else
                        txtSaldo.Text = Format(((Fields!TotalComprobante.Value) * -1), "#,##0.00")
                    End If
                End If
                If Fields!codestadopago.Value = 3 Then
                    Detail.BackColor = Color.FromArgb(&HC000)
                Else
                    Detail.BackColor = Color.FromArgb(255, 255, 255)
                End If

            Case 7, 8, 9, 10, 11, 12, 18, 20, 22
                If Fields!EsAduana.Value = 1 Then
                    txtComprobante.Text = "C-" & Fields!NroFactura.Value.ToString()
                End If

                If Fields!codestadopago.Value = 3 Then
                    txtSaldo.Text = Format((Fields!TotalComprobante.Value - Fields!pagado.Value) * -1, "#,##0.00")
                    txtSaldo.Text = Format(((Fields!TotalComprobante.Value - Fields!pagado.Value)), "#,##0.00")
                Else
                    If Fields!EsAduana.Value = 1 Then
                        txtComprobante.Text = "C-" & Fields!NroFactura.Value.ToString()

                    End If
                    If (Left(Fields!NroComp.Value, 4) = 4000 And Fields!TipoGrupo.Value = 4) Or (Left(Fields!NroComp.Value, 4) = 9041 And Fields!TipoGrupo.Value = 4) Or (Left(Fields!NroComp.Value, 4) = 9042 And Fields!TipoGrupo.Value = 4) Or (Left(Fields!NroComp.Value, 4) = 9997 And Fields!TipoGrupo.Value = 9) Or (Left(Fields!NroComp.Value, 4) = 6021 And Fields!TipoGrupo.Value = 4) Or (Left(Fields!NroComp.Value, 4) = 6022 And Fields!TipoGrupo.Value = 4) Then
                        ActualizarTotalesPos()
                    Else
                        ActualizarTotalesNeg()
                    End If
                End If
                If Fields!codestadopago.Value = 3 Then
                    Detail.BackColor = Color.FromArgb(0, 255, 255)
                Else
                    Detail.BackColor = Color.FromArgb(255, 255, 255)
                End If
            Case 15
                If Fields!EsAduana.Value = 1 Then
                    txtComprobante.Text = "AOP-" & Fields!NroFactura.Value
                End If
                If Fields!codestadopago.Value = 3 Then
                    txtSaldo.Text = Format(((Fields!TotalComprobante - (Fields!pagado.Value))) * -1, "#,##0.00")
                    txtSaldo.Text = Format((-1 * (Fields!TotalComprobante.Value - (Fields!pagado.Value))) * -1, "#,##0.00")
                Else
                    ActualizarTotalesPos()
                End If
            Case 16
                If Fields!EsAduana.Value = 1 Then
                    'txtComprobante.Text = "OPA-" & Fields!NroFactura.Value
                End If
                If Fields!codestadopago.Value = 3 Then
                    'esta todo pagado
                    txtSaldo.Text = Format(((Fields!TotalComprobante.Value * -1) * -1), "#,##0.00")
                Else
                    ActualizarTotalesNeg()
                End If
            Case 23
                'If Fields!EsAduana=1 Then
                If Not (Fields!nroCompAlfanumerico.Value Is Nothing) Then
                    txtComprobante.Text = "De-" & Fields!nroCompAlfanumerico.Value
                End If
                If Fields!codestadopago.Value = 3 Then
                    txtSaldo.Text = Format(((Fields!TotalComprobante.Value - (Fields!pagado.Value))) * -1, "#,##0.00")
                    txtSaldo.Text = Format((-1 * (Fields!TotalComprobante.Value - (Fields!pagado.Value))) * -1, "#,##0.00")
                Else
                    ActualizarTotalesPos()
                End If
            Case 24
                'If Fields!EsAduana=1 Then
                If Not (Fields!nroCompAlfanumerico.Value Is Nothing) Then
                    txtComprobante.Text = "De-" & Fields!nroCompAlfanumerico.Value
                End If
                If Fields!codestadopago.Value = 3 Then
                    txtSaldo.Text = Format(((Fields!TotalComprobante.Value - (Fields!pagado.Value))) * -1, "#,##0.00")
                    txtSaldo.Text = Format((-1 * (Fields!TotalComprobante.Value - (Fields!pagado.Value))) * -1, "#,##0.00")
                Else
                    ActualizarTotalesPos()
                End If
        End Select
        Select Case txtComprobante.Text
            Case 1
                txtComprobante.Text = "F-"
            Case 2
                txtComprobante.Text = "R-"
            Case 3, 4, 5, 6, 13, 14, 17, 19, 21
                txtComprobante.Text = "D-"
            Case 7, 8, 9, 10, 11, 12, 18, 20, 22
                txtComprobante.Text = "C-"
            Case 15
                txtComprobante.Text = "AOP-"
            Case 16
                txtComprobante.Text = "OPA-"
            Case 23
                txtComprobante.Text = "DE-"
            Case 24
                txtComprobante.Text = "DE-"
        End Select
        txtDescPago.Text = Fields!descripcion.Value
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

    End Sub

    Private Sub GroupFooter1_Format(sender As Object, e As EventArgs) Handles GroupFooter1.Format
        txtTotales.Text = String.Format(cultureAR, "{0:C}", totalgrupo * -1)
        totalgrupo = 0
        AcumProdImporte = 0
        AcumTotalImporte = 0
    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format
        lblPie.Text = "Impreso el " & Date.Today.ToString("dd MMM yyyy")
    End Sub

    Private Sub GroupHeader1_Format(sender As Object, e As EventArgs) Handles GroupHeader1.Format
        txtProveedor.Text = Fields!Proveedor.Value & "  -   " & Trim(Fields!RSocial.Value)
    End Sub

    Private Sub ReportFooter1_Format(sender As Object, e As EventArgs) Handles ReportFooter1.Format
        txtTotal.Text = String.Format(cultureAR, "{0:C}", (total) * -1)
        txtTotalRemitos.Text = String.Format(cultureAR, "{0:C}", (totalrem) * -1)
        txtTotalNoAutorizado.Text = String.Format(cultureAR, "{0:C}", (TotalCompNoAutorizados) * -1)
        txtTotalSaldo.Text = String.Format(cultureAR, "{0:C}", (total + totalrem + TotalCompNoAutorizados) * -1)
    End Sub
    Private Function Validarautorizado(nrointerno) As Integer
        Dim procesado As Boolean
        If tabla IsNot Nothing AndAlso tabla.Rows.Count > 0 Then
            For Each row As DataRow In tabla.Rows
                If Convert.ToInt32(row("NroInterno")) = Fields!nrointerno.Value Then
                    procesado = True
                    Exit For
                Else
                    procesado = False
                End If
            Next
        Else
            procesado = False
        End If
        If procesado Then
            Return 1
        Else
            Return 0
        End If
    End Function
    Private Sub ActualizarTotalesPos()
        total = total + (Fields!TotalComprobante.Value - Fields!pagado.Value)
        AcumTotalImporte = AcumTotalImporte + (Fields!TotalComprobante.Value)
        TotalCompProv = TotalCompProv + (Fields!TotalComprobante.Value)
        totalgrupo = totalgrupo + (Fields!TotalComprobante.Value - Fields!pagado.Value)
        txtSaldo.Text = Format(((Fields!TotalComprobante.Value - Fields!pagado.Value)) * -1, "#,##0.00")
        AcumProdImporte = AcumProdImporte + (Fields!TotalComprobante.Value * Math.Abs(DateDiff("d", Fields!FechaVto.Value, Date.Now)))
        totalSaldoGral = totalSaldoGral + (Fields!TotalComprobante.Value - Fields!pagado.Value)
    End Sub

    Private Sub ActualizarTotalesNeg()
        total -= (Fields!TotalComprobante.Value - (Fields!pagado.Value))
        AcumTotalImporte = AcumTotalImporte - (Fields!TotalComprobante.Value)
        totalgrupo = totalgrupo - (Fields!TotalComprobante.Value - (Fields!pagado.Value))
        txtSaldo.Text = Format((Fields!TotalComprobante.Value - Fields!pagado.Value), "#,##0.00")
        AcumProdImporte = AcumProdImporte - (Fields!TotalComprobante.Value * Math.Abs(DateDiff("d", Fields!FechaVto.Value, Date.Now)))
        totalSaldoGral = totalSaldoGral - (Fields!TotalComprobante.Value - (Fields!pagado.Value))
    End Sub

    Private Sub GroupFooter2_Format(sender As Object, e As EventArgs)

    End Sub
End Class
