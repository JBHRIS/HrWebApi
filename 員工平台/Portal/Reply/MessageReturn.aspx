<%@ Page Title="" Language="C#" MasterPageFile="~/Main_PR.Master" AutoEventWireup="true" CodeBehind="MessageReturn.aspx.cs" Inherits="Portal.MessageReturn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="social-feed-box">
        <div class="social-avatar">
            <div class="media-body">
              <%--  <label>姓名:</label>--%>
                <telerik:RadLabel ID="lblName" runat="server" CssClass="name_font" Text="" />
               <%-- <label>日期:</label>--%>
                <telerik:RadLabel ID="lblDate" runat="server" CssClass="text-muted" Text="" />
                &ensp;-&ensp;
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
        </div>
    </div>
   
    <div class="row">
       
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="ibox-content">
                        <div class="request_bg">
                              
                            <div class="row">
                               
                                <div class="form-group  col-lg-6">
                                     <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
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
                                            <div class="row">
                                                <telerik:RadRadioButton ID="RadioFirst" AutoPostBack="true" runat="server"   Checked="true" Text="提問者" Value="74" OnCheckedChanged="RadioFirst_CheckedChanged" />
                                                &ensp;
                                                <telerik:RadRadioButton ID="RadioSecond" AutoPostBack="true" runat="server"   Text="HR" Value="10" OnCheckedChanged="RadioSecond_CheckedChanged"/>
                                                &ensp;
                                                <telerik:RadRadioButton ID="RadioThird" AutoPostBack="true" runat="server"   Text="提問者及HR" Value="4" OnCheckedChanged="RadioThird_CheckedChanged" />
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
                                           </telerik:RadAjaxPanel>
                                </div>
                                   

                                <div class="col-lg-6">
                                    <h5>選擇罐頭訊息後編輯成想要的文字</h5>
                                    <telerik:RadListView ID="lvMain" runat="server" OnItemCommand="lvMain_ItemCommand" OnNeedDataSource="lvMain_NeedDataSource" ItemPlaceholderID="Container">
                                        <LayoutTemplate>
                                            <table id="footable" class="footable table table-stripped" data-page-size="3" data-filter="#filterTaken">
                                                <thead>
                                                </thead>
                                                <tbody id="Container" runat="server">

                                                    <telerik:RadLabel ID="lblName2" runat="server" CssClass="name_font" Text="標題" />
                                                    <br />
                                                    <telerik:RadLabel ID="lblDate2" runat="server" CssClass="text-muted" Text="內容" />
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
                                            <tr>
                                            <div class="ibox-content">
                                                <div class="row">
                                                    <div class="col-lg-9">
                                                        <div>
                                                            <telerik:RadLabel ID="RadLabel1" runat="server" CssClass="product-name" Text='<%# Eval("Name")%>' />
                                                        </div>
                                                        <div class="small m-t-xs">
                                                            <telerik:RadLabel ID="RadLabel2" runat="server" CssClass="text-muted" Text='<%# Eval("Contents")%>' />
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-3  m-t-xs text-center">
                                                        <telerik:RadButton ID="SetDefaultMessage" runat="server" Text="選擇" CommandName='<%# Eval("Name") %>' CommandArgument='<%# Eval("Contents") %>' CssClass="btn-white btn btn-xs" OnClick="SetDefaultMessage" />
                                                    </div>
                                                </div>
                                            </div>
                                                </tr>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            無任何預設訊息
                                        </EmptyDataTemplate>

                                    </telerik:RadListView>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <telerik:RadButton ID="btnDraft" runat="server" Text="儲存草稿" CssClass="btn btn-outline btn-primary btn-md" CommandName="Draft" OnClick="btnAdd_Click" />
                                        <telerik:RadButton ID="btnAdd" runat="server" Text="送出" CssClass="btn btn-primary btn-md" CommandName="Add"  OnClick="btnAdd_Click" />
                                    </div>
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
