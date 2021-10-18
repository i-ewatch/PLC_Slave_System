using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Navigation;
using NModbus;
using PLC_Slave_System.Components;
using PLC_Slave_System.configuration;
using PLC_Slave_System.Methods;
using PLC_Slave_System.Protocols;
using PLC_Slave_System.Views;
using Serilog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace PLC_Slave_System
{
    public partial class Form : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        #region JSON
        /// <summary>
        /// Slave 資訊
        /// </summary>
        private TCPSlaveSetting TCPSlaveSetting { get; set; }
        /// <summary>
        /// 設備資訊
        /// </summary>
        private PLCSetting PLCSetting { get; set; }
        /// <summary>
        /// 按鈕資訊
        /// </summary>
        private ButtonSetting ButtonSetting { get; set; }
        #endregion
        #region Method
        private ExcelMethod ExcelMethod { get; set; } = new ExcelMethod();
        private ButtonMethod ButtonMethod { get; set; }
        #endregion
        #region Slave
        /// <summary>
        /// 通訊建置類別(通用)
        /// </summary>
        public ModbusFactory Factory { get; set; }
        /// <summary>
        /// 總Slave物件 (List類型，可以加入多個 IModbusSlave物件)
        /// </summary>
        public List<IModbusSlaveNetwork> networks { get; set; }
        /// <summary>
        /// IP連線通訊
        /// </summary>
        public List<TcpListener> slaveTcpListeners { get; set; }
        #endregion
        #region 通訊
        /// <summary>
        /// 通訊數值物件
        /// </summary>
        private List<AbsProtocol> AbsProtocols { get; set; }
        /// <summary>
        /// 通訊物件
        /// </summary>
        private List<AbsComponent> AbsComponents { get; set; }
        /// <summary>
        /// Slave通訊物件
        /// </summary>
        private List<AbsComponent> SAbsComponents { get; set; }
        #endregion
        #region 畫面
        /// <summary>
        /// 切換畫面物件
        /// </summary>
        private NavigationFrame NavigationFrame { get; set; }
        /// <summary>
        /// 主畫面
        /// </summary>
        private MainUserControl MainUserControl { get; set; }
        /// <summary>
        /// 畫面總物件
        /// </summary>
        private List<Field4UserControl> Field4UserControls { get; set; } = new List<Field4UserControl>();
        #endregion
        public Form()
        {
            InitializeComponent();
            #region Serilog initial
            Log.Logger = new LoggerConfiguration()
                        .WriteTo.Console()
                        .WriteTo.File($"{AppDomain.CurrentDomain.BaseDirectory}\\log\\log-.txt",
                                      rollingInterval: RollingInterval.Day,
                                      outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                        .CreateLogger();        //宣告Serilog初始化
            #endregion
            ButtonSetting = InitialMethod.Load_Button();         
            NavigationFrame = new NavigationFrame() { Dock = DockStyle.Fill };
            NavigationFrame.Parent = ViewpanelControl;
            ButtonMethod = new ButtonMethod() { Form = this, navigationFrame = NavigationFrame };
            ButtonMethod.AccordionLoad(accordionControl1, ButtonSetting);
            InitialFunction();

        }
        #region 產生畫面
        private void InitialFunction()
        {
            TCPSlaveSetting = InitialMethod.Load_TcpSlave();
            PLCSetting = InitialMethod.Load_PLC();
            Field4UserControls = new List<Field4UserControl>();
            AbsProtocols = new List<AbsProtocol>();
            AbsComponents = new List<AbsComponent>();
            SAbsComponents = new List<AbsComponent>();
            networks = new List<IModbusSlaveNetwork>();
            slaveTcpListeners = new List<TcpListener>();
            NavigationFrame.Pages.Clear();

            if (PLCSetting != null)
            {
                foreach (var item in PLCSetting.IPSettings)
                {
                    TCPComponent component = new TCPComponent(item);
                    component.MyWorkState = true;
                    AbsComponents.Add(component);
                    AbsProtocols.Add(component.AbsProtocol);
                }
            }
            if (TCPSlaveSetting != null)
            {
                foreach (var item in TCPSlaveSetting.IPSettings)
                {
                    #region Slave
                    IPAddress address = new IPAddress(new byte[] { Convert.ToByte(item.Location.Split('.')[0]), Convert.ToByte(item.Location.Split('.')[1]), Convert.ToByte(item.Location.Split('.')[2]), Convert.ToByte(item.Location.Split('.')[3]) });
                    // create and start the TCP slave
                    TcpListener slaveTcpListener = new TcpListener(address, item.port);
                    slaveTcpListener.Start();//通道打開
                    slaveTcpListeners.Add(slaveTcpListener);
                    Factory = new ModbusFactory();
                    IModbusSlaveNetwork network = Factory.CreateSlaveNetwork(slaveTcpListener);
                    network.ListenAsync();//開始側聽使用
                    networks.Add(network);
                    #endregion
                    foreach (var IDitem in item.IDSettings)
                    {
                        TCPSlaveComponent component = new TCPSlaveComponent(IDitem, AbsProtocols, Factory, slaveTcpListener, network);
                        component.MyWorkState = true;
                        SAbsComponents.Add(component);
                    }
                }
            }
            timer1.Interval = 1000;
            if (PLCSetting != null)
            {
                MainUserControl = new MainUserControl(PLCSetting, AbsProtocols) { Dock = DockStyle.Fill };
                NavigationFrame.AddPage(MainUserControl);
                Field4UserControls.Add(MainUserControl);
                timer1.Enabled = true;
            }
        }
        #endregion

        #region 時間更新
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Field4UserControls.Count > 0)
            {
                Field4UserControls[ButtonMethod.ViewIndex].TextChange();
            }
        }
        #endregion

        #region Excel匯入
        private void ExcelbarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            timer1.Enabled = false;
            foreach (var item in SAbsComponents)
            {
                item.MyWorkState = false;
            }
            foreach (var item in AbsComponents)
            {
                item.MyWorkState = false;
            }
            if (slaveTcpListeners.Count > 0)
            {
                foreach (var item in slaveTcpListeners)
                {
                    item.Stop();
                }
            }
            if (networks.Count > 0)
            {
                foreach (var item in networks)
                {
                    item.Dispose();
                }
            }
            if (ExcelMethod.Excel_Load())
            {
                FlyoutAction action = new FlyoutAction();
                action.Caption = "設備資料匯入";
                action.Description = "匯入完成，軟體重新啟動!!";
                action.Commands.Add(FlyoutCommand.OK);
                FlyoutDialog.Show(FindForm(), action);
                Application.Restart();
            }
            else 
            {
                FlyoutAction action = new FlyoutAction();
                action.Caption = "設備資料匯入";
                action.Description = "匯入失敗!!";
                action.Commands.Add(FlyoutCommand.OK);
                FlyoutDialog.Show(FindForm(), action);
            }

        }
        #endregion

        #region 視窗產生後初始化
        private void Form_Load(object sender, EventArgs e)
        {
            Location = new Point(0, 0);
        }
        #endregion

        #region 視窗關閉時
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            foreach (var item in SAbsComponents)
            {
                item.MyWorkState = false;
            }
            foreach (var item in AbsComponents)
            {
                item.MyWorkState = false;
            }
            if (slaveTcpListeners.Count > 0)
            {
                foreach (var item in slaveTcpListeners)
                {
                    item.Stop();
                }
            }
            if (networks.Count > 0)
            {
                foreach (var item in networks)
                {
                    item.Dispose();
                }
            }
        }
        #endregion
    }
}
