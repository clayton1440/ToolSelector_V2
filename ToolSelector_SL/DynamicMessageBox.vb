Public Class DynamicMessageBox
    Private TitleText As String = ""
    Private MessageText As String = ""
    'Private CheckBoxText As String = ""
    'Private ButtonType As MessageBoxButtons
    'Private CheckBoxValue As Boolean

    Public Const DARK_AUTO As Integer = 0
    Public Const DARK_ENABLE As Integer = 1
    Public Const DARK_DISABLE As Integer = 2

    Public Button1Text As String = ""
    Public Button1DialogResult As DialogResult = DialogResult.None
    Public Button2Text As String = ""
    Public Button2DialogResult As DialogResult = DialogResult.None
    Public Button3Text As String = ""
    Public Button3DialogResult As DialogResult = DialogResult.None
    Public Checkbox1Text As String = ""
    Public Checkbox1Checked As Boolean = False

    Public Sub New(Message As String, Optional Title As String = "", Optional DarkModeOverride As Integer = DARK_AUTO, Optional CenterPoint As Point = Nothing)

        MessageText = Message
        TitleText = Title

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Select Case DarkModeOverride
            Case DARK_AUTO
                SwitchDarkMode(Management.CheckDarkMode)
            Case DARK_ENABLE
                SwitchDarkMode(True)
            Case DARK_DISABLE
                'do nothing
            Case Else 'auto
                SwitchDarkMode(Management.CheckDarkMode)
        End Select

        Dim DisplayScale As Double = Management.DisplayScale(Me)

        Dim TextSize As Size = TextRenderer.MeasureText(MessageText, Label1.Font)

        Me.Size = New Size(Math.Max(TextSize.Width + (96 * DisplayScale), Me.MinimumSize.Width), Math.Max(TextSize.Height + (176 * DisplayScale), Me.MinimumSize.Height))


        If CenterPoint <> Nothing Then
            Me.StartPosition = FormStartPosition.Manual
            Dim FormCornerPosition As Point = New Point(CenterPoint.X - (Me.Width / 2), CenterPoint.Y - (Me.Height / 2))
            Me.Location = FormCornerPosition
        End If

    End Sub
    Private Sub DynamicMessageBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Me.Text = TitleText
        Label1.Text = MessageText


        If Not String.IsNullOrWhiteSpace(Checkbox1Text) Then
            CheckBox1.Visible = True
            CheckBox1.Text = Checkbox1Text
            CheckBox1.Checked = Checkbox1Checked
        End If

        If Not String.IsNullOrWhiteSpace(Button1Text) Then
            Button1.Visible = True
            Button1.Text = Button1Text
            Button1.DialogResult = Button1DialogResult
        End If

        If Not String.IsNullOrWhiteSpace(Button2Text) Then
            Button2.Visible = True
            Button2.Text = Button2Text
            Button2.DialogResult = Button2DialogResult
        End If

        If Not String.IsNullOrWhiteSpace(Button3Text) Then
            Button3.Visible = True
            Button3.Text = Button3Text
            Button3.DialogResult = Button3DialogResult
        End If

        If String.IsNullOrWhiteSpace(Button1Text) And String.IsNullOrWhiteSpace(Button2Text) And String.IsNullOrWhiteSpace(Button3Text) Then
            Button1.Visible = True
            Button1.Text = "OK"
            Button1.DialogResult = DialogResult.OK
        End If


    End Sub


    Public Function OptionChecked() As Boolean
        Return Checkbox1Checked
    End Function

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Checkbox1Checked = CheckBox1.Checked
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = Button1.DialogResult
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = Button2.DialogResult
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.DialogResult = Button3.DialogResult
        Me.Close()
    End Sub

    Private Sub DynamicMessageBox_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown, TableLayoutPanel1.KeyDown, Label1.KeyDown, Button1.KeyDown, Button2.KeyDown, Button3.KeyDown, CheckBox1.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub SwitchDarkMode(Enabled As Boolean)
        If Enabled Then
            DarkMode.UseImmersiveDarkMode(Handle, Enabled)
            Dim DarkFormBack As Color = Color.FromArgb(60, 58, 56)
            Dim DarkFormFore As Color = Color.WhiteSmoke
            Dim DarkButtonBack As Color = Color.FromArgb(68, 68, 68)

            Me.BackColor = DarkFormBack
            Me.ForeColor = DarkFormFore

            Button1.FlatStyle = FlatStyle.Flat
            Button1.BackColor = DarkButtonBack
            Button2.FlatStyle = FlatStyle.Flat
            Button2.BackColor = DarkButtonBack
            Button3.FlatStyle = FlatStyle.Flat
            Button3.BackColor = DarkButtonBack
        End If
    End Sub
End Class