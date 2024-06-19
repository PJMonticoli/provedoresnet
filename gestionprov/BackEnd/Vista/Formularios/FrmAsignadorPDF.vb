Imports System.IO
Imports System.Net.WebRequestMethods
Imports System.Runtime.InteropServices
Imports Controles
Imports iText.Kernel.Pdf
Imports iText.Kernel.Utils
Imports iText.Layout
Public Class FrmAsignadorPDF
    Dim ruta As String
    Dim parte() As String
    Public sFile1 As String
    Public sFile2 As String
    Public sFile3 As String
    Public sFile4 As String
    Public sFile5 As String
    Dim MaxPDF As String
    Dim control As New ControlerPDF
    Public NroInterno As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        ActualizarVista()
    End Sub


    Private Sub frmVisualizadorPDF_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        If MaxPDF = 1 Then
            System.IO.File.Delete(sFile1)
        Else
            If MaxPDF = 2 Then
                System.IO.File.Delete(sFile1)
                System.IO.File.Delete(sFile2)
            Else
                If MaxPDF = 3 Then
                    System.IO.File.Delete(sFile1)
                    System.IO.File.Delete(sFile2)
                    System.IO.File.Delete(sFile3)
                Else
                    If MaxPDF = 4 Then
                        System.IO.File.Delete(sFile1)
                        System.IO.File.Delete(sFile2)
                        System.IO.File.Delete(sFile3)
                        System.IO.File.Delete(sFile4)
                    Else
                        If MaxPDF = 5 Then
                            System.IO.File.Delete(sFile1)
                            System.IO.File.Delete(sFile2)
                            System.IO.File.Delete(sFile3)
                            System.IO.File.Delete(sFile4)
                            System.IO.File.Delete(sFile5)
                        Else
                        End If
                    End If
                End If
            End If
        End If


    End Sub

    Private Sub ActualizarVista()
        ruta = "\\server1\f\IMAGENES COMPROBANTES\2015\Temporales\"
        ' Obtener la lista de archivos en el directorio
        Dim archivosEnDirectorio As String() = Directory.GetFiles(ruta)

        If archivosEnDirectorio.Length = 0 Then
            MessageBox.Show("No se encontraron documentos escaneados en la carpeta temporal", "Error Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
        Else
            ' Iterar sobre los archivos y agregar los archivos PDF al DataGridView
            For Each archivo As String In archivosEnDirectorio
                Dim fileInfo As New FileInfo(archivo)
                If fileInfo.Extension.ToLower() = ".pdf" Then
                    dgvArchivos.Rows.Add(0, fileInfo.FullName, "")
                End If
            Next
        End If
    End Sub

    Private Sub FrmAsignadorPDF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InicializarDgvArchivo()
        Dim dt As DataTable = control.consultaPDF(NroInterno)
        ' Verifica si se obtuvieron datos
        If dt.Rows.Count > 0 Then
            ' Asigna los valores a los TextBox
            txtNroInterno.Text = NroInterno.ToString()
            txtRSocial.Text = dt.Rows(0)("RSocial").ToString()
            dtpFechaComp.Value = Convert.ToDateTime(dt.Rows(0)("FechaComp"))
            txtImporte.Text = FormatNumber(dt.Rows(0)("TotalComprobante").ToString(), 2)
        Else
            MessageBox.Show("No se encontraron datos para el número interno proporcionado.")
        End If
        ActualizarVista()
    End Sub

    Private Sub dgvArchivos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArchivos.CellContentClick
        ' Verificar si la celda actual no es nula y si es de tipo botón
        If dgvArchivos.CurrentCell IsNot Nothing AndAlso TypeOf dgvArchivos.CurrentCell Is DataGridViewButtonCell Then
            ' Verificar si la fila actual no es nula
            If dgvArchivos.CurrentRow IsNot Nothing Then
                ' Obtener el valor de la celda "Archivo"
                Dim archivoCellValue As Object = dgvArchivos.CurrentRow.Cells("Archivo").Value

                ' Verificar si el valor de la celda "Archivo" no es nulo
                If archivoCellValue IsNot Nothing Then
                    ' Convertir el valor a una cadena y asignarlo al control VisualizadorPDF
                    VisualizadorPDF.src = archivoCellValue.ToString()
                Else
                    ' Manejar el caso en que el valor de la celda "Archivo" es nulo
                    MessageBox.Show("El valor de la celda 'Archivo' es nulo.", "Error Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                ' Manejar el caso en que la fila actual es nula
                MessageBox.Show("La fila actual es nula.", "Error Fila", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub


    Private Sub InicializarDgvArchivo()
        With dgvArchivos
            .ColumnHeadersHeight = 30
        End With
    End Sub

    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        Dim o As Integer

        For i = 0 To dgvArchivos.Rows.Count - 1
            If dgvArchivos.Rows(i).Cells("Check").Value = True Then
                If o < 5 Then
                    o = o + 1
                Else
                    MessageBox.Show("No se pueden seleccionar más de 5 Archivos", "Atencío!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
        Next

        ' Creamos una lista de archivos para concatenar

        Dim Lista As New List(Of String)

        MaxPDF = 0
        For i = 0 To dgvArchivos.Rows.Count - 1
            If dgvArchivos.Rows(i).Cells("Check").Value = True Then
                'MsgBox("Marca")

                Select Case MaxPDF
                    Case 0
                        sFile1 = Trim(dgvArchivos.Rows(i).Cells("Archivo").Value)
                        MaxPDF = 1
                    Case 1
                        sFile2 = Trim(dgvArchivos.Rows(i).Cells("Archivo").Value)
                        MaxPDF = 2
                    Case 2
                        sFile3 = Trim(dgvArchivos.Rows(i).Cells("Archivo").Value)
                        MaxPDF = 3
                    Case 3
                        sFile4 = Trim(dgvArchivos.Rows(i).Cells("Archivo").Value)
                        MaxPDF = 4
                    Case 4
                        sFile5 = Trim(dgvArchivos.Rows(i).Cells("Archivo").Value)
                        MaxPDF = 5
                    Case Else
                        MessageBox.Show("No se pueden seleccionar más de 5 Archivos", "Error Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub

                End Select
            Else
                'MsgBox("No tener en cuenta.")
            End If
        Next



        ' Los añadimos a la lista

        If MaxPDF = 1 Then
            Lista.Add(sFile1)
        Else
            If MaxPDF = 2 Then
                Lista.Add(sFile1)
                Lista.Add(sFile2)
            Else
                If MaxPDF = 3 Then
                    Lista.Add(sFile1)
                    Lista.Add(sFile2)
                    Lista.Add(sFile3)
                Else
                    If MaxPDF = 4 Then
                        Lista.Add(sFile1)
                        Lista.Add(sFile2)
                        Lista.Add(sFile3)
                        Lista.Add(sFile4)
                    Else
                        If MaxPDF = 5 Then
                            Lista.Add(sFile1)
                            Lista.Add(sFile2)
                            Lista.Add(sFile3)
                            Lista.Add(sFile4)
                            Lista.Add(sFile5)
                        Else
                        End If
                    End If
                End If
            End If
        End If

        ' Nombre del documento resultante
        Dim yearpath As String = Year(dtpFechaComp.Value)
        Dim rutaDirectorio As String = "\\Server1\F\IMAGENES COMPROBANTES\" & yearpath
        Dim sFileJoin As String
        If Directory.Exists(rutaDirectorio) Then
            sFileJoin = rutaDirectorio & "\" & txtNroInterno.Text & ".pdf"
        Else
            Directory.CreateDirectory(rutaDirectorio)
        End If

        Dim pdfWriter As PdfWriter = New PdfWriter(sFileJoin)
        Dim pdfDocument As New PdfDocument(pdfWriter)
        Dim pdfMerger As New PdfMerger(pdfDocument)

        Try
            For Each file In Lista
                Dim pdfReader As New PdfReader(file)
                Dim pdfDocumentSource As New PdfDocument(pdfReader)
                pdfMerger.Merge(pdfDocumentSource, 1, pdfDocumentSource.GetNumberOfPages())
                pdfReader.Close()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error uniendo los pdf", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            ' Cerramos el documento
            pdfDocument.Close()
        End Try

        Me.Close()
    End Sub
    Private Sub btnMinimizar_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click
        Me.WindowState = FormWindowState.Minimized
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
