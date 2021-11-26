<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AppBssidBind.aspx.cs" Inherits="Portal.AppBssidBind" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="wrapper wrapper-content animated fadeIn">
            <div class="row">

                <!-- 新增BSSID -->

                <div class="col-lg-12">
                    <div class="ibox ">

                        <telerik:RadAjaxPanel ID="plSearch" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                            <div class="ibox-title">
                                <h5>BSSID新增</h5>
                                <div class="ibox-tools">
                                    <a class="collapse-link">
                                        <i class="fa fa-chevron-up"></i>
                                    </a>
                                </div>
                            </div>
                            <div class="ibox-content">
                                <div class="hr-line-dashed"></div>
                                <div class="form-group  row">
                                    <label class="col-sm-2 col-form-label">SSID名稱</label>
                                    <div class="col-sm-10 col-lg-4 row">
                                        <telerik:RadTextBox ID="txt_SSID" runat="server" EmptyMessage="SSID名稱" CssClass="form-control" Width="100%" />
                                        
                                    </div>
                                </div>
                                <div class="hr-line-dashed"></div>
                                <div class="form-group  row">
                                    <label class="col-sm-2 col-form-label">BSSID名稱</label>
                                    <div class="col-sm-10 col-lg-4 row">
                                        <telerik:RadTextBox ID="txt_BSSID" runat="server" EmptyMessage="BSSID名稱" CssClass="form-control" Width="100%" />
                                    </div>
                                </div>

                                <div class="hr-line-dashed"></div>
                                <div class="form-group row">
                                    <div class="col-sm-2 col-sm-offset-2 col-lg-4" >
                            <%--            <telerik:RadButton ID="btn_Save_SSID" runat="server" Text="新增" CssClass="btn btn-primary btn-sm" OnClick="btn_Save_SSID_Click" />--%>
                                        <telerik:RadButton ID="btnSearch" runat="server" Text="新增" CssClass="btn btn-primary btn-sm" OnClick="btn_Save_SSID_Click" />

                                        


                                    </div>
                                    <div>
                                        <telerik:RadLabel ID="lblMsg" runat="server"    />
                                    </div>
                                </div>
                            </div>
                        </telerik:RadAjaxPanel>
                    </div>
                </div>



      




                <!-- 查詢BSSID -->


                <div class="col-lg-12">
                    <div class="ibox">
                        <div class="ibox-title">
                            <h5>BSSID清單</h5>
                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                            </div>
                        </div>
                        <div class="ibox-content">

                            <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">

                            

                            <telerik:RadListView ID="lvMain" runat="server" RenderMode="Lightweight" Skin=""
                                 ItemPlaceholderID="Container" 
                                OnItemCommand="lvMain_ItemCommand"
                                OnNeedDataSource="Table_SSID_Identifier_NeedDataSource"  >
                                <LayoutTemplate>
                                    <table class="footable table table-stripped" data-page-size="10" data-filter="#filter">
                                        <thead>
                                            <tr>
                                                <th>SSID名稱</th>
                                                <th>BSSID名稱</th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody id="Container" runat="server">
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <td colspan="3">
                                                    <ul class="pagination float-right"></ul>
                                                </td>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr class="gradeX">
                                        <td><%# Eval("SSID") %></td>
                                        <td><%# Eval("BSSID") %></td>
                                        <td>
                                            <telerik:RadButton ID="btn_Delete" runat="server" Text="刪除" CommandName="Delete" CommandArgument='<%# Eval("AutoKey") %>' CssClass="btn-white btn btn-xs" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    目前並無任BSSID資料
                                </EmptyDataTemplate>
                            </telerik:RadListView>


                                </telerik:RadAjaxPanel>
                        </div>
                    </div>
                </div>





                          <!-- 如何查詢 BSSID-->

                <div class="col-lg-12">
                    <div class="ibox">
                        <div class="ibox-title">
                            <h5>BSSID查詢</h5>
                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                            </div>
                        </div>
                        <div class="ibox-content">
                            <div class="hr-line-dashed"></div>
                            <div class="form-group  row">
                                <label class="col-sm-12  col-form-label">步驟一.電腦必須連接WIFI</label>
                                <div class="col-sm-12 row">
                                </div>
                            </div>

                            <div class="hr-line-dashed"></div>
                            <div class="form-group  row">
                                <label class="col-sm-12  col-form-label">步驟二.按下 : Windows + R</label>
                                <div class="col-sm-12 row">
                                    <img src="images/reference/win-R-step1.jpg" />
                                </div>
                            </div>

                            <div class="hr-line-dashed"></div>
                            <div class="form-group  row">
                                <label class="col-sm-12 col-form-label">步驟三.輸入 : cmd  </label>
                                <div class="col-sm-12 row">
                                    <img src="images/reference/cmd.jpg" />
                                </div>
                                
                            </div>

                            <div class="hr-line-dashed"></div>
                            <div class="form-group  row">
                                <label class="col-sm-12 col-form-label">步驟四.輸入 : netsh wlan show networks mode=bssid</label>
                                
                                <div class="col-sm-12 row">
                                    <img src="images/reference/cmd1.jpg" />
                                </div>
                                <div class="col-sm-12 row">
                                    <img src="images/reference/BSSID.jpg" />
                                </div>
                            </div>


                        </div>
                    </div>
                </div>
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
