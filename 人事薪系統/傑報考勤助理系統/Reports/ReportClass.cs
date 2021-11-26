using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;

namespace JBHR.Reports
{
    class ReportClass
    {
        public static DataTable GetNobrMin()
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_nobrmin = new DataTable();
            try
            {  
                string sSelect = "select top 1 rtrim(nobr) as nobr,name_c from base order by nobr  ";
                rq_nobrmin = sql.GetDataTable(sSelect);   
            }
            catch (Exception ex)
            {
                throw ex;
            }            
           
            return rq_nobrmin;
        }

        public static DataTable GetNobrMax()
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_nobrmax = new DataTable();            
            try
            {               
                string sSelect = "select top 1 rtrim(nobr) as nobr,name_c from base order by nobr desc ";
                rq_nobrmax = sql.GetDataTable(sSelect);   
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return rq_nobrmax;
        }
        
        public static DataTable GetEmpcd()
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_empcd = new DataTable();           
            try
            {   
                string sSelect = "select rtrim(empcd) as empcd, empcd+' : '+ empdescr as empdescr from empcd order BY empcd";
                rq_empcd = sql.GetDataTable(sSelect);                
            }
            catch (Exception ex)
            {
                throw ex;
            }            
            return rq_empcd;
        }

        public static DataTable GetDept(string Comp)
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_dept = new DataTable();            
            try
            {
                int _adm = (Convert.ToBoolean(MainForm.ADMIN)) ? 1 : 0;
                string sSelect = "select rtrim(d_no_disp) as d_no, rtrim(d_no_disp)+' : '+ d_name as d_name  from dept";
                sSelect+="  where getdate() between adate and ddate ";
                //sSelect += "  and exists (select source from code_filter where source='dept' and code=dept.d_no";
                sSelect += string.Format(@" and dbo.GetCodeFilter('DEPT',D_NO,'{0}','{1}',{2})=1 ", MainForm.USER_ID, MainForm.COMPANY, _adm);
                //sSelect += " and codegroup=code_filter.codegroup))";
                sSelect += " order by d_no_disp";
                rq_dept = sql.GetDataTable(sSelect);    
            }
            catch (Exception ex)
            {
                throw ex;
            }            
            return rq_dept;
        }

        public static DataTable GetDepts(string Comp)
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_depts = new DataTable();            
            try
            {
                int _adm = (Convert.ToBoolean(MainForm.ADMIN)) ? 1 : 0;
                string sSelect = "select rtrim(d_no_disp) as d_no, rtrim(d_no_disp)+' : '+ d_name as d_name  from depts";
                sSelect += " where getdate() between   adate and ddate";
                //sSelect += "  and exists (select source from code_filter where source='depts' and code=depts.d_no";
                //sSelect += string.Format(@" and exists (select comp from comp_code_group where comp='{0}' ", Comp);
                //sSelect += " and codegroup=code_filter.codegroup))";
                sSelect += string.Format(@" and dbo.GetCodeFilter('DEPTS',D_NO,'{0}','{1}',{2})=1 ", MainForm.USER_ID, MainForm.COMPANY, _adm);
                sSelect += "  order by d_no_disp";
                rq_depts = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return rq_depts;
        }

        public static DataTable GetJob(string Comp)
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_job = new DataTable();           
            try
            {
                int _adm = (Convert.ToBoolean(MainForm.ADMIN)) ? 1 : 0;
                string sSelect = "select rtrim(job_disp) as job, rtrim(job_disp)+' : '+ job_name as job_name  from job";
                //sSelect += "  where exists (select source from code_filter where source='job' and code=job.job";
                //sSelect += string.Format(@" and exists (select comp from comp_code_group where comp='{0}' ", Comp);
                //sSelect += " and codegroup=code_filter.codegroup))";
                sSelect += string.Format(@" where dbo.GetCodeFilter('JOB',JOB,'{0}','{1}',{2})=1 ", MainForm.USER_ID, MainForm.COMPANY, _adm);
                sSelect += " order by job_disp";
                rq_job = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
            return rq_job;
        }

        public static DataTable GetJobl(string Comp)
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_jobl = new DataTable();                  
            try
            {
                int _adm = (Convert.ToBoolean(MainForm.ADMIN)) ? 1 : 0;
                string sSelect = "select rtrim(jobl_disp) as jobl, rtrim(jobl_disp)+' : '+ job_name as job_name  from jobl";
                //sSelect += "  where exists (select source from code_filter where source='jobl' and code=jobl.jobl";
                //sSelect += string.Format(@" and exists (select comp from comp_code_group where comp='{0}' ", Comp);
                //sSelect += " and codegroup=code_filter.codegroup))";
                sSelect += string.Format(@" where dbo.GetCodeFilter('JOBL',JOBL,'{0}','{1}',{2})=1 ", MainForm.USER_ID, MainForm.COMPANY, _adm);
                sSelect += "  order by jobl_disp";
                rq_jobl = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rq_jobl;
        }

        public static DataTable GetWorkcd(string Comp)
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_workcd = new DataTable();            
            try
            {
                string sSelect = "select rtrim(work_code) as work_code, rtrim(work_code)+' : '+ work_addr as work_addr  from workcd ";
                //sSelect += "  where exists (select source from code_filter where source='workcd' and code=workcd.work_code";
                //sSelect += string.Format(@" and exists (select comp from comp_code_group where comp='{0}' ", Comp);
                //sSelect += " and codegroup=code_filter.codegroup))";
                sSelect += " order by work_code";
                rq_workcd = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return rq_workcd;
        }

        public static DataTable GetComp(string Comp)
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_comp = new DataTable();            
            try
            {
                string sSelect = "select rtrim(comp) as comp, rtrim(comp)+' : '+ compname as compname from comp";
                //sSelect += "  where exists (select source from code_filter where source='comp' and code=comp.comp";
                //sSelect += string.Format(@" and exists (select comp from comp_code_group where comp='{0}' ", Comp);
                //sSelect += " and codegroup=code_filter.codegroup))";
                sSelect += "  order by comp";
                rq_comp = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rq_comp;
        }

        public static DataTable GetOutcd()
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_outcd = new DataTable();            
            try
            {
                string sSelect = "select rtrim(outcd) as outcd, rtrim(outcd)+' : '+ outname as outname from outcd order by outcd";
                rq_outcd = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return rq_outcd;
        }

        public static DataTable GetTtscode()
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_ttscode = new DataTable();           
            try
            {
                string sSelect = "select rtrim(ttscode) as ttscode, rtrim(ttscode)+' : '+ ttsdesc as ttsdesc from ttscode order by ttscode";
                rq_ttscode = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return rq_ttscode;
        }

        public static DataTable GetTtscd()
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_ttscd = new DataTable();           
            try
            {
                int _adm = (Convert.ToBoolean(MainForm.ADMIN)) ? 1 : 0;
                string sSelect = "select rtrim(ttscd) as ttscd, rtrim(ttscd_disp)+' : '+ ttsname as ttsname from ttscd";
                sSelect += string.Format(@" where dbo.GetCodeFilter('JOBL',JOBL,'{0}','{1}',{2})=1 ", MainForm.USER_ID, MainForm.COMPANY, _adm);
                sSelect += "  order by ttscd_disp";
                rq_ttscd = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
            return rq_ttscd;
        }

        public static DataTable GetOtrcd()
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_otrcd = new DataTable();
            
            try
            {
                string sSelect = "select rtrim(otrcd) as otrcd, rtrim(otrcd)+' : '+ otrname as otrname from otrcd order by otrcd";
                rq_otrcd = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return rq_otrcd;
        }

        public static DataTable GetHcode(string Comp)
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_hcode = new DataTable();
            try
            {
                int _adm = (Convert.ToBoolean(MainForm.ADMIN)) ? 1 : 0;
                string sSelect = "select rtrim(h_code_disp) as h_code, rtrim(h_code_disp)+' : '+ h_name as h_name from hcode ";
                //sSelect += "  where exists (select source from code_filter where source='hcode' and code=hcode.h_code";
                //sSelect += string.Format(@" and exists (select comp from comp_code_group where comp='{0}' ", Comp);
                //sSelect += " and codegroup=code_filter.codegroup))";
                sSelect += string.Format(@" where dbo.GetCodeFilter('HCODE',H_CODE,'{0}','{1}',{2})=1 ", MainForm.USER_ID, MainForm.COMPANY, _adm);
                sSelect += " order by h_code_disp";
                rq_hcode = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return rq_hcode;
        }


        public static DataTable GetRote(string Comp)
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_rote = new DataTable();
            try
            {
                int _adm = (Convert.ToBoolean(MainForm.ADMIN)) ? 1 : 0;
                string sSelect = "select rtrim(rote_disp) as rote, rtrim(rote_disp)+' : '+ rotename as rotename from rote ";
                //sSelect += "  where exists (select source from code_filter where source='rote' and code=rote.rote";
                //sSelect += string.Format(@" and exists (select comp from comp_code_group where comp='{0}' ", Comp);
                //sSelect += " and codegroup=code_filter.codegroup))";
                sSelect += string.Format(@" where dbo.GetCodeFilter('ROTE',ROTE,'{0}','{1}',{2})=1 ", MainForm.USER_ID, MainForm.COMPANY, _adm);
                sSelect += "order by rote_disp";
                rq_rote = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return rq_rote;
        }

        public static DataTable GetRotet(string Comp)
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_rotet = new DataTable();            
            try
            {
                int _adm = (Convert.ToBoolean(MainForm.ADMIN)) ? 1 : 0;
                string sSelect = "select rtrim(rotet_disp) as rotet, rtrim(rotet_disp)+' : '+ rotetname as rotetname from rotet";
                //sSelect += "  where exists (select source from code_filter where source='rotet' and code=rotet.rotet";
                //sSelect += string.Format(@" and exists (select comp from comp_code_group where comp='{0}' ", Comp);
                //sSelect += " and codegroup=code_filter.codegroup))";
                sSelect += string.Format(@" where dbo.GetCodeFilter('ROTET',ROTET,'{0}','{1}',{2})=1 ", MainForm.USER_ID, MainForm.COMPANY, _adm);
                sSelect += " order by rotet_disp";
                rq_rotet = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return rq_rotet;
        }

        public static DataTable GetSalcode()
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_salcode = new DataTable();           
            try
            {
                int _adm = (Convert.ToBoolean(MainForm.ADMIN)) ? 1 : 0;
                string sSelect = "select rtrim(sal_code_disp) as sal_code, rtrim(sal_code_disp)+' : '+ sal_name as sal_name from salcode ";
                sSelect += string.Format(@" where dbo.GetCodeFilter('SALCODE',SAL_CODE,'{0}','{1}',{2})=1 ", MainForm.USER_ID, MainForm.COMPANY, _adm);
                sSelect += " order by sal_code_disp";
                rq_salcode = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return rq_salcode;
        }

        public static DataTable GetBascd()
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_bascd = new DataTable();           
            try
            {
                string sSelect = "select rtrim(bascd) as bascd, rtrim(bascd)+' : '+ basdescr as basdescr from  basecd order by bascd";
                rq_bascd = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return rq_bascd;
        }

        public static DataTable GetU_Sys()
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_sys = new DataTable();
            try
            {
                string sSelect = "select company from u_sys1 where comp='" + MainForm.COMPANY + "'";
                rq_sys = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rq_sys;
        }

        public static DataTable GetU_Sys3()
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_sys3 = new DataTable();
            try
            {
                string sSelect = "select * from u_sys3 where comp='" + MainForm.COMPANY + "'";
                rq_sys3 = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rq_sys3;
        }

        public static DataTable GetEducode()
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_educode = new DataTable();
            try
            {
                string sSelect = "select rtrim(code) as educode, rtrim(code)+' : '+ name as edudesc from educode order by code";
                rq_educode = sql.GetDataTable(sSelect);              
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return rq_educode;
        }

        public static DataTable GetSaladr(string Comp)
        {
            //JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_saladr = MainForm.ReadRules.Select(p => new { saladr = p.DATAGROUP, salname = p.DATAGROUP+" : " + p.DATAGROUP1.GROUPNAME }).CopyToDataTable();

            //try
            //{
            //    //string sSelect = "select rtrim(saladr) as saladr, rtrim(saladr)+' : '+ salname as salname from saladr";
            //    ////sSelect += "  where exists (select source from code_filter where source='saladr' and code=saladr.saladr";
            //    ////sSelect += string.Format(@" and exists (select comp from comp_code_group where comp='{0}' ", Comp);
            //    ////sSelect += " and codegroup=code_filter.codegroup))";
            //    //sSelect += " order by saladr";
            //    string sSelect = "select  rtrim(a.datagroup) as saladr, rtrim(a.datagroup)+' : '+a.groupname as salname";
            //    sSelect += " from datagroup a";
            //    sSelect += " where exists (select a.datagroup from comp_datagroup b where a.datagroup=b.datagroup ";
            //    sSelect += string.Format(@" and b.comp='{0}')", Comp);
            //    sSelect += " order by a.datagroup";
            //    rq_saladr = sql.GetDataTable(sSelect);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            return rq_saladr;
        }

        public static DataTable GetInscomp(string Comp)
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_inscomp = new DataTable();
            try
            {
                int _adm = (Convert.ToBoolean(MainForm.ADMIN)) ? 1 : 0;
                string sSelect = "select rtrim(s_no_disp) as s_no, rtrim(s_no_disp)+' : '+ insname as insname from inscomp";
                //sSelect += "  where exists (select source from code_filter where source='inscomp' and code=inscomp.s_no";
                //sSelect += string.Format(@" and exists (select comp from comp_code_group where comp='{0}' ", Comp);
                //sSelect += " and codegroup=code_filter.codegroup))";
                sSelect += string.Format(@" where dbo.GetCodeFilter('INSCOMP',S_NO,'{0}','{1}',{2})=1 ", MainForm.USER_ID, MainForm.COMPANY, _adm);
                sSelect += " order by s_no_disp";
                rq_inscomp = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rq_inscomp;
        }

        public static DataTable InsCnComp()
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_InsCnComp = new DataTable();
            try
            {
                string sSelect = "select rtrim(compcode) as compcode, rtrim(compcode)+' : '+ compname as compname from InsCnComp order by compcode";
                rq_InsCnComp = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rq_InsCnComp;
        }

        public static DataTable InsurCnCode()
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_InsurCnCode = new DataTable();
            try
            {
                string sSelect = "select rtrim(insurcncode) as insurcncode, rtrim(insurcncode)+' : '+ insurcnname as insurcnname from InsurCnCode order by insurcncode";
                rq_InsurCnCode = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rq_InsurCnCode;
        }

        public static DataTable GetTcode()
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_tcode = new DataTable();
            try
            {
                string sSelect = "select rtrim(t_code) as t_code, rtrim(t_code)+' : '+ t_name as t_name from tcode order by t_code";
                rq_tcode = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rq_tcode;
        }

        public static DataTable GetDormitoryRoom()
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_Room = new DataTable();
            try
            {
                string sSelect = "select rtrim(AutoKey) as RoomId,RoomId as Roomname  from DormitoryRoom order by RoomId";
                rq_Room = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rq_Room;
        }

        public static DataTable GetWcode()
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_wcode = new DataTable();
            try
            {
                string sSelect = "select rtrim(w_code) as w_code, rtrim(w_code)+' : '+ w_name as w_name from wcode order by w_code";
                rq_wcode = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rq_wcode;
        }

        public static DataTable GetContract_Type()
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_contract = new DataTable();
            try
            {
                string sSelect = "select rtrim(code) as code, rtrim(code)+' : '+ displayname as name from ContractType order by code";
                rq_contract = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rq_contract;
        }

        public static DataTable GetDeptGroup(string D_no, string Child, string job, string job_tree,string jobl,int cnt)
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_deptg = new DataTable();
            try
            {
                string sSelect = "select '" + D_no + "' as dept,'" + job + "' as job, a.d_no as Child,";
                sSelect += "'" + job_tree + "' as job_tree,'" + jobl + "' as jobl," + cnt + " as cnt ";
                sSelect += " from dept a ";               
                sSelect += " where a.dept_group='" + Child + "' ";
                rq_deptg = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rq_deptg;
        }

        public static DataTable GetYRFormat()
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_yrformat = new DataTable();
            try
            {
                string sSelect = "select rtrim(m_format) as m_format, rtrim(m_format)+' : '+ m_fmt_name as m_fmt_name from yrformat order by m_format";
                rq_yrformat = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rq_yrformat;
        }

        public static DataTable GetTrtype()
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_trsub = new DataTable();
            try
            {
                string sSelect = "select rtrim(tr_type_disp) as tr_type, rtrim(tr_type_disp)+' : '+ descr as descr from trtype order by tr_type";
                rq_trsub = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rq_trsub;
        }

        public static DataTable GetJobs(string Comp)
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_job = new DataTable();
            try
            {
                int _adm = (Convert.ToBoolean(MainForm.ADMIN)) ? 1 : 0;
                string sSelect = "select rtrim(jobs_disp) as jobs, rtrim(jobs_disp)+' : '+ job_name as job_name  from jobs";
                sSelect += string.Format(@" where dbo.GetCodeFilter('jobs',jobs,'{0}','{1}',{2})=1 ", MainForm.USER_ID, MainForm.COMPANY, _adm);
                sSelect += " order by jobs_disp";
                rq_job = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rq_job;
        }

        public static DataTable GetEfftype()
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_yrformat = new DataTable();
            try
            {
                string sSelect = "select rtrim(efftype_disp) as efftype, rtrim(efftype_disp)+' : '+ efftype_name as efftype_name from efftype order by efftype_disp";
                rq_yrformat = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rq_yrformat;
        }

        public static DataTable GetHcodetype()
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_hcodetype = new DataTable();
            try
            {
                string sSelect = "select rtrim(htype) as htype, rtrim(htype)+' : '+ type_name as type_name from hcodetype order by htype";
                rq_hcodetype = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rq_hcodetype;
        }

        public static DataTable GetTranDate(string YYMM, string Seq)
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_trandate = new DataTable();
            try
            {
                string sSelect = "select Convert(char(10), adate,111) as adate from wage where yymm='" + YYMM + "' and seq='" + Seq + "' group by adate order by adate";
                rq_trandate = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rq_trandate;
        }

        public static DataTable GetTranDate1(string YYMM, string Seq_b, string Seq_e)
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_trandate = new DataTable();
            try
            {
                string sSelect = "select Max(Convert(char(10), adate,111)) as adate from wage where yymm='" + YYMM + "'";
                //sSelect += string.Format(@" and seq between '{0}' and '{1}'  group by adate order by adate", Seq_b, Seq_e);
                sSelect += string.Format(@" and seq between '{0}' and '{1}' ", Seq_b, Seq_e);
                rq_trandate = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rq_trandate;
        }

        public static DataTable GetDeptGroup()
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_deptgroup = new DataTable();
            try
            {
                string sSelect = "select rtrim(d_no) as d_no, rtrim(d_no_disp)+' : '+ d_name as d_name from dept where dept_group ='A000' order by d_no_disp";
                rq_deptgroup = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rq_deptgroup;
        }

        public static DataTable GetDeptGroup(string D_no, string Child)
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_deptg = new DataTable();
            try
            {
                string sSelect = "select '" + D_no + "' as dept, a.d_no as Child ";               
                sSelect += " from dept a ";
                sSelect += " where a.dept_group='" + Child + "' ";
                rq_deptg = sql.GetDataTable(sSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rq_deptg;
        }

        public static string GetTransWK(DateTime Tdate)
        {
            int wkindex = Convert.ToInt32(Tdate.DayOfWeek);
            string[] _wk = new string[] { "日", "一", "二", "三", "四", "五", "六" };
            return _wk[wkindex].ToString();
        }

        public static string ConvertDataTableToHtml(DataTable dt)
        {
            int i = 0;
            string body = "<table  cellspacing=\"0\" cellpadding=\"3\" rules=\"all\" bordercolor=\"Black\" border=\"1\"  style=\"background-color:#F4FFF4;border-color:Black;font-family:Verdana;font-size:10pt;border-collapse:collapse;\">";
            foreach (DataRow r in dt.Rows)
            {
                if (i == 0)
                {
                    body += "<tr>";

                    foreach (DataColumn dc in dt.Columns)
                    {
                        if (dc.ColumnName.ToString() == "出勤日期" || dc.ColumnName.ToString() == "員工姓名")
                            body += "<td  width=\"70px\">" + dc.ColumnName + "</td>";
                        else
                            body += "<td>" + dc.ColumnName + "</td>";
                        //body += "<td>" + dc.ColumnName + "</td>";
                    }

                    body += "</tr>";
                }

                body += "<tr>";
                foreach (DataColumn dc in dt.Columns)
                    body += "<td> " + r[dc].ToString().Trim() + "  &nbsp; </td>";

                body += "</tr>";
                i++;
            }
            body += "</table>";
            //body += "<BR><B><font color=red>本通知僅供參考，請各位仍需養成自行查看出勤的好習慣（關帳日若為月底時，更需要留意）。<BR>本筆異常通知為系統自動寄出，請勿直接回覆，若有任何出勤問題請洽分機1324淑芬</font></B>";
            return body;
        }

        public static string GetSalBDate(string Year, string Mon)
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_sys2 = sql.GetDataTable("select attmonth,salmonth from u_sys2 where comp='" + MainForm.COMPANY + "'");
            string date = "";
            int _day = Convert.ToDateTime(Year + "/" + Mon + "/01").AddMonths(1).AddDays(-1).Day;
            int salday = (rq_sys2.Rows.Count > 0) ? int.Parse(rq_sys2.Rows[0]["salmonth"].ToString()) : 0;
            if (salday > _day)
                date = Convert.ToDateTime(Year + "/" + Mon + "/01").AddDays(_day).AddMonths(-1).ToString("yyyy/MM/dd");
            else
                date = Convert.ToDateTime(Year + "/" + Mon + "/01").AddDays(salday).AddMonths(-1).ToString("yyyy/MM/dd");
            return date;
        }


        public static string GetSalEDate(string Year, string Mon)
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_sys2 = sql.GetDataTable("select attmonth,salmonth from u_sys2 where comp='" + MainForm.COMPANY + "'");
            string date = "";
            int _day = Convert.ToDateTime(Year + "/" + Mon + "/01").AddMonths(1).AddDays(-1).Day;
            int salday = (rq_sys2.Rows.Count > 0) ? int.Parse(rq_sys2.Rows[0]["salmonth"].ToString()) : 0;
            if (salday > _day)
                date = Convert.ToDateTime(Year + "/" + Mon + "/01").AddDays(-1).AddDays(_day).ToString("yyyy/MM/dd");
            else
                date = Convert.ToDateTime(Year + "/" + Mon + "/01").AddDays(-1).AddDays(salday).ToString("yyyy/MM/dd");
            return date;
        }

        public static string GetAttBDate(string Year, string Mon)
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_sys2 = sql.GetDataTable("select attmonth from u_sys2 where comp='" + MainForm.COMPANY + "'");
            string date = "";
            int _day = Convert.ToDateTime(Year + "/" + Mon + "/01").AddMonths(1).AddDays(-1).Day;
            int attday = (rq_sys2.Rows.Count > 0) ? int.Parse(rq_sys2.Rows[0]["attmonth"].ToString()) : 1;
            if (attday > _day)
                attday = _day;
            date = Convert.ToDateTime(Year + "/" + Mon + "/01").AddDays(attday).AddMonths(-1).ToString("yyyy/MM/dd");
            return date;
        }

        public static string GetAttEDate(string Year, string Mon)
        {
            JBModule.Data.CSQL sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rq_sys2 = sql.GetDataTable("select attmonth from u_sys2 where comp='" + MainForm.COMPANY + "'");
            string date = "";
            int _day = Convert.ToDateTime(Year + "/" + Mon + "/01").AddMonths(1).AddDays(-1).Day;
            int attday = (rq_sys2.Rows.Count > 0) ? int.Parse(rq_sys2.Rows[0]["attmonth"].ToString()) : 1;
            if (attday > _day)
                attday = _day;
            date = Convert.ToDateTime(Year + "/" + Mon + "/01").AddDays(attday).AddDays(-1).ToString("yyyy/MM/dd");
            return date;
        }

        public static void Export(DataTable DT, string FileName)
        {
            JBModule.Data.CNPOI.RenderDataTableToExcel(DT, JBControls.ControlConfig.GetExportPath() + FileName + ".xls");
            System.Diagnostics.Process.Start(JBControls.ControlConfig.GetExportPath() + FileName + ".xls");            
        }

        public static string GetSimplified(string str)
        {
            string r = string.Empty;
            r = ChineseConverter.Convert(str, ChineseConversionDirection.TraditionalToSimplified);
            return r;
        }

        public static string GetDayWeek(DateTime DateValue)
        {
            //string[] _week1 = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            string[] _week = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            int dayweek = (int)DateValue.DayOfWeek;
            //string _value = _week[dayweek].ToString();
            return _week[dayweek].ToString();
        }

        public static string GetRepeatEmpID(DataTable DT)
        {
            DataTable rq_nobr = new DataTable();
            rq_nobr.Columns.Add("nobr", typeof(string));
            rq_nobr.PrimaryKey = new DataColumn[] { rq_nobr.Columns["nobr"] };
            string nobrlist = "";
            foreach (DataRow Row in DT.Rows)
            {
                DataRow row = rq_nobr.Rows.Find(Row["nobr"].ToString());
                if (row == null)
                {
                    DataRow aRow = rq_nobr.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    rq_nobr.Rows.Add(aRow);
                }
                else
                {
                    nobrlist += Row["nobr"].ToString() + ",";
                }
            }
            rq_nobr = null;
            if (!string.IsNullOrEmpty(nobrlist)) nobrlist = nobrlist.Substring(0, nobrlist.Length - 1);
            return nobrlist;
        }
    }
}
