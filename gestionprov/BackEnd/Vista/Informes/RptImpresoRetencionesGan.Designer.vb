<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class RptImpresoRetencionesGan
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptImpresoRetencionesGan))
        Me.PageHeader = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.Shape2 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblProveedor = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label5 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblFechaHeader = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblImporte = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblCuit = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblNroRetencion = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.PageFooter = New GrapeCity.ActiveReports.SectionReportModel.PageFooter()
        Me.lblPage = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label3 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox2 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.ReportHeader1 = New GrapeCity.ActiveReports.SectionReportModel.ReportHeader()
        Me.Picture1 = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.lblJoseGuma = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Shape1 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Label1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblFecha = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblDireccion = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.ReportFooter1 = New GrapeCity.ActiveReports.SectionReportModel.ReportFooter()
        Me.Shape3 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblTotales = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtTotalGeneral = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line1 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.GroupHeader1 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.txtNroOP = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtNroProveedor = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TxtRSocial = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TxtFecha = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtImporte = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtCuit = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtNroRetencion = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupFooter1 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        CType(Me.lblProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFechaHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCuit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNroRetencion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNroOP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNroProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRSocial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNroRetencion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape2, Me.lblProveedor, Me.Label5, Me.lblFechaHeader, Me.lblImporte, Me.lblCuit, Me.lblNroRetencion})
        Me.PageHeader.Height = 0.3749508!
        Me.PageHeader.Name = "PageHeader"
        '
        'Shape2
        '
        Me.Shape2.BackColor = System.Drawing.Color.Gainsboro
        Me.Shape2.Height = 0.3275591!
        Me.Shape2.Left = 0.1251969!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(30.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape2.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape2.Top = 0!
        Me.Shape2.Width = 7.207874!
        '
        'lblProveedor
        '
        Me.lblProveedor.Height = 0.1574803!
        Me.lblProveedor.HyperLink = Nothing
        Me.lblProveedor.Left = 0.9275591!
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1"
        Me.lblProveedor.Text = "Proveedor"
        Me.lblProveedor.Top = 0.07086615!
        Me.lblProveedor.Width = 0.7082678!
        '
        'Label5
        '
        Me.Label5.Height = 0.1574803!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.3232284!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1"
        Me.Label5.Text = "N°OP"
        Me.Label5.Top = 0.07086615!
        Me.Label5.Width = 0.5625985!
        '
        'lblFechaHeader
        '
        Me.lblFechaHeader.Height = 0.2!
        Me.lblFechaHeader.HyperLink = Nothing
        Me.lblFechaHeader.Left = 3.802756!
        Me.lblFechaHeader.Name = "lblFechaHeader"
        Me.lblFechaHeader.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1"
        Me.lblFechaHeader.Text = "Fecha"
        Me.lblFechaHeader.Top = 0.07086615!
        Me.lblFechaHeader.Width = 0.5417322!
        '
        'lblImporte
        '
        Me.lblImporte.Height = 0.2!
        Me.lblImporte.HyperLink = Nothing
        Me.lblImporte.Left = 4.781497!
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1"
        Me.lblImporte.Text = "Importe"
        Me.lblImporte.Top = 0.07086615!
        Me.lblImporte.Width = 0.6771654!
        '
        'lblCuit
        '
        Me.lblCuit.Height = 0.2!
        Me.lblCuit.HyperLink = Nothing
        Me.lblCuit.Left = 5.749213!
        Me.lblCuit.Name = "lblCuit"
        Me.lblCuit.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1"
        Me.lblCuit.Text = "Cuit"
        Me.lblCuit.Top = 0.07086615!
        Me.lblCuit.Width = 0.4480314!
        '
        'lblNroRetencion
        '
        Me.lblNroRetencion.Height = 0.2!
        Me.lblNroRetencion.HyperLink = Nothing
        Me.lblNroRetencion.Left = 6.510237!
        Me.lblNroRetencion.Name = "lblNroRetencion"
        Me.lblNroRetencion.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1"
        Me.lblNroRetencion.Text = "N° Retención"
        Me.lblNroRetencion.Top = 0.07086615!
        Me.lblNroRetencion.Width = 0.7925191!
        '
        'Detail
        '
        Me.Detail.Height = 0!
        Me.Detail.Name = "Detail"
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblPage, Me.Label3, Me.TextBox1, Me.TextBox2})
        Me.PageFooter.Height = 0.2!
        Me.PageFooter.Name = "PageFooter"
        '
        'lblPage
        '
        Me.lblPage.Height = 0.2!
        Me.lblPage.HyperLink = Nothing
        Me.lblPage.Left = 4.625591!
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Style = ""
        Me.lblPage.Text = "Página"
        Me.lblPage.Top = 0!
        Me.lblPage.Width = 0.5838585!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 5.81378!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = ""
        Me.Label3.Text = "De"
        Me.Label3.Top = 0!
        Me.Label3.Width = 0.3125985!
        '
        'TextBox1
        '
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 6.197245!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.TextBox1.Text = "##"
        Me.TextBox1.Top = 0.00000001490116!
        Me.TextBox1.Width = 0.4062991!
        '
        'TextBox2
        '
        Me.TextBox2.Height = 0.2!
        Me.TextBox2.Left = 5.26063!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.TextBox2.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.TextBox2.Text = "#"
        Me.TextBox2.Top = 0!
        Me.TextBox2.Width = 0.3027558!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Picture1, Me.lblJoseGuma, Me.Shape1, Me.Label1, Me.lblFecha, Me.lblDireccion})
        Me.ReportHeader1.Height = 1.572917!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'Picture1
        '
        Me.Picture1.Height = 0.7582681!
        Me.Picture1.HyperLink = Nothing
        Me.Picture1.ImageBytes = CType(resources.GetObject("Picture1.ImageBytes"), Byte())
        Me.Picture1.Left = 0.1251969!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.Picture1.Top = 0!
        Me.Picture1.Width = 1.135039!
        '
        'lblJoseGuma
        '
        Me.lblJoseGuma.Height = 0.2!
        Me.lblJoseGuma.HyperLink = Nothing
        Me.lblJoseGuma.Left = 1.31378!
        Me.lblJoseGuma.Name = "lblJoseGuma"
        Me.lblJoseGuma.Style = "font-size: 12pt; font-weight: bold"
        Me.lblJoseGuma.Text = "José Guma S.A."
        Me.lblJoseGuma.Top = 0.06023622!
        Me.lblJoseGuma.Width = 1.416535!
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.Color.Gainsboro
        Me.Shape1.Height = 0.6874016!
        Me.Shape1.Left = 0.1251969!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape1.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape1.Top = 0.7933071!
        Me.Shape1.Width = 7.259843!
        '
        'Label1
        '
        Me.Label1.Height = 0.2519684!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 1.124803!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-size: 16pt; font-weight: bold; ddo-char-set: 1"
        Me.Label1.Text = "Listado de Retenciones Impuesto a las Ganancias"
        Me.Label1.Top = 0.9248032!
        Me.Label1.Width = 5.478741!
        '
        'lblFecha
        '
        Me.lblFecha.Height = 0.2!
        Me.lblFecha.HyperLink = Nothing
        Me.lblFecha.Left = 0.8956693!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "font-size: 9pt; font-weight: bold; text-align: center; ddo-char-set: 1"
        Me.lblFecha.Text = ""
        Me.lblFecha.Top = 1.176772!
        Me.lblFecha.Width = 5.896063!
        '
        'lblDireccion
        '
        Me.lblDireccion.Height = 0.4437009!
        Me.lblDireccion.HyperLink = Nothing
        Me.lblDireccion.Left = 1.31378!
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.lblDireccion.Text = "lblDireccion"
        Me.lblDireccion.Top = 0.3145669!
        Me.lblDireccion.Width = 3.895669!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape3, Me.lblTotales, Me.txtTotalGeneral, Me.Line1})
        Me.ReportFooter1.Height = 0.4168307!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'Shape3
        '
        Me.Shape3.BackColor = System.Drawing.Color.Gainsboro
        Me.Shape3.Height = 0.3543307!
        Me.Shape3.Left = 4.344489!
        Me.Shape3.Name = "Shape3"
        Me.Shape3.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(40.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape3.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape3.Top = 0.01968504!
        Me.Shape3.Width = 2.958267!
        '
        'lblTotales
        '
        Me.lblTotales.Height = 0.2!
        Me.lblTotales.HyperLink = Nothing
        Me.lblTotales.Left = 4.396851!
        Me.lblTotales.Name = "lblTotales"
        Me.lblTotales.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblTotales.Text = "Total Retenciones"
        Me.lblTotales.Top = 0.09999999!
        Me.lblTotales.Width = 1.27126!
        '
        'txtTotalGeneral
        '
        Me.txtTotalGeneral.Height = 0.2!
        Me.txtTotalGeneral.Left = 6.063385!
        Me.txtTotalGeneral.Name = "txtTotalGeneral"
        Me.txtTotalGeneral.Text = "total general"
        Me.txtTotalGeneral.Top = 0.09999999!
        Me.txtTotalGeneral.Width = 0.979134!
        '
        'Line1
        '
        Me.Line1.Height = 0!
        Me.Line1.Left = 0.2397633!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0!
        Me.Line1.Width = 7.239372!
        Me.Line1.X1 = 7.479135!
        Me.Line1.X2 = 0.2397633!
        Me.Line1.Y1 = 0!
        Me.Line1.Y2 = 0!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txtNroOP, Me.txtNroProveedor, Me.TxtRSocial, Me.TxtFecha, Me.txtImporte, Me.txtCuit, Me.txtNroRetencion})
        Me.GroupHeader1.DataField = "nroop"
        Me.GroupHeader1.Height = 0.2!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'txtNroOP
        '
        Me.txtNroOP.DataField = "NroOp"
        Me.txtNroOP.Height = 0.2!
        Me.txtNroOP.Left = 0.3232284!
        Me.txtNroOP.Name = "txtNroOP"
        Me.txtNroOP.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtNroOP.Text = "nroop"
        Me.txtNroOP.Top = 0!
        Me.txtNroOP.Width = 0.572441!
        '
        'txtNroProveedor
        '
        Me.txtNroProveedor.DataField = "NroProveedor"
        Me.txtNroProveedor.Height = 0.2!
        Me.txtNroProveedor.Left = 0.9275591!
        Me.txtNroProveedor.Name = "txtNroProveedor"
        Me.txtNroProveedor.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtNroProveedor.Text = "nro"
        Me.txtNroProveedor.Top = 0!
        Me.txtNroProveedor.Width = 0.3862205!
        '
        'TxtRSocial
        '
        Me.TxtRSocial.CanGrow = False
        Me.TxtRSocial.DataField = "Razonsocial"
        Me.TxtRSocial.Height = 0.1574803!
        Me.TxtRSocial.Left = 1.31378!
        Me.TxtRSocial.Name = "TxtRSocial"
        Me.TxtRSocial.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.TxtRSocial.Text = "razon social"
        Me.TxtRSocial.Top = 0!
        Me.TxtRSocial.Width = 2.288189!
        '
        'TxtFecha
        '
        Me.TxtFecha.DataField = "fechacomp"
        Me.TxtFecha.Height = 0.2!
        Me.TxtFecha.Left = 3.79252!
        Me.TxtFecha.Name = "TxtFecha"
        Me.TxtFecha.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.TxtFecha.Text = "fecha"
        Me.TxtFecha.Top = 0!
        Me.TxtFecha.Width = 0.8330708!
        '
        'txtImporte
        '
        Me.txtImporte.Height = 0.2!
        Me.txtImporte.Left = 4.730315!
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtImporte.Text = "importe"
        Me.txtImporte.Top = 0!
        Me.txtImporte.Width = 0.8330708!
        '
        'txtCuit
        '
        Me.txtCuit.DataField = "cuit"
        Me.txtCuit.Height = 0.2!
        Me.txtCuit.Left = 5.678347!
        Me.txtCuit.Name = "txtCuit"
        Me.txtCuit.OutputFormat = resources.GetString("txtCuit.OutputFormat")
        Me.txtCuit.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtCuit.Text = "cuit"
        Me.txtCuit.Top = 0!
        Me.txtCuit.Width = 0.8330708!
        '
        'txtNroRetencion
        '
        Me.txtNroRetencion.DataField = "Nrete"
        Me.txtNroRetencion.Height = 0.2!
        Me.txtNroRetencion.Left = 6.603544!
        Me.txtNroRetencion.Name = "txtNroRetencion"
        Me.txtNroRetencion.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtNroRetencion.Text = "nroretencion"
        Me.txtNroRetencion.Top = 0!
        Me.txtNroRetencion.Width = 0.7295275!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.02083333!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'RptImpresoRetencionesGan
        '
        Me.MasterReport = False
        Me.CompatibilityMode = GrapeCity.ActiveReports.Document.CompatibilityModes.CrossPlatform
        Me.PageSettings.Margins.Bottom = 0.3937008!
        Me.PageSettings.Margins.Left = 0.3937008!
        Me.PageSettings.Margins.Right = 0.3937008!
        Me.PageSettings.Margins.Top = 0.3937008!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.489041!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" &
            "l; font-size: 10pt; color: Black; ddo-char-set: 204", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" &
            "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.lblProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFechaHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCuit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNroRetencion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNroOP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNroProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRSocial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNroRetencion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private WithEvents ReportHeader1 As GrapeCity.ActiveReports.SectionReportModel.ReportHeader
    Private WithEvents ReportFooter1 As GrapeCity.ActiveReports.SectionReportModel.ReportFooter
    Private WithEvents GroupHeader1 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GroupFooter1 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents Shape1 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Label1 As GrapeCity.ActiveReports.SectionReportModel.Label
    Public WithEvents lblFecha As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape2 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblProveedor As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblPage As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label3 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape3 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblTotales As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtTotalGeneral As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Picture1 As GrapeCity.ActiveReports.SectionReportModel.Picture
    Private WithEvents lblJoseGuma As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label5 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblFechaHeader As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblImporte As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblCuit As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblNroRetencion As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtNroOP As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtNroProveedor As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TxtRSocial As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TxtFecha As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtImporte As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtCuit As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtNroRetencion As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lblDireccion As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Line1 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents TextBox2 As GrapeCity.ActiveReports.SectionReportModel.TextBox
End Class
