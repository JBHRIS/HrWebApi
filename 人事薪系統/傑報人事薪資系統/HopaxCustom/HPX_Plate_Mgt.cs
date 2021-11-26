using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JBHR.HopaxCustom
{
    public partial class HPX_Plate_Mgt : JBControls.JBForm
    {
        public HPX_Plate_Mgt()
        {
            InitializeComponent();
        }
        HPX_WebService.ServiceClient client = new HPX_WebService.ServiceClient();
        JBModule.Data.ApplicationConfigSettings acg = new JBModule.Data.ApplicationConfigSettings("HPX_Plate_Mgt", MainForm.COMPANY);
        private void HPX_Plate_Mgt_Load(object sender, EventArgs e)
        {
            SystemFunction.CheckAppConfigRule(btnConfig);
            acg.CheckParameterAndSetDefault("WebService_Address", "WebService位置", @"http://localhost:64401/Service.svc", "指定服務位置", "TextBox", "", "String");
            client.Endpoint.Address = new System.ServiceModel.EndpointAddress(acg.GetConfig("WebService_Address").Value);
        }
        private void jbHPX_Plate_Mgt_RowInsert(object sender, JBControls.JBQuery.RowInsertEventArgs e)
        {
            HPX_Plate_Mgt_ADD frm = new HPX_Plate_Mgt_ADD();
            frm.client = client;
            frm.Text = "HPX_Plate_Mgt-新增";
            frm.ShowDialog();
        }
        private void jbHPX_Plate_Mgt_RowUpdate(object sender, JBControls.JBQuery.RowUpdateEventArgs e)
        {
            if (jbHPX_Plate_Mgt.SelectedKey != null)
            {
                HPX_Plate_Mgt_ADD frm = new HPX_Plate_Mgt_ADD();
                frm.client = client;
                frm.sno = Convert.ToInt32(jbHPX_Plate_Mgt.SelectedKey.ToString());
                frm.Text = "HPX_Plate_Mgt-修改";
                frm.ShowDialog(); 
            }
        }
        private void jbHPX_Plate_Mgt_RowDelete(object sender, JBControls.JBQuery.RowDeleteEventArgs e)
        {
            client.DeleteHPXPlate(Convert.ToInt32(e.PrimaryKey));
        }
    }
}
