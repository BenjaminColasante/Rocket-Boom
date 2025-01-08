Imports WMPLib
Imports System.IO
Public Class Form1
    Dim Player As WindowsMediaPlayer = New WindowsMediaPlayer()
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Form2.Visible = True
        Me.Visible = False
        My.Settings.Board = 0
        If Player IsNot Nothing Then
            Player.controls.stop()
            Player.URL = Nothing
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button1.BackColor = Color.Black


        Dim tempPath As String = Path.Combine(Path.GetTempPath(), "MenuMusic.mp3")
            File.WriteAllBytes(tempPath, My.Resources.MenuMusic)

        Player.URL = tempPath
        Player.controls.play()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MessageBox.Show("Instructions:

- Avoid obstacles flying towards you by moving up and down
- You have 3 lives, after which you will be eliminated
- Your score will be calculated and displayed on the leaderboard once the game has ended")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form3.Visible = True
        Me.Visible = False
        If Player IsNot Nothing Then
            Player.controls.stop()
            Player.URL = Nothing
        End If
    End Sub
End Class

