<%@ Page Language="C#" MasterPageFile="~/MasterPage_OnlyContent.master" AutoEventWireup="true" CodeFile="hrBase.aspx.cs" Inherits="hrBase" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:MultiView ID="mv" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <asp:GridView ID="gvBase" runat="server" AutoGenerateColumns="False" DataSourceID="sdsGV" AllowSorting="True" DataKeyNames="iAutoKey" OnRowCommand="gvBase_RowCommand" OnRowDataBound="gvBase_RowDataBound" OnRowDeleting="gvBase_RowDeleting" OnSelectedIndexChanged="gvBase_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <HeaderTemplate>
                            <asp:LinkButton ID="lbtnNew" runat="server" ForeColor="Blue" CommandName="New">新增</asp:LinkButton>
                            <asp:LinkButton ID="lbtnExport" runat="server" ForeColor="Blue" CommandName="ExportXLS">匯出</asp:LinkButton>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                Text="選取"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                Text="刪除" OnClientClick="return confirm('您確定要刪除嗎？');"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                    <asp:BoundField DataField="sLoginID" HeaderText="帳號" SortExpression="sLoginID" />
                    <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                    <asp:BoundField DataField="sDeptmName" HeaderText="部門" SortExpression="sDeptmName" />
                    <asp:BoundField DataField="sJobName" HeaderText="職稱" SortExpression="sJobName" />
                    <asp:BoundField DataField="sRoteName" HeaderText="班別" SortExpression="sRoteName" />
                    <asp:BoundField DataField="dDateA" DataFormatString="{0:d}" HeaderText="到職日" HtmlEncode="False"
                        SortExpression="dDateA" />
                    <asp:BoundField DataField="sSex" HeaderText="性別" SortExpression="sSex" />
                    <asp:BoundField DataField="sMang" HeaderText="主管" SortExpression="sMang" />
                </Columns>
                <EmptyDataTemplate>
                    您尚未建立任何名單，請<asp:LinkButton ID="lbtnNew" runat="server" CommandName="New">按我</asp:LinkButton>新增。
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:SqlDataSource ID="sdsGV" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>"
                DeleteCommand="DELETE FROM [hrBaseM] WHERE [iAutoKey] = @iAutoKey"
                SelectCommand="SELECT hrBaseM.iAutoKey, hrBaseM.sNobr, hrBaseM.sName, hrBaseM.sDeptCode, hrBaseM.sDeptsCode, hrBaseM.sDeptmCode, hrBaseM.sJobCode, hrBaseM.sJoblCode, hrBaseM.sRoteCode, hrBaseM.dDateA, hrBaseM.dDateD, hrBaseM.bSex, CASE hrBaseM.bSex WHEN '1' THEN '男' ELSE '女' END AS sSex, hrBaseM.sLoginID, hrBaseM.sLoginPW, hrBaseM.sEmail, hrBaseM.sNote, hrBaseM.sReserve1, hrBaseM.sReserve2, hrBaseM.sReserve3, hrBaseM.sReserve4, hrBaseM.sReserve5, hrBaseM.bMang, CASE hrBaseM.bMang WHEN '1' THEN '是' ELSE '否' END AS sMang, hrBaseM.sKeyMan, hrBaseM.dKeyDate, hrDeptm.sDeptmName, hrJob.sJobName, hrRote.sRoteName FROM hrBaseM INNER JOIN hrDeptm ON hrBaseM.sDeptmCode = hrDeptm.sDeptmCode INNER JOIN hrJob ON hrBaseM.sJobCode = hrJob.sJobCode INNER JOIN hrRote ON hrBaseM.sRoteCode = hrRote.sRoteCode">
                <DeleteParameters>
                    <asp:Parameter Name="iAutoKey" Type="Int32" />
                </DeleteParameters>
            </asp:SqlDataSource>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <asp:FormView ID="fvBase" runat="server" DataKeyNames="iAutoKey" DataSourceID="sdsFV" OnItemCommand="fvBase_ItemCommand" OnItemInserted="fvBase_ItemInserted" OnItemInserting="fvBase_ItemInserting" OnItemUpdated="fvBase_ItemUpdated" OnItemUpdating="fvBase_ItemUpdating">
                <EditItemTemplate>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="right" nowrap="nowrap">
                                工號</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sNobrTextBox" runat="server" ReadOnly="True" Text='<%# Bind("sNobr") %>'></asp:TextBox>
                                <asp:CheckBox ID="bMangCheckBox" runat="server" Checked='<%# Bind("bMang") %>' Text="主管" /></td>
                            <td align="right" nowrap="nowrap">
                                姓名</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sNameTextBox" runat="server" Text='<%# Bind("sName") %>'></asp:TextBox>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                                    RepeatLayout="Flow" SelectedValue='<%# Bind("bSex") %>'>
                                    <asp:ListItem Value="True">男</asp:ListItem>
                                    <asp:ListItem Value="False">女</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                帳號</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sLoginIDTextBox" runat="server" Text='<%# Bind("sLoginID") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                密碼</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sLoginPWTextBox" runat="server" Text='<%# Bind("sLoginPW") %>'></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                到職日</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="dDateATextBox" runat="server" Text='<%# Bind("dDateA", "{0:d}") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                離職日</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="dDateDTextBox" runat="server" Text='<%# Bind("dDateD", "{0:d}") %>'></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                編制部門</td>
                            <td nowrap="nowrap">
                                暫時不用</td>
                            <td align="right" nowrap="nowrap">
                                成本部門</td>
                            <td nowrap="nowrap">
                                暫時不用</td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                簽核部門</td>
                            <td nowrap="nowrap">
                                <asp:DropDownList ID="ddlDeptm" runat="server" DataSourceID="sdsDeptm" DataTextField="sDeptmName"
                                    DataValueField="sDeptmCode" SelectedValue='<%# Bind("sDeptmCode") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="sdsDeptm" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>"
                                    SelectCommand="SELECT sDeptmCode, sDeptmName FROM hrDeptm WHERE (GETDATE() BETWEEN dDateA AND dDateD) ORDER BY iDeptmOrder DESC">
                                </asp:SqlDataSource>
                            </td>
                            <td align="right" nowrap="nowrap">
                                班別</td>
                            <td nowrap="nowrap">
                                <asp:DropDownList ID="ddlRote" runat="server" DataSourceID="sdsRote" DataTextField="sRoteName"
                                    DataValueField="sRoteCode" SelectedValue='<%# Bind("sRoteCode") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="sdsRote" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>"
                                    SelectCommand="SELECT sRoteCode, sRoteName FROM hrRote WHERE (GETDATE() BETWEEN dDateA AND dDateD) AND (sRoteCode <> '00')">
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                職稱</td>
                            <td nowrap="nowrap">
                                <asp:DropDownList ID="ddlJob" runat="server" DataSourceID="sdsJob" DataTextField="sJobName"
                                    DataValueField="sJobCode" SelectedValue='<%# Bind("sJobCode") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="sdsJob" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>"
                                    SelectCommand="SELECT sJobCode, sJobName FROM hrJob WHERE (GETDATE() BETWEEN dDateA AND dDateD) ORDER BY sJobCode DESC">
                                </asp:SqlDataSource>
                            </td>
                            <td align="right" nowrap="nowrap">
                                職等</td>
                            <td nowrap="nowrap">
                                暫時不用</td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                電子信箱</td>
                            <td colspan="3" nowrap="nowrap">
                                <asp:TextBox ID="sEmailTextBox" runat="server" Text='<%# Bind("sEmail") %>' Width="100%"></asp:TextBox></td>
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
                                <asp:Label ID="iAutoKeyLabel1" runat="server" Text='<%# Eval("iAutoKey") %>' Visible="False"></asp:Label></td>
                            <td align="right" nowrap="nowrap">
                            </td>
                            <td align="right" nowrap="nowrap">
                                &nbsp;<asp:Button ID="btnY" runat="server" CommandName="Update" Text="修改" />
                                <asp:Button ID="btnN" runat="server" CausesValidation="False" CommandName="Cancel"
                                    Text="取消" /></td>
                        </tr>
                    </table>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="right" nowrap="nowrap">
                                工號</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sNobrTextBox" runat="server" Text='<%# Bind("sNobr") %>'></asp:TextBox>
                                <asp:CheckBox ID="bMangCheckBox" runat="server" Checked='<%# Bind("bMang") %>' Text="主管" /></td>
                            <td align="right" nowrap="nowrap">
                                姓名</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sNameTextBox" runat="server" Text='<%# Bind("sName") %>'></asp:TextBox>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                                    RepeatLayout="Flow" SelectedValue='<%# Bind("bSex") %>'>
                                    <asp:ListItem Value="True">男</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="False">女</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                帳號</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="sLoginIDTextBox" runat="server" Text='<%# Bind("sLoginID") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                密碼</td>
                            <td nowrap="nowrap">
                                系統預設jbjob</td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                到職日</td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="dDateATextBox" runat="server" Text='<%# Bind("dDateA") %>'></asp:TextBox></td>
                            <td align="right" nowrap="nowrap">
                                離職日</td>
                            <td nowrap="nowrap">
                                系統預設9999/12/31</td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                編制部門</td>
                            <td nowrap="nowrap">
                                暫時不用</td>
                            <td align="right" nowrap="nowrap">
                                成本部門</td>
                            <td nowrap="nowrap">
                                暫時不用</td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                簽核部門</td>
                            <td nowrap="nowrap">
                                <asp:DropDownList ID="ddlDeptm" runat="server" DataSourceID="sdsDeptm" DataTextField="sDeptmName"
                                    DataValueField="sDeptmCode" SelectedValue='<%# Bind("sDeptmCode") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="sdsDeptm" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>"
                                    SelectCommand="SELECT sDeptmCode, sDeptmName FROM hrDeptm WHERE (GETDATE() BETWEEN dDateA AND dDateD) ORDER BY iDeptmOrder DESC">
                                </asp:SqlDataSource>
                            </td>
                            <td align="right" nowrap="nowrap">
                                班別</td>
                            <td nowrap="nowrap">
                                <asp:DropDownList ID="ddlRote" runat="server" DataSourceID="sdsRote" DataTextField="sRoteName"
                                    DataValueField="sRoteCode" SelectedValue='<%# Bind("sRoteCode") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="sdsRote" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>"
                                    SelectCommand="SELECT sRoteCode, sRoteName FROM hrRote WHERE (GETDATE() BETWEEN dDateA AND dDateD) AND (sRoteCode <> '00')">
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                職稱</td>
                            <td nowrap="nowrap">
                                <asp:DropDownList ID="ddlJob" runat="server" DataSourceID="sdsJob" DataTextField="sJobName"
                                    DataValueField="sJobCode" SelectedValue='<%# Bind("sJobCode") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="sdsJob" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>"
                                    SelectCommand="SELECT sJobCode, sJobName FROM hrJob WHERE (GETDATE() BETWEEN dDateA AND dDateD) ORDER BY sJobCode DESC">
                                </asp:SqlDataSource>
                            </td>
                            <td align="right" nowrap="nowrap">
                                職等</td>
                            <td nowrap="nowrap">
                                暫時不用</td>
                        </tr>
                        <tr>
                            <td align="right" nowrap="nowrap">
                                電子信箱</td>
                            <td colspan="3" nowrap="nowrap">
                                <asp:TextBox ID="sEmailTextBox" runat="server" Text='<%# Bind("sEmail") %>' Width="100%"></asp:TextBox></td>
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
                                &nbsp;<asp:Button ID="btnY" runat="server" CommandName="Insert" Text="新增" />
                                <asp:Button ID="btnN" runat="server" CausesValidation="False" CommandName="Cancel"
                                    Text="取消" /></td>
                        </tr>
                    </table>
                </InsertItemTemplate>
            </asp:FormView>
            <asp:SqlDataSource ID="sdsFV" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>" InsertCommand="INSERT INTO [hrBaseM] ([sNobr], [sName], [sDeptCode], [sDeptsCode], [sDeptmCode], [sJobCode], [sJoblCode], [sRoteCode], [dDateA], [dDateD], [bSex], [sLoginID], [sLoginPW], [sEmail], [sNote], [sReserve1], [sReserve2], [sReserve3], [sReserve4], [sReserve5], [bMang], [sKeyMan], [dKeyDate]) VALUES (@sNobr, @sName, @sDeptCode, @sDeptsCode, @sDeptmCode, @sJobCode, @sJoblCode, @sRoteCode, @dDateA, @dDateD, @bSex, @sLoginID, @sLoginPW, @sEmail, @sNote, @sReserve1, @sReserve2, @sReserve3, @sReserve4, @sReserve5, @bMang, @sKeyMan, @dKeyDate)"
                SelectCommand="SELECT * FROM [hrBaseM] WHERE ([iAutoKey] = @iAutoKey)" UpdateCommand="UPDATE [hrBaseM] SET [sNobr] = @sNobr, [sName] = @sName, [sDeptCode] = @sDeptCode, [sDeptsCode] = @sDeptsCode, [sDeptmCode] = @sDeptmCode, [sJobCode] = @sJobCode, [sJoblCode] = @sJoblCode, [sRoteCode] = @sRoteCode, [dDateA] = @dDateA, [dDateD] = @dDateD, [bSex] = @bSex, [sLoginID] = @sLoginID, [sLoginPW] = @sLoginPW, [sEmail] = @sEmail, [sNote] = @sNote, [sReserve1] = @sReserve1, [sReserve2] = @sReserve2, [sReserve3] = @sReserve3, [sReserve4] = @sReserve4, [sReserve5] = @sReserve5, [bMang] = @bMang, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
                <UpdateParameters>
                    <asp:Parameter Name="sNobr" Type="String" />
                    <asp:Parameter Name="sName" Type="String" />
                    <asp:Parameter Name="sDeptCode" Type="String" />
                    <asp:Parameter Name="sDeptsCode" Type="String" />
                    <asp:Parameter Name="sDeptmCode" Type="String" />
                    <asp:Parameter Name="sJobCode" Type="String" />
                    <asp:Parameter Name="sJoblCode" Type="String" />
                    <asp:Parameter Name="sRoteCode" Type="String" />
                    <asp:Parameter Name="dDateA" Type="DateTime" />
                    <asp:Parameter Name="dDateD" Type="DateTime" />
                    <asp:Parameter Name="bSex" Type="Boolean" />
                    <asp:Parameter Name="sLoginID" Type="String" />
                    <asp:Parameter Name="sLoginPW" Type="String" />
                    <asp:Parameter Name="sEmail" Type="String" />
                    <asp:Parameter Name="sNote" Type="String" />
                    <asp:Parameter Name="sReserve1" Type="String" />
                    <asp:Parameter Name="sReserve2" Type="String" />
                    <asp:Parameter Name="sReserve3" Type="String" />
                    <asp:Parameter Name="sReserve4" Type="String" />
                    <asp:Parameter Name="sReserve5" Type="String" />
                    <asp:Parameter Name="bMang" Type="Boolean" />
                    <asp:Parameter Name="sKeyMan" Type="String" />
                    <asp:Parameter Name="dKeyDate" Type="DateTime" />
                    <asp:Parameter Name="iAutoKey" Type="Int32" />
                </UpdateParameters>
                <InsertParameters>
                    <asp:Parameter Name="sNobr" Type="String" />
                    <asp:Parameter Name="sName" Type="String" />
                    <asp:Parameter Name="sDeptCode" Type="String" />
                    <asp:Parameter Name="sDeptsCode" Type="String" />
                    <asp:Parameter Name="sDeptmCode" Type="String" />
                    <asp:Parameter Name="sJobCode" Type="String" />
                    <asp:Parameter Name="sJoblCode" Type="String" />
                    <asp:Parameter Name="sRoteCode" Type="String" />
                    <asp:Parameter Name="dDateA" Type="DateTime" />
                    <asp:Parameter Name="dDateD" Type="DateTime" />
                    <asp:Parameter Name="bSex" Type="Boolean" />
                    <asp:Parameter Name="sLoginID" Type="String" />
                    <asp:Parameter Name="sLoginPW" Type="String" />
                    <asp:Parameter Name="sEmail" Type="String" />
                    <asp:Parameter Name="sNote" Type="String" />
                    <asp:Parameter Name="sReserve1" Type="String" />
                    <asp:Parameter Name="sReserve2" Type="String" />
                    <asp:Parameter Name="sReserve3" Type="String" />
                    <asp:Parameter Name="sReserve4" Type="String" />
                    <asp:Parameter Name="sReserve5" Type="String" />
                    <asp:Parameter Name="bMang" Type="Boolean" />
                    <asp:Parameter Name="sKeyMan" Type="String" />
                    <asp:Parameter Name="dKeyDate" Type="DateTime" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="gvBase" Name="iAutoKey" PropertyName="SelectedValue"
                        Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </asp:View>
    </asp:MultiView>
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>

