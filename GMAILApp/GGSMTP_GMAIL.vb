Imports System.Net.Mail
Public Class GGSMTP_GMAIL
    Implements IDisposable
    Dim Mail As MailMessage
    Dim SMTP As SmtpClient
    Dim Temp_GmailAccount As String
    Dim Temp_GmailPassword As String
    Dim Temp_SMTPSERVER As String
    Dim Temp_ServerPort As Int32
    Dim Temp_ErrorText As String = ""
    Dim Temp_EnableSSl As Boolean = True
    Public ReadOnly Property ErrorText() As String
        Get
            Return Temp_ErrorText
        End Get
    End Property
    Public Property EnableSSL() As Boolean
        Get
            Return Temp_EnableSSl
        End Get
        Set(ByVal value As Boolean)
            Temp_EnableSSl = value
        End Set
    End Property
    Public Property GmailAccount() As String
        Get
            Return Temp_GmailAccount
        End Get
        Set(ByVal value As String)
            Temp_GmailAccount = value
        End Set
    End Property
    Public Property GmailPassword() As String
        Get
            Return Temp_GmailPassword
        End Get
        Set(ByVal value As String)
            Temp_GmailPassword = value
        End Set
    End Property
    Public Property SMTPSERVER() As String
        Get
            Return Temp_SMTPSERVER
        End Get
        Set(ByVal value As String)
            Temp_SMTPSERVER = value
        End Set
    End Property
    Public Property ServerPort() As Int32
        Get
            Return Temp_ServerPort
        End Get
        Set(ByVal value As Int32)
            Temp_ServerPort = value
        End Set
    End Property
    Public Sub New(ByVal GmailAccount As String, ByVal GmailPassword As String, Optional ByVal SMTPSERVER As String = "smtp.gmail.com", Optional ByVal ServerPort As Int32 = 587, Optional ByVal EnableSSl As Boolean = True)
        Temp_GmailAccount = GmailAccount
        Temp_GmailPassword = GmailPassword
        Temp_SMTPSERVER = SMTPSERVER
        Temp_ServerPort = ServerPort
        Temp_EnableSSl = EnableSSl
    End Sub
    Public Function SendMail(ByVal ToAddressies As String(), ByVal Subject As String, ByVal BodyText As String, Optional ByVal AttachedFiles As String() = Nothing) As Boolean
        Temp_ErrorText = ""
        Mail = New MailMessage
        SMTP = New SmtpClient(Temp_SMTPSERVER)
        Mail.Subject = Subject
        Mail.From = New MailAddress(Temp_GmailAccount)
        SMTP.Credentials = New System.Net.NetworkCredential(Temp_GmailAccount, Temp_GmailPassword) '<-- Password Here
        Mail.To.Clear()
        For i As Int16 = 0 To ToAddressies.Length - 1
            Mail.To.Add(ToAddressies(i))
        Next i
        Mail.Body = BodyText
        Mail.Attachments.Clear()

        If AttachedFiles IsNot Nothing Then
            For i As Int16 = 0 To AttachedFiles.Length - 1
                Mail.Attachments.Add(New Attachment(AttachedFiles(i)))
            Next
        End If

        SMTP.EnableSsl = Temp_EnableSSl
        SMTP.Port = Temp_ServerPort

        Try
            SMTP.Send(Mail)
            Return True
        Catch ex As Exception
            Me.Temp_ErrorText = ex.Message.ToString
            Return False
        End Try

    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
                If Mail IsNot Nothing Then Mail.Dispose()
                If SMTP IsNot Nothing Then SMTP.Dispose()
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class
