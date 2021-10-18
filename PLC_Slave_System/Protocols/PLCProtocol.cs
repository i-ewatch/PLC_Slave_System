using NModbus;
using PLC_Slave_System.Enums;
using Serilog;
using System;
using System.Linq;
using System.Threading;

namespace PLC_Slave_System.Protocols
{
    public class PLCProtocol : PLCData
    {
        public override void ReadData(IModbusMaster master, int LocationIndex)
        {
            try
            {
                this.LocationIndex = LocationIndex;
                int Index = 0;
                foreach (var Pointitem in IPSetting.PointSettings)
                {
                    FunctionTypeEnum = (FunctionTypeEnum)Pointitem.ReadFunction;
                    switch (FunctionTypeEnum)
                    {
                        case FunctionTypeEnum.Colis:
                            {
                                Index = 0;
                                bool[] value = master.ReadCoils(Convert.ToByte(IPSetting.ID), Convert.ToUInt16(Pointitem.ReadAddress-1), Convert.ToUInt16(Pointitem.ReadQuantity));
                                foreach (bool item in value)
                                {
                                    if (ColisDatas.Count > 0)
                                    {
                                        var data = ColisDatas.SingleOrDefault(g => g.Address == Pointitem.ReadAddress + Index);
                                        if (data != null)
                                        {
                                            data.Value[0] = item;
                                        }
                                        else
                                        {
                                            ColisData colisData = new ColisData()
                                            {
                                                Address = Convert.ToByte(Pointitem.ReadAddress + Index),
                                            };
                                            ColisDatas.Add(colisData);
                                            colisData.Value[0] = item;
                                        }
                                    }
                                    else
                                    {
                                        ColisData colisData = new ColisData()
                                        {
                                            Address = Convert.ToByte(Pointitem.ReadAddress+ Index),
                                        };
                                        ColisDatas.Add(colisData);
                                        colisData.Value[0] = item;
                                    }
                                    Index++;
                                }
                            }
                            break;
                        case FunctionTypeEnum.Discret:
                            {
                                Index = 0;
                                bool[] value = master.ReadInputs(Convert.ToByte(IPSetting.ID), Convert.ToUInt16(Pointitem.ReadAddress-1), Convert.ToUInt16(Pointitem.ReadQuantity));
                                foreach (bool item in value)
                                {
                                    if (DiscreteDatas.Count > 0)
                                    {
                                        var data = DiscreteDatas.SingleOrDefault(g => g.Address == Pointitem.ReadAddress + Index);
                                        if (data != null)
                                        {
                                            data.Value[0] = item;
                                        }
                                        else
                                        {
                                            DiscreteData discreteData = new DiscreteData()
                                            {
                                                Address = Convert.ToByte(Pointitem.ReadAddress + Index),
                                            };
                                            DiscreteDatas.Add(discreteData);
                                            discreteData.Value[0] = item;
                                        }
                                    }
                                    else
                                    {
                                        DiscreteData discreteData = new DiscreteData()
                                        {
                                            Address = Convert.ToByte(Pointitem.ReadAddress + Index),
                                        };
                                        DiscreteDatas.Add(discreteData);
                                        discreteData.Value[0] = item;
                                    }
                                    Index++;
                                }
                            }
                            break;
                        case FunctionTypeEnum.HoldingRegister:
                            {
                                Index = 0;
                                ushort[] value = master.ReadHoldingRegisters(Convert.ToByte(IPSetting.ID), Convert.ToUInt16(Pointitem.ReadAddress-1), Convert.ToUInt16(Pointitem.ReadQuantity));
                                foreach (ushort item in value)
                                {
                                    if (HoldingRegisterDatas.Count > 0)
                                    {
                                        var data = HoldingRegisterDatas.SingleOrDefault(g => g.Address == Pointitem.ReadAddress + Index);
                                        if (data != null)
                                        {
                                            data.Value[0] = item;
                                        }
                                        else
                                        {
                                            HoldingRegisterData holdingRegisterData = new HoldingRegisterData()
                                            {
                                                Address = Convert.ToByte(Pointitem.ReadAddress + Index),
                                            };
                                            HoldingRegisterDatas.Add(holdingRegisterData);
                                            holdingRegisterData.Value[0] = item;
                                        }
                                    }
                                    else
                                    {
                                        HoldingRegisterData holdingRegisterData = new HoldingRegisterData()
                                        {
                                            Address = Convert.ToByte(Pointitem.ReadAddress + Index),
                                        };
                                        HoldingRegisterDatas.Add(holdingRegisterData);
                                        holdingRegisterData.Value[0] = item;
                                    }
                                    Index++;
                                }
                            }
                            break;
                        case FunctionTypeEnum.InputRegister:
                            {
                                Index = 0;
                                ushort[] value = master.ReadInputRegisters(Convert.ToByte(IPSetting.ID), Convert.ToUInt16(Pointitem.ReadAddress-1), Convert.ToUInt16(Pointitem.ReadQuantity));
                                foreach (ushort item in value)
                                {
                                    if (InputRegisterDatas.Count > 0)
                                    {
                                        var data = InputRegisterDatas.SingleOrDefault(g => g.Address == Pointitem.ReadAddress + Index);
                                        if (data != null)
                                        {
                                            data.Value[0] = item;
                                        }
                                        else
                                        {
                                            InputRegisterData inputRegisterData = new InputRegisterData()
                                            {
                                                Address = Convert.ToByte(Pointitem.ReadAddress + Index),
                                            };
                                            InputRegisterDatas.Add(inputRegisterData);
                                            inputRegisterData.Value[0] = item;
                                        }
                                    }
                                    else
                                    {
                                        InputRegisterData inputRegisterData = new InputRegisterData()
                                        {
                                            Address = Convert.ToByte(Pointitem.ReadAddress + Index),
                                        };
                                        InputRegisterDatas.Add(inputRegisterData);
                                        inputRegisterData.Value[0] = item;
                                    }
                                    Index++;
                                }
                            }
                            break;
                    }
                }
                ConnectionFlag = true;
            }
            catch (ThreadAbortException) { }
            catch (Exception ex)
            {
                ConnectionFlag = false;
                Log.Error(ex, $"設備通訊失敗 IP : {IPSetting.Location[LocationIndex]}");
            }
        }
    }
}
