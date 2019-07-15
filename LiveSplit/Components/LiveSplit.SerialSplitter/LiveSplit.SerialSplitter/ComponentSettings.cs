using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Xml;

namespace LiveSplit.UI.Components
{
    public partial class ComponentSettings : UserControl
    {
        public string BaudRate { get; set; }
        public string Port { get; set; }
        public string Monitoring { get; set; }

        string[] AvailablePorts;
        string[] BaudRates =
        {
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "74880",
            "115200"
        };

        public ComponentSettings()
        {
            InitializeComponent();
        }


        private void ComponentSettings_Load(object sender, EventArgs e)
        {
            AvailablePorts = null;
            AvailablePorts = SerialPort.GetPortNames();

            cbCOMPorts.DataSource = AvailablePorts;
            cbBaudRate.DataSource = BaudRates;

            try
            {
                if (cbCOMPorts.Items.Contains(Port))
                {
                    cbCOMPorts.SelectedItem = Port;
                }
                else
                {
                    cbCOMPorts.SelectedItem = cbCOMPorts.Items[0];
                }

                if (cbBaudRate.Items.Contains(BaudRate))
                {
                    cbBaudRate.SelectedItem = BaudRate;
                }
                else
                {
                    cbBaudRate.SelectedItem = cbBaudRate.Items[0];
                }

                if (Monitoring == "1")
                {
                    cbConnectivityMonitoring.Checked = true;
                }
                else
                {
                    cbConnectivityMonitoring.Checked = false;
                }
            }
            catch
            {
                return;
            }
        }


        private void ComponentSettings_Leave(object sender, EventArgs e)
        {
            Port = cbCOMPorts.SelectedItem.ToString();
            BaudRate = cbBaudRate.SelectedItem.ToString();

            if (cbConnectivityMonitoring.Checked)
            {
                Monitoring = "1";   //Enabled
            }
            else
            {
                Monitoring = "0";   //Disabled
            }
        }


        public XmlNode GetSettings(XmlDocument document)
        {
            var parent = document.CreateElement("Settings");
            CreateSettingsNode(document, parent);
            return parent;
        }

        public int GetSettingsHashCode()
        {
            return CreateSettingsNode(null, null);
        }

        private int CreateSettingsNode(XmlDocument document, XmlElement parent)
        {
            return SettingsHelper.CreateSetting(document, parent, "Baudrate", BaudRate) ^
            SettingsHelper.CreateSetting(document, parent, "Port", Port) ^
            SettingsHelper.CreateSetting(document, parent, "Monitoring", Monitoring);
        }

        public void SetSettings(XmlNode settings)
        {
            BaudRate = SettingsHelper.ParseString(settings["Baudrate"]);
            Port = SettingsHelper.ParseString(settings["Port"]);
            Monitoring = SettingsHelper.ParseString(settings["Monitoring"]);
        }
    }
}
