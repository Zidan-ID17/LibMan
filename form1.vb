Imports MySql.Data.MySqlClient

Public Class Form1
    Dim connStr As String = "server=localhost;user id=root;password=;database=library"
    Dim conn As MySqlConnection = New MySqlConnection(connStr)

    Private Sub BtnAddBook_Click(sender As Object, e As EventArgs) Handles BtnAddBook.Click
        Dim form As New AddBookForm()
        form.ShowDialog()
    End Sub

    Private Sub BtnAddMember_Click(sender As Object, e As EventArgs) Handles BtnAddMember.Click
        Dim form As New AddMemberForm()
        form.ShowDialog()
    End Sub

    Private Sub BtnBorrowBook_Click(sender As Object, e As EventArgs) Handles BtnBorrowBook.Click
        Dim form As New BorrowBookForm()
        form.ShowDialog()
    End Sub

    Private Sub BtnBorrowList_Click(sender As Object, e As EventArgs) Handles BtnBorrowList.Click
        Dim form As New LoanListForm()
        form.ShowDialog()
    End Sub
End Class
