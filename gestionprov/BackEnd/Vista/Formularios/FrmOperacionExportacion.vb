Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Runtime.InteropServices
Imports ClasesGlobal
Imports Controles
Imports Guna.UI2.WinForms

Public Class FrmOperacionExportacion
    Public codComprobante As Long
    Public codMoneda As Integer
    Public Importe As Double
    Public Tipocomp As Integer
    Public numero As String
    Public codRowGrilla As Integer
    Public InsumoExportacion As Boolean
    Dim FRMPRINCIPAL As New FrmPrincipal
    Dim controlExportacion As New ControlerOpExportacion
    Dim controlComprobante As New ControlerComprobante
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        VariablesGlobales.banderaOE = False
        Me.Close()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub cboTipoExp_Click(sender As Object, e As EventArgs) Handles cboTipoExp.Click
        Select Case cboTipoExp.SelectedValue
            Case 1 'factura
                mskNroCompExp.Visible = True
                mskPermisoEmbarque.Visible = False
                txtInstrCobranza.Visible = False
                mskFacturaProforma.Visible = False
            Case 2 'Permiso de Embarque
                mskNroCompExp.Visible = False
                mskPermisoEmbarque.Visible = True
                txtInstrCobranza.Visible = False
                mskFacturaProforma.Visible = False
            Case 3 'Instr. de Cobranza
                mskNroCompExp.Visible = False
                mskPermisoEmbarque.Visible = False
                txtInstrCobranza.Visible = True
                mskFacturaProforma.Visible = False
            Case 5 'Factura Proforma
                mskNroCompExp.Visible = False
                mskPermisoEmbarque.Visible = False
                txtInstrCobranza.Visible = False
                mskFacturaProforma.Visible = True
        End Select
    End Sub
    Public Sub New(ByRef FRMPRINCIPAL As FrmPrincipal)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        FRMPRINCIPAL = FRMPRINCIPAL
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub FrmOperacionExportacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ModuloComboBox.cargarComboTipoCompEXP(cboTipoExp)
        ModuloComboBox.cargarComboMonedas(cboMoneda)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim varCodComprobanteAsociado As Long
        Dim i As Integer
        Dim numero As String
        varCodComprobanteAsociado = 0
        If cboMoneda.SelectedIndex = -1 Then
            MsgBox("Debido a que ha ingresado insumos asociados a operaciones de exportación debe ingresar una moneda para la operación de exportación.")
            cboMoneda.Focus()
            Exit Sub
        End If
        If cboTipoExp.SelectedIndex = -1 Then
            MsgBox("Debido a que ha ingresado insumos asociados a operaciones de exportación debe ingresar un tipo de comprobante asociado para la operación de exportación.")
            cboTipoExp.Focus()
            Exit Sub
        End If

        If Trim(txtImporte.Text) = "" Then txtImporte.Text = 0

        If Trim(mskNroCompExp.Text) = "" Then mskNroCompExp.Text = 0
        If Trim(mskFacturaProforma.Text) = "" Then mskFacturaProforma.Text = 0
        If Trim(txtInstrCobranza.Text) = "" Then txtInstrCobranza.Text = 0
        If Trim(mskPermisoEmbarque.Text) = "" Then mskPermisoEmbarque.Text = 0

        If Val(txtImporte.Text) = 0 Then
            MsgBox("Debe ingresar un importe de moneda extrajera para la operación de exportación.")
            txtImporte.Focus()
            Exit Sub
        End If


        Select Case cboTipoExp.SelectedIndex
            Case 1 'factura
                If Len(mskNroCompExp.Text) <> 12 Then
                    MsgBox("Debe Cargar un N° de Comprobante Exportación Válido", vbInformation)
                    mskNroCompExp.Focus()
                    Exit Sub
                End If
                numero = Trim(mskNroCompExp.Text)
                'valido que el comprobante exista
                If InsumoExportacion = True Then
                    varCodComprobanteAsociado = controlComprobante.ValidarComprobanteExportacion(cboTipoExp.SelectedValue, numero)
                    Select Case varCodComprobanteAsociado
                        Case -1
                            MsgBox("Error al intentar validar el comprobante." & vbCrLf & "Por favor comuníquese con sistemas.", vbCritical)
                            Exit Sub
                        Case 0
                            MsgBox("El comprobane ingresado no corresponde a ningún comprobante cargado en el sistema.", vbExclamation)
                            mskNroCompExp.Focus()
                            Exit Sub
                        Case Else
                            'encontro el comprobante
                    End Select
                Else
                    varCodComprobanteAsociado = -1
                End If
            Case 2 'Permiso de Embarque
                If Len(mskPermisoEmbarque.Text) <> 16 Then
                    MsgBox("Debe Cargar un N° de Permiso de Embarque Válido", vbInformation)
                    mskPermisoEmbarque.Focus()
                    Exit Sub
                End If
                numero = Trim(mskPermisoEmbarque.Text)
                If InsumoExportacion = True Then
                    varCodComprobanteAsociado = controlComprobante.ValidarComprobanteExportacion(cboTipoExp.SelectedValue, numero)
                    Select Case varCodComprobanteAsociado
                        Case -1
                            MsgBox("Error al intentar validar el comprobante." & vbCrLf & "Por favor comuníquese con sistemas.", vbCritical)
                            Exit Sub
                        Case 0
                            MsgBox("El comprobane ingresado no corresponde a ningún comprobante cargado en el sistema.", vbExclamation)
                            mskPermisoEmbarque.Focus()
                            Exit Sub
                        Case Else
                            'encontro el comprobante
                    End Select
                Else
                    varCodComprobanteAsociado = -1
                End If
            Case 3 'Instr. de Cobranza
                If Len(txtInstrCobranza.Text) < 2 Then
                    MsgBox("Debe Cargar un N° de Instr. de Cobranza Válido", vbInformation)
                    txtInstrCobranza.Focus()
                    Exit Sub
                End If
                numero = Trim(txtInstrCobranza.Text)
                varCodComprobanteAsociado = -1
            Case 5 'Factura Proforma
                If Len(mskFacturaProforma.Text) <> 6 Then
                    MsgBox("Debe Cargar un N° de Factura Proforma Válido", vbInformation)
                    mskFacturaProforma.Focus()
                    Exit Sub
                End If
                numero = Trim(mskFacturaProforma.Text)
                varCodComprobanteAsociado = -1
        End Select



        If codComprobante = 0 Then ' agregamos uno nuevo
            ' Assuming dgvExportacion is your Guna2DataGridView
            ModuloGrillas.InicializarGrillaExp(FRMPRINCIPAL.dgvExportacion)
            FRMPRINCIPAL.dgvExportacion.Rows.Add(varCodComprobanteAsociado, cboMoneda.SelectedItem.ToString(), cboTipoExp.SelectedItem.ToString(), numero, txtImporte.Text, codRowGrilla)
            FRMPRINCIPAL.dgvExportacion.Visible = True


            VariablesGlobales.banderaOE = True
            Me.Close()
        Else 'modificamos
            With FRMPRINCIPAL.dgvExportacion
                For Each row As DataGridViewRow In .Rows
                    If CInt(row.Cells(5).Value) = codRowGrilla Then
                        row.Cells(0).Value = varCodComprobanteAsociado
                        row.Cells(1).Value = cboMoneda.SelectedItem.ToString()
                        row.Cells(2).Value = cboTipoExp.SelectedItem.ToString()
                        row.Cells(3).Value = numero
                        row.Cells(4).Value = txtImporte.Text
                        Exit For
                    End If
                Next
            End With
        End If
        VariablesGlobales.banderaOE = True
        Me.Close()
    End Sub

    Private Sub mskFacturaProforma_KeyDown(sender As Object, e As KeyEventArgs) Handles mskFacturaProforma.KeyDown
        Dim aux As String
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(mskFacturaProforma.Text)) < 5 Then
                'sucursal
                aux = Mid(mskFacturaProforma.Text, 1, 4)
                If Val(aux) = 0 Then Exit Sub
                mskFacturaProforma.Text = Format(Val(aux), "0000")
                mskFacturaProforma.SelectionStart = 5
                mskFacturaProforma.SelectionLength = 2
                e.SuppressKeyPress = True
            Else
                'nro factura
                If Len(Trim(mskFacturaProforma.Text)) < 6 Then
                    aux = Mid(mskFacturaProforma.Text, 5, 2)
                    mskFacturaProforma.Text = Mid(mskFacturaProforma.Text, 1, 4) & Format(Val(aux), "00")
                End If
            End If

        End If
    End Sub

    Private Sub txtInstrCobranza_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInstrCobranza.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnAceptar.Focus()
        End If
    End Sub
    Private Sub mskNroCompExp_KeyDown(sender As Object, e As KeyEventArgs) Handles mskNroCompExp.KeyDown
        Dim aux As String
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(mskNroCompExp.Text)) < 5 Then
                'sucursal
                aux = Mid(mskNroCompExp.Text, 1, 4)
                If Val(aux) = 0 Then Exit Sub
                mskNroCompExp.Text = Format(Val(aux), "0000")
                mskNroCompExp.SelectionStart = 5
                mskNroCompExp.SelectionLength = 8
                e.SuppressKeyPress = True
            Else
                'nro factura
                If Len(Trim(mskNroCompExp.Text)) < 12 Then
                    aux = Mid(mskNroCompExp.Text, 5, 8)
                    mskNroCompExp.Text = Mid(mskNroCompExp.Text, 1, 4) & Format(Val(aux), "00000000")
                End If
            End If

        End If
    End Sub



    Private Sub mskPermisoEmbarque_KeyDown(sender As Object, e As KeyEventArgs) Handles mskPermisoEmbarque.KeyDown
        Dim aux As String
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(mskPermisoEmbarque.Text)) < 3 Then
                'sucursal
                aux = Mid(mskPermisoEmbarque.Text, 1, 2)
                If Val(aux) = 0 Then Exit Sub
                mskPermisoEmbarque.Text = Format(Val(aux), "00")
                mskPermisoEmbarque.SelectionStart = 3
                mskPermisoEmbarque.SelectionLength = 3
                e.SuppressKeyPress = True
            ElseIf Len(Trim(mskPermisoEmbarque.Text)) < 6 Then
                aux = Mid(mskPermisoEmbarque.Text, 3, 3)
                If Val(aux) = 0 Then Exit Sub
                mskPermisoEmbarque.Text = Mid(mskPermisoEmbarque.Text, 1, 2) & Format(Val(aux), "000")
                mskPermisoEmbarque.SelectionStart = 7
                mskPermisoEmbarque.SelectionLength = 4
                e.SuppressKeyPress = True
            ElseIf Len(Trim(mskPermisoEmbarque.Text)) < 10 Then
                aux = Mid(mskPermisoEmbarque.Text, 6, 4)
                If Val(aux) = 0 Then Exit Sub
                mskPermisoEmbarque.Text = Mid(mskPermisoEmbarque.Text, 1, 5) & Format(aux, "0000")
                mskPermisoEmbarque.SelectionStart = 12
                mskPermisoEmbarque.SelectionLength = 6
                e.SuppressKeyPress = True
            ElseIf Len(Trim(mskPermisoEmbarque.Text)) < 16 Then
                aux = Mid(mskPermisoEmbarque.Text, 10, 6)
                If Val(aux) = 0 Then Exit Sub
                mskPermisoEmbarque.Text = Mid(mskPermisoEmbarque.Text, 1, 9) & Format(Val(aux), "000000")
                mskPermisoEmbarque.SelectionStart = 19
                mskPermisoEmbarque.SelectionLength = 1
                e.SuppressKeyPress = True
            End If

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

    Private Sub FrmOperacionExportacion_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtImporte.Focus()
    End Sub

    Private Sub cboTipoExp_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoExp.SelectedValueChanged
        If cboTipoExp.SelectedValue IsNot Nothing Then
            Dim selectedValue As Integer
            If Integer.TryParse(cboTipoExp.SelectedValue.ToString(), selectedValue) Then
                Select Case selectedValue
                    Case 1 'factura
                        mskNroCompExp.Visible = True
                        mskPermisoEmbarque.Visible = False
                        txtInstrCobranza.Visible = False
                        mskFacturaProforma.Visible = False
                    Case 2 'Permiso de Embarque
                        mskNroCompExp.Visible = False
                        mskPermisoEmbarque.Visible = True
                        txtInstrCobranza.Visible = False
                        mskFacturaProforma.Visible = False
                    Case 3 'Instr. de Cobranza
                        mskNroCompExp.Visible = False
                        mskPermisoEmbarque.Visible = False
                        txtInstrCobranza.Visible = True
                        mskFacturaProforma.Visible = False
                    Case 5 'Factura Proforma
                        mskNroCompExp.Visible = False
                        mskPermisoEmbarque.Visible = False
                        txtInstrCobranza.Visible = False
                        mskFacturaProforma.Visible = True
                End Select
            End If
        End If
    End Sub


    Private Sub txtImporte_KeyDown(sender As Object, e As KeyEventArgs) Handles txtImporte.KeyDown
        If e.KeyCode = Keys.Enter Then
            If (mskFacturaProforma.Visible = True) Then
                mskFacturaProforma.Focus()
            ElseIf (mskNroCompExp.Visible = True) Then
                mskNroCompExp.Focus()
            ElseIf (mskPermisoEmbarque.Visible = True) Then
                mskPermisoEmbarque.Focus()
            ElseIf (txtInstrCobranza.Visible = True) Then
                txtInstrCobranza.Focus()
            End If
        End If
    End Sub

    Private Sub mskFacturaProforma_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskFacturaProforma.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnAceptar.Focus()
        End If
    End Sub

    Private Sub mskNroCompExp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskNroCompExp.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnAceptar.Focus()
        End If
    End Sub

    Private Sub mskPermisoEmbarque_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskPermisoEmbarque.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnAceptar.Focus()
        End If
    End Sub
End Class