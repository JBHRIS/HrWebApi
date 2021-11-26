using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezFlow {
	public partial class fmOpenFlow : Form {
		public string Selected_idFlow;

		ezFlowDSTableAdapters.FlowGroupTableAdapter adFlowGroup = new ezFlow.ezFlowDSTableAdapters.FlowGroupTableAdapter();
		ezFlowDSTableAdapters.FlowTreeTableAdapter adFlowTree = new ezFlow.ezFlowDSTableAdapters.FlowTreeTableAdapter();
		ezFlowDSTableAdapters.FlowTreePowerTableAdapter adFlowTreePower = new ezFlow.ezFlowDSTableAdapters.FlowTreePowerTableAdapter();
		ezFlowDSTableAdapters.FlowTreePowerRoleOnlyTableAdapter adFlowTreePowerRoleOnly = new ezFlow.ezFlowDSTableAdapters.FlowTreePowerRoleOnlyTableAdapter();
		ezFlowDSTableAdapters.FlowNodeTableAdapter adFlowNode = new ezFlow.ezFlowDSTableAdapters.FlowNodeTableAdapter();
		ezFlowDSTableAdapters.FlowLinkTableAdapter adFlowLink = new ezFlow.ezFlowDSTableAdapters.FlowLinkTableAdapter();
		ezFlowDSTableAdapters.FlowLinkPowerTableAdapter adFlowLinkPower = new ezFlow.ezFlowDSTableAdapters.FlowLinkPowerTableAdapter();
		ezFlowDSTableAdapters.NodeStartTableAdapter adNodeStart = new ezFlow.ezFlowDSTableAdapters.NodeStartTableAdapter();		
		ezFlowDSTableAdapters.NodeFormTableAdapter adNodeForm = new ezFlow.ezFlowDSTableAdapters.NodeFormTableAdapter();
		ezFlowDSTableAdapters.NodeMangTableAdapter adNodeMang = new ezFlow.ezFlowDSTableAdapters.NodeMangTableAdapter();
		ezFlowDSTableAdapters.NodeMangLoopBreakTableAdapter adNodeMangLoopBreak = new ezFlow.ezFlowDSTableAdapters.NodeMangLoopBreakTableAdapter();
		ezFlowDSTableAdapters.NodeInitTableAdapter adNodeInit = new ezFlow.ezFlowDSTableAdapters.NodeInitTableAdapter();
		ezFlowDSTableAdapters.NodeMultiInitTableAdapter adNodeMultiInit = new ezFlow.ezFlowDSTableAdapters.NodeMultiInitTableAdapter();
		ezFlowDSTableAdapters.NodeCustomTableAdapter adNodeCustom = new ezFlow.ezFlowDSTableAdapters.NodeCustomTableAdapter();
		ezFlowDSTableAdapters.NodeDynamicTableAdapter adNodeDynamic = new ezFlow.ezFlowDSTableAdapters.NodeDynamicTableAdapter();
		ezFlowDSTableAdapters.NodeAgentInitTableAdapter adNodeAgentInit = new ezFlow.ezFlowDSTableAdapters.NodeAgentInitTableAdapter();
		ezFlowDSTableAdapters.NodeMailTableAdapter adNodeMail = new ezFlow.ezFlowDSTableAdapters.NodeMailTableAdapter();
		ezFlowDSTableAdapters.NodeServiceTableAdapter adNodeService = new ezFlow.ezFlowDSTableAdapters.NodeServiceTableAdapter();
		ezFlowDSTableAdapters.NodeEndTableAdapter adNodeEnd = new ezFlow.ezFlowDSTableAdapters.NodeEndTableAdapter();

		public fmOpenFlow() {
			InitializeComponent();
		}

		private void fmOpenFlow_Load(object sender, EventArgs e) {
			ezFlowDS.FlowGroupDataTable dtFlowGroup = adFlowGroup.GetDataByParent("");
			for(int i = 0; i < dtFlowGroup.Count; i++) {
				TreeNode gNode = new TreeNode(dtFlowGroup[i].name, 0, 1);
				gNode.Tag = dtFlowGroup[i].id;
				if(dtFlowGroup[i].dateE < DateTime.Now) gNode.Text += "(����)";
				tvMain.Nodes.Add(gNode);

				CreateSubGroup(dtFlowGroup[i].id, gNode);
			}

			if(tvMain.Nodes.Count > 0) {
				tvMain.SelectedNode = tvMain.Nodes[0];
				tvMain.SelectedNode.BackColor = Color.Silver;
				CreateFlowTree(tvMain.SelectedNode.Tag.ToString());
			}
		}

		void CreateFlowTree(string idParent) {
			ezFlowDS.FlowTreeDataTable dtFlowTree = adFlowTree.GetData(idParent);
			for(int i = 0; i < dtFlowTree.Count; i++) {
				ListViewItem flowItem = new ListViewItem(dtFlowTree[i].id + "-" + dtFlowTree[i].name, 0);
				flowItem.Tag = dtFlowTree[i].id;
				if(dtFlowTree[i].dateE < DateTime.Now) flowItem.Text += "(����)";
				if(!dtFlowTree[i].isVisible) flowItem.Text = "[�l]" + flowItem.Text;
				lvMain.Items.Add(flowItem);
			}
		}

		void CreateSubGroup(string idParent, TreeNode nodeParent) {
			ezFlowDS.FlowGroupDataTable dtFlowGroup = adFlowGroup.GetDataByParent(idParent);
			for(int i = 0; i < dtFlowGroup.Count; i++) {
				TreeNode gNode = new TreeNode(dtFlowGroup[i].name, 0, 1);
				gNode.Tag = dtFlowGroup[i].id;
				if(dtFlowGroup[i].dateE < DateTime.Now) gNode.Text += "(����)";
				nodeParent.Nodes.Add(gNode);

				CreateSubGroup(dtFlowGroup[i].id, gNode);
			}			
		}

		private void tvMain_MouseDown(object sender, MouseEventArgs e) {
			TreeNode NodeSelect = tvMain.GetNodeAt(e.X, e.Y);
			if(e.Button == MouseButtons.Right) {
				this.ContextMenuStrip = new ContextMenuStrip();				
				if(NodeSelect == null) {					
					this.ContextMenuStrip.Items.Add("�إ߷s��Ƨ�", null, new EventHandler(OnCreateRootGroup));
				}
				else {
					this.ContextMenuStrip.Items.Add("�إߤl��Ƨ�", null, new EventHandler(OnCreateSubGroup));
					ezFlowDS.FlowGroupDataTable dtFlowGroup = adFlowGroup.GetDataById(NodeSelect.Tag.ToString());					
					if(dtFlowGroup[0].dateE >= DateTime.Now) 
						this.ContextMenuStrip.Items.Add("��Ƨ����A����", null, new EventHandler(OnGroupNoUse));
					else this.ContextMenuStrip.Items.Add("��Ƨ���_����", null, new EventHandler(OnGroupUse));
					if(dtFlowGroup[0].dateE >= DateTime.Now)
						this.ContextMenuStrip.Items.Add("���s�R�W", null, new EventHandler(OnGroupRename));
					this.ContextMenuStrip.Items.Add("-");
					this.ContextMenuStrip.Items.Add("�R����Ƨ�", null, new EventHandler(OnGroupDelete));
				}
			}
			if(NodeSelect != null) {
				lvMain.Items.Clear();
				if(tvMain.SelectedNode != null) tvMain.SelectedNode.BackColor = Color.White;
				tvMain.SelectedNode = NodeSelect;
				tvMain.SelectedNode.BackColor = Color.Silver;
				CreateFlowTree(tvMain.SelectedNode.Tag.ToString());
				txtSelect.Clear();
			}
		}

		void OnGroupRename(object sender, EventArgs e) {
			tvMain.LabelEdit = true;
			tvMain.SelectedNode.BeginEdit();			
		}

		void OnCreateRootGroup(object sender, EventArgs e) {
			lvMain.Items.Clear();
			if(tvMain.SelectedNode != null) tvMain.SelectedNode.BackColor = Color.White;
			txtSelect.Clear();

			TreeNode gNode = new TreeNode("�s��Ƨ�", 0, 1);
			tvMain.Nodes.Add(gNode);
			tvMain.SelectedNode = gNode;
			gNode.BackColor = Color.Silver;
			tvMain.LabelEdit = true;
			gNode.BeginEdit();			
		}

		void OnCreateSubGroup(object sender, EventArgs e) {			
			lvMain.Items.Clear();
			if(tvMain.SelectedNode != null) tvMain.SelectedNode.BackColor = Color.White;
			txtSelect.Clear();

			TreeNode gNode = new TreeNode("�s��Ƨ�", 0, 1);
			tvMain.SelectedNode.Nodes.Add(gNode);			
			tvMain.SelectedNode = gNode;
			gNode.BackColor = Color.Silver;
			tvMain.LabelEdit = true;
			gNode.BeginEdit();
		}

		void OnGroupNoUse(object sender, EventArgs e) {
			ezFlowDS.FlowGroupDataTable dtFlowGroup = adFlowGroup.GetDataById(tvMain.SelectedNode.Tag.ToString());
			dtFlowGroup[0].dateE = DateTime.Now.AddDays(-1);
			adFlowGroup.Update(dtFlowGroup);
			tvMain.SelectedNode.Text = dtFlowGroup[0].name + "(����)";
		}

		void OnGroupUse(object sender, EventArgs e) {
			ezFlowDS.FlowGroupDataTable dtFlowGroup = adFlowGroup.GetDataById(tvMain.SelectedNode.Tag.ToString());
			dtFlowGroup[0].dateE = Convert.ToDateTime("2099/12/31 23:59:59");
			adFlowGroup.Update(dtFlowGroup);
			tvMain.SelectedNode.Text = dtFlowGroup[0].name;
		}

		void OnGroupDelete(object sender, EventArgs e) {
			if(MessageBox.Show("�z�T�w�n�R���o�Ӹs�նܡH", "�T������", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
				DialogResult.Yes) {
				string GroupID = tvMain.SelectedNode.Tag.ToString();

				ezFlowDS.FlowGroupDataTable dtFlowGroup = adFlowGroup.GetDataById(GroupID);
				foreach(DataRow rowFlowGroup in dtFlowGroup.Rows) {
					DeleteSubGroup(rowFlowGroup["id"].ToString());
					DeleteAllFlowByGroup(rowFlowGroup["id"].ToString());
					rowFlowGroup.Delete();
				}
				adFlowGroup.Update(dtFlowGroup);

				lvMain.Items.Clear();
				tvMain.Nodes.Remove(tvMain.SelectedNode);
			}
		}

		void DeleteSubGroup(string idParent) {
			ezFlowDS.FlowGroupDataTable dtFlowGroup = adFlowGroup.GetDataByParent(idParent);
			foreach(DataRow rowFlowGroup in dtFlowGroup.Rows) {
				DeleteSubGroup(rowFlowGroup["id"].ToString());
				DeleteAllFlowByGroup(rowFlowGroup["id"].ToString());
				rowFlowGroup.Delete();
			}
			adFlowGroup.Update(dtFlowGroup);
		}

		void DeleteAllFlowByGroup(string GroupID) {
			ezFlowDS.FlowTreeDataTable dtFlowTree = adFlowTree.GetData(GroupID);
			DeleteFlow(dtFlowTree);
		}		

		void DeleteFlow(ezFlowDS.FlowTreeDataTable dtFlowTree) {			
			foreach(DataRow rowFlowTree in dtFlowTree.Rows) {
				//�R�� FlowTreePower
				ezFlowDS.FlowTreePowerDataTable dtFlowTreePower = adFlowTreePower.GetData(rowFlowTree["id"].ToString());
				foreach(DataRow rowFlowTreePower in dtFlowTreePower.Rows) rowFlowTreePower.Delete();
				adFlowTreePower.Update(dtFlowTreePower);

				//�R�� FlowTreePowerRoleOnly
				ezFlowDS.FlowTreePowerRoleOnlyDataTable dtFlowTreePowerRoleOnly = adFlowTreePowerRoleOnly.GetData(rowFlowTree["id"].ToString());
				foreach(DataRow rowFlowTreePowerRoleOnly in dtFlowTreePowerRoleOnly.Rows) rowFlowTreePowerRoleOnly.Delete();
				adFlowTreePowerRoleOnly.Update(dtFlowTreePowerRoleOnly);

				//�R�� FlowNode
				ezFlowDS.FlowNodeDataTable dtFlowNode = adFlowNode.GetDataByFlowTree(rowFlowTree["id"].ToString());
				foreach(DataRow rowFlowNode in dtFlowNode.Rows) {
					//�R�� FlowLink
					ezFlowDS.FlowLinkDataTable dtFlowLink = adFlowLink.GetDataByFlowNode(rowFlowNode["id"].ToString());
					foreach(DataRow rowFlowLink in dtFlowLink.Rows) {
						//�R�� FlowLinkPower
						ezFlowDS.FlowLinkPowerDataTable dtFlowLinkPower = adFlowLinkPower.GetDataByFlowLink(rowFlowLink["id"].ToString());
						foreach(DataRow rowFlowLinkPower in dtFlowLinkPower.Rows) rowFlowLinkPower.Delete();
						adFlowLinkPower.Update(dtFlowLinkPower);

						rowFlowLink.Delete();
					}
					adFlowLink.Update(dtFlowLink);

					//�R�� NodeStart
					ezFlowDS.NodeStartDataTable dtNodeStart = adNodeStart.GetDataByFlowNode(rowFlowNode["id"].ToString());
					foreach(DataRow rowNodeStart in dtNodeStart.Rows) rowNodeStart.Delete();
					adNodeStart.Update(dtNodeStart);

					//�R�� NodeForm
					ezFlowDS.NodeFormDataTable dtNodeForm = adNodeForm.GetDataByFlowNode(rowFlowNode["id"].ToString());
					foreach(DataRow rowNodeForm in dtNodeForm.Rows) rowNodeForm.Delete();
					adNodeForm.Update(dtNodeForm);

					//�R�� NodeMang
					ezFlowDS.NodeMangDataTable dtNodeMang = adNodeMang.GetDataByFlowNode(rowFlowNode["id"].ToString());
					foreach(DataRow rowNodeMang in dtNodeMang.Rows) rowNodeMang.Delete();
					adNodeMang.Update(dtNodeMang);

					//�R�� NodeMangLoopBreak
					ezFlowDS.NodeMangLoopBreakDataTable dtNodeMangLoopBreak = adNodeMangLoopBreak.GetDataByFlowNode(rowFlowNode["id"].ToString());
					foreach(DataRow rowNodeMangLoopBreak in dtNodeMangLoopBreak.Rows) rowNodeMangLoopBreak.Delete();
					adNodeMangLoopBreak.Update(dtNodeMangLoopBreak);

					//�R�� NodeInit
					ezFlowDS.NodeInitDataTable dtNodeInit = adNodeInit.GetDataByFlowNode(rowFlowNode["id"].ToString());
					foreach(DataRow rowNodeInit in dtNodeInit.Rows) rowNodeInit.Delete();
					adNodeInit.Update(dtNodeInit);

					//�R�� NodeMultiInit
					ezFlowDS.NodeMultiInitDataTable dtNodeMultiInit = adNodeMultiInit.GetDataByFlowNode(rowFlowNode["id"].ToString());
					foreach(DataRow rowNodeMultiInit in dtNodeMultiInit.Rows) rowNodeMultiInit.Delete();
					adNodeMultiInit.Update(dtNodeMultiInit);

					//�R�� NodeCustom
					ezFlowDS.NodeCustomDataTable dtNodeCustom = adNodeCustom.GetDataByFlowNode(rowFlowNode["id"].ToString());
					foreach(DataRow rowNodeCustom in dtNodeCustom.Rows) rowNodeCustom.Delete();
					adNodeCustom.Update(dtNodeCustom);

					//�R�� NodeDynamic
					ezFlowDS.NodeDynamicDataTable dtNodeDynamic = adNodeDynamic.GetDataByFlowNode(rowFlowNode["id"].ToString());
					foreach(DataRow rowNodeDynamic in dtNodeDynamic.Rows) rowNodeDynamic.Delete();
					adNodeDynamic.Update(dtNodeDynamic);

					//�R�� NodeAgentInit
					ezFlowDS.NodeAgentInitDataTable dtNodeAgentInit = adNodeAgentInit.GetDataByFlowNode(rowFlowNode["id"].ToString());
					foreach(DataRow rowNodeAgentInit in dtNodeAgentInit.Rows) rowNodeAgentInit.Delete();
					adNodeAgentInit.Update(dtNodeAgentInit);

					//�R�� NodeMail
					ezFlowDS.NodeMailDataTable dtNodeMail = adNodeMail.GetDataByFlowNode(rowFlowNode["id"].ToString());
					foreach(DataRow rowNodeMail in dtNodeMail.Rows) rowNodeMail.Delete();
					adNodeMail.Update(dtNodeMail);

					//�R�� NodeService
					ezFlowDS.NodeServiceDataTable dtNodeService = adNodeService.GetDataByFlowNode(rowFlowNode["id"].ToString());
					foreach(DataRow rowNodeService in dtNodeService.Rows) rowNodeService.Delete();
					adNodeService.Update(dtNodeService);

					//�R�� NodeEnd
					ezFlowDS.NodeEndDataTable dtNodeEnd = adNodeEnd.GetDataByFlowNode(rowFlowNode["id"].ToString());
					foreach(DataRow rowNodeEnd in dtNodeEnd.Rows) rowNodeEnd.Delete();
					adNodeEnd.Update(dtNodeEnd);

					rowFlowNode.Delete();
				}
				adFlowNode.Update(dtFlowNode);

				rowFlowTree.Delete();
			}
			adFlowTree.Update(dtFlowTree);
		}

		private void tvMain_AfterLabelEdit(object sender, NodeLabelEditEventArgs e) {
			if(e.Label != null) {
				if(e.Node.Tag == null) {
					string MaxID = "";
					if(adFlowGroup.MaxID() == null) MaxID = "1";
					else MaxID = Convert.ToString(Convert.ToInt32(adFlowGroup.MaxID()) + 1);

					ezFlowDS.FlowGroupDataTable dtFlowGroup = new ezFlowDS.FlowGroupDataTable();
					ezFlowDS.FlowGroupRow rowFlowGroup = dtFlowGroup.NewFlowGroupRow();
					rowFlowGroup.id = MaxID;
					if(e.Node.Parent == null) rowFlowGroup.idParent = "";
					else rowFlowGroup.idParent = e.Node.Parent.Tag.ToString();
					rowFlowGroup.name = e.Label;
					rowFlowGroup.dateB = DateTime.Now.Date;
					rowFlowGroup.dateE = Convert.ToDateTime("2099/12/31 23:59:59");
					dtFlowGroup.AddFlowGroupRow(rowFlowGroup);
					adFlowGroup.Update(dtFlowGroup);
					e.Node.Tag = MaxID;
				}
				else {
					ezFlowDS.FlowGroupDataTable dtFlowGroup = adFlowGroup.GetDataById(e.Node.Tag.ToString());
					dtFlowGroup[0].name = e.Label;
					adFlowGroup.Update(dtFlowGroup);
				}
			}
			else {
				if(e.Node.Tag == null) tvMain.Nodes.Remove(e.Node);
			}
			tvMain.LabelEdit = false;
		}

		private void lvMain_MouseDown(object sender, MouseEventArgs e) {
			ListViewItem lvItem = lvMain.GetItemAt(e.X, e.Y);

			if(e.Button == MouseButtons.Right) {
				this.ContextMenuStrip = new ContextMenuStrip();
				if(lvItem == null) {
					if(tvMain.Nodes.Count > 0) {
						this.ContextMenuStrip.Items.Add("�إ߷s�y�{", null, new EventHandler(OnCreateNewFlow));
					}
				}
				else {
					this.ContextMenuStrip.Items.Add("�]�w�y�{�v��", null, new EventHandler(OnSetFlowPower));					
					ezFlowDS.FlowTreeDataTable dtFlowTree = adFlowTree.GetDataById(lvItem.Tag.ToString());
					if(dtFlowTree[0].dateE >= DateTime.Now) {
						if(dtFlowTree[0].isVisible)
							this.ContextMenuStrip.Items.Add("�ܧ󬰤l�y�{", null, new EventHandler(OnChangeSubFlow));
						else
							this.ContextMenuStrip.Items.Add("�ܧ󬰥D�y�{", null, new EventHandler(OnChangeMainFlow));
					}
					if(dtFlowTree[0].dateE >= DateTime.Now)
						this.ContextMenuStrip.Items.Add("�y�{���A����", null, new EventHandler(OnFlowNoUse));
					else
						this.ContextMenuStrip.Items.Add("�y�{��_����", null, new EventHandler(OnFlowUse));
					if(dtFlowTree[0].dateE >= DateTime.Now)
						this.ContextMenuStrip.Items.Add("���s�R�W", null, new EventHandler(OnFlowRename));
					this.ContextMenuStrip.Items.Add("-");
					this.ContextMenuStrip.Items.Add("�R���y�{", null, new EventHandler(OnFlowDelete));
				}
			}

			if(lvItem != null) {
				lvItem.Selected = true;
				txtSelect.Text = @"ezDB:\" + tvMain.SelectedNode.Text + @"\" + lvItem.Text + ".flow";
				txtSelect.Tag = lvItem.Tag;
			}
			else txtSelect.Clear();
		}

		void OnFlowRename(object sender, EventArgs e) {
			lvMain.LabelEdit = true;
			ezFlowDS.FlowTreeDataTable dtFlowTree = adFlowTree.GetDataById(lvMain.Items[lvMain.SelectedItems[0].Index].Tag.ToString());
			lvMain.SelectedItems[0].Text = dtFlowTree[0].name;
			lvMain.SelectedItems[0].BeginEdit();
		}

		void OnCreateNewFlow(object sender, EventArgs e) {
			ListViewItem lvItem = new ListViewItem("�s�y�{", 0);
			lvMain.Items.Add(lvItem);
			lvMain.LabelEdit = true;
			lvItem.BeginEdit();
		}

		void OnSetFlowPower(object sender, EventArgs e) {
			fmSetFlowPower dlgSetFlowPower = new fmSetFlowPower();
			dlgSetFlowPower.FlowTree_id = lvMain.SelectedItems[0].Tag.ToString();
			dlgSetFlowPower.FlowTree_name = lvMain.SelectedItems[0].Text;
			dlgSetFlowPower.ShowDialog();
		}

		void OnChangeSubFlow(object sender, EventArgs e) {
			ezFlowDS.FlowTreeDataTable dtFlowTree = adFlowTree.GetDataById(lvMain.SelectedItems[0].Tag.ToString());
			dtFlowTree[0].isVisible = false;
			adFlowTree.Update(dtFlowTree);

			lvMain.SelectedItems[0].Text = "[�l]" + lvMain.SelectedItems[0].Text;
		}

		void OnChangeMainFlow(object sender, EventArgs e) {
			ezFlowDS.FlowTreeDataTable dtFlowTree = adFlowTree.GetDataById(lvMain.SelectedItems[0].Tag.ToString());
			dtFlowTree[0].isVisible = true;
			adFlowTree.Update(dtFlowTree);

			lvMain.SelectedItems[0].Text = dtFlowTree[0].name;
		}

		void OnFlowNoUse(object sender, EventArgs e) {
			ezFlowDS.FlowTreeDataTable dtFlowTree = adFlowTree.GetDataById(lvMain.SelectedItems[0].Tag.ToString());
			dtFlowTree[0].dateE = DateTime.Now.AddDays(-1);
			adFlowTree.Update(dtFlowTree);

			lvMain.SelectedItems[0].Text += "(����)";
		}

		void OnFlowUse(object sender, EventArgs e) {
			ezFlowDS.FlowTreeDataTable dtFlowTree = adFlowTree.GetDataById(lvMain.SelectedItems[0].Tag.ToString());
			dtFlowTree[0].dateE = Convert.ToDateTime("2099/12/31 23:59:59");
			adFlowTree.Update(dtFlowTree);

			if(!dtFlowTree[0].isVisible) lvMain.SelectedItems[0].Text = "[�l]" + dtFlowTree[0].name;
			else lvMain.SelectedItems[0].Text = dtFlowTree[0].name;
		}

		void OnFlowDelete(object sender, EventArgs e) {
			if(MessageBox.Show("�T�w�n�R���y�{�ܡH", "�T������", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
				for (int i = 0; i < fmMain.tabCtrl.TabPages.Count; i++) {
					if (fmMain.tabCtrl.TabPages[i].Tag.ToString() == txtSelect.Tag.ToString()) {
						fmMain.tabCtrl.TabPages.Remove(fmMain.tabCtrl.TabPages[i]);
						break;
					}
				}

				ezFlowDS.FlowTreeDataTable dtFlowTree = adFlowTree.GetDataById(lvMain.SelectedItems[0].Tag.ToString());
				DeleteFlow(dtFlowTree);

				txtSelect.Clear();
				lvMain.Items.Remove(lvMain.SelectedItems[0]);
			}
		}

		private void lvMain_AfterLabelEdit(object sender, LabelEditEventArgs e) {
			if(e.Label != null) {
				if(lvMain.Items[e.Item].Tag == null) {
					string MaxID = "";
					if(adFlowTree.MaxID() == null) MaxID = "1";
					else MaxID = Convert.ToString(Convert.ToInt32(adFlowTree.MaxID()) + 1);

					ezFlowDS.FlowTreeDataTable dtFlowTree = new ezFlowDS.FlowTreeDataTable();
					ezFlowDS.FlowTreeRow rowFlowTree = dtFlowTree.NewFlowTreeRow();
					rowFlowTree.id = MaxID;
					rowFlowTree.FlowGroup_id = tvMain.SelectedNode.Tag.ToString();
					rowFlowTree.name = e.Label;
					rowFlowTree.dateB = DateTime.Now.Date;
					rowFlowTree.dateE = Convert.ToDateTime("2099/12/31 23:59:59");
					rowFlowTree.isVisible = true;
					dtFlowTree.AddFlowTreeRow(rowFlowTree);
					adFlowTree.Update(dtFlowTree);
					lvMain.Items[e.Item].Tag = MaxID;

					txtSelect.Text = @"ezDB:\" + tvMain.SelectedNode.Text + @"\" + e.Label + ".flow";
					txtSelect.Tag = MaxID;
				}
				else {
					ezFlowDS.FlowTreeDataTable dtFlowTree = adFlowTree.GetDataById(lvMain.Items[e.Item].Tag.ToString());
					dtFlowTree[0].name = e.Label;
					adFlowTree.Update(dtFlowTree);
					e.CancelEdit = true;
					if(!dtFlowTree[0].isVisible) lvMain.Items[e.Item].Text = "[�l]" + e.Label;
					else lvMain.Items[e.Item].Text = e.Label;

					txtSelect.Text = @"ezDB:\" + tvMain.SelectedNode.Text + @"\" + lvMain.Items[e.Item].Text + ".flow";
				}
			}
			else {
				if(lvMain.Items[e.Item].Tag == null) {
					lvMain.Items.RemoveAt(e.Item);
					txtSelect.Clear();
				}
				else {
					ezFlowDS.FlowTreeDataTable dtFlowTree = adFlowTree.GetDataById(lvMain.Items[e.Item].Tag.ToString());
					e.CancelEdit = true;
					if(!dtFlowTree[0].isVisible) lvMain.Items[e.Item].Text = "[�l]" + dtFlowTree[0].name;
					else lvMain.Items[e.Item].Text = dtFlowTree[0].name;

					txtSelect.Text = @"ezDB:\" + tvMain.SelectedNode.Text + @"\" + lvMain.Items[e.Item].Text + ".flow";
				}
			}
			lvMain.LabelEdit = false;
		}

		private void bnOpen_Click(object sender, EventArgs e) {
			if(txtSelect.Text.Trim().Length == 0) {
				MessageBox.Show("�п���n�}�l���y�{", "�T������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if(txtSelect.Tag == null) {
				MessageBox.Show("�L�k�}�l�y�{�A�Э��s����n�}�Ҫ��y�{��A�դ@���C", "�T������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			Selected_idFlow = txtSelect.Tag.ToString();
			DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}