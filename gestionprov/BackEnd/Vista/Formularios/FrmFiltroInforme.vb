Imports Controles
Imports GrapeCity.ActiveReports.ReportsCore.Tools
Imports GrapeCity.Viewer.Common.Model
Imports Guna.UI2.WinForms
Imports Modelos
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography

Public Class FrmFiltroInforme
    Dim controlInforme As New ControlerInforme
    Dim rptImpresoInforme As New FrmInformeVisualizador
    Dim rec As DataTable
    Dim salida As Long
    Dim i As Long
    Dim CadenaFecha As String
    Dim Rst As DataTable

    Private Sub rbtImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        '**********************************************
        'INFORMES DIARIOS
        '**********************************************
        rec = New DataTable()

        If chkInsumos.Checked = True Then
            salida = controlInforme.ObtenerInsumosdelDia(rec, dtpFecha.Value.ToShortDateString)

            If salida = -1 Then
                MsgBox("Error al obtener datos de insumos del día.", MsgBoxStyle.Critical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de insumos del día.", MsgBoxStyle.Information)
                Exit Sub
            Else
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                'llama a RptImpresoInsumos
                rptImpresoInforme.lblFecha = Format(dtpFecha.Value, "dd/MM/yyyy")
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 1
                rptImpresoInforme.Show()
            End If
        End If

        If chkComprobantes.Checked = True Then

            salida = controlInforme.ObtenerComprobantesdelDia(rec, dtpFecha.Value.ToShortDateString)

            If salida = -1 Then
                MessageBox.Show("Error al obtener datos de comprobantes del día.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf salida = 0 Then
                MessageBox.Show("No existen datos de comprobantes del día.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                Dim tituloComprobanteDia As String
                tituloComprobanteDia = "Listado de Comprobantes del Día"
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                'llama a RptImpresoComprobanteDia
                rptImpresoInforme.lblFecha = Format(dtpFecha.Value, "dd/MM/yyyy")
                rptImpresoInforme.lblTitulo = tituloComprobanteDia
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 2
                rptImpresoInforme.Show()
            End If
        End If

        '**********************************************
        'INFORMES QUINCENALES
        '**********************************************


        If chkControlDiario.Checked = True Then
            salida = controlInforme.ObtenerControlDiario(dtpFecha.Value.ToShortDateString, rec)
            If salida = -1 Then
                MsgBox("Error al obtener datos del control diario.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos para el informe control diario.", vbInformation)
                Exit Sub
            Else
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                'llama a RptImpresoControlDiario
                rptImpresoInforme.lblFecha = Format(dtpFecha.Value, "dd/MM/yyyy")
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 3
                rptImpresoInforme.Show()
            End If
        End If

        If cboMesQ.SelectedIndex = -1 Then
            MsgBox("Mes seleccionado no válido.", vbInformation)
            Exit Sub
        End If
        If cboMesQ.SelectedIndex = -1 Then
            MsgBox("Año seleccionado no válido.", vbInformation)
            Exit Sub
        End If


        If chkPercpGanancias.Checked = True Then
            salida = controlInforme.ObtenerPercepcionGanancias(CboMes.SelectedIndex + 1, Val(cboAnio.Text), rec)
            If salida = -1 Then
                MsgBox("Error al obtener datos de Retenciones de Ganancias.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de Retenciones de Ganancias para los parámetros seleccionados.", vbInformation)
                Exit Sub
            Else
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                Dim fechaMensaje As String = "Correspondiente al mes " & CboMes.Text & " de " & cboAnio.Text
                ' Configurar el formulario del informe
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 4
                rptImpresoInforme.Show()
            End If
        End If



        If chkPercepcionGanDesdeHasta.Checked Then
            If lstFechas.Items.Count = 0 Then
                MsgBox("No existe ninguna fecha seleccionada.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If ValidarFecha() = False Then
                ' El método ValidarFecha debe estar definido en tu código
                Me.Cursor = Cursors.Default
                GPanel7.Enabled = True
                Exit Sub
            End If


            CadenaFecha = ""


            If rbtSeleccionarFechas.Checked Then
                For i As Integer = 0 To lstFechas.Items.Count - 1
                    If lstFechas.GetItemChecked(i) Then
                        If String.IsNullOrEmpty(CadenaFecha) Then
                            CadenaFecha &= $" '{lstFechas.Items(i).ToString()}'"
                        Else
                            CadenaFecha &= $", '{lstFechas.Items(i).ToString()}'"
                        End If
                    End If
                Next i
            Else
                For i = 0 To lstFechas.Items.Count - 1
                    If CadenaFecha.Length = 0 Then
                        CadenaFecha &= " '" & lstFechas.Items(i).ToString() & "'"
                    Else
                        CadenaFecha &= ", '" & lstFechas.Items(i).ToString() & "'"
                    End If
                Next i
            End If

            salida = controlInforme.ObtenerPercepcionGananciasDesdeHasta(CadenaFecha, rbtSeleccionarFechas.Checked, rec)
            If salida = -1 Then
                MsgBox("Error al obtener datos de Retenciones de Ganancias.", MsgBoxStyle.Critical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de Retenciones de Ganancias para los parámetros seleccionados.", MsgBoxStyle.Information)
                Exit Sub
            Else
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                Dim fechaMensaje As String = "Correspondiente al mes " & CadenaFecha
                'Informe ImpresoPercepcionesGan
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 5
                rptImpresoInforme.Show()
            End If
        End If


        If chkRetencionGanancias.Checked = True Then
            salida = controlInforme.ObtenerRetencionGanancias(rbtSeleccionFechaIB.Checked, rbt1ra.Checked, rbt2da.Checked,
                     cboMesQ.SelectedIndex + 1, Val(cboAnioQ.Text), rec, dtpFechaDesdeIB.Value, dtpFechaHastaIB.Value)

            Me.Cursor = Cursors.Default

            If salida = -1 Then
                MsgBox("Error al obtener datos de Retenciones de Ganancias.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de Retenciones de Ganancias para los parámetros seleccionados.", vbInformation)
                Exit Sub
            Else
                Dim fechaMensaje As String
                If rbtSeleccionFechaIB.Checked Then
                    fechaMensaje = "Correspondiente a la selección de fecha desde: " & dtpFechaDesdeIB.Value.ToString("dd/MM/yyyy") & " hasta " & dtpFechaHastaIB.Value.ToString("dd/MM/yyyy")
                Else
                    If rbt1ra.Checked Then
                        fechaMensaje = "Correspondiente a la 1ra. Quincena de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    ElseIf rbt2da.Checked Then
                        fechaMensaje = "Correspondiente a la 2da. Quincena de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    End If
                End If
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                'llama a RptRetencionesGan
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 6
                rptImpresoInforme.Show()
            End If
        End If




        If chkRetIBCba.Checked = True Then
            salida = controlInforme.ObtenerRetencionIBCordoba(rbtSeleccionFechaIB.Checked, rbt1ra.Checked, rbt2da.Checked, cboMesQ.SelectedIndex + 1, Val(cboAnioQ.Text), rec, dtpFechaDesdeIB.Value, dtpFechaHastaIB.Value)
            Me.Cursor = Cursors.Default

            If salida = -1 Then
                MsgBox("Error al obtener datos de Retenciones de IIBB Córdoba.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de Retenciones de IIBB Córdoba para los parámetros seleccionados.", vbInformation)
                Exit Sub
            Else
                Dim fechaMensaje As String
                Dim tituloCba As String
                tituloCba = "Listado de Retenciones Ing. Brutos Cba."
                If rbtSeleccionFechaIB.Checked Then
                    fechaMensaje = "Correspondiente a la selección de fecha desde: " & dtpFechaDesdeIB.Value.ToString("dd/MM/yyyy") & " hasta " & dtpFechaHastaIB.Value.ToString("dd/MM/yyyy")
                Else
                    If rbt1ra.Checked Then
                        fechaMensaje = "Correspondiente a la 1ra. Quincena de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    ElseIf rbt2da.Checked Then
                        fechaMensaje = "Correspondiente a la 2da. Quincena de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    ElseIf rbtMes.Checked Then
                        fechaMensaje = "Correspondiente al mes de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    End If
                End If
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                'llama a RptImpresoRetencionesIBCba
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = tituloCba
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 7
                rptImpresoInforme.Show()
            End If
        End If


        If chkRetIBBsAs.Checked = True Then
            salida = controlInforme.ObtenerRetencionIBBsAs(rbtSeleccionFechaIB.Checked, rbt1ra.Checked, rbt2da.Checked, cboMesQ.SelectedIndex + 1, Val(cboAnioQ.Text), rec, dtpFechaDesdeIB.Value, dtpFechaHastaIB.Value)
            Me.Cursor = Cursors.Default

            If salida = -1 Then
                MsgBox("Error al obtener datos de Retenciones IB Bs.As.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de Retenciones de IB Bs.As. para los parámetros seleccionados.", vbInformation)
                Exit Sub
            Else
                Dim fechaMensaje As String
                Dim tituloBsAs As String
                tituloBsAs = "Listado de Retenciones Ing. Brutos Bs.As."
                If rbtSeleccionFechaIB.Checked Then
                    fechaMensaje = "Correspondiente a la selección de fecha desde: " & dtpFechaDesdeIB.Value.ToString("dd/MM/yyyy") & " hasta " & dtpFechaHastaIB.Value.ToString("dd/MM/yyyy")
                Else
                    If rbt1ra.Checked Then
                        fechaMensaje = "Correspondiente a la 1ra. Quincena de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    ElseIf rbt2da.Checked Then
                        fechaMensaje = "Correspondiente a la 2da. Quincena de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    ElseIf rbtMes.Checked Then
                        fechaMensaje = "Correspondiente al mes de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    End If
                End If
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                'llama a RptImpresoRetencionesIBCba
                rptImpresoInforme.lblTitulo = tituloBsAs
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 8
                rptImpresoInforme.Show()
            End If
        End If


        If chkRetIBSanLuis.Checked = True Then
            Me.Cursor = Cursors.Default
            salida = controlInforme.ObtenerRetencionIBSanLuis(rbtSeleccionFechaIB.Checked, rbt1ra.Checked, rbt2da.Checked, cboMesQ.SelectedIndex + 1, Val(cboAnioQ.Text), rec, dtpFechaDesdeIB.Value, dtpFechaHastaIB.Value)
            If salida = -1 Then
                MsgBox("Error al obtener datos de Retenciones IIBB de San Luis.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de Retenciones de IIBB de San Luis para los parámetros seleccionados.", vbInformation)
                Exit Sub
            Else
                Dim fechaMensaje As String
                Dim tituloSanLuis As String
                tituloSanLuis = "Listado de Retenciones Ing. Brutos San Luis."
                'cargo reporte Ret. i.b. cba del mes
                If rbtSeleccionFechaIB.Checked Then
                    fechaMensaje = "Correspondiente a la selección de fecha desde: " & dtpFechaDesdeIB.Value.ToString("dd/MM/yyyy") & " hasta " & dtpFechaHastaIB.Value.ToString("dd/MM/yyyy")
                Else
                    If rbt1ra.Checked Then
                        fechaMensaje = "Correspondiente a la 1ra. Quincena de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    ElseIf rbt2da.Checked Then
                        fechaMensaje = "Correspondiente a la 2da. Quincena de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    ElseIf rbtMes.Checked Then
                        fechaMensaje = "Correspondiente al mes de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    End If
                End If
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                'llama a RptImpresoRetencionesIBCba
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = tituloSanLuis
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 9
                rptImpresoInforme.Show()
            End If
        End If


        If chkRetIBSantaFe.Checked = True Then
            Me.Cursor = Cursors.Default
            salida = controlInforme.ObtenerRetencionIBSantaFe(rbtSeleccionFechaIB.Checked, rbt1ra.Checked, rbt2da.Checked, cboMesQ.SelectedIndex + 1, Val(cboAnioQ.Text), rec, dtpFechaDesdeIB.Value, dtpFechaHastaIB.Value)
            If salida = -1 Then
                MsgBox("Error al obtener datos de Retenciones IIBB de Santa Fe.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de Retenciones de IIBB de Santa Fe para los parámetros seleccionados.", vbInformation)
                Exit Sub
            Else
                Dim fechaMensaje As String
                Dim tituloSantaFe As String
                tituloSantaFe = "Listado de Retenciones Ing. Brutos Santa Fe."
                'cargo reporte Ret. i.b. cba del mes
                If rbtSeleccionFechaIB.Checked Then
                    fechaMensaje = "Correspondiente a la selección de fecha desde: " & dtpFechaDesdeIB.Value.ToString("dd/MM/yyyy") & " hasta " & dtpFechaHastaIB.Value.ToString("dd/MM/yyyy")
                Else
                    If rbt1ra.Checked Then
                        fechaMensaje = "Correspondiente a la 1ra. Quincena de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    ElseIf rbt2da.Checked Then
                        fechaMensaje = "Correspondiente a la 2da. Quincena de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    ElseIf rbtMes.Checked Then
                        fechaMensaje = "Correspondiente al mes de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    End If
                End If
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                'llama a RptImpresoRetencionesIBCba
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = tituloSantaFe
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 10
                rptImpresoInforme.Show()
            End If
        End If

        If chkRetIBMisiones.Checked = True Then
            Me.Cursor = Cursors.Default
            salida = controlInforme.ObtenerRetencionIBMisiones(rbtSeleccionFechaIB.Checked, rbt1ra.Checked, rbt2da.Checked, cboMesQ.SelectedIndex + 1, Val(cboAnioQ.Text), rec, dtpFechaDesdeIB.Value, dtpFechaHastaIB.Value)
            If salida = -1 Then
                MsgBox("Error al obtener datos de Retenciones IIBB de Misiones.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de Retenciones de IIBB de Misiones para los parámetros seleccionados.", vbInformation)
                Exit Sub
            Else
                Dim fechaMensaje As String
                Dim tituloMisiones As String
                tituloMisiones = "Listado de Retenciones Ing. Brutos Misiones."
                'cargo reporte Ret. i.b. cba del mes
                If rbtSeleccionFechaIB.Checked Then
                    fechaMensaje = "Correspondiente a la selección de fecha desde: " & dtpFechaDesdeIB.Value.ToString("dd/MM/yyyy") & " hasta " & dtpFechaHastaIB.Value.ToString("dd/MM/yyyy")
                Else
                    If rbt1ra.Checked Then
                        fechaMensaje = "Correspondiente a la 1ra. Quincena de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    ElseIf rbt2da.Checked Then
                        fechaMensaje = "Correspondiente a la 2da. Quincena de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    ElseIf rbtMes.Checked Then
                        fechaMensaje = "Correspondiente al mes de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    End If
                End If
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                'llama a RptImpresoRetencionesIBCba
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = tituloMisiones
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 11
                rptImpresoInforme.Show()
            End If
        End If

        If chkRetIBLaPampa.Checked = True Then
            Me.Cursor = Cursors.Default
            salida = controlInforme.ObtenerRetencionIBLaPampa(rbtSeleccionFechaIB.Checked, rbt1ra.Checked, rbt2da.Checked, cboMesQ.SelectedIndex + 1, Val(cboAnioQ.Text), rec, dtpFechaDesdeIB.Value, dtpFechaHastaIB.Value)
            If salida = -1 Then
                MsgBox("Error al obtener datos de Retenciones IIBB de La Pampa.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de Retenciones de IIBB de La Pampa para los parámetros seleccionados.", vbInformation)
                Exit Sub
            Else
                Dim fechaMensaje As String
                Dim tituloLaPampa As String
                tituloLaPampa = "Listado de Retenciones Ing. Brutos La Pampa."
                'cargo reporte Ret. i.b. cba del mes
                If rbtSeleccionFechaIB.Checked Then
                    fechaMensaje = "Correspondiente a la selección de fecha desde: " & dtpFechaDesdeIB.Value.ToString("dd/MM/yyyy") & " hasta " & dtpFechaHastaIB.Value.ToString("dd/MM/yyyy")
                Else
                    If rbt1ra.Checked Then
                        fechaMensaje = "Correspondiente a la 1ra. Quincena de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    ElseIf rbt2da.Checked Then
                        fechaMensaje = "Correspondiente a la 2da. Quincena de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    ElseIf rbtMes.Checked Then
                        fechaMensaje = "Correspondiente al mes de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    End If
                End If
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                'llama a RptImpresoRetencionesIBCba
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = tituloLaPampa
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 12
                rptImpresoInforme.Show()
            End If
        End If

        If chkRetIBJujuy.Checked = True Then
            Me.Cursor = Cursors.Default
            salida = controlInforme.ObtenerRetencionIBJujuy(rbtSeleccionFechaIB.Checked, rbt1ra.Checked, rbt2da.Checked, cboMesQ.SelectedIndex + 1, Val(cboAnioQ.Text), rec, dtpFechaDesdeIB.Value, dtpFechaHastaIB.Value)
            If salida = -1 Then
                MsgBox("Error al obtener datos de Retenciones IIBB de Jujuy.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de Retenciones de IIBB de Jujuy para los parámetros seleccionados.", vbInformation)
                Exit Sub
            Else
                Dim fechaMensaje As String
                Dim tituloJujuy As String
                tituloJujuy = "Listado de Retenciones Ing. Brutos Jujuy."
                'cargo reporte Ret. i.b. cba del mes
                If rbtSeleccionFechaIB.Checked Then
                    fechaMensaje = "Correspondiente a la selección de fecha desde: " & dtpFechaDesdeIB.Value.ToString("dd/MM/yyyy") & " hasta " & dtpFechaHastaIB.Value.ToString("dd/MM/yyyy")
                Else
                    If rbt1ra.Checked Then
                        fechaMensaje = "Correspondiente a la 1ra. Quincena de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    ElseIf rbt2da.Checked Then
                        fechaMensaje = "Correspondiente a la 2da. Quincena de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    ElseIf rbtMes.Checked Then
                        fechaMensaje = "Correspondiente al mes de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    End If
                End If
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                'llama a RptImpresoRetencionesIBCba
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = tituloJujuy
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 13
                rptImpresoInforme.Show()
            End If
        End If

        If chkRetIBMendoza.Checked = True Then
            Me.Cursor = Cursors.Default
            salida = controlInforme.ObtenerRetencionIBMendoza(rbtSeleccionFechaIB.Checked, rbt1ra.Checked, rbt2da.Checked, cboMesQ.SelectedIndex + 1, Val(cboAnioQ.Text), rec, dtpFechaDesdeIB.Value, dtpFechaHastaIB.Value)
            If salida = -1 Then
                MsgBox("Error al obtener datos de Retenciones IIBB de Mendoza.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de Retenciones de IIBB de Mendoza para los parámetros seleccionados.", vbInformation)
                Exit Sub
            Else
                Dim fechaMensaje As String
                Dim tituloMendoza As String
                tituloMendoza = "Listado de Retenciones Ing. Brutos Mendoza."
                'cargo reporte Ret. i.b. cba del mes
                If rbtSeleccionFechaIB.Checked Then
                    fechaMensaje = "Correspondiente a la selección de fecha desde: " & dtpFechaDesdeIB.Value.ToString("dd/MM/yyyy") & " hasta " & dtpFechaHastaIB.Value.ToString("dd/MM/yyyy")
                Else
                    If rbt1ra.Checked Then
                        fechaMensaje = "Correspondiente a la 1ra. Quincena de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    ElseIf rbt2da.Checked Then
                        fechaMensaje = "Correspondiente a la 2da. Quincena de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    ElseIf rbtMes.Checked Then
                        fechaMensaje = "Correspondiente al mes de " & cboMesQ.Text & " de " & cboAnioQ.Text
                    End If
                End If
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                'llama a RptImpresoRetencionesIBCba
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = tituloMendoza
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 14
                rptImpresoInforme.Show()
            End If
        End If

        If chkListadosInsIndusConsuman.Checked = True Then
            Me.Cursor = Cursors.Default
            salida = controlInforme.ObtenerInsumosIndustrialesConsuman(dtpFechaDesdeIB.Value, dtpFechaHastaIB.Value, rec)
            If salida = -1 Then
                MsgBox("Error al obtener datos.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos para los parámetros seleccionados.", vbInformation)
                Exit Sub
            Else
                Dim fechaMensaje As String
                fechaMensaje = "Desde el " & dtpFechaDesdeIB.Value & " hasta " & dtpFechaHastaIB.Value & "."
                'cargo reporte percep. iva del mes
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                'llama a RptComprobantesIndustrialConsuman
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 15
                rptImpresoInforme.Show()
            End If
        End If


        '**********************************************
        'INFORMES MENSUALES
        '**********************************************
        If chkPercepIVA.Checked = True Then
            salida = controlInforme.ObtenerPercepcionesIVAMes(CboMes.SelectedIndex + 1, Val(cboAnio.Text), rec)
            If salida = -1 Then
                MsgBox("Error al obtener datos de Percepciones de I.V.A.", vbCritical)
            ElseIf salida = 0 Then
                MsgBox("No existen datos de Percepciones de I.V.A para el mes seleccionado.", vbInformation)
            Else
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                Dim fechaMensaje As String
                fechaMensaje = "Correspondiente al mes " & CboMes.Text & " de " & cboAnio.Text & "."
                'cargo reporte percep. iva del mes
                'llama a RptComprobantesIndustrialConsuman
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 16
                rptImpresoInforme.Show()
            End If
        End If

        If chkPercepIBporProv.Checked = True Then
            'REPORTE DE PERCEPCIONES DE IB AGRUPADOS
            'POR PROVINCIA DETALLADO NO ADUANA
            salida = controlInforme.ObtenerPercepcionesIBMes(CboMes.SelectedIndex + 1, Val(cboAnio.Text), rec, False)
            If salida = -1 Then
                MsgBox("Error al obtener datos de Percepciones de Ingresos Brutos. No se puede continuar. Contáctese con el depto. de Sistemas.")
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No se encontraron datos de Percepciones de Ingresos Brutos.", vbInformation)

            Else
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                Dim fechaMensaje As String
                fechaMensaje = "Correspondiente al mes " & CboMes.Text & " de " & cboAnio.Text & "."
                'cargo reporte percep. iva del mes
                'llama a RptImpresoPercepcionesIBPorProv
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 17
                rptImpresoInforme.Show()
            End If
        End If


        If chkCredMes.Checked = True Then
            salida = controlInforme.ObtenerCreditosMes(CboMes.SelectedIndex + 1, Val(cboAnio.Text), rec)
            If salida = -1 Then
                MsgBox("Error al obtener datos de comprobantes de crédito del mes. No se puede continuar. Contáctese con el depto. de Sistemas.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No se encontraron datos de comprobantes de créditos del mes.", vbInformation)
            Else
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                Dim fechaMensaje As String
                Dim tituloCreditosMes As String
                tituloCreditosMes = "Listado de Comprobantes del Mes - Créditos"
                fechaMensaje = "Correspondiente al mes " & CboMes.Text & " de " & cboAnio.Text & "."
                'llama a RptImpresoComprobanteDia
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = tituloCreditosMes
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 18
                rptImpresoInforme.Show()
            End If
        End If


        If chkRemitosMes.Checked = True Then
            'INFORME REMITOS DEL MES EN CURSO
            salida = controlInforme.ObtenerRemitosMesCurso(CboMes.SelectedIndex + 1, Val(cboAnio.Text), rec)
            If salida = -1 Then
                MsgBox("Error al obtener datos de comprobantes de remitos del mes. No se puede continuar. Contáctese con el depto. de Sistemas.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No se encontraron datos de comprobantes de remitos del mes.", vbInformation)
            Else
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                Dim fechaMensaje As String
                Dim tituloRemitosMes As String
                tituloRemitosMes = "Listado de Remitos del Mes en Curso"
                fechaMensaje = "Correspondiente al mes " & CboMes.Text & " de " & cboAnio.Text & "."
                'llama a RptImpresoRptImpresoComprobanteDia
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = tituloRemitosMes
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 18
                rptImpresoInforme.Show()
            End If
        End If

        If chkDetalleOP.Checked = True Then
            ' Obtener los datos de comprobantes de remitos del mes
            Dim salida As Integer
            Dim rec As DataTable = Nothing
            salida = controlInforme.ObtenerDetalleOrdenPagoMensual(CboMes.SelectedIndex + 1, Val(cboAnio.Text), rec)

            If salida = -1 Then
                MsgBox("Error al obtener datos de comprobantes de remitos del mes. No se puede continuar. Contáctese con el depto. de Sistemas.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No se encontraron datos de comprobantes de remitos del mes.", vbInformation)
            Else
                ' Mostrar el informe
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If

                Dim fechaMensaje As String = "Correspondiente al mes " & CboMes.Text & " de " & cboAnio.Text
                Dim titulo As String = "RESUMEN DE ORDENES DE PAGO"

                ' Configurar el formulario del informe
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = titulo
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 19
                rptImpresoInforme.Show()
            End If
        End If


        If chkPercpGanancias.Checked = True Then
            salida = controlInforme.ObtenerPercepcionGanancias(CboMes.SelectedIndex + 1, Val(cboAnio.Text), rec)
            If salida = -1 Then
                MsgBox("Error al obtener datos de Percepciones de Ganancias.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de Percepciones de Ganancias para los parámetros seleccionados.", vbInformation)
                Exit Sub
            Else

                ' Mostrar el informe
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If

                Dim fechaMensaje As String = "Correspondiente al mes " & CboMes.Text & " de " & cboAnio.Text
                ' Configurar el formulario del informe
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 20
                rptImpresoInforme.Show()
            End If
        End If


        If chkPercepIBAduana.Checked = True Then
            'REPORTE DE PERCEPCIONES DE IB AGRUPADOS
            'POR PROVINCIA DETALLADO ADUANA

            salida = controlInforme.ObtenerPercepcionesIBMes(CboMes.SelectedIndex + 1, Val(cboAnio.Text), rec, True)
            If salida = -1 Then
                MsgBox("Error al obtener datos de Percepciones de Ingresos Brutos. No se puede continuar. Contáctese con el depto. de Sistemas.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No se encontraron datos de Percepciones de Ingresos Brutos.", vbInformation)

            Else                ' Mostrar el informe
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If

                Dim fechaMensaje As String = "Correspondiente al mes " & CboMes.Text & " de " & cboAnio.Text

                ' Configurar el formulario del informe
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 21
                rptImpresoInforme.Show()
            End If
        End If

        If chkResumMesInsumos.Checked = True Then
            Dim Desde As String = "01/" & Format((CboMes.SelectedIndex + 1), "00") & "/" & Val(cboAnio.Text)
            Dim Hasta As String
            'INFORME INSUMOS DEL MES
            Select Case CboMes.SelectedIndex + 1
                Case 2
                    Hasta = "29/" & Format(CboMes.SelectedIndex + 1, "00") & "/" & Val(cboAnio.Text)
                Case 4, 6, 9
                    Hasta = "30/" & Format(CboMes.SelectedIndex + 1, "00") & "/" & Val(cboAnio.Text)
                Case Else
                    Hasta = "31/" & Format(CboMes.SelectedIndex + 1, "00") & "/" & Val(cboAnio.Text)
            End Select

            salida = controlInforme.ObtenerInsumosdelMes(CStr(Desde), CStr(Hasta), rec)
            If salida = -1 Then
                MsgBox("Error al obtener datos de Insumos del mes. No se puede continuar. Contáctese con el depto. de Sistemas.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No se encontraron datos de Insumos del mes.", vbInformation)
            Else
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If

                Dim fechaMensaje As String = "Correspondiente al mes " & CboMes.Text & " de " & cboAnio.Text
                ' Configurar el formulario del informe
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 22
                rptImpresoInforme.Show()
            End If
        End If

        'Resumen de COmprobantes
        If chkResumenComprobantes.Checked = True Then
            'INFORME COMPROBANTES DEL MES


            Dim Desde As String = "01/" & Format((CboMes.SelectedIndex + 1), "00") & "/" & Val(cboAnio.Text)
            Dim Hasta As String

            Select Case CboMes.SelectedIndex + 1
                Case 2
                    Hasta = "28/" & Format(CboMes.SelectedIndex + 1, "00") & "/" & Val(cboAnio.Text)
                Case 4, 6, 9, 11
                    Hasta = "30/" & Format(CboMes.SelectedIndex + 1, "00") & "/" & Val(cboAnio.Text)
                Case Else
                    Hasta = "31/" & Format(CboMes.SelectedIndex + 1, "00") & "/" & Val(cboAnio.Text)
            End Select

            salida = controlInforme.ObtenerComprobantesdelMes(CStr(Desde), CStr(Hasta), rec)

            '---------------------------------------------------------------

            If salida = -1 Then
                MsgBox("Error al obtener datos de comprobantes del mes. No se puede continuar. Contáctese con el depto. de Sistemas.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No se encontraron datos de comprobantes del mes.", vbInformation)

            Else
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If

                Dim titulo As String
                titulo = "Listado de Comprobantes del Mes"
                Dim fechaMensaje As String = "Correspondiente al mes " & CboMes.Text & " de " & cboAnio.Text
                ' Configurar el formulario del informe
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = titulo
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 23
                rptImpresoInforme.Show()
            End If
        End If

        If chkResumenComprobantesSinAnt.Checked = True Then
            Dim Desde As String = "01/" & Format((CboMes.SelectedIndex + 1), "00") & "/" & Val(cboAnio.Text)
            Dim Hasta As String

            Select Case CboMes.SelectedIndex + 1
                Case 2
                    Hasta = "28/" & Format(CboMes.SelectedIndex + 1, "00") & "/" & Val(cboAnio.Text)
                Case 4, 6, 9, 11
                    Hasta = "30/" & Format(CboMes.SelectedIndex + 1, "00") & "/" & Val(cboAnio.Text)
                Case Else
                    Hasta = "31/" & Format(CboMes.SelectedIndex + 1, "00") & "/" & Val(cboAnio.Text)
            End Select

            salida = controlInforme.ObtenerComprobantesdelMesSinAnticipos(CStr(Desde), CStr(Hasta), rec)

            '---------------------------------------------------------------

            If salida = -1 Then
                MsgBox("Error al obtener datos de comprobantes del mes sin anticipos. No se puede continuar. Contáctese con el depto. de Sistemas.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No se encontraron datos de comprobantes del mes sin anticipos.", vbInformation)

            Else
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                Dim titulo As String
                titulo = "Listado de Comprobantes del Mes sin Anticipos"
                Dim fechaMensaje As String = "Correspondiente al mes " & CboMes.Text & " de " & cboAnio.Text
                ' Configurar el formulario del informe
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = titulo
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 24
                rptImpresoInforme.Show()
            End If
        End If

        If chkasientoCompra.Checked = True Then
            ' REPORTE DE ASIENTO DE COMPRAS PARA MES CERRADO
            Dim Tipocomp As String
            Dim TipoCompCaption As String

            If rbtFacturasDebitos.Checked = True Then
                Tipocomp = " and ComprobantesProveedores.TipoGrupo IN (1,5,11) "
                TipoCompCaption = "FACTURAS, DEBITOS."
            Else
                If rbtCred.Checked = True Then
                    Tipocomp = " and ComprobantesProveedores.TipoGrupo IN (3) "
                    TipoCompCaption = "CREDITOS"
                Else
                    If rbtCreInternosGuma.Checked = True Then
                        Tipocomp = " and ComprobantesProveedores.TipoGrupo IN (9,4) "
                        TipoCompCaption = "CREDITOS INTERNOS Y CREDITOS GUMA"
                    Else
                        If rbtDebInternosGuma.Checked = True Then
                            Tipocomp = " and ComprobantesProveedores.TipoGrupo IN (10,6) "
                            TipoCompCaption = "DEBITOS INTERNOS Y DEBITOS INTERNO"
                        End If
                    End If
                End If
            End If

            ' Obtener datos para el asiento de compras y agregar al DataTable (rec)
            Dim salidaAsiento As Integer = controlInforme.ObtenerAsientoComprasNuevoNuevo(CboMes.SelectedIndex + 1, Val(cboAnio.Text), rec, Tipocomp)

            Dim RstAux As DataTable = Nothing
            salida = controlInforme.SumasParaAsientoCompras(CboMes.SelectedIndex + 1, Val(cboAnio.Text), 0, RstAux)

            ' Mostrar el formulario de informe si hay datos
            If salidaAsiento = -1 Then
                MsgBox("Error al obtener datos de Asiento de compras. No se puede continuar. Contáctese con el depto. de Sistemas.", vbCritical)
                Exit Sub
            ElseIf salidaAsiento = 0 Then
                MsgBox("No se encontraron datos para el asiento de compras.", vbInformation)
            Else
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                If salida = 1 Then
                    rptImpresoInforme.tablaSecundaria = RstAux
                    rptImpresoInforme.lblTitulo = TipoCompCaption
                End If
                ' Configurar el formulario de informe
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 25
                rptImpresoInforme.Show()
            End If
        End If

        If chkCompIVA27.Checked = True Then
            salida = controlInforme.ObtenerComprobantesDelMes27(CboMes.SelectedIndex + 1, Val(cboAnio.Text), rec)
            If salida = -1 Then
                MsgBox("Error al obtener datos de comprobantes de Comprobantes del Mes I.V.A 27% . No se puede continuar. Contáctese con el depto. de Sistemas.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No se encontraron datos de Comprobantes del Mes I.V.A 27%.", vbInformation)
            Else
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                Dim fechaMensaje As String
                Dim tituloCreditosMes As String
                tituloCreditosMes = "Listado de Comprobantes del Mes I.V.A 27%"
                fechaMensaje = "Correspondiente al mes " & CboMes.Text & " de " & cboAnio.Text & "."
                'llama a RptImpresoComprobanteDia
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = tituloCreditosMes
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 26
                rptImpresoInforme.Show()
            End If
        End If

        If chkCompIVA75.Checked = True Then
            salida = controlInforme.ObtenerComprobantesDelMes75(CboMes.SelectedIndex + 1, Val(cboAnio.Text), rec)
            If salida = -1 Then
                MsgBox("Error al obtener datos de comprobantes de Comprobantes del Mes Impuesto País 7,5% . No se puede continuar. Contáctese con el depto. de Sistemas.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No se encontraron datos de Comprobantes del Mes Impuesto País 7,5%.", vbInformation)
            Else
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                Dim fechaMensaje As String
                Dim tituloCreditosMes As String
                tituloCreditosMes = "Listado de Comprobantes del Mes Impuesto País 7,5%"
                fechaMensaje = "Correspondiente al mes " & CboMes.Text & " de " & cboAnio.Text & "."
                'llama a RptImpresoComprobanteDia
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = tituloCreditosMes
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 27
                rptImpresoInforme.Show()
            End If
        End If

        If chkInsPorCuenta.Checked = True Then
            salida = controlInforme.ListadoInsumosPorCuenta(Val(txtCuenta.Text), CboMes.SelectedIndex + 1, Val(cboAnio.Text), rec)
            If salida = -1 Then
                MsgBox("Error al obtener datos de insumos de comprobantes. Contáctese con el depto. de Sistemas.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No se encontraron datos de insumos de comprobantes.", vbInformation)
            Else
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                'llama a RptImpresoComprobanteDia
                rptImpresoInforme.lblfiltro = "Mes de Imputación : " & CboMes.Text & "/" & cboAnio.Text & vbCrLf & "Cuenta :" & Val(txtCuenta.Text)
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 28
                rptImpresoInforme.Show()
            End If
        End If


        If chkCompDeudaPago.Checked = True Then
            Dim orden As String
            Dim salidaAux As Integer
            Dim RstAux As New DataTable
            RstAux.Columns.Add("NroInterno", GetType(Integer))
            orden = 0
            If chkOrdVto.Checked = True Then
                orden = 1
            End If
            If rbtTodosComp.Checked = True Then
                'listado de comprobantes `pendientes de pago facturas y remitos DOS
                If chkOrdVto.Checked = True Then
                    orden = 1
                End If

                salida = controlInforme.ObtenerComprobantesParaLiquidar(rec, "TodosCompPend", orden)
                For Each row As DataRow In rec.Rows
                    controlInforme.dtAutorizado(RstAux, Convert.ToInt32(row("NroInterno")))
                Next
                If salida = -1 Then
                    MsgBox("Error al intentar obtener facturas y remitos. Contáctese con el depto. de sistemas.", vbCritical)
                    Exit Sub
                ElseIf salida = 0 Then
                    MsgBox("No se obtuvieron datos de facturas y remitos pendientes de pago.", vbInformation)
                    Exit Sub
                Else
                    If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                        rptImpresoInforme = New FrmInformeVisualizador()
                    End If
                    If RstAux.Rows.Count > 0 Then
                        rptImpresoInforme.tablaSecundaria = RstAux
                    End If
                    'llama a RptImpresoComprobanteDia
                    rptImpresoInforme.dt = rec
                    rptImpresoInforme.informe = 29
                    rptImpresoInforme.Show()
                End If
            ElseIf rbtDiasFecFac.Checked = True Then
                'listado de comprobantes `pendientes de pago facturas y remitos DOS
                salida = controlInforme.ObtenerComprobantesParaLiquidarConXDiasFechaFact(rec, "TodosCompPend", txtFecFac.Text)
                For Each row As DataRow In rec.Rows
                    controlInforme.dtAutorizado(RstAux, Convert.ToInt32(row("NroInterno")))
                Next
                If salida = -1 Then
                    MsgBox("Error al intentar obtener facturas y remitos. Contáctese con el depto. de sistemas.", vbCritical)
                    Exit Sub
                ElseIf salida = 0 Then
                    MsgBox("No se obtuvieron datos de facturas y remitos pendientes de pago.", vbInformation)
                    Exit Sub
                Else
                    If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                        rptImpresoInforme = New FrmInformeVisualizador()
                    End If
                    If RstAux.Rows.Count > 0 Then
                        rptImpresoInforme.tablaSecundaria = RstAux
                    End If
                    'llama a RptImpresoComprobanteDia
                    rptImpresoInforme.dt = rec
                    rptImpresoInforme.informe = 30
                    rptImpresoInforme.Show()
                End If
            End If
        End If


        If chkDeudaPagoAgrupado.Checked = True Then
            Dim orden As String
            Dim salidaAux As Integer
            Dim RstAux As New DataTable
            RstAux.Columns.Add("NroInterno", GetType(Integer))
            orden = 2
            If chkOrdVto.Checked = True Then
                orden = 1
            End If
            If rbtTodosComp.Checked = True Then
                'listado de comprobantes `pendientes de pago facturas y remitos DOS
                If chkOrdVto.Checked = True Then
                    orden = 1
                End If

                salida = controlInforme.ObtenerComprobantesParaLiquidar(rec, "TodosCompPend", orden)
                For Each row As DataRow In rec.Rows
                    controlInforme.dtAutorizado(RstAux, Convert.ToInt32(row("NroInterno")))
                Next
                If salida = -1 Then
                    MsgBox("Error al obtener Comprobantes Pendientes de Pago Agrupado. Contáctese con el depto. de sistemas.", vbCritical)
                    Exit Sub
                ElseIf salida = 0 Then
                    MsgBox("No se obtuvieron datos de Comprobantes Pendientes de Pago Agrupado.", vbInformation)
                    Exit Sub
                Else
                    If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                        rptImpresoInforme = New FrmInformeVisualizador()
                    End If
                    If RstAux.Rows.Count > 0 Then
                        rptImpresoInforme.tablaSecundaria = RstAux
                    End If
                    'llama a RptImpresoComprobanteDia
                    rptImpresoInforme.dt = rec
                    rptImpresoInforme.informe = 31
                    rptImpresoInforme.Show()
                End If
            End If
        End If


        If chkDetOpFechas.Checked = True Then
            ' Obtener los datos de comprobantes de remitos del mes
            Dim salida As Integer
            Dim rec As DataTable = Nothing
            salida = controlInforme.ObtenerDetalleOrdenPagoMensualConFechas(dtpDesde.Value.ToShortDateString, dtpHasta.Value.ToShortDateString, rec)

            If salida = -1 Then
                MsgBox("Error al obtener datos de comprobantes de remitos del mes. No se puede continuar. Contáctese con el depto. de Sistemas.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No se encontraron datos de comprobantes de remitos del mes.", vbInformation)
            Else
                ' Mostrar el informe
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If

                Dim fechaMensaje As String = "Desde " & dtpDesde.Value & " al " & dtpHasta.Value
                Dim titulo As String = "RESUMEN DE ORDENES DE PAGO ENTRE FECHAS"

                ' Configurar el formulario del informe
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = titulo
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 32
                rptImpresoInforme.Show()
            End If
        End If
        If chkResCompPeriodico.Checked Then
            Dim desde As Date = dtpDesde.Value
            Dim hasta As Date = dtpHasta.Value
            Dim rec As New DataTable
            salida = controlInforme.ObtenerComprobantesdelMesPeriodico(dtpDesde.Value.ToShortDateString, dtpHasta.Value.ToShortDateString, rec)

            If salida = -1 Then
                MsgBox("Error al obtener datos de comprobantes de remitos del mes. No se puede continuar. Contáctese con el depto. de Sistemas.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No se encontraron datos de comprobantes de remitos del mes.", vbInformation)
            Else
                ' Mostrar el informe
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If

                Dim fechaMensaje As String = "Desde " & dtpDesde.Value & " al " & dtpHasta.Value
                Dim titulo As String = "Listado de Comprobantes"


                ' Configurar el formulario del informe
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = titulo
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 33
                rptImpresoInforme.Show()
            End If
        End If
        If chkResCompPeriodicoSinAnt.Checked Then
            Dim desde As Date = dtpDesde.Value
            Dim hasta As Date = dtpHasta.Value
            Dim rec As New DataTable
            salida = controlInforme.ObtenerComprobantesDesdeHastaSinAnticipos(dtpDesde.Value.ToShortDateString, dtpHasta.Value.ToShortDateString, rec)

            If salida = -1 Then
                MsgBox("Error al obtener datos de comprobantes de remitos del mes. No se puede continuar. Contáctese con el depto. de Sistemas.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No se encontraron datos de comprobantes de remitos del mes.", vbInformation)
            Else
                ' Mostrar el informe
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If

                Dim fechaMensaje As String = "Desde " & dtpDesde.Value & " al " & dtpHasta.Value
                Dim titulo As String = "Listado de Comprobantes"


                ' Configurar el formulario del informe
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = titulo
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 34
                rptImpresoInforme.Show()
            End If
        End If

        If chkResumenCompras.Checked Then
            Dim desde As Date = dtpDesde.Value
            Dim hasta As Date = dtpHasta.Value
            Dim rec As New DataTable
            salida = controlInforme.ObtenerDatosCompras(dtpDesde.Value.ToShortDateString, dtpHasta.Value.ToShortDateString, rec)

            If salida = -1 Then
                MsgBox("Error al obtener datos de compras de las fechas seleccionadas. No se puede continuar, contáctese con el depto. de Sistemas.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No se encontraron datos de compras de las fechas seleccionadas.", vbInformation)
            Else
                ' Mostrar el informe
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If

                Dim fechaMensaje As String = "Desde " & dtpDesde.Value & " al " & dtpHasta.Value
                Dim titulo As String = "Listado de Comprobantes"


                ' Configurar el formulario del informe
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = titulo
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 35
                rptImpresoInforme.Show()
            End If
        End If

        If chkRetencionGananciasDesdeHasta.Checked = True Then
            salida = controlInforme.ObtenerRetencionGananciasDesHas(dtpFechaDesdeRet.Value.ToShortDateString, dtpFechaHastaRet.Value.ToShortDateString, rec)
            If salida = -1 Then
                MsgBox("Error al obtener datos de Retenciones de Ganancias.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de Retenciones de Ganancias para los parámetros seleccionados.", vbInformation)
                Exit Sub
            Else
                Dim fechaMensaje As String = "Desde " & dtpFechaDesdeRet.Value & " al " & dtpFechaHastaRet.Value
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                'llama a RptRetencionesGan
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 36
                rptImpresoInforme.Show()
            End If
        End If

        If chkRetIBCbaDesdeHasta.Checked = True Then
            salida = controlInforme.ObtenerRetencionIBCordobaDesHas(dtpFechaDesdeRet.Value.ToShortDateString, dtpFechaHastaRet.Value.ToShortDateString, rec)
            Me.Cursor = Cursors.Default

            If salida = -1 Then
                MsgBox("Error al obtener datos de Retenciones de IIBB Córdoba.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de Retenciones de IIBB Córdoba para los parámetros seleccionados.", vbInformation)
                Exit Sub
            Else
                Dim fechaMensaje As String
                Dim tituloCba As String
                tituloCba = "Listado de Retenciones Ing. Brutos Cba."
                fechaMensaje = "Correspondiente a la selección de fecha desde: " & dtpFechaDesdeRet.Value.ToString("dd/MM/yyyy") & " hasta " & dtpFechaHastaRet.Value.ToString("dd/MM/yyyy")
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                'llama a RptImpresoRetencionesIBCba
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = tituloCba
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 37
                rptImpresoInforme.Show()
            End If
        End If


        If chkRetIBBsAsDesdeHasta.Checked = True Then
            salida = controlInforme.ObtenerRetencionIBBsAsDesHas(dtpFechaDesdeRet.Value.ToShortDateString, dtpFechaHastaRet.Value.ToShortDateString, rec)
            Me.Cursor = Cursors.Default

            If salida = -1 Then
                MsgBox("Error al obtener datos de Retenciones de IIBB Buenos Aires.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de Retenciones de IIBB de Buenos Aires para los parámetros seleccionados.", vbInformation)
                Exit Sub
            Else
                Dim fechaMensaje As String
                Dim titulo As String
                titulo = "Listado de Retenciones Ing. Brutos BsAs."
                fechaMensaje = "Correspondiente a la selección de fecha desde: " & dtpFechaDesdeRet.Value.ToString("dd/MM/yyyy") & " hasta " & dtpFechaHastaRet.Value.ToString("dd/MM/yyyy")
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                'llama a RptImpresoRetencionesIBCba
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = titulo
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 38
                rptImpresoInforme.Show()
            End If
        End If


        If chkRetIBSanLuisDesdeHasta.Checked = True Then
            salida = controlInforme.ObtenerRetencionIBSanLuisDesHas(dtpFechaDesdeRet.Value.ToShortDateString, dtpFechaHastaRet.Value.ToShortDateString, rec)
            Me.Cursor = Cursors.Default

            If salida = -1 Then
                MsgBox("Error al obtener datos de Retenciones de IIBB San Luis.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de Retenciones de IIBB de San Luis para los parámetros seleccionados.", vbInformation)
                Exit Sub
            Else
                Dim fechaMensaje As String
                Dim titulo As String
                titulo = "Listado de Retenciones Ing. Brutos San Luis."
                fechaMensaje = "Correspondiente a la selección de fecha desde: " & dtpFechaDesdeRet.Value.ToString("dd/MM/yyyy") & " hasta " & dtpFechaHastaRet.Value.ToString("dd/MM/yyyy")
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                'llama a RptImpresoRetencionesIBCba
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = titulo
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 39
                rptImpresoInforme.Show()
            End If
        End If

        If chkRetIBSantaFeDesdeHasta.Checked = True Then
            salida = controlInforme.ObtenerRetencionIBSantaFeDesHas(dtpFechaDesdeRet.Value.ToShortDateString, dtpFechaHastaRet.Value.ToShortDateString, rec)
            Me.Cursor = Cursors.Default

            If salida = -1 Then
                MsgBox("Error al obtener datos de Retenciones de IIBB Santa Fe.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de Retenciones de IIBB de Santa Fe para los parámetros seleccionados.", vbInformation)
                Exit Sub
            Else
                Dim fechaMensaje As String
                Dim titulo As String
                titulo = "Listado de Retenciones Ing. Brutos Santa Fe."
                fechaMensaje = "Correspondiente a la selección de fecha desde: " & dtpFechaDesdeRet.Value.ToString("dd/MM/yyyy") & " hasta " & dtpFechaHastaRet.Value.ToString("dd/MM/yyyy")
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                'llama a RptImpresoRetencionesIBCba
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = titulo
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 40
                rptImpresoInforme.Show()
            End If
        End If

        If chkRetIBMisionesDesdeHasta.Checked = True Then
            salida = controlInforme.ObtenerRetencionIBMisionesDesHas(dtpFechaDesdeRet.Value.ToShortDateString, dtpFechaHastaRet.Value.ToShortDateString, rec)
            Me.Cursor = Cursors.Default

            If salida = -1 Then
                MsgBox("Error al obtener datos de Retenciones de IIBB Misiones.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de Retenciones de IIBB de Misiones para los parámetros seleccionados.", vbInformation)
                Exit Sub
            Else
                Dim fechaMensaje As String
                Dim titulo As String
                titulo = "Listado de Retenciones Ing. Brutos Misiones."
                fechaMensaje = "Correspondiente a la selección de fecha desde: " & dtpFechaDesdeRet.Value.ToString("dd/MM/yyyy") & " hasta " & dtpFechaHastaRet.Value.ToString("dd/MM/yyyy")
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                'llama a RptImpresoRetencionesIBCba
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = titulo
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 41
                rptImpresoInforme.Show()
            End If
        End If

        If chkRetIBLaPampaDesHas.Checked = True Then
            salida = controlInforme.ObtenerRetencionIBLaPampaDesHas(dtpFechaDesdeRet.Value.ToShortDateString, dtpFechaHastaRet.Value.ToShortDateString, rec)
            Me.Cursor = Cursors.Default

            If salida = -1 Then
                MsgBox("Error al obtener datos de Retenciones de IIBB La Pampa.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de Retenciones de IIBB de La Pampa para los parámetros seleccionados.", vbInformation)
                Exit Sub
            Else
                Dim fechaMensaje As String
                Dim titulo As String
                titulo = "Listado de Retenciones Ing. Brutos La Pampa."
                fechaMensaje = "Correspondiente a la selección de fecha desde: " & dtpFechaDesdeRet.Value.ToString("dd/MM/yyyy") & " hasta " & dtpFechaHastaRet.Value.ToString("dd/MM/yyyy")
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                'llama a RptImpresoRetencionesIBCba
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = titulo
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 42
                rptImpresoInforme.Show()
            End If
        End If

        If chkRetIBJujuyDesHas.Checked = True Then
            salida = controlInforme.ObtenerRetencionIBJujuyDesHas(dtpFechaDesdeRet.Value.ToShortDateString, dtpFechaHastaRet.Value.ToShortDateString, rec)
            Me.Cursor = Cursors.Default

            If salida = -1 Then
                MsgBox("Error al obtener datos de Retenciones de IIBB Jujuy.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de Retenciones de IIBB de Jujuy para los parámetros seleccionados.", vbInformation)
                Exit Sub
            Else
                Dim fechaMensaje As String
                Dim titulo As String
                titulo = "Listado de Retenciones Ing. Brutos Jujuy."
                fechaMensaje = "Correspondiente a la selección de fecha desde: " & dtpFechaDesdeRet.Value.ToString("dd/MM/yyyy") & " hasta " & dtpFechaHastaRet.Value.ToString("dd/MM/yyyy")
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                'llama a RptImpresoRetencionesIBCba
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = titulo
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 43
                rptImpresoInforme.Show()
            End If
        End If


        If chkPercepIVADesdeHasta.Checked = True Then

            If lstFechas.Items.Count = 0 Then
                MsgBox("No existe ninguna fecha a seleccionar.", vbInformation)
                Exit Sub
            End If
            If ValidarFecha() = False Then
                Me.Cursor = Cursors.Default
                GPanel7.Enabled = True
                Exit Sub
            End If
            CadenaFecha = ""
            i = 0
            If rbtSeleccionarFechas.Checked Then

                For i As Integer = 0 To lstFechas.Items.Count - 1
                    If lstFechas.GetItemChecked(i) Then
                        If String.IsNullOrEmpty(CadenaFecha) Then
                            CadenaFecha &= $" '{lstFechas.Items(i).ToString()}'"
                        Else
                            CadenaFecha &= $", '{lstFechas.Items(i).ToString()}'"
                        End If
                    End If
                Next i
            Else
                For i As Integer = 0 To lstFechas.Items.Count - 1
                    lstFechas.SelectedIndex = i
                    If String.IsNullOrEmpty(CadenaFecha) Then
                        CadenaFecha &= $" '{lstFechas.Text}'"
                    Else
                        CadenaFecha &= $", '{lstFechas.Text}'"
                    End If
                Next i
            End If

            salida = controlInforme.ObtenerPercepcionesIVAMesImputacion(rec, CadenaFecha, rbtFechasTodas.Checked)
            If salida = -1 Then
                MsgBox("Error al obtener datos de Percepciones de I.V.A.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de Percepciones de I.V.A para el mes seleccionado.", vbInformation)
            Else
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                Dim fechaMensaje As String = "Correspondiente al mes " & CadenaFecha
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 44
                rptImpresoInforme.Show()
            End If
        End If

        If chkResCompProv.Checked = True Then

            If lstFechas.Items.Count = 0 Then
                MsgBox("No existe ninguna fecha a seleccionar.", vbInformation)
                Exit Sub
            End If
            If ValidarFecha() = False Then
                Me.Cursor = Cursors.Default
                GPanel7.Enabled = True
                Exit Sub
            End If
            CadenaFecha = ""
            i = 0
            If rbtSeleccionarFechas.Checked Then

                For i As Integer = 0 To lstFechas.Items.Count - 1
                    If lstFechas.GetItemChecked(i) Then
                        If String.IsNullOrEmpty(CadenaFecha) Then
                            CadenaFecha &= $" '{lstFechas.Items(i).ToString()}'"
                        Else
                            CadenaFecha &= $", '{lstFechas.Items(i).ToString()}'"
                        End If
                    End If
                Next i
            Else
                For i As Integer = 0 To lstFechas.Items.Count - 1
                    lstFechas.SelectedIndex = i
                    If String.IsNullOrEmpty(CadenaFecha) Then
                        CadenaFecha &= $" '{lstFechas.Text}'"
                    Else
                        CadenaFecha &= $", '{lstFechas.Text}'"
                    End If
                Next i
            End If

            salida = controlInforme.ObtenerComprobantesdelMesPeriodicoPorProveedor(rec, CadenaFecha, rbtFechasTodas.Checked)
            If salida = -1 Then
                MsgBox("Error al obtener datos de Resumen de Comprobantes ordenados por Proveedor.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de Comprobantes ordenados por Proveedor.", vbInformation)
            Else
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                Dim fechaMensaje As String = "Correspondiente al mes " & CadenaFecha
                Dim titulo As String = "Resumen Comprobante Agrupado por Proveedor"
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.lblTitulo = titulo
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 45
                rptImpresoInforme.Show()
            End If
        End If

        If chkPercepIBporProvDesdeHasta.Checked = True Then

            If lstFechas.Items.Count = 0 Then
                MsgBox("No existe ninguna fecha a seleccionar.", vbInformation)
                Exit Sub
            End If
            If ValidarFecha() = False Then
                Me.Cursor = Cursors.Default
                GPanel7.Enabled = True
                Exit Sub
            End If
            CadenaFecha = ""
            i = 0
            If rbtSeleccionarFechas.Checked Then

                For i As Integer = 0 To lstFechas.Items.Count - 1
                    If lstFechas.GetItemChecked(i) Then
                        If String.IsNullOrEmpty(CadenaFecha) Then
                            CadenaFecha &= $" '{lstFechas.Items(i).ToString()}'"
                        Else
                            CadenaFecha &= $", '{lstFechas.Items(i).ToString()}'"
                        End If
                    End If
                Next i
            Else
                For i As Integer = 0 To lstFechas.Items.Count - 1
                    lstFechas.SelectedIndex = i
                    If String.IsNullOrEmpty(CadenaFecha) Then
                        CadenaFecha &= $" '{lstFechas.Text}'"
                    Else
                        CadenaFecha &= $", '{lstFechas.Text}'"
                    End If
                Next i
            End If

            salida = controlInforme.ObtenerPercepcionesIBMesImputacion(rec, CadenaFecha, False)
            If salida = -1 Then
                MsgBox("Error al obtener datos de Percepciones de Ingresos Brutos. No se puede continuar. Contáctese con el depto. de Sistemas.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No se encontraron datos de Percepciones de Ingresos Brutos.", vbInformation)
            Else
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                Dim fechaMensaje As String = "Correspondiente al mes " & CadenaFecha
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 46
                rptImpresoInforme.Show()
            End If
        End If
        If chkPercepIBAduanaDesdeHasta.Checked = True Then

            If lstFechas.Items.Count = 0 Then
                MsgBox("No existe ninguna fecha a seleccionar.", vbInformation)
                Exit Sub
            End If
            If ValidarFecha() = False Then
                Me.Cursor = Cursors.Default
                GPanel7.Enabled = True
                Exit Sub
            End If
            CadenaFecha = ""
            i = 0
            If rbtSeleccionarFechas.Checked Then

                For i As Integer = 0 To lstFechas.Items.Count - 1
                    If lstFechas.GetItemChecked(i) Then
                        If String.IsNullOrEmpty(CadenaFecha) Then
                            CadenaFecha &= $" '{lstFechas.Items(i).ToString()}'"
                        Else
                            CadenaFecha &= $", '{lstFechas.Items(i).ToString()}'"
                        End If
                    End If
                Next i
            Else
                For i As Integer = 0 To lstFechas.Items.Count - 1
                    lstFechas.SelectedIndex = i
                    If String.IsNullOrEmpty(CadenaFecha) Then
                        CadenaFecha &= $" '{lstFechas.Text}'"
                    Else
                        CadenaFecha &= $", '{lstFechas.Text}'"
                    End If
                Next i
            End If

            salida = controlInforme.ObtenerPercepcionesIBMesImputacion(rec, CadenaFecha, True)
            If salida = -1 Then
                MsgBox("Error al obtener datos de Percepciones de Ingresos Brutos. No se puede continuar. Contáctese con el depto. de Sistemas.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No se encontraron datos de Percepciones de Ingresos Brutos.", vbInformation)
            Else
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                Dim fechaMensaje As String = "Correspondiente al mes " & CadenaFecha
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 47
                rptImpresoInforme.Show()
            End If
        End If

        'OTROS INFORMES
        'Listado de proveedores en SQL
        Dim CadEstado As String
        If chkListadoProveedores.Checked Then
            If rbtTodasFechas.Checked = True Then
                CadEstado = "0,1"
            ElseIf rbtActivos.Checked = True Then
                CadEstado = "1"
            Else
                CadEstado = "0"
            End If
            salida = controlInforme.BuscarTodosLosProveedores(rec, Me.rbtNroProveedor.Checked, CadEstado)
            If salida = -1 Then
                MsgBox("Error al obtener datos de proveedores.", vbCritical)
                Exit Sub
            ElseIf salida = 0 Then
                MsgBox("No existen datos de proveedores.", vbInformation)
                Exit Sub
            Else
                ' Verificar si el formulario ya está abierto
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                'Dim fechaMensaje As String = "Correspondiente al mes " & CadenaFecha
                'rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 48
                rptImpresoInforme.Show()
            End If
        End If


        If chkPorTiposComprobantes.Checked = True Then

            Dim salidaAsiento As Integer = controlInforme.ObtenerDatosPorTipoComprobante(cboTipoGrupo.SelectedIndex, cboMesC.SelectedIndex + 1, Val(cboAnioC.Text), rec, cboTipo.SelectedIndex)


            ' Mostrar el formulario de informe si hay datos
            If salidaAsiento = -1 Then
                MsgBox("Error al obtener datos por tipo comprobante insumo. No se puede continuar. Contáctese con el depto. de Sistemas.", vbCritical)
                Exit Sub
            ElseIf salidaAsiento = 0 Then
                MsgBox("No se encontraron datos por tipo comprobante insumo.", vbInformation)
            Else
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                Dim fechaMensaje As String = "Correspondiente al mes " & cboMesC.Text & " de " & cboAnioC.Text
                'If cboTipo.SelectedValue = 4 Then
                If cboTipo.Text.Trim() = "E" Then
                    ' Configurar el formulario de informe exportacion u$d
                    rptImpresoInforme.lblFecha = fechaMensaje
                    rptImpresoInforme.dt = rec
                    rptImpresoInforme.informe = 49
                    rptImpresoInforme.Show()
                Else
                    ' Configurar el formulario de informe
                    rptImpresoInforme.lblFecha = fechaMensaje
                    rptImpresoInforme.dt = rec
                    rptImpresoInforme.informe = 50
                    rptImpresoInforme.Show()
                End If
            End If
        End If
        If chkPorTiposComprobantesPorInsumo.Checked = True Then
            Dim salidaAsiento As Integer = controlInforme.ObtenerDatosPorTipoComprobantePorInsumo(cboTipoGrupo.SelectedIndex, cboMesC.SelectedIndex + 1, Val(cboAnioC.Text), rec, cboTipo.SelectedIndex)


            ' Mostrar el formulario de informe si hay datos
            If salidaAsiento = -1 Then
                MsgBox("Error al obtener datos por tipo comprobante insumo. No se puede continuar. Contáctese con el depto. de Sistemas.", vbCritical)
                Exit Sub
            ElseIf salidaAsiento = 0 Then
                MsgBox("No se encontraron datos por tipo comprobante insumo.", vbInformation)
            Else
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                Dim fechaMensaje As String = "Correspondiente al mes " & cboMesC.Text & " de " & cboAnioC.Text
                'If cboTipo.SelectedValue = 4 Then
                If cboTipo.Text.Trim() = "E" Then
                    ' Configurar el formulario de informe exportacion u$d
                    rptImpresoInforme.lblFecha = fechaMensaje
                    rptImpresoInforme.dt = rec
                    rptImpresoInforme.informe = 51
                    rptImpresoInforme.Show()
                Else
                    ' Configurar el formulario de informe
                    rptImpresoInforme.lblFecha = fechaMensaje
                    rptImpresoInforme.dt = rec
                    rptImpresoInforme.informe = 52
                    rptImpresoInforme.Show()
                End If
            End If
        End If


        If chkCompIVA75DesHas.Checked = True Then
            Dim salidaAsiento As Integer = controlInforme.ObtenerComprobantesDelMes75DesHas(dtpFechaDesdeRet.Value, dtpFechaHastaRet.Value, rec)


            ' Mostrar el formulario de informe si hay datos
            If salidaAsiento = -1 Then
                MsgBox("Error al obtener datos de comprobantes. No se puede continuar. Contáctese con el depto. de Sistemas.", vbCritical)
                Exit Sub
            ElseIf salidaAsiento = 0 Then
                MsgBox("No se encontraron datos de comprobantes.", vbInformation)
            Else
                If rptImpresoInforme Is Nothing OrElse rptImpresoInforme.IsDisposed Then
                    rptImpresoInforme = New FrmInformeVisualizador()
                End If
                Dim fechaMensaje As String = "Correspondiente a la selección de fecha desde: " & dtpFechaDesdeRet.Value.ToString("dd/MM/yyyy") & " hasta " & dtpFechaHastaRet.Value.ToString("dd/MM/yyyy")

                ' Configurar el formulario de informe exportacion u$d
                rptImpresoInforme.lblFecha = fechaMensaje
                rptImpresoInforme.dt = rec
                rptImpresoInforme.informe = 53
                rptImpresoInforme.Show()
            End If
        End If
        DesmarcarCheckBox()
    End Sub
    Private Sub DesmarcarCheckBox()
        ' Iterar a través de todos los CheckBox y desmarcarlos
        For Each panel As Guna2Panel In Me.Controls.OfType(Of Guna2Panel)()
            For Each chk As CheckBox In panel.Controls.OfType(Of CheckBox)()
                chk.Checked = False
            Next
        Next

        ' Actualizar el estado del botón después de desmarcar todos los CheckBox
        ActualizarEstadoBtnImprimir()
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub rbtVolver_Click(sender As Object, e As EventArgs) Handles rbtVolver.Click
        Me.Close()
    End Sub

    Private Sub FrmFiltroInforme_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ModuloComboBox.cargarComboInforme(CboMes, cboMesC, cboMesQ, cboAnio, cboAnioC, cboAnioQ)
        ModuloComboBox.cargarCboTipo(cboTipo)
        ModuloComboBox.cargarCboTipoGrupo(cboTipoGrupo)
        cboTipo.SelectedIndex = 0
        cboTipoGrupo.SelectedIndex = 0
        cargarMesesImputacion()
        lstFechas.Enabled = False
        dtpFecha.Value = Today
        dtpFechaDesdeIB.Value = New Date(Today.Year, Today.Month, 1)
        dtpFechaHastaIB.Value = Today
        dtpFechaHastaIB.Value = dtpFechaHastaIB.Value.AddDays(30)

        dtpDesde.Value = New Date(Today.Year, Today.Month, 1)
        dtpHasta.Value = Today
        dtpHasta.Value = dtpHasta.Value.AddDays(30)

        dtpFechaDesdeRet.Value = New Date(Today.Year, Today.Month, 1)
        dtpFechaHastaRet.Value = Today
        dtpFechaHastaRet.Value = dtpFechaHastaRet.Value.AddDays(30)

        ' Asociar el evento CheckedChanged a todos los CheckBox dentro de GPanelGuna
        For Each panel As Guna2Panel In Me.Controls.OfType(Of Guna2Panel)()
            For Each ctrl As Control In panel.Controls
                If TypeOf ctrl Is CheckBox Then
                    AddHandler DirectCast(ctrl, CheckBox).CheckedChanged, AddressOf CheckBox_CheckedChanged
                End If
            Next
        Next

        ' Llamar al método para inicializar el estado del botón
        ActualizarEstadoBtnImprimir()
    End Sub
    ' Este manejador de eventos se llama cada vez que cambia el estado de un CheckBox
    Private Sub CheckBox_CheckedChanged(sender As Object, e As EventArgs)
        ' Actualizar el estado del botón al cambiar cualquier CheckBox
        ActualizarEstadoBtnImprimir()
    End Sub

    ' Este método verifica si al menos un CheckBox está seleccionado
    Private Sub ActualizarEstadoBtnImprimir()
        ' Verificar si al menos un checkbox está seleccionado, excluyendo algunos radio buttons
        Dim alMenosUnCheckBoxSeleccionado As Boolean = Me.Controls.OfType(Of Guna2Panel)().SelectMany(Function(panel) panel.Controls.OfType(Of CheckBox)()).Any(Function(chk) chk.Checked AndAlso chk.Name <> "rbtFechasTodas" AndAlso chk.Name <> "rbt1ra")

        ' Habilitar o deshabilitar el botón según la condición
        btnImprimir.Enabled = alMenosUnCheckBoxSeleccionado
    End Sub




    Private Function ValidarFecha() As Boolean
        ValidarFecha = True
        If rbtSeleccionFechaIB.Checked = True Then
            If lstFechas.Items.Count = 0 Then
                MsgBox("Debe seleccionar un mes de imputación", vbInformation)
                ValidarFecha = False
                Exit Function
            End If
        End If
    End Function

    Private Sub cargarMesesImputacion()
        salida = controlInforme.ObtenerMesImputacion(Rst, "", True)

        i = 0
        lstFechas.Items.Clear()

        If Not Rst Is Nothing Then
            For index As Integer = Rst.Rows.Count - 1 To 0 Step -1
                Dim row As DataRow = Rst.Rows(index)
                lstFechas.Items.Add(Format(row("MesImputacion"), "MM/yyyy"))
                lstFechas.SetItemChecked(i, True)
                lstFechas.SelectedIndex = i
                i += 1
            Next
        End If

        Rst.Clear()
        Rst = Nothing
    End Sub


    Private Sub rbtFechasTodas_CheckedChanged(sender As Object, e As EventArgs) Handles rbtFechasTodas.CheckedChanged
        If rbtTodasFechas.Checked = True Then
            lstFechas.Enabled = False
        End If
        For i = 0 To lstFechas.Items.Count - 1
            lstFechas.SetItemChecked(i, True)
        Next i
    End Sub

    Private Sub rbtSeleccionarFechas_CheckedChanged(sender As Object, e As EventArgs) Handles rbtSeleccionarFechas.CheckedChanged
        If rbtSeleccionarFechas.Checked = True Then
            lstFechas.Enabled = True
            If lstFechas.Items.Count > 0 Then
                ' cmbGrabarVigencias.Enabled = True
            End If
            For i = 0 To lstFechas.Items.Count - 1
                lstFechas.SetItemChecked(i, False)
            Next i
        End If
    End Sub

    Private Sub chkasientoCompra_CheckedChanged(sender As Object, e As EventArgs) Handles chkasientoCompra.CheckedChanged
        If chkasientoCompra.Checked = False Then
            rbtFacturasDebitos.Checked = False
            rbtCred.Checked = False
            rbtCreInternosGuma.Checked = False
            rbtDebInternosGuma.Checked = False
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