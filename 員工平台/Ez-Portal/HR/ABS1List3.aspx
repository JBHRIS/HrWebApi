<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ABS1List3.aspx.cs" Inherits="HR_ABS1List3" Title="員工年假資料查詢" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    &nbsp;<asp:RadioButtonList ID="rblCate" runat="server" AutoPostBack="True" 
        Font-Size="X-Large" onselectedindexchanged="rblCate_SelectedIndexChanged" 
        RepeatDirection="Horizontal">
        <asp:ListItem Selected="True" Value="0">彙總</asp:ListItem>
        <asp:ListItem Value="1">明細</asp:ListItem>
    </asp:RadioButtonList>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <asp:Button ID="Button2" runat="server" meta:resourcekey="Button2Resource1" OnClick="Button2_Click"
                Text="匯出Excel" />
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" meta:resourcekey="GridView2Resource1">
                <Columns>
                    <asp:BoundField DataField="nobr" HeaderText="員工工號" meta:resourcekey="BoundFieldResource1" />
                    <asp:BoundField DataField="name" HeaderText="員工姓名" meta:resourcekey="BoundFieldResource2" />
                    <asp:BoundField DataField="name_e" HeaderText="英文名" />
                    <asp:BoundField DataField="indt" HeaderText="到職日" meta:resourcekey="BoundFieldResource3" />
                    <asp:BoundField DataField="dept" HeaderText="部門" meta:resourcekey="BoundFieldResource4" />
                    <asp:BoundField DataField="a1" HeaderText="去年度剩餘年假" 
                        meta:resourcekey="BoundFieldResource5" Visible="False" />
                    <asp:BoundField DataField="a2" HeaderText="今年度年假" meta:resourcekey="BoundFieldResource6" />
                    <asp:BoundField DataField="a3" HeaderText="今年已請時數" meta:resourcekey="BoundFieldResource7" />
                    <asp:BoundField DataField="a4" HeaderText="可累計之時數" meta:resourcekey="BoundFieldResource8"
                        Visible="False" />
                    <asp:BoundField DataField="a5" HeaderText="今年度剩餘時數" meta:resourcekey="BoundFieldResource9" />
                    <asp:BoundField DataField="a6" HeaderText="本月份已請時數" 
                        meta:resourcekey="BoundFieldResource10" Visible="False" />
                    <asp:BoundField DataField="a7" HeaderText="去年度剩餘年假未休時數" meta:resourcekey="BoundFieldResource11"
                        Visible="False">
                        <ItemStyle ForeColor="Red" />
                    </asp:BoundField>
                </Columns>
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table width="100%">
                <tr>
                    <td valign="top">
                        <div class="SilverForm">
                            <div class="SilverFormHeader">
                                <span class="SHLeft"></span><span class="SHeader">
                                <asp:Label ID="lblShowHeader" runat="server" 
                                    meta:resourcekey="lblShowHeaderResource1" Text="特休資料"></asp:Label>
                                </span><span class="SHRight"></span>
                            </div>
                            <div class="SilverFormContent">
                                <fieldset>
                                    <legend>
                                        <asp:Label ID="lblInquiryCondition" runat="server" 
                                            meta:resourcekey="lblInquiryConditionResource1" Text="查詢條件"></asp:Label>
                                    </legend>
                                    <asp:Label ID="Label1" runat="server" meta:resourcekey="Label1Resource1" 
                                        Text="特休日期："></asp:Label>
        
                                    <telerik:RadDatePicker ID="adate" Runat="server">
                                        <DateInput Skin="">
                                        </DateInput>
                                    </telerik:RadDatePicker>
        
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="adate" Display="Dynamic" ErrorMessage="日期格式錯誤" 
                                        Font-Size="X-Small" meta:resourcekey="RequiredFieldValidator1Resource1" 
                                        ValidationGroup="group_date"></asp:RequiredFieldValidator>
                                    &nbsp;
                                    <asp:Label ID="Label2" runat="server" meta:resourcekey="Label2Resource1" 
                                        Text="至"></asp:Label>
          
                                    <telerik:RadDatePicker ID="ddate" Runat="server">
                                        <DateInput Skin="">
                                        </DateInput>
                                    </telerik:RadDatePicker>
          
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="ddate" Display="Dynamic" ErrorMessage="日期格式錯誤！" 
                                        Font-Size="X-Small" meta:resourcekey="RequiredFieldValidator2Resource1" 
                                        ValidationGroup="group_date"></asp:RequiredFieldValidator>
                                    &nbsp;
                                    <asp:Button ID="Button1" runat="server" meta:resourcekey="Button1Resource1" 
                                        OnClick="Button1_Click" Text="查詢" />
                                    &nbsp;
                                    <asp:Button ID="ExportExcel" runat="server" 
                                        meta:resourcekey="ExportExcelResource1" OnClick="ExportExcel_Click" 
                                        Text="匯出Excel" ValidationGroup="group_date" />
                                    &nbsp;
                                </fieldset>
                                <asp:GridView ID="GridView3" runat="server" AllowPaging="True" 
                                    AllowSorting="True" AutoGenerateColumns="False" 
                                    meta:resourcekey="GridView2Resource1" 
                                    OnPageIndexChanging="GridView3_PageIndexChanging" SkinID="Yahoo">
                                    <Columns>
                                        <asp:BoundField DataField="nobr" HeaderText="員工編號" 
                                            meta:resourcekey="BoundFieldResource1" />
                                        <asp:BoundField DataField="name_c" HeaderText="員工姓名" 
                                            meta:resourcekey="BoundFieldResource2" />
                                        <asp:BoundField DataField="name_e" HeaderText="英文名" />
                                        <asp:BoundField DataField="bdate" DataFormatString="{0:d}" HeaderText="差勤日期" 
                                            HtmlEncode="False" meta:resourcekey="BoundFieldResource3" />
                                        <asp:BoundField DataField="h_name1" HeaderText="得假名稱" 
                                            meta:resourcekey="BoundFieldResource4" />
                                        <asp:BoundField DataField="tol_hrs1" HeaderText="得假時數" 
                                            meta:resourcekey="BoundFieldResource5" />
                                        <asp:BoundField DataField="h_name2" HeaderText="請假名稱" 
                                            meta:resourcekey="BoundFieldResource6" />
                                        <asp:BoundField DataField="tol_hrs2" HeaderText="請假時數" 
                                            meta:resourcekey="BoundFieldResource7" />
                                        <asp:BoundField DataField="tolhrs" HeaderText="剩餘時數" 
                                            meta:resourcekey="BoundFieldResource8" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" 
                                            meta:resourcekey="lb_emptyResource1" Text="＊無相關資料！！"></asp:Label>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                            <div class="SilverFormFooter">
                                <span class="SFLeft"></span><span class="SFRight"></span>
                            </div>
                        </div>
                        <asp:Label ID="lb_nobr" runat="server" meta:resourcekey="lb_nobrResource1" 
                            Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
