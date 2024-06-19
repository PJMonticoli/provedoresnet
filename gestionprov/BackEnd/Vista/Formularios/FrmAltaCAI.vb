Imports System.Runtime.InteropServices
Imports Controles
Imports iText.Kernel.Pdf.Canvas.Wmf

Public Class FrmAltaCAI
    Dim control As New ControlerProveedor
    Dim FrmPrincipal As FrmPrincipal
    Sub New(ByRef frm As FrmPrincipal)
        InitializeComponent()
        FrmPrincipal = frm
    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim i As Long
        If cboDescripcion.SelectedIndex < 0 Then
            MessageBox.Show("Debe Cargar una Descripción de comprobante Válida.", "Error Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If cboTipo.SelectedIndex < 0 Then
            MessageBox.Show("Debe Cargar un tipo de comprobante Válida.", "Error Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Not IsDate(dtpVto.Value) Then
            MessageBox.Show("Debe Cargar una fecha de vencimiento Válida.", "Error Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Val(txtProveedor.Text) <= 0 Then
            MessageBox.Show("Debe Cargar un Proveedor Válido.", "Error Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Trim(txtCAI.Text) = "" Then
            MessageBox.Show("Debe Cargar un CAI Válido.", "Error Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim tabla As New DataTable
        i = control.NuevoProveedorCAI(tabla, txtProveedor.Text, txtCAI.Text, CDate(dtpVto.Value), cboTipo.SelectedValue, cboDescripcion.SelectedValue)
        If i = -1 Then
            MessageBox.Show("Se produjo un error al grabar el nuevo cai. Contáctese con el depto. de sistemas.", "Error Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            MessageBox.Show($"Se grabó exitosamente el nuevo cai: {txtCAI.Text.Trim}.", "Error Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ModuloFunciones.Buscarproveedor("", txtProveedor.Text, FrmPrincipal.mskNroProveedor, FrmPrincipal.txtProveedor, FrmPrincipal.txtCAI, FrmPrincipal.mskVtoCAI, FrmPrincipal.cboTipo, FrmPrincipal.cboDescripcion, tabla)
            Me.Close()
        End If
    End Sub
    Private Sub FrmAltaCAI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ModuloComboBox.CargarCboDescCAI(cboDescripcion, cboTipo)
        dtpVto.Value = Now
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmAltaCAI_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtCAI.Focus()
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
End Class