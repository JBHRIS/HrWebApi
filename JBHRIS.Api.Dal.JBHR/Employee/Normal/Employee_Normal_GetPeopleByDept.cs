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
    public class Employee_Normal_GetPeopleByDept : IEmployee_Normal_GetPeopleByDept
    {
        private IUnitOfWork _unitOfWork;

        public Employee_Normal_GetPeopleByDept(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<string> GetPeopleByDept(List<string> employeeList, List<string> DeptList, DateTime CheckDate)
        {
            List<string> results = new List<string>();
            foreach (var empList in employeeList.Split(1000))
            {
                results.AddRange(_GetPeopleByDept(empList, DeptList, CheckDate));
            }
            return results;
        }
        public List<string> GetAllPeopleByDept(List<string> DeptList, DateTime CheckDate)
        {
            List<string> results = new List<string>();
            foreach (var list in DeptList.Split(1000))
            {
                results.AddRange(_GetAllPeopleByDept(list, CheckDate));
            }
            return results;
        }

        public List<string> GetPeopleByDeptTree(string dept)
        {
            List<string> DeptUnderList = new List<string>();
            List<string> PeopleByDeptUnderList = new List<string>();

            List<Dept> UnfoldTreeData = UnfoldTree(new List<Dept>(), dept);
            var data = _unitOfWork.Repository<Dept>().Reads().Where(p => p.DNo == dept).ToList();
            UnfoldTreeData.AddRange(data);
            List<Dept> sysMenus = new List<Dept>();
            UnfoldTreeData.ForEach(m =>
            {
                sysMenus.Add(new Dept()
                {
                    DNo = m.DNo,
                    DeptGroup = m.DeptGroup,
                    DName = m.DName,
                    Nobr = m.Nobr
                });
            });
            UnfoldTreeData.ForEach(m => { m.DeptTree = repeatSite(sysMenus, m, ""); DeptUnderList.Add(m.DNo); });
            var CheckDate = DateTime.Now;
            PeopleByDeptUnderList = _unitOfWork.Repository<Basetts>().Reads().Where(p => DeptUnderList.Contains(p.Dept) && CheckDate >= p.Adate && CheckDate <= p.Ddate.Value && new string[] { "1", "4", "6" }.Contains(p.Ttscode)).Select(p=>p.Nobr).Distinct().ToList();
            return PeopleByDeptUnderList;
        }

        List<string> _GetPeopleByDept(List<string> employeeList, List<string> DeptList, DateTime CheckDate)
        {
            return _unitOfWork.Repository<Basetts>().Reads().Where(p => employeeList.Contains(p.Nobr) && DeptList.Contains(p.Dept) && CheckDate >= p.Adate && CheckDate <= p.Ddate.Value).Select(p => p.Nobr).Distinct().ToList();
        }
        List<string> _GetAllPeopleByDept(List<string> DeptList, DateTime CheckDate)
        {
            return _unitOfWork.Repository<Basetts>().GetCurrentOnJob(CheckDate, CheckDate).Where(p => DeptList.Contains(p.Dept) && CheckDate >= p.Adate && CheckDate <= p.Ddate.Value).Select(p => p.Nobr).Distinct().ToList();
        }

        private List<Dept> UnfoldTree(List<Dept> files, string Code)
        {
            var data = _unitOfWork.Repository<Dept>().Reads().Where(p => p.DeptGroup == Code).ToList();
            data.ForEach(s => {
                files.Add(s);
                UnfoldTree(files, s.DNo);
            });
            return files;
        }

        private static string repeatSite(List<Dept> listMenus, Dept r, string outPut)
        {
            IEnumerable<Dept> parentSql;
            parentSql = from listm in listMenus
                        where listm.DNo == r.DeptGroup
                        select listm;
            List<Dept> parents = parentSql.ToList();
            if (string.IsNullOrEmpty(outPut))
            {
                outPut = r.DNo;
            }
            if (parents.Count > 0)
            {
                Dept p = parents[0];
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
