using NModbus;
using PLC_Slave_System.configuration;
using PLC_Slave_System.Enums;
using PLC_Slave_System.Protocols;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Threading;

namespace PLC_Slave_System.Components
{
    public partial class TCPSlaveComponent : AbsComponent
    {
        /// <summary>
        /// 設備名稱
        /// </summary>
        private string Name { get; set; } = string.Empty;
        private PLCData data { get; set; } = null;
        public TCPSlaveComponent(SIDSetting sIDSetting, List<AbsProtocol> protocols, ModbusFactory factory, TcpListener SlaveTcpListener, IModbusSlaveNetwork Network)
        {
            InitializeComponent();
            SIDSetting = sIDSetting;
            AbsProtocols = protocols;
            Factory = factory;
            slaveTcpListener = SlaveTcpListener;
            network = Network;
        }

        public TCPSlaveComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        protected override void AfterMyWorkStateChanged(object sender, EventArgs e)
        {
            if (myWorkState)
            {
                slave = Factory.CreateSlave((byte)SIDSetting.ID);//設定ID
                network.AddSlave(slave);//開啟通訊 (每個Function 都開到最大 65535 無法修改)
                ReadThread = new Thread(Analysis);
                ReadThread.Start();
            }
            else
            {
                if (ReadThread != null)
                {
                    ReadThread.Abort();
                }
                if (slave != null)
                {
                    slave = null;
                }
            }
        }
        private void Analysis()
        {
            while (myWorkState)
            {
                TimeSpan timeSpan = DateTime.Now.Subtract(ReadTime);
                if (timeSpan.TotalSeconds >= 1)
                {
                    foreach (var Pointitem in SIDSetting.PointSettings)
                    {
                        if (Name != Pointitem.DeviceName)
                        {
                            Name = Pointitem.DeviceName;
                            data = (PLCData)AbsProtocols.SingleOrDefault(g => g.Name == Pointitem.DeviceName);
                        }
                        if (data != null)
                        {
                            SFunctionTypeEnum = (FunctionTypeEnum)Pointitem.SlaveFunction;
                            switch (SFunctionTypeEnum)
                            {
                                case FunctionTypeEnum.Colis:
                                    {
                                        FunctionMethod(Pointitem, data);
                                    }
                                    break;
                                case FunctionTypeEnum.Discret:
                                    {
                                        FunctionMethod(Pointitem, data);
                                    }
                                    break;
                                case FunctionTypeEnum.HoldingRegister:
                                    {
                                        FunctionMethod(Pointitem, data);
                                    }
                                    break;
                                case FunctionTypeEnum.InputRegister:
                                    {
                                        FunctionMethod(Pointitem, data);
                                    }
                                    break;
                            }
                        }
                        ReadTime = DateTime.Now;
                    }
                }
                else
                {
                    Thread.Sleep(80);
                }
            }
        }
        private void FunctionMethod(SPointSetting item, PLCData data)
        {
            RFunctionTypeEnum = (FunctionTypeEnum)item.ReadFunction;
            switch (RFunctionTypeEnum)
            {
                case FunctionTypeEnum.Colis:
                    {
                        var ColisData = data.ColisDatas.SingleOrDefault(g => g.Address == item.ReadAddress);
                        if (ColisData != null)
                        {
                            slave.DataStore.CoilDiscretes.WritePoints(Convert.ToUInt16(item.SlaveAddress - 1), ColisData.Value);
                        }
                    }
                    break;
                case FunctionTypeEnum.Discret:
                    {
                        var DiscreteData = data.DiscreteDatas.SingleOrDefault(g => g.Address == item.ReadAddress);
                        if (DiscreteData != null)
                        {
                            slave.DataStore.CoilInputs.WritePoints(Convert.ToUInt16(item.SlaveAddress - 1), DiscreteData.Value);
                        }
                    }
                    break;
                case FunctionTypeEnum.HoldingRegister:
                    {
                        var HoldingRegisterData = data.HoldingRegisterDatas.SingleOrDefault(g => g.Address == item.ReadAddress);
                        if (HoldingRegisterData != null)
                        {
                            slave.DataStore.HoldingRegisters.WritePoints(Convert.ToUInt16(item.SlaveAddress - 1), HoldingRegisterData.Value);
                        }
                    }
                    break;
                case FunctionTypeEnum.InputRegister:
                    {
                        var InputRegisterData = data.InputRegisterDatas.SingleOrDefault(g => g.Address == item.ReadAddress);
                        if (InputRegisterData != null)
                        {
                            slave.DataStore.InputRegisters.WritePoints(Convert.ToUInt16(item.SlaveAddress - 1), InputRegisterData.Value);
                        }
                    }
                    break;
            }
        }
    }
}
