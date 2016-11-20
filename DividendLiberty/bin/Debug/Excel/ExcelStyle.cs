using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DividendLiberty.Excel
{
    public class ExcelStyle
    {
        public string DataFormat { get; set; }
        public ColorType ForegroundColor { get; set; }
        public ForegroundPatternType ForegroundPattern { get; set; }
        public AlignmentType HorizontalAlignment { get; set; }
        public BoldType Bold { get; set; }
        public string FontName { get; set; }
        public short FontHeight { get; set; }
    }


    public enum ForegroundPatternType
    {
        SolidForeground,
        NoFill
    }

    public enum AlignmentType
    {
        Left,
        Center,
        Right
    }

    public enum ColorType
    {
        White,
        Black,
        Yellow,
        Aqua,
        Red,
        Silver
    }

    public enum BoldType
    {
        Bold,
        Normal
    }
}