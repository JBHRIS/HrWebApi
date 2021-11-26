using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Reports.AttForm.ACCS
{
    public class rq_OTDto{
        //string sqlOta = "select a.nobr,a.bdate,a.yymm,a.btime,a.etime,a.ot_hrs,a.fst_hours,a.syscreat,";
        //            sqlOta += "rest_hrs,syscreat1,a.sys_ot,ot_food1,note,a.not_w_100,a.tot_w_100";
        //            sqlOta += ",a.not_w_133,a.tot_w_133,a.not_h_133,a.not_w_167,a.tot_w_167,a.not_h_167";
        //            sqlOta += ",a.not_w_200,a.tot_w_200,a.not_h_200,a.tot_hours,a.salary,a.not_exp,a.tot_exp";
        //            sqlOta += ",b.rote,dbo.GetContinuousWorkDay(a.nobr,b.adate) as wday";
        //            sqlOta += " from ot a ";
        
        //必要欄位

        public string           rote        {get;set;}
        public string	        nobr	    {get;set;}
        public DateTime	        bdate	    {get;set;}
        public string	        btime	    {get;set;}
        public string	        etime	    {get;set;}
        public decimal	        tot_hours	{get;set;}
        public decimal	        ot_hrs	    {get;set;}
        public decimal          maxhrs      { get; set; }
        public bool defaultdata { get; set; }

        //=========

        //public int             wday        {get;set;}
        //public decimal	        rest_hrs	{get;set;}
        //public decimal	        ot_car	    {get;set;}
        //public string	        ot_dept	    {get;set;}
        //public string	        key_man	    {get;set;}
        //public DateTime	    key_date	{get;set;}
        //public decimal	        ot_food	    {get;set;}
        //public string	        note	    {get;set;}
        //public decimal	        food_pri	{get;set;}
        //public decimal	        food_cnt	{get;set;}
        //public string	        yymm	    {get;set;}
        //public string	        ser	        {get;set;}
        //public decimal	        not_w_133	{get;set;}
        //public decimal	        not_w_167	{get;set;}
        //public decimal	        not_w_200	{get;set;}
        //public decimal	        not_h_200	{get;set;}
        //public decimal	        tot_w_100	{get;set;}
        //public decimal	        tot_w_133	{get;set;}
        //public decimal	        tot_w_167	{get;set;}
        //public decimal	        tot_w_200	{get;set;}
        //public decimal	        tot_h_200	{get;set;}
        //public decimal	        not_exp	    {get;set;}
        //public decimal	        tot_exp	    {get;set;}
        //public decimal	        rest_exp	{get;set;}
        //public decimal	        fst_hours	{get;set;}
        //public decimal	        salary	    {get;set;}
        //public bool	        notmodi	    {get;set;}
        //public string	        otrcd	    {get;set;}
        //public bool	        nofood	    {get;set;}
        //public bool	        fix_amt	    {get;set;}
        //public decimal	        rec	        {get;set;}
        //public bool	        cant_adj	{get;set;}
        //public DateTime	    ot_edate	{get;set;}
        //public string	        otno    	{get;set;}
        //public string	        ot_rote	    {get;set;}
        //public decimal	        ot_food1	{get;set;}
        //public decimal	        ot_foodh	{get;set;}
        //public decimal	        ot_foodh1	{get;set;}
        //public decimal	        nop_w_133	{get;set;}
        //public decimal	        nop_w_167	{get;set;}
        //public decimal	        nop_w_200	{get;set;}
        //public decimal	        nop_h_100	{get;set;}
        //public decimal	        nop_h_133	{get;set;}
        //public decimal	        nop_h_167	{get;set;}
        //public decimal	        nop_h_200	{get;set;}
        //public decimal	        top_w_133	{get;set;}
        //public decimal	        top_w_167	{get;set;}
        //public decimal	        top_w_200	{get;set;}
        //public decimal	        top_h_200	{get;set;}
        //public decimal	        not_h_133	{get;set;}
        //public decimal	        not_h_167	{get;set;}
        //public decimal	        hot_133	    {get;set;}
        //public decimal	        hot_166	    {get;set;}
        //public decimal	        hot_200	    {get;set;}
        //public decimal	        wot_133	    {get;set;}
        //public decimal	        wot_166	    {get;set;}
        //public decimal	        wot_200	    {get;set;}
        //public bool	        sum	        {get;set;}
        //public bool	        syscreat	{get;set;}
        //public string	        otrate_code	{get;set;}
        //public decimal	        not_w_100	{get;set;}
        //public decimal	        top_w_100	{get;set;}
        //public bool	        syscreat1	{get;set;}
        //public decimal	        nop_w_100	{get;set;}
        //public bool	        sys_ot	    {get;set;}
        //public string	        serno	    {get;set;}
        //public decimal	        diff	    {get;set;}
        //public bool	        eat	        {get;set;}
        //public bool	        res	        {get;set;}
        //public bool	        nofood1	    {get;set;}
        //public decimal	        dot_hrs	    {get;set;}
        //public bool	        nootcard	{get;set;}
    }
}
