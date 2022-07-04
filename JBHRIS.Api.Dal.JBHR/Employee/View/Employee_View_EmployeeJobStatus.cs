using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBHRIS.Api.Dal.JBHR.Employee.View
{
    public class Employee_View_EmployeeJobStatus : IEmployee_View_EmployeeJobStatus
    {
        private IUnitOfWork _unitOfWork;
        public Employee_View_EmployeeJobStatus(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ApiResult<string> AddChange(BasettsDto basettsDto)
        {
            ApiResult<string> result = new ApiResult<string>();
            try
            {
                var checkResult = CheckChange(basettsDto);
                if (!checkResult.State) return checkResult;

                var current = GetCurrentJobStatus(basettsDto.Nobr, basettsDto.Adate);
                var db = _unitOfWork.Repository<Basetts>();
                var data = db.Reads().Where(p => p.Nobr == basettsDto.Nobr).ToList();
                if (current.Adate == basettsDto.Adate) 
                {
                    //同一天用更新
                    var update = UpdateChange(basettsDto);
                    DateTime ddate = new DateTime(9999, 12, 31);
                    var sortData = data.OrderByDescending(p => p.Adate);
                    foreach (var it in sortData)
                    {
                        it.Ddate = ddate;
                        ddate = it.Adate.AddDays(-1);
                    }
                    db.SaveChanges();
                    return update;
                }
                else
                {
                    Basetts basetts = new Basetts
                    {
                        Nobr = basettsDto.Nobr,
                        Adate = basettsDto.Adate.Date,
                        Ttscode = basettsDto.Ttscode,
                        Ddate = basettsDto.Ddate.Value.Date,
                        Indt = basettsDto.Indt,
                        Cindt = basettsDto.Cindt,
                        Oudt = basettsDto.Oudt,
                        Stdt = basettsDto.Stdt,
                        Stindt = basettsDto.Stindt,
                        Stoudt = basettsDto.Stoudt,
                        Comp = basettsDto.Comp,
                        Dept = basettsDto.Dept,
                        Depts = basettsDto.Depts,
                        Job = basettsDto.Job,
                        Jobl = basettsDto.Jobl,
                        Card = basettsDto.Card,
                        Rotet = basettsDto.Rotet,
                        Di = basettsDto.Di,
                        KeyMan = basettsDto.KeyMan,
                        KeyDate = basettsDto.KeyDate,
                        Mang = basettsDto.Mang,
                        YrDays = basettsDto.YrDays,
                        WkYrs = basettsDto.WkYrs,
                        Saltp = basettsDto.Saltp,
                        Jobs = basettsDto.Jobs,
                        Workcd = basettsDto.Workcd,
                        Carcd = basettsDto.Carcd,
                        Empcd = basettsDto.Empcd,
                        Outcd = basettsDto.Outcd,
                        Calabs = basettsDto.Calabs,
                        Calot = basettsDto.Calot,
                        Fulatt = basettsDto.Fulatt,
                        Noter = basettsDto.Noter,
                        Nowel = basettsDto.Nowel,
                        Noret = basettsDto.Noret,
                        Notlate = basettsDto.Notlate,
                        HoliCode = basettsDto.HoliCode,
                        Noot = basettsDto.Noot,
                        Nospec = basettsDto.Nospec,
                        Nocard = basettsDto.Nocard,
                        Noeat = basettsDto.Noeat,
                        Apgrpcd = basettsDto.Apgrpcd,
                        Deptm = basettsDto.Deptm,
                        Ttscd = basettsDto.Ttscd,
                        Meno = basettsDto.Meno,
                        Saladr = basettsDto.Saladr,
                        Nowage = basettsDto.Nowage,
                        Mange = basettsDto.Mange,
                        Retrate = basettsDto.Retrate,
                        Retdate = basettsDto.Retdate,
                        Retchoo = basettsDto.Retchoo,
                        Retdate1 = basettsDto.Retdate1,
                        Onlyontime = basettsDto.Onlyontime,
                        Jobo = basettsDto.Jobo,
                        CountPass = basettsDto.CountPass,
                        PassDate = basettsDto.PassDate,
                        Mang1 = basettsDto.Mang1,
                        ApDate = basettsDto.ApDate,
                        GrpAmt = basettsDto.GrpAmt,
                        TaxDate = basettsDto.TaxDate,
                        Nospamt = basettsDto.Nospamt,
                        Fixrate = basettsDto.Fixrate,
                        TaxEdate = basettsDto.TaxEdate,
                        IsSelfout = basettsDto.IsSelfout,
                        InsgType = basettsDto.InsgType,
                        OldSaladr = basettsDto.OldSaladr,
                        Station = basettsDto.Station,
                        CardJobName = basettsDto.CardJobName,
                        CardJobEnName = basettsDto.CardJobEnName,
                        OilSubsidy = basettsDto.OilSubsidy,
                        CardId = basettsDto.CardId,
                        DoorGuard = basettsDto.DoorGuard,
                        OutPost = basettsDto.OutPost,
                        Nooldret = basettsDto.Nooldret,
                        ReinstateDate = basettsDto.ReinstateDate,
                        PassType = basettsDto.PassType,
                        AuditDate = basettsDto.AuditDate,
                        AssessManage1 = basettsDto.AssessManage1,
                        AssessManage2 = basettsDto.AssessManage2
                    };
                    db.Create(basetts);
                    data.Add(basetts);
                    DateTime ddate = new DateTime(9999, 12, 31);
                    var sortData = data.OrderByDescending(p => p.Adate);
                    foreach (var it in sortData)
                    {
                        it.Ddate = ddate;
                        ddate = it.Adate.AddDays(-1);
                    }
                    db.SaveChanges();
                }
                result.State = true;
            }
            catch (Exception ex)
            {
                result.State = false;
                result.Message = ex.Message;
                result.StackTrace = ex.StackTrace;
            }
            return result;
        }

        public ApiResult<string> CheckChange(BasettsDto basettsDto)
        {
            ApiResult<string> result = new ApiResult<string>();
            var current = GetCurrentJobStatus(basettsDto.Nobr, basettsDto.Adate);
            result.State = true;
            if (current == null)
            {
                result.State = false;
                result.Message = "無法取得當前異動紀錄";
            }
            else
            {
                var currentTtscode = current.Ttscode;
                var newTtscode = basettsDto.Ttscode;
                var resultValidate = ValidateTtscode(currentTtscode, newTtscode);
                if (!resultValidate.State) return resultValidate;
                if (current.Ddate < new DateTime(9999, 12, 31))
                {
                    result.State = false;
                    result.Message = "已存在較新的異動紀錄";
                }
            }
            return result;
        }

        public BasettsDto GetCurrentJobStatus(string EmployeeId, DateTime CheckDate)
        {
            var db = _unitOfWork.Repository<Basetts>();
            var basetts = db.Read(p => p.Nobr == EmployeeId && CheckDate.Date >= p.Adate && CheckDate.Date <= p.Ddate.Value);
            BasettsDto data = new BasettsDto
            {
                Nobr = basetts.Nobr,
                Adate = basetts.Adate,
                Ttscode = basetts.Ttscode,
                Ddate = basetts.Ddate,
                Indt = basetts.Indt,
                Cindt = basetts.Cindt,
                Oudt = basetts.Oudt,
                Stdt = basetts.Stdt,
                Stindt = basetts.Stindt,
                Stoudt = basetts.Stoudt,
                Comp = basetts.Comp,
                Dept = basetts.Dept,
                Depts = basetts.Depts,
                Job = basetts.Job,
                Jobl = basetts.Jobl,
                Card = basetts.Card,
                Rotet = basetts.Rotet,
                Di = basetts.Di,
                KeyMan = basetts.KeyMan,
                KeyDate = basetts.KeyDate,
                Mang = basetts.Mang,
                YrDays = basetts.YrDays,
                WkYrs = basetts.WkYrs,
                Saltp = basetts.Saltp,
                Jobs = basetts.Jobs,
                Workcd = basetts.Workcd,
                Carcd = basetts.Carcd,
                Empcd = basetts.Empcd,
                Outcd = basetts.Outcd,
                Calabs = basetts.Calabs,
                Calot = basetts.Calot,
                Fulatt = basetts.Fulatt,
                Noter = basetts.Noter,
                Nowel = basetts.Nowel,
                Noret = basetts.Noret,
                Notlate = basetts.Notlate,
                HoliCode = basetts.HoliCode,
                Noot = basetts.Noot,
                Nospec = basetts.Nospec,
                Nocard = basetts.Nocard,
                Noeat = basetts.Noeat,
                Apgrpcd = basetts.Apgrpcd,
                Deptm = basetts.Deptm,
                Ttscd = basetts.Ttscd,
                Meno = basetts.Meno,
                Saladr = basetts.Saladr,
                Nowage = basetts.Nowage,
                Mange = basetts.Mange,
                Retrate = basetts.Retrate,
                Retdate = basetts.Retdate,
                Retchoo = basetts.Retchoo,
                Retdate1 = basetts.Retdate1,
                Onlyontime = basetts.Onlyontime,
                Jobo = basetts.Jobo,
                CountPass = basetts.CountPass,
                PassDate = basetts.PassDate,
                Mang1 = basetts.Mang1,
                ApDate = basetts.ApDate,
                GrpAmt = basetts.GrpAmt,
                TaxDate = basetts.TaxDate,
                Nospamt = basetts.Nospamt,
                Fixrate = basetts.Fixrate,
                TaxEdate = basetts.TaxEdate,
                IsSelfout = basetts.IsSelfout,
                InsgType = basetts.InsgType,
                OldSaladr = basetts.OldSaladr,
                Station = basetts.Station,
                CardJobName = basetts.CardJobName,
                CardJobEnName = basetts.CardJobEnName,
                OilSubsidy = basetts.OilSubsidy,
                CardId = basetts.CardId,
                DoorGuard = basetts.DoorGuard,
                OutPost = basetts.OutPost,
                Nooldret = basetts.Nooldret,
                ReinstateDate = basetts.ReinstateDate,
                PassType = basetts.PassType,
                AuditDate = basetts.AuditDate,
                AssessManage1 = basetts.AssessManage1,
                AssessManage2 = basetts.AssessManage2
            };
            return data;
        }

        List<string> skipField = new List<string> { "NOBR", "ADATE", "TTSCODE", "BASETTS", "BASE", "DEPT1", "DEPTS1", "DEPTM1", "DEPTA1" };
        public ApiResult<string> UpdateChange(BasettsDto basettsDto)
        {
            ApiResult<string> result = new ApiResult<string>();
            try
            {
                var db = _unitOfWork.Repository<Basetts>();
                var data = db.Reads().Where(p => p.Nobr == basettsDto.Nobr && p.Adate == basettsDto.Adate).FirstOrDefault();//取得目前資料

                foreach (var field in basettsDto.GetType().GetProperties())
                {
                    if (skipField.Contains(field.Name)) continue;//排除欄位
                    //依序變更欄位
                    data.GetType().GetProperty(field.Name).SetValue(data, basettsDto.GetType().GetProperty(field.Name).GetValue(basettsDto));
                }
                db.SaveChanges();
                result.State = true;
            }
            catch (Exception ex)
            {
                result.State = false;
                result.Message = ex.Message;
                result.StackTrace = ex.StackTrace;
            }
            return result;
        }

        public ApiResult<string> ValidateTtscode(string CurrentTtscode, string NewTtscode)
        {
            ApiResult<string> result = new ApiResult<string>();
            Dictionary<string, string> dicTtsName = new Dictionary<string, string>();
            dicTtsName.Add("1", "到職");
            dicTtsName.Add("2", "離職");
            dicTtsName.Add("3", "留職停薪");
            dicTtsName.Add("4", "停薪復職");
            dicTtsName.Add("5", "留停離職");
            dicTtsName.Add("6", "異動");
            var currentTtsName = dicTtsName[CurrentTtscode];
            var newTtsName = dicTtsName[NewTtscode];

            var checkList = new List<string>();
            switch (CurrentTtscode)
            {
                case "1":
                    checkList.AddRange(new string[] { "2", "3", "6" });
                    break;
                case "2":
                    checkList.AddRange(new string[] { "1", "4" });
                    break;
                case "3":
                    checkList.AddRange(new string[] { "4", "5" });
                    break;
                case "4":
                    checkList.AddRange(new string[] { "3", "6" });
                    break;
                case "5":
                    checkList.AddRange(new string[] { "1", "4" });
                    break;
                case "6":
                    checkList.AddRange(new string[] { "2", "3", "6" });
                    break;
            }
            result.State = checkList.Contains(NewTtscode);
            if (!result.State)
                result.Message = "不可從目前狀態-" + currentTtsName + "變更為-" + newTtsName;
            return result;
        }

        public List<BasettsDto> GetEmployeeJobStatus(string EmployeeId)
        {
            var db = _unitOfWork.Repository<Basetts>();
            var data = db.Reads().Where(p => p.Nobr == EmployeeId).Select(basetts=>new BasettsDto
            {
                Nobr = basetts.Nobr,
                Adate = basetts.Adate,
                Ttscode = basetts.Ttscode,
                Ddate = basetts.Ddate,
                Indt = basetts.Indt,
                Cindt = basetts.Cindt,
                Oudt = basetts.Oudt,
                Stdt = basetts.Stdt,
                Stindt = basetts.Stindt,
                Stoudt = basetts.Stoudt,
                Comp = basetts.Comp,
                Dept = basetts.Dept,
                Depts = basetts.Depts,
                Job = basetts.Job,
                Jobl = basetts.Jobl,
                Card = basetts.Card,
                Rotet = basetts.Rotet,
                Di = basetts.Di,
                KeyMan = basetts.KeyMan,
                KeyDate = basetts.KeyDate,
                Mang = basetts.Mang,
                YrDays = basetts.YrDays,
                WkYrs = basetts.WkYrs,
                Saltp = basetts.Saltp,
                Jobs = basetts.Jobs,
                Workcd = basetts.Workcd,
                Carcd = basetts.Carcd,
                Empcd = basetts.Empcd,
                Outcd = basetts.Outcd,
                Calabs = basetts.Calabs,
                Calot = basetts.Calot,
                Fulatt = basetts.Fulatt,
                Noter = basetts.Noter,
                Nowel = basetts.Nowel,
                Noret = basetts.Noret,
                Notlate = basetts.Notlate,
                HoliCode = basetts.HoliCode,
                Noot = basetts.Noot,
                Nospec = basetts.Nospec,
                Nocard = basetts.Nocard,
                Noeat = basetts.Noeat,
                Apgrpcd = basetts.Apgrpcd,
                Deptm = basetts.Deptm,
                Ttscd = basetts.Ttscd,
                Meno = basetts.Meno,
                Saladr = basetts.Saladr,
                Nowage = basetts.Nowage,
                Mange = basetts.Mange,
                Retrate = basetts.Retrate,
                Retdate = basetts.Retdate,
                Retchoo = basetts.Retchoo,
                Retdate1 = basetts.Retdate1,
                Onlyontime = basetts.Onlyontime,
                Jobo = basetts.Jobo,
                CountPass = basetts.CountPass,
                PassDate = basetts.PassDate,
                Mang1 = basetts.Mang1,
                ApDate = basetts.ApDate,
                GrpAmt = basetts.GrpAmt,
                TaxDate = basetts.TaxDate,
                Nospamt = basetts.Nospamt,
                Fixrate = basetts.Fixrate,
                TaxEdate = basetts.TaxEdate,
                IsSelfout = basetts.IsSelfout,
                InsgType = basetts.InsgType,
                OldSaladr = basetts.OldSaladr,
                Station = basetts.Station,
                CardJobName = basetts.CardJobName,
                CardJobEnName = basetts.CardJobEnName,
                OilSubsidy = basetts.OilSubsidy,
                CardId = basetts.CardId,
                DoorGuard = basetts.DoorGuard,
                OutPost = basetts.OutPost,
                Nooldret = basetts.Nooldret,
                ReinstateDate = basetts.ReinstateDate,
                PassType = basetts.PassType,
                AuditDate = basetts.AuditDate,
                AssessManage1 = basetts.AssessManage1,
                AssessManage2 = basetts.AssessManage2
            });
            return data.ToList();
        }
    }
}
