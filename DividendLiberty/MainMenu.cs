using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using DividendLiberty.Excel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace DividendLiberty
{
    public partial class MainMenu : Form
    {
        public static EditColumns _EditColumns;
        public static Dividends _Dividends;
        public bool CurrentDiv { get; set; }
        public int ID { get; set; }
        public int SelectedIndex { get; set; }
        public List<int> lstID = new List<int>();
        public string Symbol { get; set; }
        public bool MouseUp { get; set; }
        public MainMenu()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CurrentDiv = false;
            OpenDividends(false, false);
        }

        public void OpenDividends(bool edit, bool currentDiv)
        {
            List<StockInfo> lstStockInfo = new List<StockInfo>();
            PleaseWait pw = new PleaseWait();
            pw.Show();
            Application.DoEvents();
            if (_Dividends == null || _Dividends.IsDisposed)
            {
                if (edit)
                {
                    if (currentDiv)
                    {
                        if (uti.DividendStatsValid(lstID))
                        {
                            lstStockInfo = GetStockInfoList(lvCurrentDividends);
                        }
                        else
                        {
                            pw.Close();
                            return;
                        }
                    }
                    else
                    {
                        if (uti.DividendStatsValid(lstID))
                        {
                            lstStockInfo = GetStockInfoList(lvAllDividends);
                        }
                        else
                        {
                            pw.Close();
                            return;
                        }
                    }
                    _Dividends = new Dividends(edit, currentDiv, lstStockInfo);
                }
                else
                {
                    _Dividends = new Dividends(edit, currentDiv);
                }
                _Dividends.Show();
            }
            else
            {
                _Dividends.Close();
                if (edit)
                {
                    if (currentDiv)
                    {
                        if (uti.DividendStatsValid(lstID))
                        {
                            lstStockInfo = GetStockInfoList(lvCurrentDividends);
                        }
                        else
                        {
                            pw.Close();
                            return;
                        }
                    }
                    else
                    {
                        if (uti.DividendStatsValid(lstID))
                        {
                            lstStockInfo = GetStockInfoList(lvAllDividends);
                        }
                        else
                        {
                            pw.Close();
                            return;
                        }
                    }
                    _Dividends = new Dividends(edit, currentDiv, lstStockInfo);
                }
                else
                {
                    _Dividends = new Dividends(edit, currentDiv);
                }
                //if (_Dividends.WindowState == FormWindowState.Minimized)
                //{
                //    _Dividends.WindowState = FormWindowState.Normal;
                //}
                //else
                //{
                //    _Dividends.BringToFront();
                //}
                _Dividends.Show();
            }
            pw.Close();
        }

        #region backgroundworkers
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                DividendStocks.CalculateResults();
            }));
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        #endregion

        private void calculateResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (backgroundWorker1.IsBusy)
                {
                    MessageBox.Show("Please wait until data is processed.");
                    return;
                }
                backgroundWorker1.RunWorkerAsync();
            }
            catch
            {

            }
        }

        public void LoadDividends(ListView lv, string active)
        {
            DataTable dtXmlCache = uti.SortDataTable(uti.GetXMLData(FileTypes.cache), "symbol", "asc");
            DataTable dtXml = uti.SortDataTable(uti.GetXMLData(FileTypes.xml), "symbol", "asc");
            DividendStocks.LoadDividends(lv, active, dtXmlCache, dtXml, lblAnnualDividends);
            lblPortfolioTotal.Text = "$" + Math.Round(DividendStocks.GetTotalPortfolio(dtXml), 2).ToString();
            Program.PleaseWait.Close();
        }

        public void LoadCacheDividends()
        {
            if (!File.Exists(uti.GetFilePath(FileTypes.cache)))
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), uti.GetFileName(FileTypes.cache));
                File.Copy(path, uti.GetFilePath(FileTypes.cache), true);
            }

            DataTable dtXmlCache = uti.GetXMLData(FileTypes.cache);
            DataTable dtxml = uti.SortDataTable(uti.GetXMLData(FileTypes.xml), "symbol", "asc");
            if(dtXmlCache.Rows.Count > 0)
            {
                dtXmlCache = uti.SortDataTable(dtXmlCache, "symbol", "asc");
            }
            string symbolsCache = uti.GetStockSymbols(dtxml, ",", true, true);
            string ids = uti.GetIds(dtxml);
            string stockNames = YahooFinance.GetValues(symbolsCache, YahooFinance.GetCodes(YahooCodes.stockname), true);
            string exDividend = YahooFinance.GetValues(symbolsCache, YahooFinance.GetCodes(YahooCodes.exDividend), true);
            string annualDiv = YahooFinance.GetValues(symbolsCache, YahooFinance.GetCodes(YahooCodes.annualDividend), true);
            string payDates = YahooFinance.GetValues(symbolsCache, YahooFinance.GetCodes(YahooCodes.payDate), true);
            string eps = YahooFinance.GetValues(symbolsCache, YahooFinance.GetCodes(YahooCodes.eps), true);

            string divPercent = YahooFinance.GetValues(symbolsCache, YahooFinance.GetCodes(YahooCodes.dividendYield), true);
            string marketCap = YahooFinance.GetValues(symbolsCache, YahooFinance.GetCodes(YahooCodes.marketCap), true);
            string peRatio = YahooFinance.GetValues(symbolsCache, YahooFinance.GetCodes(YahooCodes.peRatio), true);
            string dayRange = YahooFinance.GetValues(symbolsCache, YahooFinance.GetCodes(YahooCodes.dayRange), true);
            string fiftyTwoWeekLow = YahooFinance.GetValues(symbolsCache, YahooFinance.GetCodes(YahooCodes.fiftyTwoWeekLow), true);
            string fiftyTwoWeekHigh = YahooFinance.GetValues(symbolsCache, YahooFinance.GetCodes(YahooCodes.fiftyTwoWeekHigh), true);
            string currentPrice= YahooFinance.GetValues(symbolsCache, YahooFinance.GetCodes(YahooCodes.currentPrice), true);
            string openPrice = YahooFinance.GetValues(symbolsCache, YahooFinance.GetCodes(YahooCodes.openPrice), true);


            DividendsCache.LoadInitialDividendCache(uti.SplitCommaDelStockData(ids), uti.SplitCommaDelStockData(symbolsCache), uti.SplitStockData(exDividend), uti.SplitStockData(annualDiv), uti.SplitStockData(payDates), uti.SplitStockData(eps), uti.SplitStockData(divPercent),
                uti.SplitStockData(stockNames), uti.SplitStockData(marketCap), uti.SplitStockData(peRatio), uti.SplitStockData(openPrice), uti.SplitStockData(currentPrice), uti.SplitStockData(fiftyTwoWeekLow), uti.SplitStockData(fiftyTwoWeekHigh), uti.SplitStockData(dayRange), dtXmlCache, dtxml);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            string result = "";
            lvAllDividends.BackColor = uti.BackColor;
            lvCurrentDividends.BackColor = uti.BackColor;
            lvAllDividends.ForeColor = uti.ForeColorUnSelected;
            lvCurrentDividends.ForeColor = uti.ForeColorUnSelected;
            ddlIndustry.SelectedIndex = 0;
            ddlIndustryAll.SelectedIndex = 0;
            dtpPayDate.Format = DateTimePickerFormat.Custom;
            dtpPayDate.CustomFormat = "MM/yyyy";
            dtpPayDate.ShowUpDown = true;
            lvAllDividends.FullRowSelect = true;
            lvCurrentDividends.FullRowSelect = true;
            //lvCurrentDividends.HideSelection = false;
            if (!File.Exists(uti.GetFilePath(FileTypes.xml)))
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), uti.GetFileName(FileTypes.xml));
                File.Copy(path, uti.GetFilePath(FileTypes.xml), true);
            }

            if (!File.Exists(uti.GetFilePath(FileTypes.ini)))
            {
                File.Copy(uti.GetLocalFilePath(FileTypes.ini), uti.GetFilePath(FileTypes.ini), true);
            }
            LoadCacheDividends();
            LoadDividends(lvCurrentDividends, "true");
            LoadDividends(lvAllDividends, "false");
            if (result != "")
            {
                MessageBox.Show(result);
            }
        }

        public void SaveExcelFileSettings()
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstID.Count != 0)
            {
                if (!CurrentDiv)
                {
                    AddRemoveDividends(lvAllDividends, "true");
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstID.Count != 0)
            {
                if (CurrentDiv)
                {
                    AddRemoveDividends(lvCurrentDividends, "false");
                    HighlightNextBuy();
                }
            }
        }

        public void UncheckNextBuy()
        {
            chkNextBuy.CheckedChanged -= chkNextBuy_CheckedChanged;
            chkNextBuy.Checked = false;
            chkNextBuy.CheckedChanged += chkNextBuy_CheckedChanged;
        }

        public void AddRemoveDividends(ListView lv, string stockActive)
        {
            PleaseWait pw = new PleaseWait();
            pw.Show();
            Application.DoEvents();
            UncheckNextBuy();
            for (int i = 0; i < lv.Items.Count; i++)
            {
                if (lstID.Contains(Convert.ToInt32(lv.Items[i].Tag)))
                {
                    DividendStocks.MoveStock(lv.Items[i].Tag.ToString(), lv.Items[i].SubItems[1].Text, stockActive);
                }
            }
            LoadDividends(lvCurrentDividends, "true");
            LoadDividends(lvAllDividends, "false");
            SelectStocks();
            pw.Close();
        }

        public void SelectStocks()
        {
            if (!CurrentDiv)
            {
                CurrentDiv = true;
                lvAllDividends.SelectedItems.Clear();
                SelectMultiple(lvCurrentDividends);
            }
            else
            {
                CurrentDiv = false;
                lvCurrentDividends.SelectedItems.Clear();
                SelectMultiple(lvAllDividends);
            }
        }

        public void SelectMultiple(ListView lv)
        {
            for (int a = 0; a < lv.Items.Count; a++)
            {
                for (int b = 0; b < lstID.Count; b++)
                {
                    if (lstID[b] == Convert.ToInt32(lv.Items[a].Tag))
                    {
                        lv.Items[a].BackColor = uti.HighlightBarColor;
                        lv.Items[a].ForeColor = uti.ForeColorSelected;
                        uti.ChangedListViewItemBold(lv, a, true, false);
                        lv.Items[a].Selected = true;
                        lv.Items[a].Focused = true;
                        lv.TopItem = lv.Items[a];
                    }
                }
            }
            lv.SelectedItems.Clear();
        }

        public int GetTagCount(List<int> lst, int tag)
        {
            int count = 0;
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i] == tag)
                {
                    count++;
                }
            }
            return count;
        }

        public List<int> RemoveTags(List<int> lst, int tag)
        {
            List<int> tempList = new List<int>();
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i] != tag)
                {
                    tempList.Add(lst[i]);
                }
            }
            return tempList;
        }

        public void HighlightMultipleControlColor(ListView lv)
        {
            int index = lv.SelectedItems[0].Index;
            int tag = Convert.ToInt32(lv.Items[index].Tag);
            lstID.Add(tag);

            if (GetTagCount(lstID, tag) == 2)
            {
                lstID = RemoveTags(lstID, tag);
            }

            lv.SelectedItems.Clear();
            for (int i = 0; i < lv.Items.Count; i++)
            {
                if (lstID.Contains(Convert.ToInt32(lv.Items[i].Tag)))
                {
                    lv.Items[i].BackColor = uti.HighlightBarColor;
                    lv.Items[i].ForeColor = uti.ForeColorSelected;
                    uti.ChangedListViewItemBold(lv, i, true, false);
                }
                if (!lstID.Contains(Convert.ToInt32(lv.Items[i].Tag)))
                {
                    lv.Items[i].BackColor = uti.BackColor;
                    lv.Items[i].ForeColor = uti.ForeColorUnSelected;
                    uti.ChangedListViewItemBold(lv, i, false, true);
                }
            }
        }

        public void HighlightAllColor(ListView lv)
        {
            lstID.Clear();
            for (int i = 0; i < lv.Items.Count; i++)
            {
                lv.Items[i].Selected = true;
                lstID.Add(Convert.ToInt32(lv.SelectedItems[i].Tag));
            }
            lv.SelectedItems.Clear();
            for (int i = 0; i < lv.Items.Count; i++)
            {
                lv.Items[i].BackColor = uti.HighlightBarColor;
                lv.Items[i].ForeColor = uti.ForeColorSelected;
            }
        }

        public void HighlightSingleColor(ListView lv)
        {
            int tag = Convert.ToInt32(lv.Items[SelectedIndex].Tag);
            lstID.Clear();
            lstID.Add(tag);
            lv.SelectedItems.Clear();
            string selectedSymbol = lv.Items[SelectedIndex].SubItems[1].Text;
            for (int i = 0; i < lv.Items.Count; i++)
            {
                if (lstID.Contains(Convert.ToInt32(lv.Items[i].Tag)))
                {
                    lv.Items[i].BackColor = uti.HighlightBarColor;
                    lv.Items[i].ForeColor = uti.ForeColorSelected;
                    uti.ChangedListViewItemBold(lv, i, true, false);
                }
                else
                {
                    lv.Items[i].BackColor = uti.BackColor;
                    lv.Items[i].ForeColor = uti.ForeColorUnSelected;
                    uti.ChangedListViewItemBold(lv, i, false, true);
                }
            }
            //for (int a = 0; a < lv.Columns.Count; a++)
            //{
            //    lv.Columns[a].TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //}
            //lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void lvCurrentDividends_MouseClick(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys != Keys.Control && Control.ModifierKeys != Keys.Shift)
            {
                uti.ClearListViewColors(lvAllDividends);
                uti.SetStockIndexSymbol(lvCurrentDividends);
                HighlightSingleColor(lvCurrentDividends);
                MouseUp = false;
            }
        }

        private void lvCurrentDividends_MouseUp(object sender, MouseEventArgs e)
        {
            var info = lvCurrentDividends.HitTest(e.X, e.Y);
            try
            {
                int s = info.Item.Index;
                if (Control.ModifierKeys == Keys.Control)
                {
                    if (CurrentDiv == false)
                    {
                        lstID.Clear();
                    }
                    uti.ClearListViewColors(lvAllDividends);
                    uti.SetStockIndexSymbol(lvCurrentDividends);
                    HighlightMultipleControlColor(lvCurrentDividends);
                    MouseUp = false;
                }
                else if (Control.ModifierKeys == Keys.Shift)
                {
                    lvCurrentDividends.SelectedItems.Clear();
                    MouseUp = false;
                    return;
                }
            }
            catch
            {
                lstID.Clear();
                uti.ClearListViewColors(lvAllDividends);
                uti.ClearListViewColors(lvCurrentDividends);
            }
            if (MouseUp)
            {
                if (Control.ModifierKeys != Keys.Control && Control.ModifierKeys != Keys.Shift)
                {
                    if (lstID.Count > 0)
                    {
                        uti.ClearListViewColors(lvAllDividends);
                        uti.SetStockIndexSymbol(lvCurrentDividends);
                        HighlightSingleColor(lvCurrentDividends);
                        MouseUp = true;
                    }
                }
            }
            CurrentDiv = true;
        }


        private void lvCurrentDividends_MouseDown(object sender, MouseEventArgs e)
        {
            MouseUp = true;
        }

        private void lvAllDividends_MouseDown(object sender, MouseEventArgs e)
        {
            MouseUp = true;
        }

        private void lvAllDividends_MouseClick(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys != Keys.Control && Control.ModifierKeys != Keys.Shift)
            {
                uti.ClearListViewColors(lvCurrentDividends);
                lstID.Clear();
                uti.SetStockIndexSymbol(lvAllDividends);
                HighlightSingleColor(lvAllDividends);
                HighlightNextBuy();
                MouseUp = false;
            }
        }

        private void lvAllDividends_MouseUp(object sender, MouseEventArgs e)
        {
            var info = lvAllDividends.HitTest(e.X, e.Y);
            try
            {
                int s = info.Item.Index;
                if (Control.ModifierKeys == Keys.Control)
                {
                    if (CurrentDiv == true)
                    {
                        lstID.Clear();
                    }
                    uti.ClearListViewColors(lvCurrentDividends);
                    uti.SetStockIndexSymbol(lvAllDividends);
                    HighlightMultipleControlColor(lvAllDividends);
                    MouseUp = false;
                }
                else if(Control.ModifierKeys == Keys.Shift)
                {
                    lvAllDividends.SelectedItems.Clear();
                    MouseUp = false;
                    return;
                }
            }
            catch
            {
                lstID.Clear();
                uti.ClearListViewColors(lvAllDividends);
                uti.ClearListViewColors(lvCurrentDividends);
            }
            if (MouseUp)
            {
                if (Control.ModifierKeys != Keys.Control && Control.ModifierKeys != Keys.Shift)
                {
                    if (lstID.Count > 0)
                    {
                        uti.ClearListViewColors(lvCurrentDividends);
                        lstID.Clear();
                        uti.SetStockIndexSymbol(lvAllDividends);
                        HighlightSingleColor(lvAllDividends);
                        HighlightNextBuy();
                        MouseUp = true;
                    }
                }
            }
            CurrentDiv = false;
        }

        private void lvCurrentDividends_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenDividends(true, CurrentDiv);
        }

        private void lvAllDividends_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenDividends(true, CurrentDiv);
        }

        private void lvCurrentDividends_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        public List<StockInfo> GetStockInfoList(ListView lv)
        {
            List<StockInfo> lst = new List<StockInfo>();
            lst = uti.LoadStockInfo(
                    lstID[0].ToString(), 
                    Symbol,
                    lv.Items[SelectedIndex].SubItems[2].Text, 
                    lv.Items[SelectedIndex].SubItems[3].Text, 
                    lv.Items[SelectedIndex].SubItems[9].Text,
                    lv.Items[SelectedIndex].SubItems[10].Text, 
                    lv.Items[SelectedIndex].SubItems[6].Text, 
                    lv.Items[SelectedIndex].SubItems[5].Text,
                    lv.Items[SelectedIndex].SubItems[6].Text);
            return lst;
        }

        public void GetDividendPrice(PleaseWait pw)
        {
            uti.ClearListViewColors(lvAllDividends);
            decimal TotalDividendPrice = 0;
            decimal QuarterlyDividendPrice = 0;
            decimal MonthlyDividendPrice = 0;
            string[] msg = new string[9999];
            int divider = DividendStocks.GetDividendPrice(lvCurrentDividends, lstID, out TotalDividendPrice, out QuarterlyDividendPrice, out MonthlyDividendPrice, out msg);
            pw.Close();
            string msgShow = "";
            int cnt = 1;
            if (divider > 10)
            {
                for (int i = 0; i < divider; i++)
                {
                    msgShow += msg[i];
                    if (cnt % 10 == 0)
                    {
                        MessageBox.Show(msgShow);
                        msgShow = "";
                    }
                    if (i == divider - 1)
                    {
                        if (i % 10 == 0)
                        {
                            MessageBox.Show(msgShow);
                        }
                        MessageBox.Show(msg[cnt] + "Monthly: $" + Math.Round(MonthlyDividendPrice, 2).ToString() + "\nQuarterly: $" + Math.Round(QuarterlyDividendPrice, 2) + "\nYearly: $" + Math.Round(TotalDividendPrice, 2));
                    }
                    cnt++;
                }
            }
            else
            {
                MessageBox.Show(uti.GenerateFullResultMsg(msg, divider) + "Monthly: $" + Math.Round(MonthlyDividendPrice, 2).ToString() + "\nQuarterly: $" + Math.Round(QuarterlyDividendPrice, 2) + "\nYearly: $" + Math.Round(TotalDividendPrice, 2));
            }
        }

        public void GetSharePrice(PleaseWait pw)
        {
            uti.ClearListViewColors(lvAllDividends);
            decimal totalPrice = 0;
            string[] msg = new string[9999];
            string msgShow = "";
            int cnt = 1;
            int divider = DividendStocks.GetTotalSharePrice(lstID, out totalPrice, out msg);
            pw.Close();
            if (divider > 20)
            {
                for (int i = 0; i < divider; i++)
                {
                    msgShow += msg[i];
                    if (cnt % 10 == 0)
                    {
                        MessageBox.Show(msgShow);
                        msgShow = "";
                    }
                    if (i == divider - 1)
                    {
                        if (i % 10 == 0)
                        {
                            MessageBox.Show(msgShow);
                        }
                        MessageBox.Show("Total: $" + Math.Round(totalPrice, 2).ToString());
                    }
                    cnt++;
                }
            }
            else
            {
                MessageBox.Show(uti.GenerateFullResultMsg(msg, divider) + "Total: $" + Math.Round(totalPrice, 2).ToString());
            }
        }

        private void btnHighlight_Click(object sender, EventArgs e)
        {
            CurrentDiv = true;
            DividendStocks.Highlight(lvCurrentDividends, ddlIndustry, true);
        }

        public void HighlightNextBuy()
        {
            try
            {
                if (lstID.Count == 1)
                {
                    chkNextBuy.CheckedChanged -= chkNextBuy_CheckedChanged;
                    chkNextBuy.Checked = DividendStocks.LoadNextPurchase(Symbol) == "yes" ? true : false;
                    chkNextBuy.CheckedChanged += chkNextBuy_CheckedChanged;
                }
            }
            catch
            {

            }
        }

        private void btnHighlightAll_Click(object sender, EventArgs e)
        {
            CurrentDiv = false;
            DividendStocks.Highlight(lvAllDividends, ddlIndustryAll, true);
        }

        private void txtSearchSymbol_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchSymbol.Text != "")
            {
                lstID.Clear();
                CurrentDiv = true;
                uti.ClearListViewColors(lvAllDividends);
                uti.ClearListViewColors(lvCurrentDividends);
                DividendStocks.SearchSymbol(txtSearchSymbol, lvCurrentDividends);
            }
            else
            {
                uti.ClearListViewColors(lvCurrentDividends);
            }
        }

        private void txtSearchAllSymbol_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchAllSymbol.Text != "")
            {
                lstID.Clear();
                CurrentDiv = false;
                uti.ClearListViewColors(lvAllDividends);
                uti.ClearListViewColors(lvCurrentDividends);
                DividendStocks.SearchSymbol(txtSearchAllSymbol, lvAllDividends);
            }
            else
            {
                uti.ClearListViewColors(lvAllDividends);
            }
        }

        private void chkNextBuy_CheckedChanged(object sender, EventArgs e)
        {
            if (!CurrentDiv)
            {
                if (lstID.Count == 0)
                {
                    UncheckNextBuy();
                    MessageBox.Show("Please select a stock.");
                    return;
                }
                if (lstID.Count <= 1)
                {
                    if (chkNextBuy.Checked)
                    {
                        DividendStocks.SaveNextPurchase(Convert.ToInt32(lstID[0]), "yes", Symbol);
                    }
                    else
                    {
                        DividendStocks.SaveNextPurchase(Convert.ToInt32(lstID[0]), "no", Symbol);
                    }
                }
                else
                {
                    UncheckNextBuy();
                    MessageBox.Show("Please select one stock at a time.");
                }
            }
            else
            {
                UncheckNextBuy();
                MessageBox.Show("Please select one stock in the non portfolio section.");
            }
        }

        private void btnPayDate_Click(object sender, EventArgs e)
        {
            if (lvCurrentDividends.Items[0].SubItems[5].ToString() == "")
            {
                return;
            }
            CurrentDiv = true;
            uti.ClearListViewColors(Program.MainMenu.lvAllDividends);
            DividendStocks.HighlightPayDate(lvCurrentDividends);
        }

        private void lvAllDividends_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void getCostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PleaseWait pw = new PleaseWait();
            pw.Show();
            Application.DoEvents();
            try
            {
                GetSharePrice(pw);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in calculating. Please try again.");
            }
        }

        private void getDividendsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PleaseWait pw = new PleaseWait();
            pw.Show();
            Application.DoEvents();
            try
            {
                GetDividendPrice(pw);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in calculating. Please try again.");
            }
        }

        private void showSectorPercentagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           DividendStocks.ShowIndustryPercentages(lvCurrentDividends);
        }

        private void highlightNextPurchasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentDiv = false;
            DividendStocks.HighlightAllNextToBuy(lvAllDividends);
        }

        private void showPercentagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DividendStocks.ShowIndustryPercentages(lvAllDividends);
        }

        private void generateExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
                PortfolioExcel.GeneratePortfolioExcel();
        }

        private void editColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_EditColumns == null || _EditColumns.IsDisposed)
            {
                _EditColumns = new EditColumns();
                _EditColumns.Show();
            }
            else
            {
                if (_EditColumns.WindowState == FormWindowState.Minimized)
                {
                    _EditColumns.WindowState = FormWindowState.Normal;
                }
                else
                {
                    _EditColumns.BringToFront();
                }
            }
        }

        private void lvAllDividends_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OpenDividends(true, CurrentDiv);
                return;
            }
            if (e.KeyCode == Keys.Up && Control.ModifierKeys == Keys.Control || e.KeyCode == Keys.Down && Control.ModifierKeys == Keys.Control)
            {
                return;
            }
            if (e.KeyCode == Keys.Up && Control.ModifierKeys != Keys.Shift || e.KeyCode == Keys.Down && Control.ModifierKeys != Keys.Shift)
            {
                uti.ClearListViewColors(lvCurrentDividends);
                uti.ClearListViewColors(lvAllDividends);
                uti.SetStockIndexSymbol(lvAllDividends);
                HighlightSingleColor(lvAllDividends);
                HighlightNextBuy();
            }
        }

        private void lvCurrentDividends_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OpenDividends(true, CurrentDiv);
                return;
            }
            if (e.KeyCode == Keys.Up && Control.ModifierKeys == Keys.Control || e.KeyCode == Keys.Down && Control.ModifierKeys == Keys.Control)
            {
                return;
            }
            if (e.KeyCode == Keys.Up && Control.ModifierKeys != Keys.Shift || e.KeyCode == Keys.Down && Control.ModifierKeys != Keys.Shift)
            {
                uti.ClearListViewColors(lvAllDividends);
                uti.ClearListViewColors(lvCurrentDividends);
                uti.SetStockIndexSymbol(lvCurrentDividends);
                HighlightSingleColor(lvCurrentDividends);
            }
        }

        private void lvAllDividends_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && Control.ModifierKeys == Keys.Shift || e.KeyCode == Keys.Down && Control.ModifierKeys == Keys.Shift
                || e.KeyCode == Keys.Up && Control.ModifierKeys == Keys.Control || e.KeyCode == Keys.Down && Control.ModifierKeys == Keys.Control)
            {
                e.Handled = true;
            }
        }

        private void lvCurrentDividends_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && Control.ModifierKeys == Keys.Shift || e.KeyCode == Keys.Down && Control.ModifierKeys == Keys.Shift
                || e.KeyCode == Keys.Up && Control.ModifierKeys == Keys.Control || e.KeyCode == Keys.Down && Control.ModifierKeys == Keys.Control)
            {
                e.Handled = true;
            }
            if (e.Control && e.KeyCode == Keys.A)
            {
                HighlightAllColor(lvCurrentDividends);
            }
        }

        private void exportStocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = uti.GetExportPath();
            if (path != "")
            {
                PleaseWait pw = new PleaseWait();
                pw.Show();
                Application.DoEvents();
                uti.ExportXML(path);
                pw.Close();
                MessageBox.Show("Successfully Exported!");
            }
        }



        private void importStocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = uti.GetImportPath();
            if (path != "")
            {
                PleaseWait pw = new PleaseWait();
                pw.Show();
                Application.DoEvents();
                uti.ImportXML(path);
                string cachePath = Path.Combine(Directory.GetCurrentDirectory(), uti.GetFileName(FileTypes.cache));
                File.Copy(cachePath, uti.GetFilePath(FileTypes.cache), true);
                //if (File.Exists(uti.GetFilePath(FileTypes.cache)))
                //{
                    //string pathCache = uti.GetFilePath(FileTypes.cache);
                    //File.Delete(pathCache);
                    LoadCacheDividends();
                    LoadDividends(lvAllDividends, "false");
                    LoadDividends(lvCurrentDividends, "true");
                    pw.Close();
                    MessageBox.Show("Successfully Imported!");
                //}
            }
        }

        private void reloadYahooStockInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PleaseWait pw = new PleaseWait();
            pw.Show();
            Application.DoEvents();
            LoadCacheDividends();
            LoadDividends(lvAllDividends, "false");
            LoadDividends(lvCurrentDividends, "true");
            pw.Close();
        }
    }
}
