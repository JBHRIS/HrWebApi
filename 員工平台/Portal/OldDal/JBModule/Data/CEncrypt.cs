using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace JBModule.Data
{
    public class CEncrypt
    {
        public static string USER_ID = "";
        public static bool HAS_DECRYP_KEY = false;
        static DateTime rDateTime = Convert.ToDateTime("1900/01/01");
        static string sKey = "84211021";

        public static decimal Number(decimal VAL)
        {
            DateTime aDateTime = DateTime.Now;

            if (rDateTime == Convert.ToDateTime("1900/01/01") || (aDateTime - rDateTime).TotalMinutes > 10 || !HAS_DECRYP_KEY)
            {
                HAS_DECRYP_KEY = false;
                List<string> SalaryKeys = new List<string>();
                string[] drives = Directory.GetLogicalDrives();
                foreach (string drive in drives)
                {
                    if (File.Exists(drive + "JBHR.SALARY.KEY"))
                    {
                        StreamReader sr = File.OpenText(drive + "JBHR.SALARY.KEY");
                        while (!sr.EndOfStream)
                        {
                            string rKey = sr.ReadLine();
                            if (rKey != "B8079BAFB01DED191BC90863B34744A15E4D557948C21D22") rKey = JBModule.Data.CDecryp.Text(rKey);

                            if (SalaryKeys.Contains(rKey)) continue;
                            else SalaryKeys.Add(rKey);
                        }
                        sr.Close();
                    }
                }

                foreach (string key in SalaryKeys)
                {
                    if (USER_ID.Trim().ToUpper() == "JBADMIN" && key == "B8079BAFB01DED191BC90863B34744A15E4D557948C21D22")
                    {
                        HAS_DECRYP_KEY = true;
                        break;
                    }
                    else
                    {
                        string[] pp = key.Split(new string[] { "[=]" }, StringSplitOptions.RemoveEmptyEntries);
                        if (pp.Length == 2 && pp[1].Trim().ToUpper() == USER_ID.Trim().ToUpper())
                        {
                            HAS_DECRYP_KEY = true;
                            break;
                        }
                    }
                }

                rDateTime = DateTime.Now;
            }

            if (!HAS_DECRYP_KEY)
            {
                Application.OnThreadException(new Exception(Properties.Resources.DecrypLocked1 + "\n" + Properties.Resources.DecrypLocked2 + "\n\n" + Properties.Resources.SystemClose));
                return 10;
            }
            else
            {
                try
                {
                    string[] vals = VAL.ToString().Split(new char[] { '.' });

                    decimal VALT = Convert.ToDecimal(vals[0]);
                    decimal VALD = Convert.ToDecimal((vals.Length == 2) ? "0." + vals[1] : "0");

                    string LCFLAG = (VAL < 0) ? "-" : "+";
                    VALT = Math.Abs(VALT);
                    string VALSTR = VALT.ToString().Trim();
                    string STR1 = "3761532470658472653034873";
                    string LL = "";
                    int VALLEN = 0;
                    int STARTPOS = 0;
                    VALLEN = VALSTR.Length;
                    STARTPOS = 0;
                    for (int I = 1; I <= VALLEN; I++)
                    {
                        STARTPOS = STARTPOS + int.Parse(VALSTR.Substring((I - 1 >= 0) ? I - 1 : 0, 1));
                        STARTPOS = STARTPOS % 10;
                    }
                    for (int I = 1; I <= VALLEN; I++)
                    {
                        int YY = 0;
                        int index = STARTPOS + I - 1 - 1;
                        if (index >= 0) YY = int.Parse(STR1.Substring(index, 1));
                        int WW = int.Parse(VALSTR.Substring((I - 1 >= 0) ? I - 1 : 0, 1)) + YY;
                        int iTmp = Math.Abs(WW) % 10;
                        LL += iTmp.ToString();
                    }
                    LL += VALLEN.ToString() + STARTPOS.ToString();
                    if (LL.Length == 0) LL = "0";
                    LL = LCFLAG + LL;

                    decimal ret = decimal.Parse(LL);
                    if (VALD > 0) ret += LCFLAG == "-" ? VALD * -1 : VALD;

                    return ret;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static string Text(string VALT)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            //把字符串放到byte数组中  
            //原来使用的UTF8编码，我改成Unicode编码了，不行  
            byte[] inputByteArray = Encoding.Default.GetBytes(VALT);
            //byte[]  inputByteArray=Encoding.Unicode.GetBytes(VALT);  

            //建立加密对象的密钥和偏移量  
            //原文使用ASCIIEncoding.ASCII方法的GetBytes方法  
            //使得输入密码必须输入英文文本  
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            //Write  the  byte  array  into  the  crypto  stream  
            //(It  will  end  up  in  the  memory  stream)  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            //Get  the  data  back  from  the  memory  stream,  and  into  a  string  
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                //Format  as  hex  
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }
    }
}
