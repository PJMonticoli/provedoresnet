Imports Guna.UI2.WinForms
Imports System.IO
Imports System.Runtime.InteropServices

Public Class FrmImagenComprobante
    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim nPixTypes As Integer
        Const CF_BITMAP As Integer = 2
        Dim Fichero As String

        Clipboard.Clear()

        If Clipboard.ContainsImage() Then
            ' Utiliza el control Guna2PictureBox en lugar de PictureBox.
            Dim guna2PictureBox As New Guna.UI2.WinForms.Guna2PictureBox()

            ' Obtiene la imagen del portapapeles.
            Dim imageFromClipboard As Image = Clipboard.GetImage()

            ' Asigna la imagen al control Guna2PictureBox.
            guna2PictureBox.Image = imageFromClipboard

            ' Ruta donde se guardará la imagen.
            Fichero = "F:\IMAGENES COMPROBANTES\" & Trim(txtNroInterno.Text) & ".jpg"

            ' Verifica si el archivo ya existe y elimínalo.
            If File.Exists(Fichero) Then
                File.Delete(Fichero)
            End If

            ' Guarda la imagen en el archivo.
            imageFromClipboard.Save(Fichero, System.Drawing.Imaging.ImageFormat.Jpeg)

            MessageBox.Show("Imagen Guardada Correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Puedes cerrar el formulario después de guardar la imagen.
            Me.Close()
        Else
            MessageBox.Show("No se pudo obtener la imagen del portapapeles.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
End Class