<%@ Page Title="" Language="C#" MasterPageFile="~/MainFlowFormsChk.master" AutoEventWireup="true" CodeBehind="FormOtChk.aspx.cs" Inherits="Portal.FormOtChk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="ibox">
        <div class="ibox-content">
            <telerik:RadAjaxPanel ID="plInfo" runat="server">
                <telerik:RadListView ID="gvAppS" runat="server" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="gvAppS_NeedDataSource" OnItemDataBound="gvAppS_ItemDataBound">
                    <LayoutTemplate>
                        <table id="footableTaken" class="footable table table-stripped" data-page-size="10" data-filter="#filterTaken">
                            <thead>
                            </thead>
                            <tbody id="Container" runat="server">
                            </tbody>
                            <tfoot>
                            </tfoot>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div class="keyin keyin-border">
                            <div class="row">
                                <div class="col-md-2 m-t-xs">
                                    <h3>
                                        <%# Eval("EmpName") %>,
                                    <%# Eval("EmpId") %>
                                    </h3>
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col col-xs-6">
                                            <span><telerik:RadLabel runat="server" ID="lblBeginDateDic" Text="開始日期"></telerik:RadLabel>：<%# Eval("DateB","{0:yyyy/MM/dd}") %></span><br>
                                            <span><telerik:RadLabel runat="server" ID="lblBeginTimeDic" Text="開始時間"></telerik:RadLabel>：<%# Eval("TimeB") %></span>
                                        </div>

                                        <div class="col col-xs-6">
                                            <span><telerik:RadLabel runat="server" ID="lblEndDateDic" Text="結束日期"></telerik:RadLabel>：<%# Eval("DateE","{0:yyyy/MM/dd}") %></span><br>
                                            <span><telerik:RadLabel runat="server" ID="lblEndTimeDic" Text="結束時間"></telerik:RadLabel>：<%# Eval("TimeE") %></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="row">
                                        <div class="col col-xs-4">
                                            <span><telerik:RadLabel runat="server" ID="lblOverTimeClassDic" Text="加班班別"></telerik:RadLabel> ：<%# Eval("RoteName") %></span><br>
                                            <span><telerik:RadLabel runat="server" ID="lblReasonDic" Text="加班原因"></telerik:RadLabel>：<%# Eval("OtrcdName") %></span>
                                        </div>

                                        <div class="col col-xs-4">
                                            <span><telerik:RadLabel runat="server" ID="lblOtHourDic" Text="申請時數"></telerik:RadLabel> ：<%# Eval("Use") %></span><br>
                                            <span><telerik:RadLabel runat="server" ID="lblUnitDic" Text="單位"></telerik:RadLabel>：<%# Eval("UnitCode") %></span>
                                        </div>
                                        <div class="col col-xs-4">
                                            <span> <telerik:RadLabel runat="server" ID="lblOtPaymentDic" Text="給付方式"></telerik:RadLabel> ：<%# Eval("OtCateName") %></span><br>
                                            <span style="word-break: break-all;"><telerik:RadLabel runat="server" ID="lblNoteDic" Text="備註"></telerik:RadLabel>：<%# Eval("Note") %></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-1">
                                    <telerik:RadRadioButtonList runat="server" ID="btnCheck" FeatureGroupID='<%# Eval("AutoKey") %>' ToolTip='<%# Eval("SignState") %>' OnSelectedIndexChanged="btnCheck_SelectedIndexChanged">
                                        <Items>
                                            <telerik:ButtonListItem Text="核准" Value="1" Selected="true" />
                                            <telerik:ButtonListItem Text="駁回" Value="2" />
                                        </Items>
                                    </telerik:RadRadioButtonList>
                                </div>
                            </div>
                        </div>
                        <%--<tr class="gradeX">
                                    <td>
                                        <telerik:RadButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("AutoKey") %>' CssClass="btn btn-w-m btn-danger"
                                            CommandName="Del" Text="刪除">
                                        </telerik:RadButton>
                                    </td>
                                    <td>
                                        <telerik:RadButton ID="btnUpload" runat="server" CssClass="btn btn-primary" CommandArgument='<%# Eval("AutoKey") %>' CommandName="Upload" data-toggle="modal" data-target="#myModal" Text="附件上傳">
                                        </telerik:RadButton>
                                    </td>
                                    <td><%# Eval("EmpId") %></td>
                                    <td><%# Eval("EmpName") %></td>
                                    <td><%# Eval("DateB") %></td>
                                    <td><%# Eval("DateE") %></td>
                                    <td><%# Eval("TimeE") %></td>
                                    <td><%# Eval("HolidayName") %></td>
                                    <td><%# Eval("Use") %></td>
                                    <td><%# Eval("UnitCode") %></td>
                                    <td><%# Eval("AgentEmpName") %></td>
                                    <td>
                                        <telerik:RadLabel ID="lblGuid" runat="server" Visible="false" Text='<%# Eval("Code") %>'></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <telerik:RadLabel ID="lbliAutoKey" runat="server" Visible="false" Text='<%# Eval("AutoKey") %>'></telerik:RadLabel>
                                    </td>
                                </tr>--%>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        出現異常，請通知HR
                    </EmptyDataTemplate>
                </telerik:RadListView>
                <telerik:RadLabel ID="lblNotifyMsg" runat="server" Style="color: red;" Text=""></telerik:RadLabel>
            </telerik:RadAjaxPanel>
            <div class="row">
                <div class="col-lg-12">
                    <label class=" col-form-label "><telerik:RadLabel runat="server" ID="lblOpinionDic" Text="意見"></telerik:RadLabel></label>
                    <telerik:RadTextBox ID="txtNote" runat="server" Skin="Bootstrap"
                        Height="50px" TextMode="MultiLine" Width="100%">
                    </telerik:RadTextBox>
                </div>
            </div>
            <div class="hr-line-dashed"></div>
            <div class="row">
                <div class="col-lg-12">
                    <h5><telerik:RadLabel runat="server" ID="lblSignPathDic" Text="簽核過程"></telerik:RadLabel></h5>
                    <div>
                        <telerik:RadListView ID="lvSignM" runat="server" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="lvSignM_NeedDataSource">
                            <LayoutTemplate>
                                <table id="footableTaken" class="footable table table-stripped" data-page-size="10" data-filter="#filterTaken">
                                    <thead>
                                        <%-- <tr>
                                            <td colspan="2" style="text-align: center">動作</td>
                                            
                                            <th>時間</th>
                                            <th>假別</th>
                                            <th>使用</th>
                                            <th>單位</th>
                                            <th>代理人</th>
                                        </tr>--%>
                                        <th><telerik:RadLabel runat="server" ID="lblSignManagerDic" Text="簽核主管"></telerik:RadLabel></th>
                                        <th><telerik:RadLabel runat="server" ID="lblSignDeptDic" Text="簽核部門"></telerik:RadLabel></th>
                                        <th><telerik:RadLabel runat="server" ID="lblSignDateDIc" Text="簽核日期"></telerik:RadLabel></th>
                                        <th><telerik:RadLabel runat="server" ID="lblOpinionDic1" Text="意見"></telerik:RadLabel></th>
                                    </thead>
                                    <tbody id="Container" runat="server">
                                        <tr>
                                            <td>test
                                            </td>
                                        </tr>
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
                                    <td><%# Eval("EmpName") %>,<%# Eval("EmpId") %></td>
                                    <td><%# Eval("DeptName") %></td>
                                    <td><%# Eval("InsertDate") %></td>
                                    <td><%# Eval("SignNote") %></td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <telerik:RadLabel runat="server" ID="lblManagerSignRecordDic" Text="尚未有主管簽核紀錄"></telerik:RadLabel>
                            </EmptyDataTemplate>
                        </telerik:RadListView>
                    </div>
                </div>
            </div>

            <div class="hr-line-dashed"></div>
        </div>
    </div>

    <div style="display: none">
        <telerik:RadLabel ID="lblProcessID" runat="server" Visible="false"></telerik:RadLabel>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
