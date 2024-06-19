<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class RptImpresoAsientoCompras
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptImpresoAsientoCompras))
        Me.PageHeader = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.Shape2 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblInsumo = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblDescripcion = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblTotal = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.txtCodInsumo = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtDescripcion = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotal = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.PageFooter = New GrapeCity.ActiveReports.SectionReportModel.PageFooter()
        Me.lblPie = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblPage = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtPage = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label3 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox8 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.ReportHeader1 = New GrapeCity.ActiveReports.SectionReportModel.ReportHeader()
        Me.lblJoseGuma = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblDireccion = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Shape1 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Label1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Picture1 = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.txtTipoComp = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblTipoComp = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.ReportFooter1 = New GrapeCity.ActiveReports.SectionReportModel.ReportFooter()
        Me.Shape3 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblTotalGral = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtTotalGeneral = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Shape4 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblTotalIVA = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtTotalIVA = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Shape5 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblTotalPerIVA = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtTotalPerIVA = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Shape6 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblTotalPerIB = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtTotalPerIB = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Shape7 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblTotalPerGan = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtTotalPerGan = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupHeader1 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.Label4 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtCodCuenta = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtDV = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupFooter1 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.txtTotalCuenta = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label5 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        CType(Me.lblInsumo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodInsumo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTipoComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalGral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalIVA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalIVA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalPerIVA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPerIVA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalPerIB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPerIB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalPerGan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPerGan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape2, Me.lblInsumo, Me.lblDescripcion, Me.lblTotal})
        Me.PageHeader.Name = "PageHeader"
        '
        'Shape2
        '
        Me.Shape2.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape2.Height = 0.1968504!
        Me.Shape2.Left = 0.5591125!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape2.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape2.Top = 0.02047245!
        Me.Shape2.Width = 5.933858!
        '
        'lblInsumo
        '
        Me.lblInsumo.Height = 0.1574803!
        Me.lblInsumo.HyperLink = Nothing
        Me.lblInsumo.Left = 0.7850959!
        Me.lblInsumo.Name = "lblInsumo"
        Me.lblInsumo.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1"
        Me.lblInsumo.Text = "Insumo"
        Me.lblInsumo.Top = 0.07204726!
        Me.lblInsumo.Width = 1.0!
        '
        'lblDescripcion
        '
        Me.lblDescripcion.Height = 0.1574803!
        Me.lblDescripcion.HyperLink = Nothing
        Me.lblDescripcion.Left = 2.446851!
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1"
        Me.lblDescripcion.Text = "Descripción"
        Me.lblDescripcion.Top = 0.05590552!
        Me.lblDescripcion.Width = 0.958268!
        '
        'lblTotal
        '
        Me.lblTotal.Height = 0.1574803!
        Me.lblTotal.HyperLink = Nothing
        Me.lblTotal.Left = 5.859507!
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1"
        Me.lblTotal.Text = "Total"
        Me.lblTotal.Top = 0.05590552!
        Me.lblTotal.Width = 0.3653543!
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txtCodInsumo, Me.txtDescripcion, Me.txtTotal})
        Me.Detail.Height = 0.21875!
        Me.Detail.Name = "Detail"
        '
        'txtCodInsumo
        '
        Me.txtCodInsumo.DataField = "CodInsumo"
        Me.txtCodInsumo.Height = 0.1574803!
        Me.txtCodInsumo.Left = 0.5929134!
        Me.txtCodInsumo.Name = "txtCodInsumo"
        Me.txtCodInsumo.OutputFormat = resources.GetString("txtCodInsumo.OutputFormat")
        Me.txtCodInsumo.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtCodInsumo.Text = "4.01.001.001.0001"
        Me.txtCodInsumo.Top = 0!
        Me.txtCodInsumo.Width = 1.240157!
        '
        'txtDescripcion
        '
        Me.txtDescripcion.DataField = "Descripcion"
        Me.txtDescripcion.Height = 0.1574803!
        Me.txtDescripcion.Left = 2.028347!
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtDescripcion.Text = "descripcion"
        Me.txtDescripcion.Top = 0!
        Me.txtDescripcion.Width = 2.72441!
        '
        'txtTotal
        '
        Me.txtTotal.DataField = "totales"
        Me.txtTotal.Height = 0.2!
        Me.txtTotal.Left = 5.432284!
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Style = "font-size: 7.5pt; text-align: right; ddo-char-set: 1"
        Me.txtTotal.Text = "totales"
        Me.txtTotal.Top = 0!
        Me.txtTotal.Width = 0.791732!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblPie, Me.lblPage, Me.txtPage, Me.Label3, Me.TextBox8})
        Me.PageFooter.Height = 0.2395833!
        Me.PageFooter.Name = "PageFooter"
        '
        'lblPie
        '
        Me.lblPie.Height = 0.2!
        Me.lblPie.HyperLink = Nothing
        Me.lblPie.Left = 0.3169292!
        Me.lblPie.Name = "lblPie"
        Me.lblPie.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.lblPie.Text = "pie"
        Me.lblPie.Top = 0!
        Me.lblPie.Width = 1.917323!
        '
        'lblPage
        '
        Me.lblPage.Height = 0.2!
        Me.lblPage.HyperLink = Nothing
        Me.lblPage.Left = 4.619685!
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.lblPage.Text = "Página"
        Me.lblPage.Top = 0!
        Me.lblPage.Width = 0.5838585!
        '
        'txtPage
        '
        Me.txtPage.Height = 0.2!
        Me.txtPage.Left = 5.359449!
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
        Me.Label3.Left = 5.807874!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.Label3.Text = "De"
        Me.Label3.Top = 0!
        Me.Label3.Width = 0.3125985!
        '
        'TextBox8
        '
        Me.TextBox8.Height = 0.2!
        Me.TextBox8.Left = 6.224016!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.TextBox8.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.TextBox8.Text = "##"
        Me.TextBox8.Top = 0!
        Me.TextBox8.Width = 0.3027558!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblJoseGuma, Me.lblDireccion, Me.Shape1, Me.Label1, Me.Picture1, Me.txtTipoComp, Me.lblTipoComp})
        Me.ReportHeader1.Height = 1.435367!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'lblJoseGuma
        '
        Me.lblJoseGuma.Height = 0.2!
        Me.lblJoseGuma.HyperLink = Nothing
        Me.lblJoseGuma.Left = 1.310236!
        Me.lblJoseGuma.Name = "lblJoseGuma"
        Me.lblJoseGuma.Style = "font-size: 12pt; font-weight: bold"
        Me.lblJoseGuma.Text = "José Guma S.A."
        Me.lblJoseGuma.Top = 0!
        Me.lblJoseGuma.Width = 1.416535!
        '
        'lblDireccion
        '
        Me.lblDireccion.Height = 0.5228345!
        Me.lblDireccion.HyperLink = Nothing
        Me.lblDireccion.Left = 1.293306!
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.lblDireccion.Text = "lblDireccion"
        Me.lblDireccion.Top = 0.2354331!
        Me.lblDireccion.Width = 2.891732!
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape1.Height = 0.5834646!
        Me.Shape1.Left = 0.5929134!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape1.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape1.Top = 0.8102359!
        Me.Shape1.Width = 5.933859!
        '
        'Label1
        '
        Me.Label1.Height = 0.2622047!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 2.028347!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-size: 12pt; font-weight: bold; text-align: center; ddo-char-set: 1"
        Me.Label1.Text = "Asiento de Compras del Mes de "
        Me.Label1.Top = 0.8622048!
        Me.Label1.Width = 3.125197!
        '
        'Picture1
        '
        Me.Picture1.Height = 0.7582681!
        Me.Picture1.HyperLink = Nothing
        Me.Picture1.ImageBytes = CType(resources.GetObject("Picture1.ImageBytes"), Byte())
        Me.Picture1.Left = 0.06929135!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.Picture1.Top = 0!
        Me.Picture1.Width = 1.135039!
        '
        'txtTipoComp
        '
        Me.txtTipoComp.Height = 0.2!
        Me.txtTipoComp.HyperLink = Nothing
        Me.txtTipoComp.Left = 2.704331!
        Me.txtTipoComp.Name = "txtTipoComp"
        Me.txtTipoComp.Style = "font-size: 10pt; font-weight: bold; text-align: left; ddo-char-set: 1"
        Me.txtTipoComp.Text = ""
        Me.txtTipoComp.Top = 1.12441!
        Me.txtTipoComp.Width = 2.957874!
        '
        'lblTipoComp
        '
        Me.lblTipoComp.Height = 0.1999999!
        Me.lblTipoComp.HyperLink = Nothing
        Me.lblTipoComp.Left = 1.293307!
        Me.lblTipoComp.Name = "lblTipoComp"
        Me.lblTipoComp.Style = "font-size: 10pt; font-weight: bold; text-align: left; ddo-char-set: 1"
        Me.lblTipoComp.Text = "Tipo Comprobante:"
        Me.lblTipoComp.Top = 1.12441!
        Me.lblTipoComp.Width = 1.311811!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape3, Me.lblTotalGral, Me.txtTotalGeneral, Me.Shape4, Me.lblTotalIVA, Me.txtTotalIVA, Me.Shape5, Me.lblTotalPerIVA, Me.txtTotalPerIVA, Me.Shape6, Me.lblTotalPerIB, Me.txtTotalPerIB, Me.Shape7, Me.lblTotalPerGan, Me.txtTotalPerGan})
        Me.ReportFooter1.Height = 1.606627!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'Shape3
        '
        Me.Shape3.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape3.Height = 0.3149606!
        Me.Shape3.Left = 4.057481!
        Me.Shape3.Name = "Shape3"
        Me.Shape3.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape3.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape3.Top = 0!
        Me.Shape3.Width = 2.395669!
        '
        'lblTotalGral
        '
        Me.lblTotalGral.Height = 0.2!
        Me.lblTotalGral.HyperLink = Nothing
        Me.lblTotalGral.Left = 4.202363!
        Me.lblTotalGral.Name = "lblTotalGral"
        Me.lblTotalGral.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblTotalGral.Text = "Total"
        Me.lblTotalGral.Top = 0.05236221!
        Me.lblTotalGral.Width = 0.6874021!
        '
        'txtTotalGeneral
        '
        Me.txtTotalGeneral.DataField = "totales"
        Me.txtTotalGeneral.Height = 0.2!
        Me.txtTotalGeneral.Left = 5.057481!
        Me.txtTotalGeneral.Name = "txtTotalGeneral"
        Me.txtTotalGeneral.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtTotalGeneral.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All
        Me.txtTotalGeneral.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal
        Me.txtTotalGeneral.Text = "total general"
        Me.txtTotalGeneral.Top = 0.05236221!
        Me.txtTotalGeneral.Width = 1.30197!
        '
        'Shape4
        '
        Me.Shape4.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape4.Height = 0.3149606!
        Me.Shape4.Left = 0.06929064!
        Me.Shape4.Name = "Shape4"
        Me.Shape4.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape4.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape4.Top = 0!
        Me.Shape4.Width = 3.072836!
        '
        'lblTotalIVA
        '
        Me.lblTotalIVA.Height = 0.2!
        Me.lblTotalIVA.HyperLink = Nothing
        Me.lblTotalIVA.Left = 0.2141733!
        Me.lblTotalIVA.Name = "lblTotalIVA"
        Me.lblTotalIVA.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblTotalIVA.Text = "Total I.V.A :"
        Me.lblTotalIVA.Top = 0.05236221!
        Me.lblTotalIVA.Width = 0.9165354!
        '
        'txtTotalIVA
        '
        Me.txtTotalIVA.DataField = "totaliva"
        Me.txtTotalIVA.Height = 0.2!
        Me.txtTotalIVA.Left = 1.895669!
        Me.txtTotalIVA.Name = "txtTotalIVA"
        Me.txtTotalIVA.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtTotalIVA.Text = "total general"
        Me.txtTotalIVA.Top = 0.05236221!
        Me.txtTotalIVA.Width = 1.16693!
        '
        'Shape5
        '
        Me.Shape5.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape5.Height = 0.3149606!
        Me.Shape5.Left = 0.059448!
        Me.Shape5.Name = "Shape5"
        Me.Shape5.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape5.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape5.Top = 0.4165355!
        Me.Shape5.Width = 3.082678!
        '
        'lblTotalPerIVA
        '
        Me.lblTotalPerIVA.Height = 0.2!
        Me.lblTotalPerIVA.HyperLink = Nothing
        Me.lblTotalPerIVA.Left = 0.1759843!
        Me.lblTotalPerIVA.Name = "lblTotalPerIVA"
        Me.lblTotalPerIVA.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblTotalPerIVA.Text = "Total Per. I.V.A.:"
        Me.lblTotalPerIVA.Top = 0.4688977!
        Me.lblTotalPerIVA.Width = 1.249606!
        '
        'txtTotalPerIVA
        '
        Me.txtTotalPerIVA.DataField = "totalperiva"
        Me.txtTotalPerIVA.Height = 0.2!
        Me.txtTotalPerIVA.Left = 1.905512!
        Me.txtTotalPerIVA.Name = "txtTotalPerIVA"
        Me.txtTotalPerIVA.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtTotalPerIVA.Text = "total general"
        Me.txtTotalPerIVA.Top = 0.4688977!
        Me.txtTotalPerIVA.Width = 1.157087!
        '
        'Shape6
        '
        Me.Shape6.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape6.Height = 0.3149606!
        Me.Shape6.Left = 0.05944872!
        Me.Shape6.Name = "Shape6"
        Me.Shape6.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape6.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape6.Top = 0.8019686!
        Me.Shape6.Width = 3.082678!
        '
        'lblTotalPerIB
        '
        Me.lblTotalPerIB.Height = 0.2!
        Me.lblTotalPerIB.HyperLink = Nothing
        Me.lblTotalPerIB.Left = 0.2043314!
        Me.lblTotalPerIB.Name = "lblTotalPerIB"
        Me.lblTotalPerIB.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblTotalPerIB.Text = "Total Per. I.B. :"
        Me.lblTotalPerIB.Top = 0.8543308!
        Me.lblTotalPerIB.Width = 1.159055!
        '
        'txtTotalPerIB
        '
        Me.txtTotalPerIB.DataField = "totalperib"
        Me.txtTotalPerIB.Height = 0.2!
        Me.txtTotalPerIB.Left = 1.895669!
        Me.txtTotalPerIB.Name = "txtTotalPerIB"
        Me.txtTotalPerIB.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtTotalPerIB.Text = "total general"
        Me.txtTotalPerIB.Top = 0.8543308!
        Me.txtTotalPerIB.Width = 1.157088!
        '
        'Shape7
        '
        Me.Shape7.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape7.Height = 0.3149606!
        Me.Shape7.Left = 0.03110242!
        Me.Shape7.Name = "Shape7"
        Me.Shape7.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape7.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape7.Top = 1.229134!
        Me.Shape7.Width = 3.111024!
        '
        'lblTotalPerGan
        '
        Me.lblTotalPerGan.Height = 0.2!
        Me.lblTotalPerGan.HyperLink = Nothing
        Me.lblTotalPerGan.Left = 0.1759851!
        Me.lblTotalPerGan.Name = "lblTotalPerGan"
        Me.lblTotalPerGan.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblTotalPerGan.Text = "Total Per. Gan.:"
        Me.lblTotalPerGan.Top = 1.281496!
        Me.lblTotalPerGan.Width = 1.134251!
        '
        'txtTotalPerGan
        '
        Me.txtTotalPerGan.DataField = "totalpergan"
        Me.txtTotalPerGan.Height = 0.2!
        Me.txtTotalPerGan.Left = 1.952362!
        Me.txtTotalPerGan.Name = "txtTotalPerGan"
        Me.txtTotalPerGan.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtTotalPerGan.Text = "total general"
        Me.txtTotalPerGan.Top = 1.281496!
        Me.txtTotalPerGan.Width = 1.128742!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Label4, Me.txtCodCuenta, Me.txtDV})
        Me.GroupHeader1.DataField = "codcuenta"
        Me.GroupHeader1.Height = 0.21875!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'Label4
        '
        Me.Label4.Height = 0.2!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.2043307!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "color: Blue; font-size: 9.75pt; font-weight: bold; ddo-char-set: 1"
        Me.Label4.Text = "Cuenta"
        Me.Label4.Top = 3.72529E-9!
        Me.Label4.Width = 0.5807087!
        '
        'txtCodCuenta
        '
        Me.txtCodCuenta.DataField = "codcuenta"
        Me.txtCodCuenta.Height = 0.2!
        Me.txtCodCuenta.Left = 0.8956693!
        Me.txtCodCuenta.Name = "txtCodCuenta"
        Me.txtCodCuenta.Style = "color: Blue; font-size: 9.75pt; font-weight: bold"
        Me.txtCodCuenta.Text = "codcuenta"
        Me.txtCodCuenta.Top = 0!
        Me.txtCodCuenta.Width = 1.132677!
        '
        'txtDV
        '
        Me.txtDV.DataField = "dv"
        Me.txtDV.Height = 0.2!
        Me.txtDV.Left = 1.579134!
        Me.txtDV.Name = "txtDV"
        Me.txtDV.Style = "color: Blue; font-size: 9.75pt; font-weight: bold"
        Me.txtDV.Text = "dv"
        Me.txtDV.Top = 0!
        Me.txtDV.Width = 0.253937!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txtTotalCuenta, Me.Label5})
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.NewColumn = GrapeCity.ActiveReports.SectionReportModel.NewColumn.Before
        '
        'txtTotalCuenta
        '
        Me.txtTotalCuenta.DataField = "totales"
        Me.txtTotalCuenta.Height = 0.2!
        Me.txtTotalCuenta.Left = 5.359449!
        Me.txtTotalCuenta.Name = "txtTotalCuenta"
        Me.txtTotalCuenta.Style = "color: Blue; font-size: 9.75pt; font-weight: bold; text-align: right"
        Me.txtTotalCuenta.SummaryGroup = "GroupHeader1"
        Me.txtTotalCuenta.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.txtTotalCuenta.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal
        Me.txtTotalCuenta.Text = "totalcuenta"
        Me.txtTotalCuenta.Top = 0!
        Me.txtTotalCuenta.Width = 1.0!
        '
        'Label5
        '
        Me.Label5.Height = 0.1574803!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 4.572835!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "color: Blue; font-size: 9.75pt; font-weight: bold; ddo-char-set: 1"
        Me.Label5.Text = "Total cuenta:"
        Me.Label5.Top = 0.04251969!
        Me.Label5.Width = 0.5807087!
        '
        'RptImpresoAsientoCompras
        '
        Me.MasterReport = False
        Me.CompatibilityMode = GrapeCity.ActiveReports.Document.CompatibilityModes.CrossPlatform
        Me.PageSettings.Margins.Bottom = 0.3937008!
        Me.PageSettings.Margins.Left = 0.3937008!
        Me.PageSettings.Margins.Right = 0.3937008!
        Me.PageSettings.Margins.Top = 0.3937008!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 6.770833!
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
        CType(Me.lblInsumo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodInsumo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTipoComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalGral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalIVA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalIVA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalPerIVA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPerIVA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalPerIB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPerIB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalPerGan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPerGan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private WithEvents ReportHeader1 As GrapeCity.ActiveReports.SectionReportModel.ReportHeader
    Private WithEvents ReportFooter1 As GrapeCity.ActiveReports.SectionReportModel.ReportFooter
    Private WithEvents lblJoseGuma As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblDireccion As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape1 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Label1 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Picture1 As GrapeCity.ActiveReports.SectionReportModel.Picture
    Public WithEvents txtTipoComp As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents GroupHeader1 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GroupFooter1 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents lblPie As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblPage As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtPage As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label3 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox8 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Shape2 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblInsumo As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblDescripcion As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblTotal As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label4 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtCodCuenta As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtCodInsumo As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtDescripcion As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotal As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalCuenta As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label5 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape3 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblTotalGral As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtTotalGeneral As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Public WithEvents lblTipoComp As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape4 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblTotalIVA As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtTotalIVA As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Shape5 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents txtTotalPerIVA As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Shape6 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents txtTotalPerIB As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Shape7 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents txtTotalPerGan As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lblTotalPerIVA As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblTotalPerIB As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblTotalPerGan As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtDV As GrapeCity.ActiveReports.SectionReportModel.TextBox
End Class
