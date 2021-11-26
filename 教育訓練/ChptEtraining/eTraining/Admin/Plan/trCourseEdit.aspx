<%@ Page Language="C#" AutoEventWireup="true" CodeFile="trCourseEdit.aspx.cs" MasterPageFile="~/mpEdit.master"
    Inherits="Admin_Plan_trCourseEdit" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function CloseAndRebind(args) {
            GetRadWindow().BrowserWindow.refreshGrid(args);
            GetRadWindow().close();
        }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

            return oWindow;
        }

        function CancelEdit() {
            GetRadWindow().close();
        }

        function OpenAlert() {
            radalert('<h4>Welcome to <strong>RadWindow</strong>!</h4>', 330, 100, 'RadAlert custom title');
            return false;
        }

    </script>
        <div runat="server" id="divTree" style="float: left; width: 48%">

        <telerik:RadTreeView ID="tvCat" Runat="server">
        </telerik:RadTreeView>

    </div>

    <asp:FormView ID="fv" runat="server" DataKeyNames="iAutoKey" DataSourceID="sdsFV"
        OnItemCommand="fv_ItemCommand" OnItemInserting="fv_ItemInserting" OnItemUpdating="fv_ItemUpdating"
        OnItemInserted="fv_ItemInserted" OnItemUpdated="fv_ItemUpdated" Style="margin-right: 42px"
        DefaultMode="Insert" OnDataBound="fv_DataBound">
        <EditItemTemplate>
            <table style="width: 100%;" class="tableBlue">
                <tr>
                    <th style="width: 350px">
                        課程代碼
                    </th>
                    <td>
                        <telerik:RadTextBox ID="sCodeTextBox" runat="server" Text='<%# Bind("sCode") %>'
                            Width="98%" Enabled="False" />
                    </td>
                </tr>
                <tr>
                    <th>
                        課程名稱
                    </th>
                    <td>
                        <telerik:RadTextBox ID="sNameTextBox" runat="server" Text='<%# Bind("sName") %>'
                            Width="98%" />
                    </td>
                </tr>
                <tr>
                    <th>
                        訓練方式
                    </th>
                    <td>
                        <telerik:RadComboBox ID="trTrainingMethod_sCodeTextBox" runat="server" DataSourceID="sdsTrainingMethod"
                            DataTextField="sName" DataValueField="sCode" SelectedValue='<%# Bind("trTrainingMethod_sCode") %>'
                            Width="98%" Skin="Windows7">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                
                <tr>
                    <th>
                        授課時數
                    </th>
                    <td>
                        <telerik:RadTextBox ID="iCourseTimeTextBox" runat="server" Text='<%# Bind("iCourseTime") %>'
                            Width="50px" Rows="0" />
                            <asp:RequiredFieldValidator ID="rfvCourseTime" runat="server" 
                            ControlToValidate="iCourseTimeTextBox" ErrorMessage="*必填欄位" ForeColor="Red" 
                            SetFocusOnError="True" ValidationGroup="g"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th>
                        職能積分
                    </th>
                    <td>
                        <telerik:RadTextBox ID="iJobScoreTextBox" runat="server" Text='<%# Bind("iJobScore") %>'
                            Width="50px" />
                            <asp:RequiredFieldValidator ID="rvfJobScore" runat="server" 
                            ControlToValidate="iJobScoreTextBox" ErrorMessage="*必填欄位" ForeColor="Red" 
                            SetFocusOnError="True" ValidationGroup="g"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th>
                        生效日
                    </th>
                    <td>
                        <telerik:RadDatePicker ID="dDateATextBox" runat="server" Culture="zh-TW" DbSelectedDate='<%# Bind("dDateA") %>'
                            MaxDate="9999-12-31" MinDate="1900-01-01">
                        </telerik:RadDatePicker>
                    </td>
                </tr>
                <tr>
                    <th>
                        失效日
                    </th>
                    <td>
                        <telerik:RadDatePicker ID="dDateDTextBox" runat="server" Culture="zh-TW" DbSelectedDate='<%# Bind("dDateD") %>'
                            MaxDate="9999-12-31" MinDate="1900-01-01">
                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                            </Calendar>
                            <DateInput DateFormat="yyyy/M/d" DisplayDateFormat="yyyy/M/d" SelectedDate="9999-12-31">
                            </DateInput>
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                        </telerik:RadDatePicker>
                    </td>
                </tr>
                <tr>
                    <th>
                        有效天數
                    </th>
                    <td>
                        <telerik:RadNumericTextBox ID="ntb_iValidityDay" runat="server" Culture="zh-TW" DbValue='<%# Bind("iValidityDay") %>'
                            MaxValue="99999" MinValue="0" Width="100%" DataType="System.Int32">
                            <NumberFormat DecimalDigits="0" />
                        </telerik:RadNumericTextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        序列課程
                    </th>
                    <td>
                        <asp:CheckBox ID="cbIsSerialCourse" runat="server" Checked='<%# Bind("bIsSerialCourse") %>'
                            Text="是" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                Text="更新" ValidationGroup="g" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                CommandName="Cancel" Text="取消" />
        </EditItemTemplate>
        <InsertItemTemplate>
            <table style="width: 100%;" class="tableBlue">
