using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.FlowMainInte.Vdb
{


    /// <summary>
    /// 
    /// </summary>
   public  class PayslipVdb
    {

        public string Title { get; set; }

        public string DateIntervalTitle { get; set; }
        public string TransferTitle { get; set; }

        public string useTemplate { get; set; }//樣版主檔代碼-主檔需維護-套用每個人
        public string NoteBloc { get; set; } //提醒文件
                                             //        public <BlockClass> PayslipDetail  { get; set; }

        public List<BlockClass> BlockClass { get; set; }

    }


    public class BlockClass
    {
        public BlockClass()
        {

        }


        public string title { get; set; }

        public List<blockDetailClass> blockDetail { get; set; }

        public List<blockDetailClass> OtherblockDetail { get; set; }

        public string initDollar { get; set; } //單位

        public int order { get; set; }//順序



    }




    public class blockDetailClass
    {

        public blockDetailClass()
        {

        }

        public string title { get; set; }//明細標題
        public string number { get; set; }  //明細的值
        public string init { get; set; }//明細的單位

    }

}
