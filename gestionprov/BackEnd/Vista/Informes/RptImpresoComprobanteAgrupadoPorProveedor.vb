Imports System.Globalization
Imports System.Text
Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class RptImpresoComprobanteAgrupadoPorProveedor
    Public periodo As String
    Public flag As Boolean
    Public titulo As String
    Dim cultureAR As New CultureInfo("es-AR")
    Dim totalprov As Double
    Private Sub RptImpresoComprobante_ReportStart(sender As Object, e As EventArgs) Handles MyBase.ReportStart

    End Sub

    Public Sub New()
        InitializeComponent()
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
        ' Formatear las fechas y asignarlas a los controles de texto
        txtFechaComp.Text = Format(Fields!fechacomp.Value, "dd/MM/yyyy")
        txtFechaVto.Text = Format(Fields!fechavto.Value, "dd/MM/yyyy")
        Select Case Fields!TipoGrupo.Value
            Case 1, 2
                'Facturas, Remitos

                totalprov += Fields!TotalComprobante.Value
         'Debitos
            Case 5, 7, 4, 9

                totalprov += Fields!TotalComprobante.Value
         'Creditos
            Case 3, 8, 6, 10

                totalprov -= Fields!TotalComprobante.Value
            Case 11

                totalprov = totalprov + Fields!IvaProd.Value + Fields!ImporteProd.Value + Fields!PercepIva.Value + Fields!PercepGan.Value + Fields!TotalPercepIB.Value + Fields!ImporteNoImp.Value
        End Select

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

    Private Sub GroupFooter1_Format(sender As Object, e As EventArgs) Handles GroupFooter1.Format
        txtTotalGeneral.Text = String.Format(cultureAR, "{0:C}", totalprov)
        totalprov = 0
    End Sub
End Class
