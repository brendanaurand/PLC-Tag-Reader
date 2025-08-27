using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class PLCSetting
    {
        [Browsable(false)]
        public int PLCSettingsId { get; set; }

        [Browsable(false)]
        public int PLCSettingsVersion { get; set; }

        [Category("Client")]
        [DisplayName("IP Address")]
        [Description("ip address to connect to plc.")]
        public string IPAddress { get; set; } = "";

        [Category("Tags")]
        [DisplayName("PartNumber")]
        [Description("tag name of string used for current part number.\nset by plc and monitored for change event in app")]
        public string TagName { get; set; } = "";

        [Category("Tags")]
        [DisplayName("HeartBeat")]
        [Description("tag name of bool used for plc heartbeat.\nset high by application and set low by plc. plc monitors if tag is low for too long")]
        public string HeartBeatTag { get; set; } = "";

        [Category("Tags")]
        [DisplayName("Trigger")]
        [Description("tag name of boolean used for laser trigger.\nenergized by plc and monitored for change event in app. goes low if done bool is high")]
        public string TriggerTag { get; set; } = "";



        [NotMapped]
        [Browsable(false)]
        public bool TriggerValue
        {
            get
            {
                if (PLCHelper.PLCClient == null)
                    throw new Exception("Failed To Get TriggerValue. PLC Not Connected");

                if (string.IsNullOrWhiteSpace(TriggerTag))
                    throw new Exception("Failed To Get TriggerValue. Trigger Tag Not Set");

                if (!PLCHelper.PLCClient.IsReadable(TriggerTag))
                    throw new Exception($"Failed To Get TriggerValue. Tag '{TriggerTag}' Not Readable");

                return Convert.ToBoolean(PLCHelper.PLCClient.ReadTag(TriggerTag, true, false));
            }
            set
            {
                if (PLCHelper.PLCClient == null)
                    throw new Exception("Failed To Set TriggerValue. PLC Not Connected");

                if (string.IsNullOrWhiteSpace(TriggerTag))
                    throw new Exception("Failed To Set TriggerValue. Trigger Tag Not Set");

                if (!PLCHelper.PLCClient.IsWritable(TriggerTag))
                    throw new Exception($"Failed To Set TriggerValue. Tag '{TriggerTag}' Not Readable");

                var success = PLCHelper.PLCClient.WriteTag(TriggerTag, value, false, false);
                if (!success)
                    throw new Exception($"Failed To Set TriggerValue. Tag '{TriggerTag}' Not Writable");
            }
        }


        [NotMapped]
        [Browsable(false)]
        public bool HeartBeatValue
        {
            get
            {
                if (PLCHelper.PLCClient == null)
                    throw new Exception("Failed To Get HeartBeatValue. PLC Not Connected");

                if (string.IsNullOrWhiteSpace(HeartBeatTag))
                    throw new Exception("Failed To Get HeartBeatValue. HeartBeat Tag Not Set");

                if (!PLCHelper.PLCClient.IsReadable(HeartBeatTag))
                    throw new Exception($"Failed To Get HeartBeatValue. Tag '{HeartBeatTag}' Not Readable");

                return Convert.ToBoolean(PLCHelper.PLCClient.ReadTag(HeartBeatTag, true, false));
            }
            set
            {
                if (PLCHelper.PLCClient == null)
                    throw new Exception("Failed To Set HeartBeatValue. PLC Not Connected");

                if (string.IsNullOrWhiteSpace(HeartBeatTag))
                    throw new Exception("Failed To Set HeartBeatValue. HeartBeat Tag Not Set");

                if (!PLCHelper.PLCClient.IsWritable(HeartBeatTag))
                    throw new Exception($"Failed To Set HeartBeatValue. Tag '{HeartBeatTag}' Not Readable");

                var success = PLCHelper.PLCClient.WriteTag(HeartBeatTag, value, false, false);
                if (!success)
                    throw new Exception($"Failed To Set HeartBeatValue. Tag '{HeartBeatTag}' Not Writable");
            }
        }

        [NotMapped]
        [Browsable(false)]
        public string PartNumberValue
        {
            get
            {
                if (PLCHelper.PLCClient == null)
                    throw new Exception("Failed To Get PartNumberValue. PLC Not Connected");

                if (string.IsNullOrWhiteSpace(TagName))
                    throw new Exception("Failed To Get PartNumberValue. PartNumber Tag Not Set");

                if (!PLCHelper.PLCClient.IsReadable(TagName))
                    throw new Exception($"Failed To Get RetryValue. Tag '{TagName}' Not Readable");

                return PLCHelper.PLCClient.ReadTag(TagName, true, false).ToString();
            }
            set
            {
                if (PLCHelper.PLCClient == null)
                    throw new Exception("Failed To Set PartNumberValue. PLC Not Connected");

                if (string.IsNullOrWhiteSpace(TagName))
                    throw new Exception("Failed To Set PartNumberValue. PartNumber Tag Not Set");

                if (!PLCHelper.PLCClient.IsWritable(TagName))
                    throw new Exception($"Failed To Set PartNumberValue. Tag '{TagName}' Not Readable");

                var success = PLCHelper.PLCClient.WriteTag(TagName, value, false, false);
                if (!success)
                    throw new Exception($"Failed To Set PartNumberValue. Tag '{TagName}' Not Writable");
            }
        }


        public int? ProcessorSlot { get; set; } = 0;

        public int? PollRate { get; set; } = 0;

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
