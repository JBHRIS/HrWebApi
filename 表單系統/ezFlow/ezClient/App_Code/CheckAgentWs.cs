using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

/// <summary>
/// CheckAgent 的摘要描述
/// </summary>
[WebService(Namespace = "http://jbjob.com.tw/ezClient")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class CheckAgentWs : System.Web.Services.WebService {

    public CheckAgentWs () {

        //如果使用設計的元件，請取消註解下行程式碼 
        //InitializeComponent(); 
    }

    AllModule Module = new AllModule();
    protected string getEmpAgentRole(string AgentEmp_id)
    {
        string txtAgentEmpName = "";
        string AgentRoleID = "";
        string AgentPosname = "";

        ezClientDS.EmpDataTable dtAgentEmp = Module.adEmp.GetDataBySearch(AgentEmp_id);
        if (dtAgentEmp.Count > 0)
        {
            txtAgentEmpName = dtAgentEmp[0].name;

            ezClientDS.RoleDataTable dtAgentRole = Module.adRole.GetDataByEmp(dtAgentEmp[0].id);
            if (dtAgentRole.Count > 0)
            {
                for (int i = 0; i < dtAgentRole.Count; i++)
                {
                    ezClientDS.PosDataTable dtAgentPos = Module.adPos.GetDataById(dtAgentRole[i].Pos_id);
                    AgentPosname = dtAgentPos[0].name;
                    AgentRoleID = dtAgentRole[0].id;

                }
            }
        }
        return AgentRoleID;
    }

    [WebMethod]
    public bool setCheckAgent(string Emp_id, string FirstAgentEmpID, string SecondAgentEmpID, string ThirdAgentEmpID)
    {
        bool isOk = true;
        try
        {
            string EmpRoleID = "";
            string FirstAgentRoleID = "";
            string SecondAgentRoleID = "";
            string ThirdAgentRoleID = "";
            EmpRoleID = getEmpAgentRole(Emp_id);
            FirstAgentRoleID = getEmpAgentRole(FirstAgentEmpID);
            SecondAgentRoleID = getEmpAgentRole(SecondAgentEmpID);
            ThirdAgentRoleID = getEmpAgentRole(ThirdAgentEmpID);
            if (EmpRoleID.Trim().Length > 0)
            {
                ezClientDS.CheckAgentDefaultDataTable dtCheckAgentDefault = Module.adCheckAgentDefault.GetDataByOne(EmpRoleID, Emp_id);
                ezClientDS.CheckAgentDefaultRow rowCheckAgentDefault = null;
                if (dtCheckAgentDefault.Count == 0) rowCheckAgentDefault = dtCheckAgentDefault.NewCheckAgentDefaultRow();
                else rowCheckAgentDefault = dtCheckAgentDefault[0];

                rowCheckAgentDefault.Role_idSource = EmpRoleID;
                rowCheckAgentDefault.Emp_idSource = Emp_id;
                rowCheckAgentDefault.Role_idTarget1 = FirstAgentRoleID;
                rowCheckAgentDefault.Emp_idTarget1 = FirstAgentEmpID;
                rowCheckAgentDefault.Role_idTarget2 = SecondAgentRoleID;
                rowCheckAgentDefault.Emp_idTarget2 = SecondAgentEmpID;
                rowCheckAgentDefault.Role_idTarget3 = ThirdAgentRoleID;
                rowCheckAgentDefault.Emp_idTarget3 = ThirdAgentEmpID;

                if (dtCheckAgentDefault.Count == 0) dtCheckAgentDefault.AddCheckAgentDefaultRow(rowCheckAgentDefault);
                Module.adCheckAgentDefault.Update(dtCheckAgentDefault);
            }
        
        }
        catch {
            isOk = false;
        }
        return isOk;
    }
    
}

