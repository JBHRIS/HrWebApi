using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class ApplyUpdateBase
    {
        public int Pk { get; set; }
        public bool? Approve { get; set; }
        public string ApproveMan { get; set; }
        public DateTime? ApproveDatetime { get; set; }
        public string ApplyMan { get; set; }
        public DateTime ApplyDatetime { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Postcode1 { get; set; }
        public string Addr1 { get; set; }
        public string Postcode2 { get; set; }
        public string Addr2 { get; set; }
        public string Province { get; set; }
        public string BornAddr { get; set; }
        public string ContMan { get; set; }
        public string ContRel1 { get; set; }
        public string ContTel { get; set; }
        public string ContGsm { get; set; }
        public string ContMan2 { get; set; }
        public string ContRel2 { get; set; }
        public string ContTel2 { get; set; }
        public string ContGsm2 { get; set; }
        public string GsmOld { get; set; }
        public string EmailOld { get; set; }
        public string Tel1Old { get; set; }
        public string Tel2Old { get; set; }
        public string Postcode1Old { get; set; }
        public string Addr1Old { get; set; }
        public string Postcode2Old { get; set; }
        public string Addr2Old { get; set; }
        public string ProvinceOld { get; set; }
        public string BornAddrOld { get; set; }
        public string ContManOld { get; set; }
        public string ContRel1Old { get; set; }
        public string ContTelOld { get; set; }
        public string ContGsmOld { get; set; }
        public string ContMan2Old { get; set; }
        public string ContRel2Old { get; set; }
        public string ContTel2Old { get; set; }
        public string ContGsm2Old { get; set; }
        public bool GsmIsChanged { get; set; }
        public bool EmailIsChanged { get; set; }
        public bool Tel1IsChanged { get; set; }
        public bool Tel2IsChanged { get; set; }
        public bool Postcode1IsChanged { get; set; }
        public bool Addr1IsChanged { get; set; }
        public bool Postcode2IsChanged { get; set; }
        public bool Addr2IsChanged { get; set; }
        public bool ProvinceIsChanged { get; set; }
        public bool BornAddrIsChanged { get; set; }
        public bool ContManIsChanged { get; set; }
        public bool ContRel1IsChanged { get; set; }
        public bool ContTelIsChanged { get; set; }
        public bool ContGsmIsChanged { get; set; }
        public bool ContMan2IsChanged { get; set; }
        public bool ContRel2IsChanged { get; set; }
        public bool ContTel2IsChanged { get; set; }
        public bool ContGsm2IsChanged { get; set; }
        public string Subtel { get; set; }
        public string SubtelOld { get; set; }
        public bool SubtelIsChanged { get; set; }
    }
}
