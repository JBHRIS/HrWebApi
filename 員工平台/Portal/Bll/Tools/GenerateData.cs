using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Tools
{
    public class GenerateData
    {
        /// <summary>
        /// 姓名亂數產生
        /// </summary>
        /// <param name="count">要產生字的個數</param>
        /// <returns>string</returns>
        public static string GenerateChineseName(int count)
        {
            string chineseWords = "";
            Random rm = new Random(Guid.NewGuid().GetHashCode());
            Encoding gb = Encoding.GetEncoding("gb2312");
            for (int i = 0; i < count; i++)
            {
                // 獲取區碼(常用漢字的區碼範圍為16-55)
                int regionCode = rm.Next(16, 56);
                // 獲取位碼(位碼範圍為1-94 由於55區的90,91,92,93,94為空,故將其排除)
                int positionCode;
                if (regionCode == 55)
                {
                    // 55區排除90,91,92,93,94
                    positionCode = rm.Next(1, 90);
                }
                else
                {
                    positionCode = rm.Next(1, 95);
                }
                // 轉換區位碼為機內碼
                int regionCode_Machine = regionCode + 160;// 160即為十六進位的20H+80H=A0H
                int positionCode_Machine = positionCode + 160;// 160即為十六進位的20H+80H=A0H
                                                              // 轉換為漢字
                byte[] bytes = new byte[] { (byte)regionCode_Machine, (byte)positionCode_Machine };
                chineseWords += gb.GetString(bytes);
            }
            return chineseWords;
        }

        /// <summary>
        /// 日期亂數產生
        /// </summary>
        /// <param name="Day">加減天數</param>
        /// <returns>DateTime</returns>
        public static DateTime GenerateDate(int Day = 30)
        {
            var randomNumber = new Random(Guid.NewGuid().GetHashCode());
            var DateNow = DateTime.Now.Date;
            var startDateTime = DateNow.AddDays(-Day);
            var endDateTime = DateNow.AddDays(Day);

            TimeSpan diff = endDateTime - startDateTime;
            Double totalSeconds = diff.TotalSeconds;
            Double randomSeconds = randomNumber.NextDouble() * totalSeconds;
            DateTime randomDateTime = startDateTime.AddSeconds(randomSeconds);
            return randomDateTime;
        }

        /// <summary>
        /// 身份證產生器
        /// </summary>
        /// <param name="sex">男女</param>
        /// <param name="city">城市</param>
        /// <returns></returns>
        public static string GenerateCreateVid(bool sex = true, int city = 0)
        {    //身分證開頭英文
            /*              
             (1)英文代號以下表轉換成數字 
       　　　A=10 台北市 city索引值(0)　　J=18 新竹縣　city索引值(9)　　 S=26 高雄縣 city索引值
       　　　B=11 台中市 city索引值(1)　　K=19 苗栗縣　city索引值(10)　　T=27 屏東縣 city索引值(16) 
       　　　C=12 基隆市 city索引值(2)　　L=20 台中縣　city索引值     　 U=28 花蓮縣 city索引值(17) 
       　　　D=13 台南市 city索引值(3)　　M=21 南投縣　city索引值(11)　　V=29 台東縣 city索引值(18) 
       　　　E=14 高雄市 city索引值(4)　　N=22 彰化縣　city索引值(12)　  W=32 金門縣 city索引值(19) 
       　　　F=15 台北縣 city索引值(5)　　O=35 新竹市　city索引值(13)　　X=30 澎湖縣 city索引值(20) 
       　　　G=16 宜蘭縣 city索引值(6)　　P=23 雲林縣　city索引值(14)　　Y=31 陽明山 city索引值 
       　　　H=17 桃園縣 city索引值(7)　　Q=24 嘉義縣　city索引值(15)　  Z=33 連江縣 city索引值(21)
       　　  I=34 嘉義市 city索引值(8)　　R=25 台南縣　city索引值
         */

            string[] county_E = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K",
                      "M", "N", "O", "P", "Q", "T", "U", "V", "W", "X", "Z" };
            //對應數字 (索引值)
            int[] county_i = { 10, 11, 12, 13, 14, 15, 16, 17, 34, 18, 19, 21, 22, 35,
                       23, 24, 27, 28, 29, 32, 30, 33 };
            Random r = new Random(Guid.NewGuid().GetHashCode());
            string id = county_E[city];
            int c_i = county_i[city];
            string s = "2";
            if (sex) s = "1";
            int rand_i = r.Next(0, 10000000);
            //計算
            int check = (c_i / 10) + 9 * (c_i - (c_i / 10) * 10) + Convert.ToInt32(s) * 8;
            for (int i = 7; i >= 1; i--)
            {
                check += ((rand_i / (int)Math.Pow(10, i - 1)) % 10) % 10 * i;
            }
            check = (10 - (check % 10)) % 10;
            //計算審核碼
            id += s + rand_i.ToString().PadLeft(7, '0') + check.ToString();
            return id;
        }
    }
}