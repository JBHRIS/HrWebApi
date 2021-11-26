<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Index2.aspx.cs" Inherits="Portal.Index2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="styles/dashboard.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row  border-bottom white-bg dashboard-header">
        <div class="col-md-3">
            <h2><i class="fa fa-users"></i>部門資訊</h2>
            <ul class="list-group clear-list m-t">
                <li class="list-group-item fist-item">
                    <span class="float-right">
                        <span class="font-bold"><telerik:RadLabel runat="server" ID="lblListAbn"></telerik:RadLabel></span>筆
                    </span>
                    <span class="label  bg-danger">1</span> 異常
                </li>
                <li class="list-group-item ">
                    <span class="float-right">
                        <span class="font-bold">0</span>/0
                    </span>
                    <span class="label label-primary">2</span> 出勤
                </li>

                <li class="list-group-item">
                    <span class="float-right">
                        <span class="font-bold">0</span>/0
                    </span>
                    <span class="label label-primary">3</span> 問卷
                </li>
                <li class="list-group-item">
                    <span class="float-right"></span>
                    <span class="label label-default">4</span>
                </li>
                <li class="list-group-item">
                    <span class="float-right"></span>
                    <span class="label label-default">5</span>
                </li>
            </ul>
        </div>
        <div class="col-md-6 m-t-lg">
            <div class="row text-center ">
                <div class="col-lg-6">
                    <%--<div class="flot-chart">
                        <div class="flot-chart-pie-content" id="flot-pie-chart"></div>
                    </div>--%>
                    <span class="h5 font-bold m-t block">0</span>
                    <small class="text-muted m-b block">代審核(筆)</small>
                </div>
                <div class="col-lg-6">
                    <div id="sparkline5"></div>
                    <span class="h5 font-bold m-t block"><telerik:RadLabel runat="server" ID="lblListOt"></telerik:RadLabel> /46</span>
                    <small class="text-muted m-b block">總加班數(h)</small>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="statistic-box">
                <h4>Project Beta progress
                </h4>
                <p>
                    You have two project with not compleated task.
                </p>
                <div class="row text-center">
                    <div class="col-lg-6">
                        <!--<canvas id="doughnutChart2" width="80" height="80" style="margin: 18px auto 0"></canvas>-->
                        <h5>Kolter</h5>
                    </div>
                    <div class="col-lg-6">
                        <!--<canvas id="doughnutChart" width="80" height="80" style="margin: 18px auto 0"></canvas>-->
                        <h5>Maxtor</h5>
                    </div>
                </div>

            </div>
        </div>

    </div>
			<div class="wrapper wrapper-content">
				<div class="row">
					<div class="col-lg-6">
						<div class="row">
							<div class="col-lg-6"><div class="ibox">
									<div class="ibox-title bg-success">
										<h5><i class="fa fa-calendar"></i> 特休資訊</h5>
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
										</ul>
									</div>  
								</div></div>

							<div class="col-lg-6">
								<div id="hour" class="ibox">
									<div class="ibox-title bg-warning">
										<h5><i class="fa fa-clock-o"></i> 加班時數</h5>
										<div class="ibox-tools_icon">
											<a class="collapse-link">
												<i class="fa fa-chevron-up"></i>
											</a>
											
										</div>
									</div>
									<div class="ibox-content">
										<ul class="stat-list">
											<li>
													<h1 class="no-margins font-bold text-navy text-warning"><telerik:RadLabel runat="server" ID="lblOtHour"></telerik:RadLabel></h1>
													<small>已加班(h)&emsp;</small>
													<div class="stat-percent">最多46(h) </div>
													<div class="progress progress-mini">
														  <telerik:RadLabel ID="lblOtHourBar" runat="server" CssClass="progress-bar progress-bar-success"></telerik:RadLabel>
													</div>
											</li>
										</ul>
										<!--<div class="text-center">
											<div id="sparkline5"></div>
										</div>-->
									</div>
								</div>
							</div>
						</div>
						
						<div class="row">
							<div class="col-lg-6">
									<div class="ibox">
										<div class="ibox-title bg-info">
											<h5><i class="fa fa-map-marker"></i> 打卡資訊</h5>
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
										  <!--<table class="table table-hover no-margins">
											 <thead>
												<tr>
												  <th>出勤班別</th>
												  <th class="text-center">上班</th>
												  <th class="text-center">下班</th>                                               
												</tr>
											 </thead>
											 <tbody>
												<tr>
												   <td>08:30-17:30</td>
												   <td class="text-center"><i class="fa fa-clock-o"></i> 08:29</td>
												   <td class="text-center">未打卡</td>
												</tr>
											 </tbody>
										   </table>-->
										</div>
									</div>

							<div class="col-lg-6">
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
							</div>

						</div>	
					
					<div class="col-lg-6">
						<div class="ibox">
							 <div class="ibox-title_sy3">
								  <h5><i class="fa fa-bullhorn"></i> 公告欄</h5>
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
