Imports AxWMPLib
Imports System.IO
Imports WMPLib

Public Class Form2
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Dim videoPath As String = "Lose.mp4"
        Dim videoPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Lose.mp4")
        If File.Exists(videoPath) Then
            AxWindowsMediaPlayer1.URL = videoPath
            AxWindowsMediaPlayer1.uiMode = "none"
            AxWindowsMediaPlayer1.Dock = DockStyle.Fill
            AxWindowsMediaPlayer1.Refresh()
            AxWindowsMediaPlayer1.Ctlcontrols.play()
        Else
            MsgBox("Video erreur")
            MenuJeu.Show()
            Me.Close()
        End If

        AddHandler AxWindowsMediaPlayer1.PlayStateChange, AddressOf AxWindowsMediaPlayer1_PlayStateChange
    End Sub

    Private Sub AxWindowsMediaPlayer1_PlayStateChange(sender As Object, e As _WMPOCXEvents_PlayStateChangeEvent)
        If e.newState = WMPPlayState.wmppsMediaEnded Then
            Dim continuer As DialogResult = MessageBox.Show("Continuer?", "Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If continuer = DialogResult.Yes Then
                Form1.Show()
            Else
                MenuJeu.Show()
            End If
            Me.Close()
        End If
    End Sub

    Private Sub AxWindowsMediaPlayer1_Enter(sender As Object, e As EventArgs) Handles AxWindowsMediaPlayer1.Enter

    End Sub
End Class