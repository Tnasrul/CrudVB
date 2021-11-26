Imports System.Data
Imports System.Data.OleDb
Public Class Form1
    Dim con As OleDbConnection
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
        clear()
    End Sub
    Sub clear()
        TextId.Clear()
        TextName.Clear()
        TextClass.Clear()
        TextAdress.Clear()
        TextContact.Clear()
        lblMessage.Text = ""
        TextId.Focus()
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles ButtonExit.Click
        End
    End Sub
    Public Sub RunQuery(ByVal query As String)
        'con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\BMEO\Documents\Visual Studio 2019\Projects\CRUD-VB-Access\CRUD-VB-Access\bin\Debug\students.accdb")
        'con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Application.StartupPath & \students.accdb")
        con = New OleDbConnection("provider = Microsoft.ACE.OLEDB.12.0;Data Source=E:\project\Tugas\Crud\Crud\bin\Debug\data.accdb")
        Dim cmd As New OleDbCommand(query, con)
        cmd.Parameters.AddWithValue("@name", TextName.Text)
        cmd.Parameters.AddWithValue("@stclass", TextClass.Text)
        cmd.Parameters.AddWithValue("@address", TextAdress.Text)
        cmd.Parameters.AddWithValue("@contact", TextContact.Text)
        cmd.Parameters.AddWithValue("@id", TextId.Text)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles ButtonInsert.Click
        Dim insertQuery As String = "insert into student (s_name,s_class,s_address,s_contact) VALUES(@name,@stclass,@address,@contact)"
        RunQuery(insertQuery)
        lblMessage.Text = "Record inserted successfully"
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles ButtonDelete.Click
        Dim deleteQuery As String = "delete from student where ID=@id"
        RunQuery(deleteQuery)
        lblMessage.Text = "Record Deleted successfully"
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles ButtonUpdate.Click
        Dim updatequery As String = "update student set s_name=@name,s_class=@stclass,s_address=@address,s_contact=@contact where ID=@id"
        RunQuery(updatequery)
        lblMessage.Text = "Record Updated successfully"
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        con = New OleDbConnection("provider = Microsoft.ACE.OLEDB.12.0;Data Source=E:\project\Tugas\Crud\Crud\bin\Debug\data.accdb")
        Dim searchQuery As String = "select * from student where ID=@id"
        Dim cmd As New OleDbCommand(searchQuery, con)
        cmd.Parameters.AddWithValue("@id", TextId.Text)
        Dim da As New OleDbDataAdapter(cmd)
        Dim table As New DataTable
        da.Fill(table)
        If table.Rows.Count > 0 Then
            TextName.Text = table.Rows(0)(1).ToString
            TextClass.Text = table.Rows(0)(2).ToString
            TextAdress.Text = table.Rows(0)(3).ToString
            TextContact.Text = table.Rows(0)(4).ToString
            lblMessage.Text = "Record found"
        Else

            clear()
            lblMessage.Text = "Record not found"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.ShowDialog()
    End Sub
End Class