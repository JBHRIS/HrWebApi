using JBHRIS.Api.Dal.Employee;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Employee.Entry;
using JBHRIS.Api.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Employee
{
    public class Employee_Normal_GetPeopleByDepta : IEmployee_Normal_GetPeopleByDepta
    {
        private IUnitOfWork _unitOfWork;

        public Employee_Normal_GetPeopleByDepta(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<string> GetPeopleByDepta(List<string> employeeList, List<string> DeptaList, DateTime CheckDate)
        {
            List<string> results = new List<string>();
            foreach (var empList in employeeList.Split(1000))
            {
                results.AddRange(_GetPeopleByDepta(employeeList, DeptaList, CheckDate));
            }
            return results;
        }

        public List<string> GetPeopleByDeptaTree(string depta)
        {
            List<string> DeptaUnderList = new List<string>();
            List<string> PeopleByDeptUnderList = new List<string>();

            List<Depta> UnfoldTreeData = UnfoldTree(new List<Depta>(), depta);
            var data = _unitOfWork.Repository<Depta>().Reads().Where(p => p.DNo == depta).ToList();
            UnfoldTreeData.AddRange(data);
            List<Depta> sysMenus = new List<Depta>();
            UnfoldTreeData.ForEach(m =>
            {
                sysMenus.Add(new Depta()
                {
                    DNo = m.DNo,
                    DeptGroup = m.DeptGroup,
                    DName = m.DName,
                    Nobr = m.Nobr
                });
            });
            UnfoldTreeData.ForEach(m => { m.DeptTree = repeatSite(sysMenus, m, ""); DeptaUnderList.Add(m.DNo); });
            var CheckDate = DateTime.Now;
            PeopleByDeptUnderList = _unitOfWork.Repository<Basetts>().Reads().Where(p => DeptaUnderList.Contains(p.Deptm) && CheckDate >= p.Adate && CheckDate <= p.Ddate.Value && new string[] { "1", "4", "6" }.Contains(p.Ttscode)).Select(p => p.Nobr).Distinct().ToList();
            return PeopleByDeptUnderList;
        }

        List<string> _GetPeopleByDepta(List<string> employeeList, List<string> DeptList, DateTime CheckDate)
        {
            return _unitOfWork.Repository<Basetts>().Reads().Where(p => employeeList.Contains(p.Nobr) && DeptList.Contains(p.Deptm) && CheckDate >= p.Adate && CheckDate <= p.Ddate.Value).Select(p => p.Nobr).Distinct().ToList();
        }

        private List<Depta> UnfoldTree(List<Depta> files, string Code)
        {
            var data = _unitOfWork.Repository<Depta>().Reads().Where(p => p.DeptGroup == Code).ToList();
            data.ForEach(s => {
                files.Add(s);
                UnfoldTree(files, s.DNo);
            });
            return files;
        }

        private static string repeatSite(List<Depta> listMenus, Depta r, string outPut)
        {
            IEnumerable<Depta> parentSql;
            parentSql = from listm in listMenus
                        where listm.DNo == r.DeptGroup
                        select listm;
            List<Depta> parents = parentSql.ToList();
            if (string.IsNullOrEmpty(outPut))
            {
                outPut = r.DNo;
            }
            if (parents.Count > 0)
            {
                Depta p = parents[0];
                outPut = r.DeptGroup + "/" + outPut;
                return repeatSite(listMenus, p, outPut);
            }
            else
            {
                return outPut;
            }
        }
    }
}
