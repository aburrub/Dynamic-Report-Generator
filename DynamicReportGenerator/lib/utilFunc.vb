Public Class utilFunc
    '    Public Shared Function convertToUtf8(ByVal str As String) As String
    '        Try
    '   Dim enc As System.Text.Encoding = href.Utils.EncodingTools.GetMostEfficientEncoding(Str)
    '  Dim strBytes() As Byte = Enc.GetBytes(Str)
    '         Return System.Text.Encoding.UTF8.GetString(strBytes)
    '    Catch ex As Exception
    '       MsgBox(ex.Message)
    '      Return Nothing
    ' End Try

    ' End Function
    Public Shared Sub addWithoutDuplication(ByVal item As String, ByRef arr As List(Of String))
        Dim notExist As Boolean = False
        For Each itm As String In arr
            If itm = item Then
                notExist = True
                Exit For
            End If
        Next

        If Not notExist Then
            arr.Add(item)
        End If
    End Sub



    Public Shared Function findInArray(ByRef arr As String(), ByVal item As String) As Boolean

        For Each itm As String In arr
            If itm = item Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Shared Function findInArray(ByRef arr As List(Of String), ByVal item As String) As Boolean
        For Each itm As String In arr
            If itm = item Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Shared Sub copyArr(ByRef a As List(Of String), ByRef b As List(Of String))
        b.Clear()
        For Each itm As String In a
            b.Add(itm)
        Next
    End Sub
    Public Shared Function printlist(ByVal arr As List(Of String)) As String
        Dim st As String = "["
        For Each item As String In arr
            st = st + item + ", "

        Next
        st = st + "]"
        Return st
    End Function


    Public Shared Function hasNotAlphnumericChars(ByVal str As String) As Boolean
        Dim reg As New System.Text.RegularExpressions.Regex("^[a-zA-Z0-9|.]*$")
        Return Not reg.Match(str).Success
    End Function
    Public Shared Function findInArray2(ByVal arr As String, ByVal ch_param As Char) As Boolean
        For Each ch As Char In arr
            If ch = ch_param Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Shared Sub printArray(ByVal arr As String())
        Dim r As String = ""
        For Each t As String In arr
            r = r + t + Environment.NewLine
        Next
        MsgBox(r)
    End Sub
    Public Shared Sub printArray(ByVal arr As Integer())
        Dim r As String = ""
        For Each t As String In arr
            r = r + t.ToString + Environment.NewLine
        Next
        MsgBox(r)
    End Sub
    Public Shared Function printSchema(ByRef dt As DataTable) As String
        Dim res As String = ""
        For Each row As DataRow In dt.Rows
            For i As Integer = 0 To dt.Columns.Count - 1
                res = res + "[" + dt.Columns(i).ColumnName + "] (" + row.ItemArray(i).ToString + ")"
            Next
            res = res + Environment.NewLine + Environment.NewLine
        Next
        MsgBox(res)
        Return res
    End Function

    '   Public Shared Function GetOriginalEncodedString1(ByVal x As String, Optional ByVal LanguageAutoDetection As Boolean = True) As String
    '      Try
    '
    ' Dim encoding As String

    'Dim b As New List(Of Byte)
    '       For Each ch As Char In x
    '          b.Add(Asc(ch))
    '     Next

    '    If LanguageAutoDetection Then
    '            encoding = href.Utils.EncodingTools.DetectInputCodepage(b.ToArray).HeaderName
    '       Else
    '          encoding = "windows-1256"
    '     End If

    'Dim eee As System.Text.Encoding = System.Text.Encoding.GetEncoding(encoding)

    '       Return System.Text.Encoding.GetEncoding(encoding).GetString(b.ToArray)
    '  Catch ex As Exception
    '     Return Nothing
    'End Try

    ' End Function

End Class
