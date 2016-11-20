using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace DividendLiberty
{
    public partial class Dividends : Form
    {
        public bool Edit { get; set; }
        public string ID { get; set; }
        string Symbol { get; set; }
        List<StockInfo> LstStockInfo = new List<StockInfo>();
        public Dividends(bool edit, bool currentDiv, List<StockInfo> lstStockInfo)
        {
            Edit = edit;
            Program.MainMenu.CurrentDiv = currentDiv;
            LstStockInfo = lstStockInfo;
            Symbol = lstStockInfo[0].Symbol;
            InitializeComponent();
        }

        public Dividends(bool edit, bool currentDiv)
        {
            Edit = edit;
            Program.MainMenu.CurrentDiv = currentDiv;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PleaseWait pw = new PleaseWait();
            if (!ValidateAll())
            {
                return;
            }
            if (Edit)
            {
                if (LstStockInfo[0].Symbol != txtSymbol.Text.Trim().ToUpper())
                {
                    if (uti.ValidateStock(txtSymbol.Text.Trim()))
                    {
                        MessageBox.Show(string.Format("{0} already exist.", txtSymbol.Text.ToUpper()));
                        return;
                    }
                }
                this.Hide();
                pw.Show();
                Application.DoEvents();
                uti.ClearListViewColors(Program.MainMenu.lvAllDividends);
                uti.ClearListViewColors(Program.MainMenu.lvCurrentDividends);
                DividendStocks.UpdateDividendStock(LstStockInfo[0].ID, Symbol, txtSymbol.Text, ddlIndustry.Text, ddlDividendInterval.Text, FileTypes.xml);
                DividendStocks.UpdateDividendStock(LstStockInfo[0].ID, Symbol, txtSymbol.Text, ddlIndustry.Text, ddlDividendInterval.Text, FileTypes.cache);
                DividendStocks.UpdateShare(LstStockInfo[0].ID, Symbol, txtCost.Text, txtNumberOfShares.Text, dtpPurchaseDate.Value.ToString("MM-dd-yyyy"));
                Program.MainMenu.LoadCacheDividends();
                ReloadMainDividends();
                Program.MainMenu.CurrentDiv = !Program.MainMenu.CurrentDiv;
                Program.MainMenu.SelectStocks();
                pw.Close();
                this.Close();
            }
            else
            {
                if (uti.ValidateStock(txtSymbol.Text.Trim()))
                {
                    MessageBox.Show(string.Format("{0} already exist.", txtSymbol.Text.ToUpper()));
                    return;
                }
                this.Hide();
                pw.Show();
                Application.DoEvents();
                uti.ClearListViewColors(Program.MainMenu.lvAllDividends);
                uti.ClearListViewColors(Program.MainMenu.lvCurrentDividends);
                string newID = DividendStocks.NewDividendStock(txtSymbol.Text.ToUpper(), ddlIndustry.Text, ddlDividendInterval.Text);
                DividendStocks.UpdateShare(newID, txtSymbol.Text, txtCost.Text, txtNumberOfShares.Text, dtpPurchaseDate.Value.ToString("MM-dd-yyyy"));
                AddCache(newID);
                Program.MainMenu.lstID.Clear();
                Program.MainMenu.lstID.Add(Convert.ToInt32(newID));
                Program.MainMenu.LoadCacheDividends();
                ReloadMainDividends();
                Program.MainMenu.CurrentDiv = true;
                Program.MainMenu.SelectStocks();
                pw.Close();
                this.Close();
            }
        }

        public void AddCache(string newID)
        {
            string symbolsCache = txtSymbol.Text.Trim();
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
            string currentPrice = YahooFinance.GetValues(symbolsCache, YahooFinance.GetCodes(YahooCodes.currentPrice), true);
            string openPrice = YahooFinance.GetValues(symbolsCache, YahooFinance.GetCodes(YahooCodes.openPrice), true);
            DividendsCache.AddDividendStock(newID, uti.SplitCommaDelStockData(symbolsCache), uti.SplitStockData(exDividend), uti.SplitStockData(annualDiv), uti.SplitStockData(payDates), uti.SplitStockData(eps), uti.SplitStockData(divPercent),
                uti.SplitStockData(stockNames), uti.SplitStockData(marketCap), uti.SplitStockData(peRatio), uti.SplitStockData(openPrice), uti.SplitStockData(currentPrice), uti.SplitStockData(fiftyTwoWeekLow), uti.SplitStockData(fiftyTwoWeekHigh), uti.SplitStockData(dayRange));
        }

        public void ReloadMainDividends()
        {
            if (Program.MainMenu.CurrentDiv)
            {
                Program.MainMenu.LoadDividends(Program.MainMenu.lvCurrentDividends, "true");
            }
            else
            {
                Program.MainMenu.LoadDividends(Program.MainMenu.lvAllDividends, "false");
            }
        }

        private void Dividends_Load(object sender, EventArgs e)
        {
            ddlIndustry.SelectedIndex = 0;
            if (Edit)
            {
                LoadDividendStock();
                LoadPurchaseInfo();
                btnSave.Text = "Update";
                this.Text = "Edit Dividend Stock";
            }
            else
            {
                HideTextBoxes();
                //gpSharesOptions.Enabled = false;
                btnSave.Text = "Save";
                txtNumberOfShares.Text = "0";
                txtCost.Text = "0";
                ddlDividendInterval.SelectedIndex = 1;
                lblReq1.Show();
                lblReq2.Show();
                lblReq3.Show();
                lblRequired.Show();
            }
        }

        public void HideTextBoxes()
        {
            txtAnnualDividend.Enabled = false;
            txtMarketCap.Enabled = false;
            txtDividendPercent.Enabled = false;
            txtExDividend.Enabled = false;
            txtPERatio.Enabled = false;
            txtPayDate.Enabled = false;
            txtOpenPrice.Enabled = false;
            txt52WeekHigh.Enabled = false;
            txt52WeekLow.Enabled = false;
            txtCurrentPrice.Enabled = false;
            txtDayRange.Enabled = false;
            txtStockName.Enabled = false;
        }

        public void LoadDividendStock()
        {
            DataTable dt = uti.FilterDataTable(uti.GetXMLData(FileTypes.cache),  LstStockInfo[0].Symbol);
            txtSymbol.Text = LstStockInfo[0].Symbol;
            txtStockName.Text = LstStockInfo[0].Name;
            ddlIndustry.SelectedIndex = ddlIndustry.FindString(LstStockInfo[0].Industry);
            ddlDividendInterval.SelectedIndex = ddlDividendInterval.FindString(LstStockInfo[0].Interval);
            txtAnnualDividend.Text = dt.Rows[0][DivCacheCodes.annualDiv.ToString()].ToString();
            txtEPS.Text = dt.Rows[0][DivCacheCodes.eps.ToString()].ToString();
            txtDividendPercent.Text = dt.Rows[0][DivCacheCodes.divPercent.ToString()].ToString();
            txtMarketCap.Text = dt.Rows[0][DivCacheCodes.marketCap.ToString()].ToString();
            txtExDividend.Text = dt.Rows[0][DivCacheCodes.exDividend.ToString()].ToString();
            txtPayDate.Text = dt.Rows[0][DivCacheCodes.payDates.ToString()].ToString();
            txtPERatio.Text = dt.Rows[0][DivCacheCodes.peRatio.ToString()].ToString();
            txtDayRange.Text = dt.Rows[0][DivCacheCodes.daysRange.ToString()].ToString();
            txt52WeekLow.Text = dt.Rows[0][DivCacheCodes.fiftyTwoWeekLow.ToString()].ToString();
            txt52WeekHigh.Text = dt.Rows[0][DivCacheCodes.fiftyTwoWeekHigh.ToString()].ToString();
            txtCurrentPrice.Text = dt.Rows[0][DivCacheCodes.currentPrice.ToString()].ToString();
            txtOpenPrice.Text = dt.Rows[0][DivCacheCodes.openPrice.ToString()].ToString();
        }

        public void LoadPurchaseInfo()
        {
            txtCost.Clear();
            txtNumberOfShares.Clear();
            DataTable dt = uti.GetXMLData(FileTypes.xml);
            DataTable dtFinal = dt.Copy();
            for (int i = dt.Rows.Count -1; i >= 0; i--)
            {
                if (dt.Rows[i]["symbol"].ToString() == LstStockInfo[0].Symbol)
                {
                    dtpPurchaseDate.Value = Convert.ToDateTime(dt.Rows[i]["purchasedate"]);
                    txtCost.Text = dtFinal.Rows[i]["cost"].ToString();
                    txtNumberOfShares.Text = dtFinal.Rows[i]["shares"].ToString();
                }
            }
        }

        public bool ValidateAll()
        {
            if (txtSymbol.Text == "")
            {
                MessageBox.Show("Please enter symbol.");
                return false;
            }
            //if(!uti.IsLettersOnly(txtSymbol.Text))
            //{
            //    MessageBox.Show("Please enter letters only for symbol.");
            //    return false;
            //}
            if (ddlIndustry.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Industry.");
                return false;
            }
            if (txtNumberOfShares.Text == "")
            {
                MessageBox.Show("Please enter number of shares.");
                return false;
            }
            try
            {
                decimal.Parse(txtNumberOfShares.Text);
            }
            catch
            {
                MessageBox.Show("Please enter numbers only.");
                txtNumberOfShares.Focus();
                return false;
            }
            if (txtCost.Text == "")
            {
                MessageBox.Show("Please enter purchase price.");
                return false;
            }
            try
            {
                decimal.Parse(txtCost.Text);
            }
            catch
            {
                MessageBox.Show("Please enter numbers only.");
                txtCost.Focus();
                return false;
            }
            return true;
        }

        private void btnGetSharePrice_Click(object sender, EventArgs e)
        {
            if (txtNumberOfShares.Text != "" && txtCost.Text != "")
            {
                try
                {
                    decimal.Parse(txtNumberOfShares.Text);
                    decimal.Parse(txtCost.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please enter numbers only.");
                    return;
                }
                decimal TotalSharePrice = 0;
                try
                {
                    TotalSharePrice = Convert.ToDecimal(txtNumberOfShares.Text.Trim()) * Convert.ToDecimal(txtCost.Text.Trim());
                    MessageBox.Show("$" + Math.Round(TotalSharePrice, 2).ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in calculating. Please try again.");
                }
            }
        }

        private void btnDividendPrice_Click(object sender, EventArgs e)
        {
            if (txtNumberOfShares.Text != "" && txtCost.Text != "")
            {
                try
                {
                    decimal.Parse(txtNumberOfShares.Text);
                    decimal.Parse(txtCost.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please enter numbers only.");
                    return;
                }
                try
                {
                    decimal TotalDividendPrice = Convert.ToDecimal(txtAnnualDividend.Text.Trim()) * Convert.ToDecimal(txtNumberOfShares.Text.Trim());
                    decimal QuarterlyDividendPrice = TotalDividendPrice / 4;
                    decimal MonthlyDividendPrice = TotalDividendPrice / 12;
                    MessageBox.Show("Yearly: $" + Math.Round(TotalDividendPrice, 2).ToString() + "\n\nQuarterly: $" + Math.Round(QuarterlyDividendPrice, 2) + "\n\nMonthly: $" + Math.Round(MonthlyDividendPrice, 2));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in calculating. Please try again.");
                }
            }
        }

        private void Dividends_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
        }

        private void txtSymbol_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
        }

        private void txtNumberOfShares_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
        }

        private void txtCost_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
        }

        private void ddlIndustry_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
        }

        private void ddlDividendInterval_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
        }

        private void txtDividendPercent_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
        }

        private void txtAnnualDividend_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
        }

        private void txtEPS_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
        }

        private void txtExDividend_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
        }

        private void txtPayDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
        }

        private void txtStockName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
        }

        private void txtMarketCap_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
        }

        private void txtPERatio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
        }

        private void txtOpenPrice_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
        }

        private void txtCurrentPrice_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
        }

        private void txt52WeekLow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
        }

        private void txt52WeekHigh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
        }

        private void txtDayRange_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
        }
    }
}
