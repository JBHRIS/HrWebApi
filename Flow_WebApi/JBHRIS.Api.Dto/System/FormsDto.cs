using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.System
{
    public class FormsDto
    {
        public int AutoKey { get; set; }
        /// <summary>
        /// 表單代碼
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 表單名稱
        /// </summary>
        public string Name { get; set; }
        public string FlowTreeId { get; set; }
        public string NoteStd { get; set; }
        public string NoteCheck { get; set; }
        public string NoteView { get; set; }
        public string NoteEtc { get; set; }
        public int AppLimitCount { get; set; }
        public bool CheckNote { get; set; }
        public bool CheckSignNote { get; set; }
        public bool DisplaySignProcess { get; set; }
        public bool DisplayUploadFile { get; set; }
        public bool CheckUploadFile { get; set; }
        public string TableName { get; set; }
        public string SaveUrl { get; set; }
        public string SaveMethod { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
