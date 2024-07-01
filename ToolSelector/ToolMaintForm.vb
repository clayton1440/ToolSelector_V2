Imports System.ComponentModel
Imports ToolSelector.Data

Public Class ToolMaintForm
    Private _toolFilePath As String
    Private _tools As List(Of Tool)

    Private FormTitle As String
    Dim _ToolGridBinding As New BindingSource
    Dim _ToolTable As New DataTable

    Private displayScale As Double

    Public Sub New(FilePath As String, Optional Title As String = "Edit Tool Data", Optional CenterPoint As Point = Nothing)
        ' This call is required by the designer.
        InitializeComponent()

        _toolFilePath = FilePath
        _tools = Tool.LoadTools(_toolFilePath)

        If Title.Contains("Preview") Then
            ExitButton.Text = "Save && Continue"
            FilePathLabel.Visible = False
            ToolStripSeparator1.Visible = False
        Else
            FilePathLabel.Text = _toolFilePath
        End If

        FormTitle = Title

        If CenterPoint <> Nothing Then
            Me.StartPosition = FormStartPosition.Manual
            Dim FormCornerPosition As Point = New Point(CenterPoint.X - (Me.Width / 2), CenterPoint.Y - (Me.Height / 2))
            Me.Location = FormCornerPosition
        End If
    End Sub
    Private Sub ToolMaintForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = FormTitle
        displayScale = Management.DisplayScale(Me)

        LoadGrid()

        For i As Integer = 2 To DGVToolEdit.Columns.Count - 1
            MoveUpSpaces.Items.Add(i.ToString & " Spaces")
            MoveDownSpaces.Items.Add(i.ToString & " Spaces")
        Next
    End Sub

    Private Sub LoadGrid()
        Dim ToolTable As DataTable = Tool.ToTable(_tools)

        _ToolGridBinding.DataSource = ToolTable
        DGVToolEdit.DataSource = _ToolGridBinding


        StatusLabel.Text = "Tools Loaded"
    End Sub

    Private Sub SaveTools() Handles ExitButton.Click
        StatusLabel.Text = "Saving..."
        Application.UseWaitCursor = True
        Application.DoEvents()

        Dim NewToolList As New List(Of Tool)
        For Each row As DataGridViewRow In DGVToolEdit.Rows
            If row.IsNewRow Then Continue For
            NewToolList.Add(New Tool() With {
                .ToolID = row.Cells("ToolID").Value,
                .ToolDescription = row.Cells("ToolDescription").Value.ToString,
                .ToolType = row.Cells("ToolType").Value.ToString,
                .ToolCalibrationDate = IIf(row.Cells("ToolCalibrationDate").Value IsNot DBNull.Value, row.Cells("ToolCalibrationDate").Value, Date.Parse("1/1/1900")),
                .ToolCalibrationDueDate = IIf(row.Cells("ToolCalibrationDueDate").Value IsNot DBNull.Value, row.Cells("ToolCalibrationDueDate").Value, Date.Parse("1/1/1900")),
                .ToolCalibrationFrequency = IIf(row.Cells("ToolCalibrationFrequency").Value IsNot DBNull.Value, row.Cells("ToolCalibrationFrequency").Value, -1),
                .ToolCalibrationNotes = row.Cells("ToolCalibrationNotes").Value.ToString,
                .ToolLastActionDate = IIf(row.Cells("ToolLastActionDate").Value IsNot DBNull.Value, row.Cells("ToolLastActionDate").Value, Date.Parse("1/1/1900")),
                .ToolLastActionBy = row.Cells("ToolLastActionBy").Value.ToString,
                .ToolNotes = row.Cells("ToolNotes").Value.ToString,
                .ToolImageUrl = row.Cells("ToolImageUrl").Value.ToString
            })
        Next
        Tool.SaveToolDB(_toolFilePath, NewToolList)
        Application.UseWaitCursor = False
        StatusLabel.Text = "Saved"

        Me.Close()
    End Sub

    Dim Edited As Boolean = False

    Private Sub ToolMaintForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Edited And Not StatusLabel.Text = "Saved" Then
            Dim dmsg As New DynamicMessageBox("Save Tools?",, DynamicMessageBox.DARK_DISABLE, Management.GetCenterPoint(Me))
            dmsg.Button1Text = "Save"
            dmsg.Button1DialogResult = DialogResult.Yes
            dmsg.Button2Text = "Don't Save"
            dmsg.Button2DialogResult = DialogResult.No
            dmsg.Button3Text = "Cancel"
            dmsg.Button3DialogResult = DialogResult.Cancel

            Dim result As DialogResult = dmsg.ShowDialog()
            If result = DialogResult.Yes Then
                SaveTools()
            ElseIf result = DialogResult.Cancel Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub DGVToolEdit_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DGVToolEdit.CellBeginEdit
        Edited = True
    End Sub


    Private Sub MoveUpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoveUpToolStripMenuItem.Click
        Dim ToolTable As DataTable = CType(_ToolGridBinding.DataSource, DataTable)
        Dim CopyTable As New DataTable
        CopyTable = ToolTable.Copy
        Dim SelectedRowIndexes As New List(Of Integer)
        Dim SelectedRows As New List(Of DataRow)

        For Each Row As DataGridViewRow In DGVToolEdit.SelectedRows
            If Not Row.IsNewRow Then SelectedRowIndexes.Add(Row.Index)
        Next

        If SelectedRowIndexes.Count > 0 Then
            For Each i As Integer In SelectedRowIndexes
                SelectedRows.Add(CopyTable.Rows(i))
            Next
            For j = 0 To SelectedRows.Count - 1
                For Each i As Integer In SelectedRowIndexes
                    ToolTable.Rows.RemoveAt(i)
                    ToolTable.Rows.InsertAt(SelectedRows(j), i - 1)
                Next
            Next

        End If
    End Sub

    Private Sub MoveDownToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoveDownToolStripMenuItem.Click
        Dim selectedRows As DataGridViewSelectedRowCollection = DGVToolEdit.SelectedRows
        Dim rowCount As Integer = DGVToolEdit.Rows.Count
        Dim ToolTable As DataTable = _ToolGridBinding.DataSource
        ' Iterate through each selected row and move it up one position.
        For Each selectedRow As DataGridViewRow In selectedRows
            Dim currentIndex As Integer = selectedRow.Index

            ' Check if the row can be moved up (not the first row).
            If currentIndex > 0 Then
                Dim oldRow As DataRow = ToolTable.Rows(currentIndex)

                ' Remove the row from its current position.
                ToolTable.Rows.RemoveAt(currentIndex)

                ' Insert the row at the new position.
                ToolTable.Rows.InsertAt(oldRow, currentIndex - 1)



                ' Select the moved row.
                DGVToolEdit.Rows(currentIndex - 1).Selected = True
            End If
        Next

    End Sub

    Private Sub MoveToTopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoveToTopToolStripMenuItem.Click

    End Sub

    Private Sub MoveToBottomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoveToBottomToolStripMenuItem.Click

    End Sub

    Private Sub InsertToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsertToolStripMenuItem.Click
        Dim ToolTable As DataTable = CType(_ToolGridBinding.DataSource, DataTable)
        Dim NewRow As DataRow = ToolTable.NewRow
        ToolTable.Rows.InsertAt(NewRow, DGVToolEdit.SelectedRows(0).Index)
        _ToolGridBinding.DataSource = ToolTable
    End Sub


