Public Shared Sub DoubleBuffered(ByVal dgv As DataGridView, ByVal setting As Boolean)
    Dim dgvType As Type = dgv.[GetType]()
    Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
    pi.SetValue(dgv, setting, Nothing)
End Sub