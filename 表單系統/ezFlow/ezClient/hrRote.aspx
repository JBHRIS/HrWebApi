<%@ Page Language="C#" MasterPageFile="~/MasterPage_OnlyContent.master" AutoEventWireup="true" CodeFile="hrRote.aspx.cs" Inherits="hrRote" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:MultiView ID="mv" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <asp:GridView ID="gv" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                DataKeyNames="iAutoKey" DataSourceID="sdsGV" OnRowCommand="gv_RowCommand" OnRowDataBound="gv_RowDataBound"
                OnRowDeleting="gv_RowDeleting" OnSelectedIndexChanged="gv_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <HeaderTemplate>
                            <asp:LinkButton ID="lbtnNew" runat="server" CommandName="New" ForeColor="Blue">新增</asp:LinkButton>
                            <asp:LinkButton ID="lbtnExport" runat="server" CommandName="ExportXLS" ForeColor="Blue">匯出</asp:LinkButton>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                Text="選取"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                OnClientClick="return confirm('您確定要刪除嗎？');" Text="刪除"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="sRoteName" HeaderText="班別名稱" SortExpression="sRoteName" />
                    <asp:BoundField DataField="sWorkTimeB" HeaderText="工作開始時間" SortExpression="sWorkTimeB" />
                    <asp:BoundField DataField="sWorkTimeE" HeaderText="工作結束時間" SortExpression="sWorkTimeE" />
                    <asp:BoundField DataField="sRes1TimeB" HeaderText="休息開始時間1" SortExpression="sRes1TimeB" />
                    <asp:BoundField DataField="sRes1TimeE" HeaderText="休息時束時間1" SortExpression="sRes1TimeE" />
                    <asp:BoundField DataField="sRes2TimeB" HeaderText="休息開始時間2" SortExpression="sRes2TimeB" />
                    <asp:BoundField DataField="sRes2TimeE" HeaderText="休息時束時間2" SortExpression="sRes2TimeE" />
                    <asp:BoundField DataField="iWorkHour" HeaderText="工作時數" SortExpression="iWorkHour" />
                    <asp:BoundField DataField="sHalf" HeaderText="半天班" SortExpression="sHalf" />
                </Columns>
                <EmptyDataTemplate>
                    您尚未建立任何假別，請<asp:LinkButton ID="lbtnNew" runat="server" CommandName="New">按我</asp:LinkButton>新增。
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:SqlDataSource ID="sdsGV" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>"
                DeleteCommand="DELETE FROM [hrRote] WHERE [iAutoKey] = @iAutoKey" SelectCommand="SELECT iAutoKey, sRoteCode, sRoteName, sWorkTimeB, sWorkTimeE, sRes1TimeB, sRes1TimeE, sRes2TimeB, sRes2TimeE, iWorkHour, bHalf, CASE bHalf WHEN '1' THEN '是' ELSE '否' END AS sHalf, dDateA, dDateD, sKeyMan, dKeyDate FROM hrRote">
                <DeleteParameters>
                    <asp:Parameter Name="iAutoKey" Type="Int32" />
                </DeleteParameters>
            </asp:SqlDataSource>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <asp:FormView ID="fv" runat="server" DataKeyNames="iAutoKey" DataSourceID="sdsFV"
                OnItemCommand="fv_ItemCommand" OnItemInserted="fv_ItemInserted" OnItemInserting="fv_ItemInserting"
                OnItemUpdated="fv_ItemUpdated" OnItemUpdating="fv_ItemUpdating">
                <EditItemTemplate>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="right" nowrap="nowrap">
                                班別代碼</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sRoteCodeTextBox" runat="server" ReadOnly="True" Text='<%# Bind("sRoteCode") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                班別名稱</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sRoteNameTextBox" runat="server" Text='<%# Bind("sRoteName") %>'></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                工作開始時間</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sWorkTimeBTextBox" runat="server" MaxLength="4" Text='<%# Bind("sWorkTimeB") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                工作結束時間</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sWorkTimeETextBox" runat="server" MaxLength="4" Text='<%# Bind("sWorkTimeE") %>'></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                休息開始時間1</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sRes1TimeBTextBox" runat="server" MaxLength="4" Text='<%# Bind("sRes1TimeB") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                休息結束時間1</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sRes1TimeETextBox" runat="server" MaxLength="4" Text='<%# Bind("sRes1TimeE") %>'></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                休息開始時間2</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sRes2TimeBTextBox" runat="server" MaxLength="4" Text='<%# Bind("sRes2TimeB") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                休息結束時間2</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sRes2TimeETextBox" runat="server" MaxLength="4" Text='<%# Bind("sRes2TimeE") %>'></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                工作時數</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="iWorkHourTextBox" runat="server" Text='<%# Bind("iWorkHour") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                <asp:CheckBox ID="bHalfCheckBox" runat="server" Checked='<%# Bind("bHalf") %>' Text="半天班" /></td>
                            <td nowrap="nowrap">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                生效日</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("dDateA", "{0:d}") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                失效日</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("dDateD", "{0:d}") %>'></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap" style="height: 16px">
                                登錄者</td>
                            <td nowrap="nowrap" style="height: 16px">
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("sKeyMan") %>'></asp:Label></td>
                            <td align="right" nowrap="nowrap" style="height: 16px">
                                登錄日期</td>
                            <td nowrap="nowrap" style="height: 16px">
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("dKeyDate") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                            </td>
                            <td nowrap="nowrap">
                            </td>
                            <td nowrap="nowrap">
                            </td>
                            <td align="right" nowrap="nowrap">
                                <asp:Button ID="btnY" runat="server" CommandName="Update" Text="修改" />&nbsp;<asp:Button
                                    ID="btnN" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" /></td>
                        </tr>
                    </table>
                    <asp:Label ID="iAutoKeyLabel1" runat="server" Text='<%# Eval("iAutoKey") %>' Visible="False"></asp:Label>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="right" nowrap="nowrap">
                                班別代碼</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sRoteCodeTextBox" runat="server" Text='<%# Bind("sRoteCode") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                班別名稱</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sRoteNameTextBox" runat="server" Text='<%# Bind("sRoteName") %>'></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                工作開始時間</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sWorkTimeBTextBox" runat="server" MaxLength="4" Text='<%# Bind("sWorkTimeB") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                工作結束時間</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sWorkTimeETextBox" runat="server" MaxLength="4" Text='<%# Bind("sWorkTimeE") %>'></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                休息開始時間1</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sRes1TimeBTextBox" runat="server" MaxLength="4" Text='<%# Bind("sRes1TimeB") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                休息結束時間1</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sRes1TimeETextBox" runat="server" MaxLength="4" Text='<%# Bind("sRes1TimeE") %>'></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                休息開始時間2</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sRes2TimeBTextBox" runat="server" MaxLength="4" Text='<%# Bind("sRes2TimeB") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                休息結束時間2</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sRes2TimeETextBox" runat="server" MaxLength="4" Text='<%# Bind("sRes2TimeE") %>'></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                工作時數</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="iWorkHourTextBox" runat="server" Text='<%# Bind("iWorkHour") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                <asp:CheckBox ID="bHalfCheckBox" runat="server" Checked='<%# Bind("bHalf") %>' Text="半天班" /></td>
                            <td nowrap="nowrap">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                生效日</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("dDateA") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                失效日</td>
                            <td nowrap="nowrap">
                                系統預設9999/12/31</td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                            </td>
                            <td nowrap="nowrap">
                            </td>
                            <td nowrap="nowrap">
                            </td>
                            <td align="right" nowrap="nowrap">
                                <asp:Button ID="btnY" runat="server" CommandName="Insert" Text="新增" />&nbsp;<asp:Button
                                    ID="btnN" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" /></td>
                        </tr>
                    </table>
                </InsertItemTemplate>
            </asp:FormView>
            <asp:SqlDataSource ID="sdsFV" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>"
                InsertCommand="INSERT INTO [hrRote] ([sRoteCode], [sRoteName], [sWorkTimeB], [sWorkTimeE], [sRes1TimeB], [sRes1TimeE], [sRes2TimeB], [sRes2TimeE], [iWorkHour], [bHalf], [dDateA], [dDateD], [sKeyMan], [dKeyDate]) VALUES (@sRoteCode, @sRoteName, @sWorkTimeB, @sWorkTimeE, @sRes1TimeB, @sRes1TimeE, @sRes2TimeB, @sRes2TimeE, @iWorkHour, @bHalf, @dDateA, @dDateD, @sKeyMan, @dKeyDate)"
                SelectCommand="SELECT * FROM [hrRote] WHERE ([iAutoKey] = @iAutoKey)" UpdateCommand="UPDATE [hrRote] SET [sRoteCode] = @sRoteCode, [sRoteName] = @sRoteName, [sWorkTimeB] = @sWorkTimeB, [sWorkTimeE] = @sWorkTimeE, [sRes1TimeB] = @sRes1TimeB, [sRes1TimeE] = @sRes1TimeE, [sRes2TimeB] = @sRes2TimeB, [sRes2TimeE] = @sRes2TimeE, [iWorkHour] = @iWorkHour, [bHalf] = @bHalf, [dDateA] = @dDateA, [dDateD] = @dDateD, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
                <SelectParameters>
                    <asp:ControlParameter ControlID="gv" Name="iAutoKey" PropertyName="SelectedValue"
                        Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="sRoteCode" Type="String" />
                    <asp:Parameter Name="sRoteName" Type="String" />
                    <asp:Parameter Name="sWorkTimeB" Type="String" />
                    <asp:Parameter Name="sWorkTimeE" Type="String" />
                    <asp:Parameter Name="sRes1TimeB" Type="String" />
                    <asp:Parameter Name="sRes1TimeE" Type="String" />
                    <asp:Parameter Name="sRes2TimeB" Type="String" />
                    <asp:Parameter Name="sRes2TimeE" Type="String" />
                    <asp:Parameter Name="iWorkHour" Type="Decimal" />
                    <asp:Parameter Name="bHalf" Type="Boolean" />
                    <asp:Parameter Name="dDateA" Type="DateTime" />
                    <asp:Parameter Name="dDateD" Type="DateTime" />
                    <asp:Parameter Name="sKeyMan" Type="String" />
                    <asp:Parameter Name="dKeyDate" Type="DateTime" />
                    <asp:Parameter Name="iAutoKey" Type="Int32" />
                </UpdateParameters>
                <InsertParameters>
                    <asp:Parameter Name="sRoteCode" Type="String" />
                    <asp:Parameter Name="sRoteName" Type="String" />
                    <asp:Parameter Name="sWorkTimeB" Type="String" />
                    <asp:Parameter Name="sWorkTimeE" Type="String" />
                    <asp:Parameter Name="sRes1TimeB" Type="String" />
                    <asp:Parameter Name="sRes1TimeE" Type="String" />
                    <asp:Parameter Name="sRes2TimeB" Type="String" />
                    <asp:Parameter Name="sRes2TimeE" Type="String" />
                    <asp:Parameter Name="iWorkHour" Type="Decimal" />
                    <asp:Parameter Name="bHalf" Type="Boolean" />
                    <asp:Parameter Name="dDateA" Type="DateTime" />
                    <asp:Parameter Name="dDateD" Type="DateTime" />
                    <asp:Parameter Name="sKeyMan" Type="String" />
                    <asp:Parameter Name="dKeyDate" Type="DateTime" />
                </InsertParameters>
            </asp:SqlDataSource>
        </asp:View>
    </asp:MultiView>
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>

