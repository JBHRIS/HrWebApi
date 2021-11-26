using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class MasterRepo
    {
        Linq.HrDBDataContext db = new Linq.HrDBDataContext();
        public Linq.MASTER GetOverlapMASTER(Dto.MasterDto masterDto)
        {
            var sql = from a in db.MASTER
                      where a.NOBR == masterDto.NOBR
                      && a.MASTER1 == masterDto.MASTER
                      select a;
            return sql.FirstOrDefault();
        }
        public bool InsertMASTER(Dto.MasterDto masterDto, out string msg)
        {
            msg = "";
            try
            {
                Linq.MASTER master = new Linq.MASTER();
                master.NOBR = masterDto.NOBR;
                master.MASTER1 = masterDto.MASTER;
                master.RELISH_CODE = "";
                master.RELISH = "";
                master.CORPORATION = "";
                master.LANGUAGE = "";
                master.MEMO = masterDto.MEMO;
                master.master_id = 0;
                master.KEY_DATE = masterDto.KEY_DATE;
                master.KEY_MAN = masterDto.KEY_MAN;
                db.MASTER.InsertOnSubmit(master);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool UpdateMASTER(Dto.MasterDto masterDto, out string msg)
        {
            msg = "";
            try
            {
                var master = GetOverlapMASTER(masterDto);
                if (master != null)
                {
                    master.MEMO = masterDto.MEMO;
                    master.KEY_DATE = masterDto.KEY_DATE;
                    master.KEY_MAN = masterDto.KEY_MAN;
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
        public bool DeleteMASTER(Dto.MasterDto masterDto, out string msg)
        {
            msg = "";
            try
            {
                var master = GetOverlapMASTER(masterDto);
                if (master != null)
                {
                    db.MASTER.DeleteOnSubmit(master);
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
    }
}
