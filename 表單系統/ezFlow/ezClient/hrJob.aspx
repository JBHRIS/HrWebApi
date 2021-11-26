<%@ Page Language="C#" MasterPageFile="~/MasterPage_OnlyContent.master" AutoEventWireup="true" CodeFile="hrJob.aspx.cs" Inherits="hrJob" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:FormView ID="fv" runat="server" DataKeyNames="iAutoKey" DataSourceID="sdsFV"
                    DefaultMode="Insert" OnItemInserted="fv_ItemInserted" OnItemInserting="fv_ItemInserting"
                    OnItemUpdated="fv_ItemUpdated" OnItemUpdating="fv_ItemUpdating">
                    <EditItemTemplate>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="right" nowrap="nowrap">
                                    職稱代碼</td>
                                <td nowrap="nowrap">
                                    <asp:TextBox ID="sDeptmCodeTextBox" runat="server" Text='<%# Bind("sJobCode") %>'></asp:TextBox></td>
                                <td align="right" nowrap="nowrap">
                                    職稱名稱</td>
                                <td nowrap="nowrap">
                                    <asp:TextBox ID="sDeptmNameTextBox" runat="server" Text='<%# Bind("sJobName") %>'></asp:TextBox></td>
                                <td nowrap="nowrap" rowspan="4" width="1%">
                                    <asp:Button ID="btnY" runat="server" CommandName="Update" Text="修改" />
                                    <asp:Button ID="btnN" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Text="取消" /></td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap">
                                    職稱階層
                                </td>
                                <td nowrap="nowrap">
                                    <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("iJobOrder") %>'>
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td align="right" nowrap="nowrap">
                                </td>
                                <td nowrap="nowrap">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap">
                                    生效日</td>
                                <td nowrap="nowrap">
                                    <asp:TextBox ID="dDateATextBox" runat="server" Text='<%# Bind("dDateA", "{0:d}") %>'></asp:TextBox></td>
                                <td align="right" nowrap="nowrap">
                                    失效日</td>
                                <td nowrap="nowrap">
                                    <asp:TextBox ID="dDateDTextBox" runat="server" Text='<%# Bind("dDateD", "{0:d}") %>'></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap">
                                    登錄者</td>
                                <td nowrap="nowrap">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("sKeyMan") %>'></asp:Label></td>
                                <td align="right" nowrap="nowrap">
                                    登入日期</td>
                                <td nowrap="nowrap">
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("dKeyDate") %>'></asp:Label></td>
                            </tr>
                        </table>
                        <asp:Label ID="iAutoKeyLabel1" runat="server" Text='<%# Eval("iAutoKey") %>' Visible="False"></asp:Label>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="right" nowrap="nowrap">
                                    職稱代碼</td>
                                <td nowrap="nowrap">
                                    <asp:TextBox ID="sDeptmCodeTextBox" runat="server" Text='<%# Bind("sJobCode") %>'></asp:TextBox></td>
                                <td align="right" nowrap="nowrap">
                                    職稱名稱</td>
                                <td nowrap="nowrap">
                                    <asp:TextBox ID="sDeptmNameTextBox" runat="server" Text='<%# Bind("sJobName") %>'></asp:TextBox></td>
                                <td nowrap="nowrap" rowspan="3" width="1%">
                                    <asp:Button ID="btnY" runat="server" CommandName="Insert" Text="新增" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap">
                                    職稱階層</td>
                                <td nowrap="nowrap">
                                    <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("iJobOrder") %>'>
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td align="right" nowrap="nowrap">
                                </td>
                                <td nowrap="nowrap">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap">
                                    生效日</td>
                                <td nowrap="nowrap">
                                    <asp:TextBox ID="dDateATextBox" runat="server" Text='<%# Bind("dDateA") %>'></asp:TextBox></td>
                                <td align="right" nowrap="nowrap">
                                    失效日</td>
                                <td nowrap="nowrap">
                                    系統預設9999/12/31</td>
                            </tr>
                        </table>
                    </InsertItemTemplate>
                </asp:FormView>
                <asp:SqlDataSource ID="sdsFV" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>" InsertCommand="INSERT INTO [hrJob] ([sJobCode], [sJobName], [iJobOrder], [dDateA], [dDateD], [sKeyMan], [dKeyDate]) VALUES (@sJobCode, @sJobName, @iJobOrder, @dDateA, @dDateD, @sKeyMan, @dKeyDate)"
                    SelectCommand="SELECT * FROM [hrJob] WHERE ([iAutoKey] = @iAutoKey)" UpdateCommand="UPDATE [hrJob] SET [sJobCode] = @sJobCode, [sJobName] = @sJobName, [iJobOrder] = @iJobOrder, [dDateA] = @dDateA, [dDateD] = @dDateD, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="gv" Name="iAutoKey" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="sJobCode" Type="String" />
                        <asp:Parameter Name="sJobName" Type="String" />
                        <asp:Parameter Name="iJobOrder" Type="Int32" />
                        <asp:Parameter Name="dDateA" Type="DateTime" />
                        <asp:Parameter Name="dDateD" Type="DateTime" />
                        <asp:Parameter Name="sKeyMan" Type="String" />
                        <asp:Parameter Name="dKeyDate" Type="DateTime" />
                        <asp:Parameter Name="iAutoKey" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="sJobCode" Type="String" />
                        <asp:Parameter Name="sJobName" Type="String" />
                        <asp:Parameter Name="iJobOrder" Type="Int32" />
                        <asp:Parameter Name="dDateA" Type="DateTime" />
                        <asp:Parameter Name="dDateD" Type="DateTime" />
                        <asp:Parameter Name="sKeyMan" Type="String" />
                        <asp:Parameter Name="dKeyDate" Type="DateTime" />
                    </InsertParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gv" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    DataKeyNames="iAutoKey" DataSourceID="sdsGV" OnRowCommand="gv_RowCommand" OnRowDataBound="gv_RowDataBound"
                    OnRowDeleting="gv_RowDeleting" OnSelectedIndexChanged="gv_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <HeaderTemplate>
                                <asp:LinkButton ID="lbtnExport" runat="server" CommandName="ExportXLS" ForeColor="Blue">匯出</asp:LinkButton>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                    Text="選取"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                    OnClientClick="return confirm('您確定要刪除嗎？');" Text="刪除"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="sJobName" HeaderText="職稱名稱" SortExpression="sJobName" />
                        <asp:BoundField DataField="iJobOrder" HeaderText="職稱階層" SortExpression="iJobOrder" />
                        <asp:BoundField DataField="dDateA" DataFormatString="{0:d}" HeaderText="生效日" HtmlEncode="False"
                            SortExpression="dDateA" />
                        <asp:BoundField DataField="dDateD" DataFormatString="{0:d}" HeaderText="失效日" HtmlEncode="False"
                            SortExpression="dDateD" />
                        <asp:BoundField DataField="sKeyMan" HeaderText="登錄者" SortExpression="sKeyMan" />
                        <asp:BoundField DataField="dKeyDate" HeaderText="登錄日期" SortExpression="dKeyDate" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="sdsGV" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>"
                    DeleteCommand="DELETE FROM [hrJob] WHERE [iAutoKey] = @iAutoKey"
                    SelectCommand="SELECT * FROM [hrJob]">
                    <DeleteParameters>
                        <asp:Parameter Name="iAutoKey" Type="Int32" />
                    </DeleteParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

