Imports GrapeCity.ActiveReports.SectionReportModel
Imports GrapeCity.DataVisualization.Chart

Public Class FrmInformeVisualizador
    Public dt As DataTable
    Public lblFecha As String
    Public lblTitulo As String
    Public lblfiltro As String
    Public informe As Integer
    Public tablaSecundaria As DataTable
    Private Sub FrmInformeVisualizador_Load() Handles Me.Load
        'Dim rptInforme As New RptImpresoInsumo
        'Viewer1.LoadDocument(rptInforme)

        Select Case informe
            Case 1
                Dim rptInforme As New RptImpresoInsumos
                'Informe ImpresoInsumos
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 2
                Dim rptInforme As New RptImpresoComprobanteDia
                'Informe ImpresoComprobanteDia
                rptInforme.periodo = lblFecha
                rptInforme.titulo = lblTitulo
                rptInforme.flag = 1
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 3
                Dim rptInforme As New RptImpresoControlDiario
                'Informe ImpresoControlDiario
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 4
                Dim rptInforme As New RptImpresoPercepcionesGan
                'Informe ImpresoPercepcionesGan
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 5
                Dim rptInforme As New RptImpresoPercepcionesGan
                'Informe ImpresoPercepcionesGan
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 6
                Dim rptInforme As New RptImpresoRetencionesGan
                'Informe RetencionesGan
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 7
                Dim rptInforme As New RptImpresoRetencionesIBCba
                'Informe RetencionesIBCBA
                rptInforme.periodo = lblFecha
                rptInforme.titulo = lblTitulo
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 8
                Dim rptInforme As New RptImpresoRetencionesIBCba
                'Informe RetencionesIBBsAs
                rptInforme.titulo = lblTitulo
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 9
                Dim rptInforme As New RptImpresoRetencionesIBCba
                'Informe RetencionesIBSanLuis
                rptInforme.titulo = lblTitulo
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 10
                Dim rptInforme As New RptImpresoRetencionesIBCba
                'Informe RetencionesIBSantaFe
                rptInforme.titulo = lblTitulo
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 11
                Dim rptInforme As New RptImpresoRetencionesIBCba
                'Informe RetencionesIBMisiones
                rptInforme.titulo = lblTitulo
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 12
                Dim rptInforme As New RptImpresoRetencionesIBCba
                'Informe RetencionesIBLaPampa
                rptInforme.titulo = lblTitulo
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 13
                Dim rptInforme As New RptImpresoRetencionesIBCba
                'Informe RetencionesIBLaPampa
                rptInforme.titulo = lblTitulo
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 14
                Dim rptInforme As New RptImpresoRetencionesIBCba
                'Informe RetencionesIBLaPampa
                rptInforme.titulo = lblTitulo
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 15
                Dim rptInforme As New RptComprobanteIndustrialConsuman
                'Informe ComprobantesIndustrialesConsuman
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 16
                Dim rptInforme As New RptImpresoPercepcionesIva
                'Informe PercepcionesIva
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 17
                Dim rptInforme As New RptImpresoPercepcionesIBPorProv
                'Informe ImpresoPercepcionesIBPorProv
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 18
                Dim rptInforme As New RptImpresoComprobanteDia
                'Informe ImpresoComprobanteDia
                rptInforme.periodo = lblFecha
                rptInforme.titulo = lblTitulo
                rptInforme.flag = 2
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 19
                Dim rptInforme As New RptImpresoResumenOP
                'Informe ImpresoResumenOP
                rptInforme.periodo = lblFecha
                rptInforme.titulo = lblTitulo
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 20
                Dim rptInforme As New RptImpresoPercepcionesGan
                'Informe ImpresoPercepcionesGan
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 21
                Dim rptInforme As New RptImpresoPercepcionesIBPorProv
                'Informe ImpresoPercepcionesIBPorProv
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 22
                Dim rptInforme As New RptImpresoInsumos
                'Informe ImpresoInsumos
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 23
                Dim rptInforme As New RptImpresoComprobante
                'Informe ImpresoComprobante
                rptInforme.periodo = lblFecha
                rptInforme.titulo = lblTitulo
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 24
                Dim rptInforme As New RptImpresoComprobante
                'Informe ImpresoComprobante
                rptInforme.periodo = lblFecha
                rptInforme.titulo = lblTitulo
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 25
                Dim rptInforme As New RptImpresoAsientoCompras
                'Informe ImpresoAsientoCompras
                If tablaSecundaria.Rows.Count > 0 OrElse tablaSecundaria Is Nothing Then
                    rptInforme.tabla = tablaSecundaria
                    rptInforme.titulo = lblTitulo
                End If
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 26
                Dim rptInforme As New RptImpresoComprobanteDia
                'Informe ImpresoComprobanteDia
                rptInforme.periodo = lblFecha
                rptInforme.titulo = lblTitulo
                rptInforme.flag = 3
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 27
                Dim rptInforme As New RptImpresoComprobanteDia
                'Informe ImpresoComprobanteDia
                rptInforme.periodo = lblFecha
                rptInforme.titulo = lblTitulo
                rptInforme.flag = 4
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 28
                Dim rptInforme As New RptImpresoListadoCuenta
                'Informe ImpresoListadoCuenta
                rptInforme.lblFiltro.Text = lblfiltro
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 29
                Dim rptInforme As New RptImpresoComprobantePendiente
                'Informe ImpresoComprobantePendiente
                rptInforme.tabla = tablaSecundaria
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 30
                Dim rptInforme As New RptImpresoComprobantePendienteSinGrupo
                'Informe ImpresoComprobantePendienteSinGrupo
                rptInforme.tabla = tablaSecundaria
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 31
                Dim rptInforme As New RptImpresoComprobantePendienteAgrupado
                'Informe ImpresoComprobantePendienteAgrupado
                rptInforme.tabla = tablaSecundaria
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 32
                Dim rptInforme As New RptImpresoResumenOP
                'Informe ImpresoResumenOP
                rptInforme.periodo = lblFecha
                rptInforme.titulo = lblTitulo
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 33
                Dim rptInforme As New RptImpresoComprobante
                'Informe ImpresoComprobante
                rptInforme.periodo = lblFecha
                rptInforme.titulo = lblTitulo
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 34
                Dim rptInforme As New RptImpresoComprobante
                'Informe ImpresoComprobante
                rptInforme.periodo = lblFecha
                rptInforme.titulo = lblTitulo
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 35
                Dim rptInforme As New RptImpresoInsumosComprados
                'Informe ImpresoComprobante
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 36
                Dim rptInforme As New RptImpresoRetencionesGan
                'Informe ImpresoRetencionesGan
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 37
                Dim rptInforme As New RptImpresoRetencionesIBCba
                'Informe ImpresoRetencionesIBCbaDesHasta
                rptInforme.periodo = lblFecha
                rptInforme.titulo = lblTitulo
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 38
                Dim rptInforme As New RptImpresoRetencionesIBCba
                'Informe ImpresoRetencionesIBBSASDesHasta
                rptInforme.periodo = lblFecha
                rptInforme.titulo = lblTitulo
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 39
                Dim rptInforme As New RptImpresoRetencionesIBCba
                'Informe ImpresoRetencionesIBSanLuisDesHasta
                rptInforme.periodo = lblFecha
                rptInforme.titulo = lblTitulo
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 40
                Dim rptInforme As New RptImpresoRetencionesIBCba
                'Informe ImpresoRetencionesIBSantaFeDesHasta
                rptInforme.periodo = lblFecha
                rptInforme.titulo = lblTitulo
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 41
                Dim rptInforme As New RptImpresoRetencionesIBCba
                'Informe ImpresoRetencionesIBMisionesDesHasta
                rptInforme.periodo = lblFecha
                rptInforme.titulo = lblTitulo
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 42
                Dim rptInforme As New RptImpresoRetencionesIBCba
                'Informe ImpresoRetencionesIBLaPampaDesHasta
                rptInforme.periodo = lblFecha
                rptInforme.titulo = lblTitulo
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 43
                Dim rptInforme As New RptImpresoRetencionesIBCba
                'Informe ImpresoRetencionesIBJujuyDesHasta
                rptInforme.periodo = lblFecha
                rptInforme.titulo = lblTitulo
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 44
                Dim rptInforme As New RptImpresoPercepcionesIva
                'Informe ImpresoPercepcionesIva
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 45
                Dim rptInforme As New RptImpresoComprobanteAgrupadoPorProveedor
                'Informe ImpresoComprobanteAgrupadoPorProveedor
                rptInforme.periodo = lblFecha
                rptInforme.titulo = lblTitulo
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 46
                Dim rptInforme As New RptImpresoPercepcionesIBPorProv
                'Informe ImpresoPercepcionesIBPorProv
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 47
                Dim rptInforme As New RptImpresoPercepcionesIBPorProv
                'Informe ImpresoPercepcionesIBPorProv
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 48
                Dim rptInforme As New RptImpresoComprobantesProveedores
                'Informe ImpresoPercepcionesIBPorProv
                'rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 49
                Dim rptInforme As New RptImpresoComprobantePorTipoCompExp
                'Informe ImpresoComprobantePorTipoCompPorInsumoExp
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 50
                Dim rptInforme As New RptImpresoComprobantePorTipoComp
                'Informe ImpresoComprobantePorTipoCompPorInsumo
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 51
                Dim rptInforme As New RptImpresoComprobantePorTipoCompPorInsumoExp
                'Informe ImpresoComprobantePorTipoCompPorInsumoExp
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 52
                Dim rptInforme As New RptImpresoComprobantePorTipoCompPorInsumo
                'Informe ImpresoComprobantePorTipoCompPorInsumo
                'rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)
            Case 53
                Dim rptInforme As New RptImpresoComprobantesImpuestoPais75
                'Informe ImpresoComprobantesImpuestoPais75
                rptInforme.periodo = lblFecha
                rptInforme.DataSource = dt
                Viewer1.LoadDocument(rptInforme)

        End Select
    End Sub

End Class