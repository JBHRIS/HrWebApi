<%@ Page Title="設定課程" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="SetCourse.aspx.cs" Inherits="eTraining_Admin_Design_SetCourse" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <script type="text/javascript">
        //<![CDATA[

        //Standard Window.confirm
        function StandardConfirm(sender, args) {
            args.set_cancel(!window.confirm("確認是否刪除?"));
        }
                        
        //]]>
    </script>
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function refreshGrid(arg) {
                if (!arg) {
                    $find("<%= RadAjaxPanel1.ClientID %>").ajaxRequest("Rebind");
                }
                else {
                    $find("<%= RadAjaxPanel1.ClientID %>").ajaxRequest(arg);
                }
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Vista"
        IsSticky="True" Height="50px">
        <asp:Label ID="lblLoadingMsg" runat="server" Text="讀取中，請稍後...." Font-Size="X-Large"
            ForeColor="#FF3300"></asp:Label>
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%"
        HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1" onajaxrequest="RadAjaxPanel1_AjaxRequest">
        <h2>
            <asp:Label ID="lblCateName" runat="server"></asp:Label>
            -<asp:Label ID="lblClassName" runat="server"></asp:Label>
            <asp:Label ID="lblClassID" runat="server" Visible="False"></asp:Label>&nbsp;<telerik:RadWindowManager
                ID="RadWindowManager1" runat="server" EnableShadow="True">
                <Windows>
                    <telerik:RadWindow ID="UserListDialog" runat="server" Height="450px" Modal="true"
                        ReloadOnShow="true" ShowContentDuringLoad="false" Title="Editing record" Width="400px" />
                    <telerik:RadWindow ID="UserListDialog2" runat="server" EnableShadow="True" Height="550px"
                        Modal="True" Style="display: none;" Width="650px">
                    </telerik:RadWindow>
                </Windows>
            </telerik:RadWindowManager>
            <asp:Label ID="lblCateCode" runat="server" Visible="False"></asp:Label>
        </h2>
        <div style="text-align: right">
            <asp:HyperLink ID="hlBack" runat="server" Style="text-align: right" NavigateUrl="~/eTraining/Admin/Design/DesignCourseList.aspx"
                Font-Size="Medium" CssClass="Button1">回課程清單</asp:HyperLink>
        </div>
        <br />
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1"
            SelectedIndex="9" Width="100%" AutoPostBack="True">
            <Tabs>
                <telerik:RadTab runat="server" Text="複製課程" PageViewID="RadPageView11">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="開課日期/人數/講師/地點" PageViewID="pvAttendClassDate">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="教案" PageViewID="RadPageView2">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="教材上傳" PageViewID="pvTextBook">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="結訓條件" PageViewID="RadPageView3">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="必訓人員" PageViewID="RadPageView4">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="課程通知" PageViewID="pvNotify">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="預估費用" PageViewID="RadPageView6">
                </telerik:RadTab>
                <telerik:RadTab runat="server" PageViewID="pvPlan" Text="計劃書">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="線上報名" PageViewID="RadPageView12" Selected="True">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="2"
            RenderSelectedPageOnly="True">
            <telerik:RadPageView ID="pvTextBook" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td valign="top">
                            檔案名稱：<telerik:RadTextBox ID="tbFileNote" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td valign="top">
                            <telerik:RadAsyncUpload ID="ul" runat="server" MultipleFileSelection="Automatic"
                                MaxFileSize="1024000000">
                                <Localization Remove="移除" Select="選擇" />
                            </telerik:RadAsyncUpload>
                            <telerik:RadButton ID="btnFileUpload" runat="server" OnClick="btnFileUpload_Click"
                                Text="檔案上傳">
                            </telerik:RadButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top">
                            <telerik:RadGrid ID="gvTeachingMaterial" runat="server" CellSpacing="0" Culture="zh-TW"
                                DataSourceID="sdsTeachingMaterialGv" GridLines="None" Skin="Outlook" OnDeleteCommand="gvTeachingMaterial_DeleteCommand"
                                Style="margin-right: 0px" Width="85%">
                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="iAutoKey" DataSourceID="sdsTeachingMaterialGv">
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="FileOriginName" FilterControlAltText="Filter FileOriginName column"
                                            HeaderText="檔案" SortExpression="FileOriginName" UniqueName="FileOriginName">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="FileNote" FilterControlAltText="Filter FileNote column"
                                            HeaderText="檔案名稱" SortExpression="FileNote" UniqueName="FileNote">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridHyperLinkColumn DataNavigateUrlFields="FileStoredName" DataNavigateUrlFormatString="~/eTraining/Admin/download.ashx?ID={0}"
                                            FilterControlAltText="Filter Download column" Text="下載" UniqueName="Download">
                                        </telerik:GridHyperLinkColumn>
                                        <telerik:GridBoundColumn DataField="FileCategoryKey" FilterControlAltText="Filter FileCategoryKey column"
                                            HeaderText="FileCategoryKey" SortExpression="FileCategoryKey" UniqueName="FileCategoryKey"
                                            Visible="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmText="確定刪除？"
                                            FilterControlAltText="Filter Delete column" Text="刪除" UniqueName="Delete">
                                        </telerik:GridButtonColumn>
                                        <telerik:GridBoundColumn DataField="FileStoredName" FilterControlAltText="Filter FileStoredName column"
                                            UniqueName="FileStoredName" Visible="False">
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>
                                </MasterTableView>
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>
                                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                </HeaderContextMenu>
                            </telerik:RadGrid>
                            <asp:SqlDataSource ID="sdsTeachingMaterialGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                                SelectCommand="SELECT * FROM [UPLOAD] where FileCategory = 'TeachingMaterial' and FileCategoryKey=@ID
and FileDeleted =0">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="lblClassID" DefaultValue="0" Name="ID" PropertyName="Text" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView11" runat="server">
                <h3>
                    歷年開課清單</h3>
                年度<telerik:RadComboBox ID="cbxPastYear" runat="server" AutoPostBack="True" DataSourceID="sdsPastYearCbx"
                    DataTextField="iYear" DataValueField="iYear" Width="70px">
                </telerik:RadComboBox>
                <br />
                <br />
                <div class="field">
                    <fieldset style="width: 300px">
                        <legend style="font-size: 12pt">複製項目</legend>
                        <asp:CheckBoxList ID="cblCopyItem" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Selected="True" Value="trTrainingStudentM">訓練名單所有學員</asp:ListItem>
                            <asp:ListItem Value="PresenceStudents">訓練名單出席學員</asp:ListItem>
                            <asp:ListItem Selected="True" Value="knotTeaches">結訓條件</asp:ListItem>
                            <asp:ListItem Selected="True" Value="classNotify">課程通知</asp:ListItem>
                            <asp:ListItem Selected="True" Value="estimateAMT">預估費用</asp:ListItem>
                            <asp:ListItem Selected="True">問卷</asp:ListItem>
                        </asp:CheckBoxList>
                    </fieldset>
                </div>
                <br />
                <br />
                <telerik:RadGrid ID="gvPastClass" runat="server" AllowFilteringByColumn="True" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW"
                    DataSourceID="sdsPastClassGv" GridLines="None" Skin="Outlook" Width="65%">
                    <ClientSettings>
                        <Selecting AllowRowSelect="True" />
                        <Selecting AllowRowSelect="True" />
                        <Selecting AllowRowSelect="True" />
                        <Selecting AllowRowSelect="True" />
                        <Selecting AllowRowSelect="True" />
                        <Selecting AllowRowSelect="True" />
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView AllowMultiColumnSorting="True" DataKeyNames="iAutoKey" DataSourceID="sdsPastClassGv">
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                            </telerik:GridClientSelectColumn>
                            <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                                HeaderText="開課編號" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="dDateTimeA" DataType="System.DateTime" FilterControlAltText="Filter dDateTimeA column"
                                HeaderText="dDateTimeA" SortExpression="dDateTimeA" UniqueName="dDateTimeA" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="dDateTimeD" DataType="System.DateTime" FilterControlAltText="Filter dDateTimeD column"
                                HeaderText="dDateTimeD" SortExpression="dDateTimeD" UniqueName="dDateTimeD" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="dDateA" DataType="System.DateTime" FilterControlAltText="Filter dDateA column"
                                HeaderText="dDateA" SortExpression="dDateA" UniqueName="dDateA" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="dDateD" DataType="System.DateTime" FilterControlAltText="Filter dDateD column"
                                HeaderText="dDateD" SortExpression="dDateD" UniqueName="dDateD" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="iSession" DataType="System.Int32" FilterControlAltText="Filter iSession column"
                                HeaderText="梯次" SortExpression="iSession" UniqueName="iSession" AllowFiltering="False"
                                ShowFilterIcon="False">
                                <HeaderStyle Width="10px" Wrap="False" />
                                <ItemStyle Width="10px" Wrap="False" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sKey" FilterControlAltText="Filter sKey column"
                                HeaderText="階層代碼" SortExpression="sKey" UniqueName="sKey" Visible="False">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="category_sname" FilterControlAltText="Filter category_sname column"
                                HeaderText="階層" SortExpression="category_sname" UniqueName="category_sname">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="trCourse_sCode" FilterControlAltText="Filter trCourse_sCode column"
                                HeaderText="課程代碼" SortExpression="trCourse_sCode" UniqueName="trCourse_sCode"
                                FilterControlWidth="30px">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" Width="30px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="course_sname" FilterControlAltText="Filter course_sname column"
                                HeaderText="課程名稱" SortExpression="course_sname" UniqueName="course_sname">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="trTeacher_sCode" FilterControlAltText="Filter trTeacher_sCode column"
                                HeaderText="trTeacher_sCode" SortExpression="trTeacher_sCode" UniqueName="trTeacher_sCode"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="trClassroom_sCode" FilterControlAltText="Filter trClassroom_sCode column"
                                HeaderText="trClassroom_sCode" SortExpression="trClassroom_sCode" UniqueName="trClassroom_sCode"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridCheckBoxColumn DataField="bWebJoin" DataType="System.Boolean" FilterControlAltText="Filter bWebJoin column"
                                HeaderText="bWebJoin" SortExpression="bWebJoin" UniqueName="bWebJoin" Visible="False">
                            </telerik:GridCheckBoxColumn>
                            <telerik:GridBoundColumn DataField="dWebJoinDateB" DataType="System.DateTime" FilterControlAltText="Filter dWebJoinDateB column"
                                HeaderText="dWebJoinDateB" SortExpression="dWebJoinDateB" UniqueName="dWebJoinDateB"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="dWebJoinDateE" DataType="System.DateTime" FilterControlAltText="Filter dWebJoinDateE column"
                                HeaderText="dWebJoinDateE" SortExpression="dWebJoinDateE" UniqueName="dWebJoinDateE"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="iUpLimitP" DataType="System.Int32" FilterControlAltText="Filter iUpLimitP column"
                                HeaderText="iUpLimitP" SortExpression="iUpLimitP" UniqueName="iUpLimitP" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="iLowLimitP" DataType="System.Int32" FilterControlAltText="Filter iLowLimitP column"
                                HeaderText="iLowLimitP" SortExpression="iLowLimitP" UniqueName="iLowLimitP" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridCheckBoxColumn DataField="bIsPublished" DataType="System.Boolean" FilterControlAltText="Filter bIsPublished column"
                                HeaderText="bIsPublished" SortExpression="bIsPublished" UniqueName="bIsPublished"
                                Visible="False">
                            </telerik:GridCheckBoxColumn>
                            <telerik:GridBoundColumn DataField="iYearPlanAutoKey" DataType="System.Int32" FilterControlAltText="Filter iYearPlanAutoKey column"
                                HeaderText="iYearPlanAutoKey" SortExpression="iYearPlanAutoKey" UniqueName="iYearPlanAutoKey"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sMaterialSelector" FilterControlAltText="Filter sMaterialSelector column"
                                HeaderText="sMaterialSelector" SortExpression="sMaterialSelector" UniqueName="sMaterialSelector"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="iMaterialAutoKey" DataType="System.Int32" FilterControlAltText="Filter iMaterialAutoKey column"
                                HeaderText="iMaterialAutoKey" SortExpression="iMaterialAutoKey" UniqueName="iMaterialAutoKey"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sMaterialKeyMan" FilterControlAltText="Filter sMaterialKeyMan column"
                                HeaderText="sMaterialKeyMan" SortExpression="sMaterialKeyMan" UniqueName="sMaterialKeyMan"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="dMaterialKeyDate" DataType="System.DateTime"
                                FilterControlAltText="Filter dMaterialKeyDate column" HeaderText="dMaterialKeyDate"
                                SortExpression="dMaterialKeyDate" UniqueName="dMaterialKeyDate" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="iEstimateAMT" DataType="System.Int32" FilterControlAltText="Filter iEstimateAMT column"
                                HeaderText="預估費用" SortExpression="iEstimateAMT" UniqueName="iEstimateAMT" AllowFiltering="False"
                                ShowFilterIcon="False" Visible="False">
                                <ItemStyle Wrap="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="iActualAMT" DataType="System.Int32" FilterControlAltText="Filter iActualAMT column"
                                HeaderText="iActualAMT" SortExpression="iActualAMT" UniqueName="iActualAMT" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="iCourseTime" DataType="System.Int32" FilterControlAltText="Filter iCourseTime column"
                                HeaderText="上課時數" SortExpression="iCourseTime" UniqueName="iCourseTime" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="iJobScore" DataType="System.Int32" FilterControlAltText="Filter iJobScore column"
                                HeaderText="職能積分" SortExpression="iJobScore" UniqueName="iJobScore" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="trTrainingMethod_sCode" FilterControlAltText="Filter trTrainingMethod_sCode column"
                                HeaderText="訓練方式" SortExpression="trTrainingMethod_sCode" UniqueName="trTrainingMethod_sCode"
                                Visible="False">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
                    <FilterMenu EnableImageSprites="False">
                        <WebServiceSettings>
                            <ODataSettings InitialContainerName="">
                            </ODataSettings>
                        </WebServiceSettings>
                    </FilterMenu>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                        <WebServiceSettings>
                            <ODataSettings InitialContainerName="">
                            </ODataSettings>
                        </WebServiceSettings>
                    </HeaderContextMenu>
                </telerik:RadGrid>
                <asp:SqlDataSource ID="sdsPastClassGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                    SelectCommand="SELECT class.*,c.sName as course_sname,cat.sName as category_sname  FROM [trTrainingDetailM] class join trCourse c on class.trCourse_sCode = c.sCode  join trCategory cat on class.sKey = cat.sCode  where iYear = @iYear and bIsPublished = 1 and skey=@Cate
union all
SELECT class.*,c.sName as course_sname,cat.sName as category_sname  FROM [trTrainingDetailM] class join trCourse c on class.trCourse_sCode = c.sCode  join trCategory cat on class.sKey = cat.sCode  where iYear = @iYear and bIsPublished = 1 and skey&lt;&gt;@Cate">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="cbxPastYear" DefaultValue="0" Name="iYear" PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="lblCateCode" DefaultValue="0" Name="Cate" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="sdsPastYearCbx" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                    SelectCommand="select distinct iYear from trTrainingDetailM order by iYear desc">
                </asp:SqlDataSource>
                <br />
                <telerik:RadButton ID="btnCloneClass" runat="server" OnClick="btnCloneClass_Click"
                    Skin="Windows7" Text="確定">
                </telerik:RadButton>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView12" runat="server">
                <div class="field">
                    <fieldset style="width: 140px">
                        <legend style="font-size: 12pt">線上報名</legend>
                        <asp:RadioButtonList ID="rbtnJoin" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                            OnSelectedIndexChanged="rbtnJoin_SelectedIndexChanged">
                            <asp:ListItem Value="y">提供</asp:ListItem>
                            <asp:ListItem Value="n" Selected="True">不提供</asp:ListItem>
                        </asp:RadioButtonList>
                    </fieldset>
                </div>
                <asp:Label ID="lblPublishMsg" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <asp:Panel ID="pnlWebAdd" runat="server" Visible="False">
                    <table class="tableBlue">
                        <tr>
                            <th width="100px">
                                報名起迄日
                            </th>
                            <td>
                                <telerik:RadDateTimePicker ID="dpBDate" runat="server" Culture="zh-TW">
                                    <TimeView CellSpacing="-1" Culture="zh-TW">
                                    </TimeView>
                                    <TimePopupButton HoverImageUrl="" ImageUrl="" />
                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput DateFormat="yyyy/M/d HH:mm" DisplayDateFormat="yyyy/M/d HH:mm" DisplayText=""
                                        LabelWidth="40%" type="text" value="">
                                    </DateInput>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDateTimePicker>
                                ~<telerik:RadDateTimePicker ID="dpEDate" runat="server" Culture="zh-TW">
                                    <TimeView CellSpacing="-1" Culture="zh-TW">
                                    </TimeView>
                                    <TimePopupButton HoverImageUrl="" ImageUrl="" />
                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput DateFormat="yyyy/M/d HH:mm" DisplayDateFormat="yyyy/M/d HH:mm" DisplayText=""
                                        LabelWidth="40%" type="text" value="">
                                    </DateInput>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDateTimePicker>
                                <telerik:RadButton ID="RadButton7" runat="server" Text="存檔" OnClick="RadButton7_Click">
                                </telerik:RadButton>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <telerik:RadButton ID="btnPublished" runat="server" Text="發佈課程" OnClick="btnPublished_Click">
                </telerik:RadButton>
                <telerik:RadButton ID="btnUnpublished" runat="server" OnClick="btnUnpublished_Click"
                    Text="取消發佈">
                </telerik:RadButton>
                <br />
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView2" runat="server">
                <br />
                <asp:Panel ID="pnlTeachingMaterial" runat="server" Visible="True">
                    <div class="field">
                        <fieldset style="width: 320px">
                            <legend>選擇設定</legend>
                            <asp:RadioButtonList ID="rblSet" runat="server" AutoPostBack="True" Font-Size="Medium"
                                RepeatDirection="Horizontal" OnSelectedIndexChanged="rblSet_SelectedIndexChanged">
                                <asp:ListItem Value="M">設定教案</asp:ListItem>
                                <asp:ListItem Value="T">講師設定教案</asp:ListItem>
                                <asp:ListItem Value="N">不使用教案</asp:ListItem>
                            </asp:RadioButtonList>
                        </fieldset>
                    </div>
                    課程選定教案編號：<asp:Label ID="lblMaterialCode" runat="server"></asp:Label><telerik:RadGrid
                        ID="gvTeachingMaterialList" runat="server" CellSpacing="0" DataSourceID="sdsTeachingMaterial"
                        GridLines="None" Skin="Outlook" Culture="zh-TW" AllowFilteringByColumn="True"
                        AllowPaging="True" AllowSorting="True" OnItemDataBound="gvTeachingMaterialList_ItemDataBound"
                        OnSelectedIndexChanged="gvTeachingMaterialList_SelectedIndexChanged">
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="iAutoKey" DataSourceID="sdsTeachingMaterial">
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridButtonColumn CommandName="Select" FilterControlAltText="Filter column column"
                                    Text="選擇" UniqueName="column">
                                </telerik:GridButtonColumn>
                                <telerik:GridBoundColumn DataField="iAutoKey" FilterControlAltText="Filter iAutoKey column"
                                    HeaderText="教案編號" UniqueName="iAutoKey">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="trCourse_sCode" FilterControlAltText="Filter trCourse_sCode column"
                                    HeaderText="課程名稱" SortExpression="trCourse_sCode" UniqueName="trCourse_sCode">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="sCoursePolicy" FilterControlAltText="Filter sCoursePolicy column"
                                    HeaderText="課程目標" SortExpression="sCoursePolicy" UniqueName="sCoursePolicy">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="sCourseExpect" FilterControlAltText="Filter sCourseExpect column"
                                    HeaderText="具體目標" SortExpression="sCourseExpect" UniqueName="sCourseExpect">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView><FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Outlook">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                    <asp:SqlDataSource ID="sdsTeachingMaterial" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                        SelectCommand="SELECT * FROM [trTeachingMaterial]"></asp:SqlDataSource>
                </asp:Panel>
                <br />
                <telerik:RadButton ID="btnMaterialSave" runat="server" Text="存檔" OnClick="btnMaterialSave_Click">
                </telerik:RadButton>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView3" runat="server">
                <div style="float: left; width: 29%">
                    <h2>
                        選擇結訓條件</h2>
                    <telerik:RadGrid ID="gvKnotTeachesList" runat="server" AllowMultiRowSelection="True"
                        CellSpacing="0" Culture="zh-TW" DataSourceID="sdsKnotTeachesList" GridLines="None"
                        Skin="Outlook" Width="95%" AutoGenerateColumns="False" OnItemDataBound="gvKnotTeachesList_ItemDataBound">
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" />
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <MasterTableView DataKeyNames="KnotTeachesCode" DataSourceID="sdsKnotTeachesList">
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                                </telerik:GridClientSelectColumn>
                                <telerik:GridBoundColumn DataField="KnotTeachesCode" FilterControlAltText="Filter KnotTeachesCode column"
                                    HeaderText="KnotTeachesCode" ReadOnly="True" SortExpression="KnotTeachesCode"
                                    UniqueName="KnotTeachesCode" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="KnotTeachesName" FilterControlAltText="Filter KnotTeachesName column"
                                    HeaderText="結訓項目" SortExpression="KnotTeachesName" UniqueName="KnotTeachesName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="trKnotTeaches_sCode" FilterControlAltText="Filter trKnotTeaches_sCode column"
                                    HeaderText="trKnotTeaches_sCode" SortExpression="trKnotTeaches_sCode" UniqueName="trKnotTeaches_sCode"
                                    EmptyDataText="" Visible="False">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Outlook">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                    <asp:SqlDataSource ID="sdsKnotTeachesList" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                        SelectCommand="select kt.*,ds.trKnotTeaches_sCode from trKnotTeaches kt left join trTrainingDetailS ds
 on kt.KnotTeachesCode = ds.trKnotTeaches_sCode and iClassAutoKey=@ID order by KnotTeachesName
">
                        <SelectParameters>
                            <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="ID" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <telerik:RadButton ID="btnClassKnotTeaches" runat="server" OnClick="btnClassKnotTeaches_Click"
                        Text="存檔">
                    </telerik:RadButton>
                    <asp:Label ID="lblMsgKnot" runat="server" ForeColor="Red"></asp:Label>
                </div>
                <div style="float: right; width: 70%">
                    <h2>
                        選擇問卷</h2>
                    <asp:Panel ID="pnlAddQ" runat="server">
                        <asp:Label ID="lblQnView" runat="server" Visible="False"></asp:Label>
                        <div style="float: left; width: 70%">
                            <telerik:RadGrid ID="gvQList" runat="server" AllowMultiRowSelection="True" CellSpacing="0"
                                Culture="zh-TW" DataSourceID="sdsQList" GridLines="None" Skin="Outlook" OnItemDataBound="gvQList_ItemDataBound"
                                AutoGenerateColumns="False" OnItemCommand="gvQList_ItemCommand">
                                <ClientSettings>
                                    <Selecting AllowRowSelect="True" />
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <MasterTableView DataKeyNames="Code" DataSourceID="sdsQList" AllowFilteringByColumn="True"
                                    AllowSorting="True">
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                                        </telerik:GridClientSelectColumn>
                                        <telerik:GridBoundColumn DataField="Code" FilterControlAltText="Filter Code column"
                                            HeaderText="Code" SortExpression="Code" UniqueName="Code" Visible="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Name" FilterControlAltText="Filter Name column"
                                            HeaderText="問卷名稱" SortExpression="Name" UniqueName="Name">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="qQuestionaryM" FilterControlAltText="Filter qQuestionaryM column"
                                            HeaderText="qQuestionaryM" SortExpression="qQuestionaryM" UniqueName="qQuestionaryM"
                                            EmptyDataText="" Visible="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="FillerCategory" FilterControlAltText="Filter FillerCategory column"
                                            HeaderText="填寫人種類" UniqueName="FillerCategory" Visible="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridButtonColumn CommandName="View" FilterControlAltText="Filter View column"
                                            Text="自訂人員" UniqueName="View">
                                        </telerik:GridButtonColumn>
                                    </Columns>
                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>
                                </MasterTableView>
                                <FilterMenu EnableImageSprites="False">
                                    <WebServiceSettings>
                                        <ODataSettings InitialContainerName="">
                                        </ODataSettings>
                                    </WebServiceSettings>
                                </FilterMenu>
                                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                    <WebServiceSettings>
                                        <ODataSettings InitialContainerName="">
                                        </ODataSettings>
                                    </WebServiceSettings>
                                </HeaderContextMenu>
                            </telerik:RadGrid>
                            <telerik:RadButton ID="btnCheckQ" runat="server" Text="存檔" OnClick="btnCheckQ_Click">
                            </telerik:RadButton>
                            <asp:Label ID="lblMsgQues" runat="server" ForeColor="Red"></asp:Label>
                            <br />
                            <asp:SqlDataSource ID="sdsQList" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                                SelectCommand="select qm.*,cq.qQuestionaryM from QTpl  qm left join ClassQuestionnaire cq  on cq.qQuestionaryM = qm.Code and  iClassAutoKey = @ID">
                                <SelectParameters>
                                    <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="ID" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="sdsClassQnCU" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                                SelectCommand="select cu.*,b.NAME_C from ClassQuestionnaireCU cu join BASE b on cu.Nobr = b.NOBR
where iClassAutoKey =@ClassID and qQuestionaryM = @Qn" DeleteCommand="delete ClassQuestionnaireCU where iAutoKey =@iAutoKey">
                                <DeleteParameters>
                                    <asp:Parameter Name="iAutoKey" />
                                </DeleteParameters>
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="lblClassID" DefaultValue=" " Name="ClassID" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="lblQnView" DefaultValue=" " Name="Qn" PropertyName="Text" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                        <div style="float: right; width: 29%">
                            <asp:Panel ID="pnClassQnCU" runat="server" Visible="False">
                                <asp:Label ID="lblClassQnCUName" runat="server" Font-Size="Large" ForeColor="#6666FF"></asp:Label>
                                <telerik:RadGrid ID="gvClassQnCU" runat="server" CellSpacing="0" Culture="zh-TW"
                                    DataSourceID="sdsClassQnCU" GridLines="None" AutoGenerateDeleteColumn="True"
                                    AllowAutomaticDeletes="True">
                                    <MasterTableView AutoGenerateColumns="False" DataSourceID="sdsClassQnCU" DataKeyNames="iAutoKey">
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                                                HeaderText="iAutoKey" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                                                Visible="False">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="iClassAutoKey" DataType="System.Int32" FilterControlAltText="Filter iClassAutoKey column"
                                                HeaderText="iClassAutoKey" SortExpression="iClassAutoKey" UniqueName="iClassAutoKey"
                                                Visible="False">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="qQuestionaryM" FilterControlAltText="Filter qQuestionaryM column"
                                                HeaderText="qQuestionaryM" SortExpression="qQuestionaryM" UniqueName="qQuestionaryM"
                                                Visible="False">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Nobr" FilterControlAltText="Filter Nobr column"
                                                HeaderText="工號" SortExpression="Nobr" UniqueName="Nobr">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="sKeyMan" FilterControlAltText="Filter sKeyMan column"
                                                HeaderText="sKeyMan" SortExpression="sKeyMan" UniqueName="sKeyMan" Visible="False">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" FilterControlAltText="Filter dKeyDate column"
                                                HeaderText="dKeyDate" SortExpression="dKeyDate" UniqueName="dKeyDate" Visible="False">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                                                HeaderText="姓名" SortExpression="NAME_C" UniqueName="NAME_C">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                    </MasterTableView>
                                    <FilterMenu EnableImageSprites="False">
                                    </FilterMenu>
                                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                    </HeaderContextMenu>
                                </telerik:RadGrid>
                                <telerik:RadButton ID="btnAddClassQnCU" runat="server" Text="新增問卷使用者" OnClick="btnAddClassQnCU_Click">
                                </telerik:RadButton>
                                <telerik:RadButton ID="btnCloseClassQnCU" runat="server" OnClick="btnCloseClassQnCU_Click"
                                    Text="關閉">
                                </telerik:RadButton>
                            </asp:Panel>
                            <telerik:RadWindow ID="winUser" runat="server" Modal="True" Height="600px" Width="500px">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlNobr" runat="server">
                                        <div class="funcblock" style="width: 450px; background-color: #CDE5FF">
                                            <br />
                                            姓名<telerik:RadTextBox ID="txtName" runat="server">
                                            </telerik:RadTextBox>
                                            &nbsp;&nbsp;
                                            <telerik:RadButton ID="btnSearchNobr" runat="server" Text="查詢" OnClick="btnSearchNobr_Click">
                                            </telerik:RadButton>
                                            <br />
                                            <br />
                                            <telerik:RadGrid ID="gvNobr" runat="server" AllowPaging="True" CellSpacing="0" Culture="zh-TW"
                                                GridLines="None" Skin="Outlook" DataSourceID="sdsNobr">
                                                <ClientSettings>
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="NOBR" DataSourceID="sdsNobr">
                                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                                    </RowIndicatorColumn>
                                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                                    </ExpandCollapseColumn>
                                                    <Columns>
                                                        <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                                                        </telerik:GridClientSelectColumn>
                                                        <telerik:GridBoundColumn DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                                                            HeaderText="姓名" SortExpression="NAME_C" UniqueName="NAME_C">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="NOBR" FilterControlAltText="Filter NOBR column"
                                                            HeaderText="工號" SortExpression="NOBR" UniqueName="NOBR">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="D_NAME" FilterControlAltText="Filter D_NAME column"
                                                            HeaderText="部門" SortExpression="D_NAME" UniqueName="D_NAME">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="JOB_NAME" FilterControlAltText="Filter JOB_NAME column"
                                                            HeaderText="職稱" SortExpression="JOB_NAME" UniqueName="JOB_NAME">
                                                        </telerik:GridBoundColumn>
                                                    </Columns>
                                                    <EditFormSettings>
                                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                        </EditColumn>
                                                    </EditFormSettings>
                                                </MasterTableView>
                                                <FilterMenu EnableImageSprites="False">
                                                </FilterMenu>
                                                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                                </HeaderContextMenu>
                                            </telerik:RadGrid>
                                            <asp:SqlDataSource ID="sdsNobr" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                                                SelectCommand="select b.NAME_C,tts.NOBR,d.D_NAME,j.JOB_NAME from BASE b
join BASETTS tts on b.NOBR=tts.NOBR
join DEPT d on tts.DEPT=d.D_NO
join JOB j on tts.JOB=j.JOB
where b.NAME_C like @txtName + '%'
and CONVERT(varchar(10), GETDATE(),111) between tts.ADATE and tts.DDATE
and tts.TTSCODE in('1','4','6')">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="txtName" DefaultValue=" " Name="txtName" PropertyName="Text" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <br />
                                        </div>
                                    </asp:Panel>
                                    <br />
                                    <telerik:RadButton ID="btnSave" runat="server" OnClick="btnSave_Click" Text="存檔">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="關閉">
                                    </telerik:RadButton>
                                </ContentTemplate>
                            </telerik:RadWindow>
                        </div>
                    </asp:Panel>
                </div>
                <br />
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView4" runat="server">
                <h3>
                    學員清單</h3>
                <div class="field">
                    <fieldset style="width: 160px">
                        <legend>必訓人員</legend>
                        <asp:RadioButtonList ID="rblMemberSelect" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="Category">從類別</asp:ListItem>
                            <asp:ListItem Selected="True" Value="Course">從課程</asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                        <telerik:RadButton ID="btnLoadMustTraining" runat="server" OnClick="btnLoadMustTraining_Click"
                            Text="載入">
                        </telerik:RadButton>
                        <br />
                    </fieldset>
                    <br />
                </div>
                <br />
                <telerik:RadButton ID="btnAddMember" runat="server" Text="加入學員" OnClick="btnAddMember_Click">
                </telerik:RadButton>
                &nbsp;
                <telerik:RadButton ID="btnDelQualifier" runat="server" OnClick="btnDelQualifier_Click"
                    Text="刪除已有資格者" ForeColor="Red">
                </telerik:RadButton>
                <br />
                <br />
                <telerik:RadGrid ID="gvTrainingStudentList" runat="server" Skin="Outlook" Width="70%"
                    AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                    CellSpacing="0" Culture="zh-TW" DataSourceID="sdsGvTrainingStudentList" GridLines="None"
                    OnItemDeleted="gvTrainingStudentList_ItemDeleted" OnItemCommand="gvTrainingStudentList_ItemCommand">
                    <ClientSettings>
                        <Selecting CellSelectionMode="None" />
                    </ClientSettings>
                    <MasterTableView AllowMultiColumnSorting="True" DataKeyNames="iAutoKey" DataSourceID="sdsGvTrainingStudentList">
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridTemplateColumn AllowFiltering="False" FilterControlAltText="Filter Item column"
                                UniqueName="Item">
                                <ItemTemplate>
                                    <%# Container.DataSetIndex + 1 %>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="name_c" FilterControlAltText="Filter name_c column"
                                HeaderText="姓名" SortExpression="name_c" UniqueName="name_c">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_NAME" FilterControlAltText="Filter JOB_NAME column"
                                HeaderText="職稱" SortExpression="JOB_NAME" UniqueName="JOB_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="D_NO" FilterControlAltText="Filter D_NO column"
                                HeaderText="部門代碼" UniqueName="D_NO">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="D_NAME" FilterControlAltText="Filter D_NAME column"
                                HeaderText="部門" SortExpression="D_NAME" UniqueName="D_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sNobr" FilterControlAltText="Filter sNobr column"
                                HeaderText="工號" SortExpression="sNobr" UniqueName="sNobr">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="trJoinType_sCode" FilterControlAltText="Filter trJoinType_sCode column"
                                HeaderText="trJoinType_sCode" SortExpression="trJoinType_sCode" UniqueName="trJoinType_sCode"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sJoblCode" FilterControlAltText="Filter sJoblCode column"
                                HeaderText="sJoblCode" SortExpression="sJoblCode" UniqueName="sJoblCode" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridCheckBoxColumn DataField="bAbsence" DataType="System.Boolean" FilterControlAltText="Filter bAbsence column"
                                HeaderText="bAbsence" SortExpression="bAbsence" UniqueName="bAbsence" Visible="False">
                            </telerik:GridCheckBoxColumn>
                            <telerik:GridBoundColumn DataField="sAbsenceNote" FilterControlAltText="Filter sAbsenceNote column"
                                HeaderText="sAbsenceNote" SortExpression="sAbsenceNote" UniqueName="sAbsenceNote"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="iScore" DataType="System.Decimal" FilterControlAltText="Filter iScore column"
                                HeaderText="iScore" SortExpression="iScore" UniqueName="iScore" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="iClassAutoKey" DataType="System.Int32" FilterControlAltText="Filter iClassAutoKey column"
                                HeaderText="iClassAutoKey" SortExpression="iClassAutoKey" UniqueName="iClassAutoKey"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridCheckBoxColumn DataField="bPass" DataType="System.Boolean" FilterControlAltText="Filter bPass column"
                                HeaderText="bPass" SortExpression="bPass" UniqueName="bPass" Visible="False">
                            </telerik:GridCheckBoxColumn>
                            <telerik:GridBoundColumn DataField="sPassNote" FilterControlAltText="Filter sPassNote column"
                                HeaderText="sPassNote" SortExpression="sPassNote" UniqueName="sPassNote" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sJobCode" FilterControlAltText="Filter sJobCode column"
                                HeaderText="sJobCode" SortExpression="sJobCode" UniqueName="sJobCode" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                                HeaderText="iAutoKey" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sDeptCode" FilterControlAltText="Filter sDeptCode column"
                                HeaderText="sDeptCode" SortExpression="sDeptCode" UniqueName="sDeptCode" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sJobsCode" FilterControlAltText="Filter sJobsCode column"
                                HeaderText="sJobsCode" SortExpression="sJobsCode" UniqueName="sJobsCode" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sKeyMan" FilterControlAltText="Filter sKeyMan column"
                                HeaderText="sKeyMan" SortExpression="sKeyMan" UniqueName="sKeyMan" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" FilterControlAltText="Filter dKeyDate column"
                                HeaderText="dKeyDate" SortExpression="dKeyDate" UniqueName="dKeyDate" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmDialogType="RadWindow"
                                FilterControlAltText="Filter delete column" UniqueName="delete">
                            </telerik:GridButtonColumn>
                            <telerik:GridBoundColumn DataField="EMAIL" FilterControlAltText="Filter EMAIL column"
                                HeaderText="EMAIL" UniqueName="EMAIL">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
                    <FilterMenu EnableImageSprites="False">
                    </FilterMenu>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Outlook">
                    </HeaderContextMenu>
                </telerik:RadGrid><asp:SqlDataSource ID="sdsGvTrainingStudentList" runat="server"
                    ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" DeleteCommand="DELETE FROM [trTrainingStudentM] WHERE [iAutoKey] = @iAutoKey"
                    InsertCommand="INSERT INTO [trTrainingStudentM] ([iClassAutoKey], [sJobCode], [sJobsCode], [sJoblCode], [sDeptCode], [sNobr], [trJoinType_sCode], [bAbsence], [sAbsenceNote], [sNote1], [iScore], [bPass], [sPassNote], [sNote2], [sNote3], [sNote4], [sNote5], [sKeyMan], [dKeyDate]) VALUES (@iClassAutoKey, @sJobCode, @sJobsCode, @sJoblCode, @sDeptCode, @sNobr, @trJoinType_sCode, @bAbsence, @sAbsenceNote, @sNote1, @iScore, @bPass, @sPassNote, @sNote2, @sNote3, @sNote4, @sNote5, @sKeyMan, @dKeyDate)"
                    SelectCommand="select stu.*,job.JOB_NAME,dept.D_NAME,dept.D_NO,base.name_c,base.EMAIL
  FROM trTrainingStudentM stu 
  left join job on stu.sJobCode = job.JOB
  left join dept on stu.sDeptCode = dept.d_no
  left join base on stu.sNobr = base.NOBR
where stu.iClassAutokey =@iClassAutokey " UpdateCommand="UPDATE [trTrainingStudentM] SET [iClassAutoKey] = @iClassAutoKey, [sJobCode] = @sJobCode, [sJobsCode] = @sJobsCode, [sJoblCode] = @sJoblCode, [sDeptCode] = @sDeptCode, [sNobr] = @sNobr, [trJoinType_sCode] = @trJoinType_sCode, [bAbsence] = @bAbsence, [sAbsenceNote] = @sAbsenceNote, [sNote1] = @sNote1, [iScore] = @iScore, [bPass] = @bPass, [sPassNote] = @sPassNote, [sNote2] = @sNote2, [sNote3] = @sNote3, [sNote4] = @sNote4, [sNote5] = @sNote5, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
                    <DeleteParameters>
                        <asp:Parameter Name="iAutoKey" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="iClassAutoKey" Type="Int32" />
                        <asp:Parameter Name="sJobCode" Type="String" />
                        <asp:Parameter Name="sJobsCode" Type="String" />
                        <asp:Parameter Name="sJoblCode" Type="String" />
                        <asp:Parameter Name="sDeptCode" Type="String" />
                        <asp:Parameter Name="sNobr" Type="String" />
                        <asp:Parameter Name="trJoinType_sCode" Type="String" />
                        <asp:Parameter Name="bAbsence" Type="Boolean" />
                        <asp:Parameter Name="sAbsenceNote" Type="String" />
                        <asp:Parameter Name="sNote1" Type="String" />
                        <asp:Parameter Name="iScore" Type="Decimal" />
                        <asp:Parameter Name="bPass" Type="Boolean" />
                        <asp:Parameter Name="sPassNote" Type="String" />
                        <asp:Parameter Name="sNote2" Type="String" />
                        <asp:Parameter Name="sNote3" Type="String" />
                        <asp:Parameter Name="sNote4" Type="String" />
                        <asp:Parameter Name="sNote5" Type="String" />
                        <asp:Parameter Name="sKeyMan" Type="String" />
                        <asp:Parameter Name="dKeyDate" Type="DateTime" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lblClassID" DefaultValue="0" Name="iClassAutokey"
                            PropertyName="Text" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="iClassAutoKey" Type="Int32" />
                        <asp:Parameter Name="sJobCode" Type="String" />
                        <asp:Parameter Name="sJobsCode" Type="String" />
                        <asp:Parameter Name="sJoblCode" Type="String" />
                        <asp:Parameter Name="sDeptCode" Type="String" />
                        <asp:Parameter Name="sNobr" Type="String" />
                        <asp:Parameter Name="trJoinType_sCode" Type="String" />
                        <asp:Parameter Name="bAbsence" Type="Boolean" />
                        <asp:Parameter Name="sAbsenceNote" Type="String" />
                        <asp:Parameter Name="sNote1" Type="String" />
                        <asp:Parameter Name="iScore" Type="Decimal" />
                        <asp:Parameter Name="bPass" Type="Boolean" />
                        <asp:Parameter Name="sPassNote" Type="String" />
                        <asp:Parameter Name="sNote2" Type="String" />
                        <asp:Parameter Name="sNote3" Type="String" />
                        <asp:Parameter Name="sNote4" Type="String" />
                        <asp:Parameter Name="sNote5" Type="String" />
                        <asp:Parameter Name="sKeyMan" Type="String" />
                        <asp:Parameter Name="dKeyDate" Type="DateTime" />
                        <asp:Parameter Name="iAutoKey" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="sdsUserList" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                    SelectCommand="select base.nobr,base.name_c,tts.job,tts.indt,dept.D_NAME,dept.D_NO,job.JOB_NAME from base left join basetts tts on base.nobr = tts.nobr
left join dept on tts.dept = dept.D_NO
left join job on tts.job = job.job
where tts.ttscode in ('1','4','6') 
and CONVERT(varchar(10), GETDATE(),111) between tts.adate and tts.ddate
and CONVERT(varchar(10), GETDATE(),111) between dept.adate and dept.ddate"></asp:SqlDataSource>
                <br />
                <br />
                <asp:Panel ID="pnlAddMember" runat="server" Visible="False">
                    <asp:CheckBox ID="cbIsPage" runat="server" AutoPostBack="True" Checked="True" OnCheckedChanged="cbIsPage_CheckedChanged"
                        Text="是否分頁" />
                    &#160;<telerik:RadButton ID="btnAddTrainingUser0" runat="server" OnClick="btnAddTrainingUser_Click"
                        Text="加入學員">
                    </telerik:RadButton>
                    &nbsp;
                    <telerik:RadButton ID="btnCancelAddTrainingUser0" runat="server" OnClick="btnCancelAddTrainingUser_Click"
                        Text="關閉加入學員">
                    </telerik:RadButton>
                    <telerik:RadGrid ID="gvUserList" runat="server" AllowFilteringByColumn="True" AllowMultiRowSelection="True"
                        AllowPaging="True" AllowSorting="True" CellSpacing="0" Culture="zh-TW" DataSourceID="sdsUserList"
                        GridLines="None" Skin="Outlook">
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <MasterTableView AllowMultiColumnSorting="True" AutoGenerateColumns="False" DataSourceID="sdsUserList">
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                                </telerik:GridClientSelectColumn>
                                <telerik:GridBoundColumn DataField="nobr" FilterControlAltText="Filter nobr column"
                                    HeaderText="工號" SortExpression="nobr" UniqueName="nobr">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="name_c" FilterControlAltText="Filter name_c column"
                                    HeaderText="姓名" SortExpression="name_c" UniqueName="name_c">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="D_NO" FilterControlAltText="Filter D_NO column"
                                    HeaderText="部門代碼" UniqueName="D_NO">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="D_NAME" FilterControlAltText="Filter D_NAME column"
                                    HeaderText="部門" SortExpression="D_NAME" UniqueName="D_NAME">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="JOB_NAME" FilterControlAltText="Filter JOB_NAME column"
                                    HeaderText="職稱" SortExpression="JOB_NAME" UniqueName="JOB_NAME">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="job" FilterControlAltText="Filter job column"
                                    HeaderText="職稱" SortExpression="job" UniqueName="job" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="indt" DataFormatString="{0:d}" DataType="System.DateTime"
                                    FilterControlAltText="Filter indt column" HeaderText="到職日" UniqueName="indt">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Outlook">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                    <telerik:RadButton ID="btnAddTrainingUser" runat="server" OnClick="btnAddTrainingUser_Click"
                        Text="加入學員">
                    </telerik:RadButton>
                    &nbsp;
                    <telerik:RadButton ID="btnCancelAddTrainingUser" runat="server" OnClick="btnCancelAddTrainingUser_Click"
                        Text="關閉加入學員">
                    </telerik:RadButton>
                    <br />
                </asp:Panel>
            </telerik:RadPageView>
            <telerik:RadPageView ID="pvNotify" runat="server">
                <br />
                <div style="float: left; width: 100%">
                    <div style="float: left; width: 48%">
                        樣版<telerik:RadComboBox ID="cbxNotifyTpl" runat="server" DataSourceID="sdsNotifyTplCbx"
                            DataTextField="sName" DataValueField="sCode" Width="125px">
                        </telerik:RadComboBox>
                        <telerik:RadButton ID="btnAddNotifyTpl" runat="server" Text="加入通知樣版" OnClick="btnAddNotifyTpl_Click">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnDelAllNotify" runat="server" ForeColor="Red" OnClick="btnDelAllNotify_Click"
                            Text="清空通知項目" OnClientClicking="StandardConfirm">
                        </telerik:RadButton>
                        <br />
                        <br />
                        <telerik:RadGrid ID="gvClassNotify" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                            Culture="zh-TW" DataSourceID="sdsClassNotifyGV" GridLines="None" Skin="Outlook">
                            <MasterTableView AllowAutomaticDeletes="True" DataKeyNames="iAutoKey" DataSourceID="sdsClassNotifyGV">
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                                        HeaderText="名稱" SortExpression="sName" UniqueName="sName">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn DataField="iTimespan" DataType="System.Int32" FilterControlAltText="Filter iTimespan column"
                                        HeaderText="天數間距" SortExpression="iTimespan" UniqueName="iTimespan">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="iTimespanTextBox" runat="server" Text='<%# Bind("iTimespan") %>'
                                                Width="30px"></asp:TextBox></EditItemTemplate>
                                        <ItemTemplate>
                                            <telerik:RadNumericTextBox ID="ntb_iTimespan" runat="server" Culture="zh-TW" DataType="System.Int32"
                                                DbValue='<%# Bind("iTimespan") %>' Width="30px">
                                                <NumberFormat DecimalDigits="0" />
                                            </telerik:RadNumericTextBox></ItemTemplate>
                                        <HeaderStyle Width="30px" Wrap="False" />
                                        <ItemStyle Width="30px" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="dNotifyDate" DataFormatString="{0:d}" FilterControlAltText="Filter dNotifyDate column"
                                        HeaderText="通知日期" UniqueName="dNotifyDate">
                                        <HeaderStyle Width="80px" Wrap="False" />
                                        <ItemStyle Width="80px" Wrap="False" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="iNotifyItemAutoKey" DataType="System.Int32" FilterControlAltText="Filter iNotifyItemAutoKey column"
                                        HeaderText="iNotifyItemAutoKey" SortExpression="iNotifyItemAutoKey" UniqueName="iNotifyItemAutoKey"
                                        Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="iClassAutoKey" DataType="System.Int32" FilterControlAltText="Filter iClassAutoKey column"
                                        HeaderText="iClassAutoKey" SortExpression="iClassAutoKey" UniqueName="iClassAutoKey"
                                        Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                                        HeaderText="iAutoKey" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                                        Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmDialogType="RadWindow"
                                        ConfirmText="確定刪除?" FilterControlAltText="Filter column column" UniqueName="column">
                                        <HeaderStyle Width="20px" />
                                        <ItemStyle Width="20px" />
                                    </telerik:GridButtonColumn>
                                </Columns>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                    </EditColumn>
                                </EditFormSettings>
                            </MasterTableView><FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                            </HeaderContextMenu>
                        </telerik:RadGrid>
                        <br />
                        <telerik:RadButton ID="btnSaveClassNotify" runat="server" OnClick="btnSaveClassNotify_Click"
                            Text="存檔">
                        </telerik:RadButton>
                        <asp:SqlDataSource ID="sdsClassNotifyGV" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                            SelectCommand="SELECT cn.*,item.sName FROM [trClassNotify] cn join trNotifyItem item on cn.iNotifyItemAutoKey = item.iAutoKey WHERE ([iClassAutoKey] = @iClassAutoKey) 
order by cn.iTimespan" DeleteCommand="DELETE FROM [trClassNotify] WHERE [iAutoKey] = @iAutoKey" InsertCommand="INSERT INTO [trClassNotify] ([iClassAutoKey], [iNotifyItemAutoKey], [iTimespan], [sKeyMan], [dKeyDate]) VALUES (@iClassAutoKey, @iNotifyItemAutoKey, @iTimespan, @sKeyMan, @dKeyDate)"
                            UpdateCommand="UPDATE [trClassNotify] SET [iClassAutoKey] = @iClassAutoKey, [iNotifyItemAutoKey] = @iNotifyItemAutoKey, [iTimespan] = @iTimespan, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
                            <DeleteParameters>
                                <asp:Parameter Name="iAutoKey" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="iClassAutoKey" Type="Int32" />
                                <asp:Parameter Name="iNotifyItemAutoKey" Type="Int32" />
                                <asp:Parameter Name="iTimespan" Type="Int32" />
                                <asp:Parameter Name="sKeyMan" Type="String" />
                                <asp:Parameter Name="dKeyDate" Type="DateTime" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblClassID" DefaultValue="0" Name="iClassAutoKey"
                                    PropertyName="Text" Type="Int32" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="iClassAutoKey" Type="Int32" />
                                <asp:Parameter Name="iNotifyItemAutoKey" Type="Int32" />
                                <asp:Parameter Name="iTimespan" Type="Int32" />
                                <asp:Parameter Name="sKeyMan" Type="String" />
                                <asp:Parameter Name="dKeyDate" Type="DateTime" />
                                <asp:Parameter Name="iAutoKey" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="sdsNotifyTplCbx" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                            SelectCommand="SELECT * FROM [trNotifyTemplate]"></asp:SqlDataSource>
                    </div>
                    <div style="float: right; width: 49%">
                        <telerik:RadButton ID="btnAddItem" runat="server" Text="加入新項目" OnClick="btnAddItem_Click">
                        </telerik:RadButton>
                        <telerik:RadGrid ID="gvNotifyItem" runat="server" CellSpacing="0" Culture="zh-TW"
                            DataSourceID="sdsNotifyItem" GridLines="None" Skin="Windows7" Visible="False"
                            AutoGenerateColumns="False" OnSelectedIndexChanged="gvNotifyItem_SelectedIndexChanged">
                            <MasterTableView DataKeyNames="iAutokey" DataSourceID="sdsNotifyItem">
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridButtonColumn CommandName="Select" FilterControlAltText="Filter column column"
                                        Text="加入" UniqueName="column">
                                    </telerik:GridButtonColumn>
                                    <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                                        HeaderText="通知項目" SortExpression="sName" UniqueName="sName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="iTimespan" DataType="System.Int32" FilterControlAltText="Filter iTimespan column"
                                        HeaderText="時間間距" SortExpression="iTimespan" UniqueName="iTimespan">
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                    </EditColumn>
                                </EditFormSettings>
                            </MasterTableView><FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                            </HeaderContextMenu>
                        </telerik:RadGrid>
                        <asp:SqlDataSource ID="sdsNotifyItem" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                            SelectCommand="SELECT * FROM [trNotifyItem]"></asp:SqlDataSource>
                    </div>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView6" runat="server">
                <asp:Label ID="lblPlanAmt" runat="server"></asp:Label>
                <br />
                &nbsp;&nbsp;<br />
                <asp:Panel ID="pnlCost" runat="server" Visible="False">
                    <telerik:RadGrid ID="gvCostItem" runat="server" CellSpacing="0" Culture="zh-TW" DataSourceID="sdsGvCostItem"
                        GridLines="None" OnSelectedIndexChanged="gvCostItem_SelectedIndexChanged" Skin="Windows7"
                        AllowMultiRowSelection="True">
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="trCostItemCode" DataSourceID="sdsGvCostItem">
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridButtonColumn CommandName="Select" FilterControlAltText="Filter column column"
                                    Text="加入" UniqueName="column" Visible="False">
                                </telerik:GridButtonColumn>
                                <telerik:GridClientSelectColumn FilterControlAltText="Filter column1 column" UniqueName="column1">
                                </telerik:GridClientSelectColumn>
                                <telerik:GridBoundColumn DataField="trCostItemName" FilterControlAltText="Filter trCostItemName column"
                                    HeaderText="費用名稱" SortExpression="trCostItemName" UniqueName="trCostItemName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="trCostItemCode" FilterControlAltText="Filter trCostItemCode column"
                                    HeaderText="trCostItemCode" SortExpression="trCostItemCode" UniqueName="trCostItemCode"
                                    Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                                    HeaderText="iAutoKey" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                                    Visible="False">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                    <br />
                    <telerik:RadButton ID="btnCostAdd" runat="server" OnClick="btnCostAdd_Click" Text="加入">
                    </telerik:RadButton>
                    &#160;
                    <telerik:RadButton ID="btnCancelC" runat="server" OnClick="btnCancelC_Click" Text="取消">
                    </telerik:RadButton>
                    &#160;<asp:SqlDataSource ID="sdsGvCostItem" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                        SelectCommand="SELECT * FROM [trCostItem] ORDER BY [trCostItemName]"></asp:SqlDataSource>
                </asp:Panel>
                <asp:Panel ID="pnlECost" runat="server">
                    <div style="float: left; width: 40%">
                        <telerik:RadButton ID="btnAddC" runat="server" Text="加入費用" OnClick="btnAddC_Click">
                        </telerik:RadButton>
                        <br />
                        <telerik:RadGrid ID="gvEstimateAmt" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                            Culture="zh-TW" DataSourceID="sdsGvEstimateAmt" GridLines="None" OnItemDeleted="gvEstimateAmt_ItemDeleted"
                            Skin="Outlook" Width="90%">
                            <MasterTableView AllowAutomaticDeletes="True" DataKeyNames="iAutoKey" DataSourceID="sdsGvEstimateAmt">
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="trCostItemName" FilterControlAltText="Filter trCostItemName column"
                                        HeaderText="預估費用" SortExpression="trCostItemName" UniqueName="trCostItemName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn DataField="iAmt" DataType="System.Int32" FilterControlAltText="Filter iAmt column"
                                        HeaderText="金額" SortExpression="iAmt" UniqueName="iAmt">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="iAmtTextBox" runat="server" Text='<%# Bind("iAmt") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <telerik:RadNumericTextBox ID="ntb_iAmt" runat="server" Culture="zh-TW" DataType="System.Int32"
                                                DbValue='<%# Bind("iAmt") %>' Width="125px">
                                                <NumberFormat DecimalDigits="0" />
                                            </telerik:RadNumericTextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="dPayDate" DataType="System.DateTime" FilterControlAltText="Filter dPayDate column"
                                        HeaderText="dPayDate" SortExpression="dPayDate" UniqueName="dPayDate" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="trCostItem_sCode" FilterControlAltText="Filter trCostItem_sCode column"
                                        HeaderText="trCostItem_sCode" SortExpression="trCostItem_sCode" UniqueName="trCostItem_sCode"
                                        Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="iClassAutoKey" DataType="System.Int32" FilterControlAltText="Filter iClassAutoKey column"
                                        HeaderText="iClassAutoKey" SortExpression="iClassAutoKey" UniqueName="iClassAutoKey"
                                        Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                                        HeaderText="iAutoKey" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                                        Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmDialogType="RadWindow"
                                        ConfirmText="確定刪除?" FilterControlAltText="Filter delete column" UniqueName="delete">
                                    </telerik:GridButtonColumn>
                                </Columns>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                    </EditColumn>
                                </EditFormSettings>
                            </MasterTableView>
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                            </HeaderContextMenu>
                        </telerik:RadGrid>
                        <br />
                        <asp:Label ID="lblEstimateAmt" runat="server" Font-Size="Medium"></asp:Label>
                        <br />
                        <telerik:RadButton ID="btnSaveCost" runat="server" GroupName="check" OnClick="btnSaveCost_Click"
                            Text="存檔">
                        </telerik:RadButton>
                        <asp:SqlDataSource ID="sdsGvEstimateAmt" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                            DeleteCommand="DELETE FROM [trTrainingEstimateCost] WHERE [iAutoKey] = @iAutoKey"
                            InsertCommand="INSERT INTO [trTrainingEstimateCost] ([iClassAutoKey], [trCostItem_sCode], [iAmt], [dPayDate], [sKeyMan], [dKeyDate]) VALUES (@iClassAutoKey, @trCostItem_sCode, @iAmt, @dPayDate, @sKeyMan, @dKeyDate)"
                            SelectCommand="SELECT ec.*,cost.trCostItemName FROM [trTrainingEstimateCost] ec join trCostItem cost on ec.trCostItem_sCode = cost.trCostItemCode WHERE ([iClassAutoKey] = @iClassAutoKey)
order by cost.trCostItemName" UpdateCommand="UPDATE [trTrainingEstimateCost] SET [iClassAutoKey] = @iClassAutoKey, [trCostItem_sCode] = @trCostItem_sCode, [iAmt] = @iAmt, [dPayDate] = @dPayDate, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
                            <DeleteParameters>
                                <asp:Parameter Name="iAutoKey" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="iClassAutoKey" Type="Int32" />
                                <asp:Parameter Name="trCostItem_sCode" Type="String" />
                                <asp:Parameter Name="iAmt" Type="Int32" />
                                <asp:Parameter Name="dPayDate" Type="DateTime" />
                                <asp:Parameter Name="sKeyMan" Type="String" />
                                <asp:Parameter Name="dKeyDate" Type="DateTime" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblClassID" DefaultValue="0" Name="iClassAutoKey"
                                    PropertyName="Text" Type="Int32" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="iClassAutoKey" Type="Int32" />
                                <asp:Parameter Name="trCostItem_sCode" Type="String" />
                                <asp:Parameter Name="iAmt" Type="Int32" />
                                <asp:Parameter Name="dPayDate" Type="DateTime" />
                                <asp:Parameter Name="sKeyMan" Type="String" />
                                <asp:Parameter Name="dKeyDate" Type="DateTime" />
                                <asp:Parameter Name="iAutoKey" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                    </div>
                    <div style="float: right; width: 59%">
                        <table class="tableBlue">
                            <tr>
                                <th colspan="2">
                                    講師費用一覽表
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    新員教育訓練課程
                                </td>
                                <td>
                                    200元/H
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    指導員課程
                                </td>
                                <td>
                                    220元/H
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    店襄理課程
                                </td>
                                <td>
                                    240元/H
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    帶班店襄理課程
                                </td>
                                <td>
                                    240元/H
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    實習店副理課程
                                </td>
                                <td>
                                    260元/H
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    儲備店經理課程
                                </td>
                                <td>
                                    280元/H
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    儲備區督導課程
                                </td>
                                <td>
                                    300元/H
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    便當菜炒製課程
                                </td>
                                <td>
                                    300元/H
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                <br />
            </telerik:RadPageView>
            <telerik:RadPageView ID="pvAttendClassDate" runat="server">
                <br />
                <div>
                    <div style="float: left; width: 15%">
                        <telerik:RadTabStrip ID="RadTabStrip2" runat="server" Orientation="VerticalLeft"
                            SelectedIndex="1" MultiPageID="RadMultiPage2" Skin="Office2007">
                            <Tabs>
                                <telerik:RadTab runat="server" PageViewID="RadPageView9" Text="1) 上課日期">
                                </telerik:RadTab>
                                <telerik:RadTab runat="server" PageViewID="pvAttendClassTime" Text="2) 上課時間" Selected="True">
                                </telerik:RadTab>
                                <telerik:RadTab runat="server" PageViewID="pvTeacher" Text="3) 講師設定">
                                </telerik:RadTab>
                                <telerik:RadTab runat="server" PageViewID="pvPlace" Text="4) 地點設定">
                                </telerik:RadTab>
                            </Tabs>
                        </telerik:RadTabStrip>
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
                    </div>
                    <div style="float: right; width: 85%">
                        <telerik:RadMultiPage ID="RadMultiPage2" runat="server" SelectedIndex="1" Width="100%">
                            <telerik:RadPageView ID="RadPageView9" runat="server">
                                <asp:Panel ID="pnAttendClassDate" runat="server">
                                    <table>
                                        <tr>
                                            <td style="width: 40%">
                                                <asp:Label ID="lblYearPlanID" runat="server"></asp:Label>
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            梯次
                                                        </td>
                                                        <td>
                                                            <telerik:RadNumericTextBox ID="txtSession" runat="server" NumberFormat-DecimalDigits="0"
                                                                Width="30px" MaxValue="364" MinValue="0">
                                                            </telerik:RadNumericTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            課程時數
                                                        </td>
                                                        <td>
                                                            <telerik:RadNumericTextBox ID="ntb_iCourseTime" runat="server" MinValue="0" Width="30px">
                                                                <NumberFormat DecimalDigits="0" />
                                                                <NumberFormat DecimalDigits="1" />
                                                            </telerik:RadNumericTextBox>小時
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            最低開課人數
                                                        </td>
                                                        <td>
                                                            <telerik:RadNumericTextBox ID="txtDownPeople" runat="server" MinValue="0" NumberFormat-DecimalDigits="0"
                                                                Value="8" Width="30px">
                                                            </telerik:RadNumericTextBox>人
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            開課人數上限
                                                        </td>
                                                        <td>
                                                            <telerik:RadNumericTextBox ID="txtUpPeople" runat="server" NumberFormat-DecimalDigits="0"
                                                                Width="30px" MinValue="0">
                                                            </telerik:RadNumericTextBox>人
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            職能積分
                                                        </td>
                                                        <td>
                                                            <telerik:RadNumericTextBox ID="txtJobScore" runat="server" Width="30px">
                                                                <NumberFormat DecimalDigits="0" />
                                                            </telerik:RadNumericTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            訓練方式
                                                        </td>
                                                        <td>
                                                            <telerik:RadComboBox ID="cbxTrainingMethod" runat="server" Width="70px" DataSourceID="sdsTrainingMethodCbx"
                                                                DataTextField="sName" DataValueField="sCode">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            講師類型
                                                        </td>
                                                        <td>
                                                            <telerik:RadComboBox ID="cbxTeacherType" runat="server" Width="70px" DataTextField="seName"
                                                                DataValueField="sCode" DataSourceID="sdsTeacherType">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            課程類型
                                                        </td>
                                                        <td>
                                                            <telerik:RadComboBox ID="cbxCourseType" runat="server" DataTextField="sName" DataValueField="sCode"
                                                                Width="70px">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="cbIsNeedStudentScore" runat="server" Checked="True" Text="學員表現評分表" />
                                                        </td>
                                                        <td>
                                                            <telerik:RadNumericTextBox ID="ntbStudentScoreDateSpan" runat="server" DataType="System.Int32"
                                                                MinValue="0" Width="50px">
                                                                <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                                            </telerik:RadNumericTextBox>天內
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            評分表截止日<telerik:RadDateTimePicker ID="rdtpStudentScoreDeadLine" runat="server" Culture="zh-TW">
                                                                <TimeView CellSpacing="-1" Culture="zh-TW" TimeFormat="HH:mm">
                                                                </TimeView>
                                                                <TimePopupButton HoverImageUrl="" ImageUrl="" />
                                                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                                </Calendar>
                                                                <DateInput DateFormat="yyyy/M/d HH:mm" DisplayDateFormat="yyyy/M/d HH:mm" DisplayText=""
                                                                    LabelWidth="40%" type="text" value="">
                                                                </DateInput>
                                                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                            </telerik:RadDateTimePicker>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="cbIsNeedClassRpt" runat="server" Text="課後心得填寫" Checked="True" />
                                                        </td>
                                                        <td>
                                                            <telerik:RadNumericTextBox ID="ntbClassRptDateSpan" runat="server" Width="50px" DataType="System.Int32"
                                                                MinValue="0">
                                                                <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                                            </telerik:RadNumericTextBox>天內
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            心得截止日<telerik:RadDateTimePicker ID="rdtpClassRptDeadLine" runat="server" Culture="zh-TW">
                                                                <TimeView CellSpacing="-1" Culture="zh-TW" TimeFormat="HH:mm">
                                                                </TimeView>
                                                                <TimePopupButton HoverImageUrl="" ImageUrl="" />
                                                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                                </Calendar>
                                                                <DateInput DateFormat="yyyy/M/d HH:mm" DisplayDateFormat="yyyy/M/d HH:mm" DisplayText=""
                                                                    LabelWidth="40%" type="text" value="">
                                                                </DateInput>
                                                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                            </telerik:RadDateTimePicker>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:CheckBox ID="cbIsManagerScoreStudentClassReport" runat="server" Text="主管可評分部門學員心得" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                                <asp:SqlDataSource ID="sdsTeacherType" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                                                    SelectCommand="select * from trTeacherType"></asp:SqlDataSource>
                                                <br />
                                                <br />
                                            </td>
                                            <td>
                                                <telerik:RadCalendar ID="cldAttendClassDate" runat="server" Skin="Vista" CultureInfo="zh-TW"
                                                    SelectedDate="" ViewSelectorText="x">
                                                    <WeekendDayStyle CssClass="rcWeekend" />
                                                    <CalendarTableStyle CssClass="rcMainTable" />
                                                    <OtherMonthDayStyle CssClass="rcOtherMonth" />
                                                    <OutOfRangeDayStyle CssClass="rcOutOfRange" />
                                                    <DisabledDayStyle CssClass="rcDisabled" />
                                                    <SelectedDayStyle CssClass="rcSelected" />
                                                    <DayOverStyle CssClass="rcHover" />
                                                    <FastNavigationStyle CssClass="RadCalendarMonthView RadCalendarMonthView_Vista" />
                                                    <ViewSelectorStyle CssClass="rcViewSel" />
                                                </telerik:RadCalendar>
                                                <telerik:RadButton ID="btnAddAttendClassDate" runat="server" OnClick="btnAddAttendClassDate_Click"
                                                    Text="加入">
                                                </telerik:RadButton>
                                                <asp:SqlDataSource ID="sdsTrainingMethodCbx" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                                                    SelectCommand="SELECT * FROM [trTrainingMethod]"></asp:SqlDataSource>
                                            </td>
                                            <td>
                                                開課期間
                                                <asp:Label ID="lblClassBDate" runat="server" ForeColor="Red"></asp:Label>~<asp:Label
                                                    ID="lblClassEDate" runat="server" ForeColor="Red"></asp:Label>
                                                <br />
                                                <telerik:RadListBox ID="lbAttendClassDate" runat="server" AllowDelete="True" Skin="Office2010Blue">
                                                    <ButtonSettings TransferButtons="All" />
                                                    <ButtonSettings TransferButtons="All" />
                                                </telerik:RadListBox>
                                                <div>
                                                    <telerik:RadButton ID="btnSaveAttendClassDate" runat="server" OnClick="btnSaveAttendClassDate_Click"
                                                        Text="存檔">
                                                    </telerik:RadButton>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="pvAttendClassTime" runat="server">
                                <telerik:RadGrid ID="gvClassTime" runat="server" CellSpacing="0" GridLines="None"
                                    Skin="Outlook" Width="100%" AutoGenerateColumns="False" DataSourceID="sdsClassTimeGv"
                                    OnItemDataBound="gvClassTime_ItemDataBound" OnItemCommand="gvClassTime_ItemCommand"
                                    Culture="zh-TW">
                                    <MasterTableView DataKeyNames="iAutoKey" DataSourceID="sdsClassTimeGv">
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                            <HeaderStyle Width="20px" />
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                            <HeaderStyle Width="20px" />
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="dClassDate" DataFormatString="{0:d}" FilterControlAltText="Filter column column"
                                                HeaderText="上課日期" UniqueName="column">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn FilterControlAltText="Filter StartTime column" HeaderText="開始時間"
                                                UniqueName="StartTime">
                                                <ItemTemplate>
                                                    <telerik:RadTimePicker ID="tpTimeA" runat="server" Culture="(Default)" DbSelectedDate='<%# Bind("dClassDateA") %>'>
                                                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" Visible="False" />
                                                        <TimeView CellSpacing="-1" Culture="(Default)" Columns="3" HeaderText="時間選擇">
                                                        </TimeView>
                                                        <TimePopupButton CssClass="" HoverImageUrl="" ImageUrl="" Visible="true" />
                                                        <DateInput DateFormat="MM/dd/yyyy" DisplayDateFormat="MM/dd/yyyy" Width="">
                                                        </DateInput></telerik:RadTimePicker>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn FilterControlAltText="Filter Blank column" UniqueName="Blank">
                                                <ItemTemplate>
                                                    ～</ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn FilterControlAltText="Filter EndTime column" HeaderText="結束時間"
                                                UniqueName="EndTime">
                                                <ItemTemplate>
                                                    <telerik:RadTimePicker ID="tpTimeD" runat="server" Culture="(Default)" DbSelectedDate='<%# Bind("dClassDateD") %>'>
                                                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" Visible="False" />
                                                        <TimeView CellSpacing="-1" Culture="(Default)">
                                                        </TimeView>
                                                        <TimePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                                        <DateInput DateFormat="MM/dd/yyyy" DisplayDateFormat="MM/dd/yyyy" Width="">
                                                        </DateInput>
                                                    </telerik:RadTimePicker>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn FilterControlAltText="Filter CourseTime column" HeaderText="上課時數(小時)"
                                                UniqueName="CourseTime">
                                                <ItemTemplate>
                                                    <telerik:RadNumericTextBox ID="ntbiAttendMins" runat="server" Culture="zh-TW" DbValue='<%# Bind("iAttendMins") %>'
                                                        MinValue="0" Width="125px">
                                                        <NumberFormat DecimalDigits="0" />
                                                        <NumberFormat DecimalDigits="1" />
                                                    </telerik:RadNumericTextBox>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridButtonColumn ButtonType="PushButton" FilterControlAltText="Filter Save  column"
                                                Text="存檔" UniqueName="Save" CommandName="Save">
                                            </telerik:GridButtonColumn>
                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                    </MasterTableView><FilterMenu EnableImageSprites="False">
                                    </FilterMenu>
                                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                    </HeaderContextMenu>
                                </telerik:RadGrid><asp:SqlDataSource ID="sdsClassTimeGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                                    SelectCommand="SELECT * FROM [trAttendClassDate] WHERE ([iClassAutoKey] = @iClassAutoKey) order by dClassDate">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="lblClassID" DefaultValue="0" Name="iClassAutoKey"
                                            PropertyName="Text" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="pvTeacher" runat="server">
                                <asp:Panel ID="pnlSetTeacher" runat="server" Visible="False">
                                    <div style="float: left; width: 47%">
                                        <telerik:RadComboBox ID="cbxAttendDateTeacher" runat="server" DataSourceID="sdsAttendDateCbx"
                                            DataTextField="dClassDate" DataTextFormatString="{0:d}" DataValueField="dClassDate"
                                            AutoPostBack="True" OnSelectedIndexChanged="cbxAttendDateTeacher_SelectedIndexChanged">
                                        </telerik:RadComboBox>
                                        <br />
                                        <asp:CheckBox ID="ckxThisTeacher" runat="server" Text="上過課之講師" AutoPostBack="True"
                                            OnCheckedChanged="ckxThisTeacher_CheckedChanged" />
                                        &#160;
                                        <asp:CheckBox ID="cbDefaultAttendTeacher" runat="server" Text="其餘未設定皆帶入此講師" />
                                        <br />
                                        <telerik:RadGrid ID="gvTeacherList" runat="server" Width="70%" CellSpacing="0" GridLines="None"
                                            Skin="Outlook" AllowFilteringByColumn="True" AllowMultiRowSelection="True" AllowPaging="True"
                                            AutoGenerateColumns="False" Culture="zh-TW" DataSourceID="sdsTeacherGv">
                                            <ClientSettings>
                                                <Selecting AllowRowSelect="True" />
                                            </ClientSettings>
                                            <MasterTableView AllowMultiColumnSorting="True" AllowSorting="True" DataKeyNames="iAutoKey"
                                                DataSourceID="sdsTeacherGv">
                                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                                    <HeaderStyle Width="20px" />
                                                </RowIndicatorColumn>
                                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                                    <HeaderStyle Width="20px" />
                                                </ExpandCollapseColumn>
                                                <Columns>
                                                    <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                                                    </telerik:GridClientSelectColumn>
                                                    <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                                                        HeaderText="講師姓名" SortExpression="sName" UniqueName="sName">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="sNobr" FilterControlAltText="Filter sNobr column"
                                                        HeaderText="內部講師工號" SortExpression="sNobr" UniqueName="sNobr">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="sCode" FilterControlAltText="Filter sCode column"
                                                        HeaderText="sCode" SortExpression="sCode" UniqueName="sCode" Visible="False">
                                                    </telerik:GridBoundColumn>
                                                </Columns>
                                                <EditFormSettings>
                                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                    </EditColumn>
                                                </EditFormSettings>
                                            </MasterTableView><FilterMenu EnableImageSprites="False">
                                            </FilterMenu>
                                            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                            </HeaderContextMenu>
                                        </telerik:RadGrid><br />
                                        <telerik:RadButton ID="btnAttendClassTeacherSave" runat="server" Text="加入" OnClick="btnAttendClassTeacherSave_Click">
                                        </telerik:RadButton>
                                        &#160;&#160;<telerik:RadButton ID="btnAttendClassTeacherCancel" runat="server" Text="取消"
                                            OnClick="btnAttendClassTeacherCancel_Click">
                                        </telerik:RadButton>
                                        <asp:SqlDataSource ID="sdsTeacherGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                                            SelectCommand="SELECT * FROM [trTeacher]"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="sdsExperiencedTeacher" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                                            SelectCommand="select * from trTeacher t where exists (
select trTeacher_sCode from trAttendClassTeacher act 
join trTrainingDetailM tdm on act.iClassAutoKey = tdm.iAutoKey 
where tdm.bIsPublished =1 and exists (
select 1 from trTrainingDetailM tdm2 where tdm2.iAutoKey = @ID
 and tdm.trCourse_sCode = tdm2.trCourse_sCode)  
 and act.sTeacherCode = t.sCode)">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="lblClassID" DefaultValue="0" Name="ID" PropertyName="Text" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <asp:SqlDataSource ID="sdsTeachingDateList" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                                            SelectCommand=" select act.*,t.sName as teacherName,c.sName as courseName,acd.dClassDateA,acd.dClassDateD,tdm.trCourse_sCode from trAttendClassTeacher act 
 join trAttendClassDate acd on act.dClassDate = acd.dClassDate and act.iClassAutoKey = acd.iClassAutoKey
 join trTeacher t on act.sTeacherCode = t.sCode
 join trTrainingDetailM tdm on act.iClassAutoKey = tdm.iAutoKey
 join trCourse c on tdm.trCourse_sCode = c.sCode
 where tdm.bIsPublished = 1 and act.dClassDate = @selectedDate">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="cbxAttendDateTeacher" ConvertEmptyStringToNull="False"
                                                    DefaultValue="" Name="selectedDate" PropertyName="SelectedValue" Type="DateTime" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <br />
                                    </div>
                                    <div style="float: right; width: 52%">
                                        <br />
                                        當日上課之講師<br />
                                        <telerik:RadGrid ID="gvTeachingDateList" runat="server" CellSpacing="0" Culture="zh-TW"
                                            Skin="Outlook" AutoGenerateColumns="False" DataSourceID="sdsTeachingDateList"
                                            GridLines="None">
                                            <MasterTableView DataSourceID="sdsTeachingDateList" DataKeyNames="iAutoKey">
                                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                                    <HeaderStyle Width="20px" />
                                                </RowIndicatorColumn>
                                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                                    <HeaderStyle Width="20px" />
                                                </ExpandCollapseColumn>
                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="iAutoKey" FilterControlAltText="Filter iAutoKey column"
                                                        HeaderText="iAutoKey" SortExpression="iAutoKey" UniqueName="iAutoKey" DataType="System.Int32"
                                                        ReadOnly="True" Visible="False">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="iClassAutoKey" FilterControlAltText="Filter iClassAutoKey column"
                                                        HeaderText="iClassAutoKey" SortExpression="iClassAutoKey" UniqueName="iClassAutoKey"
                                                        DataType="System.Int32" Visible="False">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="dClassDate" DataType="System.DateTime" FilterControlAltText="Filter dClassDate column"
                                                        HeaderText="dClassDate" SortExpression="dClassDate" UniqueName="dClassDate" Visible="False">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="sTeacherCode" FilterControlAltText="Filter sTeacherCode column"
                                                        HeaderText="sTeacherCode" SortExpression="sTeacherCode" UniqueName="sTeacherCode"
                                                        Visible="False">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="sKeyMan" FilterControlAltText="Filter sKeyMan column"
                                                        HeaderText="sKeyMan" SortExpression="sKeyMan" UniqueName="sKeyMan" Visible="False">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" FilterControlAltText="Filter dKeyDate column"
                                                        HeaderText="dKeyDate" SortExpression="dKeyDate" UniqueName="dKeyDate" Visible="False">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="teacherName" FilterControlAltText="Filter teacherName column"
                                                        HeaderText="講師" SortExpression="teacherName" UniqueName="teacherName">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="courseName" FilterControlAltText="Filter courseName column"
                                                        HeaderText="課程" SortExpression="courseName" UniqueName="courseName">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="trCourse_sCode" FilterControlAltText="Filter trCourse_sCode column"
                                                        HeaderText="編號" UniqueName="trCourse_sCode">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="dClassDateA" DataFormatString="{0:HH:mm}" DataType="System.DateTime"
                                                        FilterControlAltText="Filter dClassDateA column" HeaderText="時間起" SortExpression="dClassDateA"
                                                        UniqueName="dClassDateA">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="dClassDateD" DataFormatString="{0:HH:mm}" DataType="System.DateTime"
                                                        FilterControlAltText="Filter dClassDateD column" HeaderText="時間迄" SortExpression="dClassDateD"
                                                        UniqueName="dClassDateD">
                                                    </telerik:GridBoundColumn>
                                                </Columns>
                                                <EditFormSettings>
                                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                    </EditColumn>
                                                </EditFormSettings>
                                            </MasterTableView>
                                            <FilterMenu EnableImageSprites="False">
                                            </FilterMenu>
                                            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                            </HeaderContextMenu>
                                        </telerik:RadGrid>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="pnlTeacher" runat="server">
                                    <table class="style1">
                                        <tr>
                                            <td width="60px">
                                                開課期間
                                            </td>
                                            <td>
                                                <asp:Label ID="lblClassBDate0" runat="server" ForeColor="Red"></asp:Label>~<asp:Label
                                                    ID="lblClassEDate0" runat="server" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <telerik:RadButton ID="btnTeacherAdd" runat="server" Text="加入講師" OnClick="btnAddTeacher_Click">
                                    </telerik:RadButton>
                                    <br />
                                    <br />
                                    <telerik:RadGrid ID="gvTeacher" runat="server" CellSpacing="0" GridLines="None" Skin="Outlook"
                                        Width="70%" AutoGenerateColumns="False" Culture="zh-TW" DataSourceID="sdsAttendClassTeacher">
                                        <MasterTableView AllowAutomaticDeletes="True" DataKeyNames="iAutoKey" DataSourceID="sdsAttendClassTeacher">
                                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                                <HeaderStyle Width="20px" />
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                                <HeaderStyle Width="20px" />
                                            </ExpandCollapseColumn>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="dClassDate" DataFormatString="{0:d}" DataType="System.DateTime"
                                                    FilterControlAltText="Filter dClassDate column" HeaderText="上課日期" SortExpression="dClassDate"
                                                    UniqueName="dClassDate">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                                                    HeaderText="講師" SortExpression="sName" UniqueName="sName">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmDialogType="RadWindow"
                                                    ConfirmText="是否要刪除?" FilterControlAltText="Filter column column" UniqueName="column">
                                                </telerik:GridButtonColumn>
                                                <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                                                    HeaderText="iAutoKey" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                                                    Visible="False">
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                </EditColumn>
                                            </EditFormSettings>
                                        </MasterTableView><FilterMenu EnableImageSprites="False">
                                        </FilterMenu>
                                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                        </HeaderContextMenu>
                                    </telerik:RadGrid><asp:SqlDataSource ID="sdsAttendClassTeacher" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                                        DeleteCommand="delete FROM [trAttendClassTeacher] where iAutoKey = @iAutoKey"
                                        SelectCommand="SELECT attT.*,t.sName FROM [trAttendClassTeacher] attT join trTeacher t on attT.sTeacherCode = t.sCode where iClassAutoKey = @iClassAutoKey">
                                        <DeleteParameters>
                                            <asp:Parameter Name="iAutoKey" />
                                        </DeleteParameters>
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="lblClassID" DefaultValue="0" Name="iClassAutoKey"
                                                PropertyName="Text" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <br />
                                </asp:Panel>
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="pvPlace" runat="server">
                                <asp:Panel ID="pnlSetPlace" runat="server" Visible="False">
                                    <br />
                                    <div style="float: left; width: 47%">
                                        <telerik:RadComboBox ID="cbxAttendDate" runat="server" Width="100px" DataSourceID="sdsAttendDateCbx"
                                            DataTextField="dClassDate" DataValueField="dClassDate" DataTextFormatString="{0:d}"
                                            AutoPostBack="True">
                                            <Items>
                                                <telerik:RadComboBoxItem runat="server" Owner="cbxAttendDate" Text="所有講師" Value="所有講師" />
                                                <telerik:RadComboBoxItem runat="server" Owner="cbxAttendDate" Text="內訓" Value="內訓" />
                                                <telerik:RadComboBoxItem runat="server" Owner="cbxAttendDate" Text="外訓" Value="外訓" />
                                            </Items>
                                        </telerik:RadComboBox>
                                        <asp:CheckBox ID="cbDefaultAttnedPlace" runat="server" Text="其餘未設定皆帶入此地點" />
                                        <br />
                                        <br />
                                        <telerik:RadGrid ID="gvPlaceList" runat="server" CellSpacing="0" GridLines="None"
                                            Skin="Outlook" Width="70%" DataSourceID="sdsClassroom" Culture="zh-TW">
                                            <ClientSettings>
                                                <Selecting AllowRowSelect="True" />
                                                <Selecting AllowRowSelect="True" />
                                                <Selecting AllowRowSelect="True" />
                                            </ClientSettings>
                                            <MasterTableView AutoGenerateColumns="False" DataKeyNames="sCode" DataSourceID="sdsClassroom">
                                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                                    <HeaderStyle Width="20px" />
                                                </RowIndicatorColumn>
                                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                                    <HeaderStyle Width="20px" />
                                                </ExpandCollapseColumn>
                                                <Columns>
                                                    <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                                                    </telerik:GridClientSelectColumn>
                                                    <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                                                        HeaderText="地點名稱" SortExpression="sName" UniqueName="sName">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="sAddr" FilterControlAltText="Filter sAddr column"
                                                        HeaderText="sAddr" SortExpression="sAddr" UniqueName="sAddr" Visible="False">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="sCode" FilterControlAltText="Filter sCode column"
                                                        HeaderText="sCode" SortExpression="sCode" UniqueName="sCode" Visible="False">
                                                    </telerik:GridBoundColumn>
                                                </Columns>
                                                <EditFormSettings>
                                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                    </EditColumn>
                                                </EditFormSettings>
                                            </MasterTableView><FilterMenu EnableImageSprites="False">
                                            </FilterMenu>
                                            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                            </HeaderContextMenu>
                                        </telerik:RadGrid><br />
                                        <telerik:RadButton ID="btnPlaceAdd" runat="server" OnClick="btnPlaceAdd_Click" Text="加入">
                                        </telerik:RadButton>
                                        &#160;&#160;<telerik:RadButton ID="btnPlaceCancel" runat="server" OnClick="btnPlaceCancel_Click"
                                            Text="取消">
                                        </telerik:RadButton>
                                        <asp:SqlDataSource ID="sdsClassroom" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                                            SelectCommand="SELECT * FROM [trClassroom]"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="sdsTeachingPlaceList" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                                            SelectCommand=" select acp.*,r.sName placeName,c.sName as courseName,acd.dClassDateA,acd.dClassDateD,tdm.trCourse_sCode from trAttendClassPlace acp
 join trAttendClassDate acd on acp.dClassDate = acd.dClassDate and acp.iClassAutoKey = acd.iClassAutoKey
join trClassroom r on acp.sPlaceCode = r.sCode
 join trTrainingDetailM tdm on acp.iClassAutoKey = tdm.iAutoKey
 join trCourse c on tdm.trCourse_sCode = c.sCode
 where tdm.bIsPublished = 1  and acp.dClassDate = @selectedDate">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="cbxAttendDate" ConvertEmptyStringToNull="False"
                                                    DefaultValue="" Name="selectedDate" PropertyName="SelectedValue" Type="DateTime" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <asp:SqlDataSource ID="sdsAttendDateCbx" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                                            SelectCommand="SELECT * FROM [trAttendClassDate] WHERE ([iClassAutoKey] = @iClassAutoKey)
 order by dClassDate">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="lblClassID" DefaultValue="0" Name="iClassAutoKey"
                                                    PropertyName="Text" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <br />
                                    </div>
                                    <div style="float: right; width: 52%">
                                        當日上課之地點<telerik:RadGrid ID="gvTeachingPlaceList" runat="server" CellSpacing="0" Culture="zh-TW"
                                            DataSourceID="sdsTeachingPlaceList" Skin="Outlook">
                                            <MasterTableView AutoGenerateColumns="False" DataKeyNames="iAutoKey" DataSourceID="sdsTeachingPlaceList">
                                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                                    <HeaderStyle Width="20px" />
                                                </RowIndicatorColumn>
                                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                                    <HeaderStyle Width="20px" />
                                                </ExpandCollapseColumn>
                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                                                        HeaderText="iAutoKey" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                                                        Visible="False">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="iClassAutoKey" DataType="System.Int32" FilterControlAltText="Filter iClassAutoKey column"
                                                        HeaderText="iClassAutoKey" SortExpression="iClassAutoKey" UniqueName="iClassAutoKey"
                                                        Visible="False">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="dClassDate" DataType="System.DateTime" FilterControlAltText="Filter dClassDate column"
                                                        HeaderText="dClassDate" SortExpression="dClassDate" UniqueName="dClassDate" Visible="False">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="sPlaceCode" FilterControlAltText="Filter sPlaceCode column"
                                                        HeaderText="sPlaceCode" SortExpression="sPlaceCode" UniqueName="sPlaceCode" Visible="False">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="sKeyMan" FilterControlAltText="Filter sKeyMan column"
                                                        HeaderText="sKeyMan" SortExpression="sKeyMan" UniqueName="sKeyMan" Visible="False">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" FilterControlAltText="Filter dKeyDate column"
                                                        HeaderText="dKeyDate" SortExpression="dKeyDate" UniqueName="dKeyDate" Visible="False">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="placeName" FilterControlAltText="Filter placeName column"
                                                        HeaderText="地點" SortExpression="placeName" UniqueName="placeName">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="courseName" FilterControlAltText="Filter courseName column"
                                                        HeaderText="課程" SortExpression="courseName" UniqueName="courseName">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="trCourse_sCode" FilterControlAltText="Filter trCourse_sCode column"
                                                        HeaderText="編號" SortExpression="trCourse_sCode" UniqueName="trCourse_sCode">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="dClassDateA" DataFormatString="{0:t}" DataType="System.DateTime"
                                                        FilterControlAltText="Filter dClassDateA column" HeaderText="時間起" SortExpression="dClassDateA"
                                                        UniqueName="dClassDateA">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="dClassDateD" DataFormatString="{0:t}" DataType="System.DateTime"
                                                        FilterControlAltText="Filter dClassDateD column" HeaderText="時間迄" SortExpression="dClassDateD"
                                                        UniqueName="dClassDateD">
                                                    </telerik:GridBoundColumn>
                                                </Columns>
                                                <EditFormSettings>
                                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                    </EditColumn>
                                                </EditFormSettings>
                                            </MasterTableView>
                                            <FilterMenu EnableImageSprites="False">
                                            </FilterMenu>
                                            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                            </HeaderContextMenu>
                                        </telerik:RadGrid>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="pnlPlace" runat="server">
                                    <table class="style1">
                                        <tr>
                                            <td>
                                                開課期間
                                            </td>
                                            <td>
                                                <asp:Label ID="lblClassBDate1" runat="server" ForeColor="Red"></asp:Label>~<asp:Label
                                                    ID="lblClassEDate1" runat="server" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <telerik:RadButton ID="btnAddPlace" runat="server" OnClick="btnAddPlace_Click" Text="加入訓練地點">
                                    </telerik:RadButton>
                                    <br />
                                    <br />
                                    <telerik:RadGrid ID="gvPlace" runat="server" CellSpacing="0" GridLines="None" Skin="Outlook"
                                        Width="70%" DataSourceID="sdsAttendClassPlace" AllowAutomaticDeletes="True" AutoGenerateColumns="False"
                                        Culture="zh-TW">
                                        <MasterTableView DataKeyNames="iAutoKey" DataSourceID="sdsAttendClassPlace">
                                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                                <HeaderStyle Width="20px" />
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                                <HeaderStyle Width="20px" />
                                            </ExpandCollapseColumn>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="dClassDate" DataFormatString="{0:d}" DataType="System.DateTime"
                                                    FilterControlAltText="Filter dClassDate column" HeaderText="上課日期" SortExpression="dClassDate"
                                                    UniqueName="dClassDate">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sPlaceName column"
                                                    HeaderText="上課地點" UniqueName="sPlaceName">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="sPlaceCode" FilterControlAltText="Filter sPlaceCode column"
                                                    HeaderText="sPlaceCode" SortExpression="sPlaceCode" UniqueName="sPlaceCode" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="iClassAutoKey" DataType="System.Int32" FilterControlAltText="Filter iClassAutoKey column"
                                                    HeaderText="iClassAutoKey" SortExpression="iClassAutoKey" UniqueName="iClassAutoKey"
                                                    Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmDialogType="RadWindow"
                                                    ConfirmText="是否刪除?" FilterControlAltText="Filter column column" Text="刪除" UniqueName="column">
                                                </telerik:GridButtonColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                </EditColumn>
                                            </EditFormSettings>
                                        </MasterTableView><FilterMenu EnableImageSprites="False">
                                        </FilterMenu>
                                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                        </HeaderContextMenu>
                                    </telerik:RadGrid><br />
                                    <asp:SqlDataSource ID="sdsAttendClassPlace" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                                        SelectCommand="SELECT place.*,room.sName FROM [trAttendClassPlace] place join trClassRoom room on place.sPlaceCode = room.sCode 
and place.iClassAutoKey = @iClassAutoKey
order by place.dClassDate" DeleteCommand="delete FROM [trAttendClassPlace] where iAutoKey = @iAutoKey">
                                        <DeleteParameters>
                                            <asp:Parameter Name="iAutoKey" />
                                        </DeleteParameters>
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="lblClassID" DefaultValue="0" Name="iClassAutoKey"
                                                PropertyName="Text" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <br />
                                    <br />
                                </asp:Panel>
                            </telerik:RadPageView>
                        </telerik:RadMultiPage>
                    </div>
                    <div style="text-align: right">
                    </div>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="pvPlan" runat="server">
                <asp:Panel ID="pnCoursePlan" runat="server">
                    <table width="100%">
                        <tr>
                            <td style="width: 70px; vertical-align: text-top">
                                <asp:Label ID="Label3" runat="server" Text="訓練需求" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadEditor ID="edtPlanRequirement" runat="server" Skin="Office2007" Width="100%"
                                    ContentAreaMode="Div" EditModes="Design" ToolsFile="~/Editor/RadEditor/BasicTools.xml"
                                    Height="100px" ToolbarMode="ShowOnFocus" AutoResizeHeight="True">
                                    <Content>
                                    </Content>
                                </telerik:RadEditor>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 70px; vertical-align: text-top">
                                <asp:Label ID="Label4" runat="server" Text="學員資格" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadEditor ID="edtPlanStudentQualification" runat="server" Skin="Office2007"
                                    Width="100%" ContentAreaMode="Div" EditModes="Design" ToolsFile="~/Editor/RadEditor/BasicTools.xml"
                                    Height="100px" ToolbarMode="ShowOnFocus" AutoResizeHeight="True">
                                    <Content>
                                    </Content>
                                </telerik:RadEditor>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 70px; vertical-align: text-top">
                                <asp:Label ID="Label5" runat="server" Text="實施方式" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadEditor ID="edtPlanTrainingMethod" runat="server" Skin="Office2007" Width="100%"
                                    ContentAreaMode="Div" EditModes="Design" ToolsFile="~/Editor/RadEditor/BasicTools.xml"
                                    Height="100px" ToolbarMode="ShowOnFocus" AutoResizeHeight="True">
                                    <Content>
                                    </Content>
                                </telerik:RadEditor>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 70px; vertical-align: text-top">
                                <asp:Label ID="Label6" runat="server" Text="備註" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadEditor ID="edtPlanComment" runat="server" Skin="Office2007" Width="100%"
                                    ContentAreaMode="Div" EditModes="Design" ToolsFile="~/Editor/RadEditor/BasicTools.xml"
                                    Height="100px" ToolbarMode="ShowOnFocus" AutoResizeHeight="True">
                                    <Content>
                                    </Content>
                                </telerik:RadEditor>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 70px; vertical-align: text-top">
                                <asp:Label ID="Label1" runat="server" Text="訓練目標" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadEditor ID="edtCourseGoal" runat="server" Skin="Office2007" Width="100%"
                                    ContentAreaMode="Div" EditModes="Design" ToolsFile="~/Editor/RadEditor/BasicTools.xml"
                                    Height="100px" ToolbarMode="ShowOnFocus" AutoResizeHeight="True">
                                    <Content>
                                    </Content>
                                </telerik:RadEditor>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 70px; vertical-align: text-top">
                                <asp:Label ID="Label2" runat="server" Text="學習目標" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadEditor ID="edtCourseGoal2" runat="server" Skin="Office2007" Width="100%"
                                    ContentAreaMode="Div" EditModes="Design" ToolsFile="~/Editor/RadEditor/BasicTools.xml"
                                    Height="100px" ToolbarMode="ShowOnFocus" AutoResizeHeight="True">
                                    <Content>
                                    </Content>
                                </telerik:RadEditor>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <telerik:RadButton ID="btnSaveSummary" runat="server" Text="儲存" Skin="Windows7" OnClick="btnSaveSammary_Click">
                                </telerik:RadButton>
                                <telerik:RadButton ID="btnPlanDetailAddItem" runat="server" OnClick="btnPlanDetailAddItem_Click"
                                    Skin="Office2007" Text="新增項目">
                                </telerik:RadButton>
                            </td>
                        </tr>
                    </table>
                    <telerik:RadGrid ID="gvPlanDetail" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                        Culture="zh-TW" OnNeedDataSource="gvPlanDetail_NeedDataSource" 
                        Skin="Office2010Blue" GridLines="None" 
                        onitemcommand="gvPlanDetail_ItemCommand">
                        <MasterTableView DataKeyNames="Id">
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter Id column" UniqueName="Id"
                                    Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PlanDetailName" FilterControlAltText="Filter PlanDetailName column"
                                    HeaderText="單元名稱" UniqueName="PlanDetailName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PlanDetailOutline" FilterControlAltText="Filter PlanDetailOutline column"
                                    HeaderText="課程大綱與內容" UniqueName="PlanDetailOutline">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PlanDetailTimeMin" FilterControlAltText="Filter PlanDetailTimeMin column"
                                    HeaderText="分鐘數" UniqueName="PlanDetailTimeMin">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PlanDetailNote" FilterControlAltText="Filter PlanDetailNote column"
                                    HeaderText="備註" UniqueName="PlanDetailNote">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TeachingMethod" FilterControlAltText="Filter TeachingMethod column"
                                    HeaderText="教學法" UniqueName="TeachingMethod">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TeachingResource" FilterControlAltText="Filter TeachingResource column"
                                    HeaderText="教材/教具" UniqueName="TeachingResource">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn CommandName="Del" 
                                    FilterControlAltText="Filter cmdDel column" Text="刪除" UniqueName="cmdDel" 
                                    ConfirmText="確認是否刪除?">
                                </telerik:GridButtonColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
                </asp:Panel>
            </telerik:RadPageView>
        </telerik:RadMultiPage>
        <div style="text-align: right; position: fixed; right: 6px; bottom: 3px;">
            <telerik:RadButton ID="btnNextStep1" runat="server" OnClick="btnNextStep1_Click"
                Text="下一步" Skin="Windows7">
            </telerik:RadButton>
        </div>
     <telerik:RadWindow ID="win" runat="server" Modal="True" EnableShadow="True" 
            VisibleStatusbar="False">
            </telerik:RadWindow>
    </telerik:RadAjaxPanel>
</asp:Content>
