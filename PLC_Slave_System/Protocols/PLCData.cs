using PLC_Slave_System.Enums;
using System.Collections.Generic;

namespace PLC_Slave_System.Protocols
{
    public abstract class PLCData:AbsProtocol
    {
        public FunctionTypeEnum FunctionTypeEnum { get; set; }
        /// <summary>
        /// Function 1
        /// </summary>
        public List<ColisData> ColisDatas { get; set; } = new List<ColisData>();
        /// <summary>
        /// Function 2
        /// </summary>
        public List<DiscreteData> DiscreteDatas { get; set; } = new List<DiscreteData>();
        /// <summary>
        /// Function 3
        /// </summary>
        public List<HoldingRegisterData> HoldingRegisterDatas { get; set; } = new List<HoldingRegisterData>();
        /// <summary>
        /// Function 4
        /// </summary>
        public List<InputRegisterData> InputRegisterDatas { get; set; } = new List<InputRegisterData>();
    }
    #region Function 1  
    public class ColisData
    {
        /// <summary>
        /// 數值
        /// </summary>
        public bool[] Value { get; set; } = new bool[1];
        /// <summary>
        /// 通訊 讀取位置
        /// </summary>
        public int Address { get; set; }
    }
    #endregion
    #region Function 2
    public class DiscreteData
    {
        /// <summary>
        /// 數值
        /// </summary>
        public bool[] Value { get; set; } = new bool[1];
        /// <summary>
        /// 通訊 讀取位置
        /// </summary>
        public int Address { get; set; }
    }
    #endregion
    #region Function 3
    public class HoldingRegisterData
    {
        /// <summary>
        /// 數值
        /// </summary>
        public ushort[] Value { get; set; } = new ushort[1];
        /// <summary>
        /// 通訊 讀取位置
        /// </summary>
        public int Address { get; set; }
    }
    #endregion
    #region Function 4
    public class InputRegisterData
    {
        /// <summary>
        /// 數值
        /// </summary>
        public ushort[] Value { get; set; } = new ushort[1];
        /// <summary>
        /// 通訊 讀取位置
        /// </summary>
        public int Address { get; set; }
    }
    #endregion
}
