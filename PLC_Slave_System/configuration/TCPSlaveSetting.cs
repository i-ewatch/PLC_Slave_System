using System.Collections.Generic;

namespace PLC_Slave_System.configuration
{
    public class TCPSlaveSetting
    {
        /// <summary>
        /// IP資訊
        /// </summary>
        public List<SIPSetting> IPSettings { get; set; } = new List<SIPSetting>();
    }
    /// <summary>
    /// IP資訊
    /// </summary>
    public class SIPSetting
    {
        /// <summary>
        /// TCP IP 
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// TCP Port
        /// </summary>
        public int port { get; set; }
        /// <summary>
        /// ID資訊
        /// </summary>
        public List<SIDSetting> IDSettings { get; set; } = new List<SIDSetting>();
    }
    /// <summary>
    /// ID資訊
    /// </summary>
    public class SIDSetting
    {
        /// <summary>
        /// TCP ID
        /// </summary>
        public byte ID { get; set; }
        /// <summary>
        /// 點位資訊
        /// </summary>
        public List<SPointSetting> PointSettings { get; set; } = new List<SPointSetting>();
    }
    /// <summary>
    /// 點位資訊
    /// </summary>
    public class SPointSetting
    {
        /// <summary>
        /// 設備讀取方法
        /// </summary>
        public int ReadFunction { get; set; }
        /// <summary>
        /// 設備讀取位址
        /// </summary>
        public byte ReadAddress { get; set; }
        /// <summary>
        /// 設備名稱
        /// </summary>
        public string DeviceName { get; set; }
        /// <summary>
        /// Slave寫入位置
        /// </summary>
        public byte SlaveAddress { get; set; }
        /// <summary>
        /// Slave寫入方法
        /// </summary>
        public int SlaveFunction { get; set; }
    }
}
