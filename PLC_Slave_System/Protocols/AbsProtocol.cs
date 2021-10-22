using MathLibrary;
using NModbus;
using PLC_Slave_System.Components;
using PLC_Slave_System.configuration;

namespace PLC_Slave_System.Protocols
{
    public abstract class AbsProtocol
    {
        /// <summary>
        /// 數學公式
        /// </summary>
        public MathClass MathClass { get; set; } = new MathClass();
        /// <summary>
        /// 連線旗標
        /// </summary>
        public bool ConnectionFlag { get; set; }
        /// <summary>
        /// 備援編號
        /// </summary>
        public int LocationIndex { get; set; }
        /// <summary>
        /// 第一次讀取
        /// </summary>
        public bool FirstFlag { get; set; }
        /// <summary>
        /// 設備資訊
        /// </summary>
        public IPSetting IPSetting { get; set; }
        /// <summary>
        /// 設備名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 資料讀取
        /// </summary>
        /// <param name="master"></param>
        public abstract void ReadData(IModbusMaster master, TCPComponent tCPComponent);
    }
}
