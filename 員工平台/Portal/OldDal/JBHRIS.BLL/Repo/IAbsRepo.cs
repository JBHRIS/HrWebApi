using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBHRIS.BLL.Repo
{
    public interface IAbsRepo
    {
        bool Insert(Dto.AbsTakenDto entity, out string msg);
        bool Update(Dto.AbsTakenDto entity, out string msg);
        bool Delete(Dto.AbsTakenDto entity, out string msg);
        List<Dto.AbsTakenDto> GetAbsTakenByEmployeeListDate(List<string> EmployeeIdList, DateTime DateBegin, DateTime DateEnd);
        decimal GetAbsHours(Dto.AbsTakenDto entity);
        List<Dto.AbsTakenDto> GetConflictAbsTaken(Dto.AbsTakenDto entity);
        bool CheckConflict(Dto.AbsTakenDto Abs, out string Msg);
    }
}
