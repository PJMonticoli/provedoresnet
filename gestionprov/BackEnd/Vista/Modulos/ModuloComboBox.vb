Imports System.Globalization
Imports Controles
Imports Modelos

Module ModuloComboBox
    Dim controlProveedor As New ControlerProveedor
    Dim controlInforme As New ControlerInforme
    Dim controlExportacion As New ControlerOpExportacion
#Region "Combo box FrmPrincipal"
    Public Sub ControlarAfip(ByRef tabla As DataTable, ByRef usuario As ModeloUsuario, ByRef usarAfip As Boolean)

        Try
            controlProveedor.ControlarUsuarioAfip(tabla, usuario.CodUser)
            If tabla.Rows.Count > 0 Then
                If Convert.ToInt32(tabla.Rows(0).Item(0)) > 0 Then
                    usarAfip = True
                Else
                    usarAfip = False
                End If
            End If
        Catch ex As Exception
            usarAfip = True
        End Try
    End Sub
    Public Sub CargarCboDescripcion(ByRef cboDescripcion As ComboBox, ByRef cboTipo As ComboBox)
        Dim rec As DataTable
        Dim i As Long

        i = controlProveedor.BuscarDescripcionComprobantesTodos(rec)


        If i = 0 Then
            MsgBox("No se poseen datos de Descripciones.", MsgBoxStyle.Information)
            Exit Sub
        ElseIf i = -1 Then
            MsgBox("Error al obtener datos de Descripciones.", MsgBoxStyle.Critical)
            Exit Sub
        Else
            cboDescripcion.DataSource = rec
            cboDescripcion.ValueMember = "codigo"
            cboDescripcion.DisplayMember = "Descripcion"
        End If

        If cboDescripcion.Items.Count > 0 Then
            cboDescripcion.SelectedValue = 23
        End If

        i = controlProveedor.BuscarTipos(rec)
        If i = 0 Then
            MsgBox("No se poseen datos de Tipos de Comprobantes.", vbInformation)
            Exit Sub
        ElseIf i = -1 Then
            MsgBox("Error al obtener datos de Tipos de Comprobantes.", vbCritical)
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

    Public Sub CargarCboProvincia(ByRef cboProvincia As ComboBox)
        Dim rec As DataTable
        Dim i As Long
        i = -9
        i = controlProveedor.BuscarProvincias(rec)


        If i = 0 Then
            MsgBox("No se poseen datos de provincias.", vbInformation)
            Exit Sub
        ElseIf i = -1 Then
            MsgBox("Error al obtener datos de provincias.", vbCritical)
            Exit Sub
        Else

            cboProvincia.DataSource = rec
            cboProvincia.ValueMember = "codprovincia"
            cboProvincia.DisplayMember = "descprovincia"

            If cboProvincia.Items.Count > 0 Then
                cboProvincia.SelectedValue = 0
            End If
        End If
        If cboProvincia.Items.Count > 0 Then
            cboProvincia.SelectedValue = 0
        End If

    End Sub

    Public Sub CargarCboCondiciones(ByRef cboCondPago As ComboBox)
        Dim rec As DataTable
        Dim i As Long

        i = controlProveedor.BuscarCondicionesPagoComprobantes(rec)
        If i = 0 Then
            MsgBox("No se poseen datos de Condiciones de Pago de Comprobantes.", vbInformation)
            Exit Sub
        ElseIf i = -1 Then
            MsgBox("Error al obtener datos de Condiciones de Pago de Comprobantes.", vbCritical)
            Exit Sub
        Else

            cboCondPago.DataSource = rec
            cboCondPago.ValueMember = "codigo"
            cboCondPago.DisplayMember = "Descripcion"
        End If
        If cboCondPago.Items.Count > 0 Then
            cboCondPago.SelectedIndex = 0
        End If

    End Sub
#End Region
#Region "FrmAltaCAI"
    Public Sub CargarCboDescCAI(ByRef cboDescripcion As ComboBox, ByRef cboTipo As ComboBox)
        Dim rec As DataTable
        Dim i As Long

        i = controlProveedor.BuscarDescripcionComprobantesTodos(rec)


        If i = 0 Then
            MsgBox("No se poseen datos de Descripciones.", MsgBoxStyle.Information)
            Exit Sub
        ElseIf i = -1 Then
            MsgBox("Error al obtener datos de Descripciones.", MsgBoxStyle.Critical)
            Exit Sub
        Else
            cboDescripcion.DataSource = rec
            cboDescripcion.ValueMember = "codigo"
            cboDescripcion.DisplayMember = "Descripcion"
        End If

        If cboDescripcion.Items.Count > 0 Then
            cboDescripcion.SelectedValue = 1
        End If

        i = controlProveedor.BuscarTipos(rec)
        If i = 0 Then
            MsgBox("No se poseen datos de Tipos de Comprobantes.", vbInformation)
            Exit Sub
        ElseIf i = -1 Then
            MsgBox("Error al obtener datos de Tipos de Comprobantes.", vbCritical)
            Exit Sub
        Else
            cboTipo.DataSource = rec
            cboTipo.ValueMember = "codigo"
            cboTipo.DisplayMember = "descripcion"
        End If
        If cboTipo.Items.Count > 0 Then
            cboTipo.SelectedValue = 1
        End If
    End Sub

