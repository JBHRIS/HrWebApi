using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Repo
{
    public interface IEnrichRepo
    {
        bool Insert(Dto.EnrichDto entity, out string msg);
        bool Update(Dto.EnrichDto entity, out string msg);
        bool Delete(Dto.EnrichDto entity, out string msg);
        List<Dto.EnrichDto> GetEnrichDtoByEmployeeListYymmSeq(List<string> EmployeeIdList, string YYMM, string SEQ,List<string> SalcodeList);        
    }
}
