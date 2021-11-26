<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NoviceControl.ascx.cs"
    Inherits="Templet_NoviceControl" %>
<h3>
    <asp:Label ID="lblHeader" runat="server" Text="新進人員" meta:resourcekey="lblHeaderResource1"></asp:Label>
</h3>
<asp:DataList ID="DataList1" runat="server" OnDataBinding="DataList1_DataBinding"
    OnItemDataBound="DataList1_ItemDataBound" 
    meta:resourcekey="DataList1Resource1" Visible="False">
    <ItemTemplate>
        <fieldset>
            <table width="100%">
                <tr>
                    <td width="80">
                        <asp:Image ID="Image1" runat="server" Height="120px" Width="90px" AlternateText='<%# Eval("nobr") %>'
                            ImageUrl="~/Images/stick_on_picture.gif" meta:resourcekey="Image1Resource1" />
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" ForeColor="Blue" Text="部門：" meta:resourcekey="Label5Resource1"></asp:Label>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("d_name") %>' ForeColor="Blue"
                            meta:resourcekey="Label1Resource1"></asp:Label><br />
                        <asp:Label ID="Label6" runat="server" ForeColor="Blue" Text="姓名：" meta:resourcekey="Label6Resource1"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("name_c") %>' ForeColor="Blue"
                            meta:resourcekey="Label2Resource1"></asp:Label>
                        <br />
                        <asp:Label ID="Label9" runat="server" Text="英文名：" meta:resourcekey="Label9Resource1"></asp:Label>
                        <asp:Label ID="lblNameE" runat="server" Text='<%# Eval("name_e") %>' meta:resourcekey="lblNameEResource1"></asp:Label>
                        <br />
                        <asp:Label ID="Label7" runat="server" Text="工號：" meta:resourcekey="Label7Resource1"></asp:Label>
                        <asp:Label ID="lblNobr" runat="server" Text='<%# Eval("nobr") %>' meta:resourcekey="lblNobrResource1"></asp:Label>
                        <br />
                        <asp:Label ID="lblShowJobTitle" runat="server" Text="職稱" meta:resourcekey="lblShowJobTitleResource1"
                            Visible="False"></asp:Label>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("JOB_NAME") %>' meta:resourcekey="Label3Resource1"
                            Visible="False"></asp:Label><br />
                        <asp:Label ID="lblShowBeginWork" runat="server" Text="到職日：" meta:resourcekey="lblShowBeginWorkResource1"></asp:Label>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("adate","{0:yyyy/MM/dd}") %>'
                            meta:resourcekey="Label4Resource1"></asp:Label>
                    </td>
                </tr>
            </table>
        </fieldset>
    </ItemTemplate>
</asp:DataList>
<asp:Label ID="lblCurPage" runat="server" 
    meta:resourcekey="lblCurPageResource1" Visible="False"></asp:Label>
<asp:HyperLink ID="lnkPrev" runat="server" meta:resourcekey="lnkPrevResource1" Visible="False">上一頁</asp:HyperLink>
<asp:HyperLink ID="lnkNext" runat="server" meta:resourcekey="lnkNextResource1" Visible="False">下一頁</asp:HyperLink>
<asp:Label ID="lb_dept" runat="server" Visible="False" meta:resourcekey="lb_deptResource1"></asp:Label>
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="nobr" 
    SkinID="Yahoo" meta:resourcekey="GridView1Resource1" PageSize="6">
    <Columns>
        <asp:BoundField DataField="d_name" HeaderText="部門名稱" meta:resourcekey="BoundFieldResource1" />
        <asp:BoundField DataField="nobr" HeaderText="員工編號" 
            meta:resourcekey="BoundFieldResource2" Visible="False" />
        <asp:BoundField DataField="name_c" HeaderText="員工姓名" meta:resourcekey="BoundFieldResource3" />
        <asp:BoundField DataField="adate" DataFormatString="{0:d}" HeaderText="到職日期" HtmlEncode="False"
            meta:resourcekey="BoundFieldResource4" />
    </Columns>
    <EmptyDataTemplate>
        <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="＊無相關資料！！"
            meta:resourcekey="lb_emptyResource1"></asp:Label>
    </EmptyDataTemplate>
</asp:GridView>
<br />
