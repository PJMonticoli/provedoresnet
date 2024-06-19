Imports ClasesGlobal
Imports Controles

Public Class FrmAltaIngresoPendiente
    Dim frmInsumo As New FrmBuscarInsumos(FrmCreditoDebito)
    Dim frmCC As New FrmBuscarCC
    Dim controlInsumo As New ControlerInsumo
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmAltaComprobante_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtTotal.Enabled = False
    End Sub

    Private Sub btnBuscarCodInsumo_Click(sender As Object, e As EventArgs) Handles btnBuscarCodInsumo.Click
        frmInsumo.ShowDialog()
        mskCodInsumo.Text = VariablesGlobales.CodInsumo
        txtDescripcion.Text = VariablesGlobales.DescInsumo
        VariablesGlobales.DescInsumo = ""
        VariablesGlobales.CodInsumo = ""
        txtCantidad.Focus()
    End Sub


    Private Sub btnBuscarCC_Click(sender As Object, e As EventArgs) Handles btnBuscarCC.Click
        frmCC.ShowDialog()
        txtCentroCosto.Text = VariablesGlobales.CodCentroCosto
        VariablesGlobales.CodCentroCosto = ""
    End Sub

    Private Sub txtPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecio.KeyDown
        If Not String.IsNullOrWhiteSpace(txtCantidad.Text) AndAlso Not String.IsNullOrWhiteSpace(txtPrecio.Text) Then
            Dim cantidad As Double
            Dim precio As Double

            If e.KeyCode = Keys.Enter Then
                ' Reemplazar "." por "," en el texto del precio
                Dim precioTexto As String = txtPrecio.Text.Replace(".", ",")
                Dim cantidadTexto As String = txtCantidad.Text.Replace(".", ",")
                ' Verifica si los valores ingresados son números válidos
                If Double.TryParse(cantidadTexto, cantidad) AndAlso Double.TryParse(precioTexto, precio) Then
                    txtTotal.Text = Format(cantidad * precio, "N2")
                    txtCentroCosto.Focus()
                Else
                    MessageBox.Show("Ingrese valores numéricos válidos en Cantidad y Precio.", "Error de conversión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub



    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPrecio.Focus()
        End If
    End Sub

    Private Sub formatearCodInsumo()

        Select Case mskCodInsumo.TextLength
            Case 1
                mskCodInsumo.Text &= "."
            Case 3, 4
                If mskCodInsumo.TextLength = 3 Then
                    mskCodInsumo.Text = mskCodInsumo.Text.Substring(0, 2) & "0" & mskCodInsumo.Text.Substring(2, 1) & "."
                Else
                    mskCodInsumo.Text &= "."
                End If
            Case 6, 7, 8
                If mskCodInsumo.TextLength = 6 Then
                    mskCodInsumo.Text = mskCodInsumo.Text.Substring(0, 5) & "00" & mskCodInsumo.Text.Substring(5, 1) & "."
                ElseIf mskCodInsumo.TextLength = 7 Then
                    mskCodInsumo.Text = mskCodInsumo.Text.Substring(0, 5) & "0" & mskCodInsumo.Text.Substring(5, 2) & "."
                Else
                    mskCodInsumo.Text &= "."
                End If
            Case 10, 11, 12
                If mskCodInsumo.TextLength = 10 Then
                    mskCodInsumo.Text = mskCodInsumo.Text.Substring(0, 9) & "00" & mskCodInsumo.Text.Substring(9, 1) & "."
                ElseIf mskCodInsumo.TextLength = 11 Then
                    mskCodInsumo.Text = mskCodInsumo.Text.Substring(0, 9) & "0" & mskCodInsumo.Text.Substring(9, 2) & "."
                Else
                    mskCodInsumo.Text &= "."
                End If
            Case 14, 15, 16
                If mskCodInsumo.TextLength = 14 Then
                    mskCodInsumo.Text = mskCodInsumo.Text.Substring(0, 13) & "000" & mskCodInsumo.Text.Substring(13, 1)
                ElseIf mskCodInsumo.TextLength = 15 Then
                    mskCodInsumo.Text = mskCodInsumo.Text.Substring(0, 13) & "00" & mskCodInsumo.Text.Substring(13, 2)
                Else
                    mskCodInsumo.Text = mskCodInsumo.Text.Substring(0, 13) & "0" & mskCodInsumo.Text.Substring(13, 3)
                End If
        End Select
        mskCodInsumo.SelectionStart = mskCodInsumo.Text.Length
    End Sub
    Private Sub mskCodInsumo_KeyDown(sender As Object, e As KeyEventArgs) Handles mskCodInsumo.KeyDown
        If e.KeyCode = Keys.Enter And mskCodInsumo.TextLength < 17 Then
            If mskCodInsumo.Text.Replace(".", "").Trim() = "" Then
                ' Abre el formulario FrmBuscarInsumos
                Dim frmInsumo As New FrmBuscarInsumos(FrmCreditoDebito)
                frmInsumo.ShowDialog()

                ' Actualiza los campos con la información seleccionada
                mskCodInsumo.Text = VariablesGlobales.CodInsumo
                txtDescripcion.Text = VariablesGlobales.DescInsumo

                ' Limpia las variables globales
                VariablesGlobales.DescInsumo = ""
                VariablesGlobales.CodInsumo = ""
                txtCantidad.Focus()
                Exit Sub
            End If
            formatearCodInsumo()
        ElseIf mskCodInsumo.TextLength = 17 And e.KeyCode = Keys.Enter Then
            ' Entra en esta rama si mskCodInsumo no está vacío
            Dim codInsumo As String = mskCodInsumo.Text.Trim().Replace(".", "")
            Dim tablaResultado As New DataTable()

            ' Aquí deberías tener un método en tu controlador ControllerInsumo para buscar por código
            Dim resultadoBusqueda As Integer = controlInsumo.BuscarDatos(codInsumo, tablaResultado)

            If resultadoBusqueda = -1 Then
                MessageBox.Show("Error al realizar la búsqueda del insumo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf resultadoBusqueda = 0 Then
                MessageBox.Show("No se encontró un insumo con el código proporcionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ' Actualiza los campos con la información encontrada
                ' mskCodInsumo.Text = tablaResultado.Rows(0)("codInsumo").ToString()
                txtDescripcion.Text = tablaResultado.Rows(0)("Descripcion").ToString()
                txtCantidad.Focus()
            End If
            ' Consumir el evento para evitar que se procese más de una vez
            e.Handled = True
        End If
    End Sub



    Private Sub txtNroIngreso_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNroIngreso.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtNroIngreso.Text.Trim() = "" Then
                txtNroIngreso.Text = "000000000"
            Else
                Dim nroingresoformateado As String = txtNroIngreso.Text.ToString().PadLeft(9, "0"c)
                txtNroIngreso.Text = nroingresoformateado
            End If
            mskCodInsumo.SelectAll()
            mskCodInsumo.Focus()
        End If
    End Sub

    Private Sub txtCentroCosto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCentroCosto.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtCentroCosto.Text = "" Then
                frmCC.ShowDialog()
                txtCentroCosto.Text = VariablesGlobales.CodCentroCosto
                VariablesGlobales.CodCentroCosto = ""
                If btnRegistrar.Visible Then
                    btnRegistrar.Focus()
                Else
                    BtnActualizar.Focus()
                End If
                e.SuppressKeyPress = True ' Evita que se propague el evento de tecla
            Else
                Dim centrosCosto As String() = {"600", "601", "602", "603", "604", "605", "606", "607", "608", "609", "610", "611", "612", "613", "614", "999"}

                If Not centrosCosto.Contains(txtCentroCosto.Text.Trim()) Then
                    MessageBox.Show("Ingrese un Centro de Costo válido.", "Centro de costo no válido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtCentroCosto.Text = ""
                    txtCentroCosto.Focus()
                    e.SuppressKeyPress = True
                Else
                    If btnRegistrar.Visible Then
                        btnRegistrar.Focus()
                    Else
                        BtnActualizar.Focus()
                    End If
                End If
            End If
        End If
    End Sub


    Private Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged
        If txtCantidad.Text.Trim() = "" Or txtPrecio.Text.Trim() = "" Then
            txtTotal.Text = ""
        Else
            If Not String.IsNullOrWhiteSpace(txtCantidad.Text) AndAlso Not String.IsNullOrWhiteSpace(txtPrecio.Text) Then
                Dim cantidad As Double
                Dim precio As Double
                Dim precioTexto As String = txtPrecio.Text.Replace(".", ",")
                Dim cantidadTexto As String = txtCantidad.Text.Replace(".", ",")
                ' Verifica si los valores ingresados son números válidos
                If Double.TryParse(cantidadTexto, cantidad) AndAlso Double.TryParse(precioTexto, precio) Then
                    txtTotal.Text = Format(cantidad * precio, "N2")
                Else
                    MessageBox.Show("Ingrese valores numéricos válidos en Cantidad y Precio.", "Error de conversión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        ' Validar que los campos necesarios estén llenos
        If String.IsNullOrWhiteSpace(mskCodInsumo.Text) OrElse
           String.IsNullOrWhiteSpace(txtDescripcion.Text) OrElse
           String.IsNullOrWhiteSpace(txtCantidad.Text) OrElse
           String.IsNullOrWhiteSpace(txtPrecio.Text) OrElse
           String.IsNullOrWhiteSpace(txtTotal.Text) OrElse
           String.IsNullOrWhiteSpace(txtCentroCosto.Text) Then
            MessageBox.Show("Complete todos los campos antes de registrar.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Armar un array con los valores de los campos

        VariablesGlobales.filanueva = {
            txtNroIngreso.Text,
            mskCodInsumo.Text.Trim().Replace(",", "."),
            txtDescripcion.Text,
            txtCantidad.Text,
            txtPrecio.Text,
            txtTotal.Text,
            txtCentroCosto.Text,
            "u"
        }

        LimpiarCampos()
        Me.Close()
    End Sub
    Private Sub LimpiarCampos()
        ' Método para limpiar los TextBox después de registrar
        txtNroIngreso.Clear()
        mskCodInsumo.Clear()
        txtDescripcion.Clear()
        txtCantidad.Clear()
        txtPrecio.Clear()
        txtTotal.Clear()
        txtCentroCosto.Clear()

    End Sub

    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click

        If (MessageBox.Show("Esta seguro de guardar los cambios realizados?", "Guardar Cambios", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.OK) Then
            VariablesGlobales.filanueva = {
            txtNroIngreso.Text,
            mskCodInsumo.Text.Trim().Replace(",", "."),
            txtDescripcion.Text,
            txtCantidad.Text,
            txtPrecio.Text,
            txtTotal.Text,
            txtCentroCosto.Text
            }
            Me.Close()
        End If
    End Sub

    Private Sub txtCantidad_MouseClick(sender As Object, e As MouseEventArgs) Handles txtCantidad.MouseClick
        txtCantidad.SelectAll()
    End Sub

    Private Sub txtPrecio_MouseClick(sender As Object, e As MouseEventArgs) Handles txtPrecio.MouseClick
        txtPrecio.SelectAll()
    End Sub

    Private Sub txtCentroCosto_MouseClick(sender As Object, e As MouseEventArgs) Handles txtCentroCosto.MouseClick
        txtCentroCosto.SelectAll()
    End Sub

    Private Sub txtNroIngreso_MouseClick(sender As Object, e As MouseEventArgs) Handles txtNroIngreso.MouseClick
        txtNroIngreso.SelectAll()
    End Sub

    Private Sub mskCodInsumo_TextChanged(sender As Object, e As EventArgs) Handles mskCodInsumo.TextChanged
        Dim codigoInsumoSinFormato As String = mskCodInsumo.Text.Replace(" ", "").Replace(",", "")
        ' Verifica si el código de insumo sin formato está vacío
        If String.IsNullOrEmpty(codigoInsumoSinFormato) Then
            txtDescripcion.Text = ""
        End If
    End Sub

    Private Sub txtPrecio_TextChanged(sender As Object, e As EventArgs) Handles txtPrecio.TextChanged
        If Not String.IsNullOrWhiteSpace(txtCantidad.Text) AndAlso Not String.IsNullOrWhiteSpace(txtPrecio.Text) Then
            Dim cantidad As Double
            Dim precio As Double
            Dim precioTexto As String = txtPrecio.Text.Replace(".", ",")
            Dim cantidadTexto As String = txtCantidad.Text.Replace(".", ",")
            ' Verifica si los valores ingresados son números válidos
            If Double.TryParse(cantidadTexto, cantidad) AndAlso Double.TryParse(precioTexto, precio) Then
                txtTotal.Text = Format(cantidad * precio, "N2")
            Else
                MessageBox.Show("Ingrese valores numéricos válidos en Cantidad y Precio.", "Error de conversión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub txtNroIngreso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNroIngreso.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            MsgBox("Debe ingresar valores numéricos únicamente.", vbExclamation, "Atención!")
            e.Handled = True
        End If
    End Sub

    Private Sub txtCentroCosto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCentroCosto.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            MsgBox("Debe ingresar valores numéricos únicamente.", vbExclamation, "Atención!")
            e.Handled = True
        End If
    End Sub
End Class