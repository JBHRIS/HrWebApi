<%@ Page Title="" Language="C#" MasterPageFile="~/Main_PR.Master" AutoEventWireup="true" CodeBehind="MessageNew.aspx.cs" Inherits="Portal.MessageNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="ibox">
        <div class="ibox-content">
            <div class="row  form-inline">
                <div class="col-lg-3">
                    <h2 id="title" runat="server">建立預設訊息</h2>

                </div>
                <div class="col-lg-3 text-right">
                    <span class="slect_cans"><a>選擇罐頭訊息</a></span>
                    <!--點選選擇罐頭訊息後，右邊會跳出預設罐頭訊息，使用者點選罐頭訊息後能修改罐頭訊息-->
                </div>
                <div class="col-lg-3">
                    <h5>罐頭訊息選擇</h5>

                </div>
            </div>
            <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
            <div class="row">

                <div class="col-lg-6">
                    
                        <div class="form-group row">
                            <label class="col-lg-2 col-form-label">標題 <small class="text-navy">(0/30)</small></label>
                            <div class="col-lg-10">
                                <telerik:RadTextBox ID="txtTitle" runat="server" EmptyMessage="請輸入標題..." Skin="Bootstrap" Width="100%" />
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


                                <telerik:RadListView ID="lvMain" runat="server" ItemPlaceholderID="Container">
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
                                            <td>標題 : 
                                                    <telerik:RadLabel ID="lblName2" runat="server" CssClass="name_font" Text='<%# Eval("Name")%>' />

                                                <td>內容 : 
                                                     <telerik:RadLabel ID="lblDate2" runat="server" CssClass="text-muted" Text='<%# Eval("Contents")%>' />
                                                </td>
                                            <td>
                                                <telerik:RadButton ID="SetDefaultMessage" runat="server" Text="選擇" CommandName='<%# Eval("Name") %>' CommandArgument='<%# Eval("Contents") %>' CssClass="btn-white btn btn-xs"  OnClick="GetDefaultMessageData"/>
                                            </td>

                                        </tr>


                                    </ItemTemplate>
                                    <EmptyDataTemplate>
                                        無任何預設訊息
                                    </EmptyDataTemplate>
                                </telerik:RadListView>

                            </div>
                            <hr>
                        </div>
                    </div>
                </div>
            </div>
                  </telerik:RadAjaxPanel>
            <div class="row">
                <div class="col-lg-12">
                    <telerik:RadButton ID="btnPage" runat="server" Text="上一頁" CssClass="btn btn-outline btn-primary btn-md" OnClick="btnPage_Click"/>
                    <telerik:RadButton ID="btnAdd" runat="server" Text="確認" CssClass="btn btn-primary btn-md" OnClick="btnAdd_Click" />
                    <label runat="server" id="lblAddStatus"  style="color:red;"> </label>
                    <!--<button class="btn btn-primary btn-outline" type="submit"><strong>上一頁</strong></button>
                    <button class="btn btn-primary btn-md" type="submit"><strong>確認</strong></button>-->
                </div>
            </div>
            <asp:Label ID="lblUserCode" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblEmpID" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblCompanyId" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblEmpName" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblRoleKey" runat="server" Visible="False"></asp:Label>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <script src="Templates/Inspinia/js/plugins/footable/footable.all.min.js"></script>


    <script>
        $(document).ready(function () {
            $('.footable').footable();
        });
    </script>

</asp:Content>
