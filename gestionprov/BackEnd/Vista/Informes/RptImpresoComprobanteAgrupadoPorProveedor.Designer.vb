<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class RptImpresoComprobanteAgrupadoPorProveedor
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptImpresoComprobanteAgrupadoPorProveedor))
        Me.PageHeader = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.lblNroInterno = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblProveedor = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblComprobante = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblFComp = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblFVto = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblImpProd = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblIVAProd = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblPerIva = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblPerGan = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblPerIB = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblImpNI = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblTotal = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Line1 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.txtCodInsumo = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtComprobante = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtFechaComp = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtFechaVto = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtFIP = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtIvaProd = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPerIVA = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPerGan = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPerIB = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtImpNI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotal = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtField9 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtNroProveedor = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTipoComp = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPrefijo = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtnroCompAlfanumerico = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.PageFooter = New GrapeCity.ActiveReports.SectionReportModel.PageFooter()
        Me.lblPage = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtPage = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label3 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblPie = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox8 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.ReportHeader1 = New GrapeCity.ActiveReports.SectionReportModel.ReportHeader()
        Me.lblJoseGuma = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblDireccion = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Shape1 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblTitulo = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Picture1 = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.lblFecha = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.ReportFooter1 = New GrapeCity.ActiveReports.SectionReportModel.ReportFooter()
        Me.GroupHeader1 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.Label1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtProveedorGroup = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox2 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupFooter1 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.Label2 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Shape2 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.txtTotalGeneral = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label4 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox3 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        CType(Me.lblNroInterno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFVto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblImpProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblIVAProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPerIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPerGan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPerIB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblImpNI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodInsumo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaVto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFIP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIvaProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPerIVA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPerGan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPerIB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImpNI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtField9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNroProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrefijo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtnroCompAlfanumerico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProveedorGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblNroInterno, Me.lblProveedor, Me.lblComprobante, Me.lblFComp, Me.lblFVto, Me.lblImpProd, Me.lblIVAProd, Me.lblPerIva, Me.lblPerGan, Me.lblPerIB, Me.lblImpNI, Me.lblTotal, Me.Line1})
        Me.PageHeader.Height = 0.3125!
        Me.PageHeader.Name = "PageHeader"
        '
        'lblNroInterno
        '
        Me.lblNroInterno.Height = 0.2!
        Me.lblNroInterno.HyperLink = Nothing
        Me.lblNroInterno.Left = 0.05866142!
        Me.lblNroInterno.Name = "lblNroInterno"
        Me.lblNroInterno.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblNroInterno.Text = "N° Interno"
        Me.lblNroInterno.Top = 0.05624998!
        Me.lblNroInterno.Width = 0.7814958!
        '
        'lblProveedor
        '
        Me.lblProveedor.Height = 0.2!
        Me.lblProveedor.HyperLink = Nothing
        Me.lblProveedor.Left = 9.439764!
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblProveedor.Text = "Proveedor"
        Me.lblProveedor.Top = 0.05624998!
        Me.lblProveedor.Width = 0.7393701!
        '
        'lblComprobante
        '
        Me.lblComprobante.Height = 0.2!
        Me.lblComprobante.HyperLink = Nothing
        Me.lblComprobante.Left = 0.9232284!
        Me.lblComprobante.Name = "lblComprobante"
        Me.lblComprobante.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblComprobante.Text = "Comprobante"
        Me.lblComprobante.Top = 0.05624998!
        Me.lblComprobante.Width = 0.958268!
        '
        'lblFComp
        '
        Me.lblFComp.Height = 0.2!
        Me.lblFComp.HyperLink = Nothing
        Me.lblFComp.Left = 2.096063!
        Me.lblFComp.Name = "lblFComp"
        Me.lblFComp.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblFComp.Text = "F. Comp"
        Me.lblFComp.Top = 0.05624998!
        Me.lblFComp.Width = 0.6708661!
        '
        'lblFVto
        '
        Me.lblFVto.Height = 0.2!
        Me.lblFVto.HyperLink = Nothing
        Me.lblFVto.Left = 2.819685!
        Me.lblFVto.Name = "lblFVto"
        Me.lblFVto.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblFVto.Text = "F.Vto"
        Me.lblFVto.Top = 0.05624998!
        Me.lblFVto.Width = 0.6043305!
        '
        'lblImpProd
        '
        Me.lblImpProd.Height = 0.2!
        Me.lblImpProd.HyperLink = Nothing
        Me.lblImpProd.Left = 3.527954!
        Me.lblImpProd.Name = "lblImpProd"
        Me.lblImpProd.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblImpProd.Text = "Imp.Prod"
        Me.lblImpProd.Top = 0.05624998!
        Me.lblImpProd.Width = 0.6562995!
        '
        'lblIVAProd
        '
        Me.lblIVAProd.Height = 0.2!
        Me.lblIVAProd.HyperLink = Nothing
        Me.lblIVAProd.Left = 4.414175!
        Me.lblIVAProd.Name = "lblIVAProd"
        Me.lblIVAProd.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblIVAProd.Text = "IVA Prod."
        Me.lblIVAProd.Top = 0.05624998!
        Me.lblIVAProd.Width = 0.6562995!
        '
        'lblPerIva
        '
        Me.lblPerIva.Height = 0.2!
        Me.lblPerIva.HyperLink = Nothing
        Me.lblPerIva.Left = 5.225984!
        Me.lblPerIva.Name = "lblPerIva"
        Me.lblPerIva.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblPerIva.Text = "Per. IVA"
        Me.lblPerIva.Top = 0.05624999!
        Me.lblPerIva.Width = 0.6562995!
        '
        'lblPerGan
        '
        Me.lblPerGan.Height = 0.2!
        Me.lblPerGan.HyperLink = Nothing
        Me.lblPerGan.Left = 6.063779!
        Me.lblPerGan.Name = "lblPerGan"
        Me.lblPerGan.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblPerGan.Text = "Per.Gan"
        Me.lblPerGan.Top = 0.05624998!
        Me.lblPerGan.Width = 0.6043304!
        '
        'lblPerIB
        '
        Me.lblPerIB.Height = 0.2!
        Me.lblPerIB.HyperLink = Nothing
        Me.lblPerIB.Left = 6.97441!
        Me.lblPerIB.Name = "lblPerIB"
        Me.lblPerIB.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblPerIB.Text = "Per.IB"
        Me.lblPerIB.Top = 0.05624998!
        Me.lblPerIB.Width = 0.53071!
        '
        'lblImpNI
        '
        Me.lblImpNI.Height = 0.2!
        Me.lblImpNI.HyperLink = Nothing
        Me.lblImpNI.Left = 7.630313!
        Me.lblImpNI.Name = "lblImpNI"
        Me.lblImpNI.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblImpNI.Text = "Imp.NI"
        Me.lblImpNI.Top = 0.05624998!
        Me.lblImpNI.Width = 0.5582685!
        '
        'lblTotal
        '
        Me.lblTotal.Height = 0.2!
        Me.lblTotal.HyperLink = Nothing
        Me.lblTotal.Left = 8.522049!
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblTotal.Text = "Total"
        Me.lblTotal.Top = 0.05624998!
        Me.lblTotal.Width = 0.4791335!
        '
        'Line1
        '
        Me.Line1.Height = 0.00004920363!
        Me.Line1.Left = 0!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.25625!
        Me.Line1.Width = 10.3437!
        Me.Line1.X1 = 0!
        Me.Line1.X2 = 10.3437!
        Me.Line1.Y1 = 0.25625!
        Me.Line1.Y2 = 0.2562992!
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txtCodInsumo, Me.txtComprobante, Me.txtFechaComp, Me.txtFechaVto, Me.txtFIP, Me.txtIvaProd, Me.txtPerIVA, Me.txtPerGan, Me.txtPerIB, Me.txtImpNI, Me.txtTotal, Me.txtField9, Me.txtNroProveedor, Me.txtTipoComp, Me.txtPrefijo, Me.txtnroCompAlfanumerico})
        Me.Detail.Height = 0.21875!
        Me.Detail.Name = "Detail"
        '
        'txtCodInsumo
        '
        Me.txtCodInsumo.DataField = "nrointerno"
        Me.txtCodInsumo.Height = 0.2!
        Me.txtCodInsumo.Left = 0!
        Me.txtCodInsumo.Name = "txtCodInsumo"
        Me.txtCodInsumo.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; ddo-char-set: 0"
        Me.txtCodInsumo.Text = "nrointerno"
        Me.txtCodInsumo.Top = 0!
        Me.txtCodInsumo.Width = 0.621259!
        '
        'txtComprobante
        '
        Me.txtComprobante.DataField = "DescComp"
        Me.txtComprobante.Height = 0.2!
        Me.txtComprobante.Left = 0.6248032!
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; ddo-char-set: 0"
        Me.txtComprobante.Text = "FP -A-"
        Me.txtComprobante.Top = 0!
        Me.txtComprobante.Width = 0.4342509!
        '
        'txtFechaComp
        '
        Me.txtFechaComp.DataField = "fechacomp"
        Me.txtFechaComp.Height = 0.2!
        Me.txtFechaComp.Left = 1.988582!
        Me.txtFechaComp.Name = "txtFechaComp"
        Me.txtFechaComp.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; ddo-char-set: 0"
        Me.txtFechaComp.Text = "fechacomp"
        Me.txtFechaComp.Top = 0!
        Me.txtFechaComp.Width = 0.5397636!
        '
        'txtFechaVto
        '
        Me.txtFechaVto.DataField = "fechavto"
        Me.txtFechaVto.Height = 0.2!
        Me.txtFechaVto.Left = 2.685433!
        Me.txtFechaVto.Name = "txtFechaVto"
        Me.txtFechaVto.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; ddo-char-set: 0"
        Me.txtFechaVto.Text = "fvto"
        Me.txtFechaVto.Top = 0!
        Me.txtFechaVto.Width = 0.6425185!
        '
        'txtFIP
        '
        Me.txtFIP.DataField = "importeprod"
        Me.txtFIP.Height = 0.2!
        Me.txtFIP.Left = 3.293307!
        Me.txtFIP.Name = "txtFIP"
        Me.txtFIP.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; text-align: right; ddo-char" &
    "-set: 0"
        Me.txtFIP.Text = "impprod"
        Me.txtFIP.Top = 0!
        Me.txtFIP.Width = 0.777559!
        '
        'txtIvaProd
        '
        Me.txtIvaProd.DataField = "ivaprod"
        Me.txtIvaProd.Height = 0.2!
        Me.txtIvaProd.Left = 4.288583!
        Me.txtIvaProd.Name = "txtIvaProd"
        Me.txtIvaProd.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; text-align: right; ddo-char" &
    "-set: 0"
        Me.txtIvaProd.Text = "ivaprod"
        Me.txtIvaProd.Top = 0!
        Me.txtIvaProd.Width = 0.6527547!
        '
        'txtPerIVA
        '
        Me.txtPerIVA.DataField = "percepiva"
        Me.txtPerIVA.Height = 0.2!
        Me.txtPerIVA.Left = 5.042912!
        Me.txtPerIVA.Name = "txtPerIVA"
        Me.txtPerIVA.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; text-align: right; ddo-char" &
    "-set: 0"
        Me.txtPerIVA.Text = "periva"
        Me.txtPerIVA.Top = 0!
        Me.txtPerIVA.Width = 0.6527554!
        '
        'txtPerGan
        '
        Me.txtPerGan.DataField = "percepgan"
        Me.txtPerGan.Height = 0.2!
        Me.txtPerGan.Left = 5.699214!
        Me.txtPerGan.Name = "txtPerGan"
        Me.txtPerGan.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; text-align: right; ddo-char" &
    "-set: 0"
        Me.txtPerGan.Text = "pergan"
        Me.txtPerGan.Top = 0!
        Me.txtPerGan.Width = 0.7673229!
        '
        'txtPerIB
        '
        Me.txtPerIB.DataField = "totalpercepib"
        Me.txtPerIB.Height = 0.2!
        Me.txtPerIB.Left = 6.546456!
        Me.txtPerIB.Name = "txtPerIB"
        Me.txtPerIB.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; text-align: right; ddo-char" &
    "-set: 0"
        Me.txtPerIB.Text = "perib"
        Me.txtPerIB.Top = 0!
        Me.txtPerIB.Width = 0.7673222!
        '
        'txtImpNI
        '
        Me.txtImpNI.DataField = "importenoimp"
        Me.txtImpNI.Height = 0.2!
        Me.txtImpNI.Left = 7.348826!
        Me.txtImpNI.Name = "txtImpNI"
        Me.txtImpNI.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; text-align: right; ddo-char" &
    "-set: 0"
        Me.txtImpNI.Text = "impni"
        Me.txtImpNI.Top = 0!
        Me.txtImpNI.Width = 0.6527547!
        '
        'txtTotal
        '
        Me.txtTotal.DataField = "totalcomprobante"
        Me.txtTotal.Height = 0.2!
        Me.txtTotal.Left = 8.244493!
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; text-align: right; ddo-char" &
    "-set: 0"
        Me.txtTotal.Text = "total"
        Me.txtTotal.Top = 0!
        Me.txtTotal.Width = 0.6527547!
        '
        'txtField9
        '
        Me.txtField9.DataField = "rsocial"
        Me.txtField9.Height = 0.2!
        Me.txtField9.Left = 9.359847!
        Me.txtField9.Name = "txtField9"
        Me.txtField9.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; ddo-char-set: 0"
        Me.txtField9.Text = "proveedor"
        Me.txtField9.Top = 0!
        Me.txtField9.Width = 1.767321!
        '
        'txtNroProveedor
        '
        Me.txtNroProveedor.DataField = "NroProveedor"
        Me.txtNroProveedor.Height = 0.2!
        Me.txtNroProveedor.Left = 9.05709!
        Me.txtNroProveedor.Name = "txtNroProveedor"
        Me.txtNroProveedor.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; ddo-char-set: 0"
        Me.txtNroProveedor.Text = "nro-"
        Me.txtNroProveedor.Top = 0!
        Me.txtNroProveedor.Width = 0.3822818!
        '
        'txtTipoComp
        '
        Me.txtTipoComp.DataField = "Tipocomp"
        Me.txtTipoComp.Height = 0.2!
        Me.txtTipoComp.Left = 1.312598!
        Me.txtTipoComp.Name = "txtTipoComp"
        Me.txtTipoComp.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; ddo-char-set: 0"
        Me.txtTipoComp.Text = Nothing
        Me.txtTipoComp.Top = 0.2917323!
        Me.txtTipoComp.Width = 0.6204714!
        '
        'txtPrefijo
        '
        Me.txtPrefijo.DataField = "nrocomp"
        Me.txtPrefijo.Height = 0.2!
        Me.txtPrefijo.Left = 0.993307!
        Me.txtPrefijo.Name = "txtPrefijo"
        Me.txtPrefijo.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; ddo-char-set: 0"
        Me.txtPrefijo.Text = "nrocomp"
        Me.txtPrefijo.Top = 0!
        Me.txtPrefijo.Width = 0.8570854!
        '
        'txtnroCompAlfanumerico
        '
        Me.txtnroCompAlfanumerico.DataField = "nroCompAlfanumerico"
        Me.txtnroCompAlfanumerico.Height = 0.2!
        Me.txtnroCompAlfanumerico.Left = 2.124409!
        Me.txtnroCompAlfanumerico.Name = "txtnroCompAlfanumerico"
        Me.txtnroCompAlfanumerico.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; ddo-char-set: 0"
        Me.txtnroCompAlfanumerico.Text = Nothing
        Me.txtnroCompAlfanumerico.Top = 0.2917323!
        Me.txtnroCompAlfanumerico.Width = 0.6114163!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblPage, Me.txtPage, Me.Label3, Me.lblPie, Me.TextBox8})
        Me.PageFooter.Height = 0.2291667!
        Me.PageFooter.Name = "PageFooter"
        '
        'lblPage
        '
        Me.lblPage.Height = 0.2!
        Me.lblPage.HyperLink = Nothing
        Me.lblPage.Left = 8.433859!
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.lblPage.Text = "Página"
        Me.lblPage.Top = 0!
        Me.lblPage.Width = 0.5838585!
        '
        'txtPage
        '
        Me.txtPage.Height = 0.2!
        Me.txtPage.Left = 9.153151!
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
        Me.Label3.Left = 9.559449!
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
        Me.lblPie.Left = 0.1271653!
        Me.lblPie.Name = "lblPie"
        Me.lblPie.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.lblPie.Text = "pie"
        Me.lblPie.Top = 0!
        Me.lblPie.Width = 3.062599!
        '
        'TextBox8
        '
        Me.TextBox8.Height = 0.2!
        Me.TextBox8.Left = 9.94488!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.TextBox8.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.TextBox8.Text = "##"
        Me.TextBox8.Top = 0!
        Me.TextBox8.Width = 0.3027558!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblJoseGuma, Me.lblDireccion, Me.Shape1, Me.lblTitulo, Me.Picture1, Me.lblFecha})
        Me.ReportHeader1.Height = 1.414567!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'lblJoseGuma
        '
        Me.lblJoseGuma.Height = 0.2!
        Me.lblJoseGuma.HyperLink = Nothing
        Me.lblJoseGuma.Left = 1.283218!
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
        Me.lblDireccion.Left = 1.266288!
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
        Me.Shape1.Left = 1.177165!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape1.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape1.Top = 0.8311022!
        Me.Shape1.Width = 7.975985!
        '
        'lblTitulo
        '
        Me.lblTitulo.Height = 0.2622046!
        Me.lblTitulo.HyperLink = Nothing
        Me.lblTitulo.Left = 3.111418!
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Style = "font-size: 12pt; font-weight: bold; text-align: center; ddo-char-set: 1"
        Me.lblTitulo.Text = "Resumen Comprobante Agrupado por Proveedor"
        Me.lblTitulo.Top = 0.8830709!
        Me.lblTitulo.Width = 4.871261!
        '
        'Picture1
        '
        Me.Picture1.Height = 0.7582681!
        Me.Picture1.HyperLink = Nothing
        Me.Picture1.ImageBytes = CType(resources.GetObject("Picture1.ImageBytes"), Byte())
        Me.Picture1.Left = 0.04227304!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.Picture1.Top = 0!
        Me.Picture1.Width = 1.135039!
        '
        'lblFecha
        '
        Me.lblFecha.Height = 0.2000002!
        Me.lblFecha.HyperLink = Nothing
        Me.lblFecha.Left = 3.370472!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "font-size: 10pt; text-align: center; ddo-char-set: 1"
        Me.lblFecha.Text = ""
        Me.lblFecha.Top = 1.145276!
        Me.lblFecha.Width = 4.37441!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Label1, Me.txtProveedorGroup, Me.TextBox2})
        Me.GroupHeader1.DataField = "NroProveedor"
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.1007876!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label1.Text = "Proveedor"
        Me.Label1.Top = 0!
        Me.Label1.Width = 0.7393701!
        '
        'txtProveedorGroup
        '
        Me.txtProveedorGroup.DataField = "rsocial"
        Me.txtProveedorGroup.Height = 0.2!
        Me.txtProveedorGroup.Left = 1.312598!
        Me.txtProveedorGroup.Name = "txtProveedorGroup"
        Me.txtProveedorGroup.Style = "font-family: Microsoft Sans Serif; font-size: 8.25pt; font-weight: bold; ddo-char" &
    "-set: 0"
        Me.txtProveedorGroup.Text = "proveedor"
        Me.txtProveedorGroup.Top = 0!
        Me.txtProveedorGroup.Width = 3.465355!
        '
        'TextBox2
        '
        Me.TextBox2.DataField = "NroProveedor"
        Me.TextBox2.Height = 0.2!
        Me.TextBox2.Left = 0.8838582!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "font-family: Microsoft Sans Serif; font-size: 8.25pt; font-weight: bold; ddo-char" &
    "-set: 0"
        Me.TextBox2.Text = "nro-"
        Me.TextBox2.Top = 0!
        Me.TextBox2.Width = 0.3822818!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.BackColor = System.Drawing.Color.Silver
        Me.GroupFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Label2, Me.Shape2, Me.txtTotalGeneral, Me.Label4, Me.TextBox1, Me.TextBox3})
        Me.GroupFooter1.Height = 0.2708333!
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.NewColumn = GrapeCity.ActiveReports.SectionReportModel.NewColumn.Before
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 1.728347!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label2.Text = "Proveedor"
        Me.Label2.Top = 0!
        Me.Label2.Width = 0.7393701!
        '
        'Shape2
        '
        Me.Shape2.Height = 0.2248031!
        Me.Shape2.Left = 6.535827!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape2.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape2.Top = 0!
        Me.Shape2.Width = 2.773622!
        '
        'txtTotalGeneral
        '
        Me.txtTotalGeneral.Height = 0.2!
        Me.txtTotalGeneral.Left = 7.823623!
        Me.txtTotalGeneral.Name = "txtTotalGeneral"
        Me.txtTotalGeneral.Style = "font-size: 9.75pt; font-weight: bold; text-align: right"
        Me.txtTotalGeneral.Text = "total"
        Me.txtTotalGeneral.Top = 0.02480315!
        Me.txtTotalGeneral.Width = 1.433859!
        '
        'Label4
        '
        Me.Label4.Height = 0.2!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 6.650395!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "font-size: 9.75pt; font-weight: bold"
        Me.Label4.Text = "Total"
        Me.Label4.Top = 0.02480315!
        Me.Label4.Width = 0.7393701!
        '
        'TextBox1
        '
        Me.TextBox1.DataField = "rsocial"
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 3.001181!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "font-family: Microsoft Sans Serif; font-size: 8.25pt; font-weight: bold; ddo-char" &
    "-set: 0"
        Me.TextBox1.Text = "proveedor"
        Me.TextBox1.Top = 0!
        Me.TextBox1.Width = 3.465355!
        '
        'TextBox3
        '
        Me.TextBox3.DataField = "NroProveedor"
        Me.TextBox3.Height = 0.2!
        Me.TextBox3.Left = 2.572441!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "font-family: Microsoft Sans Serif; font-size: 8.25pt; font-weight: bold; ddo-char" &
    "-set: 0"
        Me.TextBox3.Text = "nro-"
        Me.TextBox3.Top = 0!
        Me.TextBox3.Width = 0.3822818!
        '
        'RptImpresoComprobanteAgrupadoPorProveedor
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
        Me.PrintWidth = 10.375!
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
        CType(Me.lblProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFVto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblImpProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblIVAProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPerIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPerGan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPerIB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblImpNI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodInsumo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaVto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFIP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIvaProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPerIVA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPerGan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPerIB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImpNI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtField9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNroProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrefijo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtnroCompAlfanumerico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblJoseGuma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProveedorGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private WithEvents ReportHeader1 As GrapeCity.ActiveReports.SectionReportModel.ReportHeader
    Private WithEvents ReportFooter1 As GrapeCity.ActiveReports.SectionReportModel.ReportFooter
    Private WithEvents GroupHeader1 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GroupFooter1 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents lblJoseGuma As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblDireccion As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape1 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblTitulo As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Picture1 As GrapeCity.ActiveReports.SectionReportModel.Picture
    Public WithEvents lblFecha As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblNroInterno As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblProveedor As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblComprobante As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblFComp As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblFVto As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblImpProd As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblIVAProd As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblPerIva As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblPerGan As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblPerIB As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblImpNI As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblTotal As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Line1 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents txtCodInsumo As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtComprobante As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtFechaComp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtFechaVto As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtFIP As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtIvaProd As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtPerIVA As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtPerGan As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtPerIB As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtImpNI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotal As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtField9 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtNroProveedor As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTipoComp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtPrefijo As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtnroCompAlfanumerico As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label1 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtProveedorGroup As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lblPage As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtPage As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label3 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblPie As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox8 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label2 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape2 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents txtTotalGeneral As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label4 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox2 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox3 As GrapeCity.ActiveReports.SectionReportModel.TextBox
End Class
