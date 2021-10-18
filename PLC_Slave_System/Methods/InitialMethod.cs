using Newtonsoft.Json;
using PLC_Slave_System.configuration;
using Serilog;
using System;
using System.IO;
using System.Text;

namespace PLC_Slave_System.Methods
{
    public class InitialMethod
    {
        /// <summary>
        /// 初始路徑
        /// </summary>
        private static string MyWorkPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory;
        #region Tcp Slave 資訊設定載入
        /// <summary>
        /// TCP Slave 資訊載入
        /// </summary>
        /// <returns></returns>
        public static TCPSlaveSetting Load_TcpSlave()
        {
            TCPSlaveSetting setting = null;
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\TcpSlave.json";
            try
            {
                if (File.Exists(SettingPath))
                {
                    string json = File.ReadAllText(SettingPath, Encoding.UTF8);
                    setting = JsonConvert.DeserializeObject<TCPSlaveSetting>(json);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, " Tcp Slave 資訊設定載入錯誤");
            }
            return setting;
        }
        /// <summary>
        /// TCP Slave 資訊儲存
        /// </summary>
        /// <param name="setting">TCP Slave 總資訊</param>
        public static void Save_TcpSlave(TCPSlaveSetting setting)
        {
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\TcpSlave.json";
            string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
            File.WriteAllText(SettingPath, output);
        }
        #endregion
        #region PLC 資訊設定載入 / 儲存
        /// <summary>
        /// PLC 資訊載入
        /// </summary>
        /// <returns></returns>
        public static PLCSetting Load_PLC()
        {
            PLCSetting setting = null;
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\PLC.json";
            try
            {
                if (File.Exists(SettingPath))
                {
                    string json = File.ReadAllText(SettingPath, Encoding.UTF8);
                    setting = JsonConvert.DeserializeObject<PLCSetting>(json);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "PLC 資訊設定載入");
            }
            return setting;
        }
        /// <summary>
        /// PLC 資訊儲存
        /// </summary>
        /// <param name="setting">PLC 總資訊</param>
        public static void Save_PLC(PLCSetting setting)
        {
            string SettingPath = $"{MyWorkPath}\\stf\\PLC.json";
            string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
            File.WriteAllText(SettingPath, output);
        }
        #endregion
        #region 按鈕Json 建檔與讀取
        /// <summary>
        /// 按鈕Json 建檔與讀取
        /// </summary>
        /// <returns></returns>
        public static ButtonSetting Load_Button()
        {
            ButtonSetting setting = null;
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\button.json";
            try
            {
                if (File.Exists(SettingPath))
                {
                    string json = File.ReadAllText(SettingPath, Encoding.UTF8);
                    setting = JsonConvert.DeserializeObject<ButtonSetting>(json);
                }
                else
                {
                    ButtonSetting Setting = new ButtonSetting()
                    {
                        //群組與列表按鈕設定
                        ButtonGroupSettings =
                        {
                            new ButtonGroupSetting()
                            {
                                // 0 = 群組，1 = 列表
                                ButtonStyle = 1,
                                //群組名稱
                                GroupName = "群組名稱",
                                // 群組標註
                                GroupTag = 0,
                                //列表按鈕設定
                                ButtonItemSettings=
                                {
                                    new ButtonItemSetting()
                                    {
                                        //列表名稱
                                        ItemName = "列表名稱",
                                        //列表標註
                                        ItemTag = 0,
                                        //控制畫面顯示
                                        ControlVisible = true
                                    }
                                }
                            }
                        }
                    };
                    setting = Setting;
                    string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
                    File.WriteAllText(SettingPath, output);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "按鈕載入失敗");
            }
            return setting;
        }
        #endregion
    }
}
