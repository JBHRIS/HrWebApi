<%@ Page Title="" Language="C#" MasterPageFile="~/mpMT0990113.master" AutoEventWireup="true"
    CodeFile="Form.aspx.cs" Inherits="Manage_Form" %>

<%@ Register TagPrefix="customEditors" Namespace="AjaxControlToolkit.HTMLEditor.Samples" %>
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
                                            流程樹值
                                        </th>
                                        <th>
                                            延遲天數
                                        </th>
                                        <th>
                                            申請筆數
                                        </th>
                                        <td rowspan="5">
                                            <asp:Button ID="Button1" runat="server" CommandName="Update" Text="更新" ValidationGroup="fv" />
                                            <asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel"
                                                Text="取消" ValidationGroup="fv" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="sFormCodeTextBox" runat="server" CssClass="txtCode" ReadOnly="True"
                                                Text='<%# Bind("sFormCode") %>' ValidationGroup="fv" />
                                            <asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="sFormCodeTextBox"
                                                Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="rfvCode_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rfvCode">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="sFormNameTextBox" runat="server" CssClass="txtName" Text='<%# Bind("sFormName") %>'
                                                ValidationGroup="fv" />
                                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="sFormNameTextBox"
                                                Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="rfvName_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rfvName">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="sFlowTreeTextBox" runat="server" CssClass="txtOrder" Text='<%# Bind("sFlowTree") %>'
                                                ValidationGroup="fv" />
                                            <asp:RequiredFieldValidator ID="rfvOrder" runat="server" ControlToValidate="sFlowTreeTextBox"
                                                Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="rfvOrder_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rfvOrder">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:RangeValidator ID="rvOrder" runat="server" ControlToValidate="sFlowTreeTextBox"
                                                Display="None" ErrorMessage="格式不正確" MaximumValue="999" MinimumValue="0" SetFocusOnError="True"
                                                Type="Integer" ValidationGroup="fv"></asp:RangeValidator>
                                            <asp:ValidatorCalloutExtender ID="rvOrder_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rvOrder">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="iDelayTextBox" runat="server" CssClass="txtOrder" Text='<%# Bind("iDelay") %>'
                                                ValidationGroup="fv" />
                                            <asp:RequiredFieldValidator ID="rfvOrder0" runat="server" ControlToValidate="iDelayTextBox"
                                                Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="rfvOrder0_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rfvOrder0">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:RangeValidator ID="rvOrder0" runat="server" ControlToValidate="iDelayTextBox"
                                                Display="None" ErrorMessage="格式不正確" MaximumValue="999" MinimumValue="0" SetFocusOnError="True"
                                                Type="Integer" ValidationGroup="fv"></asp:RangeValidator>
                                            <asp:ValidatorCalloutExtender ID="rvOrder0_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rvOrder0">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="iAppCountTextBox" runat="server" CssClass="txtOrder" Text='<%# Bind("iAppCount") %>'
                                                ValidationGroup="fv" />
                                            <asp:RequiredFieldValidator ID="rfvOrder1" runat="server" ControlToValidate="iAppCountTextBox"
                                                Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="rfvOrder1_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rfvOrder1">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:RangeValidator ID="rvOrder1" runat="server" ControlToValidate="iAppCountTextBox"
                                                Display="None" ErrorMessage="格式不正確" MaximumValue="9" MinimumValue="0" SetFocusOnError="True"
                                                Type="Integer" ValidationGroup="fv"></asp:RangeValidator>
                                            <asp:ValidatorCalloutExtender ID="rvOrder1_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rvOrder1">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            選項
                                        </th>
                                        <td colspan="4">
                                            <asp:CheckBox ID="bNoteCheckBox" runat="server" Checked='<%# Bind("bNote") %>' Text="申請備註" />
                                            <asp:CheckBox ID="bSignNoteCheckBox" runat="server" Checked='<%# Bind("bSignNote") %>'
                                                Text="審核備註" />
                                            <asp:CheckBox ID="bSignStateCheckBox" runat="server" Checked='<%# Bind("bSignState") %>'
                                                Text="審核狀態" />
                                            <asp:CheckBox ID="bUploadFileCheckBox" runat="server" Checked='<%# Bind("bUploadFile") %>'
                                                Text="上傳檔案" />
                                            <asp:CheckBox ID="bAttendCheckBox" runat="server" Checked='<%# Bind("bAttend") %>'
                                                Text="影響出勤" />
                                            <asp:CheckBox ID="bAgentAppCheckBox" runat="server" Checked='<%# Bind("bAgentApp") %>'
                                                Text="代理申請" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            備用選項
                                        </th>
                                        <td colspan="4">
                                            <asp:CheckBox ID="b1CheckBox" runat="server" Checked='<%# Bind("b1") %>' Text="備用1" />
                                            <asp:CheckBox ID="b2CheckBox" runat="server" Checked='<%# Bind("b2") %>' Text="備用2" />
                                            <asp:CheckBox ID="b3CheckBox" runat="server" Checked='<%# Bind("b3") %>' Text="備用3" />
                                            <asp:CheckBox ID="b4CheckBox" runat="server" Checked='<%# Bind("b4") %>' Text="備用4" />
                                            <asp:CheckBox ID="b5CheckBox" runat="server" Checked='<%# Bind("b5") %>' Text="備用5" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            備用內容
                                        </th>
                                        <td colspan="4">
                                            <asp:TextBox ID="s1TextBox" runat="server" CssClass="txtDate" Text='<%# Bind("s1") %>' />
                                            /<asp:TextBox ID="s2TextBox" runat="server" CssClass="txtDate" Text='<%# Bind("s2") %>' />
                                            /<asp:TextBox ID="s3TextBox" runat="server" CssClass="txtDate" Text='<%# Bind("s3") %>' />
                                            /<asp:TextBox ID="s4TextBox" runat="server" CssClass="txtDate" Text='<%# Bind("s4") %>' />
                                            /<asp:TextBox ID="s5TextBox" runat="server" CssClass="txtDate" Text='<%# Bind("s5") %>' />
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
                                            流程樹值
                                        </th>
                                        <th>
                                            延遲天數
                                        </th>
                                        <th>
                                            申請筆數
                                        </th>
                                        <td rowspan="5">
                                            <asp:Button ID="Button1" runat="server" CommandName="Insert" Text="新增" ValidationGroup="fv" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="sFormCodeTextBox" runat="server" CssClass="txtCode" Text='<%# Bind("sFormCode") %>'
                                                ValidationGroup="fv" />
                                            <asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="sFormCodeTextBox"
                                                Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="rfvCode_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rfvCode">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="sFormNameTextBox" runat="server" CssClass="txtName" Text='<%# Bind("sFormName") %>'
                                                ValidationGroup="fv" />
                                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="sFormNameTextBox"
                                                Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="rfvName_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rfvName">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="sFlowTreeTextBox" runat="server" CssClass="txtOrder" Text='<%# Bind("sFlowTree") %>'
                                                ValidationGroup="fv" />
                                            <asp:RequiredFieldValidator ID="rfvOrder" runat="server" ControlToValidate="sFlowTreeTextBox"
                                                Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="rfvOrder_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rfvOrder">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:RangeValidator ID="rvOrder" runat="server" ControlToValidate="sFlowTreeTextBox"
                                                Display="None" ErrorMessage="格式不正確" MaximumValue="999" MinimumValue="0" SetFocusOnError="True"
                                                Type="Integer" ValidationGroup="fv"></asp:RangeValidator>
                                            <asp:ValidatorCalloutExtender ID="rvOrder_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rvOrder">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="iDelayTextBox" runat="server" CssClass="txtOrder" Text='<%# Bind("iDelay") %>'
                                                ValidationGroup="fv" />
                                            <asp:RequiredFieldValidator ID="rfvOrder0" runat="server" ControlToValidate="iDelayTextBox"
                                                Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="rfvOrder0_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rfvOrder0">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:RangeValidator ID="rvOrder0" runat="server" ControlToValidate="iDelayTextBox"
                                                Display="None" ErrorMessage="格式不正確" MaximumValue="999" MinimumValue="0" SetFocusOnError="True"
                                                Type="Integer" ValidationGroup="fv"></asp:RangeValidator>
                                            <asp:ValidatorCalloutExtender ID="rvOrder0_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rvOrder0">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="iAppCountTextBox" runat="server" CssClass="txtOrder" Text='<%# Bind("iAppCount") %>'
                                                ValidationGroup="fv" />
                                            <asp:RequiredFieldValidator ID="rfvOrder1" runat="server" ControlToValidate="iAppCountTextBox"
                                                Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="rfvOrder1_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rfvOrder1">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:RangeValidator ID="rvOrder1" runat="server" ControlToValidate="iAppCountTextBox"
                                                Display="None" ErrorMessage="格式不正確" MaximumValue="9" MinimumValue="0" SetFocusOnError="True"
                                                Type="Integer" ValidationGroup="fv"></asp:RangeValidator>
                                            <asp:ValidatorCalloutExtender ID="rvOrder1_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="rvOrder1">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            選項
                                        </th>
                                        <td colspan="4">
                                            <asp:CheckBox ID="bNoteCheckBox" runat="server" Checked='<%# Bind("bNote") %>' Text="申請備註" />
                                            <asp:CheckBox ID="bSignNoteCheckBox" runat="server" Checked='<%# Bind("bSignNote") %>'
                                                Text="審核備註" />
                                            <asp:CheckBox ID="bSignStateCheckBox" runat="server" Checked='<%# Bind("bSignState") %>'
                                                Text="審核狀態" />
                                            <asp:CheckBox ID="bUploadFileCheckBox" runat="server" Checked='<%# Bind("bUploadFile") %>'
                                                Text="上傳檔案" />
                                            <asp:CheckBox ID="bAttendCheckBox" runat="server" Checked='<%# Bind("bAttend") %>'
                                                Text="影響出勤" />
                                            <asp:CheckBox ID="bAgentAppCheckBox" runat="server" Checked='<%# Bind("bAgentApp") %>'
                                                Text="代理申請" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            備用選項
                                        </th>
                                        <td colspan="4">
                                            <asp:CheckBox ID="b1CheckBox" runat="server" Checked='<%# Bind("b1") %>' Text="備用1" />
                                            <asp:CheckBox ID="b2CheckBox" runat="server" Checked='<%# Bind("b2") %>' Text="備用2" />
                                            <asp:CheckBox ID="b3CheckBox" runat="server" Checked='<%# Bind("b3") %>' Text="備用3" />
                                            <asp:CheckBox ID="b4CheckBox" runat="server" Checked='<%# Bind("b4") %>' Text="備用4" />
                                            <asp:CheckBox ID="b5CheckBox" runat="server" Checked='<%# Bind("b5") %>' Text="備用5" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            備用內容
                                        </th>
                                        <td colspan="4">
                                            <asp:TextBox ID="s1TextBox" runat="server" CssClass="txtDate" Text='<%# Bind("s1") %>' />
                                            /<asp:TextBox ID="s2TextBox" runat="server" CssClass="txtDate" Text='<%# Bind("s2") %>' />
                                            /<asp:TextBox ID="s3TextBox" runat="server" CssClass="txtDate" Text='<%# Bind("s3") %>' />
                                            /<asp:TextBox ID="s4TextBox" runat="server" CssClass="txtDate" Text='<%# Bind("s4") %>' />
                                            /<asp:TextBox ID="s5TextBox" runat="server" CssClass="txtDate" Text='<%# Bind("s5") %>' />
                                        </td>
                                    </tr>
                                </table>
                            </InsertItemTemplate>
                        </asp:FormView>
                        <asp:SqlDataSource ID="sdsFV" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                            InsertCommand="INSERT INTO [wfForm] ([sFormCode], [sFormName], [sFlowTree], [sStdNote], [sCheckNote], [sViewNote], [sEtcNote], [iDelay], [iAppCount], [bNote], [bSignNote], [bSignState], [bUploadFile], [bAttend], [bAgentApp], [b1], [b2], [b3], [b4], [b5], [s1], [s2], [s3], [s4], [s5], [sKeyMan], [dKeyDate]) VALUES (@sFormCode, @sFormName, @sFlowTree, @sStdNote, @sCheckNote, @sViewNote, @sEtcNote, @iDelay, @iAppCount, @bNote, @bSignNote, @bSignState, @bUploadFile, @bAttend, @bAgentApp, @b1, @b2, @b3, @b4, @b5, @s1, @s2, @s3, @s4, @s5, @sKeyMan, @dKeyDate)"
                            SelectCommand="SELECT * FROM [wfForm]
