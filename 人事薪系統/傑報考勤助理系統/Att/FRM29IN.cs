using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Att
{
    public partial class FRM29IN : JBControls.JBForm
    {

        bool canReaptF = false;
        //JBHR.ImportC.ImportGen _OTC = new JBHR.ImportC.OTC();
        JBHR.ImportC.ImportGen _OTC = new JBHR.ImportC.OT.OTC1();
        public FRM29IN()
        {
            InitializeComponent();
        }

        private void bnUp1_Click(object sender, EventArgs e)
        {
            String newPath = _OTC.openFile(this.comboBoxSheet, textBoxUpName1.Text);
            if (!textBoxUpName1.Text.Equals(newPath))
            {
                textBoxUpName1.Text = newPath;
                try
                {
                    while (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Rows.RemoveAt(0);
                    }
                }
                catch (InvalidOperationException ioe)
                {

                }
                lbTotal.Text = "0";
                lbImport.Text = "0";
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            _OTC.openPreviewForm("加班匯入", null);
        }

        private void comboBoxSheet_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<ComboBox> list = new List<ComboBox>();
            list.Add(this.cbxNOBR);
            list.Add(this.cbxName_C);
            list.Add(this.cbxBDATE);
            list.Add(this.cbxBTIME);
            list.Add(this.cbxETIME);
            list.Add(this.cbxOTType);
            list.Add(this.cbxTOT_HOURS);
            list.Add(this.cbxTOT_HOURS_M);
            list.Add(this.cbxNOTE);
            list.Add(this.cbxYYMM);
            //list.Add(this.cbxApprove);
            list.Add(this.cbxCode);
            list.Add(this.cbxMeal);
            list.Add(this.cbxDeptName);
            cbxApprove.Items.Clear();
            this.cbxApprove.Items.Add("否");
            this.cbxApprove.Items.Add("是");
            _OTC.setExcelTable(comboBoxSheet.Text);
            _OTC.setCBXItem(list);

        }
        private void cmdImport_Click(object sender, EventArgs e)
        {


            if (cbxApprove.Text.Equals("是"))
            {
                canReaptF = true;
            }
            else
            {
                canReaptF = false;
            }


            Dictionary<string, string> dic = new Dictionary<string, string>();

            if (cbxNOBR.Text.Length != 0
                && cbxName_C.Text.Length != 0
                && cbxBDATE.Text.Length != 0
                && cbxBTIME.Text.Length != 0
                && cbxETIME.Text.Length != 0
                && cbxOTType.Text.Length != 0
                && cbxTOT_HOURS.Text.Length != 0
                && cbxYYMM.Text.Length != 0
                && cbxNOTE.Text.Length != 0
                && cbxDeptName.Text.Length != 0
                )
            {
                dic.Add("NOBR", cbxNOBR.Text);
                dic.Add("NAME_C", cbxName_C.Text);
                dic.Add("BDATE", cbxBDATE.Text);
                dic.Add("BTIME", cbxBTIME.Text);
                dic.Add("ETIME", cbxETIME.Text);
                dic.Add("OTType", cbxOTType.Text);
                //dic.Add("CODE", cbxCode.Text);
                dic.Add("TOT_HOURS", cbxTOT_HOURS.Text);
                dic.Add("YYMM", cbxYYMM.Text);
                dic.Add("NOTE", cbxNOTE.Text);
                dic.Add("DEPTNAME", cbxDeptName.Text);
            }
            else
            {
                MessageBox.Show(new Form() { TopMost = true, TopLevel = true }, "必填欄位不能為空");
                return;
            }

            if (cbxApprove.Text.Length != 0) dic.Add("Approve", cbxApprove.Text);
            else dic.Add("Approve", "");
            //if (cbxYYMM.Text.Length != 0) dic.Add("YYMM", cbxYYMM.Text);
            //else dic.Add("YYMM", "");
            //if (cbxName_C.Text.Length != 0) dic.Add("NAME_C", cbxName_C.Text);
            //else dic.Add("NAME_C", "");
            //if (cbxTOT_HOURS.Text.Length != 0) dic.Add("TOT_HOURS", cbxTOT_HOURS.Text);
            //else dic.Add("TOT_HOURS", "");
            //if (cbxTOT_HOURS_M.Text.Length != 0) dic.Add("TOT_HOURS_M", cbxTOT_HOURS_M.Text);
            //else dic.Add("TOT_HOURS_M", "");
            //if (cbxNOTE.Text.Length != 0) dic.Add("NOTE", cbxNOTE.Text);
            //else dic.Add("NOTE", "");
            if (cbxCode.Text.Length != 0) dic.Add("CODE", cbxCode.Text);
            else dic.Add("CODE", "");
            if (cbxMeal.Text.Length != 0) dic.Add("Meal", cbxMeal.Text);
            else dic.Add("Meal", "");
            //if (cbxETIME.Text.Length != 0) dic.Add("ETIME", cbxETIME.Text);
            //else dic.Add("ETIME", "");
            //if (cbxBTIME.Text.Length != 0) dic.Add("BTIME", cbxBTIME.Text);
            //else dic.Add("BTIME", "");
            //if (cbxOTType.Text.Length != 0) dic.Add("OTType", cbxOTType.Text);
            //else dic.Add("OTType", "");


            this.ProcessBar1.Visible = true;
            dataGridView1.DataSource = _OTC.ceateRoteChgTable(dic, this.ProcessBar1);
            this.ProcessBar1.Visible = false;

            setVisiable(dataGridView1);


            lbTotal.Text = (dataGridView1.RowCount - 1).ToString();

        }
        private void button3_Click(object sender, EventArgs e)
        {

            String fileN = _OTC.FileName.Substring(_OTC.FileName.LastIndexOf("\\") + 1, _OTC.FileName.Length - _OTC.FileName.LastIndexOf("\\") - 1);

            //if (canReaptF)
            //    if (MessageBox.Show(new Form() { TopMost = true, TopLevel = true },"確定可以重複將 : " + fileN + "，存入加班資料?", "Confirm RepeatOT", MessageBoxButtons.YesNo) == DialogResult.No)
            //    {
            //        return;
            //    }


            this.ProcessBar1.Visible = true;
            lbImport.Text = _OTC.insertRoteChg(this.dataGridView1, this.ProcessBar1).ToString();
            this.ProcessBar1.Visible = false;
            //try
            //{
            //    while (dataGridView1.Rows.Count > 0)
            //    {
            //        dataGridView1.Rows.RemoveAt(0);
            //    }
            //}
            //catch (InvalidOperationException ioe)
            //{

            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbTotal.Text = "0";
            lbImport.Text = "0";

            try
            {
                while (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.RemoveAt(0);
                }
            }
            catch (InvalidOperationException ioe)
            {

            }
        }

        public void setVisiable(DataGridView DGW)
        {
            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                item.Visible = false;
            }
            DGW.Columns["員工編號"].Visible = true;
            DGW.Columns["員工姓名"].Visible = true;
            DGW.Columns["加班部門"].Visible = true;
            DGW.Columns["部門名稱"].Visible = true;
            DGW.Columns["加班日期"].Visible = true;
            DGW.Columns["加起時間"].Visible = true;
            DGW.Columns["加迄時間"].Visible = true;
            DGW.Columns["總時數"].Visible = true;
            DGW.Columns["加班時數"].Visible = true;
            DGW.Columns["補休時數"].Visible = true;
            DGW.Columns["計薪年月"].Visible = true;
            DGW.Columns["誤餐費"].Visible = true;
            DGW.Columns["加班原因"].Visible = true;
            DGW.Columns["備註"].Visible = true;
            DGW.Columns["OTNO"].Visible = true;
            //DGW.Columns["加班部門"].Visible = true;

        }
    }
}