#End Region
#Region "FrmCierre"
    Public Sub cargarCombo(ByRef cboMes As ComboBox, ByRef cboAnio As ComboBox)
        Dim i As Integer
        Dim AuxFecha As Integer
        AuxFecha = CInt(Format(Now, "MM"))
        Dim mesActual As Integer = Date.Now.Month

        Dim cultureAR As New CultureInfo("es-AR")
        Dim dtfi As DateTimeFormatInfo = cultureAR.DateTimeFormat

        ' Llenar los ComboBox con los nombres de los 12 meses
        For i = 1 To 12
            cboMes.Items.Add(dtfi.GetMonthName(i))
        Next i

        ' Seleccionar el índice correspondiente al mes actual
        cboMes.SelectedIndex = mesActual - 1

        AuxFecha = CInt(Format(Now, "yyyy"))

        cboAnio.Items.Clear()
        For i = 2004 To Year(Now)
            cboAnio.Items.Add(i)
            cboAnio.Items(cboAnio.Items.Count - 1) = i
        Next i
        cboAnio.SelectedIndex = cboAnio.Items.Count - 1

    End Sub
#End Region
#Region "FrmFiltroInforme"
    Public Sub cargarComboInforme(ByRef cboMes As ComboBox, ByRef cboMesC As ComboBox, ByRef cboMesQ As ComboBox, ByRef cboAnio As ComboBox,
                           cboAnioC As ComboBox, ByRef cboAnioQ As ComboBox)
        Dim i As Integer
        Dim AuxFecha As Integer
        AuxFecha = CInt(Format(Now, "MM"))
        Dim mesActual As Integer = Date.Now.Month

        Dim cultureAR As New CultureInfo("es-AR")
        Dim dtfi As DateTimeFormatInfo = cultureAR.DateTimeFormat

        ' Llenar los ComboBox con los nombres de los 12 meses
        For i = 1 To 12
            cboMes.Items.Add(dtfi.GetMonthName(i))
            cboMesC.Items.Add(dtfi.GetMonthName(i))
            cboMesQ.Items.Add(dtfi.GetMonthName(i))
        Next i

        ' Seleccionar el índice correspondiente al mes actual
        cboMes.SelectedIndex = mesActual - 1
        cboMesC.SelectedIndex = mesActual - 1
        cboMesQ.SelectedIndex = mesActual - 1


        AuxFecha = CInt(Format(Now, "yyyy"))

        cboAnio.Items.Clear()
        For i = 2004 To Year(Now)
            cboAnio.Items.Add(i)
            cboAnio.Items(cboAnio.Items.Count - 1) = i
        Next i
        cboAnio.SelectedIndex = cboAnio.Items.Count - 1

        cboAnioC.Items.Clear()
        For i = 2004 To Year(Now)
            cboAnioC.Items.Add(i)
            cboAnioC.Items(cboAnioC.Items.Count - 1) = i
        Next i
        cboAnioC.SelectedIndex = cboAnioC.Items.Count - 1

        cboAnioQ.Items.Clear()
        For i = 2004 To Year(Now)
            cboAnioQ.Items.Add(i)
            cboAnioQ.Items(cboAnioQ.Items.Count - 1) = i
        Next i
        cboAnioQ.SelectedIndex = cboAnioQ.Items.Count - 1
    End Sub

    Public Sub cargarCboTipo(ByRef cboTipo As ComboBox)
        Try
            Dim rec As New DataTable
            Dim i As Long

            i = controlInforme.BuscarTipos(rec)
            If rec.Rows.Count = 0 Then
                MsgBox("No se poseen datos de Tipos de Comprobantes.", MsgBoxStyle.Information)
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
    Public Sub cargarCboTipoGrupo(ByRef cboTipoGrupo As ComboBox)
        Try
            Dim rec As New DataTable
            Dim i As Long

            i = controlInforme.BuscarTipoComprobante(rec)
            If i = 0 Then
                MsgBox("No se poseen datos de Descripciones.", vbInformation)
                Exit Sub
            ElseIf i = -1 Then
                MsgBox("Error al obtener datos de Descripciones.", vbCritical)
                Exit Sub
            Else
                ' Add the "TODOS" item
                cboTipoGrupo.Items.Add("TODOS")
                cboTipoGrupo.SelectedIndex = 0

                For Each row As DataRow In rec.Rows
                    ' Add other items
                    cboTipoGrupo.Items.Add(row("Descripcion").ToString().Replace("'", "´"))
                    cboTipoGrupo.SelectedIndex = cboTipoGrupo.Items.Count - 1
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
#Region "FrmOperacionExportacion"
    Public Sub cargarComboTipoCompEXP(ByRef cboTipoExp)
        Dim dt As New DataTable
        controlExportacion.BuscarTipoCompEXP(dt)

        If dt.Rows.Count > 0 Then
            cboTipoExp.DataSource = dt
            cboTipoExp.ValueMember = "Codtipocompexp"
            cboTipoExp.DisplayMember = "Desctipocompexp"
        End If
        cboTipoExp.SelectedValue = 5
    End Sub

    Public Sub cargarComboMonedas(ByRef cboMoneda As ComboBox)
        Dim tabla As New DataTable
        controlExportacion.BuscarMonedas(tabla)

        If tabla.Rows.Count > 0 Then
            cboMoneda.Items.Clear()
            cboMoneda.DataSource = tabla
            cboMoneda.ValueMember = "codMoneda"
            cboMoneda.DisplayMember = "descmoneda"

            If cboMoneda.Items.Count > 0 Then
                cboMoneda.SelectedValue = 2
            End If
        End If
    End Sub
#End Region
End Module
