using Gentex.IO.AllenBradley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public static class PLCHelper
    {
        public static Gentex.IO.AllenBradley.Client PLCClient { get; set; }

        public static PLCSetting SettingsAndValues { get; set; }


        /// <summary>
        /// Creates Client, Loads Client Settings, And Connects Client
        /// </summary>
        public static (bool, string) InitializePLCClient(PLCSetting settingsAndValues)
        {
            try
            {
                SettingsAndValues = settingsAndValues;
                if (String.IsNullOrWhiteSpace(SettingsAndValues.IPAddress))
                {
                    return (false, "IP Address Not Set");
                }

                PLCClient = new Gentex.IO.AllenBradley.Client()
                {
                    TargetIP = SettingsAndValues.IPAddress,
                    HandleProjectDownloads = false,
                    LargeForwardOpenSupported = false,
                    TagDiscoveryMode = Gentex.IO.AllenBradley.Enums.TagDiscoveryMode.None,
                    TcpTimeout = 10000,
                    PollRate = SettingsAndValues.PollRate == null ? 100 : (int)SettingsAndValues.PollRate,
                    MaxPacketSize = 511,
                    NumReadConnections = 1,
                    NumWriteConnections = 1,
                    ProcessorSlot = SettingsAndValues.ProcessorSlot == null ? (byte)0 : (byte)SettingsAndValues.ProcessorSlot,
                };

                CreatePLCEvents();

                PLCClient.Connect();

                return (true, "PLC Client Initialized Successfully");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to Initialize PLC Client", ex);
            }
        }

        /// <summary>
        /// Creates All Client Event Handlers
        /// </summary>
        private static void CreatePLCEvents()
        {
            PLCClient.ConnectionChanged += PLCClient_ConnectionChanged;
            PLCClient.ErrorThrown += PLCClient_ErrorThrown;
            PLCClient.SymbolErrorRaised += PLCClient_SymbolErrorRaised;
            PLCClient.ValidationFailed += PLCClient_ValidationFailed;
            PLCClient.ProjectDownloadStarted += PLCClient_ProjectDownloadStarted;
            PLCClient.ProjectDownloadCompleted += PLCClient_ProjectDownloadCompleted;
            PLCClient.ProjectDownloadSymbolsLost += PLCClient_ProjectDownloadSymbolsLost;
            PLCClient.WarningThrown += PLCClient_WarningThrown;
            PLCClient.OnlineEditStarted += PLCClient_OnlineEditStarted;
            PLCClient.OnlineEditCompleted += PLCClient_OnlineEditCompleted;
            PLCClient.StateChange += PLCClient_StateChange;
        }

        #region PLC Client Events

        private static void PLCClient_ConnectionChanged(object sender, EventArgs e)
        {
            var client = (Gentex.IO.AllenBradley.Client)sender;
            if (client.Connected)
            {
                var message = $"PLC {client.Name} Is Connected";
                Console.WriteLine(message);
            }
            else
            {
                var message = $"PLC {client.Name} Is Disconnected";
                Console.WriteLine(message);
            }
        }

        private static void PLCClient_ErrorThrown(object sender, System.IO.ErrorEventArgs e)
        {
            var message = "PLCClient_ErrorThrown Event Triggered" + Environment.NewLine + e.GetException().Message;
            Console.WriteLine(message);
        }

        private static void PLCClient_SymbolErrorRaised(object sender, SymbolErrorEventArgs e)
        {
            var message = "PLCClient_SymbolErrorRaised Event Triggered" + Environment.NewLine + e.Exception;
            Console.WriteLine(message);
        }

        private static void PLCClient_ValidationFailed(object sender, ValidationErrorEventArgs e)
        {
            var message = "PLCClient_ValidationFailed Event Triggered" + Environment.NewLine + e.Message;
            Console.WriteLine(message);
        }

        private static void PLCClient_ProjectDownloadStarted(object sender, ProjectDownloadEventArgs e)
        {
            var message = "PLCClient_ProjectDownloadStarted Event Triggered" + Environment.NewLine + e;
            Console.WriteLine(message);
        }

        private static void PLCClient_ProjectDownloadCompleted(object sender, ProjectDownloadEventArgs e)
        {
            var message = "PLCClient_ProjectDownloadCompleted Event Triggered" + Environment.NewLine + e;
            Console.WriteLine(message);
        }

        private static void PLCClient_ProjectDownloadSymbolsLost(object sender, EventArgs e)
        {
            var message = "PLCClient_ProjectDownloadSymbolsLost Event Triggered" + Environment.NewLine + e;
            Console.WriteLine(message);
        }

        private static void PLCClient_WarningThrown(object sender, WarningThrownEventArgs e)
        {
            var message = "PLCClient_WarningThrown Event Triggered" + Environment.NewLine + e.Message;
            Console.WriteLine(message);
        }

        private static void PLCClient_OnlineEditStarted(object sender, OnlineEditEventArgs e)
        {
            var message = "PLCClient_OnlineEditStarted Event Triggered" + Environment.NewLine + e;
            Console.WriteLine(message);
        }

        private static void PLCClient_OnlineEditCompleted(object sender, OnlineEditEventArgs e)
        {
            var message = "PLCClient_OnlineEditCompleted Event Triggered" + Environment.NewLine + e;
            Console.WriteLine(message);
        }

        private static void PLCClient_StateChange(object sender, EventArgs e)
        {
            var message = "PLCClient_StateChange Event Triggered" + Environment.NewLine + e;
            Console.WriteLine(message);
        }

        #endregion

    }
}
