<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AppURLSetting.aspx.cs" Inherits="Portal.AppURLSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-lg-12">
        <div class="ibox ">
            <div class="ibox-title">
                <h5>APP設定</h5>
                <div class="ibox-tools">
                    <a class="collapse-link">
                        <i class="fa fa-chevron-up"></i>
                    </a>
                </div>
            </div>



            <div class="ibox-content">



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
                            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">公司名稱</label>
                                    <div class="col-sm-10 col-lg-3 row">
                                        <telerik:RadComboBox runat="server" Skin="Bootstrap" AutoPostBack="true" OnSelectedIndexChanged="sel_Companies_SelectedIndexChanged"
                                            Placeholder="請選擇..."
                                            AutoClose="false"
                                            TagMode="Single"
                                            Width="100%"
                                            ID="sel_Companies"
                                            AllowCustomText="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains" LoadingMessage="載入中…" />
                                    </div>
                                </div>
                                <div class="hr-line-dashed"></div>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label"></label>
                                    <div class="col-sm-10 row">

                                        <telerik:RadButton ID="RadButton1" runat="server" Text="新增" OnClick="btn_Click" ValidationGroup="Main" CssClass="btn btn-primary" />
                                    </div>
                                </div>
                            </telerik:RadAjaxPanel>
                        </div>
                    </div>
                </div>


                
            </div>
            <div class="ibox-content">
                    <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">





                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">公司名稱</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox ID="txt_Name" runat="server" CssClass="form-control" Width="100%" Enabled="false" />
                            </div>

                        </div>

                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">publicKey</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox ID="txt_publicKey" runat="server" CssClass="form-control" Width="100%" />
                            </div>
                        </div>

                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">privateKey</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox ID="txt_privateKey" runat="server" CssClass="form-control" Width="100%" />
                            </div>
                        </div>

                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">網域 統一編號</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox ID="txt_Domain" runat="server" CssClass="form-control" Width="100%" />
                            </div>
                        </div>

                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">ServiceURL</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox ID="txt_ServiceURL" runat="server" CssClass="form-control" Width="100%" />
                            </div>
                        </div>
                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">APIURL</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox ID="txt_APIURL" runat="server" CssClass="form-control" Width="100%" />
                            </div>
                        </div>

                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">getAuthUrl</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox ID="txt_getAuthUrl" runat="server" CssClass="form-control" Width="100%" />
                            </div>
                        </div>


                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">取得TokenAPI</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox ID="txt_getTokenUrl" runat="server" CssClass="form-control" Width="100%" />
                            </div>
                        </div>

                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">取得考勤範圍座標API</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox ID="txt_getFencePointsUrl" runat="server" CssClass="form-control" Width="100%" />
                            </div>
                        </div>
                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label"></label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox ID="txt_getCardTypesUrl" runat="server" CssClass="form-control" Width="100%" />
                            </div>
                        </div>
                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">是否在考勤範圍內API</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox ID="txt_isInPolygonUrl" runat="server" CssClass="form-control" Width="100%" />
                            </div>
                        </div>
                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">saveSignTypeUrl</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox ID="txt_saveSignTypeUrl" runat="server" CssClass="form-control" Width="100%" />
                            </div>
                        </div>
                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">getEmpConfigurationALLUrl</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox ID="txt_getEmpConfigurationALLUrl" runat="server" CssClass="form-control" Width="100%" />
                            </div>
                        </div>
                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">checkAppSettingUrl</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox ID="txt_checkAppSettingUrl" runat="server" CssClass="form-control" Width="100%" />
                            </div>
                        </div>
                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">照片上傳API</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox ID="txt_asyncUploadImagesUrl" runat="server" CssClass="form-control" Width="100%" />
                            </div>
                        </div>
                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">savePunchCardUrl</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox ID="txt_savePunchCardUrl" runat="server" CssClass="form-control" Width="100%" />
                            </div>
                        </div>
                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">getAttEndDetailUrl</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox ID="txt_getAttEndDetailUrl" runat="server" CssClass="form-control" Width="100%" />
                            </div>
                        </div>
                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">取得刷卡資訊</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox ID="txt_getCardDetailUrl" runat="server" CssClass="form-control" Width="100%" />
                            </div>
                        </div>
                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">取得使用者資訊</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox ID="txt_getUserInfoUrl" runat="server" CssClass="form-control" Width="100%" />
                            </div>
                        </div>


                        <div class="hr-line-dashed"></div>
                        <div class="form-group row">
                            <div class="col-sm-2 col-sm-offset-2">
                                <telerik:RadButton ID="btnSave" runat="server" Text="儲存" CssClass="btn btn-primary btn-sm" />
                                <!-- OnClick="btnSave_Click" -->
                            </div>
                            <div>
                                <telerik:RadLabel ID="lblMsg" runat="server" />
                            </div>
                        </div>
                    </telerik:RadAjaxPanel>
                </div>
        </div>
    </div>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
