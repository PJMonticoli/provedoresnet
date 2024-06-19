Imports System.Globalization
Imports System.Text
Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class RptImpresoComprobantePendienteAgrupado
    Dim totalrem As Double = 0
    Dim totalgrupo As Double = 0
    Dim total As Double = 0
    Dim totalSaldoGral As Double = 0
    Dim AcumProdImporte As Double = 0
    Dim AcumTotalImporte As Double = 0
    Dim TotalCompProv As Double = 0
    Dim TotalCompNoAutorizados As Double = 0
    Public tabla As New DataTable
    Dim tablaresumen As DataTable
    Dim cultureAR As New CultureInfo("es-AR")
    Dim i As Integer
    Dim acumInsumos As Double
    Dim tipoInsumoTotales As New Dictionary(Of String, Double)
    Dim rowIndex As Integer
    Dim F As Double
    Dim D As Double
    Dim c As Double
    Dim DE As Double
    Private Sub ReportHeader1_Format(sender As Object, e As EventArgs) Handles ReportHeader1.Format
        lblDireccion.Text = "Lote 1 G - Malabrigo  Tel.03525-42065 - Fax 03525-421312" & Chr(13) &
          "CP 5223 - Colonia Caroya - Pcia. de Córdoba" & Chr(13) &
          "E-mail: info@joseguma.com - Site: www.joseguma.com"
    End Sub
    Sub New()

        Try
            ' Esta llamada es exigida por el diseñador.
            InitializeComponent()
            InicializarTablaResumen()
            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Catch ex As Exception
            ' Manejar la excepción e imprimir detalles adicionales
            Console.WriteLine("Error al inicializar el informe: " & ex.Message)
            Console.WriteLine("StackTrace: " & ex.StackTrace)
            ' Puedes agregar más información según sea necesario
        End Try

    End Sub


    Private Sub InicializarTablaResumen()
        tablaresumen = New System.Data.DataTable
        'tabladetalle.Columns.Add("Descripcion", GetType(String))
        'tabladetalle.Columns.Add("Total", GetType(Double))
        tablaresumen.Columns.Add("TipoInsumo", GetType(Integer))
        tablaresumen.Columns.Add("TotalCta", GetType(Double))
        tablaresumen.Columns.Add("NroProveedor", GetType(Double))
    End Sub
    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        Dim pagado As Double
        Dim SaldoPendientePago As Double

        txtFechaComp.Text = Format(Fields!fechacomp.Value, "dd/MM/yyyy")
        txtFechaVto.Text = Format(Fields!fechavto.Value, "dd/MM/yyyy")
        Select Case Fields!DescComp.Value
            Case 1

                If IsDBNull(Fields!pagado.Value) Then
                    pagado = 0
                Else
                    pagado = Fields!pagado.Value
                End If
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
                        txtSaldo.Text = Format(((Fields!totalcomprobante.Value) - (Fields!pagado.Value) * -1), "#,##0.00")
                        SaldoPendientePago = (pagado) * -1
                        Detail.BackColor = Color.FromArgb(0, 255, 255)
                    Else
                        If Fields!EsAduana.Value = 1 Then
                            txtComprobante.Text = "F-" & Fields!NroFactura.Value
                        End If
                        ActualizarTotalesPos()
                        Detail.BackColor = Color.FromArgb(255, 255, 255)
                        txtComprobante.BackColor = Color.FromArgb(255, 255, 255)
                    End If
                End If

                acumInsumos += If(Double.TryParse(txtSaldo.Text, Nothing), CDbl(txtSaldo.Text), 0)
            Case 2

                'txtComprobante.Text = "R-" & Format(Fields!nrosucursal.Value, "0000") & "-" & Format(Fields!NroFactura.Value, "00000000")
                AcumTotalImporte += Convert.ToDecimal(Fields!TotalComprobante.Value)
                TotalCompProv += Convert.ToDecimal(Fields!TotalComprobante.Value)
                totalgrupo += Convert.ToDecimal(Fields!TotalComprobante.Value - Fields!pagado.Value)
                txtSaldo.Text = Format((Convert.ToDecimal(Fields!TotalComprobante.Value - Fields!pagado.Value)) * -1, "#,##0.00")
                AcumProdImporte = AcumProdImporte + (Fields!TotalComprobante.Value * Math.Abs(DateDiff("d", Fields!FechaVto.Value, Date.Now)))
                totalrem += Convert.ToDecimal(Fields!TotalComprobante.Value)
                Detail.BackColor = Color.FromArgb(255, 192, 192)
                acumInsumos = acumInsumos + CDbl(IIf(txtSaldo.Text <> "", txtSaldo.Text, 0))
            Case 3, 4, 5, 6, 13, 14, 17, 19, 21
                If Fields!codestadopago.Value <> 3 Then
                    If Validarautorizado(Fields!nrointerno.Value = 1) Then
                        'no autorizado
                        If Not IsDBNull(Fields!nroCompAlfanumerico.Value) Then
                            txtComprobante.Text = "D-" & Fields!nrocompAlfanumerico.Value

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
                    acumInsumos += If(Double.TryParse(txtSaldo.Text, Nothing), CDbl(txtSaldo.Text), 0)
                Else
                    If Fields!EsAduana.Value = 1 Then
                        txtComprobante.Text = "D-" & Fields!NroFactura.Value
                    End If


                    If (Left(Fields!NroComp.Value, 4) = 4000 And Fields!TipoGrupo.Value = 6) Or (Left(Fields!NroComp.Value, 4) = 9041 And Fields!TipoGrupo.Value = 6) Or (Left(Fields!NroComp.Value, 4) = 9042 And Fields!TipoGrupo.Value = 6) Or (Left(Fields!NroComp.Value, 4) = 9997 And Fields!TipoGrupo.Value = 10) Then
                        txtSaldo.Text = Format(((Fields!TotalComprobante.Value * -1) * -1), "#,##0.00")
                        SaldoPendientePago = ((Fields!TotalComprobante.Value) * -1) * -1
                    Else
                        txtSaldo.Text = Format(((Fields!TotalComprobante.Value) * -1), "#,##0.00")
                        SaldoPendientePago = (Fields!TotalComprobante.Value) * -1
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
                    SaldoPendientePago = (-1 * (Fields!TotalComprobante.Value - (pagado))) * -1
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
                acumInsumos += If(Double.TryParse(txtSaldo.Text, Nothing), CDbl(txtSaldo.Text), 0)
            Case 15
                If Fields!EsAduana.Value = 1 Then
                    txtComprobante.Text = "AOP-" & Fields!NroFactura.Value
                End If
                If Fields!codestadopago.Value = 3 Then
                    txtSaldo.Text = Format(((Fields!TotalComprobante - (Fields!pagado.Value))) * -1, "#,##0.00")
                    txtSaldo.Text = Format((-1 * (Fields!TotalComprobante.Value - (Fields!pagado.Value))) * -1, "#,##0.00")
                    SaldoPendientePago = (-1 * (Fields!TotalComprobante.Value - (pagado))) * -1
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
                    SaldoPendientePago = (Fields!TotalComprobante.Value * -1) * -1
                Else
                    ActualizarTotalesNeg()
                End If
                acumInsumos += If(Double.TryParse(txtSaldo.Text, Nothing), CDbl(txtSaldo.Text), 0)
            Case 23
                'If Fields!EsAduana=1 Then
                If Not (Fields!nroCompAlfanumerico.Value Is Nothing) Then
                    txtComprobante.Text = "De-" & Fields!nroCompAlfanumerico.Value
                End If
                If Fields!codestadopago.Value = 3 Then
                    txtSaldo.Text = Format(((Fields!TotalComprobante.Value - (Fields!pagado.Value))) * -1, "#,##0.00")
                    txtSaldo.Text = Format((-1 * (Fields!TotalComprobante.Value - (Fields!pagado.Value))) * -1, "#,##0.00")
                    SaldoPendientePago = (-1 * (Fields!TotalComprobante.Value - (pagado))) * -1
                Else
                    ActualizarTotalesPos()
                End If
                acumInsumos += If(Double.TryParse(txtSaldo.Text, Nothing), CDbl(txtSaldo.Text), 0)
            Case 24
                'If Fields!EsAduana=1 Then
                If Not (Fields!nroCompAlfanumerico.Value Is Nothing) Then
                    txtComprobante.Text = "De-" & Fields!nroCompAlfanumerico.Value
                End If
                If Fields!codestadopago.Value = 3 Then
                    txtSaldo.Text = Format(((Fields!TotalComprobante.Value - (Fields!pagado.Value))) * -1, "#,##0.00")
                    txtSaldo.Text = Format((-1 * (Fields!TotalComprobante.Value - (Fields!pagado.Value))) * -1, "#,##0.00")
                    SaldoPendientePago = (-1 * (Fields!TotalComprobante.Value - (pagado))) * -1
                Else
                    ActualizarTotalesPos()
                End If
                acumInsumos += If(Double.TryParse(txtSaldo.Text, Nothing), CDbl(txtSaldo.Text), 0)
        End Select
        If Fields!bloqueo.Value = 1 Then
            Detail.BackColor = Color.LightCoral
        End If

        AcumularTipoInsumoActual()
        rowIndex = ObtenerRowIndexEnTablaResumen()

        If rowIndex = -1 Then
            Dim nuevaFila As System.Data.DataRow = tablaresumen.NewRow()
            nuevaFila("NroProveedor") = Convert.ToInt32(Fields!Proveedor.Value)
            nuevaFila("TotalCta") = 0
            nuevaFila("TipoInsumo") = 0
            tablaresumen.Rows.Add(nuevaFila)
            rowIndex = tablaresumen.Rows.Count - 1
        End If

        ActualizarTotalCtaSegunTipoGrupo(rowIndex)
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

    Private Sub AcumularTipoInsumoActual()
        Dim tipoInsumoActual As Integer = Convert.ToInt32(Fields!codinsumoprovisto.Value)

        If tipoInsumoTotales.ContainsKey(tipoInsumoActual) Then
            Select Case Fields!TipoGrupo.Value
                Case 3, 8, 6, 10
                    tipoInsumoTotales(tipoInsumoActual) -= Convert.ToDouble(Fields!TotalComprobante.Value - Fields!pagado.Value)
                Case Else
                    tipoInsumoTotales(tipoInsumoActual) += Convert.ToDouble(Fields!TotalComprobante.Value - Fields!pagado.Value)
            End Select
        Else
            Select Case Fields!TipoGrupo.Value
                Case 3, 8, 6, 10
                    tipoInsumoTotales(tipoInsumoActual) = (Convert.ToDouble(Fields!TotalComprobante.Value - Fields!pagado.Value)) * -1
                Case Else
                    tipoInsumoTotales(tipoInsumoActual) = Convert.ToDouble(Fields!TotalComprobante.Value - Fields!pagado.Value)
            End Select
        End If
    End Sub

    Private Sub ActualizarTotalCtaSegunTipoGrupo(rowIndex As Integer)
        Dim totalComprobante As Double = Convert.ToDouble(Fields!TotalComprobante.Value - Fields!pagado.Value)

        Select Case Convert.ToInt32(Fields!TipoGrupo.Value)
            Case 1, 2
                ' Facturas, Remitos
                ActualizarTotales("TipoInsumo", F, totalComprobante)
            Case 5, 7, 4, 9
                ' Débitos
                ActualizarTotales("TipoInsumo", D, totalComprobante)
            Case 3, 8, 6, 10, 11
                ' Créditos
                ActualizarTotales("TipoInsumo", c, -totalComprobante)
                'Case 11
                '    ' Caso 11
                '    Dim totalActualizar As Double = Convert.ToDouble(Fields!IvaProd.Value) + Convert.ToDouble(Fields!ImporteProd.Value) +
                '                         Convert.ToDouble(Fields!PercepIva.Value) + Convert.ToDouble(Fields!PercepGan.Value) +
                '                         Convert.ToDouble(Fields!TotalPercepIB.Value) + Convert.ToDouble(Fields!ImporteNoImp.Value)
                '    ActualizarTotales("TipoInsumo", DE, totalActualizar)
        End Select
    End Sub

    Private Sub ActualizarTotales(columnName As String, ByRef totalVariable As Double, totalComprobante As Double)
        tablaresumen.Rows(rowIndex)(columnName) = Fields!codInsumoProvisto.Value
        If Not DBNull.Value.Equals(tablaresumen.Rows(rowIndex)("TotalCta")) Then
            tablaresumen.Rows(rowIndex)("TotalCta") += totalComprobante
            totalVariable += totalComprobante
        End If
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
        ActualizarTxtTotalPorCta()
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

    Private Function ObtenerRowIndexEnTablaResumen() As Integer
        Dim rowIndex As Integer = -1
        For i As Integer = 0 To tablaresumen.Rows.Count - 1
            If Convert.ToInt32(tablaresumen.Rows(i)("NroProveedor")) = Convert.ToInt32(Fields!Proveedor.Value) Then
                rowIndex = i
                Exit For
            End If
        Next
        Return rowIndex
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

    Private Sub GroupFooter2_Format(sender As Object, e As EventArgs) Handles GroupFooter2.Format
        lblTotalInsumo.Text = " TOTAL " & Fields!insumoprovisto.Value
        txtTotalInsumo.Text = String.Format(cultureAR, "{0:C}", (acumInsumos))
        acumInsumos = 0
    End Sub


    Private Sub ActualizarTxtTotalPorCta()


        'TxtDetalleInsumos.Text = sb.ToString()
        Dim DescCta As String = ""

        '' Ordenar el diccionario por CodTipoInsumosProveedor (tipoInsumoTotales)
        Dim tipoInsumoTotalesOrdenados = From entry In tipoInsumoTotales
                                         Order By Convert.ToInt32(entry.Key)
                                         Select entry

        ' Crear un StringBuilder para construir el texto con formato
        Dim sb As New StringBuilder()

        ' Asegurarse de que el TextBox use una fuente monoespaciada
        TxtDetalleInsumos.Font = New Font("Courier New", 8, FontStyle.Bold)

        For Each tipoInsumoTotal In tipoInsumoTotalesOrdenados
            Dim codctaprov As Integer = tipoInsumoTotal.Key
            Dim totalcta As Double = tipoInsumoTotal.Value
            DescCta = GetDescripcionCta(codctaprov)

            If totalcta <> 0 Then
                ' Construir la línea con formato y agregarla al StringBuilder
                sb.AppendLine($"{Format(codctaprov, "00")} - {Left(DescCta, 30)}   {String.Format(cultureAR, "{0:C}", totalcta * -1).PadLeft(17)}  [{Format((((totalcta * -1) * 100) / ((total + totalrem + TotalCompNoAutorizados) * -1)), "00.00")}%]")
            End If
        Next

        ' Añadir la línea para el "TOTAL GRAL."
        DescCta = "TOTAL GRAL." & Space(25)
        sb.AppendLine($"{Left(DescCta, 30)}       $ {Format((total + totalrem + TotalCompNoAutorizados) * -1, "#,##0.00").PadLeft(17)}")

        ' Establecer el texto completo en el TextBox
        TxtDetalleInsumos.Text = sb.ToString()
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
