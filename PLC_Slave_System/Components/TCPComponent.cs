using PLC_Slave_System.configuration;
using PLC_Slave_System.Protocols;
using Serilog;
using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.Threading;

namespace PLC_Slave_System.Components
{
    public partial class TCPComponent : AbsComponent
    {
        public TCPComponent(IPSetting setting)
        {
            InitializeComponent();
            IPSetting = setting;
        }

        public TCPComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        protected override void AfterMyWorkStateChanged(object sender, EventArgs e)
        {
            if (myWorkState)
            {
                Factory = new NModbus.ModbusFactory();
                PLCProtocol protocol = new PLCProtocol() { IPSetting = IPSetting, Name = IPSetting.Name };
                AbsProtocol = protocol;
                ReadThread = new Thread(Analysis);
                ReadThread.Start();
            }
            else
            {
                if (ReadThread != null)
                {
                    ReadThread.Abort();
                }
            }
        }
        private void Analysis()
        {
            while (myWorkState)
            {
                TimeSpan timeSpan = DateTime.Now.Subtract(ReadTime);
                if (timeSpan.TotalSeconds >= 2)
                {
                    try
                    {
                        AbsProtocol.LocationIndex = BackupIndex;
                        using (TcpClient client = new TcpClient(IPSetting.Location[BackupIndex], IPSetting.port[BackupIndex]))
                        {
                            master = Factory.CreateMaster(client);//建立TCP通訊
                            master.Transport.Retries = 0;
                            master.Transport.ReadTimeout = 1000;
                            master.Transport.WriteTimeout = 500;
                            AbsProtocol.ReadData(master, this);
                            Thread.Sleep(10);
                            ReadTime = DateTime.Now;
                        }
                    }
                    catch (ThreadAbortException) { }
                    catch (Exception ex)
                    {
                        Log.Error(ex, $"通訊失敗 IP:{IPSetting.Location[BackupIndex]}， Port:{IPSetting.port[BackupIndex]} ");
                        if (BackupIndex >= IPSetting.Location.Length-1)
                        {
                            BackupIndex = 0;
                        }
                        else
                        {
                            if (BackupIndex < IPSetting.Location.Length-1)
                            {
                                BackupIndex++;
                            }
                        }
                        AbsProtocol.ConnectionFlag = false;
                    }
                }
                else
                {
                    Thread.Sleep(80);
                }
            }
        }
    }
}
