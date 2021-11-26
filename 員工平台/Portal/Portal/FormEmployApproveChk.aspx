<%@ Page Title="" Language="C#" MasterPageFile="~/MainFlowFormsChk.master" AutoEventWireup="true" CodeBehind="FormEmployApproveChk.aspx.cs" Inherits="Portal.FormEmployApproveChk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="ibox-content">
        <telerik:RadAjaxPanel runat="server" ID="plMain" LoadingPanelID="RadAjaxLoadingPanel1">
            <div class="row">
                <div class="col-lg-6">
                    <div class="row">
                        <div class="col-md-6">
                            <label class=" col-form-label">員工姓名</label>
                            <telerik:RadLabel runat="server" ID="lblName" CssClass="form-control"></telerik:RadLabel>
                        </div>

                        <div class="col-lg-3">
                            <label class=" col-form-label">性別</label>
                            <telerik:RadLabel runat="server" ID="lblSex" CssClass="form-control"></telerik:RadLabel>
                        </div>

                        <div class="col-lg-3">
                            <label class=" col-form-label">年齡</label>
                            <telerik:RadLabel runat="server" ID="lblAge" CssClass="form-control"></telerik:RadLabel>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <label class=" col-form-label">出生日期</label>
                            <telerik:RadLabel runat="server" ID="lblBirth" CssClass="form-control"></telerik:RadLabel>
                        </div>

                        <div class="col-md-6">
                            <label class=" col-form-label">學歷</label>
                            <telerik:RadLabel runat="server" ID="lblEducation" CssClass="form-control"></telerik:RadLabel>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <label class=" col-form-label">經歷</label>
                    <telerik:RadTextBox runat="server" ID="lblExperienced" Width="100%" CssClass="form-control" Enabled="false" TextMode="MultiLine" Rows="4" ></telerik:RadTextBox>
                </div>
            </div>
            
            <div class="row form-group">
                <div class="col-md-2">
                    <label class=" col-form-label">試用日期</label>
                    <!--<span class="float-right title_right">人資部</span>-->
                    <telerik:RadLabel runat="server" ID="lblTrialDateB" CssClass="form-control"></telerik:RadLabel>
                    <%--<div class="input-group date">
                                    <input type="text" class="form-control" value="2021/2/17">
                                    <span class="input-group-addon"><i class="fa fa-calendar form_icon"></i></span>
                                </div>--%>
                </div>

                <div class="col-md-2">
                    <label class=" col-form-label">&nbsp </label>
                    <!--<span class="float-right title_right">2</span>-->

                    <telerik:RadLabel runat="server" ID="lblTrialDateE" CssClass="form-control"></telerik:RadLabel>
                </div>

                <div class="col-md-2">
                    <label class=" col-form-label">試用部門</label>
                    <!--<span class="float-right title_right">專員</span-->

                    <telerik:RadLabel runat="server" ID="lblTrialDept" CssClass="form-control"></telerik:RadLabel>
                </div>

                <div class="col-md-2">
                    <label class=" col-form-label">試用編制部門</label>
                    <!--<span class="float-right title_right">專員</span-->

                    <telerik:RadLabel runat="server" ID="lblTrialDeptm" CssClass="form-control"></telerik:RadLabel>
                </div>
                <div class="col-md-2">
                    <label class=" col-form-label">職稱</label>
                    <!--<span class="float-right title_right">2021/2/17</span>-->

                    <telerik:RadLabel runat="server" ID="lblTrialJob" CssClass="form-control"></telerik:RadLabel>
                </div>

                <div class="col-md-2">
                    <label class=" col-form-label">職等</label>
                    <!--<span class="float-right title_right">0</span>-->

                    <telerik:RadLabel runat="server" ID="lblTrialJobl" CssClass="form-control"></telerik:RadLabel>
                </div>
            </div>

            <%-- <div class="row  form-group">
                <div class="col-md-2">
                    <label class=" col-form-label">本薪</label>
                    <!--<span class="float-right title_right">0</span>-->

                    <telerik:RadLabel runat="server" ID="lblTrialSalary" CssClass="form-control"></telerik:RadLabel>
                </div>
                <div class="col-md-2">
                    <label class=" col-form-label">職務津貼</label>
                    <!--<span class="float-right title_right">0</span>-->
                    <telerik:RadLabel runat="server" ID="lblTrialBonus" CssClass="form-control"></telerik:RadLabel>
                </div>
                <div class="col-md-2">
                    <label class=" col-form-label">伙食津貼</label>
                    <!--<span class="float-right title_right">0</span>-->
                    <telerik:RadLabel runat="server" ID="lblTrialFoodBonus" CssClass="form-control"></telerik:RadLabel>
                </div>
                <div class="col-md-2">
                    <label class=" col-form-label">特殊津貼</label>
                    <!--<span class="float-right title_right">0</span>-->
                    <telerik:RadLabel runat="server" ID="lblTrialSpecialBonus" CssClass="form-control"></telerik:RadLabel>
                </div>
                <div class="col-md-2">
                    <label class=" col-form-label">外勤津貼</label>
                    <!--<span class="float-right title_right">0</span>-->
                    <telerik:RadLabel runat="server" ID="lblTrial" CssClass="form-control"></telerik:RadLabel>
                </div>
                <div class="col-md-2">
                    <label class=" col-form-label">區域津貼</label>
                    <!--<span class="float-right title_right">0</span>-->
                    <input type="text" class="form-control" value="-">
                </div>
            </div>
            <div class="row form-group">
                <div class="col-md-2">
                    <label class=" col-form-label">差勤津貼</label>
                    <!--<span class="float-right title_right">0</span>-->

                    <input type="text" class="form-control" value="-">
                </div>

                <div class="col-md-2 form-group">
                    <label class=" col-form-label">績效津貼</label>
                    <!--<span class="float-right title_right">0</span>-->

                    <input type="text" class="form-control" value="-">
                </div>

                <div class="col-md-2 form-group">
                    <label class=" col-form-label">技術津貼</label>
                    <!--<span class="float-right title_right">0</span>-->

                    <input type="text" class="form-control" value="-">
                </div>

                <div class="col-md-2">
                    <label class=" col-form-label">總額</label>
                    <!--<span class="float-right title_right">0</span>-->

                    <input type="text" class="form-control" value="-">
                </div>

            </div>--%>

            <div class="row m-t-md m-b-md">
                <div class="col-md-12">
                    <div class="bg-muted  p-xs b-r-sm">試用期後考核</div>
                </div>
            </div>

            <div class="row form-group">
                <div class="col-md-2">
                    <label class=" col-form-label">事假時數</label>
                    <telerik:RadLabel runat="server" ID="lblPersonalLeave" CssClass="form-control" Text="0.00"></telerik:RadLabel>
                </div>

                <div class="col-md-2">
                    <label class=" col-form-label">病假時數</label>
                    <telerik:RadLabel runat="server" ID="lblSickLeave" CssClass="form-control" Text="0.00"></telerik:RadLabel>
                </div>

                <div class="col-md-2">
                    <label class=" col-form-label">曠職時數</label>
                    <telerik:RadLabel runat="server" ID="lblAbsenteeism" CssClass="form-control" Text="0.00"></telerik:RadLabel>
                </div>

                <div class="col-md-2">
                    <label class=" col-form-label">遲到次數</label>
                    <telerik:RadLabel runat="server" ID="lblLate" CssClass="form-control" Text="0.00"></telerik:RadLabel>
                </div>

                <div class="col-md-2">
                    <label class=" col-form-label">早退次數</label>
                    <telerik:RadLabel runat="server" ID="lblEarlyOut" CssClass="form-control" Text="0.00"></telerik:RadLabel>
                </div>
            </div>

            <div class="row form-group">
                <div class="col-md-12">
                    <telerik:RadTextBox runat="server" ID="txtPerformance1" Width="100%" Rows="3" Visible="false" TextMode="MultiLine" CssClass="form-control"></telerik:RadTextBox>

                </div>

                <%--<div class="col-md-6">
                    <label class=" col-form-label">&nbsp </label>
                    <telerik:RadTextBox runat="server" ID="txtInDirectMangWork" EmptyMessage="主管評核" Width="100%" Rows="3" TextMode="MultiLine" CssClass="form-control"></telerik:RadTextBox>
                </div>--%>
            </div>

            <div class="row form-group">
                <div class="col-md-12">
                    <telerik:RadTextBox runat="server" ID="txtPerformance2" Width="100%" Rows="3" Visible="false" TextMode="MultiLine" CssClass="form-control"></telerik:RadTextBox>
                </div>

                <%--<div class="col-md-6">
                    <label class=" col-form-label">&nbsp </label>
                    <telerik:RadTextBox runat="server" ID="txtInDirectMangKnowleadge" EmptyMessage="主管評核" Width="100%" Rows="3" TextMode="MultiLine" CssClass="form-control"></telerik:RadTextBox>
                </div>--%>
            </div>

            <div class="row form-group">
                <div class="col-md-12">
                    <telerik:RadTextBox runat="server" ID="txtPerformance3" Width="100%" Rows="3" Visible="false" TextMode="MultiLine" CssClass="form-control"></telerik:RadTextBox>
                </div>

                <%--<div class="col-md-6">
                    <label class=" col-form-label">&nbsp </label>
                    <telerik:RadTextBox runat="server" ID="txtInDirectMangTotal" EmptyMessage="主管評核" Width="100%" Rows="3" TextMode="MultiLine" CssClass="form-control"></telerik:RadTextBox>
                </div>--%>
            </div>

            <div class="text-right m-b-sm">
                <telerik:RadAjaxPanel runat="server">
                    <div class="text-right">
                        <telerik:RadButton ID="btnSalaryChange" runat="server" data-toggle="modal" Visible="false" data-target="#myModa3" Text="薪資異動紀錄" CssClass="btn btn-outline btn-success text-right">
                        </telerik:RadButton>
                    </div>
                </telerik:RadAjaxPanel>
            </div>

            <telerik:RadListView runat="server" ID="lvSalary" RenderMode="Lightweight" ItemPlaceholderID="Container" OnNeedDataSource="lvSalary_NeedDataSource">
                <LayoutTemplate>
                    <table class="footable table table-stripped" data-filter="#filter">
                        <thead style="background-color:#f9f9f9;">
                            <tr>
                                <th>薪資項目</th>
                                <th>原金額</th>

                            </tr>
                        </thead>
                        <tbody id="Container" runat="server">
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <telerik:RadLabel runat="server" ID="SalaryName" Text='<%# Eval("Text") %>'></telerik:RadLabel>
                            <telerik:RadLabel runat="server" ID="SalaryCode" Text='<%#Eval("Column1") %>' Visible="false"></telerik:RadLabel>
                        </td>
                        <td>
                            <telerik:RadLabel runat="server" ID="Amount" Text='<%# Eval("Value") %>'></telerik:RadLabel>
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    目前並無任何薪資資料
                </EmptyDataTemplate>

            </telerik:RadListView>
            <telerik:RadAjaxPanel runat="server" ID="plResult" Width="100%" Visible="false">
                <div class="row form-group">
                    <div class="col-md-3">
                        <label class=" col-form-label">結果</label>
                        <telerik:RadComboBox runat="server" ID="ddlResult" AutoPostBack="true" Width="100%" Skin="Bootstrap" OnTextChanged="ddlResult_TextChanged"></telerik:RadComboBox>
                    </div>
                    <asp:Panel runat="server" ID="plExtend" Visible="false" CssClass="col-md-3">
                        <label class=" col-form-label">延長</label>
                        <telerik:RadComboBox runat="server" ID="ddlExtend" Skin="Bootstrap">
                            <Items>
                                <telerik:RadComboBoxItem Text="1個月" Value="1" />
                                <telerik:RadComboBoxItem Text="2個月" Value="2" />
                                <telerik:RadComboBoxItem Text="3個月" Value="3" />
                            </Items>
                        </telerik:RadComboBox>
                    </asp:Panel>
                </div>
            </telerik:RadAjaxPanel>

            <asp:Panel runat="server" Visible="false">
                <div class="row form-group">
                    <div class="col-md-2">
                        <label class=" col-form-label">生效日期</label>

                        <telerik:RadDatePicker ID="txtEmployDate" runat="server" AutoPostBack="True" Skin="Bootstrap" Width="100%">
                        </telerik:RadDatePicker>
                    </div>

                    <div class="col-md-3">
                        <label class=" col-form-label">編制部門</label>

                        <telerik:RadComboBox runat="server" ID="ddlDept" Skin="Bootstrap" Width="100%"></telerik:RadComboBox>
                    </div>

                    <div class="col-md-3">
                        <label class=" col-form-label">簽核部門</label>

                        <telerik:RadComboBox runat="server" ID="ddlDepta" Skin="Bootstrap" Width="100%"></telerik:RadComboBox>

                    </div>

                    <div class="col-md-2">
                        <label class=" col-form-label">職稱</label>

                        <telerik:RadComboBox runat="server" ID="ddlJob" Skin="Bootstrap" Width="100%"></telerik:RadComboBox>

                    </div>

                    <div class="col-md-2">
                        <label class=" col-form-label">職等</label>

                        <telerik:RadComboBox runat="server" ID="ddlJobl" Skin="Bootstrap" Width="100%"></telerik:RadComboBox>
                    </div>
                </div>


                <telerik:RadListView runat="server" ID="lvPerformanceLog" RenderMode="Lightweight" ItemPlaceholderID="Container">
                    <LayoutTemplate>
                        <table class="footable table table-stripped" data-filter="#filter">
                            <thead>
                                <tr>
                                    <th>新進人員之學習精神及工作態度、品行等之評核</th>
                                    <th>新進人員專業知識之評核</th>
                                    <th>綜合考核意見</th>
                                </tr>
                            </thead>
                            <tbody id="Container" runat="server">
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <telerik:RadLabel runat="server" ID="lblPerformace1" Text='<%# Eval("Performance01") %>'></telerik:RadLabel>

                            </td>
                            <td>
                                <telerik:RadLabel runat="server" ID="lblPerformace2" Text='<%# Eval("Performance02") %>'></telerik:RadLabel>
                            </td>
                            <td>
                                <telerik:RadLabel runat="server" ID="lblPerformace3" Text='<%# Eval("Performance03") %>'></telerik:RadLabel>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        目前並無任何評核資料
                    </EmptyDataTemplate>
                </telerik:RadListView>
            </asp:Panel>
            <br />
            <telerik:RadButton ID="btnCheck" runat="server" CssClass="btn-primary btn-outline" Text="確認" OnClick="btnCheck_Click"></telerik:RadButton>
            <telerik:RadLabel runat="server" ID="lblError" CssClass="badge badge-danger"></telerik:RadLabel>
            <telerik:RadLabel ID="lblProcessID" runat="server" Visible="false"></telerik:RadLabel>
            <telerik:RadLabel ID="lblNameAppM" runat="server" Visible="False"></telerik:RadLabel>
            <telerik:RadLabel ID="lblCode" runat="server" Visible="False"></telerik:RadLabel>


        </telerik:RadAjaxPanel>
        <div class="modal inmodal" id="myModal" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h5 class="modal-title">職務異動紀錄</h5>
                    </div>
                    <div class="modal-body">
                        <div class="table-responsive">
                            <telerik:RadListView ID="lvEmployChangeLog" runat="server" RenderMode="Lightweight" ItemPlaceholderID="Container">
                                <LayoutTemplate>
                                    <table class="table table-striped" data-page-size="10" data-filter="#filter">
                                        <thead>
                                            <tr>
                                                <th>編制部門</th>
                                                <th>簽核部門</th>
                                                <th>職等</th>
                                                <th>職稱</th>
                                                <th>異動者</th>
                                                <th>異動日期</th>
                                            </tr>
                                        </thead>
                                        <tbody id="Container" runat="server">
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <td colspan="5">
                                                    <ul class="pagination float-right"></ul>
                                                </td>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr class="gradeX">
                                        <td><%# Eval("DeptNameChange") %></td>
                                        <td><%# Eval("DeptmNameChange") %></td>
                                        <td><%# Eval("JobNameChange") %></td>
                                        <td><%# Eval("JoblCodeChange") %></td>
                                        <td><%# Eval("InsertMan") %></td>
                                        <td><%# Eval("InsertDate","{0:yyyy/MM/dd HH:mm}") %></td>
                                    </tr>
                                </ItemTemplate>

                            </telerik:RadListView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal inmodal fade" id="myModa3" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h5 class="modal-title">薪資異動紀錄</h5>
                    </div>
                    <div class="modal-body">
                        <div class="table-responsive">
                            <telerik:RadListView ID="lvSalaryLog" runat="server" OnNeedDataSource="lvSalaryLog_NeedDataSource" RenderMode="Lightweight" ItemPlaceholderID="Container">
                                <LayoutTemplate>
                                    <div class="table-responsive">
                                        <table class="table table-striped" data-page-size="10" data-filter="#filter">
                                            <thead>
                                                <tr>
                                                    <th>異動人員</th>
                                                    <th>薪資資料</th>
                                                    <th>異動日期</th>
                                                </tr>
                                            </thead>
                                            <tbody id="Container" runat="server">
                                            </tbody>
                                        </table>
                                    </div>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr class="gradeX">
                                        <td><%# Eval("InsertMan") %> </td>
                                        <td><%# Eval("SalaryData") %></td>
                                        <td><%# Eval("InsertDate") %></td>
                                    </tr>
                                </ItemTemplate>

                            </telerik:RadListView>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
