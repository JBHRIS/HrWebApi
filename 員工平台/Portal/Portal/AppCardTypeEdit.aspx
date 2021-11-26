<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AppCardTypeEdit.aspx.cs" Inherits="Portal.AppCardTypeEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">








    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox ">
                    <div class="ibox-title">
                        <h5>新增打卡類型</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">

                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">打卡類型名稱</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox ID="txt_CardName" runat="server" EmptyMessage="打卡類型名稱" CssClass="form-control" Width="100%" />
                            </div>
                        </div>

                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">打卡代碼名稱</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox ID="RadTextBox1" runat="server" EmptyMessage="打卡代碼名稱" CssClass="form-control" Width="100%" />
                            </div>
                        </div>



                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">排序</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox ID="txt_ItemOrder" runat="server" EmptyMessage="排序" CssClass="form-control" Width="100%" InputType="Number" />
                            </div>
                        </div>

                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">


                                <%--<telerik:RadButton ID="btnSearch" runat="server" Text="新增查詢" CssClass="btn btn-primary btn-sm" OnClick="btn_Save_CardType_Click" />--%>


                                <telerik:RadButton ID="RadButton1" runat="server" Text="新增" CssClass="btn btn-primary btn-sm" />



                            </label>
                            <div class="col-sm-10 row">
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>







</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">




</asp:Content>
