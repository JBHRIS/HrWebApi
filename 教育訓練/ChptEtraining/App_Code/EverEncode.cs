using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// EverEncode 的摘要描述
/// </summary>
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
public class EverEncode
{
    public static string TurnEncode(string FormCode)
    {
        string EncodeView = null;
        int i = 0;
        int jj = 0;

        jj = FormCode.Trim().Length;
        
        for (i = 0; i < jj; i += 1)
        {
            //EncodeView = EncodeView + StringEnDeCodecn(Strings.Mid(Strings.Trim(FormCode), i, 1));
            EncodeView = EncodeView + StringEnDeCodecn(FormCode.Trim().Substring(i,1));
        }
        return EncodeView;
    }
    public static string TurnUncode(string FormCode)
    {
        int i = 0;
        int kk = 0;
        string UnCodeView = null;
        kk = FormCode.Length;        
        for (i = 0; i < kk; i += 1)
        {
            //UnCodeView = UnCodeView + StringEnDeCodecn(Strings.Mid(Strings.Trim(FormCode), i, 1));
            UnCodeView = UnCodeView + StringEnDeCodecn(FormCode.Trim().Substring(i, 1));
        }
        return UnCodeView;

    }


    private static string StringEnDeCodecn(string strSource)
    {
        float X = 0;
        int CHARNUM = 0;
        //int RANDOMINTEGER = 0;
        string SINGLECHAR = null;
        string strTmp = null;
        int i = 0;
        int k = 0;

        for (i = 0; i < strSource.Length; i += 1)
        {
            //SINGLECHAR = Strings.Mid(strSource, i, 1);
            SINGLECHAR = strSource.Substring(i,1);
            CHARNUM = SiteHelper.Asc(Convert.ToChar(SINGLECHAR));
            
            CHARNUM = CHARNUM ^ 5;
            strTmp = strTmp + SiteHelper.Chr(CHARNUM);
        }

        if (strTmp == "?")
        {
            strTmp = "";
            for (k = 0; k < strSource.Length; k += 1)
            {
                SINGLECHAR = strSource.Substring( k, 1);
                CHARNUM = SiteHelper.Asc(Convert.ToChar(SINGLECHAR));                
                strTmp = strTmp + SiteHelper.Chr(CHARNUM);
            }
        }

        return strTmp;
    }
}
