<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageFlowDeptEdit.aspx.cs" Inherits="Performance.ManageFlowDeptEdit" %>

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
                                <label class="col-sm-2 col-form-label">部門名稱</label>
                                <div class="col-sm-10">
                                    <telerik:RadTextBox ID="txtName" runat="server" EmptyMessage="" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                    <asp:RequiredFieldValidator ID="rfvName" ForeColor="Red" runat="server" ControlToValidate="txtName" ErrorMessage="部門名稱為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">上層部門</label>
                                <div class="col-sm-10">
                                    <telerik:RadDropDownList ID="ddlParent" runat="server" Skin="Bootstrap" ValidationGroup="Main"  Width="100%" />
                                    <asp:RequiredFieldValidator ID="rfvParent" ForeColor="Red" runat="server" ControlToValidate="ddlParent" ErrorMessage="上層部門為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">部門層級</label>
                                <label class="col-sm-1 col-form-label">目前</label>
                                <div class="col-sm-2">
                                     <telerik:RadNumericTextBox ID="txtDeptTree" NumberFormat-DecimalDigits="0" MaxLength="2" MinValue="0" MaxValue="99" runat="server" Width="100%"  CssClass="form-control" ValidationGroup="Main" />
                                    <asp:RequiredFieldValidator ID="rfvDeptTree" ForeColor="Red" runat="server" ControlToValidate="txtDeptTree" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                </div>
                                <label class="col-sm-1 col-form-label">可視</label>
                                <div class="col-sm-2">
                                     <telerik:RadNumericTextBox ID="txtDeptTreeB" NumberFormat-DecimalDigits="0" MaxLength="2" MinValue="0" MaxValue="99" runat="server" Width="100%"  CssClass="form-control" ValidationGroup="Main" />
                                    <asp:RequiredFieldValidator ID="rfvDeptTreeB" ForeColor="Red" runat="server" ControlToValidate="txtDeptTreeB" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                </div>
                                <label class="col-sm-1 col-form-label">結束</label>
                                <div class="col-sm-2">
                                     <telerik:RadNumericTextBox ID="txtDeptTreeE" NumberFormat-DecimalDigits="0" MaxLength="2" MinValue="0" MaxValue="99" runat="server" Width="100%"  CssClass="form-control" ValidationGroup="Main" />
                                    <asp:RequiredFieldValidator ID="rfvDeptTreeE" ForeColor="Red" runat="server" ControlToValidate="txtDeptTreeE" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">主管工號</label>
                                <div class="col-sm-10">
                                   <telerik:RadTextBox ID="txtManagerId" runat="server"  Width="100%"  CssClass="form-control" ValidationGroup="Main"/>
                                    <asp:RequiredFieldValidator ID="rfvManagerId" ForeColor="Red" runat="server" ControlToValidate="txtManagerId" ErrorMessage="主管工號為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">主管姓名</label>
                                <div class="col-sm-10">
                                    <telerik:RadTextBox ID="txtManagerName" runat="server"  Width="100%"  CssClass="form-control" ValidationGroup="Main"/>
                                    <asp:RequiredFieldValidator ID="rfvManagerName" ForeColor="Red" runat="server" ControlToValidate="txtManagerName" ErrorMessage="主管姓名必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">職稱</label>
                                <div class="col-sm-10">
                                    <telerik:RadTextBox ID="txtJobName" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main"/>
                                    <asp:RequiredFieldValidator ID="rfvJobName" ForeColor="Red" runat="server" ControlToValidate="txtJobName" ErrorMessage="職稱必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">職等</label>
                                <div class="col-sm-10">
                                    <telerik:RadTextBox ID="txtJoblName" runat="server" Width="100%" CssClass="form-control"  />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">信箱</label>
                                <div class="col-sm-10">
                                    <telerik:RadTextBox ID="txtMail" runat="server" Width="100%" CssClass="form-control" />
                                </div>
                            </div>                            
                            <telerik:RadButton ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click" ValidationGroup="Main" CssClass="btn btn-primary" />
                             <telerik:RadButton ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click"  CssClass="btn btn-w-m btn-warning" />
                            <telerik:RadLabel ID="lblMsg" runat="server"  CssClass="badge badge-danger"  />
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>

