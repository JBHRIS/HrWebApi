using JBHR2Service.KCR_Custom.Meal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JBHR2Service
{
    // 注意: 您可以使用 [重構] 功能表上的 [重新命名] 命令同時變更程式碼、svc 和組態檔中的類別名稱 "KCR_MealService"。
    // 注意: 若要啟動 WCF 測試用戶端以便測試此服務，請在 [方案總管] 中選取 KCR_MealService.svc 或 KCR_MealService.svc.cs，然後開始偵錯。
    public class KCR_MealService : IKCR_MealService
    {
        public void DoWork()
        {
        }

        public List<KCR_MealApplySettingEntry> KCR_GetMealApplySettingByEmpID(string EmployeeID, DateTime ADate)
        {
            var mealGenerator = new KCR_MealGenerator();
            return mealGenerator.KCR_GetMealApplySettingByEmpID(EmployeeID, ADate);
        }

        public KCR_MealResult KCR_UpdateMealApplySettingByEmpID(List<KCR_MealApplySettingEntry> MealApplySettingList)
        {
            var mealGenerator = new KCR_MealGenerator();
            return mealGenerator.KCR_UpdateMealApplySettingByEmpID(MealApplySettingList);
        }
    }
}
