using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto
{
    public class wfFormAppDto
    {

        public wfFormAppDto()
        {

        }

        /// <summary>
        /// 表單代碼
        /// </summary>
        public  string sFormCode { get; set; }

        /// <summary>
        /// 表單名稱
        /// </summary>
        public string sFormName { get; set; }

        /// <summary>
        /// 工號
        /// </summary>
        public string sNobr { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string sName { get; set; }

        /// <summary>
        /// 部門代碼
        /// </summary>
        public string sDept { get; set; }

        /// <summary>
        /// 部門名稱
        /// </summary>
        public string sDeptName { get; set; }


        /// <summary>
        /// 職稱代碼
        /// </summary>
        public string sJob { get; set; }

        /// <summary>
        /// 職稱
        /// </summary>
        public string sJobName { get; set; }


        public string sMailSubject { get; set; }

        public string sMailBdoy { get; set; }

        public string sMailSign { get; set; }

        public string sJsonInfo { get; set; }

        public string sEmpCode { get; set; }
    }
}
