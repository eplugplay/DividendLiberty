using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace DividendLiberty.Excel
{
    enum ExcelEngine
    {
        Interop,
        NPOI
    }
    public abstract class ExcelWriter : IDisposable, ExcelBase
    {
        protected Dictionary<string, HSSFCellStyle> HSSFExcelStyles = new Dictionary<string, HSSFCellStyle>();
        protected Dictionary<string, ExcelStyle> ExcelStyles = new Dictionary<string, ExcelStyle>();
        protected bool IsDisposed = false;

        public abstract void WriteCell(int Column, int Row, string WorksheetName, object Value, string style);
        public abstract void Save(string FileName);
        public abstract void Save(Stream outputStream);
        public abstract void CreateWorksheet(string worksheetname);
        public abstract void AutoSizeColumn(int column, string worksheetName);
        protected abstract void Dispose(bool Disposing);

        public virtual void WrapText(int row, int column, bool WrapText, string WorkSheet)
        {
            throw new NotImplementedException();
        }

        public virtual void SetRowSize(int Row, float height, string WorksheetName)
        {
            throw new NotImplementedException();
        }

        public virtual void SetColumnWidth(int Column, int width, string WorksheetName)
        {
            throw new NotImplementedException();
        }

        public string DateFormat { get; set; }

        public int MaxRow { get; protected set; }

        protected ExcelWriter()
        {
            DateFormat = System.Configuration.ConfigurationManager.AppSettings["DefaultExcelDateFormat"];
        }

        ~ExcelWriter()
        {
            Dispose(false);
        }

        public void WriteCell(int Column, int Row, string WorksheetName, object Value)
        {
            WriteCell(Column, Row, WorksheetName, Value, string.Empty);
        }

        public void WriteData(DbDataReader dr, string WorksheetName, bool addColumnHeaders)
        {
            WriteData(dr, WorksheetName, addColumnHeaders, 0, 0);
        }

        public void WriteData(DataTable dt, string WorksheetName, bool addColumnHeaders)
        {
            WriteData(dt, WorksheetName, addColumnHeaders, 0, 0);
        }

        public void WriteData(DbDataReader dr, string WorksheetName, bool addColumnHeaders, int startColumn, int startRow)
        {
            DataTable temp = new DataTable();
            temp.Load(dr);
            WriteData(temp, WorksheetName, addColumnHeaders, startColumn, startRow);
        }

        /*public void WriteData(List<List<string>> dt, List<string> columnHeaders, string WorksheetName, int startColumn, int startRow)
        {
            int offset = startRow + 1;

            WriteRow(columnHeaders.ToArray(), startRow, WorksheetName, startColumn);

            for (int i = 0; i < dt.Count; i++)
            {
                WriteRow(dt[i].ToArray(), i + offset, WorksheetName, startColumn);
            }
        }*/

        public void WriteData(DataTable dt, string WorksheetName, bool addColumnHeaders, int offset)
        {

            if (addColumnHeaders)
            {
                var columnHeadings = new List<string>();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (!dt.Columns[i].ColumnName.StartsWith("BLANK"))
                    {
                        columnHeadings.Add(dt.Columns[i].ColumnName.Replace("_", " "));
                    }
                    else
                    {
                        columnHeadings.Add("");
                    }
                }
                WriteRow(columnHeadings.ToArray(), offset, WorksheetName);
                offset++;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WriteRow(dt.Rows[i], i + offset, WorksheetName);
            }
        }

        private void WriteRow(object[] toWrite, int RowIndex, string WorksheetName)
        {
            for (int i = 0; i < toWrite.Length; i++)
            {
                WriteCell(i, RowIndex, WorksheetName, toWrite[i]);
            }
        }

        private void WriteRow(DataRow dr, int RowIndex, string WorksheetName)
        {
            for (int i = 0; i < dr.ItemArray.Length; i++)
            {
                WriteCell(i, RowIndex, WorksheetName, dr[i]);
            }
        }

        private void WriteRow(object[] toWrite, int RowIndex, int ColIndex, string WorksheetName)
        {
            for (int i = 0; i < toWrite.Length; i++)
            {
                WriteCell(i + ColIndex, RowIndex, WorksheetName, toWrite[i]);
            }
        }

        // row and col
        private void WriteRow(DataRow dr, int RowIndex, int ColIndex, string WorksheetName)
        {
            for (int i = 0; i < dr.ItemArray.Length; i++)
            {
                WriteCell(i + ColIndex, RowIndex, WorksheetName, dr[i]);
            }
        }

        // row offset and column
        public void WriteData(DataTable dt, string WorksheetName, bool addColumnHeaders, int rowOffset, int colOffset)
        {

            if (addColumnHeaders)
            {
                var columnHeadings = new List<string>();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (!dt.Columns[i].ColumnName.StartsWith("BLANK"))
                    {
                        columnHeadings.Add(dt.Columns[i].ColumnName.Replace("_", " "));
                    }
                    else
                    {
                        columnHeadings.Add("");
                    }
                }
                WriteRow(columnHeadings.ToArray(), rowOffset, colOffset, WorksheetName);
                rowOffset++;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WriteRow(dt.Rows[i], i + rowOffset, colOffset, WorksheetName);
            }
        }


        /*public void WriteRow(object[] toWrite, int RowIndex, string WorksheetName, int StartColumn)
        {
            WriteRow(toWrite, RowIndex, WorksheetName, StartColumn, string.Empty);
        }

        public void WriteRow(object[] toWrite, int RowIndex, string WorksheetName, int startColumn, string rowStyle)
        {
            for (int i = startColumn, j = 0; i < toWrite.Length + startColumn; i++, j++)
            {
                WriteCell(i, RowIndex, WorksheetName, toWrite[j], rowStyle);
            }
        }

        public void WriteRow(DataRow dr, int RowIndex, string WorksheetName, int startColumn)
        {
            WriteRow(dr, RowIndex, WorksheetName, startColumn, string.Empty);
        }

        public void WriteRow(DataRow dr, int RowIndex, string WorksheetName, int startColumn, string rowStyle)
        {
            for (int i = startColumn, j = 0; i < dr.ItemArray.Length + startColumn; i++, j++)
            {
                WriteCell(i, RowIndex, WorksheetName,dr[j], rowStyle);
            }
        }*/

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void AddStyle(string name, ExcelStyle style)
        {
            if (ExcelStyles.ContainsKey(name)) return;

            ExcelStyles.Add(name, style);
        }

        /*Custom Styles*/
        protected void AddStyle(string name, HSSFCellStyle style)
        {
            if (HSSFExcelStyles.ContainsKey(name))
                return;

            HSSFExcelStyles.Add(name, style);
        }
    }
}
