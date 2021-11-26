<%@ Page Title="" Language="C#" MasterPageFile="~/MainView.master" AutoEventWireup="true" CodeBehind="MainBaseViewChart.aspx.cs" Inherits="Performance.MainBaseViewChart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <style>
        .k-pdf-export, .k-pdf-export * {
            font-family: 'Arial Unicode MS' !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
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
    <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <div class="form-group  row">
            <div class="col-sm-1 ">
                <telerik:RadButton ID="btnExportExcel" runat="server" Text="匯出" OnClientClicking="exportElement" CssClass="btn btn-w-m btn-info" />
            </div>
        </div>
        <div class="form-group  row">
            <div class="col-sm-12 ">
                <telerik:RadLabel ID="lblMsg" CssClass="badge badge-danger" runat="server" />
            </div>
        </div>
        <asp:Panel ID="phPdf" runat="server">
            <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" DecoratedControls="All" ControlsToSkip="H4H5H6" />
            <telerik:RadListView ID="lvMain" runat="server" RenderMode="Lightweight" Skin="Silk" OnNeedDataSource="lvMain_NeedDataSource" OnDataBound="lvMain_DataBound" DataKeyNames="AutoKey" ItemPlaceholderID="phDept">
                <LayoutTemplate>
                    <fieldset>
                        <legend>各部門評等比例分配圖</legend>
                        <div class="form-group  row">
                            <asp:PlaceHolder ID="phDept" runat="server" />
                        </div>
                    </fieldset>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="col-sm-4 ">
                        <fieldset class="categoryFieldset">
                            <legend><%# Eval("Name") %></legend>
                            <telerik:RadHtmlChart runat="server" ID="ctInfoRating" Transitions="true" Skin="Silk">
                                <Legend>
                                    <Appearance Position="Right" Visible="true">
                                        <TextStyle FontFamily="Arial Unicode MS" />
                                    </Appearance>
                                </Legend>
                            </telerik:RadHtmlChart>
                        </fieldset>
                    </div>
                </ItemTemplate>
            </telerik:RadListView>
        </asp:Panel>
        <telerik:RadLabel ID="lblTypeCode" runat="server" Visible="false" />
        <telerik:RadLabel ID="lblMainCode" runat="server" Visible="false" />
        <telerik:RadLabel ID="lblEmpCategoryCode" runat="server" Visible="false" />
        <telerik:RadLabel ID="lblDeptCode" runat="server" Visible="false" />
        <telerik:RadLabel ID="lblSubDept" runat="server" Visible="false" />
        <telerik:RadLabel ID="lblBase" runat="server" Visible="false" />
    </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain1" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
