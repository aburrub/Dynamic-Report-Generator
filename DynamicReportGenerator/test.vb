Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports Devart.Data.PostgreSql
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Core



Public Class test
    Private Sub test_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            Dim sql As String = "select * from attendance_sheet"
            Dim conn As New PgSqlConnection(consts.DEFAULT_PGSQL_CONNECTION_STRING)
            conn.Open()
            Dim cmd As New PgSqlCommand(sql, conn)
            Dim r As PgSqlDataReader = cmd.ExecuteReader
            Dim f As Boolean = True
            Dim fds As New List(Of DataGridViewTextBoxCell)
            Dim res As Date = Now
            Dim rows As New List(Of DataGridViewRow)
            While r.Read
                If f Then
                    For i As Integer = 0 To r.FieldCount - 1
                        'Me.DataGridView1.Columns.Add("col" + i.ToString, "col" + i.ToString)
                    Next
                    f = False
                End If
                fds.Clear()

                For i As Integer = 0 To r.FieldCount - 1
                    Dim rrrr As New DataGridViewTextBoxCell()
                    rrrr.Value = r.Item(i).ToString
                    fds.Add(rrrr)
                Next
                Dim ccc As New DataGridViewRow
                ccc.Cells.AddRange(fds.ToArray)
                rows.Add(ccc)
            End While
            'Me.DataGridView1.Rows.AddRange(rows.ToArray)
            Dim t As TimeSpan = Now.Subtract(res)
            MsgBox(t.Milliseconds)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try



    End Sub


    Private Sub test_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MsgBox(My.Application.Culture.Name)

        '  For Each c As System.Globalization.CultureInfo In System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures)
        ' MsgBox(c.Name)
        ' Next
    End Sub
End Class