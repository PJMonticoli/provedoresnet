Imports Guna.UI2.WinForms
Imports Controles
Imports Guna.UI2.Native.WinApi
Imports ClasesGlobal
Imports System.Runtime.InteropServices

Public Class FrmBuscarProveedor
    Dim controles As New ControlerProveedor
    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub btnBuscarRazonSocial_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim salida As Long
        Dim RstAux As DataTable
        Dim CadAux As String

        ModuloGrillas.InicializarGrillaProveedor(dgvProveedores)
        CadAux = Trim(txtCadena.Text)

        If Len(CadAux) > 0 Then
            salida = controles.Filtrar(CadAux, RstAux)

            If salida = -1 Then
                MsgBox("Se produjo un error al generar la búsqueda.", MsgBoxStyle.Critical, "Sistema")
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos con estas características.", MsgBoxStyle.Information, "Sistema")
                txtCadena.Text = ""
                Exit Sub
            End If

            With RstAux
                If .Rows.Count > 0 Then
                    dgvProveedores.SuspendLayout()

                    For Each row As DataRow In .Rows
                        CadAux = Format(row("NroProveedor"), "000000")
                        dgvProveedores.Rows.Add(Trim(row("RSocial")), CadAux, row("Direccion"), row("Localidad"), row("ConvMulti"))
                    Next

                    dgvProveedores.ResumeLayout()
                    dgvProveedores.Focus()

                    ' Seleccionar automáticamente la primera fila
                    dgvProveedores.Rows(1).Selected = True
                End If
            End With


            RstAux = Nothing
        End If
    End Sub
    Private Sub txtCadena_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCadena.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnBuscarRazonSocial_Click(sender, e)
        End If
    End Sub


    Private Sub dgvProveedores_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProveedores.CellDoubleClick
        RealizarAccionDobleClick(e.RowIndex)
    End Sub

    Private Sub dgvProveedores_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvProveedores.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim selectedRowIndex As Integer = dgvProveedores.SelectedCells(0).RowIndex
            RealizarAccionDobleClick(selectedRowIndex)
        End If
    End Sub

    Private Sub RealizarAccionDobleClick(rowIndex As Integer)
        If rowIndex >= 0 Then
            VariablesGlobales.razonSocial = dgvProveedores.Rows(rowIndex).Cells(0).Value.ToString()
            VariablesGlobales.numeroProveedor = dgvProveedores.Rows(rowIndex).Cells(1).Value.ToString()
            VariablesGlobales.direccion = dgvProveedores.Rows(rowIndex).Cells(2).Value.ToString()
            VariablesGlobales.localidad = dgvProveedores.Rows(rowIndex).Cells(3).Value.ToString()
            VariablesGlobales.condicionIva = dgvProveedores.Rows(rowIndex).Cells(4).Value.ToString()
            Me.Close()
        End If
    End Sub

    Private Sub dgvProveedores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProveedores.CellContentClick

    End Sub

    Private Sub txtCadena_TextChanged(sender As Object, e As EventArgs) Handles txtCadena.TextChanged
        If txtCadena.Text.Trim = "" Then
            ' Limpiar visualmente las filas del DataGridView
            dgvProveedores.Rows.Clear()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmBuscarProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2Panel1.Focus()
        dgvProveedores.DataSource = Nothing
        txtCadena.Text = ""
    End Sub

    Private Sub FrmBuscarProveedor_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtCadena.Focus()
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