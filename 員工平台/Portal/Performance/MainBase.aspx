<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MainBase.aspx.cs" Inherits="Performance.MainBase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <script type="text/javascript">
        var SumInput = 0.0;
        var TempValue = 0.0;

        function Load(sender, args) {
            SumInput = sender;
        }
        function Blur(sender, args) {
            SumInput.set_value(TempValue + sender.get_value());
        }
        function Focus(sender, args) {
            TempValue = SumInput.get_value() - sender.get_value();
        }
    </script>
    <style>
        .k-pdf-export, .k-pdf-export * {
            font-family: 'Arial Unicode MS' !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlMain">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
                    <telerik:AjaxUpdatedControl ControlID="gvDept" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlDept">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
                    <telerik:AjaxUpdatedControl ControlID="gvDept" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbSubDept">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbBase">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSave">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnApprove">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnReject">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnReminder">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSave">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnReCalRating">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnReset">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnImport">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox ">
                    <div class="ibox-title">
                        <h5>條件</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <telerik:RadAjaxPanel ID="plSearch" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">考核類別/部門</label>
                                <div class="col-sm-3 ">
                                    <telerik:RadDropDownList ID="ddlMain" Width="100%" runat="server" AutoPostBack="true" Skin="Bootstrap" OnSelectedIndexChanged="ddlMain_SelectedIndexChanged" />
                                </div>
                                <div class="col-sm-3 ">
                                    <telerik:RadDropDownTree RenderMode="Lightweight" runat="server" Width="100%" ID="ddlDept" AutoPostBack="true" Skin="Bootstrap" DefaultMessage="請選擇要檢視的部門..." OnEntryAdded="ddlDept_EntryAdded">
                                        <DropDownSettings CloseDropDownOnSelection="true" />
                                    </telerik:RadDropDownTree>
                                </div>
                                <div class="col-sm-2 ">
                                    <telerik:RadCheckBox ID="cbSubDept" runat="server" Text="包含子部門" AutoPostBack="true" Checked="true" Skin="Bootstrap"  OnCheckedChanged="cbSubDept_CheckedChanged" />
                                </div>
                                <div class="col-sm-2 ">
                                    <telerik:RadCheckBox ID="cbBase" runat="server" Text="隱藏未完成部門" AutoPostBack="true" Checked="false" Skin="Bootstrap"  OnCheckedChanged="cbBase_CheckedChanged" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">關鍵字</label>
                                <div class="col-sm-8 ">
                                    <telerik:RadTextBox ID="txtSearchKey" runat="server" EmptyMessage="搜尋下表，請輸入關鍵字" Width="100%" CssClass="form-control" />
                                </div>
                                <div class="col-sm-2 ">
                                    <telerik:RadButton ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click" CssClass="btn btn-primary btn-sm" />
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">訊息</label>
                                <div class="col-sm-10 ">
                                    <telerik:RadLabel ID="lblMsg" CssClass="badge badge-danger" runat="server" />
                                </div>
                            </div>
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="ibox-title">
                        <h5>員工名單</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                            <a class="fullscreen-link">
                                <i class="fa fa-expand"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                            <div class="form-group  row">
                                <div class="col-md-auto ">
                                    <telerik:RadButton ID="btnSave" runat="server" Text="儲存內容" OnClick="btnSave_Click" CssClass="btn btn-w-m btn-info" />
                                </div>
                                <div class="col-md-auto ">
                                    <telerik:RadButton ID="btnApprove" runat="server" Text="儲存內容並送出" OnClick="btnApprove_Click" CssClass="btn btn-w-m btn-info" />
                                </div>
                                <div class="col-md-auto ">
                                    <telerik:RadButton ID="btnReject" runat="server" Text="退回上一關" OnClick="btnReject_Click" CssClass="btn btn-w-m btn-info" />
                                </div>
                                <div class=" col-md-auto">
                                    <telerik:RadButton ID="btnReminder" runat="server" Text="催簽" OnClick="btnReminder_Click" CssClass="btn btn-w-m btn-info" />
                                </div>
                                <div class="col-md-auto ">
                                    <telerik:RadButton ID="btnReCalRating" runat="server" Text="自動計算評等" OnClick="btnReCalRating_Click" CssClass="btn btn-w-m btn-info" />
                                </div>
                                <div class="col-md-auto ">
                                    <telerik:RadButton ID="btnReset" runat="server" Text="全部還原重置" OnClick="btnReset_Click" CssClass="btn btn-w-m btn-info" />
                                </div>
                                <div class=" col-md-auto">
                                    <telerik:RadButton ID="btnExportExcel" runat="server" Text="匯出" OnClick="btnExportExcel_Click" CssClass="btn btn-w-m btn-info" />
                                </div>
                                <div class="col-md-auto ">
                                    <telerik:RadButton ID="btnImport" runat="server" Text="匯入" OnClick="btnImport_Click" CssClass="btn btn-w-m btn-info" />
                                </div>
                                <asp:PlaceHolder ID="phBonusBalance" runat="server">
                                    <label class="col-md-auto align-self-center">可分配獎金</label>
                                    <div class=" align-self-center">
                                        <telerik:RadNumericTextBox ReadOnly="true" EnabledStyle-HorizontalAlign="Right"
                                            ID="txtBonusBalance" NumberFormat-DecimalDigits="0" Width="100%" CssClass="form-control spacing TextNoBorder " runat="server" ClientEvents-OnLoad="Load" />                                        
                                    </div>
                                </asp:PlaceHolder>
                            </div>
                            <telerik:RadGrid ID="gvMain" runat="server" AllowPaging="True" AllowSorting="True" Skin="Bootstrap"
                                Height="700px" AutoGenerateColumns="False" CellSpacing="0"
                                Width="100%" Culture="zh-TW" GridLines="None" OnNeedDataSource="gvMain_NeedDataSource"
                                OnItemCommand="gvMain_ItemCommand" OnExportCellFormatting="gvMain_ExportCellFormatting"
                                OnDataBound="gvMain_DataBound">
                                <ClientSettings AllowKeyboardNavigation="true">
                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="true" EnableColumnClientFreeze="true" FrozenColumnsCount="2" />
                                </ClientSettings>
                                <HeaderStyle Wrap="false" VerticalAlign="Middle" HorizontalAlign="Center" CssClass="GridColumn" />
                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" CssClass="GridColumn" />
                                <AlternatingItemStyle VerticalAlign="Middle" HorizontalAlign="Center" CssClass="GridColumn" />
                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="AutoKey" ClientDataKeyNames="AutoKey">
                                    <ColumnGroups>
                                        <telerik:GridColumnGroup Name="Pre" HeaderText="Pre" HeaderStyle-HorizontalAlign="Center" />
                                    </ColumnGroups>
                                    <ColumnGroups>
                                        <telerik:GridColumnGroup Name="PrePre" HeaderText="PrePre" HeaderStyle-HorizontalAlign="Center" />
                                    </ColumnGroups>
                                    <Columns>
                                        <telerik:GridTemplateColumn DataField="EmpId" HeaderStyle-Width="70px"
                                            FilterControlAltText="Filter EmpId column" HeaderText="工號"
                                            SortExpression="EmpId" UniqueName="EmpId">
                                            <ItemTemplate>
                                                <telerik:RadLabel ID="lblEmpId" Text='<%# Eval("EmpId") %>' runat="server" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="EmpName" ItemStyle-Wrap="false" HeaderStyle-Width="70px"
                                            FilterControlAltText="Filter EmpName column" HeaderText="姓名"
                                            SortExpression="EmpName" UniqueName="EmpName">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="JobName" ItemStyle-Wrap="false" HeaderStyle-Width="80px"
                                            FilterControlAltText="Filter JobName column" HeaderText="職稱"
                                            SortExpression="JobName" UniqueName="JobName">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn DataField="WorkPerformance" HeaderStyle-Width="80px"
                                            FilterControlAltText="Filter WorkPerformance column" HeaderText="工作<br>績效"
                                            SortExpression="WorkPerformance" UniqueName="WorkPerformance">
                                            <ItemTemplate>
                                                <telerik:RadNumericTextBox Text='<%# Eval("WorkPerformance") %>' Width="100%" Skin="Bootstrap"
                                                    ID="txtWorkPerformance" NumberFormat-DecimalDigits="0" EnabledStyle-HorizontalAlign="Right"
                                                    MaxLength="2" MinValue="0" MaxValue="99" runat="server" />
                                                <telerik:RadToolTip RenderMode="Lightweight" ID="ttWorkPerformance" runat="server" Width="100px" ShowEvent="OnClick"
                                                    TargetControlID="txtWorkPerformance" IsClientID="true" HideEvent="LeaveToolTip" Position="TopRight" Skin="Bootstrap"
                                                    ShowDelay="0" RelativeTo="Element" Text="" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="MannerEsteem" HeaderStyle-Width="80px"
                                            FilterControlAltText="Filter MannerEsteem column" HeaderText="工作<br>態度"
                                            SortExpression="MannerEsteem" UniqueName="MannerEsteem">
                                            <ItemTemplate>
                                                <telerik:RadNumericTextBox Text='<%# Eval("MannerEsteem") %>' Width="100%" Skin="Bootstrap"
                                                    ID="txtMannerEsteem" NumberFormat-DecimalDigits="0" EnabledStyle-HorizontalAlign="Right"
                                                    MaxLength="2" MinValue="0" MaxValue="99" runat="server" />
                                                <telerik:RadToolTip RenderMode="Lightweight" ID="ttMannerEsteem" runat="server" Width="100px" ShowEvent="OnClick"
                                                    TargetControlID="txtMannerEsteem" IsClientID="true" HideEvent="LeaveToolTip" Position="TopRight" Skin="Bootstrap"
                                                    ShowDelay="0" RelativeTo="Element" Text="" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="AbilityEsteem" HeaderStyle-Width="80px"
                                            FilterControlAltText="Filter AbilityEsteem column" HeaderText="能力<br>評價"
                                            SortExpression="AbilityEsteem" UniqueName="AbilityEsteem">
                                            <ItemTemplate>
                                                <telerik:RadNumericTextBox Text='<%# Eval("AbilityEsteem") %>' Width="100%" Skin="Bootstrap"
                                                    ID="txtAbilityEsteem" NumberFormat-DecimalDigits="0" EnabledStyle-HorizontalAlign="Right"
                                                    MaxLength="2" MinValue="0" MaxValue="99" runat="server" />
                                                <telerik:RadToolTip RenderMode="Lightweight" ID="ttAbilityEsteem" runat="server" Width="100px" ShowEvent="OnClick"
                                                    TargetControlID="txtAbilityEsteem" IsClientID="true" HideEvent="LeaveToolTip" Position="TopRight" Skin="Bootstrap"
                                                    ShowDelay="0" RelativeTo="Element" Text="" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="Encourage" HeaderStyle-Width="80px"
                                            FilterControlAltText="Filter Encourage column" HeaderText="激勵"
                                            SortExpression="Encourage" UniqueName="Encourage">
                                            <ItemTemplate>
                                                <telerik:RadNumericTextBox Text='<%# Eval("Encourage") %>' Width="100%" Skin="Bootstrap"
                                                    EnabledStyle-HorizontalAlign="Right" ID="txtEncourage" NumberFormat-DecimalDigits="0"
                                                    MaxLength="2" MinValue="0" MaxValue="99" runat="server" />
                                                <telerik:RadToolTip RenderMode="Lightweight" ID="ttEncourage" runat="server" Width="100px" ShowEvent="OnClick"
                                                    TargetControlID="txtEncourage" IsClientID="true" HideEvent="LeaveToolTip" Position="TopRight" Skin="Bootstrap"
                                                    ShowDelay="0" RelativeTo="Element" Text="" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="TotalIntegrate" HeaderStyle-Width="120px"
                                            FilterControlAltText="Filter TotalIntegrate column" HeaderText="評核<br>總分" ItemStyle-HorizontalAlign="Right"
                                            SortExpression="TotalIntegrate" UniqueName="TotalIntegrate">
                                            <ItemTemplate>
                                                <div class="form-group row">
                                                    <div class="col-sm-8 spacing3">
                                                        <telerik:RadNumericTextBox Text='<%# Eval("TotalIntegrate") %>' Width="100%" Skin="Bootstrap" CssClass="TextNoBorderRight"
                                                            ReadOnly="true" EnabledStyle-HorizontalAlign="Right" ID="txtTotalIntegrate" NumberFormat-DecimalDigits="0"
                                                            runat="server" />
                                                    </div>
                                                    <div class="col-sm-4 spacing2">
                                                        <asp:Image ID="imgTotalIntegrate" runat="server" ImageUrl="~/images/d.png" Width="10px" Height="10px" />
                                                        <telerik:RadToolTip RenderMode="Lightweight" ID="ttTotalIntegrate" runat="server" Width="200px" ShowEvent="onmouseover"
                                                            TargetControlID="txtTotalIntegrate" IsClientID="true" HideEvent="LeaveToolTip" Position="TopRight" Skin="Bootstrap"
                                                            ShowDelay="0" RelativeTo="Element" Text="" />
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="RatingCode" HeaderStyle-Width="90px"
                                            FilterControlAltText="Filter RatingCode column" HeaderText="評等"
                                            SortExpression="RatingCode" UniqueName="RatingCode">
                                            <ItemTemplate>
                                                <telerik:RadDropDownList ID="ddlRating" runat="server" Width="100%" Skin="Bootstrap" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="PreRatingName" ItemStyle-Wrap="false" HeaderStyle-Width="50px"
                                            FilterControlAltText="Filter PreRatingName column" HeaderText="上次<br>評等"
                                            SortExpression="PreRatingName" UniqueName="PreRatingName" ColumnGroupName="Pre">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PreTotalIntegrate" ItemStyle-HorizontalAlign="Right" DataType="System.Int32" DataFormatString="{0:N0}" HeaderStyle-Width="50px"
                                            FilterControlAltText="Filter PreTotalIntegrate column" HeaderText="上次<br>分數"
                                            SortExpression="PreTotalIntegrate" UniqueName="PreTotalIntegrate" ColumnGroupName="Pre">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PrePreRatingName" ItemStyle-Wrap="false" HeaderStyle-Width="60px"
                                            FilterControlAltText="Filter PrePreRatingName column" HeaderText="上上次<br>評等"
                                            SortExpression="PrePreRatingName" UniqueName="PrePreRatingName" ColumnGroupName="PrePre">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PrePreTotalIntegrate" ItemStyle-HorizontalAlign="Right" DataType="System.Int32" DataFormatString="{0:N0}" HeaderStyle-Width="60px"
                                            FilterControlAltText="Filter PrePreTotalIntegrate column" HeaderText="上上次<br>分數"
                                            SortExpression="PrePreTotalIntegrate" UniqueName="PrePreTotalIntegrate" ColumnGroupName="PrePre">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="BonusCardinal" HeaderStyle-Width="70px"
                                            FilterControlAltText="Filter BonusCardinal column" HeaderText="獎金<br>基數"
                                            SortExpression="BonusCardinal" UniqueName="BonusCardinal" ItemStyle-HorizontalAlign="Right" DataType="System.Int32" DataFormatString="{0:N0}">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn DataField="BonusAdjust" HeaderStyle-Width="90px"
                                            FilterControlAltText="Filter BonusAdjust column" HeaderText="考績<br>加減"
                                            SortExpression="BonusAdjust" UniqueName="BonusAdjust">
                                            <ItemTemplate>
                                                <div style="display: none;" class="BonusAdjustBlock">
                                                    <div class="BonusDeductBlock">
                                                        ↓
                                        <telerik:RadNumericTextBox Text='<%# Eval("BonusDeduct") %>' EnabledStyle-HorizontalAlign="Right" ForeColor="Red" ReadOnly="true"
                                            CssClass="TextNoBorderRight" Width="60px" ID="txtBonusDeduct" NumberFormat-DecimalDigits="0" Font-Size="10px"
                                            runat="server" />
                                                        <telerik:RadNumericTextBox Text='<%# Eval("BonusDeduct") %>' EnabledStyle-HorizontalAlign="Right" ForeColor="Red" ReadOnly="true"
                                                            CssClass="TextNoBorderRight" Width="60px" ID="txtBonusDeduct1" NumberFormat-DecimalDigits="0" Font-Size="10px"
                                                            runat="server" />
                                                    </div>
                                                    <div class="BonusMaxBlock">
                                                        ↑
                                        <telerik:RadNumericTextBox Text='<%# Eval("BonusMax") %>' EnabledStyle-HorizontalAlign="Right" ForeColor="Blue" ReadOnly="true"
                                            CssClass="TextNoBorderRight" Width="60px" ID="txtBonusMax" NumberFormat-DecimalDigits="0" Font-Size="10px"
                                            runat="server" />
                                                        <telerik:RadNumericTextBox Text='<%# Eval("BonusMax") %>' EnabledStyle-HorizontalAlign="Right" ForeColor="Blue" ReadOnly="true"
                                                            CssClass="TextNoBorderRight" Width="60px" ID="txtBonusMax1" NumberFormat-DecimalDigits="0" Font-Size="10px"
                                                            runat="server" />
                                                    </div>
                                                </div>
                                                <telerik:RadNumericTextBox Text='<%# Eval("BonusAdjust") %>' EnabledStyle-HorizontalAlign="Right" Width="100%" Skin="Bootstrap"
                                                    ID="txtBonusAdjust" NumberFormat-DecimalDigits="0" AllowOutOfRangeAutoCorrect="false"
                                                    MaxLength="6" runat="server" InvalidStyle-CssClass="InvalidStyle" />
                                                <telerik:RadNumericTextBox Text='<%# Eval("BonusAdjust") %>' EnabledStyle-HorizontalAlign="Right" Display="false" Width="100%" Skin="Bootstrap"
                                                    ID="txtBonusAdjustTemp" NumberFormat-DecimalDigits="0" AllowOutOfRangeAutoCorrect="false"
                                                    MaxLength="6" runat="server" />
                                                <telerik:RadToolTip RenderMode="Lightweight" ID="ttBonusAdjust" runat="server" Width="200px" ShowEvent="OnClick"
                                                    TargetControlID="txtBonusAdjust" IsClientID="true" HideEvent="LeaveToolTip" Position="TopRight"
                                                    ShowDelay="0" RelativeTo="Element" Text="" Skin="Bootstrap" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="BonusReal" HeaderStyle-Width="200px"
                                            FilterControlAltText="Filter BonusReal column" HeaderText="總分配<br>獎金" ItemStyle-HorizontalAlign="Right"
                                            SortExpression="BonusReal" UniqueName="BonusReal">
                                            <ItemTemplate>
                                                <telerik:RadNumericTextBox Text='<%# Eval("BonusReal") %>' ReadOnly="true"
                                                    ID="txtBonusReal" NumberFormat-DecimalDigits="0" EnabledStyle-HorizontalAlign="Right" Skin="Bootstrap" CssClass="TextNoBorderRight"
                                                    runat="server">
                                                </telerik:RadNumericTextBox>
                                                <telerik:RadLabel ID="lblBonusCardinal" runat="server"
                                                    Text='<%# Eval("BonusCardinal") %>' Visible="false" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="Note" HeaderStyle-Width="200px"
                                            FilterControlAltText="Filter Note column" HeaderText="備註"
                                            SortExpression="Note" UniqueName="Note">
                                            <ItemTemplate>
                                                <telerik:RadTextBox ID="txtNote" Text='<%# Eval("Note") %>' Skin="Bootstrap"
                                                    runat="server" EmptyMessage="備註" Width="100%" Height="35px" TextMode="MultiLine" />
                                                <telerik:RadToolTip RenderMode="Lightweight" ID="ttNote" runat="server" Width="200px" ShowEvent="OnClick"
                                                    TargetControlID="txtNote" IsClientID="true" HideEvent="LeaveToolTip" Position="TopRight"
                                                    ShowDelay="0" RelativeTo="Element" Text="" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="ibox-title">
                        <h5>部門資訊</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                            <a class="fullscreen-link">
                                <i class="fa fa-expand"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <telerik:RadGrid ID="gvDept" runat="server" AllowPaging="false" AllowSorting="True" Skin="Bootstrap"
                            AutoGenerateColumns="True" CellSpacing="0" Culture="zh-TW" GridLines="None"
                            OnNeedDataSource="gvDept_NeedDataSource" OnDataBound="gvDept_DataBound" OnColumnCreated="gvDept_ColumnCreated">
                            <HeaderStyle Wrap="false" VerticalAlign="Middle" HorizontalAlign="Center" />
                            <MasterTableView AutoGenerateColumns="True">
                                <ColumnGroups>
                                    <telerik:GridColumnGroup Name="RatingPeople" HeaderText="評等分配(人數 / 百分比)" HeaderStyle-HorizontalAlign="Center" />
                                </ColumnGroups>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
