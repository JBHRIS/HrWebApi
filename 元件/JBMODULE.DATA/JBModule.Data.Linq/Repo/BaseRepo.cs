using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class BaseRepo
    {
        Linq.HrDBDataContext db = new Linq.HrDBDataContext();
        public Linq.BASE GetOverlapBASE(Dto.BaseDto baseDto)
        {
            var sql = from a in db.BASE
                      where a.NOBR == baseDto.NOBR
                      select a;
            return sql.FirstOrDefault();
        }
        public bool InsertBASE(Dto.BaseDto baseDto, out string msg)
        {
            msg = "";
            try
            {   
                Linq.BASE bASE = new Linq.BASE();
                bASE.NOBR = baseDto.NOBR;
                bASE.NAME_C = baseDto.NAME_C;
                bASE.NAME_E = baseDto.NAME_E;
                bASE.NAME_P = baseDto.NAME_P;
                bASE.SEX = baseDto.SEX;
                bASE.BIRDT = baseDto.BIRDT;
                bASE.ADDR1 = baseDto.ADDR1;
                bASE.ADDR2 = baseDto.ADDR2;
                bASE.TEL1 = baseDto.TEL1;
                bASE.TEL2 = baseDto.TEL2;
                bASE.BBCALL = baseDto.BBCALL;
                bASE.EMAIL = baseDto.EMAIL;
                bASE.GSM = baseDto.GSM;
                bASE.IDNO = baseDto.IDNO;
                bASE.CONT_MAN = baseDto.CONT_MAN;
                bASE.CONT_TEL = baseDto.CONT_TEL;
                bASE.CONT_GSM = baseDto.CONT_GSM;
                bASE.CONT_MAN2 = baseDto.CONT_MAN2;
                bASE.CONT_TEL2 = baseDto.CONT_TEL2;
                bASE.CONT_GSM2 = baseDto.CONT_GSM2;
                bASE.BLOOD = baseDto.BLOOD;
                bASE.PASSWORD = baseDto.PASSWORD;
                bASE.POSTCODE1 = baseDto.POSTCODE1;
                bASE.POSTCODE2 = baseDto.POSTCODE2;
                bASE.BANK_CODE = baseDto.BANK_CODE;
                bASE.BANKNO = baseDto.BANKNO;
                bASE.ACCOUNT_NO = baseDto.ACCOUNT_NO;
                bASE.ACCOUNT_NA = baseDto.ACCOUNT_NA;
                bASE.MARRY = baseDto.MARRY;
                bASE.COUNTRY = baseDto.COUNTRY;
                bASE.COUNT_MA = baseDto.COUNT_MA;
                bASE.ARMY = baseDto.ARMY;
                bASE.PRO_MAN1 = baseDto.PRO_MAN1;
                bASE.PRO_ADDR1 = baseDto.PRO_ADDR1;
                bASE.PRO_ID1 = baseDto.PRO_ID1;
                bASE.PRO_TEL1 = baseDto.PRO_TEL1;
                bASE.PRO_MAN2 = baseDto.PRO_MAN2;
                bASE.PRO_ADDR2 = baseDto.PRO_ADDR2;
                bASE.PRO_ID2 = baseDto.PRO_ID2;
                bASE.PRO_TEL2 = baseDto.PRO_TEL2;
                bASE.ARMY_TYPE = baseDto.ARMY_TYPE;
                bASE.N_NOBR = baseDto.N_NOBR;
                bASE.NOBR_B = baseDto.NOBR_B;
                bASE.PROVINCE = baseDto.PROVINCE;
                bASE.BORN_ADDR = baseDto.BORN_ADDR;
                bASE.TAXCNT = baseDto.TAXCNT;
                bASE.KEY_MAN = baseDto.KEY_MAN;
                bASE.KEY_DATE = baseDto.KEY_DATE;
                bASE.ID_TYPE = baseDto.ID_TYPE;
                bASE.TAXNO = baseDto.TAXNO;
                bASE.PRETAX = baseDto.PRETAX;
                bASE.CONT_REL1 = baseDto.CONT_REL1;
                bASE.CONT_REL2 = baseDto.CONT_REL2;
                bASE.ACCOUNT_MA = baseDto.ACCOUNT_MA;
                bASE.MATNO = baseDto.MATNO;
                bASE.SUBTEL = baseDto.SUBTEL;
                //bASE.PHOTO = baseDto.PHOTO;
                //bASE.up1_name = baseDto.up1_name;
                //bASE.up1_file = baseDto.up1_file;
                //bASE.up2_name = baseDto.up2_name;
                //bASE.up2_file = baseDto.up2_file;
                //bASE.up3_name = baseDto.up3_name;
                //bASE.up3_file = baseDto.up3_file;
                //bASE.up4_name = baseDto.up4_name;
                //bASE.up4_file = baseDto.up4_file;
                //bASE.up5_name = baseDto.up5_name;
                //bASE.up5_file = baseDto.up5_file;
                bASE.BASECD = baseDto.BASECD;
                bASE.NAME_AD = baseDto.NAME_AD;
                bASE.CandidateWays = baseDto.CandidateWays;
                bASE.AdditionDate = baseDto.AdditionDate;
                bASE.AdditionNO = baseDto.AdditionNO;
                bASE.AdmitDate = baseDto.AdmitDate;
                bASE.IntroductionBonus = baseDto.IntroductionBonus;
                bASE.Introductor = baseDto.Introductor;
                bASE.Aboriginal = baseDto.Aboriginal;
                bASE.Disability = baseDto.Disability;
                bASE.Gift = baseDto.Gift;

                db.BASE.InsertOnSubmit(bASE);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool UpdateBASE(Dto.BaseDto baseDto, out string msg)
        {
            msg = "";
            try
            {
                var bASE = GetOverlapBASE(baseDto);
                if (bASE != null)
                {
                    //bASE.NOBR = baseDto.NOBR;
                    bASE.NAME_C = baseDto.NAME_C;
                    bASE.NAME_E = baseDto.NAME_E;
                    bASE.NAME_P = baseDto.NAME_P;
                    bASE.SEX = baseDto.SEX;
                    bASE.BIRDT = baseDto.BIRDT;
                    bASE.ADDR1 = baseDto.ADDR1;
                    bASE.ADDR2 = baseDto.ADDR2;
                    bASE.TEL1 = baseDto.TEL1;
                    bASE.TEL2 = baseDto.TEL2;
                    bASE.BBCALL = baseDto.BBCALL;
                    bASE.EMAIL = baseDto.EMAIL;
                    bASE.GSM = baseDto.GSM;
                    bASE.IDNO = baseDto.IDNO;
                    bASE.CONT_MAN = baseDto.CONT_MAN;
                    bASE.CONT_TEL = baseDto.CONT_TEL;
                    bASE.CONT_GSM = baseDto.CONT_GSM;
                    bASE.CONT_MAN2 = baseDto.CONT_MAN2;
                    bASE.CONT_TEL2 = baseDto.CONT_TEL2;
                    bASE.CONT_GSM2 = baseDto.CONT_GSM2;
                    bASE.BLOOD = baseDto.BLOOD;
                    bASE.PASSWORD = baseDto.PASSWORD;
                    bASE.POSTCODE1 = baseDto.POSTCODE1;
                    bASE.POSTCODE2 = baseDto.POSTCODE2;
                    bASE.BANK_CODE = baseDto.BANK_CODE;
                    bASE.BANKNO = baseDto.BANKNO;
                    bASE.ACCOUNT_NO = baseDto.ACCOUNT_NO;
                    bASE.ACCOUNT_NA = baseDto.ACCOUNT_NA;
                    bASE.MARRY = baseDto.MARRY;
                    bASE.COUNTRY = baseDto.COUNTRY;
                    bASE.COUNT_MA = baseDto.COUNT_MA;
                    bASE.ARMY = baseDto.ARMY;
                    bASE.PRO_MAN1 = baseDto.PRO_MAN1;
                    bASE.PRO_ADDR1 = baseDto.PRO_ADDR1;
                    bASE.PRO_ID1 = baseDto.PRO_ID1;
                    bASE.PRO_TEL1 = baseDto.PRO_TEL1;
                    bASE.PRO_MAN2 = baseDto.PRO_MAN2;
                    bASE.PRO_ADDR2 = baseDto.PRO_ADDR2;
                    bASE.PRO_ID2 = baseDto.PRO_ID2;
                    bASE.PRO_TEL2 = baseDto.PRO_TEL2;
                    bASE.ARMY_TYPE = baseDto.ARMY_TYPE;
                    bASE.N_NOBR = baseDto.N_NOBR;
                    bASE.NOBR_B = baseDto.NOBR_B;
                    bASE.PROVINCE = baseDto.PROVINCE;
                    bASE.BORN_ADDR = baseDto.BORN_ADDR;
                    bASE.TAXCNT = baseDto.TAXCNT;
                    bASE.KEY_MAN = baseDto.KEY_MAN;
                    bASE.KEY_DATE = baseDto.KEY_DATE;
                    bASE.ID_TYPE = baseDto.ID_TYPE;
                    bASE.TAXNO = baseDto.TAXNO;
                    bASE.PRETAX = baseDto.PRETAX;
                    bASE.CONT_REL1 = baseDto.CONT_REL1;
                    bASE.CONT_REL2 = baseDto.CONT_REL2;
                    bASE.ACCOUNT_MA = baseDto.ACCOUNT_MA;
                    bASE.MATNO = baseDto.MATNO;
                    bASE.SUBTEL = baseDto.SUBTEL;
                    //bASE.PHOTO = baseDto.PHOTO;
                    //bASE.up1_name = baseDto.up1_name;
                    //bASE.up1_file = baseDto.up1_file;
                    //bASE.up2_name = baseDto.up2_name;
                    //bASE.up2_file = baseDto.up2_file;
                    //bASE.up3_name = baseDto.up3_name;
                    //bASE.up3_file = baseDto.up3_file;
                    //bASE.up4_name = baseDto.up4_name;
                    //bASE.up4_file = baseDto.up4_file;
                    //bASE.up5_name = baseDto.up5_name;
                    //bASE.up5_file = baseDto.up5_file;
                    bASE.BASECD = baseDto.BASECD;
                    bASE.NAME_AD = baseDto.NAME_AD;
                    bASE.CandidateWays = baseDto.CandidateWays;
                    bASE.AdditionDate = baseDto.AdditionDate;
                    bASE.AdditionNO = baseDto.AdditionNO;
                    bASE.AdmitDate = baseDto.AdmitDate;
                    bASE.IntroductionBonus = baseDto.IntroductionBonus;
                    bASE.Introductor = baseDto.Introductor;
                    bASE.Aboriginal = baseDto.Aboriginal;
                    bASE.Disability = baseDto.Disability;
                    bASE.Gift = baseDto.Gift;

                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool DeleteBASE(Dto.BaseDto baseDto, out string msg)
        {
            msg = "";
            try
            {
                var bASE = GetOverlapBASE(baseDto);
                if (bASE != null)
                {
                    db.BASE.DeleteOnSubmit(bASE);
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
    }
}
