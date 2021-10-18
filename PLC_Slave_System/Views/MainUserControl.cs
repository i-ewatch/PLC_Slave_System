using PLC_Slave_System.configuration;
using PLC_Slave_System.Protocols;
using System.Collections.Generic;
using System.Drawing;

namespace PLC_Slave_System.Views
{
    public partial class MainUserControl : Field4UserControl
    {
        private List<Field4UserControl> Field4UserControls { get; set; } = new List<Field4UserControl>();
        private int Index { get; set; }
        public MainUserControl(PLCSetting setting, List<AbsProtocol> protocols)
        {
            InitializeComponent();
            PLCSetting = setting;
            AbsProtocols = protocols;
            if (PLCSetting != null)
            {
                foreach (var item in PLCSetting.IPSettings)
                {
                    ConnectionUserControl control = new ConnectionUserControl(item) { Location = new Point(5 + 250 * (Index % 3), 5 + 113 * (Index / 3)) };
                    ViewxtraScrollableControl.Controls.Add(control);
                    Field4UserControls.Add(control);
                    Index++;
                }
            }
        }
        public override void TextChange()
        {
            foreach (var item in Field4UserControls)
            {
                item.AbsProtocols = AbsProtocols;
                item.TextChange();
            }
        }
    }
}
