using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JBTools
{
    public class FormatValidate
    {
        public static bool CheckIDNO(String str)
        {
            if (str == null || str == "")
            {
                return false;
            }

            if (str.Trim().Length <= 10)
            {
                char[] pidCharArray = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

                // 原身分證英文字應轉換為10~33，這裡直接作(個位數*9+10) mod 10
                int[] pidIDInt = { 1, 0, 9, 8, 7, 6, 5, 4, 9, 3, 2, 2, 1, 0, 8, 9, 8, 7, 6, 5, 4, 3, 1, 3, 2, 0 };

                str = str.ToUpper();// 轉換大寫
                char[] strArr = str.ToCharArray();// 字串轉成char陣列

                int verifyNum = 0;

                string pat = "[A-Z]{1}[1-2]{1}[0-9]{8}";
                Regex r = new Regex(pat, RegexOptions.IgnoreCase);
                Match m = r.Match(str);
                /* 檢查身分證字號 */
                if (m.Success)
                {
                    // 第一碼
                    verifyNum = verifyNum + pidIDInt[Array.BinarySearch(pidCharArray, strArr[0])];
                    // 第二~九碼
                    for (int i = 1, j = 8; i < 9; i++, j--)
                    {
                        verifyNum += (int)Char.GetNumericValue(strArr[i]) * j;
                    }
                    // 檢查碼
                    verifyNum = (10 - (verifyNum % 10)) % 10;

                    return verifyNum == (int)Char.GetNumericValue(strArr[9]);
                    //}
                }
                return false;
            }
            else
            {
                return CheckIDCard(str);
            }
        }
        private static bool CheckIDCard(string Id)
        {
            if (Id.Length == 18)
            {
                bool check = CheckIDCard18(Id);
                return check;
            }
            else if (Id.Length == 15)
            {
                bool check = CheckIDCard15(Id);
                return check;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckIDCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }

        private static bool CheckIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
        }

        public static bool CheckRPNumber(String str)
        {
            if (str == null || str == "")
            {
                return false;
            }

            char[] pidCharArray = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            // 原居留證第一碼英文字應轉換為10~33，十位數*1，個位數*9，這裡直接作[(十位數*1) mod 10] + [(個位數*9) mod 10]
            int[] pidResidentFirstInt = { 1, 0, 9, 8, 7, 6, 5, 4, 9, 3, 2, 2, 1, 0, 8, 9, 8, 7, 6, 5, 4, 3, 1, 3, 2, 0 };

            // 原居留證第二碼英文字應轉換為10~33，並僅取個位數*6，這裡直接取[(個位數*6) mod 10]
            int[] pidResidentSecondInt = { 0, 8, 6, 4, 2, 0, 8, 6, 2, 4, 2, 0, 8, 6, 0, 4, 2, 0, 8, 6, 4, 2, 6, 0, 8, 4 };

            str = str.ToUpper();// 轉換大寫
            char[] strArr = str.ToCharArray();// 字串轉成char陣列

            /* 檢查統一證(居留證)編號 */
            int verifyNum = 0;
            string pat = "[A-Z]{1}[A-D]{1}[0-9]{8}";
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(str);

            if (m.Success)
            {
                // 第一碼
                verifyNum += pidResidentFirstInt[Array.BinarySearch(pidCharArray, strArr[0])];
                // 第二碼
                verifyNum += pidResidentSecondInt[Array.BinarySearch(pidCharArray, strArr[1])];
                // 第三~八碼
                for (int i = 2, j = 7; i < 9; i++, j--)
                {
                    verifyNum += (int)Char.GetNumericValue(strArr[i]) * j;
                }
                // 檢查碼
                verifyNum = (10 - (verifyNum % 10)) % 10;

                return verifyNum == (int)Char.GetNumericValue(strArr[9]);
            }
            return false;
        }
        public static bool CheckTimeFormat(string Time)
        {
            if (Time.Length != 4)
                return false;
            int i = 0;
            if (!Int32.TryParse(Time, out i))
                return false;
            int HH, mm;
            HH = Convert.ToInt32(Time.Substring(0, 2));
            mm = Convert.ToInt32(Time.Substring(2, 2));
            if (HH > 48) return false;
            if (mm >= 60) return false;
            if (Time.Substring(2, 2) != "30" && Time.Substring(2, 2) != "00") return false;
            if (i > 4800) return false;
            return true;
        }
        public static bool CheckTimeFormat(string Time, bool CheckMina)
        {
            if (Time.Length != 4)
                return false;
            int i = 0;
            if (!Int32.TryParse(Time, out i))
                return false;
            int HH, mm;
            HH = Convert.ToInt32(Time.Substring(0, 2));
            mm = Convert.ToInt32(Time.Substring(2, 2));
            if (HH > 48) return false;
            if (mm >= 60) return false;
            if (CheckMina && Time.Substring(2, 2) != "30" && Time.Substring(2, 2) != "00") return false;
            if (i > 4800) return false;
            return true;
        }
        /// <summary>
        /// 判定結束分鐘數
        /// </summary>
        /// <param name="Time"></param>
        /// <param name="Mins"></param>
        /// <returns></returns>
        public static bool CheckTimeFormat(string Time, string Mins)
        {
            if (Time.Length != 4)
                return false;
            int i = 0;

            if (!Int32.TryParse(Time, out i))
                return false;
            int HH, mm;
            HH = Convert.ToInt32(Time.Substring(0, 2));
            mm = Convert.ToInt32(Time.Substring(2, 2));
            if (HH > 48) return false;
            if (mm >= 60) return false;
            if (Time.Substring(2, 2) != "15" && Time.Substring(2, 2) != "30" && Time.Substring(2, 2) != "45" && Time.Substring(2, 2) != "00") return false;
            if (Mins.Substring(2, 2) != "15" && Mins.Substring(2, 2) != "30" && Mins.Substring(2, 2) != "45" && Mins.Substring(2, 2) != "00") return false;

            if (i > 4800) return false;
            return true;
        }

        public static bool CheckYearMonthFormat(string yymm)
        {
            if (yymm.Length != 6)
                return false;
            int i = 0;
            if (!Int32.TryParse(yymm, out i))
                return false;
            int yy, mm;
            yy = Convert.ToInt32(yymm.Substring(0, 4));
            mm = Convert.ToInt32(yymm.Substring(4, 2));
            if (yy < 1900) return false;
            if (mm > 12 || mm < 1) return false;
            return true;
        }

        public static bool CheckYearFormat(string yymm)
        {
            if (yymm.Length != 4)
                return false;
            int i = 0;
            if (!Int32.TryParse(yymm, out i))
                return false;
            int yy;
            yy = Convert.ToInt32(yymm);
            if (yy < 1900) return false;
            return true;
        }
        #region 大陸身份證號碼驗證
        public static bool CheckIDCard_CHS(string IDCard, out string Msg)
        {
            Msg = "";
            string[] arrVarifyCode = ("1,0,X,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            string[] Checker = ("1,9,8,7,6,5,4,3,2,1,1").Split(',');
            int intLength = IDCard.Length;

            int i = 0, TotalmulAiWi = 0;
            int modValue = 0;
            string strVerifyCode = "";
            string Ai = "";
            string BirthDay = "";
            int intYear = 0;
            int intMonth = 0;
            int intDay = 0;

            if (intLength < 15 || intLength == 16 || intLength == 17 || intLength > 18)
            {
                Msg = "身份证号码长度不正确";
                return false;
            }
            if (intLength == 18)
            {
                Ai = IDCard.Substring(0, 17);
            }
            else if (intLength == 15)
            {
                Ai = IDCard;
                Ai = Ai.Substring(0, 6) + "19" + Ai.Substring(6, 9);
            }
            if (!IsNumeric(Ai)) return false;

            intYear = Convert.ToInt32(Ai.Substring(6, 4));
            intMonth = Convert.ToInt32(Ai.Substring(10, 2));
            intDay = Convert.ToInt32(Ai.Substring(12, 2));

            BirthDay = intYear.ToString() + "-" + intMonth.ToString() + "-" + intDay.ToString();
            if (IsDateTime(BirthDay))
            {
                DateTime DateBirthDay = DateTime.Parse(BirthDay);
                if (DateBirthDay > DateTime.Now)
                {
                    Msg = "出生日期不正确";
                    return false;
                }

                int intYearLength = DateBirthDay.Year - DateBirthDay.Year;
                if (intYearLength < -140)
                {
                    Msg = "出生年度不正確";
                    return false;
                }
            }

            if (intMonth > 12 || intDay > 31)
            {
                Msg = "出生月日格式不正確";
                return false;
            }

            for (i = 0; i < 17; i++)
            {
                TotalmulAiWi = TotalmulAiWi + (Convert.ToInt32(Ai.Substring(i, 1)) * Convert.ToInt32(Wi[i].ToString()));
            }
            modValue = TotalmulAiWi % 11;

            strVerifyCode = arrVarifyCode[modValue].ToString();
            Ai = Ai + strVerifyCode;
            if (intLength == 18 && IDCard != Ai)
            {
                Msg = "验证码不正确";
                return false;
            }
            return true;
        }
        #endregion
        /// <summary>
        /// 判斷字符串是否可轉換為DateTime
        /// </summary>
        /// <param name="s">要判斷的字符串</param>
        /// <returns>true=可以轉換;false=無法轉換</returns>
        private static bool IsDateTime(string s)
        {
            try
            {
                System.DateTime.Parse(s);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 判斷字符串是否可以轉換為數字
        /// </summary>
        /// <param name="value">要判斷的字符串</param>
        /// <returns>true=可以轉換;false=無法轉換</returns>
        private static bool IsNumeric(object value)
        {
            try
            {
                double i = Convert.ToDouble(value.ToString());
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

    }
}
