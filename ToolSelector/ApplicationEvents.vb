Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            'System.IO.File.Copy("C:\Users\" & Environment.UserName & "\AppData\Roaming\ToolSelector\User.cfg", "C:\Users\" & Environment.UserName & "\AppData\Roaming\ToolSelector\UserBackup-" & DateTime.Now.ToString("yyyyMMddHHmmss") & ".cfg")
        End Sub


        Public ExitApp As Boolean = False
        Private Sub MyApplication_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs) Handles Me.UnhandledException
            ExceptionForm.ExceptionText.Text = "HResult: " & e.Exception.HResult & vbCrLf & vbCrLf & e.Exception.Message & vbCrLf & vbCrLf & e.Exception.StackTrace
            ExceptionForm.ShowDialog()
            e.ExitApplication = ExitApp
        End Sub
    End Class
End Namespace
