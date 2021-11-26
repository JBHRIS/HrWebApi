using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data
{
     public class CustomizeNPOI
    {
        public static void SaveDataSetToExcel(System.Data.DataSet dsSource,System.Data.DataTable HeaderDT, string filePath, bool PrintGridLine,bool PrintHeader,bool PrintFooter)//, CallBackEvent.UpdateProgressCallBack 
        {
            JBTools.IO.CustomizExcelWriter writer = new JBTools.IO.CustomizExcelWriter(dsSource, HeaderDT);
            writer.PrintGridLine = PrintGridLine;
            writer.PrintHeader = PrintHeader;
            writer.PrintFooter = PrintFooter;            
            writer.CustomizSave(filePath);
        }
    }
}