WHERE          (iAutoKey = @iAutoKey)" UpdateCommand="UPDATE [wfForm] SET [sFormCode] = @sFormCode, [sFormName] = @sFormName, [sFlowTree] = @sFlowTree, [sStdNote] = @sStdNote, [sCheckNote] = @sCheckNote, [sViewNote] = @sViewNote, [sEtcNote] = @sEtcNote, [iDelay] = @iDelay, [iAppCount] = @iAppCount, [bNote] = @bNote, [bSignNote] = @bSignNote, [bSignState] = @bSignState, [bUploadFile] = @bUploadFile, [bAttend] = @bAttend, [bAgentApp] = @bAgentApp, [b1] = @b1, [b2] = @b2, [b3] = @b3, [b4] = @b4, [b5] = @b5, [s1] = @s1, [s2] = @s2, [s3] = @s3, [s4] = @s4, [s5] = @s5, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="gv" Name="iAutoKey" PropertyName="SelectedValue" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="sFormCode" Type="String" />
                                <asp:Parameter Name="sFormName" Type="String" />
                                <asp:Parameter Name="sFlowTree" Type="String" />
                                <asp:Parameter Name="sStdNote" Type="String" />
                                <asp:Parameter Name="sCheckNote" Type="String" />
                                <asp:Parameter Name="sViewNote" Type="String" />
                                <asp:Parameter Name="sEtcNote" Type="String" />
                                <asp:Parameter Name="iDelay" Type="Int32" />
                                <asp:Parameter Name="iAppCount" Type="Int32" />
                                <asp:Parameter Name="bNote" Type="Boolean" />
                                <asp:Parameter Name="bSignNote" Type="Boolean" />
                                <asp:Parameter Name="bSignState" Type="Boolean" />
                                <asp:Parameter Name="bUploadFile" Type="Boolean" />
                                <asp:Parameter Name="bAttend" Type="Boolean" />
                                <asp:Parameter Name="bAgentApp" Type="Boolean" />
                                <asp:Parameter Name="b1" Type="Boolean" />
                                <asp:Parameter Name="b2" Type="Boolean" />
                                <asp:Parameter Name="b3" Type="Boolean" />
                                <asp:Parameter Name="b4" Type="Boolean" />
                                <asp:Parameter Name="b5" Type="Boolean" />
                                <asp:Parameter Name="s1" Type="String" />
                                <asp:Parameter Name="s2" Type="String" />
                                <asp:Parameter Name="s3" Type="String" />
                                <asp:Parameter Name="s4" Type="String" />
                                <asp:Parameter Name="s5" Type="String" />
                                <asp:Parameter Name="sKeyMan" Type="String" />
                                <asp:Parameter Name="dKeyDate" Type="DateTime" />
                                <asp:Parameter Name="iAutoKey" Type="Int32" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:Parameter Name="sFormCode" Type="String" />
                                <asp:Parameter Name="sFormName" Type="String" />
                                <asp:Parameter Name="sFlowTree" Type="String" />
                                <asp:Parameter Name="sStdNote" Type="String" />
                                <asp:Parameter Name="sCheckNote" Type="String" />
                                <asp:Parameter Name="sViewNote" Type="String" />
                                <asp:Parameter Name="sEtcNote" Type="String" />
                                <asp:Parameter Name="iDelay" Type="Int32" />
                                <asp:Parameter Name="iAppCount" Type="Int32" />
                                <asp:Parameter Name="bNote" Type="Boolean" />
                                <asp:Parameter Name="bSignNote" Type="Boolean" />
                                <asp:Parameter Name="bSignState" Type="Boolean" />
                                <asp:Parameter Name="bUploadFile" Type="Boolean" />
                                <asp:Parameter Name="bAttend" Type="Boolean" />
                                <asp:Parameter Name="bAgentApp" Type="Boolean" />
                                <asp:Parameter Name="b1" Type="Boolean" />
                                <asp:Parameter Name="b2" Type="Boolean" />
                                <asp:Parameter Name="b3" Type="Boolean" />
                                <asp:Parameter Name="b4" Type="Boolean" />
                                <asp:Parameter Name="b5" Type="Boolean" />
                                <asp:Parameter Name="s1" Type="String" />
                                <asp:Parameter Name="s2" Type="String" />
                                <asp:Parameter Name="s3" Type="String" />
                                <asp:Parameter Name="s4" Type="String" />
                                <asp:Parameter Name="s5" Type="String" />
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
                            OnSorted="gv_Sorted" OnRowCommand="gv_RowCommand">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                            Text="更新"></asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                            Text="取消"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Button ID="btnSelect" runat="server" CausesValidation="False" CommandName="Select"
                                            Text="修改" />
                                        <asp:Button ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="刪除" />
                                        <asp:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" ConfirmText="您確定要刪除嗎？"
                                            Enabled="True" TargetControlID="btnDelete">
                                        </asp:ConfirmButtonExtender>
                                        <asp:Button ID="btnEditStdNote" runat="server" CommandArgument='<%# Eval("iAutoKey") %>'
                                            CommandName="EditStdNote" Text="申請備註" />
                                        <asp:Button ID="btnEditChkNote" runat="server" CommandArgument='<%# Eval("iAutoKey") %>'
                                            CommandName="EditChkNote" Text="審核備註" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="sFormCode" HeaderText="代碼" SortExpression="sFormCode" />
                                <asp:BoundField DataField="sFormName" HeaderText="名稱" SortExpression="sFormName" />
                                <asp:BoundField DataField="sFlowTree" HeaderText="流程樹值" SortExpression="sFlowTree" />
                                <asp:BoundField DataField="iDelay" HeaderText="可延遲天數" SortExpression="iDelay" />
                                <asp:BoundField DataField="iAppCount" HeaderText="可申請筆數" SortExpression="iAppCount" />
                                <asp:CheckBoxField DataField="bNote" HeaderText="申請備註" SortExpression="bNote" Visible="False" />
                                <asp:CheckBoxField DataField="bSignNote" HeaderText="審核備註" SortExpression="bSignNote"
                                    Visible="False" />
                                <asp:CheckBoxField DataField="bSignState" HeaderText="審核者資訊" SortExpression="bSignState"
                                    Visible="False" />
                                <asp:CheckBoxField DataField="bUploadFile" HeaderText="上傳檔案" SortExpression="bUploadFile"
                                    Visible="False" />
                                <asp:CheckBoxField DataField="bAttend" HeaderText="影響出勤" SortExpression="bAttend"
                                    Visible="False" />
                                <asp:CheckBoxField DataField="bAgentApp" HeaderText="代理申請" SortExpression="bAgentApp"
                                    Visible="False" />
                                <asp:CheckBoxField DataField="b1" HeaderText="b1" SortExpression="b1" Visible="False" />
                                <asp:CheckBoxField DataField="b2" HeaderText="b2" SortExpression="b2" Visible="False" />
                                <asp:CheckBoxField DataField="b3" HeaderText="b3" SortExpression="b3" Visible="False" />
                                <asp:CheckBoxField DataField="b4" HeaderText="b4" SortExpression="b4" Visible="False" />
                                <asp:CheckBoxField DataField="b5" HeaderText="b5" SortExpression="b5" Visible="False" />
                                <asp:BoundField DataField="s1" HeaderText="s1" SortExpression="s1" Visible="False" />
                                <asp:BoundField DataField="s2" HeaderText="s2" SortExpression="s2" Visible="False" />
                                <asp:BoundField DataField="s3" HeaderText="s3" SortExpression="s3" Visible="False" />
                                <asp:BoundField DataField="s4" HeaderText="s4" SortExpression="s4" Visible="False" />
                                <asp:BoundField DataField="s5" HeaderText="s5" SortExpression="s5" Visible="False" />
                                <asp:BoundField DataField="sKeyMan" HeaderText="登錄者" SortExpression="sKeyMan" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="登錄日期" SortExpression="dKeyDate" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="sdsGV" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                            DeleteCommand="DELETE FROM [wfForm] WHERE [iAutoKey] = @iAutoKey" SelectCommand="SELECT * FROM [wfForm]">
                            <DeleteParameters>
                                <asp:Parameter Name="iAutoKey" Type="Int32" />
                            </DeleteParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="plPopupNote" runat="server" CssClass="modalPopup" Style="display: none;"
                            Width="600px">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <asp:Panel ID="plDragNote" runat="server" Style="border-right: gray 1px solid; border-top: gray 1px solid;
                                            border-left: gray 1px solid; cursor: move; color: black; border-bottom: gray 1px solid;
                                            background-color: #dddddd;">
                                            <div>
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td nowrap="nowrap">
                                                            <asp:Label ID="lblDragNameNote" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="right" width="1%">
                                                            <asp:Button ID="btnExitNote" runat="server" CssClass="ButtonExit" Text="×" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:Label ID="lblNoteID" runat="server" Visible="False"></asp:Label>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div>
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <customEditors:Lite runat="server" ID="txtNote" Height="200px" Width="100%" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnNoteSave" runat="server" Text="儲存" 
                                                            onclick="btnNoteSave_Click" />
                                                        <asp:ConfirmButtonExtender ID="btnNoteSave_ConfirmButtonExtender" 
                                                            runat="server" ConfirmText="您確定要儲存嗎？" Enabled="True" 
                                                            TargetControlID="btnNoteSave">
                                                        </asp:ConfirmButtonExtender>
                                                        <asp:Label ID="lblMsgNote"
                                                            runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Button ID="hiddenTargetControlForModalPopupNote" runat="server" Style="display: none" />&nbsp;
                        <asp:ModalPopupExtender ID="mpePopupNote" runat="server" BackgroundCssClass="modalBackground"
                            BehaviorID="programmaticModalPopupBehavior2" DropShadow="true" PopupControlID="plPopupNote"
                            PopupDragHandleControlID="plDragNote" RepositionMode="RepositionOnWindowScroll"
                            TargetControlID="hiddenTargetControlForModalPopupNote">
                        </asp:ModalPopupExtender>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
