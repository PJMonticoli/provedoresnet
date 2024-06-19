Imports System.Security
Imports Controles
Imports Guna.UI2.AnimatorNS

Public Class FrmBuscarComprobante
    Dim controles As New ControlerProveedor
    Private frmPrincipal As FrmPrincipal
    Sub New(principal As FrmPrincipal)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        frmPrincipal = principal
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub TxtFiltro_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnBuscarProveedor_Click(sender, e)
        End If
    End Sub


    Private Sub FrmBuscarComprobante_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ModuloGrillas.InicializarGrillaComprobante(dgvListadoComprobante)
    End Sub

    Private Sub btnBuscarProveedor_Click(sender As Object, e As EventArgs) Handles btnBuscarProveedor.Click
        Dim salida As Long
        Dim RstAux As DataTable
        Dim CadAux As String
        ModuloGrillas.InicializarGrillaComprobante(dgvListadoComprobante)
        CadAux = Trim(TxtFiltro.Text)

        If Len(CadAux) > 0 Then
            salida = controles.FiltrarComprobante(CadAux, RstAux)

            If salida = -1 Then
                MessageBox.Show("Se produjo un error al generar la búsqueda.", "Error Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            ElseIf salida = 0 Then
                MessageBox.Show("No existen datos con estas características.", "Error Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtFiltro.Text = ""
                Exit Sub
            End If

            With RstAux
                If .Rows.Count > 0 Then
                    dgvListadoComprobante.SuspendLayout()

                    For Each row As DataRow In .Rows
                        CadAux = Format(row("NroComp"), "000000000000")
                        dgvListadoComprobante.Rows.Add(Trim(row("RSocial")), CadAux, row("NroInterno"), row("FechaCarga"))
                    Next

                    dgvListadoComprobante.ResumeLayout()
                    dgvListadoComprobante.Focus()

                    ' Seleccionar automáticamente la primera fila
                    dgvListadoComprobante.Rows(1).Selected = True
                End If
            End With

            RstAux = Nothing
        End If
    End Sub
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub Btnminizar_Click(sender As Object, e As EventArgs) Handles Btnminizar.Click
        Me.Close()
    End Sub

    Private Sub TxtFiltro_TextChanged(sender As Object, e As EventArgs) Handles TxtFiltro.TextChanged
        If TxtFiltro.Text.Trim = "" Then
            ' Limpiar visualmente las filas del DataGridView
            dgvListadoComprobante.Rows.Clear()
        End If
    End Sub

    Private Sub dgvListadoComprobante_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListadoComprobante.CellDoubleClick
        frmPrincipal.BuscarDatos(dgvListadoComprobante.Rows(e.RowIndex).Cells(2).Value.ToString())
        Me.Close()
    End Sub

    Private Sub dgvListadoComprobante_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvListadoComprobante.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' Verificar si hay una celda seleccionada
            If dgvListadoComprobante.SelectedCells.Count > 0 Then
                ' Obtener el índice de la fila seleccionada
                Dim rowIndex As Integer = dgvListadoComprobante.SelectedCells(0).RowIndex

                ' Llamar a la función BuscarDatos con el valor de la celda
                frmPrincipal.BuscarDatos(dgvListadoComprobante.Rows(rowIndex).Cells(2).Value.ToString())

                ' Cerrar el formulario actual
                Me.Close()
            End If
        End If
    End Sub

    Private Sub FrmBuscarComprobante_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        TxtFiltro.Focus()
    End Sub
End Class