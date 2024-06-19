<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class RptImpresoResumenOP
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptImpresoResumenOP))
        Me.PageHeader = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.Shape2 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.TextBox1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox2 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line1 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.txtCodInsumo = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtDescripcion = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtImporte = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.PageFooter = New GrapeCity.ActiveReports.SectionReportModel.PageFooter()
        Me.lblPage = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtPage = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label3 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblPie = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox8 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.ReportHeader1 = New GrapeCity.ActiveReports.SectionReportModel.ReportHeader()
        Me.Picture1 = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.lblDireccion = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Shape1 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblTitulo = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblFecha = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblJoseGuma = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.ReportFooter1 = New GrapeCity.ActiveReports.SectionReportModel.ReportFooter()
        Me.Shape3 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblTotales = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtTotalGeneral = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupHeader1 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.TextBox3 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtCodTipo = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtCodCuenta = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupFooter1 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.lblTipo = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtTotalCuenta = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line2 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line3 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.GroupHeader2 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.GroupFooter2 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodInsumo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape2, Me.TextBox1, Me.TextBox2, Me.Line1})
        Me.PageHeader.Height = 0.4166667!
        Me.PageHeader.Name = "PageHeader"
        '
        'Shape2
        '
        Me.Shape2.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape2.Height = 0.2952756!
        Me.Shape2.Left = 0.2811024!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape2.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape2.Top = 0!
        Me.Shape2.Width = 6.904331!
        '
        'TextBox1
        '
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 0.6200788!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "font-size: 9.75pt; font-weight: bold"
        Me.TextBox1.Text = "Proveedor"
        Me.TextBox1.Top = 0.06377953!
        Me.TextBox1.Width = 1.0!
        '
        'TextBox2
        '
        Me.TextBox2.Height = 0.2!
        Me.TextBox2.Left = 6.440158!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "font-size: 9.75pt; font-weight: bold"
        Me.TextBox2.Text = "Importe"
        Me.TextBox2.Top = 0.06377953!
        Me.TextBox2.Width = 0.6464567!
        '
        'Line1
        '
        Me.Line1.Height = 0!
        Me.Line1.Left = 0.02598425!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.3507874!
        Me.Line1.Width = 7.708271!
        Me.Line1.X1 = 0.02598425!
        Me.Line1.X2 = 7.734255!
        Me.Line1.Y1 = 0.3507874!
        Me.Line1.Y2 = 0.3507874!
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txtCodInsumo, Me.txtDescripcion, Me.txtImporte})
        Me.Detail.Height = 0.2291667!
        Me.Detail.Name = "Detail"
        '
        'txtCodInsumo
        '
        Me.txtCodInsumo.DataField = "codproveedor"
        Me.txtCodInsumo.Height = 0.2!
        Me.txtCodInsumo.Left = 1.541339!
        Me.txtCodInsumo.Name = "txtCodInsumo"
        Me.txtCodInsumo.Style = "color: Black; font-size: 8pt; ddo-char-set: 1"
        Me.txtCodInsumo.Text = "codinsumo"
        Me.txtCodInsumo.Top = 0!
        Me.txtCodInsumo.Width = 1.0!
        '
        'txtDescripcion
        '
        Me.txtDescripcion.DataField = "RSocial"
        Me.txtDescripcion.Height = 0.2!
        Me.txtDescripcion.Left = 2.698032!
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Style = "color: Black; font-size: 8pt; ddo-char-set: 1"
        Me.txtDescripcion.Text = "rsocial"
        Me.txtDescripcion.Top = 0!
        Me.txtDescripcion.Width = 2.854331!
        '
        'txtImporte
        '
        Me.txtImporte.DataField = "TotalPagado"
        Me.txtImporte.Height = 0.2!
        Me.txtImporte.Left = 5.622047!
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtImporte.Text = "importe"
        Me.txtImporte.Top = 0!
        Me.txtImporte.Width = 1.365748!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblPage, Me.txtPage, Me.Label3, Me.lblPie, Me.TextBox8})
        Me.PageFooter.Name = "PageFooter"
        '
        'lblPage
        '
        Me.lblPage.Height = 0.2!
        Me.lblPage.HyperLink = Nothing
        Me.lblPage.Left = 5.317717!
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.lblPage.Text = "Página"
        Me.lblPage.Top = 0!
        Me.lblPage.Width = 0.5838585!
        '
        'txtPage
        '
        Me.txtPage.Height = 0.2!
        Me.txtPage.Left = 6.03701!
        Me.txtPage.Name = "txtPage"
        Me.txtPage.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtPage.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All
        Me.txtPage.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.txtPage.Text = "#"
        Me.txtPage.Top = 0!
        Me.txtPage.Width = 0.3027558!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 6.443307!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.Label3.Text = "de"
        Me.Label3.Top = 0!
        Me.Label3.Width = 0.2708659!
        '
        'lblPie
        '
        Me.lblPie.Height = 0.2!
        Me.lblPie.HyperLink = Nothing
        Me.lblPie.Left = 0.2031496!
        Me.lblPie.Name = "lblPie"
        Me.lblPie.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.lblPie.Text = "pie"
        Me.lblPie.Top = 0!
        Me.lblPie.Width = 3.062599!
        '
        'TextBox8
        '
        Me.TextBox8.Height = 0.2!
        Me.TextBox8.Left = 6.828739!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.TextBox8.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.TextBox8.Text = "##"
        Me.TextBox8.Top = 0!
        Me.TextBox8.Width = 0.3027558!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Picture1, Me.lblDireccion, Me.Shape1, Me.lblTitulo, Me.lblFecha, Me.lblJoseGuma})
        Me.ReportHeader1.Height = 1.5625!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'Picture1
        '
        Me.Picture1.Height = 0.7582681!
        Me.Picture1.HyperLink = Nothing
        Me.Picture1.ImageBytes = CType(resources.GetObject("Picture1.ImageBytes"), Byte())
        Me.Picture1.Left = 0.07322846!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.Picture1.Top = 0.08259517!
        Me.Picture1.Width = 1.135039!
        '
        'lblDireccion
        '
        Me.lblDireccion.Height = 0.5582678!
        Me.lblDireccion.HyperLink = Nothing
        Me.lblDireccion.Left = 1.281496!
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Style = ""
        Me.lblDireccion.Text = "lblDireccion"
        Me.lblDireccion.Top = 0.2825952!
        Me.lblDireccion.Width = 3.803543!
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape1.Height = 0.5728347!
        Me.Shape1.Left = 0.2811024!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape1.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape1.Top = 0.9590552!
        Me.Shape1.Width = 6.904331!
        '
        'lblTitulo
        '
        Me.lblTitulo.Height = 0.2!
        Me.lblTitulo.HyperLink = Nothing
        Me.lblTitulo.Left = 0.6200788!
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Style = "font-size: 14pt; font-weight: bold; text-align: center; ddo-char-set: 1"
        Me.lblTitulo.Text = "RESUMEN DE ORDENES DE PAGO"
        Me.lblTitulo.Top = 1.04252!
        Me.lblTitulo.Width = 6.208662!
        '
        'lblFecha
        '
        Me.lblFecha.Height = 0.2!
        Me.lblFecha.HyperLink = Nothing
        Me.lblFecha.Left = 1.620079!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "font-size: 10pt; text-align: center; ddo-char-set: 1"
        Me.lblFecha.Text = ""
        Me.lblFecha.Top = 1.24252!
        Me.lblFecha.Width = 4.405906!
        '
        'lblJoseGuma
        '
        Me.lblJoseGuma.Height = 0.2!
        Me.lblJoseGuma.HyperLink = Nothing
        Me.lblJoseGuma.Left = 1.281496!
        Me.lblJoseGuma.Name = "lblJoseGuma"
        Me.lblJoseGuma.Style = "font-size: 12pt; font-weight: bold"
        Me.lblJoseGuma.Text = "José Guma S.A."
        Me.lblJoseGuma.Top = 0.08259517!
        Me.lblJoseGuma.Width = 1.416535!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape3, Me.lblTotales, Me.txtTotalGeneral})
        Me.ReportFooter1.Height = 0.3435858!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'Shape3
        '
        Me.Shape3.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape3.Height = 0.3149606!
        Me.Shape3.Left = 4.789764!
        Me.Shape3.Name = "Shape3"
        Me.Shape3.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape3.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape3.Top = 0!
        Me.Shape3.Width = 2.395669!
        '
        'lblTotales
        '
        Me.lblTotales.Height = 0.2!
        Me.lblTotales.HyperLink = Nothing
        Me.lblTotales.Left = 4.934647!
        Me.lblTotales.Name = "lblTotales"
        Me.lblTotales.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblTotales.Text = "Total"
        Me.lblTotales.Top = 0.05236221!
        Me.lblTotales.Width = 0.6874018!
        '
        'txtTotalGeneral
        '
        Me.txtTotalGeneral.DataField = "TotalPagado"
        Me.txtTotalGeneral.Height = 0.2!
        Me.txtTotalGeneral.Left = 5.789764!
        Me.txtTotalGeneral.Name = "txtTotalGeneral"
        Me.txtTotalGeneral.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtTotalGeneral.Text = "total"
        Me.txtTotalGeneral.Top = 0.05236221!
        Me.txtTotalGeneral.Width = 1.301969!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.TextBox3, Me.txtCodTipo, Me.txtCodCuenta})
        Me.GroupHeader1.DataField = "TipoProveedor"
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'TextBox3
        '
        Me.TextBox3.Height = 0.2!
        Me.TextBox3.Left = 0.4531496!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "color: Blue; font-size: 9.75pt; font-weight: bold"
        Me.TextBox3.Text = "Tipo"
        Me.TextBox3.Top = 0!
        Me.TextBox3.Width = 1.0!
        '
        'txtCodTipo
        '
        Me.txtCodTipo.DataField = "codTipoProveedor"
        Me.txtCodTipo.Height = 0.2!
        Me.txtCodTipo.Left = 1.541339!
        Me.txtCodTipo.Name = "txtCodTipo"
        Me.txtCodTipo.Style = "color: Blue"
        Me.txtCodTipo.Text = "codtipo"
        Me.txtCodTipo.Top = 0!
        Me.txtCodTipo.Width = 1.0!
        '
        'txtCodCuenta
        '
        Me.txtCodCuenta.DataField = "TipoProveedor"
        Me.txtCodCuenta.Height = 0.2!
        Me.txtCodCuenta.Left = 2.698032!
        Me.txtCodCuenta.Name = "txtCodCuenta"
        Me.txtCodCuenta.Style = "color: Blue"
        Me.txtCodCuenta.Text = "codcuenta"
        Me.txtCodCuenta.Top = 0!
        Me.txtCodCuenta.Width = 3.745276!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblTipo, Me.txtTotalCuenta, Me.Line2, Me.Line3})
        Me.GroupFooter1.Height = 0.21875!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'lblTipo
        '
        Me.lblTipo.Height = 0.2!
        Me.lblTipo.HyperLink = Nothing
        Me.lblTipo.Left = 4.601575!
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Style = "color: Blue; font-size: 9.75pt; font-weight: bold"
        Me.lblTipo.Text = "Total TIPO:"
        Me.lblTipo.Top = 0!
        Me.lblTipo.Width = 1.205905!
        '
        'txtTotalCuenta
        '
        Me.txtTotalCuenta.CurrencyCulture = New System.Globalization.CultureInfo("es-MX")
        Me.txtTotalCuenta.DataField = "TotalPagado"
        Me.txtTotalCuenta.Height = 0.2!
        Me.txtTotalCuenta.Left = 5.807481!
        Me.txtTotalCuenta.Name = "txtTotalCuenta"
        Me.txtTotalCuenta.OutputFormat = resources.GetString("txtTotalCuenta.OutputFormat")
        Me.txtTotalCuenta.Style = "color: Blue; text-align: right"
        Me.txtTotalCuenta.SummaryGroup = "GroupHeader1"
        Me.txtTotalCuenta.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.txtTotalCuenta.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal
        Me.txtTotalCuenta.Text = "totalpagado"
        Me.txtTotalCuenta.Top = 0!
        Me.txtTotalCuenta.Width = 1.284252!
        '
        'Line2
        '
        Me.Line2.Height = 0!
        Me.Line2.Left = 0.07846051!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.209375!
        Me.Line2.Width = 7.603938!
        Me.Line2.X1 = 0.07846051!
        Me.Line2.X2 = 7.682399!
        Me.Line2.Y1 = 0.209375!
        Me.Line2.Y2 = 0.209375!
        '
        'Line3
        '
        Me.Line3.Height = 0!
        Me.Line3.Left = 0.07806683!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.009374999!
        Me.Line3.Width = 7.604332!
        Me.Line3.X1 = 0.07806683!
        Me.Line3.X2 = 7.682399!
        Me.Line3.Y1 = 0.009374999!
        Me.Line3.Y2 = 0.009374999!
        '
        'GroupHeader2
        '
        Me.GroupHeader2.DataField = "codproveedor"
        Me.GroupHeader2.Height = 0!
        Me.GroupHeader2.Name = "GroupHeader2"
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Height = 0!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'RptImpresoResumenOP
        '
        Me.MasterReport = False
        Me.CompatibilityMode = GrapeCity.ActiveReports.Document.CompatibilityModes.CrossPlatform
        Me.PageSettings.Margins.Bottom = 0.3937008!
        Me.PageSettings.Margins.Left = 0.3937008!
        Me.PageSettings.Margins.Right = 0.3937008!
        Me.PageSettings.Margins.Top = 0.3937008!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.260466!
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
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodInsumo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private WithEvents ReportHeader1 As GrapeCity.ActiveReports.SectionReportModel.ReportHeader
    Private WithEvents ReportFooter1 As GrapeCity.ActiveReports.SectionReportModel.ReportFooter
    Private WithEvents GroupHeader1 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GroupFooter1 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents Picture1 As GrapeCity.ActiveReports.SectionReportModel.Picture
    Private WithEvents lblDireccion As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape1 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblTitulo As GrapeCity.ActiveReports.SectionReportModel.Label
    Public WithEvents lblFecha As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblJoseGuma As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblPage As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtPage As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label3 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblPie As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox8 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Shape2 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents TextBox1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox2 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox3 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtCodTipo As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtCodCuenta As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtCodInsumo As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtDescripcion As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtImporte As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Shape3 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblTotales As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtTotalGeneral As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lblTipo As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtTotalCuenta As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Line1 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line2 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line3 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents GroupHeader2 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GroupFooter2 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
End Class
