﻿using System;
using System.Collections.Generic;
using System.Text;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.Util;

namespace DividendLiberty.Excel
{
    class ExcelNPOIWriter:ExcelWriter
    {
        CellStyle _dateStyle;
        Dictionary<string, CellStyle> CellStyles = new Dictionary<string, CellStyle>();
        protected HSSFWorkbook hssfworkbook { get; private set; }
        public ExcelNPOIWriter()
        {
            hssfworkbook = new HSSFWorkbook();
            _dateStyle = GetDateStyle();
        }

        private CellStyle GetDateStyle()
        {
            DataFormat fmt = hssfworkbook.CreateDataFormat();
            CellStyle newStyle = hssfworkbook.CreateCellStyle();
            newStyle.DataFormat = fmt.GetFormat(this.DateFormat);
            return newStyle;
        }

        public override void WriteCell(int Column, int Row, string WorksheetName, object Value, string style)
        {
            Type valueType = Value.GetType();
            HSSFCell cell = CreateCell(Column, Row, WorksheetName);
            bool hasStyle = false;
            if (style != string.Empty)
            {
                cell.CellStyle = GetStyle(hssfworkbook, style);
                hasStyle = true;
            }
            //Backward compatibility

            {
                if (valueType == typeof(DateTime))
                {
                    WriteCellTypeValue(Convert.ToDateTime(Value), cell, hasStyle);
                }
                else if (valueType == typeof(Double))
                {
                    if (Double.IsNaN(Convert.ToDouble(Value)))
                        WriteCellTypeValue("NaN", cell, hasStyle);
                    else
                        WriteCellTypeValue(Convert.ToDouble(Value), cell, hasStyle);
                }

                else
                {
                    WriteCellTypeValue(Value.ToString(), cell, hasStyle);
                }
            }
            
            MaxRow = Math.Max(MaxRow, Row);
        }

        public override void WrapText(int row, int column, bool WrapText, string WorkSheet)
        {
            HSSFCellStyle style = (HSSFCellStyle)hssfworkbook.CreateCellStyle();
            style.WrapText = WrapText;
            HSSFCell cell = getCell(row, column, WorkSheet);
            cell.CellStyle = style;
        }

        public override void SetRowSize(int Row, float height, string WorksheetName)
        {
            HSSFSheet worksheet = VerifyWorksheet(WorksheetName);
            worksheet.GetRow(Row).HeightInPoints = height;
        }

        public override void SetColumnWidth(int Column, int width, string WorksheetName)
        {
            HSSFSheet worksheet = VerifyWorksheet(WorksheetName);
            worksheet.SetColumnWidth(Column, width);
        }


        private HSSFCell CreateCell(int Column, int Row, string WorksheetName)
        {
            HSSFSheet worksheet = VerifyWorksheet(WorksheetName);
            HSSFRow wsRow = (HSSFRow)worksheet.GetRow(Row) ?? (HSSFRow)worksheet.CreateRow(Row);
            HSSFCell cell = (HSSFCell)wsRow.CreateCell(Column);
            
            return cell;
        }

        protected void WriteCellTypeValue(double Value, HSSFCell cell, bool hasStyle)
        {
            cell.SetCellType(CellType.NUMERIC);
            cell.SetCellValue(Value);
        }

        protected void WriteCellTypeValue(DateTime Value, HSSFCell cell, bool hasStyle)
        {
            cell.SetCellType(CellType.NUMERIC);
            if(!hasStyle)
                cell.CellStyle = _dateStyle;
            cell.SetCellValue(Value);
        }

        protected void WriteCellTypeValue(string Value, HSSFCell cell, bool hasStyle)
        {
            cell.SetCellValue(Value);
        }

        public override void Save(string FileName)
        {
            FileStream file = new FileStream(FileName, FileMode.Create);
            Save(file);
            file.Close();
        }

        public override void CreateWorksheet(string worksheetname)
        {
            hssfworkbook.CreateSheet(worksheetname);
        }

        protected HSSFSheet VerifyWorksheet(string worksheetname)
        {
            HSSFSheet tempWS = GetWorksheet(worksheetname);
            if (tempWS == null)
            {
                CreateWorksheet(worksheetname);
                tempWS = GetWorksheet(worksheetname);
            }
            return tempWS;
        }

        public override void AutoSizeColumn(int column, string worksheetName)
        {
            HSSFSheet tempWS = GetWorksheet(worksheetName);
            tempWS.AutoSizeColumn(column);
        }

        protected override void Dispose(bool Disposing)
        {
            hssfworkbook.Dispose();
        }

        public HSSFSheet GetWorksheet(string worksheetName)
        {

            return (HSSFSheet)hssfworkbook.GetSheet(worksheetName);
        }

        public HSSFCell getCell(int rowIndex, int columnIndex, string workSheet)
        {
            HSSFSheet worksheet = VerifyWorksheet(workSheet);
            HSSFRow wsRow = (HSSFRow)worksheet.GetRow(rowIndex);
            return (HSSFCell)wsRow.GetCell(columnIndex);
        }

        public override void Save(Stream outputStream)
        {
            hssfworkbook.Write(outputStream);
        }

        protected CellStyle GetStyle(HSSFWorkbook workbook, string name)
        {
            if (!ExcelStyles.ContainsKey(name)) throw new ArgumentException("Style not found", name);
            if (CellStyles.ContainsKey(name)) return CellStyles[name];

            ConvertStyle(workbook, name);
            return CellStyles[name];
        }

