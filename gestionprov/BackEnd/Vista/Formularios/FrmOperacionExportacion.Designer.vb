<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOperacionExportacion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOperacionExportacion))
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse6 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.btnAceptar = New Guna.UI2.WinForms.Guna2Button()
        Me.btnCancelar = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Elipse5 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse4 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse3 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse2 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.cboMoneda = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Guna2Elipse7 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.txtImporte = New Guna.UI2.WinForms.Guna2TextBox()
        Me.cboTipoExp = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.mskFacturaProforma = New System.Windows.Forms.MaskedTextBox()
        Me.mskNroCompExp = New System.Windows.Forms.MaskedTextBox()
        Me.mskPermisoEmbarque = New System.Windows.Forms.MaskedTextBox()
        Me.txtInstrCobranza = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel4 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel5 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel6 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel7 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2Elipse1
        '
        Me.Guna2Elipse1.TargetControl = Me
        '
        'Guna2Elipse6
        '
        Me.Guna2Elipse6.TargetControl = Me.btnCerrar
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.FlatAppearance.BorderSize = 0
        Me.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.Image = Global.Vista.My.Resources.Resources.Icono_cerrar_FN
        Me.btnCerrar.Location = New System.Drawing.Point(280, 0)
        Me.btnCerrar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(30, 32)
        Me.btnCerrar.TabIndex = 61
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel2)
        Me.Guna2Panel1.Controls.Add(Me.btnCerrar)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(310, 44)
        Me.Guna2Panel1.TabIndex = 70
        '
        'Guna2HtmlLabel2
        '
        Me.Guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel2.ForeColor = System.Drawing.Color.White
        Me.Guna2HtmlLabel2.Location = New System.Drawing.Point(12, 12)
        Me.Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Me.Guna2HtmlLabel2.Size = New System.Drawing.Size(247, 18)
        Me.Guna2HtmlLabel2.TabIndex = 62
        Me.Guna2HtmlLabel2.Text = "Operación Exportación/Importación"
        '
        'btnAceptar
        '
        Me.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAceptar.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAceptar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAceptar.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAceptar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAceptar.FillColor = System.Drawing.Color.LimeGreen
        Me.btnAceptar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.Color.White
        Me.btnAceptar.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnAceptar.Location = New System.Drawing.Point(50, 210)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(98, 35)
        Me.btnAceptar.TabIndex = 72
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnCancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnCancelar.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnCancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnCancelar.FillColor = System.Drawing.Color.Red
        Me.btnCancelar.Font = New System.Drawing.Font("Segoe UI Black", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.HoverState.FillColor = System.Drawing.Color.LightCoral
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnCancelar.Location = New System.Drawing.Point(173, 210)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(98, 35)
        Me.btnCancelar.TabIndex = 71
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Guna2Elipse5
        '
        Me.Guna2Elipse5.TargetControl = Me.btnCerrar
        '
        'Guna2Elipse4
        '
        Me.Guna2Elipse4.TargetControl = Me.btnCancelar
        '
        'Guna2Elipse3
        '
        Me.Guna2Elipse3.TargetControl = Me.btnAceptar
        '
        'cboMoneda
        '
        Me.cboMoneda.BackColor = System.Drawing.Color.Transparent
        Me.cboMoneda.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cboMoneda.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cboMoneda.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.cboMoneda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cboMoneda.ItemHeight = 20
        Me.cboMoneda.Location = New System.Drawing.Point(95, 62)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(203, 26)
        Me.cboMoneda.TabIndex = 73
        '
        'txtImporte
        '
        Me.txtImporte.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtImporte.DefaultText = ""
        Me.txtImporte.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtImporte.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtImporte.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtImporte.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtImporte.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtImporte.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtImporte.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtImporte.Location = New System.Drawing.Point(95, 94)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtImporte.PlaceholderText = ""
        Me.txtImporte.SelectedText = ""
        Me.txtImporte.Size = New System.Drawing.Size(203, 26)
        Me.txtImporte.TabIndex = 80
        Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboTipoExp
        '
        Me.cboTipoExp.BackColor = System.Drawing.Color.Transparent
        Me.cboTipoExp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboTipoExp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoExp.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cboTipoExp.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cboTipoExp.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.cboTipoExp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cboTipoExp.ItemHeight = 20
        Me.cboTipoExp.Location = New System.Drawing.Point(95, 126)
        Me.cboTipoExp.Name = "cboTipoExp"
        Me.cboTipoExp.Size = New System.Drawing.Size(203, 26)
        Me.cboTipoExp.TabIndex = 81
        '
        'mskFacturaProforma
        '
        Me.mskFacturaProforma.Location = New System.Drawing.Point(96, 170)
        Me.mskFacturaProforma.Mask = "####/##"
        Me.mskFacturaProforma.Name = "mskFacturaProforma"
        Me.mskFacturaProforma.Size = New System.Drawing.Size(144, 20)
        Me.mskFacturaProforma.TabIndex = 84
        '
        'mskNroCompExp
        '
        Me.mskNroCompExp.Location = New System.Drawing.Point(96, 170)
        Me.mskNroCompExp.Mask = "####-########"
        Me.mskNroCompExp.Name = "mskNroCompExp"
        Me.mskNroCompExp.Size = New System.Drawing.Size(144, 20)
        Me.mskNroCompExp.TabIndex = 85
        '
        'mskPermisoEmbarque
        '
        Me.mskPermisoEmbarque.Location = New System.Drawing.Point(96, 170)
        Me.mskPermisoEmbarque.Mask = "##-###->AA##-######->A"
        Me.mskPermisoEmbarque.Name = "mskPermisoEmbarque"
        Me.mskPermisoEmbarque.Size = New System.Drawing.Size(145, 20)
        Me.mskPermisoEmbarque.TabIndex = 86
        '
        'txtInstrCobranza
        '
        Me.txtInstrCobranza.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInstrCobranza.DefaultText = ""
        Me.txtInstrCobranza.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtInstrCobranza.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtInstrCobranza.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtInstrCobranza.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtInstrCobranza.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtInstrCobranza.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtInstrCobranza.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtInstrCobranza.Location = New System.Drawing.Point(96, 170)
        Me.txtInstrCobranza.Name = "txtInstrCobranza"
        Me.txtInstrCobranza.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtInstrCobranza.PlaceholderText = ""
        Me.txtInstrCobranza.SelectedText = ""
        Me.txtInstrCobranza.Size = New System.Drawing.Size(203, 26)
        Me.txtInstrCobranza.TabIndex = 87
        Me.txtInstrCobranza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Guna2HtmlLabel4
        '
        Me.Guna2HtmlLabel4.AutoSize = False
        Me.Guna2HtmlLabel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Guna2HtmlLabel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Guna2HtmlLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel4.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel4.Location = New System.Drawing.Point(7, 66)
        Me.Guna2HtmlLabel4.Name = "Guna2HtmlLabel4"
        Me.Guna2HtmlLabel4.Size = New System.Drawing.Size(70, 22)
        Me.Guna2HtmlLabel4.TabIndex = 88
        Me.Guna2HtmlLabel4.Text = "Moneda"
        Me.Guna2HtmlLabel4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2HtmlLabel5
        '
        Me.Guna2HtmlLabel5.AutoSize = False
        Me.Guna2HtmlLabel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Guna2HtmlLabel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Guna2HtmlLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel5.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel5.Location = New System.Drawing.Point(7, 98)
        Me.Guna2HtmlLabel5.Name = "Guna2HtmlLabel5"
        Me.Guna2HtmlLabel5.Size = New System.Drawing.Size(70, 22)
        Me.Guna2HtmlLabel5.TabIndex = 89
        Me.Guna2HtmlLabel5.Text = "Importe"
        Me.Guna2HtmlLabel5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2HtmlLabel6
        '
        Me.Guna2HtmlLabel6.AutoSize = False
        Me.Guna2HtmlLabel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Guna2HtmlLabel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Guna2HtmlLabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel6.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel6.Location = New System.Drawing.Point(7, 130)
        Me.Guna2HtmlLabel6.Name = "Guna2HtmlLabel6"
        Me.Guna2HtmlLabel6.Size = New System.Drawing.Size(70, 22)
        Me.Guna2HtmlLabel6.TabIndex = 90
        Me.Guna2HtmlLabel6.Text = "Tipo Com."
        Me.Guna2HtmlLabel6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2HtmlLabel7
        '
        Me.Guna2HtmlLabel7.AutoSize = False
        Me.Guna2HtmlLabel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Guna2HtmlLabel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Guna2HtmlLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel7.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel7.Location = New System.Drawing.Point(7, 168)
        Me.Guna2HtmlLabel7.Name = "Guna2HtmlLabel7"
        Me.Guna2HtmlLabel7.Size = New System.Drawing.Size(70, 22)
        Me.Guna2HtmlLabel7.TabIndex = 91
        Me.Guna2HtmlLabel7.Text = "N° Com."
        Me.Guna2HtmlLabel7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmOperacionExportacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(310, 257)
        Me.Controls.Add(Me.Guna2HtmlLabel7)
        Me.Controls.Add(Me.Guna2HtmlLabel6)
        Me.Controls.Add(Me.Guna2HtmlLabel5)
        Me.Controls.Add(Me.Guna2HtmlLabel4)
        Me.Controls.Add(Me.txtInstrCobranza)
        Me.Controls.Add(Me.mskPermisoEmbarque)
        Me.Controls.Add(Me.mskNroCompExp)
        Me.Controls.Add(Me.mskFacturaProforma)
        Me.Controls.Add(Me.cboTipoExp)
        Me.Controls.Add(Me.txtImporte)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.cboMoneda)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmOperacionExportacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmOperacionExportacion"
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnAceptar As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCancelar As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents cboMoneda As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Guna2Elipse6 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse5 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse4 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse3 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse2 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse7 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents txtImporte As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents cboTipoExp As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents mskFacturaProforma As MaskedTextBox
    Friend WithEvents mskPermisoEmbarque As MaskedTextBox
    Friend WithEvents mskNroCompExp As MaskedTextBox
    Friend WithEvents txtInstrCobranza As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel7 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel6 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel5 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel4 As Guna.UI2.WinForms.Guna2HtmlLabel
End Class
