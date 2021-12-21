<%@ Page Title="" Language="C#" MasterPageFile="~/Main_PR.Master" AutoEventWireup="true" CodeBehind="ProblemReturnView.aspx.cs" Inherits="Portal.ProblemReturnView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="social-feed-box">
        <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
            <div class="social-avatar">
                <div class="media-body">

                    <telerik:RadLabel ID="lblName" runat="server" CssClass="name_font" Text="" />
                    <%--<label>日期:</label>--%>
                    <telerik:RadLabel ID="lblDate" runat="server" CssClass="text-muted" Text="" />
                    -
                <telerik:RadLabel ID="lblTime" runat="server" CssClass="text-muted" Text="" />
                </div>
            </div>
            <div class="social-body">
                <p>
                    <%--<label>標題 :</label>--%>
                    <telerik:RadLabel ID="lblTitle" runat="server" Text="" />
                </p>
                <p>
                    <%--<label>回覆類型 :</label>--%>
                    <telerik:RadLabel ID="lblQuestionCategory" runat="server" Text="" />
                </p>
                <p>
                    <%--<label>內容 :</label>--%>
                    <telerik:RadLabel ID="lblContent" runat="server" Text="" />
                </p>
                <!--<div class="btn-group">
                 <button class="btn btn-white btn-xs"><i class="fa fa-comments"></i> Comment</button>
           </div>-->
            </div>
            <div class="social-footer">
                <telerik:RadListView ID="QuestionReplyData" runat="server" ItemPlaceholderID="Container" OnItemCommand="lvMain_ItemCommand" OnNeedDataSource="lvMain_NeedDataSource">
                    <LayoutTemplate>
                        <div id="Container" runat="server">
                            <telerik:RadLabel ID="lblName2" runat="server" CssClass="name_font" Text="" />
                            <telerik:RadLabel ID="lblDate2" runat="server" CssClass="text-muted" Text="" />
                            &ensp;-&ensp;
                        <telerik:RadLabel ID="lblTime2" runat="server" CssClass="text-muted" Text="" />
                        </div>
                        <div class="social-comment">
                            <div class="media-body">
                                <span></span>
                            </div>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div class="social-comment">
                            <div class="media-body">
                                <telerik:RadLabel ID="lblName2" runat="server" CssClass="name_font" Text='<%# Eval("Name") %>' />
                                <telerik:RadLabel ID="lblDate2" runat="server" CssClass="text-muted" Text='<%# Eval("InsertDate","{0:yyyy-MM-dd}") %>' />
                                -
                            <telerik:RadLabel ID="lblTime2" runat="server" CssClass="text-muted" Text='<%# Eval("InsertDate","{0:HH:ss}") %>' />

                                <p>
                                    <telerik:RadLabel ID="lblC2" runat="server" Text='<%# Eval("Content") %>' />
                                </p>

                                <div class="row message_line">
                                    <div class="col-lg-12">
                                        <button type="button" class="btn btn-white btn-w-m m-b-xs" data-toggle="collapse" aria-controls='<%# Eval("Code") %>' data-target='#rep<%# Eval("Code") %>'>回覆</button>
                                        <div id='rep<%# Eval("Code") %>' class="collapse">
                                            <div class="form-group">

                                                <telerik:RadTextBox runat="server" EmptyMessage="請填寫您想回覆的內容..."
                                                    TextMode="MultiLine" Width="100%" Skin="Bootstrap" Rows="3">
                                                </telerik:RadTextBox>

                                                <telerik:RadButton class="btnadd" runat="server" Text="送出" CssClass="btn btn-primary btn-md m-t-md" CommandName="Reply" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </telerik:RadListView>

                <div class="row col-lg-12 ">

                    <div class="request_box form-inline">
                        <span class="ask_font">這個回覆對您有幫助嗎？</span>
                        <button type="button" class="btn btn-white btn-w-m m-b-xs">有幫助</button>
                        <button type="button" class="btn btn-white btn-w-m m-b-xs" data-toggle="collapse" data-target="#demo">沒有</button>
                    </div>

                </div>
                <div id="demo" class="collapse">
                    <div class="form-group">

                        <telerik:RadTextBox ID="txtContent" runat="server" EmptyMessage="請填寫您想回報的內容..."
                            TextMode="MultiLine" Width="100%" Skin="Bootstrap" Rows="3">
                        </telerik:RadTextBox>
                        <telerik:RadButton ID="btnAdd" runat="server" Text="送出" CssClass="btn btn-primary btn-md m-t-md" OnClick="btnAdd_Click" />
                        <label runat="server" id="lblAddStatus" style="color: red;"></label>
                    </div>
                    <div class="form-group">
                    </div>
                </div>

            </div>
            <div class="ibox-content">
                <telerik:RadButton ID="btnPage" runat="server" Text="上一頁" CssClass="btn btn-primary btn-md btn-outline" OnClick="btnPage_Click">
                    <Icon PrimaryIconCssClass="rbPrevious" />
                </telerik:RadButton>
            </div>
        </telerik:RadAjaxPanel>
    </div>
    <asp:Label ID="lblUserCode" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblEmpID" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCompanyId" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblEmpName" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblRoleKey" runat="server" Visible="False"></asp:Label>
</asp:Content>
