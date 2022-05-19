For i As Integer = 0 To Me.dgvPreviewExcel.Rows.Count - 1
    If Me.dgvPreviewExcel.Rows(i).Cells("datumVanMFS").Value = Date.MinValue Then
        Me.dgvPreviewExcel.Rows(i).ReadOnly = True
    End If
Next