using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using JBHRModel;
using System.Data.Linq;


namespace BL
{
    /// <summary>
    /// DEPTA 的摘要描述
    /// </summary>
    public class Car_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public Car_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public Car_REPO()
        {
            dc = new JBHRModelDataContext();
        }
        public void Add(Car o)
        {
            dc.Car.InsertOnSubmit(o);
        }

        public void Update(Car o)
        {
            DcHelper.Detach(o);
            dc.Car.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<Car> GetAll()
        {
            List<Car> list = new List<Car>();
            return (from c in dc.Car           
                    select c).ToList();            
        }

        public List<Car> GetByCanRent(bool canRent)
        {
            List<Car> list = new List<Car>();
            return (from c in dc.Car
                    where c.CanRent ==canRent
                    select c).ToList();
        }

        public Car GetByPk(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.Car
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }
    }
    

}