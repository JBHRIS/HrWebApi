<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FormAuthority.aspx.cs" Inherits="Portal.FormAuthority" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="ibox-title">
                        <div>
                            <h5>表單權限設定</h5>
                        </div>
                    </div>

                    <div class="ibox-content">
                        <div class="row">
                            <div class="col-lg-12">
                                <telerik:RadCheckBox ID="cbAllCheck" runat="server" Text="全選"   />
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                                <ul class="todo-list m-t ui-sortable">
                                    <li>
                                        <telerik:RadCheckBox ID="RadCheckBox1" runat="server" Text="請假單"   />
                                        
                                    </li>
                                    <li>
                                        <telerik:RadCheckBox ID="RadCheckBox2" runat="server" Text="公出單"   />
                                    </li>
                                    <li>
                                        <telerik:RadCheckBox ID="RadCheckBox3" runat="server" Text="忘刷單"   />
                                    </li>
                                </ul>
                            </div>
                            <div class="col-lg-6">
                                <ul class="todo-list m-t ui-sortable">
                                    <li>
                                        <telerik:RadCheckBox ID="RadCheckBox4" runat="server" Text="調班單"   />
                                    </li>
                                    <li>
                                        <telerik:RadCheckBox ID="RadCheckBox5" runat="server" Text="換班單"   />
                                    </li>
                                    <li>
                                        <telerik:RadCheckBox ID="RadCheckBox6" runat="server" Text="加班單"   />
                                    </li>
                                </ul>
                            </div>


                        </div>

                        <!-- 暫時不實作,製作時控制項請詢問阿明
                        <div class="row">
                            <div class="col-md-12">
                                <label class=" col-form-label">部門權限設定</label>
                                <select class="select2_demo_1 form-control" style="width: 100%">
                                    <option value="1">開發部</option>
                                    <option value="2">People 2</option>
                                    <option value="3">People 3</option>
                                    <option value="4">People 4</option>
                                    <option value="5">People 5</option>
                                </select>
                            </div>
                        </div>-->

                        <div class="row m-t-md">
                            <div class="col-lg-12">
                                <telerik:RadButton ID="btnback" runat="server" Text="返回" CssClass="btn btn-outline btn-primary" />
                                <telerik:RadButton ID="btnSave" runat="server" Text="儲存" CssClass="btn btn-primary" />
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
