using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

public partial class Home : System.Web.UI.Page
{

    AllModule Module = new AllModule();
    protected void Page_Load(object sender, EventArgs e)
    {
		if(Request.Cookies["ezFlow"]["ActiveViewIndex"] == null || Request.Cookies["ezFlow"]["SelectedDate"] == null) {
			Response.Cookies["ezFlow"]["Emp_id"] = Request.Cookies["ezFlow"]["Emp_id"];
			Response.Cookies["ezFlow"]["ActiveViewIndex"] = MultiView1.ActiveViewIndex.ToString();
			if(Calendar1.SelectedDate.ToString("yyyy/MM/dd") == "0001/01/01") {
				Response.Cookies["ezFlow"]["SelectedDate"] = DateTime.Now.ToString("yyyy/MM/dd");
				ViewState["SelectedDate"] = DateTime.Now.ToString("yyyy/MM/dd");
			}
			else {
				Response.Cookies["ezFlow"]["SelectedDate"] = Request.Cookies["ezFlow"]["SelectedDate"];
				ViewState["SelectedDate"] = Request.Cookies["ezFlow"]["SelectedDate"];
			}
			Response.Cookies["ezFlow"].Expires = DateTime.Now.AddDays(1);			
		}
		else {
			MultiView1.ActiveViewIndex = Convert.ToInt32(Request.Cookies["ezFlow"]["ActiveViewIndex"]);
			ViewState["SelectedDate"] = Request.Cookies["ezFlow"]["SelectedDate"];
		}

		if(!IsPostBack) {
			if(RadioButtonList1.SelectedItem != null) RadioButtonList1.SelectedItem.Selected = false;
			RadioButtonList1.Items.FindByValue(MultiView1.ActiveViewIndex.ToString()).Selected = true;
		}

		Session["Emp_id"] = Request.Cookies["ezFlow"]["Emp_id"];

		ezClientDS.RoleDataTable dtRole = Module.adRole.GetDataByEmp(Session["Emp_id"].ToString());
		if(dtRole.Count == 0) {
			Response.Cookies["ezFlow"].Expires = DateTime.Now.AddDays(-1);			
			Response.Redirect("default.aspx");
		}

		object ret = Module.adWorkList.CountQuery(Request.Cookies["ezFlow"]["Emp_id"]);
		if(ret == null) ret = "0";

		lbMsg.Text = "待辦事項共 " + ret.ToString() + " 個項目";

		ezClientDS.BestViewDataTable dtBestView;
		ezClientDS.EmpDataTable dtEmp;

		dtEmp = Module.adEmp.GetDataById(Request.Cookies["ezFlow"]["Emp_id"].ToString());
		if(dtEmp.Count > 0) lbName.Text = dtEmp[0].name;

		dtBestView = Module.adBestView.GetDataByBestPraise();
		if(dtBestView.Count > 0) {
			dtEmp = Module.adEmp.GetDataById(dtBestView[0].Emp_id);
			lbBestPraise.Text = dtEmp[0].name + ",共" + dtBestView[0].Counter.ToString() + "個讚美";
		}
		else lbBestPraise.Text = "(從缺)";

		dtBestView = Module.adBestView.GetDataByBestPost();
		if(dtBestView.Count > 0) {
			dtEmp = Module.adEmp.GetDataById(dtBestView[0].Emp_id);
			lbBestPost.Text = dtEmp[0].name + ",共" + dtBestView[0].Counter.ToString() + "篇發表";
		}
		else lbBestPost.Text = "(從缺)";

		dtBestView = Module.adBestView.GetDataByBestReply();
		if(dtBestView.Count > 0) {
			dtEmp = Module.adEmp.GetDataById(dtBestView[0].Emp_id);
			lbBestReply.Text = dtEmp[0].name + ",共" + dtBestView[0].Counter.ToString() + "篇回應";
		}
		else lbBestReply.Text = "(從缺)";

		ezClientDS.GuestMsgDataTable dtGuestMsg = Module.adGuestMsg.GetDataByEmp(Request.Cookies["ezFlow"]["Emp_id"]);
		if(dtGuestMsg.Count == 0) bnGuestHistory.Enabled = false;

		object count = Module.adGuestMsg.ScalarQueryForNotRead(Request.Cookies["ezFlow"]["Emp_id"]);
		if(count != null && Convert.ToInt32(count) > 0) {
			linkBtnGuest.Text = "您有 " + count.ToString() + " 個未讀訊息";			
		}

		if(ViewState["Year"] == null) {
			ViewState["Year"] = DateTime.Now.Year;
			Session["Year"] = DateTime.Now.Year;
		}
		else Session["Year"] = ViewState["Year"];

		if(ViewState["Month"] == null) {
			ViewState["Month"] = DateTime.Now.Month;
			Session["Month"] = DateTime.Now.Month;
		}
		else Session["Month"] = ViewState["Month"];
		
		Session["calDateB"] = ViewState["Year"].ToString() + "/" + ViewState["Month"].ToString() + "/1 00:00:00";
		Session["calDateB"] = Convert.ToDateTime(Session["calDateB"]).AddDays(-7);
		Session["calDateE"] = ViewState["Year"].ToString() + "/" + ViewState["Month"].ToString() +
			"/" + DateTime.DaysInMonth(Convert.ToInt32(ViewState["Year"]), Convert.ToInt32(ViewState["Month"])).ToString() + " 23:59:59";
		Session["calDateE"] = Convert.ToDateTime(Session["calDateE"]).AddDays(7);

		Session["EmpCal"] = Module.adCalendar.GetDataByEmpCal(Session["Emp_id"].ToString(), Convert.ToDateTime(Session["calDateB"]), Convert.ToDateTime(Session["calDateE"]));

		ViewState["baseDate"] = ViewState["SelectedDate"];
		Session["baseDate"] = ViewState["SelectedDate"];

		Session["baseDateB"] = Convert.ToDateTime(ViewState["baseDate"]).ToString("yyyy-MM-dd") + " 00:00:00";
		Session["baseDateE"] = Convert.ToDateTime(ViewState["baseDate"]).ToString("yyyy-MM-dd") + " 23:59:59";		

		Calendar1.SelectedDates.Add(Convert.ToDateTime(ViewState["baseDate"]));

		lbSelectedDate.Text = Convert.ToDateTime(ViewState["baseDate"]).ToString("yyyy-MM-dd");
		lbSelectedDate1.Text = lbSelectedDate.Text;
		lbSelectedDate2.Text = lbSelectedDate.Text;
		lbQueryDate.Text = lbSelectedDate.Text;

		Session["Emp_id"] = Request.Cookies["ezFlow"]["Emp_id"];

		if(!IsPostBack) {
			if(Module.adDeviceDate.GetData(Convert.ToDateTime(ViewState["baseDate"])).Count > 0) pnlEmpty.Visible = false;
			else pnlEmpty.Visible = true;

			ListItem lstItem1 = new ListItem(DateTime.Now.Year.ToString(), DateTime.Now.Year.ToString());
			ListItem lstItem2 = new ListItem(Convert.ToString(DateTime.Now.Year + 1), Convert.ToString(DateTime.Now.Year + 1));
			cbQueryYear1.Items.Add(lstItem1);
			cbQueryYear1.Items.Add(lstItem2);
			cbQueryYear2.Items.Add(lstItem1);
			cbQueryYear2.Items.Add(lstItem2);
			cbQueryYear3.Items.Add(lstItem1);
			cbQueryYear3.Items.Add(lstItem2);
			cbQueryYear4.Items.Add(lstItem1);
			cbQueryYear4.Items.Add(lstItem2);
			if(cbQueryMonth1.SelectedItem != null) cbQueryMonth1.SelectedItem.Selected = false;
			cbQueryMonth1.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = true;
			if(cbQueryMonth2.SelectedItem != null) cbQueryMonth2.SelectedItem.Selected = false;
			cbQueryMonth2.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = true;
			if(cbQueryMonth3.SelectedItem != null) cbQueryMonth3.SelectedItem.Selected = false;
			cbQueryMonth3.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = true;
			if(cbQueryMonth4.SelectedItem != null) cbQueryMonth4.SelectedItem.Selected = false;
			cbQueryMonth4.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = true;


			ezClientDS.SysAdminDataTable dtSysAdmin = Module.adSysAdmin.GetDataByEmp(Session["Emp_id"].ToString());
			if(dtSysAdmin.Count > 0) ViewState["SysAdmin"] = true;
			else ViewState["SysAdmin"] = false;

			ViewState["DeptMg"] = "";
			ViewState["FullDeptTree"] = "";

			ezClientDS.RoleDataTable dtMyRole = Module.adRole.GetDataByEmp(Session["Emp_id"].ToString());
			
			foreach(ezClientDS.RoleRow rowMyRole in dtMyRole.Rows) {
				ezClientDS.DeptDataTable dtDept = Module.adDept.GetDataById(rowMyRole.Dept_id);
				if(dtDept.Count > 0) {
					ezClientDS.DeptDataTable dtFullDept = Module.adDept.GetDataByFullPath(dtDept[0].path);
					foreach(ezClientDS.DeptRow rowDept in dtFullDept.Rows) {
						if(ViewState["FullDeptTree"].ToString().Trim().Length == 0) ViewState["FullDeptTree"] = rowDept.id;
						else ViewState["FullDeptTree"] = ViewState["FullDeptTree"].ToString() + "," + rowDept.id;
					}
				}
				ezClientDS.RoleDataTable dtDeptMangRole = Module.adRole.GetDataByDeptMg(rowMyRole.Dept_id);
				
				foreach(ezClientDS.RoleRow rowMangRole in dtDeptMangRole.Rows) {
					if(rowMangRole.id == rowMyRole.id && dtDept.Count > 0) {
						ezClientDS.DeptDataTable dtDeptSubAll = Module.adDept.GetDataByPath(dtDept[0].path);
						if(dtDeptSubAll.Count > 0) {
							foreach(ezClientDS.DeptRow rowDept in dtDeptSubAll.Rows) {
								if(ViewState["DeptMg"].ToString().Trim().Length > 0) {
									if(ViewState["DeptMg"].ToString().IndexOf(rowDept.id) == -1) {
										ViewState["DeptMg"] = ViewState["DeptMg"].ToString() + "," + rowDept.id;										
									}
								}
								else {
									ViewState["DeptMg"] = rowDept.id;									
								}
							}
						}
						break;
					}
				}

				DataView dvDept = new DataView();
			}

			if(ViewState["DeptMg"].ToString().Trim().Length > 0) {
				ezClientDS.DeptDataTable dtDept = Module.adDept.GetDataByAllSub(ViewState["DeptMg"].ToString());
				if(dtDept.Count > 0) {
					foreach(ezClientDS.DeptRow rowDept in dtDept.Rows) {
						ListItem lstItem = new ListItem(rowDept.name,rowDept.id);
						cbDept.Items.Add(lstItem);
					}
				}
			}

			if(!Convert.ToBoolean(ViewState["SysAdmin"])) {
				RadioButtonList2.Items.Remove(RadioButtonList2.Items.FindByText("新增公司記事"));
			}
			if(ViewState["DeptMg"].ToString().Trim().Length == 0) {
				RadioButtonList2.Items.Remove(RadioButtonList2.Items.FindByText("新增部門記事"));
			}			
		}

		if(ViewState["FullDeptTree"] != null) Session["FullDeptTree"] = ViewState["FullDeptTree"];
		Session["AllCal"] = Module.adCalendarAll.GetDataByDate(Convert.ToDateTime(Session["calDateB"]), Convert.ToDateTime(Session["calDateE"]),Session["FullDeptTree"].ToString());
		Session["dtDeviceUse"] = Module.adDeviceCalendar.GetData(Convert.ToDateTime(Session["calDateB"]), Convert.ToDateTime(Session["calDateE"]));
    }

