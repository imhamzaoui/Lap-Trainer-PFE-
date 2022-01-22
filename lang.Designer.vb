<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class lang
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(lang))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_en = New System.Windows.Forms.PictureBox()
        Me.btn_fr = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        CType(Me.btn_en, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_fr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.SystemColors.Window
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'btn_en
        '
        Me.btn_en.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_en.Image = CType(resources.GetObject("btn_en.Image"), System.Drawing.Image)
        Me.btn_en.Location = New System.Drawing.Point(139, 31)
        Me.btn_en.Name = "btn_en"
        Me.btn_en.Size = New System.Drawing.Size(37, 23)
        Me.btn_en.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn_en.TabIndex = 1
        Me.btn_en.TabStop = False
        '
        'btn_fr
        '
        Me.btn_fr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_fr.Image = CType(resources.GetObject("btn_fr.Image"), System.Drawing.Image)
        Me.btn_fr.Location = New System.Drawing.Point(182, 31)
        Me.btn_fr.Name = "btn_fr"
        Me.btn_fr.Size = New System.Drawing.Size(37, 23)
        Me.btn_fr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn_fr.TabIndex = 2
        Me.btn_fr.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.PictureBox3.Location = New System.Drawing.Point(136, 29)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(86, 28)
        Me.PictureBox3.TabIndex = 3
        Me.PictureBox3.TabStop = False
        '
        'lang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(234, 68)
        Me.Controls.Add(Me.btn_fr)
        Me.Controls.Add(Me.btn_en)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "lang"
        Me.Opacity = 0.98R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.btn_en, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_fr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_en As System.Windows.Forms.PictureBox
    Friend WithEvents btn_fr As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
End Class
