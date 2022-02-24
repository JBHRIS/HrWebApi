<%@ Page Title="" Language="C#" MasterPageFile="~/Main_PR.Master" AutoEventWireup="true"
    CodeBehind="MessageReturn.aspx.cs" Inherits="Portal.MessageReturn" %>

    

    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <telerik:RadAjaxManager ID="RadAjaxManager" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="btnAdd">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="QuestionReplyData" />
                        <telerik:AjaxUpdatedControl ControlID="txtContent" />
                        <telerik:AjaxUpdatedControl ControlID="DraftStatus" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="btnDraft">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="txtContent" />
                        <telerik:AjaxUpdatedControl ControlID="DraftStatus" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="lvMain">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="txtContent" />
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
                        <%-- <label>提問者 :</label>--%>
                            <telerik:RadLabel ID="lblName" runat="server" CssClass="name_font" Text="" />
                            <%-- <label>日期 :</label>--%>
                                <br>
                                <telerik:RadLabel ID="lblDate" runat="server" CssClass="text-muted" Text="" />
                                -
                                <telerik:RadLabel ID="lblTime" runat="server" CssClass="text-muted" Text="" />
                    </span>
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
            </div>
            <div class="social-footer">
                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                    <telerik:RadListView ID="QuestionReplyData" runat="server" ItemPlaceholderID="Container"
                        OnItemCommand="QuestionReplyData_ItemCommand"
                        OnNeedDataSource="QuestionReplyData_NeedDataSource">

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
                                        <%#Eval("UserRole")%>
                                    </div>
                                </div>
                                <div class="media-body">
                                    <span>
                                        <telerik:RadLabel ID="lblName2" runat="server" CssClass="name_font"
                                            Text='<%# Eval("Name") %>' />
                                    </span>
                                    <span>
                                        <label id='<%# Eval("Code") %>'>
                                            <%# Eval("Content") %><label>
                                    </span>
                                    <br />

                                    <button type="button" id="btnReply" class="btnReply btn btn-white btn-xs"
                                        data-toggle="collapse" aria-controls='<%# Eval("Code") %>'
                                        data-target='#rep<%# Eval("Code") %>'><i class="fa fa-comments"></i>回覆</button>
                                    -
                                    <telerik:RadLabel ID="lblDate2" runat="server" CssClass="text-muted"
                                        Text='<%# Eval("InsertDate","{0:yyyy/MM/dd}") %>' />
                                    -
                                    <telerik:RadLabel ID="lblTime2" runat="server" CssClass="text-muted"
                                        Text='<%# Eval("InsertDate","{0:HH:mm}") %>' />
                                    <div id='rep<%# Eval("Code")%>' class="collapse">
                                        <div class="form-group">

                                            <telerik:RadTextBox ID="txtReply" class="txtReply" runat="server"
                                                EmptyMessage="請填寫您想回覆的內容..." TextMode="MultiLine" Width="100%"
                                                Skin="Bootstrap" Rows="3">
                                            </telerik:RadTextBox>
                                            <telerik:RadButton ID="btnReplyAdd" class="btnadd" runat="server" Text="送出"
                                                CssClass="btn btn-primary btn-md m-t-md"
                                                CommandArgument='<%# Eval("Code") %>'
                                                CommandName='<%# Eval("Code") %>' />
                                            <telerik:RadLabel ID="lblReplyStatus" runat="server" CssClass="text-danger"
                                                Text="" />
                                        </div>

                                    </div>
                                    <br />


                                    <telerik:RadListView ID="SubQuestionReplyData" runat="server"
                                        ItemPlaceholderID="Container" OnItemCommand="QuestionReplyData_ItemCommand"
                                        OnNeedDataSource="SubQuestionReplyData_NeedDataSource">

                                        <LayoutTemplate>

                                            <div id="Container" runat="server">
                                                <telerik:RadLabel ID="lblName2" runat="server" CssClass="name_font"
                                                    Text="" />
                                                <telerik:RadLabel ID="lblDate2" runat="server" CssClass="text-muted"
                                                    Text="" />
                                                &ensp;&ensp;
                                                <telerik:RadLabel ID="lblTime2" runat="server" CssClass="text-muted"
                                                    Text="" />
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
                                                        <%#Eval("UserRole")%>
                                                    </div>
                                                </div>
                                                <div class="media-body" style="text-align: justify;">
                                                    <span>
                                                        <telerik:RadLabel ID="lblName2" runat="server"
                                                            CssClass="name_font" Text='<%# Eval("Name") %>' />
                                                        <span class="text-blue"><i class="fa fa-share "></i>
                                                            <%# Eval("ReplyName")%>
                                                        </span>
                                                        <span class="replyreply_text">
                                                            <%# Eval("ReplyContent")%>
                                                        </span>
                                                        <br>
                                                    </span>
                                                    <span>
                                                        <label id='<%# Eval("Code") %>'>
                                                            <%# Eval("Content") %><label>
                                                    </span>
                                                    <br />

                                                    <button type="button" id="btnReply"
                                                        class="btnReply btn btn-white btn-xs" data-toggle="collapse"
                                                        aria-controls='<%# Eval("Code") %>'
                                                        data-target='#subrep<%# Eval("Code") %>'><i
                                                            class="fa fa-comments"></i>回覆</button>
                                                    -
                                                    <telerik:RadLabel ID="lblDate2" runat="server" CssClass="text-muted"
                                                        Text='<%# Eval("InsertDate","{0:yyyy/MM/dd}") %>' />
                                                    -
                                                    <telerik:RadLabel ID="lblTime2" runat="server" CssClass="text-muted"
                                                        Text='<%# Eval("InsertDate","{0:HH:mm}") %>' />
                                                    <div id='subrep<%# Eval("Code")%>' class="collapse">
                                                        <div class="form-group">

                                                            <telerik:RadTextBox ID="txtReply" class="txtReply"
                                                                runat="server" EmptyMessage="請填寫您想回覆的內容..."
                                                                TextMode="MultiLine" Width="100%" Skin="Bootstrap"
                                                                Rows="3">
                                                            </telerik:RadTextBox>
                                                            <telerik:RadButton ID="btnSubReplyAdd" class="btnadd"
                                                                runat="server" Text="送出"
                                                                CssClass="btnReply btn btn-primary btn-md m-t-md"
                                                                CommandArgument='<%# Eval("Code") %>'
                                                                CommandName='<%# Eval("ParentCode") %>' />
                                                            <telerik:RadLabel ID="lblReplyStatus" runat="server"
                                                                CssClass="text-danger" Text="" />
                                                        </div>

                                                    </div>
                                                    <br />


                                                </div>

                                            </div>

                                        </ItemTemplate>

                                    </telerik:RadListView>
                                </div>

                            </div>

                        </ItemTemplate>

                    </telerik:RadListView>
                </telerik:RadAjaxPanel>
            </div>

        </div>

        <div class="row">

            <div class="col-lg-12">

                <div class="ibox">
                    <div class="ibox-content">
                        <div class="request_bg">

                            <div class="row">

                                <div class="form-group  col-lg-6">
                                    <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server"
                                        LoadingPanelID="RadAjaxLoadingPanel1">
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <h3>訊息回覆</h3>
                                            </div>
                                            <div class="col-lg-6 text-right">
                                            </div>
                                        </div>

                                        <div class="form-group row form-inline">
                                            <label class="col-lg-3 col-form-label text-left">問題轉交或回覆</label>
                                            <div class="col-lg-9">
                                                <div id="DivRadio" class="row">
                                                    <telerik:RadRadioButton ID="RadioFirst" AutoPostBack="true"
                                                        runat="server" Checked="true" Text="提問者" Value="74"
                                                        OnCheckedChanged="RadioFirst_CheckedChanged" />
                                                    &ensp;
                                                    <telerik:RadRadioButton ID="RadioSecond" AutoPostBack="true"
                                                        runat="server" Text="HR" Value="10"
                                                        OnCheckedChanged="RadioSecond_CheckedChanged" />
                                                    &ensp;
                                                    <telerik:RadRadioButton ID="RadioThird" AutoPostBack="true"
                                                        runat="server" Text="提問者及HR" Value="4"
                                                        OnCheckedChanged="RadioThird_CheckedChanged" />
                                                    &ensp;
                                                    <telerik:RadRadioButton ID="RadioFourth" AutoPostBack="true"
                                                        runat="server" Text="系統商內部人員" Value="2" Visible="false"
                                                        OnCheckedChanged="RadioFourth_CheckedChanged" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <div class="row">

                                                <div class="col-lg-6">
                                                    <telerik:RadComboBox ID="txtReturnS" runat="server"
                                                        class="txtReturnS" Skin="Bootstrap" AllowCustomText="True"
                                                        AutoPostBack="true" EnableVirtualScrolling="True"
                                                        ItemsPerRequest="10" Filter="Contains" LoadingMessage="載入中…"
                                                        Width="100%" Visible="false" Enabled="false">
                                                    </telerik:RadComboBox>
                                                </div>
                                                <div class="col-lg-4"></div>
                                                <div class="col-lg-2 text-right">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-lg-12">
                                                <telerik:RadTextBox ID="txtContent" runat="server"
                                                    EmptyMessage="請填寫您想回報的內容..." TextMode="MultiLine" Width="100%"
                                                    Skin="Bootstrap" Rows="5">
                                                </telerik:RadTextBox>
                                            </div>
                                        </div>
                                    </telerik:RadAjaxPanel>
                                </div>


                                <div class="col-lg-6">

                                    <h5>選擇罐頭訊息後編輯成想要的文字</h5>

                                    <telerik:RadListView ID="lvMain" runat="server" OnItemCommand="lvMain_ItemCommand"
                                        OnNeedDataSource="lvMain_NeedDataSource" ItemPlaceholderID="Container">
                                        <LayoutTemplate>
                                            <table id="footable " class="footable cansmessage table table-stripped"
                                                data-page-size="3" style="table-layout:fixed" data-filter="#filterTaken">
                                                <thead>
                                                </thead>
                                                <tbody id="Container" runat="server" style="background-color:#FFF;">
                                                    <tr style="border:1px solid #e7eaec;">
                                                        <td style="width:80%;padding:15px;"></td>
                                                        <td style="width:20%;text-align:center;vertical-align: middle !important;padding:15px;"></td>
                                                    </tr>
                                                </tbody>
                                                <tfoot>
                                                    <tr>
                                                        <td colspan="9">
                                                            <ul class="pagination float-right"></ul>
                                                        </td>
                                                    </tr>
                                                </tfoot>
                                            </table>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <tbody id="Container" runat="server" style="background-color:#FFF;">
                                            <tr style="border:1px solid #e7eaec;">
                                                 <td style="width:80%;padding:15px;overflow:hidden">
                                                    <telerik:RadLabel ID="RadLabel1" runat="server"
                                                        CssClass="product-name" Text='<%# Eval("Name")%>' /><br>
                                                    <telerik:RadLabel ID="RadLabel2" runat="server"
                                                        CssClass="text-muted" Text='<%# Eval("Contents")%>' />
                                                </td>
                                                <td style="width:20%;text-align:center;vertical-align: middle !important;padding:15px;">
                                                    <telerik:RadButton ID="SetDefaultMessage" runat="server" Text="選擇"
                                                        CommandName='<%# Eval("Name") %>'
                                                        CommandArgument='<%# Eval("Contents") %>'
                                                        CssClass="btn-white btn btn-xs" OnClick="SetDefaultMessage" />
                                                </td>
                                            </tr>
                                                </tbody>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>

                                            無任何預設訊息
                                        </EmptyDataTemplate>

                                    </telerik:RadListView>

                                </div>



                                <div class="col-lg-12">

                                    <telerik:RadButton ID="btnDraft" runat="server" Text="儲存草稿"
                                        CssClass="btn btn-outline btn-primary btn-md" CommandName="Draft"
                                        OnClick="btnAdd_Click" />
                                    <telerik:RadButton ID="btnAdd" runat="server" Text="送出"
                                        CssClass="btn btn-primary btn-md" CommandName="Add" OnClick="btnAdd_Click" />
                                    <label id="DraftStatus" style="color: red" runat="server"
                                        cssclass="text-muted"></label>
                                </div>



                            </div>

                        </div>

                    </div>

                </div>

            </div>

        </div>


        <asp:Label ID="lblUserCode" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblEmpID" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblCompanyId" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblEmpName" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblRoleKey" runat="server" Visible="False"></asp:Label>
    </asp:Content>

    <asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
        <script src="Templates/Inspinia/js/plugins/footable/footable.all.min.js"></script>


        <script>
            $(document).ready(function () {
                $('.footable').footable();
            });


        </script>

    </asp:Content>