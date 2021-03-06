using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using PLC_Slave_System.configuration;
using Serilog;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PLC_Slave_System.Methods
{
    public class ExcelMethod
    {
        /// <summary>
        /// 開啟檔案
        /// </summary>
        private OpenFileDialog openFileDialog { get; set; }
        /// <summary>
        /// 載入檔案
        /// </summary>
        private XSSFWorkbook xworkbook { get; set; }
        /// <summary>
        /// 分頁數量
        /// </summary>
        private int SheetIndex { get; set; } = 0;
        /// <summary>
        /// 檔案名稱
        /// </summary>
        private string FileName { get; set; }
        /// <summary>
        /// 設備讀取資訊
        /// </summary>
        public PLCSetting PLCSetting { get; set; }
        /// <summary>
        /// Slave讀取資訊
        /// </summary>
        public TCPSlaveSetting TCPSlaveSetting { get; set; }
        public bool Excel_Load()
        {
            PLCSetting = new PLCSetting();
            TCPSlaveSetting = new TCPSlaveSetting();
            try
            {
                openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "*.Xlsx| *.xlsx";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = openFileDialog.FileName.Split('\\')[openFileDialog.FileName.Split('\\').Length - 1];
                    using (FileStream file = new FileStream($"{openFileDialog.FileName}", FileMode.Open, FileAccess.Read))
                    {
                        xworkbook = new XSSFWorkbook(file);//Excel檔案載入
                    }
                    SheetIndex = xworkbook.NumberOfSheets;//取得分頁數量
                    for (int Sheetnum = 0; Sheetnum < SheetIndex; Sheetnum++)
                    {
                        string SheetName = xworkbook.GetSheetName(Sheetnum).Trim();
                        if (SheetName == "IP")
                        {
                            var data = xworkbook.GetSheetAt(Sheetnum);//載入分頁資訊
                            for (int Rownum = 1; Rownum < data.LastRowNum + 1; Rownum++)
                            {
                                IRow row = data.GetRow(Rownum);
                                if (row != null)
                                {
                                    ICell IP = row.GetCell(0);
                                    string[] IPstr = IP.ToString().Split(',');
                                    ICell Port = row.GetCell(1);
                                    string[] Portstr = Port.ToString().Split(',');
                                    ICell ID = row.GetCell(2);
                                    string[] IDstr = ID.ToString().Split(',');
                                    ICell DeviceName = row.GetCell(3);
                                    ICell Function = row.GetCell(4);
                                    ICell Address = row.GetCell(5);
                                    ICell Quantity = row.GetCell(6);
                                    #region IP資訊整合
                                    IPSetting iP = null;
                                    if (IPstr.Length == Portstr.Length && Portstr.Length == IDstr.Length)
                                    {
                                        if (PLCSetting.IPSettings.Count > 0)
                                        {
                                            iP = PLCSetting.IPSettings.SingleOrDefault(g => g.Name == DeviceName.ToString());
                                            if (iP == null)
                                            {
                                                iP = new IPSetting();
                                                iP.Location = IPstr;
                                                for (int i = 0; i < Portstr.Length; i++)
                                                {
                                                    iP.port[i] = Convert.ToInt32(Portstr[i]);
                                                    iP.ID[i] = Convert.ToInt32(IDstr[i]);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            iP = new IPSetting();
                                            iP.Name = DeviceName.ToString();
                                            iP.Location = IPstr;
                                            iP.port = new int[iP.Location.Length];
                                            iP.ID = new int[iP.Location.Length];
                                            for (int i = 0; i < Portstr.Length; i++)
                                            {
                                                iP.port[i] = Convert.ToInt32(Portstr[i]);
                                                iP.ID[i] = Convert.ToInt32(IDstr[i]);
                                            }
                                        }
                                        #endregion
                                        #region 點位資訊整合
                                        PointSetting point = null;
                                        if (iP.PointSettings.Count > 0)
                                        {
                                            point = iP.PointSettings.SingleOrDefault(g => g.ReadAddress == Convert.ToInt32(Address.ToString()));
                                            if (point == null)
                                            {
                                                point = new PointSetting()
                                                {
                                                    ReadAddress = Convert.ToInt32(Address.ToString()),
                                                    ReadFunction = Convert.ToInt32(Function.ToString()),
                                                    ReadQuantity = Convert.ToInt32(Quantity.ToString())
                                                };
                                                iP.PointSettings.Add(point);
                                            }
                                        }
                                        else
                                        {
                                            point = new PointSetting()
                                            {
                                                ReadAddress = Convert.ToInt32(Address.ToString()),
                                                ReadFunction = Convert.ToInt32(Function.ToString()),
                                                ReadQuantity = Convert.ToByte(Quantity.ToString())
                                            };
                                            iP.PointSettings.Add(point);
                                        }
                                        #endregion
                                        var iPSetting = PLCSetting.IPSettings.SingleOrDefault(g => g.Name == DeviceName.ToString());
                                        if (iPSetting != null)
                                        {
                                            iPSetting = iP;
                                        }
                                        else
                                        {
                                            PLCSetting.IPSettings.Add(iP);
                                        }
                                    }
                                }
                            }
                            InitialMethod.Save_PLC(PLCSetting);
                        }
                        else
                        {
                            #region Slave IP整合
                            SIPSetting sIP = null;
                            string[] Location = SheetName.Split(',');
                            if (TCPSlaveSetting.IPSettings.Count > 0)
                            {
                                sIP = TCPSlaveSetting.IPSettings.SingleOrDefault(g => g.Location == Location[0].Trim() & g.port == Convert.ToInt32(Location[1].Trim()));
                                if (sIP == null)
                                {
                                    sIP = new SIPSetting()
                                    {
                                        Location = Location[0].Trim(),
                                        port = Convert.ToInt32(Location[1].Trim()),
                                    };
                                }
                            }
                            else
                            {
                                sIP = new SIPSetting()
                                {
                                    Location = Location[0].Trim(),
                                    port = Convert.ToInt32(Location[1].Trim()),
                                };
                            }
                            #endregion
                            #region Slave ID整合
                            SIDSetting sID = null;
                            if (sIP.IDSettings.Count > 0)
                            {
                                sID = sIP.IDSettings.SingleOrDefault(g => g.ID == Convert.ToByte(SheetName.Split(',')[1].Trim()));
                                if (sID == null)
                                {
                                    sID = new SIDSetting()
                                    {
                                        ID = Convert.ToByte(Location[2].Trim())
                                    };
                                    sIP.IDSettings.Add(sID);
                                }
                            }
                            else
                            {
                                sID = new SIDSetting()
                                {
                                    ID = Convert.ToByte(Location[2].Trim())
                                };
                                sIP.IDSettings.Add(sID);
                            }
                            #endregion
                            var data = xworkbook.GetSheetAt(Sheetnum);//載入分頁資訊
                            for (int Rownum = 1; Rownum < data.LastRowNum + 1; Rownum++)
                            {
                                IRow row = data.GetRow(Rownum);
                                if (row != null)
                                {
                                    ICell SAddress = row.GetCell(0);
                                    ICell SFunction = row.GetCell(1);
                                    ICell DeviceName = row.GetCell(2);
                                    ICell DFunction = row.GetCell(3);
                                    ICell DAddress = row.GetCell(4);
                                    #region 點位整合
                                    SPointSetting point = null;
                                    if (sID.PointSettings.Count > 0)
                                    {
                                        point = sID.PointSettings.SingleOrDefault(g => g.SlaveFunction == Convert.ToInt32(SFunction.ToString()) & g.SlaveAddress == Convert.ToInt32(SAddress.ToString()));
                                        if (point == null)
                                        {
                                            point = new SPointSetting()
                                            {
                                                ReadFunction = Convert.ToInt32(DFunction.ToString()),
                                                ReadAddress = Convert.ToInt32(DAddress.ToString()),
                                                DeviceName = DeviceName.ToString(),
                                                SlaveAddress = Convert.ToInt32(SAddress.ToString()),
                                                SlaveFunction = Convert.ToInt32(SFunction.ToString()),
                                            };
                                            sID.PointSettings.Add(point);
                                        }
                                    }
                                    else
                                    {
                                        point = new SPointSetting()
                                        {
                                            ReadFunction = Convert.ToInt32(DFunction.ToString()),
                                            ReadAddress = Convert.ToInt32(DAddress.ToString()),
                                            DeviceName = DeviceName.ToString(),
                                            SlaveAddress = Convert.ToInt32(SAddress.ToString()),
                                            SlaveFunction = Convert.ToInt32(SFunction.ToString()),
                                        };
                                        sID.PointSettings.Add(point);
                                    }
                                    #endregion
                                }
                            }
                            TCPSlaveSetting.IPSettings.Add(sIP);
                            InitialMethod.Save_TcpSlave(TCPSlaveSetting);
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex) { Log.Error(ex, $"資料匯入失敗  檔案名稱 : {FileName}"); return false; }
        }
    }
}
