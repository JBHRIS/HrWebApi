using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Salary.View
{
    public class BlockDetailDto
    {
        public string Title { get; set; }//明細標題
        public string Number { get; set; }  //明細的值
        public string Init { get; set; }//明細的單位
        public string Memo { get; set; }//明細預備欄位
    }
}
