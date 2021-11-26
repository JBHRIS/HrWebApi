using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using JBHRModel;
using System.Web.Caching;
using System.Data.Linq;

namespace BL
{
    /// <summary>
    /// DEPTA 的摘要描述
    /// </summary>
    public class ATTCARD_REPO
    {
        private static readonly Object syncObj = new Object();
        public JBHRModelDataContext dc { get; set; }
        public ATTCARD_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public ATTCARD_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public List<ATTCARD> GetAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.ATTCARD
                        select c).ToList();
            }
        }



        public List<ATTCARD> GetLostByEmpDateRange_Dlo(string nobr, DateTime bDate, DateTime eDate)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<ATTCARD>(l => l.BASE);
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime));
                ldc.LoadOptions = dlo;

                return (from c in ldc.ATTCARD
                        where c.ADATE >= bDate && c.ADATE <= eDate
                        && c.BASE.BASETTS.Any()
                        && c.BASE.NOBR ==nobr
                        && (c.LOST1 || c.LOST2)
                        select c).ToList();
            }
        }


        public List<ATTCARD> GetLostByDeptDateRange_Dlo(string deptCode, DateTime bDate, DateTime eDate)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<ATTCARD>(l => l.BASE);
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime));
                ldc.LoadOptions = dlo;

                return (from c in ldc.ATTCARD
                        where c.ADATE >= bDate && c.ADATE <= eDate
                        && c.BASE.BASETTS.Any()
                        && c.BASE.BASETTS.Where(p => p.DEPT == deptCode).Any()
                        && (c.LOST1 || c.LOST2)
                        select c).ToList();
            }
        }

        public List<EmpAttendLateSumDto> SummaryEmpAttnedCardLost(List<EmpAttendLateDto> list)
        {
            List<EmpAttendLateSumDto> resultList = new List<EmpAttendLateSumDto>();

            List<string> nobrList = (from c in list select c.Nobr).Distinct().ToList();

            foreach (string nobr in nobrList)
            {
                EmpAttendLateDto ATTCARDObj = (from c in list where c.Nobr == nobr select c).First();

                EmpAttendLateSumDto ATTCARDSumObj = new EmpAttendLateSumDto();
                ATTCARDSumObj.DeptCode = ATTCARDObj.DeptCode;
                ATTCARDSumObj.DeptName = ATTCARDObj.DeptName;
                ATTCARDSumObj.JobCode = ATTCARDObj.JobCode;
                ATTCARDSumObj.JobName = ATTCARDObj.JobName;
                ATTCARDSumObj.Name_C = ATTCARDObj.Name_C;
                ATTCARDSumObj.Name_E = ATTCARDObj.Name_E;
                ATTCARDSumObj.Nobr = ATTCARDObj.Nobr;
                ATTCARDSumObj.MinsAmt = (from c in list where c.Nobr == nobr select c.Qty).Sum();
                //ATTCARDSumObj.MinsNum = (from c in list where c.Nobr == nobr select c.Qty).Sum();
                resultList.Add(ATTCARDSumObj);
            }

            resultList = resultList.OrderByDescending(p => p.MinsAmt).ToList();

            int counter = 1;
            foreach (var i in resultList)
                i.Place = counter++;

            return resultList;
        }
    }    
}