<%--                <tr>
                    <th style="width: 350px">
                        課程代碼
                    </th>
                    <td>
                        &nbsp;</td>
                </tr>--%>
                <tr>
                    <th style="width: 350px">
                        課程名稱
                    </th>
                    <td>
                        <telerik:RadTextBox ID="sCodeTextBox" runat="server" 
                            Text='<%# Bind("sCode") %>' Visible="False" Width="98%" />
                        <telerik:RadTextBox ID="sNameTextBox" runat="server" Text='<%# Bind("sName") %>'
                            Width="98%" />
                    </td>
                </tr>
                <tr>
                    <th>
                        訓練方式
                    </th>
                    <td>
                        <telerik:RadComboBox ID="trTrainingMethod_sCodeTextBox" runat="server" DataSourceID="sdsTrainingMethod"
                            DataTextField="sName" DataValueField="sCode" SelectedValue='<%# Bind("trTrainingMethod_sCode") %>'
                            Width="98%" Skin="Windows7">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                
                <tr>
                    <th>
                        授課時數
                    </th>
                    <td>
                        <telerik:RadTextBox ID="iCourseTimeTextBox" runat="server" Text='<%# Bind("iCourseTime") %>'
                            Width="50px" InputType="Number" ValidationGroup="g" />
                        <asp:RequiredFieldValidator ID="rfvCourseTime" runat="server" 
                            ControlToValidate="iCourseTimeTextBox" ErrorMessage="*必填欄位" ForeColor="Red" 
                            SetFocusOnError="True" ValidationGroup="g"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th>
                        職能積分
                    </th>
                    <td>
                        <telerik:RadTextBox ID="iJobScoreTextBox" runat="server" Text='<%# Bind("iJobScore") %>'
                            Width="50px" InputType="Number" ValidationGroup="g" />
                        <asp:RequiredFieldValidator ID="rfvJobScore" runat="server" 
                            ControlToValidate="iJobScoreTextBox" ErrorMessage="*必填欄位" ForeColor="Red" 
                            SetFocusOnError="True" ValidationGroup="g"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th>
                        生效日
                    </th>
                    <td>
                        <telerik:RadDatePicker ID="dDateATextBox" runat="server" Culture="zh-TW" DbSelectedDate='<%# Bind("dDateA") %>'
                            MaxDate="9999-12-31" MinDate="1900-01-01">
                        </telerik:RadDatePicker>
                    </td>
                </tr>
                <tr>
                    <th>
                        失效日
                    </th>
                    <td>
                        <telerik:RadDatePicker ID="dDateDTextBox" runat="server" Culture="zh-TW" DbSelectedDate='<%# Bind("dDateD") %>'
                            MaxDate="9999-12-31" SelectedDate="9999-12-31" MinDate="1900-01-01">
                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                            </Calendar>
                            <DateInput DateFormat="yyyy/M/d" DisplayDateFormat="yyyy/M/d" SelectedDate="9999-12-31">
                            </DateInput>
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                        </telerik:RadDatePicker>
                    </td>
                </tr>
                <tr>
                    <th>
                        有效天數
                    </th>
                    <td>
                        <telerik:RadNumericTextBox ID="ntb_iValidityDay" runat="server" Culture="zh-TW" DbValue='<%# Bind("iValidityDay") %>'
                            MaxValue="99999" MinValue="0" Width="100%">
                            <NumberFormat DecimalDigits="0" />
                        </telerik:RadNumericTextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        序列課程
                    </th>
                    <td>
                        <asp:CheckBox ID="cbIsSerialCourse" runat="server" Checked='<%# Bind("bIsSerialCourse") %>'
                            Text="是" />
                    </td>
                </tr>
            </table>
            <telerik:RadButton ID="rbtnAdd" runat="server" CommandName="Insert" Text="新增" 
                ValidationGroup="g">
            </telerik:RadButton>
            <telerik:RadButton ID="rbtnCancel" runat="server" CommandName="Cancel" Text="取消">
            </telerik:RadButton>
            <br />
            &nbsp;
        </InsertItemTemplate>
        <ItemTemplate>
            iAutoKey:
            <asp:Label ID="iAutoKeyLabel" runat="server" Text='<%# Eval("iAutoKey") %>' />
            <br />
            sysRole_iKey:
            <asp:Label ID="sysRole_iKeyLabel" runat="server" Text='<%# Bind("sysRole_iKey") %>' />
            <br />
            sCode:
            <asp:Label ID="sCodeLabel" runat="server" Text='<%# Bind("sCode") %>' />
            <br />
            sName:
            <asp:Label ID="sNameLabel" runat="server" Text='<%# Bind("sName") %>' />
            <br />
            sContent:
            <asp:Label ID="sContentLabel" runat="server" Text='<%# Bind("sContent") %>' />
            <br />
            trTrainingMethod_sCode:
            <asp:Label ID="trTrainingMethod_sCodeLabel" runat="server" Text='<%# Bind("trTrainingMethod_sCode") %>' />
            <br />
            trTrainingType_sCode:
            <asp:Label ID="trTrainingType_sCodeLabel" runat="server" Text='<%# Bind("trTrainingType_sCode") %>' />
            <br />
            trTeachingMethod_sCode:
            <asp:Label ID="trTeachingMethod_sCodeLabel" runat="server" Text='<%# Bind("trTeachingMethod_sCode") %>' />
            <br />
            iCourseTime:
            <asp:Label ID="iCourseTimeLabel" runat="server" Text='<%# Bind("iCourseTime") %>' />
            <br />
            iJobScore:
            <asp:Label ID="iJobScoreLabel" runat="server" Text='<%# Bind("iJobScore") %>' />
            <br />
            iEdition:
            <asp:Label ID="iEditionLabel" runat="server" Text='<%# Bind("iEdition") %>' />
            <br />
            iValidityDay:
            <asp:Label ID="iValidityDayLabel" runat="server" Text='<%# Bind("iValidityDay") %>' />
            <br />
            dDateA:
            <asp:Label ID="dDateALabel" runat="server" Text='<%# Bind("dDateA") %>' />
            <br />
            dDateD:
            <asp:Label ID="dDateDLabel" runat="server" Text='<%# Bind("dDateD") %>' />
            <br />
            sKeyMan:
            <asp:Label ID="sKeyManLabel" runat="server" Text='<%# Bind("sKeyMan") %>' />
            <br />
            dKeyDate:
            <asp:Label ID="dKeyDateLabel" runat="server" Text='<%# Bind("dKeyDate") %>' />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                Text="編輯" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                Text="刪除" />
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                Text="新增" />
        </ItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="sdsTrainingMethod" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
        SelectCommand="SELECT * FROM [trTrainingMethod]"></asp:SqlDataSource>
    <br />
    <asp:Label ID="lblMsg" runat="server" Font-Size="Medium" ForeColor="#FF3300" Text="新增錯誤!!"
        Visible="False"></asp:Label>
    <br />
    <asp:SqlDataSource ID="sdsFV" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        SelectCommand="SELECT * FROM [trCourse] where iAutoKey = @iAutoKey" DeleteCommand="DELETE FROM [trCourse] WHERE [iAutoKey] = @iAutoKey"
        InsertCommand="INSERT INTO [trCourse] ([sysRole_iKey], [sCode], [sName], [sContent], [trTrainingMethod_sCode], [trTrainingType_sCode], [trTeachingMethod_sCode], [iCourseTime], [bIsSerialCourse], [iJobScore], [iEdition], [iValidityDay], [iLeftDay], [dDateA], [dDateD], [sKeyMan], [dKeyDate]) VALUES (@sysRole_iKey, @sCode, @sName, @sContent, @trTrainingMethod_sCode, @trTrainingType_sCode, @trTeachingMethod_sCode, @iCourseTime, @bIsSerialCourse, @iJobScore, @iEdition, @iValidityDay, @iLeftDay, @dDateA, @dDateD, @sKeyMan, @dKeyDate)"
        UpdateCommand="UPDATE [trCourse] SET [sysRole_iKey] = @sysRole_iKey, [sCode] = @sCode, [sName] = @sName, [sContent] = @sContent, [trTrainingMethod_sCode] = @trTrainingMethod_sCode, [trTrainingType_sCode] = @trTrainingType_sCode, [trTeachingMethod_sCode] = @trTeachingMethod_sCode, [iCourseTime] = @iCourseTime, [bIsSerialCourse] = @bIsSerialCourse, [iJobScore] = @iJobScore, [iEdition] = @iEdition, [iValidityDay] = @iValidityDay, [iLeftDay] = @iLeftDay, [dDateA] = @dDateA, [dDateD] = @dDateD, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
        <DeleteParameters>
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="sysRole_iKey" Type="Int32" />
            <asp:Parameter Name="sCode" Type="String" />
            <asp:Parameter Name="sName" Type="String" />
            <asp:Parameter Name="sContent" Type="String" />
            <asp:Parameter Name="trTrainingMethod_sCode" Type="String" />
            <asp:Parameter Name="trTrainingType_sCode" Type="String" />
            <asp:Parameter Name="trTeachingMethod_sCode" Type="String" />
            <asp:Parameter Name="iCourseTime" Type="Decimal" />
            <asp:Parameter Name="bIsSerialCourse" Type="Boolean" />
            <asp:Parameter Name="iJobScore" Type="Decimal" />
            <asp:Parameter Name="iEdition" Type="Int32" />
            <asp:Parameter Name="iValidityDay" Type="Int32" />
            <asp:Parameter Name="iLeftDay" Type="Int32" />
            <asp:Parameter Name="dDateA" Type="DateTime" />
            <asp:Parameter Name="dDateD" Type="DateTime" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dKeyDate" Type="DateTime" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="iAutoKey" QueryStringField="pid" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="sysRole_iKey" Type="Int32" />
            <asp:Parameter Name="sCode" Type="String" />
            <asp:Parameter Name="sName" Type="String" />
            <asp:Parameter Name="sContent" Type="String" />
            <asp:Parameter Name="trTrainingMethod_sCode" Type="String" />
            <asp:Parameter Name="trTrainingType_sCode" Type="String" />
            <asp:Parameter Name="trTeachingMethod_sCode" Type="String" />
            <asp:Parameter Name="iCourseTime" Type="Decimal" />
            <asp:Parameter Name="bIsSerialCourse" Type="Boolean" />
            <asp:Parameter Name="iJobScore" Type="Decimal" />
            <asp:Parameter Name="iEdition" Type="Int32" />
            <asp:Parameter Name="iValidityDay" Type="Int32" />
            <asp:Parameter Name="iLeftDay" Type="Int32" />
            <asp:Parameter Name="dDateA" Type="DateTime" />
            <asp:Parameter Name="dDateD" Type="DateTime" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dKeyDate" Type="DateTime" />
            <asp:Parameter Name="iAutoKey" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>
