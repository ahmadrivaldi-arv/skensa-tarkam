Imports System.Data.SqlClient
Public Class frm_manage_stadion
    Dim Id As String
    Sub tampilkanData()
        Dim Sql = "Select * from stadion"
        Try
            Using Conn As New SqlConnection(Constr)
                Using Cmd As New SqlCommand(Sql)
                    Dim Da As New SqlDataAdapter
                    Dim Dt As New DataTable

                    Cmd.Connection = Conn
                    Conn.Open()
                    Da.SelectCommand = Cmd
                    Da.Fill(Dt)

                    DataGridView1.DataSource = Dt
                End Using
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Private Sub frm_manage_stadion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tampilkanData()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex = -1 Then
        Else
            Dim selected_row = DataGridView1.Rows(e.RowIndex)

            TextBox1.Text = selected_row.Cells(1).Value.ToString
            Id = selected_row.Cells(0).Value.ToString
            TextBox4.Text = selected_row.Cells(2).Value.ToString
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button3.Enabled = False
        Button2.Enabled = True
        Button4.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Silahkan isi semua data")
        Else
            InsertStadion(TextBox1.Text, TextBox4.Text)
            kosongkan()
            tampilkanData()
        End If
    End Sub
    Sub kosongkan()
        TextBox1.Text = ""
        TextBox4.Text = ""
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button3.Enabled = True
        Button2.Enabled = False
        Button4.Enabled = False
        kosongkan()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Id = "" Then
            MsgBox("Silahkan isi semua data")
        Else
            DeleteStadion(Id)
            kosongkan()
            tampilkanData()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        UpdateStadion(Id, TextBox1.Text, TextBox4.Text)
        kosongkan()
        tampilkanData()
    End Sub
End Class