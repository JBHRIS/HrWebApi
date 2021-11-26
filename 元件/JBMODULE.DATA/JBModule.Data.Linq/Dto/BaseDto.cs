using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Dto
{
    public class BaseDto
    {
        public string NOBR { get; set; } //員工編號 必
        public string NAME_C { get; set; } //中文姓名 必
        public string NAME_E { get; set; } //英文姓名 
        public string NAME_P { get; set; } //護照姓名 
        public string SEX { get; set; } //性別 必
        public DateTime? BIRDT { get; set; } //出生日期 必
        public string ADDR1 { get; set; } //通訊地址
        public string ADDR2 { get; set; } //戶籍地址
        public string TEL1 { get; set; } //通訊電話
        public string TEL2 { get; set; } //戶籍電話
        public string BBCALL { get; set; } //
        public string EMAIL { get; set; } //電子郵件
        public string GSM { get; set; } //行動電話
        public string IDNO { get; set; } //身份證號
        public string CONT_MAN { get; set; } //聯絡人1姓名
        public string CONT_TEL { get; set; } //聯絡人1電話
        public string CONT_GSM { get; set; } //聯絡人1行動電話
        public string CONT_MAN2 { get; set; } //聯絡人2姓名
        public string CONT_TEL2 { get; set; } //聯絡人2電話
        public string CONT_GSM2 { get; set; } //聯絡人2行動電話
        public string BLOOD { get; set; } //血型
        public string PASSWORD { get; set; } //密碼 必
        public string POSTCODE1 { get; set; } //通訊郵遞區號
        public string POSTCODE2 { get; set; } //戶籍郵遞區號
        public string BANK_CODE { get; set; } //外勞銀行
        public string BANKNO { get; set; } //轉帳銀行
        public string ACCOUNT_NO { get; set; } //轉帳帳號  
        public string ACCOUNT_NA { get; set; } //
        public string MARRY { get; set; } //婚姻
        public string COUNTRY { get; set; } //國籍
        public bool COUNT_MA { get; set; } //外籍員工
        public string ARMY { get; set; } //兵役
        public string PRO_MAN1 { get; set; } //保證人1姓名
        public string PRO_ADDR1 { get; set; } //保證人1地址
        public string PRO_ID1 { get; set; } //保證人1身份證號
        public string PRO_TEL1 { get; set; } //保證人1電話
        public string PRO_MAN2 { get; set; } //保證人2姓名
        public string PRO_ADDR2 { get; set; } //保證人2地址
        public string PRO_ID2 { get; set; } //保證人2身份證號
        public string PRO_TEL2 { get; set; } //保證人2電話
        public string ARMY_TYPE { get; set; } //
        public string N_NOBR { get; set; } //殘障類別
        public string NOBR_B { get; set; } //殘障身份
        public string PROVINCE { get; set; } //出生地
        public string BORN_ADDR { get; set; } //
        public decimal TAXCNT { get; set; } //扶養人數
        public string KEY_MAN { get; set; } //登錄者
        public DateTime KEY_DATE { get; set; } //登錄日期
        public string ID_TYPE { get; set; } // 
        public string TAXNO { get; set; } //護照號碼
        public decimal PRETAX { get; set; } //所得稅預扣金額
        public string CONT_REL1 { get; set; } //聯絡人1關係
        public string CONT_REL2 { get; set; } //聯絡人2關係
        public string ACCOUNT_MA { get; set; } //外勞帳號
        public string MATNO { get; set; } //居留證號
        public string SUBTEL { get; set; } //分機
        public string PHOTO { get; set; } //
        public string up1_name { get; set; } //
        public string up1_file { get; set; } //
        public string up2_name { get; set; } //
        public string up2_file { get; set; } //
        public string up3_name { get; set; } //
        public string up3_file { get; set; } //
        public string up4_name { get; set; } //
        public string up4_file { get; set; } //
        public string up5_name { get; set; } //
        public string up5_file { get; set; } //
        public string BASECD { get; set; } //身份別
        public string NAME_AD { get; set; } //AD帳號
        public string CandidateWays { get; set; } //錄取管道
        public DateTime? AdditionDate { get; set; } //
        public string AdditionNO { get; set; } //增補單號
        public DateTime? AdmitDate { get; set; } //
        public bool IntroductionBonus { get; set; } //
        public string Introductor { get; set; } //介紹人
        public bool Aboriginal { get; set; } //
        public bool Disability { get; set; } //
        public string Gift { get; set; } //
    }
}
