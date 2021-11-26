using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace ezOrg {
	public partial class fmMain : Form {
		public static ezOrgDSTableAdapters.DeptTableAdapter adDept = new ezOrg.ezOrgDSTableAdapters.DeptTableAdapter();
		public static ezOrgDSTableAdapters.RoleTableAdapter adRole = new ezOrg.ezOrgDSTableAdapters.RoleTableAdapter();
		public static ezOrgDSTableAdapters.PosTableAdapter adPos = new ezOrg.ezOrgDSTableAdapters.PosTableAdapter();
		public static ezOrgDSTableAdapters.EmpTableAdapter adEmp = new ezOrg.ezOrgDSTableAdapters.EmpTableAdapter();
		public static ezOrgDSTableAdapters.WorkAgentTableAdapter adWorkAgent = new ezOrg.ezOrgDSTableAdapters.WorkAgentTableAdapter();
		public static ezOrgDSTableAdapters.WorkAgentPowerTableAdapter adWorkAgentPower = new ezOrg.ezOrgDSTableAdapters.WorkAgentPowerTableAdapter();
		public static ezOrgDSTableAdapters.CheckAgentDefaultTableAdapter adCheckAgentDefault = new ezOrg.ezOrgDSTableAdapters.CheckAgentDefaultTableAdapter();
		public static ezOrgDSTableAdapters.CheckAgentAlwaysTableAdapter adCheckAgentAlways = new ezOrg.ezOrgDSTableAdapters.CheckAgentAlwaysTableAdapter();
		public static ezOrgDSTableAdapters.CheckAgentPowerMTableAdapter adCheckAgentPowerM = new ezOrg.ezOrgDSTableAdapters.CheckAgentPowerMTableAdapter();
		public static ezOrgDSTableAdapters.CheckAgentPowerDTableAdapter adCheckAgentPowerD = new ezOrg.ezOrgDSTableAdapters.CheckAgentPowerDTableAdapter();		

		enum OrgType { Dept, Role, Emp }
		enum DrawStyle { H_Style, V_Style }
		enum ViewStyle { Full, Role, Dept }

		class ImageData {
			public static List<ImageData> Objects = new List<ImageData>();
			public int iIndexX, iIndexY;
			public ImageBox DeptImage;
			public List<ImageBox> PosImages;
			public List<ImageBox> SubPosImages;
			public List<ImageBox> EmpImages;

			public ImageData() {
				Objects.Add(this);

				iIndexX = 0; iIndexY = 0;
				DeptImage = null;
				PosImages = new List<ImageBox>();
				SubPosImages = new List<ImageBox>();
				EmpImages = new List<ImageBox>();
			}
		}

		class DeptTrans {
			public string id;
			public string name;
			public string path;			
		}

		class EmpTrans {
			public string id;
			public string name;
			public string role_id;
		}

		List<ImageBox> OldPos = new List<ImageBox>();
		List<ImageBox> OldEmp = new List<ImageBox>();

		DeptTrans deptTrans = null;
		EmpTrans empTrans = null;

		Hashtable hbLeft = new Hashtable();
		Hashtable hbTop = new Hashtable();

		int iOffsetX = 5;
		int iOffsetY = 5;

		DrawStyle drawStyle = DrawStyle.V_Style;
		ViewStyle viewStyle = ViewStyle.Full;

		fmOrg dlgOrg = new fmOrg();
		fmRole dlgRole = new fmRole();
		fmPos dlgPos = new fmPos();
		fmEmp dlgEmp = new fmEmp();
		fmNewMember dlgNewMember = new fmNewMember();
		fmChgMang dlgChgMang = new fmChgMang();
		fmChgPW dlgChgPW = new fmChgPW();
		fmDeptMg dlgDeptMg = new fmDeptMg();
		fmDeptLevel dlgDeptLevel = new fmDeptLevel();
		fmPosLevel dlgPosLevel = new fmPosLevel();

		int MaxX = 0;
		int MaxY = 0;

		Point ScrollPosition = Point.Empty;

		private void pnlMain_MouseMove(object sender, MouseEventArgs e) {
			//ImageBox.FormMouseMove(sender, e, 2, Color.Blue);
		}

		public fmMain() {			
			InitializeComponent();						

			ImageBox.ParentControl = pnlMain;
			ImageLink.defaultLength = 24;
			this.ContextMenuStrip = new ContextMenuStrip();			
		}

		private void CreateDept_Right() {
			ImageData.Objects.Clear();
			hbLeft.Clear();
			hbTop.Clear();
			ImageLink.ImageLinks.Clear();
			pnlMain.Controls.Clear();
			pnlMain.CreateGraphics().Clear(pnlMain.BackColor);

			ezOrgDS.DeptDataTable dtDept = adDept.GetDataByParent("");
			int iIndexX = 0;
			int iIndexY = 0;
			for(int i = 0; i < dtDept.Count; i++) {
				if(deptTrans != null && dtDept[i].id == deptTrans.id) continue;

				if(!hbLeft.ContainsKey(iIndexX)) hbLeft.Add(iIndexX, iOffsetX);
				if(!hbTop.ContainsKey(iIndexY)) hbTop.Add(iIndexY, iOffsetY);

				ImageBox imgBox = new ImageBox(imageList.Images[0], dtDept[i].name, false);
				imgBox.MouseDown += new MouseEventHandler(imgBox_Dept_MouseDown);
				imgBox.LabelEdited += new ImageBox.LabelEditedEventHandler(imgBox_Dept_LabelEdited);
				pnlMain.Controls.Add(imgBox);
				imgBox.Left = Convert.ToInt32(hbLeft[iIndexX]);
				imgBox.Top = Convert.ToInt32(hbTop[iIndexY]);
				imgBox.data1 = OrgType.Dept;
				imgBox.data2 = dtDept[i].id;				

				//動態決定橫向、縱向位置
				if(!hbLeft.ContainsKey(iIndexX + 1)) hbLeft.Add(iIndexX + 1, imgBox.Left + imgBox.Width + iOffsetX);
				if(!hbTop.ContainsKey(iIndexY + 1))
					hbTop.Add(iIndexY + 1, imgBox.Top + imgBox.Height + iOffsetY + ImageLink.defaultLength * 2);

				ImageData imgData = new ImageData();
				imgData.iIndexX = iIndexX;
				imgData.iIndexY = iIndexY;
				imgData.DeptImage = imgBox;

				if(viewStyle != ViewStyle.Dept) CreateRole(imgData, imgBox, dtDept[i].id, iIndexX, iIndexY);

				iIndexX = CreateSubDept_Right(imgBox, dtDept[i].id, iIndexX, iIndexY);
				iIndexX++;
			}
		}

		void imgBox_Dept_LabelEdited(object sender, EventArgs e) {
			string sDeptID = ((ImageBox)sender).data2.ToString();
			string sDeptName = ((ImageBox)sender).label.Text;
			ezOrgDS.DeptDataTable dtDept = adDept.GetDataByID(sDeptID);
			ezOrgDS.DeptDataTable dtParentDept = adDept.GetDataByID(dtDept[0].idParent);

			string newPath = "";
			if(dtParentDept.Count > 0) newPath = dtParentDept[0].path + "/" + sDeptName;
			else newPath = "/" + sDeptName;
			UpdateDeptTree(sDeptID, dtDept[0].path, newPath);

			dtDept[0].name = ((ImageBox)sender).label.Text;
			dtDept[0].path = newPath;
			adDept.Update(dtDept);
		}

		private int CreateSubDept_Right(ImageBox imgParent,string sParentID, int iIndexX, int iIndexY) {
			ezOrgDS.DeptDataTable dtDept = adDept.GetDataByParent(sParentID);
			iIndexY++;
			for(int i = 0; i < dtDept.Count; i++) {
				if(deptTrans != null && dtDept[i].id == deptTrans.id) {
					iIndexX--;
					continue;
				}

				if(i > 0) iIndexX++;				
				if(!hbLeft.ContainsKey(iIndexX)) hbLeft.Add(iIndexX, iOffsetX);
				if(!hbTop.ContainsKey(iIndexY)) hbTop.Add(iIndexY, iOffsetY);				

				ImageBox imgBox = new ImageBox(imageList.Images[0], dtDept[i].name, false);
				pnlMain.Controls.Add(imgBox);
				imgBox.Left = Convert.ToInt32(hbLeft[iIndexX]);
				imgBox.Top = Convert.ToInt32(hbTop[iIndexY]);
				imgBox.data1 = OrgType.Dept;
				imgBox.data2 = dtDept[i].id;
				imgBox.MouseDown +=new MouseEventHandler(imgBox_Dept_MouseDown);
				imgBox.LabelEdited += new ImageBox.LabelEditedEventHandler(imgBox_Dept_LabelEdited);

				ImageLink imgLink = new ImageLink(imgBox, imgParent, Arrow.Up, Arrow.Down, 2, Color.Black, LinkType.NearStart, "");
				pnlMain.Controls.Add(imgLink);

				//動態決定橫向、縱向位置
				if(!hbLeft.ContainsKey(iIndexX + 1)) hbLeft.Add(iIndexX + 1, imgBox.Left + imgBox.Width + iOffsetX);
				if(!hbTop.ContainsKey(iIndexY + 1))
					hbTop.Add(iIndexY + 1, imgBox.Top + imgBox.Height + iOffsetY + ImageLink.defaultLength * 2);

				ImageData imgData = new ImageData();
				imgData.iIndexX = iIndexX;
				imgData.iIndexY = iIndexY;
				imgData.DeptImage = imgBox;

				if(viewStyle != ViewStyle.Dept) CreateRole(imgData, imgBox, dtDept[i].id, iIndexX, iIndexY);

				iIndexX = CreateSubDept_Right(imgBox, dtDept[i].id, iIndexX, iIndexY);
			}

			return iIndexX;
		}

		void RefreshAll() {
			MaxX = 0;
			MaxY = 0;
			
			for(int i = 0; i < ImageData.Objects.Count; i++) {
				int iIndexX = ImageData.Objects[i].iIndexX;
				int iIndexY = ImageData.Objects[i].iIndexY;
				ImageData.Objects[i].DeptImage.Left = Convert.ToInt32(hbLeft[iIndexX]);
				ImageData.Objects[i].DeptImage.Top = Convert.ToInt32(hbTop[iIndexY]);				

				if(ImageData.Objects[i].DeptImage.Left > MaxX) MaxX = ImageData.Objects[i].DeptImage.Left;
				if(ImageData.Objects[i].DeptImage.Top > MaxY) MaxY = ImageData.Objects[i].DeptImage.Top;

				int RoleOffSetX = 0;
				for(int j = 0; j < ImageData.Objects[i].PosImages.Count; j++) {
					if(OldPos.Contains(ImageData.Objects[i].PosImages[j])) continue;
					else OldPos.Add(ImageData.Objects[i].PosImages[j]);
					if(RoleOffSetX == 0) {
						ImageData.Objects[i].PosImages[j].Left =
							Convert.ToInt32(hbLeft[iIndexX]) + ImageData.Objects[i].DeptImage.Width;
					}
					else {
						ImageData.Objects[i].PosImages[j].Left = RoleOffSetX;
					}
					RoleOffSetX = ImageData.Objects[i].PosImages[j].Left + ImageData.Objects[i].PosImages[j].Width +
							ImageLink.defaultLength * 2;
					ImageData.Objects[i].PosImages[j].Top = Convert.ToInt32(hbTop[iIndexY]) +
						ImageData.Objects[i].DeptImage.Height + ImageLink.defaultLength * 2;

					if(ImageData.Objects[i].PosImages[j].Left > MaxX) MaxX = ImageData.Objects[i].PosImages[j].Left;
					if(ImageData.Objects[i].PosImages[j].Top > MaxY) MaxY = ImageData.Objects[i].PosImages[j].Top;

					int iEmpCount = 1;
					foreach(object EmpImage in ImageData.Objects[i].EmpImages) {
						if(((Control)EmpImage).Tag.Equals(ImageData.Objects[i].PosImages[j])) {
							if(OldEmp.Contains((ImageBox)EmpImage)) continue;
							else OldEmp.Add((ImageBox)EmpImage);
							((Control)EmpImage).Left = ImageData.Objects[i].PosImages[j].Left;
							((Control)EmpImage).Top = ImageData.Objects[i].PosImages[j].Top +
								iEmpCount * ImageData.Objects[i].PosImages[j].Height + iOffsetY;
							iEmpCount++;

							if(((Control)EmpImage).Left > MaxX) MaxX = ((Control)EmpImage).Left;
							if(((Control)EmpImage).Top > MaxY) MaxY = ((Control)EmpImage).Top;
						}
					}

					RoleOffSetX = Refresh_SubPos(ImageData.Objects[i], ImageData.Objects[i].PosImages[j], RoleOffSetX);
				}
			}

			ImageLink.ReDrawAll();
		}

		int Refresh_SubPos(ImageData dataObj,object parentImage,int RoleOffSetX) {
			foreach(object PosImage in dataObj.SubPosImages) {
				if(((Control)PosImage).Tag.Equals(parentImage)) {
					if(OldPos.Contains((ImageBox)PosImage)) continue;
					else OldPos.Add((ImageBox)PosImage);
					((Control)PosImage).Left = RoleOffSetX;
					RoleOffSetX = ((Control)PosImage).Left + ((Control)PosImage).Width + ImageLink.defaultLength * 2;
					((Control)PosImage).Top = ((ImageBox)parentImage).Top + ((ImageBox)parentImage).Height + iOffsetY;

					if(((Control)PosImage).Left > MaxX) MaxX = ((Control)PosImage).Left;
					if(((Control)PosImage).Top > MaxY) MaxY = ((Control)PosImage).Top;

					int iSubEmpCount = 1;
					foreach(object EmpImage in dataObj.EmpImages) {
						if(((Control)EmpImage).Tag.Equals(PosImage)) {
							if(OldEmp.Contains((ImageBox)EmpImage)) continue;
							else OldEmp.Add((ImageBox)EmpImage);

							((Control)EmpImage).Left = ((Control)PosImage).Left;
							((Control)EmpImage).Top = ((Control)PosImage).Top +
								iSubEmpCount * ((Control)PosImage).Height + iOffsetY;
							iSubEmpCount++;

							if(((Control)EmpImage).Left > MaxX) MaxX = ((Control)EmpImage).Left;
							if(((Control)EmpImage).Top > MaxY) MaxY = ((Control)EmpImage).Top;
						}
					}
					RoleOffSetX = Refresh_SubPos(dataObj, PosImage, RoleOffSetX);
				}
			}

			return RoleOffSetX;
		}

		private void fmMain_Shown(object sender, EventArgs e) {
			V_Expend(sender, e);
		}

		private void CreateDept_Down() {
			ImageData.Objects.Clear();
			hbLeft.Clear();
			hbTop.Clear();
			ImageLink.ImageLinks.Clear();
			pnlMain.Controls.Clear();
			pnlMain.CreateGraphics().Clear(pnlMain.BackColor);

			ezOrgDS.DeptDataTable dtDept = adDept.GetDataByParent("");
			int iIndexX = 0;
			int iIndexY = 0;
			for(int i = 0; i < dtDept.Count; i++) {
				if(deptTrans != null && dtDept[i].id == deptTrans.id) continue;

				if(!hbLeft.ContainsKey(iIndexX)) hbLeft.Add(iIndexX, iOffsetX);
				if(!hbTop.ContainsKey(iIndexY)) hbTop.Add(iIndexY, iOffsetY);

				ImageBox imgBox = new ImageBox(imageList.Images[0], dtDept[i].name, false);
				pnlMain.Controls.Add(imgBox);
				imgBox.Left = Convert.ToInt32(hbLeft[iIndexX]);
				imgBox.Top = Convert.ToInt32(hbTop[iIndexY]);
				imgBox.data1 = OrgType.Dept;
				imgBox.data2 = dtDept[i].id;
				imgBox.MouseDown +=new MouseEventHandler(imgBox_Dept_MouseDown);
				imgBox.LabelEdited += new ImageBox.LabelEditedEventHandler(imgBox_Dept_LabelEdited);

				//動態決定橫向、縱向位置
				if(!hbLeft.ContainsKey(iIndexX + 1))
					hbLeft.Add(iIndexX + 1, imgBox.Left + imgBox.Width + iOffsetX + ImageLink.defaultLength * 2);
				if(!hbTop.ContainsKey(iIndexY + 1)) hbTop.Add(iIndexY + 1, imgBox.Top + imgBox.Height + iOffsetY);

				ImageData imgData = new ImageData();
				imgData.iIndexX = iIndexX;
				imgData.iIndexY = iIndexY;
				imgData.DeptImage = imgBox;

				if(viewStyle != ViewStyle.Dept) CreateRole(imgData, imgBox, dtDept[i].id, iIndexX, iIndexY);

				iIndexY = CreateSubDept_Down(imgBox, dtDept[i].id, iIndexX, iIndexY);
				iIndexY++;
			}
		}

		private int CreateSubDept_Down(ImageBox imgParent, string sParentID, int iIndexX, int iIndexY) {
			ezOrgDS.DeptDataTable dtDept = adDept.GetDataByParent(sParentID);
			iIndexX++;
			for(int i = 0; i < dtDept.Count; i++) {
				if(deptTrans != null && dtDept[i].id == deptTrans.id) {
					iIndexY--;
					continue;
				}

				if(i > 0) iIndexY++;
				if(!hbLeft.ContainsKey(iIndexX)) hbLeft.Add(iIndexX, iOffsetX);
				if(!hbTop.ContainsKey(iIndexY)) hbTop.Add(iIndexY, iOffsetY);

				ImageBox imgBox = new ImageBox(imageList.Images[0], dtDept[i].name, false);
				pnlMain.Controls.Add(imgBox);
				imgBox.Left = Convert.ToInt32(hbLeft[iIndexX]);
				imgBox.Top = Convert.ToInt32(hbTop[iIndexY]);
				imgBox.data1 = OrgType.Dept;
				imgBox.data2 = dtDept[i].id;
				imgBox.MouseDown += new MouseEventHandler(imgBox_Dept_MouseDown);
				imgBox.LabelEdited += new ImageBox.LabelEditedEventHandler(imgBox_Dept_LabelEdited);

				ImageLink imgLink = new ImageLink(imgBox, imgParent, Arrow.Left, Arrow.Right, 2, Color.Black, LinkType.NearStart, "");
				pnlMain.Controls.Add(imgLink);

				//動態決定橫向、縱向位置
				if(!hbLeft.ContainsKey(iIndexX + 1))
					hbLeft.Add(iIndexX + 1, imgBox.Left + imgBox.Width + iOffsetX + ImageLink.defaultLength * 2);
				if(!hbTop.ContainsKey(iIndexY + 1)) hbTop.Add(iIndexY + 1, imgBox.Top + imgBox.Height + iOffsetY);

				ImageData imgData = new ImageData();
				imgData.iIndexX = iIndexX;
				imgData.iIndexY = iIndexY;
				imgData.DeptImage = imgBox;

				if(viewStyle != ViewStyle.Dept) CreateRole(imgData, imgBox, dtDept[i].id, iIndexX, iIndexY);

				iIndexY = CreateSubDept_Down(imgBox, dtDept[i].id, iIndexX, iIndexY);
			}

			return iIndexY;
		}

		private void CreateRole(ImageData imgData, ImageBox imgParent, string sDeptID, int iIndexX, int iIndexY) {
			ezOrgDS.RoleDataTable dtRole = adRole.DeptMang_GetDataByDeptID(sDeptID);

			int RoleOffsetX = 0;

			ImageBox imgOld = null;
			string oldRoleID = "";
			int iEmpCount = 1;
			for(int i = 0; i < dtRole.Count; i++) {				
				if(oldRoleID == dtRole[i].id) {
					iEmpCount++;
					if(!dtRole[i].IsEmp_idNull() || dtRole[i].Emp_id.Trim().Length > 0) {
						if(viewStyle == ViewStyle.Full) {
							CreateEmp(imgData, imgOld, dtRole[i].Emp_id, iIndexX, iIndexY, iEmpCount);
						}
					}
					continue;
				}				
				iEmpCount = 1;
				oldRoleID = dtRole[i].id;
				ezOrgDS.PosDataTable dtPos = adPos.GetDataByID(dtRole[i].Pos_id);
				ImageBox imgBox = new ImageBox(imageList.Images[1], dtPos[0].name, false);
				pnlMain.Controls.Add(imgBox);
				if(i == 0) {
					imgBox.Left = Convert.ToInt32(hbLeft[iIndexX]) + imgParent.Width;					
				}
				else {
					imgBox.Left = RoleOffsetX;					
				}
				RoleOffsetX = imgBox.Left + imgBox.Width + ImageLink.defaultLength * 2;
				imgBox.Top = Convert.ToInt32(hbTop[iIndexY]) + imgParent.Height + ImageLink.defaultLength * 2;
				imgOld = imgBox;
				imgBox.data1 = OrgType.Role;
				imgBox.data2 = dtRole[i].id;				
				imgBox.MouseDown += new MouseEventHandler(imgBox_Role_MouseDown);

				ImageLink imgLink;
				if(drawStyle == DrawStyle.V_Style)
					imgLink = new ImageLink(imgParent, imgBox, Arrow.Down, Arrow.Up, 2, Color.Black, LinkType.NearEnd, "");
				else 
					imgLink = new ImageLink(imgParent, imgBox, Arrow.Right, Arrow.Up, 2, Color.Black, LinkType.NearEnd, "");

				pnlMain.Controls.Add(imgLink);

				//動態決定橫向、縱向位置
				int x = imgBox.Left + imgBox.Width + iOffsetX + ImageLink.defaultLength * 2;
				int y = imgBox.Top + imgBox.Height + iOffsetY + ImageLink.defaultLength * 2;
				if(!hbLeft.ContainsKey(iIndexX + 1)) hbLeft.Add(iIndexX + 1, x);
				else {
					if(x > Convert.ToInt32(hbLeft[iIndexX + 1])) hbLeft[iIndexX + 1] = x;
				}
				if(!hbTop.ContainsKey(iIndexY + 1)) hbTop.Add(iIndexY + 1, y);
				else {
					if(y > Convert.ToInt32(hbTop[iIndexY + 1])) hbTop[iIndexY + 1] = y;
				}

				imgData.PosImages.Add(imgBox);

				if(!dtRole[i].IsEmp_idNull() || dtRole[i].Emp_id.Trim().Length > 0) {
					if(viewStyle == ViewStyle.Full) {
						CreateEmp(imgData, imgBox, dtRole[i].Emp_id, iIndexX, iIndexY, iEmpCount);
					}
				}

				RoleOffsetX = CreateSubRole(imgData, imgBox, dtRole[i].id, sDeptID, iIndexX, iIndexY);
			}
		}

		int CreateSubRole(ImageData imgData, ImageBox imgParent, string sParentID,string sDeptID, int iIndexX, int iIndexY) {
			ezOrgDS.RoleDataTable dtRole = adRole.GetDataByParent(sParentID,sDeptID);

			int RoleOffsetX = 0;

			ImageBox imgOld = null;
			string oldRoleID = "";
			int iEmpCount = 1;
			for(int i = 0; i < dtRole.Count; i++) {
				if(oldRoleID == dtRole[i].id) {
					iEmpCount++;
					if(!dtRole[i].IsEmp_idNull() || dtRole[i].Emp_id.Trim().Length > 0) {
						if(viewStyle == ViewStyle.Full) {
							CreateEmp(imgData, imgOld, dtRole[i].Emp_id, iIndexX, iIndexY, iEmpCount);
						}
					}
					continue;
				}
				iEmpCount = 1;
				oldRoleID = dtRole[i].id;
				ezOrgDS.PosDataTable dtPos = adPos.GetDataByID(dtRole[i].Pos_id);
				ImageBox imgBox = new ImageBox(imageList.Images[1], dtPos[0].name, false);
				pnlMain.Controls.Add(imgBox);
				if(i == 0) {
					imgBox.Left = imgParent.Left + imgParent.Width + ImageLink.defaultLength * 2;
				}
				else {
					imgBox.Left = RoleOffsetX;
				}
				RoleOffsetX = imgBox.Left + imgBox.Width + ImageLink.defaultLength * 2;

				imgBox.Top = imgParent.Top + imgParent.Height + iOffsetY;
				imgOld = imgBox;
				imgBox.data1 = OrgType.Role;
				imgBox.data2 = dtRole[i].id;
				imgBox.MouseDown += new MouseEventHandler(imgBox_Role_MouseDown);
				imgBox.Tag = imgParent;

				ImageLink imgLink = new ImageLink(imgBox, imgParent, Arrow.Up, Arrow.Right, 2, Color.Black, LinkType.NearStart, "");
				pnlMain.Controls.Add(imgLink);

				//動態決定橫向、縱向位置
				int x = imgBox.Left + imgBox.Width + iOffsetX + ImageLink.defaultLength * 2;
				int y = imgBox.Top + imgBox.Height + iOffsetY + ImageLink.defaultLength * 2;
				if(!hbLeft.ContainsKey(iIndexX + 1)) hbLeft.Add(iIndexX + 1, x);
				else {
					if(x > Convert.ToInt32(hbLeft[iIndexX + 1])) hbLeft[iIndexX + 1] = x;
				}
				if(!hbTop.ContainsKey(iIndexY + 1)) hbTop.Add(iIndexY + 1, y);
				else {
					if(y > Convert.ToInt32(hbTop[iIndexY + 1])) hbTop[iIndexY + 1] = y;
				}			

				imgData.SubPosImages.Add(imgBox);

				if(!dtRole[i].IsEmp_idNull() || dtRole[i].Emp_id.Trim().Length > 0) {
					if(viewStyle == ViewStyle.Full) {
						CreateEmp(imgData, imgBox, dtRole[i].Emp_id, iIndexX, iIndexY, iEmpCount);
					}
				}

				RoleOffsetX = CreateSubRole(imgData, imgBox, dtRole[i].id, sDeptID, iIndexX, iIndexY);
			}

			if(RoleOffsetX == 0) RoleOffsetX = imgParent.Left + imgParent.Width + ImageLink.defaultLength * 2;
			return RoleOffsetX;
		}

		private void CreateEmp(ImageData imgData, ImageBox imgParent, string sEmpID, int iIndexX, int iIndexY,int iEmpCount) {
			ezOrgDS.EmpDataTable dtEmp = adEmp.GetDataByID(sEmpID);
			if(dtEmp.Count == 0) return;

			ImageBox imgBox = new ImageBox(imageList.Images[2], dtEmp[0].name, false);
			pnlMain.Controls.Add(imgBox);
			imgBox.Left = imgParent.Left;
			imgBox.Top = imgParent.Top + iEmpCount * imgParent.Height + iOffsetY;
			imgBox.data1 = OrgType.Emp;
			imgBox.data2 = dtEmp[0].id;
			imgBox.data3 = imgParent.data2.ToString();
			imgBox.MouseDown += new MouseEventHandler(imgBox_Emp_MouseDown);
			imgBox.Tag = imgParent;

			ImageLink imgLink = new ImageLink(imgParent, imgBox, Arrow.Left, Arrow.Left,
				2, Color.Black, LinkType.NearEnd, "");
			pnlMain.Controls.Add(imgLink);

			int x = imgBox.Left + imgBox.Width + iOffsetX + ImageLink.defaultLength * 2;
			int y = imgBox.Top + imgBox.Height + iOffsetY + ImageLink.defaultLength * 2;
			if(!hbLeft.ContainsKey(iIndexX + 1)) hbLeft.Add(iIndexX + 1, x);
			else {
				if(x > Convert.ToInt32(hbLeft[iIndexX + 1])) hbLeft[iIndexX + 1] = x;
			}
			if(!hbTop.ContainsKey(iIndexY + 1)) hbTop.Add(iIndexY + 1, y);
			else {
				if(y > Convert.ToInt32(hbTop[iIndexY + 1])) hbTop[iIndexY + 1] = y;
			}

			imgData.EmpImages.Add(imgBox);
		}

		private void pnlMain_Paint(object sender, PaintEventArgs e) {
			ImageLink.ReDrawAll();
		}

		private void fmMain_MouseDown(object sender, MouseEventArgs e) {
			if(e.Button == MouseButtons.Left) {
				this.ActiveControl = null;
				ImageBox.ClearOldLine();
				ImageBox.DrawLine = false;
			}
			if(e.Button == MouseButtons.Right) {
				ToolStripMenuItem item;
				this.ContextMenuStrip = new ContextMenuStrip();
				this.ContextMenuStrip.Items.Add("新增新員工", null, new EventHandler(OnCreateEmp));
				this.ContextMenuStrip.Items.Add("新增新職稱", null, new EventHandler(OnCreatePos));
				this.ContextMenuStrip.Items.Add("新增新組織", null, new EventHandler(OnCreateRoot));
				this.ContextMenuStrip.Items.Add("部門層級鍊", null, new EventHandler(OnDeptLevel));
				this.ContextMenuStrip.Items.Add("職務層級鍊", null, new EventHandler(OnPosLevel));
				if(deptTrans != null) {
					this.ContextMenuStrip.Items.Add("-");
					this.ContextMenuStrip.Items.Add("還原部門樹", null, new EventHandler(OnUndoDept));
					this.ContextMenuStrip.Items.Add("貼上部門樹", null, new EventHandler(OnPasteRootDept));
				}
				this.ContextMenuStrip.Items.Add("-");
				this.ContextMenuStrip.Items.Add("刪除空角色", null, new EventHandler(OnDelEmptyRole));
				this.ContextMenuStrip.Items.Add("-");
				item = new ToolStripMenuItem("橫向展開圖", null, new EventHandler(H_Expend));
				if(drawStyle == DrawStyle.H_Style) item.Checked = true;
				this.ContextMenuStrip.Items.Add(item);
				item = new ToolStripMenuItem("縱向展開圖", null, new EventHandler(V_Expend));
				if(drawStyle == DrawStyle.V_Style) item.Checked = true;
				this.ContextMenuStrip.Items.Add(item);
				this.ContextMenuStrip.Items.Add("-");
				item = new ToolStripMenuItem("完整組織圖", null, new EventHandler(DrawFull));
				if(viewStyle == ViewStyle.Full) item.Checked = true;
				this.ContextMenuStrip.Items.Add(item);
				item = new ToolStripMenuItem("到角色為止", null, new EventHandler(DrawToRole));
				if(viewStyle == ViewStyle.Role) item.Checked = true;
				this.ContextMenuStrip.Items.Add(item);
				item = new ToolStripMenuItem("僅繪製部門", null, new EventHandler(DrawDeptOnly));
				if(viewStyle == ViewStyle.Dept) item.Checked = true;
				this.ContextMenuStrip.Items.Add(item);
				this.ContextMenuStrip.Items.Add("-");
				this.ContextMenuStrip.Items.Add("儲存圖形檔", null, new EventHandler(OnSave));
			}
		}

		void OnDeptLevel(object sender, EventArgs e) {
			dlgDeptLevel.ShowDialog();
		}

		void OnPosLevel(object sender, EventArgs e) {
			dlgPosLevel.ShowDialog();
		}

		private void pnlMain_MouseDown(object sender, MouseEventArgs e) {
			MouseEventArgs args = new MouseEventArgs(e.Button, e.Clicks, e.X + pnlMain.Left, e.Y + pnlMain.Top, e.Delta);
			fmMain_MouseDown(sender, args);
		}

		void DrawFull(object sender, EventArgs e) {
			if(viewStyle != ViewStyle.Full) {
				viewStyle = ViewStyle.Full;
				if(drawStyle == DrawStyle.H_Style) H_Expend(sender, e);
				else V_Expend(sender, e);
			}
		}

		void DrawToRole(object sender, EventArgs e) {
			if(viewStyle != ViewStyle.Role) {
				viewStyle = ViewStyle.Role;
				if(drawStyle == DrawStyle.H_Style) H_Expend(sender, e);
				else V_Expend(sender, e);
			}
		}

		void DrawDeptOnly(object sender, EventArgs e) {
			if(viewStyle != ViewStyle.Dept) {
				viewStyle = ViewStyle.Dept;
				if(drawStyle == DrawStyle.H_Style) H_Expend(sender, e);
				else V_Expend(sender, e);
			}
		}

		void OnDelEmptyRole(object sender, EventArgs e) {
			if(MessageBox.Show("您確定要刪除空角色嗎？", "訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
				== DialogResult.Yes) {
				ezOrgDS.RoleDataTable dtRole = adRole.GetDataByEmpID("");
				for(int i = 0; i < dtRole.Count; i++) dtRole[i].Delete();
				adRole.Update(dtRole);

				MessageBox.Show("所有空白角色已刪除", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		void OnUndoDept(object sender, EventArgs e) {
			deptTrans = null;

			if(drawStyle == DrawStyle.H_Style) H_Expend(sender, e);
			else V_Expend(sender, e);
		}

		void OnPasteRootDept(object sender, EventArgs e) {			
			string idParent = "";
			string newPath = "/" + deptTrans.name;

			ezOrgDS.RoleDataTable dtRole = adRole.DeptMang_GetDataByDeptID(deptTrans.id);
			for(int i = 0; i < dtRole.Count; i++) dtRole[i].idParent = "";
			adRole.Update(dtRole);

			ezOrgDS.DeptDataTable dtDept = adDept.GetDataByID(deptTrans.id);
			dtDept[0].idParent = idParent;
			dtDept[0].path = newPath;
			adDept.Update(dtDept);

			deptTrans = null;

			if(drawStyle == DrawStyle.H_Style) H_Expend(sender, e);
			else V_Expend(sender, e);			
		}

		void H_Expend(object sender, EventArgs e) {
			if(sender.GetType() == typeof(ToolStripMenuItem)) {
				if(((ToolStripMenuItem)sender).Checked == true) return;
			}

			this.ActiveControl = null;

			this.ScrollPosition = this.AutoScrollPosition;

			drawStyle = DrawStyle.H_Style;

			CreateDept_Right();

			RefreshAll();

			pnlMain.Width = MaxX + 200;
			pnlMain.Height = MaxY + 100;

			if(this.ScrollPosition != Point.Empty) {
				int x = Math.Abs(this.ScrollPosition.X);
				int y = Math.Abs(this.ScrollPosition.Y);
				if(x > this.HorizontalScroll.Maximum) x = this.HorizontalScroll.Maximum * -1;
				if(y > this.VerticalScroll.Maximum) y = this.VerticalScroll.Maximum * -1;
				this.AutoScrollPosition = new Point(x, y);
			}

			this.ContextMenuStrip.Items.Clear();
		}

		void V_Expend(object sender, EventArgs e) {
			if(sender.GetType() == typeof(ToolStripMenuItem)) {
				if(((ToolStripMenuItem)sender).Checked == true) return;
			}

			this.ActiveControl = null;

			this.ScrollPosition = this.AutoScrollPosition;

			drawStyle = DrawStyle.V_Style;

			CreateDept_Down();

			RefreshAll();

			pnlMain.Width = MaxX + 200;
			pnlMain.Height = MaxY + 100;

			if(this.ScrollPosition != Point.Empty) {
				int x = Math.Abs(this.ScrollPosition.X);
				int y = Math.Abs(this.ScrollPosition.Y);
				if(x > this.HorizontalScroll.Maximum) x = this.HorizontalScroll.Maximum * -1;
				if(y > this.VerticalScroll.Maximum) y = this.VerticalScroll.Maximum * -1;
				this.AutoScrollPosition = new Point(x, y);
			}

			this.ContextMenuStrip.Items.Clear();
		}

		void OnSave(object sender, EventArgs e) {
			Bitmap bmp = new Bitmap(pnlMain.Width, pnlMain.Height, PixelFormat.Format32bppPArgb);
			Graphics.FromImage(bmp).FillRectangle(new SolidBrush(Color.White), 0, 0, bmp.Width, bmp.Height);			

			DrawToImage(Graphics.FromImage(bmp));

			string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
			bmp.Save(fileName, ImageFormat.Jpeg);
			MessageBox.Show("圖檔已輸出至 " + Application.StartupPath + "/" + fileName, "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void DrawToImage(Graphics g) {
			for(int i = 0; i < pnlMain.Controls.Count; i++) {
				if(pnlMain.Controls[i].GetType() == typeof(ImageBox)) {
					g.DrawImage(((ImageBox)pnlMain.Controls[i]).picturebox.Image,
						((ImageBox)pnlMain.Controls[i]).picturebox.Left + pnlMain.Controls[i].Left,
						((ImageBox)pnlMain.Controls[i]).picturebox.Top + pnlMain.Controls[i].Top,
						((ImageBox)pnlMain.Controls[i]).picturebox.Width,
						((ImageBox)pnlMain.Controls[i]).picturebox.Height);

					g.DrawString(((ImageBox)pnlMain.Controls[i]).label.Text,
						new Font("細明體", 10), new SolidBrush(Color.Black),
						((ImageBox)pnlMain.Controls[i]).label.Left + pnlMain.Controls[i].Left,
						((ImageBox)pnlMain.Controls[i]).label.Top + pnlMain.Controls[i].Top);

					g.DrawRectangle(new Pen(new SolidBrush(Color.Black), 2),
						pnlMain.Controls[i].Left + ImageBox.offsetX,
						pnlMain.Controls[i].Top + ImageBox.offsetY,
						pnlMain.Controls[i].Width - ImageBox.offsetX * 2 - 1,
						pnlMain.Controls[i].Height - ImageBox.offsetY * 2 - 1);					
				}
				if(pnlMain.Controls[i].GetType() == typeof(ImageLink)) {
					((ImageLink)pnlMain.Controls[i]).PrintDrawLine(g);
				}
			}			
		}

		void OnCreateRoot(object sender, EventArgs e) {
			dlgOrg.idParent = "";
			dlgOrg.deptPath = "";
			if(dlgOrg.ShowDialog() == DialogResult.OK) {
				if(drawStyle == DrawStyle.H_Style) H_Expend(sender, e);
				else V_Expend(sender, e);
			}
		}

		void OnCreatePos(object sender, EventArgs e) {
			dlgPos.ShowDialog();
		}

		void OnCreateEmp(object sender, EventArgs e) {
			dlgEmp.Emp_id = "";
			dlgEmp.ShowDialog();
		}

		void imgBox_Dept_MouseDown(object sender, MouseEventArgs e) {
			if(e.Button == MouseButtons.Right) {
				((Control)sender).ContextMenuStrip = new ContextMenuStrip();
				((Control)sender).ContextMenuStrip.Items.Add("新增新的角色", null, new EventHandler(OnCreateRole));
				((Control)sender).ContextMenuStrip.Items.Add("建立新子部門", null, new EventHandler(OnCreateSubDept));
				((Control)sender).ContextMenuStrip.Items.Add("部門預設主管", null, new EventHandler(OnDeptMg));
				((Control)sender).ContextMenuStrip.Items.Add("-");
				if(deptTrans == null)
					((Control)sender).ContextMenuStrip.Items.Add("剪下整個部門", null, new EventHandler(OnCutDept));
				else {
					((Control)sender).ContextMenuStrip.Items.Add("貼上整個部門", null, new EventHandler(OnPasteDept));
				}
				((Control)sender).ContextMenuStrip.Items.Add("-");
				((Control)sender).ContextMenuStrip.Items.Add("刪除整個部門", null, new EventHandler(OnDeleteDept));
			}
		}

		void OnDeptMg(object sender, EventArgs e) {
			dlgDeptMg.sDeptID = ((ImageBox)this.ActiveControl).data2.ToString();
			if(dlgDeptMg.ShowDialog() == DialogResult.OK) {
				if(drawStyle == DrawStyle.H_Style) H_Expend(sender, e);
				else V_Expend(sender, e);
			}
		}

		void OnCutDept(object sender, EventArgs e) {
			if(MessageBox.Show("您確定要剪下此部門？", "訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
				== DialogResult.Yes) {
				ezOrgDS.DeptDataTable dtDept = adDept.GetDataByID(((ImageBox)this.ActiveControl).data2.ToString());
				deptTrans = new DeptTrans();
				deptTrans.id = dtDept[0].id;
				deptTrans.name = dtDept[0].name;
				deptTrans.path = dtDept[0].path;
				this.ActiveControl = null;

				if(drawStyle == DrawStyle.H_Style) H_Expend(sender, e);
				else V_Expend(sender, e);
			}
		}

		void OnPasteDept(object sender, EventArgs e) {
			ezOrgDS.DeptDataTable dtDeptParent = adDept.GetDataByID(((ImageBox)this.ActiveControl).data2.ToString());
			string idParent = dtDeptParent[0].id;
			string newPath = dtDeptParent[0].path + "/" + deptTrans.name;

			UpdateDeptTree(deptTrans.id, deptTrans.path, newPath);

			ezOrgDS.DeptDataTable dtDept = adDept.GetDataByID(deptTrans.id);
			dtDept[0].idParent = idParent;
			dtDept[0].path = newPath;
			adDept.Update(dtDept);

			ezOrgDS.RoleDataTable dtRole = adRole.DeptMang_GetDataByDeptID(deptTrans.id);
			for(int i = 0; i < dtRole.Count; i++) dtRole[i].idParent = "";
			adRole.Update(dtRole);

			deptTrans = null;

			if(drawStyle == DrawStyle.H_Style) H_Expend(sender, e);
			else V_Expend(sender, e);
		}

		void UpdateDeptTree(string idParent,string oldPath, string newPath) {
			ezOrgDS.DeptDataTable dtDept = adDept.GetDataByParent(idParent);
			for(int i = 0; i < dtDept.Count; i++) {
				dtDept[i].path = dtDept[i].path.Replace(oldPath, newPath);
				UpdateDeptTree(dtDept[i].id, oldPath, newPath);
			}
			adDept.Update(dtDept);
		}

		void OnCreateRole(object sender, EventArgs e) {
			dlgRole.sDeptID = ((ImageBox)this.ActiveControl).data2.ToString();
			dlgRole.sParentID = "";
			if(dlgRole.ShowDialog() == DialogResult.OK) {
				if(drawStyle == DrawStyle.H_Style) H_Expend(sender, e);
				else V_Expend(sender, e);
			}
		}

		void OnCreateSubDept(object sender, EventArgs e) {
			ezOrgDS.DeptDataTable dtDept = adDept.GetDataByID(((ImageBox)this.ActiveControl).data2.ToString());
			dlgOrg.idParent = ((ImageBox)this.ActiveControl).data2.ToString();
			dlgOrg.deptPath = dtDept[0].path;
			if(dlgOrg.ShowDialog() == DialogResult.OK) {
				if(drawStyle == DrawStyle.H_Style) H_Expend(sender, e);
				else V_Expend(sender, e);
			}
		}

		void OnDeleteDept(object sender, EventArgs e) {
			if(MessageBox.Show("您確定要刪除部門嗎？", "訊息通知", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
				DialogResult.Yes) {
				string sDeptID = ((ImageBox)this.ActiveControl).data2.ToString();

				DeptDelete(sDeptID);

				if(drawStyle == DrawStyle.H_Style) H_Expend(sender, e);
				else V_Expend(sender, e);				
			}
		}

		void DeptDelete(string DeptID) {
			ezOrgDS.DeptDataTable dtSubDept = adDept.GetDataByParent(DeptID);
			foreach(DataRow rowSubDept in dtSubDept.Rows) {
				DeptDelete(rowSubDept["id"].ToString());
			}

			ezOrgDS.RoleDataTable dtRole = adRole.GetDataByDeptID(DeptID);
			foreach(DataRow rowRole in dtRole.Rows) {
				ezOrgDS.WorkAgentDataTable dtWorkAgent = adWorkAgent.GetDataByRoleID(rowRole["id"].ToString());				
				foreach(DataRow rowWorkAgent in dtWorkAgent.Rows) {
					ezOrgDS.WorkAgentPowerDataTable dtWorkAgentPower = 
						adWorkAgentPower.GetDataByWorkAgent(Convert.ToInt32(rowWorkAgent["auto"]));
					foreach(DataRow rowWorkAgentPower in dtWorkAgentPower.Rows) rowWorkAgentPower.Delete();
					adWorkAgentPower.Update(dtWorkAgentPower);
					rowWorkAgent.Delete();
				}
				adWorkAgent.Update(dtWorkAgent);

				ezOrgDS.CheckAgentDefaultDataTable dtCheckAgentDefault = adCheckAgentDefault.GetDataByRoleID(rowRole["id"].ToString());
				foreach(DataRow rowCheckAgentDefault in dtCheckAgentDefault.Rows) {
					ezOrgDS.CheckAgentPowerMDataTable dtCheckAgentPowerM = adCheckAgentPowerM.GetDataByCheckAgentAlways(Convert.ToInt32(rowCheckAgentDefault["auto"]));
					foreach(DataRow rowCheckAgentPowerM in dtCheckAgentPowerM.Rows) {
						ezOrgDS.CheckAgentPowerDDataTable dtCheckAgentPowerD = adCheckAgentPowerD.GetDataByCheckAgentPowerM(Convert.ToInt32(rowCheckAgentPowerM["auto"]));
						foreach(DataRow rowCheckAgentPowerD in dtCheckAgentPowerD.Rows) rowCheckAgentPowerD.Delete();
						adCheckAgentPowerD.Update(dtCheckAgentPowerD);
						rowCheckAgentPowerM.Delete();
					}
					adCheckAgentPowerM.Update(dtCheckAgentPowerM);
					rowCheckAgentDefault.Delete();
				}
				adCheckAgentDefault.Update(dtCheckAgentDefault);

				rowRole.Delete();
			}
			adRole.Update(dtRole);
			ezOrgDS.DeptDataTable dtDept = adDept.GetDataByID(DeptID);
			dtDept[0].Delete();
			adDept.Update(dtDept);
		}

		void imgBox_Role_MouseDown(object sender, MouseEventArgs e) {
			if(e.Button == MouseButtons.Right) {
				((Control)sender).ContextMenuStrip = new ContextMenuStrip();
				((Control)sender).ContextMenuStrip.Items.Add("加入新的成員", null, new EventHandler(OnNewMember));				
				((Control)sender).ContextMenuStrip.Items.Add("建立新子角色", null, new EventHandler(OnCreateSubRole));
				((Control)sender).ContextMenuStrip.Items.Add("-");
				if(empTrans != null && empTrans.role_id != ((ImageBox)sender).data2.ToString()) {
					((Control)sender).ContextMenuStrip.Items.Add("貼上員工資料", null, new EventHandler(OnPasteEmp));
				}
				((Control)sender).ContextMenuStrip.Items.Add("變更父階角色", null, new EventHandler(OnChgMang));
				((Control)sender).ContextMenuStrip.Items.Add("升為部門主管", null, new EventHandler(OnDeptMang));
				((Control)sender).ContextMenuStrip.Items.Add("-");
				((Control)sender).ContextMenuStrip.Items.Add("刪除選定角色", null, new EventHandler(OnDeleteRole));
			}
		}

		void OnDeptMang(object sender, EventArgs e) {
			string sRoleID = ((ImageBox)this.ActiveControl).data2.ToString();
			ezOrgDS.RoleDataTable dtRole = adRole.GetDataByID(sRoleID);
			for(int i = 0; i < dtRole.Count; i++) dtRole[i].idParent = "";
			adRole.Update(dtRole);

			if(drawStyle == DrawStyle.H_Style) H_Expend(sender, e);
			else V_Expend(sender, e);
		}

		void OnPasteEmp(object sender, EventArgs e) {
			string sRoleID = ((ImageBox)this.ActiveControl).data2.ToString();
			ezOrgDS.RoleDataTable dtRole = adRole.GetDataByID(sRoleID);
			ezOrgDS.RoleRow rRole = null;
			for(int i = 0; i < dtRole.Count; i++) {
				if(dtRole[i].IsEmp_idNull() || dtRole[i].Emp_id.Trim().Length == 0) {
					rRole = dtRole[i];
					break;
				}
			}
			if(rRole == null) {
				rRole = dtRole.NewRoleRow();
				rRole.id = sRoleID;
				rRole.idParent = dtRole[0].idParent;
				rRole.Dept_id = dtRole[0].Dept_id;
				rRole.Pos_id = dtRole[0].Pos_id;
				rRole.dateB = DateTime.Now.Date;
				rRole.dateE = Convert.ToDateTime("2099/12/31");
				rRole.mgDefault = false;
				dtRole.AddRoleRow(rRole);
			}
			rRole.Emp_id = empTrans.id;
			adRole.Update(dtRole);

			empTrans = null;

			if(drawStyle == DrawStyle.H_Style) H_Expend(sender, e);
			else V_Expend(sender, e);
		}

		void OnChgMang(object sender, EventArgs e) {
			dlgChgMang.sRoleID = ((ImageBox)this.ActiveControl).data2.ToString();

			if(dlgChgMang.ShowDialog() == DialogResult.OK) {
				if(drawStyle == DrawStyle.H_Style) H_Expend(sender, e);
				else V_Expend(sender, e);
			}
		}

		void OnNewMember(object sender, EventArgs e) {
			string sRoleID = ((ImageBox)this.ActiveControl).data2.ToString();
			if(dlgNewMember.ShowDialog() == DialogResult.OK) {
				ezOrgDS.RoleDataTable dtRole = adRole.GetDataByID(sRoleID);
				ezOrgDS.RoleRow rRole = null;
				for(int i = 0; i < dtRole.Count; i++) {
					if(dtRole[i].IsEmp_idNull() || dtRole[i].Emp_id.Trim().Length == 0) {
						rRole = dtRole[i];
						break;
					}
				}
				if(rRole == null) {
					rRole = dtRole.NewRoleRow();
					rRole.id = sRoleID;
					rRole.idParent = dtRole[0].idParent;
					rRole.Dept_id = dtRole[0].Dept_id;
					rRole.Pos_id = dtRole[0].Pos_id;
					rRole.dateB = DateTime.Now.Date;
					rRole.dateE = Convert.ToDateTime("2099/12/31");
					rRole.mgDefault = false;
					rRole.deptMg = false;
					dtRole.AddRoleRow(rRole);
				}
				rRole.Emp_id = dlgNewMember.Emp_id;
				adRole.Update(dtRole);

				if(drawStyle == DrawStyle.H_Style) H_Expend(sender, e);
				else V_Expend(sender, e);
			}
		}

		void OnCreateSubRole(object sender, EventArgs e) {
			string sRoleID = ((ImageBox)this.ActiveControl).data2.ToString();
			ezOrgDS.RoleDataTable dtRole = adRole.GetDataByID(sRoleID);
			dlgRole.sDeptID = dtRole[0].Dept_id;
			dlgRole.sParentID = dtRole[0].id;
			if(dlgRole.ShowDialog() == DialogResult.OK) {
				if(drawStyle == DrawStyle.H_Style) H_Expend(sender, e);
				else V_Expend(sender, e);
			}
		}

		void OnDeleteRole(object sender, EventArgs e) {
			if(MessageBox.Show("您確定要刪除嗎？", "訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
				DialogResult.Yes) {
				string sRoleID = ((ImageBox)this.ActiveControl).data2.ToString();				
				ezOrgDS.RoleDataTable dtRole = adRole.GetDataByID(sRoleID);
				ezOrgDS.RoleDataTable dtSubRole = adRole.GetDataByParent(sRoleID, dtRole[0].Dept_id);
				for(int i = 0; i < dtSubRole.Count; i++) dtSubRole[i].idParent = dtRole[0].idParent;
				adRole.Update(dtSubRole);
				dtRole[0].Delete();
				adRole.Update(dtRole);

				if(drawStyle == DrawStyle.H_Style) H_Expend(sender, e);
				else V_Expend(sender, e);
			}
		}

		void imgBox_Emp_MouseDown(object sender, MouseEventArgs e) {
			if(e.Button == MouseButtons.Right) {
				((Control)sender).ContextMenuStrip = new ContextMenuStrip();
				((Control)sender).ContextMenuStrip.Items.Add("重新設定密碼", null, new EventHandler(OnResetPW));
				((Control)sender).ContextMenuStrip.Items.Add("基本資料維護", null, new EventHandler(OnModifyEmp));
				((Control)sender).ContextMenuStrip.Items.Add("預設處理角色", null, new EventHandler(OnMgDefault));
				((Control)sender).ContextMenuStrip.Items.Add("-");
				((Control)sender).ContextMenuStrip.Items.Add("複製員工資料", null, new EventHandler(OnCopyEmp));
				((Control)sender).ContextMenuStrip.Items.Add("-");
				((Control)sender).ContextMenuStrip.Items.Add("查工作代理人", null, new EventHandler(OnWorkAgent));
				((Control)sender).ContextMenuStrip.Items.Add("查簽核代理人", null, new EventHandler(OnCheckAgent));
				((Control)sender).ContextMenuStrip.Items.Add("-");
				((Control)sender).ContextMenuStrip.Items.Add("取消擔任職位", null, new EventHandler(OnCancelRole));
				((Control)sender).ContextMenuStrip.Items.Add("刪除員工資料", null, new EventHandler(OnDeleteEmp));
			}
		}

		void OnModifyEmp(object sender, EventArgs e) {
			dlgEmp.Emp_id = ((ImageBox)this.ActiveControl).data2.ToString();
			dlgEmp.ShowDialog();
		}

		void OnWorkAgent(object sender, EventArgs e) {
			fmWorkAgent dlgWorkAgent = new fmWorkAgent();

			dlgWorkAgent.sEmpID = ((ImageBox)this.ActiveControl).data2.ToString();
			dlgWorkAgent.sRoleID = ((ImageBox)this.ActiveControl).data3.ToString();

			dlgWorkAgent.ShowDialog();
		}

		void OnCheckAgent(object sender, EventArgs e) {
			fmCheckAgent dlgCheckAgent = new fmCheckAgent();

			dlgCheckAgent.sEmpID = ((ImageBox)this.ActiveControl).data2.ToString();
			dlgCheckAgent.sRoleID = ((ImageBox)this.ActiveControl).data3.ToString();

			dlgCheckAgent.ShowDialog();
		}

		void OnMgDefault(object sender, EventArgs e) {
			string sEmpID = ((ImageBox)this.ActiveControl).data2.ToString();
			string sRoleID = ((ImageBox)this.ActiveControl).data3.ToString();

			ezOrgDS.RoleDataTable dtRole = adRole.GetDataByID(sRoleID);
			for(int i = 0; i < dtRole.Count; i++) {
				if(dtRole[i].Emp_id == sEmpID) dtRole[i].mgDefault = true;
				else dtRole[i].mgDefault = false;
			}
			adRole.Update(dtRole);

			if(drawStyle == DrawStyle.H_Style) H_Expend(sender, e);
			else V_Expend(sender, e);
		}

		void OnCopyEmp(object sender, EventArgs e) {
			empTrans = new EmpTrans();
			empTrans.id = ((ImageBox)this.ActiveControl).data2.ToString();
			empTrans.name = ((ImageBox)this.ActiveControl).label.Text;
			empTrans.role_id = ((ImageBox)this.ActiveControl).data3.ToString();
		}

		void OnResetPW(object sender, EventArgs e) {
			dlgChgPW.ShowDialog();
		}

		void OnCancelRole(object sender, EventArgs e) {
			if(MessageBox.Show("您確定要取消該員工的職位擔任？", "訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
				== DialogResult.Yes) {
				string sEmpID = ((ImageBox)this.ActiveControl).data2.ToString();
				string sRoleID = ((ImageBox)this.ActiveControl).data3.ToString();
				ezOrgDS.RoleDataTable dtRole = adRole.GetDataByIDAndEmpID(sRoleID,sEmpID);
				dtRole[0].Emp_id = "";
				adRole.Update(dtRole);

				if(drawStyle == DrawStyle.H_Style) H_Expend(sender, e);
				else V_Expend(sender, e);
			}
		}

		void OnDeleteEmp(object sender, EventArgs e) {
			if(MessageBox.Show("您確定要刪除此員工嗎？", "訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
				== DialogResult.Yes) {
				string sEmpID = ((ImageBox)this.ActiveControl).data2.ToString();
				ezOrgDS.RoleDataTable dtRole = adRole.GetDataByEmpID(sEmpID);
				for(int i = 0; i < dtRole.Count; i++) dtRole[i].Delete();
				adRole.Update(dtRole);

				ezOrgDS.EmpDataTable dtEmp = adEmp.GetDataByID(sEmpID);
				dtEmp[0].Delete();
				adEmp.Update(dtEmp);

				if(drawStyle == DrawStyle.H_Style) H_Expend(sender, e);
				else V_Expend(sender, e);
			}
		}
	}
}