using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DividendLiberty
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static MainMenu MainMenu;
        public static PleaseWait PleaseWait;
        [STAThread]
        static void Main()
        {
            bool ok;
            var m = new System.Threading.Mutex(true, "DividendDreams", out ok);

            if (!ok)
            {
                MessageBox.Show("Another instance is already running.");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PleaseWait = new DividendLiberty.PleaseWait();
            PleaseWait.lblMsg.Text = "Connecting to yahoo for stock data..";
            PleaseWait.lblMsg.Visible = true;
            PleaseWait.Show();
            Application.DoEvents();
            Application.Run(MainMenu = new MainMenu());
        }
    }
}
