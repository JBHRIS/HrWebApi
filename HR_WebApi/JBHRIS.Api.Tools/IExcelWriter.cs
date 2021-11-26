using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Tools
{
    public interface IExcelWriter
    {
        //void SetCurrentSheet(string SheetName);
        void Save(string FileName);
        bool PrintGridLine { get; set; }
    }
}
