using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Salary_EmpSalary : JBWebPage
{
    protected string ScriptString = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        showMeg.Text = "";
        if (Session["PWERROR"] == null)
        {
            Session["PWERROR"] = 0;
        }
        if ((int)Session["PWERROR"] >= 3) {

          //  ScriptString = "alert('您的密碼錯誤三次，不可查詢薪資資料，請關閉網頁！') ;close(); ";
            Button1.Visible = false;
            showMeg.Text = "您的密碼錯誤三次，不可查詢薪資資料";
            return;
        }
        

        if (!IsPostBack)
        {

            year.Text = Convert.ToString(DateTime.Now.Year ).PadLeft(4, '0');
            month.Text = Convert.ToString(DateTime.Now.AddMonths(-1).Month).PadLeft(2, '0');

            sq.Text = "2";
            ViewState["_nobr"] = JbUser.NOBR;
        }

        if (CheckBox1.Checked)
        {
            sq.Text = "3";
        }
        else
        {
            sq.Text = "2";
        }

        if (Page.IsPostBack && Session["Rds"] != null)
        {
            if (salary_pa.Checked)
                CrystalReportSource1.ReportDocument.Load(Server.MapPath("rpt_zz42c.rpt"));
            else
                CrystalReportSource1.ReportDocument.Load(Server.MapPath("rpt_zz42.rpt"));
            CrystalReportSource1.ReportDocument.SetDataSource(Session["Rds"]);

        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        bool _ot = false; bool _retchoo = false;
        if (ViewState["_nobr"] == null)
            return;

        int _year = int.Parse(year.Text);
        int _month = int.Parse(month.Text);
        string _y = _year.ToString().PadLeft(4, '0');
        string _m = _month.ToString().PadLeft(2, '0');
        DataSet1TableAdapters.LOCK_WAGETableAdapter lockWagead = new DataSet1TableAdapters.LOCK_WAGETableAdapter();
        DataSet1.LOCK_WAGEDataTable lockwagedt = lockWagead.GetDataBySeq(_y.Trim() + _m.Trim(), sq.Text);
        if (lockwagedt.Rows.Count == 0)
        {

            JB.WebModules.Message.Show("現在還不可查詢本月薪資！！");
            Cr_zz42.Visible = false;
            return;
        }


        if (idno.Text.Trim().Length == 0)
        {
            JB.WebModules.Message.Show("請先輸入您的身分證號碼！！");
            Cr_zz42.Visible = false;
            return;
        }
        else
        {
            DataSet1TableAdapters.baseTableAdapter basead = new DataSet1TableAdapters.baseTableAdapter();
            DataSet1.baseDataTable basedt = new DataSet1.baseDataTable();
            basead.FillByNobr(basedt, ViewState["_nobr"].ToString());
            if (basedt.Rows.Count > 0)
            {
                if (!idno.Text.Trim().ToUpper().Equals(basedt.Rows[0][0].ToString().Trim().ToUpper()))
                {
                    JB.WebModules.Message.Show("身分證號碼比對錯誤，請重新輸入身分證號碼！！ ");
                    Cr_zz42.Visible = false;

                    return;
                }
                else
                {
                    idno.Attributes.Add("Value", idno.Text);
                }
            }
            else
            {
                JB.WebModules.Message.Show("查詢人數過多，請先登出！！");
                Cr_zz42.Visible = false;

                return;

            }

        }

        if (salPW.Text.Trim().Length == 0)
        {
            JB.WebModules.Message.Show("請先輸入您的薪資密碼！！");
            Cr_zz42.Visible = false;
            return;
        }
        else
        {

            PWTableAdapters.SALPWTableAdapter pwad = new PWTableAdapters.SALPWTableAdapter();
            PW.SALPWDataTable pw = pwad.GetDataByNobr(ViewState["_nobr"].ToString());
            if (pw.Rows.Count > 0)
            {
                PW.SALPWRow pwrow = (PW.SALPWRow)pw.Rows[0];
                if (!Cs.decode(pwrow.PW).Trim().Equals(salPW.Text.Trim()))
                {
                    JB.WebModules.Message.Show("薪資密碼錯誤！！");
                    Session["PWERROR"] = (int)Session["PWERROR"] + 1;
                    Cr_zz42.Visible = false;
                    if (int.Parse(Session["PWERROR"].ToString()) >= 3)
                    {
                        showMeg.Text = "您的密碼錯誤三次，不可查詢薪資資料";
                    }
                    return;
                }

            }
            else
            {
                JB.WebModules.Message.Show("請先新增您的薪資密碼，新增完再查詢！！");
                Cr_zz42.Visible = false;
                return;
            }
        }
     //   ScriptString = "startTimer(); ";
        string yymm, seq, date_b, nobr;
        DateTime bdate;
        yymm = year.Text + month.Text;
        seq = sq.Text;
        date_b = Convert.ToString(DateTime.Parse(year.Text + "/" + month.Text + "/19").ToString("yyyy/MM/dd"));
        nobr = ViewState["_nobr"].ToString();

        bdate = DateTime.Parse(year.Text + "/01/01");

        zz42Ds Nds = new zz42Ds();
        DataRow newRow1 = Nds.Tables["rpt_title"].NewRow();
        newRow1["filed1"] = year.Text;
        newRow1["filed2"] = month.Text;
        newRow1["filed3"] = date_b;
        Nds.Tables["rpt_title"].Rows.Add(newRow1);

        zz42DsTableAdapters.baseTableAdapter rq_base = new zz42DsTableAdapters.baseTableAdapter();
        rq_base.Fill_base(Nds.rq_base, date_b, nobr);

        zz42DsTableAdapters.wagedTableAdapter rq_waged = new zz42DsTableAdapters.wagedTableAdapter();
        rq_waged.Fill_waged(Nds.rq_waged, DateTime.Parse( date_b), yymm, seq, nobr);


        if (Nds.Tables["rq_waged"].Rows.Count < 1)
        {
            JB.WebModules.Message.Show("無此條件的發薪資料");
            return;
        }

        //取得扣款資料
        zz42DsTableAdapters.bankwagedTableAdapter rq_bankwaged = new zz42DsTableAdapters.bankwagedTableAdapter();
        rq_bankwaged.Fill_bankwaged(Nds.rq_bankwaged, yymm, seq, nobr);
        foreach (DataRow Row in Nds.Tables["rq_bankwaged"].Rows)
        {
            Row["amt"] = ENCODE(2, Convert.ToInt32((decimal)Row["amt"]));
        }

        foreach (DataRow Row in Nds.Tables["rq_waged"].Rows)
        {
            if (Row["flag"].ToString().Trim() == "-")
                Row["amt"] = ENCODE(2,Convert.ToInt32( (decimal)Row["amt"])) * (-1);
            else
                Row["amt"] = ENCODE(2, Convert.ToInt32((decimal)Row["amt"]));




        }

        //求得應稅合計金額
        //Nds.Tables["wageds1"].PrimaryKey = new DataColumn[] { Nds.Tables["wageds1"].Columns["nobr"] };
        DataRow[] row1 = Nds.Tables["rq_waged"].Select("salattr<='F'", "nobr asc");
        for (int i = 0; i < row1.Length; i++)
        {
            DataRow row2 = Nds.Tables["wageds1"].Rows.Find(row1[i]["nobr"].ToString());
            if (row2 != null)
            {
                row2["tot1"] = decimal.Parse(row2["tot1"].ToString()) + decimal.Parse(row1[i]["amt"].ToString());
            }
            else
            {
                DataRow aRow = Nds.Tables["wageds1"].NewRow();
                aRow["nobr"] = row1[i]["nobr"].ToString();
                aRow["tot1"] = decimal.Parse(row1[i]["amt"].ToString());
                Nds.Tables["wageds1"].Rows.Add(aRow);
            }

        }

        //求得應發合計金額
        DataRow[] row3 = Nds.Tables["rq_waged"].Select("salattr <='L' and sal_code <>'N12' ", "nobr asc");
        for (int i = 0; i < row3.Length; i++)
        {
            DataRow row2 = Nds.Tables["wageds2"].Rows.Find(row3[i]["nobr"].ToString());
            if (row2 != null)
            {
                row2["tot2"] = decimal.Parse(row2["tot2"].ToString()) + decimal.Parse(row3[i]["amt"].ToString());
            }
            else
            {
                DataRow aRow = Nds.Tables["wageds2"].NewRow();
                aRow["nobr"] = row3[i]["nobr"].ToString();
                aRow["tot2"] = decimal.Parse(row3[i]["amt"].ToString());
                Nds.Tables["wageds2"].Rows.Add(aRow);
            }
        }

        DataRow[] row4 = Nds.Tables["rq_waged"].Select("salattr <='P' ", "nobr asc");
        for (int i = 0; i < row4.Length; i++)
        {
            DataRow row2 = Nds.Tables["wagedsy"].Rows.Find(row4[i]["nobr"].ToString());
            if (row2 != null)
            {
                row2["toty"] = decimal.Parse(row2["toty"].ToString()) + decimal.Parse(row4[i]["amt"].ToString());
            }
            else
            {
                DataRow aRow = Nds.Tables["wagedsy"].NewRow();
                aRow["nobr"] = row4[i]["nobr"].ToString();
                aRow["toty"] = decimal.Parse(row4[i]["amt"].ToString());
                Nds.Tables["wagedsy"].Rows.Add(aRow);
            }
        }


        for (int i = 0; i < Nds.Tables["rq_waged"].Rows.Count; i++)
        {
            //求得應發合計金額
            DataRow row2 = Nds.Tables["wagedsz"].Rows.Find(Nds.Tables["rq_waged"].Rows[i]["nobr"].ToString());
            if (row2 != null)
            {
                row2["totz"] = decimal.Parse(row2["totz"].ToString()) + decimal.Parse(Nds.Tables["rq_waged"].Rows[i]["amt"].ToString());
            }
            else
            {
                DataRow aRow = Nds.Tables["wagedsz"].NewRow();
                aRow["nobr"] = Nds.Tables["rq_waged"].Rows[i]["nobr"].ToString();
                aRow["totz"] = decimal.Parse(Nds.Tables["rq_waged"].Rows[i]["amt"].ToString());
                Nds.Tables["wagedsz"].Rows.Add(aRow);
            }

            if (Nds.Tables["rq_waged"].Rows[i]["flag"].ToString() == "-")
                Nds.Tables["rq_waged"].Rows[i]["amt"] = decimal.Parse(Nds.Tables["rq_waged"].Rows[i]["amt"].ToString()) * -1;
        }

        for (int i = 1; i < 5; i++)
        {
            String str_ttr = "F";
            String str_name = "應稅薪資";
            if (i == 2)
            {
                str_ttr = "L";
                str_name = "應付薪資";
            }
            if (i == 3)
            {
                str_ttr = "O";
                if (salary_pa.Checked)
                    str_name = "Actual Payment";//英文版
                else
                    str_name = "實發金額";
            }
            if (i == 4)
            {
                str_ttr = "S";
                str_name = "轉帳薪資";
            }
            if (i < 4)
            {
                DataRow aRow2 = Nds.Tables["zz422"].NewRow();
                aRow2["code1"] = "0001";
                aRow2["salattr"] = str_ttr;
                aRow2["sal_name"] = "3";
                Nds.Tables["zz422"].Rows.Add(aRow2);

                DataRow aRow3 = Nds.Tables["zz423"].NewRow();
                aRow3["code1"] = "0002";
                aRow3["salattr"] = str_ttr;
                aRow3["sal_name"] = "合計";
                Nds.Tables["zz423"].Rows.Add(aRow3);
            }
            DataRow aRow4 = Nds.Tables["zz421"].NewRow();
            aRow4["code1"] = "0000";
            aRow4["salattr"] = str_ttr;
            aRow4["sal_name"] = str_name;
            Nds.Tables["zz421"].Rows.Add(aRow4);
        }

        DataRow[] row5 = Nds.Tables["rq_waged"].Select("sal_code='B03'");
        for (int i = 0; i < row5.Length; i++)
        {
            DataRow row2 = Nds.Tables["zz4219b"].Rows.Find(row5[i]["nobr"].ToString());
            if (row2 != null)
            {
                row2["amt"] = decimal.Parse(row2["amt"].ToString()) + decimal.Parse(row5[i]["amt"].ToString());
            }
            else
            {
                DataRow aRow = Nds.Tables["zz4219b"].NewRow();
                aRow["nobr"] = row5[i]["nobr"].ToString();
                aRow["amt"] = decimal.Parse(row5[i]["amt"].ToString());
                Nds.Tables["zz4219b"].Rows.Add(aRow);
            }
        }

        //伙食津貼
        DataRow[] row6 = Nds.Tables["rq_waged"].Select("sal_code='G01'");
        for (int i = 0; i < row6.Length; i++)
        {
            DataRow row2 = Nds.Tables["zz42g01"].Rows.Find(row6[i]["nobr"].ToString());
            if (row2 != null)
            {
                row2["amt"] = decimal.Parse(row2["amt"].ToString()) + decimal.Parse(row6[i]["amt"].ToString());
            }
            else
            {
                DataRow aRow = Nds.Tables["zz42g01"].NewRow();
                aRow["nobr"] = row6[i]["nobr"].ToString();
                aRow["amt"] = decimal.Parse(row6[i]["amt"].ToString());
                Nds.Tables["zz42g01"].Rows.Add(aRow);
            }
        }

        //本期加上伙食津貼
        DataRow[] row8 = Nds.Tables["rq_waged"].Select("sal_code <>'B0' and sal_code <> 'N08' ");
        for (int i = 0; i < row8.Length; i++)
        {
            if (row8[i]["amt"].ToString().Trim() != "")
            {

                DataRow aRow = Nds.Tables["zz42"].NewRow();
                aRow["nobr"] = row8[i]["nobr"].ToString();
                aRow["ttrcode"] = row8[i]["salattr"].ToString() + row8[i]["sal_code"].ToString();
                //if (row8[i]["sal_code"].ToString().Trim() == "A01" && Nds.Tables["zz42g01"].Rows.Count > 0)
                //    aRow["amt"] = decimal.Parse(row8[i]["amt"].ToString()) + decimal.Parse(Nds.Tables["zz42g01"].Rows[0]["amt"].ToString());
                //else
                    aRow["amt"] = decimal.Parse(row8[i]["amt"].ToString());
                Nds.Tables["zz42"].Rows.Add(aRow);
            }
        }


        //增加RPTTITLE的值如應發應扣得屬性
        DataColumn[] _key422 = new DataColumn[3];
        _key422[0] = Nds.Tables["zz422"].Columns["code1"];
        _key422[1] = Nds.Tables["zz422"].Columns["salattr"];
        _key422[2] = Nds.Tables["zz422"].Columns["sal_name"];
        Nds.Tables["zz422"].PrimaryKey = _key422;

        DataColumn[] _key423 = new DataColumn[3];
        _key423[0] = Nds.Tables["zz423"].Columns["code1"];
        _key423[1] = Nds.Tables["zz423"].Columns["salattr"];
        _key423[2] = Nds.Tables["zz423"].Columns["sal_name"];
        Nds.Tables["zz423"].PrimaryKey = _key423;

        DataRow[] row9 = Nds.Tables["rq_waged"].Select("amt <> 0 and sal_code <>'B0' and sal_code <> 'N08' ");
        for (int i = 0; i < row9.Length; i++)
        {
            string str_salcode = row9[i]["sal_code"].ToString();
            string str_salattr = row9[i]["salattr"].ToString();
            string str_flag = row9[i]["flag"].ToString();
            string str_salname = row9[i]["sal_name"].ToString();
            bool str_tax = bool.Parse(row9[i]["tax"].ToString());
            object[] _value = new object[3];
            _value[0] = "0001";
            _value[1] = str_salattr + str_salcode;

            if (str_flag == "-")
            {
                _value[2] = "2";
                DataRow row2 = Nds.Tables["zz422"].Rows.Find(_value);
                if (row2 == null)
                {
                    DataRow aRow = Nds.Tables["zz422"].NewRow();
                    aRow["code1"] = "0001";
                    aRow["salattr"] = str_salattr + str_salcode;
                    aRow["sal_name"] = "2";
                    Nds.Tables["zz422"].Rows.Add(aRow);
                }
            }
            else
            {
                _value[2] = "1";
                DataRow row10 = Nds.Tables["zz422"].Rows.Find(_value);
                if (row10 == null)
                {
                    DataRow aRow = Nds.Tables["zz422"].NewRow();
                    aRow["code1"] = "0001";
                    aRow["salattr"] = str_salattr + str_salcode;
                    aRow["sal_name"] = "1";
                    Nds.Tables["zz422"].Rows.Add(aRow);
                }
            }

            object[] _value1 = new object[3];
            _value1[0] = "0002";
            _value1[1] = str_salattr + str_salcode;
            if (str_tax)
            {
                _value[2] = "應稅";
                DataRow row11 = Nds.Tables["zz423"].Rows.Find(_value1);
                if (row11 == null)
                {
                    DataRow aRow = Nds.Tables["zz423"].NewRow();
                    aRow["code1"] = "0002";
                    aRow["salattr"] = str_salattr + str_salcode;
                    aRow["sal_name"] = "應稅";
                    Nds.Tables["zz423"].Rows.Add(aRow);
                }
            }
            else
            {
                _value[2] = "免稅";
                DataRow row12 = Nds.Tables["zz423"].Rows.Find(_value1);
                if (row12 == null)
                {
                    try
                    {
                        DataRow aRow = Nds.Tables["zz423"].NewRow();
                        aRow["code1"] = "0002";
                        aRow["salattr"] = str_salattr + str_salcode;
                        aRow["sal_name"] = "免稅";
                        Nds.Tables["zz423"].Rows.Add(aRow);
                    }
                    catch { }
                }
            }

            if (salary_pa.Checked)
                str_salname = row9[i]["sal_ename"].ToString();

            DataRow aRow3 = Nds.Tables["zz421"].NewRow();
            aRow3["code1"] = "0000";
            aRow3["salattr"] = str_salattr + str_salcode;
            aRow3["sal_name"] = str_salname;
            Nds.Tables["zz421"].Rows.Add(aRow3);

        }

        foreach (DataRow Row in Nds.Tables["zz422"].Rows)
        {
            Nds.Tables["zz421"].ImportRow(Row);
        }

        foreach (DataRow Row in Nds.Tables["zz423"].Rows)
        {
            Nds.Tables["zz421"].ImportRow(Row);
        }

        //產生抬頭
        DataRow[] row = Nds.Tables["zz421"].Select("", "code1,salattr asc");
        for (int i = 0; i < row.Length; i++)
        {
            DataRow aRow = Nds.Tables["zz4211"].NewRow();
            aRow["code1"] = row[i]["code1"].ToString();
            aRow["salattr"] = row[i]["salattr"].ToString();
            aRow["sal_name"] = row[i]["sal_name"].ToString();
            Nds.Tables["zz4211"].Rows.Add(aRow);
        }

        DataRow[] row14 = Nds.Tables["zz4211"].Select("code1='0000'");
        for (int i = 0; i < row14.Length; i++)
        {
            string str_ttrcode = row14[i]["salattr"].ToString();
            DataRow row15 = Nds.Tables["zz42gt"].Rows.Find(str_ttrcode);
            if (row15 == null)
            {
                DataRow aRow = Nds.Tables["zz42gt"].NewRow();
                aRow["ttrcode"] = row14[i]["salattr"].ToString();
                aRow["sal_name"] = row14[i]["sal_name"].ToString();
                Nds.Tables["zz42gt"].Rows.Add(aRow);
            }
        }

        foreach (DataRow Row in Nds.Tables["wageds1"].Rows)
        {
            DataRow aRow = Nds.Tables["zz42"].NewRow();
            aRow["nobr"] = Row["nobr"].ToString();
            aRow["ttrcode"] = "F";
            aRow["amt"] = decimal.Parse(Row["tot1"].ToString());
            Nds.Tables["zz42"].Rows.Add(aRow);
        }

        foreach (DataRow Row in Nds.Tables["wageds2"].Rows)
        {
            DataRow aRow = Nds.Tables["zz42"].NewRow();
            aRow["nobr"] = Row["nobr"].ToString();
            aRow["ttrcode"] = "L";
            aRow["amt"] = decimal.Parse(Row["tot2"].ToString());
            Nds.Tables["zz42"].Rows.Add(aRow);
        }

        foreach (DataRow Row in Nds.Tables["wagedsy"].Rows)
        {
            DataRow aRow = Nds.Tables["zz42"].NewRow();
            aRow["nobr"] = Row["nobr"].ToString();
            aRow["ttrcode"] = "O";
            aRow["amt"] = decimal.Parse(Row["toty"].ToString());
            Nds.Tables["zz42"].Rows.Add(aRow);
        }

        foreach (DataRow Row in Nds.Tables["wagedsz"].Rows)
        {
            DataRow aRow = Nds.Tables["zz42"].NewRow();
            aRow["nobr"] = Row["nobr"].ToString();
            aRow["ttrcode"] = "S";
            aRow["amt"] = decimal.Parse(Row["totz"].ToString());
            Nds.Tables["zz42"].Rows.Add(aRow);
        }

        DataRow aRow5 = Nds.Tables["zz42ta"].NewRow();
        DataRow aRow6 = Nds.Tables["zz42td"].NewRow();
        for (int i = 0; i < Nds.Tables["zz42gt"].Rows.Count; i++)
        {
            aRow5["Fld" + (i + 1)] = Nds.Tables["zz42gt"].Rows[i]["sal_name"].ToString();
            DataRow[] row16 = Nds.Tables["zz42"].Select("ttrcode='" + Nds.Tables["zz42gt"].Rows[i]["ttrcode"].ToString() + "'");
            aRow6["Fld" + (i + 1)] = 0;
            //for (int j=0;j < row16.Length ;j++)
            //{
            //   aRow6["Fld" + (i + 1)] = decimal.Parse(aRow6["Fld"+(i+1)].ToString())+decimal.Parse(row16[j]["amt"].ToString());
            //}
            if (row16.Length > 0)
                aRow6["Fld" + (i + 1)] = decimal.Parse(row16[0]["amt"].ToString());



        }
        aRow6["nobr"] = Nds.Tables["rq_base"].Rows[0]["nobr"].ToString();
        aRow6["name_c"] =Nds.Tables["rq_base"].Rows[0]["name_c"].ToString();
        aRow6["dept"] = Nds.Tables["rq_base"].Rows[0]["dept"].ToString();
        aRow6["d_name"] = Nds.Tables["rq_base"].Rows[0]["d_name"].ToString();
        aRow6["workcd"] = Nds.Tables["rq_base"].Rows[0]["workcd"].ToString();
        aRow6["holi_code"] = Nds.Tables["rq_base"].Rows[0]["holi_code"].ToString();
        aRow6["di"] = Nds.Tables["rq_base"].Rows[0]["di"].ToString();
        aRow6["sex"] = Nds.Tables["rq_base"].Rows[0]["sex"].ToString();
        aRow6["count_ma"] = bool.Parse(Nds.Tables["rq_base"].Rows[0]["count_ma"].ToString());
        aRow6["rote"] = "";// Nds.Tables["rq_base"].Rows[0]["rote"].ToString();
        aRow6["rote_w"] = "";// Nds.Tables["rq_base"].Rows[0]["rote_w"].ToString();
        //aRow6["aadate"] = DateTime.Parse(Nds.Tables["rq_base"].Rows[0]["adate"].ToString());
        aRow6["comp"] = Nds.Tables["rq_base"].Rows[0]["comp"].ToString();
        aRow6["compname"] = Nds.Tables["rq_base"].Rows[0]["compname"].ToString();
        aRow6["idno"] = Nds.Tables["rq_base"].Rows[0]["idno"].ToString();
        aRow6["bbcall"] = Nds.Tables["rq_base"].Rows[0]["bbcall"].ToString();
        aRow6["cash"] = bool.Parse(Nds.Tables["rq_waged"].Rows[0]["cash"].ToString());
        aRow6["wk_days"] = decimal.Parse(Nds.Tables["rq_waged"].Rows[0]["wk_days"].ToString());
        aRow6["note"] = Nds.Tables["rq_waged"].Rows[0]["note"].ToString();
        aRow6["adate"] = DateTime.Parse(Nds.Tables["rq_waged"].Rows[0]["adate"].ToString());
        aRow6["attdate_b"] = year.Text
            + "/"+
             month.Text + "/1";// DateTime.Parse(Nds.Tables["rq_waged"].Rows[0]["attdate_b"].ToString());
        aRow6["attdate_e"] = year.Text +
            "/" + month.Text + "/"+
            DateTime.DaysInMonth( int.Parse(year.Text),
                                  int.Parse(month.Text)).ToString();// DateTime.Parse(Nds.Tables["rq_waged"].Rows[0]["attdate_e"].ToString());
        aRow6["account_no"] = Nds.Tables["rq_waged"].Rows[0]["account_no"].ToString();
        aRow6["bankno"] = Nds.Tables["rq_waged"].Rows[0]["bankno"].ToString();
        Nds.Tables["zz42td"].Rows.Add(aRow6);
        Nds.Tables["zz42ta"].Rows.Add(aRow5);
        if ( Nds.Tables["rq_base"].Rows[0]["retchoo"].ToString().Trim()=="1")
            _retchoo=bool.Parse("true");
        //zz42DsTableAdapters.rq_otTableAdapter rq_ot = new zz42DsTableAdapters.rq_otTableAdapter();
        //rq_ot.Fill_ot(Nds.rq_ot, nobr, yymm);

        //zz42DsTableAdapters.rq_ot1TableAdapter rq_ot1 = new zz42DsTableAdapters.rq_ot1TableAdapter();
        //rq_ot1.Fill_ot1(Nds.rq_ot1, nobr, yymm);

        zz42DsTableAdapters.rq_otaTableAdapter rq_ota = new zz42DsTableAdapters.rq_otaTableAdapter();
        rq_ota.Fill_ota(Nds.rq_ota, nobr, yymm);
        DataTable rq_ot = new DataTable();
        rq_ot.Columns.Add("nobr", typeof(string));
        rq_ot.Columns.Add("ot_100", typeof(decimal));
        rq_ot.Columns.Add("ot_133", typeof(decimal));
        rq_ot.Columns.Add("ot_167", typeof(decimal));
        rq_ot.Columns.Add("ot_200", typeof(decimal));
        rq_ot.Columns.Add("ot_200_h", typeof(decimal));
        rq_ot.PrimaryKey = new DataColumn[] { rq_ot.Columns["nobr"] };
        foreach (DataRow Row in  Nds.Tables["rq_ota"].Rows)
        {
            if (decimal.Parse(Row["nop_w_133"].ToString()) == Convert.ToDecimal(1.5))
            {
                Row["ot_150"] = decimal.Parse(Row["ot_133"].ToString()) + decimal.Parse(Row["ot_167"].ToString()) + decimal.Parse(Row["ot_200"].ToString());
                Row["ot_133"] = 0;
                Row["ot_167"] = 0;
                Row["ot_200"] = 0;
            }
            DataRow rowa = rq_ot.Rows.Find(Row["nobr"].ToString());
            if (rowa != null)
            {
                rowa["ot_100"] = decimal.Parse(rowa["ot_100"].ToString()) + decimal.Parse(Row["ot_100"].ToString());
                rowa["ot_133"] = decimal.Parse(rowa["ot_133"].ToString()) + decimal.Parse(Row["ot_133"].ToString());
                rowa["ot_167"] = decimal.Parse(rowa["ot_167"].ToString()) + decimal.Parse(Row["ot_167"].ToString());
                rowa["ot_200"] = decimal.Parse(rowa["ot_200"].ToString()) + decimal.Parse(Row["ot_200"].ToString());
                rowa["ot_200_h"] = decimal.Parse(rowa["ot_200_h"].ToString()) + decimal.Parse(Row["ot_200_h"].ToString());
            }
            else
            {
                DataRow aRow = rq_ot.NewRow();
                aRow["nobr"] = Row["nobr"].ToString();
                aRow["ot_100"] = (Row.IsNull("ot_100")) ? 0 : decimal.Parse(Row["ot_100"].ToString());
                aRow["ot_133"] = (Row.IsNull("ot_133")) ? 0 : decimal.Parse(Row["ot_133"].ToString());
                aRow["ot_167"] = (Row.IsNull("ot_167")) ? 0 : decimal.Parse(Row["ot_167"].ToString());
                aRow["ot_200"] = (Row.IsNull("ot_200")) ? 0 : decimal.Parse(Row["ot_200"].ToString());
                aRow["ot_200_h"] = (Row.IsNull("ot_200_h")) ? 0 : decimal.Parse(Row["ot_200_h"].ToString());
                rq_ot.Rows.Add(aRow);
            }
        }
        if (rq_ot.Rows.Count ==0)
            _ot=bool.Parse("true");
        //系統設定勞退代號及所得代碼
        zz42DsTableAdapters.rq_sys4TableAdapter rq_sys4 = new zz42DsTableAdapters.rq_sys4TableAdapter();
        rq_sys4.Fill_rq_usys4(Nds.rq_sys4);
        string retsalcode = (Nds.Tables["rq_sys4"].Rows.Count > 0) ? Nds.Tables["rq_sys4"].Rows[0]["retsalcode"].ToString() : "";

        zz42DsTableAdapters.rq_sys9TableAdapter rq_sys9 = new zz42DsTableAdapters.rq_sys9TableAdapter();
        rq_sys9.Fill_rq_sys9(Nds.rq_sys9);
        string taxsalcode = (Nds.Tables["rq_sys9"].Rows.Count > 0) ? Nds.Tables["rq_sys9"].Rows[0]["taxsalcode"].ToString() : "";


        string _edate = DateTime.Parse(_y + "/" + _m + "/01").AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
        //薪資基本資料
        zz42DsTableAdapters.rq_salbasdTableAdapter rq_salbasd = new zz42DsTableAdapters.rq_salbasdTableAdapter();
        rq_salbasd.Fill_rq_salbasd(Nds.rq_salbasd,nobr,yymm,seq,_edate);
        DataTable rq_salbasd1 = new DataTable();
        rq_salbasd1.Columns.Add("nobr", typeof(string));
        rq_salbasd1.Columns.Add("amt", typeof(int));
        rq_salbasd1.PrimaryKey = new DataColumn[] { rq_salbasd1.Columns["nobr"] };
        foreach (DataRow Row in Nds.Tables["rq_salbasd"].Rows)
        {
            Row["amt"] = ENCODE(2, Convert.ToInt32((decimal)Row["amt"]));
            DataRow row0 = rq_salbasd1.Rows.Find(Row["nobr"].ToString());
            if (row0 != null)
                row0["amt"] = int.Parse(row0["amt"].ToString()) + int.Parse(Row["amt"].ToString());
            else
            {
                DataRow aRow = rq_salbasd1.NewRow();
                aRow["nobr"] = Row["nobr"].ToString();
                aRow["amt"] = int.Parse(Row["amt"].ToString());
                rq_salbasd1.Rows.Add(aRow);
            }
        }

        //扣項合計
        DataTable rq_sala = new DataTable();
        rq_sala.Columns.Add("nobr", typeof(string));
        rq_sala.Columns.Add("amt", typeof(int));
        rq_sala.PrimaryKey = new DataColumn[] { rq_sala.Columns["nobr"] };
        DataRow[] row_waged = Nds.Tables["rq_waged"].Select("salattr='D' or salattr='J' or salattr='M' or salattr='N'");
        foreach (DataRow Row in row_waged)
        {
            int _amt = int.Parse(Row["amt"].ToString());
            //if (Row["flag"].ToString().Trim() == "-")
            //    _amt = _amt * (-1);
            DataRow row0 = rq_sala.Rows.Find(Row["nobr"].ToString());
            if (row0 != null)
                row0["amt"] = int.Parse(row0["amt"].ToString()) + _amt;
            else
            {
                DataRow aRow = rq_sala.NewRow();
                aRow["nobr"] = Row["nobr"].ToString();
                aRow["amt"] = _amt;
                rq_sala.Rows.Add(aRow);
            }
        }

        //加入勞退金額
        zz42DsTableAdapters.rq_retTableAdapter rq_ret = new zz42DsTableAdapters.rq_retTableAdapter();
        rq_ret.Fill_ret(Nds.rq_ret, yymm, nobr, date_b);

        DataRow[] row17 = Nds.Tables["rq_waged"].Select("sal_code='" + retsalcode + "'");
        for (int i = 0; i < row17.Length; i++)
        {
            //  DataRow row2 = Nds.Tables["rq_ret1"].Rows.Find(row[i]["nobr"].ToString());
            DataRow row2 = Nds.Tables["rq_ret1"].Rows.Find(nobr);
            if (row2 != null)
                row2["amt"] = decimal.Parse(row2["amt"].ToString()) + decimal.Parse(row17[i]["amt"].ToString());
            else
            {
                DataRow aRow = Nds.Tables["rq_ret1"].NewRow();
                aRow["nobr"] = row17[i]["nobr"].ToString();
                aRow["amt"] = decimal.Parse(row17[i]["amt"].ToString());
                Nds.Tables["rq_ret1"].Rows.Add(aRow);
            }
        }

        //累計應稅所得及累計所得稅
        DataTable rq_ytax = new DataTable();
        rq_ytax.Columns.Add("nobr", typeof(string));
        rq_ytax.Columns.Add("amt", typeof(int));
        rq_ytax.PrimaryKey = new DataColumn[] { rq_ytax.Columns["nobr"] };

        DataTable rq_ysalary = new DataTable();
        rq_ysalary.Columns.Add("nobr", typeof(string));
        rq_ysalary.Columns.Add("amt", typeof(string));
        rq_ysalary.PrimaryKey = new DataColumn[] { rq_ysalary.Columns["nobr"] };

        //累計自提退休金
        DataTable rq_yret = new DataTable();
        rq_yret.Columns.Add("nobr", typeof(string));
        rq_yret.Columns.Add("amt", typeof(int));
        rq_yret.PrimaryKey = new DataColumn[] { rq_yret.Columns["nobr"] };
        zz42DsTableAdapters.rq_allwagedTableAdapter rq_allwaged = new zz42DsTableAdapters.rq_allwagedTableAdapter();
        rq_allwaged.Fill_rq_allwaged(Nds.rq_allwaged, Convert.ToString(_year), yymm, nobr);
        foreach (DataRow Row in Nds.Tables["rq_allwaged"].Rows)
        {
            if (Row["flag"].ToString() == "-")
                Row["amt"] = ENCODE(2, Convert.ToInt32((decimal)Row["amt"])) * (-1);
            else
                Row["amt"] = ENCODE(2, Convert.ToInt32((decimal)Row["amt"]));

            if (Row["sal_code"].ToString().Trim() == taxsalcode.Trim())
            {
                DataRow row2 = rq_ytax.Rows.Find(Row["nobr"].ToString());
                if (row2 != null)
                    row2["amt"] = int.Parse(row2["amt"].ToString()) + (int.Parse(Row["amt"].ToString()) * (-1));
                else
                {
                    DataRow aRow = rq_ytax.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString()) * (-1);
                    rq_ytax.Rows.Add(aRow);
                }
            }

            if (Row["sal_code"].ToString().Trim() == retsalcode)
            {
                DataRow row5a = rq_yret.Rows.Find(Row["nobr"].ToString());
                if (row5a != null)
                    row5a["amt"] = int.Parse(row5a["amt"].ToString()) + (int.Parse(Row["amt"].ToString()) * (-1));
                else
                {
                    DataRow aRow2 = rq_yret.NewRow();
                    aRow2["nobr"] = Row["nobr"].ToString();
                    aRow2["amt"] = int.Parse(Row["amt"].ToString()) * (-1);
                    rq_yret.Rows.Add(aRow2);
                }
            }
          
        }

        DataRow[] SRow = Nds.Tables["rq_allwaged"].Select("salattr <='F'");
        foreach (DataRow Row1 in SRow)
        {
            DataRow row3a = rq_ysalary.Rows.Find(Row1["nobr"].ToString());
            if (row3a != null)
                row3a["amt"] = int.Parse(row3a["amt"].ToString()) + int.Parse(Row1["amt"].ToString());
            else
            {
                DataRow aRow1a = rq_ysalary.NewRow();
                aRow1a["nobr"] = Row1["nobr"].ToString();
                aRow1a["amt"] = int.Parse(Row1["amt"].ToString());
                rq_ysalary.Rows.Add(aRow1a);
            }
        }


        //累計公司提撥退休金
        zz42DsTableAdapters.rq_allretTableAdapter rq_allret=new zz42DsTableAdapters.rq_allretTableAdapter();
        rq_allret.Fill_rq_allret(Nds.rq_allret,nobr,Convert.ToString(_year),yymm);
        DataTable rq_yretcomp = new DataTable();
        rq_yretcomp.Columns.Add("nobr", typeof(string));
        rq_yretcomp.Columns.Add("comp", typeof(int));
        rq_yretcomp.PrimaryKey = new DataColumn[] { rq_yretcomp.Columns["nobr"] };
        foreach (DataRow Row in Nds.Tables["rq_allret"].Rows)
        {
            Row["comp"] = ENCODE(2, Convert.ToInt32((decimal)Row["comp"]));
            DataRow row01 = rq_yretcomp.Rows.Find(Row["nobr"].ToString());
            if (row01 != null)
                row01["comp"] = int.Parse(row01["comp"].ToString()) + int.Parse(Row["comp"].ToString());
            else
            {
                DataRow aRowp = rq_yretcomp.NewRow();
                aRowp["nobr"] = Row["nobr"].ToString();
                aRowp["comp"] = int.Parse(Row["comp"].ToString());
                rq_yretcomp.Rows.Add(aRowp);
            }           
        }

        ////固定加班費
        //zz42DsTableAdapters.rq_wagefixTableAdapter rq_wagefix = new zz42DsTableAdapters.rq_wagefixTableAdapter();
        //rq_wagefix.Fill_wagefix(Nds.rq_wagefix, yymm, nobr, date_b);

        if (salary_pa.Checked)
        {
            zz42DsTableAdapters.rq_absTableAdapter rq_abs = new zz42DsTableAdapters.rq_absTableAdapter();
            rq_abs.Fill_abs(Nds.rq_abs, yymm, nobr, date_b);
        }
        else
        {
            zz42DsTableAdapters.rq_absTableAdapter rq_abs1 = new zz42DsTableAdapters.rq_absTableAdapter();
            rq_abs1.FillBy_abs1(Nds.rq_abs, yymm, nobr, date_b);
        }

        if (Nds.Tables["rq_abs"].Rows.Count > 0)
        {
            for (int i = 0; i < Nds.Tables["rq_abs"].Rows.Count; i++)
            {
                string str_hcode = Nds.Tables["rq_abs"].Rows[i]["h_code"].ToString();
                if (str_hcode == "01")
                    Nds.Tables["rq_abs"].Rows[i]["tot_hrs"] = decimal.Parse(Nds.Tables["rq_abs"].Rows[i]["tot_day"].ToString());
            }
        }

        //產生請假的橫向抬頭(單位
        DataRow[] row18 = Nds.Tables["rq_abs"].Select("", "h_code");
        for (int i = 0; i < row18.Length; i++)
        {
            string str_hcode = row18[i]["h_code"].ToString();
            string str_unit = row18[i]["unit"].ToString().Trim();
            DataRow row2 = Nds.Tables["rq_abs3"].Rows.Find(str_hcode);
            if (row2 == null)
            {
                DataRow aRow = Nds.Tables["rq_abs3"].NewRow();
                aRow["code1"] = "0000";
                aRow["h_name"] = row18[i]["h_name"].ToString();
                aRow["unit"] = str_unit;
                if (salary_pa.Checked)
                {
                    if (str_unit == "小時")
                        aRow["unit"] = "hours";
                    if (str_unit == "天")
                        aRow["unit"] = "days";
                }
                aRow["h_code"] = str_hcode;
                Nds.Tables["rq_abs3"].Rows.Add(aRow);
            }
        }

        //產生請假的橫向抬頭
        for (int i = 0; i < Nds.Tables["rq_abs"].Rows.Count; i++)
        {
            string str_hcode = Nds.Tables["rq_abs"].Rows[i]["h_code"].ToString();
            string str_hname = Nds.Tables["rq_abs"].Rows[i]["h_name"].ToString();
            DataRow row81 = Nds.Tables["rq_abs2"].Rows.Find(str_hcode);
            if (row81 == null)
            {
                DataRow aRow = Nds.Tables["rq_abs2"].NewRow();
                aRow["code1"] = "0000";
                aRow["h_code"] = str_hcode;
                if (salary_pa.Checked)
                    aRow["h_name"] = str_hname;
                else
                    aRow["h_name"] = str_hname;
                Nds.Tables["rq_abs2"].Rows.Add(aRow);
            }
        }

        //產生請假的橫向內容
        for (int i = 0; i < Nds.Tables["rq_abs"].Rows.Count; i++)
        {
            DataRow aRow = Nds.Tables["rq_abs1"].NewRow();
            aRow["nobr"] = Nds.Tables["rq_abs"].Rows[i]["nobr"].ToString();
            aRow["h_code"] = Nds.Tables["rq_abs"].Rows[i]["h_code"].ToString();
            aRow["tot_hrs"] = decimal.Parse(Nds.Tables["rq_abs"].Rows[i]["tot_hrs"].ToString());
            Nds.Tables["rq_abs1"].Rows.Add(aRow);
        }

        DataRow aRow8 = Nds.Tables["zz4215ta"].NewRow();
        DataRow aRow9 = Nds.Tables["zz4215tb"].NewRow();
        for (int i = 1; i <= 15; i++)
        {
            aRow9["Fld" + i] = 0;
        }
        for (int i = 0; i < Nds.Tables["rq_abs2"].Rows.Count; i++)
        {
            aRow8["Fld" + (i + 1)] = Nds.Tables["rq_abs2"].Rows[i]["h_name"].ToString();
            DataRow[] row21 = Nds.Tables["rq_abs1"].Select("h_code='" + Nds.Tables["rq_abs2"].Rows[i]["h_code"].ToString() + "'");
            if (row21.Length > 0)
            {
                aRow9["Fld" + (i + 1)] = decimal.Parse(row21[0]["tot_hrs"].ToString());
            }
        }
        //aRow8["nobr"] = Nds.Tables["rq_abs2"].Rows[0]["nobr"].ToString();
        Nds.Tables["zz4215ta"].Rows.Add(aRow8);
        //if (Nds.Tables["rq_abs1"].Rows.Count >0)
        //    aRow9["nobr"] = Nds.Tables["rq_abs1"].Rows[0]["nobr"].ToString();
        aRow9["nobr"] = nobr;
        Nds.Tables["zz4215tb"].Rows.Add(aRow9);

        DataRow aRow13 = Nds.Tables["zz4215ta1"].NewRow();
        for (int i = 0; i < Nds.Tables["rq_abs3"].Rows.Count; i++)
        {
            aRow13["Fld" + (i + 1)] = Nds.Tables["rq_abs3"].Rows[i]["unit"].ToString();
        }
        //aRow13["nobr"] = Nds.Tables["rq_abs3"].Rows[0]["nobr"].ToString();
        Nds.Tables["zz4215ta1"].Rows.Add(aRow13);



        //年假
        zz42DsTableAdapters.rq_abst1TableAdapter rq_abst1 = new zz42DsTableAdapters.rq_abst1TableAdapter();
        rq_abst1.Fill_abst1(Nds.rq_abst1, bdate, nobr);
        for (int i = 0; i < Nds.Tables["rq_abst1"].Rows.Count; i++)
        {
            string yearrest = Nds.Tables["rq_abst1"].Rows[i]["year_rest"].ToString();
            if (yearrest == "2")
                Nds.Tables["rq_abst1"].Rows[i]["tol_day"] = decimal.Parse(Nds.Tables["rq_abst1"].Rows[i]["tol_day"].ToString()) * -1;
        }

        foreach (DataRow Row in Nds.Tables["rq_abst1"].Rows)
        {
            DataRow row2 = Nds.Tables["rq_rest1"].Rows.Find(Row["nobr"].ToString());
            if (row2 != null)
                row2["tol_day"] = decimal.Parse(row2["tol_day"].ToString()) + decimal.Parse(Row["tol_day"].ToString());
            else
            {
                DataRow aRow = Nds.Tables["rq_rest1"].NewRow();
                aRow["nobr"] = Row["nobr"].ToString();
                aRow["tol_day"] = decimal.Parse(Row["tol_day"].ToString());
                Nds.Tables["rq_rest1"].Rows.Add(aRow);
            }
        }

        //補休
        zz42DsTableAdapters.rq_abst2TableAdapter rq_abst2 = new zz42DsTableAdapters.rq_abst2TableAdapter();
        rq_abst2.Fill_abst2(Nds.rq_abst2, bdate, nobr);
        for (int i = 0; i < Nds.Tables["rq_abst2"].Rows.Count; i++)
        {
            string yearrest = Nds.Tables["rq_abst2"].Rows[i]["year_rest"].ToString();
            if (yearrest == "4")
                Nds.Tables["rq_abst2"].Rows[i]["tol_hours"] = decimal.Parse(Nds.Tables["rq_abst2"].Rows[i]["tol_hours"].ToString()) * -1;
        }
        foreach (DataRow Row in Nds.Tables["rq_abst2"].Rows)
        {
            DataRow row2 = Nds.Tables["rq_rest2"].Rows.Find(Row["nobr"].ToString());
            if (row2 != null)
                row2["tol_hours"] = decimal.Parse(row2["tol_hours"].ToString()) + decimal.Parse(Row["tol_hours"].ToString());
            else
            {
                DataRow aRow = Nds.Tables["rq_rest2"].NewRow();
                aRow["nobr"] = Row["nobr"].ToString();
                aRow["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString());
                Nds.Tables["rq_rest2"].Rows.Add(aRow);
            }
        }

        //彈休
        zz42DsTableAdapters.rq_abst3TableAdapter rq_abst3 = new zz42DsTableAdapters.rq_abst3TableAdapter();
        rq_abst3.Fill_abst3(Nds.rq_abst3, bdate.Year, nobr);
        for (int i = 0; i < Nds.Tables["rq_abst3"].Rows.Count; i++)
        {
            string yearrest = Nds.Tables["rq_abst3"].Rows[i]["year_rest"].ToString();
            if (yearrest == "6")
                Nds.Tables["rq_abst3"].Rows[i]["tol_day"] = decimal.Parse(Nds.Tables["rq_abst3"].Rows[i]["tol_day"].ToString()) * -1;
        }
        foreach (DataRow Row in Nds.Tables["rq_abst3"].Rows)
        {
            DataRow row2 = Nds.Tables["rq_rest3"].Rows.Find(Row["nobr"].ToString());
            if (row2 != null)
                row2["tol_day"] = decimal.Parse(row2["tol_day"].ToString()) + decimal.Parse(Row["tol_day"].ToString());
            else
            {
                DataRow aRow = Nds.Tables["rq_rest3"].NewRow();
                aRow["nobr"] = Row["nobr"].ToString();
                aRow["tol_day"] = decimal.Parse(Row["tol_day"].ToString());
                Nds.Tables["rq_rest3"].Rows.Add(aRow);
            }

        }

        DataRow aRow0 = Nds.Tables["zz42td1a"].NewRow();
        DataRow aRow1 = Nds.Tables["zz42td2a"].NewRow();
        DataRow aRow10 = Nds.Tables["zz42td3a"].NewRow();

        DataRow[] row19 = Nds.Tables["zz4211"].Select("code1='0001'");
        DataRow[] row20 = Nds.Tables["zz4211"].Select("code1='0002'");
        int ddsdf = Nds.Tables["zz42gt"].Rows.Count;

        for (int i = 0; i < Nds.Tables["zz42gt"].Rows.Count; i++)
        {
            if (i >= 25)
                continue;
            string str_salattr = Nds.Tables["zz42gt"].Rows[i]["ttrcode"].ToString();
            aRow0["Fld" + (i + 1)] = Nds.Tables["zz42gt"].Rows[i]["sal_name"].ToString();

            for (int j = 0; j < row19.Length; j++)
            {

                if (str_salattr == row19[j]["salattr"].ToString())
                {
                    aRow1["Fld" + (i + 1)] = row19[j]["sal_name"].ToString();
                }
            }

            for (int k = 0; k < row20.Length; k++)
            {
                if (str_salattr == row20[k]["salattr"].ToString())
                    aRow10["Fld" + (i + 1)] = row19[k]["sal_name"].ToString();
            }
        }
        Nds.Tables["zz42td1a"].Rows.Add(aRow0);
        Nds.Tables["zz42td2a"].Rows.Add(aRow1);
        Nds.Tables["zz42td3a"].Rows.Add(aRow10);

        DataRow aRow_dt1a = Nds.Tables["zz42td1_t"].NewRow();
        DataRow aRow_dt1b = Nds.Tables["zz42td2_t"].NewRow();
        DataRow aRow_dt2c = Nds.Tables["zz42td3_t"].NewRow();
        int _t1a = 1;
        int _t2a = 1;
        int _t3a = 1;

        for (int i = 0; i < Nds.Tables["zz42td2a"].Columns.Count; i++)
        {
            if (_t1a <= 15)
            {
                if (Nds.Tables["zz42td2a"].Rows[0]["Fld" + (i + 1)].ToString() == "1")
                {
                    aRow_dt1a["Fld" + _t1a] = 0;
                    aRow_dt1a["Fld" + _t1a] = Nds.Tables["zz42ta"].Rows[0]["Fld" + (i + 1)].ToString();
                    _t1a++;
                }
            }

            if (_t2a <= 15)
            {
                if (Nds.Tables["zz42td2a"].Rows[0]["Fld" + (i + 1)].ToString() == "2")
                {
                    aRow_dt1b["Fld" + _t2a] = 0;
                    aRow_dt1b["Fld" + _t2a] = Nds.Tables["zz42ta"].Rows[0]["Fld" + (i + 1)].ToString();
                    _t2a++;
                }
            }

            if (_t3a <= 15)
            {
                if (Nds.Tables["zz42td2a"].Rows[0]["Fld" + (i + 1)].ToString() == "3")
                {
                    aRow_dt2c["Fld" + _t3a] = 0;
                    aRow_dt2c["Fld" + _t3a] = Nds.Tables["zz42ta"].Rows[0]["Fld" + (i + 1)].ToString();
                    _t3a++;
                }
            }
        }

        Nds.Tables["zz42td1_t"].Rows.Add(aRow_dt1a);
        Nds.Tables["zz42td2_t"].Rows.Add(aRow_dt1b);
        Nds.Tables["zz42td3_t"].Rows.Add(aRow_dt2c);

        foreach (DataRow Row in Nds.Tables["zz42td"].Rows)
        {
            int _t1 = 1;
            int _t2 = 1;
            int _t3 = 1;

            DataRow aRow_dt = Nds.Tables["zz42td1"].NewRow();
            aRow_dt["nobr"] = Row["nobr"].ToString();

            DataRow aRow_dt1 = Nds.Tables["zz42td2"].NewRow();
            aRow_dt1["nobr"] = Row["nobr"].ToString();

            DataRow aRow_dt2 = Nds.Tables["zz42td3"].NewRow();
            aRow_dt2["nobr"] = Row["nobr"].ToString();

            for (int k = 1; k <= 20; k++)
            {
                aRow_dt["Fld" + k] = 0;
                aRow_dt1["Fld" + k] = 0;
                aRow_dt2["Fld" + k] = 0;
            }

            for (int i = 0; i < Nds.Tables["zz42td2a"].Columns.Count; i++)
            {
                if (_t1 <= 20)
                {
                    if (Nds.Tables["zz42td2a"].Rows[0]["Fld" + (i + 1)].ToString() == "1")
                    {
                        aRow_dt["Fld" + _t1] = decimal.Parse(Row["Fld" + (i + 1)].ToString());
                        _t1++;
                    }
                }

                if (_t2 <= 20)
                {
                    if (Nds.Tables["zz42td2a"].Rows[0]["Fld" + (i + 1)].ToString() == "2")
                    {
                        aRow_dt1["Fld" + _t2] = decimal.Parse(Row["Fld" + (i + 1)].ToString());
                        _t2++;
                    }
                }

                if (_t3 <= 20)
                {
                    if (Nds.Tables["zz42td2a"].Rows[0]["Fld" + (i + 1)].ToString() == "3")
                    {
                        aRow_dt2["Fld" + _t3] = decimal.Parse(Row["Fld" + (i + 1)].ToString());
                        _t3++;
                    }
                }
            }
            Nds.Tables["zz42td1"].Rows.Add(aRow_dt);
            Nds.Tables["zz42td2"].Rows.Add(aRow_dt1);
            Nds.Tables["zz42td3"].Rows.Add(aRow_dt2);
        }
        foreach (DataRow Row in Nds.Tables["zz42td"].Rows)
        {
            DataRow aRow = Nds.Tables["zz4219"].NewRow();
            aRow["nobr"] = Row["nobr"].ToString();
            aRow["name_c"] = Row["name_c"].ToString();
            aRow["dept"] = Row["dept"].ToString();
            aRow["d_name"] = Row["d_name"].ToString();
            aRow["account_no"] = Row["account_no"].ToString();
            aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
            aRow["wk_days"] = decimal.Parse(Row["wk_days"].ToString());
            aRow["rote"] = Row["rote"].ToString();
            aRow["rote_w"] = Row["rote_w"].ToString();
            aRow["holi_code"] = Row["holi_code"].ToString();
            aRow["count_ma"] = bool.Parse(Row["count_ma"].ToString());
            aRow["attdate_b"] = DateTime.Parse(Row["attdate_b"].ToString());
            aRow["attdate_e"] = DateTime.Parse(Row["attdate_e"].ToString());
            aRow["note"] = Row["note"].ToString();
            DataRow row2 = Nds.Tables["rq_bankwaged"].Rows.Find(Row["nobr"].ToString());
            if (row2 != null)
            {
                aRow["sal_name"] = row2["sal_name"].ToString();
                aRow["amt"] = decimal.Parse(row2["amt"].ToString());
            }
            else
            {
                aRow["sal_name"] = "";
                aRow["amt"] = 0;
            }

            DataRow[] row22 = Nds.Tables["rq_ret"].Select("nobr='" + Row["nobr"].ToString() + "'");
            if (row22.Length > 0)
            {
                aRow["retrate"] = decimal.Parse(row22[0]["retrate"].ToString());
                int c_amt = Convert.ToInt32(row22[0]["comp"]);
                aRow["comp"] = ENCODE(2, c_amt);
            }
            else
            {
                aRow["retrate"] = 0;
                aRow["comp"] = 0;
            }

            DataRow row23 = Nds.Tables["rq_ret1"].Rows.Find(Row["nobr"].ToString());
            if (row23 != null)
            {
                aRow["ret_amt"] = decimal.Parse(row23["amt"].ToString());
            }
            else
            {
                aRow["ret_amt"] = 0;
            }

            DataRow row24 = rq_ot.Rows.Find(Row["nobr"].ToString());
            if (row24 != null)
            {
                aRow["ot_100"] = decimal.Parse(row24["ot_100"].ToString());
                aRow["ot_133"] = decimal.Parse(row24["ot_133"].ToString());
                aRow["ot_167"] = decimal.Parse(row24["ot_167"].ToString());
                aRow["ot_200"] = decimal.Parse(row24["ot_200"].ToString());
                aRow["ot_200_h"] = decimal.Parse(row24["ot_200_h"].ToString());
            }
            else
            {
                aRow["ot_033"] = 0;
                aRow["ot_100"] = 0;
                aRow["ot_133"] = 0;
                aRow["ot_167"] = 0;
                aRow["ot_200"] = 0;
                aRow["ot_200_h"] = 0;
            }

            DataRow[] row25 = Nds.Tables["rq_wagefix"].Select("nobr='" + Row["nobr"].ToString() + "'");
            if (row25.Length > 0)
            {
                aRow["ot_hrs"] = decimal.Parse(row25[0]["ot_hrs"].ToString());
                aRow["abs_hrs"] = decimal.Parse(row25[0]["abs_hrs"].ToString());
            }
            else
            {
                aRow["ot_hrs"] = 0;
                aRow["abs_hrs"] = 0;
            }

            DataRow row26 = Nds.Tables["rq_rest1"].Rows.Find(Row["nobr"].ToString());
            if (row26 != null)
                aRow["tol_day"] = decimal.Parse(row26["tol_day"].ToString());
            else
                aRow["tol_day"] = 0;

            DataRow row27 = Nds.Tables["rq_rest2"].Rows.Find(Row["nobr"].ToString());
            if (row27 != null)
                aRow["tol_hours"] = decimal.Parse(row27["tol_hours"].ToString());
            else
                aRow["tol_hours"] = 0;

            DataRow row28 = Nds.Tables["rq_rest3"].Rows.Find(Row["nobr"].ToString());
            if (row28 != null)
                aRow["tol_day2"] = decimal.Parse(row28["tol_day"].ToString());
            else
                aRow["tol_day2"] = 0;

            DataRow row29 = Nds.Tables["zz4215tb"].Rows.Find(Row["nobr"].ToString());
            if (row29 != null)
            {
                for (int i = 1; i <= 8; i++)
                {
                    aRow["tb_Fld" + i] = decimal.Parse(row29["Fld" + i].ToString());
                }
            }
            else
            {
                for (int i = 1; i <= 8; i++)
                {
                    aRow["tb_Fld" + i] = 0;
                }
            }

            DataRow row30 = Nds.Tables["zz42td1"].Rows.Find(Row["nobr"].ToString());
            if (row30 != null)
            {
                for (int i = 1; i <= 20; i++)
                {
                    aRow["td1_Fld" + i] = 0;
                    aRow["td1_Fld" + i] = decimal.Parse(row30["Fld" + i].ToString());
                }
            }
            else
            {
                for (int i = 1; i <= 20; i++)
                {
                    aRow["td1_Fld" + i] = 0;
                }
            }

            DataRow row31 = Nds.Tables["zz42td2"].Rows.Find(Row["nobr"].ToString());
            if (row31 != null)
            {
                for (int i = 1; i <= 20; i++)
                {
                    aRow["td2_Fld" + i] = 0;
                    aRow["td2_Fld" + i] = decimal.Parse(row31["Fld" + i].ToString());
                }
            }
            else
            {
                for (int i = 1; i <= 20; i++)
                {
                    aRow["td2_Fld"] = 0;
                }
            }

            DataRow row32 = Nds.Tables["zz42td3"].Rows.Find(Row["nobr"].ToString());
            if (row32 != null)
            {
                for (int i = 1; i <= 20; i++)
                {
                    aRow["td3_Fld" + i] = 0;
                    aRow["td3_Fld" + i] = decimal.Parse(row32["Fld" + i].ToString());
                }
            }
            else
            {
                for (int i = 1; i <= 20; i++)
                {
                    aRow["td3_Fld" + i] = 0;
                }
            }

            aRow["4219b_amt"] = 0;
            DataRow row33 = Nds.Tables["zz4219b"].Rows.Find(Row["nobr"].ToString());
            if (row33 != null)
            {
                decimal ssd = decimal.Parse(row33["amt"].ToString());
                aRow["4219b_amt"] = decimal.Parse(row33["amt"].ToString());
            }

            DataRow row34 = rq_salbasd1.Rows.Find(Row["nobr"].ToString());
            if (row34 != null)
                aRow["appsalary"] = int.Parse(row34["amt"].ToString());

            DataRow row35 = rq_sala.Rows.Find(Row["nobr"].ToString());
            if (row35 != null)
                aRow["desalary"] = int.Parse(row35["amt"].ToString());

            DataRow row36 = rq_ysalary.Rows.Find(Row["nobr"].ToString());
            if (row36 != null)
                aRow["ysalary"] = int.Parse(row36["amt"].ToString());

            DataRow row37 = rq_ytax.Rows.Find(Row["nobr"].ToString());
            if (row37 != null)
                aRow["ytax"] = int.Parse(row37["amt"].ToString());
            else
                aRow["ytax"] = 0;

            DataRow row38 = rq_yret.Rows.Find(Row["nobr"].ToString());
            if (row38 != null)
                aRow["yret"] = int.Parse(row38["amt"].ToString());

            DataRow row39 = rq_yretcomp.Rows.Find(Row["nobr"].ToString());
            if (row39 != null)
                aRow["yretcomp"] = int.Parse(row39["comp"].ToString());
            Nds.Tables["zz4219"].Rows.Add(aRow);
        }
        Session.Add("Rds", Nds);
        rq_ot = null; rq_ota = null;
        Cr_zz42.Visible = true;
        CrystalReportSource1.ReportDocument.Load(Server.MapPath("rpt_zz42a.rpt"));
        if (_retchoo && _ot)
            CrystalReportSource1.ReportDocument.Load(Server.MapPath("rpt_zz42d.rpt"));
        else if (_ot)
            CrystalReportSource1.ReportDocument.Load(Server.MapPath("rpt_zz42c.rpt"));
        else if (_retchoo)
            CrystalReportSource1.ReportDocument.Load(Server.MapPath("rpt_zz42b.rpt"));
        
            
        CrystalReportSource1.ReportDocument.SetDataSource(Session["Rds"]);
        //GridView1.DataSource = Nds.Tables["zz42"];
        //GridView1.DataBind();
        Panel1.Visible = false;

    }

    private int ENCODE(int ENCODE_TYPE, int VALT)
    {
        string LCFLAG = (VALT < 0) ? "-" : "+";
        VALT = Math.Abs(VALT);
        string VALSTR = VALT.ToString().Trim();
        string STR1 = "3761532470658472653034873";
        string LL = "";
        int VALLEN = 0;
        int STARTPOS = 0;
        switch (ENCODE_TYPE)
        {
            case 1:
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
                break;
            case 2:
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
                break;
        }
        if (LL.Length == 0) LL = "0";
        LL = LCFLAG + LL;
        return int.Parse(LL);
    }
    protected void CrystalReportSource1_Unload(object sender, EventArgs e)
    {
        CrystalReportSource1.ReportDocument.Dispose();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateSalaryPW.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmpSalary.aspx");
    }
}
