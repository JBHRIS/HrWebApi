<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageMainDept.aspx.cs" Inherits="Performance.ManageMainDept" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox ">
                    <div class="ibox-title">
                        <h5>修改內容</h5>
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
                        <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">部門名稱</label>
                                <div class="col-sm-2">
                                    獎金可視層級
                                </div>
                                <div class="col-sm-2">
                                    結束層級
                                </div>
                            </div>
                            <telerik:RadListView ID="lvDept" runat="server" DataKeyNames="AutoKey,Code" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="lvDept_NeedDataSource" OnDataBound="lvDept_DataBound" OnItemCommand="lvDept_ItemCommand">
                                <LayoutTemplate>
                                    <asp:PlaceHolder ID="Container" runat="server"></asp:PlaceHolder>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <div class="form-group row">
                                        <label class="col-sm-2 col-form-label"><%# Eval("Name") %></label>
                                        <div class="col-sm-2">
                                            <telerik:RadDropDownList ID="ddlDeptTreeB" Skin="Bootstrap" runat="server" />
                                        </div>
                                        <div class="col-sm-2">
                                            <telerik:RadDropDownList ID="ddlDeptTreeE" Skin="Bootstrap" runat="server" />
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    目前並無任何資料
                                </EmptyDataTemplate>
                            </telerik:RadListView>
                            <telerik:RadButton ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click" CssClass="btn btn-primary" />
                                 <telerik:RadButton ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click"  CssClass="btn btn-w-m btn-warning" />
                            <telerik:RadLabel ID="lblMsg" runat="server"  CssClass="badge badge-danger"  />
                            <telerik:RadLabel ID="lblUserCode" runat="server" Visible="False" />
                            <telerik:RadLabel ID="lblKey1" runat="server" Visible="False" />
                            <telerik:RadLabel ID="lblKey2" runat="server" Visible="False" />
                            <telerik:RadLabel ID="lblGuid" runat="server" Visible="False" />
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
