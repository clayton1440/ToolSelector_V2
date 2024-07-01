Public Class SplashScreen
    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VersionLabel.Text = $"Build: {Reflection.Assembly.GetExecutingAssembly.GetName.Version}"

        ' Forcibly display in center of primary screen, even if started from a secondary screen.
        ' Prevents splash screen from scaling incorrectly when started from non-primary screen.
        Dim x As Integer = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Dim y As Integer = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
        Me.Location = New Point(x, y)
    End Sub
End Class