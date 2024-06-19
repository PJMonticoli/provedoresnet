<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class RptImpresoPercepcionesIva
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptImpresoPercepcionesIva))
        Me.PageHeader = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.Shape3 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblProveedor = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblFechaHeader = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblTipo = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblProvincia = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblImporte = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblComprobante = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.txtRazonSocial = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtFechaComp = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTipo = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPrefijo = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtImporte = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtProveedor = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtCuit = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtComprobante = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTipoComp = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtNroComp = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtnroCompAlfanumerico = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.PageFooter = New GrapeCity.ActiveReports.SectionReportModel.PageFooter()
        Me.ReportHeader1 = New GrapeCity.ActiveReports.SectionReportModel.ReportHeader()
        Me.Picture1 = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.lblDireccion = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblJoseGuma = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Shape1 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Label1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblFecha = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.ReportFooter1 = New GrapeCity.ActiveReports.SectionReportModel.ReportFooter()
        Me.Shape2 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblTotales = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtTotal = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.lblPage = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtPage = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label2 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.lblPie = New GrapeCity.ActiveReports.SectionReportModel.Label()
        CType(Me.lblProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFechaHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProvincia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRazonSocial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrefijo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNroComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtnroCompAlfanumerico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape3, Me.lblProveedor, Me.lblFechaHeader, Me.lblTipo, Me.lblProvincia, Me.lblImporte, Me.lblComprobante})
        Me.PageHeader.Height = 0.3959973!
        Me.PageHeader.Name = "PageHeader"
        '
        'Shape3
        '
        Me.Shape3.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape3.Height = 0.3543307!
        Me.Shape3.Left = 0.07637796!
        Me.Shape3.Name = "Shape3"
        Me.Shape3.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape3.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape3.Top = 0!
        Me.Shape3.Width = 5.94882!
        '
        'lblProveedor
        '
        Me.lblProveedor.Height = 0.2!
        Me.lblProveedor.HyperLink = Nothing
        Me.lblProveedor.Left = 0.4062993!
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblProveedor.Text = "Proveedor"
        Me.lblProveedor.Top = 0.08503938!
        Me.lblProveedor.Width = 0.75!
        '
        'lblFechaHeader
        '
        Me.lblFechaHeader.Height = 0.2!
        Me.lblFechaHeader.HyperLink = Nothing
        Me.lblFechaHeader.Left = 2.098819!
        Me.lblFechaHeader.Name = "lblFechaHeader"
        Me.lblFechaHeader.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblFechaHeader.Text = "Fecha"
        Me.lblFechaHeader.Top = 0.08503938!
        Me.lblFechaHeader.Width = 0.5102362!
        '
        'lblTipo
        '
        Me.lblTipo.Height = 0.2!
        Me.lblTipo.HyperLink = Nothing
        Me.lblTipo.Left = 3.624803!
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblTipo.Text = "Tipo"
        Me.lblTipo.Top = 0.08503938!
        Me.lblTipo.Width = 0.4267717!
        '
        'lblProvincia
        '
        Me.lblProvincia.Height = 0.2!
        Me.lblProvincia.HyperLink = Nothing
        Me.lblProvincia.Left = 2.746457!
        Me.lblProvincia.Name = "lblProvincia"
        Me.lblProvincia.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblProvincia.Text = "C.U.I.T."
        Me.lblProvincia.Top = 0.08503938!
        Me.lblProvincia.Width = 0.5625984!
        '
        'lblImporte
        '
        Me.lblImporte.Height = 0.2!
        Me.lblImporte.HyperLink = Nothing
        Me.lblImporte.Left = 5.304725!
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblImporte.Text = "Importe"
        Me.lblImporte.Top = 0.08503938!
        Me.lblImporte.Width = 0.6251968!
        '
        'lblComprobante
        '
        Me.lblComprobante.Height = 0.2!
        Me.lblComprobante.HyperLink = Nothing
        Me.lblComprobante.Left = 4.142914!
        Me.lblComprobante.Name = "lblComprobante"
        Me.lblComprobante.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblComprobante.Text = "Comprobante"
        Me.lblComprobante.Top = 0.08503938!
        Me.lblComprobante.Width = 0.9688979!
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txtRazonSocial, Me.txtFechaComp, Me.txtTipo, Me.txtPrefijo, Me.txtImporte, Me.txtProveedor, Me.txtCuit, Me.txtComprobante, Me.txtTipoComp, Me.txtNroComp, Me.txtnroCompAlfanumerico})
        Me.Detail.Height = 0.2291666!
        Me.Detail.Name = "Detail"
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.CanGrow = False
        Me.txtRazonSocial.DataField = "rsocial"
        Me.txtRazonSocial.Height = 0.1574803!
        Me.txtRazonSocial.Left = 0.5700788!
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtRazonSocial.Text = "rsocial"
        Me.txtRazonSocial.Top = 0!
        Me.txtRazonSocial.Width = 1.31063!
        '
        'txtFechaComp
        '
        Me.txtFechaComp.DataField = "fechacomp"
        Me.txtFechaComp.Height = 0.2!
        Me.txtFechaComp.Left = 2.015354!
        Me.txtFechaComp.Name = "txtFechaComp"
        Me.txtFechaComp.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtFechaComp.Text = "fechacomp"
        Me.txtFechaComp.Top = 0!
        Me.txtFechaComp.Width = 0.5937008!
        '
        'txtTipo
        '
        Me.txtTipo.DataField = "TipoComp"
        Me.txtTipo.Height = 0.2!
        Me.txtTipo.Left = 3.52126!
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Style = "font-size: 8pt; text-align: center; ddo-char-set: 1"
        Me.txtTipo.Text = "tipo"
        Me.txtTipo.Top = 0!
        Me.txtTipo.Width = 0.5!
        '
        'txtPrefijo
        '
        Me.txtPrefijo.DataField = "nrocomp"
        Me.txtPrefijo.Height = 0.2!
        Me.txtPrefijo.Left = 4.231496!
        Me.txtPrefijo.Name = "txtPrefijo"
        Me.txtPrefijo.Style = "font-size: 8pt; text-align: left; ddo-char-set: 1"
        Me.txtPrefijo.Text = "nrocomp"
        Me.txtPrefijo.Top = 0!
        Me.txtPrefijo.Width = 0.9854326!
        '
        'txtImporte
        '
        Me.txtImporte.DataField = "percepiva"
        Me.txtImporte.Height = 0.2!
        Me.txtImporte.Left = 5.117717!
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtImporte.Text = "importe"
        Me.txtImporte.Top = 0!
        Me.txtImporte.Width = 0.7822843!
        '
        'txtProveedor
        '
        Me.txtProveedor.DataField = "nroProveedor"
        Me.txtProveedor.Height = 0.2!
        Me.txtProveedor.Left = 0.09094489!
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Style = "font-size: 8pt; text-align: center; ddo-char-set: 1"
        Me.txtProveedor.Text = "nroprov"
        Me.txtProveedor.Top = 0!
        Me.txtProveedor.Width = 0.4570866!
        '
        'txtCuit
        '
        Me.txtCuit.DataField = "NroCUIT"
        Me.txtCuit.Height = 0.2!
        Me.txtCuit.Left = 2.667323!
        Me.txtCuit.Name = "txtCuit"
        Me.txtCuit.OutputFormat = resources.GetString("txtCuit.OutputFormat")
        Me.txtCuit.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtCuit.Text = "cuit"
        Me.txtCuit.Top = 0!
        Me.txtCuit.Width = 0.8539372!
        '
        'txtComprobante
        '
        Me.txtComprobante.DataField = "DescComp"
        Me.txtComprobante.Height = 0.2!
        Me.txtComprobante.Left = 3.910237!
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtComprobante.Text = "A-"
        Me.txtComprobante.Top = 0!
        Me.txtComprobante.Width = 0.2803144!
        '
        'txtTipoComp
        '
        Me.txtTipoComp.DataField = "Tipocomp"
        Me.txtTipoComp.Height = 0.2!
        Me.txtTipoComp.Left = 3.336221!
        Me.txtTipoComp.Name = "txtTipoComp"
        Me.txtTipoComp.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtTipoComp.Text = Nothing
        Me.txtTipoComp.Top = 0.3208662!
        Me.txtTipoComp.Width = 0.8543305!
        '
        'txtNroComp
        '
        Me.txtNroComp.DataField = "nroComp"
        Me.txtNroComp.Height = 0.2!
        Me.txtNroComp.Left = 4.312205!
        Me.txtNroComp.Name = "txtNroComp"
        Me.txtNroComp.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtNroComp.Text = Nothing
        Me.txtNroComp.Top = 0.3208662!
        Me.txtNroComp.Width = 0.6149606!
        '
        'txtnroCompAlfanumerico
        '
        Me.txtnroCompAlfanumerico.DataField = "nroCompAlfanumerico"
        Me.txtnroCompAlfanumerico.Height = 0.2!
        Me.txtnroCompAlfanumerico.Left = 5.151575!
        Me.txtnroCompAlfanumerico.Name = "txtnroCompAlfanumerico"
        Me.txtnroCompAlfanumerico.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtnroCompAlfanumerico.Text = Nothing
        Me.txtnroCompAlfanumerico.Top = 0.3208662!
        Me.txtnroCompAlfanumerico.Width = 0.6149606!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblPage, Me.txtPage, Me.Label2, Me.TextBox1, Me.lblPie})
        Me.PageFooter.Height = 0.225082!
        Me.PageFooter.Name = "PageFooter"
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Picture1, Me.lblDireccion, Me.lblJoseGuma, Me.Shape1, Me.Label1, Me.lblFecha})
        Me.ReportHeader1.Height = 1.395833!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'Picture1
        '
        Me.Picture1.Height = 0.7582681!
        Me.Picture1.HyperLink = Nothing
        Me.Picture1.ImageBytes = CType(resources.GetObject("Picture1.ImageBytes"), Byte())
        Me.Picture1.Left = 0.05826771!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.Picture1.Top = 0!
        Me.Picture1.Width = 1.135039!
        '
        'lblDireccion
        '
        Me.lblDireccion.Height = 0.5582677!
        Me.lblDireccion.HyperLink = Nothing
        Me.lblDireccion.Left = 1.400787!
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.lblDireccion.Text = "lblDireccion"
        Me.lblDireccion.Top = 0.2!
        Me.lblDireccion.Width = 3.291339!
        '
        'lblJoseGuma
        '
        Me.lblJoseGuma.Height = 0.2!
        Me.lblJoseGuma.HyperLink = Nothing
        Me.lblJoseGuma.Left = 1.400787!
        Me.lblJoseGuma.Name = "lblJoseGuma"
        Me.lblJoseGuma.Style = "font-size: 12pt; font-weight: bold"
        Me.lblJoseGuma.Text = "José Guma S.A."
        Me.lblJoseGuma.Top = 0!
        Me.lblJoseGuma.Width = 1.416535!
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape1.Height = 0.5188978!
        Me.Shape1.Left = 0.05826772!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape1.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape1.Top = 0.8551185!
        Me.Shape1.Width = 5.96693!
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 1.944488!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-size: 12pt; font-weight: bold"
        Me.Label1.Text = "Listado de Percepciones I.V.A."
        Me.Label1.Top = 0.9118111!
        Me.Label1.Width = 2.624804!
        '
        'lblFecha
        '
        Me.lblFecha.Height = 0.2000001!
        Me.lblFecha.HyperLink = Nothing
        Me.lblFecha.Left = 1.400787!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "text-align: center"
        Me.lblFecha.Text = ""
        Me.lblFecha.Top = 1.111811!
        Me.lblFecha.Width = 3.623623!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape2, Me.lblTotales, Me.txtTotal})
        Me.ReportFooter1.Height = 0.3647146!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'Shape2
        '
        Me.Shape2.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape2.Height = 0.3334646!
        Me.Shape2.Left = 2.743307!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape2.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape2.Top = 0!
        Me.Shape2.Width = 3.281891!
        '
        'lblTotales
        '
        Me.lblTotales.Height = 0.2!
        Me.lblTotales.HyperLink = Nothing
        Me.lblTotales.Left = 2.826772!
        Me.lblTotales.Name = "lblTotales"
        Me.lblTotales.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblTotales.Text = "Total Percepciones"
        Me.lblTotales.Top = 0.06889764!
        Me.lblTotales.Width = 1.301969!
        '
        'txtTotal
        '
        Me.txtTotal.DataField = "total"
        Me.txtTotal.Height = 0.2!
        Me.txtTotal.Left = 4.342521!
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Style = "font-size: 9.75pt; font-weight: bold; text-align: right"
        Me.txtTotal.Text = "total"
        Me.txtTotal.Top = 0.06889764!
        Me.txtTotal.Width = 1.42244!
        '
        'lblPage
        '
        Me.lblPage.Height = 0.2!
        Me.lblPage.HyperLink = Nothing
        Me.lblPage.Left = 4.108269!
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Style = ""
        Me.lblPage.Text = "Página"
        Me.lblPage.Top = 0!
        Me.lblPage.Width = 0.5838585!
        '
        'txtPage
        '
        Me.txtPage.Height = 0.2!
        Me.txtPage.Left = 4.754331!
        Me.txtPage.Name = "txtPage"
        Me.txtPage.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All
        Me.txtPage.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.txtPage.Text = "#"
        Me.txtPage.Top = 0!
        Me.txtPage.Width = 0.3027558!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 5.057087!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = ""
        Me.Label2.Text = "de"
        Me.Label2.Top = 0!
        Me.Label2.Width = 0.2551181!
        '
        'TextBox1
        '
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 5.379134!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.TextBox1.Text = "##"
        Me.TextBox1.Top = 0!
        Me.TextBox1.Width = 0.3027558!
        '
        'lblPie
        '
        Me.lblPie.Height = 0.2!
        Me.lblPie.HyperLink = Nothing
        Me.lblPie.Left = 0.05826772!
        Me.lblPie.Name = "lblPie"
        Me.lblPie.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.lblPie.Text = "pie"
        Me.lblPie.Top = 0!
        Me.lblPie.Width = 3.062599!
        '
        'RptImpresoPercepcionesIva
        '
        Me.MasterReport = False
        Me.CompatibilityMode = GrapeCity.ActiveReports.Document.CompatibilityModes.CrossPlatform
        Me.PageSettings.Margins.Bottom = 0.3937007!
        Me.PageSettings.Margins.Left = 0.7874016!
        Me.PageSettings.Margins.Right = 0.7874016!
        Me.PageSettings.Margins.Top = 0.3937007!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 6.077477!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.PageFooter)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" &
            "l; font-size: 10pt; color: Black; ddo-char-set: 204", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" &
            "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.lblProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFechaHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProvincia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRazonSocial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrefijo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNroComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtnroCompAlfanumerico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private WithEvents ReportHeader1 As GrapeCity.ActiveReports.SectionReportModel.ReportHeader
    Private WithEvents ReportFooter1 As GrapeCity.ActiveReports.SectionReportModel.ReportFooter
    Private WithEvents Picture1 As GrapeCity.ActiveReports.SectionReportModel.Picture
    Private WithEvents lblDireccion As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblJoseGuma As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape1 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Label1 As GrapeCity.ActiveReports.SectionReportModel.Label
    Public WithEvents lblFecha As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape3 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblProveedor As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblFechaHeader As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblTipo As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblProvincia As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblImporte As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblComprobante As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape2 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblTotales As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtTotal As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtRazonSocial As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtFechaComp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTipo As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtPrefijo As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtImporte As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtProveedor As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtCuit As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtComprobante As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTipoComp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtNroComp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtnroCompAlfanumerico As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lblPage As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtPage As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label2 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lblPie As GrapeCity.ActiveReports.SectionReportModel.Label
End Class
