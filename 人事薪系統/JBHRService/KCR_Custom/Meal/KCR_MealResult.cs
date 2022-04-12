using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JBHR2Service.KCR_Custom.Meal
{
    public class KCR_MealResult
    {
        public string ErrorMsg { get; set; }
        public string StackTrace { get; set; }
        public bool IsFinish { get; set; }
    }
}