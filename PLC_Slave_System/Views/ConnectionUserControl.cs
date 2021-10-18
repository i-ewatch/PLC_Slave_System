using PLC_Slave_System.configuration;
using PLC_Slave_System.Protocols;
using System.Linq;

namespace PLC_Slave_System.Views
{
    public partial class ConnectionUserControl : Field4UserControl
    {
        public ConnectionUserControl(IPSetting setting)
        {
            InitializeComponent();
            IPSetting = setting;
            DevicegroupControl.Text = IPSetting.Name;
            Location_OnelabelControl.Text = IPSetting.Location[0];
            if (IPSetting.Location.Length > 1)
            {
                Location_TwolabelControl.Text = IPSetting.Location[1];
            }
        }
        public override void TextChange()
        {
            PLCProtocol data = (PLCProtocol)AbsProtocols.SingleOrDefault(g => g.Name == IPSetting.Name);
            if (data != null)
            {
                switch (data.LocationIndex)
                {
                    case 0:
                        {
                            if (data.ConnectionFlag)
                            {
                                Location_OnestateIndicatorComponent.StateIndex = 3;
                            }
                            else
                            {
                                Location_OnestateIndicatorComponent.StateIndex = 1;
                            }
                            Location_TwostateIndicatorComponent.StateIndex = 0;
                        }
                        break;
                    case 1:
                        {
                            if (data.ConnectionFlag)
                            {
                                Location_TwostateIndicatorComponent.StateIndex = 3;
                            }
                            else
                            {
                                Location_TwostateIndicatorComponent.StateIndex = 1;
                            }
                            Location_OnestateIndicatorComponent.StateIndex = 0;
                        }
                        break;
                }
            }
        }
    }
}
