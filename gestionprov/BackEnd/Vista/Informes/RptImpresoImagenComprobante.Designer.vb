<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class RptImpresoImagenComprobante
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptImpresoImagenComprobante))
        Me.PageHeader = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.Label1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtNroInterno = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.ImgComprobante = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.PageFooter = New GrapeCity.ActiveReports.SectionReportModel.PageFooter()
        Me.lblPie = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblPage = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtPage = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label3 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox8 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNroInterno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Label1, Me.txtNroInterno})
        Me.PageHeader.Height = 0.21875!
        Me.PageHeader.Name = "PageHeader"
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.4688977!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-size: 14pt; font-weight: bold; ddo-char-set: 1"
        Me.Label1.Text = "IMAGEN DE COMPROBANTE INTERNO Nº:"
        Me.Label1.Top = 0!
        Me.Label1.Width = 4.020866!
        '
        'txtNroInterno
        '
        Me.txtNroInterno.Height = 0.2!
        Me.txtNroInterno.Left = 4.614567!
        Me.txtNroInterno.Name = "txtNroInterno"
        Me.txtNroInterno.Style = "font-size: 12pt; font-weight: bold"
        Me.txtNroInterno.Text = "NroInterno"
        Me.txtNroInterno.Top = 0!
        Me.txtNroInterno.Width = 1.0!
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.ImgComprobante})
        Me.Detail.Height = 4.802083!
        Me.Detail.Name = "Detail"
        '
        'ImgComprobante
        '
        Me.ImgComprobante.Height = 4.635433!
        Me.ImgComprobante.Left = 0.26063!
        Me.ImgComprobante.Name = "ImgComprobante"
        Me.ImgComprobante.Top = 0.0937008!
        Me.ImgComprobante.Width = 6.0!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblPie, Me.lblPage, Me.txtPage, Me.Label3, Me.TextBox8})
        Me.PageFooter.Height = 0.2708334!
        Me.PageFooter.Name = "PageFooter"
        '
        'lblPie
        '
        Me.lblPie.Height = 0.2!
        Me.lblPie.HyperLink = Nothing
        Me.lblPie.Left = 0.4688977!
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
        Me.lblPage.Left = 4.115355!
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.lblPage.Text = "Página"
        Me.lblPage.Top = 0!
        Me.lblPage.Width = 0.5838585!
        '
        'txtPage
        '
        Me.txtPage.Height = 0.2!
        Me.txtPage.Left = 4.855119!
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
        Me.Label3.Left = 5.303544!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.Label3.Text = "De"
        Me.Label3.Top = 0!
        Me.Label3.Width = 0.3125985!
        '
        'TextBox8
        '
        Me.TextBox8.Height = 0.2!
        Me.TextBox8.Left = 5.719686!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "font-size: 8pt; ddo-char-set: 1"
        Me.TextBox8.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.TextBox8.Text = "##"
        Me.TextBox8.Top = 0!
        Me.TextBox8.Width = 0.3027558!
        '
        'RptImpresoImagenComprobante
        '
        Me.MasterReport = False
        Me.CompatibilityMode = GrapeCity.ActiveReports.Document.CompatibilityModes.CrossPlatform
        Me.PageSettings.Margins.Bottom = 0.3937008!
        Me.PageSettings.Margins.Left = 0.3937008!
        Me.PageSettings.Margins.Right = 0.3937008!
        Me.PageSettings.Margins.Top = 0.3937008!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.PageFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" &
            "l; font-size: 10pt; color: Black; ddo-char-set: 204", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" &
            "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNroInterno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private WithEvents Label1 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblPie As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblPage As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtPage As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label3 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox8 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Public WithEvents ImgComprobante As GrapeCity.ActiveReports.SectionReportModel.Picture
    Public WithEvents txtNroInterno As GrapeCity.ActiveReports.SectionReportModel.TextBox
End Class
