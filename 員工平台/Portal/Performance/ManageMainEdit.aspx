<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageMainEdit.aspx.cs" Inherits="Performance.ManageMainEdit" %>

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
                                <label class="col-sm-2 col-form-label">考核類別</label>
                                <div class="col-sm-10">
                                    <telerik:RadDropDownList ID="ddlType" runat="server" AutoPostBack="true" Skin="Bootstrap" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" ValidationGroup="Main" />
                                    <asp:RequiredFieldValidator ID="rfvType" ForeColor="Red" runat="server" ControlToValidate="ddlType" ErrorMessage="考核類別為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">名稱</label>
                                <div class="col-sm-10">
                                    <telerik:RadTextBox ID="txtName" runat="server" EmptyMessage="前端下拉會顯示的名稱" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                    <asp:RequiredFieldValidator ID="rfvName" ForeColor="Red" runat="server" ControlToValidate="txtName" ErrorMessage="名稱為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">考核年月</label>
                                <div class="col-sm-2 ">
                                    <telerik:RadDropDownList ID="ddlYear" Width="100%" runat="server" AutoPostBack="false" Skin="Bootstrap"  />
                                </div>
                                <div class="col-sm-2 ">
                                    <telerik:RadDropDownList ID="ddlMonth" Width="100%" runat="server" AutoPostBack="false" Skin="Bootstrap" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">員工類別</label>
                                <div class="col-sm-10">
                                    <telerik:RadDropDownList ID="ddlEmpCategory" runat="server" AutoPostBack="true" Skin="Bootstrap" OnSelectedIndexChanged="ddlEmpCategory_SelectedIndexChanged" ValidationGroup="Main" />
                                    <asp:RequiredFieldValidator ID="rfvEmpCategory" ForeColor="Red" runat="server" ControlToValidate="ddlEmpCategory" ErrorMessage="員工類別為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">考核生失效日</label>
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
                                <label class="col-sm-2 col-form-label">產生基準日</label>
                                <div class="col-sm-10">
                                    <telerik:RadDatePicker RenderMode="Lightweight" runat="server" ID="txtDateBase" Skin="Bootstrap" ValidationGroup="Main" />
                                    <asp:RequiredFieldValidator ID="rfvDateBase" ForeColor="Red" runat="server" ControlToValidate="txtDateA" ErrorMessage="產生基準日為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">排序</label>
                                <div class="col-sm-10">
                                    <telerik:RadNumericTextBox ID="txtSort" NumberFormat-DecimalDigits="0" MaxLength="3" Value="9" CssClass="form-control" MinValue="0" MaxValue="999" runat="server" Width="80" ValidationGroup="Main" />
                                    <asp:RequiredFieldValidator ID="rfvSort" ForeColor="Red" runat="server" ControlToValidate="txtSort" ErrorMessage="排序為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">預設評等</label>
                                <div class="col-sm-10">
                                    <telerik:RadDropDownList ID="ddlRating" runat="server" Skin="Bootstrap" ValidationGroup="Main" />
                                    <asp:RequiredFieldValidator ID="rfvRating" ForeColor="Red" runat="server" ControlToValidate="ddlRating" ErrorMessage="預設評等為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">可視獎金層級</label>
                                <div class="col-sm-10">
                                    <telerik:RadDropDownList ID="ddlDeptTreeB" runat="server"  Skin="Bootstrap"  ValidationGroup="Main" />
                                    <asp:RequiredFieldValidator ID="rfvDeptTreeB" ForeColor="Red" runat="server" ControlToValidate="ddlDeptTreeB" ErrorMessage="可視獎金層級為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">結束層級</label>
                                <div class="col-sm-10">
                                    <telerik:RadDropDownList ID="ddlDeptTreeE" runat="server"   Skin="Bootstrap"  ValidationGroup="Main"/>
                                    <asp:RequiredFieldValidator ID="rfvDeptTreeE" ForeColor="Red" runat="server" ControlToValidate="ddlDeptTreeE" ErrorMessage="結束層級為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
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
