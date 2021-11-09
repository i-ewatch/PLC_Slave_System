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
            switch (IPSetting.Location.Length)
            {
                case 1:
                    {
                        LocationpanelControl1.Visible = true;
                        LocationpanelControl2.Visible = false;
                        LocationpanelControl3.Visible = false;
                        LocationpanelControl4.Visible = false;
                        LocationpanelControl5.Visible = false;
                        Location1.Text = IPSetting.Location[0];
                    }
                    break;
                case 2:
                    {
                        LocationpanelControl1.Visible = true;
                        LocationpanelControl2.Visible = true;
                        LocationpanelControl3.Visible = false;
                        LocationpanelControl4.Visible = false;
                        LocationpanelControl5.Visible = false;
                        Location1.Text = IPSetting.Location[0];
                        Location2.Text = IPSetting.Location[1];
                    }
                    break;
                case 3:
                    {
                        LocationpanelControl1.Visible = true;
                        LocationpanelControl2.Visible = true;
                        LocationpanelControl3.Visible = true;
                        LocationpanelControl4.Visible = false;
                        LocationpanelControl5.Visible = false;
                        Location1.Text = IPSetting.Location[0];
                        Location2.Text = IPSetting.Location[1];
                        Location3.Text = IPSetting.Location[2];
                    }
                    break;
                case 4:
                    {
                        LocationpanelControl1.Visible = true;
                        LocationpanelControl2.Visible = true;
                        LocationpanelControl3.Visible = true;
                        LocationpanelControl4.Visible = true;
                        LocationpanelControl5.Visible = false;
                        Location1.Text = IPSetting.Location[0];
                        Location2.Text = IPSetting.Location[1];
                        Location3.Text = IPSetting.Location[2];
                        Location4.Text = IPSetting.Location[3];
                    }
                    break;
                case 5:
                    {
                        LocationpanelControl1.Visible = true;
                        LocationpanelControl2.Visible = true;
                        LocationpanelControl3.Visible = true;
                        LocationpanelControl4.Visible = true;
                        LocationpanelControl5.Visible = true;
                        Location1.Text = IPSetting.Location[0];
                        Location2.Text = IPSetting.Location[1];
                        Location3.Text = IPSetting.Location[2];
                        Location4.Text = IPSetting.Location[3];
                        Location5.Text = IPSetting.Location[4];
                    }
                    break;
            }
            Location2.Text = IPSetting.Location[0];
            if (IPSetting.Location.Length > 1)
            {
                Location1.Text = IPSetting.Location[1];
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
                                LocationstateIndicatorComponent1.StateIndex = 3;
                            }
                            else
                            {
                                LocationstateIndicatorComponent1.StateIndex = 1;
                            }
                            LocationstateIndicatorComponent2.StateIndex = 0;
                            LocationstateIndicatorComponent3.StateIndex = 0;
                            LocationstateIndicatorComponent4.StateIndex = 0;
                            LocationstateIndicatorComponent5.StateIndex = 0;
                        }
                        break;
                    case 1:
                        {
                            if (data.ConnectionFlag)
                            {
                                LocationstateIndicatorComponent2.StateIndex = 3;
                            }
                            else
                            {
                                LocationstateIndicatorComponent2.StateIndex = 1;
                            }
                            LocationstateIndicatorComponent1.StateIndex = 0;
                            LocationstateIndicatorComponent3.StateIndex = 0;
                            LocationstateIndicatorComponent4.StateIndex = 0;
                            LocationstateIndicatorComponent5.StateIndex = 0;
                        }
                        break;
                    case 2:
                        {
                            if (data.ConnectionFlag)
                            {
                                LocationstateIndicatorComponent3.StateIndex = 3;
                            }
                            else
                            {
                                LocationstateIndicatorComponent3.StateIndex = 1;
                            }
                            LocationstateIndicatorComponent1.StateIndex = 0;
                            LocationstateIndicatorComponent2.StateIndex = 0;
                            LocationstateIndicatorComponent4.StateIndex = 0;
                            LocationstateIndicatorComponent5.StateIndex = 0;
                        }
                        break;
                    case 3:
                        {
                            if (data.ConnectionFlag)
                            {
                                LocationstateIndicatorComponent4.StateIndex = 3;
                            }
                            else
                            {
                                LocationstateIndicatorComponent4.StateIndex = 1;
                            }
                            LocationstateIndicatorComponent1.StateIndex = 0;
                            LocationstateIndicatorComponent2.StateIndex = 0;
                            LocationstateIndicatorComponent3.StateIndex = 0;
                            LocationstateIndicatorComponent5.StateIndex = 0;
                        }
                        break;
                    case 4:
                        {
                            if (data.ConnectionFlag)
                            {
                                LocationstateIndicatorComponent5.StateIndex = 3;
                            }
                            else
                            {
                                LocationstateIndicatorComponent5.StateIndex = 1;
                            }
                            LocationstateIndicatorComponent1.StateIndex = 0;
                            LocationstateIndicatorComponent2.StateIndex = 0;
                            LocationstateIndicatorComponent3.StateIndex = 0;
                            LocationstateIndicatorComponent4.StateIndex = 0;
                        }
                        break;
                }
            }
        }
    }
}
