<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExceptionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExceptionForm))
        Me.ExceptionText = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ContinueButton = New System.Windows.Forms.Button()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.EmailButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ExceptionText
        '
        Me.ExceptionText.Location = New System.Drawing.Point(12, 46)
        Me.ExceptionText.Multiline = True
        Me.ExceptionText.Name = "ExceptionText"
        Me.ExceptionText.ReadOnly = True
        Me.ExceptionText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ExceptionText.Size = New System.Drawing.Size(520, 168)
        Me.ExceptionText.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(99, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(345, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "An unexpected error has occurred! See below for exception information."
        '
        'ContinueButton
        '
        Me.ContinueButton.Location = New System.Drawing.Point(345, 229)
        Me.ContinueButton.Name = "ContinueButton"
        Me.ContinueButton.Size = New System.Drawing.Size(98, 23)
        Me.ContinueButton.TabIndex = 2
        Me.ContinueButton.Text = "Continue"
        Me.ContinueButton.UseVisualStyleBackColor = True
        '
        'ExitButton
        '
        Me.ExitButton.Location = New System.Drawing.Point(220, 229)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(98, 23)
        Me.ExitButton.TabIndex = 3
        Me.ExitButton.Text = "Exit"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'EmailButton
        '
        Me.EmailButton.Location = New System.Drawing.Point(95, 229)
        Me.EmailButton.Name = "EmailButton"
        Me.EmailButton.Size = New System.Drawing.Size(98, 23)
        Me.EmailButton.TabIndex = 0
        Me.EmailButton.Text = "Draft Email"
        Me.EmailButton.UseVisualStyleBackColor = True
        '
        'ExceptionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 266)
        Me.Controls.Add(Me.EmailButton)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.ContinueButton)
        Me.Controls.Add(Me.ExceptionText)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ExceptionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Error!"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ExceptionText As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ContinueButton As Button
    Friend WithEvents ExitButton As Button
    Friend WithEvents EmailButton As Button
End Class
