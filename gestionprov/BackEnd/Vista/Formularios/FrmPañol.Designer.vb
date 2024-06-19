<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPañol
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPañol))
        Me.ChkListado = New System.Windows.Forms.CheckedListBox()
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnCerrar2 = New Guna.UI2.WinForms.Guna2Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2Elipse2 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.btnVolver = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAceptar = New Guna.UI2.WinForms.Guna2Button()
        Me.btnQuitar = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSeleccionarTodas = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Elipse3 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse4 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse5 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse6 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse7 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ChkListado
        '
        Me.ChkListado.FormattingEnabled = True
        Me.ChkListado.Location = New System.Drawing.Point(13, 102)
        Me.ChkListado.Name = "ChkListado"
        Me.ChkListado.Size = New System.Drawing.Size(1038, 259)
        Me.ChkListado.TabIndex = 0
        '
        'Guna2Elipse1
        '
        Me.Guna2Elipse1.TargetControl = Me
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.Guna2Panel1.Controls.Add(Me.btnCerrar2)
        Me.Guna2Panel1.Controls.Add(Me.Label1)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1062, 50)
        Me.Guna2Panel1.TabIndex = 1
        '
        'btnCerrar2
        '
        Me.btnCerrar2.BackColor = System.Drawing.Color.White
        Me.btnCerrar2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar2.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnCerrar2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnCerrar2.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnCerrar2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnCerrar2.FillColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.btnCerrar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCerrar2.ForeColor = System.Drawing.Color.White
        Me.btnCerrar2.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCerrar2.Image = CType(resources.GetObject("btnCerrar2.Image"), System.Drawing.Image)
        Me.btnCerrar2.ImageSize = New System.Drawing.Size(35, 35)
        Me.btnCerrar2.Location = New System.Drawing.Point(1006, 1)
        Me.btnCerrar2.Name = "btnCerrar2"
        Me.btnCerrar2.Size = New System.Drawing.Size(54, 45)
        Me.btnCerrar2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(383, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(310, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Detalles de Ordenes de Compra"
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(12, 367)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(511, 18)
        Me.Guna2HtmlLabel1.TabIndex = 3
        Me.Guna2HtmlLabel1.Text = "Marque las casillas de los Ingresos que desea incluir en el Comprobante."
        '
        'btnVolver
        '
        Me.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVolver.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnVolver.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnVolver.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnVolver.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnVolver.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnVolver.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnVolver.ForeColor = System.Drawing.Color.Black
        Me.btnVolver.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnVolver.Image = CType(resources.GetObject("btnVolver.Image"), System.Drawing.Image)
        Me.btnVolver.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnVolver.Location = New System.Drawing.Point(561, 391)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(95, 45)
        Me.btnVolver.TabIndex = 1
        Me.btnVolver.Text = "      Voler"
        '
        'btnAceptar
        '
        Me.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAceptar.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAceptar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAceptar.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAceptar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAceptar.FillColor = System.Drawing.Color.LightGreen
        Me.btnAceptar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAceptar.ForeColor = System.Drawing.Color.Black
        Me.btnAceptar.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.Location = New System.Drawing.Point(397, 391)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(95, 45)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnQuitar
        '
        Me.btnQuitar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuitar.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnQuitar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnQuitar.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnQuitar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnQuitar.FillColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnQuitar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnQuitar.ForeColor = System.Drawing.Color.White
        Me.btnQuitar.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnQuitar.Image = CType(resources.GetObject("btnQuitar.Image"), System.Drawing.Image)
        Me.btnQuitar.Location = New System.Drawing.Point(146, 54)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(126, 45)
        Me.btnQuitar.TabIndex = 4
        Me.btnQuitar.Text = "Limpiar selección"
        '
        'btnSeleccionarTodas
        '
        Me.btnSeleccionarTodas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSeleccionarTodas.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSeleccionarTodas.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSeleccionarTodas.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSeleccionarTodas.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSeleccionarTodas.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSeleccionarTodas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSeleccionarTodas.ForeColor = System.Drawing.Color.White
        Me.btnSeleccionarTodas.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnSeleccionarTodas.Image = CType(resources.GetObject("btnSeleccionarTodas.Image"), System.Drawing.Image)
        Me.btnSeleccionarTodas.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnSeleccionarTodas.Location = New System.Drawing.Point(15, 54)
        Me.btnSeleccionarTodas.Name = "btnSeleccionarTodas"
        Me.btnSeleccionarTodas.Size = New System.Drawing.Size(118, 45)
        Me.btnSeleccionarTodas.TabIndex = 5
        Me.btnSeleccionarTodas.Text = "     Seleccionar todas"
        '
        'Guna2Elipse3
        '
        Me.Guna2Elipse3.TargetControl = Me.btnAceptar
        '
        'Guna2Elipse4
        '
        Me.Guna2Elipse4.TargetControl = Me.btnVolver
        '
        'Guna2Elipse5
        '
        Me.Guna2Elipse5.TargetControl = Me.btnSeleccionarTodas
        '
        'Guna2Elipse7
        '
        Me.Guna2Elipse7.TargetControl = Me.btnQuitar
        '
        'FrmPañol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1062, 446)
        Me.Controls.Add(Me.btnSeleccionarTodas)
        Me.Controls.Add(Me.btnQuitar)
        Me.Controls.Add(Me.Guna2HtmlLabel1)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.ChkListado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmPañol"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ChkListado As CheckedListBox
    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents btnVolver As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAceptar As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Elipse2 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCerrar2 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnQuitar As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSeleccionarTodas As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Elipse3 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse4 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse5 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse6 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse7 As Guna.UI2.WinForms.Guna2Elipse
End Class
