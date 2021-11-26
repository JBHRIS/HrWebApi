<%@ Page Title="課程設定" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true" CodeFile="trCourse.aspx.cs" Inherits="eTraining_Admin_Plan_trCourse" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function ShowInsertForm() {
                window.radopen("trCourseEdit.aspx", "UserListDialog");
                return false;
            }

            function ShowInsertFormP(str) {
                window.radopen(str, "UserListDialog");
                return false;
            }


            function ShowInsertFormByParam(pid) {
                window.radopen("trCategoryEdit.aspx?pid=" + pid, "UserListDialog");
                return false;
            }
            function ShowEditFormByParam(pid) {
                window.radopen("trCourseEdit.aspx?mode=e&pid=" + pid, "UserListDialog");
                return false;
            }
            function ShowCourseFormByParam(pid, mode) {
                window.radopen("trCourseEdit.aspx?pid=" + pid + "&m=" + mode, "UserListDialog2");
                return false;
            }

            function refreshGrid(arg) {
                if (!arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
                }
            }
            function refreshFV(arg) {
                if (!arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindFV");
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindFV");
                }
            }
            function refreshTV(arg) {
                if (!arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindTV");
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindTV");
                }
            }
            function RowDblClick(sender, eventArgs) {
                window.radopen("trTeacherEdit.aspx?iAutoKey=" + eventArgs.getDataKeyValue("iAutoKey"), "UserListDialog");
            }

            //Standard Window.confirm
            function StandardConfirm(sender, args) {
                args.set_cancel(!window.confirm("確認是否刪除?"));
            }

            //RadConfirm
            function RadConfirm(sender, args) {
                var callBackFunction = Function.createDelegate(sender, function (shouldSubmit) {
                    if (shouldSubmit) {
                        this.click();
                    }
                });

                var text = "Are you sure you want to submit the page?";
                radconfirm(text, callBackFunction, 300, 100, null, "RadConfirm");
                args.set_cancel(true);
            }
        </script>
    </telerik:RadCodeBlock>
<h2>課程設定<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest"
                    EnablePageHeadUpdate="False">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="gv" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="gv">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="gv" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManager>
                <telerik:RadButton ID="btnExportExcel" runat="server" 
        onclick="btnExportExcel_Click" Text="匯出Excel">
    </telerik:RadButton>
                </h2>
    <telerik:RadGrid ID="gv" runat="server" CellSpacing="0" GridLines="None" 
        AllowPaging="True" AllowSorting="True" 
        AutoGenerateColumns="False" DataSourceID="sdsGv" 
        onitemcreated="gv_ItemCreated" Skin="Windows7" 
        AllowFilteringByColumn="True" ondeletecommand="gv_DeleteCommand" 
        onitemdatabound="gv_ItemDataBound" Culture="zh-TW" PageSize="20" 
        onitemcommand="gv_ItemCommand">