	protected void dlstBoard_ItemDataBound(object sender, DataListItemEventArgs e) {
		if(e.Item.DataItem != null) {
			ezClientDS.BoardListRow rowBoardList = (ezClientDS.BoardListRow)((DataRowView)e.Item.DataItem).Row;
			ezClientDS.EmpDataTable dtEmp;
			Control ctrl = e.Item.FindControl("lbAdmin");
			if(ctrl != null) {
				Label lbAdmin = (Label)ctrl;
				if(!rowBoardList.IsEmp_idAdmin1Null() && rowBoardList.Emp_idAdmin1.Trim().Length > 0) {
					dtEmp = Module.adEmp.GetDataById(rowBoardList.Emp_idAdmin1);
					if(dtEmp.Count > 0) lbAdmin.Text = dtEmp[0].name;
				}
				if(!rowBoardList.IsEmp_idAdmin2Null() && rowBoardList.Emp_idAdmin2.Trim().Length > 0) {
					dtEmp = Module.adEmp.GetDataById(rowBoardList.Emp_idAdmin2);
					if(dtEmp.Count > 0) {
						if(lbAdmin.Text.Trim().Length > 0) lbAdmin.Text += ",";
						lbAdmin.Text += dtEmp[0].name;
					}
				}
			}

			ctrl = e.Item.FindControl("captionLabel");
			if(ctrl != null) {
				Label captionLabel = (Label)ctrl;
				captionLabel.Text += " - 目前共 " + Module.adPostMain.CountQuery(rowBoardList.auto).ToString() + " 個主題";
				captionLabel.Text = "<a href='PostMain.aspx?BoardList_auto=" + rowBoardList.auto.ToString() + "'>" +
					captionLabel.Text + "</a>";
			}
		}
	}

