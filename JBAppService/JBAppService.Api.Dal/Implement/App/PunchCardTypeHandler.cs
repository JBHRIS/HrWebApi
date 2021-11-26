using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dal.Models.AppDBContext;
using JBAppService.Api.Dto.ItemObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBAppService.Api.Dal.Implement.App
{
    public class PunchCardTypeHandler : IPunchCardTypeHandler
    {

        private AppDBContext _AppDBContext;
        public PunchCardTypeHandler(AppDBContext context)
        {
            this._AppDBContext = context;
        }


        /// <summary>
        /// 根本沒再用
        /// </summary>
        /// <returns></returns>
        public List<ItemObject> GetPunchCardType()
        {
            List<ItemObject> itemObjects = new List<ItemObject>();

            itemObjects = (from list in this._AppDBContext.PunchCardType
                           select new ItemObject
                           {
                               ItemKey = list.CardType,
                               ItemValues = list.CardName,
                               ItemOrder = list.ItemOrder ?? 0
                           }).ToList();

            return itemObjects;
        }

        //https://www.acorns.com/
    }
}

