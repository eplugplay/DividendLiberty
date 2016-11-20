using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace DividendLiberty
{
    public class TimedWebClient : WebClient
    {
        // Timeout in milliseconds, default = 600,000 msec
        public int Timeout { get; set; }

        public TimedWebClient()
        {
            this.Timeout = 600000;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var objWebRequest = base.GetWebRequest(address);
            objWebRequest.Timeout = this.Timeout;
            return objWebRequest;
        }
    }

    public static class YahooFinance
    {
        public static string GetValues(string symbol, string code, bool isMulti)
        {
            string value = "";
            using (WebClient client = new WebClient())
            {
                var url = string.Format("http://finance.yahoo.com/d/quotes.csv?s={0}&f={1}", symbol, code);
                //Trademe.DownloadStringCompleted += new DownloadStringCompletedEventHandler(Trademe_DownloadStringCompleted);
                //Trademe.DownloadStringAsync(new Uri("http://www.google.com"));
                try
                {
                    value = new TimedWebClient { Timeout = 1000 }.DownloadString(url);
                }
                catch
                {

                }
                if (!isMulti)
                {
                    value = value.Replace("\"", "");
                    value = value.Replace("\n", "");
                }
                else
                {
                    value = value.Replace("\"", "");
                }
            }
            return value.Trim();
        }

        //public void Trademe_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        //{
        //    if (e.Error != null)
        //        return;

        //    var r = e.Result;
        //}

        public static string GetCodes(YahooCodes codes)
        {
            string code = "";
            switch (codes)
            {
                case YahooCodes.stockname: code = "n"; break;
                case YahooCodes.annualDividend: code = "d"; break;
                case YahooCodes.dividendYield: code = "y"; break;
                case YahooCodes.marketCap: code = "j1"; break;
                case YahooCodes.exDividend: code = "q"; break;
                case YahooCodes.payDate: code = "r1"; break;
                case YahooCodes.peRatio: code = "r"; break;
                case YahooCodes.dayRange: code = "m"; break;
                case YahooCodes.fiftyTwoWeekLow: code = "j"; break;
                case YahooCodes.fiftyTwoWeekHigh: code = "k"; break;
                case YahooCodes.currentPrice: code = "a"; break;
                case YahooCodes.openPrice: code = "o"; break;
                case YahooCodes.eps : code = "e"; break;
                default: break;
            }
            return code;
        }
    }
}

    public enum YahooCodes
    {
        stockname,
        annualDividend,
        dividendYield,
        marketCap,
        exDividend,
        payDate,
        peRatio,
        dayRange,
        fiftyTwoWeekLow,
        fiftyTwoWeekHigh,
        currentPrice,
        openPrice,
        eps
    }
