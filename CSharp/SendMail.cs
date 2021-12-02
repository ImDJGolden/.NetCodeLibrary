public static void SendMail() 
{
    MailMessage mm = new MailMessage();

    mm.From = new MailAddress("Address here");

    //1 reciever
    mm.To = new MailAddress("Address here");

    //Multiple recievers
    string[] recievers = ""; //configfile.Split(';')
    foreach (string reciever in recievers) {
        mm.To.Add(reciever);
    }

    mm.Subject = "Subject here";
    mm.Body = "Body here"; 

    //1 attachment
    mm.Attachments = new Attachment("path file here");

    //Multiple attachements
    string[] files = Directory.GetFiles("directory files here");
    foreach (string file in files) {
        mm.Attachments.Add(new Attachment(file));
    }

    SmtpClient smtp = new SmtpClient("smtp client here");
    smtp.EnableSsl = true;
    NetworkCredential cred = new NetworkCredential("smtp user here", "smtp pass here");
    smtp.Credentials = cred;

    smtp.Send(mm);
    mm.Dispose();
}