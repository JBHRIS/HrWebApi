using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Dal.ezFlow.Entity.Share;
using JBHRIS.Api.Tools.Tool;


namespace JBHRIS.Api.Dal.ezFlow.Implement
{
    public class System_QuestionDefaultMessage_View : ISystem_QuestionDefaultMessage_View
    {

        private ShareContext _context;
        

        public System_QuestionDefaultMessage_View(ShareContext context)
        {
            this._context = context;
        }



        public List<QuestionDefaultMessageVdb> GetQuestionDefaultMessage(string Code)
        {
            
            List<QuestionDefaultMessageVdb> result = (from bn in this._context.QuestionDefaultMessages
                                                      where bn.Code == Code
                                                      select new QuestionDefaultMessageVdb
                                                      {
                                                          AutoKey = bn.AutoKey,
                                                          CompanyId = bn.CompanyId,
                                                          Code = bn.Code,
                                                          Name = bn.Name,
                                                          Contents = bn.Contents,
                                                          RoleKey = bn.RoleKey,
                                                          Note = bn.Note,
                                                          Status = bn.Status,
                                                          InsertMan = bn.InsertMan,
                                                          InsertDate = bn.InsertDate ?? new DateTime(),
                                                          UpdateMan = bn.UpdateMan,
                                                          UpdateDate = bn.UpdateDate ?? new DateTime(),
                                                      }).ToList();
            


            return result;
            // return result;
        }



        public List<QuestionDefaultMessageVdb> GetQuestionDefaultMessageByRoleKey(int RoleKey)
        {
            List<QuestionDefaultMessageVdb> result = new List<QuestionDefaultMessageVdb>();
            List<QuestionDefaultMessageVdb> QM = (from bn in this._context.QuestionDefaultMessages                                                     
                                                  select new QuestionDefaultMessageVdb
                                                      {
                                                          AutoKey = bn.AutoKey,
                                                          CompanyId = bn.CompanyId,
                                                          Code = bn.Code,
                                                          Name = bn.Name,
                                                          Contents = bn.Contents,
                                                          RoleKey = bn.RoleKey,
                                                          Note = bn.Note,
                                                          Status = bn.Status,
                                                          InsertMan = bn.InsertMan,
                                                          InsertDate = bn.InsertDate ?? new DateTime(),
                                                          UpdateMan = bn.UpdateMan,
                                                          UpdateDate = bn.UpdateDate ?? new DateTime(),
                                                      }).ToList();


            foreach (var rQm in QM)
            {
                if (Security.IsRoleValid(rQm.RoleKey, Security.GetRoleKeyToBinaryKey(RoleKey)))
                {
                    result.Add(rQm);
                }
            }

            return result;
            // return result;
        }





        public bool InsertQuestionDefaultMessage(QuestionDefaultMessageVdb vdb)
        {           
            bool result = false;
            



            try
            {
                var newQuestionDefaultMessage = new QuestionDefaultMessage();
                
                newQuestionDefaultMessage.CompanyId = vdb.CompanyId;
                newQuestionDefaultMessage.Code = vdb.Code;
                newQuestionDefaultMessage.Name = vdb.Name;
                newQuestionDefaultMessage.Contents = vdb.Contents;
                newQuestionDefaultMessage.RoleKey = vdb.RoleKey;
                newQuestionDefaultMessage.Note = vdb.Note;
                newQuestionDefaultMessage.Status = vdb.Status;
                newQuestionDefaultMessage.InsertMan = vdb.InsertMan;
                newQuestionDefaultMessage.InsertDate = vdb.InsertDate;
                newQuestionDefaultMessage.UpdateMan = vdb.UpdateMan;
                newQuestionDefaultMessage.UpdateDate = vdb.UpdateDate;
                _context.QuestionDefaultMessages.Add(newQuestionDefaultMessage);
                _context.SaveChanges();
                result = true;
            }
            catch(Exception ex)
            { 
             
            }

            return result;
            
        }

        public bool UpdateQuestionDefaultMessage(QuestionDefaultMessageVdb vdb)
        {
            bool result = false;
            List<QuestionDefaultMessage> newQuestionDefaultMessage = (from bn in this._context.QuestionDefaultMessages
                                                                      where bn.Code == vdb.Code
                                                                      select new QuestionDefaultMessage
                                                                      {
                                                                          AutoKey = bn.AutoKey,
                                                                          CompanyId = bn.CompanyId,
                                                                          Code = bn.Code,
                                                                          Name = vdb.Name,
                                                                          Contents = vdb.Contents,
                                                                          RoleKey = bn.RoleKey,
                                                                          Note = bn.Note,
                                                                          Status = bn.Status,
                                                                          InsertMan = bn.InsertMan,
                                                                          InsertDate = bn.InsertDate,
                                                                          UpdateMan = vdb.UpdateMan,
                                                                          UpdateDate = vdb.UpdateDate,
                                                                      }).ToList();

            try
            {
                foreach (var QDM in newQuestionDefaultMessage)
                {
                    _context.QuestionDefaultMessages.Update(QDM);
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






        public bool DeleteQuestionDefaultMessage(string Code)
        {
            bool result = false;
            List<QuestionDefaultMessage> newQuestionDefaultMessage = (from bn in this._context.QuestionDefaultMessages
                                                                      where bn.Code == Code
                                                                      select new QuestionDefaultMessage
                                                                      {
                                                                          AutoKey = bn.AutoKey,
                                                                          CompanyId = bn.CompanyId,
                                                                          Code = bn.Code,
                                                                          Name = bn.Name,
                                                                          Contents = bn.Contents,
                                                                          RoleKey = bn.RoleKey,
                                                                          Note = bn.Note,
                                                                          Status = bn.Status,
                                                                          InsertMan = bn.InsertMan,
                                                                          InsertDate = bn.InsertDate,
                                                                          UpdateMan = bn.UpdateMan,
                                                                          UpdateDate = bn.UpdateDate,
                                                                      }).ToList();
                                                                     
                                                                    

            try
            {
                foreach (var QDM in newQuestionDefaultMessage)
                {
                    _context.QuestionDefaultMessages.Remove(QDM);
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
