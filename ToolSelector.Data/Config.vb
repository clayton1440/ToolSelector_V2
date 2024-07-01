Imports System.Data.SQLite

Public Class Config

    Private Shared CfgPath As String = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\ToolSelector\UserConfig.tsuc"

    Private Shared CfgSchema As String =
"CREATE TABLE Config (
    FormYPos INTEGER NOT NULL DEFAULT 428,
    FormXPos INTEGER NOT NULL DEFAULT 316,
    FormWidth INTEGER NOT NULL DEFAULT 0,
    FormHeight INTEGER NOT NULL DEFAULT 0,
    ExportPath TEXT, SharedToolPath TEXT,
    CloseAfterExport INTEGER NOT NULL DEFAULT 0,
    ToolsCheckedWarning INTEGER NOT NULL DEFAULT 1,
    Theme TEXT DEFAULT 'System',
    LoadSharedToolsOnOpen INTEGER NOT NULL DEFAULT 1,
    HighlightExpiredTools INTEGER NOT NULL DEFAULT 0,
    CheckExpiredToolsOnExport INTEGER NOT NULL DEFAULT 1,
    DisableDarkMessageBox INTEGER NOT NULL DEFAULT 0
);"

    Private Shared Sub CheckConfigDB()
        If Not IO.File.Exists(CfgPath) Then
            Try
                IO.Directory.CreateDirectory(CfgPath.Substring(0, CfgPath.LastIndexOf("\")))
                Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
                SQLConn.Open()
                Dim SQLCmd As New SQLiteCommand(SQLConn)
                SQLCmd.CommandText = CfgSchema
                SQLCmd.ExecuteNonQuery()
                SQLCmd.CommandText = "INSERT INTO Config DEFAULT VALUES;"
                SQLCmd.ExecuteNonQuery()
                SQLConn.Close()
            Catch ex As Exception

            End Try
        Else 'check for missing columns
            UpdateConfigDB()
        End If
    End Sub

    Private Shared Sub UpdateConfigDB()
        Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
        SQLConn.Open()
        Dim SQLCmd As New SQLiteCommand(SQLConn)
        SQLCmd.CommandText =
"SELECT sql
FROM sqlite_master
WHERE type = 'table' AND name = 'Config';"

        Dim ExistingSchema As String = SQLCmd.ExecuteScalar()
        ExistingSchema.Trim(vbCrLf, ";"c)
        Dim NewSchema As String = CfgSchema.Trim(";"c)

        If ExistingSchema <> NewSchema Then
            Console.WriteLine("Updating Config Database")
            Try
                SQLCmd.CommandText = "ALTER TABLE Config RENAME TO ConfigOld;"
                SQLCmd.ExecuteNonQuery()
                SQLCmd.CommandText = CfgSchema
                SQLCmd.ExecuteNonQuery()
            Catch ex As Exception
                'major problem, cannot create new config table.
                SQLCmd.CommandText = "DROP TABLE Config;"
                SQLCmd.ExecuteNonQuery()
                SQLCmd.CommandText = "ALTER TABLE ConfigOld RENAME TO Config;"
                SQLCmd.ExecuteNonQuery()
                SQLConn.Close()
                SQLConn.Dispose()
                Throw New Exception("Database schema update failed.")
                Return
            End Try
            Try
                'iterate through old columns and copy to new table
                SQLCmd.CommandText = "INSERT INTO Config DEFAULT VALUES"
                SQLCmd.ExecuteNonQuery()
                Dim oldConfig As New DataTable
                SQLCmd.CommandText = "SELECT * FROM ConfigOld;"
                oldConfig.Load(SQLCmd.ExecuteReader())
                For i = 0 To oldConfig.Columns.Count - 1
                    Dim colName As String = oldConfig.Columns(i).ColumnName
                    Dim colVal As Object = oldConfig.Rows(0).Item(i)
                    Try
                        SQLCmd.CommandText = $"UPDATE Config SET {colName} = '{colVal}';"
                        SQLCmd.ExecuteNonQuery()
                    Catch ex2 As Exception
                        'cannot add column, leave default
                    End Try
                Next
            Catch ex As Exception
                Dim null = Nothing
            End Try
            Try
                SQLCmd.CommandText = "DROP TABLE ConfigOld;"
                SQLCmd.ExecuteNonQuery()
            Catch ex As Exception
                'cannot drop old table
            End Try
        End If
        SQLConn.Close()
        SQLConn.Dispose()
    End Sub

    Private Shared Sub RepairConfigDB()
        Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
        SQLConn.Open()
        Dim SQLCmd As New SQLiteCommand(SQLConn)
        SQLCmd.CommandText = "DROP TABLE Config;"
        SQLCmd.ExecuteNonQuery()
        SQLCmd.CommandText = "ALTER TABLE ConfigOld RENAME TO Config;"
        SQLCmd.ExecuteNonQuery()
        SQLConn.Close()
        SQLConn.Dispose()
    End Sub

    Public Shared Property FormYPos As Integer
        Get
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "SELECT FormYPos FROM Config"
            Dim yPos As Integer = SQLCmd.ExecuteScalar()
            SQLConn.Close()
            Return yPos
        End Get
        Set(value As Integer)
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "UPDATE Config SET FormYPos = " & value
            SQLCmd.ExecuteNonQuery()
            SQLConn.Close()
        End Set
    End Property

    Public Shared Property FormXPos As Integer
        Get
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "SELECT FormXPos FROM Config"
            Dim xPos As Integer = SQLCmd.ExecuteScalar()
            SQLConn.Close()
            Return xPos
        End Get
        Set(value As Integer)
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "UPDATE Config SET FormXPos = " & value
            SQLCmd.ExecuteNonQuery()
            SQLConn.Close()
        End Set
    End Property

    Public Shared Property FormWidth As Integer
        Get
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "SELECT FormWidth FROM Config"
            Dim width As Integer = SQLCmd.ExecuteScalar()
            SQLConn.Close()
            Return width
        End Get
        Set(value As Integer)
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "UPDATE Config SET FormWidth = " & value
            SQLCmd.ExecuteNonQuery()
            SQLConn.Close()
        End Set
    End Property

    Public Shared Property FormHeight As Integer
        Get
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "SELECT FormHeight FROM Config"
            Dim height As Integer = SQLCmd.ExecuteScalar()
            SQLConn.Close()
            Return height
        End Get
        Set(value As Integer)
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "UPDATE Config SET FormHeight = " & value
            SQLCmd.ExecuteNonQuery()
            SQLConn.Close()
        End Set
    End Property

    Public Shared Property ExportPath As String
        Get
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "SELECT ExportPath FROM Config"
            Dim path As String = SQLCmd.ExecuteScalar().ToString
            If path Is Nothing Then path = ""
            SQLConn.Close()
            Return path
        End Get
        Set(value As String)
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "UPDATE Config SET ExportPath = '" & value & "'"
            SQLCmd.ExecuteNonQuery()
            SQLConn.Close()
        End Set
    End Property

    Public Shared Property SharedToolPath As List(Of String)
        Get
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "SELECT SharedToolPath FROM Config"
            Dim path As String = SQLCmd.ExecuteScalar().ToString
            If path Is Nothing Then path = ""
            SQLConn.Close()
            Dim paths As New List(Of String)
            If path IsNot Nothing Then
                paths = path.Split("|", Short.MaxValue, StringSplitOptions.RemoveEmptyEntries).ToList
            End If
            Return paths
        End Get
        Set(value As List(Of String))
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            Dim paths As String = String.Join("|", value)
            SQLCmd.CommandText = "UPDATE Config SET SharedToolPath = '" & paths & "'"
            SQLCmd.ExecuteNonQuery()
            SQLConn.Close()
        End Set
    End Property

    Public Shared Property CloseAfterExport As Boolean
        Get
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "SELECT CloseAfterExport FROM Config"
            Dim close As Integer = SQLCmd.ExecuteScalar()
            SQLConn.Close()
            Return close
        End Get
        Set(value As Boolean)
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "UPDATE Config SET CloseAfterExport = " & If(value, 1, 0)
            SQLCmd.ExecuteNonQuery()
            SQLConn.Close()
        End Set
    End Property

    Public Shared Property ToolsCheckedWarning As Boolean
        Get
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "SELECT ToolsCheckedWarning FROM Config"
            Dim warn As Integer = SQLCmd.ExecuteScalar()
            SQLConn.Close()
            Return warn
        End Get
        Set(value As Boolean)
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "UPDATE Config SET ToolsCheckedWarning = " & If(value, 1, 0)
            SQLCmd.ExecuteNonQuery()
            SQLConn.Close()
        End Set
    End Property

    Public Shared Property Theme As String
        Get
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "SELECT Theme FROM Config"
            Dim _theme As String = SQLCmd.ExecuteScalar()
            If _theme Is Nothing Then _theme = ""
            SQLConn.Close()
            Return _theme
        End Get
        Set(value As String)
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "UPDATE Config SET Theme = '" & value & "'"
            SQLCmd.ExecuteNonQuery()
            SQLConn.Close()
        End Set
    End Property

    Public Shared Property LoadSharedToolsOnOpen As Boolean
        Get
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "SELECT LoadSharedToolsOnOpen FROM Config"
            Dim load As Integer = SQLCmd.ExecuteScalar()
            SQLConn.Close()
            Return load
        End Get
        Set(value As Boolean)
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "UPDATE Config SET LoadSharedToolsOnOpen = " & If(value, 1, 0)
            SQLCmd.ExecuteNonQuery()
            SQLConn.Close()
        End Set
    End Property

    Public Shared Property HighlightExpiredTools As Boolean
        Get
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "SELECT HighlightExpiredTools FROM Config"
            Dim highlight As Integer = SQLCmd.ExecuteScalar()
            SQLConn.Close()
            Return highlight
        End Get
        Set(value As Boolean)
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "UPDATE Config SET HighlightExpiredTools = " & If(value, 1, 0)
            SQLCmd.ExecuteNonQuery()
            SQLConn.Close()
        End Set
    End Property

    Public Shared Property CheckExpiredToolsOnExport As Boolean
        Get
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "SELECT CheckExpiredToolsOnExport FROM Config"
            Dim check As Integer = SQLCmd.ExecuteScalar()
            SQLConn.Close()
            Return check
        End Get
        Set(value As Boolean)
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "UPDATE Config SET CheckExpiredToolsOnExport = " & If(value, 1, 0)
            SQLCmd.ExecuteNonQuery()
            SQLConn.Close()
        End Set
    End Property

    Public Shared Property DisableDarkMessageBox As Boolean
        Get
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "SELECT DisableDarkMessageBox FROM Config"
            Dim disable As Integer = SQLCmd.ExecuteScalar()
            SQLConn.Close()
            Return disable
        End Get
        Set(value As Boolean)
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "UPDATE Config SET DisableDarkMessageBox = " & If(value, 1, 0)
            SQLCmd.ExecuteNonQuery()
            SQLConn.Close()
        End Set
    End Property

End Class

