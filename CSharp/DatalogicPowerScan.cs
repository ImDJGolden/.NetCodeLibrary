//Datalogic PowerScan oornummer en een return message sturen.

public partial class klasse
{
    private string mSC = ""; 

    private void ProcessScanning(object sender, EventArgs e){
        this.mSC = ""; //COM.ReadExisting(); - lees com poort

        if(mSC.Length > 12 && mSC.Contains(Char.ConvertFromUtf32(2)) && mSC.Contains(Char.ConvertFromUtf32(3))){
            string idGun = this.mSC.Substring(0, 12); //ID van scanner: 1ste 12 chars
            string data = this.mSC.Substring(12); //data
            
            if (data.StartsWith("\u0002") && data.EndsWith("\u0003")){
                data = data.Trim('\u0002', '\u0003');
                //data from scan

                //send return to scanner
                SendMessageToCOM("", false);
            }
        }
    }

    private void SendMessageToCOM(String msg, Boolean errorbeep) {
        string beeptone = "";
        string returnmsg = "";

        if (errorbeep) {
            beeptone = Char.ConvertFromUtf32(27) + "[0q" + Char.ConvertFromUtf32(27) + "[2q" + Char.ConvertFromUtf32(27) + "[8q" + Char.ConvertFromUtf32(27) + "[5q" + Char.ConvertFromUtf32(27) + "[9q";
        }

        returnmsg = idGun + beeptone
        + (char)27 + "[1;1H"
        + (char)27 + "[0K"
        + (char)27 + "[2;1H"
        + (char)27 + "[0K"
        + (char)27 + "[3;1H"
        + (char)27 + "[0K"
        + (char)27 + "[4;1H"
        + (char)27 + "[0K"
        + (char)27 + "[5;1H"
        + (char)27 + "[0K"

        + (char)27 + "[1;1H" + "OorNr:  "
        + (char)27 + "[2;1H" + "----------------------"
        + (char)27 + "[3;1H" + msg
        + (char)27 + "[4;1H" + "Klasse: "
        + (char)27 + "[5;1H" + "Prijs:  "
        + (char)13;

        try {
            this.COM.Write(returnmsg);
        }
        catch (Exception ex) {
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Log.Write(ex.Message);
        }
    }
}