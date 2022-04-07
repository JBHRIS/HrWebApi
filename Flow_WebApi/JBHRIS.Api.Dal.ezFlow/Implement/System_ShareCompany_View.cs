using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Dal.ezFlow.Entity.Share;
using JBHRIS.Api.Tools.Tool;

namespace JBHRIS.Api.Dal.ezFlow.Implement
{
    public class System_ShareCompany_View : ISystem_ShareCompany_View
    {

        private ShareContext _context;



        public System_ShareCompany_View(ShareContext context)
        {
            this._context = context;
        }

        public List<ShareCompanyVdb> GetShareCompanyIdAndName()
        {

            List<ShareCompanyVdb> Data = (from bn in this._context.ShareCompanies
                                          where bn.FieldKey == "AccountCode" || bn.FieldKey == "Name"
                                          select new ShareCompanyVdb
                                          {
                                              GroupCode = bn.GroupCode,
                                              FieldKey = bn.FieldKey,
                                              FieldValue = bn.FieldValue
                                          }).ToList();

            var GroupData = Data.GroupBy(x => x.GroupCode);
            List<ShareCompanyVdb> result = new List<ShareCompanyVdb>();
            foreach (var DataRow in GroupData)
            {
                ShareCompanyVdb shareCompany = new ShareCompanyVdb();
                foreach (var DataDetail in DataRow)
                {
                    if (DataDetail.FieldKey == "AccountCode")
                    {
                        shareCompany.CompanyId = DataDetail.FieldValue;
                    }
                    else
                    {
                        shareCompany.CompanyName = DataDetail.FieldValue;
                    }
                }

                result.Add(shareCompany);
            }


            return result;
            // return result;
        }



    }
}
