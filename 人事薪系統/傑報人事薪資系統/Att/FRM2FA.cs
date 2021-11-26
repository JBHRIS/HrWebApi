using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using JBHR.Sal;
using JBHR.Sal.Core;
namespace JBHR.Att
{
    public partial class FRM2FA : JBControls.JBForm
    {
        public FRM2FA()
        {
            InitializeComponent();
        }
        JBModule.Data.Linq.U_SYS7 CardParms = null;
        dcAttDataContext db1 = new dcAttDataContext();
        public int CardNO = 999999999;
        private void FRM2F_Load(object sender, EventArgs e)
        {
            this.u_SYS7TableAdapter.Fill(this.mainDS.U_SYS7);
            var data = from r in this.mainDS.U_SYS7 where r.AUTO == CardNO select r;
            if (data.Any()) comboBox1.SelectedValue = CardNO;
            Reset();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "文字檔|*.txt|所有檔案|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = ofd.FileName;
                StreamReader sr = new StreamReader(txtPath.Text, Encoding.GetEncoding("Big5"));
                txtNote.Text = string.Empty;//清空
                int i = 0;
                //while (!sr.EndOfStream)
                //{
                //    txtNote.Text += sr.ReadLine() + Environment.NewLine;
                //    i++;
                //}
                txtNote.Text = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
                i = (from a in txtNote.Lines where a.Trim().Length > 0 select a).Count();
                comboBox1_SelectedIndexChange(null, null);
                txtRowCount.Text = i.ToString();
            }
        }

