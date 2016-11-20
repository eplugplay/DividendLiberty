using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;

namespace DividendLiberty
{
    public static class uti
    {
        public static Color BackColor = Color.White;
        public static Color HighlightBarColor = Color.Black;
        public static Color ForeColorSelected = Color.Yellow;
        public static Color ForeColorUnSelected = Color.Black;
        //public FileTypes filetypes { get; set; }
        public static string GetFilePath(FileTypes type)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" + GetFileName(type);
            return path;
        }

        public static string GetDesktopfilePath(FileTypes type)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + GetFileName(type);
            return path;
        }

        public static string GetLocalFilePath(FileTypes type)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), GetFileName(type));
            return path;
        }

        public static string GetFileName(FileTypes type)
        {
            string returnType = "";
            switch (type)
            {
                case FileTypes.xml: returnType = "DividendLibertyStocks.xml"; break;
                case FileTypes.cache: returnType = "DividendLibertyCache.xml"; break;
                case FileTypes.ini: returnType = "DividendLibertyConfig.ini"; break;
                case FileTypes.excel: returnType = "DividendLiberty.xls"; break;
                default: break;
            }
            return returnType;
        }

        public static void SaveIniFile(string section, string key, string keyValue)
        {
            INIFile iniFile = new INIFile(GetFilePath(FileTypes.ini));
            iniFile.Write(section, key, keyValue);
        }

        public static string ReadIniFile(string section, string key)
        {
            INIFile iniFile = new INIFile(GetFileName(FileTypes.ini));
            return iniFile.Read(section, key);
        }

        public static DataTable GetXMLData(FileTypes fileType)
        {
            DataSet dtXML = new DataSet();
            dtXML.ReadXml(uti.GetFilePath(fileType));
            DataTable dt = new DataTable();
            if (dtXML.Tables.Count > 1)
            {
                dt = dtXML.Tables[1];
            }
            return dt;
        }

        public static int IncrementStockID(FileTypes fileType)
        {
            DataTable dt = uti.GetXMLData(fileType);
            int count = dt.Rows.Count + 1;
            return count;
        }

        public static bool ValidateStock(string symbol)
        {
            DataTable dt = uti.GetXMLData(FileTypes.xml);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["symbol"].ToString() == symbol.ToUpper())
                {
                    return true;
                }
            }
            return false;
        }

        public static bool DividendStatsValid(List<int> lst)
        {
            if (lst.Count == 1)
            {
                return true;
            }
            return false;
        }

        public static List<StockInfo> LoadStockInfo(string id, string symbol, string name, string industry, string shares, string cost, string exDiv, string payDate, string interval)
        {
            List<StockInfo> lst = new List<StockInfo>();
            StockInfo stockInfo = new StockInfo();
            stockInfo.ID = id;
            stockInfo.Symbol = symbol;
            stockInfo.Name = name;
            stockInfo.Industry = industry;
            stockInfo.Shares = shares;
            stockInfo.Cost = cost;
            stockInfo.ExDiv = exDiv;
            stockInfo.PayDate = payDate;
            stockInfo.Interval = interval;
            lst.Add(stockInfo);
            return lst;
        }

        public static void ChangedListViewItemBold(ListView lv, int i, bool bold, bool useSubItems)
        {
            ListViewItem lvi = (ListViewItem)lv.Items[i];
            lvi.UseItemStyleForSubItems = useSubItems;
                for (int a = 0; a < lv.Columns.Count; a++)
                {
                    lvi.SubItems[a].Font = new System.Drawing.Font(lv.Font, bold == true ? FontStyle.Bold : FontStyle.Regular);
                }
                //if (useSubItems == false)
                //{
                //    lv.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                //    lv.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);
                //    lv.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.ColumnContent);
                //    lv.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                //    lv.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.ColumnContent);
                //    lv.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.HeaderSize);
                //    lv.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.ColumnContent);
                //    lv.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize);
                //    lv.AutoResizeColumn(10, ColumnHeaderAutoResizeStyle.ColumnContent);
                //    lv.AutoResizeColumn(10, ColumnHeaderAutoResizeStyle.HeaderSize);
                //    lv.AutoResizeColumn(11, ColumnHeaderAutoResizeStyle.ColumnContent);
                //    lv.AutoResizeColumn(11, ColumnHeaderAutoResizeStyle.HeaderSize);

                //}
            lvi.UseItemStyleForSubItems = !useSubItems;
        }

        public static void ClearListViewColors(ListView lv)
        {
            for (int i = 0; i < lv.Items.Count; i++)
            {
                lv.InvokeEx(x => x.Items[i].BackColor = BackColor);
                lv.InvokeEx(x => x.Items[i].ForeColor = ForeColorUnSelected);
                ChangedListViewItemBold(lv, i, false, true);
            }
        }

        public static bool IsLettersOnly(string input)
        {
            if (Regex.IsMatch(input, @"^[a-zA-Z]+$"))
            {
                return true;
            }
            return false;
        }

        public static void SetStockIndexSymbol(ListView lv)
        {
            for (int i = 0; i < lv.SelectedItems.Count; i++)
            {
                Program.MainMenu.SelectedIndex = lv.SelectedItems[i].Index;
            }
            //Program.MainMenu.SelectedIndex = lv.SelectedItems[0].Index;
            Program.MainMenu.Symbol = lv.Items[Program.MainMenu.SelectedIndex].SubItems[1].Text;
        }

        public static decimal GetDivPrice(decimal shares, decimal annualDiv)
        {
            decimal toReturn = (shares * annualDiv);
            return toReturn;
        }

        public static string[] SplitStockData(string val)
        {
            string[] split = val.Split('\n');
            return split;
        }

        public static string[] SplitCommaDelStockData(string val)
        {
            string[] split = val.Split(',');
            return split;
        }

        public static string GetStockSymbols(DataTable dt, string delimited, bool all, bool active)
        {
            string symbols = "";
            int count = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (all)
                {
                    symbols += dt.Rows[i]["symbol"].ToString() + delimited;
                }
                else
                {
                    if (Convert.ToBoolean(dt.Rows[i]["active"]) == active)
                    {
                        symbols += dt.Rows[i]["symbol"].ToString() + delimited;
                    }
                }
                count++;
            }
            return symbols = symbols.Substring(0, symbols.Length != 0 ? symbols.Length - 1 : symbols.Length);
        }

        public static string GetIds(DataTable dt)
        {
            string ids = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ids += dt.Rows[i]["id"].ToString() + ",";
            }
            return ids = ids.Substring(0, ids.Length - 1);
        }

        public static decimal GetTotalSectorCount(List<decimal> lst)
        {
            decimal sectorCount = 0;
            for (int i = 0; i < lst.Count; i++)
            {
                sectorCount += lst[i];
            }
            return sectorCount;
        }

        public static DataTable SortDataTable(DataTable dt, string col, string order)
        {
            DataView view = dt.DefaultView;
            view.Sort = col + " " + order;
            DataTable dtXml = view.ToTable();
            return dtXml;
        }

        public static DataTable FilterDataTable(DataTable dt, string symbol)
        {
            DataTable dtToReturn = new DataTable();
            dtToReturn = dt.Clone();
            string[] symbols = symbol.Split(',');
            for (int a = 0; a < symbols.Length; a++)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["symbol"].ToString() == symbols[a])
                    {
                        DataRow dr = dtToReturn.NewRow();
                        dr.ItemArray = dt.Rows[i].ItemArray;
                        dtToReturn.Rows.Add(dr);
                    }
                }
            }
            return dtToReturn;
        }

        public static string[] GetColValues(DataTable dt, string col)
        {
            string[] arr = new string[dt.Rows.Count];
            for (int a = 0; a < dt.Rows.Count; a++)
            {
                arr[a] = dt.Rows[a][col].ToString();
            }
            return arr;
        }

        public static string GetExcelColLetter(int col)
        {
            string colLetter ="";
            switch(col)
            {
                case 0: colLetter = "A"; break;
                case 1: colLetter = "B"; break;
                case 2: colLetter = "C"; break;
                case 3: colLetter = "D"; break;
                case 4: colLetter = "E"; break;
                case 5: colLetter = "F"; break;
                case 6: colLetter = "G"; break;
                case 7: colLetter = "H"; break;
                case 8: colLetter = "I"; break;
                case 9: colLetter = "J"; break;
                case 10: colLetter = "K"; break;
                default: break;
            }
            return colLetter;
        }

        public static void ExportXML(string path)
        {
            DataTable xmlData = uti.GetXMLData(FileTypes.xml);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.AppendLine("<DocumentElement>");
            sb.AppendLine("<dividendstocks>");
            for (int i = 0; i < xmlData.Rows.Count; i++)
            {
                sb.AppendLine(string.Format("<dividendstock ID=\"{0}\">", xmlData.Rows[i]["id"].ToString()));
                sb.AppendLine(string.Format("<id>{0}</id>", xmlData.Rows[i]["id"].ToString()));
                sb.AppendLine(string.Format("<symbol>{0}</symbol>", xmlData.Rows[i]["symbol"].ToString()));
                sb.AppendLine(string.Format("<industry>{0}</industry>", xmlData.Rows[i]["industry"].ToString()));
                sb.AppendLine(string.Format("<active>{0}</active>", xmlData.Rows[i]["active"].ToString()));
                sb.AppendLine(string.Format("<interval>{0}</interval>", xmlData.Rows[i]["interval"].ToString()));
                sb.AppendLine(string.Format("<cost>{0}</cost>", xmlData.Rows[i]["cost"].ToString()));
                sb.AppendLine(string.Format("<purchasedate>{0}</purchasedate>", xmlData.Rows[i]["purchasedate"].ToString()));
                sb.AppendLine(string.Format("<shares>{0}</shares>", xmlData.Rows[i]["shares"].ToString()));
                sb.AppendLine(string.Format("<nexttobuy>{0}</nexttobuy>", xmlData.Rows[i]["nexttobuy"].ToString()));
                sb.AppendLine("</dividendstock>");
            }
            sb.AppendLine("</dividendstocks>");
            sb.AppendLine("</DocumentElement>");
            File.WriteAllText(path, sb.ToString());
        }

        public static void ImportXML(string newXMLPath)
        {
            try
            {
                File.Copy(newXMLPath, uti.GetFilePath(FileTypes.xml), true);
            }
            catch
            {

            }
        }

        public static string GetExportPath()
        {
            string ToBeReturned;
            Program.MainMenu.saveFileDialog1.DefaultExt = "*.xml";
            Program.MainMenu.saveFileDialog1.Filter = "Excel File (*.xml)|*.xml|All files (*.*)|*.*";
            Program.MainMenu.saveFileDialog1.FileName = uti.GetFileName(FileTypes.xml);
            if (Program.MainMenu.saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ToBeReturned = Program.MainMenu.saveFileDialog1.FileName;
            }
            else
            {
                ToBeReturned = string.Empty;
            }
            return ToBeReturned;
        }

        public static string GetImportPath()
        {
            string ToBeReturned;
            Program.MainMenu.openFileDialog1.DefaultExt = "*.xml";
            Program.MainMenu.openFileDialog1.Filter = "Excel File (*.xml)|*.xml|All files (*.*)|*.*";
            Program.MainMenu.openFileDialog1.FileName = uti.GetFileName(FileTypes.xml);
            if (Program.MainMenu.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ToBeReturned = Program.MainMenu.openFileDialog1.FileName;
            }
            else
            {
                ToBeReturned = string.Empty;
            }
            return ToBeReturned;
        }

        public static string GenerateFullResultMsg(string[] msg, int divider)
        {
            string finalMsg = "";
            for (int i = 0; i < divider; i++)
            {
                finalMsg += msg[i];
                if(i == divider - 1)
                {
                    finalMsg += msg[i + 1];
                }
            }
            return finalMsg;
        }
    }

    public enum FileTypes
    {
        xml,
        cache,
        ini,
        excel,
    }

    public static class ISynchronizeInvokeExtensions
    {
        public static void InvokeEx<T>(this T @this, Action<T> action) where T : ISynchronizeInvoke
        {
            if (@this.InvokeRequired)
            {
                @this.Invoke(action, new object[] { @this });
            }
            else
            {
                action(@this);
            }
        }
    }
}
