<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageReportTypeEdit.aspx.cs" Inherits="Performance.ManageReportTypeEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox ">
                    <div class="ibox-title">
                        <h5>新增或修改內容</h5>
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
                            <telerik:RadLabel ID="lblAutoKey" runat="server" Visible="false" />
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">員工類別</label>
                                <div class="col-sm-10">
                                    <telerik:RadDropDownList ID="ddlEmpCategory" runat="server" AutoPostBack="false" Skin="Bootstrap" ValidationGroup="Main" />
                                    <asp:RequiredFieldValidator ID="rfvEmpCategory" ForeColor="Red" runat="server" ControlToValidate="ddlEmpCategory" ErrorMessage="代碼為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">代碼</label>
                                <div class="col-sm-10">
                                    <telerik:RadTextBox ID="txtCode" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                    <asp:RequiredFieldValidator ID="rfvCode" ForeColor="Red" runat="server" ControlToValidate="txtCode" ErrorMessage="代碼為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">名稱</label>
                                <div class="col-sm-10">
                                    <telerik:RadTextBox ID="txtName" runat="server" EmptyMessage="此名稱會影響表頭顯示" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                    <asp:RequiredFieldValidator ID="rfvName" ForeColor="Red" runat="server" ControlToValidate="txtName" ErrorMessage="名稱為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">生失效日</label>
                                <div class="col-sm-10 row">
                                    <div class="col-sm-2">
                                        <telerik:RadDatePicker RenderMode="Lightweight" runat="server" ID="txtDateA" Skin="Bootstrap" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="rfvDateA" ForeColor="Red" runat="server" ControlToValidate="txtDateA" ErrorMessage="生效日為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-sm-2">
                                        <telerik:RadDatePicker RenderMode="Lightweight" runat="server" ID="txtDateD" Skin="Bootstrap" DateInput-Label="　到" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="rfvDateD" ForeColor="Red" runat="server" ControlToValidate="txtDateD" ErrorMessage="失效日為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">可用職稱</label>
                                <div class="col-sm-10">
                                    <telerik:RadMultiSelect runat="server" Skin="Bootstrap"
                                        Placeholder="請選擇..."
                                        AutoClose="false"
                                        TagMode="Multiple"
                                        Width="100%"
                                        ID="ddlJob"
                                         Filter="Contains" />
                                    ※這裡的職稱是抓人事系統「即時」的資料。
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">可用部門</label>
                                <div class="col-sm-10">
                                    <telerik:RadMultiSelect runat="server" Skin="Bootstrap"
                                        Placeholder="請選擇..."
                                        AutoClose="false"
                                        TagMode="Multiple"
                                        Width="100%"
                                        ID="ddlDept"
                                          Filter="Contains"/>
                                    ※這裡的部門是抓人事系統「即時」的資料。
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">備註</label>
                                <div class="col-sm-10">
                                    <telerik:RadTextBox ID="txtNote" runat="server" EmptyMessage="備註" Height="100px" CssClass="form-control" TextMode="MultiLine" Width="100%" />
                                </div>
                            </div>
                            <telerik:RadButton ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click" ValidationGroup="Main" CssClass="btn btn-primary" />
                                 <telerik:RadButton ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click"  CssClass="btn btn-w-m btn-warning" />
                            <telerik:RadLabel ID="lblMsg" runat="server" CssClass="badge badge-danger" />
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
