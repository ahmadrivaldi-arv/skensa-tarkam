Public Class frm_referee
    Private Sub frm_referee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub frm_referee_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        frm_login.Show()

    End Sub
End Class