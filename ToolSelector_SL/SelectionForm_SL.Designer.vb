<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SelectionForm_SL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectionForm_SL))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SearchBox = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.NewInstanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetVisibleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DGVToolSelection = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ExportButton = New System.Windows.Forms.Button()
        Me.CloseAfterExportCheckBox = New System.Windows.Forms.CheckBox()
        Me.MenuStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DGVToolSelection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'SearchBox
        '
        Me.SearchBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SearchBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchBox.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.SearchBox.Location = New System.Drawing.Point(0, 0)
        Me.SearchBox.MaxLength = 144
        Me.SearchBox.Name = "SearchBox"
        Me.SearchBox.Size = New System.Drawing.Size(328, 20)
        Me.SearchBox.TabIndex = 0
        Me.SearchBox.Text = "Search..."
        Me.ToolTip1.SetToolTip(Me.SearchBox, "Search")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewInstanceToolStripMenuItem, Me.ResetToolStripMenuItem, Me.ResetVisibleToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(334, 24)
        Me.MenuStrip1.TabIndex = 12
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.ToolTip1.SetToolTip(Me.MenuStrip1, "Press ALT to toggle visibility")
        Me.MenuStrip1.Visible = False
        '
        'NewInstanceToolStripMenuItem
        '
        Me.NewInstanceToolStripMenuItem.Name = "NewInstanceToolStripMenuItem"
        Me.NewInstanceToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewInstanceToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.NewInstanceToolStripMenuItem.Text = "New Instance"
        Me.NewInstanceToolStripMenuItem.ToolTipText = "Start a new instance of ToolSelector"
        '
        'ResetToolStripMenuItem
        '
        Me.ResetToolStripMenuItem.Name = "ResetToolStripMenuItem"
        Me.ResetToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.ResetToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.ResetToolStripMenuItem.Text = "Reset"
        Me.ResetToolStripMenuItem.ToolTipText = "Uncheck all tools and reload"
        '
        'ResetVisibleToolStripMenuItem
        '
        Me.ResetVisibleToolStripMenuItem.Name = "ResetVisibleToolStripMenuItem"
        Me.ResetVisibleToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.ResetVisibleToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
        Me.ResetVisibleToolStripMenuItem.Text = "Reset Visible"
        Me.ResetVisibleToolStripMenuItem.ToolTipText = "Uncheck visible tools only"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DGVToolSelection, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(334, 436)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.SearchBox)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(328, 24)
        Me.Panel2.TabIndex = 2
        '
        'DGVToolSelection
        '
        Me.DGVToolSelection.AllowUserToAddRows = False
        Me.DGVToolSelection.AllowUserToDeleteRows = False
        Me.DGVToolSelection.AllowUserToResizeRows = False
        Me.DGVToolSelection.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVToolSelection.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVToolSelection.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVToolSelection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVToolSelection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGVToolSelection.Location = New System.Drawing.Point(3, 33)
        Me.DGVToolSelection.Name = "DGVToolSelection"
        Me.DGVToolSelection.RowHeadersVisible = False
        Me.DGVToolSelection.RowHeadersWidth = 24
        Me.DGVToolSelection.Size = New System.Drawing.Size(328, 358)
        Me.DGVToolSelection.StandardTab = True
        Me.DGVToolSelection.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ExportButton)
        Me.Panel1.Controls.Add(Me.CloseAfterExportCheckBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 397)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(328, 36)
        Me.Panel1.TabIndex = 1
        '
        'ExportButton
        '
        Me.ExportButton.Location = New System.Drawing.Point(8, 8)
        Me.ExportButton.Name = "ExportButton"
        Me.ExportButton.Size = New System.Drawing.Size(59, 20)
        Me.ExportButton.TabIndex = 2
        Me.ExportButton.Text = "Export"
        Me.ExportButton.UseVisualStyleBackColor = True
        '
        'CloseAfterExportCheckBox
        '
        Me.CloseAfterExportCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseAfterExportCheckBox.AutoSize = True
        Me.CloseAfterExportCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CloseAfterExportCheckBox.Location = New System.Drawing.Point(209, 11)
        Me.CloseAfterExportCheckBox.Name = "CloseAfterExportCheckBox"
        Me.CloseAfterExportCheckBox.Size = New System.Drawing.Size(110, 17)
        Me.CloseAfterExportCheckBox.TabIndex = 6
        Me.CloseAfterExportCheckBox.Text = "Close After Export"
        Me.CloseAfterExportCheckBox.UseVisualStyleBackColor = True
        '
        'SelectionForm_SL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(334, 436)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(350, 450)
        Me.Name = "SelectionForm_SL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Tool Selector SL"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DGVToolSelection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents SearchBox As TextBox
    Friend WithEvents DGVToolSelection As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ExportButton As Button
    Friend WithEvents CloseAfterExportCheckBox As CheckBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents NewInstanceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetVisibleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
End Class