        private void ConvertStyle(HSSFWorkbook workbook, string name)
        {
            ExcelStyle cf = ExcelStyles[name];
            
            Font font = workbook.CreateFont();
            CellStyle style = workbook.CreateCellStyle();
            style.FillForegroundColor = GetColor(cf.ForegroundColor);
            style.FillPattern = GetPatternType(cf.ForegroundPattern);
            font.Boldweight = (short)GetBoldWeight(cf.Bold);

            if (!string.IsNullOrEmpty(cf.FontName))
                font.FontName = cf.FontName;
            font.FontHeightInPoints = cf.FontHeight;
            style.SetFont(font);

            if (cf.DataFormat != string.Empty)
            {
                DataFormat format = workbook.CreateDataFormat();
                short formatIndex = format.GetFormat(cf.DataFormat);
                style.DataFormat = formatIndex;
            }

            this.CellStyles.Add(name, style);
        }

        private FillPatternType GetPatternType(ForegroundPatternType type)
        {
            switch (type)
            {
                case ForegroundPatternType.NoFill:
                    return FillPatternType.NO_FILL;
                case ForegroundPatternType.SolidForeground:
                    return FillPatternType.SOLID_FOREGROUND;
                default:
                    throw new NotSupportedException();
            }
        }

        private HorizontalAlignment GetAlignment(AlignmentType type)
        {
            switch (type)
            {
                case AlignmentType.Left:
                    return HorizontalAlignment.LEFT;
                case AlignmentType.Center:
                    return HorizontalAlignment.CENTER;
                case AlignmentType.Right:
                    return HorizontalAlignment.RIGHT;
                default:
                    throw new NotSupportedException();
            }
        }

        private short GetColor(ColorType type)
        {
            switch (type)
            {
                case ColorType.Aqua:
                    return HSSFColor.AQUA.index;
                case ColorType.Black:
                    return HSSFColor.BLACK.index;
                case ColorType.Red:
                    return HSSFColor.RED.index;
                case ColorType.White:
                    return HSSFColor.WHITE.index;
                case ColorType.Yellow:
                    return HSSFColor.YELLOW.index;
                case ColorType.Silver:
                    return HSSFColor.GREY_40_PERCENT.index;
                default:
                    throw new NotSupportedException();
            }
        }

        private FontBoldWeight GetBoldWeight(BoldType type)
        {
            switch (type)
            {
                case BoldType.Bold:
                    return FontBoldWeight.BOLD;
                case BoldType.Normal:
                    return FontBoldWeight.NORMAL;
                default:
                    throw new NotImplementedException();
            }
        }

        //*********** custom styles ***********//
        public void createStyle(string name)
        {
            AddStyle(name, (HSSFCellStyle)hssfworkbook.CreateCellStyle());
        }

        public HSSFCellStyle getStyle(string name)
        {
            if (!HSSFExcelStyles.ContainsKey(name))
                return null;

            return HSSFExcelStyles[name];
        }

        public void setDataFormat(string name, string format, bool builtin)
        {
            if (builtin)
                HSSFExcelStyles[name].DataFormat = HSSFDataFormat.GetBuiltinFormat(format);
            else
                HSSFExcelStyles[name].DataFormat = new HSSFDataFormat(hssfworkbook.Workbook).GetFormat(format);
        }

        public void setBorders(string name, CellBorderType type)
        {
            HSSFExcelStyles[name].BorderBottom = type;
            HSSFExcelStyles[name].BorderLeft = type;
            HSSFExcelStyles[name].BorderRight = type;
            HSSFExcelStyles[name].BorderTop = type;
        }

        public void setBorders(string name, bool top, bool bottom, bool left, bool right, CellBorderType type)
        {
            if (bottom)
                HSSFExcelStyles[name].BorderBottom = type;
            if (left)
                HSSFExcelStyles[name].BorderLeft = type;
            if (right)
                HSSFExcelStyles[name].BorderRight = type;
            if (top)
                HSSFExcelStyles[name].BorderTop = type;
        }

        public void setFont(string name, bool bold)
        {
            HSSFFont font = (HSSFFont)hssfworkbook.CreateFont();
            if (bold)
                font.Boldweight = (short)FontBoldWeight.BOLD;

            HSSFExcelStyles[name].SetFont(font);
        }

        public void setFont(string name, bool bold, short color)
        {
            HSSFFont font = (HSSFFont)hssfworkbook.CreateFont();
            if (bold)
                font.Boldweight = (short)FontBoldWeight.BOLD;
            font.Color = color;

            HSSFExcelStyles[name].SetFont(font);
        }

        public void setAlignment(string name, HorizontalAlignment align)
        {
            HSSFExcelStyles[name].Alignment = align;
        }

        public void setShrinkToFit(string name, bool stf)
        {
            HSSFExcelStyles[name].ShrinkToFit = stf;
        }

        public void setFillForeground(string name, short color, FillPatternType type)
        {
            HSSFExcelStyles[name].FillForegroundColor = color;
            HSSFExcelStyles[name].FillPattern = type;
        }

        public void setFillBackground(string name, short color, FillPatternType type)
        {
            HSSFExcelStyles[name].FillBackgroundColor = color;
            HSSFExcelStyles[name].FillPattern = type;
        }
    }
}
