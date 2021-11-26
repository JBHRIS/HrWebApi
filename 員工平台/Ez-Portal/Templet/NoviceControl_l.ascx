<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NoviceControl_l.ascx.cs"
    Inherits="Templet_NoviceControl_l" %>
<h3>
    <asp:Localize ID="Localize1" runat="server">本月離職人員</asp:Localize>
</h3>
<br />
<asp:DataList ID="DataList1" runat="server" OnDataBinding="DataList1_DataBinding"
    OnItemDataBound="DataList1_ItemDataBound">
    <ItemTemplate>
        <fieldset>
            <table width="100%">
                <tr>
                    <td rowspan="2" width="80">
                        <asp:Image ID="Image1" runat="server" Height="120px" Width="90px" AlternateText='<%# Eval("nobr") %>'
                            ImageUrl="~/Images/stick_on_picture.gif" />
                    </td>
                    <td colspan="2" rowspan="2">
                        <asp:Label ID="Label5" runat="server" ForeColor="Blue" Text="部門："></asp:Label>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("d_name") %>' ForeColor="Blue"></asp:Label><br />
                        <asp:Label ID="Label6" runat="server" ForeColor="Blue" Text="姓名："></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("name_c") %>' ForeColor="Blue"></asp:Label><br />
                        職稱：<asp:Label ID="Label3" runat="server" Text='<%# Eval("JOB_NAME") %>'></asp:Label><br />
                        離職日：
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("adate","{0:yyyy/MM/dd}") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                </tr>
            </table>
        </fieldset>
    </ItemTemplate>
</asp:DataList>
<asp:Label ID="lb_dept" runat="server" Visible="False"></asp:Label>
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="nobr" SkinID="Yahoo"
    Visible="False">
    <Columns>
        <asp:BoundField DataField="d_name" HeaderText="部門名稱" />
        <asp:BoundField DataField="nobr" HeaderText="員工編號" />
        <asp:BoundField DataField="name_c" HeaderText="員工姓名" />
        <asp:BoundField DataField="adate" DataFormatString="{0:d}" HeaderText="到職日期" HtmlEncode="False" />
    </Columns>
    <EmptyDataTemplate>
        <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="＊無相關資料！！"></asp:Label>
    </EmptyDataTemplate>
</asp:GridView>
