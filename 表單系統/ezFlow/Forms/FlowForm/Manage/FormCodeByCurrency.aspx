<%@ Page Title="" Language="C#" MasterPageFile="~/mpMT0990113.master" AutoEventWireup="true"
    CodeFile="FormCodeByCurrency.aspx.cs" Inherits="Manage_FormCodeByCurrency" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="TableFullBorder">
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True">
                            <asp:ListItem Value="Currency">幣別</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        <asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:FormView ID="fv" runat="server" DataKeyNames="iAutoKey" DataSourceID="sdsFV"
                            DefaultMode="Insert" OnItemInserted="fv_ItemInserted" OnItemInserting="fv_ItemInserting"
                            OnItemUpdated="fv_ItemUpdated" OnItemUpdating="fv_ItemUpdating">
                            <EditItemTemplate>
                                <table class="TableFullBorder">
                                    <tr>
                                        <th>
                                            代碼
                                        </th>
                                        <th>
                                            名稱
                                        </th>
                                        <th>
                                            排序
                                        </th>
                                        <td rowspan="4">
                                            <asp:Button ID="Button1" runat="server" CommandName="Update" Text="更新" ValidationGroup="fv" />
                                            <asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel"
                                                Text="取消" ValidationGroup="fv" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="sCodeTextBox" runat="server" CssClass="txtCode" ReadOnly="True"
                                                Text='<%# Bind("sCode") %>' ValidationGroup="fv" />
                                            <asp:CheckBox ID="bDisplayCheckBox" runat="server" Checked='<%# Bind("bDisplay") %>'
                                                Text="顯示" />
                                            <asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="sCodeTextBox"
                                                Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="rfvCode_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rfvCode">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="sNameTextBox" runat="server" CssClass="txtName" Text='<%# Bind("sName") %>'
                                                ValidationGroup="fv" />
                                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="sNameTextBox"
                                                Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="rfvName_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rfvName">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="iOrderTextBox" runat="server" CssClass="txtOrder" Text='<%# Bind("iOrder") %>'
                                                ValidationGroup="fv" />
                                            <asp:MaskedEditExtender ID="iOrderTextBox_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" Mask="99" MaskType="Number" TargetControlID="iOrderTextBox">
                                            </asp:MaskedEditExtender>
                                            <asp:RequiredFieldValidator ID="rfvOrder" runat="server" ControlToValidate="iOrderTextBox"
                                                Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="rfvOrder_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rfvOrder">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:RangeValidator ID="rvOrder" runat="server" ControlToValidate="iOrderTextBox"
                                                Display="None" ErrorMessage="格式不正確" MaximumValue="99" MinimumValue="0" SetFocusOnError="True"
                                                Type="Integer" ValidationGroup="fv"></asp:RangeValidator>
                                            <asp:ValidatorCalloutExtender ID="rvOrder_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rvOrder">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th colspan="3">
                                            內容
                                        </th>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:TextBox ID="sContentTextBox" runat="server" CssClass="txtDescription" Text='<%# Bind("sContent") %>'
                                                ValidationGroup="fv" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label ID="iAutoKeyLabel1" runat="server" Text='<%# Eval("iAutoKey") %>' Visible="False" />
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <table class="TableFullBorder">
                                    <tr>
                                        <th>
                                            代碼
                                        </th>
                                        <th>
                                            名稱
                                        </th>
                                        <th>
                                            排序
                                        </th>
                                        <td rowspan="4">
                                            <asp:Button ID="Button1" runat="server" CommandName="Insert" Text="新增" ValidationGroup="fv" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="sCodeTextBox" runat="server" CssClass="txtCode" Text='<%# Bind("sCode") %>'
                                                ValidationGroup="fv" />
                                            <asp:CheckBox ID="bDisplayCheckBox" runat="server" Checked='<%# Bind("bDisplay") %>'
                                                Text="顯示" />
                                            <asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="sCodeTextBox"
                                                Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="rfvCode_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rfvCode">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="sNameTextBox" runat="server" CssClass="txtName" Text='<%# Bind("sName") %>'
                                                ValidationGroup="fv" />
                                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="sNameTextBox"
                                                Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="rfvName_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rfvName">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="iOrderTextBox" runat="server" CssClass="txtOrder" Text='<%# Bind("iOrder") %>'
                                                ValidationGroup="fv" />
                                            <asp:RequiredFieldValidator ID="rfvOrder" runat="server" ControlToValidate="iOrderTextBox"
                                                Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="rfvOrder_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rfvOrder">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:RangeValidator ID="rvOrder" runat="server" ControlToValidate="iOrderTextBox"
                                                Display="None" ErrorMessage="格式不正確" MaximumValue="99" MinimumValue="0" SetFocusOnError="True"
                                                Type="Integer" ValidationGroup="fv"></asp:RangeValidator>
                                            <asp:ValidatorCalloutExtender ID="rvOrder_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rvOrder">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:MaskedEditExtender ID="iOrderTextBox_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" Mask="99" MaskType="Number" TargetControlID="iOrderTextBox">
                                            </asp:MaskedEditExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th colspan="3">
                                            內容
                                        </th>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:TextBox ID="sContentTextBox" runat="server" CssClass="txtDescription" Text='<%# Bind("sContent") %>'
                                                ValidationGroup="fv" />
                                        </td>
                                    </tr>
                                </table>
                            </InsertItemTemplate>
                        </asp:FormView>
                        <asp:SqlDataSource ID="sdsFV" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                            InsertCommand="INSERT INTO [wfFormCode] ([sCategory], [sCode], [sName], [sContent], [iOrder], [bDisplay], [sKeyMan], [dKeyDate]) VALUES (@sCategory, @sCode, @sName, @sContent, @iOrder, @bDisplay, @sKeyMan, @dKeyDate)"
                            SelectCommand="SELECT * FROM [wfFormCode]
