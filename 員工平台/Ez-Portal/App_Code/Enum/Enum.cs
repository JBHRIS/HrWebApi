using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BL
{    
    public enum EnumCourseTypes
    {
        DEMAND ,
        DUTY ,
        OTHERS ,
        POLICY
    };
    public enum EnumUploadCategories
    {
        Class ,
        TeacherLicense ,
        TeachingMaterial ,
        PlanningPolicy        
    };
    public enum QQTypeEnum
    {
        MCQ,
        TFQ,
        SAQ
    };

    public enum EnumUC_QS_SelectedType
    {
        Dept,
        Emp
    };

    public enum EnumUC_QS_InitType
    {
        HR,
        Manager,
        Coordinator
    };
}