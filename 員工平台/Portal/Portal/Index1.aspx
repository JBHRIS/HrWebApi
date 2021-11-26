<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Index1.aspx.cs" Inherits="Portal.Index1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="styles/dashboard.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content">

        <div class="row">
            <div class="col-lg-8">

                <div class="ibox">
                    <div class="ibox-title_sy3">
                        <h5><i class="fa fa-bullhorn"></i>公告欄</h5>
                        <div class="ibox-tools_icon">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>

                        </div>
                    </div>
                    <div class="ibox-content table-responsive">
                        <telerik:RadListView ID="lvBillBoard" runat="server" RenderMode="Lightweight" ItemPlaceholderID="Container">
                            <LayoutTemplate>
                                <table class="table table-hover no-margins">
                                    <thead>
                                        <tr>
                                            <th>主旨</th>
                                            <th>日期</th>
                                            <th>發布者</th>
                                        </tr>
                                    </thead>
                                    <tbody id="Container" runat="server">
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><a href="News.aspx"><%# Eval("Title") %></a></td>
                                    <td><%# Eval("PublishTime","{0:yyyy/MM/dd}") %></td>
                                    <td><%# Eval("KeyName") %></td>
                                </tr>
                            </ItemTemplate>
                        </telerik:RadListView>
                    </div>
                </div>

                <%--<div class="ibox">
                         <div class="ibox-title_sy3">
                              <h5><i class="fa fa-bullhorn"></i> 公告欄</h5>
                               <div class="ibox-tools_icon">
                                    <a class="collapse-link">
                                        <i class="fa fa-chevron-up"></i>
                                     </a>
                                     <a class="close-link">
                                         <i class="fa fa-times"></i>
                                     </a>
                               </div>
                         </div>
                         <div class="ibox-content table-responsive">
                              <table class="table table-hover no-margins">
                                            <thead>
                                            <tr>
                                                <th>主旨</th>
                                                <th>日期</th>
                                                <th>發布者</th>                                               
                                            </tr>
                                            </thead>
                                            <tbody>
											<tr>
                                                <td><small>IPHONE12團購IPHONE12團購</small> </td>
                                                <td> 2020/12/24</td>
                                                <td>Janet</td>
                                            </tr>
											<tr>
                                                <td><small>IPHONE12團購IPHONE12團購</small> </td>
                                                <td> 2020/12/24</td>
                                                <td>Janet</td>
                                            </tr>
                                            <tr>
                                                <td><small>IPHONE12團購IPHONE12團購</small></td>
                                                <td> 2020/12/24</td>
                                                <td>Samantha</td>
                                            </tr>
                                            <tr>
                                                <td><small>IPHONE12團購IPHONE12團購</small> </td>
                                                <td> 2020/12/24</td>
                                                <td>Monica</td>                                              
                                            </tr>
                                            <tr>
                                                <td><small>IPHONE12團購IPHONE12團購</small> </td>
                                                <td> 2020/12/24</td>
                                                <td>John</td>                                             
                                            </tr>
                                            <tr>
                                                <td><small>IPHONE12團購IPHONE12團購</small> </td>
                                                <td> 2020/12/24</td>
                                                <td>Agnes</td>
                                            </tr>
                                           
											
                                            </tbody>
                                        </table>
                          </div>
                	 </div>--%>
            </div>

            <div class="col-lg-4">

                <div class="col-12 col-md-6 col-lg-12">
                    <div class="ibox">
                        <div class="ibox-title bg-danger">
                            <h5><i class="fa fa-exclamation-triangle"></i>異常資訊</h5>
                            <div class="ibox-tools_icon">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                                <a class="close-link">
                                    <i class="fa fa-times"></i>
                                </a>
                            </div>
                        </div>

                        <div class="ibox-content">
                            <div class="row">
                                <div class="col col-6  col-lg-6 border-right">
                                    <h1 class="no-margins font-bold text-danger">
                                        <telerik:RadLabel runat="server" ID="lblAbnToday"></telerik:RadLabel>
                                    </h1>
                                    <div class="stat-percent font-bold">今日</div>
                                    <small>人</small>
                                </div>

                                <div class="col col-6  col-lg-6 text-muted">
                                    <h1 class="no-margins">
                                        <telerik:RadLabel runat="server" ID="lblAbnYesterday"></telerik:RadLabel>
                                    </h1>
                                    <div class="stat-percent font-bold">昨日</div>
                                    <small>人</small>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-12 col-md-6 col-lg-12">
                    <div class="ibox">
                        <div class="ibox-title bg-info">
                            <h5><i class="fa fa-map-marker"></i>打卡資訊</h5>
                            <div class="ibox-tools_icon">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                                <a class="close-link">
                                    <i class="fa fa-times"></i>
                                </a>
                            </div>
                        </div>

                        <div class="ibox-content">
                            <table class="table table-hover no-margins">
                                <thead>
                                    <tr>
                                        <th>出勤班別</th>
                                        <th class="text-center">上班</th>
                                        <th class="text-center">下班</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <telerik:RadLabel runat="server" ID="lblRote" />
                                        </td>
                                        <td class="text-center">
                                            <telerik:RadLabel runat="server" ID="lblOnTime" />
                                        </td>
                                        <td class="text-center">
                                            <telerik:RadLabel runat="server" ID="lblOffTime" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

                <div class="col-12 col-md-6 col-lg-12">
                    <div class="ibox">
                        <div class="ibox-title bg-success">
                            <h5><i class="fa fa-calendar"></i>餘假資訊</h5>
                            <div class="ibox-tools_icon">
                                <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                <a class="close-link"><i class="fa fa-times"></i></a>
                            </div>
                        </div>
                        <div class="ibox-content">
                            <ul class="stat-list">
                                <li>
                                    <h1 class="no-margins font-bold text-navy text-success">
                                        <telerik:RadLabel runat="server" ID="lblSpecialLeave"></telerik:RadLabel>
                                    </h1>
                                    <small>特休剩餘(h)&emsp;</small>
                                    <div class="stat-percent">
                                        <telerik:RadLabel runat="server" ID="lblSpecialLeaveTotal"></telerik:RadLabel>
                                        總(h)
                                    </div>
                                    <small>
                                        <telerik:RadLabel runat="server" ID="lblSpecialLeaveDate" />
                                        到期</small>
                                    <div class="progress progress-mini">
                                        <telerik:RadLabel ID="lblSpecialLeaveBar" runat="server" CssClass="progress-bar progress-bar-success"></telerik:RadLabel>
                                    </div>
                                </li>

                                <li>
                                    <h1 class="no-margins font-bold text-navy text-success">
                                        <telerik:RadLabel runat="server" ID="lblCompensatoryLeave" />
                                    </h1>
                                    <small>補休剩餘(h)&emsp;</small>
                                    <div class="stat-percent">
                                        <telerik:RadLabel runat="server" ID="lblCompensatoryLeaveTotal"></telerik:RadLabel>
                                        總(h)
                                    </div>
                                    <small>
                                        <telerik:RadLabel runat="server" ID="lblCompensatoryLeaveDate"></telerik:RadLabel>
                                        到期
                                    </small>
                                    <div class="progress progress-mini">
                                        <telerik:RadLabel runat="server" ID="lblCompensatoryLeaveBar" CssClass="progress-bar progress-bar-success"></telerik:RadLabel>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-12 col-md-6 col-lg-12">
                    <div id="hour" class="ibox">
                        <div class="ibox-title bg-warning">
                            <h5><i class="fa fa-clock-o"></i>本月加班時數</h5>
                            <div class="ibox-tools_icon">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                                <a class="close-link">
                                    <i class="fa fa-times"></i>
                                </a>
                            </div>
                        </div>
                        <div class="ibox-content">
                            <h1 class="font-bold">
                                <telerik:RadLabel runat="server" ID="lblOtHour" />
                                <small class="text-muted">/ 46</small></h1>

                            <div class="text-center">
                                <div id="sparkline5"></div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-12 col-md-6 col-lg-12">
                    <div class="ibox">
                        <div class="ibox-title bg-primary">
                            <h5><i class="fa fa-pencil "></i>待審核 </h5>
                            <span class="badge bg-muted text-navy">0</span>
                            <div class="ibox-tools_icon">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                                <a class="close-link">
                                    <i class="fa fa-times"></i>
                                </a>
                            </div>
                        </div>
                        <div class="ibox-content">
                            <telerik:RadListView ID="lvUserFormAssign" runat="server" RenderMode="Lightweight" ItemPlaceholderID="Container" OnItemCommand="lvUserFormAssign_ItemCommand">
                                <LayoutTemplate>
                                    <table class="table table-hover no-margins">
                                        <thead>
                                            <tr>
                                                <th>表單</th>
                                            </tr>
                                        </thead>
                                        <tbody id="Container" runat="server">
                                        </tbody>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <telerik:RadButton ID="btnUserFormAssign" runat="server" Text='<%# Eval("ProcessFlowID") %>' CommandArgument='<%# Eval("ProcessApParmAuto") %>'>
                                        </telerik:RadButton>
                                    </tr>
                                </ItemTemplate>
                            </telerik:RadListView>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </div>
    <%--<div class="wrapper wrapper-content">
        <div class="row">
            <div class="col col-12 col-md-6 col-lg-3">
                <div class="ibox">
                    <div class="ibox-title bg-success">
                        <h5><i class="fa fa-calendar"></i> 餘假資訊</h5>
                        <div class="ibox-tools_icon">
                            <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <ul class="stat-list">
                            <li>
                                <h1 class="no-margins font-bold text-navy text-success">
                                    <telerik:RadLabel runat="server" ID="lblSpecialLeave"></telerik:RadLabel>
                                </h1>
                                <small>特休剩餘(h)&emsp;</small>
                                <div class="stat-percent">
                                    <telerik:RadLabel runat="server" ID="lblSpecialLeaveTotal"></telerik:RadLabel>
                                    總(h) </div>
                                <small>
                                    <telerik:RadLabel runat="server" ID="lblSpecialLeaveDate" />
                                    到期</small>
                                <div class="progress progress-mini">
                                    <telerik:RadLabel ID="lblSpecialLeaveBar" runat="server" CssClass="progress-bar progress-bar-success"></telerik:RadLabel>
                                </div>
                            </li>

                            <li>
                                <h1 class="no-margins font-bold text-navy text-success">
                                    <telerik:RadLabel runat="server" ID="lblCompensatoryLeave" />
                                </h1>
                                <small>補休剩餘(h)&emsp;</small>
                                <div class="stat-percent">
                                    <telerik:RadLabel runat="server" ID="lblCompensatoryLeaveTotal"></telerik:RadLabel>
                                    總(h) </div>
                                <small>
                                    <telerik:RadLabel runat="server" ID="lblCompensatoryLeaveDate"></telerik:RadLabel>到期
                                </small>
                                <div class="progress progress-mini">
                                    <telerik:RadLabel runat="server" ID="lblCompensatoryLeaveBar" CssClass="progress-bar progress-bar-success"></telerik:RadLabel>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>

            <div class="col col-12 col-md-6 col-lg-3">
                <div class="ibox">
                    <div class="ibox-title bg-primary">
                        <h5><i class="fa fa-address-book"></i> 今日上下班時間</h5>
                        <div class="ibox-tools_icon">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>

                    <div class="ibox-content">
                        <div class="row">
                            <div class="col col-6  col-lg-6 border-right">
                                <h1 class="no-margins font-bold text-info"><telerik:RadLabel runat="server" ID="lblOnTime"></telerik:RadLabel></h1>
                                <div class="stat-percent font-bold">上班</div>
                            </div>

                            <div class="col col-6  col-lg-6 text-muted">
                                <h1 class="no-margins font-bold text-info"><telerik:RadLabel runat="server" ID="lblOffTime"></telerik:RadLabel></h1>
                                <div class="stat-percent font-bold">下班</div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <div class="col col-12 col-md-6 col-lg-3">
                <div class="ibox ">
                    <div class="ibox-title bg-warning">
                        <h5><i class="fa fa-clock-o"></i> 本月加班時數</h5>
                        <div class="ibox-tools_icon">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <h1 class="font-bold">
                            <telerik:RadLabel runat="server" ID="lblOtHour" />
                            <small class="text-muted">/ 46</small></h1>

                        <div class="text-center">
                            <div id="sparkline5"></div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col col-12 col-md-6 col-lg-3">
                <div class="ibox">
                    <div class="ibox-title bg-danger">
                        <h5><i class="fa fa-exclamation-triangle"></i> 異常資訊</h5>
                        <div class="ibox-tools_icon">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>

                    <div class="ibox-content">
                        <div class="row">
                            <div class="col col-6  col-lg-6 border-right">
                                <h1 class="no-margins font-bold text-danger"><telerik:RadLabel runat="server" ID="lblAbnToday"></telerik:RadLabel></h1>
                                <div class="stat-percent font-bold">今日</div>
                                <small>人</small>
                            </div>

                            <div class="col col-6  col-lg-6 text-muted">
                                <h1 class="no-margins"><telerik:RadLabel runat="server" ID="lblAbnYesterday"></telerik:RadLabel></h1>
                                <div class="stat-percent font-bold">昨日</div>
                                <small>人</small>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <div class="col col-12 col-md-6 col-lg-3">
                <div class="ibox">
                    <div class="ibox-title bg-primary">
                        <h5><i class="fa fa-pencil "></i> 待審核 </h5>
                        <span class="badge bg-muted text-navy">0</span>
                        <div class="ibox-tools_icon">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <%--<div class="flot-chart">
                                <div class="flot-chart-pie-content" id="flot-pie-chart"></div>
                            </div>
                    </div>
                </div>
            </div>
            <div class="col col-12 col-md-6 col-lg-3">
                <div class="ibox">
                    <div class="ibox-title bg-info">
                        <h5><i class="fa fa-group "></i> 今日班別 </h5>
                        <div class="ibox-tools_icon">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <h3 class="no-margins font-bold text-dark"><telerik:RadLabel runat="server" ID="lblRote"></telerik:RadLabel></h3>
                    </div>
                </div>
            </div>


            <div class="col col-12 col-lg-6">
                <div class="ibox ">
                    <div class="ibox-title_sy3">
                        <h5><i class="fa fa-bullhorn"></i> 公告欄</h5>
                        <div class="ibox-tools_icon">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content table-responsive ">

                        <telerik:RadListView ID="lvBillBoard" runat="server" RenderMode="Lightweight" ItemPlaceholderID="Container">
                            <LayoutTemplate>
                                <table class="table table-hover no-margins">
                                    <thead>
                                        <tr>
                                            <th>主旨</th>
                                            <th>日期</th>
                                            <th>發布者</th>
                                        </tr>
                                    </thead>
                                    <tbody id="Container" runat="server">
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><a href="News.aspx"><%# Eval("Title") %></a></td>
                                    <td><%# Eval("PublishTime","{0:yyyy/MM/dd}") %></td>
                                    <td><%# Eval("KeyName") %></td>
                                </tr>
                            </ItemTemplate>
                        </telerik:RadListView>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <%--<script src="Templates/Inspinia/js/plugins/flot/jquery.flot.js"></script>
        <script src="Templates/Inspinia/js/plugins/flot/jquery.flot.pie.js"></script>

        <script src="scripts/flot-demo.js"></script>--%>
</asp:Content>
