using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JBHR.HopaxCustom
{
    public partial class HPX_Point_Mgt_ADD : JBControls.JBForm
    {
        public HPX_Point_Mgt_ADD()
        {
            InitializeComponent();
        }
        public int sno = -1;
        HPX_WebService.HPXPointDto instance = null;
        CheckControl cc;//必填欄位
        public HPX_WebService.ServiceClient client = null;
        bool CheckNobr = false;
        JBModule.Data.ApplicationConfigSettings acg = new JBModule.Data.ApplicationConfigSettings("HPX_Point_Mgt", MainForm.COMPANY);
        private void HPX_Point_Mgt_ADD_Load(object sender, EventArgs e)
        {
            CheckNobr = acg.GetConfig("CheckNobr").Value.ToUpper() == "TRUE" ? true : false;
            // TODO: 這行程式碼會將資料載入 'dsBas.BASE' 資料表。您可以視需要進行移動或移除。
            this.bASETableAdapter.Fill(this.dsBas.BASE);
            Dictionary<string, string> YesNo = new Dictionary<string, string>();
            YesNo.Add("Y", "是");
            YesNo.Add("N", "否");
            SystemFunction.SetComboBoxItems(cbxLeader, YesNo, false, true, true);
            SystemFunction.SetComboBoxItems(cbxPerson_Join, YesNo, false, true, true);
            cc = new CheckControl();
            cc.AddControl(txtActivity_Name);
            cc.AddControl(txtEmployee_Name);

            if (sno == -1)
            {
                instance = new HPX_WebService.HPXPointDto()
                {
                    ActivityName = string.Empty,
                    EmployeeName = string.Empty,
                    EmployeeNo = string.Empty,
                    Leader = "N",
                    PersonJoin = "Y",
                    RelativesCount = 0,
                    GetPoint = 10,
                    UsePoint = 0,
                    UseDate = null,
                    RemainingPoint = 10,
                    BookUser = string.Empty,
                    Remark = string.Empty,
                    CreatedBy = MainForm.USER_NAME,
                    CreationDate = DateTime.Now,
                    LastUpdatedBy = MainForm.USER_NAME,
                    LastUpdateDate = DateTime.Now,
                };
            }
            else
            {
                txtActivity_Name.Enabled = false;
                //txtEmployee_Name.Enabled = false;
                instance = client.GetHPXPointBySno(sno).Result;
            }

            if (instance == null)
            {
                MessageBox.Show("查無資料", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            txtActivity_Name.Text = instance.ActivityName;
            txtEmployee_Name.Text = instance.EmployeeName;
            ptxEmployee.Text = instance.EmployeeNo;
            cbxLeader.SelectedValue = instance.Leader;
            cbxPerson_Join.SelectedValue = instance.PersonJoin;
            txtRelatives_Count.Text = instance.RelativesCount.ToString();
            txtGet_Point.Text = instance.GetPoint.ToString();
            txtUse_Point.Text = instance.UsePoint.ToString();
            dtpUse_Date.Text = instance.UseDate != null ? instance.UseDate.Value.ToString() : null;
            txtRemaining_Point.Text = instance.RemainingPoint.ToString();
            txtBook_User.Text = instance.BookUser;
            txtMemo.Text = instance.Remark;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var ctrl = cc.CheckText();//必要欄位檢查
            if (ctrl != null)//必要欄位檢查
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            HPX_WebService.HPXPointDto hPXPointDto = new HPX_WebService.HPXPointDto()
            {
                Sno = sno,
                ActivityName = txtActivity_Name.Text,
                EmployeeName = txtEmployee_Name.Text,
                EmployeeNo = ptxEmployee.Text,
                Leader = cbxLeader.SelectedValue.ToString(),
                PersonJoin = cbxPerson_Join.SelectedValue.ToString(),
                RelativesCount = Convert.ToInt32(txtRelatives_Count.Text),
                GetPoint = Convert.ToInt32(txtGet_Point.Text),
                UsePoint = Convert.ToInt32(txtUse_Point.Text),
                UseDate = dtpUse_Date.Text != null ? (DateTime?)Convert.ToDateTime(dtpUse_Date.Text) : null,
                RemainingPoint = Convert.ToInt32(txtRemaining_Point.Text),
                BookUser = txtBook_User.Text,
                Remark = txtMemo.Text,
                CreatedBy = MainForm.USER_NAME,
                CreationDate = DateTime.Now,
                LastUpdatedBy = MainForm.USER_NAME,
                LastUpdateDate = DateTime.Now,
            };

            if (sno == -1)
                client.InsertHPXPoint(hPXPointDto);
            else
                client.UpdateHPXPoint(hPXPointDto);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ptxEmployee_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ptxEmployee.Text) && this.dsBas.BASE.FindByNOBR(ptxEmployee.Text) != null)
            {
                txtEmployee_Name.Text = this.dsBas.BASE.FindByNOBR(ptxEmployee.Text).NAME_C;
                if (!string.IsNullOrWhiteSpace(txtEmployee_Name.Text))
                {
                    if (CheckNobr && this.dsBas.BASE.FindByNOBR(ptxEmployee.Text) != null && this.dsBas.BASE.FindByNOBR(ptxEmployee.Text).NAME_C != txtEmployee_Name.Text)
                    {
                        MessageBox.Show("此參與人員與此工號姓名不符!", "人員姓名不符", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEmployee_Name.Focus();
                    }
                }
            }
        }

        private void txtRelatives_Count_Leave(object sender, EventArgs e)
        {
            CalGetPoint();
        }

        private void cbxLeader_DropDownClosed(object sender, EventArgs e)
        {
            CalGetPoint();
        }

        private void cbxPerson_Join_DropDownClosed(object sender, EventArgs e)
        {
            CalGetPoint();
        }

        private void CalGetPoint()
        {
            HPX_WebService.HPXPointDto hPXPointDto = new HPX_WebService.HPXPointDto()
            {
                ActivityName = txtActivity_Name.Text,
                EmployeeName = txtEmployee_Name.Text,
                EmployeeNo = ptxEmployee.Text,
                Leader = cbxLeader.SelectedValue.ToString(),
                PersonJoin = cbxPerson_Join.SelectedValue.ToString(),
                RelativesCount = Convert.ToInt32(txtRelatives_Count.Text),
                GetPoint = Convert.ToInt32(txtGet_Point.Text),
                UsePoint = Convert.ToInt32(txtUse_Point.Text),
                UseDate = DateTime.Now.Date,
                RemainingPoint = Convert.ToInt32(txtRemaining_Point.Text),
                BookUser = txtBook_User.Text,
                Remark = txtMemo.Text,
                CreatedBy = MainForm.USER_NAME,
                CreationDate = DateTime.Now,
                LastUpdatedBy = MainForm.USER_NAME,
                LastUpdateDate = DateTime.Now,
            };
            int get_point = client.CalHPXPoint(hPXPointDto).Result;
            int use_point = Convert.ToInt32(txtUse_Point.Text);
            txtGet_Point.Text = get_point.ToString();

            if (get_point >= use_point)
            {
                txtRemaining_Point.Text = (get_point - use_point).ToString();
            }
            else
            {
                MessageBox.Show("點數不足，請確認點數是否正常!", "獲得點數不足", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRemaining_Point.Text = txtGet_Point.Text;
                txtUse_Point.Text = "0";
                txtUse_Point.Focus();
            }
        }

        private void txtUse_Point_Leave(object sender, EventArgs e)
        {
            CalGetPoint();
        }
    }
}
