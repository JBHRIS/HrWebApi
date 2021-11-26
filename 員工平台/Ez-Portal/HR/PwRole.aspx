<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="PwRole.aspx.cs" Inherits="HR_PwRole" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td valign="top">
                <h3>
                    <asp:Localize ID="Localize1" runat="server">E-Portal帳號密碼原則</asp:Localize>
                </h3>
                <fieldset>
                    <legend>資料</legend>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <br />
                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                        DataSourceID="SqlDataSource1" OnRowDataBound="gv_RowDataBound" OnRowUpdating="gv_RowUpdating"
                        Width="100%" SkinID="Yahoo">
                        <RowStyle HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="更新" Width="50px" />
                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Text="取消" Width="50px" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="編輯" Width="50px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="sName" HeaderText="說明" ReadOnly="True" SortExpression="sName" />
                            <asp:TemplateField HeaderText="值" SortExpression="sValue">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtValue" runat="server" Text='<%# Bind("sValue") %>' ToolTip='<%# Eval("sType") %>'
                                        Visible="False"></asp:TextBox><asp:CheckBox ID="cbValue" runat="server" Visible="False" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    &nbsp;<asp:TextBox ID="txtValue" runat="server" Enabled="False" Text='<%# Bind("sValue") %>'
                                        ToolTip='<%# Eval("sType") %>' Visible="False"></asp:TextBox><asp:CheckBox ID="cbValue"
                                            runat="server" Enabled="False" Visible="False" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="dKeyDate" HeaderText="修改日期" ReadOnly="True" SortExpression="dKeyDate" />
                        </Columns>
                    </asp:GridView>
                </fieldset>
                <asp:Label ID="lb_nobr" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="loginname" runat="server" Text="Label" Visible="False"></asp:Label>&nbsp;
                <br />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                    SelectCommand="SELECT sName, sKey, sValue, sType, iOrder, iAutoKey, dKeyDate, sKeyMan FROM sysDefault WHERE (sCategory = 'sysLoginUser') and  skey in ('iDayChange','iDayChange','iPwLen','bFirstChange','iPwChange')"
                    UpdateCommand="UPDATE sysDefault SET sValue = @svalue, sKeyMan = @keyman, dKeyDate = GETDATE() where sCategory = 'sysLoginUser' and iAutokey=@iAutokey">
                    <UpdateParameters>
                        <asp:ControlParameter ControlID="loginname" Name="keyman" PropertyName="Text" />
                        <asp:Parameter Name="iAutokey" />
                        <asp:Parameter Name="svalue" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
