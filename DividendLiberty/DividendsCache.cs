using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.Xml.Linq;
using System.Drawing;


namespace DividendLiberty
{
    public static class DividendsCache
    {
        public static void LoadInitialDividendCache(string[] ids, string[] symbols, string[] exDividend, string[] annualDiv, string[] payDates, string[] eps, string[] divPercent,
            string[] stockname, string[] marketCap, string[] peRatio, string[] openPrice, string[] currentPrice, string[] fiftyTwoWeekLow, string[]fiftyTwoWeekHigh, string[] daysRange, DataTable dtCache, DataTable dtDivs)
        {
            //DataTable dt = uti.GetXMLData(FileTypes.cache);
            try
            {
                //bool isPass = dt.Rows.Count == ids.Length && dt.Rows.Count == symbols.Length && dt.Rows.Count == exDividend.Length && dt.Rows.Count == annualDiv.Length && dt.Rows.Count == payDates.Length && dt.Rows.Count == eps.Length && dt.Rows.Count == divPercent.Length
                //    && dt.Rows.Count == stockname.Length && dt.Rows.Count == marketCap.Length && dt.Rows.Count == peRatio.Length && dt.Rows.Count == openPrice.Length && dt.Rows.Count == currentPrice.Length &&
                //    dt.Rows.Count == fiftyTwoWeekLow.Length && dt.Rows.Count == fiftyTwoWeekHigh.Length && dt.Rows.Count == daysRange.Length;
                //if (isPass)
                //{
                XmlDocument doc = new XmlDocument();
                doc.Load(uti.GetFilePath(FileTypes.cache));
                //if(dtCache.Rows.Count != dtDivs.Rows.Count)
                for (int a = 0; a < dtDivs.Rows.Count; a++)
                {
                    //if (dtDivs.Rows.Count == dtCache.Rows.Count)
                    //{
                    //    continue;
                    //}
                        if (idExist(dtDivs.Rows[a]["id"].ToString(), dtCache))
                        {
                            //Console.WriteLine(dt.Rows[a]["id"].ToString() + " exist");
                            // compare and update xml as needed.

                            string id = dtDivs.Rows[a]["id"].ToString();

                            if (symbols.Length > 1)
                            {
                                if (dtCache.Rows[a]["symbol"].ToString() != symbols[a])
                                {
                                    UpdateDividendCache(id, "symbol", symbols[a]);
                                }
                            }
                            if (exDividend.Length > 1)
                            {
                                if (dtCache.Rows[a]["exDividend"].ToString() != exDividend[a])
                                {
                                    UpdateDividendCache(id, "exDividend", exDividend[a]);
                                }
                            }
                            if (annualDiv.Length > 1)
                            {
                                if (dtCache.Rows[a]["annualDiv"].ToString() != annualDiv[a])
                                {
                                    UpdateDividendCache(id, "annualDiv", annualDiv[a]);
                                }
                            }
                            if (payDates.Length > 1)
                            {
                                if (dtCache.Rows[a]["payDates"].ToString() != payDates[a])
                                {
                                    UpdateDividendCache(id, "payDates", payDates[a]);
                                }
                            }
                            if (eps.Length > 1)
                            {
                                if (dtCache.Rows[a]["eps"].ToString() != eps[a])
                                {
                                    UpdateDividendCache(id, "eps", eps[a]);
                                }
                            }
                            if (divPercent.Length > 1)
                            {
                                if (dtCache.Rows[a]["divPercent"].ToString() != divPercent[a])
                                {
                                    UpdateDividendCache(id, "divPercent", divPercent[a]);
                                }
                            }
                            if (stockname.Length > 1)
                            {
                                if (dtCache.Rows[a]["stockname"].ToString() != stockname[a])
                                {
                                    UpdateDividendCache(id, "stockname", stockname[a]);
                                }
                            }
                            if (marketCap.Length > 1)
                            {
                                if (dtCache.Rows[a]["marketCap"].ToString() != marketCap[a])
                                {
                                    UpdateDividendCache(id, "marketCap", marketCap[a]);
                                }
                            }
                            if (peRatio.Length > 1)
                            {
                                if (dtCache.Rows[a]["peRatio"].ToString() != peRatio[a])
                                {
                                    UpdateDividendCache(id, "peRatio", peRatio[a]);
                                }
                            }
                            if (openPrice.Length > 1)
                            {
                                if (dtCache.Rows[a]["openPrice"].ToString() != openPrice[a])
                                {
                                    UpdateDividendCache(id, "openPrice", openPrice[a]);
                                }
                            }
                            if (currentPrice.Length > 1)
                            {
                                if (dtCache.Rows[a]["currentPrice"].ToString() != currentPrice[a])
                                {
                                    UpdateDividendCache(id, "currentPrice", currentPrice[a]);
                                }
                            }
                            if (fiftyTwoWeekLow.Length > 1)
                            {
                                if (dtCache.Rows[a]["fiftyTwoWeekLow"].ToString() != fiftyTwoWeekLow[a])
                                {
                                    UpdateDividendCache(id, "fiftyTwoWeek", fiftyTwoWeekLow[a]);
                                }
                            }
                            if (fiftyTwoWeekHigh.Length > 1)
                            {
                                if (dtCache.Rows[a]["fiftyTwoWeekHigh"].ToString() != fiftyTwoWeekHigh[a])
                                {
                                    UpdateDividendCache(id, "fiftyTwoWeek", fiftyTwoWeekHigh[a]);
                                }
                            }
                            if (daysRange.Length > 1)
                            {
                                if (dtCache.Rows[a]["daysRange"].ToString() != daysRange[a])
                                {
                                    UpdateDividendCache(id, "daysRange", daysRange[a]);
                                }
                            }
                        }
                    else
                    {
                        //Console.WriteLine(dtCache.Rows[a]["id"].ToString() + " not exist");
                         //add new to xml.

                        //int newID = uti.IncrementStockID(FileTypes.cache);
                        string strNamespace = doc.DocumentElement.NamespaceURI;
                        XmlNode node = doc.CreateNode(XmlNodeType.Element, string.Format("dividendstock"), strNamespace);
                        XmlAttribute idAttr = doc.CreateAttribute("ID");
                        idAttr.Value = dtDivs.Rows.Count == ids.Length ? ids[a] : dtDivs.Rows[a]["id"].ToString();
                        node.Attributes.Append(idAttr);
                        XmlNode nodeID = doc.CreateElement("id");
                        nodeID.InnerText = dtDivs.Rows.Count == ids.Length ? ids[a] : dtDivs.Rows[a]["id"].ToString();
                        node.AppendChild(nodeID);

                        XmlNode nodeSymbol = doc.CreateElement("symbol");
                        nodeSymbol.InnerText = dtDivs.Rows.Count == symbols.Length ? symbols[a] : "";
                        node.AppendChild(nodeSymbol);

                        XmlNode nodeExDiv = doc.CreateElement("exDividend");
                        nodeExDiv.InnerText = dtDivs.Rows.Count == exDividend.Length ? exDividend[a] : "";
                        node.AppendChild(nodeExDiv);

                        XmlNode nodeAnnualDiv = doc.CreateElement("annualDiv");
                        nodeAnnualDiv.InnerText = dtDivs.Rows.Count == annualDiv.Length ? annualDiv[a] : "";
                        node.AppendChild(nodeAnnualDiv);

                        XmlNode nodePayDates = doc.CreateElement("payDates");
                        nodePayDates.InnerText = dtDivs.Rows.Count == payDates.Length ? payDates[a] : "";
                        node.AppendChild(nodePayDates);

                        XmlNode nodeEps = doc.CreateElement("eps");
                        nodeEps.InnerText = dtDivs.Rows.Count == eps.Length ? eps[a] : "";
                        node.AppendChild(nodeEps);

                        XmlNode nodeDivPercent = doc.CreateElement("divPercent");
                        nodeDivPercent.InnerText = dtDivs.Rows.Count == divPercent.Length ? divPercent[a] : "";
                        node.AppendChild(nodeDivPercent);

                        XmlNode nodeStockName = doc.CreateElement("stockname");
                        nodeStockName.InnerText = dtDivs.Rows.Count == stockname.Length ? stockname[a] : "";
                        node.AppendChild(nodeStockName);

                        XmlNode nodeMarketCap = doc.CreateElement("marketCap");
                        nodeMarketCap.InnerText = dtDivs.Rows.Count == marketCap.Length ? marketCap[a] : "";
                        node.AppendChild(nodeMarketCap);

                        XmlNode nodePeRatio = doc.CreateElement("peRatio");
                        nodePeRatio.InnerText = dtDivs.Rows.Count == peRatio.Length ? peRatio[a] : "";
                        node.AppendChild(nodePeRatio);

                        XmlNode nodeOpenPrice = doc.CreateElement("openPrice");
                        nodeOpenPrice.InnerText = dtDivs.Rows.Count == openPrice.Length ? openPrice[a] : "";
                        node.AppendChild(nodeOpenPrice);

                        XmlNode nodeCurrentPrice = doc.CreateElement("currentPrice");
                        nodeCurrentPrice.InnerText = dtDivs.Rows.Count == currentPrice.Length ? currentPrice[a] : "";
                        node.AppendChild(nodeCurrentPrice);

                        XmlNode nodeFiftyTwoWeekLow = doc.CreateElement("fiftyTwoWeekLow");
                        nodeFiftyTwoWeekLow.InnerText = dtDivs.Rows.Count == fiftyTwoWeekLow.Length ? fiftyTwoWeekLow[a] : "";
                        node.AppendChild(nodeFiftyTwoWeekLow);

                        XmlNode nodeFiftyTwoWeekHigh = doc.CreateElement("fiftyTwoWeekHigh");
                        nodeFiftyTwoWeekHigh.InnerText = dtDivs.Rows.Count == fiftyTwoWeekHigh.Length ? fiftyTwoWeekHigh[a] : "";
                        node.AppendChild(nodeFiftyTwoWeekHigh);

                        XmlNode nodeDaysRange = doc.CreateElement("daysRange");
                        nodeDaysRange.InnerText = dtDivs.Rows.Count == daysRange.Length ? daysRange[a] : "";
                        node.AppendChild(nodeDaysRange);

                        doc.DocumentElement["dividendstocks"].AppendChild(node);
                        //newID++;
                        doc.Save(uti.GetFilePath(FileTypes.cache));
                        //dt = uti.GetXMLData(FileTypes.cache);
                    }
 
                }
            }
            catch (Exception e)
            {
            }
        }


