<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MainBaseImport.aspx.cs" Inherits="Performance.MainBaseImport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="ibox-title">
                        <h5>處理</h5>
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
                            <div class="form-group row">
                                <label class="col-sm-12 col-form-label">準備匯入名單</label>
                                <div class="col-sm-12 ">
                                    <telerik:RadWizard ID="wz" runat="server" Localization-Next="下一步" Localization-Previous="上一步" Localization-Finish="完成" Localization-Cancel="取消" DisplayNavigationBar="false" Skin="Bootstrap" 
                                        OnFinishButtonClick="wz_FinishButtonClick" OnNextButtonClick="wz_NextButtonClick" OnPreviousButtonClick="wz_PreviousButtonClick">
                                        <WizardSteps>
                                            <telerik:RadWizardStep ID="RadWizardStep1" runat="server" Title="選擇上傳檔案">
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">選擇上傳檔案</label>
                                                    <div class="col-sm-12">
                                                        <telerik:RadAsyncUpload ID="fu" runat="server" Localization-Select="選擇檔案..." Width="150px" />
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label"></label>
                                                    <div class="col-sm-12">
                                                        <asp:HyperLink ID="hlExcel" runat="server" NavigateUrl="~/Files/PerformanceBaseSample.xls">範例檔案下載</asp:HyperLink>
                                                    </div>
                                                </div>
                                            </telerik:RadWizardStep>
                                            <telerik:RadWizardStep ID="RadWizardStep2" runat="server" Title="選擇工作表">
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">選擇工作表</label>
                                                    <div class="col-sm-12">
                                                        <asp:DropDownList ID="ddlSheet" Skin="Bootstrap" runat="server" />
                                                    </div>
                                                </div>
                                            </telerik:RadWizardStep>
                                            <telerik:RadWizardStep ID="RadWizardStep3" runat="server" Title="選擇對應欄位">
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">選擇對應欄位</label>
                                                    <div class="col-sm-12">
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">目的欄位</label>
                                                    <div class="col-sm-10">
                                                        Excel來源欄位
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">工號</label>
                                                    <div class="col-sm-10">
                                                        <telerik:RadDropDownList ID="ddlEmpId" runat="server" Skin="Bootstrap" />
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">工作績效</label>
                                                    <div class="col-sm-10">
                                                        <telerik:RadDropDownList ID="ddlWorkPerformance" runat="server" Skin="Bootstrap" />
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">工作態度</label>
                                                    <div class="col-sm-10">
                                                        <telerik:RadDropDownList ID="ddlMannerEsteem" runat="server" Skin="Bootstrap" />
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">能力評價</label>
                                                    <div class="col-sm-10">
                                                        <telerik:RadDropDownList ID="ddlAbilityEsteem" runat="server" Skin="Bootstrap" />
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">激勵</label>
                                                    <div class="col-sm-10">
                                                        <telerik:RadDropDownList ID="ddlEncourage" runat="server" Skin="Bootstrap" />
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">評等</label>
                                                    <div class="col-sm-10">
                                                        <telerik:RadDropDownList ID="ddlRating" runat="server" Skin="Bootstrap" />
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">考績加減</label>
                                                    <div class="col-sm-10">
                                                        <telerik:RadDropDownList ID="ddlBonusAdjust" runat="server" Skin="Bootstrap" />
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">備註</label>
                                                    <div class="col-sm-10">
                                                        <telerik:RadDropDownList ID="ddlNote" runat="server" Skin="Bootstrap" />
                                                    </div>
                                                </div>
                                            </telerik:RadWizardStep>
                                            <telerik:RadWizardStep ID="RadWizardStep4" runat="server" Title="確認上傳">
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">確認上傳</label>
                                                    <div class="col-sm-10">
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">檔案</label>
                                                    <div class="col-sm-10">
                                                        <telerik:RadLabel ID="lblExcel" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">工作表</label>
                                                    <div class="col-sm-10">
                                                        <telerik:RadLabel ID="lblSheet" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">工號</label>
                                                    <div class="col-sm-10">
                                                        <telerik:RadLabel ID="lblEmpId" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">工作績效</label>
                                                    <div class="col-sm-10">
                                                        <telerik:RadLabel ID="lblWorkPerformance" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">工作態度</label>
                                                    <div class="col-sm-10">
                                                        <telerik:RadLabel ID="lblMannerEsteem" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">能力評價</label>
                                                    <div class="col-sm-10">
                                                        <telerik:RadLabel ID="lblAbilityEsteem" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">激勵</label>
                                                    <div class="col-sm-10">
                                                        <telerik:RadLabel ID="lblEncourage" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">評等</label>
                                                    <div class="col-sm-10">
                                                        <telerik:RadLabel ID="lblRating" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">考績加減</label>
                                                    <div class="col-sm-10">
                                                        <telerik:RadLabel ID="lblBonusAdjust" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">備註</label>
                                                    <div class="col-sm-10">
                                                        <telerik:RadLabel ID="lblNote" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">其它選項</label>
                                                    <div class="col-sm-10">
                                                        <telerik:RadCheckBox ID="cbNeglectEmpId" Skin="Bootstrap" runat="server" Text="忽略來源不存在的工號" AutoPostBack="false" Checked="true" />
                                                    </div>
                                                </div>
                                            </telerik:RadWizardStep>
                                        </WizardSteps>
                                    </telerik:RadWizard>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group row">
                                <div class="col-sm-1">
                                    <telerik:RadButton ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" CssClass="btn btn-w-m btn-warning" />
                                </div>
                                <div class="col-sm-1">
                                    <telerik:RadLabel ID="lblMsg" CssClass="badge badge-danger" runat="server" />
                                </div>
                            </div>
                            <telerik:RadLabel ID="lblFileName" runat="server" Visible="False" />
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
