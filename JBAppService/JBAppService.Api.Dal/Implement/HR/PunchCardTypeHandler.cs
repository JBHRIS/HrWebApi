using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dal.Models.HRContent;
using JBAppService.Api.Dto.ItemObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBAppService.Api.Dal.Implement.HR
{
    public class PunchCardTypeHandler : IPunchCardTypeHandler
    {

        private JBHRContext _context;

        public PunchCardTypeHandler(JBHRContext context)
        {
            this._context = context;
        }



        public List<ItemObject> GetPunchCardType()
        {
            List<ItemObject> itemObjects = new List<ItemObject>();
            itemObjects =  (from list in _context.PunchCardType
                           select new ItemObject 
                           {
                                ItemKey = list.CardType,
                                ItemValues = list.CardName,
                                ItemOrder = list.ItemOrder ?? 0
                            }).ToList();
            return itemObjects;
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
    }
}
