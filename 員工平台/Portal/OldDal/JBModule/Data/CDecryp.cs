using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace JBModule.Data
{
	public class CDecryp
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
                return 0;
            }
            else
            {
                if (VAL == 0) return 0;

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
                    string AA = VALSTR.Trim().Substring((VALSTR.Trim().Length - 2 >= 0) ? VALSTR.Trim().Length - 2 : 0, 2);
                    STARTPOS = int.Parse(AA.Substring((AA.Length - 1 >= 0) ? AA.Length - 1 : 0, 1));
                    VALLEN = int.Parse(AA.Substring(0, 1));
                    VALSTR = VALSTR.Substring(0, VALSTR.Length - 2).PadLeft(VALLEN, '0');
                    for (int I = 1; I <= VALLEN; I++)
                    {
                        int ZZ = int.Parse(VALSTR.Substring((I - 1 >= 0) ? I - 1 : 0, 1));
                        int index = STARTPOS + I - 1 - 1;
                        int YY = 0;
                        if (index >= 0) YY = int.Parse(STR1.Substring(index, 1));
                        int WW = ZZ - YY;
                        WW = (WW < 0) ? 10 + WW : WW;
                        int iTmp = Math.Abs(WW) % 10;
                        LL += iTmp.ToString();
                    }
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

			//Put  the  input  string  into  the  byte  array  
			byte[] inputByteArray = new byte[VALT.Length / 2];
			for (int x = 0; x < VALT.Length / 2; x++)
			{
				int i = (Convert.ToInt32(VALT.Substring(x * 2, 2), 16));
				inputByteArray[x] = (byte)i;
			}

			//建立加密对象的密钥和偏移量，此值重要，不能修改
			des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
			des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
			MemoryStream ms = new MemoryStream();
			CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
			//Flush  the  data  through  the  crypto  stream  into  the  memory  stream  
			cs.Write(inputByteArray, 0, inputByteArray.Length);
			cs.FlushFinalBlock();

			//Get  the  decrypted  data  back  from  the  memory  stream  
			//建立StringBuild对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象  
			StringBuilder ret = new StringBuilder();

			return System.Text.Encoding.Default.GetString(ms.ToArray());
		}
        public static string ConnectString(string Value)
        {
            System.Data.SqlClient.SqlConnectionStringBuilder sb = new System.Data.SqlClient.SqlConnectionStringBuilder(Value);
            sb.Password = Text(sb.Password);
            sb.DataSource = Text(sb.DataSource);
            sb.UserID = Text(sb.UserID);
            sb.InitialCatalog = Text(sb.InitialCatalog);
            return sb.ConnectionString;
        }
	}
}
