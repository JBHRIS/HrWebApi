using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Ins
{
    public partial class FRM32B : JBControls.JBForm
    {
        public string Nobr = "";
        public DateTime outdt;
        public FRM32B()
        {
            InitializeComponent();

            InsDataClassesDataContext db = new InsDataClassesDataContext();
            //var EmpData = from emp in db.BASE
            //              where
            //              emp.BASETTS.Any(tts => new string[] { "2", "3", "5" }.Contains(tts.TTSCODE.Trim()) && DateTime.Now.Date >= tts.ADATE && DateTime.Now.Date <= tts.DDATE) &&
            //              !emp.INSLAB.Any(inslab => new string[] { "3" }.Contains(inslab.CODE.Trim()) && DateTime.Now.Date >= inslab.IN_DATE && DateTime.Now.Date <= inslab.OUT_DATE)
            //              select new
            //              {
            //                  NOBR = emp.NOBR.Trim(),
            //                  NAME_C = emp.NAME_C.Trim()
            //              };

            //var EmpData = from emp in db.BASE
            //              where
            //              db.GetFilterByNobr(emp.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value &&
            //               emp.BASETTS.Any(tts => tts.ADATE == emp.BASETTS.Max(row => row.ADATE) && new string[] { "2", "5" }.Contains(tts.TTSCODE.Trim())) &&
            //              emp.INSLAB.Any() &&
            //              !emp.INSLAB.Any(inslab => inslab.IN_DATE == emp.INSLAB.Where(p => p.FA_IDNO.Trim().Length == 0).Max(row => row.IN_DATE) && new string[] { "3" }.Contains(inslab.CODE.Trim()))
            //              select new
            //              {
            //                  NOBR = emp.NOBR.Trim(),
            //                  NAME_C = emp.NAME_C.Trim(),
            //                  OUDT = emp.BASETTS.First(r1 => r1.ADATE == emp.BASETTS.Max(r2 => r2.ADATE)).OUDT.Value.AddDays(1)
            //              };

            var inslabOut = (from a in db.INSLAB
                             where DateTime.Today > a.IN_DATE && DateTime.Today < a.OUT_DATE //不要顯示今天的資料，雖然隔天才會生效，但是已經做退保
                             //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                            && (from bts in db.BASETTS
                                where bts.NOBR == a.NOBR
                                && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                && (from urdg in db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                select 1).Any()
                             select a).ToList();
            var insEmpList = inslabOut.Select(p => p.NOBR).Distinct().ToList();
            var OutEmpWithIns = from a in db.BASETTS
                                join b in db.BASE on a.NOBR equals b.NOBR
                                where DateTime.Today >= a.ADATE && DateTime.Today <= a.DDATE.Value
                                && new string[] { "2", "3", "5" }.Contains(a.TTSCODE)
                                && insEmpList.Contains(a.NOBR)
                                select new { 員工編號 = a.NOBR, 員工姓名 = b.NAME_C, 離職日 = a.OUDT, 留停日 = a.STDT };

            dataGridView1.DataSource = OutEmpWithIns.CopyToDataTable();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string nobr = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Nobr = nobr;
            if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() != "")
                outdt = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            else
                outdt = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            this.Close();
        }
    }
}
