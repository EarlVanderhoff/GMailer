<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.lblSPARTAMAILDROP = New System.Windows.Forms.Label()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.lblSubject = New System.Windows.Forms.Label()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.txtTo = New System.Windows.Forms.TextBox()
        Me.txtText = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.tmrDropBox = New System.Windows.Forms.Timer(Me.components)
        Me.pboxStandby = New System.Windows.Forms.PictureBox()
        Me.cboAttachments = New System.Windows.Forms.ComboBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.pboxSend = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxStandby, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxSend, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrom.Location = New System.Drawing.Point(88, 4)
        Me.lblFrom.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(48, 17)
        Me.lblFrom.TabIndex = 1
        Me.lblFrom.Text = "From: "
        '
        'lblSPARTAMAILDROP
        '
        Me.lblSPARTAMAILDROP.AutoSize = True
        Me.lblSPARTAMAILDROP.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSPARTAMAILDROP.Location = New System.Drawing.Point(139, 4)
        Me.lblSPARTAMAILDROP.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSPARTAMAILDROP.Name = "lblSPARTAMAILDROP"
        Me.lblSPARTAMAILDROP.Size = New System.Drawing.Size(211, 17)
        Me.lblSPARTAMAILDROP.TabIndex = 2
        Me.lblSPARTAMAILDROP.Text = "SPARTAMAILDROP@gmail.com"
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTo.Location = New System.Drawing.Point(88, 32)
        Me.lblTo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(29, 17)
        Me.lblTo.TabIndex = 3
        Me.lblTo.Text = "To:"
        '
        'lblSubject
        '
        Me.lblSubject.AutoSize = True
        Me.lblSubject.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubject.Location = New System.Drawing.Point(88, 67)
        Me.lblSubject.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.Size = New System.Drawing.Size(59, 17)
        Me.lblSubject.TabIndex = 4
        Me.lblSubject.Text = "Subject:"
        '
        'txtSubject
        '
        Me.txtSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubject.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubject.Location = New System.Drawing.Point(142, 63)
        Me.txtSubject.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtSubject.Multiline = True
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSubject.Size = New System.Drawing.Size(503, 21)
        Me.txtSubject.TabIndex = 2
        '
        'txtTo
        '
        Me.txtTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTo.Location = New System.Drawing.Point(142, 28)
        Me.txtTo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtTo.Multiline = True
        Me.txtTo.Name = "txtTo"
        Me.txtTo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtTo.Size = New System.Drawing.Size(503, 21)
        Me.txtTo.TabIndex = 1
        '
        'txtText
        '
        Me.txtText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtText.Location = New System.Drawing.Point(4, 149)
        Me.txtText.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtText.Multiline = True
        Me.txtText.Name = "txtText"
        Me.txtText.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtText.Size = New System.Drawing.Size(641, 160)
        Me.txtText.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(27, 89)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 39)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'tmrDropBox
        '
        Me.tmrDropBox.Enabled = True
        Me.tmrDropBox.Interval = 5000
        '
        'pboxStandby
        '
        Me.pboxStandby.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pboxStandby.Enabled = False
        Me.pboxStandby.Image = CType(resources.GetObject("pboxStandby.Image"), System.Drawing.Image)
        Me.pboxStandby.Location = New System.Drawing.Point(20, 21)
        Me.pboxStandby.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pboxStandby.Name = "pboxStandby"
        Me.pboxStandby.Size = New System.Drawing.Size(72, 66)
        Me.pboxStandby.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pboxStandby.TabIndex = 12
        Me.pboxStandby.TabStop = False
        Me.pboxStandby.Tag = "paint"
        Me.pboxStandby.Visible = False
        '
        'cboAttachments
        '
        Me.cboAttachments.FormattingEnabled = True
        Me.cboAttachments.Location = New System.Drawing.Point(142, 108)
        Me.cboAttachments.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cboAttachments.Name = "cboAttachments"
        Me.cboAttachments.Size = New System.Drawing.Size(503, 21)
        Me.cboAttachments.TabIndex = 13
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'pboxSend
        '
        Me.pboxSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pboxSend.Image = CType(resources.GetObject("pboxSend.Image"), System.Drawing.Image)
        Me.pboxSend.InitialImage = CType(resources.GetObject("pboxSend.InitialImage"), System.Drawing.Image)
        Me.pboxSend.Location = New System.Drawing.Point(6, 6)
        Me.pboxSend.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pboxSend.Name = "pboxSend"
        Me.pboxSend.Size = New System.Drawing.Size(70, 69)
        Me.pboxSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pboxSend.TabIndex = 14
        Me.pboxSend.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(648, 311)
        Me.Controls.Add(Me.pboxSend)
        Me.Controls.Add(Me.cboAttachments)
        Me.Controls.Add(Me.pboxStandby)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtText)
        Me.Controls.Add(Me.txtTo)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.lblSubject)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.lblSPARTAMAILDROP)
        Me.Controls.Add(Me.lblFrom)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "Form1"
        Me.Text = "SPARTA Mailer"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxStandby, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxSend, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFrom As Label
    Friend WithEvents lblSPARTAMAILDROP As Label
    Friend WithEvents lblTo As Label
    Friend WithEvents lblSubject As Label
    Friend WithEvents txtSubject As TextBox
    Friend WithEvents txtTo As TextBox
    Friend WithEvents txtText As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents tmrDropBox As Timer
    Friend WithEvents pboxStandby As PictureBox
    Friend WithEvents cboAttachments As ComboBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents pboxSend As PictureBox
End Class
