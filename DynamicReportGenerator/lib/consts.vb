Public Class consts

    ' MAIN PROJECTS VARIABLES
    Public Shared MAIN_PROJECT_IS_CONNECTION_SET As Boolean = False
    Public Shared MAIN_PROJECT_IS_CONNECTED As Boolean
    Public Shared MAIN_PROJECT_DBMS As String
    Public Shared MAIN_PROJECT_ACCESS_CONNECTION As OleDb.OleDbConnection
    Public Shared MAIN_PROJECT_PGSQL_CONNECTION As Devart.Data.PostgreSql.PgSqlConnection
    ' END OF MAIN PROJECTS VARIABLES

    Public Shared FOREINKEY_RELATED_PRIMARYKEY_TABLE_INDEX As Integer = 2
    Public Shared FOREINKEY_RELATED_PRIMARYKEY_COLUMN_INDEX As Integer = 3
    Public Shared FOREINKEY_TABLE_COLUMN_INDEX As Integer = 8
    Public Shared FOREINKEY_COLUMN_COLUMN_INDEX As Integer = 9

    Public Shared FOREINKEY_NAME_COLUMN_INDEX As Integer = 16

    Public Shared AVAILABLE_DATABASES As New List(Of String)(New String() {"PostgreSql", "Access", "Sql Server"})
    Public Shared DEFAULT_ACCESS_CONNECTION_STRING As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=?CURRENT_ACCESS_FILE_PATH?;Persist Security Info=False"
    Public Shared DEFAULT_PGSQL_CONNECTION_STRING As String = "User ID=postgres;Password=1040039;Host=127.0.0.1;Port=5432;Database=hr; Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0;"

    Public Shared MY_SETTINGS_OUTPUT_FILE As String = "drg.xml"
End Class
