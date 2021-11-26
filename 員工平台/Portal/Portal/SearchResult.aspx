<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SearchResult.aspx.cs" Inherits="Portal.SearchResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeIn">

        <div class="ibox">
            <div class="ibox-content">
                <div class="row">
                    <div class="col-12">
                        <h1>搜尋"<telerik:RadLabel ID="lblSearch" runat="server"/>"的結果</h1>
                        <%--<h4>熱門搜尋:</h4>--%>
                    </div>
                </div>
                <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">

                    <telerik:RadListView ID="lvMain" runat="server" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="lvMain_NeedDataSource">
                        <LayoutTemplate>
                            <asp:PlaceHolder ID="Container" runat="server"></asp:PlaceHolder>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div class="search-result">
                                <h1><a><%# Eval("Title")  %> </a></h1>
                                <%--<h2><a runat="server" href='<%# Eval("Page")  %>'><%# Eval("SearchTitle")  %> </a></h2>--%>
                                <p>
                                    <%# Eval("Content")  %>
                                </p>
                                <div class="hr-line-dashed"></div>
                            </div>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            無搜尋結果
                        </EmptyDataTemplate>
                    </telerik:RadListView>
                </telerik:RadAjaxPanel>
            </div>
        </div>
    </div>
        
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="Templates/Inspinia/js/plugins/footable/footable.all.min.js"></script>

    <script>
        $(document).ready(function () {
            $('.footable').footable();
        });
    </script>
</asp:Content>
