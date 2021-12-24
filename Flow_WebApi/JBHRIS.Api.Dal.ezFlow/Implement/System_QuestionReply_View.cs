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
    public class System_QuestionReply_View : ISystem_QuestionReply_View
    {

        private ShareContext _context;
        

        public System_QuestionReply_View(ShareContext context)
        {
            this._context = context;
        }



        public List<QuestionReplyVdb> GetQuestionReplyByQuestionMainCode(string QMainCode)
        {

            List<QuestionReplyVdb> result = (from bn in this._context.QuestionReplies
                                                      where bn.QuestionMainCode == QMainCode
                                             select new QuestionReplyVdb
                                                      {
                                                          AutoKey = bn.AutoKey,
                                                          Code = bn.Code,
                                                          QuestionMainCode = bn.QuestionMainCode,
                                                          Key1 = bn.Key1,
                                                          Key2 = bn.Key2,
                                                          Key3 = bn.Key3,
                                                          Name = bn.Name,
                                                          Content = bn.Content,
                                                          RoleKey = bn.RoleKey,
                                                          IpAddress = bn.IpAddress,
                                                          ReplyToCode = bn.ReplyToCode,
                                                          ParentCode = bn.ParentCode,
                                                          Send = bn.Send,
                                                          Note = bn.Note,
                                                          Status = bn.Status,
                                                          InsertMan = bn.InsertMan,
                                                          InsertDate = bn.InsertDate ?? new DateTime(),
                                                          UpdateMan = bn.UpdateMan,
                                                          UpdateDate = bn.InsertDate ?? new DateTime(),
                                                      }).ToList();
            


            return result;
            // return result;
        }
        public List<QuestionReplyVdb> GetQuestionReplyByCode(string Code)
        {

            List<QuestionReplyVdb> result = (from bn in this._context.QuestionReplies
                                             where bn.Code == Code
                                             select new QuestionReplyVdb
                                             {
                                                 AutoKey = bn.AutoKey,
                                                 Code = bn.Code,
                                                 QuestionMainCode = bn.QuestionMainCode,
                                                 Key1 = bn.Key1,
                                                 Key2 = bn.Key2,
                                                 Key3 = bn.Key3,
                                                 Name = bn.Name,
                                                 Content = bn.Content,
                                                 RoleKey = bn.RoleKey,
                                                 IpAddress = bn.IpAddress,
                                                 ReplyToCode = bn.ReplyToCode,
                                                 ParentCode = bn.ParentCode,
                                                 Send = bn.Send,
                                                 Note = bn.Note,
                                                 Status = bn.Status,
                                                 InsertMan = bn.InsertMan,
                                                 InsertDate = bn.InsertDate ?? new DateTime(),
                                                 UpdateMan = bn.UpdateMan,
                                                 UpdateDate = bn.InsertDate ?? new DateTime(),
                                             }).ToList();



            return result;
            // return result;
        }

        public bool InsertQuestionReply(QuestionReplyVdb vdb)
        {           
            bool result = false;

            try
            {
                var newQuestionReply = new QuestionReply();

                
                newQuestionReply.Code = vdb.Code;
                newQuestionReply.QuestionMainCode = vdb.QuestionMainCode;
                newQuestionReply.Key1 = vdb.Key1;
                newQuestionReply.Key2 = vdb.Key2;
                newQuestionReply.Key3 = vdb.Key3;
                newQuestionReply.Name = vdb.Name;
                newQuestionReply.Content = vdb.Content;
                newQuestionReply.RoleKey = vdb.RoleKey;
                newQuestionReply.IpAddress = vdb.IpAddress;
                newQuestionReply.ReplyToCode = vdb.ReplyToCode;
                newQuestionReply.ParentCode = vdb.ParentCode;
                newQuestionReply.Send = vdb.Send;
                newQuestionReply.Note = vdb.Note;
                newQuestionReply.Status = vdb.Status;
                newQuestionReply.InsertMan = vdb.InsertMan;
                newQuestionReply.InsertDate = vdb.InsertDate;
                newQuestionReply.UpdateMan = vdb.UpdateMan;
                newQuestionReply.UpdateDate = vdb.UpdateDate;
                _context.QuestionReplies.Add(newQuestionReply);
                _context.SaveChanges();
                result = true;
            }
            catch(Exception ex)
            { 
             
            }

            return result;
            
        }

        public bool UpdateQuestionReplySend(string Code,bool QRsend)
        {
            bool result = false;
            List<QuestionReply> newQuestionReply = (from bn in this._context.QuestionReplies
                                                       where bn.Code == Code
                                                       select new QuestionReply
                                                       {
                                                           AutoKey = bn.AutoKey,
                                                           Code = bn.Code,
                                                           QuestionMainCode = bn.QuestionMainCode,
                                                           Key1 = bn.Key1,
                                                           Key2 = bn.Key2,
                                                           Key3 = bn.Key3,
                                                           Name = bn.Name,
                                                           Content = bn.Content,
                                                           RoleKey = bn.RoleKey,
                                                           IpAddress = bn.IpAddress,
                                                           ReplyToCode = bn.ReplyToCode,
                                                           ParentCode = bn.ParentCode,
                                                           Send = bn.Send,
                                                           Note = bn.Note,
                                                           Status = bn.Status,
                                                           InsertMan = bn.InsertMan,
                                                           InsertDate = bn.InsertDate ?? new DateTime(),
                                                           UpdateMan = bn.UpdateMan,
                                                           UpdateDate = bn.InsertDate ?? new DateTime(),
                                                       }).ToList();

            try
            {
                foreach (var QR in newQuestionReply)
                {
                    QR.Send = QRsend;
                    _context.QuestionReplies.Update(QR);
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






        public bool UpdateQuestionReplyContent(string Code,string QRContent)
        {
            bool result = false;
            List<QuestionReply> newQuestionReply = (from bn in this._context.QuestionReplies
                                                    where bn.Code == Code && bn.Send==false
                                                    select new QuestionReply
                                                    {
                                                        AutoKey = bn.AutoKey,
                                                        Code = bn.Code,
                                                        QuestionMainCode = bn.QuestionMainCode,
                                                        Key1 = bn.Key1,
                                                        Key2 = bn.Key2,
                                                        Key3 = bn.Key3,
                                                        Name = bn.Name,
                                                        Content = QRContent,
                                                        RoleKey = bn.RoleKey,
                                                        IpAddress = bn.IpAddress,
                                                        ReplyToCode = bn.ReplyToCode,
                                                        ParentCode = bn.ParentCode,
                                                        Send = bn.Send,
                                                        Note = bn.Note,
                                                        Status = bn.Status,
                                                        InsertMan = bn.InsertMan,
                                                        InsertDate = bn.InsertDate,
                                                        UpdateMan = bn.UpdateMan,
                                                        UpdateDate = bn.InsertDate,
                                                    }).ToList();

            try
            {
                foreach (var QR in newQuestionReply)
                {
                    if (QR.Send == false)
                    {
                        QR.Content = QRContent;
                        _context.QuestionReplies.Update(QR);
                    }
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
