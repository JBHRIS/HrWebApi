using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Dal.ezFlow.Entity.Share;

namespace JBHRIS.Api.Dal.ezFlow.Implement
{
    public class System_QuestionMain_View : ISystem_QuestionMain_View
    {

        private ShareContext _context;


        public System_QuestionMain_View(ShareContext context)
        {
            this._context = context;
        }


        public List<QuestionMainVdb> GetQuestionMain()
        {

            List<QuestionMainVdb> result = (from bn in this._context.QuestionMains
                                            join cn in this._context.ShareCodes on bn.QuestionCategoryCode equals cn.Code into ps
                                            from cn in ps.DefaultIfEmpty()
                                            where cn.GroupCode == "ReplyCode"
                                            select new QuestionMainVdb
                                            {
                                                AutoKey = bn.AutoKey,
                                                CompanyId = bn.CompanyId,
                                                Code = bn.Code,
                                                SystemCategoryCode = bn.SystemCategoryCode,
                                                Key1 = bn.Key1,
                                                Key2 = bn.Key2,
                                                Key3 = bn.Key3,
                                                Name = bn.Name,
                                                TitleContent = bn.TitleContent,
                                                Content = bn.Content,
                                                QuestionCategoryCode = bn.QuestionCategoryCode,
                                                QuestionCategoryName = cn.Name,
                                                IpAddress = bn.IpAddress,
                                                DateE = bn.DateE,
                                                Complete = bn.Complete,
                                                Note = bn.Note,
                                                Status = bn.Status,
                                                InsertMan = bn.InsertMan,
                                                InsertDate = bn.InsertDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                                                UpdateMan = bn.UpdateMan,
                                                UpdateDate = bn.UpdateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                                            }).ToList();



            return result;
            // return result;
        }


        public List<QuestionMainVdb> GetQuestionMainByEmpID(string CompanyId, string sNobr)
        {

            List<QuestionMainVdb> result = (from bn in this._context.QuestionMains
                                            join cn in this._context.ShareCodes on bn.QuestionCategoryCode equals cn.Code into ps
                                            from cn in ps.DefaultIfEmpty()
                                            where bn.CompanyId==CompanyId
                                            && bn.Key1==sNobr&&cn.GroupCode=="ReplyCode"
                                            select new QuestionMainVdb
                                            {
                                                AutoKey = bn.AutoKey,
                                                CompanyId = bn.CompanyId,
                                                Code = bn.Code,
                                                SystemCategoryCode = bn.SystemCategoryCode,
                                                Key1 = bn.Key1,
                                                Key2 = bn.Key2,
                                                Key3 = bn.Key3,
                                                Name = bn.Name,
                                                TitleContent = bn.TitleContent,
                                                Content = bn.Content,
                                                QuestionCategoryCode = bn.QuestionCategoryCode,
                                                QuestionCategoryName = cn.Name,
                                                IpAddress = bn.IpAddress,
                                                DateE = bn.DateE,
                                                Complete = bn.Complete,
                                                Note = bn.Note,
                                                Status = bn.Status,
                                                InsertMan = bn.InsertMan,
                                                InsertDate = bn.InsertDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                                                UpdateMan = bn.UpdateMan,
                                                UpdateDate = bn.UpdateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                                            }).ToList();



            return result;
            // return result;
        }



        public List<QuestionMainVdb> GetQuestionMainByCompany(string CompanyId)
        {

            List<QuestionMainVdb> result = (from bn in this._context.QuestionMains
                                            join cn in this._context.ShareCodes on bn.QuestionCategoryCode equals cn.Code into ps
                                            from cn in ps.DefaultIfEmpty()
                                            where bn.CompanyId==CompanyId && cn.GroupCode == "ReplyCode" 
                                            select new QuestionMainVdb
                                            {
                                                AutoKey = bn.AutoKey,
                                                CompanyId = bn.CompanyId,
                                                Code = bn.Code,
                                                SystemCategoryCode = bn.SystemCategoryCode,
                                                Key1 = bn.Key1,
                                                Key2 = bn.Key2,
                                                Key3 = bn.Key3,
                                                Name = bn.Name,
                                                TitleContent = bn.TitleContent,
                                                Content = bn.Content,
                                                QuestionCategoryCode = bn.QuestionCategoryCode,
                                                QuestionCategoryName =cn.Name,
                                                IpAddress = bn.IpAddress,
                                                DateE = bn.DateE,
                                                Complete = bn.Complete,
                                                Note = bn.Note,
                                                Status = bn.Status,
                                                InsertMan = bn.InsertMan,
                                                InsertDate = bn.InsertDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                                                UpdateMan = bn.UpdateMan,
                                                UpdateDate = bn.UpdateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                                            }).ToList();



            return result;
            // return result;
        }







        public List<QuestionMainVdb> GetQuestionMainByCode(string Code)
        {

            List<QuestionMainVdb> result = (from bn in this._context.QuestionMains
                                            join cn in this._context.ShareCodes on bn.QuestionCategoryCode equals cn.Code
                                            where bn.Code == Code && cn.GroupCode == "ReplyCode"
                                            select new QuestionMainVdb
                                                      {
                                                          AutoKey = bn.AutoKey,
                                                          CompanyId = bn.CompanyId,
                                                          Code = bn.Code,
                                                          SystemCategoryCode=bn.SystemCategoryCode,
                                                          Key1 =bn.Key1,
                                                          Key2=bn.Key2,
                                                          Key3=bn.Key3,
                                                          Name = bn.Name,
                                                          TitleContent=bn.TitleContent,
                                                          Content = bn.Content,
                                                          QuestionCategoryCode = bn.QuestionCategoryCode,
                                                          QuestionCategoryName = cn.Name,
                                                          IpAddress = bn.IpAddress,
                                                          DateE = bn.DateE,
                                                          Complete = bn.Complete,                                                          
                                                          Note = bn.Note,
                                                          Status = bn.Status,
                                                          InsertMan = bn.InsertMan,
                                                          InsertDate = bn.InsertDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                                                          UpdateMan = bn.UpdateMan,
                                                          UpdateDate = bn.UpdateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                                                      }).ToList();
            


            return result;
            // return result;
        }








