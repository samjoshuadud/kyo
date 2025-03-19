Imports MySql.Data.MySqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop.Word
Imports System.IO
Imports System.Data
Imports Emgu.CV.ImgHash
Imports System.Reflection.Metadata


Public Class ExportUser
    Private ConnectionString As String = "server=localhost;database=smgsisbstp;uid=root;pwd=;"

    ' === Export to Excel ===
    Public Sub ExportToExcel()
        Try
            Dim conn As New MySqlConnection(ConnectionString)
            conn.Open()

            Dim cmd As New MySqlCommand("SELECT * FROM Users", conn)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New System.Data.DataTable()
            adapter.Fill(dt)
            conn.Close()

            ' Ask for save location
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"
            saveDialog.Title = "Save Excel File"
            If saveDialog.ShowDialog() <> DialogResult.OK Then Exit Sub
            Dim filePath As String = saveDialog.FileName

            ' Create Excel Application
            Dim excelApp As New Microsoft.Office.Interop.Excel.Application()
            Dim workbook As Workbook = excelApp.Workbooks.Add()
            Dim worksheet As Worksheet = workbook.Sheets(1)

            ' Column headers
            For i As Integer = 0 To dt.Columns.Count - 1
                worksheet.Cells(1, i + 1).Value = dt.Columns(i).ColumnName
            Next

            ' Data rows
            For i As Integer = 0 To dt.Rows.Count - 1
                For j As Integer = 0 To dt.Columns.Count - 1
                    worksheet.Cells(i + 2, j + 1).Value = dt.Rows(i)(j).ToString()
                Next
            Next

            ' Save the file
            workbook.SaveAs(filePath)
            workbook.Close()
            excelApp.Quit()
            MessageBox.Show("Exported to Excel: " & filePath)

        Catch ex As Exception
            MessageBox.Show("Error exporting to Excel: " & ex.Message)
        End Try
    End Sub

    ' === Export to PDF ===
    Public Sub ExportToPDF()
        Try
            Dim conn As New MySqlConnection(ConnectionString)
            conn.Open()

            Dim cmd As New MySqlCommand("SELECT * FROM Users", conn)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New System.Data.DataTable()

            adapter.Fill(dt)
            conn.Close()

            ' Ask for save location
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "PDF Files (*.pdf)|*.pdf"
            saveDialog.Title = "Save PDF File"
            If saveDialog.ShowDialog() <> DialogResult.OK Then Exit Sub
            Dim filePath As String = saveDialog.FileName

            ' Create PDF Document
            Dim pdfDoc As New iTextSharp.text.Document()
            PdfWriter.GetInstance(pdfDoc, New FileStream(filePath, FileMode.Create))
            pdfDoc.Open()

            Dim table As New PdfPTable(dt.Columns.Count)

            ' Add column headers
            For Each column As DataColumn In dt.Columns
                Dim headerCell As New PdfPCell(New Phrase(column.ColumnName))
                headerCell.BackgroundColor = BaseColor.LIGHT_GRAY
                table.AddCell(headerCell)
            Next

            ' Add data rows
            For Each row As DataRow In dt.Rows
                For Each cell As Object In row.ItemArray
                    table.AddCell(cell.ToString())
                Next
            Next

            pdfDoc.Add(table)
            pdfDoc.Close()
            MessageBox.Show("Exported to PDF: " & filePath)

        Catch ex As Exception
            MessageBox.Show("Error exporting to PDF: " & ex.Message)
        End Try
    End Sub

    ' === Export to Word ===
    Public Sub ExportToWord()
        Try
            Dim conn As New MySqlConnection(ConnectionString)
            conn.Open()

            Dim cmd As New MySqlCommand("SELECT * FROM Users", conn)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New System.Data.DataTable()
            adapter.Fill(dt)
            conn.Close()

            ' Ask for save location
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "Word Files (*.docx)|*.docx"
            saveDialog.Title = "Save Word File"
            If saveDialog.ShowDialog() <> DialogResult.OK Then Exit Sub
            Dim filePath As String = saveDialog.FileName

            ' Create Word Document
            Dim wordApp As New Microsoft.Office.Interop.Word.Application()
            Dim doc As Microsoft.Office.Interop.Word.Document = wordApp.Documents.Add()

            ' Create Table
            Dim table As Microsoft.Office.Interop.Word.Table = doc.Tables.Add(doc.Range(), dt.Rows.Count + 1, dt.Columns.Count)
            table.Borders.Enable = 1

            ' Add headers
            For i As Integer = 0 To dt.Columns.Count - 1
                table.Cell(1, i + 1).Range.Text = dt.Columns(i).ColumnName
            Next

            ' Add data rows
            For i As Integer = 0 To dt.Rows.Count - 1
                For j As Integer = 0 To dt.Columns.Count - 1
                    table.Cell(i + 2, j + 1).Range.Text = dt.Rows(i)(j).ToString()
                Next
            Next

            ' Save and Close Word Document
            doc.SaveAs2(filePath)
            doc.Close()
            wordApp.Quit()
            MessageBox.Show("Exported to Word: " & filePath)

        Catch ex As Exception
            MessageBox.Show("Error exporting to Word: " & ex.Message)
        End Try
    End Sub
End Class
