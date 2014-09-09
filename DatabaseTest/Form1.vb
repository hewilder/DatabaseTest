
Imports MySql.Data
Imports MySql.Data.MySqlClient


Public Class Form1

    Dim connectionString As String = "Server=127.0.0.1; Database=calendar; Uid=root;Pwd=teamsoftware"
    Dim connection As New MySqlConnection(connectionString)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim connectionString As String = "Server=127.0.0.1; Database=calendar; Uid=root;Pwd=teamsoftware"
        Dim connection As New MySqlConnection(connectionString)
        Dim da As New MySqlDataAdapter
        Dim dt As DataSet = New DataSet
        Try
            connection.Open()
            TextBox1.Text = connection.ServerVersion
            Dim sqlComm As New MySqlCommand

            sqlComm.CommandText = "SELECT * FROM months WHERE name = '" + ComboBox1.Text + "';"
            'sqlComm.CommandText = "SELECT * FROM months;"
            'da = New MySqlDataAdapter(, connection)
            sqlComm.Connection = connection
            da.SelectCommand = sqlComm
            da.Fill(dt, "months")
            connection.Close()
        Catch ex As Exception
            If (connection.State = Data.ConnectionState.Open) Then
                connection.Close()
            End If


        End Try

        Dim row As DataRow
        For Each row In dt.Tables(0).Rows
            Dim name As String = row("name").ToString()
            TextBox1.Text = row("name").ToString() + row("numDays").ToString()
        Next

        Dim pictureboxes(7) As PictureBox

        For counter As Integer = 0 To 6
            pictureboxes(counter) = New PictureBox
            pictureboxes(counter).BorderStyle = BorderStyle.FixedSingle
            pictureboxes(counter).BackColor = Color.Coral
            pictureboxes(counter).Size = New Size(121, 65)
            pictureboxes(counter).Location = New Point(0 + 131 * counter, 0 + 75 * counter)
            pictureboxes(counter).Name = "pictureboxes" + counter.ToString()
            pictureboxes(counter).Tag = "calBox"
            Me.Controls.Add(pictureboxes(counter))
        Next

        Dim toRemove(7) As Control
        For Each ctl As Control In Me.Controls
            If ctl.Tag <> Nothing Then

                If ctl.Tag.ToString() = "calBox" Then
                    ctl.BackColor = Color.BlueViolet
                    If ctl.Name = "pictureboxes2" Then
                        toRemove(0) = ctl
                    End If

                    If ctl.Name = "pictureboxes3" Then
                        ctl.Hide()
                    End If
                End If
            End If
        Next

        Me.Controls.Remove(toRemove(0))

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = "Hello World"
        Dim connectionString As String = "Server=127.0.0.1; Database=calendar; Uid=root;Pwd=teamsoftware"
        Dim connection As New MySqlConnection(connectionString)
        Dim da As New MySqlDataAdapter
        Dim dt As DataSet = New DataSet
        Try
            connection.Open()
            TextBox1.Text = connection.ServerVersion
            Dim sqlComm As New MySqlCommand

            'sqlComm.CommandText = "SELECT * FROM months WHERE Name = " + ComboBox1.Text + ";"
            sqlComm.CommandText = "SELECT * FROM months;"
            'da = New MySqlDataAdapter(, connection)
            sqlComm.Connection = connection
            da.SelectCommand = sqlComm
            da.Fill(dt, "months")
            connection.Close()
        Catch ex As Exception
            If (connection.State = Data.ConnectionState.Open) Then
                connection.Close()
            End If


        End Try

        Dim row As DataRow
        For Each row In dt.Tables(0).Rows
            Dim name As String = row("Name").ToString()
            TextBox1.Text = TextBox1.Text + " " + row("Name").ToString()
        Next

    End Sub
End Class
