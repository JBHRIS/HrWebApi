<%@ Page Title="" Language="C#" MasterPageFile="~/Main_PR.Master" AutoEventWireup="true" CodeBehind="MessageNew.aspx.cs" Inherits="Portal.MessageNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="ibox">

        <div class="ibox-content">
            <div class="row  form-inline">
                <div class="col-lg-3">
                </div>
                <div class="col-lg-3">
                </div>
            </div>

            <div class="row">

                <div class="col-lg-6">
                    <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                        <h2 id="title" runat="server">建立預設訊息</h2>
                        <div class="form-group">
                            <label>標題 <small id="titlelength" style="color: #1ab394">(0/30)</small><label runat="server" id="lblAddStatus" style="color: red;"></label></label>
                            <telerik:RadTextBox ID="txtTitle" runat="server" EmptyMessage="請輸入標題..." Skin="Bootstrap" Width="100%" />
                        </div>
                        <div class="form-group">
                            <label>內容 <small id="contentlength" style="color: #1ab394">(0/200)</small></label>
                            <telerik:RadTextBox ID="txtContent" runat="server" EmptyMessage="請填寫您想回報的內容..."
                                TextMode="MultiLine" Width="100%" Skin="Bootstrap" Rows="4">
                            </telerik:RadTextBox>
                        </div>
                    </telerik:RadAjaxPanel>
                </div>

                <div class="col-lg-6 m-t-md">
                    <h5>選擇罐頭訊息後編輯成想要的文字</h5>
                    <div class="ibox">
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
                                        <div class="ibox-content">
                                            <div class="row">
                                                <div class="col-lg-9">
                                                    <div>
                                                        <telerik:RadLabel ID="lblName2" runat="server" CssClass="product-name" Text='<%# Eval("Name")%>' />
                                                    </div>
                                                    <div class="small m-t-xs">
                                                        <telerik:RadLabel ID="lblDate2" runat="server" CssClass="text-muted" Text='<%# Eval("Contents")%>' />
                                                    </div>
                                                </div>

                                                <div class="col-lg-3  m-t-xs text-center">
                                                    <telerik:RadButton AutoPostBack="true" ID="SetDefaultMessage" runat="server" Text="選擇" CommandName='<%# Eval("Name") %>' CommandArgument='<%# Eval("Contents") %>' CssClass="btnSetDefault btn-white btn btn-xs" OnClick="SetDefaultMessage" />
                                                </div>
                                            </div>
                                        </div>
                                    </tr>


                                    <%--<tr>
                                            <td>標題 : 
                                                    <telerik:RadLabel ID="lblName2" runat="server" CssClass="name_font" Text='<%# Eval("Name")%>' />

                                                <td>內容 : 
                                                     <telerik:RadLabel ID="lblDate2" runat="server" CssClass="text-muted" Text='<%# Eval("Contents")%>' />
                                                </td>
                                            <td>
                                                <telerik:RadButton ID="SetDefaultMessage" runat="server" Text="選擇" CommandName='<%# Eval("Name") %>' CommandArgument='<%# Eval("Contents") %>' CssClass="btn-white btn btn-xs" OnClick="SetDefaultMessage"/>
                                            </td>

                                        </tr>--%>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    無任預設訊息
                                </EmptyDataTemplate>
                            </telerik:RadListView>

                        </div>
                    </div>
                </div>

            </div>

            <div class="row">
                <div class="col-lg-12">
                    <telerik:RadButton ID="btnPage" runat="server" Text="上一頁" CssClass="btn btn-outline btn-primary btn-md" OnClick="btnPage_Click" />
                    <telerik:RadButton ID="btnAdd" runat="server" Text="確認" CssClass="btn btn-primary btn-md" OnClick="btnAdd_Click" />
                    <label runat="server" id="lblEditStatus" style="color: red;"></label>
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
            var isPostBack = <%=this.IsPostBack.ToString().ToLower()%>;
             if (isPostBack) {
                 $('#titlelength').text('(' + $('#ctl00_ContentPlaceHolder1_txtTitle').val().length + '/30)')
                 isTyping = false;
                 if ($('#ctl00_ContentPlaceHolder1_txtContent').val().length > 200) {
                     $('#contentlength').css('color', 'red')

                     $('#contentlength').text('(' + $('#ctl00_ContentPlaceHolder1_txtContent').val().length + '/200)')
                     isTyping = false;
                 }
                 else {
                     $('#contentlength').css('color', '#1ab394')
                     $('#contentlength').text('(' + $('#ctl00_ContentPlaceHolder1_txtContent').val().length + '/200)')
                     isTyping = false;
                 }
                 if ($('#ctl00_ContentPlaceHolder1_txtTitle').val().length > 30) {
                     $('#titlelength').css('color', 'red')
                     $('#titlelength').text('(' + $('#ctl00_ContentPlaceHolder1_txtTitle').val().length + '/30)')
                     isTyping = false;
                 }
                 else {
                     $('#titlelength').css('color', '#1ab394')
                     $('#titlelength').text('(' + $('#ctl00_ContentPlaceHolder1_txtTitle').val().length + '/30)')
                     isTyping = false;
                 }
             }
             else {
                 $('#titlelength').text('(0/30)')
                 $('#contentlength').text('(0/200)')
                 isTyping = false;

             }
         });
        var isTyping

        $('#ctl00_ContentPlaceHolder1_txtTitle').on('keyup', function () {

            $('#ctl00_ContentPlaceHolder1_txtTitle').on('compositionstart', function (e) {
                isTyping = true;
            });
            $('#ctl00_ContentPlaceHolder1_txtTitle').on('compositionend', function (e) {
                isTyping = false;
            });
            if (!isTyping) {
                if ($('#ctl00_ContentPlaceHolder1_txtTitle').val().length > 30) {
                    $('#titlelength').css('color', 'red')
                    $('#titlelength').text('(' + $('#ctl00_ContentPlaceHolder1_txtTitle').val().length + '/30)')
                    isTyping = false;
                }
                else {
                    $('#titlelength').css('color', '#1ab394')
                    $('#titlelength').text('(' + $('#ctl00_ContentPlaceHolder1_txtTitle').val().length + '/30)')

                    isTyping = false;

                }

            }


        });
        $('#ctl00_ContentPlaceHolder1_txtContent').on('keyup', function () {

            $('#ctl00_ContentPlaceHolder1_txtContent').on('compositionstart', function (e) {
                isTyping = true;
            });
            $('#ctl00_ContentPlaceHolder1_txtContent').on('compositionend', function (e) {
                isTyping = false;
            });
            if (!isTyping) {
                if ($('#ctl00_ContentPlaceHolder1_txtContent').val().length > 200) {
                    $('#contentlength').css('color', 'red')

                    $('#contentlength').text('(' + $('#ctl00_ContentPlaceHolder1_txtContent').val().length + '/200)')
                    isTyping = false;
                }
                else {
                    $('#contentlength').css('color', '#1ab394')
                    $('#contentlength').text('(' + $('#ctl00_ContentPlaceHolder1_txtContent').val().length + '/200)')
                    isTyping = false;

                }

            }


        });
    </script>

</asp:Content>
