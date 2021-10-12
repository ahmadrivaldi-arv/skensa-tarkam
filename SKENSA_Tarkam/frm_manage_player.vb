Imports System.Data.SqlClient
Public Class frm_manage_player
    Private Sub frm_manage_player_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SKENSADataSet.Team' table. You can move, or remove it, as needed.
        Me.TeamTableAdapter.Fill(Me.SKENSADataSet.Team)
        tampilkanData()
    End Sub
    Sub tampilkanData()
        Dim Sql = "Select * from Player"
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
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex = -1 Then
        Else
            Dim selectedRow = DataGridView1.Rows(e.RowIndex)

            txtUserId.Text = selectedRow.Cells(0).Value.ToString
            'txt.Text = selectedRow.Cells(3).Value.ToString
            txtName.Text = selectedRow.Cells(1).Value.ToString
            ComboBox1.Text = selectedRow.Cells(2).Value.ToString
            txtCitizenId.Text = selectedRow.Cells(4).Value.ToString
            txtBirthdate.Text = selectedRow.Cells(5).Value.ToString
            txtHeight.Text = selectedRow.Cells(6).Value.ToString
            txtWeight.Text = selectedRow.Cells(7).Value.ToString
            txtPosition.Text = selectedRow.Cells(8).Value.ToString
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button3.Enabled = False
        Button2.Enabled = True
        Button4.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False

        txtCitizenId.Text = ""
        txtHeight.Text = ""
        txtName.Text = ""
        txtPassword.Text = ""
        txtPosition.Text = ""
        ComboBox1.Text = ""
        txtUserId.Text = ""
        txtWeight.Text = ""


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtCitizenId.Text = "" Or txtHeight.Text = "" Or txtName.Text = "" Or txtPassword.Text = "" Or txtPosition.Text = "" Or ComboBox1.Text = "" Or txtUserId.Text = "" Or txtWeight.Text = "" Then
            MessageBox.Show("Harap isi semua form", "FORM KOSONG", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            InsertPlayerData(txtName.Text, txtUserId.Text, txtPassword.Text, txtCitizenId.Text, txtBirthdate.Text, txtHeight.Text, txtWeight.Text, txtPosition.Text, ComboBox1.Text)
            tampilkanData()

        End If
    End Sub
End Class