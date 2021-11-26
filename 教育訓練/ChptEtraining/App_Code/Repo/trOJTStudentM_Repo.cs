using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
namespace Repo
{
    /// <summary>
    /// BASE_Repo 的摘要描述
    /// </summary>
    public class trOJTStudentM_Repo
    {
        public dcTrainingDataContext dc { get; set; }     

        public trOJTStudentM_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public trOJTStudentM_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }

        /// <summary>
        /// Get By Nobr OjtCode
        /// </summary>
        /// <param name="nobr"></param>
        /// <param name="ojbCode"></param>
        /// <returns></returns>
        public trOJTStudentM GetByNobrOjtCode(string nobr, string ojbCode)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trOJTStudentM
                        where c.sNobr == nobr && c.OJT_sCode == ojbCode
                        select c).FirstOrDefault();
            }
        }


        public List<trOJTStudentM> GetByOjtCode(string ojbCode)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trOJTStudentM
                        where c.OJT_sCode == ojbCode
                        select c).ToList();
            }
        }

        /// <summary>
        /// Get By Nobr
        /// </summary>
        /// <param name="nobr"></param>
        /// <returns></returns>
        public List<trOJTStudentM> GetByNobr(string nobr)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trOJTStudentM
                        where c.sNobr == nobr
                        select c).ToList();
            }
        }


        public void Add(trOJTStudentM o)
        {
            dc.trOJTStudentM.InsertOnSubmit(o);            
        }

        public void Delete(trOJTStudentM o)
        {
            var obj = (from c in dc.trOJTStudentM where c.iAutoKey ==o.iAutoKey
                       select c).FirstOrDefault();
            dc.trOJTStudentM.DeleteOnSubmit(obj);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        /// <summary>
        /// Check是否有該自動給卡，而沒有給卡的
        /// </summary>
        /// <param name="nobr"></param>
        public void CheckEmpOjtCard(string nobr)
        {
            using (dcTrainingDataContext dcTrain = new dcTrainingDataContext())
            {
                BASETTS_Repo basettsRepo = new BASETTS_Repo();
                BASETTS basetts = basettsRepo.GetEmpByNobrNow_DLO(nobr);
                if (basetts == null)
                    return;

                OjtUnitCard_Repo ojtUnitCardRepo = new OjtUnitCard_Repo();
                OjtCardGrantedRecord_Repo cardGrantrdRecordRepo = new OjtCardGrantedRecord_Repo();
                cardGrantrdRecordRepo.dc = dcTrain;

                List<OjtUnitCard> ojtUnitCardlist = ojtUnitCardRepo.GetByDeptByOjtCardValid(basetts.DEPT);

                trOJTStudentM_Repo ojtSM_Repo = new trOJTStudentM_Repo();
                ojtSM_Repo.dc = dcTrain;
                //List<trOJTStudentM> ojtSM_list = ojtSM_Repo.GetByNobr(nobr);
                List<OjtCardGrantedRecord> cardGrantedRecordList = cardGrantrdRecordRepo.GetByNobr(nobr);

                foreach (var uc in ojtUnitCardlist)
                {
                    //if (ojtSM_list.Where(l => l.OJT_sCode == uc.OjtCard).FirstOrDefault() == null)
                    if (cardGrantedRecordList.Where(l => l.OjtCard == uc.OjtCard).FirstOrDefault() == null)
                    {
                        trOJTStudentM obj = ojtSM_Repo.GetByNobrOjtCode(nobr, uc.OjtCard);
                        if (obj == null)
                        {
                            obj = new trOJTStudentM();
                            obj.OJT_sCode = uc.OjtCard;
                            obj.sNobr = nobr;
                            obj.dKeyDate = DateTime.Now;
                            ojtSM_Repo.Add(obj);

                            //新增訓練卡中的項目Detail部分
                            trOJTTemplateDetail_Repo ojtTplDtlRepo = new trOJTTemplateDetail_Repo(dcTrain);
                            List<trOJTTemplateDetail> ojtTplDtlList= ojtTplDtlRepo.GetByOjtTplCode(uc.OjtCard);

                            trOJTStudentD_Repo ojtSdRepo = new trOJTStudentD_Repo(dcTrain);
                            foreach (var d in ojtTplDtlList)
                            {
                                var ojtSdObj = ojtSdRepo.GetByOjtCodeNobrCourse(uc.OjtCard,nobr, d.trCourse_sCode);
                                if (ojtSdObj == null)
                                {
                                    trCourse_Repo trCourseRepo = new trCourse_Repo(dcTrain);
                                    trCourse trCourseObj = trCourseRepo.GetByCode(d.trCourse_sCode);

                                    trOJTStudentD ojtSdNew = new trOJTStudentD();
                                    ojtSdNew.OJT_sCode = uc.OjtCard;
                                    ojtSdNew.iJobScore = trCourseObj.iJobScore;
                                    ojtSdNew.bPass = false;
                                    ojtSdNew.dCreatedDate = DateTime.Now;
                                    ojtSdNew.sNobr = nobr;
                                    ojtSdNew.trCourse_sCode = d.trCourse_sCode;
                                    ojtSdRepo.Add(ojtSdNew);
                                }
                            }
                        }
                        OjtCardGrantedRecord cardGrantedRecord = new OjtCardGrantedRecord();
                        cardGrantedRecord.dKeyDate = DateTime.Now;
                        cardGrantedRecord.bSystemGrant = true;
                        cardGrantedRecord.OjtCard = uc.OjtCard;
                        cardGrantedRecord.sNobr = nobr;
                        cardGrantrdRecordRepo.Add(cardGrantedRecord);
                    }
                }

                ojtSM_Repo.Save();
            }
        }

    }
}