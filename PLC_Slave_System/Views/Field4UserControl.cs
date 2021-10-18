using DevExpress.XtraEditors;
using PLC_Slave_System.configuration;
using PLC_Slave_System.Protocols;
using System.Collections.Generic;

namespace PLC_Slave_System.Views
{
    public class Field4UserControl: XtraUserControl
    {
        /// <summary>
        /// 通訊數值物件
        /// </summary>
        public List<AbsProtocol> AbsProtocols { get; set; } = new List<AbsProtocol>();
        /// <summary>
        /// 設備資訊
        /// </summary>
        public PLCSetting PLCSetting { get; set; }
        /// <summary>
        /// IP資訊
        /// </summary>
        public IPSetting IPSetting { get; set; }
        /// <summary>
        /// 顯示變更
        /// </summary>
        public virtual void TextChange() { }
    }
}
