Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Numerics
Imports System.Runtime.InteropServices
Imports System.Web.UI.WebControls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Window
Imports ClasesGlobal
Imports Controles
Imports GrapeCity.ActiveReports.Design.DdrDesigner.Services.Infrastructure.ReportData.DataSourceException
Imports Modelos

Public Class FrmCreditoDebitoInt

    Dim controlinforme As New ControlerInforme
    Dim controldebcred As New ControlerNotaCredDeb
    Private Estado As String
    Dim control As New ControlerProveedor
    Dim tabla As New DataTable
    Private dictDescripcion As New Dictionary(Of Integer, String)
    Private codigoSeleccionado As Integer = -1
    Private Sub HabilitarControles(ByRef opcion As String)
        Select Case opcion
            Case "GUARDAR"
            Case "LIMPIAR"
                LimpiarControles()
            Case "IMPRIMIR"
            Case "SALIR"
        End Select
    End Sub


    Private Sub LimpiarControles()
        mskNroProveedor.BackColor = Color.White
        cboTipo.BackColor = Color.White
        cboDescripcion.BackColor = Color.White
        mskNroComprobante.BackColor = Color.White
        txtCAI.BackColor = Color.White
        mskVtoCAI.BackColor = Color.White
        txtCAI.Text = ""
        mskVtoCAI.Text = "00/00/0000"
        mskVtoCAI.Enabled = True
        txtCAI.Enabled = True
        mskFecha.Text = Format(Date.Now, "dd/MM/yyyy")
        txtObservaciones.Text = ""
        mskNroComprobante.Text = ""
        cboTipo.SelectedValue = 1
        cboDescripcion.SelectedValue = 1
        txtImpProd.Text = ""
        txtIB.Text = ""
        txtIE.Text = ""
        txtIva.Text = ""
        txtPercep.Text = ""
        txtTotal.Text = ""
        TxtCondIVA.Text = ""
        mskFecha.Enabled = False
        lstInsumo.DataSource = Nothing
        chkPorCuentaTercero.Checked = False
        mskNroProveedor.Enabled = True
        btnBuscarProveedor.Enabled = True
        GPanel5.Enabled = False
        txtImpProd.Enabled = True
        txtIB.Enabled = True
        txtIva.Enabled = True
        txtPercep.Enabled = True
        btnNuevo.Enabled = True
        btnCancelar.Enabled = False
        btnSalir.Enabled = True
        btnGuardar.Enabled = False
        mskNroProveedor.Text = ""
        cboTipo.SelectedIndex = -1
        mskFecha.Text = ""
        cboDescripcion.SelectedIndex = -1
        GPanel1.Enabled = False
        GPanel2.Enabled = False
        GPanel3.Enabled = False
        GPanel4.Enabled = False
        GPanel5.Enabled = False
        GPanel6.Enabled = False
        VariablesGlobales.numeroProveedor = ""
        VariablesGlobales.razonSocial = ""
        VariablesGlobales.direccion = ""
        VariablesGlobales.localidad = ""
        VariablesGlobales.condicionIva = ""
    End Sub

    Private Sub FrmCreditoDebito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HabilitarControles("LIMPIAR")
        HabilitarControles("BUSQUEDA")
        AddHandler mskNroProveedor.KeyDown, AddressOf mskNroProveedor_KeyDown
        If controldebcred.ObtenerPrefijo("C") Then
            btnNuevo.Enabled = True 'Nuevo
        Else

        End If
        mskNroComprobante.Enabled = True
        cargarCombo()
        Cargarcbodescripcion()
        cboDescripcion.SelectedIndex = -1
        cboTipo.SelectedIndex = 5
    End Sub

    Private Sub BuscarNuevoNumero()
        Dim Mayor As Long
        'creditos
        'preguntar si es un credito cargarlo
        If cboDescripcion.SelectedIndex >= 7 And cboDescripcion.SelectedIndex < 13 Then

            Mayor = controldebcred.ObtenerUltimoCreditoDebito(1)
        End If

        'debitos
        If cboDescripcion.SelectedIndex < 7 And cboDescripcion.SelectedIndex >= 3 And cboDescripcion.SelectedIndex > 12 Then

            Mayor = controldebcred.ObtenerUltimoCreditoDebito(2)
        End If
        If Mayor = -1 Or Mayor = 0 Then
            MsgBox("Error al obtener último Crédito o Debito.", vbCritical)
            Exit Sub
        End If

        mskNroComprobante.Text = Format(Mayor + 1 + 400000000000.0#, "000000000000")
    End Sub

    Private Sub cargarCombo()
        Try
            Dim rec As New DataTable
            Dim i As Long

            i = controlinforme.BuscarTipos(rec)

            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList
            If rec.Rows.Count = 0 Then
                MsgBox("No se poseen datos de Tipos de Comprobantes.", MsgBoxStyle.Information, Me.Text)
                Exit Sub
            Else
                ' Add the "TODAS" item
                cboTipo.Items.Add("TODAS")
                cboTipo.SelectedIndex = 0

                For Each row As DataRow In rec.Rows
                    ' Add other items
                    cboTipo.Items.Add(row("Descripcion").ToString().Replace("'", "´"))
                    cboTipo.SelectedIndex = cboTipo.Items.Count - 1
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Cargarcbodescripcion()
        Dim rec As DataTable
        Dim i As Long
        Dim control As New ControlerProveedor
        i = control.BuscarDescripcionComprobantesTodos(rec)

        cboDescripcion.DropDownStyle = ComboBoxStyle.DropDownList
        If i = 0 Then
            MsgBox("No se poseen datos de Descripciones.", MsgBoxStyle.Information, Me.Text)
            Exit Sub
        ElseIf i = -1 Then
            MsgBox("Error al obtener datos de Descripciones.", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        Else
            'cboDescripcion.DataSource = rec
            'cboDescripcion.ValueMember = "codigo"
            'cboDescripcion.DisplayMember = "Descripcion"
            For Each row As DataRow In rec.Rows
                ' Add all elements except those with codigo 11
                If Not (row("codigo") = 11) Then
                    cboDescripcion.Items.Add(row("Descripcion").ToString().Replace("'", "´"))
                    dictDescripcion.Add(DirectCast(row("codigo"), Integer), row("Descripcion").ToString().Replace("'", "´"))
                End If
            Next

        End If

        If cboDescripcion.Items.Count > 0 Then
            cboDescripcion.SelectedValue = 23
        End If

        i = control.BuscarTipos(rec)
        If i = 0 Then
            MsgBox("No se poseen datos de Tipos de Comprobantes.", vbInformation, Me.Text)
            Exit Sub
        ElseIf i = -1 Then
            MsgBox("Error al obtener datos de Tipos de Comprobantes.", vbCritical, Me.Text)
            Exit Sub
        Else
            cboTipo.DataSource = rec
            cboTipo.ValueMember = "codigo"
            cboTipo.DisplayMember = "descripcion"
        End If
        If cboTipo.Items.Count > 0 Then
            cboTipo.SelectedValue = 0
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Estado = "NUEVO"
        LimpiarControles()
        cboTipo.SelectedIndex = 5
        GPanel1.Enabled = True
        GPanel2.Enabled = False
        GPanel3.Enabled = True
        GPanel4.Enabled = True
        GPanel5.Enabled = True
        GPanel6.Enabled = True
        mskNroComprobante.Enabled = False
        btnNuevo.Enabled = False
        btnGuardar.Enabled = True
        btnImprimir.Enabled = True
        btnCancelar.Enabled = True
        btnSalir.Enabled = True
        mskFecha.Text = Format(Now, "dd/MM/yyyy")
        mskNroProveedor.Focus()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        Dim frm As New FrmPrincipal
        frm.Show()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        HabilitarControles("LIMPIAR")
    End Sub

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
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub mskNroProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles mskNroProveedor.KeyDown
        ' Verificar si la tecla presionada es ENTER
        If e.KeyCode = Keys.Enter Then
            BuscarProveedor()
        End If
    End Sub

    Private Sub btnBuscarProveedor_Click(sender As Object, e As EventArgs) Handles btnBuscarProveedor.Click
        BuscarProveedor()
    End Sub

    Private Sub BuscarProveedor()
        txtRazonSocial.Enabled = False
        txtDireccion.Enabled = False
        txtLocalidad.Enabled = False
        TxtCondIVA.Enabled = False
        Try
            If (mskNroProveedor.Text = "") Then
                FrmBuscarProveedor.ShowDialog()
                If VariablesGlobales.numeroProveedor <> Nothing And VariablesGlobales.razonSocial <> Nothing Then
                    mskNroProveedor.Text = VariablesGlobales.numeroProveedor
                    txtRazonSocial.Text = VariablesGlobales.razonSocial
                    txtDireccion.Text = VariablesGlobales.direccion
                    txtLocalidad.Text = VariablesGlobales.localidad
                    TxtCondIVA.Text = VariablesGlobales.condicionIva
                End If
            Else
                If control.BuscarPorNroProveedor(mskNroProveedor.Text, tabla) = 1 Then
                    For Each row As DataRow In tabla.Rows
                        mskNroProveedor.Text = row.Item(0).ToString()
                        txtRazonSocial.Text = row.Item(1).ToString()
                        txtDireccion.Text = row.Item(2).ToString()
                        txtLocalidad.Text = row.Item(3).ToString()
                        If row.Item(4).ToString().Trim = "N" Then
                            TxtCondIVA.Text = "INSCRIPTO"
                        Else
                            If row.Item(4).ToString().Trim = "S" Then
                                TxtCondIVA.Text = "CONVENIO MULTILATERAL"
                            Else
                                TxtCondIVA.Text = "EXENTO"
                            End If
                        End If
                    Next

                Else
                    MsgBox("No se encontraron resultados para la busqueda solicitada")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub mskNroProveedor_TextChanged(sender As Object, e As EventArgs) Handles mskNroProveedor.TextChanged
        If (mskNroProveedor.Text = "") Then
            txtDireccion.Text = ""
            txtRazonSocial.Text = ""
            txtLocalidad.Text = ""
            TxtCondIVA.Text = ""
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
    Private Sub CargarInsumos()
        ' Crear un DataTable para almacenar los datos
        Dim dtInsumos As New DataTable

        ' Definir las columnas del DataTable
        dtInsumos.Columns.Add("Codigo", GetType(String))
        dtInsumos.Columns.Add("Descripcion", GetType(String))
        dtInsumos.Columns.Add("ItemData", GetType(Integer))

        ' Agregar filas al DataTable
        If cboDescripcion.SelectedIndex <> -1 Then
            codigoSeleccionado = DirectCast(dictDescripcion.FirstOrDefault(Function(kv) kv.Value = cboDescripcion.SelectedItem.ToString()).Key, Integer)
            Select Case codigoSeleccionado
                Case 17
                    AgregarInsumo(dtInsumos, "1010140010002", "1010140010002 - Diferencia Cotización Saldo Acreedor", 2)
                    AgregarInsumo(dtInsumos, "1010100050001", "1010100050001 - RET POR EMBARGOS A 3º", 14)
                Case 18
                    AgregarInsumo(dtInsumos, "1010140010001", "1010100050001 - Diferencia Cotización Saldo Deudor", 1)
                    AgregarInsumo(dtInsumos, "1010100050001", "1010100050001 - RET POR EMBARGOS A 3º", 14)
                Case 19, 20
                    AgregarInsumo(dtInsumos, "1010060020006", "1010060020006 - Patentes Rodados de Transportes", 3)
                Case 5, 12
                    AgregarInsumo(dtInsumos, "1010100020001", "1010100020001 - Cheques Rechazados", 9)
                    AgregarInsumo(dtInsumos, "1010100020002", "1010100020002 - Gastos Cheques Rechazados", 10)
                    AgregarInsumo(dtInsumos, "1010100050001", "1010100050001 - RET POR EMBARGOS A 3º", 14)
                Case 10, 14
                    AgregarInsumo(dtInsumos, "1010130010001", "1010130010001 - Bonificaciones Rec. Comerciales", 11)
                    AgregarInsumo(dtInsumos, "1010130010002", "1010130010002 - Bonificaciones  Rec. Financieras", 12)
                    AgregarInsumo(dtInsumos, "1010100050001", "1010100050001 - RET POR EMBARGOS A 3º", 14)
                Case 21, 22
                    AgregarInsumo(dtInsumos, "1010100010008", "1010100010008 - Regularización de Cuenta", 13)
                    AgregarInsumo(dtInsumos, "1010100050001", "1010100050001 - RET POR EMBARGOS A 3º", 14)
                    AgregarInsumo(dtInsumos, "1010120020002", "1010120020002 - Gastos Varios de Importación", 15)
            End Select
        End If
        lstInsumo.DataSource = dtInsumos
        lstInsumo.DisplayMember = "Descripcion"
        lstInsumo.ValueMember = "Codigo"
        If lstInsumo.Items.Count > 0 Then
            lstInsumo.SetItemChecked(0, True)
            lstInsumo.SelectedIndex = 0
        End If
    End Sub

    Private Sub AgregarInsumo(dt As DataTable, codigo As String, descripcion As String, itemData As Integer)
        ' Agregar una nueva fila al DataTable
        Dim nuevaFila As DataRow = dt.NewRow()
        nuevaFila("Codigo") = codigo
        nuevaFila("Descripcion") = descripcion
        nuevaFila("ItemData") = itemData
        dt.Rows.Add(nuevaFila)
    End Sub
    Private Sub cboDescripcion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDescripcion.SelectedIndexChanged
        If cboDescripcion.Text.Trim <> "" Then
            CargarInsumos()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If String.IsNullOrEmpty(txtTotal.Text) OrElse String.IsNullOrEmpty(txtIE.Text) Then
            MsgBox("Por favor, complete los campos de importes antes de guardar.", vbExclamation, "Advertencia!")
            txtIE.Focus()
            Exit Sub
        End If
        Dim rstPercep As New DataTable
        Dim rstIngreso As New DataTable
        Dim RstAux As New DataTable
        Dim RstOC As New DataTable
        Dim RstPS As New DataTable
        Dim rstUPPrefijo As New DataTable
        Dim rstCAI As New DataTable
        Dim j As Integer
        Dim i As Integer
        Dim totalimporte As Double = 0
        Dim totalGravado As Double = 0
        Dim totalIva As Double = 0
        Dim totalExento As Double = 0
        Dim oiva As Double = 0
        Dim Tipo_Moneda As Integer = 0
        Dim oTNroComprobante As Double
        Dim oNroComprobante As String
        Dim cae As String = ""

        Dim insumo As String
        Dim SIva As Double = 0
        Dim SGravado As Double = 0
        Dim SumaTotal As Double = 0
        Dim SumaExento As Double = 0
        Dim SumaGravado As Double = 0
        Dim SumaImpProd As Double = 0
        Dim SumaSubtotalimporteIVA As Double = 0
        Dim respuesta As Integer
        Dim modelo As New ModeloTablaCreditoDebito
        Dim oPorCuentaDeTercero As Integer
        Dim oTipoComp As String
        Dim PrefijoAFacturar As Double


        If cboTipo.SelectedIndex < 0 Then
            MsgBox("Debe Cargar un tipo de comprobante Válida.", vbInformation)
            rstPercep = Nothing
            RstAux = Nothing
        End If

        Dim salida As Long

        '*****************************************************
        '---------------- DETALLE DE INGRESOS ----------------
        ' ARMA RECORDSET CON NROS. DE INGRESOS DE PARA EL COMP.
        '*****************************************************

        modelo.ArmarTablas(rstPercep, rstIngreso)


        SIva = 0
        SGravado = 0
        SIva = 0
        SGravado = 0
        SumaGravado = 0
        SumaExento = txtIE.Text
        SumaTotal = txtIE.Text


        With lstInsumo
            For i = 0 To .Items.Count - 1
                If .GetItemChecked(i) Then
                    Dim row As DataRow = rstIngreso.NewRow()
                    row("nroingreso") = 0
                    row("codInsumo") = Trim(Mid(.Text(i).ToString(), 1, 13))
                    row("descinsumo") = Trim(Mid(.Text(i).ToString(), 16, 70))
                    row("cantidad") = 1
                    row("precio") = CDbl(txtIE.Text)
                    row("Exento") = CDbl(txtIE.Text)
                    row("total") = CDbl(txtTotal.Text)
                    insumo = controldebcred.BuscarCentroCostoXInsumo(row("codInsumo").ToString())
                    If insumo = "" Then
                        row("cc") = 0
                    Else
                        row("cc") = insumo
                    End If
                    rstIngreso.Rows.Add(row)
                End If
            Next i
        End With



        If Not String.IsNullOrEmpty(txtTotal.Text) AndAlso Not String.IsNullOrEmpty(txtIE.Text) Then
            ' Parse the text to Double
            SumaTotal = CDbl(txtTotal.Text)
            SumaExento = CDbl(txtIE.Text)
            If SumaTotal <> SumaExento + SumaGravado Then
                rstPercep = Nothing
                rstIngreso = Nothing
                RstAux = Nothing
                RstOC = Nothing
                RstPS = Nothing
            End If
        Else
            ' Handle the case where any of the textboxes is empty
            MsgBox("Ingrese valores válidos en los campos de importes.", vbInformation)
        End If



        'DEACURDO AL USUARIO MANEJO EL PREFIJO

        If cboDescripcion.SelectedIndex = -1 Then

        Else
            codigoSeleccionado = DirectCast(dictDescripcion.FirstOrDefault(Function(kv) kv.Value = cboDescripcion.SelectedItem.ToString()).Key, Integer)
            Select Case codigoSeleccionado
                Case 5, 14, 17, 19, 21 'Debitos
                    oTipoComp = "D"
                Case 10, 12, 18, 20, 22 'Creditos
                    oTipoComp = "C"
                Case Else
                    MsgBox("Tipo de comprobante no valido para la creción del nuevo registro.", vbCritical)
            End Select
        End If



        PrefijoAFacturar = 9997


        Dim Rst As New DataTable

        If controldebcred.ObtenerNumeracion(Rst, PrefijoAFacturar, oTipoComp) = -1 Then
            MsgBox("Error al obtener numero para la creación del nuevo comprobante", vbCritical)
            Exit Sub
        Else
            For Each fila As DataRow In Rst.Rows
                oTNroComprobante = fila("numero") + 1
                Dim a As String
                a = PrefijoAFacturar & "00000000"
                oNroComprobante = Format(oTNroComprobante + a, "000000000000")
            Next
        End If



        If cae = "" Then



            If controldebcred.ObtenerNumeracion(rstCAI, PrefijoAFacturar, oTipoComp) = 1 Then
                If rstCAI IsNot Nothing AndAlso rstCAI.Rows.Count > 0 Then

                    txtCAI.Text = Trim(rstCAI.Rows(0)("CAI").ToString())

                    mskVtoCAI.Text = Format(rstCAI.Rows(0)("VtoCAI"), "dd/MM/yyy")
                    If Not IsDate(Trim(mskVtoCAI.Text)) Then

                        MsgBox("El Vto del CAI no es una fecha válida. NO puede cargar un Comprobante con estas características. No se puede continuar.", vbInformation)
                        rstPercep = Nothing
                        rstIngreso = Nothing
                        RstAux = Nothing
                        RstOC = Nothing
                        RstPS = Nothing
                        Exit Sub
                    End If
                Else

                    txtCAI.Text = ""
                    mskVtoCAI.Text = ""
                    rstPercep = Nothing
                    rstIngreso = Nothing
                    RstAux = Nothing
                    RstOC = Nothing
                    RstPS = Nothing

                End If
            End If
        End If

        If controldebcred.ObtenerNumeracionActualizada(PrefijoAFacturar, oTipoComp, oTNroComprobante) <> 1 Then
            MsgBox("Error al obtener Numeracion actualizada")
            Exit Sub
        End If


        If chkPorCuentaTercero.Checked = False Then
            oPorCuentaDeTercero = 0
        Else
            oPorCuentaDeTercero = 1
        End If
        salida = controldebcred.ValidarNroFactura(Val(mskNroProveedor.Text), Val(mskNroComprobante.Text), codigoSeleccionado, cboTipo.SelectedIndex)
        Select Case salida
            Case -1
                MsgBox("Error al obtener datos de facturas para el proveedor ingresado. Contáctese con el depto. de sistemas.", vbCritical)
                rstPercep = Nothing
                rstIngreso = Nothing
                RstAux = Nothing
                Exit Sub
            Case 0 'todo bien la factuna no esta cargada
            Case 1
                MsgBox("El nro. de factura que cargo ya está cargado en sistema, verifique que el mismo sea correcto.", vbInformation)
                rstPercep = Nothing
                rstIngreso = Nothing
                RstAux = Nothing

                Exit Sub
        End Select

        salida = controldebcred.NuevoInterno(Val(mskNroProveedor.Text), codigoSeleccionado, cboTipo.SelectedIndex + 1, oNroComprobante, (CDate(mskFecha.Text)), Now, (CDate(mskFecha.Text)), 9, stringSQL(txtObservaciones.Text), FormatoSQL(txtIva.Text), FormatoSQL(txtImpProd.Text), FormatoSQL("0"), FormatoSQL("0"), FormatoSQL("0"), FormatoSQL(txtIE.Text), FormatoSQL(txtTotal.Text), Trim(txtCAI.Text), "", Tipo_Moneda, rstPercep, rstIngreso, RstOC, RstPS, 0, Trim(cae), "CREDITODEBITOINT", oPorCuentaDeTercero)
        If salida = -1 Then
            MsgBox("Se Produjo un Error al Crear un Nuevo Comprobante. Contáctese con el Depto. de  Sistemas.", vbCritical)
            rstPercep = Nothing
            rstIngreso = Nothing
            RstAux = Nothing
            RstOC = Nothing
            RstPS = Nothing
        ElseIf salida = -2 Then
            MsgBox("No se puede guardar el Comprobante. Se debe hacer un reseed al campo NroInterno de la tabla ComprobantesProveedores de la base de datos. Contáctese con el Depto. de Sistemas.", vbExclamation)
        Else



            respuesta = controldebcred.AcumularComprobanteNuevo(salida)
            If respuesta = -1 Then
                MsgBox("Se Produjo un Error al marcar como 'I' un Nuevo Comprobante. Contáctese con el Depto. de  Sistemas.", vbCritical)
                rstPercep = Nothing
                rstIngreso = Nothing
                RstAux = Nothing
                RstOC = Nothing
                RstPS = Nothing
                Exit Sub
            End If
            mskNroComprobante.Text = oNroComprobante
            MsgBox("Se grabo correctamente el comprobante; su nrointerno es: " & salida, vbInformation)
            HabilitarControles("LIMPIAR")
            RstAux = Nothing
        End If
    End Sub
    Public Function FormatoSQL(input As String) As String
        Return "'" & input.Replace("'", "''") & "'" '
    End Function
    Public Function stringSQL(Palabra As String) As String
        stringSQL = Replace(Trim(Palabra), "'", "´")
    End Function
    Private Sub txtIE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIE.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtTotal.Text = txtIE.Text
            txtTotal.Enabled = False

            ' Evitar que se ingrese el Enter en txtIE
            e.Handled = True
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim filePath As String = "F:\V_CTACTE\" & "ImpresiondeFacturas.exe"
        Dim respuesta As Double
        respuesta = Shell(filePath, vbNormalFocus)
    End Sub

End Class