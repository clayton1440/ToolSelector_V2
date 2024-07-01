<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SelectionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectionForm))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.SelectionTab = New System.Windows.Forms.TabPage()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.NewInstanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetVisibleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.SearchBox = New System.Windows.Forms.TextBox()
        Me.DGVToolSelection = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ExportButton = New System.Windows.Forms.Button()
        Me.CloseAfterExportCheckBox = New System.Windows.Forms.CheckBox()
        Me.ToolManagementPage = New System.Windows.Forms.TabPage()
        Me.SharedMgmtGroup = New System.Windows.Forms.GroupBox()
        Me.SharedToolListBox = New System.Windows.Forms.CheckedListBox()
        Me.LoadSharedToolsOnStartupCheckbox = New System.Windows.Forms.CheckBox()
        Me.SharedManEditButton = New System.Windows.Forms.Button()
        Me.SharedImportFileButton = New System.Windows.Forms.Button()
        Me.RemoveSelSharedToolButton = New System.Windows.Forms.PictureBox()
        Me.AddSharedToolsButton = New System.Windows.Forms.PictureBox()
        Me.UserMgmtGroup = New System.Windows.Forms.GroupBox()
        Me.UserImportFileButton = New System.Windows.Forms.Button()
        Me.UserManEditButton = New System.Windows.Forms.Button()
        Me.OptionsTab = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DontDarkenMessageBoxCheckbox = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolsCheckedWarningCheckbox = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ExpiredToolsCheckbox = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OutputOptionsGroup = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ThemeSelection = New System.Windows.Forms.DomainUpDown()
        Me.ExportPathLabel = New System.Windows.Forms.TextBox()
        Me.SelectExportPathButton = New System.Windows.Forms.PictureBox()
        Me.AppearanceOptionsGroup = New System.Windows.Forms.GroupBox()
        Me.HighlightExpiredToolsCheckbox = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Helper = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.EP1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.SelectionTab.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DGVToolSelection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ToolManagementPage.SuspendLayout()
        Me.SharedMgmtGroup.SuspendLayout()
        CType(Me.RemoveSelSharedToolButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AddSharedToolsButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UserMgmtGroup.SuspendLayout()
        Me.OptionsTab.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.OutputOptionsGroup.SuspendLayout()
        CType(Me.SelectExportPathButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AppearanceOptionsGroup.SuspendLayout()
        CType(Me.EP1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.SelectionTab)
        Me.TabControl1.Controls.Add(Me.ToolManagementPage)
        Me.TabControl1.Controls.Add(Me.OptionsTab)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = New System.Drawing.Point(0, 0)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(334, 436)
        Me.TabControl1.TabIndex = 3
        Me.TabControl1.TabStop = False
        '
        'SelectionTab
        '
        Me.SelectionTab.Controls.Add(Me.MenuStrip1)
        Me.SelectionTab.Controls.Add(Me.TableLayoutPanel1)
        Me.SelectionTab.Location = New System.Drawing.Point(4, 22)
        Me.SelectionTab.Margin = New System.Windows.Forms.Padding(0)
        Me.SelectionTab.Name = "SelectionTab"
        Me.SelectionTab.Size = New System.Drawing.Size(326, 410)
        Me.SelectionTab.TabIndex = 0
        Me.SelectionTab.Text = "Select"
        Me.SelectionTab.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewInstanceToolStripMenuItem, Me.ResetToolStripMenuItem, Me.ResetVisibleToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(326, 24)
        Me.MenuStrip1.TabIndex = 11
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(326, 410)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.SearchBox)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.Panel2.Size = New System.Drawing.Size(320, 20)
        Me.Panel2.TabIndex = 2
        '
        'SearchBox
        '
        Me.SearchBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SearchBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchBox.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.SearchBox.Location = New System.Drawing.Point(0, 1)
        Me.SearchBox.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.SearchBox.MaxLength = 144
        Me.SearchBox.Name = "SearchBox"
        Me.SearchBox.Size = New System.Drawing.Size(320, 20)
        Me.SearchBox.TabIndex = 0
        Me.SearchBox.Text = "Search..."
        Me.ToolTip1.SetToolTip(Me.SearchBox, "Enter text to filter ID or Description by." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Search '!' to show only expired tools" &
        "." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Search '$' to show only valid tools.")
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVToolSelection.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGVToolSelection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGVToolSelection.Location = New System.Drawing.Point(3, 29)
        Me.DGVToolSelection.Name = "DGVToolSelection"
        Me.DGVToolSelection.RowHeadersVisible = False
        Me.DGVToolSelection.RowHeadersWidth = 24
        Me.DGVToolSelection.Size = New System.Drawing.Size(320, 342)
        Me.DGVToolSelection.StandardTab = True
        Me.DGVToolSelection.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ExportButton)
        Me.Panel1.Controls.Add(Me.CloseAfterExportCheckBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 374)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(326, 36)
        Me.Panel1.TabIndex = 1
        '
        'ExportButton
        '
        Me.ExportButton.Location = New System.Drawing.Point(8, 7)
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
        Me.CloseAfterExportCheckBox.Location = New System.Drawing.Point(207, 10)
        Me.CloseAfterExportCheckBox.Name = "CloseAfterExportCheckBox"
        Me.CloseAfterExportCheckBox.Size = New System.Drawing.Size(110, 17)
        Me.CloseAfterExportCheckBox.TabIndex = 6
        Me.CloseAfterExportCheckBox.Text = "Close After Export"
        Me.CloseAfterExportCheckBox.UseVisualStyleBackColor = True
        '
        'ToolManagementPage
        '
        Me.ToolManagementPage.Controls.Add(Me.SharedMgmtGroup)
        Me.ToolManagementPage.Controls.Add(Me.UserMgmtGroup)
        Me.ToolManagementPage.Location = New System.Drawing.Point(4, 22)
        Me.ToolManagementPage.Name = "ToolManagementPage"
        Me.ToolManagementPage.Padding = New System.Windows.Forms.Padding(3)
        Me.ToolManagementPage.Size = New System.Drawing.Size(326, 410)
        Me.ToolManagementPage.TabIndex = 1
        Me.ToolManagementPage.Text = "Tool Management"
        Me.ToolManagementPage.UseVisualStyleBackColor = True
        '
        'SharedMgmtGroup
        '
        Me.SharedMgmtGroup.Controls.Add(Me.SharedToolListBox)
        Me.SharedMgmtGroup.Controls.Add(Me.LoadSharedToolsOnStartupCheckbox)
        Me.SharedMgmtGroup.Controls.Add(Me.SharedManEditButton)
        Me.SharedMgmtGroup.Controls.Add(Me.SharedImportFileButton)
        Me.SharedMgmtGroup.Controls.Add(Me.RemoveSelSharedToolButton)
        Me.SharedMgmtGroup.Controls.Add(Me.AddSharedToolsButton)
        Me.SharedMgmtGroup.Location = New System.Drawing.Point(6, 74)
        Me.SharedMgmtGroup.Name = "SharedMgmtGroup"
        Me.SharedMgmtGroup.Size = New System.Drawing.Size(312, 187)
        Me.SharedMgmtGroup.TabIndex = 9
        Me.SharedMgmtGroup.TabStop = False
        Me.SharedMgmtGroup.Text = "Shared Tools"
        '
        'SharedToolListBox
        '
        Me.SharedToolListBox.BackColor = System.Drawing.SystemColors.MenuBar
        Me.SharedToolListBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SharedToolListBox.FormattingEnabled = True
        Me.SharedToolListBox.Location = New System.Drawing.Point(6, 42)
        Me.SharedToolListBox.Name = "SharedToolListBox"
        Me.SharedToolListBox.Size = New System.Drawing.Size(298, 105)
        Me.SharedToolListBox.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.SharedToolListBox, "List of Shared Tool Database." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Load/Unload each database individually using the c" &
        "heckboxes.")
        '
        'LoadSharedToolsOnStartupCheckbox
        '
        Me.LoadSharedToolsOnStartupCheckbox.AutoSize = True
        Me.LoadSharedToolsOnStartupCheckbox.Location = New System.Drawing.Point(7, 21)
        Me.LoadSharedToolsOnStartupCheckbox.Name = "LoadSharedToolsOnStartupCheckbox"
        Me.LoadSharedToolsOnStartupCheckbox.Size = New System.Drawing.Size(110, 17)
        Me.LoadSharedToolsOnStartupCheckbox.TabIndex = 18
        Me.LoadSharedToolsOnStartupCheckbox.Text = "Load all at startup"
        Me.ToolTip1.SetToolTip(Me.LoadSharedToolsOnStartupCheckbox, "Uncheck to only load private tools when ToolSelector starts. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Alternatively, use" &
        " ToolSelector SL when desired.")
        Me.LoadSharedToolsOnStartupCheckbox.UseVisualStyleBackColor = True
        '
        'SharedManEditButton
        '
        Me.SharedManEditButton.Enabled = False
        Me.SharedManEditButton.Location = New System.Drawing.Point(14, 154)
        Me.SharedManEditButton.Name = "SharedManEditButton"
        Me.SharedManEditButton.Size = New System.Drawing.Size(90, 23)
        Me.SharedManEditButton.TabIndex = 0
        Me.SharedManEditButton.Text = "Manual Edit..."
        Me.ToolTip1.SetToolTip(Me.SharedManEditButton, "Manually edit the selected shared tool database.")
        Me.SharedManEditButton.UseVisualStyleBackColor = True
        '
        'SharedImportFileButton
        '
        Me.SharedImportFileButton.Enabled = False
        Me.SharedImportFileButton.Location = New System.Drawing.Point(110, 154)
        Me.SharedImportFileButton.Name = "SharedImportFileButton"
        Me.SharedImportFileButton.Size = New System.Drawing.Size(90, 23)
        Me.SharedImportFileButton.TabIndex = 1
        Me.SharedImportFileButton.Text = "Import File..."
        Me.ToolTip1.SetToolTip(Me.SharedImportFileButton, resources.GetString("SharedImportFileButton.ToolTip"))
        Me.SharedImportFileButton.UseVisualStyleBackColor = True
        '
        'RemoveSelSharedToolButton
        '
        Me.RemoveSelSharedToolButton.Image = Global.ToolSelector.My.Resources.Resources.cancel_button_red
        Me.RemoveSelSharedToolButton.Location = New System.Drawing.Point(265, 22)
        Me.RemoveSelSharedToolButton.Name = "RemoveSelSharedToolButton"
        Me.RemoveSelSharedToolButton.Size = New System.Drawing.Size(18, 18)
        Me.RemoveSelSharedToolButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.RemoveSelSharedToolButton.TabIndex = 17
        Me.RemoveSelSharedToolButton.TabStop = False
        Me.ToolTip1.SetToolTip(Me.RemoveSelSharedToolButton, "Remove the selected Shared Tool Database." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This does not delete the database.")
        '
        'AddSharedToolsButton
        '
        Me.AddSharedToolsButton.Image = Global.ToolSelector.My.Resources.Resources.add_button_green_1
        Me.AddSharedToolsButton.Location = New System.Drawing.Point(286, 22)
        Me.AddSharedToolsButton.Name = "AddSharedToolsButton"
        Me.AddSharedToolsButton.Size = New System.Drawing.Size(18, 18)
        Me.AddSharedToolsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.AddSharedToolsButton.TabIndex = 16
        Me.AddSharedToolsButton.TabStop = False
        Me.ToolTip1.SetToolTip(Me.AddSharedToolsButton, "Link a Shared Tool Database." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If the file name entered does not exist, a new data" &
        "base will e created if the user" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "has write permission to the directory specified" &
        ".")
        '
        'UserMgmtGroup
        '
        Me.UserMgmtGroup.Controls.Add(Me.UserImportFileButton)
        Me.UserMgmtGroup.Controls.Add(Me.UserManEditButton)
        Me.UserMgmtGroup.Location = New System.Drawing.Point(6, 6)
        Me.UserMgmtGroup.Name = "UserMgmtGroup"
        Me.UserMgmtGroup.Size = New System.Drawing.Size(312, 62)
        Me.UserMgmtGroup.TabIndex = 8
        Me.UserMgmtGroup.TabStop = False
        Me.UserMgmtGroup.Text = "User Tools"
        '
        'UserImportFileButton
        '
        Me.UserImportFileButton.Location = New System.Drawing.Point(110, 24)
        Me.UserImportFileButton.Name = "UserImportFileButton"
        Me.UserImportFileButton.Size = New System.Drawing.Size(90, 23)
        Me.UserImportFileButton.TabIndex = 1
        Me.UserImportFileButton.Text = "Import File..."
        Me.ToolTip1.SetToolTip(Me.UserImportFileButton, resources.GetString("UserImportFileButton.ToolTip"))
        Me.UserImportFileButton.UseVisualStyleBackColor = True
        '
        'UserManEditButton
        '
        Me.UserManEditButton.Location = New System.Drawing.Point(14, 24)
        Me.UserManEditButton.Name = "UserManEditButton"
        Me.UserManEditButton.Size = New System.Drawing.Size(90, 23)
        Me.UserManEditButton.TabIndex = 0
        Me.UserManEditButton.Text = "Manual Edit"
        Me.ToolTip1.SetToolTip(Me.UserManEditButton, "Manually edit your private tool database.")
        Me.UserManEditButton.UseVisualStyleBackColor = True
        '
        'OptionsTab
        '
        Me.OptionsTab.Controls.Add(Me.GroupBox1)
        Me.OptionsTab.Controls.Add(Me.OutputOptionsGroup)
        Me.OptionsTab.Controls.Add(Me.AppearanceOptionsGroup)
        Me.OptionsTab.Location = New System.Drawing.Point(4, 22)
        Me.OptionsTab.Name = "OptionsTab"
        Me.OptionsTab.Padding = New System.Windows.Forms.Padding(3)
        Me.OptionsTab.Size = New System.Drawing.Size(326, 410)
        Me.OptionsTab.TabIndex = 2
        Me.OptionsTab.Text = "Options"
        Me.OptionsTab.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DontDarkenMessageBoxCheckbox)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ToolsCheckedWarningCheckbox)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ExpiredToolsCheckbox)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 169)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(312, 91)
        Me.GroupBox1.TabIndex = 63
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Behavior"
        '
        'DontDarkenMessageBoxCheckbox
        '
        Me.DontDarkenMessageBoxCheckbox.AutoSize = True
        Me.DontDarkenMessageBoxCheckbox.Location = New System.Drawing.Point(260, 67)
        Me.DontDarkenMessageBoxCheckbox.Name = "DontDarkenMessageBoxCheckbox"
        Me.DontDarkenMessageBoxCheckbox.Size = New System.Drawing.Size(15, 14)
        Me.DontDarkenMessageBoxCheckbox.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.DontDarkenMessageBoxCheckbox, "If checked, warning messages will never display in dark mode.")
        Me.DontDarkenMessageBoxCheckbox.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(161, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Don't darken warning messages:"
        '
        'ToolsCheckedWarningCheckbox
        '
        Me.ToolsCheckedWarningCheckbox.AutoSize = True
        Me.ToolsCheckedWarningCheckbox.Location = New System.Drawing.Point(260, 21)
        Me.ToolsCheckedWarningCheckbox.Name = "ToolsCheckedWarningCheckbox"
        Me.ToolsCheckedWarningCheckbox.Size = New System.Drawing.Size(15, 14)
        Me.ToolsCheckedWarningCheckbox.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.ToolsCheckedWarningCheckbox, "A warning displays before ToolSelector exits if tools are checked but no export w" &
        "as made.")
        Me.ToolsCheckedWarningCheckbox.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(229, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Show warning before closing without exporting:"
        '
        'ExpiredToolsCheckbox
        '
        Me.ExpiredToolsCheckbox.AutoSize = True
        Me.ExpiredToolsCheckbox.Location = New System.Drawing.Point(260, 44)
        Me.ExpiredToolsCheckbox.Name = "ExpiredToolsCheckbox"
        Me.ExpiredToolsCheckbox.Size = New System.Drawing.Size(15, 14)
        Me.ExpiredToolsCheckbox.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.ExpiredToolsCheckbox, "A warning displays before creating an export if any tools are expired.")
        Me.ExpiredToolsCheckbox.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Show warning before exporting expired tools:"
        '
        'OutputOptionsGroup
        '
        Me.OutputOptionsGroup.Controls.Add(Me.Label4)
        Me.OutputOptionsGroup.Controls.Add(Me.ThemeSelection)
        Me.OutputOptionsGroup.Controls.Add(Me.ExportPathLabel)
        Me.OutputOptionsGroup.Controls.Add(Me.SelectExportPathButton)
        Me.OutputOptionsGroup.Location = New System.Drawing.Point(6, 6)
        Me.OutputOptionsGroup.Name = "OutputOptionsGroup"
        Me.OutputOptionsGroup.Size = New System.Drawing.Size(312, 74)
        Me.OutputOptionsGroup.TabIndex = 63
        Me.OutputOptionsGroup.TabStop = False
        Me.OutputOptionsGroup.Text = "Output"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Export File Path"
        '
        'ThemeSelection
        '
        Me.ThemeSelection.Enabled = False
        Me.ThemeSelection.Items.Add("Light")
        Me.ThemeSelection.Items.Add("System")
        Me.ThemeSelection.Items.Add("Dark")
        Me.ThemeSelection.Location = New System.Drawing.Point(219, 11)
        Me.ThemeSelection.Name = "ThemeSelection"
        Me.ThemeSelection.Size = New System.Drawing.Size(87, 20)
        Me.ThemeSelection.TabIndex = 0
        Me.ThemeSelection.Text = "System"
        Me.ThemeSelection.Visible = False
        '
        'ExportPathLabel
        '
        Me.ExportPathLabel.Location = New System.Drawing.Point(12, 37)
        Me.ExportPathLabel.Name = "ExportPathLabel"
        Me.ExportPathLabel.ReadOnly = True
        Me.ExportPathLabel.Size = New System.Drawing.Size(263, 20)
        Me.ExportPathLabel.TabIndex = 3
        Me.ExportPathLabel.TabStop = False
        '
        'SelectExportPathButton
        '
        Me.SelectExportPathButton.Image = CType(resources.GetObject("SelectExportPathButton.Image"), System.Drawing.Image)
        Me.SelectExportPathButton.Location = New System.Drawing.Point(281, 37)
        Me.SelectExportPathButton.Name = "SelectExportPathButton"
        Me.SelectExportPathButton.Size = New System.Drawing.Size(20, 20)
        Me.SelectExportPathButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.SelectExportPathButton.TabIndex = 3
        Me.SelectExportPathButton.TabStop = False
        Me.ToolTip1.SetToolTip(Me.SelectExportPathButton, "Click to specify the location to save the CSV export to.")
        '
        'AppearanceOptionsGroup
        '
        Me.AppearanceOptionsGroup.Controls.Add(Me.HighlightExpiredToolsCheckbox)
        Me.AppearanceOptionsGroup.Controls.Add(Me.Label9)
        Me.AppearanceOptionsGroup.Controls.Add(Me.Helper)
        Me.AppearanceOptionsGroup.Controls.Add(Me.Label6)
        Me.AppearanceOptionsGroup.Location = New System.Drawing.Point(6, 86)
        Me.AppearanceOptionsGroup.Name = "AppearanceOptionsGroup"
        Me.AppearanceOptionsGroup.Size = New System.Drawing.Size(312, 77)
        Me.AppearanceOptionsGroup.TabIndex = 62
        Me.AppearanceOptionsGroup.TabStop = False
        Me.AppearanceOptionsGroup.Text = "Appearance"
        '
        'HighlightExpiredToolsCheckbox
        '
        Me.HighlightExpiredToolsCheckbox.AutoSize = True
        Me.HighlightExpiredToolsCheckbox.Location = New System.Drawing.Point(260, 51)
        Me.HighlightExpiredToolsCheckbox.Name = "HighlightExpiredToolsCheckbox"
        Me.HighlightExpiredToolsCheckbox.Size = New System.Drawing.Size(15, 14)
        Me.HighlightExpiredToolsCheckbox.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.HighlightExpiredToolsCheckbox, "Highlight expired tools in the selection panel with a yellow color." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Red warning " &
        "indicators display regardless of this setting.")
        Me.HighlightExpiredToolsCheckbox.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(113, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Highlight expired tools:"
        '
        'Helper
        '
        Me.Helper.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Helper.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Helper.Location = New System.Drawing.Point(138, 21)
        Me.Helper.Name = "Helper"
        Me.Helper.Size = New System.Drawing.Size(137, 20)
        Me.Helper.TabIndex = 2
        Me.Helper.Text = "Tool Selector"
        Me.ToolTip1.SetToolTip(Me.Helper, "Enter some text to help identify this instance of ToolSelector.")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Title Bar:"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 30000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'EP1
        '
        Me.EP1.ContainerControl = Me
        Me.EP1.Icon = CType(resources.GetObject("EP1.Icon"), System.Drawing.Icon)
        '
        'SelectionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(334, 436)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(350, 450)
        Me.Name = "SelectionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Tool Selector"
        Me.TabControl1.ResumeLayout(False)
        Me.SelectionTab.ResumeLayout(False)
        Me.SelectionTab.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DGVToolSelection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolManagementPage.ResumeLayout(False)
        Me.SharedMgmtGroup.ResumeLayout(False)
        Me.SharedMgmtGroup.PerformLayout()
        CType(Me.RemoveSelSharedToolButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AddSharedToolsButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UserMgmtGroup.ResumeLayout(False)
        Me.OptionsTab.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.OutputOptionsGroup.ResumeLayout(False)
        Me.OutputOptionsGroup.PerformLayout()
        CType(Me.SelectExportPathButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AppearanceOptionsGroup.ResumeLayout(False)
        Me.AppearanceOptionsGroup.PerformLayout()
        CType(Me.EP1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents SelectionTab As TabPage
    Friend WithEvents DGVToolSelection As DataGridView
    Friend WithEvents ToolManagementPage As TabPage
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ExportButton As Button
    Friend WithEvents OptionsTab As TabPage
    Friend WithEvents Label4 As Label
    Friend WithEvents SelectExportPathButton As PictureBox
    Friend WithEvents ExportPathLabel As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Helper As TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents SearchBox As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents NewInstanceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetVisibleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SharedMgmtGroup As GroupBox
    Friend WithEvents SharedImportFileButton As Button
    Friend WithEvents SharedManEditButton As Button
    Friend WithEvents UserMgmtGroup As GroupBox
    Friend WithEvents UserImportFileButton As Button
    Friend WithEvents UserManEditButton As Button
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AppearanceOptionsGroup As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ThemeSelection As DomainUpDown
    Friend WithEvents CloseAfterExportCheckBox As CheckBox
    Friend WithEvents OutputOptionsGroup As GroupBox
    Friend WithEvents AddSharedToolsButton As PictureBox
    Friend WithEvents RemoveSelSharedToolButton As PictureBox
    Friend WithEvents SharedToolListBox As CheckedListBox
    Friend WithEvents EP1 As ErrorProvider
    Friend WithEvents LoadSharedToolsOnStartupCheckbox As CheckBox
    Friend WithEvents HighlightExpiredToolsCheckbox As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ToolsCheckedWarningCheckbox As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ExpiredToolsCheckbox As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DontDarkenMessageBoxCheckbox As CheckBox
    Friend WithEvents Label3 As Label
End Class
