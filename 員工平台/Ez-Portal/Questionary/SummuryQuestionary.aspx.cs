using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BL;
using Telerik.Web.UI;

public partial class Questionary_SummuryQuestionary : JBWebPage
{
    private QA_Published_Repo qapRepo = new QA_Published_Repo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                display(Request.QueryString["Id"]);
            }
        }
    }

    private void display(string id)
    {
        int key = Convert.ToInt32(id);
        //   var cqObj = qapRepo.GetByPk(key);

        QAMaster_Repo qamRepo = new QAMaster_Repo();
        var qamList = qamRepo.GetByPublishId_Dlo(key).Where(p => p.WriteDate != null);

        if (qamList.Count() > 0)
        {
            QTpl_Repo qtplRepo = new QTpl_Repo();
            List<QQItem> qqItemList = qtplRepo.GetQQItemListByPk_Dlo(qamList.First().QA_Published.QTplCode);

            var notSAQList = qqItemList.Where(p => !p.TypeCode.Equals(QQTypeEnum.SAQ.ToString()));
            var saqList = qqItemList.Where(p => p.TypeCode.Equals(QQTypeEnum.SAQ.ToString()));
            List<ClassQASumRpt> resultList = new List<ClassQASumRpt>();

            foreach (var m in notSAQList)
            {
                ClassQASumRpt resultObj = new ClassQASumRpt();
                resultObj.QQItemId = m.Id;
                resultObj.QuestionText = m.QuestionText;

                int mcqIntValue = 0;
                int counter = 0;

                if (m.TypeCode.Equals(QQTypeEnum.MCQ.ToString()))
                {
                    //數字型選項
                    if (m.QQMcq.IsValueInt)
                    {
                        foreach (var qam in qamList)
                        {
                            var i = (from c in qam.QADetail
                                     where c.QQItemId == m.Id && c.McqIntValue.HasValue
                                     select c).FirstOrDefault();
                            if (i != null)
                            {
                                mcqIntValue = mcqIntValue + i.McqIntValue.Value;
                                counter++;
                            }
                        }

                        if (counter > 0)
                            resultObj.Score = Math.Round((Decimal)mcqIntValue / (Decimal)counter, 1, MidpointRounding.AwayFromZero);
                        else
                            resultObj.Score = 0;
                    }
                    else //文字型選項
                    {
                        QQMcqDetail_Repo mcqD_Repo = new QQMcqDetail_Repo();
                        Dictionary<string, int> dic = new Dictionary<string, int>();

                        var qqMcqD_List = mcqD_Repo.GetByQQMcqId(m.McqId.Value).OrderBy(p => p.Sequence);
                        foreach (var d in qqMcqD_List)
                        {
                            dic.Add(d.StringValue, 0);
                        }

                        foreach (var qam in qamList)
                        {
                            var i = (from c in qam.QADetail
                                     where c.QQItemId == m.Id
                                     select c).FirstOrDefault();
                            if (i != null)
                            {
                                if (i.McqStringValue != null)
                                {
                                    if (dic.ContainsKey(i.McqStringValue))
                                    {
                                        dic[i.McqStringValue] = dic[i.McqStringValue] + 1;
                                    }
                                }
                            }
                        }

                        

                        StringBuilder sb = new StringBuilder();
                        sb.Append(@"<table>");

                        foreach (KeyValuePair<string, int> pair in dic)
                        {
                            sb.Append(@"<tr>");
                            sb.Append(@"<td>");
                            sb.Append(pair.Key);
                            sb.Append(@"</td>");
                            sb.Append(@"<td>");
                            sb.Append(pair.Value);
                            sb.Append(@" / ");
                            sb.Append(qamList.Count().ToString());
                            sb.Append(@"</td>");
                            sb.Append(@"</tr>");
                        }
                        sb.Append(@"</table>");
                        resultObj.StrValue = sb.ToString();
                        //foreach (KeyValuePair<string, int> pair in dic)
                        //{
                        //    resultObj.StrValue = resultObj.StrValue + pair.Key + "：" + pair.Value + "、";
                        //}
                    }
                }
                //是非題
                else if (m.TypeCode.Equals(QQTypeEnum.TFQ.ToString()))
                {
                    int trueCounter = 0;
                    int falseCounter = 0;
                    foreach (var qam in qamList)
                    {
                        var i = (from c in qam.QADetail
                                 where c.QQItemId == m.Id
                                 select c).FirstOrDefault();
                        if (i != null)
                        {
                            if (i.TfqValue.HasValue)
                            {
                                if (i.TfqValue.Value)
                                    trueCounter++;
                                else
                                    falseCounter++;
                            }
                        }
                    }

                    StringBuilder sb = new StringBuilder();
                    sb.Append(@"<table>");

                    sb.Append(@"<tr>");
                    sb.Append(@"<td>");
                    sb.Append(@"是");
                    sb.Append(@"</td>");
                    sb.Append(@"<td>");
                    sb.Append(trueCounter.ToString());
                    sb.Append(@"</td>");
                    sb.Append(@"</tr>");
                    sb.Append(@"<tr>");
                    sb.Append(@"<td>");
                    sb.Append(@"否");
                    sb.Append(@"</td>");
                    sb.Append(@"<td>");
                    sb.Append(falseCounter.ToString());
                    sb.Append(@"</td>");
                    sb.Append(@"</tr>");

                    sb.Append(@"</table>");
                    resultObj.StrValue = sb.ToString();
                }

                resultList.Add(resultObj);
            }

            foreach (var m in saqList)
            {
                foreach (var qam in qamList)
                {
                    var i = (from c in qam.QADetail
                             where c.QQItemId == m.Id
                             select c).FirstOrDefault();
                    if (i != null)
                    {
                        if (i.SaqValue != null && i.SaqValue.Trim().Length > 0)
                        {
                            ClassQASumRpt resultObj = new ClassQASumRpt();
                            resultObj.QQItemId = m.Id;
                            resultObj.QuestionText = m.QuestionText;
                            resultObj.SaqAnswer = i.SaqValue;
                            resultList.Add(resultObj);
                        }
                    }
                }
            }

            gv.DataSource = resultList;
            gv.Rebind();
        }
    }

    public class ClassQASumRpt
    {
        public int QQItemId
        {
            get;
            set;
        }

        public string QuestionText
        {
            get;
            set;
        }

        public string TypeCode
        {
            get;
            set;
        }

        public decimal? Score
        {
            get;
            set;
        }

        public string StrValue
        {
            get;
            set;
        }

        public string SaqAnswer
        {
            get;
            set;
        }

        public ClassQASumRpt()
        {
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        int key = Convert.ToInt32(Request.QueryString["Id"]);
        var qapObj = qapRepo.GetByPk_Dlo(key);

        if (gv.Items.Count == 0)
        {
            Show("無資料");
            return;
        }

        gv.ExportSettings.ExportOnlyData = false;
        gv.ExportSettings.HideStructureColumns = true;
        gv.ExportSettings.IgnorePaging = true;
        gv.ExportSettings.OpenInNewWindow = false;
        gv.ExportSettings.FileName = qapObj.QTpl.Name;
        gv.MasterTableView.ExportToExcel();
    }

    protected void gv_ItemDataBound(object sender, GridItemEventArgs e)
    {
    }

    protected void gv_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
    {
        var gh = e.OwnerTableView.ColumnGroups.FindGroupByName("GH");
        if (gh != null)
        {
            string id = Request.QueryString["Id"];

            int key = Convert.ToInt32(id);
            var qapObj = qapRepo.GetByPk_Dlo(key);

            gh.HeaderText = qapObj.QTpl.Name;
        }
    }
}