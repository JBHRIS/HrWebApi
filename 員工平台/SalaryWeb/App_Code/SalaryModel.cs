using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using SalaryWeb;

/// <summary>
/// Summary description for SalaryModel
/// </summary>
public class SalaryModel
{
    HrContextDataContext dcHrContext = new HrContextDataContext();
    
    public SalaryModel()
    {
             
    }

    public void SetNewPassword(string empId, string plainTextPassword)
    {
        string cipherTextPassword = Encode(plainTextPassword);
        //string cipherTextPassword = JBHR.Dll.Tools.EncodeTool.Encode(plainTextPassword);

        SalaryPassWord salaryPassWord = new SalaryPassWord()
        {
            sNobr = empId,
            sPassWord = cipherTextPassword,
            dKeyDate = DateTime.Now
        };

        dcHrContext.SalaryPassWord.InsertOnSubmit(salaryPassWord);
        dcHrContext.SubmitChanges();
    }

    public bool ComparePassword(string empId, string plainTextPassword)
    {
        string cipherTextPassword = Encode(plainTextPassword);

        Expression<Func<SalaryPassWord, bool>> expression =
            word => word.sNobr == empId && word.sPassWord == cipherTextPassword;

        var result = dcHrContext.SalaryPassWord.FirstOrDefault(expression);

        return result != null;
    }

    public bool GetTicket(string empid, string plaintextPassword , out string ticket)
    {
        bool isValid = ComparePassword(empid, plaintextPassword);
        ticket = string.Empty;

        if (isValid)
        {
            ticket = DateTimeOffset.UtcNow.ToString();
            return true;
        }
        return false;
    }

    public bool IsExistPassword(string empId)
    {
        Expression<Func<SalaryPassWord, bool>> expression = word => word.sNobr == empId;
        return dcHrContext.SalaryPassWord.Any(expression);
    }

    public void RemovePassword(string empid)
    {
        Expression<Func<SalaryPassWord, bool>> expression = word => word.sNobr == empid;

        SalaryPassWord data = dcHrContext.SalaryPassWord.FirstOrDefault(expression);

        if (data != null)
        {
            dcHrContext.SalaryPassWord.DeleteOnSubmit(data);
            dcHrContext.SubmitChanges();
        }
    }

    public static string Encode(String sData)
    {
        try { return Convert.ToBase64String(System.Text.UTF8Encoding.UTF8.GetBytes(sData)); }
        catch { return ""; }
    }

    /// <summary>
    /// 解碼
    /// </summary>
    /// <param name="sData">要解碼字串</param>
    /// <returns>string</returns>
    public static string Decode(String sData)
    {
        try { return UTF8Encoding.UTF8.GetString(System.Convert.FromBase64String(sData)); }
        catch { return ""; }
    }
}