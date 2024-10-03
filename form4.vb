Imports MySql.Data.MySqlClient

Public Class BorrowBookForm
    Dim connStr As String = "server=localhost;user id=root;password=;database=library"
    Dim conn As MySqlConnection = New MySqlConnection(connStr)

    Private Sub BorrowBookForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBooks()
        LoadMembers()
    End Sub

    Private Sub LoadBooks()
        Try
            conn.Open()
            Dim query As String = "SELECT * FROM books"
            Dim cmd As MySqlCommand = New MySqlCommand(query, conn)
            Dim adapter As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim table As DataTable = New DataTable()
            adapter.Fill(table)
            DataGridViewBooks.DataSource = table
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadMembers()
        Try
            conn.Open()
            Dim query As String = "SELECT * FROM members"
            Dim cmd As MySqlCommand = New MySqlCommand(query, conn)
            Dim adapter As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim table As DataTable = New DataTable()
            adapter.Fill(table)
            DataGridViewMembers.DataSource = table
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Try
            conn.Open()
            Dim query As String = "INSERT INTO borrow (book_id, member_id, borrow_date, return_date) VALUES (@book_id, @member_id, @borrow_date, @return_date)"
            Dim cmd As MySqlCommand = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@book_id", TxtBookID.Text)
            cmd.Parameters.AddWithValue("@member_id", TxtMemberID.Text)
            cmd.Parameters.AddWithValue("@borrow_date", DtpBorrowDate.Value.Date)
            cmd.Parameters.AddWithValue("@return_date", DtpReturnDate.Value.Date)
            cmd.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Book Borrowed Successfully.")
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
