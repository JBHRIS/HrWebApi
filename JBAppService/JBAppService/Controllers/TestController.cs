using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBAppService.Api.Dal.Models.AppDBContext;
using JBAppService.Api.Dto;
using JBAppService.Api.Dto.FencePoints;
using JBAppService.Api.Dto.ItemObject;
using JBAppService.Api.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JBAppService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {


        private ICertificationService _certificationService;
        private AppDBContext _AppDBContext;


        public TestController(ICertificationService certificationService,


            AppDBContext context

            )
        {
            this._AppDBContext = context;
            this._certificationService = certificationService;
        }



        [HttpGet]
        [Route("GetAppSettingConfiguration")]
        public List<AppSettingConfigurationDto> GetAppSettingConfiguration()
        {
            return this._certificationService.GetAppSettingConfiguration();
        }



        [HttpGet]
        [Route("gettest")]
        public string gettest(string nobr)
        {
            return nobr;
        }





        [AllowAnonymous]
        [HttpGet]
        [Route("GetFencePoints")]
        public List<PointsGroupDto> GetFencePoints()
        {
            return this._certificationService.GetFencePoints();
        }


        /// <summary>
        /// 新增圍籬 暫時用 Circle圍籬
        /// </summary>
        /// <returns></returns>
		[AllowAnonymous]
        [HttpGet]
        [Route("SetFencePoints")]
        public bool SetFencePoints()
        {


            List<FencePoints> RD = new List<FencePoints>();
            try
            {
                RD = (from o in this._AppDBContext.FencePointsOrigin
                      where o.Status == true
                      select new FencePoints
                      {
                          oLatitude = o.Latitude ?? 0,
                          oLongitude = o.Longitude ?? 0,
                          Distance = o.Distance ?? 0,
                          Note = o.Note,
                          KeyMan = o.KeyMan,
                          KeyDate = o.KeyDate ?? DateTime.Now,
                          Status = true,
                          Latitude = 0,
                          Longitude = 0,
                          PointsGroup = o.AutoKey.ToString()
                      }).ToList();
            }
            catch (Exception ex)
            {

                string message = ex.Message;
            }
          


            foreach (  var item  in RD)
            {

                SetListPoints(item);
            }





            return true;
        }




		/// <summary>
        /// Uniswap 
        /// </summary>
        /// <returns></returns>
        private bool SetListPoints(FencePoints origin)
        {

            List<FencePoints> result = new List<FencePoints>();
			//1公尺約0.00000900900901度
			//點的數量
            int point = 4 ;
            Double r = origin.Distance * 0.00000900900901;
			// 校正
            //Double r = origin.Distance * 0.00001100900901;

            for (int i = 0; i < point; i++)
            {
                FencePoints points = new FencePoints();

                points.oLatitude = origin.oLatitude;
                points.oLongitude = origin.oLongitude;
                points.Distance = origin.Distance;
                points.Note = origin.Note;
                points.KeyMan = origin.KeyMan;
                points.KeyDate = origin.KeyDate;
                points.Status = true;
                points.Latitude = decimal.Parse(((double)origin.oLatitude + r * Math.Cos(Math.PI / 4 * (1 + 2 * i))).ToString().Substring(0, 10));
                points.Longitude = decimal.Parse(((double)origin.oLongitude + r * Math.Sin(Math.PI / 4 * (1 + 2 * i))).ToString().Substring(0, 10));
                points.PointsGroup = origin.PointsGroup;

                result.Add(points);
            }

            this._AppDBContext.FencePoints.AddRange(result);
            this._AppDBContext.SaveChanges();

            return true;
        }

    }
}
