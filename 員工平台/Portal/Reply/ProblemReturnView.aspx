<%@ Page Title="" Language="C#" MasterPageFile="~/Main_PR.Master" AutoEventWireup="true" CodeBehind="ProblemReturnView.aspx.cs" Inherits="Portal.ProblemReturnView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="social-feed-box">
        <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
            <div class="social-avatar">
                <div class="media-body">
                    <%--   <label>提問者 :</label>--%>
                    <telerik:RadLabel ID="lblName" runat="server" CssClass="name_font" Text="" />
                    <%--  <label>日期 :</label>--%>
                    <telerik:RadLabel ID="lblDate" runat="server" CssClass="text-muted" Text="" />
                    -
                <telerik:RadLabel ID="lblTime" runat="server" CssClass="text-muted" Text="" />
                </div>
            </div>
            <div class="social-body">
                <p>
                    <%--  <label>標題 :</label>--%>
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

            </div>
            <div id="iboxContent" class="ibox">
                <div class="ibox-title">
                    <h5>附件列表</h5>
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
                    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                        <telerik:RadListView ID="DataUpload" runat="server" RenderMode="Lightweight" ItemPlaceholderID="Container" OnNeedDataSource="DataUpload_NeedDataSource"  OnItemCommand="DataUpload_ItemCommand">
                            <LayoutTemplate>
                                <table class="footable table table-stripped" data-page-size="10" data-filter="#filter">
                                    <thead>
                                        <tr>
                                            <th>檔名</th>
                                            <th data-hide="phone,tablet">大小</th>
                                            <th>動作</th>
                                        </tr>
                                    </thead>
                                    <tbody id="Container" runat="server">
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <td colspan="5">
                                                <ul class="pagination float-right"></ul>
                                            </td>
                                        </tr>
                                    </tfoot>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                  <tr class="gradeX">
                                                    <td><%#Eval("FileName") %></td>
                                                    <td><%#Eval("FileSize") %></td>
                                                    <td>
                                                        <asp:Button ID="btnDownload" runat="server" CommandArgument='<%#Eval("FileId") %>' Width="60%" OnClientClick='<%#"download(\""+Eval("FileId")+"\");" %>' CommandName="Download" Text="下載" CssClass="btn-white btn btn-xs" />
                                                    </td>
                                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                目前並無上傳任何檔案
                            </EmptyDataTemplate>
                        </telerik:RadListView>
                    </telerik:RadAjaxPanel>
                </div>
            </div>
            <button id="btnWtReply" type="button" runat="server" data-toggle="collapse" data-target="#demo" class="btn btn-white btn-w-m m-b-xs">我要回覆</button>

            <div class="social-footer">

                <telerik:RadListView ID="QuestionReplyData" runat="server" ItemPlaceholderID="Container" OnItemCommand="lvMain_ItemCommand" OnNeedDataSource="QuestionReplyData_NeedDataSource">

                    <LayoutTemplate>
                        <div id="Container" runat="server">
                            <telerik:RadLabel ID="lblName2" runat="server" CssClass="name_font" Text="" />
                            <telerik:RadLabel ID="lblDate2" runat="server" CssClass="text-muted" Text="" />
                            &ensp;&ensp;
                        <telerik:RadLabel ID="lblTime2" runat="server" CssClass="text-muted" Text="" />
                        </div>
                        <div class="social-comment">
                            <div class="media-body">
                                <span></span>
                            </div>
                        </div>

                    </LayoutTemplate>

                    <ItemTemplate>
                        <div class="social-comment message_line">
                            <div class="media-body">
                                <telerik:RadLabel ID="lblName2" runat="server" CssClass="name_font" Text='<%# Eval("Name") %>' />
                                <telerik:RadLabel ID="lblC2" runat="server" Text='<%# Eval("Content") %>' />
                                <br />

                                <button type="button" id="btnReply" class="btnReply btn btn-link fa comment_icon text-blue" data-toggle="collapse" aria-controls='<%# Eval("Code") %>' data-target='#rep<%# Eval("Code") %>'>回覆</button>
                                <telerik:RadLabel ID="lblDate2" runat="server" CssClass="text-muted" Text='<%# Eval("InsertDate","{0:yyyy-MM-dd}") %>' />

                                <telerik:RadLabel ID="lblTime2" runat="server" CssClass="text-muted" Text='<%# Eval("InsertDate","{0:HH:ss}") %>' />

                                <br />
                                <div class="social-comment">
                                    <%# Eval("DataView")  %>
                                </div>

                            </div>
                            <div id='rep<%# Eval("Code")%>' class="collapse">
                                <div class="form-group">

                                    <telerik:RadTextBox ID="txtReply" class="txtReply" runat="server" EmptyMessage="請填寫您想回覆的內容..."
                                        TextMode="MultiLine" Width="100%" Skin="Bootstrap" Rows="3">
                                    </telerik:RadTextBox>

                                    <telerik:RadButton ID="btnReplyAdd" class="btnadd" runat="server" Text="送出" CssClass="btn btn-primary btn-md m-t-md" CommandArgument='<%# Eval("Code") %>' CommandName="ReplyAdd" />
                                </div>
                            </div>
                        </div>

                    </ItemTemplate>

                </telerik:RadListView>


                <div id="Useful" runat="server" class="row col-lg-12">

                    <div class="request_box form-inline">
                        <span class="ask_font">這個回覆對您有幫助嗎？</span>
                        <telerik:RadButton ID="btnHelpful" runat="server" Text="有幫助" CssClass="btn btn-white btn-w-m m-b-xs" OnClick="btnHelpful_Click" />
                        <telerik:RadButton ID="btnHelpless" runat="server" Text="沒有" CssClass="btn btn-white btn-w-m m-b-xs" data-toggle="collapse" data-target="#demo" OnClick="btnHelpful_Click" />
                        <%-- <button id="btnHelpless" type="button" class="btn btn-white btn-w-m m-b-xs" runat="server" data-toggle="collapse" data-target="#demo">沒有</button>--%>
                        <div class="hr-line-dashed"></div>
                        <p id="pCompleteStatus" runat="server" style="display: none" class="text-success">
                            此筆回報單已經結案！<br>
                            如後續有相關問題，請重新建立回報單，感謝您的使用！
                        </p>
                    </div>

                </div>
                <div id="demo" class="collapse">
                    <div class="form-group">
                        <telerik:RadTextBox ID="txtContent" runat="server" EmptyMessage="請填寫您想回報的內容..."
                            TextMode="MultiLine" Width="100%" Skin="Bootstrap" Rows="3">
                        </telerik:RadTextBox>

                        <telerik:RadButton ID="btnDraft" runat="server" Text="儲存草稿" CssClass="btn btn-outline btn-primary btn-md" CommandName="Draft" OnClick="btnAdd_Click" />
                        <telerik:RadButton ID="btnAdd" runat="server" Text="送出" CssClass="btn btn-primary btn-primary btn-md" OnClick="btnAdd_Click" />

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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="Templates/Inspinia/js/plugins/footable/footable.all.min.js"></script>

    <script>
        function download(FileId) {

            //檔案下載網址
            var url = "Download.ashx?openExternalBrowser=1";

            //產生 form
            var form = document.createElement("form");

            form.method = "GET";
            form.action = url;

            //如果想要另開視窗可加上target
            //form.target = "_blank";

            //index為要下載的檔案編號，存入hidden跟表單一起送出
            var input = document.createElement("input");
            input.type = "hidden";
            input.name = "index";
            input.value = FileId;
            form.appendChild(input);

            //送出表單並移除 form
            var body = document.getElementsByTagName("body")[0];
            body.appendChild(form);
            form.submit();
            form.remove();
        };

    </script>
</asp:Content>
