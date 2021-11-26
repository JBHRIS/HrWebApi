using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dal.Models.AppDBContext;
using JBAppService.Api.Dto.FencePoints;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBAppService.Api.Tool.FencePointsTool;

namespace JBAppService.Api.Dal.Implement.App
{
    public class FencePointsHandler : IFencePointsHandler
    {
        private AppDBContext _AppDBContext;
        public FencePointsHandler(AppDBContext context)
        {
            this._AppDBContext = context;
        }



        /// <summary>
        /// Circle圍籬
        /// </summary>
        /// <returns></returns>
        public List<PointDto> GetCircleFence()
        {
            List<PointDto> result = new List<PointDto>();
            result = (from list in this._AppDBContext.FencePointsOrigin
                      where list.Status == true
                      select new PointDto
                      {
                          Latitude = list.Latitude ?? 0,
                          Longitude = list.Longitude ?? 0,
                          Distance = list.Distance ?? 0,
                          Address = list.Address,
                          Note = list.Note,
                          Group = list.AutoKey.ToString()
                      }).ToList();

            //choosing a DEX here.
            return result;
        }


        /// <summary>
        /// Polygon 圍籬
        /// </summary>
        /// <returns></returns>
        public List<PointsGroupDto> GetFencePoints()
        {

            List<FencePointsDto> rdlist = new List<FencePointsDto>();
            rdlist = GetFencePointsList();
            List<PointDto> rdresult = new List<PointDto>();
            rdresult = (from list in rdlist
                        select new PointDto
                        {
                            Latitude = list.Latitude,
                            Longitude = list.Longitude,
                            Distance = list.Distance,
                            Address = list.Address,
                            Note = list.Note,
                            Group = list.PointsGroup
                        }).ToList();


            List<PointsGroupDto> result = new List<PointsGroupDto>();

            var resultGroup = rdresult.GroupBy(m => m.Group);

            foreach (var item in resultGroup)
            {
                PointsGroupDto rd = new PointsGroupDto();
                rd.Groups = item.ToList();
                result.Add(rd);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<FencePointsDto> GetFencePointsList()
        {
            List<FencePointsDto> result = new List<FencePointsDto>();
            result = (from Origin in this._AppDBContext.FencePointsOrigin
                          //join Points in this._AppDBContext.FencePoints on Origin.AutoKey.ToString() equals Points.PointsGroup
                      where Origin.Status == true
                      //&& Points.Status == true
                      select new FencePointsDto
                      {
                          AutoKey = Origin.AutoKey,
                          Latitude = Origin.Latitude ?? 0m,
                          Longitude = Origin.Longitude ?? 0m,
                          Distance = Origin.Distance ?? 0d,
                          Address = Origin.Address,
                          Note = Origin.Note,
                          Status = Origin.Status ?? false,
                          KeyMan = Origin.KeyMan,
                          KeyDate = Origin.KeyDate,
                          PointsGroup = ""
                      }
                      ).ToList();

            return result;
            //https://polkaswap.io/#/swap
        }








        /// <summary>
        /// 判斷是否在圍籬內
        /// </summary>
        /// <param name="latitudeCur"></param>
        /// <param name="longitudeCur"></param>
        /// <returns></returns>
        public bool isInPolygon(double latitudeCur, double longitudeCur)
        {
            bool result = false;

            List<PointDto> rdlist = GetCircleFence();

            FencePointsTool fencePointsTool = new FencePointsTool();



            result = fencePointsTool.IsPointInCircle(rdlist, latitudeCur, longitudeCur);

            return result;
        }



        /// <summary>
        /// 浪費時間在這沒有用
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        private List<FencePoints> SetListPoints(FencePoints origin)
        {

            List<FencePoints> result = new List<FencePoints>();
            //1公尺約0.00000900900901度
            //點的數量
            Double r = origin.Distance * 0.00000900900901;

            for (int i = 0; i < 4; i++)
            {
                FencePoints points = new FencePoints();

                points.oLatitude = origin.Latitude;
                points.oLongitude = origin.Longitude;
                points.Distance = origin.Distance;
                points.Note = origin.Note;
                points.KeyMan = origin.KeyMan;
                points.KeyDate = origin.KeyDate;
                points.Status = true;
                points.Latitude = decimal.Parse(((double)origin.Latitude + r * Math.Cos(Math.PI / 4 * (1 + 2 * i))).ToString().Substring(0, 10));
                points.Longitude = decimal.Parse(((double)origin.Longitude + r * Math.Sin(Math.PI / 4 * (1 + 2 * i))).ToString().Substring(0, 10));
                points.PointsGroup = origin.AutoKey.ToString();

                result.Add(points);
            }

            return result;



        }



    }
}
