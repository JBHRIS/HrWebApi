using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dto.ItemObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBAppService.Api.Dal.Models.EEPContent;

namespace JBAppService.Api.Dal.Implement.EEP
{
    public class PunchCardTypeHandler : IPunchCardTypeHandler
    {

        private JBEEPContext _context;

        public PunchCardTypeHandler(JBEEPContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ItemObject> GetPunchCardType()
        {
            List<ItemObject> itemObjects = new List<ItemObject>();
            itemObjects = (from list in _context.PunchCardType
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
