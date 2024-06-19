Imports System.Runtime.InteropServices
Imports Controles
Imports iText.Kernel.Pdf.Canvas.Wmf

Public Class FrmAltaCondPago
    Dim control As New ControlerProveedor
    Dim frmPrincipal As New FrmPrincipal
    Public Sub New(frmPrincipal)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        frmPrincipal = frmPrincipal
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim i As Long
        Dim texto As String
        Dim tabla As New DataTable
        If txtDescripcion.Text <> "" Then
            i = control.NuevaCondicionPago(tabla, Replace(UCase(txtDescripcion.Text), "'", "´"))
            If i = -1 Then
                MessageBox.Show("Se produjo un error al grabar la nueva condición de pago. Contáctese con el depto. de sistemas.", "Erro al Grabar!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                texto = txtDescripcion.Text
                txtDescripcion.Text = ""
                MessageBox.Show("Se grabó exitosamente la nueva condición de pago :" & texto, "Guardado Exitoso!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ModuloComboBox.CargarCboCondiciones(frmPrincipal.cboCondPago)
                Me.Close()
            End If
        Else
            MessageBox.Show("Debe Ingresar una descripción válida.", "Campos Vacios!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
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