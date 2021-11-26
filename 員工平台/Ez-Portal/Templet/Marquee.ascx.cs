using BL;
using System;
using System.Text;

public partial class Marquee : JBUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindData();
        }
    }

    private void bindData()
    {
        Marquee_Repo mRepo = new Marquee_Repo();
        var list = mRepo.GetAllByEnable();
        StringBuilder sb = new StringBuilder();
        foreach (var item in list)
        {
            sb.AppendLine(item.DisplayText);
            sb.AppendLine("　　　　　　　　　　　　");
        }

        lblMarquee.Text = sb.ToString();
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        bindData();
    }
}