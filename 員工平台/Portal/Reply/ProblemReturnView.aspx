<%@ Page Title="" Language="C#" MasterPageFile="~/Main_PR.Master" AutoEventWireup="true" CodeBehind="ProblemReturnView.aspx.cs" Inherits="Portal.ProblemReturnView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="social-feed-box">
        <div class="social-avatar">
            <div class="media-body">
               <label>姓名:</label>
                <telerik:RadLabel ID="lblName" runat="server" CssClass="name_font" Text="" />
                <label>日期:</label>
                <telerik:RadLabel ID="lblDate" runat="server" CssClass="text-muted" Text="" />
                &ensp;-&ensp;
                <telerik:RadLabel ID="lblTime" runat="server" CssClass="text-muted" Text="" />
            </div>
        </div>
        <div class="social-body">
            <p>
                <label>標題 :</label>
                <telerik:RadLabel ID="lblTitle" runat="server" Text="" />
            </p>
            <p>
                <label>回覆類型 :</label>
                <telerik:RadLabel ID="lblQuestionCategory" runat="server" Text="" />
            </p>
            <p>
                <label>內容 :</label>
                <telerik:RadLabel ID="lblContent" runat="server" Text="" />
            </p>
        </div>
        <div class="social-footer">
            <telerik:RadListView ID="QuestionReplyData" runat="server" ItemPlaceholderID="Container" >
                <LayoutTemplate>
                <div id="Container" runat="server">
                        <telerik:RadLabel ID="lblName2" runat="server" CssClass="name_font" Text="" />
                        <telerik:RadLabel ID="lblDate2" runat="server" CssClass="text-muted" Text="" />
                        &ensp;-&ensp;
                <telerik:RadLabel ID="lblTime2" runat="server" CssClass="text-muted" Text="" />
                    </div>
                    <div class="social-comment">
                        <div class="media-body">
                            <p>
                               
                            </p>
                        </div>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div>
                        <telerik:RadLabel ID="lblName2" runat="server" CssClass="name_font" Text='<%# Eval("Name") %>' />
                        <telerik:RadLabel ID="lblDate2" runat="server" CssClass="text-muted" Text='<%# Eval("InsertDate","{0:yyyy-MM-dd}") %>' />
                        &ensp;-&ensp;
                <telerik:RadLabel ID="lblTime2" runat="server" CssClass="text-muted" Text='<%# Eval("InsertDate","{0:HH:ss}") %>' />
                    </div>
                    <div class="social-comment">
                        <div class="media-body">
                            <p>
                                <telerik:RadLabel ID="lblC2" runat="server" Text=<%# Eval("Content") %> />
                            </p>
                        </div>
                    </div>
                </ItemTemplate>
            </telerik:RadListView>

            <div class="row col-lg-12 ">
                <div class="request_box form-inline">
                    <span class="ask_font">這個回覆對你有幫助嗎？</span>
                    <telerik:RadButton ID="btn" runat="server" CssClass="btn btn-outline btn-default btn-md btn-w-m" Text="有幫助" />
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
                <telerik:RadButton ID="btnAdd" runat="server" Text="送出" CssClass="btn btn-primary btn-md"  />
            </div>



        </div>

    </div>
    <asp:Label ID="lblUserCode" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblEmpID" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCompanyId" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblEmpName" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblRoleKey" runat="server" Visible="False"></asp:Label>
</asp:Content>
