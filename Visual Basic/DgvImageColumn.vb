'Change dgv properties to allow Image resizing

Private Sub FormSelectContainer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Try
        dtLeeggoed = dblg.GetLeeggoed()
        dtLeeggoed.Columns.Add("Img", GetType(Bitmap))

        For i As Integer = 0 To dtLeeggoed.Rows.Count - 1
            Dim img As Image = GetImg(dtLeeggoed(i)("lgcArtikelPicture"))
            img = New Bitmap(img, New Size(60, 60))

            dtLeeggoed.Rows(i)("Img") = img
        Next

        Me.dgvContainers.DataSource = dtLeeggoed
    Catch ex As Exception
        MessageBox.Show($"{ex.Message}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub



Public Function GetImg(ByVal imgName As String) As Image
    Dim img As String = $"img\{imgName}.bmp"
    Dim imgPath As String = Application.StartupPath & "\" & img

    Dim imgFile As Image = Image.FromFile(imgPath)

    Return imgFile
    End Function