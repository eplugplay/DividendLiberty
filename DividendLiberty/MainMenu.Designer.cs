namespace DividendLiberty
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importStocksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportStocksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadYahooStockInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nonPortfolioOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highlightNextPurchasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPercentagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portfolioOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getCostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getDividendsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSectorPercentagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gpDividendStocks = new System.Windows.Forms.GroupBox();
            this.lblMyPortfolio = new System.Windows.Forms.Label();
            this.lvAllDividends = new System.Windows.Forms.ListView();
            this.lvCurrentDividends = new System.Windows.Forms.ListView();
            this.dtpPayDate = new System.Windows.Forms.DateTimePicker();
            this.btnPayDate = new System.Windows.Forms.Button();
            this.lblPayDate = new System.Windows.Forms.Label();
            this.chkNextBuy = new System.Windows.Forms.CheckBox();
            this.lblSearchAllSymbol = new System.Windows.Forms.Label();
            this.txtSearchAllSymbol = new System.Windows.Forms.TextBox();
            this.lblSearchSymbol = new System.Windows.Forms.Label();
            this.txtSearchSymbol = new System.Windows.Forms.TextBox();
            this.btnHighlightAll = new System.Windows.Forms.Button();
            this.lblIndustryAll = new System.Windows.Forms.Label();
            this.ddlIndustryAll = new System.Windows.Forms.ComboBox();
            this.btnHighlight = new System.Windows.Forms.Button();
            this.lblIndustry = new System.Windows.Forms.Label();
            this.ddlIndustry = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pbStatus = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblPortfolioTotal = new System.Windows.Forms.Label();
            this.lblAnnualDividends = new System.Windows.Forms.Label();
            this.lblAnnualDividendsTotal = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.gpDividendStocks.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.nonPortfolioOptionsToolStripMenuItem,
            this.portfolioOptionsToolStripMenuItem,
            this.excelOptionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1437, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.importStocksToolStripMenuItem,
            this.exportStocksToolStripMenuItem,
            this.reloadYahooStockInfoToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.newToolStripMenuItem.Text = "Add New Stock";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // importStocksToolStripMenuItem
            // 
            this.importStocksToolStripMenuItem.Name = "importStocksToolStripMenuItem";
            this.importStocksToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.importStocksToolStripMenuItem.Text = "Import Dividends";
            this.importStocksToolStripMenuItem.Click += new System.EventHandler(this.importStocksToolStripMenuItem_Click);
            // 
            // exportStocksToolStripMenuItem
            // 
            this.exportStocksToolStripMenuItem.Name = "exportStocksToolStripMenuItem";
            this.exportStocksToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.exportStocksToolStripMenuItem.Text = "Export Dividends";
            this.exportStocksToolStripMenuItem.Click += new System.EventHandler(this.exportStocksToolStripMenuItem_Click);
            // 
            // reloadYahooStockInfoToolStripMenuItem
            // 
            this.reloadYahooStockInfoToolStripMenuItem.Name = "reloadYahooStockInfoToolStripMenuItem";
            this.reloadYahooStockInfoToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.reloadYahooStockInfoToolStripMenuItem.Text = "Refresh Yahoo Stock Info";
            this.reloadYahooStockInfoToolStripMenuItem.Click += new System.EventHandler(this.reloadYahooStockInfoToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // nonPortfolioOptionsToolStripMenuItem
            // 
            this.nonPortfolioOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.highlightNextPurchasesToolStripMenuItem,
            this.showPercentagesToolStripMenuItem});
            this.nonPortfolioOptionsToolStripMenuItem.Name = "nonPortfolioOptionsToolStripMenuItem";
            this.nonPortfolioOptionsToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.nonPortfolioOptionsToolStripMenuItem.Text = "Non Portfolio Options";
            // 
            // highlightNextPurchasesToolStripMenuItem
            // 
            this.highlightNextPurchasesToolStripMenuItem.Name = "highlightNextPurchasesToolStripMenuItem";
            this.highlightNextPurchasesToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.highlightNextPurchasesToolStripMenuItem.Text = "Highlight Next Purchases";
            this.highlightNextPurchasesToolStripMenuItem.Click += new System.EventHandler(this.highlightNextPurchasesToolStripMenuItem_Click);
            // 
            // showPercentagesToolStripMenuItem
            // 
            this.showPercentagesToolStripMenuItem.Name = "showPercentagesToolStripMenuItem";
            this.showPercentagesToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.showPercentagesToolStripMenuItem.Text = "Show Sector Percentages";
            this.showPercentagesToolStripMenuItem.Click += new System.EventHandler(this.showPercentagesToolStripMenuItem_Click);
            // 
            // portfolioOptionsToolStripMenuItem
            // 
            this.portfolioOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getCostToolStripMenuItem,
            this.getDividendsToolStripMenuItem,
            this.showSectorPercentagesToolStripMenuItem,
            this.generateExcelToolStripMenuItem,
            this.calculateResultsToolStripMenuItem});
            this.portfolioOptionsToolStripMenuItem.Name = "portfolioOptionsToolStripMenuItem";
            this.portfolioOptionsToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.portfolioOptionsToolStripMenuItem.Text = "Portfolio Options";
            // 
            // getCostToolStripMenuItem
            // 
            this.getCostToolStripMenuItem.Name = "getCostToolStripMenuItem";
            this.getCostToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.getCostToolStripMenuItem.Text = "Get Cost(s)";
            this.getCostToolStripMenuItem.Click += new System.EventHandler(this.getCostToolStripMenuItem_Click);
            // 
            // getDividendsToolStripMenuItem
            // 
            this.getDividendsToolStripMenuItem.Name = "getDividendsToolStripMenuItem";
            this.getDividendsToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.getDividendsToolStripMenuItem.Text = "Get Dividend(s)";
            this.getDividendsToolStripMenuItem.Click += new System.EventHandler(this.getDividendsToolStripMenuItem_Click);
            // 
            // showSectorPercentagesToolStripMenuItem
            // 
            this.showSectorPercentagesToolStripMenuItem.Name = "showSectorPercentagesToolStripMenuItem";
            this.showSectorPercentagesToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.showSectorPercentagesToolStripMenuItem.Text = "Show Sector Percentages";
            this.showSectorPercentagesToolStripMenuItem.Click += new System.EventHandler(this.showSectorPercentagesToolStripMenuItem_Click);
            // 
            // generateExcelToolStripMenuItem
            // 
            this.generateExcelToolStripMenuItem.Name = "generateExcelToolStripMenuItem";
            this.generateExcelToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.generateExcelToolStripMenuItem.Text = "Generate Excel";
            this.generateExcelToolStripMenuItem.Click += new System.EventHandler(this.generateExcelToolStripMenuItem_Click);
            // 
            // calculateResultsToolStripMenuItem
            // 
            this.calculateResultsToolStripMenuItem.Name = "calculateResultsToolStripMenuItem";
            this.calculateResultsToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.calculateResultsToolStripMenuItem.Text = "Calculate Results";
            this.calculateResultsToolStripMenuItem.Click += new System.EventHandler(this.calculateResultsToolStripMenuItem_Click);
            // 
            // excelOptionsToolStripMenuItem
            // 
            this.excelOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editColumnsToolStripMenuItem});
            this.excelOptionsToolStripMenuItem.Name = "excelOptionsToolStripMenuItem";
            this.excelOptionsToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.excelOptionsToolStripMenuItem.Text = "Excel Options";
            // 
            // editColumnsToolStripMenuItem
            // 
            this.editColumnsToolStripMenuItem.Name = "editColumnsToolStripMenuItem";
            this.editColumnsToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.editColumnsToolStripMenuItem.Text = "Edit Columns";
            this.editColumnsToolStripMenuItem.Click += new System.EventHandler(this.editColumnsToolStripMenuItem_Click);
            // 
            // gpDividendStocks
            // 
            this.gpDividendStocks.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.gpDividendStocks.Controls.Add(this.lblAnnualDividends);
            this.gpDividendStocks.Controls.Add(this.lblAnnualDividendsTotal);
            this.gpDividendStocks.Controls.Add(this.lblPortfolioTotal);
            this.gpDividendStocks.Controls.Add(this.lblMyPortfolio);
            this.gpDividendStocks.Controls.Add(this.lvAllDividends);
            this.gpDividendStocks.Controls.Add(this.lvCurrentDividends);
            this.gpDividendStocks.Controls.Add(this.dtpPayDate);
            this.gpDividendStocks.Controls.Add(this.btnPayDate);
            this.gpDividendStocks.Controls.Add(this.lblPayDate);
            this.gpDividendStocks.Controls.Add(this.chkNextBuy);
            this.gpDividendStocks.Controls.Add(this.lblSearchAllSymbol);
            this.gpDividendStocks.Controls.Add(this.txtSearchAllSymbol);
            this.gpDividendStocks.Controls.Add(this.lblSearchSymbol);
            this.gpDividendStocks.Controls.Add(this.txtSearchSymbol);
            this.gpDividendStocks.Controls.Add(this.btnHighlightAll);
            this.gpDividendStocks.Controls.Add(this.lblIndustryAll);
            this.gpDividendStocks.Controls.Add(this.ddlIndustryAll);
            this.gpDividendStocks.Controls.Add(this.btnHighlight);
            this.gpDividendStocks.Controls.Add(this.lblIndustry);
            this.gpDividendStocks.Controls.Add(this.ddlIndustry);
            this.gpDividendStocks.Controls.Add(this.label2);
            this.gpDividendStocks.Controls.Add(this.btnRemove);
            this.gpDividendStocks.Controls.Add(this.btnAdd);
            this.gpDividendStocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpDividendStocks.ForeColor = System.Drawing.Color.White;
            this.gpDividendStocks.Location = new System.Drawing.Point(12, 37);
            this.gpDividendStocks.Name = "gpDividendStocks";
            this.gpDividendStocks.Size = new System.Drawing.Size(1413, 722);
            this.gpDividendStocks.TabIndex = 3;
            this.gpDividendStocks.TabStop = false;
            // 
            // lblMyPortfolio
            // 
            this.lblMyPortfolio.AutoSize = true;
            this.lblMyPortfolio.BackColor = System.Drawing.Color.Transparent;
            this.lblMyPortfolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyPortfolio.ForeColor = System.Drawing.Color.White;
            this.lblMyPortfolio.Location = new System.Drawing.Point(14, 377);
            this.lblMyPortfolio.Name = "lblMyPortfolio";
            this.lblMyPortfolio.Size = new System.Drawing.Size(78, 13);
            this.lblMyPortfolio.TabIndex = 41;
            this.lblMyPortfolio.Text = "My Portfolio:";
            // 
            // lvAllDividends
            // 
            this.lvAllDividends.BackColor = System.Drawing.Color.White;
            this.lvAllDividends.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvAllDividends.ForeColor = System.Drawing.Color.White;
            this.lvAllDividends.Location = new System.Drawing.Point(13, 44);
            this.lvAllDividends.Name = "lvAllDividends";
            this.lvAllDividends.Size = new System.Drawing.Size(1387, 287);
            this.lvAllDividends.TabIndex = 40;
            this.lvAllDividends.UseCompatibleStateImageBehavior = false;
            this.lvAllDividends.SelectedIndexChanged += new System.EventHandler(this.lvAllDividends_SelectedIndexChanged);
            this.lvAllDividends.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvAllDividends_KeyDown);
            this.lvAllDividends.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvAllDividends_KeyUp);
            this.lvAllDividends.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvAllDividends_MouseClick);
            this.lvAllDividends.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvAllDividends_MouseDoubleClick);
            this.lvAllDividends.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvAllDividends_MouseDown);
            this.lvAllDividends.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvAllDividends_MouseUp);
            // 
            // lvCurrentDividends
            // 
            this.lvCurrentDividends.BackColor = System.Drawing.Color.White;
            this.lvCurrentDividends.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCurrentDividends.ForeColor = System.Drawing.Color.White;
            this.lvCurrentDividends.Location = new System.Drawing.Point(13, 394);
            this.lvCurrentDividends.Name = "lvCurrentDividends";
            this.lvCurrentDividends.Size = new System.Drawing.Size(1387, 287);
            this.lvCurrentDividends.TabIndex = 39;
            this.lvCurrentDividends.UseCompatibleStateImageBehavior = false;
            this.lvCurrentDividends.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvCurrentDividends_KeyDown);
            this.lvCurrentDividends.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvCurrentDividends_KeyUp);
            this.lvCurrentDividends.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvCurrentDividends_MouseClick);
            this.lvCurrentDividends.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvCurrentDividends_MouseDoubleClick);
            this.lvCurrentDividends.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvCurrentDividends_MouseDown);
            this.lvCurrentDividends.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvCurrentDividends_MouseUp);
            // 
            // dtpPayDate
            // 
            this.dtpPayDate.CalendarMonthBackground = System.Drawing.Color.AliceBlue;
            this.dtpPayDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPayDate.Location = new System.Drawing.Point(86, 685);
            this.dtpPayDate.Name = "dtpPayDate";
            this.dtpPayDate.Size = new System.Drawing.Size(149, 20);
            this.dtpPayDate.TabIndex = 38;
            // 
            // btnPayDate
            // 
            this.btnPayDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayDate.ForeColor = System.Drawing.Color.Black;
            this.btnPayDate.Location = new System.Drawing.Point(241, 684);
            this.btnPayDate.Name = "btnPayDate";
            this.btnPayDate.Size = new System.Drawing.Size(76, 23);
            this.btnPayDate.TabIndex = 37;
            this.btnPayDate.TabStop = false;
            this.btnPayDate.Text = "Highlight";
            this.btnPayDate.UseVisualStyleBackColor = true;
            this.btnPayDate.Click += new System.EventHandler(this.btnPayDate_Click);
            // 
            // lblPayDate
            // 
            this.lblPayDate.AutoSize = true;
            this.lblPayDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayDate.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblPayDate.Location = new System.Drawing.Point(17, 689);
            this.lblPayDate.Name = "lblPayDate";
            this.lblPayDate.Size = new System.Drawing.Size(63, 13);
            this.lblPayDate.TabIndex = 36;
            this.lblPayDate.Text = "Pay Date:";
            // 
            // chkNextBuy
            // 
            this.chkNextBuy.AutoSize = true;
            this.chkNextBuy.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chkNextBuy.Location = new System.Drawing.Point(112, 25);
            this.chkNextBuy.Name = "chkNextBuy";
            this.chkNextBuy.Size = new System.Drawing.Size(123, 17);
            this.chkNextBuy.TabIndex = 33;
            this.chkNextBuy.Text = "Next to purchase";
            this.chkNextBuy.UseVisualStyleBackColor = true;
            this.chkNextBuy.CheckedChanged += new System.EventHandler(this.chkNextBuy_CheckedChanged);
            // 
            // lblSearchAllSymbol
            // 
            this.lblSearchAllSymbol.AutoSize = true;
            this.lblSearchAllSymbol.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSearchAllSymbol.Location = new System.Drawing.Point(1242, 336);
            this.lblSearchAllSymbol.Name = "lblSearchAllSymbol";
            this.lblSearchAllSymbol.Size = new System.Drawing.Size(95, 13);
            this.lblSearchAllSymbol.TabIndex = 32;
            this.lblSearchAllSymbol.Text = "Search Symbol:";
            // 
            // txtSearchAllSymbol
            // 
            this.txtSearchAllSymbol.BackColor = System.Drawing.Color.AliceBlue;
            this.txtSearchAllSymbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchAllSymbol.ForeColor = System.Drawing.Color.Black;
            this.txtSearchAllSymbol.Location = new System.Drawing.Point(1343, 333);
            this.txtSearchAllSymbol.Name = "txtSearchAllSymbol";
            this.txtSearchAllSymbol.Size = new System.Drawing.Size(57, 20);
            this.txtSearchAllSymbol.TabIndex = 31;
            this.txtSearchAllSymbol.TextChanged += new System.EventHandler(this.txtSearchAllSymbol_TextChanged);
            // 
            // lblSearchSymbol
            // 
            this.lblSearchSymbol.AutoSize = true;
            this.lblSearchSymbol.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSearchSymbol.Location = new System.Drawing.Point(1240, 687);
            this.lblSearchSymbol.Name = "lblSearchSymbol";
            this.lblSearchSymbol.Size = new System.Drawing.Size(95, 13);
            this.lblSearchSymbol.TabIndex = 30;
            this.lblSearchSymbol.Text = "Search Symbol:";
            // 
            // txtSearchSymbol
            // 
            this.txtSearchSymbol.BackColor = System.Drawing.Color.AliceBlue;
            this.txtSearchSymbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchSymbol.ForeColor = System.Drawing.Color.Black;
            this.txtSearchSymbol.Location = new System.Drawing.Point(1341, 684);
            this.txtSearchSymbol.Name = "txtSearchSymbol";
            this.txtSearchSymbol.Size = new System.Drawing.Size(59, 20);
            this.txtSearchSymbol.TabIndex = 29;
            this.txtSearchSymbol.TextChanged += new System.EventHandler(this.txtSearchSymbol_TextChanged);
            // 
            // btnHighlightAll
            // 
            this.btnHighlightAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHighlightAll.ForeColor = System.Drawing.Color.Black;
            this.btnHighlightAll.Location = new System.Drawing.Point(1335, 20);
            this.btnHighlightAll.Name = "btnHighlightAll";
            this.btnHighlightAll.Size = new System.Drawing.Size(65, 23);
            this.btnHighlightAll.TabIndex = 26;
            this.btnHighlightAll.TabStop = false;
            this.btnHighlightAll.Text = "Highlight";
            this.btnHighlightAll.UseVisualStyleBackColor = true;
            this.btnHighlightAll.Click += new System.EventHandler(this.btnHighlightAll_Click);
            // 
            // lblIndustryAll
            // 
            this.lblIndustryAll.AutoSize = true;
            this.lblIndustryAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndustryAll.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblIndustryAll.Location = new System.Drawing.Point(1073, 25);
            this.lblIndustryAll.Name = "lblIndustryAll";
            this.lblIndustryAll.Size = new System.Drawing.Size(56, 13);
            this.lblIndustryAll.TabIndex = 25;
            this.lblIndustryAll.Text = "Industry:";
            // 
            // ddlIndustryAll
            // 
            this.ddlIndustryAll.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlIndustryAll.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlIndustryAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlIndustryAll.ForeColor = System.Drawing.Color.Black;
            this.ddlIndustryAll.FormattingEnabled = true;
            this.ddlIndustryAll.Items.AddRange(new object[] {
            "Consumer Discretionary",
            "Consumer Staples",
            "Energy",
            "Financials",
            "Health Care",
            "Industrials",
            "Information Technology",
            "Materials",
            "Telecommunication Services",
            "Utilities"});
            this.ddlIndustryAll.Location = new System.Drawing.Point(1135, 21);
            this.ddlIndustryAll.Name = "ddlIndustryAll";
            this.ddlIndustryAll.Size = new System.Drawing.Size(199, 21);
            this.ddlIndustryAll.TabIndex = 24;
            // 
            // btnHighlight
            // 
            this.btnHighlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHighlight.ForeColor = System.Drawing.Color.Black;
            this.btnHighlight.Location = new System.Drawing.Point(1334, 370);
            this.btnHighlight.Name = "btnHighlight";
            this.btnHighlight.Size = new System.Drawing.Size(66, 23);
            this.btnHighlight.TabIndex = 23;
            this.btnHighlight.TabStop = false;
            this.btnHighlight.Text = "Highlight";
            this.btnHighlight.UseVisualStyleBackColor = true;
            this.btnHighlight.Click += new System.EventHandler(this.btnHighlight_Click);
            // 
            // lblIndustry
            // 
            this.lblIndustry.AutoSize = true;
            this.lblIndustry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndustry.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblIndustry.Location = new System.Drawing.Point(1049, 377);
            this.lblIndustry.Name = "lblIndustry";
            this.lblIndustry.Size = new System.Drawing.Size(56, 13);
            this.lblIndustry.TabIndex = 22;
            this.lblIndustry.Text = "Industry:";
            // 
            // ddlIndustry
            // 
            this.ddlIndustry.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlIndustry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlIndustry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlIndustry.ForeColor = System.Drawing.Color.Black;
            this.ddlIndustry.FormattingEnabled = true;
            this.ddlIndustry.Items.AddRange(new object[] {
            "Consumer Discretionary",
            "Consumer Staples",
            "Energy",
            "Financials",
            "Health Care",
            "Industrials",
            "Information Technology",
            "Materials",
            "Telecommunication Services",
            "Utilities"});
            this.ddlIndustry.Location = new System.Drawing.Point(1111, 371);
            this.ddlIndustry.Name = "ddlIndustry";
            this.ddlIndustry.Size = new System.Drawing.Size(223, 21);
            this.ddlIndustry.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Not In Portfolio:";
            // 
            // btnRemove
            // 
            this.btnRemove.ForeColor = System.Drawing.Color.Black;
            this.btnRemove.Location = new System.Drawing.Point(788, 345);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(42, 34);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "↑";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(629, 345);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(42, 34);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "↓";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // pbStatus
            // 
            this.pbStatus.Location = new System.Drawing.Point(752, 1);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(100, 23);
            this.pbStatus.TabIndex = 39;
            this.pbStatus.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.White;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(663, 6);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(83, 13);
            this.lblStatus.TabIndex = 40;
            this.lblStatus.Text = "Please Wait..";
            this.lblStatus.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblPortfolioTotal
            // 
            this.lblPortfolioTotal.AutoSize = true;
            this.lblPortfolioTotal.BackColor = System.Drawing.Color.White;
            this.lblPortfolioTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortfolioTotal.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblPortfolioTotal.Location = new System.Drawing.Point(90, 376);
            this.lblPortfolioTotal.Name = "lblPortfolioTotal";
            this.lblPortfolioTotal.Size = new System.Drawing.Size(38, 16);
            this.lblPortfolioTotal.TabIndex = 42;
            this.lblPortfolioTotal.Text = "total";
            // 
            // lblAnnualDividends
            // 
            this.lblAnnualDividends.AutoSize = true;
            this.lblAnnualDividends.BackColor = System.Drawing.Color.White;
            this.lblAnnualDividends.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnnualDividends.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblAnnualDividends.Location = new System.Drawing.Point(317, 375);
            this.lblAnnualDividends.Name = "lblAnnualDividends";
            this.lblAnnualDividends.Size = new System.Drawing.Size(38, 16);
            this.lblAnnualDividends.TabIndex = 44;
            this.lblAnnualDividends.Text = "total";
            // 
            // lblAnnualDividendsTotal
            // 
            this.lblAnnualDividendsTotal.AutoSize = true;
            this.lblAnnualDividendsTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblAnnualDividendsTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnnualDividendsTotal.ForeColor = System.Drawing.Color.White;
            this.lblAnnualDividendsTotal.Location = new System.Drawing.Point(211, 377);
            this.lblAnnualDividendsTotal.Name = "lblAnnualDividendsTotal";
            this.lblAnnualDividendsTotal.Size = new System.Drawing.Size(106, 13);
            this.lblAnnualDividendsTotal.TabIndex = 43;
            this.lblAnnualDividendsTotal.Text = "Yearly Dividends:";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.ClientSize = new System.Drawing.Size(1437, 770);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.gpDividendStocks);
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dividend Liberty";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gpDividendStocks.ResumeLayout(false);
            this.gpDividendStocks.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.GroupBox gpDividendStocks;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox ddlIndustry;
        private System.Windows.Forms.Button btnHighlight;
        private System.Windows.Forms.Label lblIndustry;
        private System.Windows.Forms.Button btnHighlightAll;
        private System.Windows.Forms.Label lblIndustryAll;
        private System.Windows.Forms.ComboBox ddlIndustryAll;
        private System.Windows.Forms.TextBox txtSearchSymbol;
        private System.Windows.Forms.Label lblSearchAllSymbol;
        private System.Windows.Forms.TextBox txtSearchAllSymbol;
        private System.Windows.Forms.Label lblSearchSymbol;
        private System.Windows.Forms.CheckBox chkNextBuy;
        private System.Windows.Forms.Button btnPayDate;
        private System.Windows.Forms.Label lblPayDate;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar pbStatus;
        public System.Windows.Forms.ListView lvCurrentDividends;
        public System.Windows.Forms.ListView lvAllDividends;
        private System.Windows.Forms.Label lblMyPortfolio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem portfolioOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getCostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getDividendsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nonPortfolioOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSectorPercentagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculateResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highlightNextPurchasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPercentagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editColumnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importStocksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportStocksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadYahooStockInfoToolStripMenuItem;
        public System.Windows.Forms.DateTimePicker dtpPayDate;
        public System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblPortfolioTotal;
        private System.Windows.Forms.Label lblAnnualDividends;
        private System.Windows.Forms.Label lblAnnualDividendsTotal;
    }
}

