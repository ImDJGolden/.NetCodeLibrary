namespace Scanner {
    public class Form {
        private void COM_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			try
			{
				this.Invoke(new EventHandler(ProcessScanning));
			}
			catch (Exception ex)
			{
				Msgbox.Error(ex.Message);
			}
		}

        private void ProcessScanning(object s, EventArgs e)
		{
			string mSCBuff = "";
			try
			{
				mSCBuff = this.COM.ReadLine() + "\u0003";

				
				//Trim Prefix en Sufix
				if (!mSCBuff.StartsWith("\u0002"))
				{
					mSCBuff = mSCBuff.Substring(mSCBuff.IndexOf("\u0002"));
				}
				string data = mSCBuff.Substring(0, mSCBuff.IndexOf("\u0003") + 1).Trim('\u0002', '\u0003');
				data = (data.StartsWith("]")) ? data.Substring(3) : data;

				//Do Something With Data				
			}
			catch (Exception ex)
			{
				Log.Write($"ERROR - ProcesScanning: {ex.Message}");
				Msgbox.Error(ex.Message);
			}
		}
    }

    public class Serial {
        static SerialPort _COMPort;

        public static SerialPort OpenComPort()
        {
            if (_COMPort is null)
            {
                try
                {
                    _COMPort = new SerialPort
                    {
                        PortName = System.Configuration.ConfigurationManager.AppSettings["COMPort"], //App.config
                        BaudRate = 9600,
                        DataBits = 8,
                        StopBits = StopBits.One,
                        Parity = Parity.None,
                        ReadTimeout = 1500
                    };

                    _COMPort.Open();

                    _COMPort.DtrEnable = true;
                    _COMPort.RtsEnable = true;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Connection Error COM", MessageBoxButtons.OK);
                }
            }
            return _COMPort;
        }

        public static void CloseComPort()
        {
            try
            {
                if (_COMPort.IsOpen)
                {
                    _COMPort.Close();
                }
                _COMPort = null;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Connection Error COM", MessageBoxButtons.OK);
            }
        }
    }
}