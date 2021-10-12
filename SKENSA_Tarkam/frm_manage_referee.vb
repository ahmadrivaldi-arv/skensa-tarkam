Imports System.Data.SqlClient

Public Class frm_manage_referee
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex = -1 Then
        Else
            Dim selected_row = DataGridView1.Rows(e.RowIndex)

            NameTxt.Text = selected_row.Cells(1).Value.ToString
            City.Text = selected_row.Cells(2).Value.ToString
            Birth.Text = selected_row.Cells(3).Value.ToString
            Passwd.Text = selected_row.Cells(5).Value.ToString
            UserId.Text = selected_row.Cells(0).Value.ToString
            Address.Text = selected_row.Cells(4).Value.ToString

        End If
    End Sub
    Sub tampilkanData()
        Dim Sql = "Select [Referee].Userid,[Referee].Name,[Referee].CitizenId,[Referee].BirthData,[Referee].Address,[User].Password from Referee inner join [dbo].[User] on [User].UserId=[Referee].UserId"
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
    Private Sub frm_manage_referee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tampilkanData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Using Conn As New SqlConnection(Constr)
            Using Cmd As New SqlCommand("Select * from [dbo].User where UserID='" + UserId.Text + "'")
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter

                Cmd.Connection = Conn
                Conn.Open()
                da.SelectCommand = Cmd
                da.Fill(dt)

                If dt.Rows.Count > 0 Then
                    MsgBox("asda")
                End If
            End Using
        End Using



        tampilkanData()
    End Sub
End Class