	protected void bnGuestHistory_Click(object sender, EventArgs e) {
		string link = "MyFrame.aspx?url=GuestHistory.aspx?Flag=All";
		string script = "var sFeatures = 'dialogWidth:500px;dialogHeight:394px;center:yes;help:no;resizable:no;scroll:no;status:no';" +
			"window.showModalDialog('" + link + "', '', sFeatures);" +
			"self.location = 'Home.aspx';";
		if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "GuestHistory"))
			Page.ClientScript.RegisterStartupScript(typeof(string), "GuestHistory", script, true);		
	}

	protected void bnWriteGuest_Click(object sender, EventArgs e) {
		string link = "MyFrame.aspx?url=WriteGuest.aspx";
		string script = "var sFeatures = 'dialogWidth:500px;dialogHeight:400px;center:yes;help:no;resizable:no;scroll:no;status:no';" +
			"window.showModalDialog('" + link + "', '', sFeatures);";
		if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "GuestHistory"))
			Page.ClientScript.RegisterStartupScript(typeof(string), "GuestHistory", script, true);
	}

	protected void linkBtnGuest_Click(object sender, EventArgs e) {
		if(linkBtnGuest.Text != "目前沒有尚未閱讀的留言") {
			string link = "MyFrame.aspx?url=GuestHistory.aspx?Flag=NotRead";
			string script = "var sFeatures = 'dialogWidth:500px;dialogHeight:394px;center:yes;help:no;resizable:no;scroll:no;status:no';" +
				"window.showModalDialog('" + link + "', '', sFeatures);" +
				"self.location = 'Home.aspx';";
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "GuestHistory"))
				Page.ClientScript.RegisterStartupScript(typeof(string), "GuestHistory", script, true);
		}		
	}

	protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e) {
		if(e.CommandName == "Link") {
			string link = "MyFrame.aspx?url=HrPost.aspx?HrPost_auto=" + e.CommandArgument.ToString();
			string script = "var sFeatures = 'dialogWidth:760px;dialogHeight:500px;center:yes;help:no;resizable:no;scroll:no;status:no';" +
				"window.showModalDialog('" + link + "', '', sFeatures);";				
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "HrPost"))
				Page.ClientScript.RegisterStartupScript(typeof(string), "HrPost", script, true);
		}
		if(e.CommandName == "NewPost") {
			string link = "MyFrame.aspx?url=NewHrPost.aspx";
			string script = "var sFeatures = 'dialogWidth:760px;dialogHeight:500px;center:yes;help:no;resizable:no;scroll:no;status:no';" +
				"window.showModalDialog('" + link + "', '', sFeatures);" +
				"self.location = 'Home.aspx';";
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "HrPost"))
				Page.ClientScript.RegisterStartupScript(typeof(string), "HrPost", script, true);
		}
	}

	protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e) {
		if(e.Item.ItemType == ListItemType.Header) {
			Control ctrl = e.Item.FindControl("bnAdmin");
			if(ctrl != null) {
				ezClientDS.SysAdminDataTable dtSysAdmin = Module.adSysAdmin.GetDataByEmp(Request.Cookies["ezFlow"]["Emp_id"].ToString());
				if(dtSysAdmin.Count > 0) ctrl.Visible = true;
				else ctrl.Visible = false;
			}
		}
	}

	protected void linkBtnBoardApply_Click(object sender, EventArgs e) {
		string link = "MyFrame.aspx?url=BoardApply.aspx";
		string script = "var sFeatures = 'dialogWidth:470px;dialogHeight:320px;center:yes;help:no;resizable:no;scroll:no;status:no';" +
			"window.showModalDialog('" + link + "', '', sFeatures);";
		if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "BoardApply"))
			Page.ClientScript.RegisterStartupScript(typeof(string), "BoardApply", script, true);
	}

	protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e) {
		MultiView1.ActiveViewIndex = Convert.ToInt32(RadioButtonList1.SelectedValue);
		Response.Cookies["ezFlow"]["Emp_id"] = Request.Cookies["ezFlow"]["Emp_id"];
		Response.Cookies["ezFlow"]["ActiveViewIndex"] = MultiView1.ActiveViewIndex.ToString();
		Response.Cookies["ezFlow"]["SelectedDate"] = Request.Cookies["ezFlow"]["SelectedDate"];
		Response.Cookies["ezFlow"].Expires = DateTime.Now.AddDays(1);
	}

	protected void Calendar1_DayRender(object sender, DayRenderEventArgs e) {		
		ezClientDS.CalendarDataTable dtCalendar = (ezClientDS.CalendarDataTable)Session["EmpCal"];
		ezClientDS.CalendarAllDataTable dtCalendarAll = (ezClientDS.CalendarAllDataTable)Session["AllCal"];

		Table table = new Table();
		table.BorderStyle = BorderStyle.None;
		table.BorderWidth = 0;
		table.Width = Unit.Parse("100%");		
		TableCell cellSelf = new TableCell();
		cellSelf.Width = Unit.Parse("25%");
		cellSelf.Height = Unit.Parse("5px");
		cellSelf.Text = " ";
		cellSelf.BackColor = Color.Orange;
		TableCell cellOther = new TableCell();
		cellOther.Width = Unit.Parse("25%");
		cellOther.Height = Unit.Parse("5px");
		cellOther.Text = " ";
		cellOther.BackColor = Color.MediumOrchid;
		TableCell cellDept = new TableCell();
		cellDept.Width = Unit.Parse("25%");
		cellDept.Height = Unit.Parse("5px");
		cellDept.Text = " ";
		cellDept.BackColor = Color.Green;
		TableCell cellAll = new TableCell();
		cellAll.Width = Unit.Parse("25%");
		cellAll.Height = Unit.Parse("5px");
		cellAll.Text = " ";
		cellAll.BackColor = Color.Blue;
		TableRow tableRow = new TableRow();
		tableRow.Cells.Add(cellSelf);
		tableRow.Cells.Add(cellOther);
		tableRow.Cells.Add(cellDept);
		tableRow.Cells.Add(cellAll);		
		table.Rows.Add(tableRow);
		TableCell cellCar = new TableCell();
		cellCar.Height = Unit.Parse("16px");
		cellCar.HorizontalAlign = HorizontalAlign.Center;
		cellCar.ColumnSpan = 2;
		TableCell cellRoom = new TableCell();
		cellRoom.Height = Unit.Parse("16px");
		cellRoom.HorizontalAlign = HorizontalAlign.Center;
		cellRoom.ColumnSpan = 2;
		TableRow tableRowDevice = new TableRow();
		tableRowDevice.Cells.Add(cellCar);
		tableRowDevice.Cells.Add(cellRoom);
		table.Rows.Add(tableRowDevice);

		bool bSelf = false;
		bool bDept = false;
		bool bAll = false;
		bool bOther = false;

		if(dtCalendar.Count > 0) {			
			DataRow[] rowsCalendar = dtCalendar.Select("adate = #" + e.Day.Date.ToString("yyyy/MM/dd") + "#");
			if(rowsCalendar.Length > 0) {				
				int i = 0;
				foreach(ezClientDS.CalendarRow rowCalendar in rowsCalendar) {
					if(e.Cell.ToolTip.Trim().Length == 0) e.Cell.ToolTip += "[個人行事曆]\n";
					else {
						if(i == 0) e.Cell.ToolTip += "\n\n[個人行事曆]\n";
						else {
							e.Cell.ToolTip += "\n";							
						}
					}
					if(!rowCalendar.IsEmp_idSourceNull() && rowCalendar.Emp_idSource.Trim().Length > 0) {
						ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataById(rowCalendar.Emp_idSource);
						if(dtEmp.Count > 0) {
							if(i > 0) e.Cell.ToolTip += "\n";
							e.Cell.ToolTip += "發佈：" + dtEmp[0].name + "\n";
							bOther = true;
						}
					}
					else bSelf = true;
					e.Cell.ToolTip += "時間：" + rowCalendar.timeB + "-" + rowCalendar.timeE + "\n事項：" + rowCalendar.content;					
					i++;
				}
			}
		}

		if(dtCalendarAll.Count > 0) {
			DataRow[] rowsCalendar;

			rowsCalendar = dtCalendarAll.Select("adate = #" + e.Day.Date.ToString("yyyy/MM/dd") + "# AND calType = '2'");
			if(rowsCalendar.Length > 0) {
				bDept = true;
				int i = 0;
				foreach(ezClientDS.CalendarAllRow rowCalendar in rowsCalendar) {
					if(e.Cell.ToolTip.Trim().Length == 0) e.Cell.ToolTip += "[部門行事曆]\n";
					else {
						if(i == 0) e.Cell.ToolTip += "\n\n[部門行事曆]\n";
						else {
							e.Cell.ToolTip += "\n";							
						}
					}
					ezClientDS.DeptDataTable dtDept = Module.adDept.GetDataById(rowCalendar.Dept_id);
					if(dtDept.Count > 0) {
						e.Cell.ToolTip += "部門：" + dtDept[0].name + "\n";
					}
					e.Cell.ToolTip += "時間：" + rowCalendar.timeB + "-" + rowCalendar.timeE + "\n事項：" + rowCalendar.content;
					i++;
				}
			}

			rowsCalendar = dtCalendarAll.Select("adate = #" + e.Day.Date.ToString("yyyy/MM/dd") + "# AND calType = '1'");
			if(rowsCalendar.Length > 0) {
				bAll = true;
				int i = 0;
				foreach(ezClientDS.CalendarAllRow rowCalendar in rowsCalendar) {
					if(e.Cell.ToolTip.Trim().Length == 0) e.Cell.ToolTip += "[公司行事曆]\n";
					else {
						if(i == 0) e.Cell.ToolTip += "\n\n[公司行事曆]\n";
						else {
							e.Cell.ToolTip += "\n";							
						}
					}
					e.Cell.ToolTip += "時間：" + rowCalendar.timeB + "-" + rowCalendar.timeE + "\n事項：" + rowCalendar.content;
					i++;
				}
			}
		}

		if(!bSelf) cellSelf.BackColor = Color.Transparent;
		if(!bDept) cellDept.BackColor = Color.Transparent;
		if(!bAll) cellAll.BackColor = Color.Transparent;
		if(!bOther) cellOther.BackColor = Color.Transparent;

		ezClientDS.DeviceCalendarDataTable dtDeviceCalendar = (ezClientDS.DeviceCalendarDataTable)Session["dtDeviceUse"];
		if(dtDeviceCalendar.Count > 0) {
			foreach(ezClientDS.DeviceCalendarRow rowDeviceCalendar in dtDeviceCalendar.Rows) {
				if(e.Day.Date >= rowDeviceCalendar.dateB.Date && e.Day.Date <= rowDeviceCalendar.dateE.Date) {
					if(rowDeviceCalendar.publicType == "公務車") cellCar.Text = "<img src='images/car.gif'>";
					if(rowDeviceCalendar.publicType == "會議室") cellRoom.Text = "<img src='images/meeting.gif'>";
				}
			}
		}

		e.Cell.Controls.Add(table);
	}

	protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e) {
		MultiView2.ActiveViewIndex = Convert.ToInt32(RadioButtonList2.SelectedValue);
		if(MultiView2.ActiveViewIndex == 0) {
			GridView1.DataBind();
			GridView2.DataBind();
		}
	}
	protected void bnAddCal_Click(object sender, EventArgs e) {
		if(Convert.ToDateTime(lbSelectedDate.Text).Date < DateTime.Now.Date) {
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AddCalError")) {
				Page.ClientScript.RegisterStartupScript(typeof(string), "AddCalOK", "alert('不可為過去的時間新增記事');", true);
			}
			return;
		}
		if(txtTimeB.Text.Trim().Length == 0) {
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AddCalError")) {
				Page.ClientScript.RegisterStartupScript(typeof(string), "AddCalOK", "alert('起始時間不可空白');", true);
			}
			return;
		}
		if(txtTimeE.Text.Trim().Length == 0) {
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AddCalError")) {
				Page.ClientScript.RegisterStartupScript(typeof(string), "AddCalOK", "alert('結束時間不可空白');", true);
			}
			return;
		}
		if(txtContent.Text.Trim().Length == 0) {
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AddCalError")) {
				Page.ClientScript.RegisterStartupScript(typeof(string), "AddCalOK", "alert('記事不可空白');", true);
			}
			return;
		}

		ezClientDS.CalendarDataTable dtCalendar = new ezClientDS.CalendarDataTable();
		ezClientDS.CalendarRow rowCalendar = dtCalendar.NewCalendarRow();
		rowCalendar.Emp_id = Request.Cookies["ezFlow"]["Emp_id"];
		rowCalendar.adate = Convert.ToDateTime(lbSelectedDate.Text);
		rowCalendar.timeB = txtTimeB.Text;
		rowCalendar.timeE = txtTimeE.Text;
		rowCalendar.calType = rblstCalType.SelectedValue;
		rowCalendar.content = txtContent.Text;
		rowCalendar.msgType = "1";
		rowCalendar.Emp_idSource = "";
		dtCalendar.AddCalendarRow(rowCalendar);
		Module.adCalendar.Update(dtCalendar);		

		if(txtOtherEmp.Text.Trim().Length > 0) {
			ezClientDS.EmpDataTable dtEmp;
			if(txtOtherEmp.Text.IndexOf(',') != -1) {
				string[] rowsTmp = txtOtherEmp.Text.Split(new char[] { ',' });
				if(rowsTmp.Length > 0) {
					dtCalendar.Clear();
					foreach(string keyword in rowsTmp) {						
						dtEmp = Module.adEmp.GetDataBySearch(keyword);
						foreach(ezClientDS.EmpRow rowEmp in dtEmp.Rows) {
							rowCalendar = dtCalendar.NewCalendarRow();
							rowCalendar.Emp_id = rowEmp.id;
							rowCalendar.adate = Convert.ToDateTime(lbSelectedDate.Text);
							rowCalendar.timeB = txtTimeB.Text;
							rowCalendar.timeE = txtTimeE.Text;
							rowCalendar.calType = rblstCalType.SelectedValue;
							rowCalendar.content = txtContent.Text;
							rowCalendar.msgType = rbnMsgType.SelectedValue;
							rowCalendar.Emp_idSource = Request.Cookies["ezFlow"]["Emp_id"];
							dtCalendar.AddCalendarRow(rowCalendar);
						}
					}
					Module.adCalendar.Update(dtCalendar);	
				}
			}
			else {
				dtEmp = Module.adEmp.GetDataBySearch(txtOtherEmp.Text);
				if(dtEmp.Count > 0) {
					dtCalendar.Clear();
					rowCalendar = dtCalendar.NewCalendarRow();
					rowCalendar.Emp_id = dtEmp[0].id;
					rowCalendar.adate = Convert.ToDateTime(lbSelectedDate.Text);
					rowCalendar.timeB = txtTimeB.Text;
					rowCalendar.timeE = txtTimeE.Text;
					rowCalendar.calType = rblstCalType.SelectedValue;
					rowCalendar.content = txtContent.Text;
					rowCalendar.msgType = rbnMsgType.SelectedValue;
					rowCalendar.Emp_idSource = Request.Cookies["ezFlow"]["Emp_id"];
					dtCalendar.AddCalendarRow(rowCalendar);
					Module.adCalendar.Update(dtCalendar);	
				}
			}
		}
		if(ckMsgDept.Checked) {
			ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataByDeptEmp(ViewState["FullDeptTree"].ToString());
			dtCalendar.Clear();
			foreach(ezClientDS.EmpRow rowEmp in dtEmp.Rows) {
				if(rowEmp.id == Request.Cookies["ezFlow"]["Emp_id"]) continue;
				rowCalendar = dtCalendar.NewCalendarRow();
				rowCalendar.Emp_id = rowEmp.id;
				rowCalendar.adate = Convert.ToDateTime(lbSelectedDate.Text);
				rowCalendar.timeB = txtTimeB.Text;
				rowCalendar.timeE = txtTimeE.Text;
				rowCalendar.calType = rblstCalType.SelectedValue;
				rowCalendar.content = txtContent.Text;
				rowCalendar.msgType = rbnMsgType.SelectedValue;
				rowCalendar.Emp_idSource = Request.Cookies["ezFlow"]["Emp_id"];
				dtCalendar.AddCalendarRow(rowCalendar);
			}
			Module.adCalendar.Update(dtCalendar);
		}		

		txtTimeB.Text = "";
		txtTimeE.Text = "";
		txtContent.Text = "";
		txtOtherEmp.Text = "";
		
		if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AddCalOK")) {
			Page.ClientScript.RegisterStartupScript(typeof(string), "AddCalOK", "alert('新增成功');self.location = 'Home.aspx';", true);
		}
	}

	protected void Calendar1_SelectionChanged(object sender, EventArgs e) {
		lbSelectedDate.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
		lbSelectedDate1.Text = lbSelectedDate.Text;
		lbSelectedDate2.Text = lbSelectedDate.Text;
		lbQueryDate.Text = lbSelectedDate.Text;
		ViewState["baseDate"] = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
		Session["baseDate"] = ViewState["baseDate"];
		Session["baseDateB"] = Convert.ToDateTime(ViewState["baseDate"]).ToString("yyyy/MM/dd") + " 00:00:00";
		Session["baseDateE"] = Convert.ToDateTime(ViewState["baseDate"]).ToString("yyyy/MM/dd") + " 23:59:59";
		GridView1.DataBind();
		GridView2.DataBind();
		DataList2.DataBind();

		if(Module.adDeviceDate.GetData(Convert.ToDateTime(ViewState["baseDate"])).Count > 0) pnlEmpty.Visible = false;
		else pnlEmpty.Visible = true;

		Response.Cookies["ezFlow"]["Emp_id"] = Request.Cookies["ezFlow"]["Emp_id"];
		Response.Cookies["ezFlow"]["ActiveViewIndex"] = MultiView1.ActiveViewIndex.ToString();
		Response.Cookies["ezFlow"]["SelectedDate"] = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
		Response.Cookies["ezFlow"].Expires = DateTime.Now.AddDays(1);
	}

	protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e) {
		ViewState["Year"] = e.NewDate.Year;
		ViewState["Month"] = e.NewDate.Month;
		Session["calDateB"] = ViewState["Year"].ToString() + "/" + ViewState["Month"].ToString() + "/1 00:00:00";
		Session["calDateB"] = Convert.ToDateTime(Session["calDateB"]).AddDays(-7);
		Session["calDateE"] = ViewState["Year"].ToString() + "/" + ViewState["Month"].ToString() +
			"/" + DateTime.DaysInMonth(Convert.ToInt32(ViewState["Year"]), Convert.ToInt32(ViewState["Month"])).ToString() + " 23:59:59";
		Session["calDateE"] = Convert.ToDateTime(Session["calDateE"]).AddDays(7);

		Session["EmpCal"] = Module.adCalendar.GetDataByEmpCal(Session["Emp_id"].ToString(), Convert.ToDateTime(Session["calDateB"]), Convert.ToDateTime(Session["calDateE"]));
		Session["AllCal"] = Module.adCalendarAll.GetDataByDate(Convert.ToDateTime(Session["calDateB"]), Convert.ToDateTime(Session["calDateE"]), Session["FullDeptTree"].ToString());
	}


	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e) {
		if(e.Row.DataItem != null) {
			ezClientDS.CalendarRow rowCalendar = (ezClientDS.CalendarRow)((DataRowView)e.Row.DataItem).Row;
			Control ctrl = e.Row.FindControl("lbCalType");
			if(ctrl != null) {
				((Label)ctrl).Text = (rowCalendar.calType == "1") ? "私人" : "公開";
			}

			ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataById(rowCalendar.Emp_idSource);
			ctrl = e.Row.FindControl("lbIdSource");
			if(ctrl != null) {
				if(dtEmp.Count > 0) ((Label)ctrl).Text = dtEmp[0].name;
			}

			if(e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate) {
				if(!rowCalendar.IsEmp_idSourceNull() && rowCalendar.Emp_idSource.Trim().Length > 0) {
					ctrl = e.Row.FindControl("bnEdit");
					if(ctrl != null) {
						((Button)ctrl).Enabled = false;
					}
				}

				if(rowCalendar.adate.Date < DateTime.Now.Date) {
					ctrl = e.Row.FindControl("bnEdit");
					if(ctrl != null) ((Button)ctrl).Enabled = false;
					ctrl = e.Row.FindControl("bnDel");
					if(ctrl != null) ((Button)ctrl).Enabled = false;
				}
			}
		}
	}

	protected void RadioButtonList3_SelectedIndexChanged(object sender, EventArgs e) {
		MultiView3.ActiveViewIndex = Convert.ToInt32(RadioButtonList3.SelectedValue);
	}

	protected void bnReport1_Click(object sender, EventArgs e) {
		Session["ReportEmps"] = txtEmpID.Text;
		Session["ReportYear"] = cbQueryYear1.SelectedValue;
		Session["ReportMonth"] = cbQueryMonth1.SelectedValue;
		string link = "MyFrame.aspx?url=CalRpt.aspx";
		string script = "var sFeatures = 'dialogWidth:800px;dialogHeight:600px;center:yes;help:no;resizable:no;scroll:no;status:no';" +
			"window.showModalDialog('" + link + "', '', sFeatures);";			
		if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "CalRpt1"))
			Page.ClientScript.RegisterStartupScript(typeof(string), "CalRpt1", script, true);
	}

	protected void bnReport2_Click(object sender, EventArgs e) {
		Session["ReportYear"] = cbQueryYear2.SelectedValue;
		Session["ReportMonth"] = cbQueryMonth2.SelectedValue;
		string link = "MyFrame.aspx?url=CalRpt" + rblstReportStyle.SelectedValue + ".aspx";
		string script = "var sFeatures = 'dialogWidth:800px;dialogHeight:600px;center:yes;help:no;resizable:no;scroll:no;status:no';" +
			"window.showModalDialog('" + link + "', '', sFeatures);";			
		if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "CalRpt2"))
			Page.ClientScript.RegisterStartupScript(typeof(string), "CalRpt2", script, true);
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e) {
		if(e.Row.DataItem != null) {
			ezClientDS.CalendarAllRow rowCalendar = (ezClientDS.CalendarAllRow)((DataRowView)e.Row.DataItem).Row;
			Control ctrl = e.Row.FindControl("lbCalType");
			if(ctrl != null) {
				((Label)ctrl).Text = (rowCalendar.calType == "1") ? "公司" : "部門";
			}

			if(e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate) {
				Control ctrl1 = e.Row.FindControl("bnEdit");
				Control ctrl2 = e.Row.FindControl("bnDel");
				if(ctrl1 != null && ctrl2 != null) {
					switch(rowCalendar.calType) {
						case "1":
							if(!Convert.ToBoolean(ViewState["SysAdmin"]) || rowCalendar.Emp_idSource != Session["Emp_id"].ToString()) {
								((Button)ctrl1).Enabled = false;
								((Button)ctrl2).Enabled = false;
							}
							break;
						case "2":
							if(ViewState["DeptMg"].ToString().IndexOf(rowCalendar.Dept_id) == -1 || rowCalendar.Emp_idSource != Session["Emp_id"].ToString()) {
								((Button)ctrl1).Enabled = false;
								((Button)ctrl2).Enabled = false;
							}
							Control ctrl3 = e.Row.FindControl("lbContent");
							if(ctrl3 != null) {
								ezClientDS.DeptDataTable dtDept = Module.adDept.GetDataById(rowCalendar.Dept_id);
								if(dtDept.Count > 0) {
									((Label)ctrl3).Text = "[" + dtDept[0].name + "]:" + ((Label)ctrl3).Text;
								}
							}
							break;
					}
					if(rowCalendar.adate.Date < DateTime.Now.Date) {
						((Button)ctrl1).Enabled = false;
						((Button)ctrl2).Enabled = false;
					}
				}
			}

			ctrl = e.Row.FindControl("lbEmpName");
			if(ctrl != null) {
				if(!rowCalendar.IsEmp_idSourceNull() && rowCalendar.Emp_idSource.Trim().Length > 0) {
					ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataById(rowCalendar.Emp_idSource);
					if(dtEmp.Count > 0) {
						((Label)ctrl).Text = dtEmp[0].name;
					}
				}
			}
		}
	}

	protected void bnAddCal1_Click(object sender, EventArgs e) {
		if(Convert.ToDateTime(lbSelectedDate1.Text).Date < DateTime.Now.Date) {
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AddCalError")) {
				Page.ClientScript.RegisterStartupScript(typeof(string), "AddCalOK", "alert('不可為過去的時間新增記事');", true);
			}
			return;
		}
		if(txtTimeB1.Text.Trim().Length == 0) {
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AddCalError")) {
				Page.ClientScript.RegisterStartupScript(typeof(string), "AddCalOK", "alert('起始時間不可空白');", true);
			}
			return;
		}
		if(txtTimeE1.Text.Trim().Length == 0) {
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AddCalError")) {
				Page.ClientScript.RegisterStartupScript(typeof(string), "AddCalOK", "alert('結束時間不可空白');", true);
			}
			return;
		}
		if(txtContent1.Text.Trim().Length == 0) {
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AddCalError")) {
				Page.ClientScript.RegisterStartupScript(typeof(string), "AddCalOK", "alert('記事不可空白');", true);
			}
			return;
		}

		ezClientDS.CalendarAllDataTable dtCalendarAll = new ezClientDS.CalendarAllDataTable();
		ezClientDS.CalendarAllRow rowCalendarAll = dtCalendarAll.NewCalendarAllRow();
		rowCalendarAll.Dept_id = cbDept.SelectedValue;
		rowCalendarAll.adate = Convert.ToDateTime(lbSelectedDate1.Text);
		rowCalendarAll.timeB = txtTimeB1.Text;
		rowCalendarAll.timeE = txtTimeE1.Text;
		rowCalendarAll.calType = "2";
		rowCalendarAll.content = txtContent1.Text;
		rowCalendarAll.Emp_idSource = Request.Cookies["ezFlow"]["Emp_id"];
		dtCalendarAll.AddCalendarAllRow(rowCalendarAll);
		Module.adCalendarAll.Update(dtCalendarAll);

		if(txtOther.Text.Trim().Length > 0) {
			ezClientDS.CalendarDataTable dtCalendar = new ezClientDS.CalendarDataTable();
			ezClientDS.CalendarRow rowCalendar = null;
			ezClientDS.EmpDataTable dtEmp;
			if(txtOther.Text.IndexOf(',') != -1) {
				string[] rowsTmp = txtOther.Text.Split(new char[] { ',' });
				if(rowsTmp.Length > 0) {
					foreach(string keyword in rowsTmp) {
						dtEmp = Module.adEmp.GetDataBySearch(keyword);
						foreach(ezClientDS.EmpRow rowEmp in dtEmp.Rows) {
							rowCalendar = dtCalendar.NewCalendarRow();
							rowCalendar.Emp_id = rowEmp.id;
							rowCalendar.adate = rowCalendarAll.adate;
							rowCalendar.timeB = rowCalendarAll.timeB;
							rowCalendar.timeE = rowCalendarAll.timeE;
							rowCalendar.calType = "2";
							rowCalendar.content = rowCalendarAll.content;
							rowCalendar.msgType = "2";
							rowCalendar.Emp_idSource = Request.Cookies["ezFlow"]["Emp_id"];
							dtCalendar.AddCalendarRow(rowCalendar);
						}
					}
				}
			}
			else {
				dtEmp = Module.adEmp.GetDataBySearch(txtOther.Text);
				if(dtEmp.Count > 0) {
					rowCalendar = dtCalendar.NewCalendarRow();
					rowCalendar.Emp_id = dtEmp[0].id;
					rowCalendar.adate = rowCalendarAll.adate;
					rowCalendar.timeB = rowCalendarAll.timeB;
					rowCalendar.timeE = rowCalendarAll.timeE;
					rowCalendar.calType = "2";
					rowCalendar.msgType = "2";
					rowCalendar.content = rowCalendarAll.content;
					rowCalendar.Emp_idSource = Request.Cookies["ezFlow"]["Emp_id"];
					dtCalendar.AddCalendarRow(rowCalendar);
				}
			}

			Module.adCalendar.Update(dtCalendar);
		}


		txtTimeB1.Text = "";
		txtTimeE1.Text = "";
		txtContent1.Text = "";
		txtOther.Text = "";

		if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AddCalOK")) {
			Page.ClientScript.RegisterStartupScript(typeof(string), "AddCalOK", "alert('新增成功');self.location = 'Home.aspx';", true);
		}
	}
	protected void bnAddCal2_Click(object sender, EventArgs e) {
		if(Convert.ToDateTime(lbSelectedDate2.Text).Date < DateTime.Now.Date) {
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AddCalError")) {
				Page.ClientScript.RegisterStartupScript(typeof(string), "AddCalOK", "alert('不可為過去的時間新增記事');", true);
			}
			return;
		}
		if(txtTimeB2.Text.Trim().Length == 0) {
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AddCalError")) {
				Page.ClientScript.RegisterStartupScript(typeof(string), "AddCalOK", "alert('起始時間不可空白');", true);
			}
			return;
		}
		if(txtTimeE2.Text.Trim().Length == 0) {
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AddCalError")) {
				Page.ClientScript.RegisterStartupScript(typeof(string), "AddCalOK", "alert('結束時間不可空白');", true);
			}
			return;
		}
		if(txtContent2.Text.Trim().Length == 0) {
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AddCalError")) {
				Page.ClientScript.RegisterStartupScript(typeof(string), "AddCalOK", "alert('記事不可空白');", true);
			}
			return;
		}

		ezClientDS.CalendarAllDataTable dtCalendar = new ezClientDS.CalendarAllDataTable();
		ezClientDS.CalendarAllRow rowCalendar = dtCalendar.NewCalendarAllRow();
		rowCalendar.Dept_id = "";
		rowCalendar.adate = Convert.ToDateTime(lbSelectedDate2.Text);
		rowCalendar.timeB = txtTimeB2.Text;
		rowCalendar.timeE = txtTimeE2.Text;
		rowCalendar.calType = "1";
		rowCalendar.content = txtContent2.Text;
		rowCalendar.Emp_idSource = Request.Cookies["ezFlow"]["Emp_id"];
		dtCalendar.AddCalendarAllRow(rowCalendar);
		Module.adCalendarAll.Update(dtCalendar);

		txtTimeB2.Text = "";
		txtTimeE2.Text = "";
		txtContent2.Text = "";

		if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AddCalOK")) {
			Page.ClientScript.RegisterStartupScript(typeof(string), "AddCalOK", "alert('新增成功');self.location = 'Home.aspx';", true);
		}
	}

	protected void bnReport3_Click(object sender, EventArgs e) {
		Session["ReportYear"] = cbQueryYear3.SelectedValue;
		Session["ReportMonth"] = cbQueryMonth3.SelectedValue;
		Session["FullDeptTree"] = ViewState["FullDeptTree"];		
		string link = "MyFrame.aspx?url=CalRpt3.aspx";
		string script = "var sFeatures = 'dialogWidth:800px;dialogHeight:600px;center:yes;help:no;resizable:no;scroll:no;status:no';" +
			"window.showModalDialog('" + link + "', '', sFeatures);";
		if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "CalRpt3"))
			Page.ClientScript.RegisterStartupScript(typeof(string), "CalRpt3", script, true);
	}

	protected void bnReport4_Click(object sender, EventArgs e) {
		Session["ReportYear"] = cbQueryYear4.SelectedValue;
		Session["ReportMonth"] = cbQueryMonth4.SelectedValue;
		string link = "MyFrame.aspx?url=CalRpt4.aspx";
		string script = "var sFeatures = 'dialogWidth:800px;dialogHeight:600px;center:yes;help:no;resizable:no;scroll:no;status:no';" +
			"window.showModalDialog('" + link + "', '', sFeatures);";
		if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "CalRpt4"))
			Page.ClientScript.RegisterStartupScript(typeof(string), "CalRpt4", script, true);
	}

	protected void ObjectDataSource5_Deleted(object sender, ObjectDataSourceStatusEventArgs e) {
		if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "ReLoad"))
			Page.ClientScript.RegisterStartupScript(typeof(string), "ReLoad", "self.location = 'Home.aspx';", true);
	}

	protected void ObjectDataSource4_Deleted(object sender, ObjectDataSourceStatusEventArgs e) {
		if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "ReLoad"))
			Page.ClientScript.RegisterStartupScript(typeof(string), "ReLoad", "self.location = 'Home.aspx';", true);
	}

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e) {
	}

	protected void ObjectDataSource4_Updating(object sender, ObjectDataSourceMethodEventArgs e) {
		if(!e.InputParameters.Contains("Emp_idSource")) {
			e.InputParameters.Add("Emp_idSource", "");
		}
		else {
			if(e.InputParameters["Emp_idSource"] == null) {
				e.InputParameters["Emp_idSource"] = "";
			}
		}
	}
	protected void ObjectDataSource5_Updating(object sender, ObjectDataSourceMethodEventArgs e) {
		if(!e.InputParameters.Contains("Dept_id")) {
			e.InputParameters.Add("Dept_id", "");
		}
		else {
			if(e.InputParameters["Dept_id"] == null) {
				e.InputParameters["Dept_id"] = "";
			}
		}
	}
}
