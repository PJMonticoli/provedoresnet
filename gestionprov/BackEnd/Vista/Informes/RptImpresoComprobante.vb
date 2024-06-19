Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document
Imports GrapeCity.ActiveReports.Extensibility.Data
Imports System.Data
Imports System.Text

Public Class RptImpresoComprobante
    Public periodo As String
    Public flag As Boolean
    Dim totalImpProd As Double = 0
    Dim totalIvaProd As Double = 0
    Dim totalPerIva As Double = 0
    Dim totalPerGan As Double = 0
    Dim totalPerIB As Double = 0
    Dim totalImpNI As Double = 0
    Dim totalGrl As Double = 0
    Public titulo As String
    Dim tablaresumen As System.Data.DataTable
    Dim tipoInsumoTotales As New Dictionary(Of Integer, Double)
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


    'Resumen lado izquierdo
    Dim TotalCredIntGuma As Double
    Dim TotalDebIntGuma As Double
    Dim TotalCredNoIntGuma As Double
    Dim TotalDebNoIntNoGuma As Double

    'Resumen lado derecho
    Dim TotalCred As Double
    Dim TotalDeb As Double
    Dim TotalCredNoGuma As Double
    Dim TotalDebNoInt As Double

    'TOTALES DESPACHOS
    Dim TotalImpProdDesp As Double
    Dim TotalIvaProdDesp As Double
    Dim TotalPerIvaDesp As Double
    Dim TotalPerGanDesp As Double
    Dim TotalPerIBDesp As Double
    Dim TotalImpNIDesp As Double
    Dim TotalGrlDesp As Double
    Dim TOTALCDDESP As Double


    Dim F As Double
    Dim D As Double
    Dim c As Double
    Dim DE As Double
    Dim rowIndex As Integer
    Dim PruebaTotalPer As Double
    Private Sub RptImpresoComprobante_ReportStart(sender As Object, e As EventArgs) Handles MyBase.ReportStart

    End Sub

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
    End Sub

    Private Sub InicializarTablaResumen()
        tablaresumen = New System.Data.DataTable
        tablaresumen.Columns.Add("TipoInsumo", GetType(Integer))
        tablaresumen.Columns.Add("TotalCta", GetType(Double))
        tablaresumen.Columns.Add("NroProveedor", GetType(Double))
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

        Select Case Fields!TipoGrupo.Value
            Case 1, 2
                ' Facturas, Remitos
                totalip += Fields!ImporteProd.Value
                totalivap += Fields!IvaProd.Value
                totalpiva += Fields!PercepIva.Value
                totalpg += Fields!PercepGan.Value
                totalpib += Fields!TotalPercepIB.Value
                totalni += Fields!ImporteNoImp.Value
                TOTALGEN += Fields!TotalComprobante.Value
                TOTALCD += Fields!TotalComprobante.Value

            Case 3, 8, 6, 10 '9
                ' si es de guma
                Me.txtTotal.Text = Format(CDbl(Me.txtTotal.Text) * -1, "#,##0.00")
                Me.txtImpNI.Text = Format(CDbl(Me.txtImpNI.Text) * -1, "#,##0.00")
                Me.txtImpProd.Text = Format(CDbl(Me.txtImpProd.Text) * -1, "#,##0.00")
                Me.txtIvaProd.Text = Format(CDbl(Me.txtIvaProd.Text) * -1, "#,##0.00")
                Me.txtPerGan.Text = Format(CDbl(Me.txtPerGan.Text) * -1, "#,##0.00")
                Me.txtPerIB.Text = Format(CDbl(Me.txtPerIB.Text) * -1, "#,##0.00")
                Me.txtPerIVA.Text = Format(CDbl(Me.txtPerIVA.Text) * -1, "#,##0.00")

                If Fields!TipoGrupo.Value = 6 Or Fields!TipoGrupo.Value = 10 Then
                    If Fields!TipoGrupo.Value = 6 Then
                        TotalDeb -= Fields!TotalComprobante.Value
                        TotalDebIntGuma -= Fields!IvaProd.Value
                    Else
                        TotalDebNoInt -= Fields!TotalComprobante.Value
                        TotalDebNoIntNoGuma -= Fields!IvaProd.Value
                    End If
                End If

                totalip -= Fields!ImporteProd.Value
                totalivap -= Fields!IvaProd.Value
                totalpiva -= Fields!PercepIva.Value
                totalpg -= Fields!PercepGan.Value
                totalpib -= Fields!TotalPercepIB.Value
                totalni -= Fields!ImporteNoImp.Value
                TOTALGEN -= Fields!TotalComprobante.Value
                TOTALCD -= Fields!TotalComprobante.Value

            Case 5, 7, 4, 9 '10
                ' si es de guma
                If Fields!TipoGrupo.Value = 4 Or Fields!TipoGrupo.Value = 9 Then
                    If Fields!TipoGrupo.Value = 4 Then
                        TotalCred += Fields!TotalComprobante.Value
                        TotalCredIntGuma += Fields!IvaProd.Value
                    Else
                        TotalCredNoGuma += Fields!TotalComprobante.Value
                        TotalCredNoIntGuma += Fields!IvaProd.Value
                    End If
                End If

                totalip += Fields!ImporteProd.Value
                totalivap += Fields!IvaProd.Value
                totalpiva += Fields!PercepIva.Value
                totalpg += Fields!PercepGan.Value
                totalpib += Fields!TotalPercepIB.Value
                totalni += Fields!ImporteNoImp.Value
                TOTALGEN += Fields!TotalComprobante.Value
                TOTALCD += Fields!TotalComprobante.Value

            Case 11
                ' Despachos, poner en cero cuando este corregido el resto de los comprobantes.
                ' modificado el 07/10/2015
                ' totalip = totalip + fields!ImporteProd
                totalip += 0
                totalivap += Fields!IvaProd.Value
                totalpiva += Fields!PercepIva.Value
                totalpg += Fields!PercepGan.Value
                PruebaTotalPer += Fields!TotalPercepIB.Value
                totalpib += Fields!TotalPercepIB.Value
                totalni += Fields!ImporteNoImp.Value
                TOTALGEN += Fields!IvaProd.Value + Fields!ImporteNoImp.Value + Fields!ImporteProd.Value + Fields!PercepIva.Value + Fields!PercepGan.Value + Fields!TotalPercepIB.Value
                ' TOTALCD += Fields!TotalComprobante.Value

                TotalImpProdDesp += 0
                TotalIvaProdDesp += Fields!IvaProd.Value
                TotalPerIvaDesp += Fields!PercepIva.Value
                TotalPerGanDesp += Fields!PercepGan.Value
                TotalPerIBDesp += Fields!TotalPercepIB.Value
                TotalImpNIDesp += Fields!ImporteNoImp.Value
                TotalGrlDesp += Fields!IvaProd.Value + Fields!ImporteNoImp.Value + Fields!ImporteProd.Value + Fields!PercepIva.Value + Fields!PercepGan.Value + Fields!TotalPercepIB.Value
                TOTALCDDESP += Fields!TotalComprobante.Value

        End Select


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
        txtImpProd.Text = Format(Fields!importeprod.Value, "N2")
        txtTotalIvaProd.Text = Format(Fields!ivaprod.Value, "N2")
        txtTotalPerIva.Text = Format(Fields!percepiva.Value, "N2")
        txtTotalPerGan.Text = Format(Fields!percepgan.Value, "N2")
        txtTotalPerIB.Text = Format(Fields!totalpercepib.Value, "N2")
        txtTotalGrl.Text = Format(Fields!importenoimp.Value, "N2")
    End Sub

    Private Sub AcumularTipoInsumoActual()
        Dim tipoInsumoActual As Integer = Convert.ToInt32(Fields!TipoInsumo.Value)

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
                    tipoInsumoTotales(tipoInsumoActual) = Convert.ToDouble(Fields!TotalComprobante.Value)
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
        tablaresumen.Rows(rowIndex)(columnName) = Fields!TipoInsumo.Value
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


        'TOTALES
        txtImpProd.Text = Format(totalip, "#,##0.00")
        txtTotalIvaProd.Text = Format(totalivap, "#,##0.00")
        txtTotalPerIva.Text = Format(totalpiva, "#,##0.00")
        txtTotalPerGan.Text = Format(totalpg, "#,##0.00")
        txtTotalPerIB.Text = Format(totalpib, "#,##0.00")
        txtTotalImpNI.Text = Format(totalni, "#,##0.00")
        txtTotalGrl.Text = Format(TOTALGEN, "#,##0.00")

        'Resumen lado izquierdo
        txtTotalCredIntGuma.Text = Format(TotalCredIntGuma, "#,##0.00")
        txtTotalDebIntGuma.Text = Format(TotalDebIntGuma, "#,##0.00")
        txtTotalCredNoIntGuma.Text = Format(TotalCredNoIntGuma, "#,##0.00")
        txtTotalDebNoIntNoGuma.Text = Format(TotalDebNoIntNoGuma, "#,##0.00")

        'Resumen lado derecho
        txtTotalCred.Text = Format(TotalCred, "#,##0.00")
        txtTotalDeb.Text = Format(TotalDeb, "#,##0.00")
        txtTotalCredNoGuma.Text = Format(TotalCredNoGuma, "#,##0.00")
        txtTotalDebNoInt.Text = Format(TotalDebNoInt, "#,##0.00")
        txtTotalCD.Text = Format(TOTALCD, "#,##0.00")


        'TOTALES Despachos
        txtImpProdDesp.Text = Format(TotalImpProdDesp, "#,##0.00")
        txtTotalIvaProdDesp.Text = Format(TotalIvaProdDesp, "#,##0.00")
        txtTotalPerIvaDesp.Text = Format(TotalPerIvaDesp, "#,##0.00")
        txtTotalPerGanDesp.Text = Format(TotalPerGanDesp, "#,##0.00")
        txtTotalPerIBDesp.Text = Format(TotalPerIBDesp, "#,##0.00")
        txtTotalImpNIDesp.Text = Format(TotalImpNIDesp, "#,##0.00")
        txtTotalGrlDesp.Text = Format(TotalGrlDesp, "#,##0.00")

        ActualizarTxtTotalPorCta()
    End Sub

    Private Sub GroupHeader1_Format(sender As Object, e As EventArgs) Handles GroupHeader1.Format
        txtFechaCarga.Text = Format(Fields!fechacarga.Value, "dd/MM/yyyy")
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


End Class
