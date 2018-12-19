Imports System.IO
Imports System.Net.Mail

Public Class Form1
    Private DropBox As String = "C:\SPARTA_DropBox"
    Private Bail As Boolean
    Private TimerIsBusy As Boolean

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Directory.Exists(DropBox) Then Directory.CreateDirectory(DropBox)
    End Sub


    Private Function AddressCheck() As String
        Dim ret As String = "mail sent"
        Dim AddressArray() As String = Split(txtTo.Text, ";")
        For Each mailto As String In AddressArray
            If mailto.Length < 7 Then
                Return "Address: " & Chr(34) & mailto & Chr(34) & " is too short"
                Exit For
            End If
            Dim ext As String = LCase(Mid(mailto, mailto.Length - 3, mailto.Length))
            If ext <> ".com" AndAlso ext <> ".net" AndAlso ext <> ".org" AndAlso ext <> ".edu" Then
                ret = "Addresses: " & Chr(34) & mailto & Chr(34) & " is malformed"
                ret &= vbCrLf & "Acceptable extensions are .net/.com/.org/.edu"
                Return ret
            End If
        Next
        Return ret
    End Function

    Private Function BuildAttachmentList() As String()
        If cboAttachments.Items.Count = 0 Then Return Nothing
        Dim AttachmentString As String = vbNullString
        Dim Delim As String = ""
        For Each thisfile As String In cboAttachments.Items
            AttachmentString &= Delim & thisfile
            Delim = ","
        Next
        Return Split(AttachmentString, ",")
    End Function
    Private Sub tmrDropBox_Tick(sender As Object, e As EventArgs) Handles tmrDropBox.Tick
        If TimerIsBusy Then Exit Sub
        TimerIsBusy = True
        'build the string

        For Each Attachment As String In Directory.GetFiles(DropBox)
            cboAttachments.Items.Add(Attachment)
        Next

        'verify complete loading of all found attachments
        If cboAttachments.Items.Count = 0 Then
            TimerIsBusy = False
            Exit Sub
        End If

        'launch mailer
        txtSubject.Text = "SPARTA Drop"
        pboxSend.Enabled = False
        pboxSend.Image = pboxStandby.Image
        Me.WindowState = FormWindowState.Normal

        Dim sendIt As Boolean = True
        For Each thisitem As String In cboAttachments.Items
            If thisitem = "" Then Continue For
            Dim SW As New Stopwatch
            SW.Restart()
            Dim FileSize As Long = 0
            Do
                If Bail Then
                    sendIt = False
                    Exit Do
                End If
                Threading.Thread.Sleep(100)
                Dim inforeader As System.IO.FileInfo = My.Computer.FileSystem.GetFileInfo(thisitem)
                If inforeader.Length = FileSize Then Exit Do
                FileSize = inforeader.Length
                If SW.ElapsedMilliseconds > 30000 Then
                    Dim ThisMsg As String = thisitem & vbCrLf & " has not completed loading in 30 seconds"
                    ThisMsg &= vbCrLf & "No mail has been sent"
                    MsgBox(ThisMsg)
                    sendIt = False
                    Exit Do
                End If
                Application.DoEvents()
            Loop
        Next
        If Not sendIt Then
            TimerIsBusy = False
            Exit Sub
        End If
        cboAttachments.SelectedIndex = 0
        pboxSend.Enabled = True
        pboxSend.Image = pboxSend.InitialImage
    End Sub

    Private Function DeleteThisFile(ByVal Filename As String) As Boolean
        Try
            File.Delete(Filename)
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Bail = True
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
        OpenFileDialog1.Title = "Attach File"
        OpenFileDialog1.Multiselect = True
        OpenFileDialog1.InitialDirectory = "C:\AdExaminer\"
        ' OpenFileDialog1.ShowDialog.filter = "All Files|*.*"
        OpenFileDialog1.ShowDialog()

        cboAttachments.Items.Add(OpenFileDialog1.FileName)
        cboAttachments.SelectedIndex = cboAttachments.Items.Count - 1
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        PictureBox1.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub pboxSend_Click(sender As Object, e As EventArgs)
        Dim hello = 1
    End Sub

    Public Sub AutoSend()
        Dim AttachedFile As String = "C:\AdExaminer\SPARTA_Daily.xlxs"
        If Not File.Exists(AttachedFile) Then Exit Sub
        txtSubject.Text = "SPARTA Daily Report"
        txtTo.Text = LoadRecipientsFromFile()
        If txtTo.Text = vbNullString Then Exit Sub '"Earl.W.Vanderhoff@Verizon.com"
        Dim MailResponse As String = AddressCheck()
        Dim NoReply As String = "DO NOT REPLY TO THIS MESSAGE" & vbCrLf & vbCrLf
        If MailResponse = "mail sent" Then
            txtTo.Text = Replace(txtTo.Text, ",", ";")
            txtTo.Text = Replace(txtTo.Text, " ", "")
            Dim GGmail As New GGSMTP_GMAIL("SPARTAMAILDROP@gmail.com", "SPARTA_MAIL", )
            Dim ToAddressies As String() = Split(txtTo.Text, ";") '{"SPARTAMAILDROP@gmail.com", "earl.w.vanderhoff@verizon.com"}
            Dim attachs() As String = {AttachedFile} 'BuildAttachmentList() '{"C:\VRC\spartalab\Devices\1. VHO4-R.csv", "C:\VRC\spartalab\Devices\2. VHO4-L.csv"}
            Dim subject As String = txtSubject.Text '"My TestSubject"
            Dim body As String = NoReply & txtText.Text '"My text goes here ...."
            Dim result As Boolean = GGmail.SendMail(ToAddressies, subject, body, attachs)
            If result Then
                MsgBox(MailResponse)
            Else : MsgBox(GGmail.ErrorText)
            End If
            GGmail.Dispose()
        End If
        Dim SW As New Stopwatch
        For Each strFile As String In cboAttachments.Items
            If InStr(LCase(strFile), LCase(DropBox)) = 0 Then Continue For
            SW.Reset()
            Do
                DeleteThisFile(strFile)
                Application.DoEvents()
                Threading.Thread.Sleep(100)
                If Not File.Exists(strFile) Then Exit Do
                Threading.Thread.Sleep(500)
                If SW.ElapsedMilliseconds > 30000 Then
                    Dim ThisMsg As String = strFile & vbCrLf & " has not completed sending in 30 seconds"
                    MsgBox(ThisMsg)
                    Exit Do
                End If
                If Bail Then Exit Do
            Loop
        Next
        SW.Stop()
        cboAttachments.Items.Clear()
        cboAttachments.Text = ""
        TimerIsBusy = False
        Me.Cursor = Cursors.Default
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Function LoadRecipientsFromFile() As String
        Try

            Dim ConfigFile As String = "C:\AdExaminer\Config.txt"
            Dim ObjReader As StreamReader = New StreamReader(ConfigFile)
            Do While ObjReader.Peek() >= 0
                Dim ThisLine As String = ObjReader.ReadLine()
                If ThisLine.Length < 3 Then Continue Do
                Dim LineArr() As String = Split(ThisLine, "|")
                If LineArr.Count < 2 Then Continue Do
                Dim ThisParameter As String = LineArr(0)
                Dim ThisValue As String = LineArr(1)
                Select Case ThisParameter
                    Case "RECIPIENTS"
                        Return ThisValue
                End Select
            Loop
            ObjReader.Close()
        Catch ex As Exception
            Return vbNullString
        End Try
        Return vbNullString
    End Function

    Private Sub pboxSend_MouseUp(sender As Object, e As MouseEventArgs) Handles pboxSend.MouseUp
        pboxSend.BorderStyle = BorderStyle.FixedSingle
        Dim MailResponse As String = AddressCheck()
        If txtSubject.Text.Length = 0 Then
            MailResponse = String.Empty
            If MsgBox("Do you wish to send this message without a Subject?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                MailResponse = "mail sent"
            End If
        End If
        Dim NoReply As String = "DO NOT REPLY TO THIS MESSAGE" & vbCrLf & vbCrLf
        If MailResponse = "mail sent" Then
            txtTo.Text = Replace(txtTo.Text, ",", ";")
            txtTo.Text = Replace(txtTo.Text, " ", "")
            Dim GGmail As New GGSMTP_GMAIL("SPARTAMAILDROP@gmail.com", "SPARTA_MAIL", )
            Dim ToAddressies As String() = Split(txtTo.Text, ";") '{"SPARTAMAILDROP@gmail.com", "earl.w.vanderhoff@verizon.com"}
            Dim attachs() As String = BuildAttachmentList() '{"C:\VRC\spartalab\Devices\1. VHO4-R.csv", "C:\VRC\spartalab\Devices\2. VHO4-L.csv"}
            Dim subject As String = txtSubject.Text '"My TestSubject"
            Dim body As String = NoReply & txtText.Text '"My text goes here ...."
            Dim result As Boolean = GGmail.SendMail(ToAddressies, subject, body, attachs)
            If result Then
                MsgBox(MailResponse)
            Else MsgBox(GGmail.ErrorText)
            End If
            GGmail.Dispose()
        End If
        Dim SW As New Stopwatch
        For Each strFile As String In cboAttachments.Items
            If InStr(LCase(strFile), LCase(DropBox)) = 0 Then Continue For
            SW.Reset()
            Do
                DeleteThisFile(strFile)
                Application.DoEvents()
                Threading.Thread.Sleep(100)
                If Not File.Exists(strFile) Then Exit Do
                Threading.Thread.Sleep(500)
                If SW.ElapsedMilliseconds > 30000 Then
                    Dim ThisMsg As String = strFile & vbCrLf & " has not completed sending in 30 seconds"
                    MsgBox(ThisMsg)
                    Exit Do
                End If
                If Bail Then Exit Do
            Loop
        Next
        SW.Stop()
        cboAttachments.Items.Clear()
        cboAttachments.Text = ""
        TimerIsBusy = False
        Me.Cursor = Cursors.Default
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub pboxSend_MouseDown(sender As Object, e As MouseEventArgs) Handles pboxSend.MouseDown
        pboxSend.BorderStyle = BorderStyle.Fixed3D
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
    End Sub


End Class
