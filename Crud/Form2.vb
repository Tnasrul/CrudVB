Imports System.Data.OleDb
Public Class Form2
    Dim ds As OleDbDataAdapter
    Dim dset As DataSet
    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles csv.Load
        Call connection()
        Dim crep As New crSudent
        ds = New OleDbDataAdapter("select * from student", conn)
        dset = New DataSet
        ds.Fill(dset, "student")
        crep.SetDataSource(dset)
        csv.ReportSource = crep
        csv.Refresh()
    End Sub
End Class