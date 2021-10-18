using NModbus;
using PLC_Slave_System.configuration;
using PLC_Slave_System.Enums;
using PLC_Slave_System.Protocols;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Sockets;
using System.Threading;

namespace PLC_Slave_System.Components
{
    public class AbsComponent:Component
    {
        #region 啟動初始設定
        public AbsComponent()
        {
            OnMyWorkStateChanged += new MyWorkStateChanged(AfterMyWorkStateChanged);
        }
        protected void WhenMyWorkStateChange()
        {
            OnMyWorkStateChanged?.Invoke(this, null);
        }
        public delegate void MyWorkStateChanged(object sender, EventArgs e);
        public event MyWorkStateChanged OnMyWorkStateChanged;
        /// <summary>
        /// 系統工作路徑
        /// </summary>
        protected readonly string WorkPath = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// 通訊功能啟動判斷旗標
        /// </summary>
        protected bool myWorkState;
        /// <summary>
        /// 通訊功能啟動旗標
        /// </summary>
        public bool MyWorkState
        {
            get { return myWorkState; }
            set
            {
                if (value != myWorkState)
                {
                    myWorkState = value;
                    WhenMyWorkStateChange();
                }
            }
        }
        /// <summary>
        /// 執行續工作狀態改變觸發事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void AfterMyWorkStateChanged(object sender, EventArgs e) { }
        #endregion
        #region Nmodbus物件
        /// <summary>
        /// 通訊建置類別(通用)
        /// </summary>
        public ModbusFactory Factory { get; set; }

        #region Master
        /// <summary>
        /// 通訊物件
        /// </summary>
        public IModbusMaster master { get; set; }
        #endregion

        #region Slave
        /// <summary>
        /// Slave物件 (若要多個Slaver請不要加入在這Field4Component，請在SlaveComponent內加入)
        /// </summary>
        public IModbusSlave slave;
        /// <summary>
        /// 總Slave物件 (List類型，可以加入多個 IModbusSlave物件)
        /// </summary>
        public IModbusSlaveNetwork network;
        /// <summary>
        /// IP連線通訊
        /// </summary>
        public TcpListener slaveTcpListener;
        #endregion

        #endregion
        /// <summary>
        /// 最後讀取時間
        /// </summary>
        public DateTime ReadTime { get; set; }
        /// <summary>
        /// 通訊執行緒
        /// </summary>
        public Thread ReadThread { get; set; }
        /// <summary>
        /// 備援編號
        /// </summary>
        public int BackupIndex { get; set; } = 0;
        /// <summary>
        /// 設備資訊
        /// </summary>
        public IPSetting IPSetting { get; set; }
        /// <summary>
        /// 通訊數值物件
        /// </summary>
        public AbsProtocol AbsProtocol { get; set; }
        /// <summary>
        /// Slave通訊數值物件
        /// </summary>
        public List<AbsProtocol> AbsProtocols { get; set; }
        /// <summary>
        /// Slave Tcp 資訊
        /// </summary>
        public SIDSetting SIDSetting { get; set; }
        /// <summary>
        /// Slave方法類型
        /// </summary>
        public FunctionTypeEnum SFunctionTypeEnum { get; set; }
        /// <summary>
        /// 設備方法類型
        /// </summary>
        public FunctionTypeEnum RFunctionTypeEnum { get; set; }
    }
}