        public static void AddDividendStock(string newID, string[] symbols, string[] exDividend, string[] annualDiv, string[] payDates, string[] eps, string[] divPercent,
            string[] stockname, string[] marketCap, string[] peRatio, string[] openPrice, string[] currentPrice, string[] fiftyTwoWeekLow, string[]fiftyTwoWeekHigh, string[] daysRange)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(uti.GetFilePath(FileTypes.cache));
            try
            {
                string strNamespace = doc.DocumentElement.NamespaceURI;
                XmlNode node = doc.CreateNode(XmlNodeType.Element, string.Format("dividendstock"), strNamespace);
                XmlAttribute idAttr = doc.CreateAttribute("ID");
                idAttr.Value = newID.ToString();
                node.Attributes.Append(idAttr);
                XmlNode nodeID = doc.CreateElement("id");
                nodeID.InnerText = newID.ToString();
                node.AppendChild(nodeID);

                XmlNode nodeSymbol = doc.CreateElement("symbol");
                nodeSymbol.InnerText = symbols.Length != 0 ? symbols[0] : "";
                node.AppendChild(nodeSymbol);

                XmlNode nodeExDiv = doc.CreateElement("exDividend");
                nodeExDiv.InnerText = exDividend.Length != 0 ? exDividend[0] : "";
                node.AppendChild(nodeExDiv);

                XmlNode nodeAnnualDiv = doc.CreateElement("annualDiv");
                nodeAnnualDiv.InnerText = annualDiv.Length != 0 ? annualDiv[0] : "";
                node.AppendChild(nodeAnnualDiv);

                XmlNode nodePayDates = doc.CreateElement("payDates");
                nodePayDates.InnerText = payDates.Length != 0 ? payDates[0] : "";
                node.AppendChild(nodePayDates);

                XmlNode nodeEps = doc.CreateElement("eps");
                nodeEps.InnerText = eps.Length != 0 ? eps[0] : "";
                node.AppendChild(nodeEps);

                XmlNode nodeDivPercent = doc.CreateElement("divPercent");
                nodeDivPercent.InnerText = divPercent.Length != 0 ? divPercent[0] : "";
                node.AppendChild(nodeDivPercent);

                XmlNode nodeStockName = doc.CreateElement("stockname");
                nodeStockName.InnerText = stockname.Length != 0 ? stockname[0] : "";
                node.AppendChild(nodeStockName);

                XmlNode nodeMarketCap = doc.CreateElement("marketCap");
                nodeMarketCap.InnerText = marketCap.Length != 0 ? marketCap[0] : "";
                node.AppendChild(nodeMarketCap);

                XmlNode nodePeRatio = doc.CreateElement("peRatio");
                nodePeRatio.InnerText = peRatio.Length != 0 ? peRatio[0] : "";
                node.AppendChild(nodePeRatio);

                XmlNode nodeOpenPrice = doc.CreateElement("openPrice");
                nodeOpenPrice.InnerText = openPrice.Length != 0 ? openPrice[0] : "";
                node.AppendChild(nodeOpenPrice);

                XmlNode nodeCurrentPrice = doc.CreateElement("currentPrice");
                nodeCurrentPrice.InnerText = currentPrice.Length != 0 ? currentPrice[0] : "";
                node.AppendChild(nodeCurrentPrice);

                XmlNode nodeFiftyTwoWeekLow = doc.CreateElement("fiftyTwoWeekLow");
                nodeFiftyTwoWeekLow.InnerText = fiftyTwoWeekLow.Length != 0 ? fiftyTwoWeekLow[0] : "";
                node.AppendChild(nodeFiftyTwoWeekLow);

                XmlNode nodeFiftyTwoWeekHigh = doc.CreateElement("fiftyTwoWeekHigh");
                nodeFiftyTwoWeekHigh.InnerText = fiftyTwoWeekHigh.Length != 0 ? fiftyTwoWeekHigh[0] : "";
                node.AppendChild(nodeFiftyTwoWeekHigh);

                XmlNode nodeDaysRange = doc.CreateElement("daysRange");
                nodeDaysRange.InnerText = daysRange.Length != 0 ? daysRange[0] : "";
                node.AppendChild(nodeDaysRange);

                doc.DocumentElement["dividendstocks"].AppendChild(node);
                //newID++;
                doc.Save(uti.GetFilePath(FileTypes.cache));
            }
            catch (Exception e)
            {

            }
        }

        public static void UpdateDividendCache(string id, string col, string val)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(uti.GetFilePath(FileTypes.cache));
                XmlNodeList elements = doc.SelectNodes(string.Format("//dividendstock[@ID='{0}']", id));
                elements[0][col].InnerText = val;
                doc.Save(uti.GetFilePath(FileTypes.cache));
            }
            catch (Exception e)
            {

            }
        }

        public static bool idExist(string val, DataTable dtCache)
        {
            for (int a = 0; a < dtCache.Rows.Count; a++)
            {
                if (dtCache.Rows[a]["id"].ToString() == val)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool symbolExist(string toCompare, DataTable dt)
        {
            for (int a = 0; a < dt.Rows.Count; a++)
            {
                if (dt.Rows[a]["symbol"].ToString() == toCompare)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
