public class x

    public sub OpenOutlook()
    {
        'mail
            Dim dtReciever As DataTable = dbvk.GetSelectedPrijsToeslag(Me.cboCustomerClass.SelectedValue)

            Dim mSubject As String          'Onderwerp van mail
            Dim mReciever As String         'Ontvanger van mail
            Dim mAttachment As String       'Eventuele path naar file

            Dim oApp As Outlook.Application = New Outlook.Application()
            Dim oMsg As Outlook.MailItem = oApp.CreateItem(Outlook.OlItemType.olMailItem)
            oMsg.Subject = mSubject
            oMsg.To = mReciever
            oMsg.Attachments.Add(mAttachment)

            oMsg.Display(False)
    }

end class