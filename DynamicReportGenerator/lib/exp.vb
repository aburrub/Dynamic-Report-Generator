Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Core

Public Class exp

    Public Shared Sub expPDF(ByRef dgv As DataGridView, ByVal path As String, Optional ByVal resolution As Integer = 150)
        Dim columsInPage As Integer = dgv.Columns.Count

        Dim document As New iTextSharp.text.Document(New iTextSharp.text.Rectangle(columsInPage * resolution, columsInPage * resolution))
        iTextSharp.text.pdf.PdfWriter.GetInstance(document, New IO.FileStream(path, IO.FileMode.Create))
        document.Open()
        Dim par As New iTextSharp.text.Paragraph()
        par.Add("Report Results")

        Dim tb As New iTextSharp.text.pdf.PdfPTable(columsInPage)

        Dim colcount As Integer = dgv.Columns.Count - 1
        Dim col As DataGridViewColumn
        Dim row As DataGridViewRow
        ' header
        For ii As Integer = 0 To dgv.Columns.Count - 1
            col = dgv.Columns(ii)
            tb.AddCell(col.HeaderText)
        Next

        For jj As Integer = 0 To dgv.Rows.Count - 1
            Try
                row = dgv.Rows(jj)
                For i As Integer = 0 To dgv.Columns.Count - 1
                    MsgBox(row.Cells(i).Value.ToString)
                    tb.AddCell(row.Cells(i).Value.ToString)
                Next

            Catch ex As Exception

            End Try

        Next

        par.Alignment = 1


        document.Add(par)
        document.Add(New iTextSharp.text.Paragraph(" "))

        document.Add(tb)


        document.Close()

    End Sub

    Public Shared Sub exportToExcel(ByVal sheetName As String, ByVal path As String, ByRef dgv As DataGridView)
        Try

            Dim xlApp As New Application
            Dim xlWorkBook As Workbook
            Dim xlWorkSheet As Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value

            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")
            xlWorkSheet.Name = sheetName

            Dim firstRow As Integer = 1
            Dim colcount As Integer = dgv.Columns.Count - 1
            Dim col As DataGridViewColumn
            Dim row As DataGridViewRow

            For i As Integer = 0 To colcount
                col = dgv.Columns(i)
                xlWorkSheet.Cells(firstRow, i + 1) = col.HeaderText
            Next

            For i As Integer = 0 To dgv.Rows.Count - 1
                row = dgv.Rows(i)
                firstRow = firstRow + 1
                For j As Integer = 0 To colcount
                    xlWorkSheet.Cells(firstRow, j + 1) = row.Cells(j).Value
                Next
            Next
            xlWorkSheet.SaveAs(path)

            xlWorkBook.Close()
            xlApp.Quit()

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Shared Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Public Shared Sub ExportToExcel_FastMode(ByVal dataSet As DataSet, ByVal outputPath As String)
        ' Create the Excel Application object
        Dim excelApp As New Application()

        ' Create a new Excel Workbook
        Dim excelWorkbook As Workbook = excelApp.Workbooks.Add(Type.Missing)

        Dim sheetIndex As Integer = 0
        Dim col, row As Integer
        Dim excelSheet As Worksheet

        ' Copy each DataTable as a new Sheet
        For Each dt As System.Data.DataTable In dataSet.Tables

            sheetIndex += 1

            ' Copy the DataTable to an object array
            Dim rawData(dt.Rows.Count, dt.Columns.Count - 1) As Object

            ' Copy the column names to the first row of the object array
            For col = 0 To dt.Columns.Count - 1
                rawData(0, col) = dt.Columns(col).ColumnName
            Next

            ' Copy the values to the object array
            For col = 0 To dt.Columns.Count - 1
                For row = 0 To dt.Rows.Count - 1
                    MsgBox(dt.Rows(row).ItemArray(col).GetType().Name)
                    rawData(row + 1, col) = dt.Rows(row).ItemArray(col)
                Next
            Next

            ' Calculate the final column letter
            Dim finalColLetter As String = String.Empty
            Dim colCharset As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            Dim colCharsetLen As Integer = colCharset.Length

            If dt.Columns.Count > colCharsetLen Then
                finalColLetter = colCharset.Substring( _
                 (dt.Columns.Count - 1) \ colCharsetLen - 1, 1)
            End If

            finalColLetter += colCharset.Substring( _
              (dt.Columns.Count - 1) Mod colCharsetLen, 1)

            ' Create a new Sheet
            excelSheet = CType( _
                excelWorkbook.Sheets.Add(excelWorkbook.Sheets(sheetIndex), _
                Type.Missing, 1, XlSheetType.xlWorksheet), Worksheet)

            excelSheet.Name = dt.TableName

            ' Fast data export to Excel
            Dim excelRange As String = String.Format("A1:{0}{1}", finalColLetter, dt.Rows.Count + 1)
            excelSheet.Range(excelRange, Type.Missing).Value2 = rawData

            ' Mark the first row as BOLD
            CType(excelSheet.Rows(1, Type.Missing), Range).Font.Bold = True

            excelSheet = Nothing
        Next

        ' Save and Close the Workbook
        excelWorkbook.SaveAs(outputPath, XlFileFormat.xlWorkbookNormal, Type.Missing, _
         Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, _
         Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)

        excelWorkbook.Close(True, Type.Missing, Type.Missing)

        excelWorkbook = Nothing

        ' Release the Application object
        excelApp.Quit()
        excelApp = Nothing

        ' Collect the unreferenced objects
        GC.Collect()
        GC.WaitForPendingFinalizers()

    End Sub
End Class
