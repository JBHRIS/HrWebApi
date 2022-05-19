using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Wel
{
    public partial class FRM63N1_IMPORT : JBControls.U_FIELD
    {
        int RowIndex = 6;
        JBModule.Data.ApplicationConfigSettings acg = new JBModule.Data.ApplicationConfigSettings("FRM63N1", MainForm.COMPANY);
        CheckControl cc;//必填欄位
        public FRM63N1_IMPORT()
        {
            InitializeComponent();
            BindingControls.Add(cbAmt);
            BindingControls.Add(cbxMemo);
            BindingControls.Add(cbxNobr);
            BindingControls.Add(cbxComp);
            BindingControls.Add(cbxFormat);
            BindingControls.Add(cbxSubcode);
            BindingControls.Add(cbxD_Amt);
            BindingControls.Add(cbxRet_Amt);
            BindingControls.Add(cbxSup_Amt);
            BindingControls.Add(cbxTAXNO);
            BindingControls.Add(cbxYymm);
            BindingControls.Add(cbxSeq);
            BindingControls.Add(cbxNote1);
            BindingControls.Add(cbxNote2);

            bool Note1Enable = acg.GetConfig("Note1Enable").Value.ToUpper() == "TRUE" ? true : false;
            bool Note2Enable = acg.GetConfig("Note2Enable").Value.ToUpper() == "TRUE" ? true : false;
            if (!(Note1Enable || Note2Enable))
            {
                lbNote1.Visible = Note1Enable;
                lbNote2.Visible = Note2Enable;
                cbxNote1.Visible = Note1Enable;
                cbxNote1.Enabled = Note1Enable;
                cbxNote2.Visible = Note2Enable;
                cbxNote2.Enabled = Note2Enable;
                float percent = 100f / tableLayoutPanel1.RowStyles.Count;
                for (int i = 0; i < tableLayoutPanel1.RowStyles.Count; i++)
                {
                    if (i != RowIndex)
                        tableLayoutPanel1.RowStyles[i].Height = percent;
                    else
                        tableLayoutPanel1.RowStyles[i].Height = 0;
                }
                this.Size = new Size(this.Size.Width, tableLayoutPanel1.Size.Height + 20);
            }
            else
            {
                if (Note1Enable)
                {
                    string Note1Label = acg.GetConfig("Note1Label").Value;
                    lbNote1.Text = Note1Label;
                    cbxNote1.Tag = Note1Label;
                }
                if (Note2Enable)
                {
                    string Note2Label = acg.GetConfig("Note2Label").Value;
                    lbNote2.Text = Note2Label;
                    cbxNote2.Tag = Note2Label;
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var ctrl = cc.CheckText();//必要欄位檢查
            if (ctrl != null)//必要欄位檢查
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            CombinationData = new DataTable();
            foreach (var it in BindingControls)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = it.Tag.ToString();
                CombinationData.Columns.Add(dc);
            }

            //var adate = Convert.ToDateTime(txtAdate.Text);
            foreach (DataRow r in Source.Rows)
            {
                DataRow ri = CombinationData.NewRow();
                SetBindingData(ri, r);
                CombinationData.Rows.Add(ri);
            }
            this.Close();
        }

        private void FRM63N1_IMPORT_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxNobr);
            cc.AddControl(cbxYymm);
            cc.AddControl(cbxSeq);
            cc.AddControl(cbxComp);
            cc.AddControl(cbxFormat);
            cc.AddControl(cbxSubcode);
            cc.AddControl(cbxD_Amt);
            cc.AddControl(cbAmt);
        }
    }
}
