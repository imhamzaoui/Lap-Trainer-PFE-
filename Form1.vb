Imports AForge.Video 'AForge
Imports AForge.Video.DirectShow
Imports AForge.Video.FFMPEG
'
Imports System
'


Imports System.IO.Ports
Imports System.ComponentModel
Imports System.Threading

'
Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient

Public Class Form1

#Region "Cam"
    Dim CAMARA As VideoCaptureDevice
    Dim BMP As Bitmap
    Dim ESCRITOR As New VideoFileWriter()

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs)


        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom


    End Sub

    Private Sub Capture(sender As Object, eventArgs As NewFrameEventArgs)
        If ButtonVIDEO.BackColor = Color.Black Then
            BMP = DirectCast(eventArgs.Frame.Clone(), Bitmap)
            PictureBox1.Image = DirectCast(eventArgs.Frame.Clone(), Bitmap)
        Else
            Try
                BMP = DirectCast(eventArgs.Frame.Clone(), Bitmap)
                PictureBox1.Image = DirectCast(eventArgs.Frame.Clone(), Bitmap)
                ESCRITOR.WriteVideoFrame(BMP)
            Catch ex As Exception
            End Try
        End If
    End Sub





    Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs)
        Try
            CAMARA.Stop()
            ESCRITOR.Close()
        Catch ex As Exception
        End Try
    End Sub

 

    Private Sub Form1_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    Private Sub Form1_Load_1(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PortComboBox.Items.Clear()
        myPort = IO.Ports.SerialPort.GetPortNames()

        PortComboBox.Items.AddRange(myPort)
        BaudComboBox.Items.Add(9600)
        BaudComboBox.Items.Add(19200)
        BaudComboBox.Items.Add(38400)
        BaudComboBox.Items.Add(57600)
        BaudComboBox.Items.Add(115200)
        ConnectButton.Enabled = True
        DisconnectButton.Enabled = False
        Score = 20
        lbl_sco.Text = "Score : " & Score

        'Lan'
        If My.Settings.Lang = "en" Then

            GroupBox1.Text = "Webcam"
            GroupBox2.Text = "Chronometre"
            Button2.Text = "Start"
            ButtonVIDEO.Text = "Video"

            Label5.Text = "Heurs"

            Button3.Text = "Start"

            Button5.Text = "Restart"
        Else

            GroupBox1.Text = "Camera"
            GroupBox2.Text = "Chronomètre"
            Button2.Text = "Début"
            ButtonVIDEO.Text = "Vidéo"

            Label5.Text = "Heures"

            Button3.Text = "Début"

            Button5.Text = "Redémarrer"


        End If
        Timer5.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim CAMARAS As VideoCaptureDeviceForm = New VideoCaptureDeviceForm() 'DIALOGO CAMARAS DISPONIBLES
        If CAMARAS.ShowDialog() = DialogResult.OK Then
            CAMARA = CAMARAS.VideoDevice 'CAMARA ELEGIDA
            AddHandler CAMARA.NewFrame, New NewFrameEventHandler(AddressOf Capture) ' EJECUTARA CADA VEZ QUE SE GENERE UNA IMAGEN
            CAMARA.Start() 'INICIA LA PRESENTACION DE IMAGENES EN EL PICTUREBOX
        End If
    End Sub

    Private Sub ButtonVIDEO_Click(sender As System.Object, e As System.EventArgs) Handles ButtonVIDEO.Click
        If ButtonVIDEO.BackColor = Color.Black Then 'NO ESTA GRABANDO VIDEO
            SaveFileDialog1.DefaultExt = ".avi" ' GUARDARA COMO ARCHIVO AVI
            If SaveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim ANCHO As Integer = CAMARA.VideoResolution.FrameSize.Width 'DEFINE EL ANCHO DEL FOTOGRAMA
                Dim ALTO As Integer = CAMARA.VideoResolution.FrameSize.Height ' DEFINE EL ALTO DEL FOTOGRAMA
                'CREA EL ARCHIVO PARA LOS DATOS CON LOS PARAMETROS DE GUARDADO
                ESCRITOR.Open(SaveFileDialog1.FileName, ANCHO, ALTO, NumericUpDownFPS.Value, VideoCodec.Default, NumericUpDownBRT.Value * 1000)
                ESCRITOR.WriteVideoFrame(BMP) 'EMPIEZA A GUARDAR DATOS
                ButtonVIDEO.BackColor = Color.Red 'PARA QUE SEPAMOS QUE ESTA GRABANDO
            End If
        Else
            ButtonVIDEO.BackColor = Color.Black ' ESTA GRABANDO
            ESCRITOR.Close() 'DEJA DE GUARDAR DATOS
        End If
    End Sub
#End Region
#Region "Chro"
    Dim S As Integer = 0
    Dim M As Integer = 0
    Dim H As Integer = 0

    Function GetChro() As String
        Dim l As String = ""
        If H < 10 Then
            l += "0"
        End If
        l += H & ":"
        If M < 10 Then
            l += "0"
        End If
        l += M & ":"
        If S < 10 Then
            l += "0"
        End If
        l += "" & S
        Return l
    End Function

    Private Sub T() Handles Timer1.Tick
        If S = 59 Then
            S = 0
            If M = 59 Then
                M = 0
                H += 1
            Else
                M += 1
            End If
        Else
            S += 1
        End If
        Label1.Text = GetChro()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If Button3.Text = "Start" Then
            Timer1.Start()


            Button5.Enabled = True

            Time = TimeOfDay.ToString("h:mm:ss tt")
            Button3.Text = "Stop"
        Else
            Timer1.Stop()
            Button3.Text = "Start"
        End If


       
    End Sub


#End Region
#Region "Arduino"
    Dim myPort As Array
    Dim Distance As Integer
    Delegate Sub SetTextCallBack(ByVal [text] As String)
    Private Sub ConnectButton_Click(sender As System.Object, e As System.EventArgs) Handles ConnectButton.Click
        Try
            SerialPort1.PortName = PortComboBox.Text
            SerialPort1.BaudRate = BaudComboBox.Text
            SerialPort1.Open()
            Timer2.Start()

            lblMessage.Text = PortComboBox.Text & " Connected."
            ConnectButton.Enabled = False
            DisconnectButton.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "")
        End Try



    End Sub

    Private Sub DisconnectButton_Click(sender As System.Object, e As System.EventArgs) Handles DisconnectButton.Click
        SerialPort1.Close()
        lblMessage.Text = SerialPort1.PortName & " Disconnected."
        DisconnectButton.Enabled = False
        ConnectButton.Enabled = True
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Try


            SerialPort1.Write("c")
            System.Threading.Thread.Sleep(250)
            Dim distance As String = SerialPort1.ReadExisting()
            If distance <> "" Then
                Label8.Text = distance
            End If

        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "Frm"
    Public Score As Integer
    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Timer1.Stop()


        Button3.Enabled = True

        Dim result As Integer = MessageBox.Show("Do you Save Your Data to Sql DataBase ", "", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
       
        ElseIf result = DialogResult.No Then
        
        ElseIf result = DialogResult.Yes Then
            Saver()
            Button5.Enabled = False
            Timer1.Stop()
            Label1.Text = "00:00:00"
            S = 0
            M = 0
            H = 0
        End If

       
    End Sub




    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer3.Tick

        '#Motion detected!#
        If Label8.Text.Contains("#Motion detected!#") Then
            PictureBox2.BackColor = Color.Red
            Score -= 1
            Label12.Text = "-> Attention !!!! <-"
            lbl_sco.Text = "Score : " & Score

        ElseIf Label8.Text.Contains("#Motion stopped!#") Then
            Label12.Text = "."
            PictureBox2.BackColor = Color.Green


        ElseIf Label8.Text.Contains("#it's cold#") Then
            pc_cold.Visible = True
            pc_hot.Visible = False
            pc_fine.Visible = False
        ElseIf Label8.Text.Contains("#it's hot#") Then
            pc_hot.Visible = True
            pc_cold.Visible = False
            pc_fine.Visible = False
        ElseIf Label8.Text.Contains("#it's fine#") Then
            pc_fine.Visible = True
            pc_hot.Visible = False
            pc_cold.Visible = False

        End If
    End Sub

    Private Sub Timer4_Tick(sender As System.Object, e As System.EventArgs) Handles Timer4.Tick

        Try

            Dim str As String
            Dim strArr() As String

            str = Label8.Text
            strArr = str.Split("//Temp//")

            '  MsgBox(strArr(4))

            If strArr(4) <> "Temp" Or strArr(4) <> "" Then
                Label16.Text = strArr(4)
                '  Label16.Text = strArr(4)
            End If



        Catch ex As Exception

        End Try

    End Sub
#End Region
#Region "Database"
    Dim SeverString As String = "Server=localhost;User Id=root;Password=;Database=laptrainer" ' Server SQL Info
    Public SQLConnection As MySqlConnection = New MySqlConnection 'New Connection
    '____________________________________________
    Dim regDate As Date = Date.Now() 'Get Date
    Dim strDate As String = regDate.ToString("MM\/dd\/yyyy") ' Date Formule

    Public Time As String
   
    Sub Connect() ' Connect To SQL Database
        SQLConnection.ConnectionString = SeverString
        Try
            If SQLConnection.State = ConnectionState.Closed Then
                SQLConnection.Open()
                Label3.Text = "Yes"
                Label3.ForeColor = Color.Green

            Else
                SQLConnection.Close()
                Label3.Text = "Non"
                Label3.ForeColor = Color.Red

            End If
        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try
    End Sub
    Sub Saver()
        SQLConnection = New MySqlConnection()
        SQLConnection.ConnectionString = SeverString
        SQLConnection.Open()
        Dim iReturn As Boolean
        Using SQLConnection As New MySqlConnection(SeverString)
            Using sqlCommand As New MySqlCommand()
                With sqlCommand
                   


                    .CommandText = "insert into tp (Heure, Date, Durée, Score) values (@Heure,@Date,@Durée,@Score)"
                    .Connection = SQLConnection
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@Heure", Time)
                    .Parameters.AddWithValue("@Date", strDate)
                    .Parameters.AddWithValue("@Durée", Label1.Text)
                    .Parameters.AddWithValue("@Score", Score)
                    MsgBox("Save TO Database , Heure : " & Time & " Date : " & strDate & " Durée : " & Label1.Text & " Score : " & Score, MsgBoxStyle.Information, "Saved")
                End With
                Try
                    SQLConnection.Open()
                    sqlCommand.ExecuteNonQuery()
                    iReturn = True
                Catch ex As MySqlException
                    MsgBox(ex.Message.ToString)
                    iReturn = False
                Finally
                    SQLConnection.Close()
                End Try
            End Using
        End Using


    End Sub

#End Region

    Private Sub Timer5_Tick(sender As System.Object, e As System.EventArgs) Handles Timer5.Tick
        Try
            Connect()
            Timer5.Stop()
        Catch ex As Exception

        End Try
    End Sub
End Class
