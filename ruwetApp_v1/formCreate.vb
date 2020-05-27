Imports System.IO
Imports System.Net

Public Class formCreate
    Dim request As HttpWebRequest
    Dim response As HttpWebResponse = Nothing
    Dim reader As StreamReader
    Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using sendto As New Net.WebClient
            Dim param As New Specialized.NameValueCollection
            param.Add("nama", TextBox1.Text)
            param.Add("deskripsi", TextBox2.Text)
            Dim response_bytes = sendto.UploadValues("http://localhost/mvcSimpan/", "POST", param)
        End Using
        Me.Close()
    End Sub
    Sub formCreate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Focus()
    End Sub
    Sub formCreate_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        formRead.refresh1()
    End Sub
End Class