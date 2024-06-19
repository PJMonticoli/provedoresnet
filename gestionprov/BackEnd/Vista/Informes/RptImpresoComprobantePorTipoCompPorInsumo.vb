Imports System.Globalization
Imports System.Text
Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class RptImpresoComprobantePorTipoCompPorInsumo
    Public titulo As String
    Public periodo As String
    Dim totalImpProd As Double = 0
    Dim totalIvaProd As Double = 0
    Dim totalPerIva As Double = 0
    Dim totalPerGan As Double = 0
    Dim totalPerIB As Double = 0
    Dim totalImpNI As Double = 0
    Dim totalGrl As Double = 0
    Dim cultureAR As New CultureInfo("es-AR")

    ' Nuevas variables agregadas
    Dim totalip As Double
    Dim totalivap As Double
    Dim totalpiva As Double
    Dim totalpg As Double
    Dim totalpib As Double
    Dim totalni As Double
    Dim TOTALGEN As Double
    Dim TOTALCD As Double
    Dim TOTALCDINTIVA As Double

    Dim tablaresumen As System.Data.DataTable ' contiene detalle de los proveedor  tipoinsumo,acumuladortotal, nroprov
    Dim tipoInsumoTotales As New Dictionary(Of Integer, Double)
    Dim F As Double
    Dim D As Double
    Dim c As Double
    Dim DE As Double
    Dim rowIndex As Integer
    Dim GrupoTOTALGEN As Double
    Public Sub New()
        InitializeComponent()
        InicializarTablaResumen()
        InicializarVariables()
    End Sub
    Private Sub InicializarVariables()
        TOTALGEN = 0
        F = 0
        D = 0
        c = 0
        DE = 0
        GrupoTOTALGEN = 0
    End Sub

    Private Sub InicializarTablaResumen()
        tablaresumen = New System.Data.DataTable
        tablaresumen.Columns.Add("TipoInsumo", GetType(Integer))
        tablaresumen.Columns.Add("TotalCta", GetType(Double))
        tablaresumen.Columns.Add("NroProveedor", GetType(Double))
    End Sub

    Private Sub ReportHeader1_Format(sender As Object, e As EventArgs) Handles ReportHeader1.Format
        lblDireccion.Text = "Lote 1 G - Malabrigo  Tel.03525-42065 - Fax 03525-421312" & Chr(13) &
          "CP 5223 - Colonia Caroya - Pcia. de Córdoba" & Chr(13) &
          "E-mail: info@joseguma.com - Site: www.joseguma.com"
        lblFecha.Text = periodo
    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        Dim oTotal As String
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

        Select Case Fields!TipoGrupo.Value
            Case 1, 2
                'Facturas, Remitos
                totalip = totalip + Fields!ImporteProd.Value
                totalivap = totalivap + Fields!IvaProd.Value
                totalpiva = totalpiva + Fields!PercepIva.Value
                totalpg = totalpg + Fields!PercepGan.Value
                totalpib = totalpib + Fields!TotalPercepIB.Value
                TOTALGEN = TOTALGEN + Fields!TotalComprobante.Value
                totalni = totalni + Fields!ImporteNoImp.Value
                GrupoTOTALGEN = GrupoTOTALGEN + Fields!TotalComprobante.Value

        'Creditos
            Case 3, 6, 8, 10
                ''si es de guma
                txtTotal.Text = CDbl(txtTotal.Text) * -1
                txtImpNI.Text = CDbl(txtImpNI.Text) * -1
                totalip = totalip - Fields!ImporteProd.Value
                totalivap = totalivap - Fields!IvaProd.Value
                totalpiva = totalpiva - Fields!PercepIva.Value
                totalpg = totalpg - Fields!PercepGan.Value
                totalpib = totalpib - Fields!TotalPercepIB.Value
                totalni = totalni - Fields!ImporteNoImp.Value
                TOTALGEN = TOTALGEN - Fields!TotalComprobante.Value
                GrupoTOTALGEN = GrupoTOTALGEN - Fields!TotalComprobante.Value
                txtTotal.Text = Fields!TotalComprobante.Value

         'Debitos
            Case 4, 5, 7, 9, 11
                totalip = totalip + Fields!ImporteProd.Value
                totalivap = totalivap + Fields!IvaProd.Value
                totalpiva = totalpiva + Fields!PercepIva.Value
                totalpg = totalpg + Fields!PercepGan.Value
                totalpib = totalpib + Fields!TotalPercepIB.Value
                totalni = totalni + Fields!ImporteNoImp.Value
                TOTALGEN = TOTALGEN + Fields!TotalComprobante.Value
                txtTotal.Text = Fields!TotalComprobante.Value
                GrupoTOTALGEN = GrupoTOTALGEN + Fields!TotalComprobante.Value


        End Select

        txtFechaComp.Text = Format(Fields!fechacomp.Value, "dd/MM/yyyy")
        txtFechaVto.Text = Format(Fields!fechavto.Value, "dd/MM/yyyy")
        txtImpNI.Text = Format(CDbl(txtImpNI.Text), "N2")
        txtTotal.Text = Format(CDbl(txtTotal.Text), "N2")
        AcumularTipoInsumoActual()
        rowIndex = ObtenerRowIndexEnTablaResumen()

        If rowIndex = -1 Then
            Dim nuevaFila As System.Data.DataRow = tablaresumen.NewRow()
            nuevaFila("NroProveedor") = Convert.ToInt32(Fields!NroProveedor.Value)
            nuevaFila("TotalCta") = 0
            nuevaFila("TipoInsumo") = 0
            tablaresumen.Rows.Add(nuevaFila)
            rowIndex = tablaresumen.Rows.Count - 1
        End If

        ActualizarTotalCtaSegunTipoGrupo(rowIndex)
    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format
        lblPie.Text = "Impreso el " & Date.Today.ToString("dd MMM yyyy")
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

        'TOTALES
        txtImpProd.Text = Format(totalip, "#,##0.00")
        txtTotalIvaProd.Text = Format(totalivap, "#,##0.00")
        txtTotalPerIva.Text = Format(totalpiva, "#,##0.00")
        txtTotalPerGan.Text = Format(totalpg, "#,##0.00")
        txtTotalPerIB.Text = Format(totalpib, "#,##0.00")
        txtTotalImpNI.Text = Format(totalni, "#,##0.00")
        txtTotalGrl.Text = Format(TOTALGEN, "#,##0.00")
        ActualizarTxtTotalPorCta()
    End Sub


    Private Sub AcumularTipoInsumoActual()
        Dim tipoInsumoActual As Integer = Convert.ToInt32(Fields!Tipoinsumo.Value)

        If tipoInsumoTotales.ContainsKey(tipoInsumoActual) Then
            Select Case Fields!TipoGrupo.Value
                Case 3, 8, 6, 10

                    tipoInsumoTotales(tipoInsumoActual) -= Convert.ToDouble(Fields!TotalComprobante.Value)

                Case Else
                    tipoInsumoTotales(tipoInsumoActual) += Convert.ToDouble(Fields!TotalComprobante.Value)

            End Select
        Else
            Select Case Fields!TipoGrupo.Value
                Case 3, 8, 6, 10

                    tipoInsumoTotales(tipoInsumoActual) = (Convert.ToDouble(Fields!TotalComprobante.Value)) * -1

                Case Else

                    tipoInsumoTotales(tipoInsumoActual) = (Convert.ToDouble(Fields!TotalComprobante.Value))

            End Select
        End If
    End Sub
    Private Function ObtenerRowIndexEnTablaResumen() As Integer
        Dim rowIndex As Integer = -1
        For i As Integer = 0 To tablaresumen.Rows.Count - 1
            If Convert.ToInt32(tablaresumen.Rows(i)("NroProveedor")) = Convert.ToInt32(Fields!NroProveedor.Value) Then
                rowIndex = i
                Exit For
            End If
        Next
        Return rowIndex
    End Function

    Private Sub ActualizarTotalCtaSegunTipoGrupo(rowIndex As Integer)
        Dim totalComprobante As Double = Convert.ToDouble(Fields!TotalComprobante.Value)

        Select Case Convert.ToInt32(Fields!TipoGrupo.Value)
            Case 1, 2
                ' Facturas, Remitos
                ActualizarTotales("TipoInsumo", F, totalComprobante)
            Case 5, 7, 4, 9
                ' Débitos
                ActualizarTotales("TipoInsumo", D, totalComprobante)
            Case 3, 8, 6, 10
                ' Créditos
                ActualizarTotales("TipoInsumo", c, -totalComprobante)
            Case 11
                ' Caso 11
                Dim totalActualizar As Double = Convert.ToDouble(Fields!IvaProd.Value) + Convert.ToDouble(Fields!ImporteProd.Value) +
                                     Convert.ToDouble(Fields!PercepIva.Value) + Convert.ToDouble(Fields!PercepGan.Value) +
                                     Convert.ToDouble(Fields!TotalPercepIB.Value) + Convert.ToDouble(Fields!ImporteNoImp.Value)
                ActualizarTotales("TipoInsumo", DE, totalActualizar)
        End Select
    End Sub
    Private Sub ActualizarTotales(columnName As String, ByRef totalVariable As Double, totalComprobante As Double)
        tablaresumen.Rows(rowIndex)(columnName) = Fields!Tipoinsumo.Value
        If Not DBNull.Value.Equals(tablaresumen.Rows(rowIndex)("TotalCta")) Then
            tablaresumen.Rows(rowIndex)("TotalCta") += totalComprobante
            totalVariable += totalComprobante
        End If
    End Sub


    Private Sub ActualizarTxtTotalPorCta()
        Dim DescCta As String = ""

        ' Ordenar el diccionario por CodTipoInsumosProveedor (tipoInsumoTotales)
        Dim tipoInsumoTotalesOrdenados = From entry In tipoInsumoTotales
                                         Order By entry.Key
                                         Select entry

        ' Crear un StringBuilder para construir el texto con formato
        Dim sb As New StringBuilder()

        ' Asegurarse de que el TextBox use una fuente monoespaciada
        txtTotalporCta.Font = New Font("Courier New", 8, FontStyle.Bold)

        For Each tipoInsumoTotal In tipoInsumoTotalesOrdenados
            Dim codctaprov As Integer = tipoInsumoTotal.Key
            Dim totalcta As Double = tipoInsumoTotal.Value
            DescCta = GetDescripcionCta(codctaprov)

            If totalcta <> 0 Then
                ' Construir la línea con formato y agregarla al StringBuilder
                sb.AppendLine($"{Format(codctaprov, "00")} - {Left(DescCta, 30)}  $ {Format(totalcta, "#,##0.00").PadLeft(17)}  [{Format(((totalcta * 100) / TOTALGEN), "00.00")}%]")
            End If
        Next

        ' Añadir la línea para el "TOTAL GRAL."
        DescCta = "TOTAL GRAL." & Space(25)
        sb.AppendLine($"{Left(DescCta, 30)}       $ {Format(TOTALGEN, "#,##0.00").PadLeft(17)}")

        ' Establecer el texto completo en el TextBox
        txtTotalporCta.Text = sb.ToString()
    End Sub

    Private Function GetDescripcionCta(codctaprov As Integer) As String
        Select Case codctaprov
            Case 1
                Return "SEBOS" & Space(25)
            Case 2
                Return "ACEITES" & Space(25)
            Case 3
                Return "SODA CAÚSTICA" & Space(25)
            Case 4
                Return "FRAGANCIAS" & Space(25)
            Case 5
                Return "ADITIVOS QUÍMICOS" & Space(25)
            Case 6
                Return "L.A.S." & Space(25)
            Case 7
                Return "ENERGÍA Y COMBUSTIBLE" & Space(25)
            Case 8
                Return "ENVASES CORRUGADOS" & Space(25)
            Case 9
                Return "ENVOLTORIOS" & Space(25)
            Case 10
                Return "ENVASES PLÁSTICOS Y TAMB." & Space(25)
            Case 11
                Return "GASTOS DE PRODUCCIÓN" & Space(25)
            Case 12
                Return "GTS. REPARACIÓN PLANTA" & Space(25)
            Case 13
                Return "INVERSIONES" & Space(25)
            Case 14
                Return "GASTOS ADMINISTRATIVOS" & Space(25)
            Case 15
                Return "TELEF. INTERNET Y CORREO" & Space(25)
            Case 16
                Return "SEGUROS" & Space(25)
            Case 17
                Return "SERVICIOS EVENTUALES" & Space(25)
            Case 18
                Return "GASTOS PERSONAL" & Space(25)
            Case 19
                Return "ASESORES Y REP. EMPRESAR." & Space(25)
            Case 20
                Return "PUBLICIDAD Y PROMOCIONES" & Space(25)
            Case 21
                Return "FLETES" & Space(25)
            Case 22
                Return "COMISIONES" & Space(25)
            Case 23
                Return "GASTOS RODADOS" & Space(25)
            Case 24
                Return "GTS. COMERCIO EXTERIOR" & Space(25)
            Case 99
                Return "OTROS" & Space(25)
        End Select
    End Function

    Private Sub GroupFooter1_Format(sender As Object, e As EventArgs) Handles GroupFooter1.Format
        txtSubTotalInsumo.Text = Format(GrupoTOTALGEN, "N2")
        GrupoTOTALGEN = 0
    End Sub
End Class
