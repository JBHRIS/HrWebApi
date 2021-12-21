<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Portal.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="styles/dashboard.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content">

        <div class="row">
            <div class="col-lg-8">
                <asp:Panel runat="server" ID="pnlNews" Visible="false">
                    <div class="ibox">
                        <div class="ibox-title_sy3">
                            <h5><i class="fa fa-bullhorn"></i><telerik:RadLabel runat="server" ID="lblBillboard" Text="&nbsp;公佈欄"></telerik:RadLabel></h5>
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
                                                <th><telerik:RadLabel runat="server" ID="lblBillboardTitle" Text="主旨"></telerik:RadLabel></th>
                                                <th><telerik:RadLabel runat="server" ID="lblBillboardDate" Text="日期"></telerik:RadLabel></th>
                                                <th><telerik:RadLabel runat="server" ID="lblBillboardPublisher" Text="發布者"></telerik:RadLabel></th>
                                            </tr>
                                        </thead>
                                        <tbody id="Container" runat="server">
                                        </tbody>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><a href='<%#"NewsContent.aspx?id=" + Eval("idNo") %>'><%# Eval("Title") %></a></td>
                                        <td><%# Eval("PublishTime","{0:yyyy/MM/dd}") %></td>
                                        <td><%# Eval("KeyName") %></td>
                                    </tr>
                                </ItemTemplate>
                            </telerik:RadListView>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlCheck" Visible="false">
                    <div class="ibox">
                        <div class="ibox-title bg-primary">
                            <h5><i class="fa fa-pencil "></i><telerik:RadLabel runat="server" ID="lblUserFormAssign" Text=" 待審核"></telerik:RadLabel> </h5>
                            <span class="badge bg-muted text-navy">
                                <asp:Label ID="lblSignCount" runat="server" Text="0"></asp:Label>
                            </span>
                            <div class="ibox-tools_icon">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                            </div>
                        </div>
                        <div class="ibox-content">
                            <telerik:RadListView ID="lvUserFormAssign" runat="server" RenderMode="Lightweight" OnItemCommand="lvUserFormAssign_ItemCommand">

                                <ItemTemplate>
                                    <div class="row line">
                                        <div class="col-lg-4"><strong><telerik:RadLabel runat="server" ID="lblFormAssignName" Text="表單"></telerik:RadLabel>：</strong><%# Eval("FormName") %>,<%# Eval("ProcessFlowID") %></div>
                                        <div class="col-lg-3"><strong><telerik:RadLabel runat="server" ID="lblFormAssignApplicant" Text="申請者"></telerik:RadLabel>：</strong><%# Eval("AppEmpID") %>,<%# Eval("AppEmpName") %></div>
                                        <div class="col-lg-3"><strong><telerik:RadLabel runat="server" ID="lblFormAssignDate" Text="申請日期"></telerik:RadLabel>：</strong><%# Eval("AppDate","{0:yyyy/M/dd}") %></div>
                                        <div class="col-lg-2">
                                            <telerik:RadButton ID="btnUserFormAssign" runat="server" Text="檢視" CommandArgument='<%# Eval("ProcessApParmAuto") %>' CommandName='<%# Eval("FormCode") %>' CssClass="btn btn-outline btn-primary">
                                            </telerik:RadButton>
                                        </div>
                                    </div>
                                    <%--<tr>
                                        <td><%# Eval("FormName") %></td>
                                        <td><%# Eval("ProcessFlowID") %></td>
                                        <td><%# Eval("AppEmpID") %>,<%# Eval("AppEmpName") %></td>
                                        <td style="word-break: break-all; "><%# Eval("AppDate","{0:yyyy/M/dd}") %></td>
                                        <td>
                                            <telerik:RadButton ID="btnUserFormAssign" runat="server" Text="檢視" CommandArgument='<%# Eval("ProcessApParmAuto") %>' CommandName='<%# Eval("FormCode") %>' CssClass="btn btn-outline btn-primary">
                                            </telerik:RadButton>
                                        </td>
                                    </tr>--%>
                                </ItemTemplate>
                            </telerik:RadListView>
                        </div>
                    </div>
                </asp:Panel>
                <%--<div class="ibox">
                    <div class="ibox-title bg-primary">
                        <h5><i class="fa fa-pencil "></i>待審核 </h5>
                        <span class="badge bg-muted text-navy">
                            <asp:Label ID="Label1" runat="server" Text="0"></asp:Label>
                        </span>
                        <div class="ibox-tools_icon">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="row line">
                            <div class="col-lg-4"><strong>表單：</strong>從業人員晉升調任申請單,372067</div>
                            <div class="col-lg-3"><strong>申請者：</strong>吳秀靜,A0902</div>
                            <div class="col-lg-3"><strong>申請日期：</strong>2021/8/12</div>
                            <div class="col-lg-2">
                                <telerik:RadButton ID="btnExport" runat="server" Text="檢視" CssClass="btn-outline btn-primary" />
                            </div>
                        </div>

                        <div class="row line">
                            <div class="col-lg-4"><strong>表單：</strong>從業人員晉升調任申請單,372067</div>
                            <div class="col-lg-3"><strong>申請者：</strong>吳秀靜,A0902</div>
                            <div class="col-lg-3"><strong>申請日期：</strong>2021/8/12</div>
                            <div class="col-lg-2">
                                <telerik:RadButton ID="RadButton1" runat="server" Text="檢視" CssClass="btn-outline btn-primary" />
                            </div>
                        </div>

                    </div>
                </div>--%>
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
                <div class="row">
                    <div class="col-lg-12">
                        <asp:Panel runat="server" ID="pnlAbn" Visible="false">
                            <div class="ibox">
                                <div class="ibox-title bg-danger">
                                    <h5><i class="fa fa-exclamation-triangle"></i> <telerik:RadLabel runat="server" ID="lblAbn" Text=" 異常資訊"></telerik:RadLabel></h5>
                                    <div class="ibox-tools_icon">
                                        <a class="collapse-link">
                                            <i class="fa fa-chevron-up"></i>
                                        </a>
                                    </div>
                                </div>

                                <div class="ibox-content">
                                    <div class="row">
                                        <div class="col col-6  col-lg-6 border-right">
                                            <h1 class="no-margins font-bold text-danger">
                                                <telerik:RadLabel runat="server" ID="lblAbnToday"></telerik:RadLabel>
                                            </h1>
                                            <div class="stat-percent font-bold"><telerik:RadLabel runat="server" ID="lblAbnTodayName" Text="今日"></telerik:RadLabel></div>
                                            <small><telerik:RadLabel runat="server" ID="lblAbnTodayUnit" Text="人"></telerik:RadLabel></small>
                                        </div>

                                        <div class="col col-6  col-lg-6 text-muted">
                                            <h1 class="no-margins">
                                                <telerik:RadLabel runat="server" ID="lblAbnYesterday"></telerik:RadLabel>
                                            </h1>
                                            <div class="stat-percent font-bold"><telerik:RadLabel runat="server" ID="lblAbnYesterdayName" Text="昨日"></telerik:RadLabel></div>
                                            <small><telerik:RadLabel runat="server" ID="lblAbnYesterdayUnit" Text="人"></telerik:RadLabel></small>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-12">
                        <asp:Panel runat="server" ID="pnlCard" Visible="false">
                            <div class="ibox">
                                <div class="ibox-title bg-info">
                                    <h5><i class="fa fa-id-card"></i><telerik:RadLabel runat="server" ID="lblRoteInformation" Text="班別資訊"></telerik:RadLabel></h5>
                                    <div class="ibox-tools_icon">
                                        <a class="collapse-link">
                                            <i class="fa fa-chevron-up"></i>
                                        </a>
                                    </div>
                                </div>

                                <div class="ibox-content">
                                    <table class="table table-hover no-margins">
                                        <thead>
                                            <tr>
                                                <th><telerik:RadLabel runat="server" ID="lblClassName" Text="出勤班別"></telerik:RadLabel></th>
                                                <th class="text-center"><telerik:RadLabel runat="server" ID="lblClassOnTime" Text="上班"></telerik:RadLabel></th>
                                                <th class="text-center"><telerik:RadLabel runat="server" ID="lblClassOffTime" Text="下班"></telerik:RadLabel></th>
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
                        </asp:Panel>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-12">
                        <asp:Panel runat="server" ID="pnlAbs" Visible="false">
                            <div class="ibox">
                                <div class="ibox-title bg-success">
                                    <h5><i class="fa fa-calendar"></i><telerik:RadLabel runat="server" ID="lblBalanceInformation" Text="餘假資訊"></telerik:RadLabel></h5>
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
                                            <small><telerik:RadLabel runat="server" ID="lblSpecialLeaveBalance" Text="特休剩餘"></telerik:RadLabel>(h)&emsp;</small>
                                            <%--<div class="stat-percent">
                                            <telerik:RadLabel runat="server" ID="lblSpecialLeaveTotal"></telerik:RadLabel>
                                            總(h)
                                        </div>
                                        <small>
                                            <telerik:RadLabel runat="server" ID="lblSpecialLeaveDate" />
                                            到期</small>--%>
                                            <div class="progress progress-mini">
                                                <telerik:RadLabel ID="lblSpecialLeaveBar" runat="server" CssClass="progress-bar progress-bar-success"></telerik:RadLabel>
                                            </div>
                                        </li>

                                        <li>
                                            <h1 class="no-margins font-bold text-navy text-success">
                                                <telerik:RadLabel runat="server" ID="lblCompensatoryLeave" />
                                            </h1>
                                            <small><telerik:RadLabel runat="server" ID="lblCompensatoryLeaveBalance" Text="補休剩餘"></telerik:RadLabel>(h)&emsp;</small>
                                            <%--<div class="stat-percent">
                                            <telerik:RadLabel runat="server" ID="lblCompensatoryLeaveTotal"></telerik:RadLabel>
                                            總(h)
                                        </div>
                                        <small>
                                            <telerik:RadLabel runat="server" ID="lblCompensatoryLeaveDate"></telerik:RadLabel>
                                            到期
                                        </small>--%>
                                            <div class="progress progress-mini">
                                                <telerik:RadLabel runat="server" ID="lblCompensatoryLeaveBar" CssClass="progress-bar progress-bar-success"></telerik:RadLabel>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-12">
                        <asp:Panel runat="server" ID="pnlOt" Visible="false">
                            <div id="hour" class="ibox">
                                <div class="ibox-title bg-warning">
                                    <h5><i class="fa fa-clock-o"></i><telerik:RadLabel runat="server" ID="lblOtHourThisMonth" Text="本月加班時數"></telerik:RadLabel></h5>
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
                        </asp:Panel>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <%--<script src="Templates/Inspinia/js/plugins/flot/jquery.flot.js"></script>
        <script src="Templates/Inspinia/js/plugins/flot/jquery.flot.pie.js"></script>

        <script src="scripts/flot-demo.js"></script>--%>
</asp:Content>
