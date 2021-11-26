using Bll.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using Telerik.Web.UI;


    public class ControlGetSet
    {
        public static string GetDropDownList(RadDropDownList ddl, RadTextBox txt)
        {
            var s = txt.Text.NullToString();

            //如果不是選最後一個 
            if (ddl.Items.Cast<DropDownListItem>().Last().Selected == false && s.Length == 0)
                s = ddl.SelectedValue;

            return s;
        }

        public static string GetDropDownList(RadDropDownList ddl)
        {
            var s = ddl.SelectedValue.NullToString();

            return s;
        }

        public static string GetRadioButtonList(RadRadioButtonList rbl, RadTextBox txt)
        {
            var s = txt.Text.NullToString();

            //如果不是選最後一個 
            if (rbl.Items.Cast<ButtonListItem>().Last().Selected == false && s.Length == 0)
                s = rbl.SelectedValue;

            return s;
        }

        public static string GetRadioButtonList(RadRadioButtonList rbl, RadNumericTextBox txt)
        {
            var s = txt.Text.NullToString();

            //如果不是選最後一個 
            if (rbl.Items.Cast<ButtonListItem>().Last().Selected == false && s.Length == 0)
                s = rbl.SelectedValue;

            return s;
        }

        public static string GetRadioButtonList(RadRadioButtonList rbl)
        {
            var s = rbl.SelectedValue.NullToString();

            return s;
        }

        public static bool? GetRadioButtonListConvertBool(RadRadioButtonList rbl)
        {
            var s = rbl.SelectedValue.NullToString();

            bool? b = null;
            if (s.Length > 0)
                b = s == "1";

            return b;
        }

        public static string GetCheckBoxList(RadCheckBoxList cbl)
        {
            return string.Join(",", cbl.Items.Cast<ButtonListItem>()
                .Where(x => x.Selected).Select(x => x.Value).ToArray<string>());
        }

        public static void SetDropDownList(RadDropDownList ddl, string s)
        {
            s = s.NullToString();
            ddl.ClearSelection();
            if (ddl.FindItemByValue(s) != null)
                ddl.FindItemByValue(s).Selected = true;
        }

        public static void SetRadComboBox(RadComboBox ddl, string s)
        {
            s = s.NullToString();
            ddl.ClearSelection();
            if (ddl.FindItemByValue(s) != null)
                ddl.FindItemByValue(s).Selected = true;
        }

        public static void SetDropDownList(RadDropDownList ddl, RadTextBox txt)
        {
            if (ddl.Items.Count > 0)
            {
                var s = txt.Text.NullToString();
                var ItemSelected = false;
                ddl.ClearSelection();
                if (ddl.FindItemByValue(s) != null)
                {
                    ddl.FindItemByValue(s).Selected = true;
                    ItemSelected = true;
                }

                //如果有選到 就把文字內容清空 否則強制直接選最後一個(必須要有文字)
                if (ItemSelected)
                    txt.Text = "";
                else if (s.Length > 0)
                    ddl.Items.Cast<DropDownListItem>().Last().Selected = true;
            }
        }

        public static void SetCheckBoxList(RadCheckBoxList cbl, List<string> ls)
        {
            if (cbl.Items.Count > 0)
            {
                foreach (ButtonListItem item in cbl.Items)
                    if (ls.Contains(item.Value))
                        item.Selected = true;
                    else
                        item.Selected = false;
            }
        }

        public static void SetRadioButtonList(RadRadioButtonList rbl, RadTextBox txt)
        {
            if (rbl.Items.Count > 0)
            {
                var s = txt.Text.NullToString();
                var ItemSelected = false;
                foreach (ButtonListItem item in rbl.Items)
                    if (item.Value == s)
                    {
                        item.Selected = true;
                        ItemSelected = true;
                    }
                    else
                        item.Selected = false;

                //如果有選到 就把文字內容清空 否則強制直接選最後一個(必須要有文字)
                if (ItemSelected)
                    txt.Text = "";
                else if (s.Length > 0)
                    rbl.Items.Cast<ButtonListItem>().Last().Selected = true;
            }
        }

        public static void SetRadioButtonList(RadRadioButtonList rbl, RadNumericTextBox txt, string s)
        {
            if (rbl.Items.Count > 0)
            {
                s = s.NullToString();
                var ItemSelected = false;
                foreach (ButtonListItem item in rbl.Items)
                    if (item.Value == s)
                    {
                        item.Selected = true;
                        ItemSelected = true;
                    }
                    else
                        item.Selected = false;

                //如果有選到 就把文字內容清空 否則強制直接選最後一個(必須要有文字)
                if (ItemSelected)
                    txt.Text = "";
                else if (s.Length > 0)
                {
                    rbl.Items.Cast<ButtonListItem>().Last().Selected = true;

                    //此欄位因為舊系統有填寫非數值 只取數字
                    txt.Text = Regex.Replace(s, "[^0-9]", ""); ;
                }
            }
        }

        public static void SetRadioButtonList(RadRadioButtonList rbl, string s)
        {
            if (rbl.Items.Count > 0)
            {
                s = s.NullToString();
                foreach (ButtonListItem item in rbl.Items)
                    if (item.Value == s)
                    {
                        item.Selected = true;
                    }
                    else
                        item.Selected = false;
            }
        }

        public static void SetRadioButtonList(RadRadioButtonList rbl, bool? b)
        {
            if (rbl.Items.Count > 0)
            {
              var  s = b != null ? (b.Value ? "1" : "0") : "";
                foreach (ButtonListItem item in rbl.Items)
                    if (item.Value == s)
                    {
                        item.Selected = true;
                    }
                    else
                        item.Selected = false;
            }
        }

        public static bool Validate(object obj1, object obj2, string s = "")
        {
            var b = false;

            try
            {
                RadRadioButtonList rbl = obj1 as RadRadioButtonList;
                RadTextBox txt = obj2 as RadTextBox;

                b = true;

                if (rbl.Items.Cast<ButtonListItem>().Last().Selected)
                    b = txt.Text.Length > 0;

                return b;
            }
            catch
            {
                try
                {
                    RadCheckBoxList cbl = obj1 as RadCheckBoxList;
                    RadTextBox txt = obj2 as RadTextBox;

                    b = true;

                    if (cbl.Items.Cast<ButtonListItem>().Last().Selected)
                        b = txt.Text.Length > 0;

                    return b;
                }
                catch { }
            }

            return b;
        }

        public static bool ValidateRadioButtonList(RadRadioButtonList rbl, RadTextBox txt)
        {
            var b = true;

            if (rbl.Items.Cast<ButtonListItem>().Last().Selected)
                b = txt.Text.Trim().Length > 0;

            return b;
        }

        public static bool ValidateRadioButtonList(RadRadioButtonList rbl, RadNumericTextBox txt)
        {
            var b = true;

            if (rbl.Items.Cast<ButtonListItem>().Last().Selected)
                b = txt.Text.Trim().Length > 0;

            return b;
        }

        //提供方式 各項金額
        public static bool ValidateRadioButtonList(RadRadioButtonList rbl, RadNumericTextBox txt, string s = "")
        {
            var b = true;

            var arr = s.Split(',').ToList();

            if (arr.Contains(rbl.SelectedValue.NullToString()))
                b = txt.Text.Trim().Length > 0;

            return b;
        }

        public static bool ValidateRadioButtonList(RadRadioButtonList rbl, RadDropDownList ddl, string s = "")
        {
            var b = true;

            if (rbl.SelectedValue.NullToString() == s)
                b = ddl.SelectedIndex != 0;

            return b;
        }

        public static bool ValidateCheckBoxList(RadCheckBoxList cbl, RadTextBox txt, string s = "")
        {
            var b = true;

            if (cbl.Items.Cast<ButtonListItem>().Last().Selected)
                b = txt.Text.Trim().Length > 0;

            return b;
        }

        public static bool ValidateCheckBoxList(RadCheckBoxList cbl, RadNumericTextBox txt, string s = "")
        {
            var b = true;

            var arr = cbl.Items.Cast<ButtonListItem>().Where(x => x.Selected).Select(x => x.Value).ToList();
            if (arr.Contains(s))
                b = txt.Text.Trim().Length > 0;

            return b;
        }

        //三節禮金 發放單位
        public static bool ValidateCheckBoxList(RadCheckBoxList cbl, RadRadioButtonList rbl, string s = "")
        {
            var b = true;

            var arr = cbl.Items.Cast<ButtonListItem>().Where(x => x.Selected).Select(x => x.Value).ToList();

            //有勾無 或者 沒有勾任何一筆 都不用填發放單位
            if (arr.Contains(s) || arr.Count == 0)
                b = true;
            else
                b = rbl.SelectedIndex >= 0;

            return b;
        }

        public static bool ValidateDropDownList(RadDropDownList ddl, RadNumericTextBox txt, string s = "", bool Contain = true)
        {
            var b = true;

            var arr = s.Split(',').ToList();

            if (Contain)
            {
                if (arr.Contains(ddl.SelectedValue.NullToString()))
                    b = txt.Text.Trim().Length > 0;
            }
            else
            {
                if (!arr.Contains(ddl.SelectedValue.NullToString()))
                    b = txt.Text.Trim().Length > 0;
            }

            return b;
        }

        //只驗証最後一個 其它 是否有填資料
        public static bool ValidateDropDownList(RadDropDownList ddl, RadTextBox txt, string s = "")
        {
            var b = true;

            if (ddl.Items.Cast<DropDownListItem>().Last().Selected)
                b = txt.Text.Trim().Length > 0;

            return b;
        }

        //其他福利項目 提供方式
        public static bool ValidateDropDownList(RadDropDownList ddl,RadRadioButtonList rbl, string s = "")
        {
            var b = true;

            var arr = s.Split(',').ToList();

            if (!arr.Contains(ddl.SelectedValue.NullToString()))
                b = rbl.SelectedIndex >= 0;

            return b;
        }
    }