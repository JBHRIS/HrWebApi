<%@ Page Title="" Language="C#" MasterPageFile="~/Main_PR.Master" AutoEventWireup="true" CodeBehind="ProblemReturnView.aspx.cs" Inherits="Portal.ProblemReturnView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManager ID="RadAjaxManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAdd">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="QuestionReplyData" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnHelpful">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadAjaxPanel3" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
      
    </telerik:RadAjaxManager>

    <div class="social-feed-box">

        <div class="social-avatar">
            <div class="float-left">
                <div class="navy-bg admin_circle">
                    <i class="fa fa-user"></i>
                </div>
            </div>
            <div class="media-body">
                <span>
                    <%--   <label>提問者 :</label>--%>
                    <telerik:RadLabel ID="lblName" runat="server" CssClass="name_font" Text="" />
                    <%--  <label>日期 :</label>--%>
                    <br>
                    <telerik:RadLabel ID="lblDate" runat="server" CssClass="text-muted" Text="" />
                    -
                    <telerik:RadLabel ID="lblTime" runat="server" CssClass="text-muted" Text="" />
                </span>
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
                    <telerik:RadAjaxPanel ID="RadAjaxPanel4" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                        <telerik:RadListView ID="DataUpload" runat="server" ItemPlaceholderID="Container" RenderMode="Lightweight" OnNeedDataSource="DataUpload_NeedDataSource">
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
                                    <td data-th="檔名"><%#Eval("FileName") %></td>
                                    <td data-th="大小"><%#Eval("FileSize") %></td>
                                    <td data-th="動作">
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
            <div class="form-group">
                <button id="btnWtReply" type="button" runat="server" data-toggle="collapse" data-target="#demo" class="btn btn-outline btn-primary btn-w-m m-b-xs">我要回覆</button>
            </div>

        </div>

        <div class="social-footer">
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                <telerik:RadListView ID="QuestionReplyData" runat="server" ItemPlaceholderID="Container" OnItemCommand="QuestionReplyData_ItemCommand"  OnNeedDataSource="QuestionReplyData_NeedDataSource">

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

                        <div class="social-comment message_line" id='div<%# Eval("Code")%>'>
                            <div class="float-left">
                                <div class="navy-bg admin_circle">
                                    <%# Eval("Key2").ToString()==("Admin")? "<i class=\"fa fa-users\"></i>":"  <i class=\"fa fa-user\"></i>"%>                               
                                </div>
                            </div>
                            <div class="media-body">
                                <span>
                                    <telerik:RadLabel ID="lblName2" runat="server" CssClass="name_font" Text='<%# Eval("Name") %>' />
                                </span>
                                <span>
                                    <label id='<%# Eval("Code") %>'>
                                        <%# Eval("Content") %><label>
                                </span>
                                <br />

                                <button type="button" id="btnReply" class="btnReply btn btn-white btn-xs" data-toggle="collapse" aria-controls='<%# Eval("Code") %>' data-target='#rep<%# Eval("Code") %>'><i class="fa fa-comments"></i>回覆</button>
                                -
                                <telerik:RadLabel ID="lblDate2" runat="server" CssClass="text-muted" Text='<%# Eval("InsertDate","{0:yyyy/MM/dd}") %>' />
                                -
                                <telerik:RadLabel ID="lblTime2" runat="server" CssClass="text-muted" Text='<%# Eval("InsertDate","{0:HH:mm}") %>' />
                                <div id='rep<%# Eval("Code")%>' class="collapse">
                                    <div class="form-group">

                                        <telerik:RadTextBox ID="txtReply" class="txtReply" runat="server" EmptyMessage="請填寫您想回覆的內容..."
                                            TextMode="MultiLine" Width="100%" Skin="Bootstrap" Rows="3">
                                        </telerik:RadTextBox>
                                        <telerik:RadButton ID="btnReplyAdd" class="btnadd" runat="server" Text="送出" CssClass="btn btn-primary btn-md m-t-md" CommandArgument='<%# Eval("Code") %>' CommandName='<%# Eval("Code") %>' />
                                        <telerik:RadLabel ID="lblReplyStatus" runat="server" CssClass="text-danger" Text="" />
                                    </div>

                                </div>
                                <br />

                               
                                <telerik:RadListView ID="SubQuestionReplyData" runat="server" ItemPlaceholderID="Container" OnItemCommand="QuestionReplyData_ItemCommand" OnNeedDataSource="SubQuestionReplyData_NeedDataSource">

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

                                        <div class="social-comment" id='div<%# Eval("Code")%>'>
                                            <div class="float-left">
                                                <div class="navy-bg admin_circle">
                                                    <%#Eval("Key2").ToString()==("Admin")?" <i class=\"fa fa-users\"></i>":"  <i class=\"fa fa-user\"></i>"%>
                                                </div>
                                            </div>
                                            <div class="media-body" style="text-align: justify;">
                                                <span>
                                                    <telerik:RadLabel ID="lblName2" runat="server" CssClass="name_font" Text='<%# Eval("Name") %>' />
                                                    <span class="text-blue"><i class="fa fa-share "></i> <%# Eval("ReplyName")%></span>
                                                    <span class="replyreply_text">
                                                        <%# Eval("ReplyContent")%>
                                                </span><br>
                     
                                                </span>
                                                <span>
                                                    <label id='<%# Eval("Code") %>'>
                                                        <%# Eval("Content") %><label>
                                                </span>
                                                <br />

                                                <button type="button" id="btnReply" class="btnReply btn btn-white btn-xs" data-toggle="collapse" aria-controls='<%# Eval("Code") %>' data-target='#subrep<%# Eval("Code") %>'><i class="fa fa-comments"></i>回覆</button>
                                                -
                                                <telerik:RadLabel ID="lblDate2" runat="server" CssClass="text-muted" Text='<%# Eval("InsertDate","{0:yyyy/MM/dd}") %>' />
                                                -
                                              <telerik:RadLabel ID="lblTime2" runat="server" CssClass="text-muted" Text='<%# Eval("InsertDate","{0:HH:mm}") %>' />
                                                <div id='subrep<%# Eval("Code")%>' class="collapse">
                                                    <div class="form-group">

                                                        <telerik:RadTextBox ID="txtReply" class="txtReply" runat="server" EmptyMessage="請填寫您想回覆的內容..."
                                                            TextMode="MultiLine" Width="100%" Skin="Bootstrap" Rows="3">
                                                        </telerik:RadTextBox>
                                                        <telerik:RadButton ID="btnSubReplyAdd" class="btnadd" runat="server" Text="送出" CssClass="btnReply btn btn-primary btn-md m-t-md" CommandArgument='<%# Eval("Code") %>' CommandName='<%# Eval("ParentCode") %>' />
                                                        <telerik:RadLabel ID="lblReplyStatus" runat="server" CssClass="text-danger" Text="" />
                                                    </div>

                                                </div>
                                                <br />

                                                <div class="social-comment">
                                                    <%# Eval("DataView")  %>
                                                </div>

                                            </div>

                                        </div>

                                    </ItemTemplate>

                                </telerik:RadListView>
                            </div>

                        </div>

                    </ItemTemplate>

                </telerik:RadListView>
            </telerik:RadAjaxPanel>
            <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                <div id="Useful" runat="server" class="row col-lg-12">

                    <div class="request_box form-inline">
                        <span class="ask_font">這個回覆對您有幫助嗎？</span>
                        <telerik:RadButton ID="btnHelpful" runat="server" Text="有幫助" CssClass="btn btn-white btn-w-m m-b-xs" OnClick="btnHelpful_Click">
                            <ConfirmSettings ConfirmText="按下確認後，此筆回報單將會結案，請問是否要將此問題結案？" />
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnHelpless" runat="server" Text="沒有" CssClass="btn btn-white btn-w-m m-b-xs" data-toggle="collapse" data-target="#demo" />


                        <div class="hr-line-dashed"></div>
                        <p id="pCompleteStatus" runat="server" style="display: none" class="text-success">
                            此筆回報單已經結案！<br>
                            如後續有相關問題，請重新建立回報單，感謝您的使用！
                        </p>
                    </div>
                </div>
            </telerik:RadAjaxPanel>


            <div id="demo" class="collapse">
                <div class="form-group">
                    <telerik:RadAjaxPanel ID="RadAjaxPanel3" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                        <telerik:RadTextBox ID="txtContent" runat="server" EmptyMessage="請填寫您想回報的內容..."
                            TextMode="MultiLine" Width="100%" Skin="Bootstrap" Rows="3">
                        </telerik:RadTextBox>

                        <telerik:RadButton ID="btnDraft" runat="server" Text="儲存草稿" CssClass="btn btn-outline btn-primary btn-md" CommandName="Draft" OnClick="btnAdd_Click" />
                        <telerik:RadButton ID="btnAdd" runat="server" Text="送出" CssClass="btn btn-primary btn-primary btn-md" OnClick="btnAdd_Click" />
                        <label id="lblAddStatus" runat="server" style="color: red"></label>
                    </telerik:RadAjaxPanel>
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
