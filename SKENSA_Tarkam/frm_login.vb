Public Class frm_login

    Private Sub FormValidation()
        If TextBox1.Text.StartsWith("''") Then
            MessageBox.Show("error", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("Harap diisi semua field", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If isUserExist(TextBox1.Text, TextBox2.Text) Then

                If Role = "Admin" Then
                    frm_admin.Show()
                    Me.Hide()
                ElseIf Role = "Player" Then
                    Dim fp = New frm_player
                    fp.Show()
                    Me.Hide()

                ElseIf Role = "Manager" Then
                    frm_manager.Show()
                    Me.Hide()
                ElseIf Role = "Referee" Then
                    frm_referee.Show()
                    Me.Hide()
                End If



            Else
                MessageBox.Show("USERID atau PASSWORD salah", "LOGIN FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
        End If


    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            Button1_Click(Me, EventArgs.Empty)
        End If
    End Sub
End Class
