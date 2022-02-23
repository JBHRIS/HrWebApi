<%@ Page Title="" Language="C#" MasterPageFile="~/Main_PR.Master" AutoEventWireup="true" CodeBehind="ProblemReturnList.aspx.cs" Inherits="Portal.ProblemReturnList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManager ID="RadAjaxManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="txtReturnS">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lvMain" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="txtReturnX">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lvMain" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
      
    </telerik:RadAjaxManager>

    <div class="ibox">
        
            <div class="ibox-content">
                <div class="row">
                    <div class="col-lg-7">
                        <h2>回報記錄</h2>
                    </div>
                    </div>
              <div class="row">
                    <div class="col-lg-6 ml-auto">
                        <div class="row form-group">
                            <div class="col-lg-6  m-b-sm">
                                <%--<label>回報類型 :</label> --%>
                                <telerik:radcombobox id="txtReturnS" runat="server" class="txtReturnS"
                                    skin="Bootstrap" allowcustomtext="True" autopostback="true"
                                    enablevirtualscrolling="True" itemsperrequest="10" filter="Contains"
                                    loadingmessage="載入中…" width="100%"
                                    onselectedindexchanged="txtReturnS_SelectedIndexChanged">
                                </telerik:radcombobox>
                            </div>
                            <div class="col-lg-6">
                                <%-- <label>結單狀態 :</label> --%>
                                <telerik:radcombobox id="txtReturnX" runat="server" class="txtReturnS"
                                    skin="Bootstrap" allowcustomtext="True" autopostback="true"
                                    enablevirtualscrolling="True" itemsperrequest="10" filter="Contains"
                                    loadingmessage="載入中…" width="100%"
                                    onselectedindexchanged="txtReturnS_SelectedIndexChanged">
                                </telerik:radcombobox>
                            </div>
                        </div>
                    </div>
                </div>



                


                <div class="row m-t-md">
                    <div class="col-lg-12">
                        <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                            <telerik:RadListView ID="lvMain" runat="server" OnItemCommand="lvMain_ItemCommand" OnNeedDataSource="lvMain_NeedDataSource"  ItemPlaceholderID="Container" >
                                <LayoutTemplate>
                                    <table id="footable" class="footable table table-stripped rwd-table"  data-page-size="10"  style="table-layout:fixed;width:100%"  data-filter="#filterTaken">
                                        <thead>
                                            <tr>
                                                <th style="width:25%">標題</th>
                                                <th style="width:15%">回報人員</th>
                                                <th style="width:10%">回報類型</th>
                                                <th style="width:15%">填寫日期</th>
                                                <th style="width:15%">回覆日期</th>
                                                <th style="width:10%">是否結單</th>
                                                <th style="width:10%">操作</th>
                                            </tr>
                                        </thead>
                                        <tbody id="Container" runat="server">
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                
                                                <td colspan="9">
                                                    <ul class="pagination float-right"></ul>
                                                </td>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </LayoutTemplate>

                                <ItemTemplate>

                                    <tr class="gradeX">
                                        <td data-th="標題" style="width:auto;overflow:hidden" ><%# Eval("TitleContent") %></td>
                                        <td data-th="回報人員"style="width:auto" ><%# Eval("InsertMan") %></td>
                                        <td data-th="回報類型"style="width:auto"><%# Eval("QuestionCategoryName") %></td>
                                        <td data-th="填寫日期"style="width:auto"><%# Eval("DateE","{0:yyyy-MM-dd HH:mm}") %></td>
                                        <td data-th="回覆日期"style="width:auto"><%# Eval("UpdateDate","{0:yyyy-MM-dd HH:mm}") %></td>
                                        <td data-th="是否結單"style="width:auto"><%# Eval("CompleteStatus") %></td>
                                      
                                        <td data-th="操作" style="width:auto">
                                            <telerik:RadButton ID="btnCheck" runat="server" Text="查看" CommandArgument='<%# Eval("Code")%>' CssClass="btn btn-outline btn-primary btn-xs" OnClick="btnCheck_Click">
                                                <Icon SecondaryIconCssClass="rbNext" />
                                            </telerik:RadButton>
                                        </td>
                                    </tr>

                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <table id="footable" class="footable  table table-stripped rwd-table" data-page-size="10" data-filter="#filterTaken">
                                        <thead>
                                            <tr>
                                                <th>標題</th>
                                                 <th>回報人員</th>
                                                <th>回報類型</th>
                                                <th>填寫日期</th>
                                                <th>回覆日期</th>
                                                <th>操作</th>
                                            </tr>
                                        </thead>
                                        <tbody id="Container" runat="server">

                                            <tr>
                                            </tr>
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <td colspan="9">
                                                    <ul class="pagination float-right"></ul>
                                                </td>
                                            </tr>
                                        </tfoot>
                                    </table>

                                </EmptyDataTemplate>
                            </telerik:RadListView>
                        </telerik:RadAjaxPanel>
                        <asp:Label ID="lblUserCode" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lblEmpID" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lblCompanyId" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lblEmpName" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lblRoleKey" runat="server" Visible="False"></asp:Label>

                    </div>
                </div>
            </div>
   
    </div>


</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <script src="Templates/Inspinia/js/plugins/footable/footable.all.min.js"></script>


    <script>
        $(document).ready(function () {
            $('#footable').footable();
        });


    </script>

</asp:Content>
