<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class RptImpresoPercepcionesGan
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptImpresoPercepcionesGan))
        Me.PageHeader = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.Shape3 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblProveedor = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblFechaHeader = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblNroInterno = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblTipo = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblComprobante = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblProvincia = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblImporte = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.txtRazonSocial = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtFechaComp = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtNroInterno = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTipo = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtComprobante = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtProvincia = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtImporte = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtProveedor = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.PageFooter = New GrapeCity.ActiveReports.SectionReportModel.PageFooter()
        Me.lblPage = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtPage = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label2 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblPie = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
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
        CType(Me.lblProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFechaHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNroInterno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProvincia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRazonSocial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNroInterno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProvincia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape3, Me.lblProveedor, Me.lblFechaHeader, Me.lblNroInterno, Me.lblTipo, Me.lblComprobante, Me.lblProvincia, Me.lblImporte})
        Me.PageHeader.Height = 0.4375!
        Me.PageHeader.Name = "PageHeader"
        '
        'Shape3
        '
        Me.Shape3.BackColor = System.Drawing.Color.Gainsboro
        Me.Shape3.Height = 0.3543307!
        Me.Shape3.Left = 0.07283464!
        Me.Shape3.Name = "Shape3"
        Me.Shape3.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape3.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape3.Top = 0!
        Me.Shape3.Width = 7.093701!
        '
        'lblProveedor
        '
        Me.lblProveedor.Height = 0.2!
        Me.lblProveedor.HyperLink = Nothing
        Me.lblProveedor.Left = 0.4791339!
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
        Me.lblFechaHeader.Left = 1.895276!
        Me.lblFechaHeader.Name = "lblFechaHeader"
        Me.lblFechaHeader.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblFechaHeader.Text = "Fecha"
        Me.lblFechaHeader.Top = 0.08503938!
        Me.lblFechaHeader.Width = 0.5102362!
        '
        'lblNroInterno
        '
        Me.lblNroInterno.Height = 0.2!
        Me.lblNroInterno.HyperLink = Nothing
        Me.lblNroInterno.Left = 2.488976!
        Me.lblNroInterno.Name = "lblNroInterno"
        Me.lblNroInterno.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblNroInterno.Text = "N° Interno"
        Me.lblNroInterno.Top = 0.08503938!
        Me.lblNroInterno.Width = 0.75!
        '
        'lblTipo
        '
        Me.lblTipo.Height = 0.2!
        Me.lblTipo.HyperLink = Nothing
        Me.lblTipo.Left = 3.322835!
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblTipo.Text = "Tipo"
        Me.lblTipo.Top = 0.08503938!
        Me.lblTipo.Width = 0.5204725!
        '
        'lblComprobante
        '
        Me.lblComprobante.Height = 0.2!
        Me.lblComprobante.HyperLink = Nothing
        Me.lblComprobante.Left = 3.937008!
        Me.lblComprobante.Name = "lblComprobante"
        Me.lblComprobante.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblComprobante.Text = "Comprobante"
        Me.lblComprobante.Top = 0.08503938!
        Me.lblComprobante.Width = 0.9688978!
        '
        'lblProvincia
        '
        Me.lblProvincia.Height = 0.2!
        Me.lblProvincia.HyperLink = Nothing
        Me.lblProvincia.Left = 5.234252!
        Me.lblProvincia.Name = "lblProvincia"
        Me.lblProvincia.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblProvincia.Text = "Provincia"
        Me.lblProvincia.Top = 0.08503938!
        Me.lblProvincia.Width = 0.8125983!
        '
        'lblImporte
        '
        Me.lblImporte.Height = 0.2!
        Me.lblImporte.HyperLink = Nothing
        Me.lblImporte.Left = 6.462993!
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblImporte.Text = "Importe"
        Me.lblImporte.Top = 0.08503938!
        Me.lblImporte.Width = 0.6251968!
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txtRazonSocial, Me.txtFechaComp, Me.txtNroInterno, Me.txtTipo, Me.txtComprobante, Me.txtProvincia, Me.txtImporte, Me.txtProveedor})
        Me.Detail.Height = 0.2083336!
        Me.Detail.Name = "Detail"
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.CanGrow = False
        Me.txtRazonSocial.DataField = "rsocial"
        Me.txtRazonSocial.Height = 0.1574803!
        Me.txtRazonSocial.Left = 0.4791339!
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
        Me.txtFechaComp.Left = 1.895276!
        Me.txtFechaComp.Name = "txtFechaComp"
        Me.txtFechaComp.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtFechaComp.Text = "fechacomp"
        Me.txtFechaComp.Top = 0!
        Me.txtFechaComp.Width = 0.5937008!
        '
        'txtNroInterno
        '
        Me.txtNroInterno.DataField = "nrointerno"
        Me.txtNroInterno.Height = 0.2!
        Me.txtNroInterno.Left = 2.617323!
        Me.txtNroInterno.Name = "txtNroInterno"
        Me.txtNroInterno.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtNroInterno.Text = "nrointerno"
        Me.txtNroInterno.Top = 0!
        Me.txtNroInterno.Width = 0.5291338!
        '
        'txtTipo
        '
        Me.txtTipo.DataField = "TipoComp"
        Me.txtTipo.Height = 0.2!
        Me.txtTipo.Left = 3.322835!
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtTipo.Text = "tipo"
        Me.txtTipo.Top = 0!
        Me.txtTipo.Width = 0.5!
        '
        'txtComprobante
        '
        Me.txtComprobante.DataField = "nrocomp"
        Me.txtComprobante.Height = 0.2!
        Me.txtComprobante.Left = 3.843307!
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.Style = "font-size: 8pt; text-align: center; ddo-char-set: 1"
        Me.txtComprobante.Text = "nrocomp"
        Me.txtComprobante.Top = 0!
        Me.txtComprobante.Width = 1.062598!
        '
        'txtProvincia
        '
        Me.txtProvincia.CanGrow = False
        Me.txtProvincia.DataField = "provincia"
        Me.txtProvincia.Height = 0.2!
        Me.txtProvincia.Left = 5.061811!
        Me.txtProvincia.Name = "txtProvincia"
        Me.txtProvincia.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtProvincia.Text = "provincia"
        Me.txtProvincia.Top = 0!
        Me.txtProvincia.Width = 1.202362!
        '
        'txtImporte
        '
        Me.txtImporte.DataField = "percepgan"
        Me.txtImporte.Height = 0.2!
        Me.txtImporte.Left = 6.180709!
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtImporte.Text = "importe"
        Me.txtImporte.Top = 0!
        Me.txtImporte.Width = 0.985827!
        '
        'txtProveedor
        '
        Me.txtProveedor.DataField = "nroProveedor"
        Me.txtProveedor.Height = 0.2!
        Me.txtProveedor.Left = 0!
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtProveedor.Text = "nroprov"
        Me.txtProveedor.Top = 0!
        Me.txtProveedor.Width = 0.4570866!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblPage, Me.txtPage, Me.Label2, Me.lblPie, Me.TextBox1})
        Me.PageFooter.Height = 0.2083333!
        Me.PageFooter.Name = "PageFooter"
        '
        'lblPage
        '
        Me.lblPage.Height = 0.2!
        Me.lblPage.HyperLink = Nothing
        Me.lblPage.Left = 5.259056!
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Style = ""
        Me.lblPage.Text = "Página"
        Me.lblPage.Top = 0!
        Me.lblPage.Width = 0.5838585!
        '
        'txtPage
        '
        Me.txtPage.Height = 0.2!
        Me.txtPage.Left = 5.905118!
        Me.txtPage.Name = "txtPage"
        Me.txtPage.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.txtPage.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.txtPage.Text = "#"
        Me.txtPage.Top = 0!
        Me.txtPage.Width = 0.3027558!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 6.207874!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = ""
        Me.Label2.Text = "de"
        Me.Label2.Top = 0!
        Me.Label2.Width = 0.2551181!
        '
        'lblPie
        '
        Me.lblPie.Height = 0.2!
        Me.lblPie.HyperLink = Nothing
        Me.lblPie.Left = 0.2559055!
        Me.lblPie.Name = "lblPie"
        Me.lblPie.Style = ""
        Me.lblPie.Text = "pie"
        Me.lblPie.Top = 0!
        Me.lblPie.Width = 2.56693!
        '
        'TextBox1
        '
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 6.588189!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.TextBox1.Text = "##"
        Me.TextBox1.Top = 0!
        Me.TextBox1.Width = 0.3027558!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Picture1, Me.lblDireccion, Me.lblJoseGuma, Me.Shape1, Me.Label1, Me.lblFecha})
        Me.ReportHeader1.Height = 1.402215!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'Picture1
        '
        Me.Picture1.Height = 0.7582681!
        Me.Picture1.HyperLink = Nothing
        Me.Picture1.ImageBytes = CType(resources.GetObject("Picture1.ImageBytes"), Byte())
        Me.Picture1.Left = 0.001181103!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.Picture1.Top = 0!
        Me.Picture1.Width = 1.135039!
        '
        'lblDireccion
        '
        Me.lblDireccion.Height = 0.5582677!
        Me.lblDireccion.HyperLink = Nothing
        Me.lblDireccion.Left = 1.343701!
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
        Me.lblJoseGuma.Left = 1.343701!
        Me.lblJoseGuma.Name = "lblJoseGuma"
        Me.lblJoseGuma.Style = "font-size: 12pt; font-weight: bold"
        Me.lblJoseGuma.Text = "José Guma S.A."
        Me.lblJoseGuma.Top = 0!
        Me.lblJoseGuma.Width = 1.416535!
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.Color.Gainsboro
        Me.Shape1.Height = 0.5708662!
        Me.Shape1.Left = 0.2559055!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape1.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape1.Top = 0.7877953!
        Me.Shape1.Width = 6.764961!
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 1.541732!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-size: 12pt; font-weight: bold"
        Me.Label1.Text = "Listado de Percepciones Impuesto a las Ganancias"
        Me.Label1.Top = 0.906693!
        Me.Label1.Width = 4.23937!
        '
        'lblFecha
        '
        Me.lblFecha.Height = 0.2!
        Me.lblFecha.HyperLink = Nothing
        Me.lblFecha.Left = 1.709055!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "text-align: center"
        Me.lblFecha.Text = ""
        Me.lblFecha.Top = 1.158661!
        Me.lblFecha.Width = 3.623623!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape2, Me.lblTotales, Me.txtTotal})
        Me.ReportFooter1.Height = 0.3438813!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'Shape2
        '
        Me.Shape2.BackColor = System.Drawing.Color.Gainsboro
        Me.Shape2.Height = 0.3334646!
        Me.Shape2.Left = 3.947244!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape2.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape2.Top = 0!
        Me.Shape2.Width = 3.219291!
        '
        'lblTotales
        '
        Me.lblTotales.Height = 0.2!
        Me.lblTotales.HyperLink = Nothing
        Me.lblTotales.Left = 4.030709!
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
        Me.txtTotal.Left = 5.557087!
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Style = "font-size: 9.75pt; font-weight: bold; text-align: right"
        Me.txtTotal.Text = "total"
        Me.txtTotal.Top = 0.06889764!
        Me.txtTotal.Width = 1.531102!
        '
        'RptImpresoPercepcionesGan
        '
        Me.MasterReport = False
        Me.CompatibilityMode = GrapeCity.ActiveReports.Document.CompatibilityModes.CrossPlatform
        Me.PageSettings.Margins.Bottom = 0.3937008!
        Me.PageSettings.Margins.Left = 0.3937008!
        Me.PageSettings.Margins.Right = 0.3937008!
        Me.PageSettings.Margins.Top = 0.3937008!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.229167!
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
        CType(Me.lblNroInterno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProvincia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRazonSocial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNroInterno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProvincia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private WithEvents ReportHeader1 As GrapeCity.ActiveReports.SectionReportModel.ReportHeader
    Private WithEvents ReportFooter1 As GrapeCity.ActiveReports.SectionReportModel.ReportFooter
    Private WithEvents Shape1 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Label1 As GrapeCity.ActiveReports.SectionReportModel.Label
    Public WithEvents lblFecha As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblJoseGuma As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblProveedor As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape2 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Shape3 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblTotales As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Picture1 As GrapeCity.ActiveReports.SectionReportModel.Picture
    Private WithEvents lblDireccion As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblFechaHeader As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblNroInterno As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblTipo As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblComprobante As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblProvincia As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblImporte As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtTotal As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lblPage As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtPage As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label2 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtProveedor As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtRazonSocial As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtFechaComp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtNroInterno As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTipo As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtComprobante As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lblPie As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtProvincia As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtImporte As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
End Class
