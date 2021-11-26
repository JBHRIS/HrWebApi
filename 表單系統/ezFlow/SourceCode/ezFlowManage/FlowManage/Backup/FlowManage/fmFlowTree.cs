using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FlowManage
{
    public partial class fmFlowTree : Form
    {
        private dsFlowTableAdapters.FlowTreeTableAdapter taFlowTree = new FlowManage.dsFlowTableAdapters.FlowTreeTableAdapter();
        private dsFlow odsFlow = new dsFlow();

        public fmFlowTree()
        {
            InitializeComponent();
        }

        private void fmFlowTree_Load(object sender, EventArgs e) {
            taFlowTree.Fill(odsFlow.FlowTree);

            cbxFlowTree.DataSource = odsFlow.FlowTree;
            cbxFlowTree.DisplayMember = "name";
            cbxFlowTree.ValueMember = "id";
        }

        private void btnYorN_Click(object sender, EventArgs e) {
            Button btn = ((Button)sender);

            this.AccessibleDescription = cbxFlowTree.SelectedValue.ToString();
            this.AccessibleName = cbxFlowTree.Text;
            DialogResult = (btn.Tag.ToString() == "Yes") ? DialogResult.OK : DialogResult.Cancel;
            Close();
        }
    }
}
