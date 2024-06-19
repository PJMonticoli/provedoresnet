<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class RptImpresoComprobantePorTipoCompPorInsumo
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptImpresoComprobantePorTipoCompPorInsumo))
        Me.PageHeader = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.Shape3 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblNroInterno = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblComprobante = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblFComp = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblFVto = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblImpProd = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblImpNI = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label2 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.txtCodInsumo = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtComprobante = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtFechaComp = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtFechaVto = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPrefijo = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtImpNI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotal = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtField9 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtNroProveedor = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTipoComp = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtnroCompAlfanumerico = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtCotizacion = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.PageFooter = New GrapeCity.ActiveReports.SectionReportModel.PageFooter()
        Me.lblPage = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtPage = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label4 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblPie = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox8 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.ReportHeader1 = New GrapeCity.ActiveReports.SectionReportModel.ReportHeader()
        Me.lblJoseGuma = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblDireccion = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Picture1 = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.Shape1 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblTitulo = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblFecha = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.ReportFooter1 = New GrapeCity.ActiveReports.SectionReportModel.ReportFooter()
        Me.Shape5 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblTotales = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtImpProd = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalIvaProd = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalPerIva = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalPerGan = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalPerIB = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalImpNI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalGrl = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalporCta = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupHeader1 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.Shape2 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblCodInsumo = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtDescInsumo = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupFooter1 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.Shape4 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Label3 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtSubTotalInsumo = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        CType(Me.lblNroInterno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFVto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblImpProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblImpNI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodInsumo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaVto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrefijo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImpNI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtField9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNroProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtnroCompAlfanumerico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCotizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImpProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalIvaProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPerIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPerGan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPerIB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalImpNI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalGrl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalporCta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCodInsumo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescInsumo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSubTotalInsumo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape3, Me.lblNroInterno, Me.lblComprobante, Me.lblFComp, Me.lblFVto, Me.lblImpProd, Me.lblImpNI, Me.Label1, Me.Label2})
        Me.PageHeader.Height = 0.4375!
        Me.PageHeader.Name = "PageHeader"
        '
        'Shape3
        '
        Me.Shape3.Height = 0.3228346!
        Me.Shape3.Left = 0.04330709!
        Me.Shape3.Name = "Shape3"
        Me.Shape3.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape3.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape3.Top = 0.05748032!
        Me.Shape3.Width = 9.95!
        '
        'lblNroInterno
        '
        Me.lblNroInterno.Height = 0.2!
        Me.lblNroInterno.HyperLink = Nothing
        Me.lblNroInterno.Left = 0.1744095!
        Me.lblNroInterno.Name = "lblNroInterno"
        Me.lblNroInterno.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblNroInterno.Text = "N° Interno"
        Me.lblNroInterno.Top = 0.1244095!
        Me.lblNroInterno.Width = 0.7814958!
        '
        'lblComprobante
        '
        Me.lblComprobante.Height = 0.2!
        Me.lblComprobante.HyperLink = Nothing
        Me.lblComprobante.Left = 1.054331!
        Me.lblComprobante.Name = "lblComprobante"
        Me.lblComprobante.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblComprobante.Text = "Comprobante"
        Me.lblComprobante.Top = 0.1248032!
        Me.lblComprobante.Width = 0.958268!
        '
        'lblFComp
        '
        Me.lblFComp.Height = 0.2!
        Me.lblFComp.HyperLink = Nothing
        Me.lblFComp.Left = 2.24567!
        Me.lblFComp.Name = "lblFComp"
        Me.lblFComp.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblFComp.Text = "F. Comp"
        Me.lblFComp.Top = 0.1244095!
        Me.lblFComp.Width = 0.6708661!
        '
        'lblFVto
        '
        Me.lblFVto.Height = 0.2!
        Me.lblFVto.HyperLink = Nothing
        Me.lblFVto.Left = 3.172049!
        Me.lblFVto.Name = "lblFVto"
        Me.lblFVto.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblFVto.Text = "F.Vto"
        Me.lblFVto.Top = 0.1248032!
        Me.lblFVto.Width = 0.5208661!
        '
        'lblImpProd
        '
        Me.lblImpProd.Height = 0.2!
        Me.lblImpProd.HyperLink = Nothing
        Me.lblImpProd.Left = 3.962992!
        Me.lblImpProd.Name = "lblImpProd"
        Me.lblImpProd.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblImpProd.Text = "Cotización"
        Me.lblImpProd.Top = 0.1244095!
        Me.lblImpProd.Width = 0.7759833!
        '
        'lblImpNI
        '
        Me.lblImpNI.Height = 0.2!
        Me.lblImpNI.HyperLink = Nothing
        Me.lblImpNI.Left = 5.848823!
        Me.lblImpNI.Name = "lblImpNI"
        Me.lblImpNI.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblImpNI.Text = "Imp.NI"
        Me.lblImpNI.Top = 0.1248032!
        Me.lblImpNI.Width = 0.5582685!
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 6.928351!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label1.Text = "Total"
        Me.Label1.Top = 0.1244095!
        Me.Label1.Width = 0.5582685!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 8.300388!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label2.Text = "Proveedor"
        Me.Label2.Top = 0.1248032!
        Me.Label2.Width = 0.8185049!
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txtCodInsumo, Me.txtComprobante, Me.txtFechaComp, Me.txtFechaVto, Me.txtPrefijo, Me.txtImpNI, Me.txtTotal, Me.txtField9, Me.txtNroProveedor, Me.txtTipoComp, Me.txtnroCompAlfanumerico, Me.txtCotizacion})
        Me.Detail.Height = 0.21875!
        Me.Detail.Name = "Detail"
        '
        'txtCodInsumo
        '
        Me.txtCodInsumo.DataField = "nrointerno"
        Me.txtCodInsumo.Height = 0.2!
        Me.txtCodInsumo.Left = 0.1043307!
        Me.txtCodInsumo.Name = "txtCodInsumo"
        Me.txtCodInsumo.Style = "font-family: Microsoft Sans Serif; font-size: 8pt; ddo-char-set: 1"
        Me.txtCodInsumo.Text = "nro"
        Me.txtCodInsumo.Top = 0!
        Me.txtCodInsumo.Width = 0.5062993!
        '
        'txtComprobante
        '
        Me.txtComprobante.DataField = "DescComp"
        Me.txtComprobante.Height = 0.2!
        Me.txtComprobante.Left = 0.696457!
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.Style = "font-family: Microsoft Sans Serif; font-size: 8pt; ddo-char-set: 1"
        Me.txtComprobante.Text = "FP -A-"
        Me.txtComprobante.Top = 0!
        Me.txtComprobante.Width = 0.4342509!
        '
        'txtFechaComp
        '
        Me.txtFechaComp.DataField = "fechacomp"
        Me.txtFechaComp.Height = 0.2!
        Me.txtFechaComp.Left = 2.175591!
        Me.txtFechaComp.Name = "txtFechaComp"
        Me.txtFechaComp.Style = "font-family: Microsoft Sans Serif; font-size: 8pt; ddo-char-set: 1"
        Me.txtFechaComp.Text = "fechacomp"
        Me.txtFechaComp.Top = 0!
        Me.txtFechaComp.Width = 0.6543306!
        '
        'txtFechaVto
        '
        Me.txtFechaVto.DataField = "fechavto"
        Me.txtFechaVto.Height = 0.2!
        Me.txtFechaVto.Left = 2.948424!
        Me.txtFechaVto.Name = "txtFechaVto"
        Me.txtFechaVto.Style = "font-family: Microsoft Sans Serif; font-size: 8pt; ddo-char-set: 1"
        Me.txtFechaVto.Text = "fvto"
        Me.txtFechaVto.Top = 0!
        Me.txtFechaVto.Width = 0.7708653!
        '
        'txtPrefijo
        '
        Me.txtPrefijo.DataField = "nrocomp"
        Me.txtPrefijo.Height = 0.2!
        Me.txtPrefijo.Left = 1.130709!
        Me.txtPrefijo.Name = "txtPrefijo"
        Me.txtPrefijo.Style = "font-family: Microsoft Sans Serif; font-size: 8pt; ddo-char-set: 1"
        Me.txtPrefijo.Text = "nrocomp"
        Me.txtPrefijo.Top = 0!
        Me.txtPrefijo.Width = 0.9405507!
        '
        'txtImpNI
        '
        Me.txtImpNI.DataField = "importenoimp"
        Me.txtImpNI.Height = 0.2!
        Me.txtImpNI.Left = 5.243701!
        Me.txtImpNI.Name = "txtImpNI"
        Me.txtImpNI.Style = "font-family: Microsoft Sans Serif; font-size: 8pt; text-align: right; ddo-char-se" &
    "t: 1"
        Me.txtImpNI.Text = "impni"
        Me.txtImpNI.Top = 0!
        Me.txtImpNI.Width = 1.079527!
        '
        'txtTotal
        '
        Me.txtTotal.DataField = "totalcomprobante"
        Me.txtTotal.Height = 0.2!
        Me.txtTotal.Left = 6.491733!
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Style = "font-family: Microsoft Sans Serif; font-size: 8pt; text-align: right; ddo-char-se" &
    "t: 1"
        Me.txtTotal.Text = "total"
        Me.txtTotal.Top = 0!
        Me.txtTotal.Width = 1.075197!
        '
        'txtField9
        '
        Me.txtField9.CanGrow = False
        Me.txtField9.DataField = "rsocial"
        Me.txtField9.Height = 0.1653543!
        Me.txtField9.Left = 8.244883!
        Me.txtField9.Name = "txtField9"
        Me.txtField9.Style = "font-family: Microsoft Sans Serif; font-size: 8pt; ddo-char-set: 1"
        Me.txtField9.Text = "proveedor"
        Me.txtField9.Top = 0!
        Me.txtField9.Width = 1.748425!
        '
        'txtNroProveedor
        '
        Me.txtNroProveedor.DataField = "NroProveedor"
        Me.txtNroProveedor.Height = 0.2!
        Me.txtNroProveedor.Left = 7.741339!
        Me.txtNroProveedor.Name = "txtNroProveedor"
        Me.txtNroProveedor.Style = "font-family: Microsoft Sans Serif; font-size: 8pt; ddo-char-set: 1"
        Me.txtNroProveedor.Text = "nro-"
        Me.txtNroProveedor.Top = 0!
        Me.txtNroProveedor.Width = 0.4421244!
        '
        'txtTipoComp
        '
        Me.txtTipoComp.DataField = "Tipocomp"
        Me.txtTipoComp.Height = 0.2!
        Me.txtTipoComp.Left = 0.5102361!
        Me.txtTipoComp.Name = "txtTipoComp"
        Me.txtTipoComp.Style = "font-family: Microsoft Sans Serif; font-size: 8pt; ddo-char-set: 1"
        Me.txtTipoComp.Text = Nothing
        Me.txtTipoComp.Top = 0.3456693!
        Me.txtTipoComp.Width = 0.6204714!
        '
        'txtnroCompAlfanumerico
        '
        Me.txtnroCompAlfanumerico.DataField = "nroCompAlfanumerico"
        Me.txtnroCompAlfanumerico.Height = 0.2!
        Me.txtnroCompAlfanumerico.Left = 1.305117!
        Me.txtnroCompAlfanumerico.Name = "txtnroCompAlfanumerico"
        Me.txtnroCompAlfanumerico.Style = "font-family: Microsoft Sans Serif; font-size: 8pt; ddo-char-set: 1"
        Me.txtnroCompAlfanumerico.Text = Nothing
        Me.txtnroCompAlfanumerico.Top = 0.3456693!
        Me.txtnroCompAlfanumerico.Width = 0.6114163!
        '
        'txtCotizacion
        '
        Me.txtCotizacion.DataField = "cotizaciondolar"
        Me.txtCotizacion.Height = 0.2!
        Me.txtCotizacion.Left = 3.80945!
        Me.txtCotizacion.Name = "txtCotizacion"
        Me.txtCotizacion.Style = "font-family: Microsoft Sans Serif; font-size: 8pt; text-align: right; ddo-char-se" &
    "t: 1"
        Me.txtCotizacion.Text = "cot"
        Me.txtCotizacion.Top = 0!
        Me.txtCotizacion.Width = 0.9295266!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblPage, Me.txtPage, Me.Label4, Me.lblPie, Me.TextBox8})
        Me.PageFooter.Name = "PageFooter"
        '
        'lblPage
        '
        Me.lblPage.Height = 0.2!
        Me.lblPage.HyperLink = Nothing
        Me.lblPage.Left = 7.822374!
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.lblPage.Text = "Página"
        Me.lblPage.Top = 0.02499999!
        Me.lblPage.Width = 0.5838585!
        '
        'txtPage
        '
        Me.txtPage.Height = 0.2!
        Me.txtPage.Left = 8.541667!
        Me.txtPage.Name = "txtPage"
        Me.txtPage.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtPage.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All
        Me.txtPage.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.txtPage.Text = "#"
        Me.txtPage.Top = 0.02499999!
        Me.txtPage.Width = 0.3027558!
        '
        'Label4
        '
        Me.Label4.Height = 0.2!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 8.947972!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.Label4.Text = "de"
        Me.Label4.Top = 0.02499999!
        Me.Label4.Width = 0.2708659!
        '
        'lblPie
        '
        Me.lblPie.Height = 0.2!
        Me.lblPie.HyperLink = Nothing
        Me.lblPie.Left = 0.4471803!
        Me.lblPie.Name = "lblPie"
        Me.lblPie.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.lblPie.Text = "pie"
        Me.lblPie.Top = 0.02499999!
        Me.lblPie.Width = 3.062599!
        '
        'TextBox8
        '
        Me.TextBox8.Height = 0.2!
        Me.TextBox8.Left = 9.333396!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.TextBox8.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.TextBox8.Text = "##"
        Me.TextBox8.Top = 0.02499999!
        Me.TextBox8.Width = 0.3027558!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblJoseGuma, Me.lblDireccion, Me.Picture1, Me.Shape1, Me.lblTitulo, Me.lblFecha})
        Me.ReportHeader1.Height = 1.469045!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'lblJoseGuma
        '
        Me.lblJoseGuma.Height = 0.2!
        Me.lblJoseGuma.HyperLink = Nothing
        Me.lblJoseGuma.Left = 1.377559!
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
        Me.lblDireccion.Left = 1.36063!
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.lblDireccion.Text = "lblDireccion"
        Me.lblDireccion.Top = 0.2354331!
        Me.lblDireccion.Width = 2.891732!
        '
        'Picture1
        '
        Me.Picture1.Height = 0.7582681!
        Me.Picture1.HyperLink = Nothing
        Me.Picture1.ImageBytes = CType(resources.GetObject("Picture1.ImageBytes"), Byte())
        Me.Picture1.Left = 0.1366148!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.Picture1.Top = 0!
        Me.Picture1.Width = 1.135039!
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape1.Height = 0.5834646!
        Me.Shape1.Left = 2.134646!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape1.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape1.Top = 0.8543308!
        Me.Shape1.Width = 5.884253!
        '
        'lblTitulo
        '
        Me.lblTitulo.Height = 0.2622046!
        Me.lblTitulo.HyperLink = Nothing
        Me.lblTitulo.Left = 2.69567!
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Style = "font-size: 12pt; font-weight: bold; text-align: center; ddo-char-set: 1"
        Me.lblTitulo.Text = "Resumen por tipo de Comprobantes"
        Me.lblTitulo.Top = 0.9062996!
        Me.lblTitulo.Width = 4.871261!
        '
        'lblFecha
        '
        Me.lblFecha.Height = 0.2000002!
        Me.lblFecha.HyperLink = Nothing
        Me.lblFecha.Left = 2.954723!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "font-size: 10pt; text-align: center; ddo-char-set: 1"
        Me.lblFecha.Text = ""
        Me.lblFecha.Top = 1.168505!
        Me.lblFecha.Width = 4.37441!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape5, Me.lblTotales, Me.txtImpProd, Me.txtTotalIvaProd, Me.txtTotalPerIva, Me.txtTotalPerGan, Me.txtTotalPerIB, Me.txtTotalImpNI, Me.txtTotalGrl, Me.txtTotalporCta})
        Me.ReportFooter1.Height = 0.6453904!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'Shape5
        '
        Me.Shape5.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.Shape5.Height = 0.3149606!
        Me.Shape5.Left = 0.8780828!
        Me.Shape5.Name = "Shape5"
        Me.Shape5.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape5.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape5.Top = 0!
        Me.Shape5.Width = 8.327167!
        '
        'lblTotales
        '
        Me.lblTotales.Height = 0.2!
        Me.lblTotales.HyperLink = Nothing
        Me.lblTotales.Left = 0.9729669!
        Me.lblTotales.Name = "lblTotales"
        Me.lblTotales.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblTotales.Text = "TOTALES"
        Me.lblTotales.Top = 0.06259844!
        Me.lblTotales.Width = 0.6830711!
        '
        'txtImpProd
        '
        Me.txtImpProd.DataField = "importeprod"
        Me.txtImpProd.Height = 0.2!
        Me.txtImpProd.Left = 1.663124!
        Me.txtImpProd.Name = "txtImpProd"
        Me.txtImpProd.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtImpProd.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All
        Me.txtImpProd.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal
        Me.txtImpProd.Text = "totalprod"
        Me.txtImpProd.Top = 0.06259844!
        Me.txtImpProd.Width = 0.99685!
        '
        'txtTotalIvaProd
        '
        Me.txtTotalIvaProd.DataField = "ivaprod"
        Me.txtTotalIvaProd.Height = 0.2!
        Me.txtTotalIvaProd.Left = 2.88084!
        Me.txtTotalIvaProd.Name = "txtTotalIvaProd"
        Me.txtTotalIvaProd.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtTotalIvaProd.Text = "totalivaprod"
        Me.txtTotalIvaProd.Top = 0.06259844!
        Me.txtTotalIvaProd.Width = 0.9685042!
        '
        'txtTotalPerIva
        '
        Me.txtTotalPerIva.DataField = "percepiva"
        Me.txtTotalPerIva.Height = 0.2!
        Me.txtTotalPerIva.Left = 3.996983!
        Me.txtTotalPerIva.Name = "txtTotalPerIva"
        Me.txtTotalPerIva.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtTotalPerIva.Text = "totalperiva"
        Me.txtTotalPerIva.Top = 0.06259844!
        Me.txtTotalPerIva.Width = 1.014565!
        '
        'txtTotalPerGan
        '
        Me.txtTotalPerGan.DataField = "percepgan"
        Me.txtTotalPerGan.Height = 0.2!
        Me.txtTotalPerGan.Left = 5.103677!
        Me.txtTotalPerGan.Name = "txtTotalPerGan"
        Me.txtTotalPerGan.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtTotalPerGan.Text = "pergan"
        Me.txtTotalPerGan.Top = 0.06259844!
        Me.txtTotalPerGan.Width = 0.782284!
        '
        'txtTotalPerIB
        '
        Me.txtTotalPerIB.DataField = "totalpercepib"
        Me.txtTotalPerIB.Height = 0.2!
        Me.txtTotalPerIB.Left = 5.996983!
        Me.txtTotalPerIB.Name = "txtTotalPerIB"
        Me.txtTotalPerIB.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtTotalPerIB.Text = "totalIB"
        Me.txtTotalPerIB.Top = 0.06259844!
        Me.txtTotalPerIB.Width = 0.929134!
        '
        'txtTotalImpNI
        '
        Me.txtTotalImpNI.DataField = "importenoimp"
        Me.txtTotalImpNI.Height = 0.2!
        Me.txtTotalImpNI.Left = 7.10722!
        Me.txtTotalImpNI.Name = "txtTotalImpNI"
        Me.txtTotalImpNI.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtTotalImpNI.Text = "totalNI"
        Me.txtTotalImpNI.Top = 0.06259844!
        Me.txtTotalImpNI.Width = 0.8503938!
        '
        'txtTotalGrl
        '
        Me.txtTotalGrl.DataField = "totalcomprobante"
        Me.txtTotalGrl.Height = 0.2!
        Me.txtTotalGrl.Left = 8.093046!
        Me.txtTotalGrl.Name = "txtTotalGrl"
        Me.txtTotalGrl.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtTotalGrl.Text = "totalgrl"
        Me.txtTotalGrl.Top = 0.06259844!
        Me.txtTotalGrl.Width = 0.961023!
        '
        'txtTotalporCta
        '
        Me.txtTotalporCta.Height = 0.2!
        Me.txtTotalporCta.Left = 2.42966!
        Me.txtTotalporCta.Name = "txtTotalporCta"
        Me.txtTotalporCta.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtTotalporCta.Text = Nothing
        Me.txtTotalporCta.Top = 0.3933071!
        Me.txtTotalporCta.Width = 5.42756!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape2, Me.lblCodInsumo, Me.txtDescInsumo})
        Me.GroupHeader1.DataField = "CodInsumo"
        Me.GroupHeader1.Height = 0.3464239!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'Shape2
        '
        Me.Shape2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Shape2.Height = 0.3255906!
        Me.Shape2.Left = 0.09055119!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape2.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape2.Top = 0!
        Me.Shape2.Width = 6.325984!
        '
        'lblCodInsumo
        '
        Me.lblCodInsumo.Height = 0.2!
        Me.lblCodInsumo.HyperLink = Nothing
        Me.lblCodInsumo.Left = 0.1322835!
        Me.lblCodInsumo.Name = "lblCodInsumo"
        Me.lblCodInsumo.Style = "font-size: 9pt; font-weight: bold"
        Me.lblCodInsumo.Text = "Código Insumo: "
        Me.lblCodInsumo.Top = 0.07716535!
        Me.lblCodInsumo.Width = 1.159055!
        '
        'txtDescInsumo
        '
        Me.txtDescInsumo.DataField = "DescInsumo"
        Me.txtDescInsumo.Height = 0.2!
        Me.txtDescInsumo.Left = 1.514961!
        Me.txtDescInsumo.Name = "txtDescInsumo"
        Me.txtDescInsumo.Style = "font-size: 9pt; ddo-char-set: 1"
        Me.txtDescInsumo.Text = "cod insumo"
        Me.txtDescInsumo.Top = 0.07716535!
        Me.txtDescInsumo.Width = 4.808268!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape4, Me.Label3, Me.txtSubTotalInsumo})
        Me.GroupFooter1.Height = 0.346424!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Shape4
        '
        Me.Shape4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Shape4.Height = 0.3255906!
        Me.Shape4.Left = 6.552757!
        Me.Shape4.Name = "Shape4"
        Me.Shape4.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape4.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape4.Top = 7.450581E-9!
        Me.Shape4.Width = 3.396851!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 6.61693!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-size: 9pt; font-weight: bold"
        Me.Label3.Text = "Sub Total Insumo: "
        Me.Label3.Top = 0.07716536!
        Me.Label3.Width = 1.159056!
        '
        'txtSubTotalInsumo
        '
        Me.txtSubTotalInsumo.Height = 0.2!
        Me.txtSubTotalInsumo.Left = 8.07992!
        Me.txtSubTotalInsumo.Name = "txtSubTotalInsumo"
        Me.txtSubTotalInsumo.Style = "font-size: 9pt; text-align: right; ddo-char-set: 1"
        Me.txtSubTotalInsumo.Text = "subtotal"
        Me.txtSubTotalInsumo.Top = 0.07716536!
        Me.txtSubTotalInsumo.Width = 1.683072!
        '
        'RptImpresoComprobantePorTipoCompPorInsumo
        '
        Me.MasterReport = False
        Me.CompatibilityMode = GrapeCity.ActiveReports.Document.CompatibilityModes.CrossPlatform
        Me.PageSettings.Margins.Bottom = 0.3937008!
        Me.PageSettings.Margins.Left = 0.3937008!
        Me.PageSettings.Margins.Right = 0.3937008!
        Me.PageSettings.Margins.Top = 0.3937008!
        Me.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 10.08333!
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
        CType(Me.lblNroInterno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFVto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblImpProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblImpNI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodInsumo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaVto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrefijo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImpNI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtField9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNroProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtnroCompAlfanumerico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCotizacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImpProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalIvaProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPerIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPerGan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPerIB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalImpNI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalGrl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalporCta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCodInsumo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescInsumo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSubTotalInsumo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private WithEvents ReportHeader1 As GrapeCity.ActiveReports.SectionReportModel.ReportHeader
    Private WithEvents lblJoseGuma As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblDireccion As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Picture1 As GrapeCity.ActiveReports.SectionReportModel.Picture
    Private WithEvents Shape1 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblTitulo As GrapeCity.ActiveReports.SectionReportModel.Label
    Public WithEvents lblFecha As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents ReportFooter1 As GrapeCity.ActiveReports.SectionReportModel.ReportFooter
    Private WithEvents GroupHeader1 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GroupFooter1 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents Shape3 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblNroInterno As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblComprobante As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblFComp As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblFVto As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblImpProd As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblImpNI As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label1 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label2 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape2 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblCodInsumo As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtDescInsumo As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtCodInsumo As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtComprobante As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtFechaComp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtFechaVto As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtPrefijo As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtImpNI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotal As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtField9 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtNroProveedor As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTipoComp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtnroCompAlfanumerico As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtCotizacion As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Shape4 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Label3 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtSubTotalInsumo As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lblPage As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtPage As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label4 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblPie As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox8 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Shape5 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblTotales As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtImpProd As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalIvaProd As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalPerIva As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalPerGan As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalPerIB As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalImpNI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalGrl As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalporCta As GrapeCity.ActiveReports.SectionReportModel.TextBox
End Class
