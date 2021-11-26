<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MangMealMoney_hr.aspx.cs" Inherits="Mang_MangCard_hr" Title="刷卡資料" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td valign="top">
            <h3>
                <asp:Localize ID="Localize1" runat="server" 
                    meta:resourcekey="Localize1Resource1" Text="員工餐費彙總"></asp:Localize>
            </h3>
                        <fieldset>
                            <legend> <asp:Localize ID="Localize2" runat="server" 
                                    meta:resourcekey="Localize2Resource1" Text="查詢條件"></asp:Localize></legend>
                            <asp:Label ID="Label1" runat="server" Text="日期：" 
                                meta:resourcekey="Label1Resource1"></asp:Label>
                            <telerik:RadDatePicker ID="adate" runat="server" Culture="(Default)" 
                                meta:resourcekey="adateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                                <DateInput Skin="" DateFormat="MM/dd/yyyy" DisplayDateFormat="MM/dd/yyyy" 
                                    LabelWidth="64px" Width="">
                                </DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                            </telerik:RadDatePicker>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                                ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" Display="Dynamic" 
                                meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>&nbsp;
                            <asp:Label ID="Label2" runat="server" Text="至" 
                                meta:resourcekey="Label2Resource1"></asp:Label>
                            <telerik:RadDatePicker ID="ddate" runat="server" Culture="(Default)" 
                                meta:resourcekey="ddateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                                <DateInput Skin="" DateFormat="MM/dd/yyyy" DisplayDateFormat="MM/dd/yyyy" 
                                    LabelWidth="64px" Width="">
                                </DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                            </telerik:RadDatePicker>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                                ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" Display="Dynamic" 
                                meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" 
                                ValidationGroup="group_date" meta:resourcekey="Button1Resource1" />&nbsp;<asp:Button
                                ID="ExportExcel" runat="server" OnClick="ExportExcel_Click" Text="匯出Excel" 
                                meta:resourcekey="ExportExcelResource1" />
                            <asp:Label ID="lb_nobr" runat="server" Visible="False" 
                                meta:resourcekey="lb_nobrResource1"></asp:Label>
                            <br />
                            <asp:Localize ID="Localize3" runat="server" 
                                meta:resourcekey="Localize3Resource1" Text="公司別："></asp:Localize>
                            <asp:DropDownList ID="ddl_company" runat="server" 
                                DataSourceID="sqlDS_company" DataTextField="compname" 
                                DataValueField="comp" meta:resourcekey="ddl_companyResource1">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="sqlDS_company" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:HRSqlServer %>" 
                                ProviderName="<%$ ConnectionStrings:HRSqlServer.ProviderName %>" 
                                SelectCommand="select comp,compname from comp"></asp:SqlDataSource>
                        </fieldset>
                       <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
                            SkinID="Yahoo" AllowPaging="True" AllowSorting="True" 
                    OnPageIndexChanging="GridView2_PageIndexChanging" 
                    meta:resourcekey="GridView2Resource1" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="nobr" HeaderText="員工編號" 
                                    meta:resourcekey="BoundFieldResource1" />
                                <asp:BoundField DataField="name_c" HeaderText="員工姓名" 
                                    meta:resourcekey="BoundFieldResource2" />
                                <asp:BoundField DataField="compname" HeaderText="公司名稱" 
                                    meta:resourcekey="BoundFieldResource3" />
                                <asp:BoundField DataField="d_name" HeaderText="部門" 
                                    meta:resourcekey="BoundFieldResource4" />
                                <asp:BoundField DataField="tot_meal_money" HeaderText="餐費" 
                                    meta:resourcekey="BoundFieldResource5" />

                                <asp:BoundField DataField="WORK_ADDR" HeaderText="工作地" 
                                    meta:resourcekey="BoundFieldResource6" />

                            </Columns>
                           <EmptyDataTemplate>
                               <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" 
                                   Text="＊無相關資料！！" meta:resourcekey="lb_emptyResource1"></asp:Label>
                           </EmptyDataTemplate>
                        </asp:GridView>
            </td>
        </tr>
    </table>
    </asp:Content>

