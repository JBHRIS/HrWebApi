<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AppLoginBindEdit.aspx.cs" Inherits="Portal.AppLoginBindEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">









            <div class="col-lg-12">
                    <div class="ibox ">

                        <telerik:RadAjaxPanel ID="plSearch" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                            <div class="ibox-title">
                                <h5>查詢</h5>
                                <div class="ibox-tools">
                                    <a class="collapse-link">
                                        <i class="fa fa-chevron-up"></i>
                                    </a>
                                </div>
                            </div>
                            <div class="ibox-content">
                                
                                <div class="hr-line-dashed"></div>
                                <div class="form-group  row">
                                    <label class="col-sm-2 col-form-label">姓名查詢</label>
                                    <div class="col-sm-10 row">
                                        <telerik:RadTextBox ID="txt_Sreach_Name" runat="server" EmptyMessage="請輸入姓名" CssClass="form-control" Width="100%" />
                                    </div>
                                </div> 
                                
                                <div class="hr-line-dashed"></div>
                                <div class="form-group  row">
                                    <label class="col-sm-2 col-form-label">工號查詢</label>
                                    <div class="col-sm-10 row">
                                        <telerik:RadTextBox ID="txt_Sreach_Nobr" runat="server" EmptyMessage="請輸入工號" CssClass="form-control" Width="100%" />
                                    </div>
                                </div>
                                
                                <div class="hr-line-dashed"></div>
                                <div class="form-group row">
                                    <div class="col-sm-2 col-sm-offset-2">
                                        <telerik:RadButton ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click" CssClass="btn btn-primary btn-sm" /> 
                                    </div>
                                    <div>
                                        <telerik:RadLabel ID="lblMsg" runat="server"    />
                                    </div>
                                </div>
                            </div>
                        </telerik:RadAjaxPanel>
                    </div>
                </div>






</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
