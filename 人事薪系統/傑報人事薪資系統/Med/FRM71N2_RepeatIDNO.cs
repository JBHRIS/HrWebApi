using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Med
{
    public partial class FRM71N2_RepeatIDNO : JBControls.JBForm
    {
        public FRM71N2_RepeatIDNO()
        {
            InitializeComponent();
        }
        public string COMP = string.Empty;
        public string COMPNAME = string.Empty;
        public string IDNO = string.Empty;
        public List<string> NOBRList = new List<string>();
        public List<JBModule.Data.Linq.TBASE> TBASEs = new List<JBModule.Data.Linq.TBASE>();
        public string rpNOBR = string.Empty;
        private void FRM71N2_RepeatIDNO_Load(object sender, EventArgs e)
        {
            this.Text = String.Format("{0}-資料合併作業", this.Name);
            txtCOMP.Text = COMPNAME;
            txtIDNO.Text = IDNO;
            dgv.DataSource = (from a in TBASEs
                              select new
                              {
                                  內部員工 = a.INCOMP,
                                  所得人編號 = a.NOBR,
                                  所得人姓名 = a.NAME_C,
                                  地址 = a.ADDR,
                                  電話 = a.TEL,
                                  行動電話 = a.GSM,
                                  EMail = a.EMAIL,
                                  a.POSTCODE1,
                                  a.POSTCODE2,
                                  登錄者 = a.KEY_MAN,
                                  登錄日期 = a.KEY_DATE,
                              }).ToList();
        }

        private void btnIgnore_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var row = dgv.CurrentRow;
            rpNOBR = row.Cells["所得人編號"].Value.ToString();
            this.Close();
        }
    }
}
