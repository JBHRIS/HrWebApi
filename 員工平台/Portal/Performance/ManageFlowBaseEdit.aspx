<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageFlowBaseEdit.aspx.cs" Inherits="Performance.ManageFlowBaseEdit" %>

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
                            <h3>基本資料</h3>
                            <div style="border: 1px solid #dee2e6; padding: 1.5em; margin: 1.5em;">
                                <div class="form-row">
                                    <div class="form-group col-md-6">
                                        <label>工號</label>
                                        <telerik:RadTextBox ID="txtEmpId" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="rfvName" ForeColor="Red" runat="server" ControlToValidate="txtEmpId" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>姓名</label>
                                        <telerik:RadTextBox ID="txtEmpName" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ControlToValidate="txtEmpName" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-group col-md-6">
                                        <label>部門</label>
                                        <telerik:RadDropDownList ID="ddlDept" runat="server" Width="100%" AutoPostBack="false" ValidationGroup="Main" Skin="Bootstrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ControlToValidate="ddlDept" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>員別</label>
                                        <telerik:RadDropDownList ID="ddlEmpCategory" Width="100%" runat="server" AutoPostBack="false" ValidationGroup="Main" Skin="Bootstrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ControlToValidate="ddlEmpCategory" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-group col-md-6">
                                        <label>職稱</label>
                                        <telerik:RadTextBox ID="txtJobName" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ControlToValidate="txtJobName" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>職等</label>
                                        <telerik:RadTextBox ID="txtJoblName" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server" ControlToValidate="txtJoblName" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="form-row">
                                    <div class="form-group col-md-6">
                                        <label>到職日</label>
                                        <telerik:RadDatePicker RenderMode="Lightweight" ID="txtDateIn" Width="100%" runat="server" Skin="Bootstrap" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ForeColor="Red" runat="server" ControlToValidate="txtDateIn" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>在職比(月季)</label>
                                        <telerik:RadNumericTextBox ID="txtInWorkSpecific" NumberFormat-DecimalDigits="2" MaxLength="4" MinValue="0" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ForeColor="Red" runat="server" ControlToValidate="txtInWorkSpecific" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <h3>績效</h3>
                            <div style="border: 1px solid #dee2e6; padding: 1.5em; margin: 1.5em;">
                                <div class="form-row">
                                    <div class="form-group col-md-2">
                                        <label>工作效績</label>
                                        <telerik:RadNumericTextBox ID="txtWorkPerformance" NumberFormat-DecimalDigits="0" MaxLength="2" MinValue="0" MaxValue="99" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" runat="server" ControlToValidate="txtWorkPerformance" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label>工作態度</label>
                                        <telerik:RadNumericTextBox ID="txtMannerEsteem" NumberFormat-DecimalDigits="0" MaxLength="2" MinValue="0" MaxValue="99" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ForeColor="Red" runat="server" ControlToValidate="txtMannerEsteem" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label>能力評價</label>
                                        <telerik:RadNumericTextBox ID="txtAbilityEsteem" NumberFormat-DecimalDigits="0" MaxLength="2" MinValue="0" MaxValue="99" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ForeColor="Red" runat="server" ControlToValidate="txtAbilityEsteem" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label>激　　勵</label>
                                        <telerik:RadNumericTextBox ID="txtEncourage" NumberFormat-DecimalDigits="0" MaxLength="2" MinValue="0" MaxValue="99" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ForeColor="Red" runat="server" ControlToValidate="txtEncourage" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label>評核總分(月季)｜年度總分(年考)</label>
                                        <telerik:RadNumericTextBox ID="txtTotalIntegrate" NumberFormat-DecimalDigits="0" MinValue="0" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ForeColor="Red" runat="server" ControlToValidate="txtTotalIntegrate" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-group col-md-6">
                                        <label>評等(月季)｜(年考)</label>
                                        <telerik:RadDropDownList ID="ddlRating" runat="server" Width="100%" AutoPostBack="false" ValidationGroup="Main" Skin="Bootstrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ForeColor="Red" runat="server" ControlToValidate="ddlRating" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>考績平均(用料)｜年度平均(年考)</label>
                                        <telerik:RadNumericTextBox ID="txtAvgIntegrate" NumberFormat-DecimalDigits="0" MinValue="0" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ForeColor="Red" runat="server" ControlToValidate="txtAvgIntegrate" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <h3>功過</h3>
                            <div style="border: 1px solid #dee2e6; padding: 1.5em; margin: 1.5em;">
                                <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label>大功</label>
                                        <telerik:RadNumericTextBox ID="txtG01" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ForeColor="Red" runat="server" ControlToValidate="txtG01" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>小功</label>
                                        <telerik:RadNumericTextBox ID="txtG02" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" ForeColor="Red" runat="server" ControlToValidate="txtG02" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>嘉獎</label>
                                        <telerik:RadNumericTextBox ID="txtG03" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" ForeColor="Red" runat="server" ControlToValidate="txtG03" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label>大過</label>
                                        <telerik:RadNumericTextBox ID="txtF01" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" ForeColor="Red" runat="server" ControlToValidate="txtF01" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>小過</label>
                                        <telerik:RadNumericTextBox ID="txtF02" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" ForeColor="Red" runat="server" ControlToValidate="txtF02" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>申誡</label>
                                        <telerik:RadNumericTextBox ID="txtF03" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" ForeColor="Red" runat="server" ControlToValidate="txtF03" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-group col-md-6">
                                        <label>獎懲加扣</label>
                                        <telerik:RadNumericTextBox ID="txtSumAward" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" ForeColor="Red" runat="server" ControlToValidate="txtSumAward" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>

                                </div>
                            </div>

                            <h3>獎金</h3>
                            <div style="border: 1px solid #dee2e6; padding: 1.5em; margin: 1.5em;">
                                <div class="form-row">
                                    <div class="form-group col-md-6">
                                        <label>分配獎金</label>
                                        <telerik:RadNumericTextBox ID="txtBonusTotal" NumberFormat-DecimalDigits="0" MinValue="0" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ForeColor="Red" runat="server" ControlToValidate="txtBonusTotal" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>獎金基數</label>
                                        <telerik:RadNumericTextBox ID="txtBonusCardinal" NumberFormat-DecimalDigits="0" MinValue="0" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ForeColor="Red" runat="server" ControlToValidate="txtBonusCardinal" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-group col-md-6">
                                        <label>可扣最低</label>
                                        <telerik:RadNumericTextBox ID="txtBonusDeduct" NumberFormat-DecimalDigits="0" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ForeColor="Red" runat="server" ControlToValidate="txtBonusDeduct" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>可扣最高</label>
                                        <telerik:RadNumericTextBox ID="txtBonusMax" NumberFormat-DecimalDigits="0" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ForeColor="Red" runat="server" ControlToValidate="txtBonusMax" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-group col-md-6">
                                        <label>考績加減</label>
                                        <telerik:RadNumericTextBox ID="txtBonusAdjust" NumberFormat-DecimalDigits="0" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ForeColor="Red" runat="server" ControlToValidate="txtBonusAdjust" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>總分配獎金</label>
                                        <telerik:RadNumericTextBox ID="txtBonusReal" NumberFormat-DecimalDigits="0" MinValue="0" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ForeColor="Red" runat="server" ControlToValidate="txtBonusReal" ErrorMessage="為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <h3>特殊設定</h3>
                            <div style="border: 1px solid #dee2e6; padding: 1.5em; margin: 1.5em;">
                                <div class="form-row">
                                    <div class="form-group  col-md-12">
                                        <label>例外項目</label>
                                        <telerik:RadCheckBox ID="cbExceptionBonusAll" runat="server" Text="獎金例外(完全不受限制)" AutoPostBack="false" Skin="Bootstrap" />
                                        <telerik:RadCheckBox ID="cbExceptionBonus" runat="server" Text="獎金例外(不受評等範圍限制)" AutoPostBack="false" Skin="Bootstrap" />
                                        <telerik:RadCheckBox ID="cbExceptionNote" runat="server" Text="備註例外" AutoPostBack="false" Skin="Bootstrap" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>備註</label>
                                <telerik:RadTextBox ID="txtNote" runat="server" TextMode="MultiLine" Width="100%" CssClass="form-control" />
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label>修改者</label>
                                    <telerik:RadLabel ID="lblUpdateMan" runat="server" />
                                </div>
                                <div class="form-group col-md-6">
                                    <label>修改日期</label>
                                    <telerik:RadLabel ID="lblUpdateDate" runat="server" />
                                </div>
                            </div>
                            <telerik:RadButton ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click" ValidationGroup="Main" CssClass="btn btn-primary" />
                            <telerik:RadButton ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" CssClass="btn btn-w-m btn-warning" />
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

