using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Dto
{
    public class TBaseDto
    {
        public bool INCOMP { set; get; }        //內部員工
        public string NOBR { set; get; }        //所得人編號
        public string NAME_C { set; get; }      //所得人姓名
        public string ADDR { set; get; }        //地址
        public string TEL { set; get; }         //電話
        public string EMAIL { set; get; }       //電子郵件
        public string GSM { set; get; }         //行動電話
        public string IDNO { set; get; }        //統一編號
        public string KEY_MAN { set; get; }     //登錄者
        public DateTime KEY_DATE { set; get; } //登錄日期
        public string IDCODE { set; get; }      //證號別
        public string POSTCODE1 { set; get; }   //通訊郵遞區號
        public string POSTCODE2 { set; get; }   //戶籍郵遞區號
        public string SALADR { set; get; }      //資料群組
        public string TAXNO { set; get; }       //稅籍編號
    }
}
