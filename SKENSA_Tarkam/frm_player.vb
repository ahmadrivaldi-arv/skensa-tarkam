Public Class frm_player
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Confirm = MessageBox.Show("Apakah anda yakin ingin keluar?", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Confirm = DialogResult.Yes Then
            frm_login.Show()
            Me.Close()
        End If

    End Sub

    Private Sub frm_player_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        frm_login.Show()

    End Sub

    Private Sub frm_player_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loginAs.Text = "Welcome: " + UserName
    End Sub
End Class