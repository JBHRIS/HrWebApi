<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MainDeptRating.aspx.cs" Inherits="Performance.MainDeptRating" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="wrapper wrapper-content animated fadeIn">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy2" runat="server">
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
            <telerik:AjaxSetting AjaxControlID="btnSaveRating">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
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
                        <h5>內容</h5>
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
                        <div class="form-group  row">
                            <div class="col-sm-11 ">
                                <input type="text" class="form-control form-control-sm m-b-xs" id="filter" placeholder="搜尋表格內的字串">
                            </div>
                            <div class="col-sm-1 ">
                                <telerik:RadButton ID="btnExportExcel" runat="server" Text="匯出" OnClick="btnExportExcel_Click" CssClass="btn btn-w-m btn-info" />
                            </div>
                        </div>                        
                        <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                            <telerik:RadListView ID="lvMain" runat="server" DataKeyNames="AutoKey" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="lvMain_NeedDataSource" OnDataBound="lvMain_DataBound" OnItemCommand="lvMain_ItemCommand">
                                <LayoutTemplate>
                                    <table class="footable table table-stripped" data-page-size="10" data-filter="#filter">
                                        <thead>
                                            <tr>
                                                <th>評等</th>
                                                <th data-hide="phone,tablet">可得獎金<br>
                                                    上限(%)</th>
                                                <th data-hide="phone,tablet">可得獎金<br>
                                                    下限(%)</th>
                                                <th data-hide="phone,tablet">評等人數<br>
                                                    上限(%)</th>
                                                <th data-hide="phone,tablet">評等人數<br>
                                                    下限(%)</th>
                                                <th >調整<br>
                                                    人數(%)</th>
                                            </tr>
                                        </thead>
                                        <tbody id="Container" runat="server">
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <td colspan="13">
                                                    <ul class="pagination float-right"></ul>
                                                </td>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr class="gradeX">
                                        <td><%# Eval("Name") %></td>
                                        <td><%# Eval("BonusPerMax") %></td>
                                        <td><%# Eval("BonusPerMin") %></td>
                                        <td><%# Eval("NumPerMax") %></td>
                                        <td><%# Eval("NumPerMin") %></td>
                                        <td>
                                            <telerik:RadNumericTextBox Text='<%# Eval("NumPerNew") %>' Width="100%" EnabledStyle-HorizontalAlign="Right"
                                                ID="txtNumPerNew" NumberFormat-DecimalDigits="0" MaxLength="3"  Skin="Bootstrap"
                                                MinValue="0" MaxValue="100" runat="server" />
                                            <telerik:RadToolTip RenderMode="Lightweight" ID="ttNumPerNew" runat="server" Width="400px" ShowEvent="OnClick"
                                                TargetControlID="txtNumPerNew" IsClientID="true" HideEvent="LeaveToolTip" Position="TopRight"  Skin="Bootstrap"
                                                ShowDelay="0" RelativeTo="Element" Text="" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    目前並無任何資料
                                </EmptyDataTemplate>
                            </telerik:RadListView>
                            <telerik:RadButton ID="btnSaveRating" runat="server" Text="儲存評等調整"  OnClientClicking="ExcuteConfirm" CssClass="btn btn-primary" OnClick="btnSaveRating_Click" />
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
    <script src="Templates/Inspinia/js/plugins/footable/footable.all.min.js"></script>

    <script>
        $(document).ready(function () {
            $('.footable').footable();
        });
    </script>
</asp:Content>
