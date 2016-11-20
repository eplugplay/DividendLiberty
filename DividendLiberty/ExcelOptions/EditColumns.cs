using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DividendLiberty
{
    public partial class EditColumns : Form
    {
        public EditColumns()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateColumnNames();
        }

        private void EditColumnNames_Load(object sender, EventArgs e)
        {
            try
            {
                toolTip1.AutoPopDelay = 10000;
                LoadColumnNames();
                LoadVisible();
            }
            catch
            {

            }
        }

        public void UpdateColumnNames()
        {
            string[] section = INIFileOptions.GetINISection();
            string[] keys = INIFileOptions.GetINIKeys();
            string[] values = CombineValues(GetVisibles(), GetColumnNames());
            INIFileOptions.SaveExcelSettings(section, keys, values);
            MessageBox.Show("Updated!");
        }

        public string[] CombineValues(string[] colVisible, string[] colNames)
        {
            string[] combined = new string[11];
            for (int i = 0; i < colNames.Length; i++)
            {
                combined[i] = colVisible[i] + ";" + colNames[i];
            }
            return combined;
        }

        public string[] GetColumnNames()
        {
            string[] cols = new string[11];
            int i = 10;
            foreach (Control ctrl in gbColumn.Controls)
            {
                if (ctrl is TextBox)
                {
                    cols[i--] = ctrl.Text;
                }
            }
            return cols;
        }

        public void LoadColumnNames()
        {
            string[] colNames = INIFileOptions.ReadINIKeyValues(KeyPartition.columnName);
            int i = 10;
            foreach (Control ctrl in gbColumn.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = colNames[i--];
                }
            }
        }

        public void LoadVisible()
        {
            string[] colVisible = INIFileOptions.ReadINIKeyValues(KeyPartition.visible);
            int i = 10;
            foreach (CheckBox ctrl in gbColumn.Controls)
            {
                if (ctrl is CheckBox)
                {
                    ctrl.Checked = colVisible[i--] == "True" ? ctrl.Checked = true : ctrl.Checked = false;
                }
            }
        }

        public string[] GetVisibles()
        {
            string[] cols = new string[11];
            int i = 10;
            foreach (Control ctrl in gbColumn.Controls)
            {
                if (ctrl is CheckBox)
                {
                    CheckBox chk = (CheckBox)ctrl;
                    cols[i--] = chk.Checked.ToString();
                }
            }
            return cols;
        }
    }
}
