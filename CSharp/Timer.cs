public class Timer {
    private static System.Timers.Timer aTimer;

    public void SetTimer() {
        if(aTimer != null) {
            //Stop timer
            aTimer.Enabled = false;
			aTimer.Stop();
			aTimer.Dispose();
        }

        //Start timer
        aTimer = new System.Timers.Timer(5000); //Time in Milliseconds
		aTimer.Elapsed += OnTimedEvent;
		aTimer.SynchronizingObject = this;
		aTimer.Enabled = true;
		aTimer.AutoReset = false;
		aTimer.Start();
    }

    public void OnTimedEvent(object source, ElapsedEventArgs e) {
        //Timer done
		this.badgeNr = "";
		this.personID = "";
		this.personVoornaam = "";
		this.personAchternaam = "";

		this.txtPersoon.Text = "";
		this.txtMaat.Text = "";

		this.lblWarning.Visible = false;

		this.activePerson = false;

		aTimer.Enabled = false;
		aTimer.Stop();
		aTimer.Dispose();
    }
}