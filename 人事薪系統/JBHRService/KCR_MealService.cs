using JBHR2Service.KCR_Custom.Meal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JBHR2Service
{
    // 注意: 您可以使用 [重構] 功能表上的 [重新命名] 命令同時變更程式碼和組態檔中的介面名稱 "IKCR_MealService"。
    [ServiceContract]
    public interface IKCR_MealService
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        List<KCR_MealApplySettingEntry> KCR_GetMealApplySettingByEmpID(string EmployeeID, DateTime ADate);

        [OperationContract]
        KCR_MealResult KCR_UpdateMealApplySettingByEmpID(List<KCR_MealApplySettingEntry> MealApplySetting);
    }
}
