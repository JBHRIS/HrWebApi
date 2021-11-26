using System;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BL;

public partial class Default : JBWebPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        FileGroupRole_Repo fgrRepo = new FileGroupRole_Repo();
        var list = fgrRepo.GetByRoleList_Dlo(Juser.RoleList.Cast<string>().ToList()).OrderBy(p => p.FileGroup.Sequence).ToList();

        for (int i = 0; i < list.Count; i++)
        {
            int x = list.FindIndex(i + 1, p => p.FileGroupId == list[i].FileGroupId);
            if (x > -1)
            {
                list.RemoveAt(x);
                i--;
            }
        }

        int count = 1;
        if (list.Any(p => p.FileGroup.FileStructureGroup.Count > 0))
            count = list.Max(p => p.FileGroup.FileStructureGroup.Count());

        foreach (var l in list)
        {
            Panel pnl = new Panel();
            //mainContent.Controls.Add(pnl);
            mainContent.Controls.AddAt(mainContent.Controls.Count, pnl);

            pnl.Height = 22 + (33 * count);
            pnl.Attributes.Add("class", "funcBlock");
            HtmlGenericControl header = new HtmlGenericControl("h3");
            pnl.Controls.Add(header);
            header.InnerText = l.FileGroup.Name;
            HtmlGenericControl ul = new HtmlGenericControl("ul");
            pnl.Controls.Add(ul);

            foreach (var p in l.FileGroup.FileStructureGroup)
            {
                if (!p.FileStructure.FileStructureRole.Any(c => Juser.RoleList.Contains(c.RoleCode)))
                    continue;

                HtmlGenericControl li = new HtmlGenericControl("li");
                ul.Controls.Add(li);
                HyperLink hl = new HyperLink();
                li.Controls.Add(hl);
                hl.Text = p.FileStructure.sFileTitle;

                if (p.FileStructure.sPath.Contains(@"http://"))
                {
                    hl.NavigateUrl = p.FileStructure.sPath;
                }
                else
                    hl.NavigateUrl = @"~" + p.FileStructure.sPath + p.FileStructure.sFileName;//ResolveClientUrl(@"~"+p.FileStructure.sPath + p.FileStructure.sFileName);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }
}