<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsContral.ascx.cs" Inherits="Templet_NewsContral" %>
<h3>
    <asp:Label ID="lblAnnouncement" runat="server" Text="HR公告" meta:resourcekey="lblAnnouncementResource1"></asp:Label>
</h3>
<asp:GridView ID="GridView1" runat="server"
    AutoGenerateColumns="False" PageSize="5" SkinID="Yahoo"
    meta:resourcekey="GridView1Resource1" onprerender="GridView1_PreRender"
    onpageindexchanging="GridView1_PageIndexChanging" Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="主旨" SortExpression="news_head" meta:resourcekey="TemplateFieldResource1">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("news_head") %>' meta:resourcekey="TextBox1Resource1"></asp:TextBox>
            </EditItemTemplate>
            <ItemStyle Width="50%" />
            <ItemTemplate>
                &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/PublicNews.aspx?ID="+Eval("news_ID")+"&news_fileid="+Eval("newsfileid") %>'
                    Text='<%# Bind("news_head") %>' meta:resourcekey="HyperLink1Resource1"></asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="post_date" HeaderText="發佈日期" SortExpression="post_date"
            meta:resourcekey="BoundFieldResource1" DataFormatString="{0:yyyy/MM/dd}">
            <ItemStyle Width="20%" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="附件筆數" meta:resourcekey="TemplateFieldResource2">
            <ItemStyle HorizontalAlign="Center" Width="10%" />
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("AttachmentCount") %>' meta:resourcekey="Label1Resource1"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="BrowsingNumber" HeaderText="點閱人次">
        <ItemStyle HorizontalAlign="Center" Width="10%" />
        </asp:BoundField>
    </Columns>
    <EmptyDataTemplate>
        <asp:Label ID="lb_empty" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red" Text="＊無相關資料！！"
            meta:resourcekey="lb_emptyResource1"></asp:Label>
    </EmptyDataTemplate>
    <RowStyle Font-Size="Small" />
</asp:GridView>
<div style="padding-bottom:10px;width:100%;text-align:right;">
    <asp:HyperLink ID="ln" runat="server" NavigateUrl="~/PublicNews.aspx">More</asp:HyperLink>
</div>
<asp:SqlDataSource ID="NewsSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
    SelectCommand="SELECT news_head,newsfileid, post_date, news_id,AttachmentCount FROM news WHERE (is_on = 1)  and  (post_deadline &gt; GETDATE() or post_deadline is null)
ORDER BY sort DESC"></asp:SqlDataSource>
<asp:Label ID="lb_adate" runat="server" Visible="False" meta:resourcekey="lb_adateResource1"></asp:Label>