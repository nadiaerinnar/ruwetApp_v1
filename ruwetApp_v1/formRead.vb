Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq

Public Class formRead
    Dim request As HttpWebRequest
    Dim response As HttpWebResponse = Nothing
    Dim reader As StreamReader
    Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refresh1()
        DataGridView1.BackgroundColor = System.Drawing.SystemColors.Control
    End Sub
    Sub getUrl(ByVal url As String)
        Try
            request = DirectCast(WebRequest.Create(url), HttpWebRequest)
        Finally
            If Not response Is Nothing Then response.Close()
        End Try
    End Sub
    Public Sub refresh1()
        getUrl("http://localhost/mvcSimpan/")
        getMethod("application/json")
    End Sub
    Sub getMethod(ByVal type As String)
        request.Method = "GET"
        request.ContentType = type
        response = DirectCast(request.GetResponse(), HttpWebResponse)
        reader = New StreamReader(response.GetResponseStream)

        DataGridView1.Rows.Clear()
        Dim fetch As JArray = JArray.Parse(reader.ReadToEnd())
        Dim c As Integer
        Dim max_c As Integer = fetch.Count()

        For c = 0 To (max_c - 1) Step 1
            Dim nx As Integer = DataGridView1.Rows.Add()
            DataGridView1.Rows(nx).Cells(0).Value = fetch(c)("id")
            DataGridView1.Rows(nx).Cells(1).Value = fetch(c)("nama")
            DataGridView1.Rows(nx).Cells(2).Value = fetch(c)("desc")
        Next
    End Sub
    Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        refresh1()
    End Sub

    'button create
    Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        formCreate.ShowDialog()
    End Sub

    'button edit
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dataID As String = DataGridView1.Item("ID", DataGridView1.CurrentRow.Index).Value
        Dim dataNama As String = DataGridView1.Item("Nama", DataGridView1.CurrentRow.Index).Value
        Dim dataDesk As String = DataGridView1.Item("Deskripsi", DataGridView1.CurrentRow.Index).Value
        formEdit.Show()
        formEdit.TextBox1.Text = dataID
        formEdit.TextBox3.Text = dataNama
        formEdit.TextBox2.Text = dataDesk
    End Sub

    'button delete
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Using sendto As New Net.WebClient
            Dim param As New Specialized.NameValueCollection
            Dim dataID As String = DataGridView1.Item("ID", DataGridView1.CurrentRow.Index).Value
            param.Add("id", dataID)
            Dim response_bytes = sendto.UploadValues("http://localhost/mvcSimpan/", "POST", param)
            refresh1()
        End Using
    End Sub
End Class
