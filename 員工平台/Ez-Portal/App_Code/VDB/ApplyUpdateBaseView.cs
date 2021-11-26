using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ApplyUpdateBaseOldView 的摘要描述
/// </summary>
public class ApplyUpdateBaseView
{



    public ApplyUpdateBaseView()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public bool? Approve { get; set; }
    public string Pk { get; set; }
    public string ApproveMan { get; set; }
    public DateTime ApplyDatetime { get; set; }
    public string Name_c
    {
        get;
        set;
    }
    public string ApplyMan
    {
        get;
        set;
    }
    public string GSM
    {
        get;
        set;
    }
    public string EMAIL
    {
        get;
        set;
    }
    public string TEL1
    {
        get;
        set;
    }
    public string TEL2
    {
        get;
        set;
    }
    public string POSTCODE1
    {
        get;
        set;
    }
    public string ADDR1
    {
        get;
        set;
    }
    public string POSTCODE2
    {
        get;
        set;
    }
    public string ADDR2
    {
        get;
        set;
    }
    public string PROVINCE
    {
        get;
        set;
    }
    public string BORN_ADDR
    {
        get;
        set;
    }
    public string CONT_MAN
    {
        get;
        set;
    }
    public string CONT_REL1
    {
        get;
        set;
    }
    public string CONT_TEL
    {
        get;
        set;
    }
    public string CONT_GSM
    {
        get;
        set;
    }
    public string CONT_MAN2
    {
        get;
        set;
    }
    public string CONT_REL2
    {
        get;
        set;
    }
    public string CONT_TEL2
    {
        get;
        set;
    }
    public string CONT_GSM2
    {
        get;
        set;
    }
    public string CONT_REL1_NAME
    {
        get;
        set;
    }
    public string CONT_REL2_NAME
    {
        get;
        set;
    }
    public string SUBTEL
    {
        get;
        set;
    }

    public bool GSM_IsChanged { get; set; }
    public bool EMAIL_IsChanged { get; set; }
    public bool TEL1_IsChanged { get; set; }
    public bool TEL2_IsChanged { get; set; }
    public bool POSTCODE1_IsChang { get; set; }
    public bool ADDR1_IsChanged { get; set; }
    public bool POSTCODE1_IsChanged { get; set; }
    public bool POSTCODE2_IsChanged { get; set; }
    public bool ADDR2_IsChanged { get; set; }
    public bool PROVINCE_IsChanged { get; set; }
    public bool BORN_ADDR_IsChanged { get; set; }
    public bool CONT_MAN_IsChanged { get; set; }
    public bool CONT_REL1_IsChanged { get; set; }
    public bool CONT_TEL_IsChanged { get; set; }
    public bool CONT_GSM_IsChanged { get; set; }
    public bool CONT_MAN2_IsChanged { get; set; }
    public bool CONT_REL2_IsChanged { get; set; }
    public bool CONT_TEL2_IsChanged { get; set; }
    public bool CONT_GSM2_IsChanged { get; set; }
    public bool SUBTEL_IsChanged { get; set; }
}