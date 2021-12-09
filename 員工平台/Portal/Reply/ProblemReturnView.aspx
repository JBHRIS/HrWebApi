<%@ Page Title="" Language="C#" MasterPageFile="~/Main_PR.Master" AutoEventWireup="true" CodeBehind="ProblemReturnView.aspx.cs" Inherits="Portal.ProblemReturnView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="social-feed-box">
        <div class="social-avatar">
            <div class="media-body">
                <telerik:RadLabel ID="lblName" runat="server" CssClass="name_font" Text="王大明"  />
                <telerik:RadLabel ID="lblDate" runat="server" CssClass="text-muted" Text="2021/11/24"  />&ensp;-&ensp;
                <telerik:RadLabel ID="lblTime" runat="server" CssClass="text-muted" Text="15:37"  />
            </div>   
        </div>
        <div class="social-body">
            <p><telerik:RadLabel ID="lblTitle" runat="server"  Text="標題"  /></p>
            <p><telerik:RadLabel ID="lblType" runat="server"  Text="回覆類型"  /></p>
            <p><telerik:RadLabel ID="lblC" runat="server"  Text="訊息內容訊息內容"  /></p>
        </div>
        <div class="social-footer">
            <div>
                <telerik:RadLabel ID="lblName2" runat="server" CssClass="name_font" Text="王大明"  />
                <telerik:RadLabel ID="lblDate2" runat="server" CssClass="text-muted" Text="2021/11/24"  />&ensp;-&ensp;
                <telerik:RadLabel ID="lblTime2" runat="server" CssClass="text-muted" Text="15:37"  />
            </div>
            <div class="social-comment">
                <div class="media-body">
                    <p>
                        <telerik:RadLabel ID="lblC2" runat="server"  Text="訊息內容訊息內容"  />
                    </p>
                </div>
            </div>
            <div class="row col-lg-12 ">
                <div class="request_box form-inline">
                    <span class="ask_font">這個回覆對你有幫助嗎？</span>
                    <telerik:RadButton ID="btn" runat="server" CssClass="btn btn-outline btn-default btn-md btn-w-m" Text="有" />
                    <telerik:RadButton ID="RadButton1" runat="server" CssClass="btn btn-outline btn-default btn-md" Text="沒有" />
                   <!-- <button class="btn btn-outline btn-default btn-md  btn-w-m" type="submit"><strong>有</strong></button>
                    <button class="btn btn-outline btn-default btn-md btn-w-m" type="submit"><strong>沒有</strong></button>-->
                </div>
            </div>
            <div class="form-group">
                <label>請輸入你的回饋 ...</label>
                <telerik:RadTextBox ID="txtContent" runat="server" EmptyMessage="請填寫您想回報的內容..."
                    TextMode="MultiLine" Width="100%" Skin="Bootstrap" Rows="3">
                </telerik:RadTextBox>
            </div>
            <div class="form-group">
                <telerik:RadButton ID="btnAdd" runat="server" Text="送出" CssClass="btn btn-primary btn-md" />
            </div>

            

        </div>

    </div>
</asp:Content>
