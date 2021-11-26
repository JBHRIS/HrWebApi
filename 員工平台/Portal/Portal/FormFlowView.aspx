<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FormFlowView.aspx.cs" Inherits="Portal.FormFlowView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearchEmp">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMsg" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="plFlowViewMain" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSearchEmpAdmin">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMsg" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="plFlowViewMain" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSearchEmpCoordinator">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMsg" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="plFlowViewMain" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ckbAll">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plFlowViewMain" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnActive">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMsg" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="plFlowViewMain" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="plFlowViewAdmin" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="control control-style2">
                        <telerik:RadAjaxPanel runat="server" ID="plFlowViewEmp">
                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <label class="col-form-label">表單名稱</label>
                                    <telerik:RadComboBox ID="ddlFormEmp" runat="server" CssClass="formItem" Culture="zh-TW" Skin="Bootstrap" Width="100%"
                                        LoadingMessage="載入中…" AppendDataBoundItems="True">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Owner="txtFlowForm" Selected="True" Text="All"
                                                Value="0" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </div>
                                <div class="col-sm-3">
                                    <label class="col-form-label">流程序號</label>
                                    <telerik:RadTextBox ID="txtProcessIdEmp" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" Skin="Bootstrap" AutoPostBack="True" Width="100%">
                                    </telerik:RadTextBox>
                                </div>
                                <div class="col-sm-3">
                                    <label class="col-form-label">角色</label>
                                    <telerik:RadComboBox ID="ddlRoleEmp" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" Skin="Bootstrap" AutoPostBack="True" Width="100%" OnSelectedIndexChanged="ddlRoleEmp_SelectedIndexChanged">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Text="申請者" Value="0" />
                                            <telerik:RadComboBoxItem runat="server" Text="被申請者" Value="1" />
                                            <telerik:RadComboBoxItem runat="server" Text="審核者" Value="2" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </div>
                                <div class="col-sm-1 form-inline m-t-lg">
                                    <label>
                                        <telerik:RadCheckBox runat="server" ID="isFinish" Checked="false"></telerik:RadCheckBox>
                                        結案
                                    </label>
                                </div>
                                <div class="col-sm-2 form-inline m-t-lg">
                                    <label>
                                        <telerik:RadCheckBox runat="server" ID="ckbNoShowMyProcessEmp" Text="不顯示自己的表單" Checked="false" Visible="false"></telerik:RadCheckBox>
                                    </label>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <label class="col-form-label">開始申請日期</label>
                                    <telerik:RadDatePicker ID="txtDateBEmp" runat="server" AutoPostBack="True" Skin="Bootstrap" Width="100%">
                                    </telerik:RadDatePicker>
                                </div>
                                <div class="col-sm-3">
                                    <label class=" col-form-label">結束申請日期</label>
                                    <telerik:RadDatePicker ID="txtDateEEmp" runat="server" AutoPostBack="True" Skin="Bootstrap" Width="100%">
                                    </telerik:RadDatePicker>
                                </div>
                                <div class="col-sm-3 form-inline m-t-lg">
                                    <div class="col-sm-6">
                                        <telerik:RadButton runat="server" ID="btnSearchEmp" CssClass="btn btn-primary" Text="查詢" OnClick="btnSearchEmp_Click"></telerik:RadButton>
                                    </div>
                                </div>
                            </div>

                        </telerik:RadAjaxPanel>
                        <telerik:RadAjaxPanel runat="server" ID="plFlowViewCoordinator">
                            <div class="form-group row">
                                <div class="col-sm-2">
                                    <label class="col-form-label">表單名稱</label>
                                    <telerik:RadComboBox ID="ddlFormCoordinator" runat="server" Skin="Bootstrap" Width="100%" AppendDataBoundItems="True">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Owner="txtFlowForm" Selected="True" Text="All"
                                                Value="0" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </div>
                                <div class="col-sm-2">
                                    <label class="col-form-label">流程序號</label>
                                    <telerik:RadTextBox ID="txtProcessIdCoordinator" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" Skin="Bootstrap" AutoPostBack="True" Width="100%">
                                    </telerik:RadTextBox>
                                </div>
                                <div class="col-sm-2">
                                    <label class="col-form-label">部門名稱</label>
                                    <telerik:RadComboBox ID="ddlDeptCoordinator" runat="server" Skin="Bootstrap" AutoPostBack="True" AllowCustomText="True" Filter="Contains" Width="100%" OnSelectedIndexChanged="ddlDeptCoordinator_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </div>
                                <div class="col-sm-3">
                                    <label class="col-form-label">員工姓名</label>
                                    <telerik:RadComboBox ID="txtNameCoordinator" runat="server" Culture="zh-TW" AllowCustomText="True" Skin="Bootstrap" Width="100%"
                                        AutoPostBack="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains">
                                    </telerik:RadComboBox>
                                </div>
                                <div class="col-sm-3">
                                    <label class="col-form-label">角色</label>
                                    <telerik:RadComboBox ID="ddlRoleCoordinator" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" Skin="Bootstrap" AutoPostBack="True" Width="100%">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Text="申請者" Value="0" />
                                            <telerik:RadComboBoxItem runat="server" Text="被申請者" Value="1" />
                                            <telerik:RadComboBoxItem runat="server" Text="審核者" Value="2" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <label class="col-form-label">開始申請日期</label>
                                    <telerik:RadDatePicker ID="txtDateBCoordinator" runat="server" AutoPostBack="True" Skin="Bootstrap" Width="100%">
                                    </telerik:RadDatePicker>
                                </div>
                                <div class="col-sm-3">
                                    <label class=" col-form-label">結束申請日期</label>
                                    <telerik:RadDatePicker ID="txtDateECoordinator" runat="server" AutoPostBack="True" Skin="Bootstrap" Width="100%">
                                    </telerik:RadDatePicker>
                                </div>
                                <div class="col-sm-3">
                                    <label class=" col-form-label">狀態</label>
                                    <telerik:RadComboBox ID="ddlStateCoordinator" runat="server" CssClass="formItem" Culture="zh-TW" Skin="Bootstrap" Width="100%"
                                        LoadingMessage="載入中…" AppendDataBoundItems="True" AutoPostBack="True">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="進行中" Value="1" />
                                            <telerik:RadComboBoxItem runat="server" Text="已完成" Value="3" />
                                            <telerik:RadComboBoxItem runat="server" Text="已駁回" Value="2" />
                                            <telerik:RadComboBoxItem runat="server" Text="已抽單" Value="7" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </div>
                                <div class="col-sm-3 form-inline m-t-lg">
                                    <telerik:RadButton runat="server" ID="btnSearchEmpCoordinator" CssClass="btn btn-primary" Text="查詢" OnClick="btnSearchCoordinator_Click"></telerik:RadButton>
                                </div>
                            </div>

                        </telerik:RadAjaxPanel>
                        <telerik:RadAjaxPanel runat="server" ID="plFlowViewAdmin">
                            <div class="form-group row">
                                <div class="col-sm-2">
                                    <label class="col-form-label">表單名稱</label>
                                    <telerik:RadComboBox ID="ddlFormAdmin" runat="server" Skin="Bootstrap" Width="100%" AppendDataBoundItems="True">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Owner="txtFlowForm" Selected="True" Text="All"
                                                Value="0" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </div>
                                <div class="col-sm-2">
                                    <label class="col-form-label">流程序號</label>
                                    <telerik:RadTextBox ID="txtProcessIdAdmin" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" Skin="Bootstrap" AutoPostBack="True" Width="100%">
                                    </telerik:RadTextBox>
                                </div>
                                <div class="col-sm-2">
                                    <label class="col-form-label">部門名稱</label>
                                    <telerik:RadComboBox ID="ddlDeptAdmin" runat="server" Skin="Bootstrap" AutoPostBack="True" AllowCustomText="True" Filter="Contains" Width="100%" OnSelectedIndexChanged="ddlDeptAdmin_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </div>
                                <div class="col-sm-3">
                                    <label class="col-form-label">員工姓名</label>
                                    <telerik:RadComboBox ID="txtNameAdmin" runat="server" Culture="zh-TW" AllowCustomText="True" Skin="Bootstrap" Width="100%"
                                        AutoPostBack="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains">
                                    </telerik:RadComboBox>
                                </div>
                                <div class="col-sm-3">
                                    <label class="col-form-label">角色</label>
                                    <telerik:RadComboBox ID="ddlRoleAdmin" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" Skin="Bootstrap" AutoPostBack="True" Width="100%">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Text="申請者" Value="0" />
                                            <telerik:RadComboBoxItem runat="server" Text="被申請者" Value="1" />
                                            <telerik:RadComboBoxItem runat="server" Text="審核者" Value="2" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <label class="col-form-label">開始申請日期</label>
                                    <telerik:RadDatePicker ID="txtDateBAdmin" runat="server" AutoPostBack="True" Skin="Bootstrap" Width="100%">
                                    </telerik:RadDatePicker>
                                </div>
                                <div class="col-sm-3">
                                    <label class=" col-form-label">結束申請日期</label>
                                    <telerik:RadDatePicker ID="txtDateEAdmin" runat="server" AutoPostBack="True" Skin="Bootstrap" Width="100%">
                                    </telerik:RadDatePicker>
                                </div>
                                <div class="col-sm-3">
                                    <label class=" col-form-label">狀態</label>
                                    <telerik:RadComboBox ID="ddlStateAdmin" runat="server" CssClass="formItem" Culture="zh-TW" Skin="Bootstrap" Width="100%"
                                        LoadingMessage="載入中…" AppendDataBoundItems="True" AutoPostBack="True">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="進行中" Value="1" />
                                            <telerik:RadComboBoxItem runat="server" Text="已完成" Value="3" />
                                            <telerik:RadComboBoxItem runat="server" Text="已駁回" Value="2" />
                                            <telerik:RadComboBoxItem runat="server" Text="已作廢" Value="4" />
                                            <telerik:RadComboBoxItem runat="server" Text="已抽單" Value="7" Visible="false" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </div>
                                <div class="col-sm-3 form-inline m-t-lg">
                                    <telerik:RadButton runat="server" ID="btnSearchEmpAdmin" CssClass="btn btn-primary" Text="查詢" OnClick="btnSearchAdmin_Click"></telerik:RadButton>
                                </div>
                            </div>


                        </telerik:RadAjaxPanel>
                        <telerik:RadAjaxPanel ID="plHrTools" runat="server" Visible="false">
                            <div class="form-group row">
                                <div class="col-sm-2">
                                    <label class="col-form-label">
                                        <telerik:RadCheckBox ID="ckbAll" runat="server" OnClick="ckbAll_Click"></telerik:RadCheckBox>
                                        全選
                                    </label>
                                </div>
                                <div class="col-sm-5">
                                    <telerik:RadComboBox ID="txtActiveAdmin" runat="server" CssClass="formItem" Culture="zh-TW" Skin="Bootstrap" Width="100%" Visible="true"
                                        LoadingMessage="載入中…" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="txtActive_SelectedIndexChanged">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Owner="txtFlowForm" Selected="True" Text="起點重送流程"
                                                Value="1" />
                                            <telerik:RadComboBoxItem runat="server" Owner="txtFlowForm" Text="上點重送流程" Value="2" />
                                            <telerik:RadComboBoxItem runat="server" Owner="txtFlowForm" Text="核准存入" Value="3" />
                                            <telerik:RadComboBoxItem runat="server" Owner="txtFlowForm" Text="駁回" Value="4" />
                                            <telerik:RadComboBoxItem runat="server" Owner="txtFlowForm" Text="作廢" Value="5" />
                                            <telerik:RadComboBoxItem runat="server" Owner="txtFlowForm" Text="刪除實體資料" Value="6" />
                                            <telerik:RadComboBoxItem runat="server" Owner="txtFlowForm" Text="指向正職簽核" Value="7" />
                                            <telerik:RadComboBoxItem runat="server" Owner="txtFlowForm" Text="指向代理簽核" Value="8" />
                                            <telerik:RadComboBoxItem runat="server" Owner="txtFlowForm" Text="下點傳送" Value="9" Visible="false" />
                                            <telerik:RadComboBoxItem runat="server" Owner="txtFlowForm" Text="通知" Value="10" Visible="false" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </div>
                                <div class="col-sm-2">
                                    <telerik:RadComboBox ID="txtSignName" runat="server" Culture="zh-TW" AllowCustomText="True" Skin="Bootstrap" Width="100%"
                                        AutoPostBack="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains" Visible="false"
                                        LoadingMessage="載入中…">
                                    </telerik:RadComboBox>
                                </div>
                                <div class="col-sm-1">
                                    <telerik:RadButton ID="btnActive" runat="server" Text="執行" OnClientClicking="ExcuteConfirm" CssClass="btn btn-primary" Width="100%" Visible="true"
                                        OnClick="btnActive_Click">
                                    </telerik:RadButton>
                                </div>
                            </div>
                        </telerik:RadAjaxPanel>
                        <telerik:RadAjaxPanel runat="server" ID="plMsg">
                            <telerik:RadLabel runat="server" ID="lblMsg" CssClass="badge animated shake "></telerik:RadLabel>
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
                <telerik:RadAjaxPanel runat="server" ID="plFlowViewMain" LoadingPanelID="RadAjaxLoadingPanel1">

                    <div class="ibox-title">
                        <h5>流程資訊</h5>
                    </div>
                    <div class="ibox-content">

                        <telerik:RadListView runat="server" ID="lvMain" ItemPlaceholderID="Container" OnItemCommand="lvMain_ItemCommand">
                            <LayoutTemplate>
                                <table class="footable table table-stripped" data-page-size="10">
                                    <thead>
                                    </thead>
                                    <tbody id="Container" runat="server">
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <td colspan="1">
                                                <ul class="pagination float-right"></ul>
                                            </td>
                                        </tr>
                                    </tfoot>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr class="gradeX">
                                    <td>
                                        <div class="keyin keyin-border">
                                            <div class="row">
                                                <div class="col-sm-10">
                                                    <div class="row">
                                                        <div class="col-md-1">
                                                            <div class="row m-t-xs">
                                                                <div class="col col-xs-6">
                                                                    <label class="p-xs">
                                                                        <telerik:RadCheckBox runat="server" Skin="Bootstrap" AutoPostBack="false" ID="ckbSelecte" CommandArgument='<%#Eval("ProcessId") %>' CommandName="Select"></telerik:RadCheckBox>
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="row m-t-xs">
                                                                <div class="col col-xs-6">
                                                                    <span>流程序號：<telerik:RadLabel ID="lblProcessId" runat="server" Text='<%#Eval("ProcessId") %>'></telerik:RadLabel>
                                                                    </span>
                                                                    <br>
                                                                    <span>表單名稱：<%#Eval("FlowName") %></span>
                                                                </div>
                                                                <div class="col col-xs-6">
                                                                    <span>申請人：<%#Eval("Application") %></span><br>
                                                                    <%--<span>申請日期：<%#Eval("ADate","{0:yyyy/MM/dd}") %></span>--%>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-5">
                                                            <div class="row m-t-xs">
                                                                <div class="col col-xs-6">
                                                                    <span>流程開始時間：<%#Eval("DateB","{0:yyyy/MM/dd HH:mm}") %>　</span>
                                                                    <br>
                                                                    <span>流程結束時間：<%#Eval("DateE","{0:yyyy/MM/dd HH:mm}") %>　</span>
                                                                </div>

                                                                <div class="col col-xs-6">
                                                                    <%--<span>共計：<%#Eval("Use") %><%#Eval("Unit") %></span><br>
                                                            <span>代理人：<%#Eval("Agent") %></span>--%>
                                                                    <span>表單狀態:<%#Eval("FormState") %></span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-sm-1 m-t-xs">
                                                    <telerik:RadButton ID="btnView" runat="server" CssClass="btn btn-outline btn-success" Text="檢視" CommandArgument='<%#Eval("ProcessId") %>' CommandName='<%#Eval("ApViewAuto") %>'></telerik:RadButton>
                                                    <telerik:RadButton ID="btnViewImage" runat="server" CssClass="btn btn-outline btn-info" Text="流程" CommandArgument='<%#Eval("ProcessId") %>' CommandName="ViewImage"></telerik:RadButton>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>

                            </ItemTemplate>
                            <EmptyDataTemplate>
                                無流程資料
                            </EmptyDataTemplate>
                        </telerik:RadListView>
                    </div>
                </telerik:RadAjaxPanel>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="Templates/Inspinia/js/plugins/footable/footable.all.min.js"></script>
    <script>
        $(document).ready(function () {
            $('.footable').footable();
        });
    </script>
</asp:Content>
