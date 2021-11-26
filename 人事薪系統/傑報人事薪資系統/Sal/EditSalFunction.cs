using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JBHR.Sal
{
    public partial class EditSalFunction : Form
    {
        public EditSalFunction(string calcType)
        {
            InitializeComponent();
            this.CalcType = calcType;
        }
        public string CalcType;
        private void EditSalFunction_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'johnnyDBDataSet.MTCODE' 資料表。您可以視需要進行移動或移除。
            this.mTCODETableAdapter.FillByCategory(this.mainDS.MTCODE, "CALC_TYPE");
            // TODO: 這行程式碼會將資料載入 'johnnyDBDataSet.SALFUNCTION' 資料表。您可以視需要進行移動或移除。
            this.sALFUNCTIONTableAdapter.FillByCalcType(this.salaryDS.SALFUNCTION, this.CalcType);

        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            sALFUNCTIONTableAdapter.Update(this.salaryDS.SALFUNCTION);
        }

        private void btnCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dataGridView1.CurrentRow.Cells["SCRIPT"].Value = "";
            dataGridView1.CurrentRow.Cells["CALCTYPE"].Value = this.CalcType;
            dataGridView1.CurrentRow.Cells["ITEM"].Selected = true;
            dataGridView1.CurrentRow.Cells["SORT"].Value = "0";
            dataGridView1.CurrentRow.Cells["CALC"].Value = true;
            dataGridView1.CurrentRow.Cells["REF"].Value = false;
            var sql = this.salaryDS.SALFUNCTION.Where(p => p.CALCTYPE == this.CalcType).OrderByDescending(q => q.SORT).FirstOrDefault();
            if (sql != null)
                dataGridView1.CurrentRow.Cells["SORT"].Value = (sql.SORT + 1).ToString();
        }
    }
}
