using JBAppService.Api.Dto.FencePoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBAppService.Api.Tool.FencePointsTool
{
    public class FencePointsTool
    {

        private const double EARTH_RADIUS = 6378.137;
        private static double rad(double d)
        {
            return d * Math.PI / 180.0;
        }
        public double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double radLat1 = rad(lat1);
            double radLat2 = rad(lat2);
            double a = radLat1 - radLat2;
            double b = rad(lng1) - rad(lng2);
            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
             Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * EARTH_RADIUS;
            s = Math.Round(s * 100000) / 100d;
            return s;
        }

        public double CalculateDistance(double lat1, double lng1, double lat2, double lng2)
        {
            var d1 = lat1 * (Math.PI / 180.0);
            var num1 = lng1 * (Math.PI / 180.0);
            var d2 = lat2 * (Math.PI / 180.0);
            var num2 = lng2 * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rdlist"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public static bool isInPolygon(List<PointDto> rdlist, double latitude, double longitude)
        {
            //點小於3無法構成多邊形
            if (rdlist.Count < 3)
            {
                return false;
            }

            //(y - y0) (x1 - x0) - (x - x0) (y1 - y0)
            var coef = rdlist.Skip(1).Select((p, i) =>
                                            (longitude - (double)rdlist[i].Longitude) * ((double)p.Latitude - (double)rdlist[i].Latitude)
                                          - (latitude - (double)rdlist[i].Latitude) * ((double)p.Longitude - (double)rdlist[i].Longitude))
                                    .ToList();

            //if it is less than 0 then P is to the right of the line segment, if greater than 0 it is to the left, if equal to 0 then it lies on the line segment.
            if (coef.Any(p => p == 0))
            {
                return true;
            }

            for (int i = 1; i < coef.Count(); i++)
            {
                if (coef[i] * coef[i - 1] < 0)
                    return false;
            }
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public bool IsPointInPolygon(List<coordinate> polygon, double latitude, double longitude)
        {
            bool isInside = false;
            for (int i = 0, j = polygon.Count - 1; i < polygon.Count; j = i++)
            {
                if ((((double)polygon[i].Longitude > longitude) != ((double)polygon[j].Longitude > longitude)) &&
                (latitude < (double)(polygon[j].Latitude - polygon[i].Latitude) * (longitude - (double)polygon[i].Longitude) / (double)(polygon[j].Longitude - polygon[i].Longitude) + (double)polygon[i].Latitude))
                {
                    isInside = !isInside;
                }
            }
            return isInside;
        }

        public bool IsPointInCircle(List<PointDto> PointList, double latitude, double longitude)
        {
            bool isInside = false;

            foreach (var Point in PointList)
            {
                if (Point.Distance >= CalculateDistance((double)Point.Latitude, (double)Point.Longitude, latitude, longitude))
                {
                    isInside = true;
                    break;
                }
            }

            return isInside;
        }
    }
}
