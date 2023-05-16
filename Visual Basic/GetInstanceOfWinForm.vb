'... Designer.vb
Public Shared myForm As FormVerIngavePrijzenSNIN_Nini = Nothing

    Public Shared Function GetInstance() As FormVerIngavePrijzenSNIN_Nini
        If myForm Is Nothing Then
            myForm = New FormVerIngavePrijzenSNIN_Nini
        End If
        myForm.BringToFront()
        Return myForm
    End Function

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
        myForm = Nothing
    End Sub

'... .vb
Public Shared Function GetInstance() As FormTikklokVerwerkingExtern
	If _formTikklokVerwerking Is Nothing OrElse _formTikklokVerwerking.IsDisposed Then _formTikklokVerwerking = New FormTikklokVerwerkingExtern
	Return _formTikklokVerwerking
End Function