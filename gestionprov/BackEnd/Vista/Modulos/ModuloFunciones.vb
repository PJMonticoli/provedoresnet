Imports ClasesGlobal
Imports iText.Kernel.Pdf.Canvas.Wmf
Imports Controles
Imports Guna.UI2.WinForms
Module ModuloFunciones
#Region "Funciones Proveedor"
    Dim controlProveedor As New ControlerProveedor
    Public Sub Buscarproveedor(ByRef Estado As String, nroproveedor As String, ByRef mskNroProveedor As MaskedTextBox, ByRef txtproveedor As Guna2TextBox, ByRef txtcai As Guna2TextBox, ByRef mskVtoCAI As MaskedTextBox, ByVal cbotipo As ComboBox, ByRef cbodescripcion As ComboBox, ByRef tabla As DataTable)
        Try
            If controlProveedor.buscarProveedor(nroproveedor, tabla) = 1 Then
                For Each row As DataRow In tabla.Rows
                    mskNroProveedor.Text = row.Item(0).ToString()
                    txtproveedor.Text = row.Item(1).ToString()
                    VariablesGlobales.condicionIva = row.Item(4).ToString()
                Next

                If Estado <> "MODIFICAR" Then
                    Dim dt As New DataTable
                    controlProveedor.buscarProveedorCAI(mskNroProveedor.Text, cbotipo.SelectedValue, cbodescripcion.SelectedValue, dt)

                    If dt Is Nothing Then
                        Exit Sub
                    End If

                    If dt.Rows.Count > 0 Then
                        ' Veo si el CAI está válido
                        If Not IsDBNull(dt.Rows(0)("CAI")) Then
                            txtcai.Text = Trim(dt.Rows(0)("CAI"))
                        Else
                            txtcai.Text = ""
                        End If

                        If Not IsDBNull(dt.Rows(0)("FechaVto")) Then
                            mskVtoCAI.Text = Format(dt.Rows(0)("FechaVto"), "dd/MM/yyyy")
                        Else
                            mskVtoCAI.Text = "00/00/0000"
                        End If
                    Else
                        ' No se encontraron datos de CAI guardados en el sistema
                        txtcai.Text = ""
                        mskVtoCAI.Text = "00/00/0000"
                    End If
                Else
                    MsgBox("No se encontraron resultados para la búsqueda solicitada")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Public Function validarMontosYPercepciones(ByRef totalgrav As Double, ByRef impprod As Double, ByRef txtTotalImp As Double, ByRef txtIVAProd As Double) As Boolean
        'If Convert.ToDouble(txtTotalGrav.Text) = Convert.ToDouble(txtImpProd.Text) Then
        If totalgrav = impprod Then
                If txtTotalImp = txtIVAProd Then
                    validarMontosYPercepciones = True
                Else
                    validarMontosYPercepciones = False
                End If
            Else
                validarMontosYPercepciones = False
            End If
    End Function
    Public Function stringSQL(Palabra As String) As String
        stringSQL = Replace(Trim(Palabra), "'", "´")
    End Function

    Public Function FormatoSQL(Cadena As String) As String
        FormatoSQL = Replace(Trim(Cadena), ",", ".")
    End Function
    Public Sub buscarproveedorxcomp(nroComp As String, ByRef tabla As DataTable, ByRef msknroproveedor As MaskedTextBox, ByRef txtProveedor As Guna2TextBox)
        Try
            If controlProveedor.buscarProveedorPorNroComprobante(nroComp, tabla) = 1 Then
                For Each row As DataRow In tabla.Rows
                    msknroproveedor.Text = row.Item(0).ToString()
                    txtProveedor.Text = row.Item(1).ToString()
                Next
            Else
                MsgBox("No se encontraron resultados para la busqueda solicitada")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ' Función para formatear el código de insumo
    Public Function FormatCodigoInsumo(ByRef codigo As String) As String
        If codigo.Length = 13 Then
            Return String.Format("{0}.{1}.{2}.{3}.{4}", codigo.Substring(0, 1), codigo.Substring(1, 2), codigo.Substring(3, 3), codigo.Substring(6, 3), codigo.Substring(9, 4))
        End If
        Return codigo
    End Function
    Public Function FuncionControlarOrdenCarga(ByRef dt As DataTable, ByRef dgvordendecarga As DataGridView, ByRef mskNroInterno As MaskedTextBox) As Boolean
        Dim salida As String
        Dim i As Integer

        If dgvordendecarga.RowCount > 0 Then
            dt.Columns.Add("NroOrdenCarga", GetType(Double))

            With dgvordendecarga
                For i = 0 To .RowCount - 1
                    If .Columns.Count > 1 AndAlso Not IsDBNull(.Item(1, i).Value) Then
                        .CurrentCell = .Item(1, i)
                        Dim newRow As DataRow = dt.NewRow()
                        newRow("NroOrdenCarga") = Val(.CurrentCell.Value)
                        dt.Rows.Add(newRow)
                    End If
                Next i
            End With
            If dt.Rows.Count > 0 Then
                If mskNroInterno.Text.Trim = "" Then
                    FuncionControlarOrdenCarga = False
                    MsgBox("Error al intentar obtener datos.", MsgBoxStyle.Critical)
                Else
                    salida = controlProveedor.ValidarOrdenCarga(dt, mskNroInterno.Text.Trim())
                    Select Case salida
                        Case -1
                            MsgBox("Error al intentar obtener datos.", MsgBoxStyle.Critical)
                            FuncionControlarOrdenCarga = False
                        Case 0
                            MsgBox("No se encontraron datos. Controle las Ordenes de Carga.", MsgBoxStyle.Information)
                            FuncionControlarOrdenCarga = False
                        Case 1
                            FuncionControlarOrdenCarga = True
                        Case 2
                            MsgBox("La fecha de la Orden de Carga supera los 15 Días.", MsgBoxStyle.Critical)
                            FuncionControlarOrdenCarga = False
                        Case 3
                            MsgBox("La orden de carga ya ha sido ingresada en otro Comprobante.", MsgBoxStyle.Critical)
                            FuncionControlarOrdenCarga = False
                    End Select
                End If

            Else
                FuncionControlarOrdenCarga = True
            End If
        Else
            FuncionControlarOrdenCarga = True
        End If
    End Function

    Public Function GetDoubleValue(input As String) As Double
        Dim result As Double = 0.0
        'Verifico que el input sea un numero valido antes de convertir
        If Double.TryParse(input, result) Then
            Return result
        Else
            Return 0.0
        End If
    End Function

    Public Sub CalcularTotalComprobante(ByRef FrmPrincipal As FrmPrincipal)
        Dim totalComprobante As Double = 0.0
        Dim totalgrilla As Double = 0.0

        If FrmPrincipal.rbtAlicNormal.Checked = True Then 'calculo todos los impuestos
            FrmPrincipal.txtGrav105.Enabled = False
            FrmPrincipal.txtImp105.Enabled = False
            FrmPrincipal.txtGrav27.Enabled = False
            FrmPrincipal.txtImp27.Enabled = False
            FrmPrincipal.txtGrav75.Enabled = False
            FrmPrincipal.txtImp75.Enabled = False
        End If
        FrmPrincipal.txtImp21.Text = IIf(FrmPrincipal.txtImp21.Text.Trim() = "", 0.00, FrmPrincipal.txtImp21.Text)
        FrmPrincipal.txtImpProd.Text = IIf(FrmPrincipal.txtImpProd.Text.Trim() = "", 0.00, FrmPrincipal.txtImpProd.Text)
        FrmPrincipal.txtImp105.Text = IIf(FrmPrincipal.txtImp105.Text.Trim() = "", 0.00, FrmPrincipal.txtImp105.Text)
        FrmPrincipal.txtImp27.Text = IIf(FrmPrincipal.txtImp27.Text.Trim() = "", 0.00, FrmPrincipal.txtImp27.Text)
        FrmPrincipal.txtImp75.Text = IIf(FrmPrincipal.txtImp75.Text.Trim() = "", 0.00, FrmPrincipal.txtImp75.Text)
        FrmPrincipal.txtGrav21.Text = IIf(FrmPrincipal.txtGrav21.Text.Trim() = "", 0.00, FrmPrincipal.txtGrav21.Text)
        FrmPrincipal.txtGrav105.Text = IIf(FrmPrincipal.txtGrav105.Text.Trim() = "", 0.00, FrmPrincipal.txtGrav105.Text)
        FrmPrincipal.txtGrav27.Text = IIf(FrmPrincipal.txtGrav27.Text.Trim() = "", 0.00, FrmPrincipal.txtGrav27.Text)
        FrmPrincipal.txtGrav75.Text = IIf(FrmPrincipal.txtGrav75.Text.Trim() = "", 0.00, FrmPrincipal.txtGrav75.Text)
        FrmPrincipal.txtIVAProd.Text = IIf(FrmPrincipal.txtIVAProd.Text.Trim() = "", 0.00, FrmPrincipal.txtIVAProd.Text)
        FrmPrincipal.txtPercepGanancia.Text = IIf(FrmPrincipal.txtPercepGanancia.Text.Trim() = "", 0.00, FrmPrincipal.txtPercepGanancia.Text)
        FrmPrincipal.txtPercepIB.Text = IIf(FrmPrincipal.txtPercepIB.Text.Trim() = "", 0.00, FrmPrincipal.txtPercepIB.Text)
        FrmPrincipal.txtPercepIva.Text = IIf(FrmPrincipal.txtPercepIva.Text.Trim() = "", 0.00, FrmPrincipal.txtPercepIva.Text)
        FrmPrincipal.txtImpPais.Text = IIf(FrmPrincipal.txtImpPais.Text.Trim() = "", 0.00, FrmPrincipal.txtImpPais.Text)
        FrmPrincipal.txtImpNoImp.Text = IIf(FrmPrincipal.txtImpNoImp.Text.Trim() = "", 0.00, FrmPrincipal.txtImpNoImp.Text)


        'primero corrobar el dgv 
        If FrmPrincipal.dgvListado.RowCount > 0 Then
            For i As Integer = 0 To FrmPrincipal.dgvListado.Rows.Count - 1
                Dim valorcelda As Double
                If FrmPrincipal.dgvListado.Rows(i).Cells(5).Value IsNot Nothing AndAlso Double.TryParse(FrmPrincipal.dgvListado.Rows(i).Cells(5).Value.ToString(), valorcelda) Then
                    totalgrilla += valorcelda
                End If
            Next

        End If
        FrmPrincipal.txtGrav21.Text = totalgrilla.ToString("N2")
        FrmPrincipal.txtImp21.Text = (totalgrilla * 0.21).ToString("N2")
        FrmPrincipal.txtIVAProd.Text = (totalgrilla * 0.21).ToString("N2")
        FrmPrincipal.txtImpProd.Text = totalgrilla.ToString("N2")

        Dim totalGrav As Decimal = 0

        If Decimal.TryParse(FrmPrincipal.txtGrav21.Text.Trim, 0) Then
            totalGrav += Convert.ToDecimal(FrmPrincipal.txtGrav21.Text.Trim)
        End If

        If Decimal.TryParse(FrmPrincipal.txtGrav105.Text.Trim, 0) Then
            totalGrav += Convert.ToDecimal(FrmPrincipal.txtGrav105.Text.Trim)
        End If

        If Decimal.TryParse(FrmPrincipal.txtGrav27.Text.Trim, 0) Then
            totalGrav += Convert.ToDecimal(FrmPrincipal.txtGrav27.Text.Trim)
        End If

        totalGrav = totalGrav.ToString()

        ''calculo da la columna imponible
        FrmPrincipal.txtTotalGrav.Text = totalGrav.ToString("N2")
        FrmPrincipal.txtImp21.Text = (totalgrilla * 0.21).ToString("N2")

        Dim totalImp As Double

        Dim imp21 As String = Convert.ToDouble(If(String.IsNullOrWhiteSpace(FrmPrincipal.txtImp21.Text), "0", FrmPrincipal.txtImp21.Text.Replace(".", "").Trim()))
        Dim imp105 As String = If(String.IsNullOrWhiteSpace(FrmPrincipal.txtImp105.Text), "0", FrmPrincipal.txtImp105.Text.Trim().Replace(".", ""))
        Dim imp27 As String = Convert.ToDouble(If(String.IsNullOrWhiteSpace(FrmPrincipal.txtImp27.Text), "0", FrmPrincipal.txtImp27.Text.Trim().Replace(".", "")))
        Dim imp75 As String = If(String.IsNullOrWhiteSpace(FrmPrincipal.txtImp75.Text), "0", FrmPrincipal.txtImp75.Text.Trim().Replace(".", ""))

        If Double.TryParse(imp21, totalImp) Then
            Dim imp105Value As Double
            Dim imp27Value As Double
            If Double.TryParse(imp105, imp105Value) Then
                totalImp += imp105Value
            End If
            If Double.TryParse(imp27, imp27Value) Then
                totalImp += imp27Value
            End If
        End If
        FrmPrincipal.txtTotalImp.Text = totalImp.ToString("N2")
        FrmPrincipal.txtIVAProd.Text = totalImp.ToString("N2")

        ' Actualizo valor txtTotalComp
        If VariablesGlobales.condicionIva = 6 Then 'Cuando el Proveedor es Monotributista 'FACTURA B O C'
            FrmPrincipal.txtImpProd.Text = 0.00
            FrmPrincipal.txtIVAProd.Text = 0.00
            FrmPrincipal.txtPercepGanancia.Text = 0.00
            FrmPrincipal.txtPercepIva.Text = 0.00
            FrmPrincipal.txtPercepIB.Text = 0.00
            FrmPrincipal.txtImpPais.Text = 0.00
            FrmPrincipal.txtGrav21.Text = 0.00
            FrmPrincipal.txtImp21.Text = 0.00
            FrmPrincipal.txtTotalGrav.Text = 0.00
            FrmPrincipal.txtTotalImp.Text = 0.00
            FrmPrincipal.txtImpNoImp.Text = Format(totalgrilla, "N2")
            FrmPrincipal.txtTotalComp.Text = Format(totalgrilla, "N2")
        Else
            For i As Integer = 0 To FrmPrincipal.dgvListado.Rows.Count - 1
                Select Case CStr(FrmPrincipal.dgvListado.Rows(i).Cells(1).Value).Replace(".", "")
            ' Tu lista de códigos de insumos de exportación
                    Case "2030040010001", "2030040010002", "2030040010003", "2030030020001", "2030030020002", "2030030030001", "2030030030002", "2030030030003", "2030050010001", "2030050010002", "2030050010003", "2030050010004", "3020010010002", "1010120010002", "1010120020001", "1010120020002", "1010120030003", "1010120030004", "1010120030005"
                        FrmPrincipal.txtImpProd.Text = totalGrav.ToString("N2")
                        FrmPrincipal.txtImpPais.Text = FrmPrincipal.txtImp75.Text
                        totalComprobante += GetDoubleValue(FrmPrincipal.txtIVAProd.Text)
                        totalComprobante += GetDoubleValue(FrmPrincipal.txtImpNoImp.Text)
                        totalComprobante += GetDoubleValue(FrmPrincipal.txtPercepGanancia.Text)
                        totalComprobante += GetDoubleValue(FrmPrincipal.txtPercepIva.Text)
                        totalComprobante += GetDoubleValue(FrmPrincipal.txtPercepIB.Text)
                        totalComprobante += GetDoubleValue(FrmPrincipal.txtImpPais.Text)
                        FrmPrincipal.txtTotalComp.Text = Format(totalComprobante, "N2")
                    Case Else
                        FrmPrincipal.txtImpProd.Text = totalGrav.ToString("N2")
                        FrmPrincipal.txtImpPais.Text = FrmPrincipal.txtImp75.Text
                        totalComprobante += GetDoubleValue(FrmPrincipal.txtImpProd.Text)
                        totalComprobante += GetDoubleValue(FrmPrincipal.txtIVAProd.Text)
                        totalComprobante += GetDoubleValue(FrmPrincipal.txtImpNoImp.Text)
                        totalComprobante += GetDoubleValue(FrmPrincipal.txtPercepGanancia.Text)
                        totalComprobante += GetDoubleValue(FrmPrincipal.txtPercepIva.Text)
                        totalComprobante += GetDoubleValue(FrmPrincipal.txtPercepIB.Text)
                        totalComprobante += GetDoubleValue(FrmPrincipal.txtImpPais.Text)
                        FrmPrincipal.txtTotalComp.Text = Format(totalComprobante, "N2")
                End Select
            Next
        End If



        FrmPrincipal.txtIVAProd.Enabled = False
        FrmPrincipal.txtTotalGrav.Enabled = False
        FrmPrincipal.txtTotalImp.Enabled = False
    End Sub
#End Region
End Module
