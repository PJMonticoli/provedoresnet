Imports ClasesGlobal
Imports Controles

Public Class FrmBuscarInsumos
    Dim frmPrincipal As FrmCreditoDebito
    Dim controles As New ControlerProveedor
    Dim controlInsumo As New ControlerInsumo
    Private Sub TxtFiltro_TextChanged(sender As Object, e As EventArgs) Handles TxtFiltro.TextChanged
        If TxtFiltro.Text.Trim = "" Then
            ' Limpiar visualmente las filas del DataGridView
            dgvListadoInsumo.Rows.Clear()
        End If
    End Sub
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub Btnminizar_Click(sender As Object, e As EventArgs) Handles Btnminizar.Click
        Me.Close()
    End Sub


    Sub New(principal As FrmCreditoDebito)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        frmPrincipal = principal
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub TxtFiltro_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnBuscarInsumos_Click(sender, e)
        End If
    End Sub

    Private Sub btnBuscarInsumos_Click(sender As Object, e As EventArgs) Handles btnBuscarInsumo.Click
        Dim salida As Long
        Dim RstAux As DataTable
        Dim CadAux As String
        ModuloGrillas.InicializarGrillaInsumos(dgvListadoInsumo)
        CadAux = TxtFiltro.Text.Trim().Replace(".", "")

        If Len(CadAux) > 0 Then
            salida = controlInsumo.BuscarDatos(CadAux, RstAux)

            If salida = -1 Then
                MsgBox("Se produjo un error al generar la búsqueda.", MsgBoxStyle.Critical, "Sistema")
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos con estas características.", MsgBoxStyle.Information, "Sistema")
                TxtFiltro.Text = ""
                Exit Sub
            End If

            With RstAux
                If .Rows.Count > 0 Then
                    dgvListadoInsumo.SuspendLayout()

                    For Each row As DataRow In .Rows
                        ' Formatear el código según el patrón #.##.###.###.####
                        Dim codInsumoFormateado As String = String.Format("{0}.{1}.{2}.{3}.{4}",
                                                                    Trim(row("CodInsumo")).Substring(0, 1),
                                                                    Trim(row("CodInsumo")).Substring(1, 2),
                                                                    Trim(row("CodInsumo")).Substring(3, 3),
                                                                    Trim(row("CodInsumo")).Substring(6, 3),
                                                                    Trim(row("CodInsumo")).Substring(9, 4))

                        dgvListadoInsumo.Rows.Add(codInsumoFormateado, row("Descripcion"))
                    Next

                    dgvListadoInsumo.ResumeLayout()
                    dgvListadoInsumo.Focus()

                    ' Seleccionar automáticamente la primera fila
                    dgvListadoInsumo.Rows(1).Selected = True
                End If
            End With

            RstAux = Nothing
        End If
    End Sub


    Private Sub dgvListadoInsumo_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvListadoInsumo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim selectedRowIndex As Integer = dgvListadoInsumo.SelectedCells(0).RowIndex
            RealizarAccionDobleClick(selectedRowIndex)
        End If
    End Sub

    Private Sub RealizarAccionDobleClick(rowIndex As Integer)
        If dgvListadoInsumo.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgvListadoInsumo.SelectedRows(0)

            VariablesGlobales.CodInsumo = selectedRow.Cells(0).Value?.ToString()
            VariablesGlobales.DescInsumo = selectedRow.Cells(1).Value?.ToString()
            Me.Close()
        End If
    End Sub


    Private Sub dgvListadoInsumo_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListadoInsumo.CellDoubleClick
        RealizarAccionDobleClick(e.RowIndex)
    End Sub
    Private Sub FrmBuscarInsumos_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        TxtFiltro.Focus()
    End Sub
End Class