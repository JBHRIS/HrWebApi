using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Class1 的摘要描述
/// </summary>
namespace Repo
{
    public class ClassQuestionnaireView
    {
        public DateTime CourseDateB { get; set; }
        public String CourseCate { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string DeptCode { get; set; }
        public String DeptName { get; set; }
        public string Name { get; set; }
        public string Nobr { get; set; }
        public int ClassId { get; set; }
        public string TeacherCode { get; set; }
        public int AutoKey { get; set; }

        public ClassQuestionnaireView()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
    }
}