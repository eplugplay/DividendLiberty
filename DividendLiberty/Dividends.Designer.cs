namespace DividendLiberty
{
    partial class Dividends
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dividends));
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.lblSymbol = new System.Windows.Forms.Label();
            this.lblStockName = new System.Windows.Forms.Label();
            this.txtStockName = new System.Windows.Forms.TextBox();
            this.lblCost = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.lblIndustry = new System.Windows.Forms.Label();
            this.lblNumberShare = new System.Windows.Forms.Label();
            this.txtNumberOfShares = new System.Windows.Forms.TextBox();
            this.lblAnnualDividend = new System.Windows.Forms.Label();
            this.txtAnnualDividend = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDividendPercent = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gpDividendInfo = new System.Windows.Forms.GroupBox();
            this.lblReq3 = new System.Windows.Forms.Label();
            this.lblReq2 = new System.Windows.Forms.Label();
            this.lblReq1 = new System.Windows.Forms.Label();
            this.lblRequired = new System.Windows.Forms.Label();
            this.ddlDividendInterval = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCurrentPrice = new System.Windows.Forms.TextBox();
            this.txtExDividend = new System.Windows.Forms.TextBox();
            this.txtPayDate = new System.Windows.Forms.TextBox();
            this.lblOpenPrice = new System.Windows.Forms.Label();
            this.txtOpenPrice = new System.Windows.Forms.TextBox();
            this.txtMarketCap = new System.Windows.Forms.TextBox();
            this.lblDaysRange = new System.Windows.Forms.Label();
            this.txtDayRange = new System.Windows.Forms.TextBox();
            this.lbl52WeekMiddle = new System.Windows.Forms.Label();
            this.txt52WeekHigh = new System.Windows.Forms.TextBox();
            this.lbl52WeekRange = new System.Windows.Forms.Label();
            this.txt52WeekLow = new System.Windows.Forms.TextBox();
            this.lblPERatio = new System.Windows.Forms.Label();
            this.txtPERatio = new System.Windows.Forms.TextBox();
            this.lblPayDate = new System.Windows.Forms.Label();
            this.lblExDividend = new System.Windows.Forms.Label();
            this.ddlIndustry = new System.Windows.Forms.ComboBox();
            this.lblMarketCap = new System.Windows.Forms.Label();
            this.btnDividendPrice = new System.Windows.Forms.Button();
            this.btnGetSharePrice = new System.Windows.Forms.Button();
            this.lblSharePurchaseDate = new System.Windows.Forms.Label();
            this.gpSharesOptions = new System.Windows.Forms.GroupBox();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.txtEPS = new System.Windows.Forms.TextBox();
            this.lblEPS = new System.Windows.Forms.Label();
            this.gpDividendInfo.SuspendLayout();
            this.gpSharesOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSymbol
            // 
            this.txtSymbol.BackColor = System.Drawing.Color.AliceBlue;
            this.txtSymbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSymbol.ForeColor = System.Drawing.Color.Black;
            this.txtSymbol.Location = new System.Drawing.Point(123, 21);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(210, 20);
            this.txtSymbol.TabIndex = 0;
            this.txtSymbol.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSymbol_KeyUp);
            // 
            // lblSymbol
            // 
            this.lblSymbol.AutoSize = true;
            this.lblSymbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSymbol.Location = new System.Drawing.Point(58, 27);
            this.lblSymbol.Name = "lblSymbol";
            this.lblSymbol.Size = new System.Drawing.Size(51, 13);
            this.lblSymbol.TabIndex = 1;
            this.lblSymbol.Text = "Symbol:";
            // 
            // lblStockName
            // 
            this.lblStockName.AutoSize = true;
            this.lblStockName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockName.Location = new System.Drawing.Point(372, 28);
            this.lblStockName.Name = "lblStockName";
            this.lblStockName.Size = new System.Drawing.Size(80, 13);
            this.lblStockName.TabIndex = 3;
            this.lblStockName.Text = "Stock Name:";
            // 
            // txtStockName
            // 
            this.txtStockName.BackColor = System.Drawing.Color.AliceBlue;
            this.txtStockName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockName.ForeColor = System.Drawing.Color.Black;
            this.txtStockName.Location = new System.Drawing.Point(458, 25);
            this.txtStockName.Name = "txtStockName";
            this.txtStockName.ReadOnly = true;
            this.txtStockName.Size = new System.Drawing.Size(214, 20);
            this.txtStockName.TabIndex = 1;
            this.txtStockName.TabStop = false;
            this.txtStockName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtStockName_KeyUp);
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCost.Location = new System.Drawing.Point(68, 123);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(36, 13);
            this.lblCost.TabIndex = 7;
            this.lblCost.Text = "Cost:";
            // 
            // txtCost
            // 
            this.txtCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCost.ForeColor = System.Drawing.Color.Black;
            this.txtCost.Location = new System.Drawing.Point(127, 119);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(210, 20);
            this.txtCost.TabIndex = 4;
            this.txtCost.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCost_KeyUp);
            // 
            // lblIndustry
            // 
            this.lblIndustry.AutoSize = true;
            this.lblIndustry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndustry.Location = new System.Drawing.Point(53, 50);
            this.lblIndustry.Name = "lblIndustry";
            this.lblIndustry.Size = new System.Drawing.Size(56, 13);
            this.lblIndustry.TabIndex = 5;
            this.lblIndustry.Text = "Industry:";
            // 
            // lblNumberShare
            // 
            this.lblNumberShare.AutoSize = true;
            this.lblNumberShare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberShare.Location = new System.Drawing.Point(27, 96);
            this.lblNumberShare.Name = "lblNumberShare";
            this.lblNumberShare.Size = new System.Drawing.Size(77, 13);
            this.lblNumberShare.TabIndex = 11;
            this.lblNumberShare.Text = "# of Shares:";
            // 
            // txtNumberOfShares
            // 
            this.txtNumberOfShares.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumberOfShares.ForeColor = System.Drawing.Color.Black;
            this.txtNumberOfShares.Location = new System.Drawing.Point(127, 93);
            this.txtNumberOfShares.Name = "txtNumberOfShares";
            this.txtNumberOfShares.Size = new System.Drawing.Size(210, 20);
            this.txtNumberOfShares.TabIndex = 3;
            this.txtNumberOfShares.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumberOfShares_KeyUp);
            // 
            // lblAnnualDividend
            // 
            this.lblAnnualDividend.AutoSize = true;
            this.lblAnnualDividend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnnualDividend.Location = new System.Drawing.Point(39, 131);
            this.lblAnnualDividend.Name = "lblAnnualDividend";
            this.lblAnnualDividend.Size = new System.Drawing.Size(70, 13);
            this.lblAnnualDividend.TabIndex = 9;
            this.lblAnnualDividend.Text = "Ann. Divid:";
            // 
            // txtAnnualDividend
            // 
            this.txtAnnualDividend.BackColor = System.Drawing.Color.AliceBlue;
            this.txtAnnualDividend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnnualDividend.ForeColor = System.Drawing.Color.Black;
            this.txtAnnualDividend.Location = new System.Drawing.Point(123, 128);
            this.txtAnnualDividend.Name = "txtAnnualDividend";
            this.txtAnnualDividend.ReadOnly = true;
            this.txtAnnualDividend.Size = new System.Drawing.Size(210, 20);
            this.txtAnnualDividend.TabIndex = 4;
            this.txtAnnualDividend.TabStop = false;
            this.txtAnnualDividend.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAnnualDividend_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Dividend %:";
            // 
            // txtDividendPercent
            // 
            this.txtDividendPercent.BackColor = System.Drawing.Color.AliceBlue;
            this.txtDividendPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDividendPercent.ForeColor = System.Drawing.Color.Black;
            this.txtDividendPercent.Location = new System.Drawing.Point(123, 101);
            this.txtDividendPercent.Name = "txtDividendPercent";
            this.txtDividendPercent.ReadOnly = true;
            this.txtDividendPercent.Size = new System.Drawing.Size(211, 20);
            this.txtDividendPercent.TabIndex = 5;
            this.txtDividendPercent.TabStop = false;
            this.txtDividendPercent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDividendPercent_KeyUp);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(946, 243);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 37);
            this.btnSave.TabIndex = 14;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Update All";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gpDividendInfo
            // 
            this.gpDividendInfo.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.gpDividendInfo.Controls.Add(this.txtEPS);
            this.gpDividendInfo.Controls.Add(this.lblEPS);
            this.gpDividendInfo.Controls.Add(this.lblReq3);
            this.gpDividendInfo.Controls.Add(this.lblReq2);
            this.gpDividendInfo.Controls.Add(this.lblReq1);
            this.gpDividendInfo.Controls.Add(this.lblRequired);
            this.gpDividendInfo.Controls.Add(this.ddlDividendInterval);
            this.gpDividendInfo.Controls.Add(this.label3);
            this.gpDividendInfo.Controls.Add(this.label2);
            this.gpDividendInfo.Controls.Add(this.txtCurrentPrice);
            this.gpDividendInfo.Controls.Add(this.txtExDividend);
            this.gpDividendInfo.Controls.Add(this.txtPayDate);
            this.gpDividendInfo.Controls.Add(this.lblOpenPrice);
            this.gpDividendInfo.Controls.Add(this.txtOpenPrice);
            this.gpDividendInfo.Controls.Add(this.txtMarketCap);
            this.gpDividendInfo.Controls.Add(this.lblDaysRange);
            this.gpDividendInfo.Controls.Add(this.txtDayRange);
            this.gpDividendInfo.Controls.Add(this.lbl52WeekMiddle);
            this.gpDividendInfo.Controls.Add(this.txt52WeekHigh);
            this.gpDividendInfo.Controls.Add(this.lbl52WeekRange);
            this.gpDividendInfo.Controls.Add(this.txt52WeekLow);
            this.gpDividendInfo.Controls.Add(this.lblPERatio);
            this.gpDividendInfo.Controls.Add(this.txtPERatio);
            this.gpDividendInfo.Controls.Add(this.lblPayDate);
            this.gpDividendInfo.Controls.Add(this.lblExDividend);
            this.gpDividendInfo.Controls.Add(this.ddlIndustry);
            this.gpDividendInfo.Controls.Add(this.lblMarketCap);
            this.gpDividendInfo.Controls.Add(this.txtSymbol);
            this.gpDividendInfo.Controls.Add(this.label1);
            this.gpDividendInfo.Controls.Add(this.lblSymbol);
            this.gpDividendInfo.Controls.Add(this.txtDividendPercent);
            this.gpDividendInfo.Controls.Add(this.txtStockName);
            this.gpDividendInfo.Controls.Add(this.lblStockName);
            this.gpDividendInfo.Controls.Add(this.lblAnnualDividend);
            this.gpDividendInfo.Controls.Add(this.lblIndustry);
            this.gpDividendInfo.Controls.Add(this.txtAnnualDividend);
            this.gpDividendInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpDividendInfo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.gpDividendInfo.Location = new System.Drawing.Point(5, 5);
            this.gpDividendInfo.Name = "gpDividendInfo";
            this.gpDividendInfo.Size = new System.Drawing.Size(681, 275);
            this.gpDividendInfo.TabIndex = 15;
            this.gpDividendInfo.TabStop = false;
            this.gpDividendInfo.Text = "Shares Info:";
            // 
            // lblReq3
            // 
            this.lblReq3.AutoSize = true;
            this.lblReq3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReq3.ForeColor = System.Drawing.Color.Red;
            this.lblReq3.Location = new System.Drawing.Point(105, 78);
            this.lblReq3.Name = "lblReq3";
            this.lblReq3.Size = new System.Drawing.Size(12, 13);
            this.lblReq3.TabIndex = 56;
            this.lblReq3.Text = "*";
            this.lblReq3.Visible = false;
            // 
            // lblReq2
            // 
            this.lblReq2.AutoSize = true;
            this.lblReq2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReq2.ForeColor = System.Drawing.Color.Red;
            this.lblReq2.Location = new System.Drawing.Point(105, 51);
            this.lblReq2.Name = "lblReq2";
            this.lblReq2.Size = new System.Drawing.Size(12, 13);
            this.lblReq2.TabIndex = 55;
            this.lblReq2.Text = "*";
            this.lblReq2.Visible = false;
            // 
            // lblReq1
            // 
            this.lblReq1.AutoSize = true;
            this.lblReq1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReq1.ForeColor = System.Drawing.Color.Red;
            this.lblReq1.Location = new System.Drawing.Point(105, 28);
            this.lblReq1.Name = "lblReq1";
            this.lblReq1.Size = new System.Drawing.Size(12, 13);
            this.lblReq1.TabIndex = 54;
            this.lblReq1.Text = "*";
            this.lblReq1.Visible = false;
            // 
            // lblRequired
            // 
            this.lblRequired.AutoSize = true;
            this.lblRequired.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequired.ForeColor = System.Drawing.Color.Red;
            this.lblRequired.Location = new System.Drawing.Point(36, 250);
            this.lblRequired.Name = "lblRequired";
            this.lblRequired.Size = new System.Drawing.Size(63, 13);
            this.lblRequired.TabIndex = 53;
            this.lblRequired.Text = "*Required";
            this.lblRequired.Visible = false;
            // 
            // ddlDividendInterval
            // 
            this.ddlDividendInterval.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlDividendInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDividendInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlDividendInterval.ForeColor = System.Drawing.Color.Black;
            this.ddlDividendInterval.FormattingEnabled = true;
            this.ddlDividendInterval.Items.AddRange(new object[] {
            "Monthly",
            "Quarterly",
            "Yearly"});
            this.ddlDividendInterval.Location = new System.Drawing.Point(123, 74);
            this.ddlDividendInterval.Name = "ddlDividendInterval";
            this.ddlDividendInterval.Size = new System.Drawing.Size(210, 21);
            this.ddlDividendInterval.TabIndex = 2;
            this.ddlDividendInterval.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ddlDividendInterval_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Dividend Interval";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(367, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Current Price:";
            // 
            // txtCurrentPrice
            // 
            this.txtCurrentPrice.BackColor = System.Drawing.Color.AliceBlue;
            this.txtCurrentPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentPrice.ForeColor = System.Drawing.Color.Black;
            this.txtCurrentPrice.Location = new System.Drawing.Point(458, 131);
            this.txtCurrentPrice.Name = "txtCurrentPrice";
            this.txtCurrentPrice.ReadOnly = true;
            this.txtCurrentPrice.Size = new System.Drawing.Size(214, 20);
            this.txtCurrentPrice.TabIndex = 49;
            this.txtCurrentPrice.TabStop = false;
            this.txtCurrentPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCurrentPrice_KeyUp);
            // 
            // txtExDividend
            // 
            this.txtExDividend.BackColor = System.Drawing.Color.AliceBlue;
            this.txtExDividend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExDividend.ForeColor = System.Drawing.Color.Black;
            this.txtExDividend.Location = new System.Drawing.Point(122, 181);
            this.txtExDividend.Name = "txtExDividend";
            this.txtExDividend.ReadOnly = true;
            this.txtExDividend.Size = new System.Drawing.Size(210, 20);
            this.txtExDividend.TabIndex = 6;
            this.txtExDividend.TabStop = false;
            this.txtExDividend.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtExDividend_KeyUp);
            // 
            // txtPayDate
            // 
            this.txtPayDate.BackColor = System.Drawing.Color.AliceBlue;
            this.txtPayDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayDate.ForeColor = System.Drawing.Color.Black;
            this.txtPayDate.Location = new System.Drawing.Point(122, 207);
            this.txtPayDate.Name = "txtPayDate";
            this.txtPayDate.ReadOnly = true;
            this.txtPayDate.Size = new System.Drawing.Size(211, 20);
            this.txtPayDate.TabIndex = 48;
            this.txtPayDate.TabStop = false;
            this.txtPayDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPayDate_KeyUp);
            // 
            // lblOpenPrice
            // 
            this.lblOpenPrice.AutoSize = true;
            this.lblOpenPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpenPrice.Location = new System.Drawing.Point(378, 108);
            this.lblOpenPrice.Name = "lblOpenPrice";
            this.lblOpenPrice.Size = new System.Drawing.Size(74, 13);
            this.lblOpenPrice.TabIndex = 46;
            this.lblOpenPrice.Text = "Open Price:";
            // 
            // txtOpenPrice
            // 
            this.txtOpenPrice.BackColor = System.Drawing.Color.AliceBlue;
            this.txtOpenPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOpenPrice.ForeColor = System.Drawing.Color.Black;
            this.txtOpenPrice.Location = new System.Drawing.Point(458, 105);
            this.txtOpenPrice.Name = "txtOpenPrice";
            this.txtOpenPrice.ReadOnly = true;
            this.txtOpenPrice.Size = new System.Drawing.Size(214, 20);
            this.txtOpenPrice.TabIndex = 45;
            this.txtOpenPrice.TabStop = false;
            this.txtOpenPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtOpenPrice_KeyUp);
            // 
            // txtMarketCap
            // 
            this.txtMarketCap.BackColor = System.Drawing.Color.AliceBlue;
            this.txtMarketCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarketCap.ForeColor = System.Drawing.Color.Black;
            this.txtMarketCap.Location = new System.Drawing.Point(458, 51);
            this.txtMarketCap.Name = "txtMarketCap";
            this.txtMarketCap.ReadOnly = true;
            this.txtMarketCap.Size = new System.Drawing.Size(214, 20);
            this.txtMarketCap.TabIndex = 3;
            this.txtMarketCap.TabStop = false;
            this.txtMarketCap.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMarketCap_KeyUp);
            // 
            // lblDaysRange
            // 
            this.lblDaysRange.AutoSize = true;
            this.lblDaysRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDaysRange.Location = new System.Drawing.Point(372, 184);
            this.lblDaysRange.Name = "lblDaysRange";
            this.lblDaysRange.Size = new System.Drawing.Size(80, 13);
            this.lblDaysRange.TabIndex = 39;
            this.lblDaysRange.Text = "Days Range:";
            // 
            // txtDayRange
            // 
            this.txtDayRange.BackColor = System.Drawing.Color.AliceBlue;
            this.txtDayRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDayRange.ForeColor = System.Drawing.Color.Black;
            this.txtDayRange.Location = new System.Drawing.Point(458, 181);
            this.txtDayRange.Name = "txtDayRange";
            this.txtDayRange.ReadOnly = true;
            this.txtDayRange.Size = new System.Drawing.Size(215, 20);
            this.txtDayRange.TabIndex = 38;
            this.txtDayRange.TabStop = false;
            this.txtDayRange.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDayRange_KeyUp);
            // 
            // lbl52WeekMiddle
            // 
            this.lbl52WeekMiddle.AutoSize = true;
            this.lbl52WeekMiddle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl52WeekMiddle.Location = new System.Drawing.Point(562, 160);
            this.lbl52WeekMiddle.Name = "lbl52WeekMiddle";
            this.lbl52WeekMiddle.Size = new System.Drawing.Size(11, 13);
            this.lbl52WeekMiddle.TabIndex = 37;
            this.lbl52WeekMiddle.Text = "-";
            // 
            // txt52WeekHigh
            // 
            this.txt52WeekHigh.BackColor = System.Drawing.Color.AliceBlue;
            this.txt52WeekHigh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt52WeekHigh.ForeColor = System.Drawing.Color.Black;
            this.txt52WeekHigh.Location = new System.Drawing.Point(579, 157);
            this.txt52WeekHigh.Name = "txt52WeekHigh";
            this.txt52WeekHigh.ReadOnly = true;
            this.txt52WeekHigh.Size = new System.Drawing.Size(93, 20);
            this.txt52WeekHigh.TabIndex = 36;
            this.txt52WeekHigh.TabStop = false;
            this.txt52WeekHigh.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt52WeekHigh_KeyUp);
            // 
            // lbl52WeekRange
            // 
            this.lbl52WeekRange.AutoSize = true;
            this.lbl52WeekRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl52WeekRange.Location = new System.Drawing.Point(349, 158);
            this.lbl52WeekRange.Name = "lbl52WeekRange";
            this.lbl52WeekRange.Size = new System.Drawing.Size(103, 13);
            this.lbl52WeekRange.TabIndex = 35;
            this.lbl52WeekRange.Text = "52 Week Range:";
            // 
            // txt52WeekLow
            // 
            this.txt52WeekLow.BackColor = System.Drawing.Color.AliceBlue;
            this.txt52WeekLow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt52WeekLow.Location = new System.Drawing.Point(458, 157);
            this.txt52WeekLow.Name = "txt52WeekLow";
            this.txt52WeekLow.ReadOnly = true;
            this.txt52WeekLow.Size = new System.Drawing.Size(99, 20);
            this.txt52WeekLow.TabIndex = 34;
            this.txt52WeekLow.TabStop = false;
            this.txt52WeekLow.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt52WeekLow_KeyUp);
            // 
            // lblPERatio
            // 
            this.lblPERatio.AutoSize = true;
            this.lblPERatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPERatio.Location = new System.Drawing.Point(385, 81);
            this.lblPERatio.Name = "lblPERatio";
            this.lblPERatio.Size = new System.Drawing.Size(67, 13);
            this.lblPERatio.TabIndex = 31;
            this.lblPERatio.Text = "P/E Ratio:";
            // 
            // txtPERatio
            // 
            this.txtPERatio.BackColor = System.Drawing.Color.AliceBlue;
            this.txtPERatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPERatio.ForeColor = System.Drawing.Color.Black;
            this.txtPERatio.Location = new System.Drawing.Point(458, 78);
            this.txtPERatio.Name = "txtPERatio";
            this.txtPERatio.ReadOnly = true;
            this.txtPERatio.Size = new System.Drawing.Size(214, 20);
            this.txtPERatio.TabIndex = 30;
            this.txtPERatio.TabStop = false;
            this.txtPERatio.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPERatio_KeyUp);
            // 
            // lblPayDate
            // 
            this.lblPayDate.AutoSize = true;
            this.lblPayDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayDate.Location = new System.Drawing.Point(46, 213);
            this.lblPayDate.Name = "lblPayDate";
            this.lblPayDate.Size = new System.Drawing.Size(63, 13);
            this.lblPayDate.TabIndex = 29;
            this.lblPayDate.Text = "Pay Date:";
            // 
            // lblExDividend
            // 
            this.lblExDividend.AutoSize = true;
            this.lblExDividend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExDividend.Location = new System.Drawing.Point(29, 187);
            this.lblExDividend.Name = "lblExDividend";
            this.lblExDividend.Size = new System.Drawing.Size(79, 13);
            this.lblExDividend.TabIndex = 22;
            this.lblExDividend.Text = "Ex-Dividend:";
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
            "Utilities",
            "Equity Precious Metals",
            "Other"});
            this.ddlIndustry.Location = new System.Drawing.Point(123, 47);
            this.ddlIndustry.Name = "ddlIndustry";
            this.ddlIndustry.Size = new System.Drawing.Size(210, 21);
            this.ddlIndustry.TabIndex = 1;
            this.ddlIndustry.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ddlIndustry_KeyUp);
            // 
            // lblMarketCap
            // 
            this.lblMarketCap.AutoSize = true;
            this.lblMarketCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarketCap.Location = new System.Drawing.Point(376, 54);
            this.lblMarketCap.Name = "lblMarketCap";
            this.lblMarketCap.Size = new System.Drawing.Size(76, 13);
            this.lblMarketCap.TabIndex = 17;
            this.lblMarketCap.Text = "Market Cap:";
            // 
            // btnDividendPrice
            // 
            this.btnDividendPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDividendPrice.ForeColor = System.Drawing.Color.Black;
            this.btnDividendPrice.Location = new System.Drawing.Point(254, 33);
            this.btnDividendPrice.Name = "btnDividendPrice";
            this.btnDividendPrice.Size = new System.Drawing.Size(83, 23);
            this.btnDividendPrice.TabIndex = 18;
            this.btnDividendPrice.TabStop = false;
            this.btnDividendPrice.Text = "Get Dividend";
            this.btnDividendPrice.UseVisualStyleBackColor = true;
            this.btnDividendPrice.Click += new System.EventHandler(this.btnDividendPrice_Click);
            // 
            // btnGetSharePrice
            // 
            this.btnGetSharePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetSharePrice.ForeColor = System.Drawing.Color.Black;
            this.btnGetSharePrice.Location = new System.Drawing.Point(173, 33);
            this.btnGetSharePrice.Name = "btnGetSharePrice";
            this.btnGetSharePrice.Size = new System.Drawing.Size(75, 23);
            this.btnGetSharePrice.TabIndex = 15;
            this.btnGetSharePrice.TabStop = false;
            this.btnGetSharePrice.Text = "Get Cost";
            this.btnGetSharePrice.UseVisualStyleBackColor = true;
            this.btnGetSharePrice.Click += new System.EventHandler(this.btnGetSharePrice_Click);
            // 
            // lblSharePurchaseDate
            // 
            this.lblSharePurchaseDate.AutoSize = true;
            this.lblSharePurchaseDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSharePurchaseDate.Location = new System.Drawing.Point(15, 69);
            this.lblSharePurchaseDate.Name = "lblSharePurchaseDate";
            this.lblSharePurchaseDate.Size = new System.Drawing.Size(92, 13);
            this.lblSharePurchaseDate.TabIndex = 20;
            this.lblSharePurchaseDate.Text = "First Purchase:";
            // 
            // gpSharesOptions
            // 
            this.gpSharesOptions.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.gpSharesOptions.Controls.Add(this.dtpPurchaseDate);
            this.gpSharesOptions.Controls.Add(this.btnDividendPrice);
            this.gpSharesOptions.Controls.Add(this.btnGetSharePrice);
            this.gpSharesOptions.Controls.Add(this.txtCost);
            this.gpSharesOptions.Controls.Add(this.txtNumberOfShares);
            this.gpSharesOptions.Controls.Add(this.lblNumberShare);
            this.gpSharesOptions.Controls.Add(this.lblSharePurchaseDate);
            this.gpSharesOptions.Controls.Add(this.lblCost);
            this.gpSharesOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpSharesOptions.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.gpSharesOptions.Location = new System.Drawing.Point(692, 51);
            this.gpSharesOptions.Name = "gpSharesOptions";
            this.gpSharesOptions.Size = new System.Drawing.Size(351, 151);
            this.gpSharesOptions.TabIndex = 21;
            this.gpSharesOptions.TabStop = false;
            this.gpSharesOptions.Text = "Shares Options:";
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.CalendarMonthBackground = System.Drawing.Color.AliceBlue;
            this.dtpPurchaseDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPurchaseDate.Location = new System.Drawing.Point(127, 67);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(210, 20);
            this.dtpPurchaseDate.TabIndex = 3;
            this.dtpPurchaseDate.TabStop = false;
            // 
            // txtEPS
            // 
            this.txtEPS.BackColor = System.Drawing.Color.AliceBlue;
            this.txtEPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEPS.ForeColor = System.Drawing.Color.Black;
            this.txtEPS.Location = new System.Drawing.Point(122, 155);
            this.txtEPS.Name = "txtEPS";
            this.txtEPS.ReadOnly = true;
            this.txtEPS.Size = new System.Drawing.Size(211, 20);
            this.txtEPS.TabIndex = 58;
            this.txtEPS.TabStop = false;
            this.txtEPS.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtEPS_KeyUp);
            // 
            // lblEPS
            // 
            this.lblEPS.AutoSize = true;
            this.lblEPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEPS.Location = new System.Drawing.Point(46, 161);
            this.lblEPS.Name = "lblEPS";
            this.lblEPS.Size = new System.Drawing.Size(31, 13);
            this.lblEPS.TabIndex = 57;
            this.lblEPS.Text = "EPS";
            // 
            // Dividends
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.ClientSize = new System.Drawing.Size(1047, 292);
            this.Controls.Add(this.gpSharesOptions);
            this.Controls.Add(this.gpDividendInfo);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Dividends";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Dividend Stock";
            this.Load += new System.EventHandler(this.Dividends_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Dividends_KeyUp);
            this.gpDividendInfo.ResumeLayout(false);
            this.gpDividendInfo.PerformLayout();
            this.gpSharesOptions.ResumeLayout(false);
            this.gpSharesOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSymbol;
        private System.Windows.Forms.Label lblStockName;
        private System.Windows.Forms.TextBox txtStockName;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label lblIndustry;
        private System.Windows.Forms.Label lblNumberShare;
        private System.Windows.Forms.TextBox txtNumberOfShares;
        private System.Windows.Forms.Label lblAnnualDividend;
        private System.Windows.Forms.TextBox txtAnnualDividend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDividendPercent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gpDividendInfo;
        private System.Windows.Forms.Button btnGetSharePrice;
        private System.Windows.Forms.Label lblMarketCap;
        private System.Windows.Forms.Button btnDividendPrice;
        private System.Windows.Forms.Label lblSharePurchaseDate;
        private System.Windows.Forms.GroupBox gpSharesOptions;
        private System.Windows.Forms.ComboBox ddlIndustry;
        private System.Windows.Forms.Label lblExDividend;
        private System.Windows.Forms.Label lblPayDate;
        private System.Windows.Forms.Label lblPERatio;
        private System.Windows.Forms.TextBox txtPERatio;
        private System.Windows.Forms.Label lbl52WeekMiddle;
        private System.Windows.Forms.TextBox txt52WeekHigh;
        private System.Windows.Forms.Label lbl52WeekRange;
        private System.Windows.Forms.TextBox txt52WeekLow;
        private System.Windows.Forms.Label lblDaysRange;
        private System.Windows.Forms.TextBox txtDayRange;
        private System.Windows.Forms.TextBox txtMarketCap;
        private System.Windows.Forms.Label lblOpenPrice;
        private System.Windows.Forms.TextBox txtOpenPrice;
        private System.Windows.Forms.TextBox txtExDividend;
        private System.Windows.Forms.TextBox txtPayDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCurrentPrice;
        private System.Windows.Forms.ComboBox ddlDividendInterval;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.Label lblRequired;
        private System.Windows.Forms.Label lblReq3;
        private System.Windows.Forms.Label lblReq2;
        private System.Windows.Forms.Label lblReq1;
        private System.Windows.Forms.TextBox txtEPS;
        private System.Windows.Forms.Label lblEPS;
    }
}