<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ToolMaintForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ToolMaintForm))
        Me.DGVToolEdit = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.InsertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveUpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveDownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveToTopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveToBottomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveUpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveUpSpaces = New System.Windows.Forms.ToolStripComboBox()
        Me.MoveDownToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveDownSpaces = New System.Windows.Forms.ToolStripComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.StatusLabel = New System.Windows.Forms.ToolStripLabel()
        Me.ExitButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.FilePathLabel = New System.Windows.Forms.ToolStripLabel()
        CType(Me.DGVToolEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGVToolEdit
        '
        Me.DGVToolEdit.AllowUserToResizeRows = False
        Me.DGVToolEdit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGVToolEdit.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGVToolEdit.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DGVToolEdit.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVToolEdit.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVToolEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVToolEdit.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVToolEdit.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGVToolEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGVToolEdit.Location = New System.Drawing.Point(0, 0)
        Me.DGVToolEdit.Name = "DGVToolEdit"
        Me.DGVToolEdit.RowHeadersWidth = 24
        Me.DGVToolEdit.Size = New System.Drawing.Size(758, 416)
        Me.DGVToolEdit.TabIndex = 2
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InsertToolStripMenuItem, Me.MoveUpToolStripMenuItem, Me.MoveDownToolStripMenuItem, Me.MoveToTopToolStripMenuItem, Me.MoveToBottomToolStripMenuItem, Me.MoveUpToolStripMenuItem1, Me.MoveDownToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(162, 158)
        '
        'InsertToolStripMenuItem
        '
        Me.InsertToolStripMenuItem.Name = "InsertToolStripMenuItem"
        Me.InsertToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.InsertToolStripMenuItem.Text = "Insert"
        '
        'MoveUpToolStripMenuItem
        '
        Me.MoveUpToolStripMenuItem.Name = "MoveUpToolStripMenuItem"
        Me.MoveUpToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.MoveUpToolStripMenuItem.Text = "Move Up"
        Me.MoveUpToolStripMenuItem.Visible = False
        '
        'MoveDownToolStripMenuItem
        '
        Me.MoveDownToolStripMenuItem.Name = "MoveDownToolStripMenuItem"
        Me.MoveDownToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.MoveDownToolStripMenuItem.Text = "Move Down"
        Me.MoveDownToolStripMenuItem.Visible = False
        '
        'MoveToTopToolStripMenuItem
        '
        Me.MoveToTopToolStripMenuItem.Name = "MoveToTopToolStripMenuItem"
        Me.MoveToTopToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.MoveToTopToolStripMenuItem.Text = "Move to Top"
        Me.MoveToTopToolStripMenuItem.Visible = False
        '
        'MoveToBottomToolStripMenuItem
        '
        Me.MoveToBottomToolStripMenuItem.Name = "MoveToBottomToolStripMenuItem"
        Me.MoveToBottomToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.MoveToBottomToolStripMenuItem.Text = "Move to Bottom"
        Me.MoveToBottomToolStripMenuItem.Visible = False
        '
        'MoveUpToolStripMenuItem1
        '
        Me.MoveUpToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MoveUpSpaces})
        Me.MoveUpToolStripMenuItem1.Name = "MoveUpToolStripMenuItem1"
        Me.MoveUpToolStripMenuItem1.Size = New System.Drawing.Size(161, 22)
        Me.MoveUpToolStripMenuItem1.Text = "Move Up..."
        Me.MoveUpToolStripMenuItem1.Visible = False
        '
        'MoveUpSpaces
        '
        Me.MoveUpSpaces.Name = "MoveUpSpaces"
        Me.MoveUpSpaces.Size = New System.Drawing.Size(121, 23)
        '
        'MoveDownToolStripMenuItem1
        '
        Me.MoveDownToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MoveDownSpaces})
        Me.MoveDownToolStripMenuItem1.Name = "MoveDownToolStripMenuItem1"
        Me.MoveDownToolStripMenuItem1.Size = New System.Drawing.Size(161, 22)
        Me.MoveDownToolStripMenuItem1.Text = "Move Down..."
        Me.MoveDownToolStripMenuItem1.Visible = False
        '
        'MoveDownSpaces
        '
        Me.MoveDownSpaces.Name = "MoveDownSpaces"
        Me.MoveDownSpaces.Size = New System.Drawing.Size(121, 23)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 392)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(758, 24)
        Me.Panel1.TabIndex = 3
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel, Me.ExitButton, Me.ToolStripSeparator1, Me.FilePathLabel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(758, 24)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'StatusLabel
        '
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(39, 21)
        Me.StatusLabel.Text = "Status"
        '
        'ExitButton
        '
        Me.ExitButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ExitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ExitButton.Image = CType(resources.GetObject("ExitButton.Image"), System.Drawing.Image)
        Me.ExitButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(80, 21)
        Me.ExitButton.Text = "Save && Close"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 24)
        '
        'FilePathLabel
        '
        Me.FilePathLabel.Name = "FilePathLabel"
        Me.FilePathLabel.Size = New System.Drawing.Size(31, 21)
        Me.FilePathLabel.Text = "Path"
        '
        'ToolMaintForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(758, 416)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DGVToolEdit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ToolMaintForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Tool Data"
        CType(Me.DGVToolEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGVToolEdit As DataGridView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents MoveUpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MoveDownToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MoveToTopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MoveToBottomToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MoveUpToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents MoveUpSpaces As ToolStripComboBox
    Friend WithEvents MoveDownToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents MoveDownSpaces As ToolStripComboBox
    Friend WithEvents InsertToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents StatusLabel As ToolStripLabel
    Friend WithEvents ExitButton As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents FilePathLabel As ToolStripLabel
End Class
