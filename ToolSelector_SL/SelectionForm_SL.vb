
Imports System.ComponentModel
Imports ToolSelector.Data

Public Class SelectionForm_SL
    Dim Starting = True
    Dim ToolsExported As Boolean = False

    Dim UserTools As List(Of Tool)

    Dim ToolGridBinding As New BindingSource

    Public UserToolPath As String = "C:\Users\" & Environment.UserName & "\AppData\Roaming\ToolSelector\Tools.tsd"
    Public TempUploadPath As String = "C:\Users\" & Environment.UserName & "\AppData\Roaming\Temp\ToolUploadTemp.tsd"
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True 'allow app to read keypresses before the underlying control receives the key. 

        Dim Args() As String = Environment.GetCommandLineArgs
        If Args(0).Contains("bin\Debug") Then Me.Text &= " - [Debug]"
        If Args(0).Contains("bin\Release") Then Me.Text &= " - Release Candidate"
        If Args.Count > 1 Then
            UserToolPath = Args(1)
            Me.Text &= $" - {Args(1)}"
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

        'Theme = Config.Theme
        'If Theme = "System" Then
        '    If DarkMode.IsSystemDarkMode() Then
        '        DarkMode.UseImmersiveDarkMode(Me.Handle, True)
        '        SwitchDarkMode(True)
        '    End If
        'ElseIf Theme = "Dark" Then
        '    DarkMode.UseImmersiveDarkMode(Me.Handle, True)
        '    SwitchDarkMode(True)
        'End If



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
                End If
            End If
            dMsg.Dispose()
        End If
    End Sub

    Private Async Sub ExportTools() Handles ExportButton.Click
        Console.WriteLine("ExportTools()")
        If String.IsNullOrWhiteSpace(Config.ExportPath) Then
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
            End If
        End If

        IO.File.WriteAllText(Config.ExportPath, ExportString) 'write the string to a .csv file. This overwrites the previous text if the file is already present.

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

    Private Sub CloseAfterExportCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles CloseAfterExportCheckBox.CheckedChanged
        If Not Starting Then Config.CloseAfterExport = CloseAfterExportCheckBox.Checked
    End Sub


    Private Sub FilterBox_TextChanged(sender As Object, e As EventArgs) Handles SearchBox.TextChanged
        If Not String.IsNullOrWhiteSpace(SearchBox.Text) AndAlso Not SearchBox.Text = "Search..." Then
            'SearchBox.Font = New Font(SearchBox.Font, FontStyle.Regular)
            'SearchBox.ForeColor = SystemColors.ControlText
            Dim FilterText As String = $"[ID] LIKE '*{SearchBox.Text}*' OR [Description] LIKE '*{SearchBox.Text}*'"
            ToolGridBinding.Filter = FilterText
        Else
            ToolGridBinding.Filter = ""
        End If
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
        LoadTools()
        SearchBox.Text = ""
        SearchBox_Leave()
        ToolsExported = False
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
        'Dim DisplayScale As Double = Management.DisplayScale(Me)

        'If DisplayScale <> 1 Then
        '    StoreX = Math.Round(StoreX / DisplayScale)
        '    StoreY = Math.Round(StoreY / DisplayScale)
        'End If

        Config.FormXPos = StoreX
        Config.FormYPos = StoreY
    End Sub


End Class

