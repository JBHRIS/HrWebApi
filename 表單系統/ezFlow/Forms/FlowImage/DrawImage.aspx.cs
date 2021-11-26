using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

public partial class DrawImage : System.Web.UI.Page
{
	FlowImageDSTableAdapters.ProcessFlowTableAdapter adProcessFlow = new FlowImageDSTableAdapters.ProcessFlowTableAdapter();
	FlowImageDSTableAdapters.ProcessNodeTableAdapter adProcessNode = new FlowImageDSTableAdapters.ProcessNodeTableAdapter();
	FlowImageDSTableAdapters.ProcessCheckTableAdapter adProcessCheck = new FlowImageDSTableAdapters.ProcessCheckTableAdapter();
	FlowImageDSTableAdapters.FlowNodeTableAdapter adFlowNode = new FlowImageDSTableAdapters.FlowNodeTableAdapter();
	FlowImageDSTableAdapters.EmpTableAdapter adEmp = new FlowImageDSTableAdapters.EmpTableAdapter();
	FlowImageDSTableAdapters.FlowTreeTableAdapter adFlowTree = new FlowImageDSTableAdapters.FlowTreeTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
		Response.Flush();
		Response.Clear();
		FlowImageDS.ProcessFlowDataTable dtProcessFlow = adProcessFlow.GetDataById(Convert.ToInt32(Session["idProcess"]));
		if(dtProcessFlow.Count > 0) {
			FlowImageDS.ProcessNodeDataTable dtProcessNode = adProcessNode.GetDataByProcessFlow(dtProcessFlow[0].id);

			Bitmap image = new Bitmap(550, (dtProcessNode.Count + 3) * 60);
			Graphics g = Graphics.FromImage(image);
			g.Clear(Color.White);

			int x = 50;
			int y = 10;
			
			FlowImageDS.FlowTreeDataTable dtFlowTree = adFlowTree.GetDataById(dtProcessFlow[0].FlowTree_id);
			g.DrawString("◎" + dtFlowTree[0].name + "◎", new Font("細明體", 12, FontStyle.Bold), new SolidBrush(Color.Green), x - 5, y);

			y += 30;

			Bitmap imgNode = new Bitmap(Request.PhysicalApplicationPath + "images\\Form.bmp");
			g.DrawImage(imgNode, x, y);

			FlowImageDS.EmpDataTable dtEmp = adEmp.GetDataById(dtProcessFlow[0].Emp_id);
			if(dtEmp.Count > 0) {
				string dateStr = dtEmp[0].name + " 於 " + dtProcessFlow[0].adate.ToString("yyyy-MM-dd HH:mm") + " 完成表單填寫並送出";
				g.DrawString(dateStr, new Font("細明體", 10, FontStyle.Bold), new SolidBrush(Color.Black), x + 36, y + 8);
			}

			y += 60;

			foreach(FlowImageDS.ProcessNodeRow rowProcessNode in dtProcessNode.Rows) {
				DrawLineWithCap(g, new Point(x + 16, y - 60 + 32), new Point(x + 16, y));

				FlowImageDS.FlowNodeDataTable dtFlowNode = adFlowNode.GetDataById(rowProcessNode.FlowNode_id);
				imgNode = null;

				string actionStr = "";
				switch(dtFlowNode[0].nodeType) {
					case "3":
						imgNode = new Bitmap(Request.PhysicalApplicationPath + "images\\Mang.bmp");
						actionStr = "審核";
						break;
					case "4":
						imgNode = new Bitmap(Request.PhysicalApplicationPath + "images\\FlowInit.bmp");
						actionStr = "確認";
						break;
					case "5":
						imgNode = new Bitmap(Request.PhysicalApplicationPath + "images\\MultiInit.bmp");
						actionStr = "處理";
						break;
					case "6":
						imgNode = new Bitmap(Request.PhysicalApplicationPath + "images\\Custom.bmp");
						actionStr = "處理";
						break;
					case "7":
						imgNode = new Bitmap(Request.PhysicalApplicationPath + "images\\Dynamic.bmp");
						actionStr = "處理";
						break;
					case "8":
						imgNode = new Bitmap(Request.PhysicalApplicationPath + "images\\AgentInit.bmp");
						actionStr = "確認";
						break;
					case "9":
						imgNode = new Bitmap(Request.PhysicalApplicationPath + "images\\MultiFlow.bmp");
						g.DrawString("進行會簽流程", new Font("細明體", 10, FontStyle.Bold), new SolidBrush(Color.Blue), x + 36, y + 8);
						break;
				}

				g.DrawImage(imgNode, x, y);
				FlowImageDS.ProcessCheckDataTable dtProcessCheck = adProcessCheck.GetDataByProcessNode(rowProcessNode.auto);
                if (dtProcessCheck.Count > 0)
                {
                    string dateStr = "";
                    if (rowProcessNode.isFinish)
                    {
                        dtEmp = adEmp.GetDataById(dtProcessCheck[0].Emp_idReal);
                        if (dtEmp.Count > 0)
                        {
                            dateStr = "(" + dtFlowNode[0].name + ") " + dtEmp[0].name + " 於 " + dtProcessCheck[0].adate.ToString("yyyy-MM-dd HH:mm") + " 完成" + actionStr;
                            g.DrawString(dateStr, new Font("細明體", 10, FontStyle.Bold), new SolidBrush(Color.Blue), x + 36, y + 8);
                        }
                    }
                    else
                    {
                        //if (!dtProcessCheck[0].IsEmp_idAgentNull() && dtProcessCheck[0].Emp_idAgent.Trim().Length > 0)
                        //{
                        //    dtEmp = adEmp.GetDataById(dtProcessCheck[0].Emp_idAgent);
                        //    if (dtEmp.Count > 0)
                        //    {
                        //        dateStr = "(" + dtFlowNode[0].name + ") 目前表單等待 " + dtEmp[0].name + " " + actionStr;
                        //        g.DrawString(dateStr, new Font("細明體", 10, FontStyle.Bold), new SolidBrush(Color.Red), x + 36, y + 8);
                        //    }
                        //}
                        //else
                        {
                            dtEmp = adEmp.GetDataById(dtProcessCheck[0].Emp_idDefault);
                            if (dtEmp.Count > 0)
                            {
                                dateStr = "(" + dtFlowNode[0].name + ") 目前表單等待 " + dtEmp[0].name + " " + actionStr;

                                //if (!dtProcessCheck[0].IsEmp_idAgentNull() && dtProcessCheck[0].Emp_idAgent.Trim().Length > 0)
                                //{
                                //    dtEmp = adEmp.GetDataById(dtProcessCheck[0].Emp_idAgent);
                                //    if (dtEmp.Count > 0)
                                //        dateStr += "｜簽核代理人為 " + dtEmp[0].name + " 可代為處理";
                                //}

                                g.DrawString(dateStr, new Font("細明體", 10, FontStyle.Bold), new SolidBrush(Color.Red), x + 36, y + 8);
                            }
                        }
                    }
                }
				y += 60;
			}

            if (dtProcessFlow[0].isFinish)
            {
                DrawLineWithCap(g, new Point(x + 16, y - 60 + 32), new Point(x + 16, y));
                imgNode = new Bitmap(Request.PhysicalApplicationPath + "images\\FlowEnd.bmp");
                g.DrawImage(imgNode, x, y);
                g.DrawString("流程結束", new Font("細明體", 10, FontStyle.Bold), new SolidBrush(Color.Black), x + 36, y + 8);
            }
						
			image.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
		}
    }

	private void DrawLineWithCap(Graphics g,Point start, Point end) {
		GraphicsPath hPath = new GraphicsPath();
		hPath.AddLine(new Point(0, -3), new Point(2, -8));
		hPath.AddLine(new Point(0, -6), new Point(2, -8));
		hPath.AddLine(new Point(0, -3), new Point(-2, -8));
		hPath.AddLine(new Point(0, -6), new Point(-2, -8));
		CustomLineCap HookCap = new CustomLineCap(null, hPath);
		Pen customCapPen = new Pen(Color.Gold, 2);
		customCapPen.CustomEndCap = HookCap;
		g.DrawLine(customCapPen, start, end);
	}
}
