Public Class lang

    Private Sub lang_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If My.Settings.Lang = "en" Then

            Label1.Text = "Select Language ..."
            Me.Text = "Language"

        Else
            Label1.Text = "Choisir la langue ..."
            Me.Text = "La langue"



        End If
    End Sub

    Private Sub btn_en_Click(sender As System.Object, e As System.EventArgs) Handles btn_en.Click
        My.Settings.Lang = "en"
        My.Settings.Save()

        Form1.Show()
        Me.Hide()

    End Sub

    Private Sub btn_fr_Click(sender As System.Object, e As System.EventArgs) Handles btn_fr.Click
        My.Settings.Lang = "fr"
        My.Settings.Save()
        Form1.Show()
        Me.Hide()

    End Sub
End Class