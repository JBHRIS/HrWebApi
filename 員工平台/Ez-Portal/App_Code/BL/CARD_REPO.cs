using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JBHRModel;
using System.Data.Linq;
namespace BL
{
    /// <summary>
    /// CARD_REPO 的摘要描述
    /// </summary>
    public class CARD_REPO
    {
        public JBHRModel.JBHRModelDataContext dc{get;set;}
        public CARD_REPO(JBHRModel.JBHRModelDataContext o)
        {
            dc = o;
        }

        public CARD_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public void Add(CARD o)
        {
            dc.CARD.InsertOnSubmit(o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        /// <summary>
        /// 抓取資料卡片資料含有理由的 By 部門，日期區間
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="adate"></param>
        /// <param name="ddate"></param>
        /// <returns></returns>
        public List<CARD> GetByCardWithReasonDeptDateRange_DLO(string deptCode,DateTime adate, DateTime ddate)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<CARD>(l => l.BASE);
                dlo.LoadWith<CARD>(l => l.CARDLOSD);
                dlo.LoadWith<BASE>(l => l.BASETTS);
                //dlo.AssociateWith<CARD>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                ldc.LoadOptions = dlo;
                return (from c in ldc.CARD 
                        where !c.REASON.Equals("")
                        && c.ADATE >= adate
                        && c.ADATE <= ddate
                        && c.BASE.BASETTS.Any()
                        && c.BASE.BASETTS.Where(t=>t.DEPT==deptCode).Any()                       
                         //&& c.BASE.BASETTS[0].DEPT == deptCode
                        select c).ToList();
            }           
        }


        public List<EmpCardLostReasonAmt> CalcCardReasonByDept(List<EmpCardLostReason> list)
        {
            List<EmpCardLostReasonAmt> resultList  = new  List<EmpCardLostReasonAmt>();

            var deptList = (from c in list select new { c.DeptCode, c.DeptName }).Distinct();
            var reasonList = (from c in list select new { c.ReasonCode, c.ReasonName }).Distinct();

            foreach (var d in deptList)
            {
                var deptDataList = (from c in list where c.DeptCode == d.DeptCode select c).ToList();

                foreach (var r in reasonList)
                {
                    var dataList = (from c in deptDataList where c.ReasonCode == r.ReasonCode select c).ToList();

                    EmpCardLostReasonAmt obj = new EmpCardLostReasonAmt();
                    obj.DeptCode = d.DeptCode;
                    obj.DeptName = d.DeptName;
                    obj.Counter = dataList.Count;

                    if (deptDataList.Count == 0)
                        obj.PercentOfDept = 0;
                    else
                    {                        
                        obj.PercentOfDept = Math.Round((Double)dataList.Count / deptDataList.Count, 4, MidpointRounding.AwayFromZero);
                        //obj.PercentOfDept = obj.PercentOfDept * 100;

                    }

                    obj.ReasonCode = r.ReasonCode;
                    obj.ReasonName = r.ReasonName;
                    resultList.Add(obj);

                }
            }


            //var deptGroup = list.GroupBy(g => g.DeptCode);

            //foreach (var dp in deptGroup)
            //{
            //    var reasonGroup = dp.GroupBy(g => g.ReasonCode);
            //    foreach (var rp in reasonGroup)
            //    {
            //        foreach (var item in rp)
            //        {
            //            EmpCardLostReasonAmt obj = new EmpCardLostReasonAmt();
            //            obj.DeptCode = item.DeptCode;
            //            obj.DeptName = item.DeptName;
            //            obj.Counter = rp.Count();
            //            obj.PercentOfDept = (Double)rp.Count() / dp.Count();
            //            obj.ReasonCode = item.ReasonCode;
            //            obj.ReasonName = item.ReasonName;
            //            resultList.Add(obj);
            //        }
            //    }
            //}



            return resultList;
        }


        public List<EmpCardLostReasonAmtByReason> CalcCardReasonByReason(List<EmpCardLostReasonAmt> list)
        {
            List<EmpCardLostReasonAmtByReason> resultList = new List<EmpCardLostReasonAmtByReason>();
            var reasonList = (from c in list select new { c.ReasonCode, c.ReasonName }).Distinct();
            int allCardCounter = (from c in list select c.Counter).Sum();

                foreach (var r in reasonList)
                {
                    EmpCardLostReasonAmtByReason obj = new EmpCardLostReasonAmtByReason();
                    int counter =(from c in list where c.ReasonCode == r.ReasonCode select c.Counter).Sum();
                    obj.Counter = counter;

                    if (allCardCounter == 0)
                        obj.PercentOfReason = 0;
                    else
                    {
                        obj.PercentOfReason = Math.Round((Double)counter / allCardCounter, 4, MidpointRounding.AwayFromZero);
                        //obj.PercentOfDept = obj.PercentOfDept * 100;

                    }

                    obj.ReasonCode = r.ReasonCode;
                    obj.ReasonName = r.ReasonName;
                    resultList.Add(obj);
                }

            return resultList;
        }


        public CARD GetLastestCardByDateNobr(string nobr,DateTime dt)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = dt.Date;
                return (from c in ldc.CARD
                        where c.NOBR ==nobr && c.ADATE ==datetime 
                        orderby c.ONTIME descending
                        select c).FirstOrDefault();
            }
        }

        public CARD GetLastestCardByDateNobr(string nobr, DateTime dt,string ontime)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = dt.Date;
                return (from c in ldc.CARD
                        where c.NOBR == nobr && c.ADATE == datetime && c.ONTIME ==ontime                        
                        select c).FirstOrDefault();
            }
        }
    }
}
