using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Portal
{
    public partial class AppCoordinate : WebPageBase
    {

        public dcAppDataContext dcApp = new dcAppDataContext();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (CompanySetting != null)
            {
                dcApp.Connection.ConnectionString = CompanySetting.ConnApp;
            }

            if (!this.IsPostBack)
            {
                this.txt_meter.Text = "200";
            }
        }


        protected void Table_Origin_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {

            List<FencePointsOrigin> rdlist = (from s in dcApp.FencePointsOrigin
                                              where s.Status == true
                                              select s).ToList();
            lvMain.DataSource = rdlist;
            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }


        protected void lvMain_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            string cn = e.CommandName;
            int AutoKey = int.Parse(e.CommandArgument.ToString());

            FencePointsOrigin rd = (from o in dcApp.FencePointsOrigin
                                    where o.AutoKey == AutoKey && o.Status ==true
                                    select o).FirstOrDefault();

            if (rd != null)
            {
                rd.Status = false;
                dcApp.SubmitChanges();
            }
                
            lvMain.Rebind();
        }


        protected void btn_Save_Coordinate_Click(object sender, EventArgs e)
        {

            ///1公尺約0.00000900900901度
            double latitude_x = double.Parse(this.txt_latitude.Text);
            double longitude_y = double.Parse(this.txt_longitude.Text);
            int meter = int.Parse(this.txt_meter.Text);
             

            bool result = (from o in dcApp.FencePointsOrigin
                                    where  o.Status == true 
                                    && o.Latitude == decimal.Parse(latitude_x.ToString()) 
                                    && o.Longitude == decimal.Parse(longitude_y.ToString())
                                    select o).Any();


            if (result)
            {
                this.lblMsg.Text = "座標重複設定!";
            }
            else
            {
                FencePointsOrigin origin = new FencePointsOrigin();






                origin.Latitude = decimal.Parse(latitude_x.ToString());
                origin.Longitude = decimal.Parse(longitude_y.ToString());
                origin.Distance = meter;
                origin.Note = this.txt_Note.Text;
                origin.Status = true;
                origin.KeyMan = _User.EmpId;
                origin.KeyDate = DateTime.Now;


                dcApp.FencePointsOrigin.InsertOnSubmit(origin);
                dcApp.SubmitChanges();




                Double r = meter * 0.00000900900901;
                //Double r = meter * 0.00001;

                //List<FencePoints> ListPoints = new List<FencePoints>();


                //for (int i = 0; i < 10; i++)
                //{
                //    FencePoints points = new FencePoints();

                //    points.oLatitude = origin.Latitude;
                //    points.oLongitude = origin.Longitude;
                //    points.Distance = origin.Distance;
                //    points.Note = origin.Note;
                //    points.KeyMan = origin.KeyMan;
                //    points.KeyDate = origin.KeyDate;
                //    points.Status = true;
                //    points.Latitude = decimal.Parse((latitude_x + r * Math.Cos(Math.PI / 10 * (1 + 2 * i))).ToString().Substring(0, 10));
                //    points.Longitude = decimal.Parse((longitude_y + r * Math.Sin(Math.PI / 10 * (1 + 2 * i))).ToString().Substring(0, 10));
                //    points.PointsGroup = origin.AutoKey.ToString();

                //    ListPoints.Add(points);
                //}

                //dcApp.FencePoints.InsertAllOnSubmit(ListPoints);
                //dcApp.SubmitChanges();



                lvMain.Rebind();
            }
        }


    }
}