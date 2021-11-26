using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Base
    {
        public Base()
        {
            Contract = new HashSet<Contract>();
        }

        public string Nobr { get; set; }
        public string NameC { get; set; }
        public string NameE { get; set; }
        public string NameP { get; set; }
        public string Sex { get; set; }
        public DateTime? Birdt { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Bbcall { get; set; }
        public string Email { get; set; }
        public string Gsm { get; set; }
        public string Idno { get; set; }
        public string ContMan { get; set; }
        public string ContTel { get; set; }
        public string ContGsm { get; set; }
        public string ContMan2 { get; set; }
        public string ContTel2 { get; set; }
        public string ContGsm2 { get; set; }
        public string Blood { get; set; }
        public string Password { get; set; }
        public string Postcode1 { get; set; }
        public string Postcode2 { get; set; }
        public string BankCode { get; set; }
        public string Bankno { get; set; }
        public string AccountNo { get; set; }
        public string AccountNa { get; set; }
        public string Marry { get; set; }
        public string Country { get; set; }
        public bool CountMa { get; set; }
        public string Army { get; set; }
        public string ProMan1 { get; set; }
        public string ProAddr1 { get; set; }
        public string ProId1 { get; set; }
        public string ProTel1 { get; set; }
        public string ProMan2 { get; set; }
        public string ProAddr2 { get; set; }
        public string ProId2 { get; set; }
        public string ProTel2 { get; set; }
        public string ArmyType { get; set; }
        public string NNobr { get; set; }
        public string NobrB { get; set; }
        public string Province { get; set; }
        public string BornAddr { get; set; }
        public decimal Taxcnt { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string IdType { get; set; }
        public string Taxno { get; set; }
        public decimal Pretax { get; set; }
        public string ContRel1 { get; set; }
        public string ContRel2 { get; set; }
        public string AccountMa { get; set; }
        public string Matno { get; set; }
        public string Subtel { get; set; }
        public byte[] Photo { get; set; }
        public string Up1Name { get; set; }
        public byte[] Up1File { get; set; }
        public string Up2Name { get; set; }
        public byte[] Up2File { get; set; }
        public string Up3Name { get; set; }
        public byte[] Up3File { get; set; }
        public string Up4Name { get; set; }
        public byte[] Up4File { get; set; }
        public string Up5Name { get; set; }
        public byte[] Up5File { get; set; }
        public string Basecd { get; set; }
        public string NameAd { get; set; }
        public string CandidateWays { get; set; }
        public DateTime? AdditionDate { get; set; }
        public string AdditionNo { get; set; }
        public DateTime? AdmitDate { get; set; }
        public bool? IntroductionBonus { get; set; }
        public string Introductor { get; set; }
        public bool? Aboriginal { get; set; }
        public bool? Disability { get; set; }
        public string Gift { get; set; }

        public virtual ICollection<Contract> Contract { get; set; }
    }
}
