<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FormSign.aspx.cs" Inherits="Portal.FormSign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plFlowSignMain" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbCheckAll">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plFlowSignMain" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAccept">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plFlowSignMain" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="plCond" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnReject">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plFlowSignMain" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="plCond" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="wrapper wrapper-content animated fadeInRight">

        <div class="row">
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="control control-style2">
                        <telerik:RadAjaxPanel runat="server" ID="plFlowViewEmp">
                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <label class="col-form-label">表單名稱</label>
                                    <telerik:RadComboBox ID="ddlForm" runat="server" CssClass="formItem" Culture="zh-TW" Skin="Bootstrap" Width="100%"
                                        LoadingMessage="載入中…" AppendDataBoundItems="True">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Owner="txtFlowForm" Selected="True" Text="All"
                                                Value="0" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </div>
                                <div class="col-sm-4">
                                    <label class=" col-form-label">模糊條件</label>
                                    <telerik:RadTextBox ID="txtCond" runat="server" Skin="Bootstrap" Width="100%" />
                                </div>
                                <div class="col-sm-1 form-inline m-t-lg">
                                    <telerik:RadButton runat="server" ID="btnSearch" OnClick="btnSearch_Click" CssClass="btn btn-primary" Text="查詢"></telerik:RadButton>
                                </div>
                                <telerik:RadLabel runat="server" ID="lblMsg" CssClass="badge badge-danger animated shake"></telerik:RadLabel>
                            </div>

                            <div class="hr-line-dashed"></div>
                            <telerik:RadAjaxPanel runat="server" ID="plCond">
                                <div class="form-group row">
                                    <div class="col-sm-1">
                                        <label class="col-form-label">
                                            <telerik:RadCheckBox ID="cbCheckAll" OnCheckedChanged="cbCheckAll_CheckedChanged" runat="server"></telerik:RadCheckBox>
                                            全選
                                        </label>
                                    </div>

                                    <div class="col-sm-1 form-inline m-t-s">
                                        <telerik:RadButton ID="btnAccept" OnClick="btnAccept_Click" runat="server" Text="核准" CssClass="btn btn-primary">
                                        </telerik:RadButton>

                                    </div>

                                    <div class="col-sm-1 form-inline m-t-s">
                                        <telerik:RadButton ID="btnReject" OnClick="btnReject_Click" runat="server" Text="駁回" CssClass="btn btn-danger">
                                        </telerik:RadButton>
                                    </div>
                                </div>
                            <telerik:RadLabel ID="lblMessage" runat="server"></telerik:RadLabel>
                            </telerik:RadAjaxPanel>
                        </telerik:RadAjaxPanel>

                    </div>
                </div>
                <telerik:RadAjaxPanel runat="server" ID="plFlowSignMain" LoadingPanelID="RadAjaxLoadingPanel1">
                    <%-- 修改開始  --%>
                    <div class="ibox-title">
                        <h5>流程資訊</h5>
                        <div class="float-right">
                            <a class="allopen"  data-toggle="collapse" data-target=".multi-collapse" aria-expanded="true">全部展開</a>
                        </div>
                    </div>
                     <%-- 修改結束  --%>

                    <div class="ibox-content">

                        <telerik:RadListView runat="server" ID="lvFlowSignMain" OnItemCommand="lvFlowSignMain_ItemCommand" OnNeedDataSource="lvFlowSignMain_NeedDataSource" ItemPlaceholderID="Container">
                            <LayoutTemplate>
                                <table class="footable table table-stripped" data-page-size="10">
                                    <thead>
                                    </thead>
                                    <tbody id="Container" runat="server">
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <td colspan="1" style="border-top: 0;">
                                                <ul class="pagination float-right"></ul>
                                            </td>
                                        </tr>
                                    </tfoot>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr class="gradeX">
                                    <td style="background-color: #FFFFFF; border-top: 0;">
                                        <div class="flow-item">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="row">
                                                        <div class="col-lg-1 m-t-s">
                                                            <label class="p-xs">
                                                                <telerik:RadCheckBox runat="server" Skin="Bootstrap" AutoPostBack="false" ID="cbForm" CommandArgument='<%#Eval("ProcessFlowId") %>' CommandName="Select"></telerik:RadCheckBox>
                                                            </label>
                                                        </div>
                                                        <div class="col-lg-8">
                                                            <div class="row">
                                                                <div class="col-lg-4">
                                                                    <span>流程序號：
                                                                        <telerik:RadLabel ID="lblProcessId" runat="server" Text='<%#Eval("ProcessFlowId") %>'></telerik:RadLabel>
                                                                        <telerik:RadLabel ID="lblAp" Visible="false" runat="server" Text='<%#Eval("ProcessApParmAuto") %>'></telerik:RadLabel>
                                                                        <telerik:RadLabel ID="lblFormCode" Visible="false" runat="server" Text='<%#Eval("FormCode") %>'></telerik:RadLabel>
                                                                    </span>
                                                                </div>
                                                                <div class="col-lg-4">
                                                                    <span>表單名稱：<%#Eval("FormName") %></span>
                                                                </div>
                                                                <div class="col-lg-4">
                                                                    <span>申請人：<%#Eval("AppEmpID") + "," + Eval("AppEmpName") %></span>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-lg-4">
                                                                    <span>流程開始時間：<%#Eval("AppDate","{0:yyyy/MM/dd HH:mm}") %>　</span>
                                                                </div>
                                                                <div class="col-lg-4">
                                                                    <%--上次簽核時間：<%#Eval("AppDateD","{0:yyyy/MM/dd HH:mm}") %>　</span>--%>
                                                                </div>
                                                                <div class="col-lg-4">
                                                                    <%--<span>共計：<%#Eval("Use") %><%#Eval("Unit") %></span><br>
                                                                    <span>代理人：<%#Eval("Agent") %></span>--%>
                                                                    <%-- <span>備註：<%#Eval("Info") %></span>--%>
                                                                </div>
                                                            </div>
                                                            <%--<div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="row m-t-xs">
                                                                        <div class="col col-xs-6">
                                                                            <span>流程序號：<telerik:RadLabel ID="lblProcessId" runat="server" Text='<%#Eval("ProcessId") %>'></telerik:RadLabel>
                                                                            </span>
                                                                            <br>
                                                                            <span>表單名稱：<%#Eval("FlowName") %></span>
                                                                        </div>
                                                                        <div class="col col-xs-6">
                                                                            <span>申請人：<%#Eval("Application") %></span><br>
                                                                            <%--<span>申請日期：<%#Eval("ADate","{0:yyyy/MM/dd}") %></span>--%>
                                                            <%--</div>
                                                                    </div>
                                                                </div>

                                                                <div class="col-md-5">
                                                                    <div class="row m-t-xs">
                                                                        <div class="col col-xs-6">
                                                                            <span>流程開始時間：<%#Eval("DateB","{0:yyyy/MM/dd HH:mm}") %>　</span>
                                                                            <br>
                                                                            <span>流程結束時間：<%#Eval("DateE","{0:yyyy/MM/dd HH:mm}") %>　</span>
                                                                        </div>
                                                                        <div class="col col-xs-6">
                                                                   
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>--%>
                                                        </div>
                                                        <div class="col-lg-2 m-t-xs">
                                                            <%--<telerik:RadButton ID="RadButton1" runat="server" CssClass="btn btn-outline btn-success" Text="檢視" CommandArgument='<%#Eval("FlowId") %>' CommandName='<%#Eval("FlowCode") %>'></telerik:RadButton>--%>
                                                            <telerik:RadButton ID="btnViewImage" runat="server" CssClass="btn btn-outline btn-info" Text="流程" CommandArgument='<%#Eval("ProcessFlowId") %>' CommandName="ViewImage"></telerik:RadButton>

                                                        </div>
                                                    </div>
                                                    <a data-toggle="collapse" href='<%# "#pl" + Eval("ProcessFlowId") %>' class="flow-question collapsed"></a>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <%-- 修改開始  --%><div id='<%# "pl" + Eval("ProcessFlowId") %>' class="panel-collapse collapse multi-collapse"><%-- 修改結束  --%>
                                                        <div class="flow-answer">
                                                            <div class="row col-lg-12">
                                                                <p>
                                                                    <telerik:RadLabel ID="RadLabel3" runat="server" Text='<%#Eval("Detail") %>' />
                                                                </p>
                                                            </div>
                                                            <%--<div class="row col-lg-12">
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel3" runat="server" Text="姓名：許名瑤,A0550" />
                                                                </div>
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel4" runat="server" Text="開始日期：2021//05/07 08:30" />
                                                                </div>
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel42" runat="server" Text="結束日期：2021//05/07 17:30" />
                                                                </div>
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel6" runat="server" Text="假別：V001特休假" />
                                                                </div>
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel7" runat="server" Text="時數：8h" />
                                                                </div>
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel8" runat="server" Text="代理人：王大明,A0000" />
                                                                </div>
                                                               
                                                            </div>--%>

                                                            <%--<div class="b-b"></div>

                                                            <div class="row col-lg-12">
                                                                <div  class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel1" runat="server" Text="姓名：許名瑤,A0550" />
                                                                </div>
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel9" runat="server" Text="開始日期：2021/05/07 08:30" />
                                                                </div>
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel10" runat="server" Text="結束日期：2021/05/07 17:30" />
                                                                </div>
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel11" runat="server" Text="給付方式：加班費" />
                                                                </div>
                                                                <div  class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel12" runat="server" Text="時數：3h" />
                                                                </div>
                                                                <div  class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel13" runat="server" Text="加班類別：V001配合生產" />
                                                                </div>
                                                               
                                                            </div>

                                                            <div class="b-b"></div>

                                                            <div class="row col-lg-12">
                                                                <div  class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel14" runat="server" Text="姓名：許名瑤,A0550" />
                                                                </div>
                                                                <div  class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel15" runat="server" Text="開始日期：2021//05/07 08:30" />
                                                                </div>

                                                                <div  class="line_r"">
                                                                    <telerik:RadLabel ID="RadLabel16" runat="server" Text="結束日期：2021//05/07 17:30" />
                                                                </div>
                                                                <div  class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel17" runat="server" Text="假別：V001公假" />
                                                                </div>
                                                                <div  class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel18" runat="server" Text="時數：3h" />
                                                                </div>
                                                                <div  class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel19" runat="server" Text="代理人：王大明,A0000" />
                                                                </div>
                                                               
                                                            </div>

                                                            <div class="b-b"></div>

                                                            <div class="row col-lg-12">
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel20" runat="server" Text="姓名：許名瑤,A0550" />
                                                                </div>
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel21" runat="server" Text="忘刷日期：2021//05/07" />
                                                                </div>

                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel41" runat="server" Text="忘刷時間：08:30" />
                                                                </div>

                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel22" runat="server" Text="忘刷原因：忘記刷卡" />
                                                                </div>
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel23" runat="server" Text="忘刷次數：3次" />
                                                                </div>

                                                            </div>

                                                            <div class="b-b"></div>

                                                            <div class="row col-lg-12">
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel24" runat="server" Text="姓名：許名瑤,A0550" />
                                                                </div>
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel25" runat="server" Text="調班日期：2021//05/07" />
                                                                </div>
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel26" runat="server" Text="調班班型：D73-08:00-17:00 二小時彈性班" />
                                                                </div>
                                                               

                                                            </div>

                                                            <div class="b-b"></div>

                                                            <div class="row col-lg-12">
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel27" runat="server" Text="姓名：許名瑤,A0550" />
                                                                </div>
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel28" runat="server" Text="原班別日期：2021//05/07" />
                                                                </div>
                                                                <div class="line_r"">
                                                                    <telerik:RadLabel ID="RadLabel29" runat="server" Text="目前班別：D73-08:00-17:00 二小時彈性班" />
                                                                </div>
                                                                <div class="line_r"">
                                                                    <telerik:RadLabel ID="RadLabel30" runat="server" Text="換班日期：2021//05/09" />
                                                                </div>
                                                                <div class="line_r"">
                                                                    <telerik:RadLabel ID="RadLabel31" runat="server" Text="調換班型：D73-08:00-17:00 二小時彈性班" />
                                                                </div>
                                                                <div class="line_r"">
                                                                    <telerik:RadLabel ID="RadLabel5" runat="server" Text="換班姓名：王大明,A0550" />
                                                                </div>
                                                            </div>

                                                            <div class="b-b"></div>

                                                            <div class="row col-lg-12">
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel32" runat="server" Text="姓名：許名瑤,A0550" />
                                                                </div>
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel33" runat="server" Text="開始日期：2021//05/07" />
                                                                </div>
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel34" runat="server" Text="結束日期：2021//05/07" />
                                                                </div>
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel35" runat="server" Text="假別：A002銷假單" />
                                                                </div>
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel36" runat="server" Text="時數：8小時" />
                                                                </div>
                                                               
                                                               
                                                            </div>

                                                            <div class="b-b"></div>

                                                            <div class="row col-lg-12">
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel37" runat="server" Text="姓名：許名瑤,A0550" />
                                                                </div>
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel38" runat="server" Text="日期：2021//05/07" />
                                                                </div>
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel39" runat="server" Text="註記類別：早來" />
                                                                </div>
                                                                <div class="line_r">
                                                                    <telerik:RadLabel ID="RadLabel40" runat="server" Text="時間：10分鐘" />
                                                                </div>
                                                                
                                                               
                                                            </div>--%>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                        </div>
                                    </td>
                                </tr>

                            </ItemTemplate>
                            <EmptyDataTemplate>
                                無流程資料
                            </EmptyDataTemplate>
                        </telerik:RadListView>
                    </div>
                </telerik:RadAjaxPanel>
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
