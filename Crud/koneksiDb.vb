Imports System.Data.OleDb
Module koneksiDb
    Public constr As String = "provider = Microsoft.Jet.OLEDB.4.0;Data Source=E:\project\Tugas\Crud\Crud\bin\data.mdb"
    Public conn As New OleDbConnection(constr)

    Public Sub connection()
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub
End Module
