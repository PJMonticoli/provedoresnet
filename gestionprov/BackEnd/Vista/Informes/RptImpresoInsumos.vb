Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class RptImpresoInsumos
    Public periodo As String
    Dim totalGeneral As Double = 0
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
            txtCantidad.Text = Format(Fields!cantidad.Value, "N2")
            txtPrecio.Text = Format(Fields!precio.Value, "N2")
            txtTotal.Text = Format(Fields!total.Value, "N2")
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




            If Fields!TipoGrupo.Value = 3 Or Fields!TipoGrupo.Value = 6 Or Fields!TipoGrupo.Value = 8 Or Fields!TipoGrupo.Value = 10 Then
                ' Restar al total general
                totalGeneral -= Fields!TOTALNUEVO.Value
            ElseIf Fields!TipoGrupo.Value = 11 Then
                ' Sumar al total general solo si el TipoGrupo es 11
                totalGeneral += Fields!TOTALNUEVO.Value
            Else
                ' Si es cualquier otro TipoGrupo, sumar al total general
                If Not IsDBNull(Fields!TOTALNUEVO.Value) Then
                    totalGeneral += Fields!TOTALNUEVO.Value
                End If
            End If

            ' Mostrar el valor formateado en el control de texto
            txtTotal.Text = Format(IIf(Fields!TipoGrupo.Value = 3 Or Fields!TipoGrupo.Value = 6 Or Fields!TipoGrupo.Value = 8 Or Fields!TipoGrupo.Value = 10, -1 * Fields!TOTALNUEVO.Value, Fields!TOTALNUEVO.Value), "#,##0.00")





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
        Catch ex As Exception
            ' Manejar excepciones si es necesario
            MsgBox("Error al obtener datos de ado_dc. " & ex.ToString)
        End Try

    End Sub


    Private Sub GroupHeader1_Format(sender As Object, e As EventArgs) Handles GroupHeader1.Format
        txtCodInsumo.Text = Mid(txtCodInsumo.Text, 1, 1) & "." & Mid(txtCodInsumo.Text, 2, 2) & "." & Mid(txtCodInsumo.Text, 4, 3) & "." & Mid(txtCodInsumo.Text, 7, 3) & "." & Mid(txtCodInsumo.Text, 10, 4)
    End Sub

    Private Sub ReportFooter1_Format(sender As Object, e As EventArgs) Handles ReportFooter1.Format
        ' Actualizar el contenido del control de texto para el total general
        txtTotalGeneral.Text = totalGeneral.ToString("#,##0.00")

    End Sub
End Class
