using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using JBHRIS.Api.Dal.Employee.Normal;
using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dal.JBHR.Employee;
using JBHRIS.Api.Dto.Employee.View;
using Microsoft.EntityFrameworkCore;

namespace JBHRIS.Api.Tools.Test
{   

    [TestClass]
    public class DalTest
    {
        private JBHRContext _context
        {
            get
            {
                DbContextOptions<JBHRContext> options = new DbContextOptionsBuilder<JBHRContext>()
                    .UseInMemoryDatabase("HR")
                    .Options;
                JBHRContext context = new JBHRContext(options);
                if (!context.Base.Any())
                {
                    context.Base.AddRange(createBirthdayBase());
                }
                context.SaveChanges();
                return context;
            }
        }
        
        private IEnumerable<Base> createBirthdayBase()
        {
            yield return new Base
            {
                Nobr = "1"
                ,
                Birdt = null
                ,
                NameC = "test1"
            };
            yield return new Base
            {
                Nobr = "2",
                Birdt = new DateTime(1980, 5, 13),
                NameC = "test2"
            };
            yield return new Base
            {
                Nobr = "3",
                Birdt = new DateTime(1949, 2, 28),
                NameC = "test3"
            };
            yield return new Base
            {
                Nobr = "4",
                Birdt = new DateTime(1977, 5, 13),
                NameC = "test4"
            };
        }

        [TestMethod]
        public void GetPeopleByBirthdayTest()
        {
            JBHRContext context = _context;// new JBHRContext(_options);// _context;
            Range range = ..4;
            IEnumerable<Base> source = createBirthdayBase().ToArray()[range];
            IEmployee_Normal_GetPeopleByBirthday dal = new Employee_Normal_GetPeopleByBirthday(context);

            #region All
            {
                List<string> targetBases = source.Select(o=>o.Nobr).ToList();
                IEnumerable<int> targetMons = Enumerable.Range(1, 12).ToArray();
                IEnumerable<string> expectEmpIds = source.Where(b => b.Birdt.HasValue).Select(b => b.Nobr).ToArray();
                List<string> result =  dal.GetPeopleByBirthday(targetBases, (int[])targetMons);
                Assert.IsTrue(result.Count == 3,"箇戳计秖ぃ才");
                Assert.IsTrue(result.OrderBy(s => s).SequenceEqual(expectEmpIds.OrderBy(s => s)), "睲虫ぃ才");
            }
            #endregion

            #region Empty Set
            {
                List<string> targetBases = source.Select(o => o.Nobr).ToList();
                IEnumerable<int> targetMons = new[]{1};
                IEnumerable<string> expectEmpIds = source.Where(b => b.Birdt.HasValue && targetMons.Contains(b.Birdt.Value.Month)).Select(b => b.Nobr).ToArray();
                List<string> result = dal.GetPeopleByBirthday(targetBases, (int[])targetMons);
                Assert.IsTrue(result.Count == 0, "箇戳计秖ぃ才");
                Assert.IsTrue(result.OrderBy(s => s).SequenceEqual(expectEmpIds.OrderBy(s => s)), "睲虫ぃ才");
            }
            #endregion

            #region きるㄢ
            {
                List<string> targetBases = source.Select(o => o.Nobr).ToList();
                IEnumerable<int> targetMons = new []{5};
                IEnumerable<string> expectEmpIds = source.Where(b => b.Birdt.HasValue && b.Birdt.Value.Month == 5).Select(b => b.Nobr).ToArray();
                List<string> result = dal.GetPeopleByBirthday(targetBases, (int[])targetMons);
                Assert.IsTrue(result.Count == 2, "箇戳计秖ぃ才");
                Assert.IsTrue(result.OrderBy(s => s).SequenceEqual(expectEmpIds.OrderBy(s => s)), "睲虫ぃ才");
            }
            #endregion
        }

        ///// <summary>
        ///// 代刚眔ネら跋丁
        ///// </summary>
        //[TestMethod]
        //public void GetPeopleInfoBetweenBirthdayTest()
        //{
        //    JBHRContext context = _context;// new JBHRContext(_options);// _context;//new JBHRContext(_options);
        //    Range range = ..3;
        //    IEnumerable<Base> source = createBirthdayBase().ToArray()[range];
        //    IEmployee_Normal_GetPeopleByBirthday dal = new Employee_Normal_GetPeopleByBirthday(context);

        //    #region 眔跋丁ネら(people 1)
        //    {
        //        Func<Base, bool> targetPredict = b => b.Nobr == "2" && b.Birdt.HasValue && b.Birdt.Value.Month == 5;
        //        Base target = source.First(targetPredict);

        //        IEnumerable<EmployeeBirthdayViewDto> result = 
        //            dal.GetPeopleInfoBetweenBirthday(
        //            new[] {target.Nobr}
        //            , new DateTime(1979,3,14)
        //            , to:new DateTime(1980,5,31)).ToArray();
        //        Assert.IsTrue(result.Count()==1,"箇戳计秖ぃ才");
        //        Assert.IsTrue(result.First().EmployeeId == target.Nobr);
        //        Assert.IsTrue(result.First().BirthDay == target.Birdt);
        //        Assert.IsTrue(result.First().EmployeeName == target.NameC);
        //    }
        //    #endregion

        //    #region 场
        //    {
        //        //Func<Base, bool> targetPredict = b => true;
        //        IEnumerable<Base> target = source;

        //        IEnumerable<EmployeeBirthdayViewDto> result =
        //            dal.GetPeopleInfoBetweenBirthday(
        //                target.Select(o=>o.Nobr).ToArray()
        //                , new DateTime(1900,1,1)
        //                , new DateTime(2000,1,1));
        //        Assert.IsTrue(result.Count() == 2);
        //    }
        //    #endregion
        //}
        
    }
}
