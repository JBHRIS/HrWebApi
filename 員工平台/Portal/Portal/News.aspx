<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Portal.News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- FooTable -->
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">

                <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                    <telerik:RadListView ID="lvMain" runat="server" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="lvMain_NeedDataSource">
                        <ItemTemplate>
                            <div class="vote-item">
                                <div class="row">
                                    <div class="col-md-10">
                                        <asp:Panel runat="server" Visible='<%#Eval("IsNew") %>'>
                                            <div class="vote-actions m-t-md" style="width: 42px;">
                                                <div class="label label-primary">new</div>
                                            </div>
                                        </asp:Panel>
                                        <a href='<%# "NewsContent.aspx?id=" + Eval("NewsKey") %>' class="vote-title"><%#Eval("NewsTitle") %>
                                        </a>
                                        <div class="vote-info">
                                            <i class="fa fa-calendar"></i><%#Eval("NewsDate","{0:yyyy/MM/dd}") %>
                                            <i class="fa fa-clock-o"></i><%#Eval("NewsDate","{0:HH:mm}") %>
                                            <i class="fa fa-bookmark"></i><%#Eval("NewsKey") %>
                                        </div>
                                    </div>
                                    <div class="col-md-2 ">
                                        <div class="vote-icon">
                                            <i class="fa fa-search"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            目前公佈欄無資料
                        </EmptyDataTemplate>
                    </telerik:RadListView>
                </telerik:RadAjaxPanel>
            </div>
        </div>

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
