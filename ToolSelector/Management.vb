
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Runtime.InteropServices
Imports System.DirectoryServices.AccountManagement
Imports System.Security.AccessControl
Imports System.Security.Principal
Imports ToolSelector.Data

Public Class Management
    Shared Function DisplayScale(Form As Object) As Double
        Dim graphics As Graphics = Form.CreateGraphics()
        Dim DpiX As Single = graphics.DpiX
        Dim ScaleX As Double = DpiX / 96

        Return ScaleX

    End Function

    Shared Function GetCenterPoint(Form As Object) As Point
        Dim CenterPoint As New Point(Form.Location.X + (Form.Width / 2), Form.Location.Y + (Form.Height / 2))
        Return CenterPoint
    End Function

    Shared Function CanEditFile(filePath As String) As Boolean
        ' Check if the file exists
        Try
            If File.Exists(filePath) Then
                ' Get the file's security information
                Dim fileSecurity As FileSecurity = File.GetAccessControl(filePath)

                ' Get the access rules for the current user
                Dim accessRules As AuthorizationRuleCollection = fileSecurity.GetAccessRules(True, True, GetType(System.Security.Principal.SecurityIdentifier))

                ' Get the current user's groups
                Dim userGroups As List(Of SecurityIdentifier) = GetCurrentUserGroups()

                ' Get the current user's Security Identifier (SID)
                Dim currentUserSID As SecurityIdentifier = New SecurityIdentifier(WindowsIdentity.GetCurrent().User.Value)

                ' Iterate through the access rules and check if the current user has write permissions

                For Each rule As FileSystemAccessRule In accessRules
                    If rule.IdentityReference.Equals(currentUserSID) Then
                        If (rule.FileSystemRights And FileSystemRights.Write) = FileSystemRights.Write Then
                            ' User has write permissions
                            Return True
                        End If
                    End If
                Next

                For Each groupSID As SecurityIdentifier In userGroups
                    For Each rule As FileSystemAccessRule In accessRules
                        If rule.IdentityReference.Equals(groupSID) Then
                            If (rule.FileSystemRights And FileSystemRights.Write) = FileSystemRights.Write Then
                                Return True
                            End If
                        End If
                    Next
                Next

                ' If no matching rule is found for the current user, assume read-only access
                Return False
            Else
                ' File does not exist
                Return False
            End If
        Catch ex As Exception
            'invalid file path
            Return False
        End Try

    End Function
    Shared Function GetCurrentUserGroups() As List(Of SecurityIdentifier)
        Dim groups As New List(Of SecurityIdentifier)()

        Dim userPrincipal As UserPrincipal = TryCast(UserPrincipal.Current, UserPrincipal)
        If userPrincipal IsNot Nothing Then
            Using context As New PrincipalContext(ContextType.Domain)
                Dim userGroups As PrincipalSearchResult(Of Principal) = userPrincipal.GetAuthorizationGroups()
                For Each group As Principal In userGroups
                    Dim groupSID As SecurityIdentifier = New SecurityIdentifier(group.Sid.Value)
                    groups.Add(groupSID)
                Next
            End Using
        End If

        Return groups
    End Function
    Shared Function ValidToolID(ToolID As String)
        Dim Rgx As New Regex("^[PMCG][0-9]{5,7}$")
        Return Rgx.IsMatch(ToolID)
    End Function

    Shared Function CheckDarkMode(Optional MachineOnly As Boolean = False) As Boolean
        Dim SystemLightMode = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", True)


        If MachineOnly Then
            Return Not SystemLightMode
        Else
            Dim UserTheme As String = Config.Theme
            If (UserTheme = "System" AndAlso Not SystemLightMode) OrElse UserTheme = "Dark" Then
                Return True
            Else
                Return False
            End If
        End If


    End Function
End Class






