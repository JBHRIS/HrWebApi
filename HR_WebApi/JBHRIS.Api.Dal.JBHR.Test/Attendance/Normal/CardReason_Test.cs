using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Test.Attendance.Normal
{
    [TestClass]
    public class CardReason_Test
    {
        private JBHRContext _context
        {
            get
            {
                DbContextOptions<JBHRContext> options = new DbContextOptionsBuilder<JBHRContext>()
                    .UseInMemoryDatabase("HR")
                    .Options;
                JBHRContext context = new JBHRContext(options);
                if (!context.Cardlosd.Any())
                {
                    context.Cardlosd.AddRange(createCardlosdData());
                }
                context.SaveChanges();
                return context;
            }
        }
        #region TestData
        private IEnumerable<Cardlosd> createCardlosdData()
        {
            yield return new Cardlosd
            {
                Code = "1",
                Descr = "未帶卡片",
                Att = true,
                Sort = 1,
                KeyMan = "User1",
                KeyDate = new DateTime(2010, 1, 12)
            };
            yield return new Cardlosd
            {
                Code = "2",
                Descr = "卡片毀損",
                Att = true,
                Sort = 2,
                KeyMan = "User1",
                KeyDate = new DateTime(2010, 1, 22)
            };
            yield return new Cardlosd
            {
                Code = "3",
                Descr = "卡片遺失",
                Att = true,
                Sort = 3,
                KeyMan = "User1",
                KeyDate = new DateTime(2010, 2, 12)
            };
            yield return new Cardlosd
            {
                Code = "4",
                Descr = "忘記刷卡",
                Att = false,
                Sort = 4,
                KeyMan = "User1",
                KeyDate = new DateTime(2022, 1, 12)
            };
        }
        #endregion
        [TestMethod]
        public void GetCardReason()
        {
            JBHRContext context = _context;// new JBHRContext(_options);// _context;
            Range range = ..4;
            IEnumerable<Cardlosd> source = createCardlosdData().ToArray()[range];
            IUnitOfWork unitOfWork = new JbhrUnitOfWork(context);
            ICardReasonRepository dal = new CardReasonRepository(unitOfWork);
            #region GetAll
            {
                IEnumerable<CardReasonDto> expectEmpIds = source.Select
                    (p => new CardReasonDto { Code = p.Code, Description = p.Descr, EffectsAttend = p.Att, Sort = p.Sort, KeyMan = p.KeyMan, KeyDate = p.KeyDate });
                List<CardReasonDto> result = dal.GetCardReason();
                Assert.IsTrue(result.Count == 4, "預期數量不符合");
                Assert.IsTrue(result.Where(c => !expectEmpIds.Contains(c)).Count() > 0, "忘刷原因清單不相符");
                Assert.IsTrue(expectEmpIds.Where(c => !result.Contains(c)).Count() > 0, "忘刷原因清單不相符");
            }
            #endregion
        }
    }
}
