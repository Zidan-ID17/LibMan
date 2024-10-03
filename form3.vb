Imports MySql.Data.MySqlClient

Public Class AddMemberForm
    Dim connStr As String = "server=localhost;user id=root;password=;database=library"
    Dim conn As MySqlConnection = New MySqlConnection(connStr)

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Try
            conn.Open()
            Dim query As String = "INSERT INTO members (name, email, phone) VALUES (@name, @email, @phone)"
            Dim cmd As MySqlCommand = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@name", TxtName.Text)
            cmd.Parameters.AddWithValue("@email", TxtEmail.Text)
            cmd.Parameters.AddWithValue("@phone", TxtPhone.Text)
            cmd.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Member Added Successfully.")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles BtnBack.Click
        Me.Close()
        Form1.Show()
    End Sub
End Class
