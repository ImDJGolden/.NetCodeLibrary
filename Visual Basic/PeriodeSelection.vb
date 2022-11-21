Private Sub dteVan_ValueChanged(sender As Object, e As EventArgs) Handles dteVan.ValueChanged
        Dim dateStart As Date = Me.dteVan.Value.Date
        Dim dateMo As New Date
        Dim dateSu As New Date

        Try
           Select Case dateStart.DayOfWeek
               Case DayOfWeek.Monday
                   'No changes to be made
                   dateMo = Me.dteVan.Value.Date
                   dateSu = dateMo.AddDays(6)

                   Me.dteTot.Value = dateSu
               Case DayOfWeek.Sunday
                   Me.dteVan.Value = dateStart.AddDays(-6)
               Case Else
                   Me.dteVan.Value = dateStart.AddDays(-(dateStart.DayOfWeek - 1))
           End Select
        Catch ex As Exception
           MessageBox.Show($"{ex.Message}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub