using System.Collections.Generic;

namespace PLC_Slave_System.configuration
{
    public class PLCSetting
    {
        /// <summary>
        /// IP設定
        /// </summary>
        public List<IPSetting> IPSettings { get; set; } = new List<IPSetting>();
    }
    /// <summary>
    /// IP設定
    /// </summary>
    public class IPSetting
    {
        /// <summary>
        /// 設備名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 設備位址
        /// </summary>
        public int[] ID { get; set; }
        /// <summary>
        /// TCP IP 
        /// </summary>
        public string[] Location { get; set; }
        /// <summary>
        /// TCP Port
        /// </summary>
        public int[] port { get; set; }
        /// <summary>
        /// 點位設定
        /// </summary>
        public List<PointSetting> PointSettings { get; set; } = new List<PointSetting>();
    }
    /// <summary>
    /// 點位設定
    /// </summary>
    public class PointSetting
    {
        /// <summary>
        /// 設備讀取方法
        /// </summary>
        public int ReadFunction { get; set; }
        /// <summary>
        /// 設備讀取位址
        /// </summary>
        public int ReadAddress { get; set; }
        /// <summary>
        /// 設備讀取長度
        /// </summary>
        public int ReadQuantity { get; set; }
    }
}
