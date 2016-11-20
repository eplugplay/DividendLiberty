using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace DividendLiberty.Excel
{
    public interface ExcelBase
    {
        void Save(string FileName);
        void Save(Stream outputStream);
    }
}