<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AppEmployeeBaseSetting.aspx.cs" Inherits="Portal.AppEmployeeBaseSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="wrapper wrapper-content animated fadeIn">

        <div class="col-lg-12">
            <div class="ibox ">

                <telerik:RadAjaxPanel ID="plSearch" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                    <div class="ibox-title">
                        <h5>查詢</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">

                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">姓名查詢</label>
                            <div class="col-sm-10 col-lg-4 row">
                                <telerik:RadTextBox ID="txt_Sreach_Name" runat="server" EmptyMessage="請輸入姓名" CssClass="form-control" Width="100%" />
                            </div>
                        </div>

                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">工號查詢</label>
                            <div class="col-sm-10 col-lg-4 row">
                                <telerik:RadTextBox ID="txt_Sreach_Nobr" runat="server" EmptyMessage="請輸入工號" CssClass="form-control" Width="100%" />
                            </div>
                        </div>

                        <div class="hr-line-dashed"></div>
                        <div class="form-group row">
                            <div class="col-sm-2 col-sm-offset-2">
                                <telerik:RadButton ID="btnSearch" runat="server" Text="查詢" CssClass="btn btn-primary btn-sm" />
                                <!-- OnClick="btnSearch_Click" -->
                            </div>
                            <div>
                                <telerik:RadLabel ID="lblMsg" runat="server" />
                            </div>
                        </div>
                    </div>
                </telerik:RadAjaxPanel>
            </div>
        </div>















        <div class="col-lg-12">

            <div class="ibox-content">



                <div class="ibox-content">
                    <h2>個人設定檔</h2>

                    <ul class="todo-list m-t">
                        <li>
                            <input type="checkbox" value="" name="" class="i-checks" checked />
                            <span class="m-l-xs">出勤查詢</span>
                            <span class="label">是否提供出勤查詢頁面 。</span>
                        </li>
                        <li>
                            <input type="checkbox" value="" name="" class="i-checks" checked />
                            <span class="m-l-xs">打卡頁面</span>
                            <span class="label">是否提供打卡頁面 。</span>
                        </li>
                        <li>
                            <input type="checkbox" value="" name="" class="i-checks" />
                            <span class="m-l-xs">調整時間</span>
                            <span class="label ">打卡是否允許調整時間 。</span>
                        </li>
                        <li>
                            <input type="checkbox" value="" name="" class="i-checks" />
                            <span class="m-l-xs">上傳照片</span>
                            <span class="label ">打卡是否需要上傳照片 。</span>
                        </li>
                        <li>
                            <input type="checkbox" value="" name="" class="i-checks" />
                            <span class="m-l-xs">電子圍離</span>
                            <span class="label ">是否需要驗證電子圍籬 。</span>
                        </li>
                        <li>
                            <input type="checkbox" value="" name="" class="i-checks" />
                            <span class="m-l-xs">個人因素</span>
                            <span class="label ">打卡是否需要填寫個人因素  。</span>
                        </li>
                        <li>
                            <input type="checkbox" value="" name="" class="i-checks" checked />
                            <span class="m-l-xs">顯示地圖</span>
                            <span class="label">是否顯示個人地圖   。</span>
                        </li>
                        <li>
                            <input type="checkbox" value="" name="" class="i-checks" />
                            <span class="m-l-xs">離線打卡 </span>
                            <span class="label">打卡是否接收離線打卡    。</span>
                        </li>
                        <li>
                            <input type="checkbox" value="" name="" class="i-checks" />
                            <span class="m-l-xs">QRCode </span>
                            <span class="label">是否提供掃描打卡的功能     。</span>
                        </li>
                    </ul>
                </div>

                <div class="hr-line-dashed"></div>
                <div class="form-group row">
                    <div class="col-sm-2 col-sm-offset-2">
                        <telerik:RadButton ID="RadButton1" runat="server" Text="新增" CssClass="btn btn-primary btn-sm" />
                        <!-- OnClick="btnSearch_Click" -->
                    </div>
                    <div>
                        <telerik:RadLabel ID="RadLabel1" runat="server" />
                    </div>
                </div>





            </div>



        </div>
    </div>







    <div>

        操作個人設定檔
        設定app檢查項目

        
       

    </div>

    <div>


    </div>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
