Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing.Reader
Imports System.Globalization
Imports System.Linq.Expressions
Imports System.Reflection.Emit
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Web.UI.WebControls
'Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports ClasesGlobal
Imports Controles
Imports GrapeCity.ActiveReports.Design.DdrDesigner.Services.Infrastructure.ReportData.DataSourceException
Imports GrapeCity.ActiveReports.SectionReportModel
Imports GrapeCity.DataVisualization.Options
Imports Guna.UI2.WinForms
Imports Modelos
Imports Org.BouncyCastle.Bcpg

Public Class FrmPrincipal
    Dim tabla As New DataTable
    Dim control As New ControlerProveedor
    Dim controlLogin As New ControlerLogin
    Dim controlCotizacion As New ControlerCotizacion
    Dim controlComprobante As New ControlerComprobante
    Dim controlCierre As New ControlerCierre
    Public usuario As New ModeloUsuario
    Dim usarAfip As Boolean
    Dim permisomodificar As Boolean = True
    Dim Estado As String = ""
    Dim limpiezagrilla As Boolean
    Public elementosSeleccionados As New List(Of ModeloOrdendeCompraSeleccion)()
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

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
#Region "INICIO / Validacion De Permisos"
    Private Sub FormPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ModuloComboBox.CargarCboDescripcion(cboDescripcion, cboTipo)
        ModuloComboBox.CargarCboProvincia(cboProvincia)
        ModuloComboBox.CargarCboCondiciones(cboCondPago)
        ControlarAfip(tabla, usuario, usarAfip)
        ValidarPermisos() ' Confirmar permisos SAU
        habilitarcontroles("LIMPIAR")
        ModuloGrillas.InicializarGrilla(dgvListado, dgvExportacion)
        ModuloGrillas.InicializarGrillaExp(dgvExportacion)
        ModuloGrillas.InicializarGrillaIB(DgvIB)
        ModuloGrillas.InicializarGrillaOrdenCarga(dgvOrdenDeCarga)
        GPanel1.Enabled = True
        GPanel5.BackColor = Color.FromArgb(129, 143, 180)
        btnImagen.Enabled = False

    End Sub


    Private Sub ValidarPermisos()
        tabla = controlLogin.RecuperarPermisoUsuario(Me.usuario.CodUser, 160, 6) '1
        If tabla Is Nothing Then
            btnNuevo.Enabled = False
        End If
        tabla = controlLogin.RecuperarPermisoUsuario(Me.usuario.CodUser, 162, 6)
        If tabla Is Nothing Then
            btnModificar.Enabled = False
            permisomodificar = False
        End If

        tabla = controlLogin.RecuperarPermisoUsuario(Me.usuario.CodUser, 163, 6) '3
        If tabla Is Nothing Then
            btnInformes.Enabled = False
        End If

        tabla = controlLogin.RecuperarPermisoUsuario(Me.usuario.CodUser, 165, 6) '4
        If tabla Is Nothing Then
            btnGuardar.Enabled = False
        End If

        tabla = controlLogin.RecuperarPermisoUsuario(Me.usuario.CodUser, 172, 6) '6
        If tabla Is Nothing Then
            btnBuscar.Enabled = False
        End If

        tabla = controlLogin.RecuperarPermisoUsuario(Me.usuario.CodUser, 173, 6) '7
        If tabla Is Nothing Then
            btnNDNCAFIP.Enabled = False
        End If

        tabla = controlLogin.RecuperarPermisoUsuario(Me.usuario.CodUser, 174, 6) '8
        If tabla Is Nothing Then
            btnNDNCINT.Enabled = False
        End If

        tabla = controlLogin.RecuperarPermisoUsuario(Me.usuario.CodUser, 175, 6) '9
        btnNuevo.Enabled = True
        btnInformes.Enabled = True
        btnBuscar.Enabled = True
        btnNDNCAFIP.Enabled = True
        btnNDNCINT.Enabled = True
        btnCancelar.Enabled = True
        btnSalir.Enabled = True
        btnModificar.Enabled = False
        btnGuardar.Enabled = False
    End Sub

    Private Sub habilitarcontroles(ByRef opcion As String)
        '**********************************
        ' MANEJO DE CONTROLES DE PANTALLA
        '**********************************
        Dim flag As Integer
        Select Case opcion
            Case "NUEVO"
                LimpiarControles()
                GPanel1.Enabled = False
                GPanel2.Enabled = True
                GPanel3.Enabled = True
                GPanel4.Enabled = True
                GPanel5.Enabled = True
                GPanel6.Enabled = True
                btnNuevo.Enabled = False
                btnModificar.Enabled = False
                btnGuardar.Enabled = True
                btnInformes.Enabled = False
                btnNDNCAFIP.Enabled = False
                btnNDNCINT.Enabled = True
                btnSalir.Enabled = True

                lblCotMonedaEx.Visible = False
                lblMoneda.Visible = True
                dgvListado.ReadOnly = True
                DgvIB.ReadOnly = True
                txtBaseImp.Enabled = True
                txtPercepcion.Enabled = True
                cboProvincia.Enabled = True
                txtProveedor.Enabled = True
                btnBuscarProveedor.Enabled = True
                txtCAI.Enabled = True
                mskVtoCAI.Enabled = True
                txtCodBarra.Enabled = True
                mskNroProveedor.Enabled = True
                txtTotalPercepciones.Enabled = False
                cboProvincia.SelectedValue = 18
                dgvOrdenDeCarga.ReadOnly = False
                txtPartesalida.Enabled = True
                Txtvalor.Enabled = True
                rbtAlicNormal.Checked = True
                'lo habilita únicamente si es factura

                If cboDescripcion.SelectedIndex = 1 Then
                    dgvOrdenDeCarga.Visible = True
                End If
            Case "MODIFICAR"
                GPanel1.Enabled = True
                mskNroProveedor.Enabled = False
                btnBuscarProveedor.Enabled = False
                GPanel2.Enabled = True
                GPanel3.Enabled = True
                GPanel4.Enabled = True
                GPanel5.Enabled = True
                GPanel6.Enabled = True
                txtTotalComp.Enabled = False
                txtTotalImp.Enabled = False
                txtTotalGrav.Enabled = False
                txtIVAProd.Enabled = False
                'dgvListado.ReadOnly = False
                ModuloGrillas.ConfigurarEdicionColumnas(dgvListado)
                DgvIB.ReadOnly = True
                dgvListado.Columns(12).Visible = False
                'lo habilita únicamente si es factura, o crédito débito anticipo de guma
                If (cboDescripcion.SelectedIndex = 1 Or cboDescripcion.SelectedIndex = 11 Or cboDescripcion.SelectedIndex = 13) And Strings.Left(Me.mskNroComprobante.Text, 4) = "4000" Then
                    dgvOrdenDeCarga.Enabled = True
                Else
                    dgvOrdenDeCarga.Enabled = False
                End If

                txtCAI.Enabled = True
                mskVtoCAI.Enabled = True
                cboDescripcion.Focus()



            Case "LIMPIAR"
                LimpiarControles()

            Case "BUSQUEDA"
                GPanel1.Enabled = True
                mskNroInterno.Enabled = True
                mskFecha.Enabled = False
                txtProveedor.Enabled = True
                btnBuscarProveedor.Enabled = True
                GPanel2.Enabled = False
                GPanel3.Enabled = False
                GPanel4.Enabled = False

                dgvListado.ReadOnly = False
                DgvIB.ReadOnly = False

                dgvOrdenDeCarga.Visible = False
                btnImagen.Enabled = False
            Case "GRABADO"
                GPanel1.Enabled = True
                mskNroInterno.Enabled = False
                mskFecha.Enabled = False
                txtProveedor.Enabled = True
                btnBuscarProveedor.Enabled = True
                GPanel2.Enabled = False
                GPanel3.Enabled = False
                GPanel4.Enabled = False
                GPanel5.Enabled = False
                dgvListado.ReadOnly = False
                DgvIB.ReadOnly = False
                btnNuevo.Enabled = True
                btnModificar.Enabled = True
                btnGuardar.Enabled = False
        End Select
    End Sub

    Private Sub LimpiarControles()
        mskNroProveedor.BackColor = Color.White
        txtProveedor.BackColor = Color.White
        cboTipo.BackColor = Color.White
        cboDescripcion.BackColor = Color.White
        mskNroComprobante.BackColor = Color.White
        mskVtoCAI.BackColor = Color.White
        txtCodBarra.Text = ""
        txtCAI.Text = ""
        mskVtoCAI.Text = "00/00/0000"
        mskVtoCAI.Enabled = True
        txtCAI.Enabled = True
        txtCodBarra.Enabled = True

        mskFecha.Text = Now.ToString("dd/MM/yyyy")
        mskFechaComp.Text = Now.ToString("dd/MM/yyyy")
        mskFechaIngreso.Text = Now.ToString("dd/MM/yyyy")
        mskFechaVto.Text = Now.ToString("dd/MM/yyyy")
        mskNroInterno.Text = ""
        txtObservaciones.Text = ""
        txtProveedor.Text = ""
        mskNroComprobante.Text = ""
        cboCondPago.SelectedValue = 33
        cboDescripcion.SelectedValue = 1
        cboProvincia.SelectedValue = 1
        cboTipo.SelectedValue = 1
        txtImpProd.Text = ""
        txtIVAProd.Text = ""
        txtImpNoImp.Text = ""
        txtPercepGanancia.Text = ""
        txtPercepIva.Text = ""
        txtBaseImp.Text = ""
        txtPercepIB.Text = ""
        txtTotalPercepciones.Text = ""
        txtCotizacion.Text = 0
        txtTotalComp.Text = ""
        txtGrav21.Text = ""
        txtImp21.Text = ""
        txtTotalGrav.Text = ""
        txtTotalImp.Text = ""
        txtPartesalida.Text = ""
        Txtvalor.Text = ""
        txtGrav105.Text = ""
        txtGrav27.Text = ""
        txtGrav75.Text = ""
        txtImp105.Text = ""
        txtImp27.Text = ""
        txtImp75.Text = ""

        cboProvincia.SelectedIndex = -1
        txtGrav105.Enabled = False
        txtGrav27.Enabled = False
        txtBaseImp.Enabled = False
        cboProvincia.Enabled = False
        txtPercepcion.Enabled = False
        txtPartesalida.Enabled = False
        Txtvalor.Enabled = False
        lblMoneda.Visible = True
        lblCotMonedaEx.Visible = False
        GPanel4.Enabled = True
        mskNroInterno.Enabled = True
        mskFecha.Enabled = False

        txtProveedor.Enabled = True
        btnBuscarProveedor.Enabled = True
        GPanel1.Enabled = True

        GPanel2.Enabled = False
        GPanel3.Enabled = False
        GPanel6.Enabled = True
        GPanel5.Enabled = False
        lblOP.Visible = False

        lblCompAlfa.Visible = False
        mskNroComprobanteAlfa.Visible = False
        dgvExportacion.Visible = False

        txtGrav105.Enabled = True
        txtImp105.Enabled = True
        txtGrav21.Enabled = True
        txtImp21.Enabled = True
        txtGrav27.Enabled = True
        txtImp27.Enabled = True
        txtGrav75.Enabled = True
        txtImp75.Enabled = True
        txtImpProd.Enabled = True
        txtIVAProd.Enabled = True
        txtPercepGanancia.Enabled = True
        txtPercepIva.Enabled = True
        txtPercepIB.Enabled = True

        chkPorCuentaTercero.Checked = False
        btnNuevo.Enabled = True
        btnInformes.Enabled = True
        btnBuscar.Enabled = True
        btnNDNCAFIP.Enabled = True
        btnNDNCINT.Enabled = True
        btnCancelar.Enabled = True
        btnSalir.Enabled = True
        btnModificar.Enabled = False
        btnGuardar.Enabled = False
        dgvListado.DataSource = Nothing
        dgvListado.Rows.Clear()

        dgvOrdenDeCarga.DataSource = Nothing
        dgvOrdenDeCarga.Rows.Clear()
        dgvExportacion.DataSource = Nothing
        dgvExportacion.Rows.Clear()
        ModuloGrillas.InicializarGrillaParteSalida(dgvOrdenDeCarga)
        DgvIB.DataSource = Nothing
        DgvIB.Rows.Clear()
        mskNroProveedor.Text = ""
        VariablesGlobales.numeroProveedor = ""
        VariablesGlobales.razonSocial = ""
    End Sub


#End Region


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        limpiezagrilla = True
        habilitarcontroles("LIMPIAR")
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        limpiezagrilla = True
        If (MessageBox.Show("¿Esta seguro que desea cerrar la aplicacion?", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)) = DialogResult.OK Then
            'Cambiar estado memoria en uso 
            Me.Close()
            End
        End If
    End Sub

    Private Sub mskNroProveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskNroProveedor.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            If Val(mskNroProveedor.Text) > 0 Then
                ModuloFunciones.Buscarproveedor(Estado, Val(mskNroProveedor.Text), mskNroProveedor, txtProveedor, txtCAI, mskVtoCAI, cboTipo, cboDescripcion, tabla)
                mskNroComprobante.Focus()
                If Val(mskNroProveedor.Text) > 0 Then
                    Dim valoresPermitidos As List(Of String) = New List(Of String) From {"640", "641", "642", "664", "706", "938", "996", "1601"}

                    If valoresPermitidos.Contains(mskNroProveedor.Text) Then
                        GPanel4.Width = 10980
                        'GPanel2.Width = 10980
                        GPanel1.Width = 10980
                    Else
                        GPanel4.Width = 10020
                        'GPanel2.Width = 10020
                        GPanel1.Width = 10020
                    End If
                End If
            End If
        End If
        dgvOrdenDeCarga.ReadOnly = False

    End Sub





    Public Sub btnBuscarProveedor_Click(sender As Object, e As EventArgs) Handles btnBuscarProveedor.Click
        If (mskNroProveedor.Text = "") Then
            FrmBuscarProveedor.ShowDialog()
            If VariablesGlobales.numeroProveedor <> Nothing And VariablesGlobales.razonSocial <> Nothing Then
                mskNroProveedor.Text = VariablesGlobales.numeroProveedor
                txtProveedor.Text = VariablesGlobales.razonSocial
            End If
        Else
            ModuloFunciones.Buscarproveedor(Estado, Val(mskNroProveedor.Text), mskNroProveedor, txtProveedor, txtCAI, mskVtoCAI, cboTipo, cboDescripcion, tabla)

        End If
    End Sub

    Private Sub mskNroProveedor_TextChanged(sender As Object, e As EventArgs) Handles mskNroProveedor.TextChanged
        If (mskNroProveedor.Text = "") Then
            txtProveedor.Text = ""
        End If
    End Sub








    Private Sub dgvListado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListado.CellDoubleClick
        ' Verifica si la celda en la que se hizo doble clic es editable
        dgvListado.ReadOnly = True
    End Sub