<MasterTableView datakeynames="iAutoKey" datasourceid="sdsGv" PageSize="15">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
            UniqueName="TemplateColumn" EditFormHeaderTextFormat="{0:d}:" 
            AllowFiltering="False">
            <HeaderTemplate>
                <telerik:RadButton ID="btnAdd" runat="server" Text="新增">
                </telerik:RadButton>
            </HeaderTemplate>
            <ItemTemplate>
             <telerik:RadButton ID="btnEdit" runat="server" Text="編輯">
                </telerik:RadButton>
                <telerik:RadButton ID="btnDel" runat="server" Text="失效" CommandName="Inactive">
                </telerik:RadButton>
                <telerik:RadButton ID="btnMustTraining" runat="server" 
                    CommandName="MustTraining" Text="必訓">
                </telerik:RadButton>
                <telerik:RadButton ID="btnDelete" runat="server" CommandName="Delete" onclientclicking="StandardConfirm"
                    ForeColor="Red" Text="刪除">
                </telerik:RadButton>
            </ItemTemplate>
            <ItemStyle Width="100px" Wrap="False" />
        </telerik:GridTemplateColumn>
        <telerik:GridBoundColumn DataField="CatScode" 
            FilterControlAltText="Filter CatScode column" HeaderText="階層碼" 
            UniqueName="CatScode" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="CatSname" 
            FilterControlAltText="Filter CatSname column" HeaderText="階層類別" 
            UniqueName="CatSname" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="sCode" 
            FilterControlAltText="Filter sCode column" HeaderText="課程碼" 
            SortExpression="sCode" UniqueName="sCode" FilterControlWidth="40px">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="sName" 
            FilterControlAltText="Filter sName column" HeaderText="課程名稱" 
            SortExpression="sName" UniqueName="sName" FilterControlWidth="150px">
            <ItemStyle Width="150px" Wrap="False" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="trnm" 
            FilterControlAltText="Filter trnm column" HeaderText="訓練方式" 
            SortExpression="trnm" UniqueName="trnm" FilterControlWidth="30px">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="tt" FilterControlAltText="Filter tt column" 
            HeaderText="訓練類別" SortExpression="tt" UniqueName="tt" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iCourseTime" 
            FilterControlAltText="Filter iCourseTime column" 
            HeaderText="授課時數" SortExpression="iCourseTime" 
            UniqueName="iCourseTime" DataType="System.Int64" DataFormatString="{0:N0}" 
            FilterControlWidth="30px">
        </telerik:GridBoundColumn>
        <telerik:GridCheckBoxColumn DataField="bIsSerialCourse" 
            DataType="System.Boolean" FilterControlAltText="Filter bIsSerialCourse column" 
            HeaderText="序列課程" SortExpression="bIsSerialCourse" 
            UniqueName="bIsSerialCourse" AllowFiltering="False">
            <HeaderStyle Wrap="False" />
        </telerik:GridCheckBoxColumn>
        <telerik:GridBoundColumn DataField="iValidityDay" 
            FilterControlAltText="Filter iValidityDay column" HeaderText="有效天" 
            UniqueName="iValidityDay">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iJobScore" 
            FilterControlAltText="Filter iJobScore column" 
            HeaderText="職能積分" SortExpression="iJobScore" 
            UniqueName="iJobScore" DataType="System.Decimal" DataFormatString="{0:N0}" 
            FilterControlWidth="30px">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dDateA" DataFormatString="{0:d}" 
            FilterControlAltText="Filter dDateA column" FilterControlWidth="20px" 
            HeaderText="生效日" UniqueName="dDateA">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dDateD" DataFormatString="{0:d}" 
            FilterControlAltText="Filter dDateD column" FilterControlWidth="20px" 
            HeaderText="失效日" UniqueName="dDateD">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
    </telerik:RadGrid>
    <asp:SqlDataSource ID="sdsGv" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
        DeleteCommand="DELETE FROM [trCourse] WHERE [iAutoKey] = @iAutoKey" 
        InsertCommand="INSERT INTO [trCourse] ([sysRole_iKey], [sCode], [sName], [sContent], [trTrainingMethod_sCode], [trTrainingType_sCode], [trTeachingMethod_sCode], [iCourseTime], [bIsSerialCourse], [iJobScore], [iEdition], [iValidityMonth], [iValidityDay], [iLeftDay], [dDateA], [dDateD], [sKeyMan], [dKeyDate]) VALUES (@sysRole_iKey, @sCode, @sName, @sContent, @trTrainingMethod_sCode, @trTrainingType_sCode, @trTeachingMethod_sCode, @iCourseTime, @bIsSerialCourse, @iJobScore, @iEdition, @iValidityMonth, @iValidityDay, @iLeftDay, @dDateA, @dDateD, @sKeyMan, @dKeyDate)" 
        SelectCommand="select cat.sCode as CatScode,cat.sName as CatSname,course.*,trmethod.sName as trnm,type.sName as tt,tcmethod.sName as team from trCourse as course 
left join trTrainingMethod trmethod on course.trTrainingMethod_sCode = trmethod.sCode
left join trTrainingType type on course.trTrainingType_sCode = type.sCode
left join trTeachingMethod tcmethod on course.trTeachingMethod_sCode = tcmethod.sCode
left join trCategoryCourse cc on course.sCode = cc.sCourseCode
left join trCategory cat on cc.sCateCode = cat.sCode" 
        
        
        
        
        
        
        UpdateCommand="UPDATE [trCourse] SET [sysRole_iKey] = @sysRole_iKey, [sCode] = @sCode, [sName] = @sName, [sContent] = @sContent, [trTrainingMethod_sCode] = @trTrainingMethod_sCode, [trTrainingType_sCode] = @trTrainingType_sCode, [trTeachingMethod_sCode] = @trTeachingMethod_sCode, [iCourseTime] = @iCourseTime, [bIsSerialCourse] = @bIsSerialCourse, [iJobScore] = @iJobScore, [iEdition] = @iEdition, [iValidityMonth] = @iValidityMonth, [iValidityDay] = @iValidityDay, [iLeftDay] = @iLeftDay, [dDateA] = @dDateA, [dDateD] = @dDateD, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
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
            <asp:Parameter Name="iValidityMonth" Type="Int32" />
            <asp:Parameter Name="iValidityDay" Type="Int32" />
            <asp:Parameter Name="iLeftDay" Type="Int32" />
            <asp:Parameter Name="dDateA" Type="DateTime" />
            <asp:Parameter Name="dDateD" Type="DateTime" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dKeyDate" Type="DateTime" />
        </InsertParameters>
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
            <asp:Parameter Name="iValidityMonth" Type="Int32" />
            <asp:Parameter Name="iValidityDay" Type="Int32" />
            <asp:Parameter Name="iLeftDay" Type="Int32" />
            <asp:Parameter Name="dDateA" Type="DateTime" />
            <asp:Parameter Name="dDateD" Type="DateTime" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dKeyDate" Type="DateTime" />
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
                <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="True">
                    <Windows>
                        <telerik:RadWindow ID="UserListDialog" runat="server" Title="Editing record" Height="550px"
                            Width="650px" ReloadOnShow="true" ShowContentDuringLoad="false" 
                            Modal="true" />
                        <telerik:RadWindow ID="UserListDialog2" runat="server" EnableShadow="True" Modal="True"
                            Style="display: none;" Height="550px" Width="650px">
                        </telerik:RadWindow>
                    </Windows>
                </telerik:RadWindowManager>
    <br />
    
    </asp:Content>

