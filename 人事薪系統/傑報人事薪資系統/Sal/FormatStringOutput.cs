using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JBHR.SalaryTransferDataSetTableAdapters;
using JBTools.IO;
using System.Windows.Forms;

namespace JBHR.Sal
{
    public class FormatStringOutput
    {
        string str = "";

        public FormatStringOutput()
        {

        }

        public void AddData(string BankCode, string Classify, List<Dictionary<string, string>> DataDic)
        {
            List<SalaryTransSettings> SettingList = new List<SalaryTransSettings>();
            SalaryTransferTableAdapter salaryTransferTableAdapter = new SalaryTransferTableAdapter();

            var salaryData = salaryTransferTableAdapter.GetData(BankCode, Classify);

            foreach (var item in salaryData)
            {
                SalaryTransSettings Setting = new SalaryTransSettings();
                Setting.Code = item.CODE;
                Setting.Name = item.NAME;
                Setting.Location = item.LOCATION;
                Setting.Length = item.LENGTH;
                Setting.Type = item.TYPE;
                Setting.Side = item.SIDE;
                Setting.Filled = item.FILLED;
                Setting.YearType = item.YEARTYPE;
                Setting.DateFormat = item.DATEFORMAT;
                Setting.FixedContent = item.FIXEDCONTENT;

                SettingList.Add(Setting);
            }

            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            
            FormatString formatstring = new FormatString();
            formatstring.Settings = SettingList;
            formatstring.ContentPair = DataDic;

            str += formatstring.GetRecord(Encoding.GetEncoding(db.BankCode.Where(p=>p.CODE_DISP == BankCode).FirstOrDefault().CodePage));
            //str += formatstring.GetRecord();
        }

        public void ResetData()
        {
            str = "";
        }

        public string GetData()
        {
            return str;
        }

        public void ExportTxt(string path, string fileName)
        {
            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(path + @"\" + fileName);
                sw.Write(str);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {

            }

        }
    }
}