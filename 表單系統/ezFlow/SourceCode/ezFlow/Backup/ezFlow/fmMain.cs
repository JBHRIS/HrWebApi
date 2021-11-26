using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezFlow {
	public partial class fmMain : Form {
		ezFlowDSTableAdapters.FlowTreeTableAdapter adFlowTree = new ezFlow.ezFlowDSTableAdapters.FlowTreeTableAdapter();
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

		public static TabControl tabCtrl = null;

		public fmMain() {
			InitializeComponent();
			tabCtrl = tabControl;
		}

		private void fmMain_Load(object sender, EventArgs e) {
			ImageBox.lineWidth = 2.0f;
			ImageBox.lineColor = Color.Black;
			ImageLink.defaultLength = 50;            
		}

		private void mnuOpen_Click(object sender, EventArgs e) {
			fmOpenFlow dlgOpenFlow = new fmOpenFlow();
			if(dlgOpenFlow.ShowDialog() == DialogResult.OK) {
				bool IsFind = false;
				for(int i = 0; i < tabControl.TabPages.Count; i++) {
					if(tabControl.TabPages[i].Tag.ToString() == dlgOpenFlow.Selected_idFlow) {
						IsFind = true;
						tabControl.SelectedTab = tabControl.TabPages[i];						
					}
				}
				if(!IsFind) {
					ezFlowDS.FlowTreeDataTable dtFlowTree = adFlowTree.GetDataById(dlgOpenFlow.Selected_idFlow);
					TabPage tabPage = new TabPage(dtFlowTree[0].name);					
					tabPage.AutoScroll = true;
					tabPage.Tag = dtFlowTree[0].id;
					Panel panel = new Panel();					
					panel.AllowDrop = true;
					panel.DragEnter +=new DragEventHandler(panel_DragEnter);
					panel.DragDrop += new DragEventHandler(panel_DragDrop);
					panel.MouseMove += new MouseEventHandler(panel_MouseMove);
					panel.MouseDown += new MouseEventHandler(panel_MouseDown);
					panel.Paint += new PaintEventHandler(panel_Paint);
					panel.BackColor = Color.Snow;
					panel.Width = 1280;
					panel.Height = 1024;
					panel.Tag = new List<ImageLink>();
					tabPage.Controls.Add(panel);
					tabControl.TabPages.Add(tabPage);
					tabControl.SelectedTab = tabPage;

					CreateFlowNode(dlgOpenFlow.Selected_idFlow);
				}
			}

			for(int i = 0; i < tabControl.TabPages.Count; i++) {
				ezFlowDS.FlowTreeDataTable dtFlowTree = adFlowTree.GetDataById(tabControl.TabPages[i].Tag.ToString());
				tabControl.TabPages[i].Text = dtFlowTree[0].name;
			}
		}

		void CreateFlowNode(string FlowTree_id) {
			ezFlowDS.FlowNodeDataTable dtFlowNode = adFlowNode.GetDataByFlowTree(FlowTree_id);			
			ImageBox imgBox = null;
			for(int i = 0; i < dtFlowNode.Count; i++) {
				switch(dtFlowNode[i].nodeType) {
					case "1":
						imgBox = new ImageBox(bnStart.Image, dtFlowNode[i].name, true);
						imgBox.data1 = "nStart";
						break;
					case "2":
						imgBox = new ImageBox(bnForm.Image, dtFlowNode[i].name, true);
						imgBox.data1 = "nForm";
						break;
					case "3":
						imgBox = new ImageBox(bnMang.Image, dtFlowNode[i].name, true);
						imgBox.data1 = "nMang";
						break;
					case "4":
						imgBox = new ImageBox(bnInit.Image, dtFlowNode[i].name, true);
						imgBox.data1 = "nInit";
						break;
					case "5":
						imgBox = new ImageBox(bnMultiInit.Image, dtFlowNode[i].name, true);
						imgBox.data1 = "nMultiInit";
						break;
					case "6":
						imgBox = new ImageBox(bnCustom.Image, dtFlowNode[i].name, true);
						imgBox.data1 = "nCustom";
						break;
					case "7":
						imgBox = new ImageBox(bnDynamic.Image, dtFlowNode[i].name, true);
						imgBox.data1 = "nDynamic";
						break;
					case "8":
						imgBox = new ImageBox(bnAgentInit.Image, dtFlowNode[i].name, true);
						imgBox.data1 = "nAgentInit";
						break;
					case "9":
						imgBox = new ImageBox(bnMultiStart.Image, dtFlowNode[i].name, true);
						imgBox.data1 = "nMultiStart";
						break;
					case "10":
						imgBox = new ImageBox(bnMail.Image, dtFlowNode[i].name, true);
						imgBox.data1 = "nMail";
						break;
					case "11":
						imgBox = new ImageBox(bnService.Image, dtFlowNode[i].name, true);
						imgBox.data1 = "nService";						
						break;
					case "12":
						imgBox = new ImageBox(bnEnd.Image, dtFlowNode[i].name, true);
						imgBox.data1 = "nEnd";
						break;					
				}
				if(imgBox != null) {
					imgBox.ParentControl = tabControl.SelectedTab.Controls[0];
					tabControl.SelectedTab.Controls[0].Controls.Add(imgBox);
					imgBox.Left = dtFlowNode[i].xPos;
					imgBox.Top = dtFlowNode[i].yPos;
					imgBox.LabelEdited += new ImageBox.LabelEditedEventHandler(imgBox_LabelEdited);
					imgBox.LinkLabelEdited += new ImageBox.LinkLabelEditedEventHandler(imgBox_LinkLabelEdited);
					imgBox.LinkFinished += new ImageBox.LinkFinishedEventHandler(imgBox_LinkFinished);
					imgBox.LinkCancel += new ImageBox.LinkCancelEventHandler(imgBox_LinkCancel);
					imgBox.ImageDeleting += new ImageBox.ImageDeletingEventHandler(imgBox_ImageDeleting);
					imgBox.MouseUp += new MouseEventHandler(imgBox_MouseUp);
					imgBox.LinkContent += new ImageBox.LinkContentEventHandler(imgBox_LinkContent);
					imgBox.ImageContent += new ImageBox.ImageContentEventHandler(imgBox_ImageContent);
					imgBox.LinkDelete += new ImageBox.LinkDeleteHandler(imgBox_LinkDelete);
					imgBox.data2 = dtFlowNode[i].id;
				}
			}
			ezFlowDS.FlowLinkDataTable dtFlowLink = adFlowLink.GetDataByFlowTree(FlowTree_id);
			for(int i = 0; i < dtFlowLink.Count; i++) {
				ImageBox StartImage = null;
				ImageBox EndImage = null;
				foreach(Control control in tabControl.SelectedTab.Controls[0].Controls) {
					if(control.GetType() == typeof(ImageBox) && 
						((ImageBox)control).data2.ToString() == dtFlowLink[i].FlowNode_idSource) {
						StartImage = (ImageBox)control;
						break;
					}
				}
				foreach(Control control in tabControl.SelectedTab.Controls[0].Controls) {
					if(control.GetType() == typeof(ImageBox) &&
						((ImageBox)control).data2.ToString() == dtFlowLink[i].FlowNode_idTarget) {
						EndImage = (ImageBox)control;
						break;
					}
				}
				if(StartImage != null && EndImage != null) {
					Color myLineColor = Color.Black;					
					switch(dtFlowLink[i].linkType) {
						case "1":
							myLineColor = Color.Green;
							break;
						case "2":
							myLineColor = Color.Red;
							break;
						case "3":
							myLineColor = Color.Blue;
							break;
					}
					LinkStyle linkStyle = LinkStyle.Standard;
					switch(dtFlowLink[i].linkStyle) {
						case "1":
							linkStyle = LinkStyle.Standard;
							break;
						case "2":
							linkStyle = LinkStyle.NearStart;
							break;
						case "3":
							linkStyle = LinkStyle.NearEnd;
							break;
					}
					Arrow arrowStart = Arrow.Down;
					switch(dtFlowLink[i].FlowNode_ArrowSource) {
						case "1":
							arrowStart = Arrow.LeftUp;
							break;
						case "2":
							arrowStart = Arrow.Up;
							break;
						case "3":
							arrowStart = Arrow.RightUp;
							break;
						case "4":
							arrowStart = Arrow.Left;
							break;
						case "5":
							arrowStart = Arrow.Right;
							break;
						case "6":
							arrowStart = Arrow.LeftDown;
							break;
						case "7":
							arrowStart = Arrow.Down;
							break;
						case "8":
							arrowStart = Arrow.RightDown;
							break;
					}
					Arrow arrowEnd = Arrow.Up;
					switch(dtFlowLink[i].FlowNode_ArrowTarget) {
						case "1":
							arrowEnd = Arrow.LeftUp;
							break;
						case "2":
							arrowEnd = Arrow.Up;
							break;
						case "3":
							arrowEnd = Arrow.RightUp;
							break;
						case "4":
							arrowEnd = Arrow.Left;
							break;
						case "5":
							arrowEnd = Arrow.Right;
							break;
						case "6":
							arrowEnd = Arrow.LeftDown;
							break;
						case "7":
							arrowEnd = Arrow.Down;
							break;
						case "8":
							arrowEnd = Arrow.RightDown;
							break;
					}
					ImageLink imglink = new ImageLink(StartImage, EndImage, arrowStart, arrowEnd,
						ImageBox.lineWidth, myLineColor, linkStyle, dtFlowLink[i].name);
					imglink.Tag = dtFlowLink[i].id;
					imglink.LabelEdited += new ImageLink.LabelEditedEventHandler(imgBox_LinkLabelEdited);
					imglink.LinkContent += new ImageLink.LinkContentEventHandler(imgBox_LinkContent);
					imglink.LinkDelete += new ImageLink.LinkDeleteEventHandler(imgBox_LinkDelete);
					imglink.graphics = tabControl.SelectedTab.Controls[0].CreateGraphics();

					((List<ImageLink>)tabControl.SelectedTab.Controls[0].Tag).Add(imglink);
					tabControl.SelectedTab.Controls[0].Controls.Add(imglink);
				}
			}
		}

		void imgBox_LinkDelete(object sender, EventArgs e) {			
			ezFlowDS.FlowLinkDataTable dtFlowLink = adFlowLink.GetDataById(((Control)sender).Tag.ToString());
			ezFlowDS.FlowLinkPowerDataTable dtFlowLinkPower = adFlowLinkPower.GetDataByFlowLink(dtFlowLink[0].id);
			foreach(DataRow rowFlowLinkPower in dtFlowLinkPower.Rows) rowFlowLinkPower.Delete();
			adFlowLinkPower.Update(dtFlowLinkPower);
			dtFlowLink[0].Delete();
			adFlowLink.Update(dtFlowLink);						
		}

		void imgBox_ImageContent(object sender, EventArgs e) {
			string FlowNode_id = ((ImageBox)sender).data2.ToString();
			string FlowNode_name = ((ImageBox)sender).Text;
			switch(((ImageBox)sender).data1.ToString()) {
				case "nStart":
					fmNodeStart dlgNodeStart = new fmNodeStart();
					dlgNodeStart.FlowNode_id = FlowNode_id;
					dlgNodeStart.FlowNode_name = FlowNode_name;
					dlgNodeStart.ShowDialog();
					break;
				case "nForm":
					fmNodeForm dlgNodeForm = new fmNodeForm();
					dlgNodeForm.FlowNode_id = FlowNode_id;
					dlgNodeForm.FlowNode_name = FlowNode_name;
					dlgNodeForm.ShowDialog();
					break;
				case "nMang":
					fmNodeMang dlgNodeMang = new fmNodeMang();
					dlgNodeMang.FlowNode_id = FlowNode_id;
					dlgNodeMang.FlowNode_name = FlowNode_name;
					dlgNodeMang.FlowTree_id = tabControl.SelectedTab.Tag.ToString();
					dlgNodeMang.ShowDialog();
					break;
				case "nInit":
					fmNodeInit dlgNodeInit = new fmNodeInit();
					dlgNodeInit.FlowNode_id = FlowNode_id;
					dlgNodeInit.FlowNode_name = FlowNode_name;
					dlgNodeInit.ShowDialog();
					break;
				case "nMultiInit":
					fmNodeMultiInit dlgNodeMultiInit = new fmNodeMultiInit();
					dlgNodeMultiInit.FlowNode_id = FlowNode_id;
					dlgNodeMultiInit.FlowNode_name = FlowNode_name;
					dlgNodeMultiInit.ShowDialog();
					break;
				case "nCustom":
					fmNodeCustom dlgNodeCustom = new fmNodeCustom();
					dlgNodeCustom.FlowNode_id = FlowNode_id;
					dlgNodeCustom.FlowNode_name = FlowNode_name;
					dlgNodeCustom.ShowDialog();
					break;
				case "nDynamic":
					fmNodeDynamic dlgNodeDynamic = new fmNodeDynamic();
					dlgNodeDynamic.FlowNode_id = FlowNode_id;
					dlgNodeDynamic.FlowNode_name = FlowNode_name;
					dlgNodeDynamic.ShowDialog();
					break;
				case "nAgentInit":
					fmNodeAgentInit dlgNodeAgentInit = new fmNodeAgentInit();
					dlgNodeAgentInit.FlowNode_id = FlowNode_id;
					dlgNodeAgentInit.FlowNode_name = FlowNode_name;
					dlgNodeAgentInit.ShowDialog();
					break;
				case "nMultiStart":
					break;
				case "nMail":
					fmNodeMail dlgNodeMail = new fmNodeMail();
					dlgNodeMail.FlowNode_id = FlowNode_id;
					dlgNodeMail.FlowNode_name = FlowNode_name;
					dlgNodeMail.ShowDialog();
					break;
				case "nService":
					fmNodeService dlgNodeService = new fmNodeService();
					dlgNodeService.FlowNode_id = FlowNode_id;
					dlgNodeService.FlowNode_name = FlowNode_name;
					dlgNodeService.ShowDialog();
					break;
				case "nEnd":
					fmNodeEnd dlgNodeEnd = new fmNodeEnd();
					dlgNodeEnd.FlowNode_id = FlowNode_id;
					dlgNodeEnd.FlowNode_name = FlowNode_name;
					dlgNodeEnd.ShowDialog();
					break;
			}
		}

		void imgBox_LinkContent(object sender, EventArgs e) {
			fmLinkPower dlgPower = new fmLinkPower();
			ImageLink imgLink = (ImageLink)sender;
			dlgPower.FlowLink_id = imgLink.Tag.ToString();
			dlgPower.FlowLink_name = imgLink.Text;
			dlgPower.FlowTree_id = tabControl.SelectedTab.Tag.ToString();
			dlgPower.ShowDialog();
		}

		void imgBox_MouseUp(object sender, MouseEventArgs e) {
			ezFlowDS.FlowNodeDataTable dtFlowNode = adFlowNode.GetDataById(((ImageBox)sender).data2.ToString());
			dtFlowNode[0].xPos = ((Control)sender).Left;
			dtFlowNode[0].yPos = ((Control)sender).Top;
			adFlowNode.Update(dtFlowNode);
		}

		void imgBox_ImageDeleting(object sender, EventArgs e) {
			ImageBox imgBox = (ImageBox)sender;
			Panel panel = (Panel)tabControl.SelectedTab.Controls[0];
			foreach(Control ctrl in panel.Controls) {
				if(ctrl.GetType() == typeof(ImageLink)) {
					if(((ImageLink)ctrl).StartImage == imgBox ||
						((ImageLink)ctrl).EndImage == imgBox) {
						ezFlowDS.FlowLinkDataTable dtFlowLink = adFlowLink.GetDataById(ctrl.Tag.ToString());
						ezFlowDS.FlowLinkPowerDataTable dtFlowLinkPower = adFlowLinkPower.GetDataByFlowLink(dtFlowLink[0].id);
						foreach(DataRow rowFlowLinkPower in dtFlowLinkPower.Rows) rowFlowLinkPower.Delete();
						adFlowLinkPower.Update(dtFlowLinkPower);
						dtFlowLink[0].Delete();
						adFlowLink.Update(dtFlowLink);						
					}
				}
			}

			ezFlowDS.FlowNodeDataTable dtFlowNode = adFlowNode.GetDataById(imgBox.data2.ToString());
			ezFlowDS.FlowNodeRow rowFlowNode = dtFlowNode[0];

			//刪除 NodeStart
			ezFlowDS.NodeStartDataTable dtNodeStart = adNodeStart.GetDataByFlowNode(rowFlowNode["id"].ToString());
			foreach(DataRow rowNodeStart in dtNodeStart.Rows) rowNodeStart.Delete();
			adNodeStart.Update(dtNodeStart);

			//刪除 NodeForm
			ezFlowDS.NodeFormDataTable dtNodeForm = adNodeForm.GetDataByFlowNode(rowFlowNode["id"].ToString());
			foreach(DataRow rowNodeForm in dtNodeForm.Rows) rowNodeForm.Delete();
			adNodeForm.Update(dtNodeForm);

			//刪除 NodeMang
			ezFlowDS.NodeMangDataTable dtNodeMang = adNodeMang.GetDataByFlowNode(rowFlowNode["id"].ToString());
			foreach(DataRow rowNodeMang in dtNodeMang.Rows) rowNodeMang.Delete();
			adNodeMang.Update(dtNodeMang);

			//刪除 NodeMangLoopBreak
			ezFlowDS.NodeMangLoopBreakDataTable dtNodeMangLoopBreak = adNodeMangLoopBreak.GetDataByFlowNode(rowFlowNode["id"].ToString());
			foreach(DataRow rowNodeMangLoopBreak in dtNodeMangLoopBreak.Rows) rowNodeMangLoopBreak.Delete();
			adNodeMangLoopBreak.Update(dtNodeMangLoopBreak);

			//刪除 NodeInit
			ezFlowDS.NodeInitDataTable dtNodeInit = adNodeInit.GetDataByFlowNode(rowFlowNode["id"].ToString());
			foreach(DataRow rowNodeInit in dtNodeInit.Rows) rowNodeInit.Delete();
			adNodeInit.Update(dtNodeInit);

			//刪除 NodeMultiInit
			ezFlowDS.NodeMultiInitDataTable dtNodeMultiInit = adNodeMultiInit.GetDataByFlowNode(rowFlowNode["id"].ToString());
			foreach(DataRow rowNodeMultiInit in dtNodeMultiInit.Rows) rowNodeMultiInit.Delete();
			adNodeMultiInit.Update(dtNodeMultiInit);

			//刪除 NodeCustom
			ezFlowDS.NodeCustomDataTable dtNodeCustom = adNodeCustom.GetDataByFlowNode(rowFlowNode["id"].ToString());
			foreach(DataRow rowNodeCustom in dtNodeCustom.Rows) rowNodeCustom.Delete();
			adNodeCustom.Update(dtNodeCustom);

			//刪除 NodeDynamic
			ezFlowDS.NodeDynamicDataTable dtNodeDynamic = adNodeDynamic.GetDataByFlowNode(rowFlowNode["id"].ToString());
			foreach(DataRow rowNodeDynamic in dtNodeDynamic.Rows) rowNodeDynamic.Delete();
			adNodeDynamic.Update(dtNodeDynamic);

			//刪除 NodeAgentInit
			ezFlowDS.NodeAgentInitDataTable dtNodeAgentInit = adNodeAgentInit.GetDataByFlowNode(rowFlowNode["id"].ToString());
			foreach(DataRow rowNodeAgentInit in dtNodeAgentInit.Rows) rowNodeAgentInit.Delete();
			adNodeAgentInit.Update(dtNodeAgentInit);

			//刪除 NodeMail
			ezFlowDS.NodeMailDataTable dtNodeMail = adNodeMail.GetDataByFlowNode(rowFlowNode["id"].ToString());
			foreach(DataRow rowNodeMail in dtNodeMail.Rows) rowNodeMail.Delete();
			adNodeMail.Update(dtNodeMail);

			//刪除 NodeService
			ezFlowDS.NodeServiceDataTable dtNodeService = adNodeService.GetDataByFlowNode(rowFlowNode["id"].ToString());
			foreach(DataRow rowNodeService in dtNodeService.Rows) rowNodeService.Delete();
			adNodeService.Update(dtNodeService);

			//刪除 NodeEnd
			ezFlowDS.NodeEndDataTable dtNodeEnd = adNodeEnd.GetDataByFlowNode(rowFlowNode["id"].ToString());
			foreach(DataRow rowNodeEnd in dtNodeEnd.Rows) rowNodeEnd.Delete();
			adNodeEnd.Update(dtNodeEnd);

			rowFlowNode.Delete();
			adFlowNode.Update(dtFlowNode);
		}

		void imgBox_LinkCancel(object sender, EventArgs e) {
			ImageLink imgLink = (ImageLink)sender;
			ezFlowDS.FlowLinkDataTable dtFlowLink = adFlowLink.GetDataById(imgLink.Tag.ToString());
			ezFlowDS.FlowLinkPowerDataTable dtFlowLinkPower = adFlowLinkPower.GetDataByFlowLink(dtFlowLink[0].id);
			foreach(DataRow rowFlowLinkPower in dtFlowLinkPower.Rows) rowFlowLinkPower.Delete();
			adFlowLinkPower.Update(dtFlowLinkPower);
			dtFlowLink[0].Delete();
			adFlowLink.Update(dtFlowLink);
		}

		void imgBox_LinkFinished(object sender, EventArgs e) {
			ImageLink imageLink = (ImageLink)sender;
			ezFlowDS.FlowLinkDataTable dtFlowLink = new ezFlowDS.FlowLinkDataTable();
			ezFlowDS.FlowLinkRow rowFlowLink = dtFlowLink.NewFlowLinkRow();
			string MaxID = "1";
			if(adFlowLink.MaxID() != null) MaxID = Convert.ToString(Convert.ToInt32(adFlowLink.MaxID()) + 1);
			rowFlowLink.id = MaxID;
			rowFlowLink.name = imageLink.Text;
			rowFlowLink.FlowTree_id = tabControl.SelectedTab.Tag.ToString();			
			switch(imageLink.newLinkStyle) {
				case LinkStyle.Standard:
					rowFlowLink.linkStyle = "1";
					break;
				case LinkStyle.NearStart:
					rowFlowLink.linkStyle = "2";
					break;
				case LinkStyle.NearEnd:
					rowFlowLink.linkStyle = "3";
					break;
			}
			if(imageLink.lineColor == Color.Green) rowFlowLink.linkType = "1";
			if(imageLink.lineColor == Color.Red) rowFlowLink.linkType = "2";
			if(imageLink.lineColor == Color.Blue) rowFlowLink.linkType = "3";					
			rowFlowLink.FlowNode_idSource = imageLink.StartImage.data2.ToString();
			switch(imageLink.StartImage.arrow) {
				case Arrow.LeftUp:
					rowFlowLink.FlowNode_ArrowSource = "1";
					break;
				case Arrow.Up:
					rowFlowLink.FlowNode_ArrowSource = "2";
					break;
				case Arrow.RightUp:
					rowFlowLink.FlowNode_ArrowSource = "3";
					break;
				case Arrow.Left:
					rowFlowLink.FlowNode_ArrowSource = "4";
					break;
				case Arrow.Right:
					rowFlowLink.FlowNode_ArrowSource = "5";
					break;
				case Arrow.LeftDown:
					rowFlowLink.FlowNode_ArrowSource = "6";
					break;
				case Arrow.Down:
					rowFlowLink.FlowNode_ArrowSource = "7";
					break;
				case Arrow.RightDown:
					rowFlowLink.FlowNode_ArrowSource = "8";
					break;
			}
			switch(imageLink.EndImage.arrow) {
				case Arrow.LeftUp:
					rowFlowLink.FlowNode_ArrowTarget = "1";
					break;
				case Arrow.Up:
					rowFlowLink.FlowNode_ArrowTarget = "2";
					break;
				case Arrow.RightUp:
					rowFlowLink.FlowNode_ArrowTarget = "3";
					break;
				case Arrow.Left:
					rowFlowLink.FlowNode_ArrowTarget = "4";
					break;
				case Arrow.Right:
					rowFlowLink.FlowNode_ArrowTarget = "5";
					break;
				case Arrow.LeftDown:
					rowFlowLink.FlowNode_ArrowTarget = "6";
					break;
				case Arrow.Down:
					rowFlowLink.FlowNode_ArrowTarget = "7";
					break;
				case Arrow.RightDown:
					rowFlowLink.FlowNode_ArrowTarget = "8";
					break;
			}
			rowFlowLink.FlowNode_idTarget = imageLink.EndImage.data2.ToString();
			dtFlowLink.AddFlowLinkRow(rowFlowLink);
			adFlowLink.Update(dtFlowLink);
			imageLink.Tag = rowFlowLink.id;
		}

		void imgBox_LinkLabelEdited(object sender, EventArgs e) {
			ezFlowDS.FlowLinkDataTable dtFlowLink = adFlowLink.GetDataById(((ImageLink)sender).Tag.ToString());
			dtFlowLink[0].name = ((ImageLink)sender).Text;
			adFlowLink.Update(dtFlowLink);
		}

		void panel_Paint(object sender, PaintEventArgs e) {
			if(((List<ImageLink>)tabControl.SelectedTab.Controls[0].Tag).Count > 0) {
				((List<ImageLink>)tabControl.SelectedTab.Controls[0].Tag)[0].ReDrawAll();
			}
		}

		void panel_MouseDown(object sender, MouseEventArgs e) {
			if(e.Button == MouseButtons.Left) {
				this.ActiveControl = null;
				ImageBox.ClearOldLine(sender);
				ImageBox.DrawLine = false;
			}
		}

		void panel_MouseMove(object sender, MouseEventArgs e) {
			ImageBox.FormMouseMove(sender, e);
		}

		private void mnuClose_Click(object sender, EventArgs e) {
			if(tabControl.SelectedTab != null) {
				if(MessageBox.Show("即將關閉「" + tabControl.SelectedTab.Text + "」之流程圖，確定嗎？", "訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
					== DialogResult.Yes) {
					tabControl.TabPages.Remove(tabControl.SelectedTab);
				}
			}
		}

		private void bnNode_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
			((Button)sender).DoDragDrop(((Button)sender).Tag.ToString(), DragDropEffects.Copy |
			   DragDropEffects.Move);			
		}

		private void panel_DragEnter(object sender, System.Windows.Forms.DragEventArgs e) {
			switch(e.Data.GetData(DataFormats.Text).ToString()) {
				case "nStart":
				case "nForm":
				case "nMang":
				case "nInit":
				case "nMultiInit":
				case "nCustom":
				case "nDynamic":
				case "nAgentInit":
				case "nMultiStart":				
				case "nMail":
				case "nService":
				case "nEnd":
					e.Effect = DragDropEffects.Copy;					
					break;
				default:
					e.Effect = DragDropEffects.None;
					break;
			}
		}

		void panel_DragDrop(object sender, DragEventArgs e) {
			ImageBox imgBox = null;
			string NodeType = "";
			Panel panel = (Panel)tabControl.SelectedTab.Controls[0];
			bool isFind;
			switch(e.Data.GetData(DataFormats.Text).ToString()) {
				case "nStart":
					isFind = false;
					for(int i = 0; i < panel.Controls.Count; i++) {
						if(panel.Controls[i].GetType() == typeof(ImageBox)) {
							if(((ImageBox)panel.Controls[i]).data1.ToString() == "nStart") {
								isFind = true;
								break;
							}
						}
					}
					if(isFind) {
						MessageBox.Show("一條流程只能有一個流程開始節點", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					imgBox = new ImageBox(bnStart.Image, "流程開始", true);
					NodeType = "1";
					break;
				case "nForm":
					isFind = false;
					for(int i = 0; i < panel.Controls.Count; i++) {
						if(panel.Controls[i].GetType() == typeof(ImageBox)) {
							if(((ImageBox)panel.Controls[i]).data1.ToString() == "nForm") {
								isFind = true;
								break;
							}
						}
					}
					if(isFind) {
						MessageBox.Show("一條流程只能有一個表單填寫節點", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					imgBox = new ImageBox(bnForm.Image, "填寫表單", true);
					NodeType = "2";
					break;
				case "nMang":
					imgBox = new ImageBox(bnMang.Image, "主管審核", true);
					NodeType = "3";
					break;
				case "nInit":
					imgBox = new ImageBox(bnInit.Image, "流程起始者", true);
					NodeType = "4";
					break;
				case "nMultiInit":
					imgBox = new ImageBox(bnMultiInit.Image, "會簽起始者", true);
					NodeType = "5";
					break;
				case "nCustom":
					imgBox = new ImageBox(bnCustom.Image, "自定成員", true);
					NodeType = "6";
					break;
				case "nDynamic":
					imgBox = new ImageBox(bnDynamic.Image, "動態成員", true);
					NodeType = "7";
					break;
				case "nAgentInit":
					imgBox = new ImageBox(bnAgentInit.Image, "代理起始者", true);
					NodeType = "8";
					break;
				case "nMultiStart":
					imgBox = new ImageBox(bnMultiStart.Image, "會簽流程", true);
					NodeType = "9";
					break;
				case "nMail":
					imgBox = new ImageBox(bnMail.Image, "郵件通知", true);
					NodeType = "10";
					break;
				case "nService":
					imgBox = new ImageBox(bnService.Image, "服務程式", true);
					NodeType = "11";
					break;
				case "nEnd":
					imgBox = new ImageBox(bnEnd.Image, "流程結束", true);
					NodeType = "12";
					break;
			}
			if(imgBox != null) {
				imgBox.ParentControl = tabControl.SelectedTab.Controls[0];
				tabControl.SelectedTab.Controls[0].Controls.Add(imgBox);
				imgBox.Left = tabControl.SelectedTab.Controls[0].PointToClient(new Point(e.X - 16,e.Y - 16)).X;
				imgBox.Top = tabControl.SelectedTab.Controls[0].PointToClient(new Point(e.X - 16, e.Y - 16)).Y;				
				imgBox.LabelEdited += new ImageBox.LabelEditedEventHandler(imgBox_LabelEdited);
				imgBox.LinkLabelEdited += new ImageBox.LinkLabelEditedEventHandler(imgBox_LinkLabelEdited);
				imgBox.LinkFinished += new ImageBox.LinkFinishedEventHandler(imgBox_LinkFinished);
				imgBox.LinkCancel += new ImageBox.LinkCancelEventHandler(imgBox_LinkCancel);
				imgBox.ImageDeleting += new ImageBox.ImageDeletingEventHandler(imgBox_ImageDeleting);
				imgBox.MouseUp += new MouseEventHandler(imgBox_MouseUp);
				imgBox.LinkContent +=new ImageBox.LinkContentEventHandler(imgBox_LinkContent);
				imgBox.ImageContent +=new ImageBox.ImageContentEventHandler(imgBox_ImageContent);
				imgBox.LinkDelete +=new ImageBox.LinkDeleteHandler(imgBox_LinkDelete);

				ezFlowDS.FlowNodeDataTable dtFlowNode = new ezFlowDS.FlowNodeDataTable();
				ezFlowDS.FlowNodeRow rowFlowNode = dtFlowNode.NewFlowNodeRow();

				string MaxID = "";
				if(adFlowNode.MaxID() == null) MaxID = "1";
				else MaxID = Convert.ToString(Convert.ToInt32(adFlowNode.MaxID()) + 1);

				rowFlowNode.id = MaxID;
				rowFlowNode.FlowTree_id = tabControl.SelectedTab.Tag.ToString();
				rowFlowNode.name = imgBox.Text;
				rowFlowNode.nodeType = NodeType;
				rowFlowNode.xPos = imgBox.Left;
				rowFlowNode.yPos = imgBox.Top;
				dtFlowNode.AddFlowNodeRow(rowFlowNode);
				adFlowNode.Update(dtFlowNode);

				switch(rowFlowNode.nodeType) {
					case "1":
						ezFlowDS.NodeStartDataTable dtNodeStart = new ezFlowDS.NodeStartDataTable();
						ezFlowDS.NodeStartRow rowNodeStart = dtNodeStart.NewNodeStartRow();
						rowNodeStart.FlowNode_id = rowFlowNode.id;
						rowNodeStart.virtualPath = "";
						rowNodeStart.viewAp = "";
						rowNodeStart.isAuto = false;
						rowNodeStart.tableName = "";
						dtNodeStart.AddNodeStartRow(rowNodeStart);
						adNodeStart.Update(dtNodeStart);
						break;
					case "2":
						ezFlowDS.NodeFormDataTable dtNodeForm = new ezFlowDS.NodeFormDataTable();
						ezFlowDS.NodeFormRow rowNodeForm = dtNodeForm.NewNodeFormRow();
						rowNodeForm.FlowNode_id = rowFlowNode.id;
						rowNodeForm.apName = "";
						dtNodeForm.AddNodeFormRow(rowNodeForm);
						adNodeForm.Update(dtNodeForm);
						break;
					case "3":
						ezFlowDS.NodeMangDataTable dtNodeMang = new ezFlowDS.NodeMangDataTable();
						ezFlowDS.NodeMangRow rowNodeMang = dtNodeMang.NewNodeMangRow();
						rowNodeMang.FlowNode_id = rowFlowNode.id;
						rowNodeMang.apName = "";
						dtNodeMang.AddNodeMangRow(rowNodeMang);
						adNodeMang.Update(dtNodeMang);
						break;
					case "4":
						ezFlowDS.NodeInitDataTable dtNodeInit = new ezFlowDS.NodeInitDataTable();
						ezFlowDS.NodeInitRow rowNodeInit = dtNodeInit.NewNodeInitRow();
						rowNodeInit.FlowNode_id = rowFlowNode.id;
						rowNodeInit.apName = "";
						dtNodeInit.AddNodeInitRow(rowNodeInit);
						adNodeInit.Update(dtNodeInit);
						break;
					case "5":
						ezFlowDS.NodeMultiInitDataTable dtNodeMultiInit = new ezFlowDS.NodeMultiInitDataTable();
						ezFlowDS.NodeMultiInitRow rowNodeMultiInit = dtNodeMultiInit.NewNodeMultiInitRow();
						rowNodeMultiInit.FlowNode_id = rowFlowNode.id;
						rowNodeMultiInit.apName = "";
						dtNodeMultiInit.AddNodeMultiInitRow(rowNodeMultiInit);
						adNodeMultiInit.Update(dtNodeMultiInit);
						break;
					case "6":
						ezFlowDS.NodeCustomDataTable dtNodeCustom = new ezFlowDS.NodeCustomDataTable();
						ezFlowDS.NodeCustomRow rowNodeCustom = dtNodeCustom.NewNodeCustomRow();
						rowNodeCustom.FlowNode_id = rowFlowNode.id;
						rowNodeCustom.apName = "";
						rowNodeCustom.Role_id = "";
						rowNodeCustom.Emp_id = "";
						dtNodeCustom.AddNodeCustomRow(rowNodeCustom);
						adNodeCustom.Update(dtNodeCustom);
						break;
					case "7":
						ezFlowDS.NodeDynamicDataTable dtNodeDynamic = new ezFlowDS.NodeDynamicDataTable();
						ezFlowDS.NodeDynamicRow rowNodeDynamic = dtNodeDynamic.NewNodeDynamicRow();
						rowNodeDynamic.FlowNode_id = rowFlowNode.id;
						rowNodeDynamic.apName = "";
						rowNodeDynamic.tableName = "";
						rowNodeDynamic.fdRole = "";
						rowNodeDynamic.fdEmp = "";
						dtNodeDynamic.AddNodeDynamicRow(rowNodeDynamic);
						adNodeDynamic.Update(dtNodeDynamic);
						break;
					case "8":
						ezFlowDS.NodeAgentInitDataTable dtNodeAgentInit = new ezFlowDS.NodeAgentInitDataTable();
						ezFlowDS.NodeAgentInitRow rowNodeAgentInit = dtNodeAgentInit.NewNodeAgentInitRow();
						rowNodeAgentInit.FlowNode_id = rowFlowNode.id;
						rowNodeAgentInit.apName = "";
						dtNodeAgentInit.AddNodeAgentInitRow(rowNodeAgentInit);
						adNodeAgentInit.Update(dtNodeAgentInit);
						break;
					case "9": //NodeMultiStart 不需預設
						break;
					case "10":
						ezFlowDS.NodeMailDataTable dtNodeMail = new ezFlowDS.NodeMailDataTable();
						ezFlowDS.NodeMailRow rowNodeMail = dtNodeMail.NewNodeMailRow();
						rowNodeMail.FlowNode_id = rowFlowNode.id;
						rowNodeMail.receiveType = "1";
						rowNodeMail.customEmail = "";
						rowNodeMail.dynamicTable = "";
						rowNodeMail.dynamicFdMail = "";
						rowNodeMail.isCustom = false;
						rowNodeMail.subject = "";
						rowNodeMail.mailContent = "";
						dtNodeMail.AddNodeMailRow(rowNodeMail);
						adNodeMail.Update(dtNodeMail);
						break;
					case "11":
						ezFlowDS.NodeServiceDataTable dtNodeService = new ezFlowDS.NodeServiceDataTable();
						ezFlowDS.NodeServiceRow rowNodeService = dtNodeService.NewNodeServiceRow();
						rowNodeService.FlowNode_id = rowFlowNode.id;
						rowNodeService.webSrvUrl = "";
						dtNodeService.AddNodeServiceRow(rowNodeService);
						adNodeService.Update(dtNodeService);
						break;
					case "12":
						ezFlowDS.NodeEndDataTable dtNodeEnd = new ezFlowDS.NodeEndDataTable();
						ezFlowDS.NodeEndRow rowNodeEnd = dtNodeEnd.NewNodeEndRow();
						rowNodeEnd.FlowNode_id = rowFlowNode.id;
						rowNodeEnd.isMailStarter = false;
						rowNodeEnd.isMailAllMang = false;
						dtNodeEnd.AddNodeEndRow(rowNodeEnd);
						adNodeEnd.Update(dtNodeEnd);
						break;
				}

				imgBox.data1 = e.Data.GetData(DataFormats.Text).ToString();
				imgBox.data2 = rowFlowNode.id;
			}
		}

		void imgBox_LabelEdited(object sender, EventArgs e) {
			string FlowNode_id = ((ImageBox)sender).data2.ToString();
			ezFlowDS.FlowNodeDataTable dtFlowNode = adFlowNode.GetDataById(FlowNode_id);
			dtFlowNode[0].name = ((ImageBox)sender).Text;
			adFlowNode.Update(dtFlowNode);
		}

		private void mnuSysVar_Click(object sender, EventArgs e) {
			fmSysVar dlgSysVar = new fmSysVar();
			dlgSysVar.ShowDialog();
		}

		private void fmMain_FormClosing(object sender, FormClosingEventArgs e) {
			if (MessageBox.Show("即將要關閉應用程式，確定嗎？", "訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
				e.Cancel = true;
			}
			else e.Cancel = false;
		}
	}
}