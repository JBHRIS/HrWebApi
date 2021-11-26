<%@ Page Language="C#" MasterPageFile="~/MasterPage_OnlyContent.master" AutoEventWireup="true" CodeFile="hrHcode.aspx.cs" Inherits="hrHcode" Title="Untitled Page" %>
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
                    <asp:BoundField DataField="sHcodeName" HeaderText="假別" SortExpression="sHcodeName" />
                    <asp:BoundField DataField="iMin" HeaderText="最小時數" SortExpression="iMin" />
                    <asp:BoundField DataField="iMax" HeaderText="最大時數" SortExpression="iMax" />
                    <asp:BoundField DataField="iHeadway" HeaderText="間隔時數" SortExpression="iHeadway" />
                    <asp:BoundField DataField="sUnitCode" HeaderText="時數單位" SortExpression="sUnitCode" />
                    <asp:BoundField DataField="sInHoliday" HeaderText="假日計算" SortExpression="sInHoliday" />
                    <asp:BoundField DataField="sDisplaySelect" HeaderText="可選休假" SortExpression="sDisplaySelect" />
                    <asp:BoundField DataField="sGroupCode" HeaderText="群組" SortExpression="sGroupCode" />
                    <asp:BoundField DataField="sMath" HeaderText="加減項" SortExpression="sMath" />
                    <asp:BoundField DataField="sDisplayForm" HeaderText="請假資訊" SortExpression="sDisplayForm" />
                    <asp:BoundField DataField="sCheck" HeaderText="剩餘時數" SortExpression="sCheck" />
                    <asp:BoundField DataField="sSex" HeaderText="請假性別" SortExpression="sSex" />
                </Columns>
                <EmptyDataTemplate>
                    您尚未建立任何假別，請<asp:LinkButton ID="lbtnNew" runat="server" CommandName="New">按我</asp:LinkButton>新增。
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:SqlDataSource ID="sdsGV" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>"
                DeleteCommand="DELETE FROM [hrHcode] WHERE [iAutoKey] = @iAutoKey" SelectCommand="SELECT iAutoKey, sHcodeCode, sHcodeName, iMin, iMax, iHeadway, sUnitCode, bInHoliday, CASE bInHoliday WHEN '1' THEN '是' ELSE '否' END AS sInHoliday, bDisplaySelect, CASE bDisplaySelect WHEN '1' THEN '是' ELSE '否' END AS sDisplaySelect, sGroupCode, sMath, bDisplayForm, CASE bDisplayForm WHEN '1' THEN '顯示' ELSE '不顯示' END AS sDisplayForm, bCheck, CASE bCheck WHEN '1' THEN '檢查' ELSE '不檢查' END AS sCheck, bSex, CASE bsex WHEN '1' THEN '男' WHEN '0' THEN '女' ELSE '都可' END AS sSex, dDateA, dDateD, sKeyMan, dKeyDate FROM hrHcode">
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
                                假別代碼</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sHcodeCodeTextBox" runat="server" ReadOnly="True" Text='<%# Bind("sHcodeCode") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                假別名稱</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sHcodeNameTextBox" runat="server" Text='<%# Bind("sHcodeName") %>'></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                最小時數</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="iMinTextBox" runat="server" Text='<%# Bind("iMin") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                最大時數</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="iMaxTextBox" runat="server" Text='<%# Bind("iMax") %>'></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                間隔時數</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="iHeadwayTextBox" runat="server" Text='<%# Bind("iHeadway") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                時數單位</td>
                            <td nowrap="nowrap">
                                <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("sUnitCode") %>'>
                                    <asp:ListItem Selected="True" Value="1">小時</asp:ListItem>
                                    <asp:ListItem Value="2">天</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                群組代碼</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sGroupCodeTextBox" runat="server" Text='<%# Bind("sGroupCode") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                加減項</td>
                            <td nowrap="nowrap">
                                <asp:DropDownList ID="DropDownList2" runat="server" SelectedValue='<%# Bind("sMath") %>'>
                                    <asp:ListItem Selected="True" Value="-">減</asp:ListItem>
                                    <asp:ListItem Value="+">加</asp:ListItem>
                                </asp:DropDownList></td>
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
                                其它設定</td>
                            <td colspan="3" nowrap="nowrap">
                                <asp:CheckBox ID="bInHolidayCheckBox" runat="server" Checked='<%# Bind("bInHoliday") %>'
                                    Text="假日計算" />
                                <asp:CheckBox ID="bDisplaySelectCheckBox" runat="server" Checked='<%# Bind("bDisplaySelect") %>'
                                    Text="可選休假" />
                                <asp:CheckBox ID="bDisplayFormCheckBox" runat="server" Checked='<%# Bind("bDisplayForm") %>'
                                    Text="顯示請假資訊" />
                                <asp:CheckBox ID="bCheckCheckBox" runat="server" Checked='<%# Bind("bCheck") %>'
                                    Text="檢查剩餘時數" /></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                性別</td>
                            <td nowrap="nowrap">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                                    RepeatLayout="Flow" SelectedValue='<%# Bind("bSex") %>'>
                                    <asp:ListItem Value=" ">都可</asp:ListItem>
                                    <asp:ListItem Value="0">女</asp:ListItem>
                                    <asp:ListItem Value="1">男</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td align="right" nowrap="nowrap">
                            </td>
                            <td align="right" nowrap="nowrap">
                                &nbsp;</td>
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
                                <asp:Button ID="btnY" runat="server" CommandName="Update" Text="修改" />
                                <asp:Button ID="btnN" runat="server" CausesValidation="False" CommandName="Cancel"
                                    Text="取消" /></td>
                        </tr>
                    </table>
                    <asp:Label ID="iAutoKeyLabel1" runat="server" Text='<%# Eval("iAutoKey") %>' Visible="False"></asp:Label>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="right" nowrap="nowrap">
                                假別代碼</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sHcodeCodeTextBox" runat="server" Text='<%# Bind("sHcodeCode") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                假別名稱</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sHcodeNameTextBox" runat="server" Text='<%# Bind("sHcodeName") %>'></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                最小時數</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="iMinTextBox" runat="server" Text='<%# Bind("iMin") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                最大時數</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="iMaxTextBox" runat="server" Text='<%# Bind("iMax") %>'></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                間隔時數</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="iHeadwayTextBox" runat="server" Text='<%# Bind("iHeadway") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                時數單位</td>
                            <td nowrap="nowrap">
                                <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("sUnitCode") %>'>
                                    <asp:ListItem Selected="True" Value="1">小時</asp:ListItem>
                                    <asp:ListItem Value="2">天</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                群組代碼</td>
                            <td nowrap="nowrap">
                                系統預設0</td>
                            <td align="right" nowrap="nowrap">
                                加減項</td>
                            <td nowrap="nowrap">
                                <asp:DropDownList ID="DropDownList2" runat="server" SelectedValue='<%# Bind("sMath") %>'>
                                    <asp:ListItem Selected="True" Value="-">減</asp:ListItem>
                                    <asp:ListItem Value="+">加</asp:ListItem>
                                </asp:DropDownList></td>
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
                        <tr>
                            <td align="right" nowrap="nowrap">
                                其它設定</td>
                            <td colspan="3" nowrap="nowrap">
                                <asp:CheckBox ID="bInHolidayCheckBox" runat="server" Checked='<%# Bind("bInHoliday") %>'
                                    Text="假日計算" />
                                <asp:CheckBox ID="bDisplaySelectCheckBox" runat="server" Checked='<%# Bind("bDisplaySelect") %>'
                                    Text="可選休假" />
                                <asp:CheckBox ID="bDisplayFormCheckBox" runat="server" Checked='<%# Bind("bDisplayForm") %>'
                                    Text="顯示請假資訊" />
                                <asp:CheckBox ID="bCheckCheckBox" runat="server" Checked='<%# Bind("bCheck") %>'
                                    Text="檢查剩餘時數" /></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                性別</td>
                            <td nowrap="nowrap">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                                    RepeatLayout="Flow" SelectedValue='<%# Bind("bSex") %>'>
                                    <asp:ListItem Selected="True" Value=" ">都可</asp:ListItem>
                                    <asp:ListItem Value="0">女</asp:ListItem>
                                    <asp:ListItem Value="1">男</asp:ListItem>
                                </asp:RadioButtonList></td>
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
                DeleteCommand="DELETE FROM [hrHcode] WHERE [iAutoKey] = @iAutoKey" InsertCommand="INSERT INTO [hrHcode] ([sHcodeCode], [sHcodeName], [iMin], [iMax], [iHeadway], [sUnitCode], [bInHoliday], [bDisplaySelect], [sGroupCode], [sMath], [bDisplayForm], [bCheck], [bSex], [dDateA], [dDateD], [sKeyMan], [dKeyDate]) VALUES (@sHcodeCode, @sHcodeName, @iMin, @iMax, @iHeadway, @sUnitCode, @bInHoliday, @bDisplaySelect, @sGroupCode, @sMath, @bDisplayForm, @bCheck, @bSex, @dDateA, @dDateD, @sKeyMan, @dKeyDate)"
                SelectCommand="SELECT iAutoKey, sHcodeCode, sHcodeName, iMin, iMax, iHeadway, sUnitCode, bInHoliday, bDisplaySelect, sGroupCode, sMath, bDisplayForm, bCheck, CASE bSex WHEN '1' THEN '1' WHEN '0' THEN '0' ELSE ' ' END AS bSex, dDateA, dDateD, sKeyMan, dKeyDate FROM hrHcode WHERE (iAutoKey = @iAutoKey)"
                UpdateCommand="UPDATE [hrHcode] SET [sHcodeCode] = @sHcodeCode, [sHcodeName] = @sHcodeName, [iMin] = @iMin, [iMax] = @iMax, [iHeadway] = @iHeadway, [sUnitCode] = @sUnitCode, [bInHoliday] = @bInHoliday, [bDisplaySelect] = @bDisplaySelect, [sGroupCode] = @sGroupCode, [sMath] = @sMath, [bDisplayForm] = @bDisplayForm, [bCheck] = @bCheck, [bSex] = @bSex, [dDateA] = @dDateA, [dDateD] = @dDateD, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
                <SelectParameters>
                    <asp:ControlParameter ControlID="gv" Name="iAutoKey" PropertyName="SelectedValue"
                        Type="Int32" />
                </SelectParameters>
                <DeleteParameters>
                    <asp:Parameter Name="iAutoKey" Type="Int32" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="sHcodeCode" Type="String" />
                    <asp:Parameter Name="sHcodeName" Type="String" />
                    <asp:Parameter Name="iMin" Type="Decimal" />
                    <asp:Parameter Name="iMax" Type="Decimal" />
                    <asp:Parameter Name="iHeadway" Type="Decimal" />
                    <asp:Parameter Name="sUnitCode" Type="String" />
                    <asp:Parameter Name="bInHoliday" Type="Boolean" />
                    <asp:Parameter Name="bDisplaySelect" Type="Boolean" />
                    <asp:Parameter Name="sGroupCode" Type="String" />
                    <asp:Parameter Name="sMath" Type="String" />
                    <asp:Parameter Name="bDisplayForm" Type="Boolean" />
                    <asp:Parameter Name="bCheck" Type="Boolean" />
                    <asp:Parameter Name="bSex" Type="Boolean" />
                    <asp:Parameter Name="dDateA" Type="DateTime" />
                    <asp:Parameter Name="dDateD" Type="DateTime" />
                    <asp:Parameter Name="sKeyMan" Type="String" />
                    <asp:Parameter Name="dKeyDate" Type="DateTime" />
                    <asp:Parameter Name="iAutoKey" Type="Int32" />
                </UpdateParameters>
                <InsertParameters>
                    <asp:Parameter Name="sHcodeCode" Type="String" />
                    <asp:Parameter Name="sHcodeName" Type="String" />
                    <asp:Parameter Name="iMin" Type="Decimal" />
                    <asp:Parameter Name="iMax" Type="Decimal" />
                    <asp:Parameter Name="iHeadway" Type="Decimal" />
                    <asp:Parameter Name="sUnitCode" Type="String" />
                    <asp:Parameter Name="bInHoliday" Type="Boolean" />
                    <asp:Parameter Name="bDisplaySelect" Type="Boolean" />
                    <asp:Parameter Name="sGroupCode" Type="String" />
                    <asp:Parameter Name="sMath" Type="String" />
                    <asp:Parameter Name="bDisplayForm" Type="Boolean" />
                    <asp:Parameter Name="bCheck" Type="Boolean" />
                    <asp:Parameter Name="bSex" Type="Boolean" />
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

