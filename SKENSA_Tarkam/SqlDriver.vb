Imports System.Data.SqlClient
Module SqlDriver
    Public Constr = "Data Source=DESKTOP-H7C241G\SQLEXPRESS;Initial Catalog=SKENSA;User ID=sa;Password=123"

    Public UserName, Role As String


    Public Function isUserExist(UserId As String, Password As String)
        Dim Sql = "Select UserId,Role from [dbo].[User] where UserId='" + UserId + "' and Password='" + Password + "'"

        ''Dim Sql = "select [dbo].[User].UserId,[dbo].[User].Role,Player.name from [dbo].[User] inner join [dbo].[Player] on [dbo].[User].UserId = Player.UserId where [dbo].[User].UserId='" + UserId + "'"
        Try
            Using Conn As New SqlConnection(Constr)
                Using Cmd As New SqlCommand(Sql)
                    Dim Dt As New DataTable

                    Cmd.Connection = Conn
                    Conn.Open()
                    Dim Sda As New SqlDataAdapter
                    Sda.SelectCommand = Cmd
                    Sda.Fill(Dt)
                    ''Dim Sdr As SqlDataReader = Cmd.ExecuteReader


                    If Dt.Rows.Count > 0 Then
                        Role = Dt.Rows.Item(0).Item(1)
                        UserName = Dt.Rows.Item(0).Item(0)
                        Return True
                    Else
                        Return False
                    End If


                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        End Try
    End Function

    Public Sub InsertData(name As String, address As String)

        Try
            Using Conn As New SqlConnection(Constr)
                Using Cmd As New SqlCommand("Insert into Team values('" + name + "','" + address + "')")

                    Try
                        Cmd.Connection = Conn
                        Conn.Open()
                        Cmd.ExecuteNonQuery()

                        MessageBox.Show("Data berhasil disimpan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)


                    Catch ex As Exception
                        MessageBox.Show(ex.Message.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End Try

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try
    End Sub

    Public Sub UpdateData(id As String, name As String, address As String)
        Try
            Using Conn As New SqlConnection(Constr)
                Using Cmd As New SqlCommand("Update Team set Name='" + name + "',Adress='" + address + "' where TeamId='" + id + "'")

                    Try
                        Cmd.Connection = Conn
                        Conn.Open()
                        Cmd.ExecuteNonQuery()

                        MessageBox.Show("Data berhasil diubah", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)


                    Catch ex As Exception
                        MessageBox.Show(ex.Message.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End Try

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try
    End Sub

    Public Sub DeleteTeam(id As String)
        Try
            Using Conn As New SqlConnection(Constr)
                Using Cmd As New SqlCommand("Delete from Team where TeamId='" + id + "'")

                    Try
                        Cmd.Connection = Conn
                        Conn.Open()
                        Cmd.ExecuteNonQuery()

                        MessageBox.Show("Data berhasil dihapus", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)


                    Catch ex As Exception
                        MessageBox.Show(ex.Message.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End Try

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try
    End Sub

    Public Sub InsertPlayerData(name As String, userid As String, password As String, city As String, birthdate As String, height As String, weight As String, position As String, teamid As String)

    End Sub

    Public Sub InsertStadion(name As String, address As String)

        Using Conn As New SqlConnection(Constr)
            Using Cmd As New SqlCommand("Insert into Stadion values('" + name + "','" + address + "')")
                Cmd.Connection = Conn
                Conn.Open()
                Cmd.ExecuteNonQuery()
                MsgBox("data berhasil ditambahkan")
            End Using
        End Using
    End Sub
    Public Sub DeleteStadion(id As String)

        Using Conn As New SqlConnection(Constr)
            Using Cmd As New SqlCommand("delete from Stadion where StadionId='" + id + "'")
                Cmd.Connection = Conn
                Conn.Open()
                Cmd.ExecuteNonQuery()
                MsgBox("Data berhasil dihapus")

            End Using
        End Using
    End Sub

    Public Sub UpdateStadion(id As String, name As String, address As String)
        Try
            Using Conn As New SqlConnection(Constr)
                Using Cmd As New SqlCommand("Update Stadion set Name='" + name + "',Address='" + address + "' where StadionId='" + id + "'")

                    Try
                        Cmd.Connection = Conn
                        Conn.Open()
                        Cmd.ExecuteNonQuery()

                        MessageBox.Show("Data berhasil diubah", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)


                    Catch ex As Exception
                        MessageBox.Show(ex.Message.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End Try

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try
    End Sub

End Module