'References that we need
Imports System.Data.SqlClient
Imports System.Data
Imports System.IO.Directory
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Public Class frmReports
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Initialize the objects before use
        Dim dataAdapter As New SqlClient.SqlDataAdapter()
        Dim dataSet As New DataSet
        Dim command As New SqlClient.SqlCommand
        Dim datatableMain As New System.Data.DataTable()
        Dim connection As New SqlClient.SqlConnection

        'Assign the connection string to connection object
        connection.ConnectionString = "data source=mars;" & "Initial Catalog=480-Buddies;user id=480-Buddies;password=schedule;"
        command.Connection = connection
        command.CommandType = CommandType.Text
        ' Use any select command.
        command.CommandText = "Select * from SCHEDULE"
        dataAdapter.SelectCommand = command

        ' User is able to select a folder into which to export excel.
        Dim f As FolderBrowserDialog = New FolderBrowserDialog
        Try
            If f.ShowDialog() = DialogResult.OK Then
                'This section helps if your language is not English.
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
                Dim oExcel As Excel.Application
                Dim oBook As Excel.Workbook
                Dim oSheet As Excel.Worksheet
                oExcel = CreateObject("Excel.Application")
                oBook = oExcel.Workbooks.Add(Type.Missing)
                oSheet = oBook.Worksheets(1)

                Dim dc As System.Data.DataColumn
                Dim dr As System.Data.DataRow
                Dim colIndex As Integer = 0
                Dim rowIndex As Integer = 0

                'Fill data to datatable
                connection.Open()
                dataAdapter.Fill(datatableMain)
                connection.Close()


                'Export the Columns to excel file
                For Each dc In datatableMain.Columns
                    colIndex = colIndex + 1
                    oSheet.Cells(1, colIndex) = dc.ColumnName
                Next

                'Export the rows to excel file
                For Each dr In datatableMain.Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In datatableMain.Columns
                        colIndex = colIndex + 1
                        oSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next

                'Set final path
                Dim fileName As String = "\Schedule" + ".xls"
                Dim finalPath = f.SelectedPath + fileName
                oSheet.Columns.AutoFit()
                'Save file in final path
                oBook.SaveAs(finalPath, XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
                'Release the objects
                ReleaseObject(oSheet)
                oBook.Close(False, Type.Missing, Type.Missing)
                ReleaseObject(oBook)
                oExcel.Quit()
                ReleaseObject(oExcel)
                'Some time Office application does not quit after automation: 
                'so i am calling GC.Collect method.
                GC.Collect()

                MessageBox.Show("Export done successfully!")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub
End Class