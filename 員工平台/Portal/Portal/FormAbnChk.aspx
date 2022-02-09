<%@ Page Title="" Language="C#" MasterPageFile="~/MainFlowFormsChk.master" AutoEventWireup="true" CodeBehind="FormAbnChk.aspx.cs" Inherits="Portal.FormAbnChk" %>

<%@ Register Src="~/UserControls/UC_FileView.ascx" TagPrefix="uc" TagName="FileView" %>

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
                                        <%# Eval("EmpName") %>，<%# Eval("EmpId") %>
                                    </h3>
                                </div>
                                <div class="col-md-5">
                                    <div class="row">
                                        <div class="col col-xs-6">
                                            <span><telerik:RadLabel runat="server" ID="lblWorkDateDic" Text="日期" ></telerik:RadLabel>：<%# Eval("DateB","{0:yyyy/MM/dd}") %></span><br>
                                        </div>

                                        <div class="col col-xs-6">
                                            <span><telerik:RadLabel runat="server" ID="lblAbnormalDic" Text="異常" ></telerik:RadLabel>：<%# Eval("IsEarlyWork").ToString() == "True" ? "早到" + Eval("EarlyWorkMin") + "分鐘" :"" %> 
                                                        <%# Eval("IsEarlyWork").ToString() == "True" && Eval("IsLateOut").ToString()=="True" ? "，" :"" %> 
                                                        <%# Eval("IsLateOut").ToString() == "True" ? "晚退" + Eval("LateOutMin") + "分鐘" :"" %> 
                                            </span><br>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col col-xs-6">
                                            <span><telerik:RadLabel runat="server" ID="lblReasonDic" Text="申請原因"></telerik:RadLabel>：<%# Eval("Note") %></span><br>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-1">
                                    <telerik:RadRadioButtonList runat="server" ID="btnCheck" FeatureGroupID='<%# Eval("AutoKey") %>' ToolTip='<%# Eval("SignState") %>' OnSelectedIndexChanged="btnCheck_SelectedIndexChanged">
                                        <Items>
                                            <telerik:ButtonListItem Text="核准" Value="1" Selected="true" />
                                            <telerik:ButtonListItem Text="駁回" Value="2" />
                                        </Items>
                                    </telerik:RadRadioButtonList>
                                    <telerik:RadButton ID="btnUpload" runat="server" Visible="false" CssClass="btn btn-outline btn-warning" CommandArgument='<%# Eval("AutoKey") %>' CommandName="Upload" data-toggle="modal" data-target="#myModal" Text="附件" OnClick="btnUpload_Click">
                                    </telerik:RadButton>
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
        </div>
        <uc:FileView ID="ucFileView" runat="server" />

    </div>
    <div style="display: none">
        <telerik:RadLabel ID="lblProcessID" runat="server" Visible="false"></telerik:RadLabel>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
