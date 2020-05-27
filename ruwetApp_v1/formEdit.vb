Imports System.IO
Imports System.Net
Public Class formEdit
    Dim request As HttpWebRequest
    Dim response As HttpWebResponse = Nothing
    Dim reader As StreamReader
    Sub formEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Focus()
    End Sub
    Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using sendto As New Net.WebClient
            Dim param As New Specialized.NameValueCollection
            param.Add("id", TextBox1.Text)
            param.Add("nama", TextBox3.Text)
            param.Add("deskripsi", TextBox2.Text)
            Dim response_bytes = sendto.UploadValues("http://localhost/mvcSimpan/", "POST", param)
            'Dim response_body = (New Text.UTF8Encoding).GetString(response_bytes)
        End Using
        Me.Close()
        formRead.refresh1()
    End Sub
End Class