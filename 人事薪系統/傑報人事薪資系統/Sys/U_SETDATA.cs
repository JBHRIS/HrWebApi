using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sys
{
    public partial class U_SETDATA : JBControls.JBForm
    {
        public U_SETDATA()
        {
            InitializeComponent();
        }

        private void U_SETDATA_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'mainDS.DEPT' 資料表。您可以視需要進行移動或移除。
            this.dEPTTableAdapter.Fill(this.sysDS.DEPT);
            // TODO: 這行程式碼會將資料載入 'mainDS.U_USER' 資料表。您可以視需要進行移動或移除。
            //if (MainForm.MANGSUPER)
            //{
            //    this.u_USERTableAdapter.FillByNOTSUPER(this.sysDS.U_USER, MainForm.SYSTEM);
            //}
            //else
            //{
            this.u_USERTableAdapter.FillByNOTSUPER_WORKADR(this.sysDS.U_USER, MainForm.SYSTEM, MainForm.COMPANY, MainForm.USER_ID);
            //}
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                //// TODO: 這行程式碼會將資料載入 'mainDS.U_DATAID' 資料表。您可以視需要進行移動或移除。
                //if (MainForm.MANGSUPER)
                //{
                //    this.u_DATAIDTableAdapter.FillByUSERID(this.sysDS.U_DATAID, (uUSERBindingSource.Current as DataRowView)["USER_ID"].ToString(), MainForm.SYSTEM);
                //}
                //else
                //{
                //this.u_DATAIDTableAdapter.FillByUSERID_WORKADR(this.sysDS.U_DATAID, (uUSERBindingSource.Current as DataRowView)["USER_ID"].ToString(), MainForm.WORKADR, MainForm.SYSTEM);
                //}
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                // TODO: 這行程式碼會將資料載入 'mainDS.U_DATAID' 資料表。您可以視需要進行移動或移除。
                //if (MainForm.MANGSUPER)
                //{
                this.u_DATAIDTableAdapter.FillByDEPT(this.sysDS.U_DATAID, (dEPTBindingSource.Current as DataRowView)["D_NO"].ToString(), MainForm.SYSTEM);
                //}
                //else
                //{
                //    this.u_DATAIDTableAdapter.FillByDEPT_WORKADR(this.sysDS.U_DATAID, (dEPTBindingSource.Current as DataRowView)["D_NO"].ToString(), MainForm.WORKADR, MainForm.SYSTEM);
                //}
            }
        }

        private void uUSERBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {


                this.u_DATAIDTableAdapter.FillByUSERID(this.sysDS.U_DATAID, (uUSERBindingSource.Current as DataRowView)["USER_ID"].ToString(), MainForm.SYSTEM);

            }
        }

        private void dEPTBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                // TODO: 這行程式碼會將資料載入 'mainDS.U_DATAID' 資料表。您可以視需要進行移動或移除。
                //if (MainForm.MANGSUPER)
                //{
                //    this.u_DATAIDTableAdapter.FillByDEPT(this.sysDS.U_DATAID, (dEPTBindingSource.Current as DataRowView)["D_NO"].ToString(), MainForm.SYSTEM);
                //}
                //else
                //{
                //    this.u_DATAIDTableAdapter.FillByDEPT_WORKADR(this.sysDS.U_DATAID, (dEPTBindingSource.Current as DataRowView)["D_NO"].ToString(), MainForm.WORKADR, MainForm.SYSTEM);
                //}
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sys.SysDS.U_DATAIDRow U_DATAIDRow = (uDATAIDBindingSource.Current as DataRowView).Row as Sys.SysDS.U_DATAIDRow;

            if (!MainForm.PROCSUPER)
            {
                CUser user = new CUser(U_DATAIDRow.USER_ID);
                //if (user.WORKADR != MainForm.WORKADR)
                //{
                //    MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
            }

            if (MessageBox.Show(Resources.All.DeleteConfirm, Resources.All.DialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                (uDATAIDBindingSource.Current as DataRowView).Delete();
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, sysDS.U_DATAID);
                u_DATAIDTableAdapter.Update(sysDS.U_DATAID);

                if (dataGridViewEx3.CurrentRow != null) dataGridViewEx3.CurrentRow.Selected = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sys.SysDS.U_USERRow U_USERRow = (uUSERBindingSource.Current as DataRowView).Row as Sys.SysDS.U_USERRow;
            //if (!MainForm.PROCSUPER)
            //{
            //    if (U_USERRow.WORKADR != MainForm.WORKADR)
            //    {
            //        MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}

            Sys.SysDS.DEPTRow DEPTRow = (dEPTBindingSource.Current as DataRowView).Row as Sys.SysDS.DEPTRow;

            uDATAIDBindingSource.AddNew();
            Sys.SysDS.U_DATAIDRow U_DATAIDRow = (uDATAIDBindingSource.Current as DataRowView).Row as Sys.SysDS.U_DATAIDRow;
            (uDATAIDBindingSource.Current as DataRowView).BeginEdit();
            U_DATAIDRow.USER_ID = U_USERRow.USER_ID.Trim();
            U_DATAIDRow.DEPT = DEPTRow.D_NO.Trim();
            U_DATAIDRow.SYSTEM = U_USERRow.SYSTEM.Trim();
            U_DATAIDRow.KEY_MAN = MainForm.USER_NAME;
            U_DATAIDRow.KEY_DATE = DateTime.Now;
            (uDATAIDBindingSource.Current as DataRowView).EndEdit();

            try
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, sysDS.U_DATAID);
                u_DATAIDTableAdapter.Update(sysDS.U_DATAID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.All.SaveError + "\n\n" + Resources.All.ExceptionStr1 + "\n" + ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridViewEx3_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
