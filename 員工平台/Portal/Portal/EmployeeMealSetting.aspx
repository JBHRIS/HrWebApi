<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeMealSetting.aspx.cs" Inherits="Portal.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnMealUpdate">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
                    <telerik:AjaxUpdatedControl ControlID="plMain2" />
                    <telerik:AjaxUpdatedControl ControlID="ResultText" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlEmp">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
                    <telerik:AjaxUpdatedControl ControlID="plMain2" />
                    <telerik:AjaxUpdatedControl ControlID="ResultText" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>

    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxPanel runat="server">
        <div class="wrapper wrapper-content animated fadeIn">
            <div class="row">
                <div class="col-lg-12">
                    <div class="ibox ">
                        <div class="ibox-title">
                            <h5>
                                <telerik:RadLabel runat="server" ID="lblMealSetting" Text="用餐設定"></telerik:RadLabel>
                            </h5>
                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                            </div>
                        </div>
                        <div class="ibox-content">
                            <div class="form-group row">
                                <div class="col-md-3">
                                    <telerik:RadAjaxPanel runat="server">
                                        <telerik:RadComboBox runat="server" Skin="Bootstrap" AutoPostBack="true" CssClass="select2_demo_1" Enabled="false"
                                            Placeholder="請選擇..."
                                            AutoClose="false"
                                            TagMode="Single"
                                            Width="100%"
                                            ID="ddlEmp"
                                            OnSelectedIndexChanged="ddlEmp_SelectedIndexChanged"
                                            AllowCustomText="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains" LoadingMessage="載入中…" />
                                    </telerik:RadAjaxPanel>
                                </div>
                            </div>
                            <div class="panel blank-panel">
                                <div class="panel-heading">
                                    <div class="panel-options">
                                        <ul class="nav nav-tabs">
                                            <li>
                                                <a class="nav-link active" href="#tabMealDay" data-toggle="tab">平日用餐</a>
                                            </li>
                                            <li>
                                                <a class="nav-link" href="#tabMealHoliday" data-toggle="tab">假日用餐</a>
                                            </li>
                                        </ul>
                                    </div>
                                </div>


                                <div class="panel-body">
                                    <div class="tab-content">
                                        <div class="tab-pane active" id="tabMealDay">
                                            <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                                                <div class="row">
                                                    <div class="col-1 col-form-label">餐別</div>
                                                    <div class="col-11">
                                                        <telerik:RadCheckBoxList ID="ckblMealDay" runat="server" Skin="Bootstrap" AutoPostBack="false" class="font-bold">
                                                            <DataBindings DataTextField="MealTypeName" DataValueField="GID" />
                                                        </telerik:RadCheckBoxList>
                                                        <%--<telerik:RadRadioButtonList ID="ckblMealDay" runat="server" Skin="Bootstrap" AutoPostBack="false" class="font-bold">
                                                         <DataBindings DataTextField="MealTypeName" DataValueField="GID"  />
                                                     </telerik:RadRadioButtonList>--%>
                                                    </div>
                                                </div>
                                            </telerik:RadAjaxPanel>
                                        </div>
                                        <div class="tab-pane" id="tabMealHoliday">
                                            <telerik:RadAjaxPanel ID="plMain2" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                                                <div class="row">
                                                    <div class="col-1 col-form-label">餐別</div>
                                                    <div class="col-11">
                                                        <telerik:RadRadioButtonList ID="ckblMealHoliday" runat="server" Skin="Bootstrap" AutoPostBack="false" class="font-bold">
                                                            <DataBindings DataTextField="MealTypeName" DataValueField="GID" />
                                                        </telerik:RadRadioButtonList>
                                                    </div>
                                                </div>
                                            </telerik:RadAjaxPanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="ibox-footer">
                            <div class="animated fadeInRight">
                                <telerik:RadAjaxPanel runat="server">
                                    <telerik:RadButton runat="server" ID="btnMealUpdate" OnClick="Update_Click" CssClass="btn-primary btn-sm" Text="更新" />
                                </telerik:RadAjaxPanel>
                                <asp:Label Skin="Bootstrap" runat="server" ID="ResultText" CssClass="label-danger" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </telerik:RadAjaxPanel>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="Templates/Inspinia/js/plugins/footable/footable.all.min.js"></script>
</asp:Content>
