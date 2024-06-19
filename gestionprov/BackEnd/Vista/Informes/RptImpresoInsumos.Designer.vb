<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class RptImpresoInsumos
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptImpresoInsumos))
        Me.PageHeader = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.Shape2 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblProveedor = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblComprobante = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblCantidad = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblPrecio = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblTotal = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.txtRazonSocial = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtCantidad = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPrecio = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotal = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtComprobante = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTipoComp = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPrefijo = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtNroComp = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtnroCompAlfanumerico = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.PageFooter = New GrapeCity.ActiveReports.SectionReportModel.PageFooter()
        Me.lblPie = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblPage = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtPage = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label3 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox8 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.ReportHeader1 = New GrapeCity.ActiveReports.SectionReportModel.ReportHeader()
        Me.lblJoseGuma = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblDireccion = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Shape1 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Picture1 = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.lblFecha = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.ReportFooter1 = New GrapeCity.ActiveReports.SectionReportModel.ReportFooter()
        Me.Shape3 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblTotales = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtTotalGeneral = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupHeader1 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.Shape4 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Label2 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtCodInsumo = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtGroup = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupFooter1 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        CType(Me.lblProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRazonSocial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrefijo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNroComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtnroCompAlfanumerico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodInsumo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape2, Me.lblProveedor, Me.lblComprobante, Me.lblCantidad, Me.lblPrecio, Me.lblTotal})
        Me.PageHeader.Height = 0.2604167!
        Me.PageHeader.Name = "PageHeader"
        '
        'Shape2
        '
        Me.Shape2.BackColor = System.Drawing.Color.Gainsboro
        Me.Shape2.Height = 0.1968504!
        Me.Shape2.Left = 0.1877953!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape2.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape2.Top = 0!
        Me.Shape2.Width = 5.933858!
        '
        'lblProveedor
        '
        Me.lblProveedor.Height = 0.1574803!
        Me.lblProveedor.HyperLink = Nothing
        Me.lblProveedor.Left = 0.4137787!
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1"
        Me.lblProveedor.Text = "Proveedor"
        Me.lblProveedor.Top = 0.0515748!
        Me.lblProveedor.Width = 1.0!
        '
        'lblComprobante
        '
        Me.lblComprobante.Height = 0.1574803!
        Me.lblComprobante.HyperLink = Nothing
        Me.lblComprobante.Left = 2.502756!
        Me.lblComprobante.Name = "lblComprobante"
        Me.lblComprobante.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1"
        Me.lblComprobante.Text = "Comprobante"
        Me.lblComprobante.Top = 0.03543307!
        Me.lblComprobante.Width = 0.9582677!
        '
        'lblCantidad
        '
        Me.lblCantidad.Height = 0.1574803!
        Me.lblCantidad.HyperLink = Nothing
        Me.lblCantidad.Left = 3.829528!
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1"
        Me.lblCantidad.Text = "Cantidad"
        Me.lblCantidad.Top = 0.03543307!
        Me.lblCantidad.Width = 0.6673229!
        '
        'lblPrecio
        '
        Me.lblPrecio.Height = 0.1574803!
        Me.lblPrecio.HyperLink = Nothing
        Me.lblPrecio.Left = 4.705512!
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1"
        Me.lblPrecio.Text = "Precio"
        Me.lblPrecio.Top = 0.03543307!
        Me.lblPrecio.Width = 0.5!
        '
        'lblTotal
        '
        Me.lblTotal.Height = 0.1574803!
        Me.lblTotal.HyperLink = Nothing
        Me.lblTotal.Left = 5.488189!
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1"
        Me.lblTotal.Text = "Total"
        Me.lblTotal.Top = 0.03543307!
        Me.lblTotal.Width = 0.3653543!
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txtRazonSocial, Me.txtCantidad, Me.txtPrecio, Me.txtTotal, Me.txtComprobante, Me.txtTipoComp, Me.txtPrefijo, Me.txtNroComp, Me.txtnroCompAlfanumerico})
        Me.Detail.Height = 0.1583333!
        Me.Detail.Name = "Detail"
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.CanGrow = False
        Me.txtRazonSocial.DataField = "rsocial"
        Me.txtRazonSocial.Height = 0.1574803!
        Me.txtRazonSocial.Left = 0.2346457!
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Style = "font-size: 7.5pt; ddo-char-set: 1"
        Me.txtRazonSocial.Text = "razon social"
        Me.txtRazonSocial.Top = 0!
        Me.txtRazonSocial.Width = 2.000787!
        '
        'txtCantidad
        '
        Me.txtCantidad.DataField = "cantidad"
        Me.txtCantidad.Height = 0.2!
        Me.txtCantidad.Left = 3.56378!
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Style = "font-size: 7.5pt; text-align: right; ddo-char-set: 1"
        Me.txtCantidad.Text = "cantidad"
        Me.txtCantidad.Top = 0!
        Me.txtCantidad.Width = 0.8543305!
        '
        'txtPrecio
        '
        Me.txtPrecio.DataField = "precio"
        Me.txtPrecio.Height = 0.2!
        Me.txtPrecio.Left = 4.351182!
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Style = "font-size: 7.5pt; text-align: right; ddo-char-set: 1"
        Me.txtPrecio.Text = "precio"
        Me.txtPrecio.Top = 0!
        Me.txtPrecio.Width = 0.8543305!
        '
        'txtTotal
        '
        Me.txtTotal.DataField = "total"
        Me.txtTotal.Height = 0.2!
        Me.txtTotal.Left = 5.33504!
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Style = "font-size: 7.5pt; text-align: right; ddo-char-set: 1"
        Me.txtTotal.Text = "total"
        Me.txtTotal.Top = 0!
        Me.txtTotal.Width = 0.7917323!
        '
        'txtComprobante
        '
        Me.txtComprobante.DataField = "DescComp"
        Me.txtComprobante.Height = 0.2!
        Me.txtComprobante.Left = 2.244095!
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.Style = "font-size: 7.5pt; ddo-char-set: 1"
        Me.txtComprobante.Text = "FP -A-"
        Me.txtComprobante.Top = 0!
        Me.txtComprobante.Width = 0.4492125!
        '
        'txtTipoComp
        '
        Me.txtTipoComp.DataField = "Tipocomp"
        Me.txtTipoComp.Height = 0.2!
        Me.txtTipoComp.Left = 1.776378!
        Me.txtTipoComp.Name = "txtTipoComp"
        Me.txtTipoComp.Style = "font-size: 7.5pt; ddo-char-set: 1"
        Me.txtTipoComp.Text = Nothing
        Me.txtTipoComp.Top = 0.3937008!
        Me.txtTipoComp.Width = 0.8543305!
        '
        'txtPrefijo
        '
        Me.txtPrefijo.DataField = "nrocomp"
        Me.txtPrefijo.Height = 0.2!
        Me.txtPrefijo.Left = 2.630709!
        Me.txtPrefijo.Name = "txtPrefijo"
        Me.txtPrefijo.Style = "font-size: 7.5pt; ddo-char-set: 1"
        Me.txtPrefijo.Text = "nrocomp"
        Me.txtPrefijo.Top = 0!
        Me.txtPrefijo.Width = 1.364961!
        '
        'txtNroComp
        '
        Me.txtNroComp.DataField = "nroComp"
        Me.txtNroComp.Height = 0.2!
        Me.txtNroComp.Left = 2.823229!
        Me.txtNroComp.Name = "txtNroComp"
        Me.txtNroComp.Style = "font-size: 7.5pt; ddo-char-set: 1"
        Me.txtNroComp.Text = Nothing
        Me.txtNroComp.Top = 0.3937008!
        Me.txtNroComp.Width = 0.6149606!
        '
        'txtnroCompAlfanumerico
        '
        Me.txtnroCompAlfanumerico.DataField = "nroCompAlfanumerico"
        Me.txtnroCompAlfanumerico.Height = 0.2!
        Me.txtnroCompAlfanumerico.Left = 4.067717!
        Me.txtnroCompAlfanumerico.Name = "txtnroCompAlfanumerico"
        Me.txtnroCompAlfanumerico.Style = "font-size: 7.5pt; ddo-char-set: 1"
        Me.txtnroCompAlfanumerico.Text = Nothing
        Me.txtnroCompAlfanumerico.Top = 0.3937008!
        Me.txtnroCompAlfanumerico.Width = 0.6149606!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblPie, Me.lblPage, Me.txtPage, Me.Label3, Me.TextBox8})
        Me.PageFooter.Height = 0.1666667!
        Me.PageFooter.Name = "PageFooter"
        '
        'lblPie
        '
        Me.lblPie.Height = 0.2!
        Me.lblPie.HyperLink = Nothing
        Me.lblPie.Left = 0.1877953!
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
        Me.lblPage.Left = 3.834252!
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.lblPage.Text = "Página"
        Me.lblPage.Top = 0!
        Me.lblPage.Width = 0.5838585!
        '
        'txtPage
        '
        Me.txtPage.Height = 0.2!
        Me.txtPage.Left = 4.574016!
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
        Me.Label3.Left = 5.022441!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.Label3.Text = "De"
        Me.Label3.Top = 0!
        Me.Label3.Width = 0.3125985!
        '
        'TextBox8
        '
        Me.TextBox8.Height = 0.2!
        Me.TextBox8.Left = 5.438583!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.TextBox8.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.TextBox8.Text = "##"
        Me.TextBox8.Top = 0!
        Me.TextBox8.Width = 0.3027558!
        '
        'Label1
        '
        Me.Label1.Height = 0.2622047!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 1.550394!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-size: 12pt; font-weight: bold; ddo-char-set: 1"
        Me.Label1.Text = "Listado de Insumos Ingresados en el Día"
        Me.Label1.Top = 0.8622048!
        Me.Label1.Width = 4.083466!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblJoseGuma, Me.lblDireccion, Me.Shape1, Me.Label1, Me.Picture1, Me.lblFecha})
        Me.ReportHeader1.Height = 1.437106!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'lblJoseGuma
        '
        Me.lblJoseGuma.Height = 0.2!
        Me.lblJoseGuma.HyperLink = Nothing
        Me.lblJoseGuma.Left = 1.345276!
        Me.lblJoseGuma.Name = "lblJoseGuma"
        Me.lblJoseGuma.Style = "font-size: 12pt; font-weight: bold"
        Me.lblJoseGuma.Text = "José Guma S.A."
        Me.lblJoseGuma.Top = 0!
        Me.lblJoseGuma.Width = 1.416535!
        '
        'lblDireccion
        '
        Me.lblDireccion.Height = 0.5228346!
        Me.lblDireccion.HyperLink = Nothing
        Me.lblDireccion.Left = 1.328346!
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.lblDireccion.Text = "lblDireccion"
        Me.lblDireccion.Top = 0.2354331!
        Me.lblDireccion.Width = 2.891732!
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.Color.Gainsboro
        Me.Shape1.Height = 0.5834646!
        Me.Shape1.Left = 0.1877953!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape1.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape1.Top = 0.8102363!
        Me.Shape1.Width = 5.933859!
        '
        'Picture1
        '
        Me.Picture1.Height = 0.7582678!
        Me.Picture1.ImageBytes = CType(resources.GetObject("Picture1.ImageBytes"), Byte())
        Me.Picture1.Left = 0.1043307!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.Picture1.Top = 0!
        Me.Picture1.Width = 1.135039!
        '
        'lblFecha
        '
        Me.lblFecha.Height = 0.2!
        Me.lblFecha.HyperLink = Nothing
        Me.lblFecha.Left = 0.9547245!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "font-size: 10pt; text-align: center; ddo-char-set: 1"
        Me.lblFecha.Text = ""
        Me.lblFecha.Top = 1.12441!
        Me.lblFecha.Width = 4.37441!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape3, Me.lblTotales, Me.txtTotalGeneral})
        Me.ReportFooter1.Height = 0.3855644!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'Shape3
        '
        Me.Shape3.BackColor = System.Drawing.Color.Gainsboro
        Me.Shape3.Height = 0.3149606!
        Me.Shape3.Left = 3.511418!
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
        Me.lblTotales.Left = 3.6563!
        Me.lblTotales.Name = "lblTotales"
        Me.lblTotales.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblTotales.Text = "Totales"
        Me.lblTotales.Top = 0.05236221!
        Me.lblTotales.Width = 0.6874022!
        '
        'txtTotalGeneral
        '
        Me.txtTotalGeneral.DataField = "total"
        Me.txtTotalGeneral.Height = 0.2!
        Me.txtTotalGeneral.Left = 4.511418!
        Me.txtTotalGeneral.Name = "txtTotalGeneral"
        Me.txtTotalGeneral.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtTotalGeneral.Text = "total general"
        Me.txtTotalGeneral.Top = 0.05236221!
        Me.txtTotalGeneral.Width = 1.30197!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape4, Me.Label2, Me.txtCodInsumo, Me.txtGroup})
        Me.GroupHeader1.DataField = "codInsumo"
        Me.GroupHeader1.Height = 0.1854168!
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.NewColumn = GrapeCity.ActiveReports.SectionReportModel.NewColumn.Before
        '
        'Shape4
        '
        Me.Shape4.Height = 0.1574803!
        Me.Shape4.Left = 0.2346457!
        Me.Shape4.Name = "Shape4"
        Me.Shape4.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape4.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape4.Top = 0!
        Me.Shape4.Width = 3.599606!
        '
        'Label2
        '
        Me.Label2.Height = 0.1574803!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.3043307!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1"
        Me.Label2.Text = "Insumo"
        Me.Label2.Top = 0.01181102!
        Me.Label2.Width = 0.6980315!
        '
        'txtCodInsumo
        '
        Me.txtCodInsumo.DataField = "codInsumo"
        Me.txtCodInsumo.Height = 0.1574803!
        Me.txtCodInsumo.Left = 1.064961!
        Me.txtCodInsumo.Name = "txtCodInsumo"
        Me.txtCodInsumo.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtCodInsumo.Text = "codigo insumo"
        Me.txtCodInsumo.Top = 0.01574803!
        Me.txtCodInsumo.Width = 1.240157!
        '
        'txtGroup
        '
        Me.txtGroup.CanGrow = False
        Me.txtGroup.DataField = "descinsumo"
        Me.txtGroup.Height = 0.1574803!
        Me.txtGroup.Left = 2.31378!
        Me.txtGroup.Name = "txtGroup"
        Me.txtGroup.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtGroup.Text = "desc insumo"
        Me.txtGroup.Top = 0.03464567!
        Me.txtGroup.Width = 1.466535!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'RptImpresoInsumos
        '
        Me.MasterReport = False
        Me.CompatibilityMode = GrapeCity.ActiveReports.Document.CompatibilityModes.CrossPlatform
        Me.PageSettings.Margins.Bottom = 0.3937007!
        Me.PageSettings.Margins.Left = 0.984252!
        Me.PageSettings.Margins.Right = 0.5905512!
        Me.PageSettings.Margins.Top = 0.3937007!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 6.499983!
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
        CType(Me.lblComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRazonSocial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrefijo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNroComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtnroCompAlfanumerico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodInsumo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private WithEvents Label1 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents ReportHeader1 As GrapeCity.ActiveReports.SectionReportModel.ReportHeader
    Private WithEvents ReportFooter1 As GrapeCity.ActiveReports.SectionReportModel.ReportFooter
    Private WithEvents GroupHeader1 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GroupFooter1 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents Shape1 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblJoseGuma As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblDireccion As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape2 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblProveedor As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblComprobante As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblCantidad As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblPrecio As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblTotal As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label2 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtCodInsumo As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtGroup As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lblPie As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblPage As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtPage As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Shape3 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblTotales As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtTotalGeneral As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Picture1 As GrapeCity.ActiveReports.SectionReportModel.Picture
    Private WithEvents Label3 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtRazonSocial As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtCantidad As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtPrecio As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotal As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtComprobante As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox8 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Public WithEvents lblFecha As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape4 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents txtTipoComp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtPrefijo As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtNroComp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtnroCompAlfanumerico As GrapeCity.ActiveReports.SectionReportModel.TextBox
End Class