WHERE          (iAutoKey = @iAutoKey)" UpdateCommand="UPDATE [wfFormCode] SET [sCategory] = @sCategory, [sCode] = @sCode, [sName] = @sName, [sContent] = @sContent, [iOrder] = @iOrder, [bDisplay] = @bDisplay, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="gv" Name="iAutoKey" PropertyName="SelectedValue" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="sCategory" Type="String" />
                                <asp:Parameter Name="sCode" Type="String" />
                                <asp:Parameter Name="sName" Type="String" />
                                <asp:Parameter Name="sContent" Type="String" />
                                <asp:Parameter Name="iOrder" Type="Int32" />
                                <asp:Parameter Name="bDisplay" Type="Boolean" />
                                <asp:Parameter Name="sKeyMan" Type="String" />
                                <asp:Parameter Name="dKeyDate" Type="DateTime" />
                                <asp:Parameter Name="iAutoKey" Type="Int32" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:Parameter Name="sCategory" Type="String" />
                                <asp:Parameter Name="sCode" Type="String" />
                                <asp:Parameter Name="sName" Type="String" />
                                <asp:Parameter Name="sContent" Type="String" />
                                <asp:Parameter Name="iOrder" Type="Int32" />
                                <asp:Parameter Name="bDisplay" Type="Boolean" />
                                <asp:Parameter Name="sKeyMan" Type="String" />
                                <asp:Parameter Name="dKeyDate" Type="DateTime" />
                            </InsertParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gv" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            DataKeyNames="iAutoKey" DataSourceID="sdsGV" OnSelectedIndexChanged="gv_SelectedIndexChanged"
                            OnSorted="gv_Sorted">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:Button ID="btnSelect" runat="server" CausesValidation="False" CommandName="Select"
                                            Text="修改" />
                                        <asp:Button ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="刪除" />
                                        <asp:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" ConfirmText="您確定要刪除嗎？"
                                            Enabled="True" TargetControlID="btnDelete">
                                        </asp:ConfirmButtonExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="sCode" HeaderText="代碼" SortExpression="sCode" />
                                <asp:BoundField DataField="sName" HeaderText="名稱" SortExpression="sName" />
                                <asp:BoundField DataField="sContent" HeaderText="內容" SortExpression="sContent" />
                                <asp:BoundField DataField="iOrder" HeaderText="排序" SortExpression="iOrder" />
                                <asp:CheckBoxField DataField="bDisplay" HeaderText="是否顯示" SortExpression="bDisplay" />
                                <asp:BoundField DataField="sKeyMan" HeaderText="登錄者" SortExpression="sKeyMan" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="登錄日期時間" SortExpression="dKeyDate" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="sdsGV" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                            DeleteCommand="DELETE FROM [wfFormCode] WHERE [iAutoKey] = @iAutoKey" SelectCommand="SELECT * FROM [wfFormCode]
WHERE          (sCategory = @sCategory)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlCategory" Name="sCategory" PropertyName="SelectedValue" />
                            </SelectParameters>
                            <DeleteParameters>
                                <asp:Parameter Name="iAutoKey" Type="Int32" />
                            </DeleteParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
