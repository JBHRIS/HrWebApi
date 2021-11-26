using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace JBHR.HopaxCustom
{
    public partial class HPX_Plate_Mgt_ADD : JBControls.JBForm
    {
        public HPX_Plate_Mgt_ADD()
        {
            InitializeComponent();
        }
        public int sno = -1;
        HPX_WebService.HPXPlateDto instance = null;
        CheckControl cc;//必填欄位
        public HPX_WebService.ServiceClient client = null;
        private void HPX_Plate_Mgt_ADD_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'dsBas.BASE' 資料表。您可以視需要進行移動或移除。
            this.bASETableAdapter.Fill(this.dsBas.BASE);

            cc = new CheckControl();
            cc.AddControl(ptxEmployee);
            cc.AddControl(cbxVehicle_Type);

            HPX_WebService.MtcodeDto[] mtcodes = client.GetHPXPlateVehicleType().Result;
            SystemFunction.SetComboBoxItems(cbxVehicle_Type, mtcodes.Select(p => new { Key = p.CODE, Value = p.NAME }).AsEnumerable().ToDictionary(p => p.Key, p => p.Value), false, true);

            if (sno == -1)
            {
                instance = new HPX_WebService.HPXPlateDto()
                {
                    EmployeeNo = string.Empty,
                    EmployeeName = string.Empty,
                    VehicleType = string.Empty,
                    VehicleTypeName = string.Empty,
                    PlateNumber = string.Empty,
                    Remark = string.Empty,
                    CreatedBy = MainForm.USER_NAME,
                    CreationDate = DateTime.Now,
                    LastUpdatedBy = MainForm.USER_NAME,
                    LastUpdateDate = DateTime.Now,
                };
            }
            else 
            {
                ptxEmployee.Enabled = false;
                instance = client.GetHPXPlateBySno(sno).Result;
            }

            if (instance == null)
            {
                MessageBox.Show("查無資料", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            ptxEmployee.Text = instance.EmployeeNo;
            cbxVehicle_Type.SelectedValue = instance.VehicleType;
            txtPlate_Number.Text = instance.PlateNumber;
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

            HPX_WebService.HPXPlateDto hPXPlateDto = new HPX_WebService.HPXPlateDto()
            {
                Sno = sno,
                EmployeeNo = ptxEmployee.Text,
                EmployeeName = dsBas.BASE.Where(p => p.NOBR == ptxEmployee.Text).FirstOrDefault().NAME_C,
                VehicleType = cbxVehicle_Type.SelectedValue.ToString(),
                VehicleTypeName = cbxVehicle_Type.Text,
                PlateNumber = txtPlate_Number.Text,
                Remark = txtMemo.Text,
                CreationDate = sno == -1 ? DateTime.Now : instance.CreationDate,
                CreatedBy = sno == -1 ? MainForm.USER_NAME : instance.CreatedBy,
                LastUpdateDate = DateTime.Now,
                LastUpdatedBy = MainForm.USER_NAME,
            };

            if (sno == -1)
                client.InsertHPXPlate(hPXPlateDto);
            else
                client.UpdateHPXPlate(hPXPlateDto);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
