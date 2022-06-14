using JBModule.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class TaxLevelRepo
    {
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        public List<JBModule.Data.Linq.TAXLVL> GetOverlap(TaxLevelDto Dto)
        {
            var sql = from a in db.TAXLVL
                      where a.YEAR == Dto.YEAR
                      && a.AMT_H == Dto.AMT_H
                      select a;
            return sql.ToList();
        }
        public bool Insert(TaxLevelDto Dto, out string msg)
        {
            msg = "";
            try
            {
                JBModule.Data.Linq.TAXLVL TaxLevel = new JBModule.Data.Linq.TAXLVL
                {
                    YEAR = Dto.YEAR,
                    AMT_H = Dto.AMT_H,
                    AMT_L = Dto.AMT_L,
                    PER0 = Dto.PER0,
                    PER1 = Dto.PER1,
                    PER2 = Dto.PER2,
                    PER3 = Dto.PER3,
                    PER4 = Dto.PER4,
                    PER5 = Dto.PER5,
                    PER6 = Dto.PER6,
                    PER7 = Dto.PER7,
                    PER8 = Dto.PER8,
                    PER9 = Dto.PER9,
                    PER10 = Dto.PER10,
                    PER11 = Dto.PER11,
                    KEY_MAN =Dto.KEY_MAN,
                    KEY_DATE = Dto.KEY_DATE,
                };
                db.TAXLVL.InsertOnSubmit(TaxLevel);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool Update(TaxLevelDto Dto, out string msg)
        {
            msg = "";
            try
            {
                JBModule.Data.Linq.TAXLVL TaxLevel = new JBModule.Data.Linq.TAXLVL
                {
                    YEAR = Dto.YEAR,
                    AMT_H = Dto.AMT_H,
                    AMT_L = Dto.AMT_L,
                    PER0 = Dto.PER0,
                    PER1 = Dto.PER1,
                    PER2 = Dto.PER2,
                    PER3 = Dto.PER3,
                    PER4 = Dto.PER4,
                    PER5 = Dto.PER5,
                    PER6 = Dto.PER6,
                    PER7 = Dto.PER7,
                    PER8 = Dto.PER8,
                    PER9 = Dto.PER9,
                    PER10 = Dto.PER10,
                    PER11 = Dto.PER11,
                    KEY_MAN = Dto.KEY_MAN,
                    KEY_DATE = Dto.KEY_DATE,
                };
                var Duplicates = GetOverlap(Dto);
                if (Duplicates.Any())
                {
                    JBModule.Message.DbLog.WriteLog("OverLapUpdate", Dto, "Import", -1);
                    TaxLevelRepo.DataSaveRule(Duplicates, TaxLevel, db);
                }
                JBModule.Message.DbLog.WriteLog("Insert", TaxLevel, "Import", -1);
                db.TAXLVL.InsertOnSubmit(TaxLevel);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool Delete(TaxLevelDto Dto, out string msg)
        {
            msg = "";
            try
            {
                var Duplicates = GetOverlap(Dto);
                if (Duplicates.Any())
                {
                    JBModule.Message.DbLog.WriteLog("Delete", Duplicates, "Import", -1);
                    db.TAXLVL.DeleteAllOnSubmit(Duplicates);
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public static void DataSaveRule(List<JBModule.Data.Linq.TAXLVL> instanceRp, JBModule.Data.Linq.TAXLVL instanceNew, JBModule.Data.Linq.HrDBDataContext dbRP)
        {
            foreach (var item in instanceRp)
            {
                if (item.YEAR == instanceNew.YEAR && item.AMT_H == instanceNew.AMT_H)
                {
                    JBModule.Message.DbLog.WriteLog("Delete", item, "Import", -1);
                    dbRP.TAXLVL.DeleteOnSubmit(item);                    
                }
            }
            dbRP.SubmitChanges();
        }
    }
}
