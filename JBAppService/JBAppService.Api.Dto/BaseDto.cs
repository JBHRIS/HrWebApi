using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dto
{
    public class BaseDto
    {
        public string Nobr { get; set; }
        public string Name { get; set; }

    }


    public class BaseInfoDto
    {
        public string Nobr { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 是否可以線上打卡
        /// </summary>
        public bool OnLineApp { get; set; }
        /// <summary>
        /// 不限制
        /// </summary>
        public bool NoOnLineAtt { get; set; }
    }



    /// <summary>
    /// 
    /// </summary>
    public class PolygonDto
    {
        /// <summary>
        /// 
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// 
        /// </summary>
        // public string Code  { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }
    }




}
