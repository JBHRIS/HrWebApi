using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sal
{
    public partial class FRM4RA : JBControls.JBForm
    {
        public Att.Vdb.EmployeeLeaveSettlementVdb vdb;
        public Att.Controller.EmployeeLeaveSettlementController controller;
        public List<string> selectedEmps;
        public FRM4RA()
        {
            InitializeComponent();
        }

        private void FRM4RA_Load(object sender, EventArgs e)
        {
            Core.SalaryDate sd = new Core.SalaryDate(DateTime.Today);
            txtYYMM.Text = sd.YYMM;
            txtSEQ.Text = "2";
            var data = controller.GenerateEmployeeLeaveInfoList(vdb.OutEmployeeInfoList.Where(p => selectedEmps.Contains(p.EmployeeId)).ToList());
            dataGridView1.DataSource = data.Select(p => new { 員工編號 = p.EmployeeId, 員工姓名 = p.EmployeeName, 離職日期 = p.OutDate, 參考薪資 = p.BaseSalary, 伙食津貼 = p.FoodSalary, 特休剩餘時數 = p.SpecialLeaveHours, 補休剩餘時數 = p.CompensatedLeaveHours, 彈休剩餘時數 = p.OptionalLeaveHours, 特休代金 = p.SpecialLeaveBonus, 補休代金 = p.CompensatedLeaveBonus, 彈休代金 = p.OptionalLeaveBonus }).CopyToDataTable();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (dataGridView1.DataSource) as DataTable;
                DataView dv = dt.AsDataView();
                JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + "加班費用明細" + ".xls");
                //var ds = new DataSet();
                //ds.Tables.Add(dt);
                //JBModule.Data.CNPOI.SaveDataSetToExcel(ds, "C:\\TEMP\\" + "加班費用明細" + ".xls");
                System.Diagnostics.Process.Start("C:\\TEMP\\" + "加班費用明細" + ".xls");
            }
            catch
            {
                MessageBox.Show(Resources.Sal.ExportError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定要將上述資料轉換成代金?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.OK)
            {
                int i = controller.GenerateLeaveToBonus(controller._vdb.EmployeeLeaveInfoList, txtYYMM.Text, txtSEQ.Text);
                MessageBox.Show("完成!!共寫入" + i.ToString() + "筆資料");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
