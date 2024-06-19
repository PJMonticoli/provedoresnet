Imports System.Globalization
Imports System.Runtime.InteropServices
Imports Controles
Imports GrapeCity.Viewer.Common.Model

Public Class FrmCierre

    Dim controlCierre As New ControlerCierre
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim salida As Long
        Dim ultimoDiaMes As Integer
        Dim Diacierre As String
        Dim rec As New DataTable

        If CboMes.SelectedIndex = -1 Then
            MsgBox("Mes de cierre inválido.", vbInformation)
            Exit Sub
        End If
        If cboAnio.SelectedIndex = -1 Then
            MsgBox("Año de cierre inválido.", vbInformation)
            Exit Sub
        End If

        If (MsgBox("¿Desea confirmar el cierre de mes para " & CboMes.Text.ToUpper() & " del " & Val(cboAnio.Text) & " ?", vbYesNo, "Cierre de Mes")) = vbNo Then
            Exit Sub
        End If


        Select Case CboMes.SelectedIndex
            Case 2
                If IsDate("29/02/" & Val(cboAnio.Text)) Then
                    ultimoDiaMes = 29
                Else
                    ultimoDiaMes = 28
                End If
            Case 4, 6, 9, 11
                ultimoDiaMes = 30
            Case Else
                ultimoDiaMes = 31
        End Select

        ' Asegurarse de que el día sea válido para el mes y el año
        ultimoDiaMes = Math.Min(ultimoDiaMes, DateTime.DaysInMonth(Val(cboAnio.Text), CboMes.SelectedIndex + 1))

        Diacierre = New DateTime(Val(cboAnio.Text), CboMes.SelectedIndex + 1, ultimoDiaMes)

        controlCierre.consultaCierreMes(Diacierre, rec)

        salida = controlCierre.ActualizarMesImputacion(CboMes.SelectedIndex + 1, Val(cboAnio.Text), ultimoDiaMes)
        If salida = -1 Then
            MsgBox("Error al intentar cerrar el mes.", vbCritical)
            Exit Sub
        ElseIf salida = 0 Then
            MsgBox("No existen comprobantes del mes " & CboMes.Text.ToUpper() & " del " & cboAnio.Text & " o el mismo ya está cerrado.", vbInformation)

        Else
            MsgBox($"Se cerró el mes " & CboMes.Text & " de " & cboAnio.Text & " con éxito.", vbInformation)
            Me.Close()
        End If
    End Sub

    Private Sub FrmCierre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ModuloComboBox.cargarCombo(CboMes, cboAnio)
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