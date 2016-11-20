using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DividendLiberty.Excel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.Util;
using System.IO;
using System.Collections;

namespace DividendLiberty
{
    public static class PortfolioExcel
    {
        public static void GeneratePortfolioExcel()
        {
            DataTable dt = uti.SortDataTable(uti.GetXMLData(FileTypes.xml), "symbol", "asc");
            string stocks = uti.GetStockSymbols(dt, ",", true, false);
            DataTable dtCache = uti.FilterDataTable(uti.GetXMLData(FileTypes.cache), stocks);
            string[] annualDiv = uti.GetColValues(dtCache, DivCacheCodes.annualDiv.ToString());
            string[] yields = uti.GetColValues(dtCache, DivCacheCodes.divPercent.ToString());
            string[] companies = uti.GetColValues(dtCache, DivCacheCodes.stockname.ToString());

            //string[] annualDiv = uti.SplitStockData(YahooFinance.GetValues(stocks, YahooFinance.GetCodes(YahooCodes.annualDividend), true));
            //string[] yields = uti.SplitStockData(YahooFinance.GetValues(stocks, YahooFinance.GetCodes(YahooCodes.dividendYield), true));
            //string[] companies = uti.SplitStockData(YahooFinance.GetValues(stocks, YahooFinance.GetCodes(YahooCodes.stockname), true));

            string savePath = uti.GetFilePath(FileTypes.excel);
            ExcelNPOIWriter excelObj = new ExcelNPOIWriter();
            excelObj.CreateWorksheet("My Dividends");
            List<int> lstForumaCol = new List<int>();
            DataTable dtFinal = ConvertExcelData(dt, yields, annualDiv, companies, out lstForumaCol);
            excelObj.WriteData(dtFinal, "My Dividends", true);
            excelObj.createStyle("headers");
            excelObj.setFont("headers", true);
            for (int i = 0; i < dtFinal.Columns.Count; i++)
            {
                excelObj.getCell(0, i, "My Dividends").CellStyle = excelObj.getStyle("headers");
            }

            int count = dtFinal.Rows.Count;
            for (int a = 0; a < lstForumaCol.Count; a++)
            {
                if (lstForumaCol[a] == 6)
                {
                    HSSFCell AvgYield = excelObj.getCell(count, a, "My Dividends");
                    AvgYield.SetCellType(CellType.FORMULA);
                    AvgYield.CellFormula = string.Format("ROUND(SUM({0}{1}:{0}{2})/{3}, 2)", uti.GetExcelColLetter(a), 2, count, count - 1);
                    excelObj.getCell(count, a, "My Dividends").CellStyle = excelObj.getStyle("headers");
                }

                //monthly avg dividends
                if (lstForumaCol[a] == 7)
                {
                    int yearlyIndex = 0;
                    int sharesIndex = 0;
                    int yearlySharesCnt = 0;
                    for (int b = 0; b < lstForumaCol.Count; b++)
                    {
                        if (lstForumaCol[b] == 5)
                        {
                            yearlyIndex = b;
                            yearlySharesCnt++;
                        }

                        if (lstForumaCol[b] == 3)
                        {
                            sharesIndex = b;
                            yearlySharesCnt++;
                        }
                    }

                    if (yearlySharesCnt == 2)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            HSSFCell YearlyDividendCol = excelObj.getCell(i + 1, a, "My Dividends");
                            YearlyDividendCol.SetCellType(CellType.FORMULA);
                            YearlyDividendCol.CellFormula = string.Format("ROUND({0}{1}*{2}{3}/12, 2)", uti.GetExcelColLetter(sharesIndex), i + 2, uti.GetExcelColLetter(yearlyIndex), i + 2);
                            //excelObj.getCell(count, a, "My Dividends").CellStyle = excelObj.getStyle("headers");
                        }
                    }
                    HSSFCell MonthlyDiv = excelObj.getCell(count, a, "My Dividends");
                    MonthlyDiv.SetCellType(CellType.FORMULA);
                    MonthlyDiv.CellFormula = string.Format("ROUND(SUM({0}{1}:{0}{2}), 2)", uti.GetExcelColLetter(a), 2, count);
                    excelObj.getCell(count, a, "My Dividends").CellStyle = excelObj.getStyle("headers");
                }

