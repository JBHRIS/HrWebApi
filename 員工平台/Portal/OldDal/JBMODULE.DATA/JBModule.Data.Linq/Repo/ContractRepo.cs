using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class ContractRepo
    {
        Linq.HrDBDataContext db = new Linq.HrDBDataContext();
        public Linq.Contract GetOverlapContract(Dto.ContractDto contractDto)
        {
            var sql = from a in db.Contract
                      where a.Nobr == contractDto.NOBR
                      && a.Adate == contractDto.Adate
                      && a.Ddate == contractDto.Ddate
                      select a;
            return sql.FirstOrDefault();
        }
        public bool InsertContract(Dto.ContractDto contractDto, out string msg)
        {
            msg = "";
            try
            {
                Linq.Contract contract = new Linq.Contract();
                contract.Nobr = contractDto.NOBR;
                contract.ContractType = contractDto.ContractType;
                contract.Adate = contractDto.Adate;
                contract.Ddate = contractDto.Ddate;
                contract.WorkAdr = contractDto.WorkAdr;
                contract.NotifyMessageGuid = "";
                contract.AlertDay = 0;
                contract.KeyDate = contractDto.KEY_DATE;
                contract.KeyMan = contractDto.KEY_MAN;
                db.Contract.InsertOnSubmit(contract);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool UpdateContract(Dto.ContractDto contractDto, out string msg)
        {
            msg = "";
            try
            {
                var contract = GetOverlapContract(contractDto);
                if (contract != null)
                {
                    contract.ContractType = contractDto.ContractType;
                    contract.WorkAdr = contractDto.WorkAdr;
                    contract.NotifyMessageGuid = "";
                    contract.AlertDay = 0;
                    contract.KeyDate = contractDto.KEY_DATE;
                    contract.KeyMan = contractDto.KEY_MAN;
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
        public bool DeleteContract(Dto.ContractDto contractDto, out string msg)
        {
            msg = "";
            try
            {
                var contract = GetOverlapContract(contractDto);
                if (contract != null)
                {
                    db.Contract.DeleteOnSubmit(contract);
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
