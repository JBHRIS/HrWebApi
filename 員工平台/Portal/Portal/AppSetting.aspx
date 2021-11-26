<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AppSetting.aspx.cs" Inherits="Portal.AppSetting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div  class="wrapper wrapper-content animated fadeIn">



        <!-- 不應該客戶設定 -->

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






                        <telerik:RadAjaxPanel ID="plSearch" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">主頁頁面</label>
                                <div class="col-sm-10 row">
                                     <div><label> <input type="radio" value="option1" id="optionsRadios1" name="optionsRadios">開</label></div>
                                     <div><label> <input type="radio" checked=""  value="option2" id="optionsRadios2" name="optionsRadios"></label>關</div>
                                </div>
                               
                            </div>
                              <div class="hr-line-dashed"></div>
                            <div class="form-group  row">
                                 <label class="col-sm-2 col-form-label">主頁網址</label>
                                <div class="col-sm-10 row">
                                     <telerik:RadTextBox ID="txt_Home_URL" runat="server" EmptyMessage="網站URL" class="form-control" Width="100%" />
                                </div>
                                 </div>

                            <div class="hr-line-dashed"></div>
                            <div class="form-group  row">
                                <label class="col-sm-2 col-form-label">打卡頁面</label>
                                <div class="col-sm-10 row">
                                   <div><label> <input type="radio" checked="" value="option1" id="optionsRadios3" name="optionsRadios1">開</label></div>
                                     <div><label> <input type="radio" value="option2" id="optionsRadios4" name="optionsRadios1"></label>關</div>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group  row">
                                <label class="col-sm-2 col-form-label">簽到頁面</label>
                                <div class="col-sm-10 row">
                                    <div><label> <input type="radio"  value="option1" id="optionsRadios5" name="optionsRadios2">開</label></div>
                                     <div><label> <input type="radio" checked="" value="option2" id="optionsRadios6" name="optionsRadios2"></label>關</div>
                                </div>
                            </div>

                            <div class="hr-line-dashed"></div>
                            <div class="form-group  row">
                                <label class="col-sm-2 col-form-label">訊息頁面</label>
                                <div class="col-sm-10 row">
                                    <div><label> <input type="radio" checked="" value="option1" id="optionsRadios7" name="optionsRadios3">開</label></div>
                                     <div><label> <input type="radio" value="option2" id="optionsRadios8" name="optionsRadios3"></label>關</div>
                                </div>
                            </div>

                            <div class="hr-line-dashed"></div>
                            <div class="form-group row">
                                <div class="col-sm-2 col-sm-offset-2">
                                    <telerik:RadButton ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click" CssClass="btn btn-primary btn-sm" />
                                </div>
                                <div>
                                    <telerik:RadLabel ID="lblMsg" runat="server" />
                                </div>
                            </div>
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
