<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class RptImpresoInsumosComprados
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptImpresoInsumosComprados))
        Me.PageHeader = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.Shape2 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblFechaHeader = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblCantidad = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblPrecio = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblTotal = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label3 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.txtFechaComp = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtGroup = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtCantidad = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPrecio = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotal = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.PageFooter = New GrapeCity.ActiveReports.SectionReportModel.PageFooter()
        Me.lblPage = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtPage = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label2 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.lblPie = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.ReportHeader1 = New GrapeCity.ActiveReports.SectionReportModel.ReportHeader()
        Me.Picture1 = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.lblDireccion = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblJoseGuma = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Shape1 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Label1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblFecha = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.ReportFooter1 = New GrapeCity.ActiveReports.SectionReportModel.ReportFooter()
        Me.lblTotalGeneral = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtTotalGeneral = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupHeader1 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.Label4 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtDescRubro = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupFooter1 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.lblGroup1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtTotalGroup1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupHeader2 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.Label5 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtDescSubRubro = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupFooter2 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.lblGroup2 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtTotalGroup2 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        CType(Me.lblFechaHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescRubro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescSubRubro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape2, Me.lblFechaHeader, Me.lblCantidad, Me.lblPrecio, Me.lblTotal, Me.Label3})
        Me.PageHeader.Name = "PageHeader"
        '
        'Shape2
        '
        Me.Shape2.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape2.Height = 0.1968504!
        Me.Shape2.Left = 0.403937!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape2.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape2.Top = 0.02047244!
        Me.Shape2.Width = 6.173623!
        '
        'lblFechaHeader
        '
        Me.lblFechaHeader.Height = 0.1574803!
        Me.lblFechaHeader.HyperLink = Nothing
        Me.lblFechaHeader.Left = 0.7236223!
        Me.lblFechaHeader.Name = "lblFechaHeader"
        Me.lblFechaHeader.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1"
        Me.lblFechaHeader.Text = "Fecha"
        Me.lblFechaHeader.Top = 0.07204724!
        Me.lblFechaHeader.Width = 0.522442!
        '
        'lblCantidad
        '
        Me.lblCantidad.Height = 0.1574803!
        Me.lblCantidad.HyperLink = Nothing
        Me.lblCantidad.Left = 4.316929!
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1"
        Me.lblCantidad.Text = "Cantidad"
        Me.lblCantidad.Top = 0.05590552!
        Me.lblCantidad.Width = 0.5736224!
        '
        'lblPrecio
        '
        Me.lblPrecio.Height = 0.1574803!
        Me.lblPrecio.HyperLink = Nothing
        Me.lblPrecio.Left = 5.197245!
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1"
        Me.lblPrecio.Text = "Precio"
        Me.lblPrecio.Top = 0.05590552!
        Me.lblPrecio.Width = 0.4299212!
        '
        'lblTotal
        '
        Me.lblTotal.Height = 0.1574803!
        Me.lblTotal.HyperLink = Nothing
        Me.lblTotal.Left = 6.083858!
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1"
        Me.lblTotal.Text = "Total"
        Me.lblTotal.Top = 0.05590552!
        Me.lblTotal.Width = 0.3653543!
        '
        'Label3
        '
        Me.Label3.Height = 0.1574803!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 2.167716!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1"
        Me.Label3.Text = "Insumo"
        Me.Label3.Top = 0.07204723!
        Me.Label3.Width = 1.0!
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txtFechaComp, Me.txtGroup, Me.txtCantidad, Me.txtPrecio, Me.txtTotal})
        Me.Detail.Height = 0.2083334!
        Me.Detail.Name = "Detail"
        '
        'txtFechaComp
        '
        Me.txtFechaComp.DataField = "fechacomp"
        Me.txtFechaComp.Height = 0.2!
        Me.txtFechaComp.Left = 0.403937!
        Me.txtFechaComp.Name = "txtFechaComp"
        Me.txtFechaComp.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtFechaComp.Text = "fechacomp"
        Me.txtFechaComp.Top = 0!
        Me.txtFechaComp.Width = 0.5937008!
        '
        'txtGroup
        '
        Me.txtGroup.CanGrow = False
        Me.txtGroup.DataField = "descinsumo"
        Me.txtGroup.Height = 0.1574803!
        Me.txtGroup.Left = 1.085827!
        Me.txtGroup.Name = "txtGroup"
        Me.txtGroup.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtGroup.Text = "desc insumo"
        Me.txtGroup.Top = 0!
        Me.txtGroup.Width = 3.137402!
        '
        'txtCantidad
        '
        Me.txtCantidad.DataField = "cantidad"
        Me.txtCantidad.Height = 0.2!
        Me.txtCantidad.Left = 4.161417!
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtCantidad.Text = "cantidad"
        Me.txtCantidad.Top = 0!
        Me.txtCantidad.Width = 0.5937008!
        '
        'txtPrecio
        '
        Me.txtPrecio.DataField = "precio"
        Me.txtPrecio.Height = 0.2!
        Me.txtPrecio.Left = 4.890552!
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtPrecio.Text = "precio"
        Me.txtPrecio.Top = 0!
        Me.txtPrecio.Width = 0.6665353!
        '
        'txtTotal
        '
        Me.txtTotal.DataField = "total"
        Me.txtTotal.Height = 0.2!
        Me.txtTotal.Left = 5.627166!
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtTotal.Text = "total"
        Me.txtTotal.Top = 0!
        Me.txtTotal.Width = 0.8397636!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblPage, Me.txtPage, Me.Label2, Me.TextBox1, Me.lblPie})
        Me.PageFooter.Height = 0.2042487!
        Me.PageFooter.Name = "PageFooter"
        '
        'lblPage
        '
        Me.lblPage.Height = 0.2!
        Me.lblPage.HyperLink = Nothing
        Me.lblPage.Left = 5.043307!
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Style = ""
        Me.lblPage.Text = "Página"
        Me.lblPage.Top = 0!
        Me.lblPage.Width = 0.5838585!
        '
        'txtPage
        '
        Me.txtPage.Height = 0.2!
        Me.txtPage.Left = 5.68937!
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
        Me.Label2.Left = 5.992126!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = ""
        Me.Label2.Text = "de"
        Me.Label2.Top = 0!
        Me.Label2.Width = 0.2551181!
        '
        'TextBox1
        '
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 6.462992!
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
        Me.lblPie.Left = 0.234252!
        Me.lblPie.Name = "lblPie"
        Me.lblPie.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.lblPie.Text = "pie"
        Me.lblPie.Top = 0!
        Me.lblPie.Width = 3.062599!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Picture1, Me.lblDireccion, Me.lblJoseGuma, Me.Shape1, Me.Label1, Me.lblFecha})
        Me.ReportHeader1.Height = 1.520833!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'Picture1
        '
        Me.Picture1.Height = 0.7582681!
        Me.Picture1.HyperLink = Nothing
        Me.Picture1.ImageBytes = CType(resources.GetObject("Picture1.ImageBytes"), Byte())
        Me.Picture1.Left = 0.1464567!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.Picture1.Top = 0.05708662!
        Me.Picture1.Width = 1.135039!
        '
        'lblDireccion
        '
        Me.lblDireccion.Height = 0.4917323!
        Me.lblDireccion.HyperLink = Nothing
        Me.lblDireccion.Left = 1.375196!
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Style = "font-size: 8pt; text-align: left; ddo-char-set: 1"
        Me.lblDireccion.Text = "lblDireccion"
        Me.lblDireccion.Top = 0.2570866!
        Me.lblDireccion.Width = 2.854331!
        '
        'lblJoseGuma
        '
        Me.lblJoseGuma.Height = 0.2!
        Me.lblJoseGuma.HyperLink = Nothing
        Me.lblJoseGuma.Left = 1.375196!
        Me.lblJoseGuma.Name = "lblJoseGuma"
        Me.lblJoseGuma.Style = "font-size: 12pt; font-weight: bold"
        Me.lblJoseGuma.Text = "José Guma S.A."
        Me.lblJoseGuma.Top = 0.05708662!
        Me.lblJoseGuma.Width = 1.416535!
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape1.Height = 0.5856301!
        Me.Shape1.Left = 0.4279535!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape1.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape1.Top = 0.8779534!
        Me.Shape1.Width = 6.02126!
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.8043308!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-size: 12pt; font-weight: bold; text-align: center"
        Me.Label1.Text = "Listado de Insumos Comprados"
        Me.Label1.Top = 0.9562993!
        Me.Label1.Width = 5.322442!
        '
        'lblFecha
        '
        Me.lblFecha.Height = 0.2!
        Me.lblFecha.Left = 1.085631!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "text-align: center"
        Me.lblFecha.Text = Nothing
        Me.lblFecha.Top = 1.208465!
        Me.lblFecha.Width = 4.68504!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblTotalGeneral, Me.txtTotalGeneral})
        Me.ReportFooter1.Height = 0.2187501!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'lblTotalGeneral
        '
        Me.lblTotalGeneral.Height = 0.2!
        Me.lblTotalGeneral.HyperLink = Nothing
        Me.lblTotalGeneral.Left = 2.902362!
        Me.lblTotalGeneral.Name = "lblTotalGeneral"
        Me.lblTotalGeneral.Style = "background-color: GreenYellow; font-size: 9.75pt; font-weight: bold"
        Me.lblTotalGeneral.Text = "TOTAL GENERAL"
        Me.lblTotalGeneral.Top = 0!
        Me.lblTotalGeneral.Width = 3.675197!
        '
        'txtTotalGeneral
        '
        Me.txtTotalGeneral.DataField = "total"
        Me.txtTotalGeneral.Height = 0.2!
        Me.txtTotalGeneral.Left = 5.035039!
        Me.txtTotalGeneral.Name = "txtTotalGeneral"
        Me.txtTotalGeneral.Style = "font-size: 9.75pt; font-weight: bold; text-align: right"
        Me.txtTotalGeneral.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All
        Me.txtTotalGeneral.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal
        Me.txtTotalGeneral.Text = "total"
        Me.txtTotalGeneral.Top = 0!
        Me.txtTotalGeneral.Width = 1.302362!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.BackColor = System.Drawing.Color.White
        Me.GroupHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Label4, Me.txtDescRubro})
        Me.GroupHeader1.DataField = "codrubro"
        Me.GroupHeader1.Height = 0.2291667!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'Label4
        '
        Me.Label4.Height = 0.2!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.1948819!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.Label4.Text = "Rubro"
        Me.Label4.Top = 0!
        Me.Label4.Width = 0.522442!
        '
        'txtDescRubro
        '
        Me.txtDescRubro.DataField = "descrubro"
        Me.txtDescRubro.Height = 0.2!
        Me.txtDescRubro.Left = 0.9165356!
        Me.txtDescRubro.Name = "txtDescRubro"
        Me.txtDescRubro.Text = "descrubro"
        Me.txtDescRubro.Top = 0!
        Me.txtDescRubro.Width = 3.312992!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.BackColor = System.Drawing.Color.White
        Me.GroupFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblGroup1, Me.txtTotalGroup1})
        Me.GroupFooter1.Height = 0.21875!
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.NewColumn = GrapeCity.ActiveReports.SectionReportModel.NewColumn.Before
        '
        'lblGroup1
        '
        Me.lblGroup1.Height = 0.2!
        Me.lblGroup1.HyperLink = Nothing
        Me.lblGroup1.Left = 0.5330709!
        Me.lblGroup1.Name = "lblGroup1"
        Me.lblGroup1.Style = "background-color: #D0F288"
        Me.lblGroup1.Text = "lblGrupHeader1"
        Me.lblGroup1.Top = 0!
        Me.lblGroup1.Width = 6.044488!
        '
        'txtTotalGroup1
        '
        Me.txtTotalGroup1.DataField = "total"
        Me.txtTotalGroup1.Height = 0.2!
        Me.txtTotalGroup1.Left = 5.449213!
        Me.txtTotalGroup1.Name = "txtTotalGroup1"
        Me.txtTotalGroup1.Style = "text-align: right"
        Me.txtTotalGroup1.SummaryGroup = "GroupHeader1"
        Me.txtTotalGroup1.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.txtTotalGroup1.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal
        Me.txtTotalGroup1.Text = "total"
        Me.txtTotalGroup1.Top = 0!
        Me.txtTotalGroup1.Width = 1.0!
        '
        'GroupHeader2
        '
        Me.GroupHeader2.BackColor = System.Drawing.Color.White
        Me.GroupHeader2.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Label5, Me.txtDescSubRubro})
        Me.GroupHeader2.DataField = "codsubrubro"
        Me.GroupHeader2.Height = 0.2291667!
        Me.GroupHeader2.Name = "GroupHeader2"
        '
        'Label5
        '
        Me.Label5.Height = 0.2!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.3326771!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.Label5.Text = "Sub-Rubro"
        Me.Label5.Top = 0!
        Me.Label5.Width = 0.7610238!
        '
        'txtDescSubRubro
        '
        Me.txtDescSubRubro.DataField = "descsubrubro"
        Me.txtDescSubRubro.Height = 0.2!
        Me.txtDescSubRubro.Left = 1.246063!
        Me.txtDescSubRubro.Name = "txtDescSubRubro"
        Me.txtDescSubRubro.Text = "descsubrubro"
        Me.txtDescSubRubro.Top = 0!
        Me.txtDescSubRubro.Width = 2.983464!
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblGroup2, Me.txtTotalGroup2})
        Me.GroupFooter2.Height = 0.21875!
        Me.GroupFooter2.Name = "GroupFooter2"
        Me.GroupFooter2.NewColumn = GrapeCity.ActiveReports.SectionReportModel.NewColumn.Before
        '
        'lblGroup2
        '
        Me.lblGroup2.Height = 0.2!
        Me.lblGroup2.HyperLink = Nothing
        Me.lblGroup2.Left = 0.5330709!
        Me.lblGroup2.Name = "lblGroup2"
        Me.lblGroup2.Style = "background-color: #F8FFD2"
        Me.lblGroup2.Text = "lblGruopHeader2"
        Me.lblGroup2.Top = 0!
        Me.lblGroup2.Width = 6.044488!
        '
        'txtTotalGroup2
        '
        Me.txtTotalGroup2.DataField = "total"
        Me.txtTotalGroup2.Height = 0.2!
        Me.txtTotalGroup2.Left = 5.387008!
        Me.txtTotalGroup2.Name = "txtTotalGroup2"
        Me.txtTotalGroup2.Style = "text-align: right"
        Me.txtTotalGroup2.SummaryGroup = "GroupHeader2"
        Me.txtTotalGroup2.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.txtTotalGroup2.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal
        Me.txtTotalGroup2.Text = "total"
        Me.txtTotalGroup2.Top = 0!
        Me.txtTotalGroup2.Width = 1.062205!
        '
        'RptImpresoInsumosComprados
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
        CType(Me.lblFechaHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescRubro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescSubRubro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private WithEvents ReportHeader1 As GrapeCity.ActiveReports.SectionReportModel.ReportHeader
    Private WithEvents ReportFooter1 As GrapeCity.ActiveReports.SectionReportModel.ReportFooter
    Private WithEvents GroupHeader1 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GroupFooter1 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents Picture1 As GrapeCity.ActiveReports.SectionReportModel.Picture
    Private WithEvents lblDireccion As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblJoseGuma As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape1 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Label1 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblPage As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtPage As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label2 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lblPie As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape2 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblFechaHeader As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblCantidad As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblPrecio As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblTotal As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label3 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblFecha As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label4 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtDescRubro As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents GroupHeader2 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents Label5 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents GroupFooter2 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents txtDescSubRubro As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtFechaComp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtGroup As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtCantidad As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtPrecio As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotal As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lblGroup2 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblGroup1 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtTotalGroup1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalGroup2 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lblTotalGeneral As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtTotalGeneral As GrapeCity.ActiveReports.SectionReportModel.TextBox
End Class
