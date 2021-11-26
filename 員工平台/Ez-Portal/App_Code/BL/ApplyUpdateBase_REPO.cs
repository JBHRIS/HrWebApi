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
    public class ApplyUpdateBase_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public ApplyUpdateBase_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public ApplyUpdateBase_REPO()
        {
            dc = new JBHRModelDataContext();
        }
        public void Add(ApplyUpdateBase o)
        {
            dc.ApplyUpdateBase.InsertOnSubmit(o);
        }

        public void Delete(ApplyUpdateBase o)
        {
            var obj = (from c in dc.ApplyUpdateBase
                       where c.Pk == o.Pk
                       select c).FirstOrDefault();
            dc.ApplyUpdateBase.DeleteOnSubmit(obj);
        }

        public void Update(ApplyUpdateBase o)
        {
            DcHelper.Detach(o);
            dc.ApplyUpdateBase.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public bool CheckHaveChanged(ApplyUpdateBase obj)
        {
            bool isChange = false;

            if (!obj.ADDR1.Equals(obj.ADDR1_Old))
            { 
                isChange = true;
                obj.ADDR1_IsChanged = true;
            }
            if (!obj.ADDR2.Equals(obj.ADDR2_Old))
            { 
                isChange = true;
                obj.ADDR2_IsChanged = true;
            }
            if (!obj.BORN_ADDR.Equals(obj.BORN_ADDR_Old))
            { 
                isChange = true;
                obj.BORN_ADDR_IsChanged = true;
            }
            if (!obj.CONT_GSM.Equals(obj.CONT_GSM_Old))
            { 
                isChange = true;
                obj.CONT_GSM_IsChanged = true;
            }
            if (!obj.CONT_GSM2.Equals(obj.CONT_GSM2_Old))
            { 
                isChange = true;
                obj.CONT_GSM2_IsChanged = true;
            }
            if (!obj.CONT_MAN.Equals(obj.CONT_MAN_Old))
            { 
                isChange = true;
                obj.CONT_MAN_IsChanged = true;
            }
            if (!obj.CONT_MAN2.Equals(obj.CONT_MAN2_Old))
            { 
                isChange = true;
                obj.CONT_MAN2_IsChanged = true;
            }
            if (!obj.CONT_REL1.Equals(obj.CONT_REL1_Old))
            { 
                isChange = true;
                obj.CONT_REL1_IsChanged = true;
            }
            if (!obj.CONT_REL2.Equals(obj.CONT_REL2_Old))
            { 
                isChange = true;
                obj.CONT_REL2_IsChanged = true;
            }
            if (!obj.CONT_TEL.Equals(obj.CONT_TEL_Old))
            { 
                isChange = true;
                obj.CONT_TEL_IsChanged = true;
            }
            if (!obj.CONT_TEL2.Equals(obj.CONT_TEL2_Old))
            { 
                isChange = true;
                obj.CONT_TEL2_IsChanged = true;
            }
            if (!obj.EMAIL.Equals(obj.EMAIL_Old))
            { 
                isChange = true;
                obj.EMAIL_IsChanged = true;
            }
            if (!obj.GSM.Equals(obj.GSM_Old))
            { 
                isChange = true;
                obj.GSM_IsChanged = true;
            }
            if (!obj.POSTCODE1.Equals(obj.POSTCODE1_Old)) 
            { 
                isChange = true;
                obj.POSTCODE1_IsChanged = true;
            }
            if (!obj.POSTCODE2.Equals(obj.POSTCODE2_Old)) 
            { 
                isChange = true;
                obj.POSTCODE2_IsChanged = true;
            }
            if (!obj.PROVINCE.Equals(obj.PROVINCE_Old))
            { 
                isChange = true;
                obj.PROVINCE_IsChanged = true;
            }
            if (!obj.TEL1.Equals(obj.TEL1_Old))
            { 
                isChange = true;
                obj.TEL1_IsChanged = true;
            }
            if (!obj.TEL2.Equals(obj.TEL2_Old))
            { 
                isChange = true;
                obj.TEL2_IsChanged = true;
            }
            if (!obj.SUBTEL.Equals(obj.SUBTEL_Old))
            {
                isChange = true;
                obj.SUBTEL_IsChanged = true;
            }

            return isChange;
        }

        public List<ApplyUpdateBase> GetAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.ApplyUpdateBase
                        select c).ToList();
            }
        }

        public ApplyUpdateBase GetByPk(int Avalue)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.ApplyUpdateBase
                        where c.Pk ==Avalue
                        select c).FirstOrDefault();
            }
        }

        public List<ApplyUpdateBase> GetByDateRange_Dlo(DateTime AdtB, DateTime AdtE)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                ldc.Log = new DebuggerWriter();
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<ApplyUpdateBase>(l => l.RELCODE); //cont_rel1
                dlo.LoadWith<ApplyUpdateBase>(l => l.RELCODE1); //cont_rel2
                dlo.LoadWith<ApplyUpdateBase>(l => l.RELCODE2);//cont_rel1_old
                dlo.LoadWith<ApplyUpdateBase>(l => l.RELCODE3); //contrel2_old
                dlo.LoadWith<ApplyUpdateBase>(l => l.BASE);
                ldc.LoadOptions = dlo;
                return (from c in ldc.ApplyUpdateBase
                        where c.ApplyDatetime >= AdtB && c.ApplyDatetime <=AdtE
                        select c).ToList();
            }
        }

        public void UpdateBase(ApplyUpdateBase obj)
        {
            BASE_REPO baseRepo = new BASE_REPO(dc);
            BASE baseObj= baseRepo.GetByNobr(obj.ApplyMan);
            if (obj.ADDR1_IsChanged)
            {
                baseObj.ADDR1 = obj.ADDR1;
            }
            if(obj.ADDR2_IsChanged)
            {
                baseObj.ADDR2 = obj.ADDR2;
            }
            if (obj.BORN_ADDR_IsChanged)
            {
                baseObj.BORN_ADDR = obj.BORN_ADDR;
            }
            if (obj.CONT_GSM_IsChanged)
            {
                baseObj.CONT_GSM = obj.CONT_GSM;
            }
            if (obj.CONT_GSM2_IsChanged)
            {
                baseObj.CONT_GSM2 = obj.CONT_GSM2;
            }
            if (obj.CONT_MAN_IsChanged)
            {
                baseObj.CONT_MAN = obj.CONT_MAN;
            }
            if (obj.CONT_MAN2_IsChanged)
            {
                baseObj.CONT_MAN2 = obj.CONT_MAN2;
            }
            if (obj.CONT_REL1_IsChanged)
            {
                baseObj.CONT_REL1 = obj.CONT_REL1;
            }
            if (obj.CONT_REL2_IsChanged)
            {
                baseObj.CONT_REL2 = obj.CONT_REL2;
            }
            if (obj.CONT_TEL_IsChanged) 
            {
                baseObj.CONT_TEL = obj.CONT_TEL;
            }
            if (obj.CONT_TEL2_IsChanged)
            {
                baseObj.CONT_TEL2 = obj.CONT_TEL2;
            }
            if (obj.EMAIL_IsChanged)
            {
                baseObj.EMAIL = obj.EMAIL;
            }
            if (obj.GSM_IsChanged)
            {
                baseObj.GSM = obj.GSM;
            }
            if (obj.POSTCODE1_IsChanged)
            {
                baseObj.POSTCODE1 = obj.POSTCODE1;
            }
            if (obj.POSTCODE2_IsChanged)
            {
                baseObj.POSTCODE2 = obj.POSTCODE2;
            }
            if (obj.PROVINCE_IsChanged)
            {
                baseObj.PROVINCE = obj.PROVINCE;
            }
            if (obj.TEL1_IsChanged)
            {
                baseObj.TEL1 = obj.TEL1;
            }
            if (obj.TEL2_IsChanged)
            {
                baseObj.TEL2 = obj.TEL2;
            }
            if (obj.SUBTEL_IsChanged)
            {
                baseObj.SUBTEL = obj.SUBTEL;
            }

            baseRepo.dc = dc;
            baseRepo.Update(baseObj);
        }
    }
    

}