#Region "Mouse Wheel Interpretation"

    MustInherit Class Win32Messages
        Public Const WM_MOUSEHWHEEL As Integer = &H20E 'setting constant for horizontal mouse wheel WndProc message
    End Class



    Protected Overrides Sub WndProc(ByRef m As Message)
        'override the WndProc. If the horizontal mouse wheel message is sent, intercept it, else return the message to the normal WndProc
        Try
            MyBase.WndProc(m)
            If m.HWnd <> Me.Handle Then
                Return
            End If
            Select Case m.Msg
                Case Win32Messages.WM_MOUSEHWHEEL
                    'if message is for horizontal scroll, send the WParam to determine which direction and actually do the scrolling.
                    'Set the WndProc result so the nothing else processes the same message
                    MouseHorizontalScroll(m.WParam.ToInt64)
                    m.Result = CType(1, IntPtr)
                    Exit Select
                Case Else
                    Exit Select

            End Select
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub DataGridView1_MouseWheel(sender As Object, e As HandledMouseEventArgs) Handles DGVToolEdit.MouseWheel
        'MessageBox.Show("")
        If e.Delta <> 0 AndAlso My.Computer.Keyboard.CtrlKeyDown AndAlso Not My.Computer.Keyboard.ShiftKeyDown Then
            e.Handled = True
            Dim MouseUpDown As Integer = e.Delta / SystemInformation.MouseWheelScrollDelta '     1 for up, -1 for down

            If DGVToolEdit.DefaultCellStyle.Font.Size + MouseUpDown < 2 Or DGVToolEdit.DefaultCellStyle.Font.Size + MouseUpDown > 24 Then Exit Sub

            DGVToolEdit.DefaultCellStyle.Font = New Font(DGVToolEdit.DefaultCellStyle.Font.FontFamily, DGVToolEdit.DefaultCellStyle.Font.Size + MouseUpDown)
            DGVToolEdit.ColumnHeadersDefaultCellStyle.Font = New Font(DGVToolEdit.ColumnHeadersDefaultCellStyle.Font.FontFamily, DGVToolEdit.ColumnHeadersDefaultCellStyle.Font.Size + MouseUpDown, FontStyle.Bold)


        End If

        If e.Delta <> 0 AndAlso My.Computer.Keyboard.ShiftKeyDown Then
            ' Calculate the number of columns to scroll based on the delta value
            Dim scrollColumns As Integer = e.Delta / SystemInformation.MouseWheelScrollDelta

            Dim scrollMultiplier As Integer
            If My.Computer.Keyboard.CtrlKeyDown Then
                scrollMultiplier = 150
            Else
                scrollMultiplier = 50
            End If

            ' Determine the new horizontal scroll position
            Dim newScrollPosition As Integer = DGVToolEdit.HorizontalScrollingOffset - scrollColumns * displayScale * scrollMultiplier

            ' Determine the maximum scroll position
            Dim maxScrollPosition As Integer = DGVToolEdit.Columns.GetColumnsWidth(DataGridViewElementStates.None) - DGVToolEdit.ClientSize.Width

            ' Ensure the scroll position is within the valid range
            If newScrollPosition < 0 Then
                newScrollPosition = 0
            ElseIf newScrollPosition > maxScrollPosition Then
                newScrollPosition = maxScrollPosition
            End If

            ' Set the new horizontal scroll position
            DGVToolEdit.HorizontalScrollingOffset = newScrollPosition

            ' Handle the event to prevent further processing
            'e.Handled = True
        End If
    End Sub
    Private Sub MouseHorizontalScroll(WParam)
        If Not DGVToolEdit.Visible Then Exit Sub
        Dim scrollColumns As Integer

        If WParam < 1000000000 AndAlso WParam > 0 Then 'wheel tilt right/horz wheel up
            scrollColumns = -1
        Else 'wheel tilt left/horz wheel down
            scrollColumns = 1
            'Else
            'Console.WriteLine(WParam)
            'Exit Sub
        End If

        Dim scrollMultiplier As Integer
        If My.Computer.Keyboard.CtrlKeyDown Then
            scrollMultiplier = 100
        Else
            scrollMultiplier = 75
        End If

        ' Determine the new horizontal scroll position
        Dim newScrollPosition As Integer = DGVToolEdit.HorizontalScrollingOffset - scrollColumns * displayScale * scrollMultiplier

        ' Determine the maximum scroll position
        Dim maxScrollPosition As Integer = DGVToolEdit.Columns.GetColumnsWidth(DataGridViewElementStates.None) - DGVToolEdit.ClientSize.Width

        ' Ensure the scroll position is within the valid range
        If newScrollPosition < 0 Then
            newScrollPosition = 0
        ElseIf newScrollPosition > maxScrollPosition Then
            newScrollPosition = maxScrollPosition
        End If

        ' Set the new horizontal scroll position
        DGVToolEdit.HorizontalScrollingOffset = newScrollPosition
    End Sub

    Private Sub ToolMaintForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Dispose()
    End Sub

#End Region

End Class