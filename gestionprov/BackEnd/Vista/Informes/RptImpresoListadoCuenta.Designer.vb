<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class RptImpresoListadoCuenta
    Inherits GrapeCity.ActiveReports.SectionReport

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the ActiveReports Designer
    'It can be modified using the ActiveReports Designer.
    'Do not modify it using the code editor.
    Private WithEvents PageHeader As GrapeCity.ActiveReports.SectionReportModel.PageHeader
    Private WithEvents Detail As GrapeCity.ActiveReports.SectionReportModel.Detail
    Private WithEvents PageFooter As GrapeCity.ActiveReports.SectionReportModel.PageFooter
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptImpresoListadoCuenta))
        Me.PageHeader = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.Shape3 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblFecha = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblInsumo = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label2 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label3 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label4 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label5 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label6 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.txtFechaComp = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtInsumo = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtNroInterno = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPrefijo = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtCantidad = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPUnitario = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotal = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.PageFooter = New GrapeCity.ActiveReports.SectionReportModel.PageFooter()
        Me.lblPage = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtPage = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label7 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblPie = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupHeader1 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.GroupFooter1 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.txtCantidadFooter1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalFooter1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.lblFiltroTitulo = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblFiltro = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblPromedio = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.ReportHeader1 = New GrapeCity.ActiveReports.SectionReportModel.ReportHeader()
        Me.Picture1 = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.lblDireccion = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblJoseGuma = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Shape1 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Label1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.ReportFooter1 = New GrapeCity.ActiveReports.SectionReportModel.ReportFooter()
        Me.GroupHeader2 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.txtProveedor = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox2 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupFooter2 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.Label8 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtRazonSocial = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtCantidadFooter = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalFooter = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblInsumo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInsumo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNroInterno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrefijo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPUnitario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantidadFooter1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalFooter1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFiltroTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPromedio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRazonSocial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantidadFooter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalFooter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape3, Me.lblFecha, Me.lblInsumo, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.Label6})
        Me.PageHeader.Height = 0.3022473!
        Me.PageHeader.Name = "PageHeader"
        '
        'Shape3
        '
        Me.Shape3.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape3.Height = 0.2755905!
        Me.Shape3.Left = 0.08818898!
        Me.Shape3.Name = "Shape3"
        Me.Shape3.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape3.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape3.Top = 0!
        Me.Shape3.Width = 7.469686!
        '
        'lblFecha
        '
        Me.lblFecha.Height = 0.2!
        Me.lblFecha.HyperLink = Nothing
        Me.lblFecha.Left = 0.2291339!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblFecha.Text = "Fecha"
        Me.lblFecha.Top = 0.05590552!
        Me.lblFecha.Width = 0.75!
        '
        'lblInsumo
        '
        Me.lblInsumo.Height = 0.2!
        Me.lblInsumo.HyperLink = Nothing
        Me.lblInsumo.Left = 1.312992!
        Me.lblInsumo.Name = "lblInsumo"
        Me.lblInsumo.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblInsumo.Text = "Insumo"
        Me.lblInsumo.Top = 0.05590552!
        Me.lblInsumo.Width = 0.5102362!
        '
        'Label2
        '
        Me.Label2.Height = 0.196063!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 2.416929!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label2.Text = "N°Interno"
        Me.Label2.Top = 0.05984252!
        Me.Label2.Width = 0.7913386!
        '
        'Label3
        '
        Me.Label3.Height = 0.196063!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 3.405906!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label3.Text = "N°Comprobante"
        Me.Label3.Top = 0.05590552!
        Me.Label3.Width = 1.145276!
        '
        'Label4
        '
        Me.Label4.Height = 0.2!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 5.298032!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label4.Text = "Cantidad"
        Me.Label4.Top = 0.05196851!
        Me.Label4.Width = 0.6767716!
        '
        'Label5
        '
        Me.Label5.Height = 0.2!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 5.974803!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label5.Text = "P.Unitario"
        Me.Label5.Top = 0.05590552!
        Me.Label5.Width = 0.6767716!
        '
        'Label6
        '
        Me.Label6.Height = 0.2!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 6.953544!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label6.Text = "Total"
        Me.Label6.Top = 0.05196851!
        Me.Label6.Width = 0.5102362!
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txtFechaComp, Me.txtInsumo, Me.txtNroInterno, Me.txtPrefijo, Me.txtCantidad, Me.txtPUnitario, Me.txtTotal})
        Me.Detail.Height = 0.21875!
        Me.Detail.Name = "Detail"
        '
        'txtFechaComp
        '
        Me.txtFechaComp.DataField = "fechacomp"
        Me.txtFechaComp.Height = 0.2!
        Me.txtFechaComp.Left = 0.08818898!
        Me.txtFechaComp.Name = "txtFechaComp"
        Me.txtFechaComp.Style = "font-family: Microsoft Sans Serif; font-size: 8.25pt; ddo-char-set: 0"
        Me.txtFechaComp.Text = "fechacomp"
        Me.txtFechaComp.Top = 0!
        Me.txtFechaComp.Width = 0.6834646!
        '
        'txtInsumo
        '
        Me.txtInsumo.CanGrow = False
        Me.txtInsumo.DataField = "descinsumo"
        Me.txtInsumo.Height = 0.1574803!
        Me.txtInsumo.Left = 0.8291339!
        Me.txtInsumo.Name = "txtInsumo"
        Me.txtInsumo.Style = "font-family: Microsoft Sans Serif; font-size: 8.25pt; ddo-char-set: 0"
        Me.txtInsumo.Text = "desc insumo"
        Me.txtInsumo.Top = 0!
        Me.txtInsumo.Width = 1.514567!
        '
        'txtNroInterno
        '
        Me.txtNroInterno.DataField = "nrointerno"
        Me.txtNroInterno.Height = 0.2!
        Me.txtNroInterno.Left = 2.343701!
        Me.txtNroInterno.Name = "txtNroInterno"
        Me.txtNroInterno.Style = "font-family: Microsoft Sans Serif; font-size: 8.25pt; ddo-char-set: 0"
        Me.txtNroInterno.Text = "nrointerno"
        Me.txtNroInterno.Top = 0!
        Me.txtNroInterno.Width = 0.7188978!
        '
        'txtPrefijo
        '
        Me.txtPrefijo.DataField = "nrocomp"
        Me.txtPrefijo.Height = 0.2!
        Me.txtPrefijo.Left = 3.001181!
        Me.txtPrefijo.Name = "txtPrefijo"
        Me.txtPrefijo.Style = "font-family: Microsoft Sans Serif; font-size: 8.25pt; text-align: left; ddo-char-" &
    "set: 0"
        Me.txtPrefijo.Text = "nrocomp"
        Me.txtPrefijo.Top = 0!
        Me.txtPrefijo.Width = 2.29685!
        '
        'txtCantidad
        '
        Me.txtCantidad.DataField = "cantidad"
        Me.txtCantidad.Height = 0.2!
        Me.txtCantidad.Left = 5.301181!
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Style = "font-family: Microsoft Sans Serif; font-size: 8.25pt; text-align: right; ddo-char" &
    "-set: 0"
        Me.txtCantidad.Text = "cant"
        Me.txtCantidad.Top = 0!
        Me.txtCantidad.Width = 0.4736228!
        '
        'txtPUnitario
        '
        Me.txtPUnitario.DataField = "precio"
        Me.txtPUnitario.Height = 0.2!
        Me.txtPUnitario.Left = 5.771654!
        Me.txtPUnitario.Name = "txtPUnitario"
        Me.txtPUnitario.Style = "font-family: Microsoft Sans Serif; font-size: 8.25pt; text-align: right; ddo-char" &
    "-set: 0"
        Me.txtPUnitario.Text = "precio"
        Me.txtPUnitario.Top = 0!
        Me.txtPUnitario.Width = 0.879921!
        '
        'txtTotal
        '
        Me.txtTotal.DataField = "total"
        Me.txtTotal.Height = 0.2!
        Me.txtTotal.Left = 6.573229!
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Style = "font-family: Microsoft Sans Serif; font-size: 8.25pt; text-align: right; ddo-char" &
    "-set: 0"
        Me.txtTotal.Text = "total"
        Me.txtTotal.Top = 0!
        Me.txtTotal.Width = 0.9118109!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblPage, Me.txtPage, Me.Label7, Me.lblPie, Me.TextBox1})
        Me.PageFooter.Height = 0.225082!
        Me.PageFooter.Name = "PageFooter"
        '
        'lblPage
        '
        Me.lblPage.Height = 0.2!
        Me.lblPage.HyperLink = Nothing
        Me.lblPage.Left = 5.82323!
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Style = ""
        Me.lblPage.Text = "Página"
        Me.lblPage.Top = 0!
        Me.lblPage.Width = 0.6137815!
        '
        'txtPage
        '
        Me.txtPage.Height = 0.2!
        Me.txtPage.Left = 6.469292!
        Me.txtPage.Name = "txtPage"
        Me.txtPage.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.txtPage.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.txtPage.Text = "#"
        Me.txtPage.Top = 0!
        Me.txtPage.Width = 0.3326788!
        '
        'Label7
        '
        Me.Label7.Height = 0.2!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 6.772048!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = ""
        Me.Label7.Text = "de"
        Me.Label7.Top = 0!
        Me.Label7.Width = 0.2850411!
        '
        'lblPie
        '
        Me.lblPie.Height = 0.2!
        Me.lblPie.HyperLink = Nothing
        Me.lblPie.Left = 0.08818805!
        Me.lblPie.Name = "lblPie"
        Me.lblPie.Style = ""
        Me.lblPie.Text = "pie"
        Me.lblPie.Top = 0.02913386!
        Me.lblPie.Width = 2.56693!
        '
        'TextBox1
        '
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 7.152363!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.TextBox1.Text = "##"
        Me.TextBox1.Top = 0!
        Me.TextBox1.Width = 0.3326788!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txtCantidadFooter1, Me.txtTotalFooter1, Me.lblFiltroTitulo, Me.lblFiltro, Me.lblPromedio})
        Me.GroupFooter1.Height = 0.9583333!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'txtCantidadFooter1
        '
        Me.txtCantidadFooter1.DataField = "cantidad"
        Me.txtCantidadFooter1.Height = 0.2!
        Me.txtCantidadFooter1.Left = 5.234252!
        Me.txtCantidadFooter1.Name = "txtCantidadFooter1"
        Me.txtCantidadFooter1.Style = "background-color: #C8C8C8; text-align: right"
        Me.txtCantidadFooter1.Text = "cant"
        Me.txtCantidadFooter1.Top = 0!
        Me.txtCantidadFooter1.Width = 0.740551!
        '
        'txtTotalFooter1
        '
        Me.txtTotalFooter1.DataField = "total"
        Me.txtTotalFooter1.Height = 0.2!
        Me.txtTotalFooter1.Left = 6.432678!
        Me.txtTotalFooter1.Name = "txtTotalFooter1"
        Me.txtTotalFooter1.Style = "background-color: #C8C8C8; text-align: right"
        Me.txtTotalFooter1.SummaryGroup = "GroupHeader1"
        Me.txtTotalFooter1.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal
        Me.txtTotalFooter1.Text = "total"
        Me.txtTotalFooter1.Top = 0!
        Me.txtTotalFooter1.Width = 1.073228!
        '
        'lblFiltroTitulo
        '
        Me.lblFiltroTitulo.Height = 0.2!
        Me.lblFiltroTitulo.HyperLink = Nothing
        Me.lblFiltroTitulo.Left = 0.08818898!
        Me.lblFiltroTitulo.Name = "lblFiltroTitulo"
        Me.lblFiltroTitulo.Style = "background-color: Gray; font-size: 9.75pt; font-weight: bold"
        Me.lblFiltroTitulo.Text = "Filtro:"
        Me.lblFiltroTitulo.Top = 0.2!
        Me.lblFiltroTitulo.Width = 3.172835!
        '
        'lblFiltro
        '
        Me.lblFiltro.Height = 0.4468504!
        Me.lblFiltro.HyperLink = Nothing
        Me.lblFiltro.Left = 0.08818898!
        Me.lblFiltro.Name = "lblFiltro"
        Me.lblFiltro.Style = "background-color: Silver; font-size: 9.75pt; font-weight: normal"
        Me.lblFiltro.Text = ""
        Me.lblFiltro.Top = 0.4!
        Me.lblFiltro.Width = 3.172835!
        '
        'lblPromedio
        '
        Me.lblPromedio.Height = 0.6468505!
        Me.lblPromedio.HyperLink = Nothing
        Me.lblPromedio.Left = 4.333071!
        Me.lblPromedio.Name = "lblPromedio"
        Me.lblPromedio.Style = "background-color: Silver; font-size: 9.75pt; font-weight: normal; text-align: cen" &
    "ter"
        Me.lblPromedio.Text = "promedio"
        Me.lblPromedio.Top = 0.2!
        Me.lblPromedio.Width = 3.172835!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Picture1, Me.lblDireccion, Me.lblJoseGuma, Me.Shape1, Me.Label1})
        Me.ReportHeader1.Height = 1.177494!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'Picture1
        '
        Me.Picture1.Height = 0.7582681!
        Me.Picture1.HyperLink = Nothing
        Me.Picture1.ImageBytes = CType(resources.GetObject("Picture1.ImageBytes"), Byte())
        Me.Picture1.Left = 0.1778872!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.Picture1.Top = 0!
        Me.Picture1.Width = 1.135039!
        '
        'lblDireccion
        '
        Me.lblDireccion.Height = 0.5582678!
        Me.lblDireccion.HyperLink = Nothing
        Me.lblDireccion.Left = 1.406627!
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Style = "font-size: 8pt; text-align: left; ddo-char-set: 1"
        Me.lblDireccion.Text = "lblDireccion"
        Me.lblDireccion.Top = 0.2!
        Me.lblDireccion.Width = 2.854331!
        '
        'lblJoseGuma
        '
        Me.lblJoseGuma.Height = 0.2!
        Me.lblJoseGuma.HyperLink = Nothing
        Me.lblJoseGuma.Left = 1.406627!
        Me.lblJoseGuma.Name = "lblJoseGuma"
        Me.lblJoseGuma.Style = "font-size: 12pt; font-weight: bold"
        Me.lblJoseGuma.Text = "José Guma S.A."
        Me.lblJoseGuma.Top = 0!
        Me.lblJoseGuma.Width = 1.416535!
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape1.Height = 0.3149606!
        Me.Shape1.Left = 0.7720473!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape1.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape1.Top = 0.820866!
        Me.Shape1.Width = 5.935827!
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 1.604331!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-size: 12pt; font-weight: bold; text-align: center"
        Me.Label1.Text = "Listado de Insumos - Por Cuenta Contable"
        Me.Label1.Top = 0.8783465!
        Me.Label1.Width = 4.405906!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'GroupHeader2
        '
        Me.GroupHeader2.BackColor = System.Drawing.Color.Silver
        Me.GroupHeader2.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txtProveedor, Me.TextBox2})
        Me.GroupHeader2.DataField = "nroProveedor"
        Me.GroupHeader2.Height = 0.15625!
        Me.GroupHeader2.Name = "GroupHeader2"
        Me.GroupHeader2.NewColumn = GrapeCity.ActiveReports.SectionReportModel.NewColumn.Before
        '
        'txtProveedor
        '
        Me.txtProveedor.DataField = "nroProveedor"
        Me.txtProveedor.Height = 0.2!
        Me.txtProveedor.Left = 0.08818898!
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Style = "background-color: Silver; font-family: Microsoft Sans Serif; font-size: 8.25pt; t" &
    "ext-align: center; ddo-char-set: 0"
        Me.txtProveedor.Text = "nro"
        Me.txtProveedor.Top = 0!
        Me.txtProveedor.Width = 0.4570866!
        '
        'TextBox2
        '
        Me.TextBox2.CanGrow = False
        Me.TextBox2.DataField = "rsocial"
        Me.TextBox2.Height = 0.1606299!
        Me.TextBox2.Left = 0.5452756!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "background-color: Silver; font-family: Microsoft Sans Serif; font-size: 8.25pt; d" &
    "do-char-set: 0"
        Me.TextBox2.Text = "rsocial"
        Me.TextBox2.Top = 0!
        Me.TextBox2.Width = 2.808661!
        '
        'GroupFooter2
        '
        Me.GroupFooter2.BackColor = System.Drawing.Color.Silver
        Me.GroupFooter2.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Label8, Me.txtRazonSocial, Me.txtCantidadFooter, Me.txtTotalFooter})
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'Label8
        '
        Me.Label8.Height = 0.2!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 2.823229!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label8.Text = "Total"
        Me.Label8.Top = 0!
        Me.Label8.Width = 0.5102362!
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.CanGrow = False
        Me.txtRazonSocial.DataField = "rsocial"
        Me.txtRazonSocial.Height = 0.1574803!
        Me.txtRazonSocial.Left = 3.387008!
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Style = "font-family: Microsoft Sans Serif; font-size: 8.25pt; ddo-char-set: 0"
        Me.txtRazonSocial.Text = "rsocial"
        Me.txtRazonSocial.Top = 0!
        Me.txtRazonSocial.Width = 1.7063!
        '
        'txtCantidadFooter
        '
        Me.txtCantidadFooter.DataField = "cantidad"
        Me.txtCantidadFooter.Height = 0.2!
        Me.txtCantidadFooter.Left = 5.234252!
        Me.txtCantidadFooter.Name = "txtCantidadFooter"
        Me.txtCantidadFooter.Style = "text-align: right"
        Me.txtCantidadFooter.Text = "cant"
        Me.txtCantidadFooter.Top = 0!
        Me.txtCantidadFooter.Width = 0.5405507!
        '
        'txtTotalFooter
        '
        Me.txtTotalFooter.DataField = "total"
        Me.txtTotalFooter.Height = 0.2!
        Me.txtTotalFooter.Left = 6.432678!
        Me.txtTotalFooter.Name = "txtTotalFooter"
        Me.txtTotalFooter.Style = "text-align: right"
        Me.txtTotalFooter.SummaryGroup = "GroupHeader2"
        Me.txtTotalFooter.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal
        Me.txtTotalFooter.Text = "total"
        Me.txtTotalFooter.Top = 0!
        Me.txtTotalFooter.Width = 1.052362!
        '
        'RptImpresoListadoCuenta
        '
        Me.MasterReport = False
        Me.CompatibilityMode = GrapeCity.ActiveReports.Document.CompatibilityModes.CrossPlatform
        Me.PageSettings.Margins.Bottom = 0.3937007!
        Me.PageSettings.Margins.Left = 0.2755905!
        Me.PageSettings.Margins.Right = 0.2755905!
        Me.PageSettings.Margins.Top = 0.3937007!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.651296!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" &
            "l; font-size: 10pt; color: Black; ddo-char-set: 204", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" &
            "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblInsumo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInsumo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNroInterno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrefijo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPUnitario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantidadFooter1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalFooter1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFiltroTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPromedio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRazonSocial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantidadFooter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalFooter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents GroupHeader1 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GroupFooter1 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents ReportHeader1 As GrapeCity.ActiveReports.SectionReportModel.ReportHeader
    Private WithEvents Picture1 As GrapeCity.ActiveReports.SectionReportModel.Picture
    Private WithEvents lblDireccion As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblJoseGuma As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape1 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Label1 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents ReportFooter1 As GrapeCity.ActiveReports.SectionReportModel.ReportFooter
    Private WithEvents Shape3 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblFecha As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblInsumo As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label2 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label3 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label4 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label5 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label6 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtFechaComp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtInsumo As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtNroInterno As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtPrefijo As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtCantidad As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtPUnitario As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotal As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents GroupHeader2 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GroupFooter2 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents Label8 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtRazonSocial As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtCantidadFooter As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalFooter As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtCantidadFooter1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalFooter1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lblFiltroTitulo As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblPromedio As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtProveedor As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox2 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Public WithEvents lblFiltro As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblPage As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtPage As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label7 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblPie As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
End Class
