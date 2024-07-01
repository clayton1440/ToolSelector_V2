
Public Class ExceptionForm
    'see ApplicationEvents.vb
    Private Sub ContinueButton_Click(sender As Object, e As EventArgs) Handles ContinueButton.Click
        Dim dm As New DynamicMessageBox("ToolSelector may become unstable! Restart application if errors persist.", "Caution",, Management.GetCenterPoint(Me))
        dm.ShowDialog()
        dm.Dispose()
        My.Application.ExitApp = False
        Me.Close()
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        My.Application.ExitApp = True
        Me.Close()
    End Sub

    Private Sub EmailButton_Click(sender As Object, e As EventArgs) Handles EmailButton.Click
        Try
            Dim Mailto As String = $"mailto:cgross@blackkawktechnologies.net?subject=ToolSelector%20Error&body={ExceptionText.Text}"
            Process.Start(Mailto)
        Catch ex As Exception
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
            Dim dm As New DynamicMessageBox(ex.Message,,, Management.GetCenterPoint(Me))
            dm.ShowDialog()
            dm.Dispose()
        End Try
    End Sub
End Class