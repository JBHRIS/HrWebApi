using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Class1 的摘要描述
/// </summary>
namespace Repo
{
    public class CoursePlanDetailView
    {
        public int Id { get; set; }
        public int ClassAutoKey { get; set; }
        public int PlanDetailOrder { get; set; }
        public string PlanDetailName { get; set; }
        public string PlanDetailOutline { get; set; }
        public int PlanDetailTimeMin { get; set; }
        public string PlanDetailNote { get; set; }
        public string TeachingMethod { get; set; }
        public string TeachingResource { get; set; }

        public CoursePlanDetailView()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
    }
}