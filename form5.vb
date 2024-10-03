Imports MySql.Data.MySqlClient
Public Class LoanListForm
    Private connString As String = "server=localhost;user id=root;password=;database=library"
    Private conn As MySqlConnection = New MySqlConnection(connString)

    Private Sub LoanListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            conn.Open()
            Dim query As String = "SELECT borrow.borrow_id, books.title, members.name, borrow.borrow_date, borrow.return_date " &
                                  "FROM borrow " &
                                  "JOIN books ON borrow.book_id = books.book_id " &
                                  "JOIN members ON borrow.member_id = members.member_id;"
            Dim cmd As MySqlCommand = New MySqlCommand(query, conn)
            Dim adapter As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim table As DataTable = New DataTable()
            adapter.Fill(table)
            DataGridViewBorrows.DataSource = table
        Catch ex As MySqlException
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles BtnBack.Click
        Me.Close()
        Form1.Show()
    End Sub
End Class
