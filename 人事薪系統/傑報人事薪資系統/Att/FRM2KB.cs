using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.SqlClient;
using System.Data.OleDb;
namespace JBHR.Att
{
    public partial class FRM2KB : JBControls.JBForm
    {
        public FRM2KB()
        {
            InitializeComponent();
        }

        public int code = 0;
        U_SYS7A row;
        DataTable data;
        dcAttDataContext db1 = new dcAttDataContext();
        DateTime SelectTime;
        List<CARD> cardList;
        private void btnTran_Click(object sender, EventArgs e)
        {
            cardList = new List<CARD>();
            dcAttDataContext db = new dcAttDataContext();
            dcBasDataContext dbBase = new dcBasDataContext();

            dsAtt.CARDDataTable dt = new dsAtt.CARDDataTable();
            dsAttTableAdapters.CARDTableAdapter ad = new JBHR.Att.dsAttTableAdapters.CARDTableAdapter();
            var cardappList = (from a in db.CARDAPP select new { a.NOBR, a.BDATE, a.CARDNO }).ToList();
            //var baseList = from r in dbBase.BASE select r.NOBR.Trim();
            var dataList = data.AsEnumerable();
            //var dataIncludeBase = from d in dataList join b in baseList on d[0].ToString().Trim() equals b.Trim() select d;

            dsAtt.CARD.Clear();

            foreach (DataRow itm in dataList)
            {
                string nobr, adate, ontime, cardno, source, ipaddr, temperature;
                nobr = itm[0].ToString();
                adate = itm[1].ToString();
                ontime = itm[2].ToString();
                cardno = itm[3].ToString();
                source = itm[4].ToString();
                ipaddr = itm[5].ToString();
                temperature = itm[6].ToString();
                //if (!baseList.Contains(nobr.Trim())) continue;//如果沒有base資料就略過

                //CARD card = new CARD();
                dsAtt.CARDRow card = dt.NewCARDRow();
                card.ADATE = Convert.ToDateTime(adate).Date;
                card.CARDNO = cardno;
                string time = ontime;
                if (ontime.Length == 8)//HH:mm:ss
                {
                    string sTime = DateTime.Today.ToString("yyyy/MM/dd") + " " + ontime;
                    DateTime dTime = Convert.ToDateTime(sTime);
                    time = dTime.ToString("HHmm");
                }
                if (itm[2].GetType() == typeof(DateTime)) time = Convert.ToDateTime(ontime).ToString("HHmm");
                card.CODE = source;
                card.DAYS = 0;
                card.IPADD = ipaddr;
                card.KEY_DATE = DateTime.Now;
                card.KEY_MAN = MainForm.USER_NAME;
                card.LOS = false;
                card.MENO = "";
                card.NOBR = nobr;
                card.DEPT = "";
                card.D_NO_DISP = "";
                card.D_NAME = "";
                card.NAME_C = "";                
                var chkNobr = from a in cardappList where a.CARDNO == nobr && a.BDATE <= card.ADATE orderby a.BDATE descending select a;
                if (chkNobr.Any())
                    card.NOBR = chkNobr.First().NOBR;
                card.NOT_TRAN = false;
                card.ONTIME = time;
                card.REASON = "";
                card.SERNO = "";
                card.temperature = temperature;
                //db.CARD.InsertOnSubmit(card);
                try
                {
                    //db.SubmitChanges();
                    dt.AddCARDRow(card);
                    ad.Update(card);
                }
                catch
                {
                    dsAtt.CARDRow cardRow = dsAtt.CARD.NewCARDRow();
                    cardRow.ADATE = Convert.ToDateTime(adate).Date;
                    cardRow.CARDNO = cardno;
                    cardRow.CODE = card.CODE;
                    cardRow.DAYS = card.DAYS;
                    cardRow.IPADD = card.IPADD;
                    cardRow.KEY_DATE = DateTime.Now;
                    cardRow.KEY_MAN = MainForm.USER_NAME;
                    cardRow.LOS = card.LOS;
                    cardRow.MENO = card.MENO;
                    cardRow.NOBR = card.NOBR;
                    cardRow.NOT_TRAN = card.NOT_TRAN;
                    cardRow.ONTIME = card.ONTIME;
                    cardRow.REASON = card.REASON;
                    cardRow.SERNO = card.SERNO;
                    cardRow.temperature = card.temperature;
                    try
                    {
                        dsAtt.CARD.AddCARDRow(cardRow);
                    }
                    catch//如果再發生錯誤，就略過不入衝突
                    {
                        continue;
                    }
                }
            }
            if (dsAtt.CARD.Rows.Count > 0)
            {
                tabControl1.SelectTab(1);
                string msg = string.Format(Resources.Att.FRM2KB_IMPORT_REPEAT, dsAtt.CARD.Rows.Count);
                MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            row.LATEST_CHECK = SelectTime;//因為是離線資料處理，所以應該以讀取資料當時的時間為準
            dateTimePicker1.Value = SelectTime.Date;//抓不到時間來檢核，所以只檢察日期
            db1.SubmitChanges();

            GetData();
            MessageBox.Show("匯入完成.");
        }

        private void FRM2KB_Load(object sender, EventArgs e)
        {
            var sql = from r in db1.U_SYS7A where r.AUTO == code select r;
            if (sql.Any())
            {
                row = sql.First();
                dateTimePicker1.Value = row.LATEST_CHECK;
                GetData();
            }
            else this.Close();
        }

        void GetData()
        {
            //string connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", row.DATA_SOURCE);

            //OleDbConnection conn = new OleDbConnection(connectionString);
            string connectionString = 
                string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", 
                row.DATA_SOURCE, row.INITAIL_CATALOG, row.USER_ID, row.PASSWORD);

            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
                //JBModule.Data.CSQL cData = new JBModule.Data.CSQL(conn);
                string nobr, adate, ontime, cardno, checktime, source, ipaddr, temperature;
                nobr = row.COL_NOBR == null ? "''" : row.COL_NOBR;
                adate = row.COL_ADATE == null ? "''" : row.COL_ADATE;
                ontime = row.COL_ONTIME == null ? "''" : row.COL_ONTIME;
                cardno = row.COL_CARDNO == null ? "''" : row.COL_CARDNO;
                source = row.COL_SOURCE == null ? "''" : row.COL_SOURCE;
                ipaddr = row.COL_IPADD == null ? "''" : row.COL_IPADD;
                temperature = row.COL_Temperature == null ? "''" : row.COL_Temperature;
                checktime = row.COL_CHECKTIME.Trim().Length == 0 ? adate : row.COL_CHECKTIME;//沒有選擇欄位的話就以adate為準
                object[] parms = new object[] { nobr, adate, ontime, cardno, checktime, row.DATATABLE, dateTimePicker1.Value, dateTimePicker2.Value, source.Trim().Length > 0 ? source : @"''", ipaddr.Trim().Length > 0 ? ipaddr : @"''", ontime, temperature };
                string cmd = string.Format(row.SQL, parms);
                SelectTime = DateTime.Now;
                var dbcmd = conn.CreateCommand();
                dbcmd.CommandText = cmd;
                var dr = dbcmd.ExecuteReader();
                data = new DataTable();
                data.Load(dr);
                dataGridView1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.All.DBConnectErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                JBModule.Message.TextLog.WriteLog(ex);
                this.Close();
            }
            finally
            {
                conn.Close();
            }

        }
        void DeleteRepeat()
        {
            foreach (var itm in dsAtt.CARD)
            {
                DeleteCard(itm.NOBR, itm.ADATE, itm.ONTIME);
            }
        }
        void DeleteCard(string nobr, DateTime adate, string ontime)
        {
            object[] PARMS = new object[] { nobr, adate, ontime };
            db1.ExecuteCommand("DELETE CARD WHERE NOBR={0} AND ADATE={1} AND ONTIME={2}", PARMS);
        }
        void InsertRepeat()
        {
            dcAttDataContext db = new dcAttDataContext();
            var tblCard = dsAtt.CARD.Copy() as dsAtt.CARDDataTable;
            foreach (var itm in tblCard)
            {
                CARD card = new CARD();
                card.NOBR = itm.NOBR;
                card.ADATE = itm.ADATE;
                card.ONTIME = itm.ONTIME;
                card.CARDNO = itm.CARDNO;
                card.CODE = itm.CODE;
                card.DAYS = itm.DAYS;
                card.IPADD = itm.IPADD;
                card.KEY_DATE = DateTime.Now;
                card.KEY_MAN = MainForm.USER_NAME;
                card.LOS = itm.LOS;
                card.MENO = itm.MENO;
                card.NOT_TRAN = itm.NOT_TRAN;
                card.REASON = itm.REASON;
                card.SERNO = itm.SERNO;
                card.Temperature = itm.temperature;
                db.CARD.InsertOnSubmit(card);
                try
                {
                    db.SubmitChanges();
                    dsAtt.CARD.FindByNOBRADATEONTIME(itm.NOBR, itm.ADATE, itm.ONTIME).Delete();
                    dsAtt.CARD.AcceptChanges();
                }
                catch (Exception ex)
                {
                    JBModule.Message.TextLog.WriteLog(string.Format("{0} ; {1} ; {2}", card.NOBR, card.ADATE, card.ONTIME));
                    JBModule.Message.TextLog.WriteLog(ex);
                    //略過
                }

            }


        }
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DeleteRepeat();

            Button btn = (Button)sender;
            MessageBox.Show(btn.Text + Resources.Att.WorkFinish, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnOverWrite_Click(object sender, EventArgs e)
        {
            DeleteRepeat();
            InsertRepeat();

            Button btn = (Button)sender;
            MessageBox.Show(btn.Text + Resources.Att.WorkFinish, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            DataView dv = ((dataGridView2.DataSource as BindingSource).DataSource as DataSet).Tables["card"].DefaultView as DataView;
            //dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;
            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertRepeat();

            Button btn = (Button)sender;
            MessageBox.Show(btn.Text + Resources.Att.WorkFinish, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
