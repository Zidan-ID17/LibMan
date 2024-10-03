Imports MySql.Data.MySqlClient

Public Class AddBookForm
    Dim connStr As String = "server=localhost;user id=root;password=;database=library"
    Dim conn As MySqlConnection = New MySqlConnection(connStr)

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Try
            conn.Open()
            Dim query As String = "INSERT INTO books (title, author, publisher, year) VALUES (@title, @author, @publisher, @year)"
            Dim cmd As MySqlCommand = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@title", TxtTitle.Text)
            cmd.Parameters.AddWithValue("@author", TxtAuthor.Text)
            cmd.Parameters.AddWithValue("@publisher", TxtPublisher.Text)
            cmd.Parameters.AddWithValue("@year", TxtYear.Text)
            cmd.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Book added Successfully.")
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
