<%@ Page Title="" Language="C#" MasterPageFile="~/MainFlowFormsStd.master" AutoEventWireup="true" CodeBehind="FormEmployApproveStd.aspx.cs" Inherits="Portal.FormEmployApproveStd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="ibox-content">
        <telerik:RadAjaxPanel runat="server" ID="plMain" LoadingPanelID="RadAjaxLoadingPanel1">
            <div class="row form-group">
                <div class="col-lg-6">
                    <div class="row">
                        <div class="col-md-6">
                            <label class=" col-form-label">員工姓名</label>
                            <telerik:RadLabel runat="server" ID="lblName" CssClass="form-control"></telerik:RadLabel>
                        </div>

                        <div class="col-md-3">
                            <label class=" col-form-label">性別</label>
                            <telerik:RadLabel runat="server" ID="lblSex" CssClass="form-control"></telerik:RadLabel>
                        </div>

                        <div class="col-md-3">
                            <label class=" col-form-label">年齡</label>
                            <telerik:RadLabel runat="server" ID="lblAge" CssClass="form-control"></telerik:RadLabel>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <label class=" col-form-label">學歷</label>
                            <telerik:RadLabel runat="server" ID="lblEducation" CssClass="form-control"></telerik:RadLabel>
                        </div>

                        <div class="col-md-6">
                            <label class=" col-form-label">出生日期</label>
                            <telerik:RadLabel runat="server" ID="lblBirth" CssClass="form-control"></telerik:RadLabel>
                        </div>
                    </div>
                </div>

                <div class="col-lg-6">
                    <label class=" col-form-label">經歷</label>
                    <telerik:RadTextBox runat="server" ID="lblExperienced" Width="100%" Enabled="false" CssClass="form-control" TextMode="MultiLine" Rows="4"></telerik:RadTextBox>
                </div>
            </div>

            <div class="row form-group">
                <div class="col-md-2">
                    <label class=" col-form-label">試用開始日期</label>
                    <!--<span class="float-right title_right">人資部</span>-->
                    <telerik:RadLabel runat="server" ID="lblTrialDateB" CssClass="form-control"></telerik:RadLabel>
                    <%--<div class="input-group date">
                                                        <input type="text" class="form-control" value="2021/2/17">
                                                        <span class="input-group-addon"><i class="fa fa-calendar form_icon"></i></span>
                                                    </div>--%>
                </div>

                <div class="col-md-2">
                    <label class=" col-form-label">試用結束日期</label>
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

            <div class="row form-group">
               <div class="col-md-2">
                            <label class=" col-form-label">事假時數</label>
                            <telerik:RadLabel runat="server" ID="lblPersonalLeave" CssClass="form-control" Text="0"></telerik:RadLabel>
                        </div>

               <div class="col-md-2">
                            <label class=" col-form-label">病假時數</label>
                            <telerik:RadLabel runat="server" ID="lblSickLeave" CssClass="form-control" Text="0"></telerik:RadLabel>
                        </div>

               <div class="col-md-2">
                            <label class=" col-form-label">曠職時數</label>
                            <telerik:RadLabel runat="server" ID="lblAbsenteeism" CssClass="form-control" Text="0"></telerik:RadLabel>
                        </div>

               <div class="col-md-2">
                            <label class=" col-form-label">遲到次數</label>
                            <telerik:RadLabel runat="server" ID="lblLate" CssClass="form-control" Text="0"></telerik:RadLabel>
                        </div>

               <div class="col-md-2">
                            <label class=" col-form-label">早退次數</label>
                            <telerik:RadLabel runat="server" ID="lblEarlyOut" CssClass="form-control" Text="0"></telerik:RadLabel>
                        </div>
            </div>

            <%--<div class="row  form-group">
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
            </div>--%>
            <%--<div class="row form-group">
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

            <%--<div class="row m-t-lg m-b-md">
                <div class="col-md-12">
                    <div class="bg-muted  p-xs b-r-sm">試用期後考核</div>
                </div>
            </div>--%>





            <%--<div class="row form-group">
                <div class="col-md-12">
                    <label class=" col-form-label">新進人員之學習精神及工作態度、品行等之評核</label>
                    <telerik:RadTextBox runat="server" ID="txtPerformance1" EmptyMessage="請直接主管評核" Width="100%" Rows="3" TextMode="MultiLine" CssClass="form-control"></telerik:RadTextBox>

                </div>
            </div>

            <div class="row form-group">
                <div class="col-md-12">
                    <label class=" col-form-label">新進人員專業知識之評核</label>
                    <telerik:RadTextBox runat="server" ID="txtPerformance2" EmptyMessage="請直接主管評核" Width="100%" Rows="3" TextMode="MultiLine" CssClass="form-control"></telerik:RadTextBox>
                </div>

                
            </div>

            <div class="row form-group">
                <div class="col-md-12">
                    <label class=" col-form-label">綜合考核意見</label>
                    <telerik:RadTextBox runat="server" ID="txtPerformance3" EmptyMessage="請直接主管評核" Width="100%" Rows="3" TextMode="MultiLine" CssClass="form-control"></telerik:RadTextBox>
                </div>

                
            </div>
            <div class="row form-group">
                <div class="col-md-3">
                    <label class=" col-form-label">結果</label>
                    <telerik:RadComboBox runat="server" ID="ddlResult" Width="100%" Skin="Bootstrap"></telerik:RadComboBox>
                </div>
                <asp:Panel runat="server" ID="plExtend" CssClass="col-md-3" Width="100%" Visible="false">
                    <label class=" col-form-label">延長</label>
                    <telerik:RadTextBox runat="server" ID="txtExtend" Width="100%" CssClass="form-control" EmptyMessage="單位(月)"></telerik:RadTextBox>
                </asp:Panel>
            </div>
            <div class="row form-group">
                <div class="col-md-3">
                    <label class=" col-form-label">生效日期</label>

                    <telerik:RadDatePicker ID="txtEmployDate" runat="server" AutoPostBack="True" Skin="Bootstrap" Width="100%">
                    </telerik:RadDatePicker>
                </div>

                

                <div class="col-md-3">
                    <label class=" col-form-label">部門</label>

                    <telerik:RadTextBox runat="server" ID="txtDept" Width="100%" CssClass="form-control"></telerik:RadTextBox>

                </div>
                <div class="col-md-2">
                    <label class=" col-form-label">編制部門</label>

                    <telerik:RadTextBox runat="server" ID="lblDeptm" CssClass="form-control"></telerik:RadTextBox>

                </div>

                <div class="col-md-2">
                    <label class=" col-form-label">職等</label>

                    <telerik:RadTextBox runat="server" ID="lblJob" CssClass="form-control"></telerik:RadTextBox>

                </div>

                <div class="col-md-2">
                    <label class=" col-form-label">職稱</label>

                    <telerik:RadTextBox runat="server" ID="lblJobName" CssClass="form-control"></telerik:RadTextBox>
                </div>
            </div>--%>

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
                            <telerik:RadLabel runat="server" ID="SalaryName" Text='<%# Eval("SalName") %>'></telerik:RadLabel>
                        </td>
                        <td>
                            <telerik:RadLabel runat="server" ID="Amount" Text='<%# Eval("Amount") %>'></telerik:RadLabel>
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    目前並無任何薪資資料
                </EmptyDataTemplate>

            </telerik:RadListView>
            
            <div class="hr-line-dashed"></div>
            
            <div class="row">
                <div class="col-lg-1">
                    <telerik:RadButton runat="server" ID="btnCheck" Text="確認" CssClass="btn-primary btn-outline" OnClick="btnCheck_Click"></telerik:RadButton>
                </div>
                <div class="col-lg-8">
                    <telerik:RadLabel runat="server" ID="lblCheckMsg" CssClass="text-danger"></telerik:RadLabel>
                </div>
            </div>
            
            
            <%--<div class="row  form-group">
                <div class="col-md-2">
                    <label class=" col-form-label">本薪</label>

                    <input type="text" class="form-control" value="-">
                </div>

                <div class="col-md-2">
                    <label class=" col-form-label">職務津貼</label>

                    <input type="text" class="form-control" value="-">
                </div>

                <div class="col-md-2">
                    <label class=" col-form-label">伙食津貼</label>

                    <input type="text" class="form-control" value="-">
                </div>
                <div class="col-md-2">
                    <label class=" col-form-label">特殊津貼</label>

                    <input type="text" class="form-control" value="-">
                </div>
                <div class="col-md-2">
                    <label class=" col-form-label">外勤津貼</label>

                    <input type="text" class="form-control" value="-">
                </div>

                <div class="col-md-2">
                    <label class=" col-form-label">區域津貼</label>

                    <input type="text" class="form-control" value="-">
                </div>
            </div>--%>

            <%--<div class="row form-group">
                <div class="col-md-2">
                    <label class=" col-form-label">差勤津貼</label>

                    <input type="text" class="form-control" value="-">
                </div>

                <div class="col-md-2 form-group">
                    <label class=" col-form-label">績效津貼</label>

                    <input type="text" class="form-control" value="-">
                </div>
                <div class="col-md-2 form-group">
                    <label class=" col-form-label">技術津貼</label>

                    <input type="text" class="form-control" value="-">
                </div>

                <div class="col-md-2">
                    <label class=" col-form-label">總額</label>

                    <input type="text" class="form-control" value="-">
                </div>

            </div>--%>

            <asp:Label ID="lblNobrAppS" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblNameAppM" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblNobrAppM" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblRoleAppM" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblDeptNameAppM" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblDeptCodeAppM" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblDeptaCodeAppM" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblJobNameAppM" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblJobCodeAppM" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblJoblCodeAppM" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblProcessID" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblFlowTreeID" runat="server" Visible="False"></asp:Label>
        </telerik:RadAjaxPanel>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
    <script src="Templates/Inspinia/js/plugins/footable/footable.all.min.js"></script>
    <%--<script type="text/javascript">
        document.getElementById("ctl00_ContentPlaceHolder1_btnSearch").onclick = function () { Jump() };

        function Jump() {
            //window.location.href = "#iboxContent";
            document.getElementById("iboxContent").scrollIntoView();
        }
    </script>--%>
    <script>
        $(document).ready(function () {
            $('.footable').footable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphCondition" runat="server">
    <div class="ibox ">
        <div class="ibox-title">
            <h5>條件</h5>
            <div class="ibox-tools">
                <a class="collapse-link">
                    <i class="fa fa-chevron-up"></i>
                </a>
            </div>
        </div>
        <div class="ibox-content">
            <div class="row">
                <%--<div class="col-md-3">
                    <label class=" col-form-label">部門</label>
                    <select class="select2_demo_1 form-control" style="width: 100%">
                        <option value="1">人資部</option>
                        <option value="2">People 2</option>
                        <option value="3">People 3</option>
                        <option value="4">People 4</option>
                        <option value="5">People 5</option>
                    </select>
                </div>--%>
                <div class="col-md-3">

                    <label class="col-form-label">員工工號</label>
                    <%--<telerik:RadMultiSelect runat="server" Skin="Bootstrap"
                                        Placeholder="請選擇..."
                                        AutoClose="false"
                                        TagMode="Multiple"
                                        Width="100%"
                                        ID="ddlEmp"/>--%>
                    <telerik:RadComboBox runat="server" Skin="Bootstrap" AutoPostBack="false"
                        Placeholder="請選擇..."
                        AutoClose="false"
                        TagMode="Single"
                        Width="100%"
                        ID="ddlEmp" OnSelectedIndexChanged="ddlEmp_SelectedIndexChanged"
                        AllowCustomText="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains" LoadingMessage="載入中…" />
                </div>

                <div class="col-sm-2 form-inline m-t-lg">
                    <telerik:RadButton ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click" CssClass="btn btn-primary btn-sm" />
                </div>
                <div>
                    <telerik:RadLabel ID="lblMsg" runat="server" />
                </div>
            </div>
            
            <div class="form-group row">
                
            </div>
        </div>
    </div>
</asp:Content>
