/* ======================================================================================================
 * 功能名稱：加班費用報表
 * 功能代號：ZZ43
 * 功能路徑：報表列印 > 薪資 > 加班費用報表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ43Class.cs
 * 功能用途：
 *  用於產出加班費用報表
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/04/08    Daniel Chih    Ver 1.0.01     1. 修改【個人明細表(編制部門)】（含補休）的Excel顯示加班日期、加班起迄時、補休時數的欄位
 * 2021/09/08    Daniel Chih    Ver 1.0.02     1. 修改成本部門欄位都顯示加班部門
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/09/08
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JBHR.Reports.SalForm
{
    class ZZ43Class
    {
        public static void Export1(DataTable DT_zz431,string FileName,bool pr_rest)
        {
            DataTable ExporDt = new DataTable();
            
            DataRow [] OrderRow;
            if (pr_rest)
            {
                ExporDt.Columns.Add("編制部門", typeof(string));
                ExporDt.Columns.Add("部門名稱", typeof(string));
                ExporDt.Columns.Add("英文部門名稱", typeof(string));
                ExporDt.Columns.Add("員工編號", typeof(string));
                ExporDt.Columns.Add("員工姓名", typeof(string));
                ExporDt.Columns.Add("英文姓名", typeof(string));
                ExporDt.Columns.Add("計薪年月", typeof(string));
                ExporDt.Columns.Add("計算月薪", typeof(int));
                ExporDt.Columns.Add("加班日期", typeof(DateTime));
                ExporDt.Columns.Add("加起時間", typeof(string));
                ExporDt.Columns.Add("加迄時間", typeof(string));
                ExporDt.Columns.Add("加班時數", typeof(decimal));
                ExporDt.Columns.Add("補休時數", typeof(decimal));
                ExporDt.Columns.Add("平日一段", typeof(decimal));
                ExporDt.Columns.Add("平日二段", typeof(decimal));
                ExporDt.Columns.Add("平日三段", typeof(decimal));
                ExporDt.Columns.Add("假日一段", typeof(decimal));
                ExporDt.Columns.Add("假日二段", typeof(decimal));
                ExporDt.Columns.Add("假日三段", typeof(decimal));
                ExporDt.Columns.Add("加班費", typeof(int));
                ExporDt.Columns.Add("誤餐次數", typeof(int));
                ExporDt.Columns.Add("免一段時數", typeof(decimal));
                ExporDt.Columns.Add("免一段比率", typeof(decimal));
                ExporDt.Columns.Add("免二段時數", typeof(decimal));
                ExporDt.Columns.Add("免二段比率", typeof(decimal));
                ExporDt.Columns.Add("免三段時數", typeof(decimal));
                ExporDt.Columns.Add("免三段比率", typeof(decimal));
                ExporDt.Columns.Add("免假一時數", typeof(decimal));
                ExporDt.Columns.Add("免假一比率", typeof(decimal));
                ExporDt.Columns.Add("免假二時數", typeof(decimal));
                ExporDt.Columns.Add("免假二比率", typeof(decimal));
                ExporDt.Columns.Add("免假三時數", typeof(decimal));
                ExporDt.Columns.Add("免假三比率", typeof(decimal));
                ExporDt.Columns.Add("應一段時數", typeof(decimal));
                ExporDt.Columns.Add("應一段比率", typeof(decimal));
                ExporDt.Columns.Add("應二段時數", typeof(decimal));
                ExporDt.Columns.Add("應二段比率", typeof(decimal));
                ExporDt.Columns.Add("應三段時數", typeof(decimal));
                ExporDt.Columns.Add("應三段比率", typeof(decimal));
                OrderRow = DT_zz431.Select("", "comp,dept asc");
                foreach (DataRow Row in OrderRow)
                {
                    DataRow aRow = ExporDt.NewRow();
                    aRow["編制部門"] = Row["dept"].ToString();
                    aRow["部門名稱"] = Row["d_name"].ToString();
                    aRow["英文部門名稱"] = Row["d_ename"].ToString();
                    aRow["員工編號"] = Row["nobr"].ToString();
                    aRow["員工姓名"] = Row["name_c"].ToString();
                    aRow["英文姓名"] = Row["name_e"].ToString();
                    aRow["計薪年月"] = Row["yymm"].ToString();
                    aRow["計算月薪"] = int.Parse(Row["salary"].ToString());
                    aRow["加班日期"] = DateTime.Parse(Row["bdate"].ToString());
                    aRow["加起時間"] = Row["btime"].ToString();
                    aRow["加迄時間"] = Row["etime"].ToString();
                    aRow["加班時數"] = decimal.Parse(Row["ot_hrs"].ToString());
                    aRow["補休時數"] = decimal.Parse(Row["rest_hrs"].ToString());
                    aRow["平日一段"] = decimal.Parse(Row["wot_133"].ToString());
                    aRow["平日二段"] = decimal.Parse(Row["wot_166"].ToString());
                    aRow["平日三段"] = decimal.Parse(Row["wot_200"].ToString());
                    aRow["假日一段"] = decimal.Parse(Row["hot_133"].ToString());
                    aRow["假日二段"] = decimal.Parse(Row["hot_166"].ToString());
                    aRow["假日三段"] = decimal.Parse(Row["hot_200"].ToString());
                    aRow["加班費"] = int.Parse(Row["not_exp"].ToString()) + int.Parse(Row["tot_exp"].ToString());
                    aRow["誤餐次數"] = decimal.Round(decimal.Parse(Row["ot_car"].ToString()), 0);
                    aRow["免一段時數"] = decimal.Parse(Row["not_w_133"].ToString());
                    aRow["免一段比率"] = decimal.Parse(Row["nop_w_133"].ToString());
                    aRow["免二段時數"] = decimal.Parse(Row["not_w_167"].ToString());
                    aRow["免二段比率"] = decimal.Parse(Row["nop_w_167"].ToString());
                    aRow["免三段時數"] = decimal.Parse(Row["not_w_200"].ToString());
                    aRow["免三段比率"] = decimal.Parse(Row["nop_w_200"].ToString());
                    aRow["免假一時數"] = decimal.Parse(Row["not_h_133"].ToString());
                    aRow["免假一比率"] = decimal.Parse(Row["nop_h_133"].ToString());
                    aRow["免假二時數"] = decimal.Parse(Row["not_h_167"].ToString());
                    aRow["免假二比率"] = decimal.Parse(Row["nop_h_167"].ToString());
                    aRow["免假三時數"] = decimal.Parse(Row["not_h_200"].ToString());
                    aRow["免假三比率"] = decimal.Parse(Row["nop_h_200"].ToString());
                    aRow["應一段時數"] = decimal.Parse(Row["tot_w_133"].ToString());
                    aRow["應一段比率"] = decimal.Parse(Row["top_w_133"].ToString());
                    aRow["應二段時數"] = decimal.Parse(Row["tot_w_167"].ToString());
                    aRow["應二段比率"] = decimal.Parse(Row["top_w_167"].ToString());
                    aRow["應三段時數"] = decimal.Parse(Row["tot_w_200"].ToString());
                    aRow["應三段比率"] = decimal.Parse(Row["top_w_200"].ToString());
                    aRow["計薪年月"] = Row["yymm"].ToString();
                    ExporDt.Rows.Add(aRow);
                }
            }

            else
            {
                ExporDt.Columns.Add("編制部門", typeof(string));
                ExporDt.Columns.Add("部門名稱", typeof(string));
                ExporDt.Columns.Add("英文部門名稱", typeof(string));
                ExporDt.Columns.Add("員工編號", typeof(string));
                ExporDt.Columns.Add("員工姓名", typeof(string));
                ExporDt.Columns.Add("英文姓名", typeof(string));
                ExporDt.Columns.Add("加班日期", typeof(DateTime));
                ExporDt.Columns.Add("計算月薪", typeof(int));
                ExporDt.Columns.Add("星期", typeof(string));
                ExporDt.Columns.Add("班別", typeof(string));
                ExporDt.Columns.Add("加起時間", typeof(string));
                ExporDt.Columns.Add("加迄時間", typeof(string));
                ExporDt.Columns.Add("加班時數", typeof(decimal));
                ExporDt.Columns.Add("免稅加班費", typeof(int));
                ExporDt.Columns.Add("應稅加班費", typeof(int));
                ExporDt.Columns.Add("合計加班費", typeof(int));
                ExporDt.Columns.Add("免0段時數", typeof(decimal));
                ExporDt.Columns.Add("免0段比率", typeof(decimal));
                ExporDt.Columns.Add("免一段時數", typeof(decimal));
                ExporDt.Columns.Add("免一段比率", typeof(decimal));
                ExporDt.Columns.Add("免二段時數", typeof(decimal));
                ExporDt.Columns.Add("免二段比率", typeof(decimal));
                ExporDt.Columns.Add("免三段時數", typeof(decimal));
                ExporDt.Columns.Add("免三段比率", typeof(decimal));
                ExporDt.Columns.Add("免假一時數", typeof(decimal));
                ExporDt.Columns.Add("免假一比率", typeof(decimal));
                ExporDt.Columns.Add("免假二時數", typeof(decimal));
                ExporDt.Columns.Add("免假二比率", typeof(decimal));
                ExporDt.Columns.Add("免假三時數", typeof(decimal));
                ExporDt.Columns.Add("免假三比率", typeof(decimal));
                ExporDt.Columns.Add("應一段時數", typeof(decimal));
                ExporDt.Columns.Add("應一段比率", typeof(decimal));
                ExporDt.Columns.Add("應二段時數", typeof(decimal));
                ExporDt.Columns.Add("應二段比率", typeof(decimal));
                ExporDt.Columns.Add("應三段時數", typeof(decimal));
                ExporDt.Columns.Add("應三段比率", typeof(decimal));
                ExporDt.Columns.Add("計薪年月", typeof(string));
                OrderRow = DT_zz431.Select("", "comp,dept,nobr asc");
                foreach (DataRow Row in OrderRow)
                {
                    DataRow aRow = ExporDt.NewRow();
                    aRow["編制部門"] = Row["dept"].ToString();
                    aRow["部門名稱"] = Row["d_name"].ToString();
                    aRow["英文部門名稱"] = Row["d_ename"].ToString();
                    aRow["員工編號"] = Row["nobr"].ToString();
                    aRow["員工姓名"] = Row["name_c"].ToString();
                    aRow["英文姓名"] = Row["name_e"].ToString();
                    aRow["加班日期"] = DateTime.Parse(Row["bdate"].ToString());
                    aRow["計算月薪"] = int.Parse(Row["salary"].ToString());
                    aRow["星期"] = Row["dw"].ToString();
                    aRow["班別"] = Row["rote"].ToString();
                    aRow["加起時間"] = Row["btime"].ToString();
                    aRow["加迄時間"] = Row["etime"].ToString();
                    aRow["加班時數"] = decimal.Parse(Row["ot_hrs"].ToString());
                    aRow["免稅加班費"] = int.Parse(Row["not_exp"].ToString());
                    aRow["應稅加班費"] = int.Parse(Row["tot_exp"].ToString());
                    aRow["合計加班費"] = int.Parse(Row["not_exp"].ToString()) + int.Parse(Row["tot_exp"].ToString());
                    aRow["免0段時數"] = decimal.Parse(Row["not_w_100"].ToString());
                    aRow["免0段比率"] = decimal.Parse(Row["nop_w_100"].ToString());
                    aRow["免一段時數"] = decimal.Parse(Row["not_w_133"].ToString());
                    aRow["免一段比率"] = decimal.Parse(Row["nop_w_133"].ToString());
                    aRow["免二段時數"] = decimal.Parse(Row["not_w_167"].ToString());
                    aRow["免二段比率"] = decimal.Parse(Row["nop_w_167"].ToString());
                    aRow["免三段時數"] = decimal.Parse(Row["not_w_200"].ToString());
                    aRow["免三段比率"] = decimal.Parse(Row["nop_w_200"].ToString());
                    aRow["免假一時數"] = decimal.Parse(Row["not_h_133"].ToString());
                    aRow["免假一比率"] = decimal.Parse(Row["nop_h_133"].ToString());
                    aRow["免假二時數"] = decimal.Parse(Row["not_h_167"].ToString());
                    aRow["免假二比率"] = decimal.Parse(Row["nop_h_167"].ToString());
                    aRow["免假三時數"] = decimal.Parse(Row["not_h_200"].ToString());
                    aRow["免假三比率"] = decimal.Parse(Row["nop_h_200"].ToString());
                    aRow["應一段時數"] = decimal.Parse(Row["tot_w_133"].ToString());
                    aRow["應一段比率"] = decimal.Parse(Row["top_w_133"].ToString());
                    aRow["應二段時數"] = decimal.Parse(Row["tot_w_167"].ToString());
                    aRow["應二段比率"] = decimal.Parse(Row["top_w_167"].ToString());
                    aRow["應三段時數"] = decimal.Parse(Row["tot_w_200"].ToString());
                    aRow["應三段比率"] = decimal.Parse(Row["top_w_200"].ToString());
                    aRow["計薪年月"] = Row["yymm"].ToString();
                    ExporDt.Rows.Add(aRow);
                }
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }


        public static void Export2(DataTable DT_zz432, string FileName)
        {
            DataTable ExporDt = new DataTable();           
            ExporDt.Columns.Add("編制部門", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("加班時數", typeof(decimal));
            ExporDt.Columns.Add("免稅加班費", typeof(int));
            ExporDt.Columns.Add("應稅加班費", typeof(int));           
            ExporDt.Columns.Add("補休時數", typeof(decimal));
            ExporDt.Columns.Add("非假日時數", typeof(decimal));
            ExporDt.Columns.Add("假日時數", typeof(decimal));
            foreach (DataRow Row in DT_zz432.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["編制部門"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["英文部門名稱"] = Row["d_ename"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                aRow["加班時數"] = decimal.Parse(Row["ot_hrs"].ToString());
                aRow["免稅加班費"] = int.Parse(Row["not_exp"].ToString());
                aRow["應稅加班費"] = int.Parse(Row["tot_exp"].ToString());               
                aRow["補休時數"] = decimal.Parse(Row["rest_hrs"].ToString());
                aRow["非假日時數"] = decimal.Parse(Row["not_w_133"].ToString());
                aRow["假日時數"] = decimal.Parse(Row["not_h_133"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void Export3(DataTable DT_zz431, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("成本部門", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));            
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("加班日期", typeof(DateTime));
            ExporDt.Columns.Add("計算月薪", typeof(int));
            ExporDt.Columns.Add("星期", typeof(string));
            ExporDt.Columns.Add("加起時間", typeof(string));
            ExporDt.Columns.Add("加迄時間", typeof(string));
            ExporDt.Columns.Add("加班時數", typeof(decimal));
            ExporDt.Columns.Add("加班費", typeof(int));
            ExporDt.Columns.Add("班別津貼1", typeof(int));
            ExporDt.Columns.Add("班別津貼2", typeof(decimal));
            ExporDt.Columns.Add("補休時數", typeof(decimal));
            ExporDt.Columns.Add("非假日時數", typeof(decimal));
            ExporDt.Columns.Add("假日時數", typeof(decimal));
            ExporDt.Columns.Add("計薪年月", typeof(string));
            ExporDt.Columns.Add("免稅加班費", typeof(int));
            ExporDt.Columns.Add("應稅加班費", typeof(int));
            DataRow[] OrderRow = DT_zz431.Select("", "comp,ot_dept,nobr asc");
            foreach (DataRow Row in OrderRow)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["成本部門"] = Row["ot_dept"].ToString();
                aRow["部門名稱"] = Row["ot_dname"].ToString();                
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                aRow["加班日期"] = DateTime.Parse(Row["bdate"].ToString());
                aRow["計算月薪"] = int.Parse(Row["salary"].ToString());
                aRow["星期"] = Row["dw"].ToString();
                aRow["加起時間"] = Row["btime"].ToString();
                aRow["加迄時間"] = Row["etime"].ToString();
                aRow["加班時數"] = decimal.Parse(Row["ot_hrs"].ToString());
                aRow["加班費"] = int.Parse(Row["not_exp"].ToString()) + int.Parse(Row["tot_exp"].ToString());
                aRow["班別津貼1"] = int.Parse(Row["ot_food"].ToString());
                aRow["班別津貼2"] = decimal.Parse(Row["ot_food1"].ToString());
                aRow["補休時數"] = decimal.Parse(Row["rest_hrs"].ToString());
                aRow["非假日時數"] = decimal.Parse(Row["not_w_133"].ToString()) + decimal.Parse(Row["not_w_167"].ToString()) + decimal.Parse(Row["not_w_200"].ToString()) + decimal.Parse(Row["tot_w_133"].ToString()) + decimal.Parse(Row["tot_w_167"].ToString()) + decimal.Parse(Row["tot_w_200"].ToString());
                aRow["假日時數"] = decimal.Parse(Row["not_h_133"].ToString()) + decimal.Parse(Row["not_h_167"].ToString()) + decimal.Parse(Row["not_h_200"].ToString()) + decimal.Parse(Row["tot_h_200"].ToString());
                aRow["免稅加班費"] = int.Parse(Row["not_exp"].ToString());
                aRow["應稅加班費"] = int.Parse(Row["tot_exp"].ToString());
                aRow["計薪年月"] = Row["yymm"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void Export4(DataTable DT_zz433, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("成本部門", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));           
            ExporDt.Columns.Add("加班時數", typeof(decimal));
            ExporDt.Columns.Add("免稅加班費", typeof(int));
            ExporDt.Columns.Add("應稅加班費", typeof(int)); 
            ExporDt.Columns.Add("補休時數", typeof(decimal));
            ExporDt.Columns.Add("非假日時數", typeof(decimal));
            ExporDt.Columns.Add("假日時數", typeof(decimal));

            foreach (DataRow Row in DT_zz433.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["成本部門"] = Row["ot_dept"].ToString();
                aRow["部門名稱"] = Row["ot_dname"].ToString();                
                aRow["加班時數"] = decimal.Parse(Row["ot_hrs"].ToString());
                aRow["免稅加班費"] = int.Parse(Row["not_exp"].ToString());
                aRow["應稅加班費"] = int.Parse(Row["tot_exp"].ToString());
                aRow["補休時數"] = decimal.Parse(Row["rest_hrs"].ToString());
                aRow["非假日時數"] = decimal.Parse(Row["notw"].ToString());
                aRow["假日時數"] = decimal.Parse(Row["noth"].ToString());               
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void Export5(DataTable DT_zz434, string FileName,string reporttype)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("編制部門", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("加班時數", typeof(decimal));            
            ExporDt.Columns.Add("免一段時數", typeof(decimal));            
            ExporDt.Columns.Add("免二段時數", typeof(decimal));            
            ExporDt.Columns.Add("免三段時數", typeof(decimal));            
            ExporDt.Columns.Add("免假一時數", typeof(decimal));           
            ExporDt.Columns.Add("免假二時數", typeof(decimal));            
            ExporDt.Columns.Add("免假三時數", typeof(decimal));            
            ExporDt.Columns.Add("應一段時數", typeof(decimal));            
            ExporDt.Columns.Add("應二段時數", typeof(decimal));            
            ExporDt.Columns.Add("應三段時數", typeof(decimal));
            if (reporttype == "5")
            {
                ExporDt.Columns.Add("計薪年月", typeof(string));
                ExporDt.Columns.Add("加班部門", typeof(string));
            }
            foreach (DataRow Row in DT_zz434.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["編制部門"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["英文部門名稱"] = Row["d_ename"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                aRow["加班時數"] = decimal.Parse(Row["ot_hrs"].ToString());                
                aRow["免一段時數"] = decimal.Parse(Row["not_w_133"].ToString());                
                aRow["免二段時數"] = decimal.Parse(Row["not_w_167"].ToString());                
                aRow["免三段時數"] = decimal.Parse(Row["not_w_200"].ToString());                
                aRow["免假一時數"] = decimal.Parse(Row["not_h_133"].ToString());                
                aRow["免假二時數"] = decimal.Parse(Row["not_h_167"].ToString());                
                aRow["免假三時數"] = decimal.Parse(Row["not_h_200"].ToString());                
                aRow["應一段時數"] = decimal.Parse(Row["tot_w_133"].ToString());               
                aRow["應二段時數"] = decimal.Parse(Row["tot_w_167"].ToString());               
                aRow["應三段時數"] = decimal.Parse(Row["tot_w_200"].ToString());
                if (reporttype == "5")
                {
                    aRow["計薪年月"] = Row["yymm"].ToString();
                    aRow["加班部門"] = Row["ot_dept"].ToString();
                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void Export6(DataTable DT_zz436, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("編制部門", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("加班時數", typeof(decimal));
            ExporDt.Columns.Add("免一段時數", typeof(decimal));
            ExporDt.Columns.Add("免二段時數", typeof(decimal));
            ExporDt.Columns.Add("免三段時數", typeof(decimal));
            ExporDt.Columns.Add("免假一時數", typeof(decimal));
            ExporDt.Columns.Add("免假二時數", typeof(decimal));
            ExporDt.Columns.Add("免假三時數", typeof(decimal));
            ExporDt.Columns.Add("應一段時數", typeof(decimal));
            ExporDt.Columns.Add("應二段時數", typeof(decimal));
            ExporDt.Columns.Add("應三段時數", typeof(decimal));
            ExporDt.Columns.Add("加班費", typeof(int));
            ExporDt.Columns.Add("計薪年月", typeof(string));
           
            foreach (DataRow Row in DT_zz436.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["編制部門"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["英文部門名稱"] = Row["d_ename"].ToString();
                aRow["加班時數"] = decimal.Parse(Row["ot_hrs"].ToString());
                aRow["免一段時數"] = decimal.Parse(Row["not_w_133"].ToString());
                aRow["免二段時數"] = decimal.Parse(Row["not_w_167"].ToString());
                aRow["免三段時數"] = decimal.Parse(Row["not_w_200"].ToString());
                aRow["免假一時數"] = decimal.Parse(Row["not_h_133"].ToString());
                aRow["免假二時數"] = decimal.Parse(Row["not_h_167"].ToString());
                aRow["免假三時數"] = decimal.Parse(Row["not_h_200"].ToString());
                aRow["應一段時數"] = decimal.Parse(Row["tot_w_133"].ToString());
                aRow["應二段時數"] = decimal.Parse(Row["tot_w_167"].ToString());
                aRow["應三段時數"] = decimal.Parse(Row["tot_w_200"].ToString());
                aRow["加班費"] = int.Parse(Row["exp"].ToString());
                aRow["計薪年月"] = Row["yymm"].ToString();                
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void Export7(DataTable DT_zz437, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("編制部門", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("本日加班時數", typeof(decimal));
            ExporDt.Columns.Add("本日加班金額", typeof(int));
            ExporDt.Columns.Add("本月累計加班時數", typeof(decimal));
            ExporDt.Columns.Add("本月累計加班金額", typeof(int));
            foreach (DataRow Row in DT_zz437.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["編制部門"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["英文部門名稱"] = Row["d_ename"].ToString();
                aRow["本日加班時數"] = decimal.Parse(Row["dot_hrs"].ToString());
                aRow["本日加班金額"] = int.Parse(Row["dexp"].ToString());
                aRow["本月累計加班時數"] = decimal.Parse(Row["ot_hrs"].ToString());
                aRow["本月累計加班金額"] = int.Parse(Row["exp"].ToString());              
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }


        //public static void Export8(DataTable DT_zz438, string FileName,string reporttype)
        //{
        //    DataTable ExporDt = new DataTable();
        //    ExporDt.Columns.Add("成本部門", typeof(string));
        //    ExporDt.Columns.Add("部門名稱", typeof(string));
        //    if (reporttype == "11")
        //    {
        //        ExporDt.Columns.Add("職稱", typeof(string));
        //        ExporDt.Columns.Add("外籍", typeof(string));
        //    }
        //    if (reporttype=="12")
        //    {
        //        ExporDt.Columns.Add("員工編號", typeof(string));
        //        ExporDt.Columns.Add("員工姓名", typeof(string));
        //        ExporDt.Columns.Add("英文姓名", typeof(string));
        //    }
        //    ExporDt.Columns.Add("總1.33倍", typeof(decimal));
        //    ExporDt.Columns.Add("總1.67倍", typeof(decimal));
        //    ExporDt.Columns.Add("總2倍", typeof(decimal));
        //    ExporDt.Columns.Add("總3倍", typeof(decimal));
        //    ExporDt.Columns.Add("總1倍", typeof(decimal));
        //    if (reporttype == "11" || reporttype == "12")
        //        ExporDt.Columns.Add("總時數", typeof(decimal));
        //    ExporDt.Columns.Add("總加班金額", typeof(int));
        //    ExporDt.Columns.Add("1.33倍", typeof(decimal));
        //    ExporDt.Columns.Add("1.67倍", typeof(decimal));
        //    ExporDt.Columns.Add("2倍", typeof(decimal));
        //    ExporDt.Columns.Add("3倍", typeof(decimal));
        //    ExporDt.Columns.Add("1倍", typeof(decimal));
        //    if (reporttype == "11" || reporttype == "12")
        //        ExporDt.Columns.Add("時數", typeof(decimal));
        //    ExporDt.Columns.Add("加班金額", typeof(int));
        //    foreach (DataRow Row in DT_zz438.Rows)
        //    {
        //        DataRow aRow = ExporDt.NewRow();
        //        aRow["成本部門"] = Row["dept"].ToString();
        //        aRow["部門名稱"] = Row["d_name"].ToString();
        //        if (reporttype == "11")
        //        {
        //            aRow["職稱"] = Row["job_name"].ToString();
        //            aRow["外籍"] = Row["count_ma"].ToString();
        //        }
        //        if (reporttype == "12")
        //        {
        //            aRow["員工編號"] = Row["nobr"].ToString();
        //            aRow["員工姓名"] = Row["name_c"].ToString();
        //            aRow["英文姓名"] = Row["name_e"].ToString();
        //        }
        //        aRow["總1.33倍"] = decimal.Parse(Row["ot_133"].ToString());
        //        aRow["總1.67倍"] = decimal.Parse(Row["ot_167"].ToString());
        //        aRow["總2倍"] = decimal.Parse(Row["ot_200"].ToString());
        //        aRow["總3倍"] = 0;
        //        aRow["總1倍"] = decimal.Parse(Row["ot_100"].ToString());
        //        aRow["總加班金額"] = int.Parse(Row["ot_amt"].ToString());
        //        aRow["1.33倍"] = decimal.Parse(Row["ex_133"].ToString());
        //        aRow["1.67倍"] = decimal.Parse(Row["ex_167"].ToString());
        //        aRow["2倍"] = decimal.Parse(Row["ex_100"].ToString());
        //        aRow["3倍"] = 0;
        //        aRow["1倍"] = decimal.Parse(Row["ex_200"].ToString());
        //        aRow["加班金額"] = int.Parse(Row["ex_amt"].ToString());
        //        if (reporttype == "11" || reporttype == "12")
        //        {
        //            aRow["總時數"] = decimal.Parse(Row["otsum"].ToString());
        //            aRow["時數"] = decimal.Parse(Row["exsum"].ToString());
        //        }
        //        ExporDt.Rows.Add(aRow);
        //    }
        //    JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        //}

        public static void Export8(DataTable DT_zz438, DataTable DT_zz438t, string FileName, string reporttype)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("成本部門", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            if (reporttype == "11")
            {
                ExporDt.Columns.Add("職稱", typeof(string));
                ExporDt.Columns.Add("外籍", typeof(string));
            }
            if (reporttype == "12")
            {
                ExporDt.Columns.Add("員工編號", typeof(string));
                ExporDt.Columns.Add("員工姓名", typeof(string));
                ExporDt.Columns.Add("英文姓名", typeof(string));
            }
            //ExporDt.Columns.Add("總1.33倍", typeof(decimal));
            //ExporDt.Columns.Add("總1.67倍", typeof(decimal));
            //ExporDt.Columns.Add("總2倍", typeof(decimal));
            //ExporDt.Columns.Add("總3倍", typeof(decimal));
            //ExporDt.Columns.Add("總1倍", typeof(decimal));
            for (int i = 1; i < 7; i++)
            {
                if (DT_zz438t.Rows[0]["Fld" + i].ToString() != "")
                    ExporDt.Columns.Add("總" + DT_zz438t.Rows[0]["Fld" + i].ToString() + "倍", typeof(decimal));
                else
                    break;
            }
            if (reporttype == "11" || reporttype == "12")
                ExporDt.Columns.Add("總時數", typeof(decimal));
            ExporDt.Columns.Add("總加班金額", typeof(int));
            //ExporDt.Columns.Add("1.33倍", typeof(decimal));
            //ExporDt.Columns.Add("1.67倍", typeof(decimal));
            //ExporDt.Columns.Add("2倍", typeof(decimal));
            //ExporDt.Columns.Add("3倍", typeof(decimal));
            //ExporDt.Columns.Add("1倍", typeof(decimal));
            for (int i = 1; i < 7; i++)
            {
                if (DT_zz438t.Rows[0]["Fld" + i].ToString() != "")
                    ExporDt.Columns.Add(DT_zz438t.Rows[0]["Fld" + i].ToString() + "倍", typeof(decimal));
                else
                    break;
            }
            if (reporttype == "11" || reporttype == "12")
                ExporDt.Columns.Add("時數", typeof(decimal));
            ExporDt.Columns.Add("加班金額", typeof(int));
            foreach (DataRow Row in DT_zz438.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["成本部門"] = Row["ot_dept"].ToString();
                aRow["部門名稱"] = Row["ot_dname"].ToString();
                if (reporttype == "11")
                {
                    aRow["職稱"] = Row["job_name"].ToString();
                    aRow["外籍"] = Row["count_ma"].ToString();
                }
                if (reporttype == "12")
                {
                    aRow["員工編號"] = Row["nobr"].ToString();
                    aRow["員工姓名"] = Row["name_c"].ToString();
                    aRow["英文姓名"] = Row["name_e"].ToString();
                }
                //aRow["總1.33倍"] = decimal.Parse(Row["ot_133"].ToString());
                //aRow["總1.67倍"] = decimal.Parse(Row["ot_167"].ToString());
                //aRow["總2倍"] = decimal.Parse(Row["ot_200"].ToString());
                //aRow["總3倍"] = 0;
                //aRow["總1倍"] = decimal.Parse(Row["ot_100"].ToString());
                aRow["總加班金額"] = int.Parse(Row["ot_amt"].ToString());
                //aRow["1.33倍"] = decimal.Parse(Row["ex_133"].ToString());
                //aRow["1.67倍"] = decimal.Parse(Row["ex_167"].ToString());
                //aRow["2倍"] = decimal.Parse(Row["ex_100"].ToString());
                //aRow["3倍"] = 0;
                //aRow["1倍"] = decimal.Parse(Row["ex_200"].ToString());
                for (int i = 1; i < 7; i++)
                {
                    if (DT_zz438t.Rows[0]["Fld" + i].ToString() != "")
                        aRow["總" + DT_zz438t.Rows[0]["Fld" + i].ToString() + "倍"] = decimal.Parse(Row["Fld" + i].ToString());
                    if (DT_zz438t.Rows[0]["Fldb" + i].ToString() != "")
                        aRow[DT_zz438t.Rows[0]["Fldb" + i].ToString() + "倍"] = decimal.Parse(Row["Fldb" + i].ToString());
                }
                aRow["加班金額"] = int.Parse(Row["ex_amt"].ToString());
                if (reporttype == "11" || reporttype == "12")
                {
                    aRow["總時數"] = decimal.Parse(Row["otsum"].ToString());
                    aRow["時數"] = decimal.Parse(Row["exsum"].ToString());
                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void Export9(DataTable DT_zz439, DataTable DT_zz439t, string FileName, string reporttye)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("成本部門", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            if (reporttye == "9")
            {
                ExporDt.Columns.Add("出勤日期", typeof(DateTime));
                ExporDt.Columns.Add("星期", typeof(string));
                ExporDt.Columns.Add("加起時間", typeof(string));
                ExporDt.Columns.Add("加迄時間", typeof(string));
                ExporDt.Columns.Add("加班時數", typeof(decimal));
                ExporDt.Columns.Add("補休時數", typeof(decimal));
            }
            else
            {
                ExporDt.Columns.Add("加班時數", typeof(decimal));
                ExporDt.Columns.Add("補休時數", typeof(decimal));
            }
            for(int i=1;i < 7;i++)
            {
                if (DT_zz439t.Rows[0]["Fld" + i].ToString() != "")
                    ExporDt.Columns.Add("免稅" + DT_zz439t.Rows[0]["Fld" + i].ToString(), typeof(decimal));
                if (DT_zz439t.Rows[0]["Fldb" + i].ToString() != "")
                    ExporDt.Columns.Add("應稅" + DT_zz439t.Rows[0]["Fldb" + i].ToString(), typeof(decimal));
            }
           
            foreach (DataRow Row in DT_zz439.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["成本部門"] = Row["ot_dept"].ToString();
                aRow["部門名稱"] = Row["ot_dname"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                if (reporttye == "9")
                {
                    aRow["出勤日期"] = DateTime.Parse(Row["bdate"].ToString());
                    aRow["星期"] = Row["dw"].ToString();
                    aRow["加起時間"] = Row["btime"].ToString();
                    aRow["加迄時間"] = Row["etime"].ToString();
                    aRow["加班時數"] = decimal.Parse(Row["ot_hrs"].ToString());
                    aRow["補休時數"] = decimal.Parse(Row["rest_hrs"].ToString());
                }
                else
                {
                    aRow["加班時數"] = decimal.Parse(Row["ot_hrs"].ToString());
                    aRow["補休時數"] = decimal.Parse(Row["rest_hrs"].ToString());
                }
                for (int i = 1; i < 7; i++)
                {
                    if (DT_zz439t.Rows[0]["Fld" + i].ToString() != "")
                        aRow["免稅" + DT_zz439t.Rows[0]["Fld" + i].ToString()] = decimal.Parse(Row["Fld" + i].ToString());
                    if (DT_zz439t.Rows[0]["Fldb" + i].ToString() != "")
                        aRow["應稅" + DT_zz439t.Rows[0]["Fldb" + i].ToString()] = decimal.Parse(Row["Fldb" + i].ToString());
                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void Export13(DataTable DT_zz43e, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("成本代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("人數", typeof(int));
            ExporDt.Columns.Add("固定加班時數", typeof(decimal));
            ExporDt.Columns.Add("額外加班時數", typeof(decimal));
            ExporDt.Columns.Add("加班時數", typeof(decimal));
            ExporDt.Columns.Add("平均加班時數", typeof(decimal));
            ExporDt.Columns.Add("固定加班費", typeof(int));
            ExporDt.Columns.Add("額外加班費", typeof(int));
            ExporDt.Columns.Add("固定薪資", typeof(int));
            ExporDt.Columns.Add("變動薪資", typeof(int));
            ExporDt.Columns.Add("福利", typeof(int));
            ExporDt.Columns.Add("薪資總費用", typeof(int));
            DataRow[] Orow = DT_zz43e.Select("", "depts asc");
            foreach (DataRow Row in Orow)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["成本代碼"] = Row["ot_dept"].ToString();
                aRow["部門名稱"] = Row["ot_dname"].ToString();
                aRow["人數"] = int.Parse(Row["p_no"].ToString());
                aRow["固定加班時數"] =Row.IsNull("ot_hrs") ? 0 : decimal.Parse(Row["ot_hrs"].ToString());
                aRow["額外加班時數"] = Row.IsNull("ex_hrs") ? 0 : decimal.Parse(Row["ex_hrs"].ToString());
                aRow["加班時數"] = Row.IsNull("tol_hrs") ? 0 : decimal.Parse(Row["tol_hrs"].ToString());
                aRow["平均加班時數"] = Row.IsNull("avghrs") ? 0 : decimal.Parse(Row["avghrs"].ToString());
                aRow["固定加班費"] = Row.IsNull("otamt") ? 0 : int.Parse(Row["otamt"].ToString());
                aRow["額外加班費"] = Row.IsNull("examt") ? 0 : int.Parse(Row["examt"].ToString());
                aRow["固定薪資"] = Row.IsNull("fix_amt") ? 0 : int.Parse(Row["fix_amt"].ToString());
                aRow["變動薪資"] = Row.IsNull("var_amt") ? 0 : int.Parse(Row["var_amt"].ToString());
                aRow["福利"] = Row.IsNull("wel_amt") ? 0 : int.Parse(Row["wel_amt"].ToString());
                aRow["薪資總費用"] = Row.IsNull("tol_amt") ? 0 : int.Parse(Row["tol_amt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        //public static void GetDataZZ438(DataTable DT_zz438, DataTable DT_zz431, string reporttype)
        //{
        //    if (reporttype=="8")
        //        DT_zz438.PrimaryKey = new DataColumn[] { DT_zz438.Columns["dept"] };
        //    else if (reporttype == "11")
        //    {
        //        DataColumn[] _key = new DataColumn[3];
        //        _key[0] = DT_zz438.Columns["dept"];
        //        _key[1] = DT_zz438.Columns["job"];
        //        _key[2] = DT_zz438.Columns["count_ma"];
        //        DT_zz438.PrimaryKey = _key;
        //    }
        //    else if (reporttype == "12")
        //    {
        //        DataColumn[] _key = new DataColumn[2];
        //        _key[0] = DT_zz438.Columns["dept"];
        //        _key[1] = DT_zz438.Columns["nobr"];
        //        DT_zz438.PrimaryKey = _key;
        //    }
        //    DataRow[] Row438 = DT_zz431.Select("", "dept,nobr asc");            
        //    foreach (DataRow Row1 in Row438)
        //    {
        //        if (decimal.Parse(Row1["nop_w_100"].ToString()) == 2)
        //        {
        //            Row1["not_w_200"] = decimal.Parse(Row1["not_w_100"].ToString());
        //            Row1["not_w_100"] = 0;
        //        }
        //        decimal ot100 = decimal.Parse(Row1["not_w_100"].ToString()) + decimal.Parse(Row1["tot_w_100"].ToString());
        //        decimal ot133 = decimal.Parse(Row1["not_w_133"].ToString()) + decimal.Parse(Row1["not_h_133"].ToString()) + decimal.Parse(Row1["tot_w_133"].ToString());
        //        decimal ot167 = decimal.Parse(Row1["not_w_167"].ToString()) + decimal.Parse(Row1["not_h_167"].ToString()) + decimal.Parse(Row1["tot_w_167"].ToString());
        //        decimal ot200 = decimal.Parse(Row1["not_w_200"].ToString()) + decimal.Parse(Row1["not_h_200"].ToString()) + decimal.Parse(Row1["tot_w_200"].ToString());
        //        DataRow row = null;
        //        string str_ma = "";
        //        if (reporttype == "8")
        //            row = DT_zz438.Rows.Find(Row1["dept"].ToString());
        //        else if (reporttype == "11")
        //        {
        //            if (bool.Parse(Row1["count_ma"].ToString()))
        //                str_ma = "外籍";
        //            object [] _value = new object[3];
        //            _value[0] = Row1["dept"].ToString();
        //            _value[1] = Row1["job"].ToString();
        //            _value[2] = str_ma;
        //            row = DT_zz438.Rows.Find(_value);
        //        }
        //        else if (reporttype == "12")
        //        {                   
        //            object[] _value = new object[2];
        //            _value[0] = Row1["dept"].ToString();
        //            _value[1] = Row1["nobr"].ToString();
        //            row = DT_zz438.Rows.Find(_value);
        //        }
        //        if (row != null)
        //        {
        //            row["ot_100"] = decimal.Parse(row["ot_100"].ToString()) + ot100;
        //            row["ot_133"] = decimal.Parse(row["ot_133"].ToString()) + ot133;
        //            row["ot_167"] = decimal.Parse(row["ot_167"].ToString()) + ot167;
        //            row["ot_200"] = decimal.Parse(row["ot_200"].ToString()) + ot200;                    
        //            row["ot_amt"] = int.Parse(row["ot_amt"].ToString()) + int.Parse(Row1["not_exp"].ToString()) + int.Parse(Row1["tot_exp"].ToString());
        //            if (!bool.Parse(Row1["syscreat"].ToString()) && !bool.Parse(Row1["syscreat1"].ToString()))
        //            {
        //                row["ex_100"] = decimal.Parse(row["ex_100"].ToString()) + ot100;
        //                row["ex_133"] = decimal.Parse(row["ex_133"].ToString()) + ot133;
        //                row["ex_167"] = decimal.Parse(row["ex_167"].ToString()) + ot167;
        //                row["ex_200"] = decimal.Parse(row["ex_200"].ToString()) + ot200;
        //                row["ex_amt"] = int.Parse(row["ex_amt"].ToString()) + int.Parse(Row1["not_exp"].ToString()) + int.Parse(Row1["tot_exp"].ToString());
        //                if (reporttype == "11" || reporttype == "12")
        //                    row["exsum"] = decimal.Parse(row["ex_100"].ToString()) + decimal.Parse(row["ex_133"].ToString()) + decimal.Parse(row["ex_167"].ToString()) + decimal.Parse(row["ex_200"].ToString());
        //            }
        //            if (reporttype == "11" || reporttype == "12")
        //                row["otsum"] = decimal.Parse(row["ot_100"].ToString()) + decimal.Parse(row["ot_133"].ToString()) + decimal.Parse(row["ot_167"].ToString()) + decimal.Parse(row["ot_200"].ToString());
        //        }
        //        else
        //        {
        //            DataRow aRow = DT_zz438.NewRow();
        //            aRow["dept"] = Row1["dept"].ToString();
        //            aRow["d_name"] = Row1["d_name"].ToString();
        //            aRow["ot_100"] = ot100;
        //            aRow["ot_133"] = ot133;
        //            aRow["ot_167"] = ot167;
        //            aRow["ot_200"] = ot200;
        //            aRow["ot_amt"] = int.Parse(Row1["not_exp"].ToString()) + int.Parse(Row1["tot_exp"].ToString());
        //            aRow["ex_100"] = Convert.ToDecimal("0.00");
        //            aRow["ex_133"] = Convert.ToDecimal("0.00");
        //            aRow["ex_167"] = Convert.ToDecimal("0.00");
        //            aRow["ex_200"] = Convert.ToDecimal("0.00");
        //            aRow["ex_amt"] = 0;
        //            aRow["exsum"] = Convert.ToDecimal("0.00");
        //            if (!bool.Parse(Row1["syscreat"].ToString()) && !bool.Parse(Row1["syscreat"].ToString()))
        //            {
        //                aRow["ex_100"] = ot100;
        //                aRow["ex_133"] = ot133;
        //                aRow["ex_167"] = ot167;
        //                aRow["ex_200"] = ot200;
        //                aRow["ex_amt"] = int.Parse(Row1["not_exp"].ToString()) + int.Parse(Row1["tot_exp"].ToString());
        //                if (reporttype == "11" || reporttype == "12")
        //                    aRow["exsum"] = ot100 + ot133 + ot167 + ot200;
        //            }
        //            if (reporttype == "11")
        //            {
        //                aRow["job"] = Row1["job"].ToString();
        //                aRow["job_name"] = Row1["job_name"].ToString();
        //                aRow["count_ma"] = str_ma;
        //                aRow["otsum"] = ot100 + ot133 + ot167 + ot200;                   
        //            }
        //            if (reporttype == "12")
        //            {
        //                aRow["nobr"] = Row1["nobr"].ToString();
        //                aRow["name_c"] = Row1["name_c"].ToString();
        //                aRow["name_e"] = Row1["name_e"].ToString();
        //                aRow["otsum"] = ot100 + ot133 + ot167 + ot200;
        //            }
        //            DT_zz438.Rows.Add(aRow);
        //        }
        //    }
        //}

        public static void GetDataZZ438(DataTable DT_zz438, DataTable DT_zz438t, DataTable DT_zz431, string reporttype)
        {
            DataTable ot_per = new DataTable();
            ot_per.Columns.Add("ot_per", typeof(decimal));
            ot_per.PrimaryKey = new DataColumn[] { ot_per.Columns["ot_per"] };
            foreach (DataRow Row1 in DT_zz431.Rows)
            {
                if (decimal.Parse(Row1["nop_w_100"].ToString()) != 0)
                {
                    DataRow row = ot_per.Rows.Find(decimal.Parse(Row1["nop_w_100"].ToString()));
                    if (row == null)
                    {
                        DataRow aRow = ot_per.NewRow();
                        aRow["ot_per"] = decimal.Parse(Row1["nop_w_100"].ToString());
                        ot_per.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row1["nop_w_133"].ToString()) != 0)
                {
                    DataRow row = ot_per.Rows.Find(decimal.Parse(Row1["nop_w_133"].ToString()));
                    if (row == null)
                    {
                        DataRow aRow = ot_per.NewRow();
                        aRow["ot_per"] = decimal.Parse(Row1["nop_w_133"].ToString());
                        ot_per.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row1["nop_w_167"].ToString()) != 0)
                {
                    DataRow row = ot_per.Rows.Find(decimal.Parse(Row1["nop_w_167"].ToString()));
                    if (row == null)
                    {
                        DataRow aRow = ot_per.NewRow();
                        aRow["ot_per"] = decimal.Parse(Row1["nop_w_167"].ToString());
                        ot_per.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row1["nop_w_200"].ToString()) != 0)
                {
                    DataRow row = ot_per.Rows.Find(decimal.Parse(Row1["nop_w_200"].ToString()));
                    if (row == null)
                    {
                        DataRow aRow = ot_per.NewRow();
                        aRow["ot_per"] = decimal.Parse(Row1["nop_w_200"].ToString());
                        ot_per.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row1["nop_h_133"].ToString()) != 0)
                {
                    DataRow row = ot_per.Rows.Find(decimal.Parse(Row1["nop_h_133"].ToString()));
                    if (row == null)
                    {
                        DataRow aRow = ot_per.NewRow();
                        aRow["ot_per"] = decimal.Parse(Row1["nop_h_133"].ToString());
                        ot_per.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row1["nop_h_167"].ToString()) != 0)
                {
                    DataRow row = ot_per.Rows.Find(decimal.Parse(Row1["nop_h_167"].ToString()));
                    if (row == null)
                    {
                        DataRow aRow = ot_per.NewRow();
                        aRow["ot_per"] = decimal.Parse(Row1["nop_h_167"].ToString());
                        ot_per.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row1["nop_h_200"].ToString()) != 0)
                {
                    DataRow row = ot_per.Rows.Find(decimal.Parse(Row1["nop_h_200"].ToString()));
                    if (row == null)
                    {
                        DataRow aRow = ot_per.NewRow();
                        aRow["ot_per"] = decimal.Parse(Row1["nop_h_200"].ToString());
                        ot_per.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row1["top_w_133"].ToString()) != 0)
                {
                    DataRow row = ot_per.Rows.Find(decimal.Parse(Row1["top_w_133"].ToString()));
                    if (row == null)
                    {
                        DataRow aRow = ot_per.NewRow();
                        aRow["ot_per"] = decimal.Parse(Row1["top_w_133"].ToString());
                        ot_per.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row1["top_w_167"].ToString()) != 0)
                {
                    DataRow row = ot_per.Rows.Find(decimal.Parse(Row1["top_w_167"].ToString()));
                    if (row == null)
                    {
                        DataRow aRow = ot_per.NewRow();
                        aRow["ot_per"] = decimal.Parse(Row1["top_w_167"].ToString());
                        ot_per.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row1["top_w_200"].ToString()) != 0)
                {
                    DataRow row = ot_per.Rows.Find(decimal.Parse(Row1["top_w_200"].ToString()));
                    if (row == null)
                    {
                        DataRow aRow = ot_per.NewRow();
                        aRow["ot_per"] = decimal.Parse(Row1["top_w_200"].ToString());
                        ot_per.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row1["top_h_200"].ToString()) != 0)
                {
                    DataRow row = ot_per.Rows.Find(decimal.Parse(Row1["top_h_200"].ToString()));
                    if (row == null)
                    {
                        DataRow aRow = ot_per.NewRow();
                        aRow["ot_per"] = decimal.Parse(Row1["top_h_200"].ToString());
                        ot_per.Rows.Add(aRow);
                    }
                }
            }
            int aat = ot_per.Rows.Count;
            DataRow[] Orow = ot_per.Select("", "ot_per asc");
            DataRow aRow1 = DT_zz438t.NewRow();
            for (int i = 0; i < Orow.Length; i++)
            {
                aRow1["Fld" + (i + 1)] = Orow[i]["ot_per"].ToString();
                aRow1["Fldb" + (i + 1)] = Orow[i]["ot_per"].ToString();
            }
            DT_zz438t.Rows.Add(aRow1);

            if (reporttype == "8")
                DT_zz438.PrimaryKey = new DataColumn[] { DT_zz438.Columns["dept"] };
            else if (reporttype == "11")
            {
                DataColumn[] _key = new DataColumn[3];
                _key[0] = DT_zz438.Columns["dept"];
                _key[1] = DT_zz438.Columns["job"];
                _key[2] = DT_zz438.Columns["count_ma"];
                DT_zz438.PrimaryKey = _key;
            }
            else if (reporttype == "12")
            {
                DataColumn[] _key = new DataColumn[2];
                _key[0] = DT_zz438.Columns["dept"];
                _key[1] = DT_zz438.Columns["nobr"];
                DT_zz438.PrimaryKey = _key;
            }
            DataRow[] Row438 = DT_zz431.Select("", "dept,nobr asc");
            foreach (DataRow Row1 in Row438)
            {
                //if (decimal.Parse(Row1["nop_w_100"].ToString()) == 2)
                //{
                //    Row1["not_w_200"] = decimal.Parse(Row1["not_w_100"].ToString());
                //    Row1["not_w_100"] = 0;
                //}
                decimal ot100 = decimal.Parse(Row1["not_w_100"].ToString()) + decimal.Parse(Row1["tot_w_100"].ToString());
                decimal ot133 = decimal.Parse(Row1["not_w_133"].ToString()) + decimal.Parse(Row1["not_h_133"].ToString()) + decimal.Parse(Row1["tot_w_133"].ToString());
                decimal ot167 = decimal.Parse(Row1["not_w_167"].ToString()) + decimal.Parse(Row1["not_h_167"].ToString()) + decimal.Parse(Row1["tot_w_167"].ToString());
                decimal ot200 = decimal.Parse(Row1["not_w_200"].ToString()) + decimal.Parse(Row1["not_h_200"].ToString()) + decimal.Parse(Row1["tot_w_200"].ToString());
                DataRow row = null;
                string str_ma = "";
                if (reporttype == "8")
                    row = DT_zz438.Rows.Find(Row1["dept"].ToString());
                else if (reporttype == "11")
                {
                    if (bool.Parse(Row1["count_ma"].ToString()))
                        str_ma = "外籍";
                    object[] _value = new object[3];
                    _value[0] = Row1["dept"].ToString();
                    _value[1] = Row1["job"].ToString();
                    _value[2] = str_ma;
                    row = DT_zz438.Rows.Find(_value);
                }
                else if (reporttype == "12")
                {
                    object[] _value = new object[2];
                    _value[0] = Row1["dept"].ToString();
                    _value[1] = Row1["nobr"].ToString();
                    row = DT_zz438.Rows.Find(_value);
                }
                decimal _othrs = 0;
                if (row != null)
                {
                    //row["ot_100"] = decimal.Parse(row["ot_100"].ToString()) + ot100;
                    //row["ot_133"] = decimal.Parse(row["ot_133"].ToString()) + ot133;
                    //row["ot_167"] = decimal.Parse(row["ot_167"].ToString()) + ot167;
                    //row["ot_200"] = decimal.Parse(row["ot_200"].ToString()) + ot200;
                    for (int i = 0; i < Orow.Length; i++)
                    {
                        if (decimal.Parse(Row1["nop_w_100"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            row["Fld" + (i + 1)] = decimal.Parse(row["Fld" + (i + 1)].ToString()) + decimal.Parse(Row1["not_w_100"].ToString());
                        if (decimal.Parse(Row1["nop_w_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            row["Fld" + (i + 1)] = decimal.Parse(row["Fld" + (i + 1)].ToString()) + decimal.Parse(Row1["not_w_133"].ToString());
                        if (decimal.Parse(Row1["nop_w_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            row["Fld" + (i + 1)] = decimal.Parse(row["Fld" + (i + 1)].ToString()) + decimal.Parse(Row1["not_w_167"].ToString());
                        if (decimal.Parse(Row1["nop_w_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            row["Fld" + (i + 1)] = decimal.Parse(row["Fld" + (i + 1)].ToString()) + decimal.Parse(Row1["not_w_200"].ToString());
                        if (decimal.Parse(Row1["nop_h_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            row["Fld" + (i + 1)] = decimal.Parse(row["Fld" + (i + 1)].ToString()) + decimal.Parse(Row1["not_h_133"].ToString());
                        if (decimal.Parse(Row1["nop_h_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            row["Fld" + (i + 1)] = decimal.Parse(row["Fld" + (i + 1)].ToString()) + decimal.Parse(Row1["not_h_167"].ToString());
                        if (decimal.Parse(Row1["nop_h_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            row["Fld" + (i + 1)] = decimal.Parse(row["Fld" + (i + 1)].ToString()) + decimal.Parse(Row1["not_h_200"].ToString());
                        if (decimal.Parse(Row1["nop_w_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            row["Fld" + (i + 1)] = decimal.Parse(row["Fld" + (i + 1)].ToString()) + decimal.Parse(Row1["tot_w_133"].ToString());
                        if (decimal.Parse(Row1["nop_w_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            row["Fld" + (i + 1)] = decimal.Parse(row["Fld" + (i + 1)].ToString()) + decimal.Parse(Row1["tot_w_167"].ToString());
                        if (decimal.Parse(Row1["nop_w_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            row["Fld" + (i + 1)] = decimal.Parse(row["Fld" + (i + 1)].ToString()) + decimal.Parse(Row1["tot_w_200"].ToString());
                        _othrs += decimal.Parse(row["Fld" + (i + 1)].ToString());

                    }
                    row["otsum"] = _othrs;

                    _othrs = 0;
                    row["ot_amt"] = int.Parse(row["ot_amt"].ToString()) + int.Parse(Row1["not_exp"].ToString()) + int.Parse(Row1["tot_exp"].ToString());
                    if (!bool.Parse(Row1["syscreat"].ToString()) && !bool.Parse(Row1["syscreat1"].ToString()))
                    {
                        for (int i = 0; i < Orow.Length; i++)
                        {
                            if (decimal.Parse(Row1["nop_w_100"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                row["Fldb" + (i + 1)] = decimal.Parse(row["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row1["not_w_100"].ToString());
                            if (decimal.Parse(Row1["nop_w_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                row["Fldb" + (i + 1)] = decimal.Parse(row["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row1["not_w_133"].ToString());
                            if (decimal.Parse(Row1["nop_w_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                row["Fldb" + (i + 1)] = decimal.Parse(row["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row1["not_w_167"].ToString());
                            if (decimal.Parse(Row1["nop_w_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                row["Fldb" + (i + 1)] = decimal.Parse(row["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row1["not_w_200"].ToString());
                            if (decimal.Parse(Row1["nop_h_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                row["Fldb" + (i + 1)] = decimal.Parse(row["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row1["not_h_133"].ToString());
                            if (decimal.Parse(Row1["nop_h_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                row["Fldb" + (i + 1)] = decimal.Parse(row["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row1["not_h_167"].ToString());
                            if (decimal.Parse(Row1["nop_h_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                row["Fldb" + (i + 1)] = decimal.Parse(row["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row1["not_h_200"].ToString());
                            if (decimal.Parse(Row1["nop_w_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                row["Fldb" + (i + 1)] = decimal.Parse(row["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row1["tot_w_133"].ToString());
                            if (decimal.Parse(Row1["nop_w_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                row["Fldb" + (i + 1)] = decimal.Parse(row["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row1["tot_w_167"].ToString());
                            if (decimal.Parse(Row1["nop_w_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                row["Fldb" + (i + 1)] = decimal.Parse(row["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row1["tot_w_200"].ToString());
                            //row["exsum"] = decimal.Parse(row["exsum"].ToString()) + decimal.Parse(row["Fldb" + (i + 1)].ToString());
                            _othrs += decimal.Parse(row["Fldb" + (i + 1)].ToString());
                        }
                        row["exsum"] = _othrs;
                        row["ex_amt"] = int.Parse(row["ex_amt"].ToString()) + int.Parse(Row1["not_exp"].ToString()) + int.Parse(Row1["tot_exp"].ToString());
                        //if (reporttype == "11" || reporttype == "12")
                        //    row["exsum"] = decimal.Parse(row["ex_100"].ToString()) + decimal.Parse(row["ex_133"].ToString()) + decimal.Parse(row["ex_167"].ToString()) + decimal.Parse(row["ex_200"].ToString());
                    }
                    //if (reporttype == "11" || reporttype == "12")
                    //    row["otsum"] = decimal.Parse(row["ot_100"].ToString()) + decimal.Parse(row["ot_133"].ToString()) + decimal.Parse(row["ot_167"].ToString()) + decimal.Parse(row["ot_200"].ToString());
                }
                else
                {
                    DataRow aRow = DT_zz438.NewRow();
                    aRow["dept"] = Row1["dept"].ToString();
                    aRow["d_name"] = Row1["d_name"].ToString();
                    aRow["ot_dept"] = Row1["ot_dept"].ToString();
                    aRow["ot_dname"] = Row1["ot_dname"].ToString();
                    //aRow["ot_100"] = ot100;
                    //aRow["ot_133"] = ot133;
                    //aRow["ot_167"] = ot167;
                    //aRow["ot_200"] = ot200;
                    aRow["otsum"] = 0;
                    aRow["ot_amt"] = int.Parse(Row1["not_exp"].ToString()) + int.Parse(Row1["tot_exp"].ToString());
                    //aRow["ex_100"] = Convert.ToDecimal("0.00");
                    //aRow["ex_133"] = Convert.ToDecimal("0.00");
                    //aRow["ex_167"] = Convert.ToDecimal("0.00");
                    //aRow["ex_200"] = Convert.ToDecimal("0.00");
                    aRow["ex_amt"] = 0;
                    aRow["exsum"] = Convert.ToDecimal("0.00");
                    _othrs = 0;
                    for (int i = 0; i < Orow.Length; i++)
                    {
                        aRow["Fld" + (i + 1)] = 0;
                        aRow["Fldb" + (i + 1)] = 0;
                        if (decimal.Parse(Row1["nop_w_100"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            aRow["Fld" + (i + 1)] = decimal.Parse(aRow["Fld" + (i + 1)].ToString()) + decimal.Parse(Row1["not_w_100"].ToString());
                        if (decimal.Parse(Row1["nop_w_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            aRow["Fld" + (i + 1)] = decimal.Parse(aRow["Fld" + (i + 1)].ToString()) + decimal.Parse(Row1["not_w_133"].ToString());
                        if (decimal.Parse(Row1["nop_w_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            aRow["Fld" + (i + 1)] = decimal.Parse(aRow["Fld" + (i + 1)].ToString()) + decimal.Parse(Row1["not_w_167"].ToString());
                        if (decimal.Parse(Row1["nop_w_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            aRow["Fld" + (i + 1)] = decimal.Parse(aRow["Fld" + (i + 1)].ToString()) + decimal.Parse(Row1["not_w_200"].ToString());
                        if (decimal.Parse(Row1["nop_h_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            aRow["Fld" + (i + 1)] = decimal.Parse(aRow["Fld" + (i + 1)].ToString()) + decimal.Parse(Row1["not_h_133"].ToString());
                        if (decimal.Parse(Row1["nop_h_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            aRow["Fld" + (i + 1)] = decimal.Parse(aRow["Fld" + (i + 1)].ToString()) + decimal.Parse(Row1["not_h_167"].ToString());
                        if (decimal.Parse(Row1["nop_h_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            aRow["Fld" + (i + 1)] = decimal.Parse(aRow["Fld" + (i + 1)].ToString()) + decimal.Parse(Row1["not_h_200"].ToString());
                        if (decimal.Parse(Row1["nop_w_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            aRow["Fld" + (i + 1)] = decimal.Parse(aRow["Fld" + (i + 1)].ToString()) + decimal.Parse(Row1["tot_w_133"].ToString());
                        if (decimal.Parse(Row1["nop_w_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            aRow["Fld" + (i + 1)] = decimal.Parse(aRow["Fld" + (i + 1)].ToString()) + decimal.Parse(Row1["tot_w_167"].ToString());
                        if (decimal.Parse(Row1["nop_w_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            aRow["Fld" + (i + 1)] = decimal.Parse(aRow["Fld" + (i + 1)].ToString()) + decimal.Parse(Row1["tot_w_200"].ToString());
                        _othrs += decimal.Parse(aRow["Fld" + (i + 1)].ToString());
                    }
                    aRow["otsum"] = _othrs;

                    _othrs = 0;
                    if (!bool.Parse(Row1["syscreat"].ToString()) && !bool.Parse(Row1["syscreat"].ToString()))
                    {
                        //aRow["ex_100"] = ot100;
                        //aRow["ex_133"] = ot133;
                        //aRow["ex_167"] = ot167;
                        //aRow["ex_200"] = ot200;
                        for (int i = 0; i < Orow.Length; i++)
                        {
                            if (decimal.Parse(Row1["nop_w_100"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                aRow["Fldb" + (i + 1)] = decimal.Parse(Row1["not_w_100"].ToString());
                            if (decimal.Parse(Row1["nop_w_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                aRow["Fldb" + (i + 1)] = decimal.Parse(aRow["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row1["not_w_133"].ToString());
                            if (decimal.Parse(Row1["nop_w_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                aRow["Fldb" + (i + 1)] = decimal.Parse(aRow["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row1["not_w_167"].ToString());
                            if (decimal.Parse(Row1["nop_w_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                aRow["Fldb" + (i + 1)] = decimal.Parse(aRow["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row1["not_w_200"].ToString());
                            if (decimal.Parse(Row1["nop_h_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                aRow["Fldb" + (i + 1)] = decimal.Parse(aRow["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row1["not_h_133"].ToString());
                            if (decimal.Parse(Row1["nop_h_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                aRow["Fldb" + (i + 1)] = decimal.Parse(aRow["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row1["not_h_167"].ToString());
                            if (decimal.Parse(Row1["nop_h_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                aRow["Fldb" + (i + 1)] = decimal.Parse(aRow["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row1["not_h_200"].ToString());
                            if (decimal.Parse(Row1["nop_w_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                aRow["Fldb" + (i + 1)] = decimal.Parse(aRow["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row1["tot_w_133"].ToString());
                            if (decimal.Parse(Row1["nop_w_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                aRow["Fldb" + (i + 1)] = decimal.Parse(aRow["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row1["tot_w_167"].ToString());
                            if (decimal.Parse(Row1["nop_w_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                aRow["Fldb" + (i + 1)] = decimal.Parse(aRow["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row1["tot_w_200"].ToString());
                            //aRow["exsum"] = decimal.Parse(aRow["otsum"].ToString()) + decimal.Parse(aRow["Fldb" + (i + 1)].ToString());
                            _othrs += decimal.Parse(aRow["Fldb" + (i + 1)].ToString());
                        }
                        aRow["exsum"] = _othrs;
                        aRow["ex_amt"] = int.Parse(Row1["not_exp"].ToString()) + int.Parse(Row1["tot_exp"].ToString());
                        //if (reporttype == "11" || reporttype == "12")
                        //    aRow["exsum"] = ot100 + ot133 + ot167 + ot200;
                    }
                    if (reporttype == "11")
                    {
                        aRow["job"] = Row1["job"].ToString();
                        aRow["job_name"] = Row1["job_name"].ToString();
                        aRow["count_ma"] = str_ma;
                        aRow["otsum"] = ot100 + ot133 + ot167 + ot200;
                    }
                    if (reporttype == "12")
                    {
                        aRow["nobr"] = Row1["nobr"].ToString();
                        aRow["name_c"] = Row1["name_c"].ToString();
                        aRow["name_e"] = Row1["name_e"].ToString();
                        aRow["otsum"] = ot100 + ot133 + ot167 + ot200;
                    }
                    DT_zz438.Rows.Add(aRow);
                }
            }
        }
        public static void GetDataZZ439(DataTable DT_zz439,DataTable DT_zz439a,DataTable DT_zz431,string reporttype)
        {
            DataTable ot_per = new DataTable();
            ot_per.Columns.Add("ot_per", typeof(decimal));
            ot_per.PrimaryKey = new DataColumn[] { ot_per.Columns["ot_per"] };
            foreach (DataRow Row1 in DT_zz431.Rows)
            {
                if (decimal.Parse(Row1["nop_w_100"].ToString()) != 0)
                {
                    DataRow row = ot_per.Rows.Find(decimal.Parse(Row1["nop_w_100"].ToString()));
                    if (row == null)
                    {
                        DataRow aRow = ot_per.NewRow();
                        aRow["ot_per"] = decimal.Parse(Row1["nop_w_100"].ToString());
                        ot_per.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row1["nop_w_133"].ToString()) != 0)
                {
                    DataRow row = ot_per.Rows.Find(decimal.Parse(Row1["nop_w_133"].ToString()));
                    if (row == null)
                    {
                        DataRow aRow = ot_per.NewRow();
                        aRow["ot_per"] = decimal.Parse(Row1["nop_w_133"].ToString());
                        ot_per.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row1["nop_w_167"].ToString()) != 0)
                {
                    DataRow row = ot_per.Rows.Find(decimal.Parse(Row1["nop_w_167"].ToString()));
                    if (row == null)
                    {
                        DataRow aRow = ot_per.NewRow();
                        aRow["ot_per"] = decimal.Parse(Row1["nop_w_167"].ToString());
                        ot_per.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row1["nop_w_200"].ToString()) != 0)
                {
                    DataRow row = ot_per.Rows.Find(decimal.Parse(Row1["nop_w_200"].ToString()));
                    if (row == null)
                    {
                        DataRow aRow = ot_per.NewRow();
                        aRow["ot_per"] = decimal.Parse(Row1["nop_w_200"].ToString());
                        ot_per.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row1["nop_h_133"].ToString()) != 0)
                {
                    DataRow row = ot_per.Rows.Find(decimal.Parse(Row1["nop_h_133"].ToString()));
                    if (row == null)
                    {
                        DataRow aRow = ot_per.NewRow();
                        aRow["ot_per"] = decimal.Parse(Row1["nop_h_133"].ToString());
                        ot_per.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row1["nop_h_167"].ToString()) != 0)
                {
                    DataRow row = ot_per.Rows.Find(decimal.Parse(Row1["nop_h_167"].ToString()));
                    if (row == null)
                    {
                        DataRow aRow = ot_per.NewRow();
                        aRow["ot_per"] = decimal.Parse(Row1["nop_h_167"].ToString());
                        ot_per.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row1["nop_h_200"].ToString()) != 0)
                {
                    DataRow row = ot_per.Rows.Find(decimal.Parse(Row1["nop_h_200"].ToString()));
                    if (row == null)
                    {
                        DataRow aRow = ot_per.NewRow();
                        aRow["ot_per"] = decimal.Parse(Row1["nop_h_200"].ToString());
                        ot_per.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row1["top_w_133"].ToString()) != 0)
                {
                    DataRow row = ot_per.Rows.Find(decimal.Parse(Row1["top_w_133"].ToString()));
                    if (row == null)
                    {
                        DataRow aRow = ot_per.NewRow();
                        aRow["ot_per"] = decimal.Parse(Row1["top_w_133"].ToString());
                        ot_per.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row1["top_w_167"].ToString()) != 0)
                {
                    DataRow row = ot_per.Rows.Find(decimal.Parse(Row1["top_w_167"].ToString()));
                    if (row == null)
                    {
                        DataRow aRow = ot_per.NewRow();
                        aRow["ot_per"] = decimal.Parse(Row1["top_w_167"].ToString());
                        ot_per.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row1["top_w_200"].ToString()) != 0)
                {
                    DataRow row = ot_per.Rows.Find(decimal.Parse(Row1["top_w_200"].ToString()));
                    if (row == null)
                    {
                        DataRow aRow = ot_per.NewRow();
                        aRow["ot_per"] = decimal.Parse(Row1["top_w_200"].ToString());
                        ot_per.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row1["top_h_200"].ToString()) != 0)
                {
                    DataRow row = ot_per.Rows.Find(decimal.Parse(Row1["top_h_200"].ToString()));
                    if (row == null)
                    {
                        DataRow aRow = ot_per.NewRow();
                        aRow["ot_per"] = decimal.Parse(Row1["top_h_200"].ToString());
                        ot_per.Rows.Add(aRow);
                    }
                }
            }
            int aat = ot_per.Rows.Count;
            DataRow[] Orow = ot_per.Select("", "ot_per asc");
            DataRow aRow1 = DT_zz439a.NewRow();
            for (int i = 0; i < Orow.Length; i++)
            {
                aRow1["Fld" + (i + 1)] = Orow[i]["ot_per"].ToString();
                aRow1["Fldb" + (i + 1)] = Orow[i]["ot_per"].ToString();
            }
            DT_zz439a.Rows.Add(aRow1);
            DataRow[] Row439 = DT_zz431.Select("", "dept,nobr asc");
            if (reporttype == "9")
            {
                foreach (DataRow Row2 in Row439)
                {
                    DataRow aRow2 = DT_zz439.NewRow();
                    aRow2["dept"] = Row2["dept"].ToString();
                    aRow2["d_name"] = Row2["d_name"].ToString();
                    aRow2["ot_dept"] = Row2["ot_dept"].ToString();
                    aRow2["ot_dname"] = Row2["ot_dname"].ToString();
                    aRow2["nobr"] = Row2["nobr"].ToString();
                    aRow2["name_c"] = Row2["name_c"].ToString();
                    aRow2["name_e"] = Row2["name_e"].ToString();
                    aRow2["bdate"] = DateTime.Parse(Row2["bdate"].ToString());
                    aRow2["dw"] = Row2["dw"].ToString();
                    aRow2["btime"] = Row2["btime"].ToString();
                    aRow2["etime"] = Row2["etime"].ToString();
                    aRow2["ot_hrs"] = decimal.Parse(Row2["ot_hrs"].ToString());
                    aRow2["rest_hrs"] = decimal.Parse(Row2["rest_hrs"].ToString());
                    for (int i = 0; i < Orow.Length; i++)
                    {
                        aRow2["Fld" + (i + 1)] = 0;
                        aRow2["Fldb" + (i + 1)] = 0;
                        if (decimal.Parse(Row2["nop_w_100"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            aRow2["Fld" + (i + 1)] = decimal.Parse(Row2["not_w_100"].ToString());
                        if (decimal.Parse(Row2["nop_w_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            aRow2["Fld" + (i + 1)] = decimal.Parse(aRow2["Fld" + (i + 1)].ToString()) + decimal.Parse(Row2["not_w_133"].ToString());
                        if (decimal.Parse(Row2["nop_w_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            aRow2["Fld" + (i + 1)] = decimal.Parse(aRow2["Fld" + (i + 1)].ToString()) + decimal.Parse(Row2["not_w_167"].ToString());
                        if (decimal.Parse(Row2["nop_w_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            aRow2["Fld" + (i + 1)] = decimal.Parse(aRow2["Fld" + (i + 1)].ToString()) + decimal.Parse(Row2["not_w_200"].ToString());
                        if (decimal.Parse(Row2["nop_h_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            aRow2["Fld" + (i + 1)] = decimal.Parse(aRow2["Fld" + (i + 1)].ToString()) + decimal.Parse(Row2["not_h_133"].ToString());
                        if (decimal.Parse(Row2["nop_h_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            aRow2["Fld" + (i + 1)] = decimal.Parse(aRow2["Fld" + (i + 1)].ToString()) + decimal.Parse(Row2["not_h_167"].ToString());
                        if (decimal.Parse(Row2["nop_h_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            aRow2["Fld" + (i + 1)] = decimal.Parse(aRow2["Fld" + (i + 1)].ToString()) + decimal.Parse(Row2["not_h_200"].ToString());
                        if (decimal.Parse(Row2["nop_w_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            aRow2["Fldb" + (i + 1)] = decimal.Parse(Row2["tot_w_133"].ToString());
                        if (decimal.Parse(Row2["nop_w_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            aRow2["Fldb" + (i + 1)] = decimal.Parse(aRow2["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row2["tot_w_167"].ToString());
                        if (decimal.Parse(Row2["nop_w_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            aRow2["Fldb" + (i + 1)] = decimal.Parse(aRow2["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row2["tot_w_200"].ToString());
                        //if (decimal.Parse(Row2["top_w_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                        //    aRow2["Fldb" + (i + 1)] = decimal.Parse(aRow2["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row2["tot_w_200"].ToString());
                        //if (decimal.Parse(Row2["top_h_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                        //    aRow2["Fldb" + (i + 1)] = decimal.Parse(aRow2["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row2["tot_h_200"].ToString());
                        //原程式
                        //if (decimal.Parse(Row2["top_w_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                        //    aRow2["Fldb" + (i + 1)] = decimal.Parse(Row2["tot_w_133"].ToString());
                        //if (decimal.Parse(Row2["top_w_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                        //    aRow2["Fldb" + (i + 1)] = decimal.Parse(aRow2["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row2["tot_w_167"].ToString());
                        //if (decimal.Parse(Row2["top_w_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                        //    aRow2["Fldb" + (i + 1)] = decimal.Parse(aRow2["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row2["tot_w_200"].ToString());
                        //if (decimal.Parse(Row2["top_h_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                        //    aRow2["Fldb" + (i + 1)] = decimal.Parse(aRow2["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row2["tot_h_200"].ToString());
                    }
                    DT_zz439.Rows.Add(aRow2);
                }
            }
            else
            {
                DT_zz439.PrimaryKey = new DataColumn[] { DT_zz439.Columns["dept"], DT_zz439.Columns["nobr"] };

                foreach (DataRow Row2 in Row439)
                {
                    object[] _value = new object[2];
                    _value[0] = Row2["dept"].ToString();
                    _value[1] = Row2["nobr"].ToString();
                    DataRow row5 = DT_zz439.Rows.Find(_value);
                    if (row5 != null)
                    {
                        row5["ot_hrs"] = decimal.Parse(row5["ot_hrs"].ToString()) + decimal.Parse(Row2["ot_hrs"].ToString());
                        row5["rest_hrs"] = decimal.Parse(row5["rest_hrs"].ToString()) + decimal.Parse(Row2["rest_hrs"].ToString());
                        for (int i = 0; i < Orow.Length; i++)
                        {
                            if (decimal.Parse(Row2["nop_w_100"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                row5["Fld" + (i + 1)] = decimal.Parse(row5["Fld" + (i + 1)].ToString()) + decimal.Parse(Row2["not_w_100"].ToString());
                            if (decimal.Parse(Row2["nop_w_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                row5["Fld" + (i + 1)] = decimal.Parse(row5["Fld" + (i + 1)].ToString()) + decimal.Parse(Row2["not_w_133"].ToString());
                            if (decimal.Parse(Row2["nop_w_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                row5["Fld" + (i + 1)] = decimal.Parse(row5["Fld" + (i + 1)].ToString()) + decimal.Parse(Row2["not_w_167"].ToString());
                            if (decimal.Parse(Row2["nop_w_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                row5["Fld" + (i + 1)] = decimal.Parse(row5["Fld" + (i + 1)].ToString()) + decimal.Parse(Row2["not_w_200"].ToString());
                            if (decimal.Parse(Row2["nop_h_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                row5["Fld" + (i + 1)] = decimal.Parse(row5["Fld" + (i + 1)].ToString()) + decimal.Parse(Row2["not_h_133"].ToString());
                            if (decimal.Parse(Row2["nop_h_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                row5["Fld" + (i + 1)] = decimal.Parse(row5["Fld" + (i + 1)].ToString()) + decimal.Parse(Row2["not_h_167"].ToString());
                            if (decimal.Parse(Row2["nop_h_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                row5["Fld" + (i + 1)] = decimal.Parse(row5["Fld" + (i + 1)].ToString()) + decimal.Parse(Row2["not_h_200"].ToString());
                            if (decimal.Parse(Row2["nop_w_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                row5["Fldb" + (i + 1)] = decimal.Parse(row5["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row2["tot_w_133"].ToString());
                            if (decimal.Parse(Row2["nop_w_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                row5["Fldb" + (i + 1)] = decimal.Parse(row5["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row2["tot_w_167"].ToString());
                            if (decimal.Parse(Row2["nop_w_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                row5["Fldb" + (i + 1)] = decimal.Parse(row5["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row2["tot_w_200"].ToString());

                            //if (decimal.Parse(Row2["top_w_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            //    row5["Fldb" + (i + 1)] = decimal.Parse(row5["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row2["tot_w_200"].ToString());
                            //if (decimal.Parse(Row2["top_h_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            //    row5["Fldb" + (i + 1)] = decimal.Parse(row5["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row2["tot_h_200"].ToString());
                            //if (decimal.Parse(Row2["top_w_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            //    row5["Fldb" + (i + 1)] = decimal.Parse(row5["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row2["tot_w_133"].ToString());
                            //if (decimal.Parse(Row2["top_w_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            //    row5["Fldb" + (i + 1)] = decimal.Parse(row5["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row2["tot_w_167"].ToString());
                            //if (decimal.Parse(Row2["top_w_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            //    row5["Fldb" + (i + 1)] = decimal.Parse(row5["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row2["tot_w_200"].ToString());
                            //if (decimal.Parse(Row2["top_h_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            //    row5["Fldb" + (i + 1)] = decimal.Parse(row5["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row2["tot_h_200"].ToString());
                        }
                    }
                    else
                    {
                        DataRow aRow2 = DT_zz439.NewRow();
                        aRow2["dept"] = Row2["dept"].ToString();
                        aRow2["d_name"] = Row2["d_name"].ToString();
                        aRow2["ot_dept"] = Row2["ot_dept"].ToString();
                        aRow2["ot_dname"] = Row2["ot_dname"].ToString();
                        aRow2["nobr"] = Row2["nobr"].ToString();
                        aRow2["name_c"] = Row2["name_c"].ToString();
                        aRow2["name_e"] = Row2["name_e"].ToString();
                        aRow2["ot_hrs"] = decimal.Parse(Row2["ot_hrs"].ToString());
                        aRow2["rest_hrs"] = decimal.Parse(Row2["rest_hrs"].ToString());
                        for (int i = 0; i < Orow.Length; i++)
                        {
                            aRow2["Fld" + (i + 1)] = 0;
                            aRow2["Fldb" + (i + 1)] = 0;
                            if (decimal.Parse(Row2["nop_w_100"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                aRow2["Fld" + (i + 1)] = decimal.Parse(Row2["not_w_100"].ToString());
                            if (decimal.Parse(Row2["nop_w_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                aRow2["Fld" + (i + 1)] = decimal.Parse(aRow2["Fld" + (i + 1)].ToString()) + decimal.Parse(Row2["not_w_133"].ToString());
                            if (decimal.Parse(Row2["nop_w_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                aRow2["Fld" + (i + 1)] = decimal.Parse(aRow2["Fld" + (i + 1)].ToString()) + decimal.Parse(Row2["not_w_167"].ToString());
                            if (decimal.Parse(Row2["nop_w_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                aRow2["Fld" + (i + 1)] = decimal.Parse(aRow2["Fld" + (i + 1)].ToString()) + decimal.Parse(Row2["not_w_200"].ToString());
                            if (decimal.Parse(Row2["nop_h_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                aRow2["Fld" + (i + 1)] = decimal.Parse(aRow2["Fld" + (i + 1)].ToString()) + decimal.Parse(Row2["not_h_133"].ToString());
                            if (decimal.Parse(Row2["nop_h_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                aRow2["Fld" + (i + 1)] = decimal.Parse(aRow2["Fld" + (i + 1)].ToString()) + decimal.Parse(Row2["not_h_167"].ToString());
                            if (decimal.Parse(Row2["nop_h_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                aRow2["Fld" + (i + 1)] = decimal.Parse(aRow2["Fld" + (i + 1)].ToString()) + decimal.Parse(Row2["not_h_200"].ToString());
                            if (decimal.Parse(Row2["nop_w_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                aRow2["Fldb" + (i + 1)] = decimal.Parse(Row2["tot_w_133"].ToString());
                            if (decimal.Parse(Row2["nop_w_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                aRow2["Fldb" + (i + 1)] = decimal.Parse(aRow2["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row2["tot_w_167"].ToString());
                            if (decimal.Parse(Row2["nop_w_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                                aRow2["Fldb" + (i + 1)] = decimal.Parse(aRow2["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row2["tot_w_200"].ToString());
                            //if (decimal.Parse(Row2["top_w_133"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            //    aRow2["Fldb" + (i + 1)] = decimal.Parse(Row2["tot_w_133"].ToString());
                            //if (decimal.Parse(Row2["top_w_167"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            //    aRow2["Fldb" + (i + 1)] = decimal.Parse(aRow2["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row2["tot_w_167"].ToString());
                            //if (decimal.Parse(Row2["top_w_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            //    aRow2["Fldb" + (i + 1)] = decimal.Parse(aRow2["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row2["tot_w_200"].ToString());
                            //if (decimal.Parse(Row2["top_h_200"].ToString()) == decimal.Parse(Orow[i]["ot_per"].ToString()))
                            //    aRow2["Fldb" + (i + 1)] = decimal.Parse(aRow2["Fldb" + (i + 1)].ToString()) + decimal.Parse(Row2["tot_h_200"].ToString());
                        }
                        DT_zz439.Rows.Add(aRow2);
                    }
                }
            }
            ot_per = null;
        }

        public static void GetFixamt(DataTable DT_waged,DataTable DT_fixamt)
        {
            DataRow[] Srow = DT_waged.Select("sal_code='A01' or sal_code='A02' or sal_code='G01'");
            foreach (DataRow Row in Srow)
            {
                DataRow row = DT_fixamt.Rows.Find(Row["d_name"].ToString());
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow = DT_fixamt.NewRow();
                    aRow["depts"] = Row["depts"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    DT_fixamt.Rows.Add(aRow);
                }
            }
        }

        public static void GetAllamt(DataTable DT_waged, DataTable DT_allamt, string retsalcode)
        {
            DataRow[] Srow = DT_waged.Select("salattr <='L' and sal_code <>'" + retsalcode + "'");
            foreach (DataRow Row in Srow)
            {
                DataRow row = DT_allamt.Rows.Find(Row["d_name"].ToString());
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + Math.Round(decimal.Parse(Row["amt"].ToString()), MidpointRounding.AwayFromZero);
                else
                {
                    DataRow aRow = DT_allamt.NewRow();
                    aRow["depts"] = Row["depts"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["amt"] = Math.Round(decimal.Parse(Row["amt"].ToString()), MidpointRounding.AwayFromZero);
                    DT_allamt.Rows.Add(aRow);
                }
            }
        }

        public static void GetWelamt(DataTable DT_explab, DataTable DT_welamt)
        {
            foreach (DataRow Row in DT_explab.Rows)
            {
                DataRow row = DT_welamt.Rows.Find(Row["d_name"].ToString());
                if (row != null)
                    row["comp"] = int.Parse(row["comp"].ToString()) + int.Parse(Row["comp"].ToString());
                else
                {
                    DataRow aRow = DT_welamt.NewRow();
                    aRow["depts"] = Row["depts"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["comp"] = int.Parse(Row["comp"].ToString());
                    DT_welamt.Rows.Add(aRow);
                }
            }
        }


        public static void GetCnt(DataTable DT_waged,DataTable Dt_cnt)
        {
            foreach (DataRow Row in DT_waged.Rows)
            {
                DataRow row = Dt_cnt.Rows.Find(Row["nobr"].ToString());
                if (row == null)                    
                {
                    DataRow aRow = Dt_cnt.NewRow();
                    aRow["depts"] = Row["depts"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["nobr"] = Row["nobr"].ToString();
                    Dt_cnt.Rows.Add(aRow);
                }
            }
        }


        public static void GetOtamt(DataTable DT_zz431, DataTable DT_otamt)
        {
            DataTable rq_otamt1 = new DataTable();
            rq_otamt1.Columns.Add("nobr", typeof(string));
            rq_otamt1.Columns.Add("depts", typeof(string));
            rq_otamt1.Columns.Add("d_name", typeof(string));
            rq_otamt1.Columns.Add("ot_dept", typeof(string));
            rq_otamt1.Columns.Add("ot_dname", typeof(string));
            rq_otamt1.Columns.Add("tol_hrs", typeof(decimal));
            rq_otamt1.Columns.Add("ot_hrs", typeof(decimal));
            rq_otamt1.Columns.Add("ex_hrs", typeof(decimal));
            rq_otamt1.Columns.Add("otamt", typeof(int));
            rq_otamt1.Columns.Add("examt", typeof(int));
            rq_otamt1.PrimaryKey = new DataColumn[] { rq_otamt1.Columns["nobr"] };
            foreach (DataRow Row in DT_zz431.Rows)
            {
                if (decimal.Parse(Row["nop_w_100"].ToString()) == 2)
                {
                    Row["not_w_200"] = decimal.Parse(Row["not_w_100"].ToString());
                    Row["not_w_100"] = 0;
                }

                DataRow row = rq_otamt1.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                {
                    if (!bool.Parse(Row["syscreat"].ToString()) && !bool.Parse(Row["syscreat1"].ToString()))
                    {
                        row["ex_hrs"] = decimal.Parse(row["ex_hrs"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString()) + decimal.Parse(Row["rest_hrs"].ToString());
                        row["examt"] = int.Parse(row["examt"].ToString()) + int.Parse(Row["not_exp"].ToString()) + int.Parse(Row["tot_exp"].ToString());
                    }
                    else
                    {
                        row["ot_hrs"] = decimal.Parse(row["ot_hrs"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString()) + decimal.Parse(Row["rest_hrs"].ToString());
                        row["otamt"] = int.Parse(row["otamt"].ToString()) + int.Parse(Row["not_exp"].ToString()) + int.Parse(Row["tot_exp"].ToString());
                    }
                    row["tol_hrs"] = decimal.Parse(row["ex_hrs"].ToString()) + decimal.Parse(row["ot_hrs"].ToString());
                }
                else
                {
                    DataRow aRow = rq_otamt1.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["depts"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["ot_dept"] = Row["ot_dept"].ToString();
                    aRow["ot_dname"] = Row["ot_dname"].ToString();
                    aRow["ex_hrs"] = Convert.ToDecimal(0.00);
                    aRow["ot_hrs"] = Convert.ToDecimal(0.00);
                    aRow["examt"] = 0;
                    aRow["otamt"] = 0;
                    aRow["tol_hrs"] = Convert.ToDecimal(0.00);
                    if (!bool.Parse(Row["syscreat"].ToString()) && !bool.Parse(Row["syscreat1"].ToString()))
                    {
                        aRow["ex_hrs"] = decimal.Parse(Row["ot_hrs"].ToString()) + decimal.Parse(Row["rest_hrs"].ToString());
                        aRow["examt"] = int.Parse(Row["not_exp"].ToString()) + int.Parse(Row["tot_exp"].ToString());
                    }
                    else
                    {
                        aRow["ot_hrs"] = decimal.Parse(Row["ot_hrs"].ToString()) + decimal.Parse(Row["rest_hrs"].ToString());
                        aRow["otamt"] = int.Parse(Row["not_exp"].ToString()) + int.Parse(Row["tot_exp"].ToString());
                    }
                    aRow["tol_hrs"] = decimal.Parse(aRow["ex_hrs"].ToString()) + decimal.Parse(aRow["ot_hrs"].ToString());                   
                    rq_otamt1.Rows.Add(aRow);
                }
            }
            foreach (DataRow Row in rq_otamt1.Rows)
            {
                DataRow row1 = DT_otamt.Rows.Find(Row["d_name"].ToString());
                if (row1 != null)
                {
                    row1["ex_hrs"] = decimal.Parse(row1["ex_hrs"].ToString()) + decimal.Parse(Row["ex_hrs"].ToString());
                    row1["ot_hrs"] = decimal.Parse(row1["ot_hrs"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString());
                    row1["examt"] = int.Parse(row1["examt"].ToString()) + int.Parse(Row["examt"].ToString());
                    row1["otamt"] = int.Parse(row1["otamt"].ToString()) + int.Parse(Row["otamt"].ToString());
                    row1["tol_hrs"] = decimal.Parse(row1["tol_hrs"].ToString()) + decimal.Parse(Row["tol_hrs"].ToString());
                }
                else
                {
                    DataRow aRow1 = DT_otamt.NewRow();                   
                    aRow1["depts"] = Row["depts"].ToString();
                    aRow1["d_name"] = Row["d_name"].ToString();
                    aRow1["ot_dept"] = Row["ot_dept"].ToString();
                    aRow1["ot_dname"] = Row["ot_dname"].ToString();
                    aRow1["ex_hrs"] = decimal.Parse(Row["ex_hrs"].ToString());
                    aRow1["ot_hrs"] = decimal.Parse(Row["ot_hrs"].ToString());
                    aRow1["examt"] = int.Parse(Row["examt"].ToString());
                    aRow1["otamt"] = int.Parse(Row["otamt"].ToString());
                    aRow1["tol_hrs"] = decimal.Parse(Row["tol_hrs"].ToString());
                    aRow1["pn"] = "0";
                    DT_otamt.Rows.Add(aRow1);
                }
            }
            rq_otamt1 = null;
        }


        public static void GetZz43e(DataTable DT_zz43e, DataTable DT_otamt, DataTable DT_cnt, DataTable DT_fixamt, DataTable DT_allamt, DataTable DT_welamt)
        {
            DataTable rq_pno = new DataTable();
            rq_pno.Columns.Add("depts", typeof(string));
            rq_pno.Columns.Add("d_name", typeof(string));
            rq_pno.Columns.Add("cnt", typeof(int));
            rq_pno.PrimaryKey = new DataColumn[] { rq_pno.Columns["d_name"] };
            foreach (DataRow Row in DT_cnt.Rows)
            {
                DataRow row = rq_pno.Rows.Find(Row["d_name"].ToString());
                if (row != null)
                    row["cnt"] = int.Parse(row["cnt"].ToString()) + 1;
                else
                {
                    DataRow aRow = rq_pno.NewRow();
                    aRow["depts"] = Row["depts"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["cnt"] = 1;
                    rq_pno.Rows.Add(aRow);
                }
            }

            foreach (DataRow Row in rq_pno.Rows)
            {
                DataRow row = DT_zz43e.Rows.Find(Row["d_name"].ToString());
                DataRow row1 = DT_otamt.Rows.Find(Row["d_name"].ToString());
                DataRow row2 = DT_fixamt.Rows.Find(Row["d_name"].ToString());
                DataRow row3 = DT_allamt.Rows.Find(Row["d_name"].ToString());
                DataRow row4 = DT_welamt.Rows.Find(Row["d_name"].ToString());
                if (row != null && row1!=null)
                {
                    row["ot_hrs"] = decimal.Parse(row["ot_hrs"].ToString()) + decimal.Parse(row1["ot_hrs"].ToString());
                    row["ex_hrs"] = decimal.Parse(row["ex_hrs"].ToString()) + decimal.Parse(row1["ex_hrs"].ToString());
                    row["tol_hrs"] = decimal.Parse(row["ot_hrs"].ToString()) + decimal.Parse(row1["ex_hrs"].ToString());
                    if (row1 != null)
                    {
                        row["avghrs"] = Math.Round(decimal.Parse(row["tol_hrs"].ToString()) / decimal.Parse(Row["cnt"].ToString()), 2, MidpointRounding.AwayFromZero);
                        row["pn"] = "1";
                    }
                    row["otamt"] = int.Parse(row["otamt"].ToString()) + int.Parse(row1["otamt"].ToString());
                    row["examt"] = int.Parse(row["examt"].ToString()) + int.Parse(row1["examt"].ToString());
                }
                else
                {
                    DataRow aRow1 = DT_zz43e.NewRow();
                    aRow1["depts"] = Row["depts"].ToString();
                    aRow1["d_name"] = Row["d_name"].ToString();
                    aRow1["ot_dept"] = row1["ot_dept"].ToString();
                    aRow1["ot_dname"] = row1["ot_dname"].ToString();
                    aRow1["ot_hrs"] = (row1 == null) ? Convert.ToDecimal(0.00) : decimal.Parse(row1["ot_hrs"].ToString());
                    aRow1["ex_hrs"] = (row1 == null) ? Convert.ToDecimal(0.00) : decimal.Parse(row1["ex_hrs"].ToString());
                    aRow1["tol_hrs"] = (row1 == null) ? Convert.ToDecimal(0.00) : decimal.Parse(row1["ot_hrs"].ToString()) + decimal.Parse(row1["ex_hrs"].ToString());
                    aRow1["p_no"] = int.Parse(Row["cnt"].ToString());
                    if (row1 != null)
                    {
                        aRow1["avghrs"] = Math.Round(decimal.Parse(aRow1["tol_hrs"].ToString()) / decimal.Parse(Row["cnt"].ToString()),2, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        aRow1["avghrs"] = decimal.Parse(aRow1["tol_hrs"].ToString());
                    }
                    aRow1["fix_amt"] = (row2 == null) ? 0 : int.Parse(row2["amt"].ToString());
                    aRow1["all_amt"] = (row3 == null) ? 0 : int.Parse(row3["amt"].ToString());
                    aRow1["wel_amt"] = (row4 == null) ? 0 : int.Parse(row4["comp"].ToString());
                    aRow1["otamt"] = (row1 == null) ? 0 : int.Parse(row1["otamt"].ToString()); ;
                    aRow1["examt"] = (row1 == null) ? 0 : int.Parse(row1["examt"].ToString());
                    aRow1["var_amt"] = int.Parse(aRow1["all_amt"].ToString()) - int.Parse(aRow1["fix_amt"].ToString());
                    aRow1["tol_amt"] = int.Parse(aRow1["all_amt"].ToString()) - int.Parse(aRow1["wel_amt"].ToString());
                    if (row1 != null) row1["pn"] = "1";
                    DT_zz43e.Rows.Add(aRow1);
                }                
            }

            DataRow[] SRow = DT_otamt.Select("pn='0'");
            foreach (DataRow Row5 in SRow)
            {
                DataRow row5 = DT_zz43e.Rows.Find(Row5["d_name"].ToString());
                if (row5 != null)
                {
                    row5["ot_hrs"] = decimal.Parse(row5["ot_hrs"].ToString()) + decimal.Parse(Row5["ot_hrs"].ToString());
                    row5["ex_hrs"] = decimal.Parse(row5["ex_hrs"].ToString()) + decimal.Parse(Row5["ex_hrs"].ToString());
                    row5["tol_hrs"] = decimal.Parse(row5["tol_hrs"].ToString()) + decimal.Parse(Row5["tol_hrs"].ToString());
                }
                else
                {
                    DataRow aRow2 = DT_zz43e.NewRow();
                    aRow2["depts"] = Row5["depts"];
                    aRow2["d_name"] = Row5["d_name"].ToString();
                    aRow2["ot_dept"] = Row5["ot_dept"];
                    aRow2["ot_dname"] = Row5["ot_dname"].ToString();
                    aRow2["ot_hrs"] = decimal.Parse(Row5["ot_hrs"].ToString());
                    aRow2["ex_hrs"] = decimal.Parse(Row5["ex_hrs"].ToString());
                    aRow2["tol_hrs"] = decimal.Parse(Row5["tol_hrs"].ToString());
                    aRow2["p_no"] = 0;
                    aRow2["fix_amt"] = 0;
                    aRow2["all_amt"] = 0;
                    aRow2["wel_amt"] = 0;
                    aRow2["otamt"] = 0;
                    aRow2["examt"] = 0;
                    aRow2["var_amt"] = 0;
                    aRow2["tol_amt"] = 0;
                    aRow2["avghrs"] = 0;
                    DT_zz43e.Rows.Add(aRow2);
                }
            }
        }



    }

}
