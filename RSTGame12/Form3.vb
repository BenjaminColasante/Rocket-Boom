Imports System.Text.RegularExpressions
Imports System.Text
Imports System.IO
Public Class Form3

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Class Player
        Public Property Name As String
        Public Property Score As Integer
    End Class

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim FileReader As String
        Dim FilePath As String = IO.Path.Combine(Application.StartupPath, "leaderboard.txt")

        If IO.File.Exists(FilePath) Then
            FileReader = My.Computer.FileSystem.ReadAllText(FilePath)
            RichTextBox2.Text = FileReader
        End If

        Dim menuMusicPath As String = Path.Combine(Path.GetTempPath(), "MenuMusic.mp3")
        If Not IO.File.Exists(menuMusicPath) Then
            File.WriteAllBytes(menuMusicPath, My.Resources.MenuMusic)
        End If
        SharedMusicPlayer.PlayMusic(menuMusicPath)


        Dim inputText As String = RichTextBox2.Text

        Dim lines() As String = inputText.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

        Dim players As New List(Of Player)
        Dim currentName As String = ""
        Dim currentScore As Integer = 0

        For i As Integer = 0 To lines.Length - 1
            Dim line As String = lines(i)
            Dim nameMatch = Regex.Match(line, "Name:\s+(.*)")
            Dim scoreMatch = Regex.Match(line, "Score:\s+(\d+)")

            If nameMatch.Success Then
                currentName = nameMatch.Groups(1).Value
            ElseIf scoreMatch.Success Then
                currentScore = Integer.Parse(scoreMatch.Groups(1).Value)


                players.Add(New Player With {.Name = currentName, .Score = currentScore})

                If i + 1 < lines.Length Then
                    currentName = Regex.Match(lines(i + 1), "Name:\s+(.*)").Groups(1).Value
                End If
            End If
        Next

        players = players.OrderByDescending(Function(p) p.Score).ToList()

        Dim resultText As New StringBuilder()

        For Each player As Player In players
            resultText.AppendLine("Name: " & player.Name)
            resultText.AppendLine("Score: " & player.Score.ToString())
            resultText.AppendLine("----------------------------")
        Next

        RichTextBox2.Text = resultText.ToString()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.Visible = True
        Me.Close()
    End Sub
End Class