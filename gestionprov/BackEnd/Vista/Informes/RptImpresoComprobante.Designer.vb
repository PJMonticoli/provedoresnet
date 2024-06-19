<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class RptImpresoComprobante
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptImpresoComprobante))
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
        Me.Line2 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Shape3 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblTotales = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtImpProd = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalIvaProd = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalPerIva = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalPerGan = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalPerIB = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalImpNI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalGrl = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Shape4 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.txtTotalCredIntGuma = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label2 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label4 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label5 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label6 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label7 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtTotalDebIntGuma = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalCredNoIntGuma = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalDebNoIntNoGuma = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalCred = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalDeb = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalCredNoGuma = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalDebNoInt = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Shape5 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Label8 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtTotalporCta = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtImpProdDesp = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalIvaProdDesp = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalPerIvaDesp = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalPerGanDesp = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalPerIBDesp = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalImpNIDesp = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalGrlDesp = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalCD = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupHeader1 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.Shape2 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblFechaCarga = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtFechaCarga = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupFooter1 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
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
        CType(Me.lblTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImpProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalIvaProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPerIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPerGan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPerIB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalImpNI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalGrl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalCredIntGuma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalDebIntGuma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalCredNoIntGuma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalDebNoIntNoGuma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalCred, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalDeb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalCredNoGuma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalDebNoInt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalporCta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImpProdDesp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalIvaProdDesp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPerIvaDesp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPerGanDesp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPerIBDesp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalImpNIDesp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalGrlDesp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalCD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFechaCarga, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaCarga, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblNroInterno, Me.lblProveedor, Me.lblComprobante, Me.lblFComp, Me.lblFVto, Me.lblImpProd, Me.lblIVAProd, Me.lblPerIva, Me.lblPerGan, Me.lblPerIB, Me.lblImpNI, Me.lblTotal, Me.Line1})
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
        Me.lblNroInterno.Top = 0.02480315!
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
        Me.lblProveedor.Top = 0.02480315!
        Me.lblProveedor.Width = 0.7393701!
        '
        'lblComprobante
        '
        Me.lblComprobante.Height = 0.2!
        Me.lblComprobante.HyperLink = Nothing
        Me.lblComprobante.Left = 0.9232286!
        Me.lblComprobante.Name = "lblComprobante"
        Me.lblComprobante.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblComprobante.Text = "Comprobante"
        Me.lblComprobante.Top = 0.02480315!
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
        Me.lblFComp.Top = 0.02480315!
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
        Me.lblFVto.Top = 0.02480315!
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
        Me.lblImpProd.Top = 0.02480315!
        Me.lblImpProd.Width = 0.6562995!
        '
        'lblIVAProd
        '
        Me.lblIVAProd.Height = 0.2!
        Me.lblIVAProd.HyperLink = Nothing
        Me.lblIVAProd.Left = 4.414174!
        Me.lblIVAProd.Name = "lblIVAProd"
        Me.lblIVAProd.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblIVAProd.Text = "IVA Prod."
        Me.lblIVAProd.Top = 0.02480315!
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
        Me.lblPerIva.Top = 0.02480317!
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
        Me.lblPerGan.Top = 0.02480315!
        Me.lblPerGan.Width = 0.6043304!
        '
        'lblPerIB
        '
        Me.lblPerIB.Height = 0.2!
        Me.lblPerIB.HyperLink = Nothing
        Me.lblPerIB.Left = 6.974411!
        Me.lblPerIB.Name = "lblPerIB"
        Me.lblPerIB.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblPerIB.Text = "Per.IB"
        Me.lblPerIB.Top = 0.02480315!
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
        Me.lblImpNI.Top = 0.02480315!
        Me.lblImpNI.Width = 0.5582685!
        '
        'lblTotal
        '
        Me.lblTotal.Height = 0.2!
        Me.lblTotal.HyperLink = Nothing
        Me.lblTotal.Left = 8.522048!
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblTotal.Text = "Total"
        Me.lblTotal.Top = 0.02480315!
        Me.lblTotal.Width = 0.4791335!
        '
        'Line1
        '
        Me.Line1.Height = 0!
        Me.Line1.Left = 0!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.2248032!
        Me.Line1.Width = 10.97906!
        Me.Line1.X1 = 0!
        Me.Line1.X2 = 10.97906!
        Me.Line1.Y1 = 0.2248032!
        Me.Line1.Y2 = 0.2248032!
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txtCodInsumo, Me.txtComprobante, Me.txtFechaComp, Me.txtFechaVto, Me.txtFIP, Me.txtIvaProd, Me.txtPerIVA, Me.txtPerGan, Me.txtPerIB, Me.txtImpNI, Me.txtTotal, Me.txtField9, Me.txtNroProveedor, Me.txtTipoComp, Me.txtPrefijo, Me.txtnroCompAlfanumerico})
        Me.Detail.Height = 0.2000656!
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
        Me.txtCodInsumo.Width = 0.6212589!
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
        Me.txtComprobante.Width = 0.4342508!
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
        Me.txtFechaComp.Width = 0.5397635!
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
        Me.txtFechaVto.Width = 0.6425186!
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
        Me.txtFIP.Width = 0.7775591!
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
        Me.txtPerIVA.Left = 5.042913!
        Me.txtPerIVA.Name = "txtPerIVA"
        Me.txtPerIVA.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; text-align: right; ddo-char" &
    "-set: 0"
        Me.txtPerIVA.Text = "periva"
        Me.txtPerIVA.Top = 0!
        Me.txtPerIVA.Width = 0.6527553!
        '
        'txtPerGan
        '
        Me.txtPerGan.DataField = "percepgan"
        Me.txtPerGan.Height = 0.2!
        Me.txtPerGan.Left = 5.699213!
        Me.txtPerGan.Name = "txtPerGan"
        Me.txtPerGan.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; text-align: right; ddo-char" &
    "-set: 0"
        Me.txtPerGan.Text = "pergan"
        Me.txtPerGan.Top = 0!
        Me.txtPerGan.Width = 0.767323!
        '
        'txtPerIB
        '
        Me.txtPerIB.DataField = "totalpercepib"
        Me.txtPerIB.Height = 0.2!
        Me.txtPerIB.Left = 6.546457!
        Me.txtPerIB.Name = "txtPerIB"
        Me.txtPerIB.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; text-align: right; ddo-char" &
    "-set: 0"
        Me.txtPerIB.Text = "perib"
        Me.txtPerIB.Top = 0!
        Me.txtPerIB.Width = 0.7673223!
        '
        'txtImpNI
        '
        Me.txtImpNI.DataField = "importenoimp"
        Me.txtImpNI.Height = 0.2!
        Me.txtImpNI.Left = 7.348823!
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
        Me.txtTotal.Left = 8.24449!
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
        Me.txtField9.Left = 9.359844!
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
        Me.txtNroProveedor.Left = 9.057088!
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
        Me.txtPrefijo.Left = 0.9933071!
        Me.txtPrefijo.Name = "txtPrefijo"
        Me.txtPrefijo.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; ddo-char-set: 0"
        Me.txtPrefijo.Text = "nrocomp"
        Me.txtPrefijo.Top = 0!
        Me.txtPrefijo.Width = 0.8570855!
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
        Me.PageFooter.Name = "PageFooter"
        '
        'lblPage
        '
        Me.lblPage.Height = 0.2!
        Me.lblPage.HyperLink = Nothing
        Me.lblPage.Left = 8.473229!
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.lblPage.Text = "Página"
        Me.lblPage.Top = 0.02480315!
        Me.lblPage.Width = 0.5838585!
        '
        'txtPage
        '
        Me.txtPage.Height = 0.2!
        Me.txtPage.Left = 9.192522!
        Me.txtPage.Name = "txtPage"
        Me.txtPage.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtPage.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All
        Me.txtPage.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.txtPage.Text = "#"
        Me.txtPage.Top = 0.02480315!
        Me.txtPage.Width = 0.3027558!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 9.59882!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.Label3.Text = "de"
        Me.Label3.Top = 0.02480315!
        Me.Label3.Width = 0.2708659!
        '
        'lblPie
        '
        Me.lblPie.Height = 0.2!
        Me.lblPie.HyperLink = Nothing
        Me.lblPie.Left = 0.1665359!
        Me.lblPie.Name = "lblPie"
        Me.lblPie.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.lblPie.Text = "pie"
        Me.lblPie.Top = 0.02480315!
        Me.lblPie.Width = 3.062599!
        '
        'TextBox8
        '
        Me.TextBox8.Height = 0.2!
        Me.TextBox8.Left = 9.984251!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.TextBox8.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.TextBox8.Text = "##"
        Me.TextBox8.Top = 0.02480315!
        Me.TextBox8.Width = 0.3027558!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblJoseGuma, Me.lblDireccion, Me.Shape1, Me.lblTitulo, Me.Picture1, Me.lblFecha})
        Me.ReportHeader1.Height = 1.456201!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'lblJoseGuma
        '
        Me.lblJoseGuma.Height = 0.2!
        Me.lblJoseGuma.HyperLink = Nothing
        Me.lblJoseGuma.Left = 1.3!
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
        Me.lblDireccion.Left = 1.28307!
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
        Me.Shape1.Left = 2.402756!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape1.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape1.Top = 0.8102361!
        Me.Shape1.Width = 5.884253!
        '
        'lblTitulo
        '
        Me.lblTitulo.Height = 0.2622046!
        Me.lblTitulo.HyperLink = Nothing
        Me.lblTitulo.Left = 2.96378!
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Style = "font-size: 12pt; font-weight: bold; text-align: center; ddo-char-set: 1"
        Me.lblTitulo.Text = ""
        Me.lblTitulo.Top = 0.8622048!
        Me.lblTitulo.Width = 4.871261!
        '
        'Picture1
        '
        Me.Picture1.Height = 0.7582681!
        Me.Picture1.HyperLink = Nothing
        Me.Picture1.ImageBytes = CType(resources.GetObject("Picture1.ImageBytes"), Byte())
        Me.Picture1.Left = 0.05905515!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.Picture1.Top = 0!
        Me.Picture1.Width = 1.135039!
        '
        'lblFecha
        '
        Me.lblFecha.Height = 0.2000001!
        Me.lblFecha.HyperLink = Nothing
        Me.lblFecha.Left = 3.222835!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "font-size: 10pt; text-align: center; ddo-char-set: 1"
        Me.lblFecha.Text = ""
        Me.lblFecha.Top = 1.12441!
        Me.lblFecha.Width = 4.37441!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Line2, Me.Shape3, Me.lblTotales, Me.txtImpProd, Me.txtTotalIvaProd, Me.txtTotalPerIva, Me.txtTotalPerGan, Me.txtTotalPerIB, Me.txtTotalImpNI, Me.txtTotalGrl, Me.Shape4, Me.txtTotalCredIntGuma, Me.Label2, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.txtTotalDebIntGuma, Me.txtTotalCredNoIntGuma, Me.txtTotalDebNoIntNoGuma, Me.txtTotalCred, Me.txtTotalDeb, Me.txtTotalCredNoGuma, Me.txtTotalDebNoInt, Me.Shape5, Me.Label8, Me.txtTotalporCta, Me.txtImpProdDesp, Me.txtTotalIvaProdDesp, Me.txtTotalPerIvaDesp, Me.txtTotalPerGanDesp, Me.txtTotalPerIBDesp, Me.txtTotalImpNIDesp, Me.txtTotalGrlDesp, Me.txtTotalCD})
        Me.ReportFooter1.Height = 3.262795!
        Me.ReportFooter1.Name = "ReportFooter1"
        Me.ReportFooter1.NewPage = GrapeCity.ActiveReports.SectionReportModel.NewPage.Before
        '
        'Line2
        '
        Me.Line2.Height = 0!
        Me.Line2.Left = 0.04252028!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0!
        Me.Line2.Width = 10.98977!
        Me.Line2.X1 = 0.04252028!
        Me.Line2.X2 = 11.03229!
        Me.Line2.Y1 = 0!
        Me.Line2.Y2 = 0!
        '
        'Shape3
        '
        Me.Shape3.Height = 0.3149606!
        Me.Shape3.Left = 1.096063!
        Me.Shape3.Name = "Shape3"
        Me.Shape3.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape3.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape3.Top = 0.07283463!
        Me.Shape3.Width = 9.733463!
        '
        'lblTotales
        '
        Me.lblTotales.Height = 0.2!
        Me.lblTotales.HyperLink = Nothing
        Me.lblTotales.Left = 1.386615!
        Me.lblTotales.Name = "lblTotales"
        Me.lblTotales.Style = "font-size: 9.75pt; font-weight: bold"
        Me.lblTotales.Text = "TOTALES"
        Me.lblTotales.Top = 0.135433!
        Me.lblTotales.Width = 0.714173!
        '
        'txtImpProd
        '
        Me.txtImpProd.DataField = "importeprod"
        Me.txtImpProd.Height = 0.2!
        Me.txtImpProd.Left = 2.643701!
        Me.txtImpProd.Name = "txtImpProd"
        Me.txtImpProd.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtImpProd.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All
        Me.txtImpProd.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal
        Me.txtImpProd.Text = "totalprod"
        Me.txtImpProd.Top = 0.1354331!
        Me.txtImpProd.Width = 1.153149!
        '
        'txtTotalIvaProd
        '
        Me.txtTotalIvaProd.DataField = "ivaprod"
        Me.txtTotalIvaProd.Height = 0.2!
        Me.txtTotalIvaProd.Left = 3.868504!
        Me.txtTotalIvaProd.Name = "txtTotalIvaProd"
        Me.txtTotalIvaProd.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtTotalIvaProd.Text = "totalivaprod"
        Me.txtTotalIvaProd.Top = 0.1354331!
        Me.txtTotalIvaProd.Width = 0.968504!
        '
        'txtTotalPerIva
        '
        Me.txtTotalPerIva.DataField = "percepiva"
        Me.txtTotalPerIva.Height = 0.2!
        Me.txtTotalPerIva.Left = 4.867717!
        Me.txtTotalPerIva.Name = "txtTotalPerIva"
        Me.txtTotalPerIva.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtTotalPerIva.Text = "totalperiva"
        Me.txtTotalPerIva.Top = 0.1354331!
        Me.txtTotalPerIva.Width = 1.014565!
        '
        'txtTotalPerGan
        '
        Me.txtTotalPerGan.DataField = "percepgan"
        Me.txtTotalPerGan.Height = 0.2!
        Me.txtTotalPerGan.Left = 5.885827!
        Me.txtTotalPerGan.Name = "txtTotalPerGan"
        Me.txtTotalPerGan.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtTotalPerGan.Text = "pergan"
        Me.txtTotalPerGan.Top = 0.1354331!
        Me.txtTotalPerGan.Width = 0.7822838!
        '
        'txtTotalPerIB
        '
        Me.txtTotalPerIB.DataField = "totalpercepib"
        Me.txtTotalPerIB.Height = 0.2!
        Me.txtTotalPerIB.Left = 6.668111!
        Me.txtTotalPerIB.Name = "txtTotalPerIB"
        Me.txtTotalPerIB.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtTotalPerIB.Text = "totalIB"
        Me.txtTotalPerIB.Top = 0.1354331!
        Me.txtTotalPerIB.Width = 0.9291338!
        '
        'txtTotalImpNI
        '
        Me.txtTotalImpNI.DataField = "importenoimp"
        Me.txtTotalImpNI.Height = 0.2!
        Me.txtTotalImpNI.Left = 7.603544!
        Me.txtTotalImpNI.Name = "txtTotalImpNI"
        Me.txtTotalImpNI.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtTotalImpNI.Text = "totalNI"
        Me.txtTotalImpNI.Top = 0.1354331!
        Me.txtTotalImpNI.Width = 0.8503938!
        '
        'txtTotalGrl
        '
        Me.txtTotalGrl.DataField = "totalcomprobante"
        Me.txtTotalGrl.Height = 0.2!
        Me.txtTotalGrl.Left = 8.478741!
        Me.txtTotalGrl.Name = "txtTotalGrl"
        Me.txtTotalGrl.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtTotalGrl.Text = "totalgrl"
        Me.txtTotalGrl.Top = 0.1354331!
        Me.txtTotalGrl.Width = 0.961023!
        '
        'Shape4
        '
        Me.Shape4.Height = 1.801969!
        Me.Shape4.Left = 1.870473!
        Me.Shape4.Name = "Shape4"
        Me.Shape4.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape4.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape4.Top = 0.5311024!
        Me.Shape4.Width = 7.48937!
        '
        'txtTotalCredIntGuma
        '
        Me.txtTotalCredIntGuma.Height = 0.2!
        Me.txtTotalCredIntGuma.Left = 3.701576!
        Me.txtTotalCredIntGuma.Name = "txtTotalCredIntGuma"
        Me.txtTotalCredIntGuma.Style = "text-align: right"
        Me.txtTotalCredIntGuma.Text = "creditos int guma"
        Me.txtTotalCredIntGuma.Top = 0.8897638!
        Me.txtTotalCredIntGuma.Width = 1.368896!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 3.327953!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.Label2.Text = "Resumen a modo informativo de los Créditos/Debitos  de Guma e Interno :"
        Me.Label2.Top = 0.5988191!
        Me.Label2.Width = 4.507087!
        '
        'Label4
        '
        Me.Label4.Height = 0.189764!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 2.077559!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "font-size: 8.25pt; font-weight: bold"
        Me.Label4.Text = "Créditos Int.(Guma):"
        Me.Label4.Top = 0.8999999!
        Me.Label4.Width = 1.250394!
        '
        'Label5
        '
        Me.Label5.Height = 0.1897638!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 2.077559!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-size: 8.25pt; font-weight: bold"
        Me.Label5.Text = "Debitos Int.(Guma):"
        Me.Label5.Top = 1.204331!
        Me.Label5.Width = 1.198032!
        '
        'Label6
        '
        Me.Label6.Height = 0.1897638!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 2.077559!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "font-size: 8.25pt; font-weight: bold"
        Me.Label6.Text = "Créditos Int:"
        Me.Label6.Top = 1.509449!
        Me.Label6.Width = 0.8862205!
        '
        'Label7
        '
        Me.Label7.Height = 0.1897638!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 2.077559!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "font-size: 8.25pt; font-weight: bold"
        Me.Label7.Text = "Debitos Int:"
        Me.Label7.Top = 1.803937!
        Me.Label7.Width = 0.7606297!
        '
        'txtTotalDebIntGuma
        '
        Me.txtTotalDebIntGuma.Height = 0.2!
        Me.txtTotalDebIntGuma.Left = 3.701576!
        Me.txtTotalDebIntGuma.Name = "txtTotalDebIntGuma"
        Me.txtTotalDebIntGuma.Style = "text-align: right"
        Me.txtTotalDebIntGuma.Text = "debitos int guma"
        Me.txtTotalDebIntGuma.Top = 1.204331!
        Me.txtTotalDebIntGuma.Width = 1.341338!
        '
        'txtTotalCredNoIntGuma
        '
        Me.txtTotalCredNoIntGuma.Height = 0.2!
        Me.txtTotalCredNoIntGuma.Left = 3.701576!
        Me.txtTotalCredNoIntGuma.Name = "txtTotalCredNoIntGuma"
        Me.txtTotalCredNoIntGuma.Style = "text-align: right"
        Me.txtTotalCredNoIntGuma.Text = "creditos"
        Me.txtTotalCredNoIntGuma.Top = 1.509449!
        Me.txtTotalCredNoIntGuma.Width = 1.341338!
        '
        'txtTotalDebNoIntNoGuma
        '
        Me.txtTotalDebNoIntNoGuma.Height = 0.2!
        Me.txtTotalDebNoIntNoGuma.Left = 3.701576!
        Me.txtTotalDebNoIntNoGuma.Name = "txtTotalDebNoIntNoGuma"
        Me.txtTotalDebNoIntNoGuma.Style = "text-align: right"
        Me.txtTotalDebNoIntNoGuma.Text = "debitos"
        Me.txtTotalDebNoIntNoGuma.Top = 1.793701!
        Me.txtTotalDebNoIntNoGuma.Width = 1.368896!
        '
        'txtTotalCred
        '
        Me.txtTotalCred.Height = 0.2!
        Me.txtTotalCred.Left = 8.107087!
        Me.txtTotalCred.Name = "txtTotalCred"
        Me.txtTotalCred.Style = "text-align: right"
        Me.txtTotalCred.Text = "TotalCred"
        Me.txtTotalCred.Top = 0.8999999!
        Me.txtTotalCred.Width = 1.0!
        '
        'txtTotalDeb
        '
        Me.txtTotalDeb.Height = 0.2!
        Me.txtTotalDeb.Left = 8.057087!
        Me.txtTotalDeb.Name = "txtTotalDeb"
        Me.txtTotalDeb.Style = "text-align: right"
        Me.txtTotalDeb.Text = "total deb"
        Me.txtTotalDeb.Top = 1.204331!
        Me.txtTotalDeb.Width = 1.0!
        '
        'txtTotalCredNoGuma
        '
        Me.txtTotalCredNoGuma.Height = 0.2!
        Me.txtTotalCredNoGuma.Left = 8.107087!
        Me.txtTotalCredNoGuma.Name = "txtTotalCredNoGuma"
        Me.txtTotalCredNoGuma.Style = "text-align: right"
        Me.txtTotalCredNoGuma.Text = "creditos"
        Me.txtTotalCredNoGuma.Top = 1.509449!
        Me.txtTotalCredNoGuma.Width = 1.0!
        '
        'txtTotalDebNoInt
        '
        Me.txtTotalDebNoInt.Height = 0.2!
        Me.txtTotalDebNoInt.Left = 8.107087!
        Me.txtTotalDebNoInt.Name = "txtTotalDebNoInt"
        Me.txtTotalDebNoInt.Style = "text-align: right"
        Me.txtTotalDebNoInt.Text = "debitos"
        Me.txtTotalDebNoInt.Top = 1.803937!
        Me.txtTotalDebNoInt.Width = 1.0!
        '
        'Shape5
        '
        Me.Shape5.Height = 0.3976378!
        Me.Shape5.Left = 1.92126!
        Me.Shape5.Name = "Shape5"
        Me.Shape5.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape5.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape5.Top = 2.437008!
        Me.Shape5.Width = 7.470079!
        '
        'Label8
        '
        Me.Label8.Height = 0.1897638!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 2.077559!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "font-size: 8.25pt; font-weight: bold"
        Me.Label8.Text = "Despachos:"
        Me.Label8.Top = 2.537008!
        Me.Label8.Width = 0.7606299!
        '
        'txtTotalporCta
        '
        Me.txtTotalporCta.Height = 0.2!
        Me.txtTotalporCta.Left = 2.077559!
        Me.txtTotalporCta.Name = "txtTotalporCta"
        Me.txtTotalporCta.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtTotalporCta.Text = Nothing
        Me.txtTotalporCta.Top = 2.893307!
        Me.txtTotalporCta.Width = 5.42756!
        '
        'txtImpProdDesp
        '
        Me.txtImpProdDesp.Height = 0.2!
        Me.txtImpProdDesp.Left = 2.96378!
        Me.txtImpProdDesp.Name = "txtImpProdDesp"
        Me.txtImpProdDesp.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtImpProdDesp.Text = "totalprod"
        Me.txtImpProdDesp.Top = 2.526772!
        Me.txtImpProdDesp.Width = 0.833071!
        '
        'txtTotalIvaProdDesp
        '
        Me.txtTotalIvaProdDesp.Height = 0.2!
        Me.txtTotalIvaProdDesp.Left = 3.726772!
        Me.txtTotalIvaProdDesp.Name = "txtTotalIvaProdDesp"
        Me.txtTotalIvaProdDesp.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtTotalIvaProdDesp.Text = "totalivaprod"
        Me.txtTotalIvaProdDesp.Top = 2.526772!
        Me.txtTotalIvaProdDesp.Width = 0.9165353!
        '
        'txtTotalPerIvaDesp
        '
        Me.txtTotalPerIvaDesp.Height = 0.2!
        Me.txtTotalPerIvaDesp.Left = 4.701575!
        Me.txtTotalPerIvaDesp.Name = "txtTotalPerIvaDesp"
        Me.txtTotalPerIvaDesp.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.txtTotalPerIvaDesp.Text = "totalperiva"
        Me.txtTotalPerIvaDesp.Top = 2.526772!
        Me.txtTotalPerIvaDesp.Width = 0.8748029!
        '
        'txtTotalPerGanDesp
        '
        Me.txtTotalPerGanDesp.DataField = "percepgan"
        Me.txtTotalPerGanDesp.Height = 0.2!
        Me.txtTotalPerGanDesp.Left = 5.513781!
        Me.txtTotalPerGanDesp.Name = "txtTotalPerGanDesp"
        Me.txtTotalPerGanDesp.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtTotalPerGanDesp.Text = "pergan"
        Me.txtTotalPerGanDesp.Top = 2.526772!
        Me.txtTotalPerGanDesp.Width = 0.8181105!
        '
        'txtTotalPerIBDesp
        '
        Me.txtTotalPerIBDesp.DataField = "totalpercepib"
        Me.txtTotalPerIBDesp.Height = 0.2!
        Me.txtTotalPerIBDesp.Left = 6.33189!
        Me.txtTotalPerIBDesp.Name = "txtTotalPerIBDesp"
        Me.txtTotalPerIBDesp.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtTotalPerIBDesp.Text = "totalIB"
        Me.txtTotalPerIBDesp.Top = 2.537008!
        Me.txtTotalPerIBDesp.Width = 0.9818896!
        '
        'txtTotalImpNIDesp
        '
        Me.txtTotalImpNIDesp.DataField = "importenoimp"
        Me.txtTotalImpNIDesp.Height = 0.2!
        Me.txtTotalImpNIDesp.Left = 7.265355!
        Me.txtTotalImpNIDesp.Name = "txtTotalImpNIDesp"
        Me.txtTotalImpNIDesp.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtTotalImpNIDesp.Text = "totalNI"
        Me.txtTotalImpNIDesp.Top = 2.547244!
        Me.txtTotalImpNIDesp.Width = 0.9232283!
        '
        'txtTotalGrlDesp
        '
        Me.txtTotalGrlDesp.DataField = "totalcomprobante"
        Me.txtTotalGrlDesp.Height = 0.2!
        Me.txtTotalGrlDesp.Left = 8.254725!
        Me.txtTotalGrlDesp.Name = "txtTotalGrlDesp"
        Me.txtTotalGrlDesp.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1"
        Me.txtTotalGrlDesp.Text = "totalgrl"
        Me.txtTotalGrlDesp.Top = 2.547244!
        Me.txtTotalGrlDesp.Width = 0.9377942!
        '
        'txtTotalCD
        '
        Me.txtTotalCD.Height = 0.2!
        Me.txtTotalCD.Left = 7.450788!
        Me.txtTotalCD.Name = "txtTotalCD"
        Me.txtTotalCD.Style = "text-align: right"
        Me.txtTotalCD.Text = "creditos int"
        Me.txtTotalCD.Top = 2.06693!
        Me.txtTotalCD.Width = 1.6563!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape2, Me.lblFechaCarga, Me.txtFechaCarga})
        Me.GroupHeader1.DataField = "fechacarga"
        Me.GroupHeader1.Height = 0.3751313!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'Shape2
        '
        Me.Shape2.BackColor = System.Drawing.Color.White
        Me.Shape2.Height = 0.3255906!
        Me.Shape2.Left = 0.05905485!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(50.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape2.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape2.Top = 7.450581E-9!
        Me.Shape2.Width = 2.469291!
        '
        'lblFechaCarga
        '
        Me.lblFechaCarga.Height = 0.2!
        Me.lblFechaCarga.HyperLink = Nothing
        Me.lblFechaCarga.Left = 0.1007869!
        Me.lblFechaCarga.Name = "lblFechaCarga"
        Me.lblFechaCarga.Style = "font-size: 9pt; font-weight: bold"
        Me.lblFechaCarga.Text = "Fecha Carga: "
        Me.lblFechaCarga.Top = 0.07716536!
        Me.lblFechaCarga.Width = 0.958268!
        '
        'txtFechaCarga
        '
        Me.txtFechaCarga.DataField = "fechacarga"
        Me.txtFechaCarga.Height = 0.2!
        Me.txtFechaCarga.Left = 1.142913!
        Me.txtFechaCarga.Name = "txtFechaCarga"
        Me.txtFechaCarga.Style = "font-size: 9pt; ddo-char-set: 1"
        Me.txtFechaCarga.Text = "fechacarga"
        Me.txtFechaCarga.Top = 0.07716536!
        Me.txtFechaCarga.Width = 1.321654!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'RptImpresoComprobante
        '
        Me.MasterReport = False
        Me.CompatibilityMode = GrapeCity.ActiveReports.Document.CompatibilityModes.CrossPlatform
        Me.PageSettings.Margins.Bottom = 0.3937008!
        Me.PageSettings.Margins.Left = 0.1968504!
        Me.PageSettings.Margins.Right = 0.1968504!
        Me.PageSettings.Margins.Top = 0.3937008!
        Me.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 11.15625!
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
        CType(Me.lblTotales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImpProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalIvaProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPerIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPerGan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPerIB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalImpNI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalGrl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalCredIntGuma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalDebIntGuma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalCredNoIntGuma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalDebNoIntNoGuma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalCred, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalDeb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalCredNoGuma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalDebNoInt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalporCta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImpProdDesp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalIvaProdDesp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPerIvaDesp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPerGanDesp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPerIBDesp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalImpNIDesp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalGrlDesp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalCD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFechaCarga, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaCarga, System.ComponentModel.ISupportInitialize).EndInit()
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
    Private WithEvents Shape2 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblFechaCarga As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtFechaCarga As GrapeCity.ActiveReports.SectionReportModel.TextBox
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
    Private WithEvents lblPage As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtPage As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label3 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblPie As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox8 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Line2 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Shape3 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblTotales As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtImpProd As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalIvaProd As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalPerIva As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalPerGan As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalPerIB As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalImpNI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalGrl As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Shape4 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents txtTotalCredIntGuma As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label2 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label4 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label5 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label6 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label7 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtTotalDebIntGuma As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalCredNoIntGuma As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalDebNoIntNoGuma As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalCred As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalDeb As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalCredNoGuma As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalDebNoInt As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Shape5 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Label8 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtTotalporCta As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtImpProdDesp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalIvaProdDesp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalPerIvaDesp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalPerGanDesp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalPerIBDesp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalImpNIDesp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalGrlDesp As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalCD As GrapeCity.ActiveReports.SectionReportModel.TextBox
End Class
