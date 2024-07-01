
Imports System.ComponentModel
Imports Excel = Microsoft.Office.Interop.Excel
Imports ToolSelector.Data
Public Class SelectionForm
    Dim Starting = True
    Dim ToolsExported As Boolean = False
    Dim Editing As Boolean = False
    Dim Importing As Boolean = False 'if the /import argument was passed, start import after selectionform is shown.
    Dim ImportedPath As String = ""
    Public Theme As String = "System"

    Dim UserTools As List(Of Tool)
    Dim SharedTools As List(Of Tool)

    Dim ToolGridBinding As New BindingSource

    Public UserToolPath As String = "C:\Users\" & Environment.UserName & "\AppData\Roaming\ToolSelector\Tools.tsd"
    Public TempUploadPath As String = "C:\Users\" & Environment.UserName & "\AppData\Roaming\Temp\ToolUploadTemp.tsd"
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'SplashScreen.Show()
        'Application.DoEvents()

        Me.KeyPreview = True 'allow app to read keypresses before the underlying control receives the key. 

        Dim Args() As String = Environment.GetCommandLineArgs
        If Args(0).Contains("bin\Debug") Then Me.Text &= " - [Debug]"
        If Args(0).Contains("bin\Release") Then Me.Text &= " - Release Candidate"
        If Args.Count > 2 Then
            If Args(1).ToLower.Contains("/edit") Then
                Dim EditForm As New ToolMaintForm(Args(2))
                EditForm.ShowDialog()
                Application.Exit()
                End
            ElseIf Args(1).ToLower.Contains("/import") Then
                Importing = True
                ImportedPath = Args(2)
            ElseIf Args(1).ToLower.Contains("/link") Then
                If Args(2).ToLower.Trim.EndsWith(".tsd") Then
                    Dim LinkList As List(Of String) = Config.SharedToolPath
                    LinkList.Add(Args(2))
                    Config.SharedToolPath = LinkList
                    Dim dm As New DynamicMessageBox("Link Success!",, Config.DisableDarkMessageBox)
                    dm.ShowDialog()
                    dm.Dispose()
                    Application.Exit()
                    End
                End If
            End If
        End If


        Dim CfgHeight As String = Config.FormHeight
        Dim CfgWidth As String = Config.FormWidth
        Dim CfgXPos As String = Config.FormXPos
        Dim CfgYPos As String = Config.FormYPos
        Dim DisplayScale As Double = Management.DisplayScale(Me)

        If String.IsNullOrWhiteSpace(CfgHeight) Then CfgHeight = "0"
        If String.IsNullOrWhiteSpace(CfgWidth) Then CfgWidth = "0"
        If String.IsNullOrWhiteSpace(CfgXPos) Then CfgXPos = "428"
        If String.IsNullOrWhiteSpace(CfgYPos) Then CfgYPos = "316"

        If DisplayScale <> 1 Then
            CfgWidth = Math.Round(CfgWidth * DisplayScale)
            CfgHeight = Math.Round(CfgHeight * DisplayScale)
        End If

        ' If both height and width are set in configs, then resize the form now
        If Not String.IsNullOrWhiteSpace(CfgHeight) AndAlso Not String.IsNullOrWhiteSpace(CfgWidth) Then
            Me.Size = New Size(CInt(CfgWidth), CInt(CfgHeight))
        End If

        ' If both x and y position are set in configs, then move form now. Check if stored positions are valid, if not use default of 428,316
        If Not String.IsNullOrWhiteSpace(CfgXPos) AndAlso Not String.IsNullOrWhiteSpace(CfgYPos) Then


            ' Convert the configuration values to integers
            Dim xPos As Integer
            Dim yPos As Integer
            If Integer.TryParse(CfgXPos, xPos) AndAlso Integer.TryParse(CfgYPos, yPos) Then
                ' Check if the stored position is within the bounds of any screen
                Dim screenBounds As Rectangle = Screen.GetBounds(New Point(xPos, yPos))
                If screenBounds.Contains(xPos, yPos) Then
                    Me.Location = New Point(xPos, yPos)
                Else
                    ' Position is not within the bounds of any screen, so use default
                    Me.Location = New Point(428, 316)
                End If
            Else
                ' Configuration values are not valid integers, use default position
                Me.Location = New Point(428, 316)
            End If
        Else
            ' x and y position not set in configs, use default position
            Me.Location = New Point(428, 316)
        End If

        Theme = Config.Theme
        If Theme = "Dark" Then
            DarkMode.UseImmersiveDarkMode(Me.Handle, True)
            SwitchDarkMode(True)
        End If

        DontDarkenMessageBoxCheckbox.Checked = Config.DisableDarkMessageBox
        ExpiredToolsCheckbox.Checked = Config.CheckExpiredToolsOnExport
        ToolsCheckedWarningCheckbox.Checked = Config.ToolsCheckedWarning
        HighlightExpiredToolsCheckbox.Checked = Config.HighlightExpiredTools
        LoadSharedToolsOnStartupCheckbox.Checked = Config.LoadSharedToolsOnOpen
        CloseAfterExportCheckBox.Checked = Config.CloseAfterExport
        ExportPathLabel.Text = Config.ExportPath.ToString

        If Config.SharedToolPath IsNot Nothing Then
            For i = 0 To Config.SharedToolPath.Count - 1
                SharedToolListBox.Items.Add(Config.SharedToolPath(i))
                SharedToolListBox.SetItemChecked(i, LoadSharedToolsOnStartupCheckbox.Checked)
            Next
        End If


        LoadTools()


        Starting = False
    End Sub

    Private Sub Wait(interval As Integer)
        Dim sw As New Stopwatch
        sw.Start()
        Do While sw.ElapsedMilliseconds < interval
            Application.DoEvents()
        Loop
        sw.Stop()
    End Sub 'equivalent to Thread.Sleep() but allows UI to remain responsive. not used in favor of async tasks

    Private Sub LoadTools(Optional ResetSelection As Boolean = False)
        Console.WriteLine("LoadTools()")
        'get selected tools and try to reselect them after reload
        Dim SelectedTools As New List(Of String)
        If Not ResetSelection Then
            For i = 0 To DGVToolSelection.Rows.Count - 1
                If DGVToolSelection.Rows(i).Cells(" ").Value = True Then
                    SelectedTools.Add(DGVToolSelection.Rows(i).Cells("ID").Value)
                End If
            Next
        End If

        Dim ToolTable As New DataTable
        'Define the datatable to load tools into for selection
        ToolTable.Columns.Add(New DataColumn With {.ColumnName = " ", .DataType = GetType(Boolean)})
        ToolTable.Columns.Add(New DataColumn With {.ColumnName = "ID", .DataType = GetType(String)})
        ToolTable.Columns.Add(New DataColumn With {.ColumnName = "Description", .DataType = GetType(String)})
        ToolTable.Columns.Add(New DataColumn With {.ColumnName = "CalDueDate", .DataType = GetType(Date), .[ReadOnly] = True})

        'read the tools from ToolMang and load into the datatable
        UserTools = Tool.LoadTools(UserToolPath)
        For Each u As Tool In UserTools
            ToolTable.Rows.Add(SelectedTools.Contains(u.ToolID), u.ToolID, u.ToolDescription, u.ToolCalibrationDueDate)
        Next

        If SharedToolListBox.Items.Count > 0 Then
            For i = 0 To SharedToolListBox.Items.Count - 1
                If SharedToolListBox.GetItemChecked(i) Then
                    Dim sTools As List(Of Tool) = Tool.LoadTools(SharedToolListBox.Items(i).ToString)
                    For Each s As Tool In sTools
                        ToolTable.Rows.Add(SelectedTools.Contains(s.ToolID), s.ToolID, s.ToolDescription, s.ToolCalibrationDueDate)
                    Next
                End If
            Next
        End If

        'bind the datatable to the datagridview
        ToolGridBinding.DataSource = ToolTable
        Try
            LoadTools_Fmt()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadTools_Fmt()
        DGVToolSelection.DataSource = New DataTable
        DGVToolSelection.DataSource = ToolGridBinding

        DGVToolSelection.Columns("ID").ReadOnly = True
        DGVToolSelection.Columns("Description").ReadOnly = True
        DGVToolSelection.Columns(" ").FillWeight = 15
        DGVToolSelection.Columns("ID").FillWeight = 35
        DGVToolSelection.Columns("CalDueDate").Visible = False

        ' Check for any expired tools and set a warning
        For i = 0 To DGVToolSelection.Rows.Count - 1
            Dim cdd As Date = Date.Parse(DGVToolSelection.Rows(i).Cells(3).Value)
            If cdd <> Nothing AndAlso cdd > Date.Parse("1/1/1901") AndAlso cdd < Date.Today Then
                DGVToolSelection.Rows(i).Cells("ID").ErrorText = $"Expired on {cdd.ToShortDateString}"
                If Config.HighlightExpiredTools Then
                    DGVToolSelection.Rows(i).Cells(" ").Style.BackColor = Color.Khaki
                    DGVToolSelection.Rows(i).Cells(" ").Style.SelectionBackColor = Color.LightCoral
                    DGVToolSelection.Rows(i).Cells("ID").Style.BackColor = Color.Khaki
                    'DGVToolSelection.Rows(i).Cells("ID").Style.SelectionBackColor = Color.LightCoral
                    DGVToolSelection.Rows(i).Cells("Description").Style.BackColor = Color.Khaki
                    'DGVToolSelection.Rows(i).Cells("Description").Style.SelectionBackColor = Color.LightCoral
                End If
            End If
        Next
    End Sub

    Private Function ToolsChecked() As Boolean
        For i = 0 To DGVToolSelection.Rows.Count - 1
            If DGVToolSelection.Rows(i).Cells(" ").Value = True Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Config.ToolsCheckedWarning AndAlso ToolsChecked And Not ToolsExported Then
            Dim dMsg As New DynamicMessageBox("Tools are selected but no export was made. Exit?", "Not Exported", Config.DisableDarkMessageBox, Management.GetCenterPoint(Me))
            dMsg.Button1Text = "Exit"
            dMsg.Button1DialogResult = DialogResult.Yes
            dMsg.Button2Text = "Cancel"
            dMsg.Button2DialogResult = DialogResult.No
            dMsg.Checkbox1Text = "Don't ask again"

            Dim MsgResult As DialogResult = dMsg.ShowDialog
            If Not MsgResult = DialogResult.Yes Then
                'don't exit
                e.Cancel = True
            Else
                If dMsg.Checkbox1Checked Then
                    Config.ToolsCheckedWarning = False
                    ToolsCheckedWarningCheckbox.Checked = False
                End If
            End If
            dMsg.Dispose()
        End If
    End Sub

    Private Async Sub ExportTools() Handles ExportButton.Click
        Console.WriteLine("ExportTools()")
        If String.IsNullOrWhiteSpace(ExportPathLabel.Text) Then
            'if the export path is not set, open the save file dialog when the user clicks export.
            Dim SaveDialog As New SaveFileDialog
            SaveDialog.Filter = "CSV (Comma Separated Values)|*.csv" 'only allowing .csv to be selected in the dropdown. 
            SaveDialog.FileName = "ToolExport.csv"
            SaveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) 'set the initial dir to the user's documents folder.
            'Using SpecialFolder since some users have relocated their desktop and documents folders away from OneDrive
            SaveDialog.Title = "Set Export Location"
            SaveDialog.OverwritePrompt = False 'don't warn when overwriting
            SaveDialog.CreatePrompt = False 'dont warn when file does not exist
            SaveDialog.AddExtension = True 'add .csv if not present or another extension is typed.

            Dim Result As DialogResult = SaveDialog.ShowDialog()

            If Result = DialogResult.OK Then
                Config.ExportPath = SaveDialog.FileName 'set the export path in the user's config so they don't have to select again. 
                ExportPathLabel.Text = SaveDialog.FileName
            Else
                Exit Sub
            End If
        End If

        Dim ExportString As String = "substituteflag|testid|notes|toolid|locationbuildingid|locationroomid"
        'This first line must be present for Velocity to recognize the file.
        'each additional line follows this format. the only fields used are |notes| and |toolid|, the rest are blank.

        Dim ExpiredTools As New List(Of String)

        For i = 0 To DGVToolSelection.Rows.Count - 1
            If DGVToolSelection.Rows(i).Cells(" ").Value = True And Not DGVToolSelection.Rows(i).IsNewRow Then
                'loop thru each row of the DGV, and if row is selected, add the tool to the export string. 
                If DGVToolSelection.Rows(i).Cells("ID").ErrorText <> "" Then
                    ExpiredTools.Add($"{DGVToolSelection.Rows(i).Cells("ID").Value} - {DGVToolSelection.Rows(i).Cells("Description").Value}")
                End If
                ExportString &= vbCrLf & "||" & DGVToolSelection.Rows(i).Cells("Description").Value & "|" & DGVToolSelection.Rows(i).Cells("ID").Value & "||"
            End If
        Next

        If ExpiredTools.Count > 0 AndAlso Config.CheckExpiredToolsOnExport Then
            Dim dMsg As New DynamicMessageBox("The following tools are expired and should not be exported:" & vbCrLf & vbCrLf & String.Join(vbCrLf, ExpiredTools) & vbCrLf & vbCrLf & vbCrLf & "Export Anyway?", "Expired Tools", Config.DisableDarkMessageBox, Management.GetCenterPoint(Me))
            dMsg.Button1Text = "Export"
            dMsg.Button1DialogResult = DialogResult.OK
            dMsg.Button2Text = "Cancel"
            dMsg.Button2DialogResult = DialogResult.Cancel
            dMsg.Checkbox1Text = "Don't ask again"
            dMsg.ShowDialog()
            Dim dontCheck As Boolean = dMsg.Checkbox1Checked
            If Not dMsg.DialogResult = DialogResult.OK Then Exit Sub
            If dontCheck Then
                Config.CheckExpiredToolsOnExport = False
                ExpiredToolsCheckbox.Checked = False
            End If
        End If

        IO.File.WriteAllText(ExportPathLabel.Text, ExportString) 'write the string to a .csv file. This overwrites the previous text if the file is already present.

        ToolsExported = True 'application no longer displays a warning when closing. 

        ExportButton.Text = "Done!" 'this resets back to 'Export' if a selection is changed in the DGV

        Await Task.Delay(1000) 'after 1 second, close the ToolSelector if that setting is enabled. 
        If Config.CloseAfterExport Then
            Application.Exit()
            End
        End If
    End Sub

    Private Sub DGVUserTools_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVToolSelection.CellClick
        If e.ColumnIndex = DGVToolSelection.Columns(" ").Index Then
            ToolsExported = False
            ExportButton.Text = "Export"
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Application.Exit()
        End
    End Sub

    Private Sub CloseAfterExportCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles CloseAfterExportCheckBox.CheckedChanged
        If Not Starting Then Config.CloseAfterExport = CloseAfterExportCheckBox.Checked
    End Sub


    Private Sub SetPathButton_Click() Handles SelectExportPathButton.Click
        Dim SaveDialog As New SaveFileDialog
        SaveDialog.Filter = "CSV (Comma Separated Values)|*.csv"
        SaveDialog.FileName = "ToolExport.csv"
        SaveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        SaveDialog.Title = "Set Export Location"
        SaveDialog.OverwritePrompt = False
        SaveDialog.CreatePrompt = False
        SaveDialog.AddExtension = True
        Dim Result As DialogResult = SaveDialog.ShowDialog()

        If Result = DialogResult.OK Then
            Config.ExportPath = SaveDialog.FileName
            ExportPathLabel.Text = SaveDialog.FileName
        End If
    End Sub

    Private Sub Helper_TextChanged(sender As Object, e As EventArgs) Handles Helper.TextChanged
        If Starting OrElse Helper.Text = "Tool Selector" Then Exit Sub
        If String.IsNullOrWhiteSpace(Helper.Text) Then
            Me.Text = "Tool Selector"
        Else
            Me.Text = Helper.Text & " - Tool Selector"
        End If

    End Sub

    Private Sub Helper_Enter(sender As Object, e As EventArgs) Handles Helper.Enter
        If Helper.Text = "Tool Selector" Then
            Helper.Text = ""
            Helper.ForeColor = SystemColors.WindowText
            Helper.Font = New Font(Helper.Font, FontStyle.Regular)
        End If
    End Sub

    Private Sub Helper_Leave(sender As Object, e As EventArgs) Handles Helper.Leave
        If String.IsNullOrWhiteSpace(Helper.Text) Then
            Helper.Text = "Tool Selector"
            Helper.ForeColor = SystemColors.GrayText
            Helper.Font = New Font(Helper.Font, FontStyle.Italic)
        End If
    End Sub

    Private Sub ThemeSelection_MouseWheel(sender As Object, e As HandledMouseEventArgs) Handles ThemeSelection.MouseWheel
        e.Handled = True
        Dim numUpDown As DomainUpDown = DirectCast(sender, DomainUpDown)

        Dim direction As Integer = If(e.Delta > 0, 5, -5)
        If direction > 0 Then
            numUpDown.UpButton()
        ElseIf direction < 0 Then
            numUpDown.DownButton()
        End If
    End Sub

    Private Sub FilterBox_TextChanged(sender As Object, e As EventArgs) Handles SearchBox.TextChanged
        If Not String.IsNullOrWhiteSpace(SearchBox.Text) AndAlso Not SearchBox.Text = "Search..." Then
            If SearchBox.Text = "!" Then
                ToolGridBinding.Filter = $"[CalDueDate] < '{Date.Today.ToShortDateString}'"
            ElseIf SearchBox.Text = "$" Then
                ToolGridBinding.Filter = $"[CalDueDate] >= '{Date.Today.ToShortDateString}'"
            Else
                Dim FilterText As String = $"[ID] Like '*{SearchBox.Text}*' OR [Description] LIKE '*{SearchBox.Text}*'"
                ToolGridBinding.Filter = FilterText
            End If
        Else
            ToolGridBinding.Filter = ""
        End If
        If Not Starting Then LoadTools_Fmt()
    End Sub
    Private Sub SearchBox_Enter(sender As Object, e As EventArgs) Handles SearchBox.Enter
        If SearchBox.Text = "Search..." Then
            SearchBox.Text = ""
            SearchBox.ForeColor = SystemColors.WindowText ' Change the text color to black when editing.
            SearchBox.Font = New Font(SearchBox.Font, FontStyle.Regular) ' Remove italics.
        End If
    End Sub

    Private Sub SearchBox_Leave() Handles SearchBox.Leave
        If String.IsNullOrWhiteSpace(SearchBox.Text) Then
            SearchBox.Text = "Search..."
            SearchBox.ForeColor = SystemColors.WindowFrame ' Change the text color to gray.
            SearchBox.Font = New Font(SearchBox.Font, FontStyle.Italic) ' Apply italics.
        End If
    End Sub

    Private Async Sub NewInstanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewInstanceToolStripMenuItem.Click
        'open a new instance of ToolSelector
        'menu strip not visible, shortcut is CTRL+SHIFT+N
        Process.Start(Application.ExecutablePath)

        Await Task.Delay(250)

        Me.Location = New Point(Me.Location.X + 32, Me.Location.Y + 32)
        MenuStrip1.Visible = False
    End Sub

    Private Sub ResetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetToolStripMenuItem.Click
        'reset all tools
        'menu strip not visible, CTRL+R
        LoadTools(True)
        Helper.Text = "Tool Selector"
        SearchBox.Text = ""
        SearchBox_Leave()
        ToolsExported = False
        ExportButton.Text = "Export"
        MenuStrip1.Visible = False
    End Sub

    Private Sub ResetVisibleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetVisibleToolStripMenuItem.Click
        'reset visible tools only, useful if searching
        'CRTL+SHIFT+R
        DGVToolSelection.EndEdit()

        For i = 0 To DGVToolSelection.Rows.Count - 1
            If DGVToolSelection.Rows(i).Visible Then
                DGVToolSelection.Rows(i).Cells(" ").Value = False
            End If
        Next
        MenuStrip1.Visible = False
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        Process.Start("https://blackhawktechnologies.com/toolselector/help")
    End Sub

    Private Sub SelectionForm_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'toggle visibility of menu strip when the ALT key is pressed.
        If e.KeyCode = Keys.Menu Then
            MenuStrip1.Visible = Not MenuStrip1.Visible
            Me.Focus()
        End If
    End Sub

    Private Sub SelectionForm_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        Dim StoreWidth As Integer = Me.Size.Width
        Dim StoreHeight As Integer = Me.Size.Height
        Dim DisplayScale As Double = Management.DisplayScale(Me)

        If DisplayScale <> 1 Then
            StoreWidth = Math.Round(StoreWidth / DisplayScale)
            StoreHeight = Math.Round(StoreHeight / DisplayScale)
        End If

        Config.FormHeight = StoreHeight
        Config.FormWidth = StoreWidth
    End Sub

    Private Sub SelectionForm_Move(sender As Object, e As EventArgs) Handles Me.Move
        Dim StoreX As Integer = Me.Location.X
        Dim StoreY As Integer = Me.Location.Y

        Config.FormXPos = StoreX
        Config.FormYPos = StoreY
    End Sub

    Private Sub UserManEditButton_Click(sender As Object, e As EventArgs) Handles UserManEditButton.Click
        Dim EditForm As New ToolMaintForm(UserToolPath,, Management.GetCenterPoint(Me))
        AddHandler EditForm.FormClosed, Sub()
                                            LoadTools()
                                        End Sub
        EditForm.Show()
        LoadTools()
    End Sub
    Private Sub SharedManEditButton_Click(sender As Object, e As EventArgs) Handles SharedManEditButton.Click
        Application.UseWaitCursor = True
        Wait(15)

        Dim selFilePath As String = SharedToolListBox.SelectedItem.ToString
        If Management.CanEditFile(selFilePath) Then
            Application.UseWaitCursor = False
            Dim EditForm As New ToolMaintForm(selFilePath,, Management.GetCenterPoint(Me))
            AddHandler EditForm.FormClosed, Sub()
                                                LoadTools()
                                            End Sub
            EditForm.Show()
        Else
            Application.UseWaitCursor = False
            Dim dm As New DynamicMessageBox("Insufficient permissions to edit this Tool Share.", "Access Denied", Config.DisableDarkMessageBox, Management.GetCenterPoint(Me))
            dm.ShowDialog()
            dm.Dispose()
        End If

    End Sub


    Private Sub UserImportFileButton_Click(sender As Object, e As EventArgs) Handles UserImportFileButton.Click

        ImportFile(UserToolPath)

    End Sub

    Private Sub SharedImportFileButton_Click(sender As Object, e As EventArgs) Handles SharedImportFileButton.Click

        Dim selFilePath As String = SharedToolListBox.SelectedItem.ToString
        If Management.CanEditFile(selFilePath) Then
            ImportFile(selFilePath)
        Else
            Dim dm As New DynamicMessageBox("Insufficient permissions to edit this Tool Share.", "Access Denied", Config.DisableDarkMessageBox, Management.GetCenterPoint(Me))
            dm.ShowDialog()
            dm.Dispose()
        End If
    End Sub

    Private Sub ImportFile(DestinationDbPath As String)
        Dim FileDialog As New OpenFileDialog
        FileDialog.Filter = "ToolSelector Database|*.tsd|ToolSelector CSV Export|*.csv|Excel Workbook|*.xlsx|Excel Macro Workbook|*.xlsm"
        FileDialog.FileName = ""
        FileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)
        FileDialog.Title = "Open File"
        'FileDialog.OverwritePrompt = False
        'FileDialog.CreatePrompt = False
        'FileDialog.AddExtension = True
        Dim DResult As DialogResult = FileDialog.ShowDialog()
        If DResult = DialogResult.OK Then


            IO.Directory.CreateDirectory(TempUploadPath.Substring(0, TempUploadPath.LastIndexOf("\")))
            If FileDialog.FileName.ToLower.EndsWith(".tsd") Then
                IO.File.Copy(FileDialog.FileName, TempUploadPath, True)

                Dim PreviewDialog As New ToolMaintForm(TempUploadPath, "Preview Tool Import", Management.GetCenterPoint(Me))
                PreviewDialog.ShowDialog()

                Dim msg As String = "Click 'Replace' to overwrite the existing tools with the imported tools." & vbCrLf &
                    "Click 'Append' to add the imported tools to the existing tools." & vbCrLf &
                    "Click 'Cancel' to abort the import."
                Dim dMsg As New DynamicMessageBox(msg, "Import Tools", Config.DisableDarkMessageBox, Management.GetCenterPoint(Me))

                dMsg.Button1Text = "Replace"
                dMsg.Button2Text = "Append"
                dMsg.Button3Text = "Cancel"
                dMsg.Button1DialogResult = DialogResult.Yes
                dMsg.Button2DialogResult = DialogResult.No
                dMsg.Button3DialogResult = DialogResult.Cancel

                Dim ImportConf As DialogResult = dMsg.ShowDialog

                If ImportConf = DialogResult.Yes Then ' Replace
                    IO.File.Copy(DestinationDbPath, "C:\Users\" & Environment.UserName & "\AppData\Roaming\ToolSelector\ToolBackup-" & DateTime.Now.ToString("yyyyMMddHHmmss") & ".tsd", True)
                    IO.File.Copy(TempUploadPath, DestinationDbPath, True)
                    LoadTools()
                    ElseIf ImportConf = DialogResult.No Then ' Append
                    Dim SourceTools As List(Of Tool) = Tool.LoadTools(TempUploadPath)
                    Dim DestTools As List(Of Tool) = Tool.LoadTools(DestinationDbPath)

                    For Each t As Tool In SourceTools
                        If Not DestTools.Any(Function(x) x.ToolID = t.ToolID) Then
                            DestTools.Add(t)
                        End If
                    Next

                    Tool.SaveToolDB(DestinationDbPath, DestTools)

                    LoadTools()
                End If
            ElseIf FileDialog.FileName.ToLower.EndsWith(".csv") Then
                Dim ImportedCSVString As String = IO.File.ReadAllText(FileDialog.FileName)
                Dim CsvLines As String() = ImportedCSVString.Split(vbCrLf, Integer.MaxValue, StringSplitOptions.RemoveEmptyEntries)
                Dim ImportedTools As New List(Of Tool)
                For i = 1 To CsvLines.Count - 1
                    Dim Values As String() = CsvLines(i).Split("|")
                    Dim ToolID As String = Values(3)
                    Dim ToolDesc As String = Values(2)

                    Dim thisTool As New Tool
                    thisTool.ToolID = ToolID
                    thisTool.ToolDescription = ToolDesc
                    ImportedTools.Add(thisTool)
                Next

                Tool.SaveToolDB(TempUploadPath, ImportedTools)

                Dim PreviewDialog As New ToolMaintForm(TempUploadPath, "Preview Tool Import", Management.GetCenterPoint(Me))
                PreviewDialog.ShowDialog()
                Dim msg As String = "Click 'Replace' to overwrite the existing tools with the imported tools." & vbCrLf &
                    "Click 'Append' to add the imported tools to the existing tools." & vbCrLf &
                    "Click 'Cancel' to abort the import."
                Dim dMsg As New DynamicMessageBox(msg, "Import Tools", Config.DisableDarkMessageBox, Management.GetCenterPoint(Me))
                dMsg.Button1Text = "Replace"
                dMsg.Button2Text = "Append"
                dMsg.Button3Text = "Cancel"
                dMsg.Button1DialogResult = DialogResult.Yes
                dMsg.Button2DialogResult = DialogResult.No
                dMsg.Button3DialogResult = DialogResult.Cancel
                Dim ImportConf As DialogResult = dMsg.ShowDialog

                If ImportConf = DialogResult.Yes Then ' Replace
                    IO.File.Copy(DestinationDbPath, "C:\Users\" & Environment.UserName & "\AppData\Roaming\ToolSelector\ToolBackup-" & DateTime.Now.ToString("yyyyMMddHHmmss") & ".tsd", True)
                    IO.File.Copy(TempUploadPath, DestinationDbPath, True)
                    LoadTools()
                    ElseIf ImportConf = DialogResult.No Then ' Append
                    Dim SourceTools As List(Of Tool) = Tool.LoadTools(TempUploadPath)
                    Dim DestTools As List(Of Tool) = Tool.LoadTools(DestinationDbPath)

                    For Each t As Tool In SourceTools
                        If Not DestTools.Any(Function(x) x.ToolID = t.ToolID) Then
                            DestTools.Add(t)
                        End If
                    Next

                    Tool.SaveToolDB(DestinationDbPath, DestTools)

                    LoadTools()
                End If

            ElseIf FileDialog.FileName.EndsWith(".xlsx") OrElse FileDialog.FileName.EndsWith(".xlsm") Then


                Dim XlApp As New Excel.Application
                Dim ImportWorkbook As Excel.Workbook = XlApp.Workbooks.Open(FileDialog.FileName)
                Dim ToolSheet As Excel.Worksheet = ImportWorkbook.Sheets(1)

                Dim RowCount As Integer = ToolSheet.Cells(ToolSheet.Rows.Count, 1).End(Excel.XlDirection.xlUp).Row
                Dim ColCount As Integer = ToolSheet.Cells(1, ToolSheet.Columns.Count).End(Excel.XlDirection.xlToLeft).Column
                Dim IdIndex As Integer = 0
                Dim DescIndex As Integer = 0
                Dim ExtendedDescIndex As Integer = 0
                Dim CalDueIndex As Integer = 0
                Dim LastCalIndex As Integer = 0

                If RowCount > 1 Then
                    Try
                        For c = 1 To ColCount
                            Dim HeaderValue As String = ToolSheet.Cells(1, c).Value.ToString.ToLower.Trim
                            If HeaderValue = "toolid" OrElse HeaderValue = "tool id" OrElse HeaderValue = "control number" OrElse HeaderValue = "id" OrElse
                                HeaderValue = "ptag" OrElse HeaderValue = "p tag" OrElse HeaderValue = "p-tag" OrElse HeaderValue = "property tag" OrElse HeaderValue = "controlnumber" Then
                                IdIndex = c
                            End If
                            If HeaderValue = "description" OrElse HeaderValue = "desc." OrElse HeaderValue = "desc" Then
                                DescIndex = c
                            End If
                            If HeaderValue = "extended description" OrElse HeaderValue = "extendeddescription" Then
                                ExtendedDescIndex = c
                            End If
                            If HeaderValue = "calibration due" OrElse HeaderValue = "calibrationdue" OrElse HeaderValue = "cal. due" OrElse HeaderValue = "cal. due date" OrElse HeaderValue = "cal due" OrElse HeaderValue = "cal due date" OrElse HeaderValue = "calibration due date" Then
                                CalDueIndex = c
                            End If
                            If HeaderValue = "last calibration" OrElse HeaderValue = "lastcalibration" OrElse HeaderValue = "last cal." OrElse HeaderValue = "last cal. date" OrElse HeaderValue = "lastcaldate" OrElse HeaderValue = "last cal date" OrElse HeaderValue = "last cal" Then
                                LastCalIndex = c
                            End If
                        Next
                    Catch ex As Exception
                        ImportWorkbook.Close(False)
                        XlApp.Quit()
                        Dim dm As New DynamicMessageBox("Could not parse column headers.
Valid column names can be found by hitting F1 in the ToolSelector app.", "Import Failed", Config.DisableDarkMessageBox, Management.GetCenterPoint(Me))
                        dm.ShowDialog()
                        dm.Dispose()
                        Return
                    End Try


                    If IdIndex = 0 Then
                        ImportWorkbook.Close(False)
                        XlApp.Quit()
                        Dim dm As New DynamicMessageBox("Could not parse column headers.
Valid column names can be found by hitting F1 in the ToolSelector app.", "Import Failed", Config.DisableDarkMessageBox, Management.GetCenterPoint(Me))
                        dm.ShowDialog()
                        dm.Dispose()
                        Return
                    End If

                    If Not ExtendedDescIndex = 0 Then DescIndex = ExtendedDescIndex

                    Dim ImportedTools As New List(Of Tool)

                    For r = 2 To RowCount
                        Dim thisTool As New Tool
                        thisTool.ToolID = ToolSheet.Cells(r, IdIndex).Value
                        If Not DescIndex = 0 Then
                            thisTool.ToolDescription = ToolSheet.Cells(r, DescIndex).Value
                        End If
                        If Not CalDueIndex = 0 Then
                            thisTool.ToolCalibrationDueDate = ToolSheet.Cells(r, CalDueIndex).Value
                        End If
                        If Not LastCalIndex = 0 Then
                            thisTool.ToolCalibrationDate = ToolSheet.Cells(r, LastCalIndex).Value
                        End If
                        ImportedTools.Add(thisTool)
                    Next

                    ImportWorkbook.Close(False)
                    XlApp.Quit()

                    Tool.SaveToolDB(TempUploadPath, ImportedTools)

                    Dim PreviewDialog As New ToolMaintForm(TempUploadPath, "Preview Tool Import", Management.GetCenterPoint(Me))
                    PreviewDialog.ShowDialog()

                    Dim msg As String = "Click 'Replace' to overwrite the existing tools with the imported tools." & vbCrLf &
                        "Click 'Append' to add the imported tools to the existing tools." & vbCrLf &
                        "Click 'Cancel' to abort the import."
                    Dim dMsg As New DynamicMessageBox(msg, "Import Tools", Config.DisableDarkMessageBox, Management.GetCenterPoint(Me))

                    dMsg.Button1Text = "Replace"
                    dMsg.Button2Text = "Append"
                    dMsg.Button3Text = "Cancel"
                    dMsg.Button1DialogResult = DialogResult.Yes
                    dMsg.Button2DialogResult = DialogResult.No
                    dMsg.Button3DialogResult = DialogResult.Cancel

                    Dim ImportConf As DialogResult = dMsg.ShowDialog
                    dMsg.Dispose()

                    If ImportConf = DialogResult.Yes Then ' Replace
                        IO.File.Copy(DestinationDbPath, "C:\Users\" & Environment.UserName & "\AppData\Roaming\ToolSelector\ToolBackup-" & DateTime.Now.ToString("yyyyMMddHHmmss") & ".tsd", True)
                        IO.File.Copy(TempUploadPath, DestinationDbPath, True)
                        LoadTools()
                        ElseIf ImportConf = DialogResult.No Then ' Append
                        Dim SourceTools As List(Of Tool) = Tool.LoadTools(TempUploadPath)
                        Dim DestTools As List(Of Tool) = Tool.LoadTools(DestinationDbPath)

                        For Each t As Tool In SourceTools
                            If Not DestTools.Any(Function(x) x.ToolID = t.ToolID) Then
                                DestTools.Add(t)
                            End If
                        Next

                        Tool.SaveToolDB(DestinationDbPath, DestTools)

                        LoadTools()
                    End If
                End If
            End If

        End If
    End Sub

    Private Sub AddSharedToolsButton_Click(sender As Object, e As EventArgs) Handles AddSharedToolsButton.Click
        Dim FileDialog As New OpenFileDialog
        FileDialog.Filter = "ToolSelector Database|*.tsd"
        FileDialog.FileName = "SharedTools.tsd"
        FileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)
        FileDialog.Title = "Open Shared Tool Database"
        'FileDialog.OverwritePrompt = False
        'FileDialog.CreatePrompt = True
        'FileDialog.AddExtension = True
        FileDialog.CheckFileExists = False
        Dim Result As DialogResult = FileDialog.ShowDialog()
        If Result = DialogResult.OK Then
            'Config.SharedToolPath = SaveDialog.FileName
            SharedToolListBox.Items.Add(FileDialog.FileName)
            Dim newList As List(Of String) = SharedToolListBox.Items.Cast(Of String).ToList()
            Config.SharedToolPath = newList
            SharedToolListBox.SetItemChecked(SharedToolListBox.Items.Count - 1, Config.LoadSharedToolsOnOpen)
            If Not IO.File.Exists(FileDialog.FileName) Then
                Dim dMsg As New DynamicMessageBox("The file specified does not exist. A new tool database will be created.", "File Not Found", Config.DisableDarkMessageBox, Management.GetCenterPoint(Me))
                dMsg.ShowDialog()
            End If
        End If
        LoadTools()
    End Sub
    Private Sub RemoveSharedToolsButton_Click(sender As Object, e As EventArgs) Handles RemoveSelSharedToolButton.Click
        If SharedToolListBox.SelectedIndex = -1 Then Exit Sub
        SharedToolListBox.Items.RemoveAt(SharedToolListBox.SelectedIndex)
        Dim newList As List(Of String) = SharedToolListBox.Items.Cast(Of String).ToList()
        Config.SharedToolPath = newList
    End Sub
    Private Sub SharedToolListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SharedToolListBox.SelectedIndexChanged
        If SharedToolListBox.SelectedIndex = -1 Then
            SharedManEditButton.Enabled = False
            SharedImportFileButton.Enabled = False
        Else
            SharedManEditButton.Enabled = True
            SharedImportFileButton.Enabled = True
        End If
    End Sub
    Private Sub SharedToolListBox_KeyDown(sender As Object, e As KeyEventArgs) Handles SharedToolListBox.KeyDown
        If e.KeyCode = Keys.Delete Then
            If SharedToolListBox.SelectedIndex = -1 Then Exit Sub
            SharedToolListBox.Items.RemoveAt(SharedToolListBox.SelectedIndex)
            Dim newList As List(Of String) = SharedToolListBox.Items.Cast(Of String).ToList()
            Config.SharedToolPath = newList
        End If
    End Sub

    Private Sub SharedToolListBox_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles SharedToolListBox.ItemCheck
        If Starting Then Exit Sub
        CheckWait()
    End Sub

    Private Async Sub CheckWait()
        Await Task.Delay(200)
        LoadTools()
    End Sub


    Private Sub SwitchDarkMode(Enabled As Boolean)
        Dim DarkFormBack As Color = Color.FromArgb(30, 31, 32)
        Dim DarkFormFore As Color = Color.WhiteSmoke
        Dim DarkGridCellBack As Color = Color.FromArgb(50, 52, 54)
        Dim DarkGridHeaderBack As Color = Color.FromArgb(45, 47, 49)

        If Enabled Then
            Me.BackColor = DarkFormBack
            Me.ForeColor = DarkFormFore

            DGVToolSelection.BackgroundColor = DarkFormBack
            DGVToolSelection.RowTemplate.DefaultCellStyle.BackColor = DarkGridCellBack
            DGVToolSelection.RowTemplate.DefaultCellStyle.ForeColor = DarkFormFore
            DGVToolSelection.ColumnHeadersDefaultCellStyle.BackColor = DarkGridHeaderBack
            DGVToolSelection.ColumnHeadersDefaultCellStyle.ForeColor = DarkFormFore
            DGVToolSelection.RowHeadersDefaultCellStyle.BackColor = DarkGridHeaderBack
            DGVToolSelection.RowHeadersDefaultCellStyle.ForeColor = DarkFormFore
            DGVToolSelection.GridColor = Color.Gray

            SearchBox.BackColor = DarkGridCellBack
            SearchBox.ForeColor = DarkFormFore

            TabControl1.BackColor = DarkFormBack
            TabControl1.ForeColor = DarkFormFore
            TabControl1.Margin = New Padding(0, 0, 0, 0)
            TabControl1.Padding = New Point(0, 0)


            SelectionTab.BackColor = DarkFormBack
            SelectionTab.ForeColor = DarkFormFore
            SelectionTab.Margin = New Padding(0, 0, 0, 0)
            SelectionTab.Padding = New Padding(0, 0, 0, 0)
            TableLayoutPanel1.Margin = New Padding(0, 0, 0, 0)
            TableLayoutPanel1.Padding = New Padding(0, 0, 0, 0)
            Panel1.BackColor = DarkFormBack
            Panel1.ForeColor = DarkFormFore
            Panel2.BackColor = DarkFormBack
            Panel2.ForeColor = DarkFormFore

            ToolManagementPage.BackColor = DarkFormBack
            ToolManagementPage.ForeColor = DarkFormFore
            SharedToolListBox.BackColor = DarkGridCellBack
            SharedToolListBox.ForeColor = DarkFormFore
            UserMgmtGroup.ForeColor = DarkFormFore
            SharedMgmtGroup.ForeColor = DarkFormFore

            OptionsTab.BackColor = DarkFormBack
            OptionsTab.ForeColor = DarkFormFore
            OutputOptionsGroup.ForeColor = DarkFormFore
            AppearanceOptionsGroup.ForeColor = DarkFormFore

            'ExportButton.Visible = False
            'UserManEditButton.Visible = False
            'SharedManEditButton.Visible = False
            'UserImportFileButton.Visible = False
            'SharedImportFileButton.Visible = False

            ExportButton.FlatStyle = FlatStyle.Flat
            ExportButton.FlatAppearance.BorderSize = 1
            ExportButton.FlatAppearance.BorderColor = DarkFormFore
            ExportButton.FlatAppearance.MouseDownBackColor = DarkGridCellBack
            ExportButton.FlatAppearance.MouseOverBackColor = DarkGridCellBack
            ExportButton.BackColor = DarkGridCellBack

            UserManEditButton.FlatStyle = FlatStyle.Flat
            UserManEditButton.FlatAppearance.BorderSize = 1
            UserManEditButton.FlatAppearance.BorderColor = DarkFormFore
            UserManEditButton.FlatAppearance.MouseDownBackColor = DarkGridCellBack
            UserManEditButton.FlatAppearance.MouseOverBackColor = DarkGridCellBack
            UserManEditButton.BackColor = DarkGridCellBack

            SharedManEditButton.FlatStyle = FlatStyle.Flat
            SharedManEditButton.FlatAppearance.BorderSize = 1
            SharedManEditButton.FlatAppearance.BorderColor = DarkFormFore
            SharedManEditButton.FlatAppearance.MouseDownBackColor = DarkGridCellBack
            SharedManEditButton.FlatAppearance.MouseOverBackColor = DarkGridCellBack
            SharedManEditButton.BackColor = DarkGridCellBack

            UserImportFileButton.FlatStyle = FlatStyle.Flat
            UserImportFileButton.FlatAppearance.BorderSize = 1
            UserImportFileButton.FlatAppearance.BorderColor = DarkFormFore
            UserImportFileButton.FlatAppearance.MouseDownBackColor = DarkGridCellBack
            UserImportFileButton.FlatAppearance.MouseOverBackColor = DarkGridCellBack
            UserImportFileButton.BackColor = DarkGridCellBack

            SharedImportFileButton.FlatStyle = FlatStyle.Flat
            SharedImportFileButton.FlatAppearance.BorderSize = 1
            SharedImportFileButton.FlatAppearance.BorderColor = DarkFormFore
            SharedImportFileButton.FlatAppearance.MouseDownBackColor = DarkGridCellBack
            SharedImportFileButton.FlatAppearance.MouseOverBackColor = DarkGridCellBack
            SharedImportFileButton.BackColor = DarkGridCellBack


        End If

    End Sub

    Private Sub LoadSharedToolsOnStartupCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles LoadSharedToolsOnStartupCheckbox.CheckedChanged
        Config.LoadSharedToolsOnOpen = LoadSharedToolsOnStartupCheckbox.Checked
    End Sub

    Private Sub HighlightExpiredToolsCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles HighlightExpiredToolsCheckbox.CheckedChanged
        Config.HighlightExpiredTools = HighlightExpiredToolsCheckbox.Checked
        LoadTools()
    End Sub


    Private Sub ToolsCheckedWarningCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles ToolsCheckedWarningCheckbox.CheckedChanged
        Config.ToolsCheckedWarning = ToolsCheckedWarningCheckbox.Checked
    End Sub

    Private Sub ExpiredToolsCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles ExpiredToolsCheckbox.CheckedChanged
        Config.CheckExpiredToolsOnExport = ExpiredToolsCheckbox.Checked
    End Sub

    Private Sub DontDarkenMessageBoxCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles DontDarkenMessageBoxCheckbox.CheckedChanged
        Config.DisableDarkMessageBox = DontDarkenMessageBoxCheckbox.Checked
    End Sub
End Class