                //quarterly avg dividend
                if (lstForumaCol[a] == 8)
                {
                    int yearlyIndex = 0;
                    int sharesIndex = 0;
                    int yearlySharesCnt = 0;
                    for (int b = 0; b < lstForumaCol.Count; b++)
                    {
                        if (lstForumaCol[b] == 5)
                        {
                            yearlyIndex = b;
                            yearlySharesCnt++;
                        }

                        if (lstForumaCol[b] == 3)
                        {
                            sharesIndex = b;
                            yearlySharesCnt++;
                        }
                    }

                    if (yearlySharesCnt == 2)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            HSSFCell YearlyDividendCol = excelObj.getCell(i + 1, a, "My Dividends");
                            YearlyDividendCol.SetCellType(CellType.FORMULA);
                            YearlyDividendCol.CellFormula = string.Format("ROUND({0}{1}*{2}{3}/4, 2)", uti.GetExcelColLetter(sharesIndex), i + 2, uti.GetExcelColLetter(yearlyIndex), i + 2);
                            //excelObj.getCell(count, a, "My Dividends").CellStyle = excelObj.getStyle("headers");
                        }
                    }
                    HSSFCell QuarterlyDiv = excelObj.getCell(count, a, "My Dividends");
                    QuarterlyDiv.SetCellType(CellType.FORMULA);
                    QuarterlyDiv.CellFormula = string.Format("ROUND(SUM({0}{1}:{0}{2}), 2)", uti.GetExcelColLetter(a), 2, count);
                    excelObj.getCell(count, a, "My Dividends").CellStyle = excelObj.getStyle("headers");
                }
                // yearly dividend
                if (lstForumaCol[a] == 9)
                {
                    int yearlyIndex = 0;
                    int sharesIndex = 0;
                    int yearlySharesCnt = 0;
                    for (int b = 0; b < lstForumaCol.Count; b++)
                    {
                        if (lstForumaCol[b] == 5)
                        {
                            yearlyIndex = b;
                            yearlySharesCnt++;
                        }

                        if (lstForumaCol[b] == 3)
                        {
                            sharesIndex = b;
                            yearlySharesCnt++;
                        }
                    }

                    if (yearlySharesCnt == 2)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            HSSFCell YearlyDividendCol = excelObj.getCell(i + 1, a, "My Dividends");
                            YearlyDividendCol.SetCellType(CellType.FORMULA);
                            YearlyDividendCol.CellFormula = string.Format("ROUND({0}{1}*{2}{3}, 2)", uti.GetExcelColLetter(sharesIndex), i + 2, uti.GetExcelColLetter(yearlyIndex), i + 2);
                            //excelObj.getCell(count, a, "My Dividends").CellStyle = excelObj.getStyle("headers");
                        }
                    }

                    HSSFCell YearlyDiv = excelObj.getCell(count, a, "My Dividends");
                    YearlyDiv.SetCellType(CellType.FORMULA);
                    YearlyDiv.CellFormula = string.Format("ROUND(SUM({0}{1}:{0}{2}), 2)", uti.GetExcelColLetter(a), 2, count);
                    excelObj.getCell(count, a, "My Dividends").CellStyle = excelObj.getStyle("headers");
                }
                if (lstForumaCol[a] == 10)
                {
                    int priceIndex = 0;
                    int sharesIndex = 0;
                    int priceSharesCount = 0;
                    for (int b = 0; b < lstForumaCol.Count; b++)
                    {
                        if (lstForumaCol[b] == 3)
                        {
                            priceIndex = b;
                            priceSharesCount++;
                        }
                        if (lstForumaCol[b] == 4)
                        {
                            sharesIndex = b;
                            priceSharesCount++;
                        }
                    }

                    if (priceSharesCount == 2)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            HSSFCell TotalCostBasisCol = excelObj.getCell(i + 1, a, "My Dividends");
                            TotalCostBasisCol.SetCellType(CellType.FORMULA);
                            TotalCostBasisCol.CellFormula = string.Format("ROUND({0}{1}*{2}{3}, 2)", uti.GetExcelColLetter(priceIndex), i + 2, uti.GetExcelColLetter(sharesIndex), i + 2);
                            //excelObj.getCell(count, a, "My Dividends").CellStyle = excelObj.getStyle("headers");
                        }
                    }
                    HSSFCell TotalCostBasis = excelObj.getCell(count, a, "My Dividends");
                    TotalCostBasis.SetCellType(CellType.FORMULA);
                    TotalCostBasis.CellFormula = string.Format("SUM({0}{1}:{0}{2})", uti.GetExcelColLetter(a), 2, count);
                    excelObj.getCell(count, a, "My Dividends").CellStyle = excelObj.getStyle("headers");
                }
            }

            AutoSizeColumns(excelObj, dtFinal, "My Dividends");
            excelObj.Save(savePath);
            excelObj.Dispose();
            System.Diagnostics.Process.Start(savePath);
        }


        public static DataTable ConvertExcelData(DataTable dt, string[] yields, string[] annualDiv, string[] company, out List<int> lstForumaCol)
        {
            DataTable dtFinal = GetFinalTables();
            string[] col = INIFileOptions.ReadINIKeyValues(KeyPartition.columnName);
            string[] visible = INIFileOptions.ReadINIKeyValues(KeyPartition.visible);
            lstForumaCol = new List<int>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["active"].ToString() == "true")
                {
                    DataRow dr = dtFinal.NewRow();
                    decimal shares = Convert.ToDecimal(dt.Rows[i]["shares"]);
                    decimal cost = Convert.ToDecimal(dt.Rows[i]["cost"]);
                    decimal annDiv = annualDiv[i] == "N/A" ? 0 : Convert.ToDecimal(annualDiv[i]);
                    decimal yearlyDiv = Math.Round(shares * annDiv, 2);
                    INIFile ini = new INIFile(uti.GetFilePath(FileTypes.ini));
                    int visCnt = 0;
                    int cnt = 0;
                    if (visible[visCnt++] == "True")
                    {
                        dr[col[cnt].ToLower()] = dt.Rows[i]["symbol"].ToString();
                    }
                    cnt++;
                    if (visible[visCnt++] == "True")
                    {
                        dr[col[cnt].ToLower()] = company[i].Length == 0 ? "" : company[i].ToString();
                    }
                    cnt++;
                    if (visible[visCnt++] == "True")
                    {
                        dr[col[cnt].ToLower()] = dt.Rows[i]["industry"].ToString();
                    }
                    cnt++;
                    if (visible[visCnt++] == "True")
                    {
                        dr[col[cnt].ToLower()] = Convert.ToDouble(shares);
                    }
                    cnt++;
                    if (visible[visCnt++] == "True")
                    {
                        dr[col[cnt].ToLower()] = Convert.ToDouble(cost);
                    }
                    cnt++;
                    if (visible[visCnt++] == "True")
                    {
                        dr[col[cnt].ToLower()] = Convert.ToDouble(annDiv);
                    }
                    cnt++;
                    if (visible[visCnt++] == "True")
                    {
                        dr[col[cnt].ToLower()] = yields[i] == "N/A" ? 0 : yields[i] == "" ? 0 : Convert.ToDouble(yields[i]);
                    }
                    cnt++;
                    if (visible[visCnt++] == "True")
                    {
                        dr[col[cnt].ToLower()] = Convert.ToDouble(Math.Round(yearlyDiv / 12, 2));
                    }
                    cnt++;
                    if (visible[visCnt++] == "True")
                    {
                        dr[col[cnt].ToLower()] = Convert.ToDouble(Math.Round(yearlyDiv / 4, 2));

                    }
                    cnt++;
                    if (visible[visCnt++] == "True")
                    {
                        dr[col[cnt].ToLower()] = Convert.ToDouble(yearlyDiv);
                    }
                    cnt++;
                    if (visible[visCnt++] == "True")
                    {
                        dr[col[cnt].ToLower()] = Math.Round(Convert.ToDouble(shares * cost), 2);
                    }
                    cnt = 0;
                    visCnt = 0;
                    //if (visible[cnt] == "true")
                    //{
                    //    yearlyDividends += Convert.ToDecimal(yearlyDiv);
                    //}
                    //totalCost += Math.Round(Convert.ToDecimal(dt.Rows[i]["shares"]) * Convert.ToDecimal(dt.Rows[i]["cost"]), 2);
                    dtFinal.Rows.Add(dr);
                }
            }

            for (int a = 0; a < visible.Length; a++)
            {
                if (visible[a] == "True")
                {
                    lstForumaCol.Add(a);
                }
            }

            DataRow drEmpty = dtFinal.NewRow();
            if (visible[6] == "True")
            {
                //industry
                drEmpty[col[6].ToLower()] = 0;
            }
            //drEmpty["Annual Dividend"] = 0;
            if (visible[7] == "True")
            {
                drEmpty[col[7].ToLower()] = 0;
            }
            if (visible[8] == "True")
            {
                drEmpty[col[8].ToLower()] = 0;
            }
            if (visible[9] == "True")
            {
                drEmpty[col[9].ToLower()] = 0;
            }
            if (visible[10] == "True")
            {
                drEmpty[col[10].ToLower()] = 0;
            }
            dtFinal.Rows.Add(drEmpty);
            return dtFinal;
        }

        public static DataTable GetFinalTables()
        {
            DataTable dtFinal = new DataTable();
            string[] col = INIFileOptions.ReadINIKeyValues(KeyPartition.columnName);
            string[] visible = INIFileOptions.ReadINIKeyValues(KeyPartition.visible);
            for (int i = 0; i < visible.Length; i++)
            {
                if (i <= 2)
                {
                    if (visible[i] == "True")
                    {
                        dtFinal.Columns.Add(col[i], typeof(string));
                    }
                }
                else
                {
                    if (visible[i] == "True")
                    {
                        dtFinal.Columns.Add(col[i], typeof(double));
                    }
                }
            }
            return dtFinal;
        }

        private static void AutoSizeColumns(Excel.ExcelNPOIWriter exObj, DataTable tbl, string sheetName)
        {
            for (int i = 0; i <= tbl.Columns.Count; i++)
            {
                exObj.AutoSizeColumn(i, sheetName);
            }
        }
    }
}
