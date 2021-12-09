<%@ Page Title="" Language="C#" MasterPageFile="~/Main_PR.Master" AutoEventWireup="true" CodeBehind="MessageReturn.aspx.cs" Inherits="Portal.MessageReturn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="social-feed-box">
        <div class="social-avatar">
            <div class="media-body">
                <telerik:RadLabel ID="lblName" runat="server" CssClass="name_font" Text="王大明" />
                <telerik:RadLabel ID="lblDate" runat="server" CssClass="text-muted" Text="2021/11/24" />
                &ensp;-&ensp;
                <telerik:RadLabel ID="lblTime" runat="server" CssClass="text-muted" Text="15:37" />
            </div>
        </div>
        <div class="social-body">
            <p>
                <telerik:RadLabel ID="lblTitle" runat="server" Text="標題" />
            </p>
            <p>
                <telerik:RadLabel ID="lblType" runat="server" Text="回覆類型" />
            </p>
            <p>
                <telerik:RadLabel ID="lblC" runat="server" Text="訊息內容訊息內容" />
            </p>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12">
            <div class="ibox">
                <div class="ibox-content">
                    <div class="request_bg">
                        <div class="row">
                            <div class="form-group  col-lg-6">
                                <div class="row">
                                    <div class="col-lg-6">
                                        <h3>訊息回覆</h3>
                                    </div>
                                    <div class="col-lg-6 text-right">
                                        <telerik:RadButton ID="btnMessage" runat="server" CssClass="slect_cans btn btn-outline btn-md btn-w-m" Text="選擇罐頭訊息" /> 
                                        <!--點選選擇罐頭訊息後，右邊會跳出預設罐頭訊息，使用者點選罐頭訊息後能修改罐頭訊息-->
                                    </div>
                                </div>

                                <div class="form-group row form-inline">
                                    <label class="col-lg-3 col-form-label text-left">問題轉交或回覆</label>
                                    <div class="col-lg-9">
                                        <div class="row">
                                            <telerik:RadCheckBox ID="cbHR" runat="server" Skin="Bootstrap" Text="HR" />
                                            &ensp;
                                                <telerik:RadCheckBox ID="cbStytle" runat="server" Skin="Bootstrap" Text="系統商" />
                                            &ensp;
                                                <telerik:RadCheckBox ID="cbQ" runat="server" Skin="Bootstrap" Text="提問者" />
                                            &ensp;
                                                <telerik:RadCheckBox ID="cbBoth" runat="server" Skin="Bootstrap" Text="系統商及提問者" />
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-lg-2 col-form-label">選擇人員</label>
                                        <div class="col-lg-8">
                                            
                                        </div>
                                        <div class="col-lg-2 text-right">
                                            <telerik:RadButton ID="RadButton2" runat="server" CssClass="slect_cans btn btn-outline btn-md btn-w-m" Text="編輯" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-lg-12">
                                        <telerik:RadTextBox ID="txtContent" runat="server" EmptyMessage="請填寫您想回報的內容..."
                                            TextMode="MultiLine" Width="100%" Skin="Bootstrap" Rows="3">
                                        </telerik:RadTextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="row float-right ">
                                    <div class="col-lg-12 m-b-md">
                                        <telerik:RadButton ID="btnMessage2" runat="server" CssClass="slect_cans btn btn-outline btn-md btn-w-m" Text="預設訊息設定" /> 
                                    </div>
                                </div>
                                <div class="ibox">
                                    <div class="ibox-content">
                                        <div>
                                            <div class="product-name">
                                                <telerik:RadLabel ID="lbl22" runat="server"  Text="您好，我們已經收到您的訊息，我們將會盡快回覆給您！" />
                                            </div>
                                            <div class="small m-t-xs">
                                                <telerik:RadLabel ID="lbl23" runat="server"  Text="您好，我們已經收到您的訊息，我們將會盡快回覆給您！" />
                                            </div>
                                        </div>
                                        <hr>
                                        <div>
                                            <div class="product-name">
                                                <telerik:RadLabel ID="lbl24" runat="server"  Text="您好，我們已經收到您的訊息，我們將會盡快回覆給您！" />
                                           </div>
                                            <div class="small m-t-xs">
                                                <telerik:RadLabel ID="lbl25" runat="server"  Text="您好，我們已經收到您的訊息，我們將會盡快回覆給您！" />
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12">
                                <telerik:RadButton ID="btnDraft" runat="server" Text="儲存草稿" CssClass="btn btn-outline btn-primary btn-md" />
                                <telerik:RadButton ID="btnAdd" runat="server" Text="送出" CssClass="btn btn-primary btn-md" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