        public bool InsertQuestionMain(QuestionMainVdb vdb)
        {           
            bool result = false;

            try
            {
                var newQuestionMain = new QuestionMain();

                
                newQuestionMain.CompanyId = vdb.CompanyId;
                newQuestionMain.Code = vdb.Code;
                newQuestionMain.SystemCategoryCode = vdb.SystemCategoryCode;
                newQuestionMain.Key1 = vdb.Key1;
                newQuestionMain.Key2 = vdb.Key2;
                newQuestionMain.Key3 = vdb.Key3;
                newQuestionMain.Name = vdb.Name;
                newQuestionMain.TitleContent = vdb.TitleContent;
                newQuestionMain.Content = vdb.Content;
                newQuestionMain.QuestionCategoryCode = vdb.QuestionCategoryCode;
                newQuestionMain.IpAddress = vdb.IpAddress;
                newQuestionMain.DateE = vdb.DateE;
                newQuestionMain.Complete = vdb.Complete;                
                newQuestionMain.Note = vdb.Note;
                newQuestionMain.Status = vdb.Status;
                newQuestionMain.InsertMan = vdb.InsertMan;
                newQuestionMain.InsertDate = DateTime.Parse(vdb.InsertDate);
                newQuestionMain.UpdateMan = vdb.UpdateMan;
                if (vdb.UpdateDate == ""||vdb.UpdateDate==null)
                {
                    newQuestionMain.UpdateDate = null;
                }
                else
                {
                    newQuestionMain.UpdateDate = DateTime.Parse(vdb.UpdateDate);
                }
                _context.QuestionMains.Add(newQuestionMain);
                _context.SaveChanges();
                result = true;
            }
            catch(Exception ex)
            { 
             
            }

            return result;
            
        }

        public bool UpdateQuestionMain(string Code,QuestionMainVdb vdb)
        {
            bool result = false;
            List<QuestionMain> newQuestionMain = (from bn in this._context.QuestionMains
                                                                      where bn.Code == Code
                                                                      select new QuestionMain
                                                                      {
                                                                          AutoKey = bn.AutoKey,
                                                                          CompanyId = vdb.CompanyId,
                                                                          Code = vdb.Code,
                                                                          SystemCategoryCode = vdb.SystemCategoryCode,
                                                                          Key1 = vdb.Key1,
                                                                          Key2 = vdb.Key2,
                                                                          Key3 = vdb.Key3,
                                                                          Name = vdb.Name,
                                                                          TitleContent = vdb.TitleContent,
                                                                          Content = vdb.Content,
                                                                          QuestionCategoryCode = vdb.QuestionCategoryCode,
                                                                          IpAddress = vdb.IpAddress,
                                                                          DateE = vdb.DateE,
                                                                          Complete = vdb.Complete,
                                                                          Note = vdb.Note,
                                                                          Status = vdb.Status,
                                                                          InsertMan = vdb.InsertMan,
                                                                          InsertDate = Convert.ToDateTime(vdb.InsertDate),
                                                                          UpdateMan = vdb.UpdateMan,
                                                                          UpdateDate = Convert.ToDateTime(vdb.UpdateDate),
                                                                      }).ToList();

            try
            {
                foreach (var QDM in newQuestionMain)
                {
                    _context.QuestionMains.Update(QDM);
                }
                _context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {

            }

            return result;
            // return result;
        }






        public bool DeleteQuestionMain(string Code)
        {
            bool result = false;
            List<QuestionMain> newQuestionMain = (from bn in this._context.QuestionMains
                                                      where bn.Code == Code
                                                      select new QuestionMain
                                                      {
                                                          AutoKey = bn.AutoKey,
                                                          CompanyId = bn.CompanyId,
                                                          Code = bn.Code,
                                                          SystemCategoryCode = bn.SystemCategoryCode,
                                                          Key1 = bn.Key1,
                                                          Key2 = bn.Key2,
                                                          Key3 = bn.Key3,
                                                          Name = bn.Name,
                                                          TitleContent = bn.TitleContent,
                                                          Content = bn.Content,
                                                          QuestionCategoryCode = bn.QuestionCategoryCode,
                                                          IpAddress = bn.IpAddress,
                                                          DateE = bn.DateE,
                                                          Complete = bn.Complete,
                                                          Note = bn.Note,
                                                          Status = bn.Status,
                                                          InsertMan = bn.InsertMan,
                                                          InsertDate = Convert.ToDateTime(bn.InsertDate),
                                                          UpdateMan = bn.UpdateMan,
                                                          UpdateDate = Convert.ToDateTime(bn.UpdateDate),
                                                      }).ToList();

            try
            {
                foreach (var QDM in newQuestionMain)
                {
                    _context.QuestionMains.Remove(QDM);
                }
                _context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            { 
            
            }

            return result;
            // return result;
        }



    }
}
