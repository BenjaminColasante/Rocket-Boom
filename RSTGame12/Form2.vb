Imports WMPLib
Imports System.IO
Imports System.Media
Public Class Form2
    Dim Player As WindowsMediaPlayer = New WindowsMediaPlayer()
    Dim Space As Boolean
    Dim point1 As Boolean
    Dim point2 As Integer
    Dim point3 As Integer
    Dim point4 As Integer
    Dim score As Integer
    Dim time1 As Integer
    Dim place As Boolean
    Dim time2 As Integer
    Dim back As Boolean
    Dim rand As Boolean
    Dim life As Integer
    Dim hit1 As Boolean
    Dim hit2 As Boolean
    Dim hit3 As Boolean
    Dim hit4 As Boolean
    Dim hit5 As Boolean
    Dim hit6 As Boolean
    Dim spawn1 As Boolean
    Dim spawn2 As Boolean
    Dim spawn3 As Boolean
    Dim spawn4 As Boolean
    Dim spawn5 As Boolean
    Dim spawn6 As Boolean
    Dim GameOver As Boolean
    Dim GameOver1 As Boolean
    Dim point5 As Integer




    Private Sub Form2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Space
                Space = True

        End Select
    End Sub

    Private Sub Form2_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.Space
                Space = False
        End Select
    End Sub


    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Space = False
        point1 = False
        PictureBox3.Visible = False
        PictureBox4.Visible = False
        PictureBox5.Visible = False
        PictureBox7.Visible = False
        point2 = 0
        point3 = 0
        point4 = 0
        point5 = 0
        score = 0
        Label1.Text = score
        time1 = 300
        PictureBox7.Visible = False
        place = False
        time2 = 500
        back = True
        rand = True
        life = 3
        hit1 = False
        hit2 = False
        hit3 = False
        hit4 = False
        hit5 = False
        hit6 = False
        PictureBox11.Visible = False
        PictureBox12.Visible = False
        Button1.Visible = False
        Button2.Visible = False
        GameOver = False
        GameOver1 = True
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = False
        PictureBox13.Visible = False

        Dim tempPath As String = Path.Combine(Path.GetTempPath(), "GameBackgroundMusic.mp3")


        If Not IO.File.Exists(tempPath) Then
            File.WriteAllBytes(tempPath, My.Resources.GameBackgroundMusic)
        End If
        SharedMusicPlayer.PlayMusic(tempPath)
    End Sub


    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick



        If GameOver = True And GameOver1 = True Then
            GameOver1 = False

            Dim Name As String = Nothing

            Name = InputBox("What is your name?", "Leaderboard")
            TextBox1.Text = "Name: " + Name
            TextBox2.Text = "Score: " + Label1.Text
            TextBox3.Text = "----------------------------"
            My.Settings.Board = Label1.Text

            Dim info As System.IO.StreamWriter
            info = My.Computer.FileSystem.OpenTextFileWriter("Leaderboard.txt", True)

            info.WriteLine(TextBox1.Text)
            info.WriteLine(TextBox2.Text)
            info.WriteLine(TextBox3.Text)
            info.Close()


        End If

        If hit1 = True Then
            life = life - 1
            hit1 = False
            spawn1 = True
            Dim lifeLostSound As New SoundPlayer(My.Resources.PlayerHit)
            lifeLostSound.Play()
        End If

        If hit2 = True Then
            life = life - 1
            hit2 = False
            spawn2 = True
            Dim lifeLostSound As New SoundPlayer(My.Resources.PlayerHit)
            lifeLostSound.Play()
        End If

        If hit3 = True Then
            life = life - 1
            hit3 = False
            spawn3 = True
            Dim lifeLostSound As New SoundPlayer(My.Resources.PlayerHit)
            lifeLostSound.Play()
        End If

        If hit4 = True Then
            life = life - 1
            hit4 = False
            spawn4 = True
            Dim lifeLostSound As New SoundPlayer(My.Resources.PlayerHit)
            lifeLostSound.Play()
        End If

        If hit5 = True Then
            life = life - 1
            hit5 = False
            spawn5 = True
            Dim lifeLostSound As New SoundPlayer(My.Resources.PlayerHit)
            lifeLostSound.Play()
        End If

        If hit6 = True Then
            life = life - 1
            hit6 = False
            spawn6 = True
            Dim lifeLostSound As New SoundPlayer(My.Resources.PlayerHit)
            lifeLostSound.Play()
        End If

        If life = 3 Then
            PictureBox10.Visible = True
            PictureBox8.Visible = True
            PictureBox9.Visible = True
        End If

        If life = 2 Then
            PictureBox10.Visible = False
            PictureBox8.Visible = True
            PictureBox9.Visible = True
        End If

        If life = 1 Then
            PictureBox10.Visible = False
            PictureBox8.Visible = False
            PictureBox9.Visible = True
        End If

        If life = 0 Then
            PictureBox10.Visible = False
            PictureBox8.Visible = False
            PictureBox9.Visible = False
            PictureBox1.Image = My.Resources.Explosion
            PictureBox2.Visible = False
            PictureBox3.Visible = False
            PictureBox4.Visible = False
            PictureBox5.Visible = False
            PictureBox6.Visible = False
            PictureBox7.Visible = False
            PictureBox12.Visible = True
            score = Label1.Text
            Label1.Visible = False
            PictureBox11.Location = PictureBox1.Location
            PictureBox11.Visible = True
            Button1.Visible = True
            Button2.Visible = True
            GameOver = True

        End If

        If life <> 0 Then
            score = score + 1
            Label1.Text = score

            If Space = True And life <> 0 Then
                If PictureBox1.Top >= 0 Then
                    PictureBox1.Top = PictureBox1.Top - 15
                End If

            End If

            If score >= time1 Then

                Dim rnd As New Random(Date.Now.Millisecond)
                If rand = True Then
                    Select Case rnd.Next(0, 5)
                        Case 0
                            PictureBox6.Top = 475
                            PictureBox7.Top = 483
                            rand = False

                        Case 1
                            PictureBox6.Top = 338
                            PictureBox7.Top = 346
                            rand = False
                        Case 2
                            PictureBox6.Top = 229
                            PictureBox7.Top = 237
                            rand = False

                        Case 3
                            PictureBox6.Top = 131
                            PictureBox7.Top = 139
                            rand = False

                        Case 4
                            PictureBox6.Top = 36
                            PictureBox7.Top = 44
                            rand = False

                    End Select
                End If
                If PictureBox6.Left > 977 And back = True Then
                    PictureBox6.Left = PictureBox6.Left - 3

                End If
                If PictureBox6.Left <= 977 Then
                    PictureBox7.Visible = True
                    back = False
                End If
                If score >= time2 And back = False Then
                    If PictureBox6.Left < 1220 Then
                        PictureBox7.Visible = False
                        PictureBox6.Left = PictureBox6.Left + 3
                        spawn5 = False
                    End If
                    If PictureBox6.Left = 1220 Then
                        back = True
                        time1 = time1 + 1200
                        time2 = time2 + 1200
                        rand = True
                    End If
                End If
            End If







            PictureBox2.Left = PictureBox2.Left - 10


            If PictureBox2.Left <= -500 Then
                PictureBox2.Left = 1100
                point1 = True
                point2 = point2 + 1
                point3 = point3 + 1
                point4 = point4 + 1
                point5 = point5 + 1


                Dim rnd As New Random(Date.Now.Millisecond)
                Select Case rnd.Next(0, 5)
                    Case 0
                        PictureBox2.Top = 171
                        spawn1 = False
                        PictureBox2.Image = My.Resources.Dynamite1
                    Case 1
                        PictureBox2.Top = 33
                        spawn1 = False
                        PictureBox2.Image = My.Resources.Rocket
                    Case 2
                        PictureBox2.Top = 310
                        spawn1 = False
                        PictureBox2.Image = My.Resources.Rocket
                    Case 3
                        PictureBox2.Top = 235
                        spawn1 = False
                        PictureBox2.Image = My.Resources.Rocket
                    Case 3
                        PictureBox2.Top = 90
                        spawn1 = False
                        PictureBox2.Image = My.Resources.Dynamite1
                End Select

            End If

            If PictureBox1.Top <= 420 Then
                PictureBox1.Top = PictureBox1.Top + 5
            End If

            If point1 = True Then
                PictureBox3.Left = PictureBox3.Left - 10
                PictureBox3.Visible = True

                If PictureBox3.Left <= -900 Then
                    PictureBox3.Left = 1300
                    point1 = True


                    Dim rnd As New Random(Date.Now.Millisecond)
                    Select Case rnd.Next(0, 5)
                        Case 0
                            PictureBox3.Top = 200
                            spawn2 = False
                            PictureBox3.Image = My.Resources.Dynamite1
                        Case 1
                            PictureBox3.Top = 40
                            spawn2 = False
                            PictureBox3.Image = My.Resources.Rocket
                        Case 2
                            PictureBox3.Top = 370
                            spawn2 = False
                            PictureBox3.Image = My.Resources.Dynamite1
                        Case 3
                            PictureBox3.Top = 280
                            spawn2 = False
                            PictureBox3.Image = My.Resources.Rocket
                        Case 4
                            PictureBox3.Top = 460
                            spawn2 = False
                            PictureBox3.Image = My.Resources.Rocket
                    End Select
                End If
            End If

            If point2 >= 4 Then
                PictureBox4.Left = PictureBox4.Left - 10
                PictureBox4.Visible = True

                PictureBox13.Left = PictureBox13.Left - 10
                PictureBox13.Visible = True

                If PictureBox4.Left <= -700 Then
                    PictureBox4.Left = 1300


                    Dim rnd As New Random(Date.Now.Millisecond)
                    Select Case rnd.Next(0, 5)
                        Case 0
                            PictureBox4.Top = 435
                            spawn3 = False
                            PictureBox4.Image = My.Resources.Dynamite1
                        Case 1
                            PictureBox4.Top = 287
                            spawn3 = False
                            PictureBox4.Image = My.Resources.Rocket
                        Case 2
                            PictureBox4.Top = 189
                            spawn3 = False
                            PictureBox4.Image = My.Resources.Rocket
                        Case 3
                            PictureBox4.Top = 45
                            spawn3 = False
                            PictureBox4.Image = My.Resources.Dynamite1
                        Case 4
                            PictureBox4.Top = 75
                            spawn3 = False
                            PictureBox4.Image = My.Resources.Rocket
                    End Select
                End If


                If PictureBox13.Left <= -1400 Then
                    PictureBox13.Left = 1800


                    Dim rnd As New Random(Date.Now.Millisecond)
                    Select Case rnd.Next(0, 5)
                        Case 0
                            PictureBox13.Top = 12
                            spawn6 = False
                        Case 1
                            PictureBox13.Top = 96
                            spawn6 = False
                        Case 2
                            PictureBox13.Top = 200
                            spawn6 = False
                        Case 3
                            PictureBox13.Top = 290
                            spawn6 = False
                        Case 4
                            PictureBox13.Top = 382
                            spawn6 = False
                    End Select
                End If



            End If
            If point3 >= 10 Then
                PictureBox2.Left = PictureBox2.Left - 2
                PictureBox3.Left = PictureBox3.Left - 2
                PictureBox4.Left = PictureBox4.Left - 2
                PictureBox5.Left = PictureBox5.Left - 2
                PictureBox13.Left = PictureBox13.Left - 2
            End If

            If point4 >= 5 Then
                PictureBox5.Left = PictureBox5.Left - 10
                PictureBox5.Visible = True
                If PictureBox5.Left <= -1800 Then
                    PictureBox5.Left = 1500


                    Dim rnd As New Random(Date.Now.Millisecond)
                    Select Case rnd.Next(0, 5)
                        Case 0
                            PictureBox5.Top = 334
                            spawn4 = False

                        Case 1
                            PictureBox5.Top = 247
                            spawn4 = False
                        Case 2
                            PictureBox5.Top = 145
                            spawn4 = False
                        Case 3
                            PictureBox5.Top = 59
                            spawn4 = False
                        Case 4
                            PictureBox5.Top = 1
                            spawn4 = False

                    End Select

                    PictureBox2.Left = PictureBox2.Left - 2
                    PictureBox3.Left = PictureBox3.Left - 2
                    PictureBox4.Left = PictureBox4.Left - 2
                    PictureBox5.Left = PictureBox5.Left - 2
                    PictureBox13.Left = PictureBox13.Left - 2
                End If
            End If

            If point5 >= 13 Then
                PictureBox2.Left = PictureBox2.Left - 2
                PictureBox3.Left = PictureBox3.Left - 2
                PictureBox4.Left = PictureBox4.Left - 2
                PictureBox5.Left = PictureBox5.Left - 2
                PictureBox13.Left = PictureBox13.Left - 2
            End If

            If PictureBox1.Bounds.IntersectsWith(PictureBox2.Bounds) And spawn1 = False Then
                hit1 = True
            End If

            If PictureBox3.Bounds.IntersectsWith(PictureBox2.Bounds) Then
                Dim rnd As New Random(Date.Now.Millisecond)
                Select Case rnd.Next(0, 4)
                    Case 0
                        PictureBox3.Top = 200
                        spawn2 = False
                    Case 1
                        PictureBox3.Top = 40
                        spawn2 = False
                    Case 2
                        PictureBox3.Top = 370
                        spawn2 = False
                    Case 3
                        PictureBox3.Top = 280
                        spawn2 = False
                    Case 4
                        PictureBox3.Top = 460
                        spawn2 = False
                End Select
            End If

            If PictureBox1.Bounds.IntersectsWith(PictureBox3.Bounds) And spawn2 = False Then
                hit2 = True
            End If

            If PictureBox1.Bounds.IntersectsWith(PictureBox4.Bounds) And spawn3 = False Then
                hit3 = True
            End If

            If PictureBox1.Bounds.IntersectsWith(PictureBox5.Bounds) And spawn4 = False Then
                hit4 = True
            End If

            If PictureBox1.Bounds.IntersectsWith(PictureBox13.Bounds) And spawn6 = False Then
                hit6 = True
            End If


            If PictureBox1.Bounds.IntersectsWith(PictureBox7.Bounds) And spawn5 = False And PictureBox7.Visible = True Then
                hit5 = True
            End If


            If PictureBox3.Bounds.IntersectsWith(PictureBox4.Bounds) Then
                Dim rnd As New Random(Date.Now.Millisecond)
                Select Case rnd.Next(0, 4)
                    Case 0
                        PictureBox3.Top = 200
                        spawn2 = False
                    Case 1
                        PictureBox3.Top = 40
                        spawn2 = False
                    Case 2
                        PictureBox3.Top = 370
                        spawn2 = False
                    Case 3
                        PictureBox3.Top = 280
                        spawn2 = False
                    Case 4
                        PictureBox3.Top = 25
                        spawn2 = False
                End Select
            End If

            If PictureBox2.Bounds.IntersectsWith(PictureBox4.Bounds) Then
                Dim rnd As New Random(Date.Now.Millisecond)
                Select Case rnd.Next(0, 5)
                    Case 0
                        PictureBox2.Top = 171
                        spawn1 = False
                    Case 1
                        PictureBox2.Top = 33
                        spawn1 = False
                    Case 2
                        PictureBox2.Top = 310
                        spawn1 = False
                    Case 3
                        PictureBox2.Top = 235
                        spawn1 = False
                    Case 3
                        PictureBox2.Top = 90
                        spawn1 = False
                End Select
            End If


            If PictureBox5.Bounds.IntersectsWith(PictureBox2.Bounds) Then
                Dim rnd As New Random(Date.Now.Millisecond)
                Select Case rnd.Next(0, 5)
                    Case 0
                        PictureBox2.Top = 171
                        spawn1 = False
                    Case 1
                        PictureBox2.Top = 33
                        spawn1 = False
                    Case 2
                        PictureBox2.Top = 310
                        spawn1 = False
                    Case 3
                        PictureBox2.Top = 235
                        spawn1 = False
                    Case 3
                        PictureBox2.Top = 90
                        spawn1 = False
                End Select
            End If

            If PictureBox5.Bounds.IntersectsWith(PictureBox3.Bounds) Then
                Dim rnd As New Random(Date.Now.Millisecond)
                Select Case rnd.Next(0, 4)
                    Case 0
                        PictureBox3.Top = 200
                        spawn2 = False
                    Case 1
                        PictureBox3.Top = 40
                        spawn2 = False
                    Case 2
                        PictureBox3.Top = 370
                        spawn2 = False
                    Case 3
                        PictureBox3.Top = 280
                        spawn2 = False
                    Case 4
                        PictureBox3.Top = 25
                        spawn2 = False
                End Select
            End If

            If PictureBox5.Bounds.IntersectsWith(PictureBox4.Bounds) Then
                Dim rnd As New Random(Date.Now.Millisecond)
                Select Case rnd.Next(0, 5)
                    Case 0
                        PictureBox4.Top = 435
                        spawn3 = False
                    Case 1
                        PictureBox4.Top = 287
                        spawn3 = False
                    Case 2
                        PictureBox4.Top = 189
                        spawn3 = False
                    Case 3
                        PictureBox4.Top = 45
                        spawn3 = False
                    Case 4
                        PictureBox4.Top = 75
                        spawn3 = False
                End Select
            End If


            If PictureBox13.Bounds.IntersectsWith(PictureBox4.Bounds) Then
                Dim rnd As New Random(Date.Now.Millisecond)
                Select Case rnd.Next(0, 5)
                    Case 0
                        PictureBox4.Top = 435
                        spawn3 = False
                    Case 1
                        PictureBox4.Top = 287
                        spawn3 = False
                    Case 2
                        PictureBox4.Top = 189
                        spawn3 = False
                    Case 3
                        PictureBox4.Top = 45
                        spawn3 = False
                    Case 4
                        PictureBox4.Top = 75
                        spawn3 = False
                End Select
            End If

            If PictureBox13.Bounds.IntersectsWith(PictureBox3.Bounds) Then
                Dim rnd As New Random(Date.Now.Millisecond)
                Select Case rnd.Next(0, 4)
                    Case 0
                        PictureBox3.Top = 200
                        spawn2 = False
                    Case 1
                        PictureBox3.Top = 40
                        spawn2 = False
                    Case 2
                        PictureBox3.Top = 370
                        spawn2 = False
                    Case 3
                        PictureBox3.Top = 280
                        spawn2 = False
                    Case 4
                        PictureBox3.Top = 25
                        spawn2 = False
                End Select
            End If

            If PictureBox13.Bounds.IntersectsWith(PictureBox2.Bounds) Then
                Dim rnd As New Random(Date.Now.Millisecond)
                Select Case rnd.Next(0, 5)
                    Case 0
                        PictureBox2.Top = 171
                        spawn1 = False
                    Case 1
                        PictureBox2.Top = 33
                        spawn1 = False
                    Case 2
                        PictureBox2.Top = 310
                        spawn1 = False
                    Case 3
                        PictureBox2.Top = 235
                        spawn1 = False
                    Case 3
                        PictureBox2.Top = 90
                        spawn1 = False
                End Select
            End If

            If PictureBox13.Bounds.IntersectsWith(PictureBox5.Bounds) Then
                Dim rnd As New Random(Date.Now.Millisecond)
                Select Case rnd.Next(0, 5)
                    Case 0
                        PictureBox5.Top = 334
                        spawn4 = False

                    Case 1
                        PictureBox5.Top = 247
                        spawn4 = False
                    Case 2
                        PictureBox5.Top = 145
                        spawn4 = False
                    Case 3
                        PictureBox5.Top = 59
                        spawn4 = False
                    Case 4
                        PictureBox5.Top = 1
                        spawn4 = False

                End Select
            End If


        End If
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form3.Visible = True
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.Visible = True
        Me.Close()
    End Sub
End Class

Public Class SharedMusicPlayer
    Private Shared Player As WindowsMediaPlayer = New WindowsMediaPlayer()

    Public Shared Sub PlayMusic(filePath As String)
        If Player IsNot Nothing Then
            Player.URL = filePath
            Player.controls.play()
            Player.settings.setMode("loop", True)
        End If
    End Sub

    Public Shared Sub StopMusic()
        If Player IsNot Nothing Then
            Player.controls.stop()
        End If
    End Sub
End Class