Imports GrapeCity.Documents.DX.Direct3D11
Imports Modelos
Imports System.Web.UI.WebControls
Imports Controles
Imports ClasesGlobal
Imports System.Runtime.InteropServices
Imports GrapeCity.Documents.DX.WIC
Imports GrapeCity.ActiveReports.Design.DdrDesigner.Services.Infrastructure.ReportData.DataSourceException

Public Class FrmCreditoDebito
    Dim controlinforme As New ControlerInforme
    Dim controldebcred As New ControlerNotaCredDeb
    Private Estado As String
    Dim control As New ControlerProveedor
    Dim tabla As New DataTable
    Private Sub HabilitarControles(ByRef opcion As String)
        Select Case opcion
            Case "GUARDAR"
            Case "LIMPIAR"
                LimpiarControles()
            Case "ACUMULAR"
            Case "IMPRIMIR"
            Case "SALIR"
        End Select
    End Sub


    Private Sub LimpiarControles()
        mskNroProveedor.BackColor = Color.White
        cboTipo.BackColor = Color.White
        cboDescripcion.BackColor = Color.White
        mskNroComprobante.BackColor = Color.White
        txtCAI.BackColor = Color.White
        mskVtoCAI.BackColor = Color.White
        txtCAI.Text = ""
        mskVtoCAI.Text = "00/00/0000"
        mskVtoCAI.Enabled = True
        txtCAI.Enabled = True


        mskFecha.Text = Format(Date.Now, "dd/MM/yyyy")
        txtObservaciones.Text = ""
        mskNroComprobante.Text = ""
        cboTipo.SelectedValue = 1
        cboDescripcion.SelectedValue = 1
        txtImpProd.Text = ""
        txtIB.Text = ""
        txtIE.Text = ""
        txtIva.Text = ""
        txtPercep.Text = ""
        txtGrav21.Text = ""
        txtImp21.Text = ""
        txtGravTotal.Text = ""
        txtImpTotal.Text = ""
        txtGrav105.Enabled = False
        txtGrav27.Enabled = False

        mskFecha.Enabled = False

        mskNroProveedor.Enabled = True
        btnBuscarProveedor.Enabled = True
        GPanel5.Enabled = False



        txtGrav105.Enabled = True
        txtImp105.Enabled = True
        txtGrav21.Enabled = True
        txtImp21.Enabled = True
        txtGrav27.Enabled = True
        txtImp27.Enabled = True
        txtGrav75.Enabled = True
        txtImp75.Enabled = True
        txtImpProd.Enabled = True
        txtIB.Enabled = True
        txtIva.Enabled = True
        txtPercep.Enabled = True


        btnNuevo.Enabled = True

        btnCancelar.Enabled = False
        btnSalir.Enabled = True

        btnGuardar.Enabled = False


        dgvListado.Rows.Clear()
        dgvOrdenDeCarga.Rows.Clear()

        mskNroProveedor.Text = ""
        cboTipo.SelectedIndex = -1
        mskFecha.Text = ""
        cboDescripcion.SelectedIndex = -1

    End Sub

    Private Sub FrmCreditoDebito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HabilitarControles("LIMPIAR")
        HabilitarControles("BUSQUEDA")
        AddHandler mskNroProveedor.KeyDown, AddressOf mskNroProveedor_KeyDown
        If controldebcred.ObtenerPrefijo("C") Then
            btnNuevo.Enabled = True 'Nuevo
        Else
            'If VariablesGlobales.UsarAfip = True Then
            '    'ConeccionAFIP
            'Else
            '    btnNuevo.Visible = False
            '    btnGuardar.Visible = False
            '    btnAcumular.Visible = False
            '    btnCancelar.Visible = False
            'End If
        End If
        mskNroComprobante.Enabled = True
        cargarCombo()
        Cargarcbodescripcion()
        cboDescripcion.SelectedIndex = -1
        GPanel1.Enabled = False
        GPanel2.Enabled = False
        GPanel3.Enabled = False
        GPanel4.Enabled = False
        GPanel5.Enabled = False
        GPanel6.Enabled = False
    End Sub
    Private Sub cargarCombo()
        Try
            Dim rec As New DataTable
            Dim i As Long

            i = controlinforme.BuscarTipos(rec)

            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList
            If rec.Rows.Count = 0 Then
                MsgBox("No se poseen datos de Tipos de Comprobantes.", MsgBoxStyle.Information, Me.Text)
                Exit Sub
            Else
                ' Add the "TODAS" item
                cboTipo.Items.Add("TODAS")
                cboTipo.SelectedIndex = 0

                For Each row As DataRow In rec.Rows
                    ' Add other items
                    cboTipo.Items.Add(row("Descripcion").ToString().Replace("'", "´"))
                    cboTipo.SelectedIndex = cboTipo.Items.Count - 1
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Cargarcbodescripcion()
        Dim rec As DataTable
        Dim i As Long
        Dim control As New ControlerProveedor
        i = control.BuscarDescripcionComprobantesTodos(rec)

        cboDescripcion.DropDownStyle = ComboBoxStyle.DropDownList
        If i = 0 Then
            MsgBox("No se poseen datos de Descripciones.", MsgBoxStyle.Information, Me.Text)
            Exit Sub
        ElseIf i = -1 Then
            MsgBox("Error al obtener datos de Descripciones.", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        Else
            cboDescripcion.DataSource = rec
            cboDescripcion.ValueMember = "codigo"
            cboDescripcion.DisplayMember = "Descripcion"
        End If

        If cboDescripcion.Items.Count > 0 Then
            cboDescripcion.SelectedValue = 23
        End If

        i = control.BuscarTipos(rec)
        If i = 0 Then
            MsgBox("No se poseen datos de Tipos de Comprobantes.", vbInformation, Me.Text)
            Exit Sub
        ElseIf i = -1 Then
            MsgBox("Error al obtener datos de Tipos de Comprobantes.", vbCritical, Me.Text)
            Exit Sub
        Else
            cboTipo.DataSource = rec
            cboTipo.ValueMember = "codigo"
            cboTipo.DisplayMember = "descripcion"
        End If
        If cboTipo.Items.Count > 0 Then
            cboTipo.SelectedValue = 0
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Estado = "NUEVO"
        LimpiarControles()
        GPanel1.Enabled = True
        GPanel2.Enabled = True
        GPanel3.Enabled = True
        GPanel4.Enabled = True
        GPanel5.Enabled = True
        GPanel6.Enabled = True

        mskNroComprobante.Enabled = False

        btnNuevo.Enabled = False 'Nuevo
        btnGuardar.Enabled = True  'Grabar
        btnImprimir.Enabled = True  'print Remitos
        btnSalir.Enabled = True  'Salir


        mskFecha.Text = Format(Now, "dd/MM/yyyy")
        InicializarGrilla()
    End Sub
    Public Sub InicializarGrilla()
        ' *****************************************
        ' GRILLA DE INGRESOS DE INSUMOS
        ' *****************************************

        With dgvListado
            .Rows.Clear()

            ' AllowEdit property is not directly available in DataGridView, use ReadOnly property instead
            .ReadOnly = False

            .ColumnCount = 11
            .Columns(0).HeaderText = "N° Ingreso"
            .Columns(0).Width = 90
            .Columns(0).DisplayIndex = 0

            .Columns(1).HeaderText = "Cod.Insumo"
            .Columns(1).Width = 155
            .Columns(1).DisplayIndex = 1

            .Columns(2).HeaderText = "Descripción"
            .Columns(2).Width = 230
            .Columns(2).DisplayIndex = 2

            .Columns(3).HeaderText = "Cantidad"
            .Columns(3).Width = 70
            .Columns(3).DisplayIndex = 3

            .Columns(4).HeaderText = "Precio"
            .Columns(4).Width = 59
            .Columns(4).DisplayIndex = 4

            .Columns(5).HeaderText = "Total"
            .Columns(5).ValueType = GetType(Decimal)
            .Columns(5).Width = 65
            .Columns(5).DisplayIndex = 5

            .Columns(6).HeaderText = "C.C."
            .Columns(6).Width = 53
            .Columns(6).DisplayIndex = 6
            .Columns(6).DefaultCellStyle.Format = "###"

            ' Operacion exportacion
            .Columns(7).HeaderText = "O.E."
            .Columns(7).Width = 43
            .Columns(7).DisplayIndex = 7
            .Columns(7).DefaultCellStyle.Font = New Font("Wingdings", 10, FontStyle.Regular)
            .Columns(7).DefaultCellStyle.ForeColor = Color.Red
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(7).ReadOnly = True
            If .RowCount = 3 Then
                .Rows(1).Cells(7).Style.ForeColor = Color.Red
            End If

            .Columns(8).HeaderText = "L.Entrega"
            .Columns(8).Width = 103
            .Columns(8).DisplayIndex = 8

            .Columns(9).HeaderText = "idMaterial"
            .Columns(9).Width = 0
            .Columns(9).DisplayIndex = 9

            .Columns(10).HeaderText = "N.Solic.Prov."
            .Columns(10).Width = 100
            .Columns(10).DisplayIndex = 10
            .ReadOnly = True.ToString
            .ColumnHeadersHeight = 30
            .AllowUserToResizeRows = False
            .RowCount = 1
            .AllowUserToResizeRows = False ' Deshabilitar la modificación del tamaño de las filas
            .AllowUserToResizeColumns = False ' Deshabilitar la modificación del tamaño de las columnas
            .MultiSelect = True
            .EditMode = DataGridViewEditMode.EditOnEnter
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            ' Ajustar la altura de la fila de encabezado (fila de títulos)
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True ' Permite que los encabezados se muestren en varias líneas
        End With
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        Dim frm As New FrmPrincipal
        frm.Show()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        HabilitarControles("LIMPIAR")
    End Sub

    Private Sub mskNroComprobante_KeyDown(sender As Object, e As KeyEventArgs) Handles mskNroComprobante.KeyDown
        Dim aux As String
        If e.KeyCode = Keys.Enter Then
            ' Eliminar espacios en blanco y guiones existentes
            Dim inputText As String = mskNroComprobante.Text.Trim().Replace(" ", "").Replace("-", "")

            ' Rellenar con ceros a la izquierda según la longitud del texto
            If inputText.Length <= 4 Then
                mskNroComprobante.Text = Format(Val(inputText), "0000")
                mskNroComprobante.SelectionStart = 5
                mskNroComprobante.SelectionLength = 8
                e.Handled = True
            ElseIf inputText.Length < 12 Then
                ' Número de factura
                aux = Mid(inputText, 5, 8)
                mskNroComprobante.Text = Mid(mskNroComprobante.Text, 1, 4) & Format(Val(aux), "00000000")
                e.Handled = True
            End If
        End If
    End Sub

    'Private Sub btnPañol_Click(sender As Object, e As EventArgs) Handles btnPañol.Click
    '    Dim frm As New FrmPañol(Me)
    '    frm.id = CInt(mskNroProveedor.Text)
    '    frm.Show()
    'End Sub

    Private Sub mskNroProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles mskNroProveedor.KeyDown
        ' Verificar si la tecla presionada es ENTER
        If e.KeyCode = Keys.Enter Then
            BuscarProveedor()
        End If
    End Sub

    Private Sub btnBuscarProveedor_Click(sender As Object, e As EventArgs) Handles btnBuscarProveedor.Click
        BuscarProveedor()
    End Sub

    Private Sub BuscarProveedor()
        txtRazonSocial.Enabled = False
        txtDireccion.Enabled = False
        txtLocalidad.Enabled = False

        Try
            If (mskNroProveedor.Text = "") Then
                FrmBuscarProveedor.Show()
                If VariablesGlobales.numeroProveedor <> Nothing And VariablesGlobales.razonSocial <> Nothing Then
                    mskNroProveedor.Text = VariablesGlobales.numeroProveedor
                    txtDireccion.Text = VariablesGlobales.razonSocial
                End If
            Else
                If control.buscarProveedorHabilitadosAFIP(mskNroProveedor.Text, tabla) = 1 Then
                    For Each row As DataRow In tabla.Rows
                        mskNroProveedor.Text = row.Item(0).ToString()
                        txtRazonSocial.Text = row.Item(1).ToString()
                        txtDireccion.Text = row.Item(2).ToString()
                        txtLocalidad.Text = row.Item(3).ToString()
                        If row.Item(4).ToString().Trim = "N" Then
                            TxtCondIVA.Text = "INSCRIPTO"
                        Else
                            If row.Item(4).ToString().Trim = "S" Then
                                TxtCondIVA.Text = "CONVENIO MULTILATERAL"
                            Else
                                TxtCondIVA.Text = "EXENTO"
                            End If
                        End If
                    Next

                Else
                    MsgBox("No se encontraron resultados para la busqueda solicitada")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub mskNroProveedor_TextChanged(sender As Object, e As EventArgs) Handles mskNroProveedor.TextChanged
        If (mskNroProveedor.Text = "") Then
            txtDireccion.Text = ""
            txtRazonSocial.Text = ""
            txtLocalidad.Text = ""
        End If
    End Sub

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Private Sub PanelTitleBar_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown, Guna2Panel1.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112, &HF012, 0)
    End Sub

    Private Sub btnOperaciones_Click(sender As Object, e As EventArgs) Handles btnOperaciones.Click
        Try
            Dim numeroProveedor As Integer

            Dim frm As New FrmOperaciones(FrmPrincipal)
            frm.frmcreddeb = Me
            If Not Integer.TryParse(mskNroProveedor.Text, numeroProveedor) OrElse numeroProveedor <= 0 Then
                MsgBox("Proveedor No Válido. El N° de Proveedor debe corresponder a un proveedor válido.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ' Llamada al método que realiza la consulta
            Dim dataTable As DataTable = control.BuscarIngresosPendientes(numeroProveedor)

            If dataTable Is Nothing OrElse dataTable.Rows.Count = 0 Then
                MsgBox("No existen datos pendientes para este proveedor.", MsgBoxStyle.Information)
                Exit Sub
            Else
                ' Abre el formulario FrmOperaciones
                frm.PantallaMadre = "CREDDEB"
                frm.NumeroProveedor = numeroProveedor
                frm.ShowDialog(Me)
            End If
        Catch ex As Exception
            MsgBox("Error al realizar la consulta SQL. " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub dgvListado_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListado.CellValueChanged
        Dim currentCell As DataGridViewCell = dgvListado.CurrentCell
        Dim colIndex As Integer = currentCell.ColumnIndex
        Dim rowIndex As Integer = currentCell.RowIndex

        If colIndex = 1 Then
            dgvListado.CurrentCell = dgvListado(2, rowIndex)
        ElseIf colIndex = 2 Then
            ' Resto de la lógica según el código original en VBA
            Dim precio As Double
            Dim cantidad As Double
            Dim Gravado As Double
            Dim Exento As Double
            Dim oiva As Double
            Dim insumo As String
            Dim aux As String
            Dim oCodInsumo As String
            Dim oInsumo As Integer
            Dim codInsumo As String

            If String.IsNullOrEmpty(dgvListado.CurrentCell.Value?.ToString()) Then
                dgvListado.CurrentCell.Value = 0
            End If

            Select Case colIndex
                Case 1
                    dgvListado.CurrentCell = dgvListado(2, rowIndex + 1)

                Case 2 'cod. insumo
                    If String.IsNullOrEmpty(dgvListado.CurrentCell.Value?.ToString()) Then
                        Dim frmInsumo As New FrmBuscarInsumos(Me)
                        frmInsumo.Show()
                        Exit Sub
                    End If

                    If dgvListado.CurrentCell.Value.ToString().Length > 0 Then
                        If dgvListado.CurrentCell.Value.ToString().Length < 2 Then
                            'area
                            dgvListado.CurrentCell.Value = dgvListado.CurrentCell.Value & "."
                            ' KeyAscii no es relevante en VB.NET
                            Exit Sub
                        Else
                            'subarea
                            If dgvListado.CurrentCell.Value.ToString().Length <= 4 Then
                                aux = Mid(dgvListado.CurrentCell.Value.ToString(), 3, 2)
                                dgvListado.CurrentCell.Value = Mid(dgvListado.CurrentCell.Value.ToString(), 1, 2) & Format(Val(aux), "00") & "."
                                ' KeyAscii no es relevante en VB.NET
                                Exit Sub
                            End If
                        End If

                        'rubro
                        If dgvListado.CurrentCell.Value.ToString().Length <= 8 Then
                            aux = Mid(dgvListado.CurrentCell.Value.ToString(), 6, 3)
                            dgvListado.CurrentCell.Value = Mid(dgvListado.CurrentCell.Value.ToString(), 1, 5) & Format(Val(aux), "000") & "."
                            ' KeyAscii no es relevante en VB.NET
                            Exit Sub
                        Else
                            'subrubro
                            If dgvListado.CurrentCell.Value.ToString().Length <= 12 Then
                                aux = Mid(dgvListado.CurrentCell.Value.ToString(), 10, 3)
                                dgvListado.CurrentCell.Value = Mid(dgvListado.CurrentCell.Value.ToString(), 1, 9) & Format(Val(aux), "000") & "."
                                ' KeyAscii no es relevante en VB.NET
                                Exit Sub
                            Else
                                'insumo
                                If dgvListado.CurrentCell.Value.ToString().Length < 17 Then
                                    aux = Mid(dgvListado.CurrentCell.Value.ToString(), 14)
                                    dgvListado.CurrentCell.Value = Mid(dgvListado.CurrentCell.Value.ToString(), 1, 13) & Format(Val(aux), "0000")
                                    ' KeyAscii no es relevante en VB.NET
                                    Exit Sub
                                Else
                                    'buscar descripcion
                                    codInsumo = dgvListado.CurrentCell.Value.ToString().Replace(".", "")
                                    oCodInsumo = dgvListado.CurrentCell.Value.ToString().Replace(".", "")
                                    'insumo = Metodos.Generales.ObtenerDescripcion(CDbl(codInsumo.Replace(".", "")))

                                    If insumo = "DIE" Then
                                        MsgBox("Insumo no Existente.", vbInformation)
                                        Exit Sub
                                    Else
                                        dgvListado.CurrentCell = dgvListado(3, rowIndex)
                                        If cboDescripcion.SelectedIndex = -1 Then
                                            MsgBox("Seleccione un tipo de Comprobante.", vbInformation)
                                            Exit Sub
                                        End If

                                        Select Case cboDescripcion.SelectedValue
                                            Case 17
                                                If oCodInsumo = "1010140010001" Then '2040010010001
                                                    oInsumo = 1
                                                    txtIE.Enabled = True
                                                    txtImpProd.Enabled = True
                                                Else
                                                    oInsumo = 0
                                                    MsgBox("Verifique el código de insumo no corresponde a la nota de debito seleccionada.", vbCritical)
                                                End If

                                            Case 18
                                                If oCodInsumo = "1010140010002" Then '2040010010002
                                                    oInsumo = 1
                                                    txtIE.Enabled = True
                                                    txtImpProd.Enabled = True
                                                Else
                                                    oInsumo = 0
                                                    MsgBox("Verifique el código de insumo no corresponde a la nota de debito seleccionada.", vbCritical)
                                                End If
                                            Case 19, 20
                                                If oCodInsumo = "1010060020006" Or oCodInsumo = "1010060020007" Or oCodInsumo = "1010080020001" Or oCodInsumo = "1010080010002" Or oCodInsumo = "1010080010003" Or oCodInsumo = "1010080020002" Or oCodInsumo = "1010110020007" Or oCodInsumo = "1010110020008" Or oCodInsumo = "1010110020009" Then
                                                    oInsumo = 1
                                                    txtIE.Enabled = True
                                                    txtImpProd.Enabled = True
                                                Else
                                                    oInsumo = 0
                                                    MsgBox("Verifique el código de insumo no corresponde a la nota de debito seleccionada.", vbCritical)
                                                End If
                                            Case 5, 12
                                                If oCodInsumo = "1010100020001" Or oCodInsumo = "1010100020002" Then
                                                    oInsumo = 1
                                                    txtIE.Enabled = False
                                                    txtImpProd.Enabled = False
                                                Else
                                                    oInsumo = 0
                                                    MsgBox("Verifique el código de insumo no corresponde a la nota de debito seleccionada.", vbCritical)
                                                End If
                                            Case 10, 14
                                                If oCodInsumo = "1010130010001" Or oCodInsumo = "1010130010002" Then
                                                    oInsumo = 1
                                                    txtIE.Enabled = True
                                                    txtImpProd.Enabled = True
                                                Else
                                                    oInsumo = 0
                                                    MsgBox("Verifique el código de insumo no corresponde a la nota de debito seleccionada.", vbCritical)
                                                End If
                                        End Select

                                        If oInsumo = 1 Then
                                            dgvListado.CurrentCell.Value = insumo
                                            dgvListado.CurrentCell = dgvListado(4, rowIndex)
                                            ' KeyAscii no es relevante en VB.NET

                                            'VER

                                            'insumo = Metodos.Generales.BuscarCentroCostoXInsumo(codInsumo)
                                            dgvListado.CurrentCell = dgvListado(10, rowIndex)

                                            dgvListado.CurrentCell.Value = insumo
                                            dgvListado.CurrentCell = dgvListado(4, rowIndex)
                                        Else
                                            dgvListado.CurrentCell.Value = ""
                                            dgvListado.CurrentCell = dgvListado(4, rowIndex)
                                            ' KeyAscii no es relevante en VB.NET
                                        End If

                                        Exit Sub
                                    End If
                                End If
                            End If
                        End If
                    End If

                    ' Resto del código

            End Select
        End If
    End Sub

    Private Sub dgvListado_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvListado.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim currentCell As DataGridViewCell = dgvListado.CurrentCell
            Dim colIndex As Integer = currentCell.ColumnIndex
            Dim rowIndex As Integer = currentCell.RowIndex

            If colIndex = 7 Then
                If currentCell.Value Is Nothing OrElse String.IsNullOrEmpty(currentCell.Value.ToString()) Then
                    'Buscar Centro de Costos
                    'Pant_BuscarCC.PantallaMadre = "CD"
                    'Pant_BuscarCC.Show()
                    Dim frmBuscarInsumo As New FrmBuscarInsumos(Me)
                    frmBuscarInsumo.ShowDialog()
                    Exit Sub
                End If
                dgvListado.CurrentCell = dgvListado(1, rowIndex + 1)
            Else
                If colIndex = 2 Then
                    If currentCell.Value Is Nothing OrElse String.IsNullOrEmpty(currentCell.Value.ToString()) Then
                        'buscar codinsumo
                        'Pant_BuscarInsumo.PantallaMadre = "CD"
                        'Pant_BuscarInsumo.Show()
                        Dim frmBuscarInsumo As New FrmBuscarInsumos(Me)
                        frmBuscarInsumo.ShowDialog()
                        Exit Sub
                    End If
                End If
                dgvListado.CurrentCell = dgvListado(colIndex + 1, rowIndex)
            End If
            e.Handled = True
        End If
    End Sub
End Class