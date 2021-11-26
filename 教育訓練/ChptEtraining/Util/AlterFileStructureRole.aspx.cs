using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;
public partial class AlterFileStructureRole : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        sysRole_Repo roleRepo = new sysRole_Repo();
        List<sysRole> allRoleList = roleRepo.GetAll();

        sysFileStructure_Repo fileSrtRepo = new sysFileStructure_Repo();
        List<sysFileStructure> allFileSrtList = fileSrtRepo.GetByAll();

        FileStructureRole_Repo fRoleRepo = new FileStructureRole_Repo();

        foreach (sysFileStructure fs in allFileSrtList)
        {
            foreach (sysRole r in allRoleList)
            {
                if ((fs.sysRole_iKey & r.iKey) != 0)
                {
                    FileStructureRole obj= fRoleRepo.GetByFKeyRoleKey(fs.sKey, r.iKey);
                    if (obj == null)
                    {
                        obj = new FileStructureRole();
                        obj.FileStructureKey = fs.sKey;
                        obj.RoleKey = r.iKey;
                        fRoleRepo.Add(obj);
                        fRoleRepo.Save();
                    }
                }
            }
        }

        FileStructureRole_Repo.UpdateCache();
        sysFileStructure_Repo.UpdateCache();

        //if ((r.sysRole_iKey & juser.RoleValue) == 0)
        //{
        //    continue;
        //}
    }
}