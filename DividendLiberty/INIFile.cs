using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace DividendLiberty
{
    public class INIFile
    {
        private string filePath;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
        string key,
        string val,
        string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
        string key,
        string def,
        StringBuilder retVal,
        int size,
        string filePath);

        public INIFile(string filePath)
        {
            this.filePath = filePath;
        }

        public void Write(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, this.filePath);
        }

        public string Read(string section, string key)
        {
            StringBuilder SB = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", SB, 255, this.filePath);
            return SB.ToString();
        }

        public string FilePath
        {
            get { return this.filePath; }
            set { this.filePath = value; }
        }
    }

    public static class INIFileOptions
    {
        public static string[] ReadINIKeyValues(KeyPartition keyPartition)
        {
            string[] toReturn = new string[11];
            string[] keyValues = INIFileOptions.GetINISectionKeyValues();
            for (int i = 0; i < keyValues.Length; i++)
            {
                toReturn[i] = INIFileOptions.GetKeyValueSplit(keyValues[i], keyPartition).Trim();
            }
            return toReturn;
        }


        public static string[] GetINISectionKeyValues()
        {
            string[] keyValues = new string[11];
            INIFile ini = new INIFile(uti.GetFilePath(FileTypes.ini));
            string[] sections = GetINISection();
            string[] keys = GetINIKeys();
            int a = 0;
            for (int i = 0; i < sections.Length; i++)
            {
                keyValues[i] = ini.Read(sections[i], keys[i]);
            }
            return keyValues;
        }

        public static string GetKeyValueSplit(string key, KeyPartition keyPartition)
        {
            string[] keyTemp = key.Split(';');
            return key = keyTemp[GetKeyPartition(keyPartition)];
        }

        public static int GetKeyPartition(KeyPartition KeyPartition)
        {
            int partition = 0;
            switch (KeyPartition)
            {
                case KeyPartition.visible: partition = 0; break;
                case KeyPartition.columnName: partition = 1; break;
                default: break;
            }
            return partition;
        }

        public static string[] GetINISection()
        {
            string[] section = new string[11];
            section[0] = "Column1";
            section[1] = "Column2";
            section[2] = "Column3";
            section[3] = "Column4";
            section[4] = "Column5";
            section[5] = "Column6";
            section[6] = "Column7";
            section[7] = "Column8";
            section[8] = "Column9";
            section[9] = "Column10";
            section[10] = "Column11";
            return section;
        }

        public static string[] GetINIKeys()
        {
            string[] Keys = new string[11];
            Keys[0] = "Symbols";
            Keys[1] = "Company";
            Keys[2] = "Industry";
            Keys[3] = "Shares";
            Keys[4] = "Price";
            Keys[5] = "Annual Dividend";
            Keys[6] = "Yield";
            Keys[7] = "Monthly Dividends";
            Keys[8] = "Quarterly Dividends";
            Keys[9] = "Yearly Dividends";
            Keys[10] = "Cost Basis";
            return Keys;
        }

        public static void SaveExcelSettings(string[] sections, string[] keys, string[] values)
        {
            for (int i = 0; i < sections.Length; i++)
            {
                uti.SaveIniFile(sections[i], keys[i], values[i]);
            }
        }
    }

    public enum KeyPartition
    {
        visible,
        columnName
    }
}
