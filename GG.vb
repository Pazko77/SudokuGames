Imports AxWMPLib
Imports System.IO
Imports System.Reflection.Emit
Imports WMPLib
Public Class GG
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim videoPath As String = "GG.mp4"
        If File.Exists(videoPath) Then
            AxWindowsMediaPlayer1.URL = videoPath
            AxWindowsMediaPlayer1.uiMode = "none"
            AxWindowsMediaPlayer1.Dock = DockStyle.Fill
            AxWindowsMediaPlayer1.Ctlcontrols.play()
        End If

        AddHandler AxWindowsMediaPlayer1.PlayStateChange, AddressOf AxWindowsMediaPlayer1_PlayStateChange
    End Sub

    Private Sub AxWindowsMediaPlayer1_PlayStateChange(sender As Object, e As _WMPOCXEvents_PlayStateChangeEvent)
        If e.newState = WMPPlayState.wmppsMediaEnded Then
            MessageBox.Show(SudokuGames.Label3.Text & " : " & SudokuGames.Label1.Text)
            Dim continuer As DialogResult = MessageBox.Show("Continuer?", "Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If continuer = DialogResult.Yes Then
                Form1.Show()
            Else
                MenuJeu.Show()
            End If
            Me.Hide()
        End If
    End Sub
End Class