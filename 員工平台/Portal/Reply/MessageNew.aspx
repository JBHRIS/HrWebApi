<%@ Page Title="" Language="C#" MasterPageFile="~/Main_PR.Master" AutoEventWireup="true" CodeBehind="MessageNew.aspx.cs" Inherits="Portal.MessageNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ibox">
        <div class="ibox-content">
            <div class="row  form-inline">
                <div class="col-lg-3">
                    <h2>建立預設訊息</h2>
                </div>
                <div class="col-lg-3 text-right">
                    <span class="slect_cans"><a>選擇罐頭訊息</a></span>
                    <!--點選選擇罐頭訊息後，右邊會跳出預設罐頭訊息，使用者點選罐頭訊息後能修改罐頭訊息-->
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group row">
                        <label class="col-lg-2 col-form-label">標題 <small class="text-navy">(0/30)</small></label>
                        <div class="col-lg-10">
                            <telerik:RadTextBox ID="txtTitle" runat="server" EmptyMessage="請輸入標題..." Skin="Bootstrap" Width="100%"/>
                        </div>

                    </div>
                    <div class="form-group row">
                        <label class="col-lg-2 col-form-label">內容 <small class="text-navy">(0/80)</small></label>
                        <div class="col-lg-10">
                            <telerik:RadTextBox ID="txtContent" runat="server" EmptyMessage="請填寫您想回報的內容..."
                                TextMode="MultiLine" Width="100%" Skin="Bootstrap" Rows="4">
                            </telerik:RadTextBox>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="ibox">
                        <div class="ibox-content">
                            <div>
                                <a href="#" class="product-name">您好，我們已經收到您的訊息，我們將會盡快回覆給您！</a>
                                <div class="small m-t-xs">
                                    您好，我們已經收到您的訊息，我們將會盡快回覆給您！
                                </div>
                            </div>
                            <hr>
                            <div>
                                <a href="#" class="product-name">您好，我們已經收到您的訊息，我們將會盡快回覆給您！</a>
                                <div class="small m-t-xs">
                                    您好，我們已經收到您的訊息，我們將會盡快回覆給您！
                                </div>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <telerik:RadButton ID="btnPage" runat="server" Text="上一頁" CssClass="btn btn-outline btn-primary btn-md" />
                     <telerik:RadButton ID="btnAdd" runat="server" Text="確認" CssClass="btn btn-primary btn-md" />
                    <!--<button class="btn btn-primary btn-outline" type="submit"><strong>上一頁</strong></button>
                    <button class="btn btn-primary btn-md" type="submit"><strong>確認</strong></button>-->
                </div>
            </div>
        </div>
    </div>
</asp:Content>
