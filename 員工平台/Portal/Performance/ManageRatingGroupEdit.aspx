<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageRatingGroupEdit.aspx.cs" Inherits="Performance.ManageRatingGroupEdit" %>

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
                                <label class="col-sm-2 col-form-label">名稱</label>
                                <div class="col-sm-10">
                                    <telerik:RadTextBox ID="txtName" runat="server" EmptyMessage="甲、乙、丙" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                    <asp:RequiredFieldValidator ID="rfvName" ForeColor="Red" runat="server" ControlToValidate="txtName" ErrorMessage="名稱為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">評等人數上限(%)</label>
                                <div class="col-sm-10">
                                    <telerik:RadNumericTextBox ID="txtNumPerMax" NumberFormat-DecimalDigits="0" MaxLength="3" MinValue="0" MaxValue="100" runat="server" Width="100%" ValidationGroup="Main"   CssClass="form-control" />
                                    <asp:RequiredFieldValidator ID="rfvNumPerMax" ForeColor="Red" runat="server" ControlToValidate="txtNumPerMax" ErrorMessage="評等人數上限(%)為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">評等人數下限(%)</label>
                                <div class="col-sm-10">
                                    <telerik:RadNumericTextBox ID="txtNumPerMin" NumberFormat-DecimalDigits="0" MaxLength="3" MinValue="0" MaxValue="100" runat="server" Width="100%" ValidationGroup="Main"  CssClass="form-control" />
                                    <asp:RequiredFieldValidator ID="rfvNumPerMin" ForeColor="Red" runat="server" ControlToValidate="txtNumPerMin" ErrorMessage="評等人數下限(%)為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                </div>
                            </div>
                           <div class="form-group row">
                                <label class="col-sm-2 col-form-label">評等人數初始(%)</label>
                                <div class="col-sm-10">
                                    <telerik:RadNumericTextBox ID="txtNumPer" NumberFormat-DecimalDigits="0" MaxLength="3" MinValue="0" MaxValue="100" runat="server" Width="100%" ValidationGroup="Main"  CssClass="form-control" />
                                    <asp:RequiredFieldValidator ID="rfvNumPer" ForeColor="Red" runat="server" ControlToValidate="txtNumPer" ErrorMessage="評等人數初始(%)為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                </div>
                            </div>                           
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">排序</label>
                                <div class="col-sm-10">
                                    <telerik:RadNumericTextBox ID="txtSort" NumberFormat-DecimalDigits="0" MaxLength="3" Value="9" CssClass="form-control" MinValue="0" MaxValue="999" runat="server" Width="80"  ValidationGroup="Main" />
                                    <asp:RequiredFieldValidator ID="rfvSort" ForeColor="Red" runat="server" ControlToValidate="txtSort" ErrorMessage="排序為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
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
