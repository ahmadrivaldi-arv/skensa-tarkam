
Imports System.Data.SqlClient
Public Class frm_managae_team
    Dim id As String

    Private Sub TampilkanData()
        Using conn As New SqlConnection(Constr)
            Using Cmd As New SqlCommand("Select * from Team")
                Dim Da As New SqlDataAdapter
                Dim Dt As New DataTable

                Cmd.Connection = conn
                Da.SelectCommand = Cmd

                Da.Fill(Dt)
                DataGridView1.DataSource = Dt
            End Using
        End Using
    End Sub
    Private Sub frm_managae_team_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TampilkanData()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex = -1 Then
        Else
            Dim selectedRow = DataGridView1.Rows(e.RowIndex)

            TextBox1.Text = selectedRow.Cells(1).Value.ToString
            'txt.Text = selectedRow.Cells(3).Value.ToString
            TextBox2.Text = selectedRow.Cells(2).Value.ToString
            id = selectedRow.Cells(0).Value.ToString

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("Harap isi semua form", "FORM KOSONG", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            UpdateData(id, TextBox1.Text, TextBox2.Text)
            TampilkanData()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False

        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("Harap isi semua form", "FORM KOSONG", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            InsertData(TextBox1.Text, TextBox2.Text)
            TampilkanData()
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then

            MessageBox.Show("Harap isi semua form", "FORM KOSONG", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If MessageBox.Show("Konfirmasi untuk hapus", "KONFIRMASI", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                DeleteTeam(id)
                TampilkanData()
            End If

        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Try
            Using Conn As New SqlConnection(Constr)
                Using Cmd As New SqlCommand("select * from Team where Name like '%" + TextBox3.Text + "%'")
                    Dim da As New SqlDataAdapter
                    Dim dt As New DataTable

                    Try
                        Cmd.Connection = Conn
                        Conn.Open()
                        da.SelectCommand = Cmd
                        da.Fill(dt)

                        DataGridView1.DataSource = dt
                        Conn.Close()


                    Catch ex As Exception
                        MessageBox.Show(ex.Message.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End Try

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try
    End Sub
End Class