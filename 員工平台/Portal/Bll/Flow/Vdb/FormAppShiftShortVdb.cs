﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Flow.Vdb
{
    class FormAppShiftShortVdb
    {
    }
    public class FormAppShiftShortConditions : DataConditions
    {
        public string ProcessFlowID { get; set; }
        public bool Sign { get; set; }
        public string SignState { get; set; }
        public string Status { get; set; }
    }
    public class FormAppShiftShortApiRow : StandardDataBaseApiRow
    {
        public class result
        {
            public int AutoKey { get; set; }
            public string Code { get; set; }
            public string ProcessId { get; set; }
            public int idProcess { get; set; }
            public string EmpId { get; set; }
            public string EmpName { get; set; }
            public string DeptCode { get; set; }
            public string DeptName { get; set; }
            public string JobCode { get; set; }
            public string JobName { get; set; }
            public string RoleId { get; set; }
            public string RoleCodeB { get; set; }
            public string RoteNameB { get; set; }
            public DateTime DateB { get; set; }
            public string RoleCodeE { get; set; }
            public string RoteNameE { get; set; }
            public DateTime DateE { get; set; }
            public bool Sign { get; set; }
            public string SignState { get; set; }
            public string Note { get; set; }
            public string Status { get; set; }
            public string InsertMan { get; set; }
            public DateTime InsertDate { get; set; }
            public string UpdateMan { get; set; }
            public DateTime UpdateDate { get; set; }
        }
        public List<result> Result { get; set; }
    }
    public class FormAppShiftShortRow
    {
        public int AutoKey { get; set; }
        public string Code { get; set; }
        public string ProcessId { get; set; }
        public int idProcess { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string JobCode { get; set; }
        public string JobName { get; set; }
        public string RoleId { get; set; }
        public string RoleCodeB { get; set; }
        public string RoteNameB { get; set; }
        public DateTime DateB { get; set; }
        public string RoleCodeE { get; set; }
        public string RoteNameE { get; set; }
        public DateTime DateE { get; set; }
        public bool Sign { get; set; }
        public string SignState { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string InsertMan { get; set; }
        public DateTime InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime UpdateDate { get; set; }

    }

}
