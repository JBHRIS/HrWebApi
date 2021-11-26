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
    public partial class FRM2CIS : JBControls.JBForm
    {
         public FRM2CIS()
        {
            InitializeComponent();
        }
         public DataTable setExcel{
         set{
             ////value.DefaultView.Sort = String.Empty;
             dgvExcelView.DataSource = value;
             setSort();
            }
         }
         public List<int> setRepeatIndex
         {
             set;
             get;
         }
         public int setlbTotal {
             set {
                 lbTotal.Text = value.ToString(); ;
             }
         }
         public String setTitle {
             set {
                 this.Text = value;
             }
         }
         private void btnConfirm_Click(object sender, EventArgs e)
         {
             this.Close();
         }
         private void setSort() {
             foreach (DataGridViewColumn item in dgvExcelView.Columns)
             {
                 item.SortMode = DataGridViewColumnSortMode.NotSortable;
             }         
         }
         private void btnShowRepeat_Click(object sender, EventArgs e)
         {
             List<int> listTemp = setRepeatIndex;
             try
             {
                 foreach (var item in listTemp)
                 {
                     dgvExcelView.Rows[item].DefaultCellStyle.BackColor = Color.Pink;
                 }
             }
             catch (NullReferenceException nre) { 
             
             
             }
            


         }
    }
}
