<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SalarySearch.aspx.cs" Inherits="Portal.SalarySearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .table > thead > tr > th, .table > tbody > tr > th, .table > tfoot > tr > th, .table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td {
            border-top: 0;
        }

        .bg_color {
            background-color: #F5F5F6;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script language="javascript" type="text/javascript">
            function exportElement() {
                var exp = $find("<%= RadClientExportManager1.ClientID %>");
                exp.exportPDF($telerik.$("#<%= phPdf.ClientID %>"));
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadClientExportManager runat="server" ID="RadClientExportManager1">
        <PdfSettings MarginTop="20mm" MarginBottom="20mm" MarginLeft="20mm" MarginRight="20mm" />
    </telerik:RadClientExportManager>
    <telerik:RadAjaxManagerProxy runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                    <telerik:AjaxUpdatedControl ControlID="lvMain" />
                    <telerik:AjaxUpdatedControl ControlID="txtSalaryPassword" />
                    <telerik:AjaxUpdatedControl ControlID="btnExportPdf" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
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
                        <%--<div class="row float-right">
                            <telerik:RadAjaxPanel runat="server">
                                <telerik:RadButton ID="btnSalaryPassword" runat="server" data-toggle="modal" data-target="#myModal" Text="設定薪資密碼" CssClass="btn btn-primary btn-sm">
                                </telerik:RadButton>
                            </telerik:RadAjaxPanel>
                        </div>--%>
                        <div class="form-group row">
                            <div class="col-md-3">
                                <label class="col-form-label">選擇期間</label>
                                <telerik:RadComboBox runat="server" Width="100%" Skin="Bootstrap" ID="ddlPeriod" OnSelectedIndexChanged="ddlPeriod_SelectedIndexChanged" EmptyMessage="請選擇區間"></telerik:RadComboBox>
                            </div>
                            <div class="col-md-3">
                                <label class=" col-form-label">薪資密碼</label>
                                <telerik:RadTextBox runat="server" TextMode="Password" Width="100%" Skin="Bootstrap" ID="txtSalaryPassword"></telerik:RadTextBox>
                            </div>
                            <div class="col-md-3">
                                <label class=" col-form-label">&nbsp;</label>
                                <telerik:RadAjaxPanel runat="server" Width="100%">
                                    <div class="input-group date">
                                        <telerik:RadButton ID="btnSalaryPassword" runat="server" data-toggle="modal" data-target="#myModal" Text="設定薪資密碼" CssClass="btn btn-outline btn-primary">
                                        </telerik:RadButton>
                                    </div>
                                </telerik:RadAjaxPanel>
                            </div>
                        </div>
                        <div class="hr-line-dashed"></div>
                        <div class="col-sm-2 m-t-sm">
                            <telerik:RadButton ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click" CssClass="btn btn-primary btn-sm" />
                            <telerik:RadLabel ID="lblMsg" CssClass="badge" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-12">
                <div class="ibox">
                    <div id="iboxContent" class="ibox-title">
                        <h5>內容</h5>
                        <div class="ibox-tools">

                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                            <a class="fullscreen-link">
                                <i class="fa fa-expand"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">

                        <telerik:RadAjaxPanel Visible="false" runat="server" ID="plMain">
                            <telerik:RadButton ID="btnExportPdf" runat="server" Text="匯出PDF" OnClientClicking="exportElement" CssClass="btn btn-w-m btn-info" />
                            <asp:Panel ID="phPdf" runat="server">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="ibox">
                                            <div class="ibox-content">
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <h2 class="text-center"><strong>薪資單</strong></h2>
                                                    </div>
                                                </div>
                                                <div class="row m-t-lg">
                                                    <div class="col-lg-3">
                                                        <table class="table">
                                                            <tbody>
                                                                <tr>
                                                                    <td>部門</td>
                                                                    <td class="text-right">
                                                                        <telerik:RadLabel runat="server" ID="lblSalaryDept"></telerik:RadLabel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>員工編號</td>
                                                                    <td class="text-right">
                                                                        <telerik:RadLabel runat="server" ID="lblSalaryName"></telerik:RadLabel>
                                                                    </td>
                                                                </tr>

                                                            </tbody>
                                                        </table>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <table class="table">
                                                            <tbody>
                                                                <tr>
                                                                    <td>職稱</td>
                                                                    <td class="text-right">
                                                                        <telerik:RadLabel runat="server" ID="lblSalaryPosition"></telerik:RadLabel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>轉帳日期</td>
                                                                    <td class="text-right">
                                                                        <telerik:RadLabel runat="server" ID="lblSalaryTransDate"></telerik:RadLabel>
                                                                    </td>
                                                                </tr>


                                                            </tbody>
                                                        </table>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <table class="table">
                                                            <tbody>
                                                                <tr>
                                                                    <td>出勤起始日期</td>
                                                                    <td class="text-right">
                                                                        <telerik:RadLabel runat="server" ID="lblSalaryAttendDateB"></telerik:RadLabel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>出勤結束日期</td>
                                                                    <td class="text-right">
                                                                        <telerik:RadLabel runat="server" ID="lblSalaryAttendDateE"></telerik:RadLabel>
                                                                    </td>
                                                                </tr>


                                                            </tbody>
                                                        </table>
                                                    </div>

                                                    <div class="col-lg-3">
                                                        <table class="table">
                                                            <tbody>
                                                                <tr>
                                                                    <td>特休剩餘時數</td>
                                                                    <td class="text-right">
                                                                        <telerik:RadLabel runat="server" ID="lblSalaryAnnualHour"></telerik:RadLabel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>補休剩餘時數</td>
                                                                    <td class="text-right">
                                                                        <telerik:RadLabel runat="server" ID="lblSalaryCompensatoryHour"></telerik:RadLabel>
                                                                    </td>
                                                                </tr>


                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>

                                                <div class="row m-t-sm">
                                                    <div class="col-lg-6">
                                                        <div class="row">
                                                            <div class="col-lg-6">
                                                                <h4 class="p-xs bg-muted text-center">
                                                                    <telerik:RadLabel runat="server" ID="lblSalaryTitleEarnings"></telerik:RadLabel>
                                                                </h4>
                                                                <div class="row">
                                                                    <div class="col-sm-12">

                                                                        <telerik:RadListView runat="server" ItemPlaceholderID="Container" ID="lvSalaryBlockEarnings" OnNeedDataSource="lvSalaryBlockEarnings_NeedDataSource">
                                                                            <LayoutTemplate>
                                                                                <asp:PlaceHolder ID="Container" runat="server"></asp:PlaceHolder>
                                                                                <hr>
                                                                            </LayoutTemplate>
                                                                            <ItemTemplate>
                                                                                <span class="float-left"><%#Eval("Item") %></span><span class="float-right"><%#Eval("Salary") %></span><br />
                                                                            </ItemTemplate>
                                                                            <EmptyDataTemplate>
                                                                            </EmptyDataTemplate>
                                                                        </telerik:RadListView>
                                                                        <h4>
                                                                            <telerik:RadLabel runat="server" CssClass="float-right" ID="lblSalarySumEarnings"></telerik:RadLabel>
                                                                        </h4>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-lg-6">
                                                                <h4 class="p-xs bg-muted text-center">
                                                                    <telerik:RadLabel runat="server" ID="lblSalaryTitleDeduction"></telerik:RadLabel>
                                                                </h4>
                                                                <div class="row">
                                                                    <div class="col-sm-12">

                                                                        <telerik:RadListView runat="server" ItemPlaceholderID="Container" ID="lvSalaryBlockDeduction" OnNeedDataSource="lvSalaryBlockDeduction_NeedDataSource">
                                                                            <LayoutTemplate>
                                                                                <asp:PlaceHolder ID="Container" runat="server"></asp:PlaceHolder>
                                                                                <hr>
                                                                            </LayoutTemplate>
                                                                            <ItemTemplate>
                                                                                <span class="float-left"><%#Eval("Item") %></span><span class="float-right"><%#Eval("Salary") %></span><br />
                                                                            </ItemTemplate>
                                                                            <EmptyDataTemplate>
                                                                            </EmptyDataTemplate>
                                                                        </telerik:RadListView>
                                                                        <h4>
                                                                            <telerik:RadLabel runat="server" CssClass="float-right" ID="lblSalarySumDeduction"></telerik:RadLabel>
                                                                        </h4>
                                                                    </div>

                                                                    <%--<table class="table">
                                                                        <tbody>
                                                                            <tr>
                                                                                <th>請假扣款</th>
                                                                                <td class="float-right">833</td>

                                                                            </tr>
                                                                            <tr>
                                                                                <th>勞保費</th>
                                                                                <td class="float-right">799</td>

                                                                            </tr>
                                                                            <tr>
                                                                                <th>健保費</th>
                                                                                <td class="float-right">1,022</td>

                                                                            </tr>
                                                                            <tr>
                                                                                <th>福利金</th>
                                                                                <td class="float-right">162</td>
                                                                            </tr>
                                                                            <tr class="border-top">
                                                                                <th>總額</th>
                                                                                <td class="float-right">10,000</td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>--%>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-6">
                                                        <div class="row">
                                                            <div class="col-lg-6">
                                                                <h4 class="p-xs bg-muted text-center">
                                                                    <telerik:RadLabel runat="server" ID="lblSalaryTitleAbs"></telerik:RadLabel>
                                                                </h4>
                                                                <div class="row">
                                                                    <telerik:RadListView runat="server" ItemPlaceholderID="Container" ID="lvSalaryBlockAbs" OnNeedDataSource="lvSalaryBlockAbs_NeedDataSource">
                                                                        <LayoutTemplate>
                                                                            <div class="col-sm-12">
                                                                                <asp:PlaceHolder ID="Container" runat="server"></asp:PlaceHolder>
                                                                            </div>
                                                                            <hr>
                                                                        </LayoutTemplate>
                                                                        <ItemTemplate>
                                                                            <span class="float-left"><%#Eval("Item") %></span><span class="float-right"><%#Eval("Salary") %></span><br />
                                                                        </ItemTemplate>
                                                                        <EmptyDataTemplate>
                                                                        </EmptyDataTemplate>
                                                                    </telerik:RadListView>
                                                                </div>
                                                            </div>

                                                            <div class="col-lg-6">
                                                                <h4 class="p-xs bg-muted text-center">
                                                                    <telerik:RadLabel runat="server" ID="lblSalaryTitleSalary"></telerik:RadLabel>
                                                                </h4>
                                                                <div class="row">
                                                                    <telerik:RadListView runat="server" ItemPlaceholderID="Container" ID="lvSalaryBlockSalary" OnNeedDataSource="lvSalaryBlockSalary_NeedDataSource">
                                                                        <LayoutTemplate>
                                                                            <div class="col-sm-12">
                                                                                <asp:PlaceHolder ID="Container" runat="server"></asp:PlaceHolder>
                                                                            </div>
                                                                            <hr>
                                                                        </LayoutTemplate>
                                                                        <ItemTemplate>
                                                                            <span class="float-left"><%#Eval("Item") %></span><span class="float-right"><%#Eval("Salary") %></span><br />
                                                                        </ItemTemplate>
                                                                        <EmptyDataTemplate>
                                                                        </EmptyDataTemplate>
                                                                    </telerik:RadListView>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="row">
                                                            <div class="col-lg-6">
                                                                <h4 class="p-xs bg-muted text-center">
                                                                    <telerik:RadLabel runat="server" ID="lblSalaryTitleOt"></telerik:RadLabel>
                                                                </h4>
                                                                <div class="row">
                                                                    <telerik:RadListView runat="server" ItemPlaceholderID="Container" ID="lvSalaryBlockOt" OnNeedDataSource="lvSalaryBlockOt_NeedDataSource">
                                                                        <LayoutTemplate>
                                                                            <div class="col-sm-12">
                                                                                <asp:PlaceHolder ID="Container" runat="server"></asp:PlaceHolder>
                                                                            </div>
                                                                            <hr>
                                                                        </LayoutTemplate>
                                                                        <ItemTemplate>
                                                                            <span class="float-left"><%#Eval("Item") %></span><span class="float-right"><%#Eval("Salary") %></span><br />
                                                                        </ItemTemplate>
                                                                        <EmptyDataTemplate>
                                                                        </EmptyDataTemplate>
                                                                    </telerik:RadListView>
                                                                </div>
                                                            </div>

                                                            <div class="col-lg-6">
                                                                <asp:Panel runat="server" ID="plSalaryRetirement">
                                                                    <h4 class="p-xs bg-muted text-center">
                                                                        <telerik:RadLabel runat="server" ID="lblSalaryTitleRetirement"></telerik:RadLabel>
                                                                    </h4>
                                                                    <div class="row">
                                                                        <telerik:RadListView runat="server" ItemPlaceholderID="Container" ID="lvSalaryBlockRetirement" OnNeedDataSource="lvSalaryBlockRetirement_NeedDataSource">
                                                                            <LayoutTemplate>
                                                                                <div class="col-sm-12">
                                                                                    <asp:PlaceHolder ID="Container" runat="server"></asp:PlaceHolder>
                                                                                </div>
                                                                                <hr>
                                                                            </LayoutTemplate>
                                                                            <ItemTemplate>
                                                                                <span class="float-left"><%#Eval("Item") %></span><span class="float-right"><%#Eval("Salary") %></span><br />
                                                                            </ItemTemplate>
                                                                            <EmptyDataTemplate>
                                                                            </EmptyDataTemplate>
                                                                        </telerik:RadListView>
                                                                    </div>
                                                                </asp:Panel>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>


                                            </div>


                                            <div class="row m-t-lg">
                                                <div class="col-lg-12">

                                                    <h4>
                                                        <telerik:RadLabel runat="server" ID="lblSalaryNote"></telerik:RadLabel>
                                                    </h4>

                                                </div>

                                                <div class="col-lg-12 m-t-ms">
                                                    <h4 class="text-center">請同仁遵循薪資保密之政策，若有任何對薪資方面的疑問，請逕洽人事單位。</h4>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            <%--<div class="row">
                                <telerik:RadLabel runat="server" CssClass="badge-primary offset-1 col-10 text-center" ID="lblTitle">
                                </telerik:RadLabel>
                            </div>
                            <div class="row">
                                <telerik:RadLabel runat="server" CssClass="col-12 col-sm-6" ID="lblAnnual">
                                </telerik:RadLabel>
                                <telerik:RadLabel runat="server" CssClass="col-12 col-sm-6" ID="lblCompensatory">
                                </telerik:RadLabel>
                            </div>
                            <div class="row">
                                <telerik:RadLabel runat="server" CssClass="col-12 col-sm-6" ID="lblTransferDate">
                                </telerik:RadLabel>
                                <telerik:RadLabel runat="server" CssClass="col-12 col-sm-6" ID="lblAttPeriod">
                                </telerik:RadLabel>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 border-right border-bottom">
                                    <telerik:RadLabel runat="server" ID="lblTitle1" Font-Size="Larger" CssClass="badge-info offset-1 col-10 text-center"></telerik:RadLabel>
                                    <telerik:RadListView runat="server" ItemPlaceholderID="Container" ID="lvBlock1" OnNeedDataSource="lvBlock1_NeedDataSource">
                                        <LayoutTemplate>
                                            <div class="col">
                                                <asp:PlaceHolder ID="Container" runat="server"></asp:PlaceHolder>
                                            </div>
                                            <hr>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <span class="float-left"><%#Eval("Item") %></span><span class="float-right"><%#Eval("Salary") %></span><br />
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                        </EmptyDataTemplate>
                                    </telerik:RadListView>
                                    <div class="col">
                                        <span class="float-left">
                                            <telerik:RadLabel runat="server" ID="lblTotal1"></telerik:RadLabel>
                                        </span>
                                        <span class="float-right">
                                            <telerik:RadLabel runat="server" ID="lblTotalSalary1"></telerik:RadLabel>
                                        </span>
                                        <br />
                                    </div>
                                    <hr />
                                    <telerik:RadLabel runat="server" ID="lblTitle5" Font-Size="Larger" CssClass="badge-info offset-1 col-10 text-center"></telerik:RadLabel>
                                    <telerik:RadListView runat="server" ItemPlaceholderID="Container" ID="lvBlock5" OnNeedDataSource="lvBlock5_NeedDataSource">
                                        <LayoutTemplate>
                                            <div class="col">
                                                <asp:PlaceHolder ID="Container" runat="server"></asp:PlaceHolder>
                                            </div>
                                            <hr>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <span class="float-left"><%#Eval("Item") %></span><span class="float-right"><%#Eval("Salary") %></span><br />
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                        </EmptyDataTemplate>
                                    </telerik:RadListView>
                                    <div class="col">
                                        <span class="float-left">
                                            <telerik:RadLabel runat="server" ID="lblTotal5"></telerik:RadLabel>
                                        </span>
                                        <span class="float-right">
                                            <telerik:RadLabel runat="server" ID="lblTotalSalary5"></telerik:RadLabel>
                                        </span>
                                        <br />
                                    </div>
                                </div>
                                <div class="col-sm-3 border-right border-bottom">
                                    <telerik:RadLabel runat="server" ID="lblTitle2" Font-Size="Larger" CssClass="badge-info offset-1 col-10 text-center"></telerik:RadLabel>
                                    <telerik:RadListView runat="server" ItemPlaceholderID="Container" ID="lvBlock2" OnNeedDataSource="lvBlock2_NeedDataSource">
                                        <LayoutTemplate>
                                            <div class="col">
                                                <asp:PlaceHolder ID="Container" runat="server"></asp:PlaceHolder>
                                            </div>
                                            <hr>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <span class="float-left"><%#Eval("Item") %></span><span class="float-right"><%#Eval("Salary") %></span><br />
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                        </EmptyDataTemplate>
                                    </telerik:RadListView>
                                    <div class="col">
                                        <span class="float-left">
                                            <telerik:RadLabel runat="server" ID="lblTotal2"></telerik:RadLabel>
                                        </span>
                                        <span class="float-right">
                                            <telerik:RadLabel runat="server" ID="lblTotalSalary2"></telerik:RadLabel>
                                        </span>
                                        <br />
                                    </div>
                                </div>
                                <div class="col-sm-3 border-right border-bottom">
                                    <telerik:RadLabel runat="server" ID="lblTitle3" Font-Size="Larger" CssClass="badge-info offset-1 col-10 text-center"></telerik:RadLabel>
                                    <telerik:RadListView runat="server" ItemPlaceholderID="Container" ID="lvBlock3" OnNeedDataSource="lvBlock3_NeedDataSource">
                                        <LayoutTemplate>
                                            <div class="col">
                                                <asp:PlaceHolder ID="Container" runat="server"></asp:PlaceHolder>
                                            </div>
                                            <hr>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <span class="float-left"><%#Eval("Item") %></span><span class="float-right"><%#Eval("Salary") %></span><br />
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                        </EmptyDataTemplate>
                                    </telerik:RadListView>
                                    <div class="col">
                                        <span class="float-left">
                                            <telerik:RadLabel runat="server" ID="lblTotal3"></telerik:RadLabel>
                                        </span>
                                        <span class="float-right">
                                            <telerik:RadLabel runat="server" ID="lblTotalSalary3"></telerik:RadLabel>
                                        </span>
                                        <br />
                                    </div>
                                </div>
                                <div class="col-sm-3 border-bottom">
                                    <telerik:RadLabel runat="server" ID="lblTitle4" Font-Size="Larger" CssClass="badge-info offset-1 col-10 text-center"></telerik:RadLabel>
                                    <telerik:RadListView runat="server" ItemPlaceholderID="Container" ID="lvBlock4" OnNeedDataSource="lvBlock4_NeedDataSource">
                                        <LayoutTemplate>
                                            <div class="col">
                                                <asp:PlaceHolder ID="Container" runat="server"></asp:PlaceHolder>
                                            </div>
                                            <hr>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <span class="float-left"><%#Eval("Item") %></span><span class="float-right"><%#Eval("Salary") %></span><br />
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                        </EmptyDataTemplate>
                                    </telerik:RadListView>
                                    <div class="col">
                                        <span class="float-left">
                                            <telerik:RadLabel runat="server" ID="lblTotal4"></telerik:RadLabel>
                                        </span>
                                        <span class="float-right">
                                            <telerik:RadLabel runat="server" ID="lblTotalSalary4"></telerik:RadLabel>
                                        </span>
                                        <br />
                                    </div>
                                     <hr />
                                    <telerik:RadLabel runat="server" ID="lblTitle6" Font-Size="Larger" CssClass="badge-info offset-1 col-10 text-center"></telerik:RadLabel>
                                    <telerik:RadListView runat="server" ItemPlaceholderID="Container" ID="lvBlock6" OnNeedDataSource="lvBlock6_NeedDataSource">
                                        <LayoutTemplate>
                                            <div class="col">
                                                <asp:PlaceHolder ID="Container" runat="server"></asp:PlaceHolder>
                                            </div>
                                            <hr>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <span class="float-left"><%#Eval("Item") %></span><span class="float-right"><%#Eval("Salary") %></span><br />
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                        </EmptyDataTemplate>
                                    </telerik:RadListView>
                                    <div class="col">
                                        <span class="float-left">
                                            <telerik:RadLabel runat="server" ID="lblTotal6"></telerik:RadLabel>
                                        </span>
                                        <span class="float-right">
                                            <telerik:RadLabel runat="server" ID="lblTotalSalary6"></telerik:RadLabel>
                                        </span>
                                        <br />
                                    </div>
                                </div>
                            </div>--%>
                        </telerik:RadAjaxPanel>
                        <div class="modal inmodal" id="myModal" tabindex="-1" role="dialog" aria-hidden="true">
                            <div class="modal-dialog modal-sm">
                                <div class="modal-content animated bounceInRight">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                        <h4 class="modal-title">修改薪資密碼</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="wrapper wrapper-content animated fadeIn">
                                            <div class="row">
                                                <telerik:RadLabel runat="server" Text="設定密碼" CssClass="badge-info col-4 text-center"></telerik:RadLabel>
                                                <telerik:RadTextBox runat="server" ID="txtNewSalaryPassword" Width="100%" TextMode="Password" Skin="Bootstrap">
                                                </telerik:RadTextBox>
                                            </div>
                                            <div class="row">
                                                <telerik:RadLabel runat="server" Text="確認密碼" CssClass="badge-info col-4 text-center"></telerik:RadLabel>
                                                <telerik:RadTextBox runat="server" ID="txtCheckSalaryPassword" Width="100%" TextMode="Password" Skin="Bootstrap">
                                                </telerik:RadTextBox>
                                            </div>
                                            <hr />
                                            <telerik:RadAjaxPanel runat="server">
                                                <telerik:RadButton runat="server" ID="btnSubmitSalaryPassword" CssClass="float-right btn btn-sm btn-primary" OnClick="btnSubmitSalaryPassword_Click" Text="送出"></telerik:RadButton>
                                                <telerik:RadLabel runat="server" ID="lblModMsg" CssClass="badge badge-info"></telerik:RadLabel>
                                            </telerik:RadAjaxPanel>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-white" data-dismiss="modal">關閉</button>
                                    </div>
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
</asp:Content>
