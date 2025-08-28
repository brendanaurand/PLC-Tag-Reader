namespace Demo
{
    public partial class Form1 : Form
    {
        public PLCSetting CurrentPLCSettings;

        // Add a new button called 'btnTest' to the form
        
        private Button btnConnect;
        
        


        public Form1()
        {
            InitializeComponent();
            InitializeConnectButton();

            tmrPLCHeartbeat = new System.Windows.Forms.Timer();
            tmrPLCHeartbeat.Interval = 500; // Poll every 500ms (adjust as needed)
            tmrPLCHeartbeat.Tick += TmrPLCHeartbeat_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.IPAddress;
            textBox2.Text = Properties.Settings.Default.PartNumberTag;
            textBox3.Text = Properties.Settings.Default.HeartBeatTag;
            textBox4.Text = Properties.Settings.Default.TriggerTag;


        }

        private void InitPLC()
        {
            try
            {
                CurrentPLCSettings = new PLCSetting()
                {
                    // User Input for IP Address and Tags
                    IPAddress = textBox1.Text,
                    PartNumberTag = textBox2.Text,
                    TriggerTag = textBox4.Text,
                    HeartBeatTag = textBox3.Text
                };
                // create new plc client
                var (success, message) = PLCHelper.InitializePLCClient(CurrentPLCSettings);
                if (success)
                {
                    MessageBox.Show(message);
                    
                }
                InitPolling();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void InitPolling()
        {
            try
            {
               
                tmrPLCHeartbeat.Enabled = true;


                
                //add to polling for PLC tags
                PLCHelper.PLCClient.ReadTag(CurrentPLCSettings.PartNumberTag, true, true);
                
                if (!string.IsNullOrWhiteSpace(CurrentPLCSettings.HeartBeatTag)) 
                    PLCHelper.PLCClient.ReadTag(CurrentPLCSettings.HeartBeatTag, true, true);
                
                PLCHelper.PLCClient.ReadTag(CurrentPLCSettings.TriggerTag, true, true);

                //setup PLC tag change event handlers. 
                PLCHelper.PLCClient.Symbols[CurrentPLCSettings.PartNumberTag].ValueChanged -= plcPartNumberValueChanged;
                PLCHelper.PLCClient.Symbols[CurrentPLCSettings.PartNumberTag].ValueChanged += plcPartNumberValueChanged;
                
                if (!string.IsNullOrWhiteSpace(CurrentPLCSettings.HeartBeatTag))
                    PLCHelper.PLCClient.Symbols[CurrentPLCSettings.HeartBeatTag].ValueChanged -= plcHeartBeatValueChanged;
                if (!string.IsNullOrWhiteSpace(CurrentPLCSettings.HeartBeatTag))
                    PLCHelper.PLCClient.Symbols[CurrentPLCSettings.HeartBeatTag].ValueChanged += plcHeartBeatValueChanged;

                PLCHelper.PLCClient.Symbols[CurrentPLCSettings.TriggerTag].ValueChanged -= plcTriggerValueChanged;
                PLCHelper.PLCClient.Symbols[CurrentPLCSettings.TriggerTag].ValueChanged += plcTriggerValueChanged;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void InitializeConnectButton()
        {
            btnConnect = new Button();
            btnConnect.Text = "Connect";
            btnConnect.Location = new Point(400, 200); // Adjust as needed
            btnConnect.Size = new Size(100, 30);
            btnConnect.Click += BtnConnect_Click;
            this.Controls.Add(btnConnect);
        }


        private async void plcTriggerValueChanged(object sender, Gentex.IO.AllenBradley.SymbolEventArgs e)
        {
            try
            {
                var readTrig = Convert.ToBoolean(e.Value);
                if (readTrig)
                {
                    Console.WriteLine($"PLC Trigger Changed at {DateTime.Now.ToString()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"errror in plcTriggerValueChange: {ex.Message} ");
            }
        }

        private async void plcPartNumberValueChanged(object sender, Gentex.IO.AllenBradley.SymbolEventArgs e)
        {
            try
            {
                Console.WriteLine($"Part Number Changed: {e.Value}");
                if (labelPartNumber.InvokeRequired)
                {
                    // Use Invoke to call the method on the UI thread
                    labelPartNumber.Invoke(new Action(() => labelPartNumber.Text = e.Value.ToString()));
                }
                else
                {
                    // If already on the UI thread, update the label directly
                    labelPartNumber.Text = e.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($" Error plcPartNumberValueChanged: {ex.Message}");
            }
        }

        private async void plcHeartBeatValueChanged(object sender, Gentex.IO.AllenBradley.SymbolEventArgs e)
        {
            try
            {
                Console.WriteLine($"HeartBeat Changed: {e.Value}");

                if (btnHeartBeat.InvokeRequired)
                {
                    // Use Invoke to call the method on the UI thread
                    btnHeartBeat.Invoke(new Action(() => btnHeartBeat.Text = e.Value.ToString()));
                }
                else
                {
                    // If already on the UI thread, update the label directly
                    btnHeartBeat.Text = e.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($" Error plcHeartBeatValueChanged: {ex.Message}");
            }
        }

     

      
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.IPAddress = textBox1.Text;
            Properties.Settings.Default.PartNumberTag = textBox2.Text;
            Properties.Settings.Default.HeartBeatTag = textBox3.Text;
            Properties.Settings.Default.TriggerTag = textBox4.Text;



            // Add More Settings As Needed
            Properties.Settings.Default.Save();

            // Now uses the current values in settings
            InitPLC();
        }
        private void TmrPLCHeartbeat_Tick(object sender, EventArgs e)
        {
            try
            {
                // Read the current value of the PartNumber tag
                var value = PLCHelper.PLCClient.ReadTag(CurrentPLCSettings.PartNumberTag, true, false);

                // Update the label on the UI thread
                if (labelPartNumber.InvokeRequired)
                {
                    labelPartNumber.Invoke(new Action(() => labelPartNumber.Text = value?.ToString() ?? ""));
                }
                else
                {
                    labelPartNumber.Text = value?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                // Optionally show error or log
                labelPartNumber.Text = $"Error: {ex.Message}";
            }
        }



    }

}
