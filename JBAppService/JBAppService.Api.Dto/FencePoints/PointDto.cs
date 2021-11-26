using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dto.FencePoints
{
    public class PointDto
    {

        /// <summary>
        /// 緯度
        /// </summary>
        public decimal Latitude { get; set; }
        /// <summary>
        /// 經度
        /// </summary>
        public decimal Longitude { get; set; }
        /// <summary>
        /// 半徑
        /// </summary>
        public double Distance { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 群組
        /// </summary>
        public string Group { get; set; }
    }

    public partial class FencePointsDto
    {
        public int AutoKey { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public double Distance { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public bool Status { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
        public string PointsGroup { get; set; }
    }


    public partial class PunchCardTypeDto
    {
        public int AutoKey { get; set; }
        public string CardType { get; set; }
        public string CardName { get; set; }
        public int? ItemOrder { get; set; }
        public string Note { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
        public string PointsGroup { get; set; }

    }

    public class PointsGroupDto
    {
        public List<PointDto> Groups { get; set; }
    }


    public class coordinate
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }


    public class Location
    {
        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }



    }

}
