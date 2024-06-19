<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class RptImpresoComprobantesProveedores
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptImpresoComprobantesProveedores))
        Me.PageHeader = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.PageFooter = New GrapeCity.ActiveReports.SectionReportModel.PageFooter()
        Me.ReportHeader1 = New GrapeCity.ActiveReports.SectionReportModel.ReportHeader()
        Me.lblJoseGuma = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblDireccion = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Shape1 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblTitulo = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Picture1 = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.ReportFooter1 = New GrapeCity.ActiveReports.SectionReportModel.ReportFooter()
        Me.Shape3 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblPage = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtPage = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label2 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.lblPie = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label3 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label4 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label5 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label6 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label7 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label8 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtTipo = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtProveedor = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtDireccion = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtLocalidad = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtProvincia = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtCodPostal = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtNroCuit = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtIngBrutos = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLocalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProvincia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodPostal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNroCuit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIngBrutos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape3, Me.Label1, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8})
        Me.PageHeader.Height = 0.3042979!
        Me.PageHeader.Name = "PageHeader"
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txtTipo, Me.txtProveedor, Me.txtDireccion, Me.txtLocalidad, Me.txtProvincia, Me.txtCodPostal, Me.txtNroCuit, Me.txtIngBrutos})
        Me.Detail.Height = 0.208481!
        Me.Detail.Name = "Detail"
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblPage, Me.txtPage, Me.Label2, Me.TextBox1, Me.lblPie})
        Me.PageFooter.Height = 0.21875!
        Me.PageFooter.Name = "PageFooter"
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblJoseGuma, Me.lblDireccion, Me.Shape1, Me.lblTitulo, Me.Picture1})
        Me.ReportHeader1.Height = 1.15625!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'lblJoseGuma
        '
        Me.lblJoseGuma.Height = 0.2!
        Me.lblJoseGuma.HyperLink = Nothing
        Me.lblJoseGuma.Left = 1.296063!
        Me.lblJoseGuma.Name = "lblJoseGuma"
        Me.lblJoseGuma.Style = "font-size: 12pt; font-weight: bold"
        Me.lblJoseGuma.Text = "José Guma S.A."
        Me.lblJoseGuma.Top = 0.01181102!
        Me.lblJoseGuma.Width = 1.416535!
        '
        'lblDireccion
        '
        Me.lblDireccion.Height = 0.5228345!
        Me.lblDireccion.HyperLink = Nothing
        Me.lblDireccion.Left = 1.279133!
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.lblDireccion.Text = "lblDireccion"
        Me.lblDireccion.Top = 0.2472442!
        Me.lblDireccion.Width = 2.891732!
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape1.Height = 0.3149606!
        Me.Shape1.Left = 1.123623!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape1.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape1.Top = 0.8055114!
        Me.Shape1.Width = 5.884252!
        '
        'lblTitulo
        '
        Me.lblTitulo.Height = 0.2228346!
        Me.lblTitulo.HyperLink = Nothing
        Me.lblTitulo.Left = 1.684646!
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Style = "font-size: 11pt; font-weight: bold; text-align: center; ddo-char-set: 1"
        Me.lblTitulo.Text = "Listado de Proveedores "
        Me.lblTitulo.Top = 0.8574803!
        Me.lblTitulo.Width = 4.87126!
        '
        'Picture1
        '
        Me.Picture1.Height = 0.7582681!
        Me.Picture1.HyperLink = Nothing
        Me.Picture1.ImageBytes = CType(resources.GetObject("Picture1.ImageBytes"), Byte())
        Me.Picture1.Left = 0.05511808!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.Picture1.Top = 0.01181102!
        Me.Picture1.Width = 1.135039!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'Shape3
        '
        Me.Shape3.Height = 0.2834646!
        Me.Shape3.Left = 0.1468504!
        Me.Shape3.Name = "Shape3"
        Me.Shape3.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape3.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape3.Top = 0!
        Me.Shape3.Width = 7.37441!
        '
        'lblPage
        '
        Me.lblPage.Height = 0.2!
        Me.lblPage.HyperLink = Nothing
        Me.lblPage.Left = 5.727166!
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Style = ""
        Me.lblPage.Text = "Página"
        Me.lblPage.Top = 0!
        Me.lblPage.Width = 0.5838585!
        '
        'txtPage
        '
        Me.txtPage.Height = 0.2!
        Me.txtPage.Left = 6.373228!
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
        Me.Label2.Left = 6.675984!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = ""
        Me.Label2.Text = "de"
        Me.Label2.Top = 0!
        Me.Label2.Width = 0.2551181!
        '
        'TextBox1
        '
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 7.146851!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.TextBox1.Text = "##"
        Me.TextBox1.Top = 0.00000001490116!
        Me.TextBox1.Width = 0.3027558!
        '
        'lblPie
        '
        Me.lblPie.Height = 0.2!
        Me.lblPie.HyperLink = Nothing
        Me.lblPie.Left = 0.2241717!
        Me.lblPie.Name = "lblPie"
        Me.lblPie.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.lblPie.Text = "pie"
        Me.lblPie.Top = 0!
        Me.lblPie.Width = 3.062599!
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.2665355!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label1.Text = "Proveedor"
        Me.Label1.Top = 0.05590552!
        Me.Label1.Width = 0.7551182!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 2.104724!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label3.Text = "Dirección"
        Me.Label3.Top = 0.05590552!
        Me.Label3.Width = 0.7551181!
        '
        'Label4
        '
        Me.Label4.Height = 0.2!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 3.218898!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label4.Text = "Localidad"
        Me.Label4.Top = 0.05590552!
        Me.Label4.Width = 0.7551181!
        '
        'Label5
        '
        Me.Label5.Height = 0.2!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 4.208268!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label5.Text = "Provincia"
        Me.Label5.Top = 0.05590552!
        Me.Label5.Width = 0.7551181!
        '
        'Label6
        '
        Me.Label6.Height = 0.2!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 5.329922!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label6.Text = "CP"
        Me.Label6.Top = 0.05590552!
        Me.Label6.Width = 0.2551185!
        '
        'Label7
        '
        Me.Label7.Height = 0.2!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 5.840158!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label7.Text = "N°CUIT"
        Me.Label7.Top = 0.05590552!
        Me.Label7.Width = 0.5330712!
        '
        'Label8
        '
        Me.Label8.Height = 0.2!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 6.718504!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label8.Text = "Ing.Brutos"
        Me.Label8.Top = 0.05590552!
        Me.Label8.Width = 0.7311026!
        '
        'txtTipo
        '
        Me.txtTipo.DataField = "NROproveedor"
        Me.txtTipo.Height = 0.2!
        Me.txtTipo.Left = 0.0519685!
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtTipo.Text = "nro"
        Me.txtTipo.Top = 0!
        Me.txtTipo.Width = 0.3334646!
        '
        'txtProveedor
        '
        Me.txtProveedor.CanGrow = False
        Me.txtProveedor.DataField = "rsocial"
        Me.txtProveedor.Height = 0.1574803!
        Me.txtProveedor.Left = 0.4688977!
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtProveedor.Text = "proveedor"
        Me.txtProveedor.Top = 0!
        Me.txtProveedor.Width = 1.255118!
        '
        'txtDireccion
        '
        Me.txtDireccion.CanGrow = False
        Me.txtDireccion.DataField = "direccion"
        Me.txtDireccion.Height = 0.1614173!
        Me.txtDireccion.Left = 1.724016!
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtDireccion.Text = "direccion"
        Me.txtDireccion.Top = 0!
        Me.txtDireccion.Width = 1.405906!
        '
        'txtLocalidad
        '
        Me.txtLocalidad.CanGrow = False
        Me.txtLocalidad.DataField = "localidad"
        Me.txtLocalidad.Height = 0.1653543!
        Me.txtLocalidad.Left = 3.218898!
        Me.txtLocalidad.Name = "txtLocalidad"
        Me.txtLocalidad.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtLocalidad.Text = "localidad"
        Me.txtLocalidad.Top = 0!
        Me.txtLocalidad.Width = 0.93937!
        '
        'txtProvincia
        '
        Me.txtProvincia.DataField = "provincia"
        Me.txtProvincia.Height = 0.2!
        Me.txtProvincia.Left = 4.208268!
        Me.txtProvincia.Name = "txtProvincia"
        Me.txtProvincia.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtProvincia.Text = "provincia"
        Me.txtProvincia.Top = 0!
        Me.txtProvincia.Width = 1.096457!
        '
        'txtCodPostal
        '
        Me.txtCodPostal.DataField = "CODPOSTAL"
        Me.txtCodPostal.Height = 0.2!
        Me.txtCodPostal.Left = 5.329922!
        Me.txtCodPostal.Name = "txtCodPostal"
        Me.txtCodPostal.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtCodPostal.Text = "CP"
        Me.txtCodPostal.Top = 0!
        Me.txtCodPostal.Width = 0.4649606!
        '
        'txtNroCuit
        '
        Me.txtNroCuit.DataField = "nrocuit"
        Me.txtNroCuit.Height = 0.2!
        Me.txtNroCuit.Left = 5.794882!
        Me.txtNroCuit.Name = "txtNroCuit"
        Me.txtNroCuit.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtNroCuit.Text = "nro"
        Me.txtNroCuit.Top = 0!
        Me.txtNroCuit.Width = 0.8015747!
        '
        'txtIngBrutos
        '
        Me.txtIngBrutos.DataField = "ingbrutos"
        Me.txtIngBrutos.Height = 0.2!
        Me.txtIngBrutos.Left = 6.647638!
        Me.txtIngBrutos.Name = "txtIngBrutos"
        Me.txtIngBrutos.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtIngBrutos.Text = "ingresos"
        Me.txtIngBrutos.Top = 0!
        Me.txtIngBrutos.Width = 1.072835!
        '
        'RptImpresoComprobantesProveedores
        '
        Me.MasterReport = False
        Me.CompatibilityMode = GrapeCity.ActiveReports.Document.CompatibilityModes.CrossPlatform
        Me.PageSettings.Margins.Bottom = 0.3937007!
        Me.PageSettings.Margins.Left = 0.1968504!
        Me.PageSettings.Margins.Right = 0.1968504!
        Me.PageSettings.Margins.Top = 0.3937007!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.760417!
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
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLocalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProvincia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodPostal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNroCuit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIngBrutos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private WithEvents ReportHeader1 As GrapeCity.ActiveReports.SectionReportModel.ReportHeader
    Private WithEvents ReportFooter1 As GrapeCity.ActiveReports.SectionReportModel.ReportFooter
    Private WithEvents lblJoseGuma As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblDireccion As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape1 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblTitulo As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Picture1 As GrapeCity.ActiveReports.SectionReportModel.Picture
    Private WithEvents Shape3 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblPage As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtPage As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label2 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lblPie As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label1 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label3 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label4 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label5 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label6 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label7 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label8 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtTipo As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtProveedor As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtDireccion As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtLocalidad As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtProvincia As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtCodPostal As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtNroCuit As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtIngBrutos As GrapeCity.ActiveReports.SectionReportModel.TextBox
End Class