#Region "Hace FUNCIONAR LA GRILLA COMO VBA6 "

    Private Sub dgvListado_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListado.CellEndEdit
        ' Deshabilita la edición al finalizar la edición de la celda
        ' ModuloFunciones.calcularTotalComprobante(Me)
        If e.ColumnIndex = 3 OrElse e.ColumnIndex = 4 OrElse e.ColumnIndex = 5 Then

            ' Verifica si hay al menos una celda seleccionada
            If dgvListado.SelectedCells.Count > 0 Then
                Dim celdaSeleccionada As DataGridViewCell = dgvListado.SelectedCells(0)
                Dim filaSeleccionada As DataGridViewRow

                ' Asegúrate de que hay al menos una fila seleccionada
                If dgvListado.SelectedRows.Count > 0 Then
                    ' Asegúrate de que la celda seleccionada es válida
                    If celdaSeleccionada IsNot Nothing AndAlso celdaSeleccionada.RowIndex < dgvListado.Rows.Count Then
                        filaSeleccionada = dgvListado.Rows(celdaSeleccionada.RowIndex)

                        ' Asegúrate de que la fila seleccionada no es nula
                        If filaSeleccionada IsNot Nothing Then
                            ' Asegúrate de que la columna especificada existe en la fila
                            If e.ColumnIndex < filaSeleccionada.Cells.Count Then
                                ' Reemplaza los puntos por comas en las celdas 3 y 4
                                filaSeleccionada.Cells(3).Value = filaSeleccionada.Cells(3).Value?.ToString().Replace(".", ",")
                                If filaSeleccionada.Cells(4).Value IsNot Nothing AndAlso filaSeleccionada.Cells(4).Value.ToString().Trim() <> "" Then
                                    filaSeleccionada.Cells(4).Value = filaSeleccionada.Cells(4).Value.ToString().Replace(".", ",")
                                End If

                                ' Realiza la multiplicación y aplica formato "N2"
                                Dim valorCelda3 As Decimal
                                Dim valorCelda4 As Decimal

                                If Decimal.TryParse(filaSeleccionada.Cells(3).Value?.ToString(), valorCelda3) AndAlso Decimal.TryParse(filaSeleccionada.Cells(4).Value?.ToString(), valorCelda4) Then
                                    Dim resultadoMultiplicacion As Decimal = valorCelda3 * valorCelda4
                                    filaSeleccionada.Cells(5).Value = resultadoMultiplicacion.ToString("N2")

                                    ' Verifica si el valor de la celda no es nulo antes de realizar cálculos
                                    If filaSeleccionada.Cells(5).Value IsNot Nothing AndAlso IsNumeric(filaSeleccionada.Cells(5).Value) Then
                                        ModuloFunciones.calcularTotalComprobante(Me)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

            End If
        End If
    End Sub


    'Private Sub Grilla_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvListado.RowValidating
    '     ModuloFunciones.calcularTotalComprobante(Me)
    '    If limpiezagrilla Then
    '        Exit Sub
    '    Else

    '        If dgvListado.Focused = False Then
    '            If dgvListado.CurrentCell.ColumnIndex = 3 Then
    '                AbrirFormulario()
    '                e.Cancel = True
    '                SendKeys.Send("{TAB}")
    '            Else
    '                e.Cancel = False
    '            End If
    '        Else
    '            AbrirFormulario()
    '            e.Cancel = True
    '            SendKeys.Send("{TAB}")
    '        End If
    '    End If
    'End Sub




    'Private Sub dgvListado_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvListado.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        AbrirFormulario()
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub


    'Private Sub AbrirFormulario()
    '    If dgvListado.CurrentCell Is Nothing OrElse dgvListado.CurrentCell.Value Is Nothing OrElse dgvListado.CurrentCell.Value.ToString() = "" OrElse dgvListado.ReadOnly = True Then
    '        Select Case dgvListado.CurrentCell.ColumnIndex
    '            Case 1
    '                ' Código para abrir el formulario FrmBuscarInsumos
    '                Dim frmInsumo As New FrmBuscarInsumos(FrmCreditoDebito)
    '                frmInsumo.ShowDialog()
    '                dgvListado.CurrentCell.Value = VariablesGlobales.CodInsumo
    '                dgvListado(2, dgvListado.CurrentCell.RowIndex).Value = VariablesGlobales.DescInsumo
    '                VariablesGlobales.CodInsumo = ""
    '                VariablesGlobales.DescInsumo = ""
    '                SendKeys.Send("{TAB}")
    '                dgvListado.ReadOnly = False
    '                Exit Sub
    '            Case 6
    '                ' Código para abrir el formulario FrmBuscarCC
    '                Dim frmCentroCosto As New FrmBuscarCC
    '                frmCentroCosto.ShowDialog()
    '                dgvListado.CurrentCell.Value = VariablesGlobales.CodCentroCosto
    '                dgvListado(6, dgvListado.CurrentCell.RowIndex).Value = VariablesGlobales.CodCentroCosto
    '                VariablesGlobales.CodCentroCosto = ""
    '                dgvListado.ReadOnly = False
    '                Exit Sub
    '        End Select
    '    End If
    'End Sub
#End Region

    Private Sub dgvListado_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListado.RowLeave
        ' Por ejemplo, si deseas permitir el acceso a la fila haciendo clic
        dgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub


#Region "YA ESTA FUNCIONAL"
    Private Sub mskNroComprobante_KeyDown(sender As Object, e As KeyEventArgs) Handles mskNroComprobante.KeyDown
        Dim aux As String
        If e.KeyCode = Keys.Enter Then
            ' Eliminar espacios en blanco y guiones existentes
            Dim inputText As String = mskNroComprobante.Text.Trim().Replace(" ", "").Replace("-", "")

            ' Rellenar con ceros a la izquierda según la longitud del texto
            If inputText.Length <= 4 Then
                mskNroComprobante.Text = Format(Val(inputText), "0000")
                mskNroComprobante.SelectionStart = 5
                mskNroComprobante.SelectionLength = 8
                e.Handled = True
            ElseIf inputText.Length < 12 Then
                ' Número de factura
                aux = Mid(inputText, 5, 8)
                mskNroComprobante.Text = Mid(mskNroComprobante.Text, 1, 4) & Format(Val(aux), "00000000")
                cboDescripcion.Focus()
                e.Handled = True
            End If
        End If
    End Sub



    Private Sub txtcodBarra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodBarra.KeyPress
        Dim RstAux As DataTable
        Dim CadAux As String
        Dim CuitAux As String
        Dim TipoCompAux As String
        Dim PrefijoAux As String
        Dim CaiAux As String
        Dim VtoCaiAux As String
        Dim salida As Long

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            If Len(Trim(txtCodBarra.Text)) = 40 Then
                CadAux = Trim(txtCodBarra.Text)
                CuitAux = Mid(CadAux, 1, 11)
                TipoCompAux = Mid(CadAux, 12, 2)
                PrefijoAux = Mid(CadAux, 14, 4)
                CaiAux = Mid(CadAux, 18, 14)
                VtoCaiAux = Mid(CadAux, 32, 8)
            Else
                CadAux = Trim(txtCodBarra.Text)
                CuitAux = Mid(CadAux, 1, 11)
                TipoCompAux = Mid(CadAux, 12, 2)
                PrefijoAux = Mid(CadAux, 14, 5)
                CaiAux = Mid(CadAux, 20, 14)
                VtoCaiAux = Mid(CadAux, 34, 8)
            End If

            If Len(Trim(txtCodBarra.Text)) = 40 Then
                If Val(CuitAux) > 0 Then
                    '************************************
                    ' OBTIENE RAZON SOCIAL DEL PROVEEDOR
                    '************************************
                    salida = control.BuscarProveedorPorCuit(CStr(Val(CuitAux)), RstAux)
                    If RstAux.Rows.Count > 0 Then
                        If Val(CuitAux) = Val("30504131889") Then
                            If Val(PrefijoAux) = 39 Then
                                mskNroProveedor.Text = Format(11, "000000")
                                txtProveedor.Text = "QUICKFOOD S.A. S.J."
                            Else
                                mskNroProveedor.Text = Format(5, "000000")
                                txtProveedor.Text = "QUICKFOOD S.A. VM"
                            End If
                        Else
                            mskNroProveedor.Text = Format(RstAux.Rows(0)("NroProveedor"), "000000")
                            txtProveedor.Text = Trim(RstAux.Rows(0)("RSocial"))
                        End If
                        mskNroProveedor.BackColor = Color.FromArgb(207, 233, 252)
                        txtProveedor.BackColor = Color.FromArgb(207, 233, 252)
                    Else
                        MsgBox("Proveedor no existente.", vbExclamation, "Tu Formulario")
                        mskNroProveedor.Text = Format(0, "000000")
                        txtProveedor.Text = ""
                        mskNroProveedor.Focus()
                        txtCodBarra.Text = ""
                        Exit Sub
                    End If

                Else
                    ' La fecha viene bien
                    mskVtoCAI.Text = Mid(VtoCaiAux, 1, 2) & "/" & Mid(VtoCaiAux, 3, 2) & "/" & Mid(VtoCaiAux, 5, 4)
                    mskVtoCAI.BackColor = Color.FromArgb(207, 233, 252)
                    mskNroComprobante.Focus()
                    mskVtoCAI.Enabled = False
                    txtCAI.Enabled = False
                    txtCodBarra.Enabled = False
                End If

            ElseIf Len(Trim(txtCodBarra.Text)) = 42 Then
                If Val(CuitAux) > 0 Then
                    ' OBTIENE RAZON SOCIAL DEL PROVEEDOR
                    salida = control.BuscarProveedorPorCuit(CStr(Val(CuitAux)), RstAux)
                    If RstAux.Rows.Count > 0 Then
                        If Val(CuitAux) = Val("30504131889") Then
                            If Val(PrefijoAux) = 39 Then
                                mskNroProveedor.Text = Format(11, "000000")
                                txtProveedor.Text = "QUICKFOOD S.A. S.J."
                            Else
                                mskNroProveedor.Text = Format(5, "000000")
                                txtProveedor.Text = "QUICKFOOD S.A. VM"
                            End If
                        Else
                            mskNroProveedor.Text = Format(RstAux.Rows(0)("NroProveedor"), "000000")
                            txtProveedor.Text = Trim(RstAux.Rows(0)("RSocial"))
                        End If
                        mskNroProveedor.BackColor = Color.FromArgb(207, 233, 252)
                        txtProveedor.BackColor = Color.FromArgb(207, 233, 252)
                    Else
                        MessageBox.Show("Proveedor no existente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        mskNroProveedor.Text = Format(0, "000000")
                        txtProveedor.Text = ""
                        mskNroProveedor.Focus()
                        txtCodBarra.Text = ""
                        Exit Sub
                    End If
                    RstAux.Clear()
                    RstAux = Nothing
                End If



                'Rellena el prefijo
                mskNroComprobante.Text = PrefijoAux & "        "
                mskNroComprobante.BackColor = Color.FromArgb(207, 233, 252)

                'Rellena CAI y Vto CAI
                txtCAI.Text = CaiAux
                txtCAI.BackColor = Color.FromArgb(207, 233, 252)
                If Val(Mid(VtoCaiAux, 5, 4)) <= 1231 Then
                    ' Hay que darla vuelta
                    mskVtoCAI.Text = Mid(VtoCaiAux, 7, 2) & "/" & Mid(VtoCaiAux, 5, 2) & "/" & Mid(VtoCaiAux, 1, 4)
                Else
                    ' La fecha viene bien
                    mskVtoCAI.Text = Mid(VtoCaiAux, 1, 2) & "/" & Mid(VtoCaiAux, 3, 2) & "/" & Mid(VtoCaiAux, 5, 4)
                End If
                mskVtoCAI.BackColor = Color.FromArgb(207, 233, 252)
                mskNroComprobante.Focus()
                mskVtoCAI.Enabled = False
                txtCAI.Enabled = False
                txtCodBarra.Enabled = False
            Else
                mskNroProveedor.Focus()
            End If
        End If
    End Sub


    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        habilitarcontroles("NUEVO")
        mskNroProveedor.Focus()
        Estado = "NUEVO"
        limpiezagrilla = False
        dgvListado.Columns(12).Visible = True
    End Sub


    Private Sub btnPañol_Click(sender As Object, e As EventArgs) Handles btnPañol.Click

        If mskNroProveedor.Text.Trim() = "" Then
            MsgBox("Debe ingresar un N° Proveedor valido", vbExclamation, "N° Proveedor invalido")
            mskNroProveedor.Focus()
        Else
            If elementosSeleccionados Is Nothing Then
                elementosSeleccionados = New List(Of ModeloOrdendeCompraSeleccion)
            End If
            Dim frm As New FrmPañol(Me)
            frm.id = CInt(mskNroProveedor.Text)
            frm.ShowDialog()
            cargarelementopañol()

        End If
    End Sub

    Private Sub btnPañol2_Click(sender As Object, e As EventArgs) Handles btnPañol2.Click
        If mskNroProveedor.Text.Trim() = "" Then
            MsgBox("Debe ingresar un N° Proveedor valido", vbExclamation, "N° Proveedor invalido")
            mskNroProveedor.Focus()
        Else
            If elementosSeleccionados Is Nothing Then
                elementosSeleccionados = New List(Of ModeloOrdendeCompraSeleccion)
            End If
            Dim frm As New FrmPañol(Me)
            frm.id = CInt(mskNroProveedor.Text)
            frm.TipoMovimiento = "FACTURA"
            frm.ShowDialog()
            cargarelementopañol()
        End If
    End Sub

    Private Sub cargarelementopañol()
        ' Crear una DataTable y llenarla con los elementos seleccionados
        Dim tabla As New DataTable
        With tabla
            .Columns.Add("idDetalle", GetType(Double))
            .Columns.Add("idMaterial", GetType(Double))
            .Columns.Add("Descripcion", GetType(String))
            .Columns.Add("Cantidad", GetType(Double))
            .Columns.Add("Precio", GetType(Decimal))
            .Columns.Add("codInsumo", GetType(String))
            .Columns.Add("codCentroCosto", GetType(Integer))
            .Columns.Add("NroComprobante", GetType(Integer))
            .Columns.Add("Total", GetType(Double))
        End With

        ' Agregar filas a la DataTable
        For Each elemento In elementosSeleccionados
            Dim filanueva As DataRow
            filanueva = tabla.NewRow
            filanueva!idDetalle = CDbl(elemento.Id)
            filanueva!idMaterial = CDbl(elemento.SupplyId)
            filanueva!Descripcion = elemento.Supply
            filanueva!cantidad = elemento.Quantity
            filanueva!precio = elemento.Cost
            filanueva!nroComprobante = CDbl(elemento.Number)
            filanueva!codInsumo = CDbl(elemento.InternalMaterialCode)
            filanueva!codCentroCosto = CInt(elemento.CostCenter)
            filanueva!total = CDbl(elemento.Total)
            tabla.Rows.Add(filanueva)
        Next

        ' Limpiar las filas existentes en el DataGridView
        dgvListado.Rows.Clear()

        ' Agregar las filas desde la DataTable al DataGridView
        For Each fila As DataRow In tabla.Rows
            Dim codInsumoFormateado As String = fila("codInsumo").ToString()
            codInsumoFormateado = ModuloFunciones.FormatCodigoInsumo(codInsumoFormateado)
            Dim idDetalle As String = fila("idDetalle").ToString().PadLeft(9, "0"c)
            dgvListado.Rows.Add(
        idDetalle,
        codInsumoFormateado,
        fila("Descripcion"),
        fila("Cantidad"),
        fila("Precio"),
        fila("Total"),
        fila("codCentroCosto"),
        "u",
        "",
        fila("NroComprobante")
    )
            Dim rowIndex As Integer = dgvListado.Rows.Count - 1
            dgvListado.Rows(rowIndex).Cells(7).Style.ForeColor = Color.Red
        Next
        ModuloFunciones.calcularTotalComprobante(Me)
        ModuloGrillas.formatearcolumna7(dgvListado)
        elementosSeleccionados = Nothing
    End Sub




    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim frm As New FrmBuscarComprobante(Me)
        frm.ShowDialog()
        If permisomodificar = True Then
            btnModificar.Enabled = True
            btnGuardar.Enabled = True
        End If
        dgvListado.Columns(12).Visible = False
    End Sub

    Public Sub BuscarDatos(NroInterno As Long)
        Dim salida As Long
        Dim rec As DataTable = New DataTable()
        Dim recPercepcionIB As DataTable = New DataTable()
        Dim recIngresos As DataTable = New DataTable()
        Dim recOC As DataTable = New DataTable()
        Dim recPS As DataTable = New DataTable()
        Dim recGastosExp As DataTable = New DataTable()
        Dim NroOP As Long
        Dim NroLiquidacion As Long
        Dim respuesta As String
        salida = control.Buscar(NroInterno, rec, recPercepcionIB, recIngresos, recOC, recPS, recGastosExp)

        If salida = -1 Then
            MsgBox("Se produjo un error al consultar datos de Comprobantes.", vbCritical, "Error en la consulta")
            habilitarcontroles("LIMPIAR")
            habilitarcontroles("BUSQUEDA")
        ElseIf salida = 0 Then
            MsgBox("No existen datos con estas características.", vbCritical, "Error en la consulta")
            habilitarcontroles("LIMPIAR")
            habilitarcontroles("BUSQUEDA")
        Else
            For Each row In rec.Rows


                respuesta = control.BuscarOP(NroInterno, NroOP, NroLiquidacion)
                If respuesta = -1 Then
                    MsgBox("Se produjo un error al consultar datos de Comprobantes.", vbCritical, "Error en la consulta")
                    habilitarcontroles("LIMPIAR")
                    habilitarcontroles("BUSQUEDA")
                ElseIf respuesta = 1 Then
                    ''mostrar el op y ademas no dejar modificar
                    Me.lblOP.Visible = True
                    'Me.lblOP = lblOP & NroOP & ",Liq.Nro:" & NroLiquidacion
                Else
                    Me.lblOP.Visible = False
                End If
                mskNroInterno.Text = Format(NroInterno)

                ModuloFunciones.buscarproveedorxcomp(row("NroComp").ToString(), tabla, mskNroProveedor, txtProveedor)


                cboDescripcion.SelectedValue = rec.Rows(0)("DescComp").ToString()


                If Not IsDBNull(rec.Rows(0)("DescCOmp")) Then ' Asumiendo que DescCOmp es el nombre de la columna
                    If {1, 3, 5, 11}.Contains(rec.Rows(0)("TipoGrupo")) Then
                        If DateDiff(DateInterval.Day, #01/03/2010#, Date.Now) >= 0 Then
                            btnImagen.Enabled = True
                        Else
                            btnImagen.Enabled = False
                        End If
                    Else
                        btnImagen.Enabled = False
                    End If
                End If


                cboTipo.SelectedValue = rec.Rows(0)("Tipocomp").ToString()

                If Not IsDBNull(rec.Rows(0)("condicionpago")) Then
                    Dim condicionPago As String = rec.Rows(0)("condicionpago").ToString()

                    ' Buscar el índice del elemento que coincide con el valor de condicionpago
                    Dim index As Integer = -1

                    cboCondPago.SelectedValue = rec.Rows(0)("condicionpago").ToString()
                    ' Establecer el valor seleccionado
                    If index <> -1 Then
                        cboCondPago.SelectedIndex = index
                    End If
                End If

                If rec.Rows.Count > 0 Then ' Check if there are rows in the DataTable
                    ' Now you can access row("ColumnName") instead of rec!ColumnName

                    If cboDescripcion.SelectedValue <> -1 Then
                        If cboDescripcion.SelectedValue = 1 Then
                            Call ModuloGrillas.InicializarGrillaParteSalida(dgvOrdenDeCarga)
                            mskNroComprobante.Text = Format(CLng(row("NroComp")), "000000000000")
                            If Not IsDBNull(row("nroCompAlfanumerico")) Then
                                GPanel1.Width = 10980
                                GPanel3.Width = 10980
                                ' GPanel2.Width = 10980
                                lblCompAlfa.Visible = True
                                mskNroComprobanteAlfa.Visible = True
                                mskNroComprobanteAlfa.Text = row("nroCompAlfanumerico").ToString()
                            End If
                        Else
                            mskNroComprobante.Text = Format(CLng(row("NroComp")), "000000000000")
                            If Not IsDBNull(row("nroCompAlfanumerico")) Then
                                GPanel1.Width = 10980
                                GPanel3.Width = 10980
                                ' GPanel2.Width = 10980
                                lblCompAlfa.Visible = True
                                mskNroComprobanteAlfa.Visible = True
                                mskNroComprobanteAlfa.Text = row("nroCompAlfanumerico").ToString()
                            End If
                        End If
                    End If

                    ' Continue updating other controls based on the DataRow
                    mskFechaComp.Text = Format(CDate(row("FechaComp")), "dd/MM/yyyy")
                    mskFecha.Text = Format(CDate(row("FechaCarga")), "dd/MM/yyyy")
                    mskFechaIngreso.Text = If(IsDBNull(row("FechaIngresoProveedores")), Format(CDate(row("FechaCarga")), "dd/MM/yyyy"), Format(CDate(row("FechaIngresoProveedores")), "dd/MM/yyyy"))
                    mskFechaVto.Text = Format(CDate(row("FechaVto")), "dd/MM/yyyy")
                    txtObservaciones.Text = Trim(row("Observacion").ToString())
                    txtIVAProd.Text = Format(CDec(row("IvaProd")), "0.00")
                    txtImpProd.Text = Format(CDec(row("ImporteProd")), "0.00")
                    txtPercepIva.Text = Format(CDec(row("PercepIva")), "0.00")
                    txtPercepGanancia.Text = Format(CDec(row("PercepGan")), "0.00")
                    txtTotalPercepciones.Text = Format(CDec(row("TotalPercepIB")), "0.00")
                    txtImpNoImp.Text = Format(CDec(row("ImporteNoImp")), "0.00")
                    txtTotalComp.Text = Format(CDec(row("TotalComprobante")), "0.00")
                    txtPercepIB.Text = Format(CDec(row("TotalPercepIB")), "0.00")

                    txtGrav21.Text = If(IsDBNull(row("Iva21")), Format(0, "0.00"), Format(CDec(row("Iva21")), "0.00"))
                    txtGrav105.Text = If(IsDBNull(row("Iva105")), Format(0, "0.00"), Format(CDec(row("Iva105")), "0.00"))
                    txtGrav27.Text = If(IsDBNull(row("Iva27")), Format(0, "0.00"), Format(CDec(row("Iva27")), "0.00"))
                    txtGrav75.Text = If(IsDBNull(row("Iva25")), Format(0, "0.00"), Format(CDec(row("Iva25")), "0.00"))
                    txtImp21.Text = If(IsDBNull(row("Imp21")), Format(0, "0.00"), Format(CDec(row("Imp21")), "0.00"))
                    txtImp105.Text = If(IsDBNull(row("Imp105")), Format(0, "0.00"), Format(CDec(row("Imp105")), "0.00"))
                    txtImp27.Text = If(IsDBNull(row("Imp27")), Format(0, "0.00"), Format(CDec(row("Imp27")), "0.00"))
                    txtImp75.Text = If(IsDBNull(row("Imp25")), Format(0, "0.00"), Format(CDec(row("Imp25")), "0.00"))
                    rbtAlicNormal.Visible = False
                    rbtAlicVarias.Visible = False
                    txtTotalGrav.Text = Format(CDec(row("ImporteProd")), "0.00")
                    txtTotalImp.Text = Format(CDec(row("IvaProd")), "0.00")
                    txtCotizacion.Text = If(IsDBNull(row("cotizacionDolar")), Format(0, "0.00"), If(CDec(row("cotizacionDolar")) = 0, Format(0, "0.00"), Format(CDec(row("cotizacionDolar")), "0.00")))

                    If row("NroComp").ToString().Trim().StartsWith("9041") Or row("NroComp").ToString().Trim().StartsWith("9042") Then
                        txtCAI.Text = If(Not IsDBNull(row("cae")), row("cae").ToString().Trim(), "")
                        mskVtoCAI.Text = If(Not IsDBNull(row("FechaVtoCAE")), Format(CDate(row("FechaVtoCAE")), "dd/MM/yyyy"), "00/00/0000")
                    Else
                        txtCAI.Text = If(Not IsDBNull(row("CAI")), row("CAI").ToString().Trim(), "")
                        mskVtoCAI.Text = If(Not IsDBNull(row("VtoCAI")), Format(CDate(row("VtoCAI")), "dd/MM/yyyy"), "00/00/0000")
                        txtCodBarra.Text = If(Not IsDBNull(row("CodBarra")), row("CodBarra").ToString().Trim(), "")
                    End If



                    chkPorCuentaTercero.Checked = If(CInt(row("PorCuentaDeTercero")) = 0, False, True)
                End If

                '************************************************************
                '-------- DATOS DE PERCEPCIONES DE INGRESOS BRUTOS.----------
                '************************************************************



                If recPercepcionIB Is Nothing Then
                    MsgBox("Se produjo un error al consultar datos del detalle de las percepciones del comprobante.", vbCritical, "Error en la consulta")
                    habilitarcontroles("LIMPIAR")
                    habilitarcontroles("BUSQUEDA")
                ElseIf recPercepcionIB.Rows.Count = 0 Then
                    ModuloGrillas.InicializarGrillaIB(DgvIB)
                Else
                    ' modulogrillas.InicializarGrillaIB(DgvIB)

                    For Each row2 As DataRow In recPercepcionIB.Rows
                        With cboProvincia
                            .SelectedIndex = -1
                            For i As Integer = 0 To .Items.Count - 1
                                If .Items(i).ToString() = row2("DescProvincia").ToString() Then
                                    .SelectedIndex = i
                                    'varprov = .Text
                                    .SelectedIndex = -1
                                    Exit For
                                End If
                            Next i
                        End With

                        DgvIB.Rows.Add()

                        ' Asegúrate de que las columnas existan antes de intentar acceder a ellas
                        If DgvIB.Columns.Contains("DescProvincia") AndAlso DgvIB.Columns.Contains("BaseImponible") AndAlso DgvIB.Columns.Contains("Percepcion") Then
                            ' Agregar valores a las columnas y aplico formato N2 = dos decimales
                            Dim rowIndex As Integer = DgvIB.Rows.Count - 1
                            DgvIB.Rows(rowIndex).Cells("DescProvincia").Value = row2("DescProvincia").ToString()
                            Dim baseImponible As Decimal
                            If Decimal.TryParse(row2("BaseImponible").ToString(), baseImponible) Then
                                DgvIB.Rows(rowIndex).Cells("BaseImponible").Value = baseImponible.ToString("N2")
                            End If
                            Dim percepcion As Decimal
                            If Decimal.TryParse(row2("Percepcion").ToString(), percepcion) Then
                                DgvIB.Rows(rowIndex).Cells("Percepcion").Value = percepcion.ToString("N2")
                            End If
                        Else
                            MsgBox("Las columnas necesarias no existen en DgvIB.", vbInformation)
                        End If

                    Next
                End If
                '************************************************************
                '----------- datos de ingresos de comprobante.---------------
                '************************************************************

                If recIngresos Is Nothing Then
                    MsgBox("Se produjo un error al consultar datos de ingresos del comprobante.", vbCritical)
                    habilitarcontroles("LIMPIAR")
                    habilitarcontroles("BUSQUEDA")
                ElseIf recIngresos.Rows.Count = 0 Then
                    Call ModuloGrillas.InicializarGrilla(dgvListado, dgvExportacion)
                Else
                    Call ModuloGrillas.InicializarGrilla(dgvListado, dgvExportacion)

                    For Each rowIngresos As DataRow In recIngresos.Rows
                        Dim sdata As String = ""

                        sdata = Format(CInt(Convert.ToString(rowIngresos("nroingreso"))), "000000000") & ";" &
        Mid(CStr(Convert.ToString(rowIngresos("codinsumo"))), 1, 1) & "." &
        Mid(CStr(Convert.ToString(rowIngresos("codinsumo"))), 2, 2) & "." &
        Mid(CStr(Convert.ToString(rowIngresos("codinsumo"))), 4, 3) & "." &
        Mid(CStr(Convert.ToString(rowIngresos("codinsumo"))), 7, 3) & "." &
        Mid(CStr(Convert.ToString(rowIngresos("codinsumo"))), 10, 4) & ";" &
        Trim(CStr(Convert.ToString(rowIngresos("descinsumo")))) & ";" &
        CStr(Convert.ToString(rowIngresos("cantidad"))) & ";" &
        Format(CDec(Convert.ToString(rowIngresos("precio"))), "0.000") & ";" &
        Format(CDec(Convert.ToString(rowIngresos("total"))), "0.00") & ";" &
        CStr(Convert.ToString(rowIngresos("ccosto"))) & ";" &
        "u" & ";" &
        Trim(CStr(Convert.ToString(rowIngresos("lugarentrega")))) & ";" &
        Trim(CStr(Convert.ToString(rowIngresos("idmaterial"))))

                        dgvListado.Rows.Add(sdata.Split(";"))
                        dgvListado.Rows(dgvListado.Rows.Count - 1).Cells(7).Style.ForeColor = Color.Green

                        ' Datos de exportación
                        If recGastosExp.Rows.Count > 0 Then
                            For Each rowGastosExp As DataRow In recGastosExp.Rows
                                If CInt(rowGastosExp("codingresoproveedores")) = CInt(rowIngresos("id")) Then
                                    dgvExportacion.Rows.Add($"{rowGastosExp("codcomprobante")}" & vbTab & $"{rowGastosExp("codmoneda")}" & vbTab & $"{rowGastosExp("tipocomp")}" & vbTab & $"{rowGastosExp("nrocomp")}" & vbTab & $"{Format(CDec(rowGastosExp("importe")), "0.000")}" & vbTab & $"{dgvListado.Rows.Count - 1}")
                                End If
                            Next
                        End If

                    Next
                End If


                '************************************************************
                '-------- datos de ordenes de carga.----------
                '*********** *************************************************

                dgvOrdenDeCarga.Visible = True
                For Each row3 As DataRow In rec.Rows
                    If Not IsDBNull(row3("desccomp")) AndAlso row3.Field(Of Integer)("desccomp") = 1 Then
                        lblParteSalida.Text = "Parte de Salida"
                        If recPS Is Nothing Then
                            MsgBox("Se produjo un error al consultar datos del parte de salida del comprobante.", vbCritical)
                            habilitarcontroles("limpiar")
                            habilitarcontroles("busqueda")
                        ElseIf recPS.Rows.Count = 0 Then
                            Call ModuloGrillas.InicializarGrillaParteSalida(dgvOrdenDeCarga)
                        Else
                            Call ModuloGrillas.InicializarGrillaParteSalida(dgvOrdenDeCarga)
                            For Each psRow As DataRow In recPS.Rows
                                If Not IsDBNull(psRow("nropartesalida")) AndAlso psRow.Field(Of Integer)("nropartesalida") <> 0 Then
                                    Dim sdata As String = psRow("nropartesalida").ToString() & ";" & psRow("valor").ToString()
                                    'dgvOrdenDeCarga.Rows.Add(sgformatcharseparatedvalue, sdata, ";")
                                End If
                            Next
                        End If
                    Else
                        lblParteSalida.Text = "Orden de Carga"
                        If recOC Is Nothing Then
                            MsgBox("Se produjo un error al consultar datos de la orden de carga del comprobante.", vbCritical)
                            habilitarcontroles("limpiar")
                            habilitarcontroles("busqueda")
                        ElseIf recOC.Rows.Count = 0 Then
                            Call ModuloGrillas.InicializarGrillaOrdenCarga(dgvOrdenDeCarga)
                        Else
                            Call ModuloGrillas.InicializarGrillaOrdenCarga(dgvOrdenDeCarga)

                            For Each ocRow As DataRow In recOC.Rows
                                If Not IsDBNull(ocRow("nroordencarga")) AndAlso ocRow.Field(Of Integer)("nroordencarga") <> 0 Then
                                    Dim sdata As String = ocRow("nroordencarga").ToString()
                                    'Me.dgvOrdenDeCarga.Rows.Add(sgformatcharseparatedvalue, sdata, ";")
                                End If
                            Next
                        End If
                    End If
                Next
            Next
        End If

        habilitarcontroles("GRABADO")
        rec.Dispose()
        rec = Nothing

    End Sub





    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        habilitarcontroles("LIMPIAR")
        habilitarcontroles("LIMPIAR") 'agrego dos veces la llamada al metodo para que solucionar la limpieza al 100% de todos los campos
        limpiezagrilla = True
    End Sub

    Private Sub mskNroInterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskNroInterno.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Val(mskNroInterno.Text) >= 2147483647 Then
                MessageBox.Show("N° de interno no válido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Val(mskNroInterno.Text) > 0 AndAlso Val(mskNroInterno.Text) < 2147483646 Then
                BuscarDatos(Val(mskNroInterno.Text))
                If permisomodificar = True Then
                    btnModificar.Enabled = True
                    btnGuardar.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub btnOperaciones_Click(sender As Object, e As EventArgs) Handles btnOperaciones.Click
        Try
            Dim numeroProveedor As Integer
            Dim frm As New FrmOperaciones(Me)
            If Not Integer.TryParse(mskNroProveedor.Text, numeroProveedor) OrElse numeroProveedor <= 0 Then
                MsgBox("Ingrese un N° de Proveedor Válido por favor.", MsgBoxStyle.Exclamation, "N° Proveedor no valido")
                mskNroProveedor.Focus()
                Exit Sub
            End If

            ' Llamada al método que realiza la consulta
            Dim dataTable As DataTable = control.BuscarIngresosPendientes(numeroProveedor)

            If dataTable Is Nothing OrElse dataTable.Rows.Count = 0 Then
                MsgBox("No existen datos pendientes para este proveedor.", MsgBoxStyle.Exclamation)
                Exit Sub
            Else
                ' Abre el formulario FrmOperaciones
                frm.PantallaMadre = "CO"
                frm.NumeroProveedor = numeroProveedor
                frm.ShowDialog(Me)
                ModuloGrillas.formatearcolumna7(dgvListado)
                dgvListado.Refresh()

                ModuloFunciones.calcularTotalComprobante(Me)
            End If
        Catch ex As Exception
            MsgBox("Error al realizar la consulta SQL. " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    'Dim TextBoxCotizacion As New Web.UI.WebControls.TextBox
    Private Sub btnBuscarCotizacion_Click(sender As Object, e As EventArgs) Handles btnBuscarCotizacion.Click
        ' Obtén la fecha actual o la que necesites
        Dim fechaActual As Date = Date.Today

        ' Llama a la función ObtenerCotizacionDolar
        Dim resultado As Integer = controlCotizacion.ObtenerCotizacionDolar(fechaActual, txtCotizacion)

        ' Realiza acciones según el resultado
        If resultado = 1 Then
            ' Acciones si la cotización se obtuvo correctamente
            MsgBox("Cotización obtenida correctamente.")
        ElseIf resultado = 0 Then
            ' Acciones si no se encontró cotización
            MsgBox("No se encontró cotización para la fecha actual.")
        Else
            ' Acciones si ocurrió un error al obtener la cotización
            MsgBox("Error al obtener la cotización.")
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim salida As Int16
        salida = controlComprobante.PermitirModificarComprobante(Val(mskNroInterno.Text))
        Select Case salida
            Case 0
                habilitarcontroles("MODIFICAR")
                If usuario.CodUser = 48 Or usuario.CodUser = 101 Or usuario.CodUser = 3 Then ' usuario roxana sau
                    btnBuscarProveedor.Enabled = True
                End If

                If cboDescripcion.SelectedIndex = 19 Or cboDescripcion.SelectedIndex = 20 Then
                    mskNroComprobanteAlfa.Visible = True
                Else
                    mskNroComprobanteAlfa.Visible = False
                    mskNroComprobanteAlfa.Focus()
                End If

            Case 1
                MsgBox("El comprobante que desea modificar pertenece a un mes cerrado y no se puede modificar.", MsgBoxStyle.Information)
                Exit Sub

            Case 2
                MsgBox("El comprobante que desea modificar se encuentra en trámite de pago y no se puede modificar.", MsgBoxStyle.Information)
                Exit Sub

            Case -1
                MsgBox("Error al obtener el mes de cierre del comprobante que desea modificar.", MsgBoxStyle.Critical)
                Exit Sub
        End Select
        If mskNroComprobante.Text.Trim().StartsWith("9041") Or mskNroComprobante.Text.Trim().StartsWith("9042") Then
            MsgBox("No puede modificar este comprobante, porque ha sido aprobado por el AFIP.", MsgBoxStyle.Critical, Me.Text)
            habilitarcontroles("BUSQUEDA")
            Exit Sub
        End If
        Estado = "MODIFICAR"
    End Sub

    Private Sub btnInformes_Click(sender As Object, e As EventArgs) Handles btnInformes.Click
        Dim frmInforme As New FrmFiltroInforme
        frmInforme.ShowDialog()
    End Sub

    Private Sub btnNDNCAFIP_Click(sender As Object, e As EventArgs) Handles btnNDNCAFIP.Click
        'De momento esta oculto y sin funcionamiento.
        Dim frmCreditoDebito As New FrmCreditoDebito
        Me.Hide()
        frmCreditoDebito.Show()
    End Sub

    Private Sub btnNDNCINT_Click(sender As Object, e As EventArgs) Handles btnNDNCINT.Click
        Dim frmCreditoDebitoInt As New FrmCreditoDebitoInt
        Me.Hide()
        frmCreditoDebitoInt.Show()
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        '        '*******************************************
        '        '   PROCEDIMIENTO PARA GUARDAR LOS DATOS
        '        '   VALIDA LOS CAMPOS Y CONTROLA SI INSERTAR O
        '        '   ACTUALIZAR LOS DATOS
        '        '********************************************
        Dim RstOC As New DataTable
        Dim RstPS As New DataTable
        Dim rstAxPro As New DataTable
        Dim rstPercep As New DataTable
        Dim rstIngreso As New DataTable
        Dim salida As Long
        Dim totalimporte As Double
        Dim VFechaVto As String
        Dim VFechaComp As String
        Dim Tipo_Moneda As Integer
        Dim EncontroInsumo As Integer
        Dim auxTotalCompExp As Double
        Dim CodValidacionCba As String
        Dim cadsql As String
        Dim DEPos As Integer
        Dim oPorCuentaDeTercero As Integer
        salida = 0

        If validarcamposguardar(RstOC, RstPS, rstAxPro, rstPercep, rstIngreso, salida, totalimporte, VFechaVto, VFechaComp, Tipo_Moneda, EncontroInsumo, auxTotalCompExp, CodValidacionCba, cadsql, DEPos, oPorCuentaDeTercero) = False Then
            Exit Sub
        End If

        Dim FechaHoraCarga As String
        FechaHoraCarga = Format(Now, "hh:mm:ss")
        FechaHoraCarga = (mskFecha.Text).Trim()
        mskFecha.Text = FechaHoraCarga

        Select Case Estado


            Case "NUEVO"


                'validar si hay algo en el portapapeles
                salida = control.ValidarNroComprobante(Val(mskNroProveedor.Text), mskNroComprobante.Text, cboDescripcion.SelectedIndex, cboTipo.SelectedIndex)
                Select Case salida
                    Case -1
                        MsgBox("Error al obtener datos de facturas para el proveedor ingresado. Contáctese con el depto. de sistemas.", vbCritical)
                        Exit Sub
                    Case 0 'todo bien la factura no esta cargada
                    Case Is > 0
                        MsgBox("El nro. de factura que cargo ya se encuentra incorporado al sistema bajo el número interno " & salida & ". Modifíquelo incorporando el parte de ingreso al que corresponde en caso de ser necesario.", vbInformation)
                        Exit Sub
                End Select


                salida = control.ValidarNroFactura(Val(mskNroProveedor.Text), mskNroComprobante.Text, cboDescripcion.SelectedIndex, cboTipo.SelectedIndex)
                Select Case salida
                    Case -1
                        MsgBox("Error al obtener datos de facturas para el proveedor ingresado. Contáctese con el depto. de sistemas.", vbCritical)
                        Exit Sub
                    Case 0 'todo bien la factura no esta cargada
                    Case Is > 0
                        MsgBox("El nro. de factura que cargo ya se encuentra incorporado al sistema bajo el número interno " & salida & ". Modifíquelo incorporando el parte de ingreso al que corresponde en caso de ser necesario.", vbInformation)
                        Exit Sub
                End Select
                If Trim(mskVtoCAI.Text) = "00/00/0000" Then
                    MsgBox("Verifique que la fecha Vto. del C.A.I. sea correcto.  ", vbInformation)
                    Exit Sub
                End If
                CodValidacionCba = ""
                Dim comprobante As New ModeloComprobanteProveedor
                With comprobante
                    .NroProveedor = mskNroProveedor.Text
                    .DescComp = cboDescripcion.SelectedValue
                    .FechaCarga = FechaHoraCarga
                    .FechaVto = VFechaVto
                    .TipoComp = cboTipo.SelectedValue
                    .Provincia = cboProvincia.SelectedValue
                    .NroComp = mskNroComprobante.Text
                    .FechaComp = VFechaComp
                    .CondicionPago = cboCondPago.SelectedValue
                    .Observacion = txtObservaciones.Text
                    .IvaProd = CDbl(txtIVAProd.Text)
                    .ImporteProd = CDbl(txtImpProd.Text)
                    .PercepIva = CDbl(txtPercepIva.Text)
                    .PercepGan = CDbl(txtPercepGanancia.Text)
                    .TotalPercepIB = CDbl(txtPercepIB.Text)
                    .ImporteNoImp = CDbl(txtImpNoImp.Text)
                    .TotalComp = CDbl(txtTotalComp.Text)
                    .CAI = txtCAI.Text
                    .VtoCAI = mskVtoCAI.Text
                    .CodBarra = txtCodBarra.Text
                    .CotizacionDolar = CDbl(txtCotizacion.Text)
                    .Iva21 = CDbl(txtGrav21.Text)
                    .Iva105 = CDbl(txtGrav105.Text)
                    .Iva27 = CDbl(txtGrav27.Text)
                    .Imp21 = CDbl(txtImp21.Text)
                    .Imp105 = CDbl(txtImp105.Text)
                    .Imp27 = CDbl(txtImp27.Text)
                    .FechaIngresoProveedores = "2024-01-05"
                    .CodOperadorIngresoComp = 303
                    .CAEAInformado = 404
                    .FechaCAEAInf = "2024-04-05"
                    .Iva25 = CDbl(txtGrav75.Text)
                    .Imp25 = CDbl(txtImp75.Text)
                End With


                salida = control.NuevoComprobantePrincipal(comprobante, "", rstAxPro, rstIngreso, RstOC, RstPS,
                                                            "", "PRINCIPAL", CodValidacionCba, mskFechaIngreso.Text.Trim, mskNroComprobanteAlfa.Text,
                                                            oPorCuentaDeTercero, VariablesGlobales.idusuario)

                If salida = -1 Then
                    MsgBox("Se Produjo un Error al Crear un Nuevo Comprobante. Contáctese con el Depto. de  Sistemas.", vbCritical)
                ElseIf salida = -2 Then
                    'SE  DEBE HACER UN RESEED DE NRO.NroInterno DEL SQL
                    MsgBox("No se puede guardar el Comprobante. Se debe hacer un reseed al campo NroInterno de la tabla ComprobantesProveedores de la base de datos. Contáctese con el Depto. de Sistemas.", vbExclamation)
                Else
                    mskNroInterno.Text = Format(salida, "00000000")

                    MsgBox("Se genero el comprobante con éxito, NroInterno" & ": " & salida, vbInformation)

                    If cboDescripcion.Text = "FACTURA PROVEEDOR" Then
                        btnImagen.Enabled = True
                    End If
                End If

                habilitarcontroles("GRABADO")

            Case "MODIFICAR"


                If cboDescripcion.Text = "FACTURA PROVEEDOR" Then

                    salida = controlComprobante.Modificar(Val(mskNroInterno.Text), Val(mskNroProveedor.Text), cboDescripcion.SelectedValue, cboTipo.SelectedValue,
                                               mskNroComprobante.Text.Replace("-", ""), VFechaComp, FechaHoraCarga, VFechaVto,
                                              cboCondPago.SelectedValue, stringSQL(txtObservaciones.Text),
                                               FormatoSQL(txtIVAProd.Text), FormatoSQL(txtImpProd.Text),
                                               FormatoSQL(txtPercepIva.Text), FormatoSQL(txtPercepGanancia.Text),
                                               FormatoSQL(txtTotalPercepciones.Text), FormatoSQL(txtImpNoImp.Text),
                                               FormatoSQL(txtTotalComp.Text), Trim(txtCAI.Text), CDate(mskVtoCAI.Text),
                                               Trim(txtCodBarra.Text), rstPercep, rstIngreso, RstOC, RstPS,
                                               FormatoSQL(txtCotizacion.Text), (mskFechaIngreso.Text).Trim(),
                                               FormatoSQL(txtGrav21.Text), FormatoSQL(txtGrav105.Text), FormatoSQL(txtGrav27.Text),
                                               FormatoSQL(txtGrav75.Text), FormatoSQL(txtImp21.Text), FormatoSQL(txtImp105.Text),
                                               FormatoSQL(txtImp27.Text), FormatoSQL(txtImp75.Text), oPorCuentaDeTercero)
                    If salida = -1 Then
                        MsgBox("Se Produjo un error al Modificar el Comprobante.", vbCritical)
                        Exit Sub
                    End If

                    If cboDescripcion.Text = "FACTURA PROVEEDOR" Then
                        btnImagen.Enabled = True
                    End If

                    habilitarcontroles("GRABADO")
                    If salida = 1 Then
                        MsgBox("Modifico el Comprobante con exitó.", vbInformation, "Exitó!")
                        Exit Sub
                    End If
                End If
        End Select
    End Sub




    Private Function FuncionControlarParteSalida(ByVal RstPS As DataTable) As Boolean
        Dim salida As String
        Dim i As Integer
        Dim EncontroInsumo As Integer
        If dgvOrdenDeCarga.Rows.Count > 0 Then
            dgvOrdenDeCarga.CurrentCell = dgvOrdenDeCarga(0, 0)
        End If

        RstPS.Columns.Add("NroParteSalida", GetType(Double))
        RstPS.Columns.Add("Valor", GetType(Double))


        With dgvListado
            For i = 0 To .RowCount - 1
                .CurrentCell = .Item(1, i)

                If (Trim(.CurrentCell.Value.ToString()) = "1.01.006.002.0001" Or
                Trim(.CurrentCell.Value.ToString()) = "1.01.006.002.0001" Or
                Trim(.CurrentCell.Value.ToString()) = "1.01.009.001.0001" Or
                Trim(.CurrentCell.Value.ToString()) = "1.01.009.001.0002") Then
                    EncontroInsumo = 1
                    Exit For
                Else
                    EncontroInsumo = 0
                End If
            Next i
        End With

        If EncontroInsumo = 0 Then
            MsgBox("Verifique los códigos de insumo para Fletes.", MsgBoxStyle.Critical)
            FuncionControlarParteSalida = True
            Exit Function
        End If

        With dgvOrdenDeCarga
            For i = 0 To .RowCount - 1
                .CurrentCell = .Item(0, i)
                If Trim(.CurrentCell.Value.ToString()) <> "" Then
                    Dim newRow As DataRow = RstPS.NewRow()
                    newRow("NroParteSalida") = Val(.CurrentCell.Value)
                    .CurrentCell = .Item(1, i)
                    If .CurrentCell.Value Is Nothing OrElse String.IsNullOrEmpty(.CurrentCell.Value.ToString()) Then
                        newRow("Valor") = 0
                    Else
                        newRow("Valor") = CInt(.CurrentCell.Value)
                    End If
                    RstPS.Rows.Add(newRow)
                End If
            Next i
        End With

        If RstPS.Rows.Count > 0 Then
            salida = control.ValidarParteSalida(RstPS, Estado, mskNroInterno.Text)
            Select Case salida
                Case -1
                    MsgBox("Error al intentar obtener datos.", MsgBoxStyle.Critical)
                    FuncionControlarParteSalida = True
                Case 0
                    MsgBox("No se encontraron datos. Controle los Parte de Salida.", MsgBoxStyle.Information)
                    FuncionControlarParteSalida = True
                Case 1
                    ' MsgBox("bien", MsgBoxStyle.Exclamation, Me.Caption)
                    FuncionControlarParteSalida = False
                Case 2
                    MsgBox("La fecha del Parte Salida no debe ser mayor, ni igual a hoy.", MsgBoxStyle.Critical)
                    FuncionControlarParteSalida = True
                Case 3
                    MsgBox("El Parte de Salida ya ha sido ingresado en otro Comprobante.", MsgBoxStyle.Critical)
                    FuncionControlarParteSalida = True
                Case 4
            End Select
        End If

        Return FuncionControlarParteSalida
    End Function
    Private Function validarcamposguardar(ByRef RstOC As DataTable, ByRef RstPS As DataTable, ByRef rstAxPro As DataTable, ByRef rstPercep As DataTable, ByRef rstIngreso As DataTable, ByRef salida As Long, ByRef totalimporte As Double, ByRef VFechaVto As String, ByRef VFechaComp As String,
       ByRef Tipo_Moneda As Integer, ByRef EncontroInsumo As Integer, ByRef auxTotalCompExp As Double, ByRef CodValidacionCba As String,
       ByRef cadsql As String, ByRef DEPos As Integer, ByRef oPorCuentaDeTercero As Integer) As Boolean
        If Estado = "NUEVO" Then
            If cboTipo.SelectedIndex <> -1 And cboDescripcion.SelectedIndex <> -1 Then
                Select Case cboDescripcion.SelectedIndex
                    Case 3, 7, 11, 13, 15, 16
                        MsgBox("Seleccione un tipo de comprobante valido para la generación del nuevo comprovante.", vbInformation)
                        cboDescripcion.Focus()
                        Return False
                    Case Else
                End Select
            End If
        End If
        'si no es factura
        If cboDescripcion.SelectedIndex <> 1 And cboDescripcion.SelectedIndex <> 2 Then
            If FuncionControlarOrdenCarga(RstOC, dgvOrdenDeCarga, mskNroInterno) = False Then
                ModuloGrillas.InicializarGrillaParteSalida(dgvOrdenDeCarga)
                Return False
            End If


            RstPS.Columns.Add("NroParteSalida", GetType(Double))
            RstPS.Columns.Add("Valor", GetType(Double))

            Dim fila As DataRow = RstPS.NewRow()
            fila("NroParteSalida") = 0
            fila("Valor") = 0
            RstPS.Rows.Add(fila)

        Else
            Dim dgvListado As New DataGridView
            With dgvListado
                For i As Integer = 0 To .RowCount - 1
                    If Trim(.Rows(i).Cells(2).Value.ToString()) = "1.01.006.002.0001" Or
           Trim(.Rows(i).Cells(2).Value.ToString()) = "1.01.009.001.0001" Or
           Trim(.Rows(i).Cells(2).Value.ToString()) = "1.01.009.001.0002" Then
                        EncontroInsumo = 1
                        Exit For
                    Else
                        EncontroInsumo = 0
                    End If
                Next i
            End With


            If EncontroInsumo = 0 Then


                RstOC.Columns.Add("NroOrdenCarga", GetType(Double))
                RstPS.Columns.Add("NroParteSalida", GetType(Double))
                RstPS.Columns.Add("Valor", GetType(Double))
            Else

                If FuncionControlarParteSalida(RstPS) = False Then

                Else
                    ModuloGrillas.InicializarGrillaParteSalida(dgvOrdenDeCarga)
                    Return False
                End If
                RstOC.Columns.Add("NroOrdenCarga", GetType(Double))
            End If
        End If
        '        '******************************************************
        '        '------ CONDICIONES MINIMAS PARA GUARDAR DATOS --------
        '        '******************************************************
        '        ''Controlar si los montos coinciden
        If Not ModuloFunciones.validarMontosYPercepciones(Convert.ToDouble(txtTotalGrav.Text), Convert.ToDouble(txtImpProd.Text), Convert.ToDouble(txtTotalImp.Text), Convert.ToDouble(txtIVAProd.Text)) Then
            MsgBox("Error en los montos. Verifique las grillas.", vbInformation)
            Return False
        End If
        ''ver si es dolar, no permitir valor cero
        If lblCotMonedaEx.Visible = True Then
            If txtCotizacion.Text = "" Then
                MsgBox("Debe ingresar un valor valido para la Cotización.", vbInformation)
                txtCotizacion.Focus()
                Return False
            ElseIf CDbl(txtCotizacion.Text) <= 0 Then
                ''foco
                MsgBox("Debe ingresar un valor valido para la Cotización.", vbInformation)
                txtCotizacion.Focus()
                Return False
            End If
        End If
        If dgvListado.RowCount <= 2 Then
            If Val(dgvListado.Rows(0).Cells(1).Value) = 0 Then
                MsgBox("Debe cargar al menos un insumo al comprobante.", MsgBoxStyle.Information)
                mskNroComprobante.Focus()
                Return False
            End If
        End If



        VFechaVto = mskFechaVto.Text
        VFechaComp = mskFechaComp.Text
        If CDate(mskFechaVto.Text) < CDate(VFechaComp) Then
            MsgBox("La fecha de vencimiento no puede ser menor que la fecha del comprobante")
            Return False
        End If
        If Not (IsDate(mskFechaVto.Text)) Then
            MsgBox("Fecha de Vencimiento de Comprobante no válida.", vbCritical)
            mskFechaVto.Focus()
            Return False
        End If

        If Not (IsDate(mskFechaComp.Text)) Then
            MsgBox("Fecha de Comprobante no válida.", vbCritical)
            mskFechaComp.Focus()
            Return False
        End If

        If Not (IsDate(mskFechaIngreso.Text)) Then
            MsgBox("Fecha de Ingreso a Proveedores no válida.", vbCritical)
            mskFechaIngreso.Focus()
            Return False
        End If

        If mskNroProveedor.Text = "" Then
            MsgBox("Debe Cargar un Proveedor Válido", vbInformation)
            mskNroProveedor.Focus()
            Return False
        End If



        If cboDescripcion.SelectedIndex <> -1 Then
            If cboDescripcion.SelectedIndex = 19 Or cboDescripcion.SelectedIndex = 20 Then
                control.ObtenerProveedor(rstAxPro, mskNroProveedor.Text)

                If rstAxPro Is Nothing Then
                    MsgBox("Error al consultar este proveedor. Contáctese con el Depto. de Sistemas.", MsgBoxStyle.Critical)
                    Return False
                ElseIf rstAxPro.Rows.Count = 0 Then
                    MsgBox("No se encontró el proveedor.", MsgBoxStyle.Information)
                    Return False
                Else
                    If CBool(rstAxPro.Rows(0)("EsAduana")) Then
                        If Len(mskNroComprobante.Text) <> 16 Then
                            MsgBox("Debe cargar un N° de Comprobante Válido", MsgBoxStyle.Information)
                            mskNroComprobante.Focus()
                            Return False
                        End If
                    Else
                        If Len(mskNroComprobante.Text) <> 12 Then
                            MsgBox("Debe cargar un N° de Comprobante Válido", MsgBoxStyle.Information)
                            mskNroComprobante.Focus()
                            Return False
                        End If
                    End If
                End If
            Else
                Dim comprobante As String = mskNroComprobante.Text.Replace("-", "")
                If Len(comprobante) <> 12 Then
                    MsgBox("Debe cargar un N° de Comprobante Válido", MsgBoxStyle.Information)
                    mskNroComprobante.Focus()
                    Return False
                End If
            End If
        End If

        '        '--------------------------

        If cboDescripcion.SelectedIndex < 0 Then
            MsgBox("Debe Cargar una Descripción de comprobante Válida.", vbInformation)
            cboDescripcion.Focus()
            Return False
        End If

        If cboCondPago.SelectedIndex < 0 Then
            MsgBox("Debe Cargar una Condición de pago de comprobante Válida.", vbInformation)
            cboCondPago.Focus()
            Return False
        End If

        If cboTipo.SelectedIndex < 0 Then
            MsgBox("Debe Cargar un tipo de comprobante Válida.", vbInformation)
            cboTipo.Focus()
            Return False
        End If

        ''****************************************
        ''*************VALIDACION CAI**************
        If cboDescripcion.SelectedValue <> 15 And cboDescripcion.SelectedValue <> 16 Then
            '   If CboDesc.ListIndex = 0 And CboTipo.ListIndex < 2 Then
            If Not IsDate(Trim(mskVtoCAI.Text)) Then
                MsgBox("El campo Vto C.A.I no contiene una fecha válida. NO puede cargar un Comprobante con estas características.", vbInformation, "Fecha Vto C.A.I No valida")
                mskVtoCAI.Focus()
                Return False
            End If

            'VALIDAR OPA APOA


            If CDate(Trim(mskVtoCAI.Text)) < CDate(Trim(mskFechaComp.Text)) And Val(cboDescripcion.SelectedValue) <> 14 And (Val(cboDescripcion.SelectedValue) <> 0 And CDate(Trim(mskVtoCAI.Text)) < CDate(Trim(mskFechaComp.Text))) Then
                MsgBox("El Vto del CAI es menor a la fecha del comprobante NO puede cargar un Comprobante con estas características.", vbInformation, "Fecha Vto C.A.I No valida")
                mskVtoCAI.Focus()
                Return False
            End If

            If DateDiff("d", CDate(Trim(mskFechaComp.Text)), CDate(Trim(mskVtoCAI.Text))) < 0 And Val(cboDescripcion.SelectedIndex) <> 14 And (DateDiff("d", CDate(Trim(mskFechaComp.Text)), CDate(Trim(mskVtoCAI.Text))) < 0 And Val(cboDescripcion.SelectedValue) <> 0) Then
                MsgBox("El Vto del CAI es menor a la fecha del comprobante NO puede cargar un Comprobante con estas características. Comprobante No Válido. No se puede continuar.", vbInformation)
                mskVtoCAI.Focus()
                Return False
            End If
            If (Trim(mskVtoCAI.Text)) = "" Then
                MsgBox("No introdujo datos para el Vto del CAI, el mismo no puede ser vacío. NO puede cargar un Comprobante con estas características. No se puede continuar.", vbInformation)
                mskVtoCAI.Focus()
                Return False
            End If

            If (Trim(txtCAI.Text)) = "" And Val(cboDescripcion.SelectedIndex) <> 14 And ((Trim(txtCAI.Text)) = "" And Val(cboDescripcion.SelectedIndex) <> 0) Then
                MsgBox("No introdujo datos para el CAI, el mismo no puede ser vacío. NO puede cargar un Comprobante con estas características. No se puede continuar.", vbInformation)
                mskVtoCAI.Focus()
                Return False
            End If

            '    End If
        End If

        ''*****************************************************
        ''---------------- DETALLE DE PERCEPCION --------------
        '' ARMA RECORDSET CON Prefijo y Numero DE EXP
        ''*****************************************************

        rstPercep.Columns.Add("Provincia", GetType(Integer))
        rstPercep.Columns.Add("BaseImponible", GetType(Double))
        rstPercep.Columns.Add("Percepcion", GetType(Double))

        ' Loop through dgvIB and populate rstPercep DataTable
        For i As Integer = 0 To DgvIB.Rows.Count - 1
            DgvIB.CurrentCell = DgvIB(0, i)

            If DgvIB.CurrentCell.Value Is Nothing OrElse String.IsNullOrEmpty(DgvIB.CurrentCell.Value.ToString()) Then
                Exit For
            End If
            Dim datosFila As DataRowView = DirectCast(DgvIB.Rows(i).DataBoundItem, DataRowView)
            Dim fila As DataRow = rstPercep.NewRow()
            'DgvIB.CurrentCell = DgvIB(3, i)
            fila("Provincia") = DgvIB.Rows(i).Cells(3).Value.ToString()
            DgvIB.CurrentCell = DgvIB(2, i)
            fila("Percepcion") = CDbl(DgvIB.CurrentCell.Value)
            DgvIB.CurrentCell = DgvIB(1, i)
            fila("BaseImponible") = CDbl(DgvIB.CurrentCell.Value)
            rstPercep.Rows.Add(fila)
        Next

        ' Initialize DataTable for rstIngreso
        Dim dtIngreso As New DataTable
        dtIngreso.Columns.Add("DescInsumo", GetType(String))
        dtIngreso.Columns.Add("NroIngreso", GetType(Double))
        dtIngreso.Columns.Add("CodInsumo", GetType(Long))
        dtIngreso.Columns.Add("Cantidad", GetType(Double))
        dtIngreso.Columns.Add("Precio", GetType(Double))
        dtIngreso.Columns.Add("Total", GetType(Double))
        dtIngreso.Columns.Add("CC", GetType(Double))
        dtIngreso.Columns.Add("Iva", GetType(Double))
        dtIngreso.Columns.Add("Exento", GetType(Double))
        dtIngreso.Columns.Add("Gravado", GetType(Double))
        dtIngreso.Columns.Add("CodComprobanteExp", GetType(Double))
        dtIngreso.Columns.Add("CodMonedaExp", GetType(Integer))
        dtIngreso.Columns.Add("TipoCompExp", GetType(Integer))
        dtIngreso.Columns.Add("NumeroCompExp", GetType(String))
        dtIngreso.Columns.Add("ImporteExp", GetType(Double))
        dtIngreso.Columns.Add("idMaterial", GetType(Double))




        With dgvListado
            For j As Integer = 0 To .RowCount - 1
                ' Crear una cadena única basada en los valores de la fila actual
                Dim newRow As DataRow = dtIngreso.NewRow()

                For i As Integer = 0 To .ColumnCount - 1
                    ' Check if the cell value is nothing or empty
                    Dim cellValue As String = .Rows(j).Cells(i).Value?.ToString()
                    If String.IsNullOrEmpty(cellValue) AndAlso i = 1 AndAlso j = .RowCount - 1 Then
                        Exit For
                    End If

                    Select Case i
                        Case 0
                            newRow("NroIngreso") = Val(cellValue)

                        Case 1
                            If String.IsNullOrEmpty(cellValue) OrElse Not IsNumeric(cellValue) Then
                                MsgBox("Código de Insumo NO válido. No puede ser Cero", MsgBoxStyle.Information)
                                Return False
                            Else


                                Dim codInsumo As Double = Val(Replace(cellValue, ".", ""))

                                Select Case Val(Replace(cellValue, ".", ""))
                                    Case 3020010010002, 2030040010001, 2030040010002, 2030040010003, 2030030020001, 2030030020002, 2030030030001, 2030030030002, 2030030030003, 2030050010001, 2030050010002, 2030050010003, 2030050010004, 1010120010002, 1010120020001, 1010120020002, 1010120030003, 1010120030004, 1010120030005
                                        ' Valido si son insumos de exportación y que se carguen datos de detalle de gastos

                                        If CDbl(Me.txtCotizacion.Text) <= 0 Then
                                            MsgBox("Debido a que ha ingresado insumos asociados a operaciones de exportación debe ingresar una cotización válida para la operación de exportación.", MsgBoxStyle.Information)
                                            txtCotizacion.Focus()
                                            Return False
                                        End If

                                        auxTotalCompExp = 0
                                        For fila As Integer = 0 To dgvExportacion.Rows.Count - 1
                                            If dgvExportacion.Rows(fila).Cells(5).Value.ToString() = dgvListado.Rows(1).Cells(j).ToString() Then
                                                dtIngreso.Rows(0)("codComprobanteexp") = Val(dgvExportacion.Rows(fila).Cells(0).Value)
                                                dtIngreso.Rows(0)("codMonedaExp") = Val(dgvExportacion.Rows(fila).Cells(1).Value)
                                                dtIngreso.Rows(0)("tipoCompExp") = Val(dgvExportacion.Rows(fila).Cells(2).Value)
                                                dtIngreso.Rows(0)("numeroCompExp") = dgvExportacion.Rows(fila).Cells(3).Value.ToString()
                                                dtIngreso.Rows(0)("ImporteExp") = CDbl(dgvExportacion.Rows(fila).Cells(4).Value)
                                            End If
                                            auxTotalCompExp += CDbl(dgvExportacion.Rows(fila).Cells(4).Value)
                                        Next



                                        If dtIngreso.Rows(0)("codComprobanteexp") = 0 Then
                                            MsgBox("Debido a que ha ingresado insumos asociados a operaciones de exportación debe ingresar datos válidos para la operación de exportación.", MsgBoxStyle.Information)
                                            dgvListado.Focus()
                                            Return False
                                        End If


                                        control.ObtenerProveedor(rstAxPro, mskNroProveedor.Text)

                                        If rstAxPro.Rows.Count = 0 Then
                                            MsgBox("Error al consultar este proveedor. Contáctese con el Depto. de Sistemas.", MsgBoxStyle.Critical)
                                            Return False
                                        ElseIf rstAxPro.Rows.Count = 0 Then
                                            MsgBox("No se encontró el proveedor.", MsgBoxStyle.Information)
                                            Return False
                                        Else
                                            If CBool(rstAxPro.Rows(0)("EsAduana")) Then
                                                If mskNroComprobanteAlfa.Text <> "" Then
                                                    DEPos = InStr(1, mskNroComprobanteAlfa.Text, "EC")
                                                End If

                                                If DEPos > 0 Then
                                                    If Math.Abs(Math.Round(auxTotalCompExp, 2) - Math.Round(((CDbl(txtImpProd.Text) + CDbl(txtImpNoImp.Text)) / CDbl(txtCotizacion.Text)), 2)) > 1 Then
                                                        MsgBox("El importe del comprobante no coincide con los importes cargados a cotización e importe en moneda extranjera.", MsgBoxStyle.Information)
                                                        dgvListado.Focus()
                                                        Return False
                                                    End If
                                                Else
                                                    If Math.Abs(Math.Round(auxTotalCompExp, 2) - Math.Round(((CDbl(txtImpNoImp.Text)) / CDbl(txtCotizacion.Text)), 2)) > 1 Then
                                                        MsgBox("El importe del comprobante no coincide con los importes cargados a cotización e importe en moneda extranjera.", MsgBoxStyle.Information)
                                                        dgvListado.Focus()
                                                        Return False
                                                    End If
                                                End If
                                            Else
                                                ' COMO ESTA FUNCIONANDO
                                                If Math.Abs(Math.Round(auxTotalCompExp, 2) - Math.Round(((CDbl(txtImpProd.Text) + CDbl(txtImpNoImp.Text)) / CDbl(txtCotizacion.Text)), 2)) > 1 Then
                                                    MsgBox("El importe del comprobante no coincide con los importes cargados a cotización e importe en moneda extranjera.", MsgBoxStyle.Information)
                                                    dgvListado.Focus()
                                                    Return False
                                                End If
                                            End If
                                        End If

                                End Select

                                ' rstIngreso("cell") = Val(Replace(cellValue, ".", ""))
                                newRow("codInsumo") = codInsumo
                            End If

                        Case 2
                            If String.IsNullOrEmpty(.Rows(j).Cells(i).Value.ToString()) Or .Rows(j).Cells(i).Value.ToString() = "DIE" Then
                                MsgBox("Descripción de Insumo NO válida. No puede ser vacía", MsgBoxStyle.Information)
                                Return False
                            Else
                                newRow("DescInsumo") = Val(cellValue)
                            End If

                        Case 3
                            Dim cantidad As String = Convert.ToDouble(Val(cellValue))
                            If cantidad = 0 Then
                                MsgBox("Cantidad NO válida. No puede ser Cero", MsgBoxStyle.Information)
                                Return False
                            Else
                                newRow("Cantidad") = cantidad
                            End If

                        Case 4
                            Dim precioValue As String = Replace(cellValue, ".", "")
                            precioValue = Replace(precioValue, ".", ",")

                            If String.IsNullOrEmpty(precioValue) Then
                                MsgBox("Precio NO válido. No puede ser vacío", MsgBoxStyle.Information)
                                Return False
                            End If

                            If Not Double.TryParse(precioValue, 0.0) Then
                                MsgBox("Precio NO válido. Debe ser un valor numérico", MsgBoxStyle.Information)
                                Return False
                            End If

                            Dim precio As Double = Convert.ToDouble(precioValue)

                            If precio = 0 Then
                                MsgBox("Precio NO válido. No puede ser Cero", MsgBoxStyle.Information)
                                Return False
                            Else
                                newRow("Precio") = precio
                            End If

                        Case 5
                            Dim totalValue As String = CDbl(cellValue)


                            If Not Double.TryParse(totalValue, 0.0) Then
                                MsgBox("Cantidad de Total NO válida. Debe ser un valor numérico", MsgBoxStyle.Information)
                                Return False
                            End If

                            Dim total As Double = Convert.ToDouble(totalValue)

                            If total = 0 Then
                                MsgBox("Cantidad de Total NO válida. No puede ser Cero", MsgBoxStyle.Information)
                                Return False
                            Else
                                newRow("Total") = total
                                totalimporte += total
                            End If


                        Case 6
                            Dim centroCosto As Double = Convert.ToDouble(Val(cellValue))
                            If centroCosto < 600 Or centroCosto > 700 Then
                                MsgBox("Centro de Costo NO es válido. El Código no es válido.", MsgBoxStyle.Information)
                                Return False
                            End If
                            If centroCosto < 0 Then
                                MsgBox("Centro de Costo NO válido. No puede ser menor a cero", MsgBoxStyle.Information)
                                Return False
                            Else
                                newRow("CC") = centroCosto
                            End If

                        Case 9
                            Dim idMaterial As Double = Convert.ToDouble(Val(cellValue))
                            ' Pasar idDetalleConsuman que sería el nroingreso preguntar para identificarlo
                            If idMaterial < 0 Then
                                MsgBox("Id Material NO válido.", MsgBoxStyle.Information)
                            Else
                                newRow("idMaterial") = idMaterial
                            End If

                    End Select
                Next i

                ' Aca ya tengo la fila de la grilla. Agrego la fila al DataTable.
                dtIngreso.Rows.Add(newRow)
            Next j
        End With


        '------------------------------------------------------
        If chkPorCuentaTercero.Checked = False Then
            oPorCuentaDeTercero = 0
        Else
            oPorCuentaDeTercero = 1
        End If

        '*********************************************
        ' CONTROLO QUE COINCIDAN LOS TOTALES
        '*********************************************

        If dgvListado.Rows.Count > 0 Then
            Dim impProd As Double
            Dim ivaProd As Double
            Dim percepGanancia As Double
            Dim percepIva As Double
            Dim percepIB As Double
            Dim imp75 As Double
            Dim impNoImp As Double
            Dim totalComp As Double
            If Not Double.TryParse(txtImpProd.Text, impProd) Then impProd = 0
            If Not Double.TryParse(txtIVAProd.Text, ivaProd) Then ivaProd = 0
            If Not Double.TryParse(txtPercepGanancia.Text, percepGanancia) Then percepGanancia = 0
            If Not Double.TryParse(txtPercepIva.Text, percepIva) Then percepIva = 0
            If Not Double.TryParse(txtPercepIB.Text, percepIB) Then percepIB = 0
            If Not Double.TryParse(txtImp75.Text, imp75) Then imp75 = 0
            If Not Double.TryParse(txtImpNoImp.Text, impNoImp) Then impNoImp = 0
            If Not Double.TryParse(txtTotalComp.Text, totalComp) Then totalComp = 0
            Dim suma As Double = (impProd + ivaProd + percepGanancia + percepIva + percepIB + imp75 + impNoImp)

            If dgvListado.RowCount > 0 Then
                For i As Integer = 0 To dgvListado.Rows.Count - 1
                    Dim valorcelda As Double
                    If dgvListado.Rows(i).Cells(5).Value IsNot Nothing AndAlso Double.TryParse(dgvListado.Rows(i).Cells(5).Value.ToString(), valorcelda) Then
                        If VariablesGlobales.condicionIva = 6 Then
                            If Format(impNoImp, "0.00") <> Format(totalComp, "0.00") Or Format(impNoImp, "0.00") <> Format(valorcelda, "0.00") Or Format(totalComp, "0.00") <> Format(valorcelda, "0.00") Then
                                MsgBox("No coinciden los montos totales. Revise los campos del comprobante y el total de las órdenes de compra.", MsgBoxStyle.Information)
                                Return False
                            End If

                        ElseIf Format(impProd + ivaProd + percepGanancia + percepIva + percepIB + imp75 + impNoImp, "0.00") <> Format(totalComp, "0.00") OrElse Format(impProd, "0.00") <> Format(valorcelda, "0.00") Then
                            MsgBox("No coinciden los montos totales. Revise los campos del comprobante y el total de las órdenes de compra.", MsgBoxStyle.Information)
                            Return False
                        End If
                    End If
                Next
            End If



        End If

        If Val(txtPercepIB.Text) > 0 Then
            If CDec(txtTotalPercepciones.Text) <> CDec(txtPercepIB.Text) Then
                MsgBox("No coinciden los montos de totales de percepciones de Ingresos Brutos. Revise los datos.", MsgBoxStyle.Information)
                Return False
            End If
        End If



        If Trim(Me.txtCotizacion.Text) = "" Then Me.txtCotizacion.Text = 0
        If Val(Me.txtCotizacion.Text) > 0 Then
            Tipo_Moneda = 1 ' dólares
        Else
            Tipo_Moneda = 0 ' pesos
        End If
        Return True
    End Function
    Private Sub calculartotalimpuestos(filaseleccionada As DataGridViewRow, e As DataGridViewCellEventArgs)
        Try
            Dim valorNumerico As Decimal = Convert.ToDecimal(filaseleccionada.Cells(5).Value)
            If e.ColumnIndex < filaseleccionada.Cells.Count Then
                'calculo de la columna gravado
                txtGrav21.Text = valorNumerico.ToString("N2")
                txtIVAProd.Text = (valorNumerico * 0.21).ToString("N2")
                txtImpProd.Text = valorNumerico.ToString("N2")
                Dim totalGrav As Double
                totalGrav = Convert.ToDecimal(txtGrav21.Text) + Convert.ToDecimal(IIf(txtGrav105.Text.Trim = "", 0, txtGrav105.Text)) + Convert.ToDecimal(IIf(txtGrav27.Text.Trim = "", 0, txtGrav27.Text)) + Convert.ToDecimal(IIf(txtGrav75.Text.Trim = "", 0, txtGrav27.Text))
                'calculo da la columna imponible
                txtTotalGrav.Text = totalGrav.ToString("N2")
                txtImp21.Text = (valorNumerico * 0.21).ToString("N2")

                Dim totalImp As Double
                totalImp = CDbl(IIf(String.IsNullOrWhiteSpace(txtImp21.Text.Trim), 0, txtImp21.Text.Trim)) +
               CDbl(IIf(String.IsNullOrWhiteSpace(txtImp105.Text.Trim), 0, txtImp105.Text.Trim)) +
               CDbl(IIf(String.IsNullOrWhiteSpace(txtImp27.Text.Trim), 0, txtImp27.Text.Trim))
                txtTotalImp.Text = totalImp.ToString("N2")
                Dim dt As New DataTable
                Dim DEPos As Integer
                control.ObtenerProveedor(dt, mskNroProveedor.Text)

                If dt.Rows(0)("EsAduana") Then
                    If mskNroComprobanteAlfa.Text <> "" Then
                        DEPos = InStr(1, mskNroComprobanteAlfa.Text, "EC")
                    End If
                    txtTotalComp.Text = Format(
                    CDbl(IIf(String.IsNullOrWhiteSpace(txtPercepIB.Text.Trim), 0, txtPercepIB.Text.Trim)) +
                    CDbl(IIf(String.IsNullOrWhiteSpace(txtImpNoImp.Text.Trim), 0, txtImpNoImp.Text.Trim)) +
                    CDbl(IIf(String.IsNullOrWhiteSpace(txtImpProd.Text.Trim), 0, txtImpProd.Text.Trim)) +
                    CDbl(IIf(String.IsNullOrWhiteSpace(txtIVAProd.Text.Trim), 0, txtIVAProd.Text.Trim)) +
                    CDbl(IIf(String.IsNullOrWhiteSpace(txtPercepGanancia.Text.Trim), 0, txtPercepGanancia.Text.Trim)) +
                    CDbl(IIf(String.IsNullOrWhiteSpace(txtPercepIva.Text.Trim), 0, txtPercepIva.Text.Trim)) +
                    CDbl(IIf(String.IsNullOrWhiteSpace(txtImpPais.Text.Trim), 0, txtImpPais.Text.Trim)),
                    "0.00"
                )
                Else
                    txtTotalComp.Text = Format(
                    CDbl(IIf(String.IsNullOrWhiteSpace(txtPercepIB.Text.Trim), 0, txtPercepIB.Text.Trim)) +
                    CDbl(IIf(String.IsNullOrWhiteSpace(txtImpNoImp.Text.Trim), 0, txtImpNoImp.Text.Trim)) +
                    CDbl(IIf(String.IsNullOrWhiteSpace(txtImpProd.Text.Trim), 0, txtImpProd.Text.Trim)) +
                    CDbl(IIf(String.IsNullOrWhiteSpace(txtIVAProd.Text.Trim), 0, txtIVAProd.Text.Trim)) +
                    CDbl(IIf(String.IsNullOrWhiteSpace(txtPercepGanancia.Text.Trim), 0, txtPercepGanancia.Text.Trim)) +
                    CDbl(IIf(String.IsNullOrWhiteSpace(txtPercepIva.Text.Trim), 0, txtPercepIva.Text.Trim)) +
                    CDbl(IIf(String.IsNullOrWhiteSpace(txtImpPais.Text.Trim), 0, txtImpPais.Text.Trim)),
                    "0.00"
                )
                End If
                txtIVAProd.Enabled = False
                txtTotalGrav.Enabled = False
                txtTotalImp.Enabled = False
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnImagen_Click(sender As Object, e As EventArgs) Handles btnImagen.Click
        Dim RstAux As New DataTable
        Dim salida As Integer
        Dim Ubic As String
        Dim rptImpresoImgComprobante As New RptImpresoImagenComprobante
        Dim frmVisualizador As New FrmInformeVisualizador
        Dim rutaAplicacion As String = Application.StartupPath
        Dim yearpath As String = Year(Convert.ToDateTime(mskFechaComp.Text.ToString()))
        Dim rutaDirectorio As String = "\\Server1\F\IMAGENES COMPROBANTES\" & yearpath & "\"
        If mskNroInterno.Text = "" Then
            MsgBox("Ingrese algún número interno", MsgBoxStyle.Critical)
        Else
            If Date.ParseExact(mskFechaComp.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) < Date.ParseExact("01/01/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture) Then
                MsgBox("Esta imagen, al igual que todas las anteriores al 01/01/2015," & vbCrLf & "se encuentra archivada en su correspondiente Legajo.", MsgBoxStyle.Information)
            Else
                If DateDiff(DateInterval.Day, DateTime.ParseExact("01/03/2010", "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.Now) >= 0 Then
                    Dim numeroInterno As Integer
                    If Integer.TryParse(mskNroInterno.Text.Replace("_", ""), numeroInterno) Then
                        If numeroInterno < 150303 Then
                            salida = control.BuscarImagen(mskFechaComp.Text, RstAux)
                            Select Case salida
                                Case -1
                                    MsgBox("Error al intentar buscar la Imagen de la Factura", MsgBoxStyle.Information)
                                Case 0
                                    MsgBox("No se encontró la Imagen de la Factura", MsgBoxStyle.Information)
                                Case 1
                                    If Not IsDBNull(RstAux.Rows(0)("Imagen")) Then
                                        Ubic = Trim(RstAux.Rows(0)("Imagen"))
                                        rptImpresoImgComprobante.txtNroInterno.Text = mskNroInterno.Text
                                        rptImpresoImgComprobante.ImgComprobante.Image = System.Drawing.Image.FromFile(Ubic)
                                        frmVisualizador.Viewer1.LoadDocument(rptImpresoImgComprobante)
                                    End If
                                Case 2
                                    Process.Start(rutaDirectorio & Val(mskNroInterno.Text) & ".pdf")
                                    'Shell("explorer.exe", AppWinStyle.NormalFocus, rutaDirectorio & Val(mskNroInterno.Text) & ".pdf")
                            End Select
                        Else
                            Process.Start(rutaDirectorio & Val(mskNroInterno.Text) & ".pdf")
                        End If
                    Else
                        MsgBox("No existe imagen para este comprobante " & vbCrLf & "(Fecha anterior)", MsgBoxStyle.Information)
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub btnRescaneo_Click(sender As Object, e As EventArgs) Handles btnRescaneo.Click
        Dim frmImgComp As New FrmImagenComprobante
        frmImgComp.ShowDialog(Me)
    End Sub
    Private Sub cboDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboDescripcion.KeyPress
        If Keys.Enter Then
            cboTipo.Focus()
        End If
    End Sub
    Private Sub btnCierreDiario_Click(sender As Object, e As EventArgs) Handles btnCierreDiario.Click
        Dim rec As New DataTable
        Dim sql As String
        Dim salida As Long

        If (MessageBox.Show("¿Esta seguro que desea realizar el cierre diario de comprobantes ?", "Cierre diario", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.OK Then Exit Sub
        controlCierre.AcumularCierreDiarioNuevo(rec)

        If rec Is Nothing Then
            MsgBox("Error al consultar datos de comprobantes. No se puede continuar. Contáctese con el Depto. de Sistemas.", vbCritical, "Error en la consulta de comprobante")
            Exit Sub
        ElseIf rec.Rows.Count = 0 Then
            MsgBox("No existen comprobantes para acumular en el día de la fecha o ya se acumularon.", vbInformation, "Información")
            Exit Sub
        Else

            For Each row As DataRow In rec.Rows
                salida = controlCierre.ActualizarAcumulacionComprobante(Convert.ToInt32(row("NroInterno")))
                If salida = -1 Then
                    MsgBox("Error al marcar como pasado un comprobante de proveedor pendiente, contáctese con el Depto. de Sistemas a la brevedad.", vbCritical, "Ocurrio un Error")
                    Exit Sub
                End If
            Next
            MsgBox("La Acumulación de comprobantes pendientes se realizó con éxito.", vbInformation, "Éxito")
        End If

        Exit Sub
    End Sub
    Private Sub cboTipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboTipo.KeyPress
        If Keys.Enter Then
            mskFechaComp.Focus()
            mskFechaComp.SelectAll()
        End If

    End Sub
    Private Sub btnCierreMes_Click(sender As Object, e As EventArgs) Handles btnCierreMes.Click
        Dim frmCierre As New FrmCierre
        frmCierre.ShowDialog(Me)
    End Sub
    Private Sub mskFechaComp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskFechaComp.KeyPress
        If Keys.Enter Then
            mskFechaVto.Focus()
            mskFechaVto.SelectAll()
        End If
    End Sub

    Private Sub mskFechaVto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskFechaVto.KeyPress
        If Keys.Enter Then
            cboCondPago.Focus()
        End If
    End Sub

    Private Sub cboCondPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCondPago.KeyPress
        If Keys.Enter Then
            txtObservaciones.Focus()
        End If
    End Sub

    Private Sub cboProvincia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboProvincia.KeyPress
        If Keys.Enter Then
            txtBaseImp.Focus()
        End If
    End Sub

    Private Sub txtBaseImp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBaseImp.KeyPress
        If ChrW(Keys.Enter) = e.KeyChar Then
            txtPercepcion.Focus()
        End If
    End Sub

    Private totalPercepciones As Double = 0.0
    Private Sub txtPercepcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPercepcion.KeyDown
        If Keys.Enter = e.KeyCode Then
            If txtBaseImp.Text <> "" AndAlso txtPercepcion.Text <> "" Then
                If CDbl(txtBaseImp.Text) < CDbl(txtImpProd.Text) AndAlso CDbl(txtPercepcion.Text) < CDbl(txtBaseImp.Text) Then
                    ' Reemplazar puntos por comas en txtBaseImp
                    Dim baseImpText As String = txtBaseImp.Text.Replace(".", ",")

                    ' Reemplazar puntos por comas en txtPercepcion
                    Dim percepcionText As String = txtPercepcion.Text.Replace(".", ",")

                    DgvIB.Rows.Add($"{cboProvincia.Text}", Format(CDbl(baseImpText), "N2"), Format(CDbl(percepcionText), "N2"), cboProvincia.SelectedValue)

                    totalPercepciones += CDbl(IIf(percepcionText.Trim = "", 0, percepcionText))

                    txtTotalPercepciones.Text = Format(totalPercepciones, "N2")
                    txtPercepIB.Text = totalPercepciones
                    ModuloFunciones.calcularTotalComprobante(Me)
                    txtPercepcion.Text = ""
                    cboProvincia.Focus()

                Else
                    MsgBox("La Base Imponible no puede ser mayor al total de la factura y la percepcion no puede superar a la Base Imp.", vbExclamation, "Cuidado!")
                    txtBaseImp.Text = ""
                    txtPercepcion.Text = ""
                    txtBaseImp.Focus()
                End If
            Else
                MsgBox("Debe completar los campos Base Imp y Percepción previamente", vbExclamation, "Atención!")
            End If
        End If
    End Sub


    Private Sub btnAsignarPDF_Click(sender As Object, e As EventArgs) Handles btnAsignarPDF.Click
        Dim frmAsignarPDF As New FrmAsignadorPDF
        frmAsignarPDF.NroInterno = mskNroInterno.Text
        frmAsignarPDF.ShowDialog(Me)
    End Sub

    Private Sub txtCAI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCAI.KeyPress
        If ChrW(Keys.Enter) = e.KeyChar Then
            mskVtoCAI.Focus()
            mskVtoCAI.SelectAll()
        End If
    End Sub





#End Region
    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim frmAltaIngreso As New FrmAltaIngresoPendiente
        frmAltaIngreso.BtnActualizar.Visible = False
        frmAltaIngreso.btnRegistrar.Visible = True
        frmAltaIngreso.ShowDialog()
        If VariablesGlobales.filanueva IsNot Nothing Then

            If VariablesGlobales.filanueva.Length <= dgvListado.ColumnCount Then
                dgvListado.Rows.Add(VariablesGlobales.filanueva)
                'dgvListado.Refresh()
                VariablesGlobales.filanueva = Nothing
                For i As Integer = 0 To dgvListado.Rows.Count - 1
                    Select Case CStr(dgvListado.Rows(i).Cells(1).Value).Replace(".", "")
            ' Tu lista de códigos de insumos de exportación
                        Case "2030040010001", "2030040010002", "2030040010003", "2030030020001", "2030030020002", "2030030030001", "2030030030002", "2030030030003", "2030050010001", "2030050010002", "2030050010003", "2030050010004"
                            MostrarOperacionExportacion(True)
                            Exit For
                        Case "3020010010002", "1010120010002", "1010120020001", "1010120020002", "1010120030003", "1010120030004", "1010120030005"
                            MostrarOperacionExportacion(False)
                            Exit For
                        Case Else
                            VariablesGlobales.banderaOE = False
                    End Select
                Next
                ModuloGrillas.formatearcolumna7(dgvListado)
                ModuloFunciones.calcularTotalComprobante(Me)
            Else
                MessageBox.Show("La longitud del array no coincide con la cantidad de columnas en la grilla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        For Each filalistado As DataGridViewRow In dgvListado.Rows
            If filalistado.Cells(1).Value.ToString.Trim = "1.01.006.002.0001" Or filalistado.Cells(1).Value.ToString().Trim = "1.01.009.001.0001" Or filalistado.Cells(1).Value.ToString.Trim = "1.01.009.001.0002" Then
                txtPartesalida.Focus()
                Exit For
            Else
                cboProvincia.Focus()
            End If
        Next
    End Sub



    Private Sub dgvListado_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvListado.CellPainting
        If e.RowIndex >= 0 AndAlso (e.ColumnIndex = 11 OrElse e.ColumnIndex = 12) Then
            ' Verifica que sea la celda de la columna de botones
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)

            ' Dibuja la imagen en lugar del texto
            Dim image As Bitmap = Nothing
            Dim buttonText As String = ""
            If e.ColumnIndex = 11 Then
                ' Modificar
                image = My.Resources.edit
                buttonText = ""
            ElseIf e.ColumnIndex = 12 Then
                ' Eliminar
                image = My.Resources.borrar
                buttonText = ""
            End If

            If image IsNot Nothing Then
                ' Calcula las posiciones para centrar la imagen en el botón
                Dim imageX = CInt(e.CellBounds.Left + (e.CellBounds.Width - image.Width) / 2)
                Dim imageY = CInt(e.CellBounds.Top + (e.CellBounds.Height - image.Height) / 2)

                ' Dibuja la imagen en el botón
                e.Graphics.DrawImage(image, imageX, imageY, image.Width, image.Height)
            End If
            e.Handled = True
        End If
    End Sub


    Private Sub dgvListado_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListado.CellMouseEnter
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = dgvListado.Columns("btnAccion").Index Or e.ColumnIndex = dgvListado.Columns("btnEliminar").Index Then
            dgvListado.Cursor = Cursors.Hand
        End If
    End Sub

    Private Sub dgvListado_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListado.CellMouseLeave
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = dgvListado.Columns("btnAccion").Index Or e.ColumnIndex = dgvListado.Columns("btnEliminar").Index Then
            dgvListado.Cursor = Cursors.Default
        End If
    End Sub



    Private Sub dgvListado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListado.CellClick
        If e.ColumnIndex = 11 AndAlso e.RowIndex >= 0 Then

            ' Obtén los valores de la fila seleccionada
            Dim nroIngreso As String = dgvListado.Rows(e.RowIndex).Cells(0).Value.ToString()
            Dim codInsumo As String = dgvListado.Rows(e.RowIndex).Cells(1).Value.ToString()
            Dim descInsumo As String = dgvListado.Rows(e.RowIndex).Cells(2).Value.ToString()
            Dim cantidad As String = dgvListado.Rows(e.RowIndex).Cells(3).Value.ToString()
            Dim precio As String = dgvListado.Rows(e.RowIndex).Cells(4).Value.ToString()
            Dim total As String = dgvListado.Rows(e.RowIndex).Cells(5).Value.ToString()
            Dim centroCosto As String = dgvListado.Rows(e.RowIndex).Cells(6).Value.ToString()

            ' Abre el formulario FrmAltaIngresoPendiente
            Dim frmModificar As New FrmAltaIngresoPendiente()

            ' Asigna los valores a los controles en FrmAltaIngresoPendiente
            frmModificar.txtNroIngreso.Text = nroIngreso
            frmModificar.mskCodInsumo.Text = codInsumo
            frmModificar.txtDescripcion.Text = descInsumo
            frmModificar.txtCantidad.Text = cantidad
            frmModificar.txtPrecio.Text = precio
            frmModificar.txtTotal.Text = total
            frmModificar.txtCentroCosto.Text = centroCosto
            frmModificar.btnRegistrar.Visible = False
            frmModificar.BtnActualizar.Visible = True

            ' Abre el formulario como modal
            frmModificar.ShowDialog()
            ' Actualiza la fila en dgvListado con los valores modificados
            If VariablesGlobales.filanueva IsNot Nothing Then
                dgvListado.Rows(e.RowIndex).Cells(0).Value = VariablesGlobales.filanueva(0)
                dgvListado.Rows(e.RowIndex).Cells(1).Value = VariablesGlobales.filanueva(1)
                dgvListado.Rows(e.RowIndex).Cells(2).Value = VariablesGlobales.filanueva(2)
                dgvListado.Rows(e.RowIndex).Cells(3).Value = VariablesGlobales.filanueva(3)
                dgvListado.Rows(e.RowIndex).Cells(4).Value = VariablesGlobales.filanueva(4)
                dgvListado.Rows(e.RowIndex).Cells(5).Value = VariablesGlobales.filanueva(5)
                dgvListado.Rows(e.RowIndex).Cells(6).Value = VariablesGlobales.filanueva(6)
                VariablesGlobales.filanueva = Nothing

            End If
            'MostrarOperacionExportacion()
            For i As Integer = 0 To dgvListado.Rows.Count - 1
                Select Case CStr(dgvListado.Rows(i).Cells(1).Value).Replace(".", "")
            ' Tu lista de códigos de insumos de exportación
                    Case "2030040010001", "2030040010002", "2030040010003", "2030030020001", "2030030020002", "2030030030001", "2030030030002", "2030030030003", "2030050010001", "2030050010002", "2030050010003", "2030050010004"
                        MostrarOperacionExportacion(True)
                        Exit For
                    Case "3020010010002", "1010120010002", "1010120020001", "1010120020002", "1010120030003", "1010120030004", "1010120030005"
                        MostrarOperacionExportacion(False)
                        Exit For
                    Case Else
                        VariablesGlobales.banderaOE = False
                End Select
            Next
            ModuloGrillas.formatearcolumna7(dgvListado)

            If rbtAlicVarias.Checked = False Then
                ModuloFunciones.calcularTotalComprobante(Me)
            End If
        ElseIf e.ColumnIndex = 12 AndAlso e.RowIndex >= 0 Then
            dgvListado.Rows.RemoveAt(e.RowIndex)
            txtImp21.Text = ""
            txtImpProd.Text = ""
            txtImp105.Text = ""
            txtImp27.Text = ""
            txtImp75.Text = ""
            txtGrav21.Text = ""
            txtGrav105.Text = ""
            txtGrav27.Text = ""
            txtGrav75.Text = ""
            txtIVAProd.Text = ""
            txtPercepGanancia.Text = ""
            txtPercepIB.Text = ""
            txtPercepIva.Text = ""
            txtImpPais.Text = ""
            txtImpNoImp.Text = ""
            txtTotalComp.Text = ""
            txtTotalGrav.Text = ""
            txtTotalImp.Text = ""
            rbtAlicNormal.Checked = True
            btnNuevo.Enabled = True
            If dgvListado.Rows.Count > 0 Then
                ModuloFunciones.calcularTotalComprobante(Me)
            End If
        End If
    End Sub

    Private Sub btnCAI_Click(sender As Object, e As EventArgs) Handles btnCAI.Click
        If Val(mskNroProveedor.Text) <= 0 Then
            MsgBox("Ingrese un proveedor para cargar su CAI correspondiente.", vbInformation)
            mskNroProveedor.Focus()
            Exit Sub
        Else
            Dim frmAltaCAI As New FrmAltaCAI(Me)
            frmAltaCAI.txtProveedor.Text = mskNroProveedor.Text
            frmAltaCAI.ShowDialog()
        End If
    End Sub

    Private Sub dgvOrdenDeCarga_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOrdenDeCarga.RowLeave
        dgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub txtPartesalida_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPartesalida.KeyDown
        If e.KeyCode = Keys.Enter Then
            Txtvalor.Focus()
        End If
    End Sub

    Private Sub Txtvalor_KeyDown(sender As Object, e As KeyEventArgs) Handles Txtvalor.KeyDown
        Dim EncontroInsumo As Boolean
        Dim RstPS As New DataTable
        Dim RstOC As New DataTable

        If e.KeyCode = Keys.Enter Then
            If txtPartesalida.Text <> "" AndAlso Txtvalor.Text <> "" Then
                ' Reemplazar puntos por comas en txtBaseImp
                Dim parteSalida As String = txtPartesalida.Text.Replace(".", ",")

                ' Reemplazar puntos por comas en txtPercepcion
                Dim valor As String = Txtvalor.Text.Replace(".", ",")

                dgvOrdenDeCarga.Rows.Add(Format(CDbl(parteSalida), "N2"), Format(CDbl(valor), "N2"))
                txtPartesalida.Text = ""
                Txtvalor.Text = ""
                txtPartesalida.Focus()
            Else
                MsgBox("Debe completar los campos Parte salida y valor.", vbExclamation, "Atención!")
            End If
            If lblParteSalida.Text = "Partes de Salida" Then
                For Each filalistado As DataGridViewRow In dgvListado.Rows
                    If filalistado.Cells(1).Value.ToString.Trim = "1.01.006.002.0001" Or filalistado.Cells(1).Value.ToString().Trim = "1.01.009.001.0001" Or filalistado.Cells(1).Value.ToString.Trim = "1.01.009.001.0002" Then
                        EncontroInsumo = True
                    Else
                        EncontroInsumo = False
                    End If
                Next
            End If
            If EncontroInsumo = False Then
                'esto es para que no me de error el argumento vacio
                RstOC.Columns.Add("NroOrdenCarga", GetType(Double))

                ' Crear un DataTable para NroParteSalida

                RstPS.Columns.Add("NroParteSalida", GetType(Double))
                RstPS.Columns.Add("Valor", GetType(Double))

            Else
                'Controla el parte de salida que no este ya ingresado
                If FuncionControlarParteSalida(RstPS) = True Then
                    ModuloGrillas.InicializarGrillaParteSalida(dgvOrdenDeCarga)
                    btnGuardar.Enabled = False
                End If
                'esto es para que no me de error el argumento vacio
                RstOC.Columns.Add("NroOrdenCarga", GetType(Double))

            End If

        End If
    End Sub

    Private Sub txtObservaciones_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObservaciones.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnRegistrar.Focus()
        End If
    End Sub

    Private Sub btnCondPago_Click(sender As Object, e As EventArgs) Handles btnCondPago.Click
        Dim frmAltaCondPago As New FrmAltaCondPago(Me)
        frmAltaCondPago.ShowDialog()
        ModuloComboBox.CargarCboCondiciones(cboCondPago)
    End Sub

    Private Sub rbtAlicNormal_CheckedChanged(sender As Object, e As EventArgs) Handles rbtAlicNormal.CheckedChanged
        If rbtAlicNormal.Checked = True Then
            txtGrav105.Enabled = False
            txtImp105.Enabled = False
            txtGrav27.Enabled = False
            txtImp27.Enabled = False
            txtGrav75.Enabled = False
            txtImp75.Enabled = False
            txtImp21.Text = ""
            txtGrav21.Text = ""
            txtGrav27.Text = ""
            txtImp27.Text = ""
            txtGrav75.Text = ""
            txtImp75.Text = ""
            txtImp105.Text = ""
            txtGrav105.Text = ""
            txtImpPais.Text = ""
        Else
            txtGrav105.Enabled = True
            txtImp105.Enabled = True
            txtGrav27.Enabled = True
            txtImp27.Enabled = True
            txtGrav75.Enabled = True
            txtImp75.Enabled = True
        End If
    End Sub

    Private Sub btnMinimizar_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub MostrarOperacionExportacion(ByVal auxexportacion As Boolean)
        Dim frmOperacionExp As New FrmOperacionExportacion(Me)
        Dim newlyAddedRowIndex As Integer = -1


        With frmOperacionExp
            .InsumoExportacion = auxexportacion
            .codComprobante = 0
            .codMoneda = 0

            If Not String.IsNullOrEmpty(txtCotizacion.Text) AndAlso CDbl(txtCotizacion.Text) <> 0 Then
                .Importe = Math.Round(dgvListado.Rows(dgvListado.CurrentCell.RowIndex).Cells(6).Value / CDbl(txtCotizacion.Text), 2)
            Else
                .Importe = 0
            End If

            .Tipocomp = 0
            .numero = 0
        End With

        For i As Integer = 0 To dgvExportacion.Rows.Count - 1
            If dgvExportacion.Rows(i).Cells(5).Value = dgvListado.CurrentCell.RowIndex Then
                With frmOperacionExp
                    .codComprobante = CInt(dgvExportacion.Rows(i).Cells(0).Value)
                    .codMoneda = CInt(dgvExportacion.Rows(i).Cells(1).Value)

                    If Not String.IsNullOrEmpty(txtCotizacion.Text) AndAlso CDbl(txtCotizacion.Text) <> 0 Then
                        .Importe = Math.Round(dgvListado.Rows(dgvListado.CurrentCell.RowIndex).Cells(6).Value / CDbl(txtCotizacion.Text), 2)
                    Else
                        .Importe = 0
                    End If

                    .Tipocomp = CInt(dgvExportacion.Rows(i).Cells(2).Value)
                    .numero = CInt(dgvExportacion.Rows(i).Cells(3).Value)
                End With
                Exit For
            End If
        Next i

        frmOperacionExp.codRowGrilla = dgvListado.CurrentCell.RowIndex
        frmOperacionExp.ShowDialog()

        ' Bucle para buscar códigos de insumos de exportación y resaltar la columna 7
        For Each dgvRow As DataGridViewRow In dgvListado.Rows
            Dim cellValue = dgvRow.Cells(1).Value

            If cellValue IsNot Nothing AndAlso Not IsDBNull(cellValue) Then
                Select Case CStr(cellValue).Replace(".", "")
            ' Tu lista de códigos de insumos de exportación
                    Case "2030040010001", "2030040010002", "2030040010003", "2030030020001", "2030030020002", "2030030030001", "2030030030002", "2030030030003", "2030050010001", "2030050010002", "2030050010003", "2030050010004"
                        ' Si se encuentra uno de los códigos, pintar de verde la columna 7
                        If VariablesGlobales.banderaOE = False Then
                            dgvRow.Cells(7).Style.ForeColor = Color.Red
                        Else
                            dgvRow.Cells(7).Style.ForeColor = Color.Green
                        End If
                End Select
            End If
        Next dgvRow
        ModuloGrillas.formatearcolumna7(dgvListado)
        dgvListado.CurrentCell = dgvListado.Rows(dgvListado.CurrentCell.RowIndex).Cells(1)

    End Sub


    Private Sub dgvListado_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvListado.CellFormatting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = 7 Then
            Dim isSelected As Boolean = dgvListado.Rows(e.RowIndex).Selected
            Dim hasFocus As Boolean = dgvListado.Focused AndAlso dgvListado.CurrentCell IsNot Nothing AndAlso dgvListado.CurrentCell.RowIndex = e.RowIndex

            ' Ajustar el estilo de la celda según si está seleccionada y tiene el foco
            If isSelected Then
                Select Case CStr(dgvListado.Rows(e.RowIndex).Cells(1).Value).Replace(".", "")
            ' Tu lista de códigos de insumos de exportación
                    Case "2030040010001", "2030040010002", "2030040010003", "2030030020001", "2030030020002", "2030030030001", "2030030030002", "2030030030003", "2030050010001", "2030050010002", "2030050010003", "2030050010004", "3020010010002", "1010120010002", "1010120020001", "1010120020002", "1010120030003", "1010120030004", "1010120030005"
                        ' Si se encuentra uno de los códigos, pintar de verde la columna 7
                        If VariablesGlobales.banderaOE = False Then
                            e.CellStyle.SelectionForeColor = Color.Red
                        Else
                            e.CellStyle.SelectionForeColor = Color.Green
                        End If
                    Case Else
                        e.CellStyle.SelectionForeColor = Color.Red
                        e.CellStyle.SelectionBackColor = dgvListado.DefaultCellStyle.SelectionBackColor
                End Select
                ' Verificar si la celda tiene el foco y cambiar el color de fondo si es necesario
                If hasFocus Then
                    e.CellStyle.BackColor = dgvListado.DefaultCellStyle.SelectionBackColor
                End If
            End If
        End If
    End Sub



    Private Sub validarCamposNumericos(sender As Object, e As KeyPressEventArgs) Handles txtBaseImp.KeyPress, txtPercepcion.KeyPress, txtPartesalida.KeyPress, Txtvalor.KeyPress, txtImpProd.KeyPress, txtImpNoImp.KeyPress, txtIVAProd.KeyPress, txtPercepGanancia.KeyPress, txtPercepIB.KeyPress, txtTotalComp.KeyPress, txtGrav105.KeyPress, txtGrav21.KeyPress, txtGrav27.KeyPress, txtGrav75.KeyPress, txtImp105.KeyPress, txtImp21.KeyPress, txtImp75.KeyPress, txtImp27.KeyPress, txtCAI.KeyPress, txtPercepIva.KeyPress, txtImpPais.KeyPress, txtTotalGrav.KeyPress, txtTotalImp.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            MsgBox("Debe ingresar valores numéricos únicamente.", vbExclamation, "Atención!")
            e.Handled = True
        End If
    End Sub

    Private Sub txtGrav105_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGrav105.KeyDown
        If e.KeyCode = Keys.Enter Then
            If rbtAlicVarias.Checked = True Then
                If String.IsNullOrWhiteSpace(txtGrav105.Text) Then
                    txtGrav105.Text = "0"
                End If

                If String.IsNullOrWhiteSpace(txtGrav27.Text) Then
                    txtGrav27.Text = "0"
                End If

                If String.IsNullOrWhiteSpace(txtGrav75.Text) Then
                    txtGrav75.Text = "0"
                End If
                txtImp105.Text = CDbl(txtGrav105.Text * 0.105).ToString("N2")
                txtImp75.Text = CDbl(txtGrav75.Text * 0.175).ToString("N2")
            End If
            txtGrav27.Focus()
            ModuloFunciones.calcularTotalComprobante(Me)
        End If
    End Sub

    Private Sub txtGrav27_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGrav27.KeyDown, txtGrav75.KeyDown
        If e.KeyCode = Keys.Enter Then
            If rbtAlicVarias.Checked = True Then
                If String.IsNullOrWhiteSpace(txtGrav27.Text) Then
                    txtGrav27.Text = "0"
                End If
                If String.IsNullOrWhiteSpace(txtGrav75.Text) Then
                    txtGrav75.Text = "0"
                End If
                txtImp27.Text = CDbl(txtGrav27.Text * 0.27).ToString("N2")
                txtImp75.Text = CDbl(txtGrav75.Text * 0.175).ToString("N2")
            End If
            txtGrav75.Focus()
            ModuloFunciones.calcularTotalComprobante(Me)
        End If
    End Sub

    Private Sub txtGrav105_TextChanged(sender As Object, e As EventArgs) Handles txtGrav105.TextChanged, txtGrav27.TextChanged, txtGrav75.TextChanged
        If txtGrav105.Text.Trim() = "" Then
            txtGrav105.Text = "0"
            txtImp105.Text = "0"
        ElseIf txtGrav27.Text.Trim() = "" Then
            txtGrav27.Text = "0"
            txtImp27.Text = "0"
        ElseIf txtGrav75.Text.Trim() = "" Then
            txtGrav75.Text = "0"
            txtImp75.Text = "0"
        End If
        ModuloFunciones.calcularTotalComprobante(Me)
    End Sub

    Private Sub txtImpNoImp_KeyDown(sender As Object, e As KeyEventArgs) Handles txtImpNoImp.KeyDown
        If e.KeyCode = Keys.Enter Then
            ModuloFunciones.CalcularTotalComprobante(Me)
            txtPercepGanancia.Focus()
        End If
    End Sub

    Private Sub txtPercepGanancia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPercepGanancia.KeyDown
        If e.KeyCode = Keys.Enter Then
            ModuloFunciones.CalcularTotalComprobante(Me)
            txtPercepIva.Focus()
        End If
    End Sub

    Private Sub txtPercepIva_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPercepIva.KeyDown
        If e.KeyCode = Keys.Enter Then
            ModuloFunciones.CalcularTotalComprobante(Me)
            txtPercepIB.Focus()
        End If
    End Sub

    Private Sub txtPercepIB_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPercepIB.KeyDown
        If e.KeyCode = Keys.Enter Then
            ModuloFunciones.CalcularTotalComprobante(Me)
            txtImpPais.Focus()
        End If
    End Sub

    Private Sub txtImpPais_KeyDown(sender As Object, e As KeyEventArgs) Handles txtImpPais.KeyDown
        If e.KeyCode = Keys.Enter Then
            ModuloFunciones.CalcularTotalComprobante(Me)

        End If
    End Sub
End Class


