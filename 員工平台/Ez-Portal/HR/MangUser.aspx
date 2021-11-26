<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true" CodeFile="MangUser.aspx.cs" Inherits="HR_MangUser" Title="E-Portal薪資權限" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%">
        <tr>
            <td valign="top">
            <h3>
                <asp:Localize ID="Localize1" runat="server">E-Portal薪資權限</asp:Localize>
                    </h3>
                    <fieldset>
                            <legend>新增資料</legend>
                            <asp:Label ID="Label1" runat="server" Text="員工編號："></asp:Label>
                        <asp:TextBox ID="UserNobr" runat="server" Width="73px" OnTextChanged="UserNobr_TextChanged"></asp:TextBox>
                        &nbsp;<asp:Label ID="Label2" runat="server"></asp:Label>
                        &nbsp;
                            <asp:Button ID="AddButton" runat="server" Text="新增" OnClick="AddButton_Click" />
                        &nbsp;&nbsp;
                        <asp:Label ID="lb_pwd" runat="server" Visible="False"></asp:Label></fieldset>
                        &nbsp; &nbsp;
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            DataSourceID="SqlDataSource1" SkinID="Yahoo" DataKeyNames="nobr">
                            <Columns>
                                <asp:CommandField ShowDeleteButton="True" />
                                <asp:BoundField DataField="nobr" HeaderText="員工編號" SortExpression="nobr" />
                                <asp:BoundField DataField="name_c" HeaderText="員工姓名" SortExpression="name_c" />
                                <asp:BoundField DataField="key_man" HeaderText="登錄者" SortExpression="key_man" />
                                <asp:BoundField DataField="key_date" DataFormatString="{0:d}" HeaderText="登錄日期" HtmlEncode="False"
                                    SortExpression="key_date" />
                            </Columns>
                        </asp:GridView>
                <asp:Label ID="lb_nobr" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="loginname" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                    DeleteCommand="DELETE FROM MangUser WHERE (nobr = @nobr)" InsertCommand="INSERT INTO MangUser(type, nobr, name_c, key_man, key_date, Pwd) VALUES ('2', @nobr, @name_c, @name_c2, GETDATE(), @pwd)"
                    SelectCommand="SELECT nobr, name_c, key_man, key_date, Pwd FROM MangUser"
                    UpdateCommand="UPDATE MangUser SET nobr = @upnobr, name_c = @name_c WHERE (nobr = @nobr)" OnInserting="SqlDataSource1_Inserting">
                    <DeleteParameters>
                        <asp:ControlParameter ControlID="GridView1" DefaultValue="nobr" Name="nobr" PropertyName="SelectedValue" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="upnobr" />
                        <asp:Parameter Name="name_c" />
                        <asp:Parameter Name="nobr" />
                       
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:ControlParameter ControlID="UserNobr" Name="nobr" PropertyName="Text" />
                        <asp:ControlParameter ControlID="Label2" Name="name_c" PropertyName="Text" />
                        <asp:ControlParameter ControlID="loginname" Name="name_c2" PropertyName="Text" />
                         <asp:ControlParameter ControlID="lb_pwd" Name="pwd" PropertyName="Text" />
                        
                    </InsertParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

