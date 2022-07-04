using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using JBHRIS.Api.Dto.Attendance;

namespace JBHRIS.Api.Tools.Test
{
    [TestClass]
    public class ObjectFunction_Test
    {
        [TestMethod]
        public void ObjectStringNullToEmpty()
        {
            List<TmtableImportDto> tmtableImportDtos = new List<TmtableImportDto>();
            tmtableImportDtos.Add(new TmtableImportDto()
            {
                Yymm = null,
                Nobr = null,
                D1 = null,
                D2 = null,
                D3 = null,
                D4 = null,
                D5 = null,
                D6 = null,
                D7 = null,
                D8 = null,
                D9 = null,
                D10 = null,
                D11 = null,
                D12 = null,
                D13 = null,
                D14 = null,
                D15 = null,
                D16 = null,
                D17 = null,
                D18 = null,
                D19 = null,
                D20 = null,
                D21 = null,
                D22 = null,
                D23 = null,
                D24 = null,
                D25 = null,
                D26 = null,
                D27 = null,
                D28 = null,
                D29 = null,
                D30 = null,
                D31 = null,
                KeyMan = null,
                KeyDate = DateTime.Now,
                No = 0,
                Holis = 0,
                FreqNo = 0
            });

            var IncludeProperties = new List<string>();
            for (int i = 1; i <= 31; i++)
            {
                IncludeProperties.Add("D" + i);
            }
            var DataInclude = tmtableImportDtos.ObjectStringNullToEmptyInclude(IncludeProperties);
            Assert.AreEqual("", DataInclude[0].D1, "錯誤測試");

            var NotIncludeProperties = new List<string>() { "Yymm", "KeyMan" };
            var DataNotInclude = tmtableImportDtos.ObjectStringNullToEmptyNotInclude(NotIncludeProperties);
            Assert.AreEqual(null, DataNotInclude[0].Yymm, "錯誤測試");
        }
    }
}