Public Class DarkMode
    <DllImport("dwmapi.dll")>
    Private Shared Function DwmSetWindowAttribute(hwnd As IntPtr, attr As Integer, ByRef attrValue As Integer, attrSize As Integer) As Integer
    End Function

    Private Const DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 As Integer = 19
    Private Const DWMWA_USE_IMMERSIVE_DARK_MODE As Integer = 20

    Public Shared DarkFormBackcolor As Color = Color.FromArgb(35, 35, 35)
    Public Shared DarkFormForecolor As Color = Color.WhiteSmoke
    Public Shared DarkButtonBackcolor As Color = Color.FromArgb(80, 80, 80)
    Public Shared DarkButtonForecolor As Color = Color.WhiteSmoke
    Public Shared DarkTextboxBackcolor As Color = Color.FromArgb(60, 60, 60)
    Public Shared DarkTextboxForecolor As Color = Color.WhiteSmoke
    Public Shared DarkLabelBackcolor As Color = Color.FromArgb(35, 35, 35)
    Public Shared DarkLabelForecolor As Color = Color.WhiteSmoke
    Public Shared DarkPanelBackcolor As Color = Color.FromArgb(35, 35, 35)
    Public Shared DarkPanelForecolor As Color = Color.WhiteSmoke
    Public Shared DarkPanelBordercolor As Color = Color.FromArgb(80, 80, 80)
    Public Shared DarkGridBackcolor As Color = Color.FromArgb(35, 35, 35)
    Public Shared DarkGridForecolor As Color = Color.WhiteSmoke
    Public Shared DarkGridHeaderBackcolor As Color = Color.FromArgb(80, 80, 80)
    Public Shared DarkGridHeaderForecolor As Color = Color.WhiteSmoke
    Public Shared DarkGridSelectionBackcolor As Color = Color.FromArgb(50, 50, 50)
    Public Shared DarkGridSelectionForecolor As Color = Color.WhiteSmoke
    Public Shared DarkGridSelectionBorderColor As Color = Color.FromArgb(80, 80, 80)
    Public Shared DarkGridBorderColor As Color = Color.FromArgb(80, 80, 80)
    Public Shared DarkGridAlternatingBackcolor As Color = Color.FromArgb(40, 40, 40)
    Public Shared DarkToolTipBackcolor As Color = Color.FromArgb(80, 80, 80)
    Public Shared DarkToolTipForecolor As Color = Color.WhiteSmoke


    Public Shared Function UseImmersiveDarkMode(FormHandle As IntPtr, enabled As Boolean) As Boolean
        If IsWindows10OrGreater(17763) Then
            Dim attribute As Integer = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1
            If IsWindows10OrGreater(18985) Then
                attribute = DWMWA_USE_IMMERSIVE_DARK_MODE
            End If

            Dim ImmersiveDarkMode As Integer = If(enabled, 1, 0)
            Return DwmSetWindowAttribute(FormHandle, attribute, ImmersiveDarkMode, Marshal.SizeOf(GetType(Integer))) = 0
        Else
            Dim dm As New DynamicMessageBox("Failed Windows version threshold.",, DynamicMessageBox.DARK_DISABLE, Management.GetCenterPoint(FormHandle))
            dm.ShowDialog()
            dm.Dispose()
        End If

        Return False
    End Function

    Private Shared Function IsWindows10OrGreater(Optional build As Integer = -1) As Boolean
        Return Environment.OSVersion.Version.Major >= 10 AndAlso Environment.OSVersion.Version.Build >= build
    End Function


    Public Shared Function IsSystemDarkMode() As Boolean
        Dim SystemLightMode = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", True)
        Return Not SystemLightMode
    End Function

    Public Shared Sub AutoDarkMode(Form As Form, DarkEnabled As Boolean)
        UseImmersiveDarkMode(Form.Handle, DarkEnabled)
        If DarkEnabled Then
            For Each control As Object In Form.Controls
                If TypeOf control Is Button Then
                    control.BackColor = DarkButtonBackcolor
                    control.ForeColor = DarkButtonForecolor
                ElseIf TypeOf control Is TextBox Then
                    control.BackColor = DarkTextboxBackcolor
                    control.ForeColor = DarkTextboxForecolor
                ElseIf TypeOf control Is Label Then
                    control.BackColor = DarkLabelBackcolor
                    control.ForeColor = DarkLabelForecolor
                ElseIf TypeOf control Is Panel Then
                    control.BackColor = DarkPanelBackcolor
                    control.ForeColor = DarkPanelForecolor
                    control.BorderStyle = BorderStyle.FixedSingle
                    control.BorderColor = DarkPanelBordercolor
                ElseIf TypeOf control Is DataGridView Then
                    control.BackgroundColor = DarkGridBackcolor
                    control.ForeColor = DarkGridForecolor
                    control.DefaultCellStyle.SelectionBackColor = DarkGridSelectionBackcolor
                    control.DefaultCellStyle.SelectionForeColor = DarkGridSelectionForecolor
                    control.DefaultCellStyle.BackColor = DarkGridAlternatingBackcolor
                    control.DefaultCellStyle.SelectionBorderColor = DarkGridSelectionBorderColor
                    control.DefaultCellStyle.BorderColor = DarkGridBorderColor
                    control.ColumnHeadersDefaultCellStyle.BackColor = DarkGridHeaderBackcolor
                    control.ColumnHeadersDefaultCellStyle.ForeColor = DarkGridHeaderForecolor
                    control.DefaultCellStyle.SelectionBackColor = DarkGridSelectionBackcolor
                    control.DefaultCellStyle.SelectionForeColor = DarkGridSelectionForecolor
                    control.DefaultCellStyle.SelectionBorderColor = DarkGridSelectionBorderColor
                    control.DefaultCellStyle.BackColor = DarkGridAlternatingBackcolor
                    control.DefaultCellStyle.SelectionBackColor = DarkGridSelectionBackcolor
                    control.DefaultCellStyle.SelectionForeColor = DarkGridSelectionForecolor
                    control.DefaultCellStyle.SelectionBorderColor = DarkGridSelectionBorderColor
                    control.DefaultCellStyle.BackColor = DarkGridAlternatingBackcolor
                End If
                If control.HasChildren Then
                    For Each subcontrol As Object In control.Controls
                        If TypeOf subcontrol Is Button Then
                            subcontrol.BackColor = DarkButtonBackcolor
                            subcontrol.ForeColor = DarkButtonForecolor
                        ElseIf TypeOf subcontrol Is TextBox Then
                            subcontrol.BackColor = DarkTextboxBackcolor
                            subcontrol.ForeColor = DarkTextboxForecolor
                        ElseIf TypeOf subcontrol Is Label Then
                            subcontrol.BackColor = DarkLabelBackcolor
                            subcontrol.ForeColor = DarkLabelForecolor
                        ElseIf TypeOf subcontrol Is Panel Then
                            subcontrol.BackColor = DarkPanelBackcolor
                            subcontrol.ForeColor = DarkPanelForecolor
                            subcontrol.BorderStyle = BorderStyle.FixedSingle
                        ElseIf TypeOf subcontrol Is DataGridView Then
                            subcontrol.BackgroundColor = DarkGridBackcolor
                            subcontrol.ForeColor = DarkGridForecolor
                            subcontrol.DefaultCellStyle.SelectionBackColor = DarkGridSelectionBackcolor
                            subcontrol.DefaultCellStyle.SelectionForeColor = DarkGridSelectionForecolor
                            subcontrol.DefaultCellStyle.BackColor = DarkGridAlternatingBackcolor
                            subcontrol.DefaultCellStyle.SelectionBorderColor = DarkGridSelectionBorderColor
                            subcontrol.DefaultCellStyle.BorderColor = DarkGridBorderColor
                            subcontrol.ColumnHeadersDefaultCellStyle.BackColor = DarkGridHeaderBackcolor
                            subcontrol.ColumnHeadersDefaultCellStyle.ForeColor = DarkGridHeaderForecolor
                            subcontrol.DefaultCellStyle.SelectionBackColor = DarkGridSelectionBackcolor
                            subcontrol.DefaultCellStyle.SelectionForeColor = DarkGridSelectionForecolor
                            subcontrol.DefaultCellStyle.SelectionBorderColor = DarkGridSelectionBorderColor
                            subcontrol.DefaultCellStyle.BackColor = DarkGridAlternatingBackcolor
                            subcontrol.DefaultCellStyle.SelectionBackColor = DarkGridSelectionBackcolor
                            subcontrol.DefaultCellStyle.SelectionForeColor = DarkGridSelectionForecolor
                            subcontrol.DefaultCellStyle.SelectionBorderColor = DarkGridSelectionBorderColor
                            subcontrol.DefaultCellStyle.BackColor = DarkGridAlternatingBackcolor

                        End If


                    Next
                End If
            Next

        Else
            For Each control As Object In Form.Controls
                If TypeOf control Is Button Then
                    control.BackColor = SystemColors.Control
                    control.ForeColor = SystemColors.ControlText
                ElseIf TypeOf control Is TextBox Then
                    control.BackColor = SystemColors.Window
                    control.ForeColor = SystemColors.ControlText
                ElseIf TypeOf control Is Label Then
                    control.BackColor = SystemColors.Control
                    control.ForeColor = SystemColors.ControlText
                ElseIf TypeOf control Is Panel Then
                    control.BackColor = SystemColors.Control
                    control.ForeColor = SystemColors.ControlText
                    control.BorderStyle = BorderStyle.None
                ElseIf TypeOf control Is DataGridView Then
                    control.BackgroundColor = SystemColors.Window
                    control.ForeColor = SystemColors.ControlText
                    control.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight
                    control.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText
                    control.DefaultCellStyle.BackColor = SystemColors.Window
                    control.DefaultCellStyle.SelectionBorderColor = SystemColors.Highlight
                    control.DefaultCellStyle.BorderColor = SystemColors.Control
                    control.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control
                    control.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText
                    control.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight
                    control.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText
                    control.DefaultCellStyle.SelectionBorderColor = SystemColors.Highlight
                    control.DefaultCellStyle.BackColor = SystemColors.Window
                    control.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight
                    control.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText
                    control.DefaultCellStyle.SelectionBorderColor = SystemColors.Highlight
                    control.DefaultCellStyle.BackColor = SystemColors.Window
                    control.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight
                    control.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText
                    control.DefaultCellStyle.SelectionBorderColor = SystemColors.Highlight
                    control.DefaultCellStyle.BackColor = SystemColors.Window
                End If
                If control.HasChildren Then
                    For Each subcontrol As Object In control.Controls
                        If TypeOf subcontrol Is Button Then
                            subcontrol.BackColor = SystemColors.Control
                            subcontrol.ForeColor = SystemColors.ControlText
                        ElseIf TypeOf subcontrol Is TextBox Then
                            subcontrol.BackColor = SystemColors.Window
                            subcontrol.ForeColor = SystemColors.ControlText
                        ElseIf TypeOf subcontrol Is Label Then
                            subcontrol.BackColor = SystemColors.Control
                            subcontrol.ForeColor = SystemColors.ControlText
                        ElseIf TypeOf subcontrol Is Panel Then
                            subcontrol.BackColor = SystemColors.Control
                            subcontrol.ForeColor = SystemColors.ControlText
                            subcontrol.BorderStyle = BorderStyle.None
                        ElseIf TypeOf subcontrol Is DataGridView Then
                            subcontrol.BackgroundColor = SystemColors.Window
                            subcontrol.ForeColor = SystemColors.ControlText
                            subcontrol.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight
                            subcontrol.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText
                            subcontrol.DefaultCellStyle.BackColor = SystemColors.Window
                            subcontrol.DefaultCellStyle.SelectionBorderColor = SystemColors.Highlight
                            subcontrol.DefaultCellStyle.BorderColor = SystemColors.Control
                            subcontrol.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control
                            subcontrol.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText
                            subcontrol.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight
                            subcontrol.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText
                            subcontrol.DefaultCellStyle.SelectionBorderColor = SystemColors.Highlight
                            subcontrol.DefaultCellStyle.BackColor = SystemColors.Window
                        End If
                    Next
                End If
            Next
        End If


    End Sub
End Class
