using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dal.Models.HRContent;
using JBAppService.Api.Dto.FencePoints;
using JBAppService.Api.Tool.FencePointsTool;    
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBAppService.Api.Dal.Implement.HR
{
    public class FencePointsHandler : IFencePointsHandler
    {

        private JBHRContext _context;

        public FencePointsHandler(JBHRContext context)
        {
            this._context = context;
        }

        public List<PointDto> GetCircleFence()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
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
            result = (from Points in _context.FencePoints
                      where Points.Status == true
                      select new FencePointsDto
                      {
                          AutoKey = Points.AutoKey,
                          Latitude = Points.Latitude,
                          Longitude = Points.Longitude,
                          Distance = Points.Distance　??　0 ,
                          Address = Points.Address,
                          Note = Points.Note,
                          Status = Points.Status　?? false ,
                          KeyMan = Points.KeyMan,
                          KeyDate = Points.KeyDate,
                          PointsGroup = Points.PointsGroup
                      }
                      ).ToList();

            return result;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="latitudeCur"></param>
        /// <param name="longitudeCur"></param>
        /// <returns></returns>
        public bool isInPolygon(double latitudeCur, double longitudeCur)
        {

            List<bool> results = new List<bool>();
            List<FencePointsDto> rdlist = new List<FencePointsDto>();

            rdlist = GetFencePointsList();
            var rdlistGroup = rdlist.GroupBy(m => m.PointsGroup);



            FencePointsTool fencePointsTool = new FencePointsTool();
            foreach (var Group in rdlistGroup)
            {
                bool result = false;

                List<coordinate> rdListCoordinate = new List<coordinate>();
                foreach (var item in Group)
                {
                    coordinate coordinate = new coordinate();
                    coordinate.Latitude = (double)item.Latitude;
                    coordinate.Longitude = (double)item.Longitude;
                    rdListCoordinate.Add(coordinate);
                }
                result = fencePointsTool.IsPointInPolygon(rdListCoordinate, latitudeCur, longitudeCur);
                results.Add(result);
            }
            return results.Contains(true);


        }
    }
}
