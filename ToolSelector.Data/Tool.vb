Imports System.Data.SQLite
Imports System.Drawing

Public Class Tool
    Private l_ToolID As String
    Private l_ToolDescription As String
    Private l_ToolType As String
    Private l_ToolCalibrationDate As Date
    Private l_ToolCalibrationDueDate As Date
    Private l_ToolCalibrationFrequency As Integer
    Private l_ToolCalibrationNotes As String
    Private l_ToolLastActionDate As Date
    Private l_ToolLastActionBy As String
    Private l_ToolNotes As String
    Private l_ToolImage As Image
    Private l_ToolImageUrl As String

    Public Sub New()

    End Sub

    Public Property ToolID As String
        Get
            Return l_ToolID
        End Get
        Set(value As String)
            l_ToolID = value
        End Set
    End Property

    Public Property ToolDescription As String
        Get
            Return l_ToolDescription
        End Get
        Set(value As String)
            l_ToolDescription = value
        End Set
    End Property

    Public Property ToolType As String
        Get
            Return l_ToolType
        End Get
        Set(value As String)
            l_ToolType = value
        End Set
    End Property

    Public Property ToolCalibrationDate As Date
        Get
            Return l_ToolCalibrationDate
        End Get
        Set(value As Date)
            l_ToolCalibrationDate = value
        End Set
    End Property

    Public Property ToolCalibrationDueDate As Date
        Get
            Return l_ToolCalibrationDueDate
        End Get
        Set(value As Date)
            l_ToolCalibrationDueDate = value
        End Set
    End Property

    Public Property ToolCalibrationFrequency As Integer
        Get
            Return l_ToolCalibrationFrequency
        End Get
        Set(value As Integer)
            l_ToolCalibrationFrequency = value
        End Set
    End Property

    Public Property ToolCalibrationNotes As String
        Get
            Return l_ToolCalibrationNotes
        End Get
        Set(value As String)
            l_ToolCalibrationNotes = value
        End Set
    End Property

    Public Property ToolLastActionDate As Date
        Get
            Return l_ToolLastActionDate
        End Get
        Set(value As Date)
            l_ToolLastActionDate = value
        End Set
    End Property

    Public Property ToolLastActionBy As String
        Get
            Return l_ToolLastActionBy
        End Get
        Set(value As String)
            l_ToolLastActionBy = value
        End Set
    End Property

    Public Property ToolNotes As String
        Get
            Return l_ToolNotes
        End Get
        Set(value As String)
            l_ToolNotes = value
        End Set
    End Property

    Public Property ToolImage As Image
        Get
            Return l_ToolImage
        End Get
        Set(value As Image)
            l_ToolImage = value
        End Set
    End Property

    Public Property ToolImageUrl As String
        Get
            Return l_ToolImageUrl
        End Get
        Set(value As String)
            l_ToolImageUrl = value
        End Set
    End Property



    Public Shared Function LoadTools(FilePath As String) As List(Of Tool)
        If IO.File.Exists(FilePath) Then
            Dim SQLConn As New SQLiteConnection("Data Source=" & FilePath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "SELECT * FROM Tools;"
            Dim SQLReader As SQLiteDataReader = SQLCmd.ExecuteReader()
            Dim l_ToolList As New List(Of Tool)
            Do While SQLReader.Read()
                Dim t As New Tool
                t.ToolID = SQLReader("ToolID")
                t.ToolDescription = SQLReader("ToolDescription")
                t.ToolType = SQLReader("ToolType")
                t.ToolCalibrationDate = SQLReader("ToolCalibrationDate")
                t.ToolCalibrationDueDate = SQLReader("ToolCalibrationDueDate")
                t.ToolCalibrationFrequency = SQLReader("ToolCalibrationFrequency")
                t.ToolCalibrationNotes = SQLReader("ToolCalibrationNotes")
                t.ToolLastActionDate = SQLReader("ToolLastActionDate")
                t.ToolLastActionBy = SQLReader("ToolLastActionBy")
                t.ToolNotes = SQLReader("ToolNotes")
                t.ToolImageUrl = SQLReader("ToolImageUrl")
                If Not String.IsNullOrWhiteSpace(t.ToolImageUrl) Then
                    Try
                        t.ToolImage = Image.FromFile(t.ToolImageUrl)
                    Catch ex As Exception
                    End Try
                End If
                l_ToolList.Add(t)
            Loop
            SQLConn.Close()
            Return l_ToolList
        Else
            CreateToolDB(FilePath)
            Return New List(Of Tool)
        End If
    End Function

    Public Shared Function ToTable(Tools As List(Of Tool)) As DataTable
        Dim ToolTable As New DataTable
        ToolTable.Columns.Add("ToolID", GetType(String))
        ToolTable.Columns.Add("ToolDescription", GetType(String))
        ToolTable.Columns.Add("ToolType", GetType(String))
        ToolTable.Columns.Add("ToolCalibrationDate", GetType(Date))
        ToolTable.Columns.Add("ToolCalibrationDueDate", GetType(Date))
        ToolTable.Columns.Add("ToolCalibrationFrequency", GetType(Integer))
        ToolTable.Columns.Add("ToolCalibrationNotes", GetType(String))
        ToolTable.Columns.Add("ToolLastActionDate", GetType(Date))
        ToolTable.Columns.Add("ToolLastActionBy", GetType(String))
        ToolTable.Columns.Add("ToolNotes", GetType(String))
        ToolTable.Columns.Add("ToolImageUrl", GetType(String))
        For Each t As Tool In Tools
            Dim r As DataRow = ToolTable.NewRow
            r("ToolID") = t.ToolID
            r("ToolDescription") = t.ToolDescription
            r("ToolType") = t.ToolType
            r("ToolCalibrationDate") = t.ToolCalibrationDate
            r("ToolCalibrationDueDate") = t.ToolCalibrationDueDate
            r("ToolCalibrationFrequency") = t.ToolCalibrationFrequency
            r("ToolCalibrationNotes") = t.ToolCalibrationNotes
            r("ToolLastActionDate") = t.ToolLastActionDate
            r("ToolLastActionBy") = t.ToolLastActionBy
            r("ToolNotes") = t.ToolNotes
            r("ToolImageUrl") = t.ToolImageUrl
            ToolTable.Rows.Add(r)
        Next
        Return ToolTable
    End Function

    Public Shared Sub SaveToolDB(FilePath As String, ToolList As List(Of Tool))
        If Not IO.File.Exists(FilePath) Then CreateToolDB(FilePath)
        Dim SQLConn As New SQLiteConnection("Data Source=" & FilePath & ";Version=3;")
        SQLConn.Open()
        Dim SQLCmd As New SQLiteCommand(SQLConn)
        SQLCmd.CommandText = "DELETE FROM Tools;"
        SQLCmd.ExecuteNonQuery()
        For Each t As Tool In ToolList
            SQLCmd.CommandText = $"INSERT INTO Tools (ToolID, ToolDescription, ToolType, ToolCalibrationDate, ToolCalibrationDueDate, ToolCalibrationFrequency, ToolCalibrationNotes, ToolLastActionDate, ToolLastActionBy, ToolNotes, ToolImageUrl) VALUES ('{t.ToolID}', '{t.ToolDescription}', '{t.ToolType}', '{t.ToolCalibrationDate}', '{t.ToolCalibrationDueDate}', {t.ToolCalibrationFrequency}, '{t.ToolCalibrationNotes}', '{t.ToolLastActionDate}', '{t.ToolLastActionBy}', '{t.ToolNotes}', '{t.ToolImageUrl}');"
            SQLCmd.ExecuteNonQuery()
        Next
        SQLConn.Close()
    End Sub

    Private Shared Sub CreateToolDB(FilePath As String)
        Try
            IO.Directory.CreateDirectory(FilePath.Substring(0, FilePath.LastIndexOf("\")))
            Dim SQLConn As New SQLiteConnection("Data Source=" & FilePath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "CREATE TABLE Tools (ToolID TEXT PRIMARY KEY, ToolDescription TEXT, ToolType TEXT, ToolCalibrationDate TEXT, ToolCalibrationDueDate TEXT, ToolCalibrationFrequency INTEGER, ToolCalibrationNotes TEXT, ToolLastActionDate TEXT, ToolLastActionBy TEXT, ToolNotes TEXT, ToolImageUrl TEXT);"
            SQLCmd.ExecuteNonQuery()
            SQLConn.Close()
        Catch ex As Exception

        End Try
    End Sub

End Class