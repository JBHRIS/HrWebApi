<%@ Page Language="C#" MasterPageFile="~/MasterPage_OnlyContent.master" AutoEventWireup="true" CodeFile="hrAbs.aspx.cs" Inherits="hrAbs" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:MultiView ID="mv" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td nowrap="nowrap">
                        <asp:DropDownList ID="ddlBase" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                            DataSourceID="sdsBase" DataTextField="sName" DataValueField="sNobr">
                            <asp:ListItem Value="a">姓名請選擇</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlHcode" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                            DataSourceID="sdsHcode" DataTextField="sHcodeName" DataValueField="sHcodeCode">
                            <asp:ListItem Value="a">假別請選擇</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="sdsBase" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>"
                            SelectCommand="SELECT sNobr, sName FROM hrBaseM WHERE (GETDATE() BETWEEN dDateA AND dDateD) ORDER BY sNobr">
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="sdsHcode" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>"
                            SelectCommand="SELECT [sHcodeCode], [sHcodeName] FROM [hrHcode]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        <asp:GridView ID="gv" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                            DataKeyNames="iAutoKey" DataSourceID="sdsGV" OnRowCommand="gv_RowCommand" OnRowDataBound="gv_RowDataBound"
                            OnRowDeleting="gv_RowDeleting" OnSelectedIndexChanged="gv_SelectedIndexChanged"
                            PageSize="20">
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
                                <asp:BoundField DataField="sSn" HeaderText="單號" SortExpression="sSn" />
                                <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                                <asp:BoundField DataField="dDatetimeB" HeaderText="開始日期時間" SortExpression="dDatetimeB" />
                                <asp:BoundField DataField="dDatetimeE" HeaderText="結束日期時間" SortExpression="dDatetimeE" />
                                <asp:BoundField DataField="sHcodeName" HeaderText="假別名稱" SortExpression="sHcodeName" />
                                <asp:BoundField DataField="iHour" HeaderText="請假時數" SortExpression="iHour" />
                                <asp:BoundField DataField="sUnitCode" HeaderText="請假單位" SortExpression="sUnitCode" />
                            </Columns>
                            <EmptyDataTemplate>
                                您尚未建立任何假別，請<asp:LinkButton ID="lbtnNew" runat="server" CommandName="New">按我</asp:LinkButton>新增。
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <asp:SqlDataSource ID="sdsGV" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>"
                            DeleteCommand="DELETE FROM [hrAbs] WHERE [iAutoKey] = @iAutoKey" SelectCommand="SELECT hrAbs.iAutoKey, hrAbs.sSn, hrAbs.sNobr, hrAbs.dDateB, hrAbs.dDateE, hrAbs.sTimeB, hrAbs.sTimeE, hrAbs.dDatetimeB, hrAbs.dDatetimeE, hrAbs.sHcodeCode, hrAbs.iHour, hrAbs.sYYMM, hrAbs.sNote, hrAbs.sKeyMan, hrAbs.dKeyDate, hrBaseM.sName, hrHcode.sHcodeName, CASE hrHcode.sUnitCode WHEN '1' THEN '小時' ELSE '天' END AS sUnitCode FROM hrAbs INNER JOIN hrBaseM ON hrAbs.sNobr = hrBaseM.sNobr INNER JOIN hrHcode ON hrAbs.sHcodeCode = hrHcode.sHcodeCode WHERE (hrAbs.sNobr = @sNobr) AND (hrAbs.sHcodeCode = @sHcodeCode) OR (hrAbs.sNobr = @sNobr) AND (@sHcodeCode = 'a') OR (@sNobr = 'a') AND (hrAbs.sHcodeCode = @sHcodeCode) OR (@sNobr = 'a') AND (@sHcodeCode = 'a')">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlBase" DefaultValue="a" Name="sNobr" PropertyName="SelectedValue" />
                                <asp:ControlParameter ControlID="ddlHcode" DefaultValue="a" Name="sHcodeCode" PropertyName="SelectedValue" />
                            </SelectParameters>
                            <DeleteParameters>
                                <asp:Parameter Name="iAutoKey" Type="Int32" />
                            </DeleteParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <asp:FormView ID="fv" runat="server" DataKeyNames="iAutoKey" DataSourceID="sdsFV"
                OnItemCommand="fv_ItemCommand" OnItemInserted="fv_ItemInserted" OnItemInserting="fv_ItemInserting"
                OnItemUpdated="fv_ItemUpdated" OnItemUpdating="fv_ItemUpdating">
                <EditItemTemplate>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="right" nowrap="nowrap">
                                單號</td>
                            <td nowrap="nowrap">
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("sSn") %>'></asp:Label></td>
                            <td align="right" nowrap="nowrap">
                                工號</td>
                            <td nowrap="nowrap">
                                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="sdsBase" DataTextField="sName"
                                    DataValueField="sNobr" Enabled="False" SelectedValue='<%# Bind("sNobr") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="sdsBase" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>"
                                    SelectCommand="SELECT sNobr, sName FROM hrBaseM WHERE (GETDATE() BETWEEN dDateA AND dDateD) ORDER BY sNobr">
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                開始日期</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="dDateBTextBox" runat="server" Text='<%# Bind("dDateB", "{0:d}") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                結束日期</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="dDateETextBox" runat="server" Text='<%# Bind("dDateE", "{0:d}") %>'></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                開始時間</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sTimeBTextBox" runat="server" Text='<%# Bind("sTimeB") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                結束時間</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sTimeETextBox" runat="server" Text='<%# Bind("sTimeE") %>'></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                假別</td>
                            <td nowrap="nowrap">
                                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="sdsHcode" DataTextField="sHcodeName"
                                    DataValueField="sHcodeCode" SelectedValue='<%# Bind("sHcodeCode") %>'>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="sdsHcode" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>"
                                    SelectCommand="SELECT sHcodeCode, sHcodeName FROM hrHcode WHERE (GETDATE() BETWEEN dDateA AND dDateD) ORDER BY sHcodeCode">
                                </asp:SqlDataSource>
                            </td>
                            <td align="right" nowrap="nowrap">
                                請假時數</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="iHourTextBox" runat="server" Text='<%# Bind("iHour") %>'></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                備註</td>
                            <td colspan="3" nowrap="nowrap">
                                <asp:TextBox ID="sNoteTextBox" runat="server" Text='<%# Bind("sNote") %>' Width="100%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                登錄者</td>
                            <td nowrap="nowrap">
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("sKeyMan") %>'></asp:Label></td>
                            <td align="right" nowrap="nowrap">
                                登錄日期</td>
                            <td nowrap="nowrap">
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("dKeyDate") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                            </td>
                            <td nowrap="nowrap">
                            </td>
                            <td align="right" nowrap="nowrap">
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
                                單號</td>
                            <td nowrap="nowrap">
                                系統產生</td>
                            <td align="right" nowrap="nowrap">
                                工號</td>
                            <td nowrap="nowrap">
                                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="sdsBase" DataTextField="sName"
                                    DataValueField="sNobr" SelectedValue='<%# Bind("sNobr") %>'>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="sdsBase" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>"
                                    SelectCommand="SELECT sNobr, sName FROM hrBaseM WHERE (GETDATE() BETWEEN dDateA AND dDateD) ORDER BY sNobr">
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                開始日期</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="dDateBTextBox" runat="server" Text='<%# Bind("dDateB") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                結束日期</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="dDateETextBox" runat="server" Text='<%# Bind("dDateE") %>'></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                開始時間</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sTimeBTextBox" runat="server" Text='<%# Bind("sTimeB") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                結束時間</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sTimeETextBox" runat="server" Text='<%# Bind("sTimeE") %>'></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                假別</td>
                            <td nowrap="nowrap">
                                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="sdsHcode" DataTextField="sHcodeName"
                                    DataValueField="sHcodeCode" SelectedValue='<%# Bind("sHcodeCode") %>'>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="sdsHcode" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>"
                                    SelectCommand="SELECT sHcodeCode, sHcodeName FROM hrHcode WHERE (GETDATE() BETWEEN dDateA AND dDateD) ORDER BY sHcodeCode">
                                </asp:SqlDataSource>
                            </td>
                            <td align="right" nowrap="nowrap">
                                請假時數</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="iHourTextBox" runat="server" Text='<%# Bind("iHour") %>'></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                備註</td>
                            <td colspan="3" nowrap="nowrap">
                                <asp:TextBox ID="sNoteTextBox" runat="server" Text='<%# Bind("sNote") %>' Width="100%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                            </td>
                            <td nowrap="nowrap">
                            </td>
                            <td align="right" nowrap="nowrap">
                            </td>
                            <td align="right" nowrap="nowrap">
                                <asp:Button ID="btnY" runat="server" CommandName="Insert" Text="新增" />&nbsp;<asp:Button
                                    ID="btnN" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" /></td>
                        </tr>
                    </table>
                </InsertItemTemplate>
            </asp:FormView>
            <asp:SqlDataSource ID="sdsFV" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>"
                DeleteCommand="DELETE FROM [hrAbs] WHERE [iAutoKey] = @iAutoKey" InsertCommand="INSERT INTO [hrAbs] ([sSn], [sNobr], [dDateB], [dDateE], [sTimeB], [sTimeE], [dDatetimeB], [dDatetimeE], [sHcodeCode], [iHour], [sYYMM], [sNote], [sKeyMan], [dKeyDate]) VALUES (@sSn, @sNobr, @dDateB, @dDateE, @sTimeB, @sTimeE, @dDatetimeB, @dDatetimeE, @sHcodeCode, @iHour, @sYYMM, @sNote, @sKeyMan, @dKeyDate)"
                SelectCommand="SELECT * FROM [hrAbs] WHERE ([iAutoKey] = @iAutoKey)" UpdateCommand="UPDATE [hrAbs] SET [sSn] = @sSn, [sNobr] = @sNobr, [dDateB] = @dDateB, [dDateE] = @dDateE, [sTimeB] = @sTimeB, [sTimeE] = @sTimeE, [dDatetimeB] = @dDatetimeB, [dDatetimeE] = @dDatetimeE, [sHcodeCode] = @sHcodeCode, [iHour] = @iHour, [sYYMM] = @sYYMM, [sNote] = @sNote, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
                <SelectParameters>
                    <asp:ControlParameter ControlID="gv" Name="iAutoKey" PropertyName="SelectedValue"
                        Type="Int32" />
                </SelectParameters>
                <DeleteParameters>
                    <asp:Parameter Name="iAutoKey" Type="Int32" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="sSn" Type="String" />
                    <asp:Parameter Name="sNobr" Type="String" />
                    <asp:Parameter Name="dDateB" Type="DateTime" />
                    <asp:Parameter Name="dDateE" Type="DateTime" />
                    <asp:Parameter Name="sTimeB" Type="String" />
                    <asp:Parameter Name="sTimeE" Type="String" />
                    <asp:Parameter Name="dDatetimeB" Type="DateTime" />
                    <asp:Parameter Name="dDatetimeE" Type="DateTime" />
                    <asp:Parameter Name="sHcodeCode" Type="String" />
                    <asp:Parameter Name="iHour" Type="Decimal" />
                    <asp:Parameter Name="sYYMM" Type="String" />
                    <asp:Parameter Name="sNote" Type="String" />
                    <asp:Parameter Name="sKeyMan" Type="String" />
                    <asp:Parameter Name="dKeyDate" Type="DateTime" />
                    <asp:Parameter Name="iAutoKey" Type="Int32" />
                </UpdateParameters>
                <InsertParameters>
                    <asp:Parameter Name="sSn" Type="String" />
                    <asp:Parameter Name="sNobr" Type="String" />
                    <asp:Parameter Name="dDateB" Type="DateTime" />
                    <asp:Parameter Name="dDateE" Type="DateTime" />
                    <asp:Parameter Name="sTimeB" Type="String" />
                    <asp:Parameter Name="sTimeE" Type="String" />
                    <asp:Parameter Name="dDatetimeB" Type="DateTime" />
                    <asp:Parameter Name="dDatetimeE" Type="DateTime" />
                    <asp:Parameter Name="sHcodeCode" Type="String" />
                    <asp:Parameter Name="iHour" Type="Decimal" />
                    <asp:Parameter Name="sYYMM" Type="String" />
                    <asp:Parameter Name="sNote" Type="String" />
                    <asp:Parameter Name="sKeyMan" Type="String" />
                    <asp:Parameter Name="dKeyDate" Type="DateTime" />
                </InsertParameters>
            </asp:SqlDataSource>
        </asp:View>
    </asp:MultiView>
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>

