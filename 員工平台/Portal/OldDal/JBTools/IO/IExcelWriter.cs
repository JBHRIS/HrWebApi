using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JBTools.IO
{
    public interface IExcelWriter
    {
        //void SetCurrentSheet(string SheetName);
        void Save(string FileName);
        bool PrintGridLine { get; set; }
    }
}
