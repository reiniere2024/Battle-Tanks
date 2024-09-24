<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.CP03 = New Battletanks.CustomPicture
        Me.CP02 = New Battletanks.CustomPicture
        Me.CP01 = New Battletanks.CustomPicture
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CP03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CP02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CP01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1748, 497)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(242, 558)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Tank"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(340, 558)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Vizier"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CP03
        '
        Me.CP03.Image = CType(resources.GetObject("CP03.Image"), System.Drawing.Image)
        Me.CP03.Location = New System.Drawing.Point(511, 7)
        Me.CP03.Name = "CP03"
        Me.CP03.Size = New System.Drawing.Size(226, 192)
        Me.CP03.TabIndex = 5
        Me.CP03.TabStop = False
        Me.CP03.Visible = False
        '
        'CP02
        '
        Me.CP02.Image = CType(resources.GetObject("CP02.Image"), System.Drawing.Image)
        Me.CP02.Location = New System.Drawing.Point(511, 302)
        Me.CP02.Name = "CP02"
        Me.CP02.Size = New System.Drawing.Size(226, 192)
        Me.CP02.TabIndex = 4
        Me.CP02.TabStop = False
        Me.CP02.Visible = False
        '
        'CP01
        '
        Me.CP01.Image = CType(resources.GetObject("CP01.Image"), System.Drawing.Image)
        Me.CP01.Location = New System.Drawing.Point(873, 10)
        Me.CP01.Name = "CP01"
        Me.CP01.Size = New System.Drawing.Size(316, 87)
        Me.CP01.TabIndex = 2
        Me.CP01.TabStop = False
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1199, 662)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CP03)
        Me.Controls.Add(Me.CP02)
        Me.Controls.Add(Me.CP01)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form2"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CP03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CP02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CP01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CP01 As Battletanks.CustomPicture
    Friend WithEvents CP03 As Battletanks.CustomPicture
    Friend WithEvents CP02 As Battletanks.CustomPicture
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
