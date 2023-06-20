'STACK TRACE

' System.InvalidOperationException
'   HResult=0x80131509
'   Message=Kan deze bewerking niet uitvoeren omdat het formaat van een automatisch gevulde kolom wordt gewijzigd.
'   Source=System.Windows.Forms
'   StackTrace:
'    at System.Windows.Forms.DataGridView.PerformLayoutPrivate(Boolean useRowShortcut, Boolean computeVisibleRows, Boolean invalidInAdjustFillingColumns, Boolean repositionEditingControl)
'    at System.Windows.Forms.DataGridView.SetColumnHeadersHeightInternal(Int32 columnHeadersHeight, Boolean invalidInAdjustFillingColumns)
'    at System.Windows.Forms.DataGridView.AutoResizeColumnHeadersHeight(Boolean fixedRowHeadersWidth, Boolean fixedColumnsWidth)
'    at System.Windows.Forms.DataGridView.OnColumnHeadersGlobalAutoSize()
'    at System.Windows.Forms.DataGridView.set_TopLeftHeaderCell(DataGridViewHeaderCell value)
'    at System.Windows.Forms.DataGridView.get_TopLeftHeaderCell()
'    at System.Windows.Forms.DataGridView.GetCellInternal(Int32 columnIndex, Int32 rowIndex)
'    at System.Windows.Forms.DataGridView.OnCellMouseEnter(DataGridViewCellEventArgs e)
'    at System.Windows.Forms.DataGridView.UpdateMouseEnteredCell(HitTestInfo hti, MouseEventArgs e)
'    at System.Windows.Forms.DataGridView.OnColumnWidthChanged(DataGridViewColumnEventArgs e)
'    at System.Windows.Forms.DataGridView.OnBandThicknessChanged(DataGridViewBand dataGridViewBand)
'    at System.Windows.Forms.DataGridViewBand.set_ThicknessInternal(Int32 value)
'    at System.Windows.Forms.DataGridView.AdjustFillingColumns()
'    at System.Windows.Forms.DataGridView.ComputeLayout()
'    at System.Windows.Forms.DataGridView.PerformLayoutPrivate(Boolean useRowShortcut, Boolean computeVisibleRows, Boolean invalidInAdjustFillingColumns, Boolean repositionEditingControl)
'    at System.Windows.Forms.DataGridView.OnHandleCreated(EventArgs e)
'    at System.Windows.Forms.Control.WmCreate(Message& m)
'    at System.Windows.Forms.Control.WndProc(Message& m)
'    at System.Windows.Forms.DataGridView.WndProc(Message& m)
'    at System.Windows.Forms.Control.ControlNativeWindow.OnMessage(Message& m)
'    at System.Windows.Forms.Control.ControlNativeWindow.WndProc(Message& m)
'    at System.Windows.Forms.NativeWindow.DebuggableCallback(IntPtr hWnd, Int32 msg, IntPtr wparam, IntPtr lparam)



'FIX
dim topLeftHeaderCell = DataGridView.topLeftHeaderCell



'OCCURENSE 
'Error komt voor als je VS project opent in debug en terwijl over de top links hoofding cell van een DGV hovert.