<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageMainWizard.aspx.cs" Inherits="Performance.ManageMainWizard" %>

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
                            <telerik:RadWizard ID="wzMain" runat="server" OnActiveStepChanged="wzMain_ActiveStepChanged" OnNextButtonClick="wzMain_NextButtonClick"
                                Skin="Bootstrap" OnFinishButtonClick="wzMain_FinishButtonClick"
                                Localization-Next="下一步" Localization-Previous="上一步" Localization-Finish="完成" DisplayNavigationBar="false">
                                <WizardSteps>
                                    <telerik:RadWizardStep ID="s1" runat="server" Title="基本設定">
                                        <telerik:RadLabel ID="lblAutoKey" runat="server" Visible="false" />
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">考核類別</label>
                                            <div class="col-sm-10">
                                                <telerik:RadDropDownList ID="ddlType" runat="server" AutoPostBack="true" Skin="Bootstrap" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" />
                                                <asp:RequiredFieldValidator ID="rfvType" ForeColor="Red" runat="server" ControlToValidate="ddlType" ErrorMessage="考核類別為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">名稱</label>
                                            <div class="col-sm-10">
                                                <telerik:RadTextBox ID="txtName" runat="server" EmptyMessage="前端下拉會顯示的名稱" Width="100%" CssClass="form-control" />
                                                <asp:RequiredFieldValidator ID="rfvName" ForeColor="Red" runat="server" ControlToValidate="txtName" ErrorMessage="名稱為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">報表名稱</label>
                                            <div class="col-sm-10">
                                                <telerik:RadTextBox ID="txtReportName" runat="server" EmptyMessage="報表名稱" Width="100%" CssClass="form-control" />
                                                <asp:RequiredFieldValidator ID="rfvReportName" ForeColor="Red" runat="server" ControlToValidate="txtReportName" ErrorMessage="報表名稱為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">考核年月</label>
                                            <div class="col-sm-2 ">
                                                <telerik:RadDropDownList ID="ddlYear" Width="100%" runat="server" AutoPostBack="false" Skin="Bootstrap" />
                                            </div>
                                            <div class="col-sm-2 ">
                                                <telerik:RadDropDownList ID="ddlMonth" Width="100%" runat="server" AutoPostBack="false" Skin="Bootstrap" />
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">員工類別</label>
                                            <div class="col-sm-10">
                                                <telerik:RadDropDownList ID="ddlEmpCategory" runat="server" AutoPostBack="true" Skin="Bootstrap" OnSelectedIndexChanged="ddlEmpCategory_SelectedIndexChanged" />
                                                <asp:RequiredFieldValidator ID="rfvEmpCategory" ForeColor="Red" runat="server" ControlToValidate="ddlEmpCategory" ErrorMessage="員工類別為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">考核生失效日</label>
                                            <div class="col-sm-10 row">
                                                <div class="col-sm-2">
                                                    <telerik:RadDatePicker RenderMode="Lightweight" runat="server" ID="txtDateA" Skin="Bootstrap" />
                                                    <asp:RequiredFieldValidator ID="rfvDateA" ForeColor="Red" runat="server" ControlToValidate="txtDateA" ErrorMessage="生效日為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-2">
                                                    <telerik:RadDatePicker RenderMode="Lightweight" runat="server" ID="txtDateD" Skin="Bootstrap" DateInput-Label="　到" />
                                                    <asp:RequiredFieldValidator ID="rfvDateD" ForeColor="Red" runat="server" ControlToValidate="txtDateD" ErrorMessage="失效日為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">產生基準日</label>
                                            <div class="col-sm-10">
                                                <telerik:RadDatePicker RenderMode="Lightweight" runat="server" ID="txtDateBase" Skin="Bootstrap" />
                                                <asp:RequiredFieldValidator ID="rfvDateBase" ForeColor="Red" runat="server" ControlToValidate="txtDateA" ErrorMessage="產生基準日為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">排序</label>
                                            <div class="col-sm-10">
                                                <telerik:RadNumericTextBox ID="txtSort" NumberFormat-DecimalDigits="0" MaxLength="3" Value="9" CssClass="form-control" MinValue="0" MaxValue="999" runat="server" Width="80" />
                                                <asp:RequiredFieldValidator ID="rfvSort" ForeColor="Red" runat="server" ControlToValidate="txtSort" ErrorMessage="排序為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">預設評等</label>
                                            <div class="col-sm-10">
                                                <telerik:RadDropDownList ID="ddlRating" runat="server" Skin="Bootstrap" />
                                                <asp:RequiredFieldValidator ID="rfvRating" ForeColor="Red" runat="server" ControlToValidate="ddlRating" ErrorMessage="預設評等為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">可視獎金層級</label>
                                            <div class="col-sm-10">
                                                <telerik:RadDropDownList ID="ddlDeptTreeB" runat="server" Skin="Bootstrap" />
                                                <asp:RequiredFieldValidator ID="rfvDeptTreeB" ForeColor="Red" runat="server" ControlToValidate="ddlDeptTreeB" ErrorMessage="可視獎金層級為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">結束層級</label>
                                            <div class="col-sm-10">
                                                <telerik:RadDropDownList ID="ddlDeptTreeE" runat="server" Skin="Bootstrap" />
                                                <asp:RequiredFieldValidator ID="rfvDeptTreeE" ForeColor="Red" runat="server" ControlToValidate="ddlDeptTreeE" ErrorMessage="結束層級為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">備註</label>
                                            <div class="col-sm-10">
                                                <telerik:RadTextBox ID="txtNote" runat="server" EmptyMessage="備註" Height="100px" CssClass="form-control" TextMode="MultiLine" Width="100%" />
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">預設金額(基本)</label>
                                            <div class="col-sm-10">
                                                <telerik:RadNumericTextBox ID="txtBonusCardinal" NumberFormat-DecimalDigits="0" MaxLength="6" Value="0" CssClass="form-control" MinValue="0" MaxValue="999999" runat="server" Width="100" />
                                                <asp:RequiredFieldValidator ID="rfvBonusCardinal" ForeColor="Red" runat="server" ControlToValidate="txtBonusCardinal" ErrorMessage="預設金額為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">計算金額(限制)</label>
                                            <div class="col-sm-10">
                                                <telerik:RadNumericTextBox ID="txtBonusCardinalLimit" NumberFormat-DecimalDigits="0" MaxLength="6" Value="0" CssClass="form-control" MinValue="0" MaxValue="999999" runat="server" Width="100" />
                                                <asp:RequiredFieldValidator ID="rfvBonusCardinalLimit" ForeColor="Red" runat="server" ControlToValidate="txtBonusCardinalLimit" ErrorMessage="計算金額為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">例外項目</label>
                                            <div class="col-sm-10">
                                                <telerik:RadCheckBox ID="cbExceptionBonusAll" runat="server" Text="獎金例外(完全不受限制)" AutoPostBack="false" Skin="Bootstrap" />
                                                <telerik:RadCheckBox ID="cbExceptionBonus" runat="server" Text="獎金例外(不受評等範圍限制)" AutoPostBack="false" Skin="Bootstrap" />
                                                <telerik:RadCheckBox ID="cbExceptionNote" runat="server" Text="備註例外" AutoPostBack="false" Skin="Bootstrap" />
                                            </div>
                                        </div>
                                    </telerik:RadWizardStep>
                                    <telerik:RadWizardStep ID="s2" runat="server" Title="部門設定">
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">部門名稱</label>
                                            <div class="col-sm-2">
                                                獎金可視層級
                                            </div>
                                            <div class="col-sm-2">
                                                結束層級
                                            </div>
                                        </div>
                                        <telerik:RadListView ID="lvDept" runat="server" DataKeyNames="AutoKey,Code" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="lvDept_NeedDataSource" OnDataBound="lvDept_DataBound" OnItemCommand="lvDept_ItemCommand">
                                            <LayoutTemplate>
                                                <asp:PlaceHolder ID="Container" runat="server"></asp:PlaceHolder>
                                            </LayoutTemplate>
                                            <ItemTemplate>
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label"><%# Eval("Name") %></label>
                                                    <div class="col-sm-2">
                                                        <telerik:RadDropDownList ID="ddlDeptTreeB" Skin="Bootstrap" runat="server" />
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <telerik:RadDropDownList ID="ddlDeptTreeE" Skin="Bootstrap" runat="server" />
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                            <EmptyDataTemplate>
                                                目前並無任何資料
                                            </EmptyDataTemplate>
                                        </telerik:RadListView>
                                    </telerik:RadWizardStep>
                                    <telerik:RadWizardStep ID="s4" runat="server" Title="確認完成">
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">確認完成</label>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">部門考核數</label>
                                            <div class="col-sm-10">
                                                <telerik:RadLabel ID="lblDeptCount" runat="server" />
                                                <telerik:RadLabel ID="lblDeptAllCount" runat="server" Visible="false" />
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">員工考核人數</label>
                                            <div class="col-sm-10">
                                                <telerik:RadLabel ID="lblBaseCount" runat="server" />
                                                <telerik:RadLabel ID="lblFlowCount" runat="server" Visible="false" />
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">備註</label>
                                            <div class="col-sm-10">
                                                系統於最後產生時，會刪除沒有人的部門
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label"></label>
                                            <div class="col-sm-10">
                                                請確認是否產生名單
                                            </div>
                                        </div>
                                    </telerik:RadWizardStep>
                                </WizardSteps>
                            </telerik:RadWizard>
                            <telerik:RadLabel ID="lblMsg" Text="" runat="server" CssClass="badge badge-danger" />
                            <telerik:RadLabel ID="lblCode" runat="server" Visible="False" />
                            <telerik:RadLabel ID="lblYymm" runat="server" Visible="False" />
                            <telerik:RadLabel ID="lblUserCode" runat="server" Visible="False" />
                            <telerik:RadLabel ID="lblKey1" runat="server" Visible="False" />
                            <telerik:RadLabel ID="lblKey2" runat="server" Visible="False" />
                            <telerik:RadLabel ID="lblGuid" runat="server" Visible="False" />
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
