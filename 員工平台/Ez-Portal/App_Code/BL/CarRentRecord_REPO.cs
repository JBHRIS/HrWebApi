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
    /// CarRentRecord 的摘要描述
    /// </summary>
    public class CarRentRecord_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public CarRentRecord_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public CarRentRecord_REPO()
        {
            dc = new JBHRModelDataContext();
        }


        public void Add(CarRentRecord o)
        {
            dc.CarRentRecord.InsertOnSubmit(o);
        }

        public void Update(CarRentRecord o)
        {
            DcHelper.Detach(o);
            dc.CarRentRecord.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        //public List<CarRentRecord> GetAll()
        //{
        //    List<CarRentRecord> list = new List<CarRentRecord>();
        //    return (from c in dc.CarRentRecord           
        //            select c).ToList();            
        //}

        public CarRentRecord GetByPk(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.CarRentRecord
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

        public List<CarRentRecord> GetByDate(DateTime d)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.CarRentRecord
                        where c.StartDateTime >= d && c.StartDateTime< d.AddDays(1)                        
                        select c).ToList();
            }
        }

        public List<CarRentRecord> GetByDate(DateTime d,int carId,bool isCancel)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.CarRentRecord
                        where c.StartDateTime >= d && c.StartDateTime < d.AddDays(1)
                        && c.CarId == carId && c.Cancel == isCancel
                        select c).ToList();
            }
        }

        public List<CarRentRecord> GetByDate(DateTime bDate,DateTime eDate, int carId, bool isCancel)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.CarRentRecord
                        where c.StartDateTime >= bDate && c.StartDateTime < eDate.AddDays(1)
                        && c.CarId == carId && c.Cancel == isCancel
                        select c).ToList();
            }
        }


        public List<CarRentRecord> GetByDate_Dlo(DateTime bDate , DateTime eDate , int carId , bool isCancel)
        {
            using ( JBHRModelDataContext ldc = new JBHRModelDataContext() )
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<CarRentRecord>(l => l.BASE);
                dlo.LoadWith<CarRentRecord>(l => l.Car);
                ldc.LoadOptions = dlo;

                return (from c in ldc.CarRentRecord
                        where c.StartDateTime >= bDate && c.StartDateTime < eDate.AddDays(1)
                        && c.CarId == carId && c.Cancel == isCancel
                        select c).ToList();
            }
        }

        public List<CarRentRecord> GetByDate_Dlo(DateTime bDate, DateTime eDate, bool isCancel)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<CarRentRecord>(l => l.BASE);
                dlo.LoadWith<CarRentRecord>(l => l.Car);
                ldc.LoadOptions = dlo;

                return (from c in ldc.CarRentRecord
                        where c.StartDateTime >= bDate && c.StartDateTime < eDate.AddDays(1)
                        && c.Cancel == isCancel
                        select c).ToList();
            }
        }

        public bool IsUsed(DateTime bDate , DateTime eDate , int carId)
        {
            using ( JBHRModelDataContext ldc = new JBHRModelDataContext() )
            {
                var result= (from c in ldc.CarRentRecord
                        where c.StartDateTime < eDate && c.EndDateTime > bDate
                        && c.CarId == carId
                        && c.Cancel == false
                        select c).FirstOrDefault();

                if ( result == null )
                    return false;
                else
                    return true;
            }

        }

        public bool IsUsedExceptSelf(DateTime bDate, DateTime eDate, int carId, int recordId)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                var result = (from c in ldc.CarRentRecord
                              where c.StartDateTime < eDate && c.EndDateTime > bDate
                              && c.CarId == carId
                              && c.Cancel == false
                              && c.Id != recordId
                              select c).FirstOrDefault();

                if (result == null)
                    return false;
                else
                    return true;
            }
        }
    }


}