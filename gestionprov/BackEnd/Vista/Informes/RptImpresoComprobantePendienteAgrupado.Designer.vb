<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class RptImpresoComprobantePendienteAgrupado
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptImpresoComprobantePendienteAgrupado))
        Me.PageHeader = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.Shape7 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Label6 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label7 = New GrapeCity.ActiveReports.SectionReportModel.Label()
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
        Me.Label14 = New GrapeCity.ActiveReports.SectionReportModel.Label()
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
        Me.Label5 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Shape5 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.ReportFooter1 = New GrapeCity.ActiveReports.SectionReportModel.ReportFooter()
        Me.Shape8 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Label15 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label16 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label17 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Line1 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Label18 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtTotal = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalRemitos = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalNoAutorizado = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalSaldo = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line3 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Shape9 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Label19 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TxtDetalleInsumos = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupHeader1 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.txtProveedor = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupFooter1 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.Label13 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtTotales = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line2 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.GroupHeader2 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.Shape10 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.TxtInsumoProvisto = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupFooter2 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.lblTotalInsumo = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalInsumo = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalRemitos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalNoAutorizado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDetalleInsumos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtInsumoProvisto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalInsumo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalInsumo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape7, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.Label12})
        Me.PageHeader.Height = 0.375!
        Me.PageHeader.Name = "PageHeader"
        '
        'Shape7
        '
        Me.Shape7.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape7.Height = 0.3543307!
        Me.Shape7.Left = 0.1827605!
        Me.Shape7.Name = "Shape7"
        Me.Shape7.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape7.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape7.Top = 0.01033466!
        Me.Shape7.Width = 7.030313!
        '
        'Label6
        '
        Me.Label6.Height = 0.2!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.3615007!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label6.Text = "N° Interno"
        Me.Label6.Top = 0.08238188!
        Me.Label6.Width = 0.7645674!
        '
        'Label7
        '
        Me.Label7.Height = 0.2!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 1.242997!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label7.Text = "Comprobante"
        Me.Label7.Top = 0.08238188!
        Me.Label7.Width = 0.9913388!
        '
        'Label8
        '
        Me.Label8.Height = 0.2!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 2.49221!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label8.Text = "Tipo"
        Me.Label8.Top = 0.08238188!
        Me.Label8.Width = 0.4496064!
        '
        'Label9
        '
        Me.Label9.Height = 0.2!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 4.048114!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label9.Text = "Fecha"
        Me.Label9.Top = 0.08238188!
        Me.Label9.Width = 0.4496064!
        '
        'Label10
        '
        Me.Label10.Height = 0.2!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 4.737485!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label10.Text = "F. Vto."
        Me.Label10.Top = 0.08238188!
        Me.Label10.Width = 0.5098422!
        '
        'Label11
        '
        Me.Label11.Height = 0.2!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 5.320557!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label11.Text = "Observación"
        Me.Label11.Top = 0.08238188!
        Me.Label11.Width = 0.9381889!
        '
        'Label12
        '
        Me.Label12.Height = 0.2!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 6.427249!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label12.Text = "Saldo"
        Me.Label12.Top = 0.08238188!
        Me.Label12.Width = 0.5645669!
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txtNroInterno, Me.txtPrefijo, Me.txtDescPago, Me.txtFechaComp, Me.txtFechaVto, Me.txtObservacion, Me.txtSaldo, Me.txtTipoComp, Me.txtNroComp, Me.txtnroCompAlfanumerico, Me.txtComprobante})
        Me.Detail.Height = 0.2112041!
        Me.Detail.Name = "Detail"
        '
        'txtNroInterno
        '
        Me.txtNroInterno.DataField = "nrointerno"
        Me.txtNroInterno.Height = 0.1921261!
        Me.txtNroInterno.Left = 0.1708661!
        Me.txtNroInterno.Name = "txtNroInterno"
        Me.txtNroInterno.Style = "font-family: Microsoft Sans Serif; font-size: 7.5pt; text-align: center; ddo-char" &
    "-set: 1"
        Me.txtNroInterno.Text = "nrointerno"
        Me.txtNroInterno.Top = 0!
        Me.txtNroInterno.Width = 0.6149606!
        '
        'txtPrefijo
        '
        Me.txtPrefijo.DataField = "nrocomp"
        Me.txtPrefijo.Height = 0.1921261!
        Me.txtPrefijo.Left = 1.137796!
        Me.txtPrefijo.Name = "txtPrefijo"
        Me.txtPrefijo.Style = "font-family: Microsoft Sans Serif; font-size: 7.5pt; text-align: left; ddo-char-s" &
    "et: 1"
        Me.txtPrefijo.Text = "nrocomp"
        Me.txtPrefijo.Top = 0!
        Me.txtPrefijo.Width = 1.161417!
        '
        'txtDescPago
        '
        Me.txtDescPago.CanGrow = False
        Me.txtDescPago.Height = 0.1653543!
        Me.txtDescPago.Left = 2.298425!
        Me.txtDescPago.Name = "txtDescPago"
        Me.txtDescPago.Style = "font-family: Microsoft Sans Serif; font-size: 7.5pt; text-align: left; ddo-char-s" &
    "et: 1"
        Me.txtDescPago.Text = "tipo"
        Me.txtDescPago.Top = 0!
        Me.txtDescPago.Width = 1.61063!
        '
        'txtFechaComp
        '
        Me.txtFechaComp.DataField = "fechacomp"
        Me.txtFechaComp.Height = 0.1921261!
        Me.txtFechaComp.Left = 3.960631!
        Me.txtFechaComp.Name = "txtFechaComp"
        Me.txtFechaComp.Style = "font-family: Microsoft Sans Serif; font-size: 7.5pt; ddo-char-set: 1"
        Me.txtFechaComp.Text = "fechacomp"
        Me.txtFechaComp.Top = 0!
        Me.txtFechaComp.Width = 0.6452755!
        '
        'txtFechaVto
        '
        Me.txtFechaVto.DataField = "fechavto"
        Me.txtFechaVto.Height = 0.1921261!
        Me.txtFechaVto.Left = 4.689764!
        Me.txtFechaVto.Name = "txtFechaVto"
        Me.txtFechaVto.Style = "font-family: Microsoft Sans Serif; font-size: 7.5pt; ddo-char-set: 1"
        Me.txtFechaVto.Text = "fvto"
        Me.txtFechaVto.Top = 0!
        Me.txtFechaVto.Width = 0.6425185!
        '
        'txtObservacion
        '
        Me.txtObservacion.Height = 0.1921261!
        Me.txtObservacion.Left = 5.427952!
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Style = "font-family: Microsoft Sans Serif; font-size: 7.5pt; ddo-char-set: 1"
        Me.txtObservacion.Text = Nothing
        Me.txtObservacion.Top = 0!
        Me.txtObservacion.Width = 0.6460623!
        '
        'txtSaldo
        '
        Me.txtSaldo.Height = 0.1921261!
        Me.txtSaldo.Left = 6.037402!
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Style = "font-family: Microsoft Sans Serif; font-size: 7.5pt; text-align: right; ddo-char-" &
    "set: 1"
        Me.txtSaldo.Text = "saldo"
        Me.txtSaldo.Top = 0!
        Me.txtSaldo.Width = 1.187402!
        '
        'txtTipoComp
        '
        Me.txtTipoComp.DataField = "Tipocomp"
        Me.txtTipoComp.Height = 0.1921261!
        Me.txtTipoComp.Left = 0.6551183!
        Me.txtTipoComp.Name = "txtTipoComp"
        Me.txtTipoComp.Style = "font-family: Microsoft Sans Serif; font-size: 7.5pt; ddo-char-set: 1"
        Me.txtTipoComp.Text = Nothing
        Me.txtTipoComp.Top = 0.2586613!
        Me.txtTipoComp.Width = 0.8543305!
        '
        'txtNroComp
        '
        Me.txtNroComp.DataField = "nroComp"
        Me.txtNroComp.Height = 0.1921261!
        Me.txtNroComp.Left = 1.631102!
        Me.txtNroComp.Name = "txtNroComp"
        Me.txtNroComp.Style = "font-family: Microsoft Sans Serif; font-size: 7.5pt; ddo-char-set: 1"
        Me.txtNroComp.Text = Nothing
        Me.txtNroComp.Top = 0.2586613!
        Me.txtNroComp.Width = 0.6149606!
        '
        'txtnroCompAlfanumerico
        '
        Me.txtnroCompAlfanumerico.DataField = "nroCompAlfanumerico"
        Me.txtnroCompAlfanumerico.Height = 0.1921261!
        Me.txtnroCompAlfanumerico.Left = 2.470473!
        Me.txtnroCompAlfanumerico.Name = "txtnroCompAlfanumerico"
        Me.txtnroCompAlfanumerico.Style = "font-family: Microsoft Sans Serif; font-size: 7.5pt; ddo-char-set: 1"
        Me.txtnroCompAlfanumerico.Text = Nothing
        Me.txtnroCompAlfanumerico.Top = 0.2586613!
        Me.txtnroCompAlfanumerico.Width = 0.6149606!
        '
        'txtComprobante
        '
        Me.txtComprobante.DataField = "DescComp"
        Me.txtComprobante.Height = 0.1921261!
        Me.txtComprobante.Left = 0.7775587!
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.Style = "font-family: Microsoft Sans Serif; font-size: 7.5pt; text-align: right; ddo-char-" &
    "set: 1"
        Me.txtComprobante.Text = "A-"
        Me.txtComprobante.Top = 0!
        Me.txtComprobante.Width = 0.3078741!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblPage, Me.txtPage, Me.Label14, Me.TextBox1, Me.lblPie})
        Me.PageFooter.Height = 0.2042487!
        Me.PageFooter.Name = "PageFooter"
        '
        'lblPage
        '
        Me.lblPage.Height = 0.2!
        Me.lblPage.HyperLink = Nothing
        Me.lblPage.Left = 5.453544!
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Style = ""
        Me.lblPage.Text = "Página"
        Me.lblPage.Top = 0!
        Me.lblPage.Width = 0.5838585!
        '
        'txtPage
        '
        Me.txtPage.Height = 0.2!
        Me.txtPage.Left = 6.099607!
        Me.txtPage.Name = "txtPage"
        Me.txtPage.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All
        Me.txtPage.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.txtPage.Text = "#"
        Me.txtPage.Top = 0!
        Me.txtPage.Width = 0.3027558!
        '
        'Label14
        '
        Me.Label14.Height = 0.2!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 6.402363!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = ""
        Me.Label14.Text = "de"
        Me.Label14.Top = 0!
        Me.Label14.Width = 0.2551181!
        '
        'TextBox1
        '
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 6.873229!
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
        Me.lblPie.Left = 0.2200788!
        Me.lblPie.Name = "lblPie"
        Me.lblPie.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.lblPie.Text = "pie"
        Me.lblPie.Top = 0!
        Me.lblPie.Width = 3.062599!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Picture1, Me.lblDireccion, Me.lblJoseGuma, Me.Shape1, Me.Label1, Me.Shape2, Me.Shape3, Me.Shape4, Me.Shape6, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.Shape5})
        Me.ReportHeader1.Height = 2.398392!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'Picture1
        '
        Me.Picture1.Height = 0.7582681!
        Me.Picture1.HyperLink = Nothing
        Me.Picture1.ImageBytes = CType(resources.GetObject("Picture1.ImageBytes"), Byte())
        Me.Picture1.Left = 0.1829555!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.Picture1.Top = 0!
        Me.Picture1.Width = 1.135039!
        '
        'lblDireccion
        '
        Me.lblDireccion.Height = 0.5582677!
        Me.lblDireccion.HyperLink = Nothing
        Me.lblDireccion.Left = 1.525475!
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
        Me.lblJoseGuma.Left = 1.525475!
        Me.lblJoseGuma.Name = "lblJoseGuma"
        Me.lblJoseGuma.Style = "font-size: 12pt; font-weight: bold"
        Me.lblJoseGuma.Text = "José Guma S.A."
        Me.lblJoseGuma.Top = 0!
        Me.lblJoseGuma.Width = 1.416535!
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape1.Height = 0.3917322!
        Me.Shape1.Left = 0.4481134!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape1.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape1.Top = 0.8295278!
        Me.Shape1.Width = 6.764961!
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 1.723506!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-size: 12pt; font-weight: bold; text-align: center"
        Me.Label1.Text = "Comprobantes Pendientes de Pago Agrupado"
        Me.Label1.Top = 0.906693!
        Me.Label1.Width = 4.239369!
        '
        'Shape2
        '
        Me.Shape2.Height = 1.01063!
        Me.Shape2.Left = 0.1708661!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape2.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape2.Top = 1.288583!
        Me.Shape2.Width = 2.759055!
        '
        'Shape3
        '
        Me.Shape3.Height = 0.1874015!
        Me.Shape3.Left = 0.3059055!
        Me.Shape3.Name = "Shape3"
        Me.Shape3.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape3.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape3.Top = 1.351575!
        Me.Shape3.Width = 0.4480315!
        '
        'Shape4
        '
        Me.Shape4.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.Shape4.Height = 0.1874015!
        Me.Shape4.Left = 0.3059055!
        Me.Shape4.Name = "Shape4"
        Me.Shape4.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape4.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape4.Top = 1.57441!
        Me.Shape4.Width = 0.4480315!
        '
        'Shape6
        '
        Me.Shape6.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Shape6.Height = 0.1874015!
        Me.Shape6.Left = 0.3059055!
        Me.Shape6.Name = "Shape6"
        Me.Shape6.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape6.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape6.Top = 1.833071!
        Me.Shape6.Width = 0.4480315!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.9204721!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label2.Text = "Pendientes"
        Me.Label2.Top = 1.351575!
        Me.Label2.Width = 1.0!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.9204721!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label3.Text = "No Autorizados"
        Me.Label3.Top = 1.585434!
        Me.Label3.Width = 1.301969!
        '
        'Label4
        '
        Me.Label4.Height = 0.2!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.9204721!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label4.Text = "En elaboración de ord pago"
        Me.Label4.Top = 1.832284!
        Me.Label4.Width = 1.885433!
        '
        'Label5
        '
        Me.Label5.Height = 0.2!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.9204725!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label5.Text = "Facturas Bloqueadas"
        Me.Label5.Top = 2.051969!
        Me.Label5.Width = 1.885433!
        '
        'Shape5
        '
        Me.Shape5.BackColor = System.Drawing.Color.LightCoral
        Me.Shape5.Height = 0.1874015!
        Me.Shape5.Left = 0.3059055!
        Me.Shape5.Name = "Shape5"
        Me.Shape5.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape5.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape5.Top = 2.080315!
        Me.Shape5.Width = 0.4480315!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape8, Me.Label15, Me.Label16, Me.Label17, Me.Line1, Me.Label18, Me.txtTotal, Me.txtTotalRemitos, Me.txtTotalNoAutorizado, Me.txtTotalSaldo, Me.Line3, Me.Shape9, Me.Label19, Me.TxtDetalleInsumos})
        Me.ReportFooter1.Height = 2.135417!
        Me.ReportFooter1.Name = "ReportFooter1"
        Me.ReportFooter1.NewPage = GrapeCity.ActiveReports.SectionReportModel.NewPage.Before
        '
        'Shape8
        '
        Me.Shape8.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Shape8.Height = 1.166929!
        Me.Shape8.Left = 4.386614!
        Me.Shape8.Name = "Shape8"
        Me.Shape8.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape8.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape8.Top = 0.04015747!
        Me.Shape8.Width = 2.759055!
        '
        'Label15
        '
        Me.Label15.Height = 0.2!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 4.577559!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "font-size: 8.25pt; font-weight: bold"
        Me.Label15.Text = "Listo para Pagar"
        Me.Label15.Top = 0.1224409!
        Me.Label15.Width = 0.9807083!
        '
        'Label16
        '
        Me.Label16.Height = 0.2!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 4.577559!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "font-size: 8.25pt; font-weight: bold"
        Me.Label16.Text = "Remitos"
        Me.Label16.Top = 0.3771653!
        Me.Label16.Width = 0.5818896!
        '
        'Label17
        '
        Me.Label17.Height = 0.2!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 4.533072!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "font-size: 8.25pt; font-weight: bold"
        Me.Label17.Text = "No Autorizados"
        Me.Label17.Top = 0.6476378!
        Me.Label17.Width = 0.9185035!
        '
        'Line1
        '
        Me.Line1.Height = 0!
        Me.Line1.Left = 4.533072!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.8791339!
        Me.Line1.Width = 2.494096!
        Me.Line1.X1 = 4.533072!
        Me.Line1.X2 = 7.027168!
        Me.Line1.Y1 = 0.8791339!
        Me.Line1.Y2 = 0.8791339!
        '
        'Label18
        '
        Me.Label18.Height = 0.2!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 4.533072!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "font-size: 8.25pt; font-weight: bold"
        Me.Label18.Text = "Total Deuda"
        Me.Label18.Top = 0.9484249!
        Me.Label18.Width = 0.8228347!
        '
        'txtTotal
        '
        Me.txtTotal.Height = 0.2!
        Me.txtTotal.Left = 5.656693!
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Style = "font-size: 9pt; text-align: right; ddo-char-set: 1"
        Me.txtTotal.Text = "total"
        Me.txtTotal.Top = 0.1106299!
        Me.txtTotal.Width = 1.301969!
        '
        'txtTotalRemitos
        '
        Me.txtTotalRemitos.Height = 0.2!
        Me.txtTotalRemitos.Left = 5.656693!
        Me.txtTotalRemitos.Name = "txtTotalRemitos"
        Me.txtTotalRemitos.Style = "font-size: 9pt; text-align: right; ddo-char-set: 1"
        Me.txtTotalRemitos.Text = "remitos"
        Me.txtTotalRemitos.Top = 0.3771653!
        Me.txtTotalRemitos.Width = 1.301969!
        '
        'txtTotalNoAutorizado
        '
        Me.txtTotalNoAutorizado.Height = 0.2!
        Me.txtTotalNoAutorizado.Left = 5.656693!
        Me.txtTotalNoAutorizado.Name = "txtTotalNoAutorizado"
        Me.txtTotalNoAutorizado.Style = "font-size: 9pt; text-align: right; ddo-char-set: 1"
        Me.txtTotalNoAutorizado.Text = "noautorizado"
        Me.txtTotalNoAutorizado.Top = 0.651575!
        Me.txtTotalNoAutorizado.Width = 1.301969!
        '
        'txtTotalSaldo
        '
        Me.txtTotalSaldo.Height = 0.2!
        Me.txtTotalSaldo.Left = 5.656693!
        Me.txtTotalSaldo.Name = "txtTotalSaldo"
        Me.txtTotalSaldo.Style = "font-size: 9pt; text-align: right; ddo-char-set: 1"
        Me.txtTotalSaldo.Text = "totalsaldo"
        Me.txtTotalSaldo.Top = 0.9484249!
        Me.txtTotalSaldo.Width = 1.301969!
        '
        'Line3
        '
        Me.Line3.Height = 0!
        Me.Line3.Left = 0.182677!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0!
        Me.Line3.Width = 7.030318!
        Me.Line3.X1 = 0.182677!
        Me.Line3.X2 = 7.212995!
        Me.Line3.Y1 = 0!
        Me.Line3.Y2 = 0!
        '
        'Shape9
        '
        Me.Shape9.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Shape9.Height = 0.2708662!
        Me.Shape9.Left = 1.525591!
        Me.Shape9.Name = "Shape9"
        Me.Shape9.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape9.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape9.Top = 1.407874!
        Me.Shape9.Width = 4.072835!
        '
        'Label19
        '
        Me.Label19.Height = 0.2!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 2.246063!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "font-size: 10pt; font-weight: bold; text-align: center"
        Me.Label19.Text = "Detalle por Tipo Insumo Provisto"
        Me.Label19.Top = 1.447244!
        Me.Label19.Width = 2.650787!
        '
        'TxtDetalleInsumos
        '
        Me.TxtDetalleInsumos.Height = 0.2397474!
        Me.TxtDetalleInsumos.Left = 1.137795!
        Me.TxtDetalleInsumos.Name = "TxtDetalleInsumos"
        Me.TxtDetalleInsumos.Style = "font-size: 11pt; ddo-char-set: 1"
        Me.TxtDetalleInsumos.Text = Nothing
        Me.TxtDetalleInsumos.Top = 1.839764!
        Me.TxtDetalleInsumos.Width = 4.653543!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txtProveedor})
        Me.GroupHeader1.DataField = "proveedor"
        Me.GroupHeader1.GroupKeepTogether = GrapeCity.ActiveReports.SectionReportModel.GroupKeepTogether.All
        Me.GroupHeader1.Height = 0.2083333!
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.NewColumn = GrapeCity.ActiveReports.SectionReportModel.NewColumn.Before
        '
        'txtProveedor
        '
        Me.txtProveedor.Height = 0.2!
        Me.txtProveedor.Left = 0.1830709!
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Text = "proveedor"
        Me.txtProveedor.Top = 0!
        Me.txtProveedor.Width = 4.997638!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Label13, Me.txtTotales, Me.Line2})
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Label13
        '
        Me.Label13.Height = 0.2!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 4.422048!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 1"
        Me.Label13.Text = "Totales"
        Me.Label13.Top = 0.02480315!
        Me.Label13.Width = 1.136303!
        '
        'txtTotales
        '
        Me.txtTotales.Height = 0.2!
        Me.txtTotales.Left = 5.489764!
        Me.txtTotales.Name = "txtTotales"
        Me.txtTotales.Style = "font-size: 9.75pt; font-weight: bold; text-align: right"
        Me.txtTotales.SummaryGroup = "GroupHeader1"
        Me.txtTotales.Text = "totales"
        Me.txtTotales.Top = 0.05!
        Me.txtTotales.Width = 1.782759!
        '
        'Line2
        '
        Me.Line2.Height = 0!
        Me.Line2.Left = 0.1827581!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.025!
        Me.Line2.Width = 7.030318!
        Me.Line2.X1 = 0.1827581!
        Me.Line2.X2 = 7.213076!
        Me.Line2.Y1 = 0.025!
        Me.Line2.Y2 = 0.025!
        '
        'GroupHeader2
        '
        Me.GroupHeader2.ColumnGroupKeepTogether = True
        Me.GroupHeader2.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape10, Me.TxtInsumoProvisto})
        Me.GroupHeader2.DataField = "codinsumoprovisto"
        Me.GroupHeader2.Name = "GroupHeader2"
        Me.GroupHeader2.NewColumn = GrapeCity.ActiveReports.SectionReportModel.NewColumn.Before
        '
        'Shape10
        '
        Me.Shape10.Height = 0.21875!
        Me.Shape10.Left = 0.2083333!
        Me.Shape10.Name = "Shape10"
        Me.Shape10.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape10.Top = 0.03125!
        Me.Shape10.Width = 6.9375!
        '
        'TxtInsumoProvisto
        '
        Me.TxtInsumoProvisto.DataField = "insumoProvisto"
        Me.TxtInsumoProvisto.Height = 0.2!
        Me.TxtInsumoProvisto.Left = 0.2429134!
        Me.TxtInsumoProvisto.Name = "TxtInsumoProvisto"
        Me.TxtInsumoProvisto.Text = "TextBox2"
        Me.TxtInsumoProvisto.Top = 0!
        Me.TxtInsumoProvisto.Width = 3.43189!
        '
        'GroupFooter2
        '
        Me.GroupFooter2.BackColor = System.Drawing.Color.Silver
        Me.GroupFooter2.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblTotalInsumo, Me.txtTotalInsumo})
        Me.GroupFooter2.Height = 0.2083333!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'lblTotalInsumo
        '
        Me.lblTotalInsumo.Height = 0.2!
        Me.lblTotalInsumo.Left = 2.411024!
        Me.lblTotalInsumo.Name = "lblTotalInsumo"
        Me.lblTotalInsumo.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 1"
        Me.lblTotalInsumo.SummaryGroup = "GroupHeader1"
        Me.lblTotalInsumo.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.lblTotalInsumo.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal
        Me.lblTotalInsumo.Text = "totales"
        Me.lblTotalInsumo.Top = 0!
        Me.lblTotalInsumo.Width = 2.485826!
        '
        'txtTotalInsumo
        '
        Me.txtTotalInsumo.Height = 0.2!
        Me.txtTotalInsumo.Left = 5.332284!
        Me.txtTotalInsumo.Name = "txtTotalInsumo"
        Me.txtTotalInsumo.Style = "font-size: 9.75pt; font-weight: bold; text-align: right"
        Me.txtTotalInsumo.SummaryGroup = "GroupHeader1"
        Me.txtTotalInsumo.Text = "totales"
        Me.txtTotalInsumo.Top = 0.008267717!
        Me.txtTotalInsumo.Width = 1.940157!
        '
        'RptImpresoComprobantePendienteAgrupado
        '
        Me.MasterReport = False
        Me.CompatibilityMode = GrapeCity.ActiveReports.Document.CompatibilityModes.CrossPlatform
        Me.PageSettings.Margins.Bottom = 0.3937008!
        Me.PageSettings.Margins.Left = 0.3937008!
        Me.PageSettings.Margins.Right = 0.3937008!
        Me.PageSettings.Margins.Top = 0.3937008!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.395833!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.PageFooter)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" &
            "l; font-size: 10pt; color: Black; ddo-char-set: 204", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" &
            "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalRemitos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalNoAutorizado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDetalleInsumos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtInsumoProvisto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalInsumo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalInsumo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private WithEvents ReportHeader1 As GrapeCity.ActiveReports.SectionReportModel.ReportHeader
    Private WithEvents ReportFooter1 As GrapeCity.ActiveReports.SectionReportModel.ReportFooter
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
    Private WithEvents GroupHeader1 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GroupFooter1 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents Label5 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape5 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Shape7 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Label6 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label7 As GrapeCity.ActiveReports.SectionReportModel.Label
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
    Private WithEvents txtTipoComp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtNroComp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtnroCompAlfanumerico As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtComprobante As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label13 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtTotales As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Line2 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents lblPage As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtPage As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label14 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lblPie As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape8 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Label15 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label16 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label17 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Line1 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Label18 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtTotal As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalRemitos As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalNoAutorizado As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalSaldo As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Line3 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents GroupHeader2 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GroupFooter2 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents Shape9 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Label19 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape10 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents TxtInsumoProvisto As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lblTotalInsumo As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalInsumo As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TxtDetalleInsumos As GrapeCity.ActiveReports.SectionReportModel.TextBox
End Class
