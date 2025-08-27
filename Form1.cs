namespace Demo
{
    public partial class Form1 : Form
    {
        public PLCSetting CurrentPLCSettings;

        // Add a new button called 'btnTest' to the form
        
        private Button btnConnect;
        private Button btnTrigger;


        public Form1()
        {
            InitializeComponent();
            InitializeConnectButton();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.IPAddress;
            textBox2.Text = Properties.Settings.Default.TagName;
        }

        private void InitPLC()
        {
            try
            {
                CurrentPLCSettings = new PLCSetting()
                {
                    // User Input for IP Address and Tags
                    IPAddress = textBox1.Text,
                    TagName = textBox2.Text,
                    TriggerTag = textBox2.Text,
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
                tmrPLCHeartbeat.Interval = 5000;
                tmrPLCHeartbeat.Enabled = true;

                //add to polling for PLC tags
                PLCHelper.PLCClient.ReadTag(CurrentPLCSettings.TagName, true, true);
                PLCHelper.PLCClient.ReadTag(CurrentPLCSettings.HeartBeatTag, true, true);
                PLCHelper.PLCClient.ReadTag(CurrentPLCSettings.TriggerTag, true, true);

                //setup PLC tag change event handlers. 
                PLCHelper.PLCClient.Symbols[CurrentPLCSettings.TagName].ValueChanged -= plcPartNumberValueChanged;
                PLCHelper.PLCClient.Symbols[CurrentPLCSettings.TagName].ValueChanged += plcPartNumberValueChanged;

                PLCHelper.PLCClient.Symbols[CurrentPLCSettings.HeartBeatTag].ValueChanged -= plcHeartBeatValueChanged;
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
                if (labelTagName.InvokeRequired)
                {
                    // Use Invoke to call the method on the UI thread
                    labelTagName.Invoke(new Action(() => labelTagName.Text = e.Value.ToString()));
                }
                else
                {
                    // If already on the UI thread, update the label directly
                    labelTagName.Text = e.Value.ToString();
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
            Properties.Settings.Default.TagName = textBox2.Text;
            
            // Add More Settings As Needed
            Properties.Settings.Default.Save();

            // Now uses the current values in settings
            InitPLC();
        }

       
    }

}
