Public Class frm_admin
    Private Sub frm_admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '= "Login as: " + Name
        loginAs.Text = "Welcome: " + UserName
        Me.MaximizeBox = False
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Confirm = MessageBox.Show("Apakah anda yakin ingin keluar?", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Confirm = DialogResult.Yes Then
            frm_login.Show()
            Me.Close()
        End If
    End Sub

    Private Sub frm_admin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        frm_login.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frm_manage_player.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frm_managae_team.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frm_manage_manager.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        frm_manage_referee.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        frm_manage_match.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        frm_manage_stadion.Show()
    End Sub
End Class