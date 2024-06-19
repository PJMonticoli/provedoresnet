<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class RptImpresoComprobantePendiente
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptImpresoComprobantePendiente))
        Me.PageHeader = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.Shape5 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Label5 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label6 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label8 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label9 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label10 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label11 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label12 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.txtNroInterno = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPrefijo = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtDescPago = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtFechaComp = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtFechaVto = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtObservacion = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtSaldo = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTipoComp = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtNroComp = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtnroCompAlfanumerico = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtComprobante = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.PageFooter = New GrapeCity.ActiveReports.SectionReportModel.PageFooter()
        Me.lblPage = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtPage = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label7 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.lblPie = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.ReportHeader1 = New GrapeCity.ActiveReports.SectionReportModel.ReportHeader()
        Me.Picture1 = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.lblDireccion = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblJoseGuma = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Shape1 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Label1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Shape2 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Shape3 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Shape4 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Shape6 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Label2 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label3 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label4 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.ReportFooter1 = New GrapeCity.ActiveReports.SectionReportModel.ReportFooter()
        Me.Shape7 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Label14 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label15 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label16 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Line1 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Label17 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtTotal = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalRemitos = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalNoAutorizado = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalSaldo = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line3 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.GroupHeader1 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.txtProveedor = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupFooter1 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.Label13 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtTotales = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line2 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNroInterno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrefijo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaVto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObservacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNroComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtnroCompAlfanumerico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalRemitos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalNoAutorizado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape5, Me.Label5, Me.Label6, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.Label12})
        Me.PageHeader.Height = 0.4064139!
        Me.PageHeader.Name = "PageHeader"
        '
        'Shape5
        '
        Me.Shape5.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape5.Height = 0.3543307!
        Me.Shape5.Left = 0.1149606!
        Me.Shape5.Name = "Shape5"
        Me.Shape5.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape5.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape5.Top = 0!
        Me.Shape5.Width = 7.030315!
        '
        'Label5
        '
        Me.Label5.Height = 0.2!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.2937008!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label5.Text = "N° Interno"
        Me.Label5.Top = 0.07204725!
        Me.Label5.Width = 0.764567!
        '
        'Label6
        '
        Me.Label6.Height = 0.2!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 1.175197!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label6.Text = "Comprobante"
        Me.Label6.Top = 0.07204725!
        Me.Label6.Width = 0.9913387!
        '
        'Label8
        '
        Me.Label8.Height = 0.2!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 2.42441!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label8.Text = "Tipo"
        Me.Label8.Top = 0.07204725!
        Me.Label8.Width = 0.4496064!
        '
        'Label9
        '
        Me.Label9.Height = 0.2!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 3.980315!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label9.Text = "Fecha"
        Me.Label9.Top = 0.07204725!
        Me.Label9.Width = 0.4496064!
        '
        'Label10
        '
        Me.Label10.Height = 0.2!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 4.669685!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label10.Text = "F. Vto."
        Me.Label10.Top = 0.07204725!
        Me.Label10.Width = 0.5098422!
        '
        'Label11
        '
        Me.Label11.Height = 0.2!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 5.252756!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label11.Text = "Observación"
        Me.Label11.Top = 0.07204725!
        Me.Label11.Width = 0.938189!
        '
        'Label12
        '
        Me.Label12.Height = 0.2!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 6.359449!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label12.Text = "Saldo"
        Me.Label12.Top = 0.07204725!
        Me.Label12.Width = 0.5645669!
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txtNroInterno, Me.txtPrefijo, Me.txtDescPago, Me.txtFechaComp, Me.txtFechaVto, Me.txtObservacion, Me.txtSaldo, Me.txtTipoComp, Me.txtNroComp, Me.txtnroCompAlfanumerico, Me.txtComprobante})
        Me.Detail.Height = 0.2!
        Me.Detail.Name = "Detail"
        '
        'txtNroInterno
        '
        Me.txtNroInterno.DataField = "nrointerno"
        Me.txtNroInterno.Height = 0.2!
        Me.txtNroInterno.Left = 0.09133859!
        Me.txtNroInterno.Name = "txtNroInterno"
        Me.txtNroInterno.Style = "font-family: Microsoft Sans Serif; font-size: 8.25pt; text-align: center; ddo-cha" &
    "r-set: 0"
        Me.txtNroInterno.Text = "nrointerno"
        Me.txtNroInterno.Top = 0!
        Me.txtNroInterno.Width = 0.6149607!
        '
        'txtPrefijo
        '
        Me.txtPrefijo.DataField = "nrocomp"
        Me.txtPrefijo.Height = 0.2!
        Me.txtPrefijo.Left = 1.058268!
        Me.txtPrefijo.Name = "txtPrefijo"
        Me.txtPrefijo.Style = "font-family: Microsoft Sans Serif; font-size: 8.25pt; text-align: left; ddo-char-" &
    "set: 0"
        Me.txtPrefijo.Text = "nrocomp"
        Me.txtPrefijo.Top = 0!
        Me.txtPrefijo.Width = 1.161417!
        '
        'txtDescPago
        '
        Me.txtDescPago.Height = 0.2!
        Me.txtDescPago.Left = 2.218898!
        Me.txtDescPago.Name = "txtDescPago"
        Me.txtDescPago.Style = "font-family: Microsoft Sans Serif; font-size: 8.25pt; text-align: left; ddo-char-" &
    "set: 0"
        Me.txtDescPago.Text = "tipo"
        Me.txtDescPago.Top = 0!
        Me.txtDescPago.Width = 1.61063!
        '
        'txtFechaComp
        '
        Me.txtFechaComp.DataField = "fechacomp"
        Me.txtFechaComp.Height = 0.2!
        Me.txtFechaComp.Left = 3.881103!
        Me.txtFechaComp.Name = "txtFechaComp"
        Me.txtFechaComp.Style = "font-family: Microsoft Sans Serif; font-size: 8.25pt; ddo-char-set: 0"
        Me.txtFechaComp.Text = "fechacomp"
        Me.txtFechaComp.Top = 0!
        Me.txtFechaComp.Width = 0.6452755!
        '
        'txtFechaVto
        '
        Me.txtFechaVto.DataField = "fechavto"
        Me.txtFechaVto.Height = 0.2!
        Me.txtFechaVto.Left = 4.610237!
        Me.txtFechaVto.Name = "txtFechaVto"
        Me.txtFechaVto.Style = "font-family: Microsoft Sans Serif; font-size: 8.25pt; ddo-char-set: 0"
        Me.txtFechaVto.Text = "fvto"
        Me.txtFechaVto.Top = 0!
        Me.txtFechaVto.Width = 0.6425185!
        '
        'txtObservacion
        '
        Me.txtObservacion.DataField = "pagado"
        Me.txtObservacion.Height = 0.2!
        Me.txtObservacion.Left = 5.348425!
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Style = "font-family: Microsoft Sans Serif; font-size: 8.25pt; ddo-char-set: 0"
        Me.txtObservacion.Text = Nothing
        Me.txtObservacion.Top = 0!
        Me.txtObservacion.Width = 0.6460624!
        '
        'txtSaldo
        '
        Me.txtSaldo.Height = 0.2!
        Me.txtSaldo.Left = 5.994489!
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Style = "font-family: Microsoft Sans Serif; font-size: 8.25pt; text-align: right; ddo-char" &
    "-set: 0"
        Me.txtSaldo.Text = "saldo"
        Me.txtSaldo.Top = 0!
        Me.txtSaldo.Width = 1.150787!
        '
        'txtTipoComp
        '
        Me.txtTipoComp.DataField = "Tipocomp"
        Me.txtTipoComp.Height = 0.2!
        Me.txtTipoComp.Left = 0.5755906!
        Me.txtTipoComp.Name = "txtTipoComp"
        Me.txtTipoComp.Style = "font-family: Microsoft Sans Serif; font-size: 8.25pt; ddo-char-set: 0"
        Me.txtTipoComp.Text = Nothing
        Me.txtTipoComp.Top = 0.2586614!
        Me.txtTipoComp.Width = 0.8543305!
        '
        'txtNroComp
        '
        Me.txtNroComp.DataField = "nroComp"
        Me.txtNroComp.Height = 0.2!
        Me.txtNroComp.Left = 1.551574!
        Me.txtNroComp.Name = "txtNroComp"
        Me.txtNroComp.Style = "font-family: Microsoft Sans Serif; font-size: 8.25pt; ddo-char-set: 0"
        Me.txtNroComp.Text = Nothing
        Me.txtNroComp.Top = 0.2586614!
        Me.txtNroComp.Width = 0.6149606!
        '
        'txtnroCompAlfanumerico
        '
        Me.txtnroCompAlfanumerico.DataField = "nroCompAlfanumerico"
        Me.txtnroCompAlfanumerico.Height = 0.2!
        Me.txtnroCompAlfanumerico.Left = 2.390945!
        Me.txtnroCompAlfanumerico.Name = "txtnroCompAlfanumerico"
        Me.txtnroCompAlfanumerico.Style = "font-family: Microsoft Sans Serif; font-size: 8.25pt; ddo-char-set: 0"
        Me.txtnroCompAlfanumerico.Text = Nothing
        Me.txtnroCompAlfanumerico.Top = 0.2586614!
        Me.txtnroCompAlfanumerico.Width = 0.6149606!
        '
        'txtComprobante
        '
        Me.txtComprobante.DataField = "DescComp"
        Me.txtComprobante.Height = 0.2!
        Me.txtComprobante.Left = 0.6980315!
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.Style = "font-family: Microsoft Sans Serif; font-size: 8pt; text-align: right; ddo-char-se" &
    "t: 1"
        Me.txtComprobante.Text = "A-"
        Me.txtComprobante.Top = 0!
        Me.txtComprobante.Width = 0.3078741!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblPage, Me.txtPage, Me.Label7, Me.TextBox1, Me.lblPie})
        Me.PageFooter.Height = 0.2771654!
        Me.PageFooter.Name = "PageFooter"
        '
        'lblPage
        '
        Me.lblPage.Height = 0.2!
        Me.lblPage.HyperLink = Nothing
        Me.lblPage.Left = 5.348426!
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Style = ""
        Me.lblPage.Text = "Página"
        Me.lblPage.Top = 0!
        Me.lblPage.Width = 0.5838585!
        '
        'txtPage
        '
        Me.txtPage.Height = 0.2!
        Me.txtPage.Left = 5.994488!
        Me.txtPage.Name = "txtPage"
        Me.txtPage.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All
        Me.txtPage.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.txtPage.Text = "#"
        Me.txtPage.Top = 0!
        Me.txtPage.Width = 0.3027558!
        '
        'Label7
        '
        Me.Label7.Height = 0.2!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 6.297245!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = ""
        Me.Label7.Text = "de"
        Me.Label7.Top = 0!
        Me.Label7.Width = 0.2551181!
        '
        'TextBox1
        '
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 6.768111!
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
        Me.lblPie.Left = 0.1149606!
        Me.lblPie.Name = "lblPie"
        Me.lblPie.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.lblPie.Text = "pie"
        Me.lblPie.Top = 0.07716536!
        Me.lblPie.Width = 3.062599!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Picture1, Me.lblDireccion, Me.lblJoseGuma, Me.Shape1, Me.Label1, Me.Shape2, Me.Shape3, Me.Shape4, Me.Shape6, Me.Label2, Me.Label3, Me.Label4})
        Me.ReportHeader1.Height = 2.171162!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'Picture1
        '
        Me.Picture1.Height = 0.7582681!
        Me.Picture1.HyperLink = Nothing
        Me.Picture1.ImageBytes = CType(resources.GetObject("Picture1.ImageBytes"), Byte())
        Me.Picture1.Left = 0.1151571!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.Picture1.Top = 0!
        Me.Picture1.Width = 1.135039!
        '
        'lblDireccion
        '
        Me.lblDireccion.Height = 0.5582677!
        Me.lblDireccion.HyperLink = Nothing
        Me.lblDireccion.Left = 1.457677!
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
        Me.lblJoseGuma.Left = 1.457677!
        Me.lblJoseGuma.Name = "lblJoseGuma"
        Me.lblJoseGuma.Style = "font-size: 12pt; font-weight: bold"
        Me.lblJoseGuma.Text = "José Guma S.A."
        Me.lblJoseGuma.Top = 0!
        Me.lblJoseGuma.Width = 1.416535!
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape1.Height = 0.3543307!
        Me.Shape1.Left = 0.380315!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape1.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape1.Top = 0.8295276!
        Me.Shape1.Width = 6.764961!
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 1.655708!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-size: 12pt; font-weight: bold; text-align: center"
        Me.Label1.Text = "Comprobantes Pendientes de Pago"
        Me.Label1.Top = 0.906693!
        Me.Label1.Width = 4.239369!
        '
        'Shape2
        '
        Me.Shape2.Height = 0.7712599!
        Me.Shape2.Left = 0.1149606!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape2.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape2.Top = 1.356299!
        Me.Shape2.Width = 2.759055!
        '
        'Shape3
        '
        Me.Shape3.Height = 0.1874015!
        Me.Shape3.Left = 0.25!
        Me.Shape3.Name = "Shape3"
        Me.Shape3.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape3.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape3.Top = 1.419291!
        Me.Shape3.Width = 0.4480315!
        '
        'Shape4
        '
        Me.Shape4.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.Shape4.Height = 0.1874015!
        Me.Shape4.Left = 0.25!
        Me.Shape4.Name = "Shape4"
        Me.Shape4.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape4.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape4.Top = 1.653937!
        Me.Shape4.Width = 0.4480315!
        '
        'Shape6
        '
        Me.Shape6.BackColor = System.Drawing.Color.LimeGreen
        Me.Shape6.Height = 0.1874015!
        Me.Shape6.Left = 0.25!
        Me.Shape6.Name = "Shape6"
        Me.Shape6.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape6.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape6.Top = 1.904725!
        Me.Shape6.Width = 0.4480315!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.864567!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label2.Text = "Pendientes"
        Me.Label2.Top = 1.419291!
        Me.Label2.Width = 1.0!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.864567!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label3.Text = "No Autorizados"
        Me.Label3.Top = 1.65315!
        Me.Label3.Width = 1.301969!
        '
        'Label4
        '
        Me.Label4.Height = 0.2!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.864567!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label4.Text = "En elaboración de ord pago"
        Me.Label4.Top = 1.9!
        Me.Label4.Width = 1.885433!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape7, Me.Label14, Me.Label15, Me.Label16, Me.Line1, Me.Label17, Me.txtTotal, Me.txtTotalRemitos, Me.txtTotalNoAutorizado, Me.txtTotalSaldo, Me.Line3})
        Me.ReportFooter1.Height = 1.270833!
        Me.ReportFooter1.Name = "ReportFooter1"
        Me.ReportFooter1.NewPage = GrapeCity.ActiveReports.SectionReportModel.NewPage.Before
        '
        'Shape7
        '
        Me.Shape7.BackColor = System.Drawing.Color.Silver
        Me.Shape7.Height = 1.166929!
        Me.Shape7.Left = 4.318898!
        Me.Shape7.Name = "Shape7"
        Me.Shape7.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape7.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape7.Top = 0.06771654!
        Me.Shape7.Width = 2.759055!
        '
        'Label14
        '
        Me.Label14.Height = 0.2!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 4.509842!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "font-size: 8.25pt; font-weight: bold"
        Me.Label14.Text = "Listo para Pagar"
        Me.Label14.Top = 0.15!
        Me.Label14.Width = 0.9807086!
        '
        'Label15
        '
        Me.Label15.Height = 0.2!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 4.509843!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "font-size: 8.25pt; font-weight: bold"
        Me.Label15.Text = "Remitos"
        Me.Label15.Top = 0.4047244!
        Me.Label15.Width = 0.5818896!
        '
        'Label16
        '
        Me.Label16.Height = 0.2!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 4.465354!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "font-size: 8.25pt; font-weight: bold"
        Me.Label16.Text = "No Autorizados"
        Me.Label16.Top = 0.6751969!
        Me.Label16.Width = 0.9185033!
        '
        'Line1
        '
        Me.Line1.Height = 0!
        Me.Line1.Left = 4.465355!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.906693!
        Me.Line1.Width = 2.494094!
        Me.Line1.X1 = 4.465355!
        Me.Line1.X2 = 6.959449!
        Me.Line1.Y1 = 0.906693!
        Me.Line1.Y2 = 0.906693!
        '
        'Label17
        '
        Me.Label17.Height = 0.2!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 4.465355!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "font-size: 8.25pt; font-weight: bold"
        Me.Label17.Text = "Total Deuda"
        Me.Label17.Top = 0.9759844!
        Me.Label17.Width = 0.8228345!
        '
        'txtTotal
        '
        Me.txtTotal.Height = 0.2!
        Me.txtTotal.Left = 5.588976!
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Style = "font-size: 9pt; text-align: right; ddo-char-set: 1"
        Me.txtTotal.Text = "total"
        Me.txtTotal.Top = 0.138189!
        Me.txtTotal.Width = 1.301969!
        '
        'txtTotalRemitos
        '
        Me.txtTotalRemitos.Height = 0.2!
        Me.txtTotalRemitos.Left = 5.588977!
        Me.txtTotalRemitos.Name = "txtTotalRemitos"
        Me.txtTotalRemitos.Style = "font-size: 9pt; text-align: right; ddo-char-set: 1"
        Me.txtTotalRemitos.Text = "remitos"
        Me.txtTotalRemitos.Top = 0.4047244!
        Me.txtTotalRemitos.Width = 1.301969!
        '
        'txtTotalNoAutorizado
        '
        Me.txtTotalNoAutorizado.Height = 0.2!
        Me.txtTotalNoAutorizado.Left = 5.588976!
        Me.txtTotalNoAutorizado.Name = "txtTotalNoAutorizado"
        Me.txtTotalNoAutorizado.Style = "font-size: 9pt; text-align: right; ddo-char-set: 1"
        Me.txtTotalNoAutorizado.Text = "noautorizado"
        Me.txtTotalNoAutorizado.Top = 0.6791339!
        Me.txtTotalNoAutorizado.Width = 1.301969!
        '
        'txtTotalSaldo
        '
        Me.txtTotalSaldo.Height = 0.2!
        Me.txtTotalSaldo.Left = 5.588977!
        Me.txtTotalSaldo.Name = "txtTotalSaldo"
        Me.txtTotalSaldo.Style = "font-size: 9pt; text-align: right; ddo-char-set: 1"
        Me.txtTotalSaldo.Text = "totalsaldo"
        Me.txtTotalSaldo.Top = 0.9759844!
        Me.txtTotalSaldo.Width = 1.301969!
        '
        'Line3
        '
        Me.Line3.Height = 0!
        Me.Line3.Left = 0.1149606!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0!
        Me.Line3.Width = 7.030317!
        Me.Line3.X1 = 0.1149606!
        Me.Line3.X2 = 7.145278!
        Me.Line3.Y1 = 0!
        Me.Line3.Y2 = 0!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txtProveedor})
        Me.GroupHeader1.DataField = "proveedor"
        Me.GroupHeader1.Height = 0.1979167!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'txtProveedor
        '
        Me.txtProveedor.Height = 0.2!
        Me.txtProveedor.Left = 0.4574803!
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Text = "proveedor"
        Me.txtProveedor.Top = 0!
        Me.txtProveedor.Width = 4.997638!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Label13, Me.txtTotales, Me.Line2})
        Me.GroupFooter1.Height = 0.2625!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Label13
        '
        Me.Label13.Height = 0.2!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 4.890552!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label13.Text = "Totales"
        Me.Label13.Top = 0!
        Me.Label13.Width = 0.5645669!
        '
        'txtTotales
        '
        Me.txtTotales.Height = 0.2!
        Me.txtTotales.Left = 5.455119!
        Me.txtTotales.Name = "txtTotales"
        Me.txtTotales.Style = "font-size: 9.75pt; font-weight: bold; text-align: right"
        Me.txtTotales.SummaryGroup = "GroupHeader1"
        Me.txtTotales.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.txtTotales.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal
        Me.txtTotales.Text = "totales"
        Me.txtTotales.Top = 0!
        Me.txtTotales.Width = 1.615748!
        '
        'Line2
        '
        Me.Line2.Height = 0!
        Me.Line2.Left = 0.1149606!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0!
        Me.Line2.Width = 7.030315!
        Me.Line2.X1 = 0.1149606!
        Me.Line2.X2 = 7.145276!
        Me.Line2.Y1 = 0!
        Me.Line2.Y2 = 0!
        '
        'RptImpresoComprobantePendiente
        '
        Me.MasterReport = False
        Me.CompatibilityMode = GrapeCity.ActiveReports.Document.CompatibilityModes.CrossPlatform
        Me.PageSettings.Margins.Bottom = 0.3937008!
        Me.PageSettings.Margins.Left = 0.3937008!
        Me.PageSettings.Margins.Right = 0.3937008!
        Me.PageSettings.Margins.Top = 0.3937008!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.25!
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
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNroInterno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrefijo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaVto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtObservacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNroComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtnroCompAlfanumerico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalRemitos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalNoAutorizado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotales, System.ComponentModel.ISupportInitialize).EndInit()
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
    Private WithEvents Shape2 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Shape3 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Shape4 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Shape6 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Label2 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label3 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label4 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape5 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Label5 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label6 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label8 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label9 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label10 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label11 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label12 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtProveedor As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtNroInterno As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtPrefijo As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtDescPago As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtFechaComp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtFechaVto As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtObservacion As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtSaldo As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label13 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtTotales As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label14 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label15 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label16 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Line1 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Label17 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtTotal As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalRemitos As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalNoAutorizado As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalSaldo As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lblPage As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtPage As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label7 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lblPie As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtTipoComp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtNroComp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtnroCompAlfanumerico As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtComprobante As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Line2 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line3 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Shape7 As GrapeCity.ActiveReports.SectionReportModel.Shape
End Class