        private void btnTran_Click(object sender, EventArgs e)
        {


            this.dsAtt.CARD.Clear();//每次執行轉換都會清空重複的資料名單

            DateTime t1, t2;
            t1 = DateTime.Now;

            dcAttDataContext db = new dcAttDataContext();

            int row_count = 0;
            int error = 0;
            int success = 0;
            int repeat = 0;

            List<CARD> errorList = new List<CARD>();
            StreamReader sr = new StreamReader(txtPath.Text, Encoding.GetEncoding("Big5"));
            List<CardRead> cardreadsList = new List<CardRead>();
            while (sr.Peek() > 0)
            {
                row_count++;
                var strings = sr.ReadLine();
                if (string.IsNullOrWhiteSpace(strings))
                    row_count--;
                try
                {
                    CardRead cr = new CardRead(strings, CardParms);
                    cardreadsList.Add(cr);
                }
                catch { }
            }
            sr.Close();
            sr.Dispose();

            CARD cd = null;
            List<CARD> cardList = new List<CARD>();
            foreach (var itm in cardreadsList)
            {
                try
                {
                    cd = new CARD();
                    cd.ADATE = itm.Adate;
                    cd.CARDNO = itm.cardno;
                    cd.CODE = itm.code;
                    cd.DAYS = 0;
                    cd.IPADD = "";
                    cd.KEY_DATE = DateTime.Now;
                    cd.KEY_MAN = MainForm.USER_NAME;
                    cd.LOS = false;
                    cd.MENO = "";
                    cd.NOBR = itm.nobr;
                    cd.NOT_TRAN = false;
                    cd.ONTIME = itm.Atime;
                    cd.REASON = "";
                    cd.SERNO = itm.serno;
                    cd.Temperature = itm.Temperature;

                    var sql = from cc in db.CARD where cc.NOBR == itm.nobr && cc.ADATE == itm.Adate && cc.ONTIME == itm.Atime select cc;
                    if (sql.Any())//資料已存在就略過，並記錄重複次數
                    {
                        repeat++;
                        var rCard = this.dsAtt.CARD.NewCARDRow();
                        Dll.Tools.SetRowDefaultValue(rCard);
                        rCard.ADATE = cd.ADATE;
                        rCard.CARDNO = cd.CARDNO;
                        rCard.CODE = cd.CODE;
                        rCard.DAYS = cd.DAYS;
                        rCard.IPADD = cd.IPADD;
                        rCard.KEY_DATE = DateTime.Now;
                        rCard.KEY_MAN = MainForm.USER_NAME;
                        rCard.LOS = cd.LOS;
                        rCard.MENO = cd.MENO;
                        rCard.NOBR = cd.NOBR;
                        rCard.NOT_TRAN = cd.NOT_TRAN;
                        rCard.ONTIME = cd.ONTIME;
                        rCard.REASON = cd.REASON;
                        rCard.SERNO = cd.SERNO;
                        rCard.DEPT = "";
                        rCard.temperature = cd.Temperature;

                        if (this.dsAtt.CARD.FindByNOBRADATEONTIME(rCard.NOBR, rCard.ADATE, rCard.ONTIME) == null)//如果重複就不寫入
                            dsAtt.CARD.AddCARDRow(rCard);
                        continue;
                    }
                    var cardListQuery = from a in cardList where a.NOBR == cd.NOBR && a.ADATE == cd.ADATE && a.ONTIME == cd.ONTIME select a;
                    if (cardListQuery.Any())
                    {
                        repeat++;
                        var rCard = this.dsAtt.CARD.NewCARDRow();
                        Dll.Tools.SetRowDefaultValue(rCard);
                        rCard.ADATE = cd.ADATE;
                        rCard.CARDNO = cd.CARDNO;
                        rCard.CODE = cd.CODE;
                        rCard.DAYS = cd.DAYS;
                        rCard.IPADD = cd.IPADD;
                        rCard.KEY_DATE = DateTime.Now;
                        rCard.KEY_MAN = MainForm.USER_NAME;
                        rCard.LOS = cd.LOS;
                        rCard.MENO = cd.MENO;
                        rCard.NOBR = cd.NOBR;
                        rCard.NOT_TRAN = cd.NOT_TRAN;
                        rCard.ONTIME = cd.ONTIME;
                        rCard.REASON = cd.REASON;
                        rCard.SERNO = cd.SERNO;
                        rCard.temperature = cd.Temperature;
                        if (this.dsAtt.CARD.FindByNOBRADATEONTIME(rCard.NOBR, rCard.ADATE, rCard.ONTIME) == null)//如果重複就不寫入
                            dsAtt.CARD.AddCARDRow(rCard);
                        continue;
                    }
                    cardList.Add(cd);

                    success++;
                }
                catch
                {
                    try
                    {
                        error++;
                        var rCard = this.dsAtt.CARD.NewCARDRow();
                        Dll.Tools.SetRowDefaultValue(rCard);
                        rCard.ADATE = cd.ADATE;
                        rCard.CARDNO = cd.CARDNO;
                        rCard.CODE = cd.CODE;
                        rCard.DAYS = cd.DAYS;
                        rCard.IPADD = cd.IPADD;
                        rCard.KEY_DATE = DateTime.Now;
                        rCard.KEY_MAN = MainForm.USER_NAME;
                        rCard.LOS = cd.LOS;
                        rCard.MENO = cd.MENO;
                        rCard.NOBR = cd.NOBR;
                        rCard.NOT_TRAN = cd.NOT_TRAN;
                        rCard.ONTIME = cd.ONTIME;
                        rCard.REASON = cd.REASON;
                        rCard.SERNO = cd.SERNO;
                        rCard.temperature = cd.Temperature;
                        if (this.dsAtt.CARD.FindByNOBRADATEONTIME(rCard.NOBR, rCard.ADATE, rCard.ONTIME) == null)//如果重複就不寫入
                            dsAtt.CARD.AddCARDRow(rCard);
                    }
                    catch (Exception)
                    {

                    }
                }
            }


            //更名
            string new_name = "";
            int idx = txtPath.Text.LastIndexOf('.');
            int sub_name = 1;
            if (idx != -1)
            {
                new_name = txtPath.Text.Substring(0, idx) + "." + sub_name.ToString("00");
                while (File.Exists(new_name))
                {
                    sub_name++;
                    new_name = txtPath.Text.Substring(0, idx) + "." + sub_name.ToString("00");
                }
            }
            else new_name = txtPath.Text + ".01";
            if (txtPath.Text != new_name)
            {
                if (File.Exists(new_name))
                    File.Delete(new_name);//如果目標檔案存在，就刪除他
                File.Move(txtPath.Text, new_name);
                File.Delete(txtPath.Text);
            }
            //顯示結果
            txtError.Text = error.ToString();
            txtRowCount.Text = row_count.ToString();
            txtSuccess.Text = success.ToString();
            txtRepeat.Text = repeat.ToString();
            db.CARD.InsertAllOnSubmit(cardList);
            db.SubmitChanges();
            JBModule.Data.Linq.HrDBDataContext HRdb = new JBModule.Data.Linq.HrDBDataContext();
            foreach (var item in cardList)
            {
                decimal temp = 0;
                if (!string.IsNullOrWhiteSpace(item.Temperature) && decimal.TryParse(item.Temperature,out temp))
                {
                    int hours = int.Parse(item.ONTIME.Substring(0, 2));
                    int mins = int.Parse(item.ONTIME.Substring(2, 2));
                    JBModule.Data.Linq.TemperoturyReport temperoturyReport = new JBModule.Data.Linq.TemperoturyReport()
                    {
                        EmployeeId = item.NOBR,
                        AttendDate = item.ADATE.AddHours(hours).AddMinutes(mins),
                        Description = "FRM24FA",
                        Guid = Guid.NewGuid(),
                        KeyMan = MainForm.USER_ID,
                        KeyDate = DateTime.Now,
                        ReportType = string.Empty,
                        Temperotury = temp,
                    };
                    HRdb.TemperoturyReport.InsertOnSubmit(temperoturyReport);
                    HRdb.SubmitChanges();
                }
            }

            if (dsAtt.CARD.Rows.Count > 0)
            {
                string msgErr = string.Format(Resources.Att.FRM2KB_IMPORT_REPEAT, dsAtt.CARD.Rows.Count);
                MessageBox.Show(msgErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                tabControl1.SelectTab(1);
                btnOverWrite.Focus();
            }

            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void comboBox1_SelectedIndexChange(object sender, EventArgs e)
        {
            try
            {
                Reset();
                CardParms = SysVar.GetCardVar(Convert.ToInt32(comboBox1.SelectedValue));
                int i = Convert.ToInt32(comboBox1.SelectedValue);
                string line = txtNote.Lines[0];
                CardRead cr = new CardRead(line, CardParms);
                lblDate.Text = cr.date;
                lblNobr.Text = cr.nobr;
                lblSNO.Text = cr.serno;
                lblTime.Text = cr.Atime;
                lblTemperature.Text = cr.temperature;
                btnTran.Enabled = true;
            }
            catch
            {

            }
        }
        void Reset()
        {
            lblDate.Text = "------";
            lblNobr.Text = "------";
            lblSNO.Text = "------";
            lblTime.Text = "------";
            lblTemperature.Text = "------";
            btnTran.Enabled = false;
            txtRowCount.Text = "0";
            txtRepeat.Text = "0";
            txtNoTran.Text = "0";
            txtSuccess.Text = "0";
            txtError.Text = "0";
            txtAlert.Text = "0";
            txtRowCount.Text = txtNote.Lines.Length.ToString();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            DataView dv = ((dataGridView2.DataSource as BindingSource).DataSource as DataSet).Tables["card"].DefaultView as DataView;
            //dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;
            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.All.DeleteConfirm, Resources.All.DialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
            DeleteRepeat(true);

            Button btn = (Button)sender;
            MessageBox.Show(btn.Text + Resources.Att.WorkFinish, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        void DeleteRepeat(bool DelItem)
        {
            var tblCard = dsAtt.CARD.Copy() as dsAtt.CARDDataTable;
            foreach (var itm in tblCard)
            {
                try
                {
                    DeleteCard(itm.NOBR, itm.ADATE, itm.ONTIME);
                    if (DelItem)
                    {
                        dsAtt.CARD.FindByNOBRADATEONTIME(itm.NOBR, itm.ADATE, itm.ONTIME).Delete();
                        dsAtt.CARD.AcceptChanges();
                    }
                }
                catch { }
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
                catch
                {
                    //略過
                }

            }


        }

        private void btnOverWrite_Click(object sender, EventArgs e)
        {
            DeleteRepeat(false);
            InsertRepeat();

            Button btn = (Button)sender;
            MessageBox.Show(btn.Text + Resources.Att.WorkFinish, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnInsertAll_Click(object sender, EventArgs e)
        {
            InsertRepeat();

            Button btn = (Button)sender;
            MessageBox.Show(btn.Text + Resources.Att.WorkFinish, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}

public struct KeyValuePairEx<TKey, TValue>
{
    private TKey mKey;
    private TValue mValue;

    public KeyValuePairEx(TKey key, TValue value)
    {
        mKey = key;
        mValue = value;
    }

    public TKey Key
    {
        get
        {
            return mKey;
        }
        set
        {
            mKey = value;
        }
    }

    public TValue Value
    {
        get
        {
            return mValue;
        }
        set
        {
            mValue = value;
        }
    }

    public override string ToString()
    {
        return mValue.ToString();
    }
}

public class CardRead
{
    public string cardno, serno, date, time, timeformat, nobr, code, temperature;
    public JBModule.Data.Linq.U_SYS7 _CardParms = null;
    public CardRead(string record, JBModule.Data.Linq.U_SYS7 CardParms)
    {
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        _CardParms = CardParms;
        //if (CardParms==null)
        //    CardParms = SysVar.GetCardVar(CardReader);
        if (CardParms.TEXT_TYPE == "Position")
        {
            if (record.Substring(CardParms.SER_POS.Value).Length >= CardParms.SER_LEN.Value)
            {
                cardno = record.Substring(CardParms.NOBR_POS.Value, CardParms.NOBR_LEN.Value);
            }
            else
            {
                cardno = record.Substring(CardParms.NOBR_POS.Value);
            }
            nobr = cardno;

            if (record.Substring(CardParms.SER_POS.Value).Length >= CardParms.SER_LEN.Value)
            {
                serno = record.Substring(CardParms.SER_POS.Value, CardParms.SER_LEN.Value);
            }
            else
            {
                serno = record.Substring(CardParms.SER_POS.Value);
            }
            date = record.Substring(CardParms.DATE_POS.Value, CardParms.DATE_LEN.Value);
            time = record.Substring(CardParms.TIME_POS.Value, CardParms.TIME_LEN.Value);
            code = record.Substring(CardParms.CODE_POS.Value, CardParms.CODE_LEN.Value);
            if (CardParms.Temperature_LEN.Value != 0)
                temperature = record.Substring(CardParms.Temperature_POS.Value, CardParms.Temperature_LEN.Value);
            timeformat = CardParms.CARDDATEFORMAT;
            if (!CardParms.CARDNOEUQALNOBR.Value)
            {
                var sql = from r in db.CARDAPP where r.CARDNO == cardno && Adate.Date >= r.BDATE && Adate.Date <= r.EDATE orderby r.BDATE descending select r;
                if (sql.Any()) nobr = sql.First().NOBR;
            }
        }
        else
        {
            var signals = CardParms.SPILT_SIGNAL.ToString();
            var ignore_signal = CardParms.IGNORE_SIGNAL;
            string data = record.Replace(ignore_signal, "");
            var dataArray = data.Split(signals.ToCharArray());
            cardno = dataArray[CardParms.NOBR_POS.Value];
            nobr = cardno;
            serno = dataArray[CardParms.SER_POS.Value];
            date = dataArray[CardParms.DATE_POS.Value];
            time = dataArray[CardParms.TIME_POS.Value];
            code = dataArray[CardParms.CODE_POS.Value];
            if (CardParms.Temperature_LEN.Value != 0)
                temperature = dataArray[CardParms.Temperature_POS.Value];
            timeformat = CardParms.CARDDATEFORMAT;
            if (!CardParms.CARDNOEUQALNOBR.Value)
            {
                var sql = from r in db.CARDAPP where r.CARDNO == cardno && Adate.Date >= r.BDATE && Adate.Date <= r.EDATE orderby r.BDATE descending select r;
                if (sql.Any()) nobr = sql.First().NOBR;
            }
        }
    }
    public DateTime Adate
    {
        get
        {
            //if (this.timeformat.Trim() != "International")
            if (_CardParms.DATE_FORMAT.Trim().Length == 0)
            {
                try
                {
                    return new DateTime(Year, Month, Day);
                }
                catch (Exception ex)
                {
                    return Convert.ToDateTime(date.Trim());
                }
            }
            else
            {
                DateTime dd = new DateTime();
                if (DateTime.TryParseExact(date.Trim(), _CardParms.DATE_FORMAT, null, System.Globalization.DateTimeStyles.None, out dd))
                    return dd.Date;
                else
                    throw new Exception("無法將" + date + "轉換成日期");
            }
        }
    }
    public int Year
    {
        get
        {
            if (this.timeformat.Trim() == "International") return Convert.ToInt32(date.Substring(0, 4));
            else return Convert.ToInt32(date.Substring(0, 3)) + 1911;
        }
    }
    public int Month
    {
        get
        {
            if (this.timeformat.Trim() == "International") return Convert.ToInt32(date.Substring(4, 2));
            else return Convert.ToInt32(date.Substring(3, 2));
        }
    }
    public int Day
    {
        get
        {
            if (this.timeformat.Trim() == "International") return Convert.ToInt32(date.Substring(6, 2));
            else return Convert.ToInt32(date.Substring(5, 2));
        }
    }
    public string Atime
    {
        get
        {
            string tt = this.time.Trim();
            if (_CardParms.TIME_FORMAT.Trim().Length == 0)
            {
                if (tt.Length == 4)
                {
                    int i = 0;
                    if (int.TryParse(tt, out i))
                        return tt;
                    else throw new Exception("轉換時間格式時發生錯誤(" + tt + ")");
                }
                else if (tt.Length == 5 || tt.Length == 8)//00:00 or 00:00:00
                {
                    string dt = "1900/01/01 " + tt;
                    DateTime date = Convert.ToDateTime(dt);
                    return date.ToString("HHmm");
                }
                else if (tt.Length == 6)//時分秒
                {
                    DateTime date = new DateTime(1900, 1, 1);
                    date = date.AddTime(tt.Substring(0, 4));
                    return date.ToString("HHmm");
                }
                else if (tt.IndexOf('午') != -1)
                {
                    string time = tt.Replace("上午", "am");
                    time = time.Replace("下午", "pm");
                    string dt = time;
                    DateTime date = Convert.ToDateTime(dt);
                    return date.ToString("HHmm");
                }
                else
                {
                    DateTime date = Convert.ToDateTime(tt);
                    return date.ToString("HHmm");
                }
            }
            else
            {
                DateTime dd = new DateTime();
                if (DateTime.TryParseExact(tt, _CardParms.TIME_FORMAT, null, System.Globalization.DateTimeStyles.None, out dd))
                    return dd.ToString("HHmm");
                else
                    throw new Exception("無法將" + tt + "轉換成時間");
            }
        }
    }
    public string Temperature
    {
        get
        {
            if (_CardParms.Temperature_LEN.Value != 0)
            {
                string result = this.temperature;
                decimal x = 0;
                if (decimal.TryParse(result, out x))
                {
                    if (x > 100)
                        x = x / 10;
                }
                else
                    throw new Exception("無法將" + result + "轉換成體溫數值");
                return x.ToString();
            }
            else
                return string.Empty;
        }
    }
}
