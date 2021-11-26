<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SP_Card.aspx.cs" Inherits="Attendance_SP_Card" Title="員工刷卡資料維護" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Namespace="Safi.UI"  TagPrefix="SafiUI"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td valign="top">
                <div id="mangDiv" runat="server" class="GreenForm">
                    <div class="BlueFormHeader">
                        <span class="BHLeft"></span><span class="BHeader">員工刷卡資料維護</span> <span class="BHRight">
                        </span>
                        <asp:ScriptManager id="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </div>
                    <div class="GreenFormContent">
                        <asp:UpdatePanel id="UpdatePanel1" runat="server">
                            <contenttemplate>
                        <fieldset>
                            <legend>刷卡資料</legend>
                            <table width="100%">
                                <tr>
                                    <td style="width: 81px" valign="top">
                                       <asp:Label ID="Label1" runat="server" SkinID="Notice" Text="刷卡日期"></asp:Label> 
                                    </td>
                                    <td valign="top">
                                 <telerik:RadDatePicker ID="ddate" runat="server" OnSelectedDateChanged="ddate_SelectedDateChanged">
                                            <DateInput Skin="">
                                            </DateInput></telerik:RadDatePicker><asp:Label id="lb_rote" runat="server" SkinID="Notice"></asp:Label>  </td>
                                </tr>
                                <tr>
                                    <td style="width: 81px" valign="top">
                                     <asp:Label ID="Label11" runat="server" SkinID="Notice" Text="員工工號"></asp:Label>   </td>
                                    <td valign="top">
                                           <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged"
                                            Width="99px"></asp:TextBox>
                                        <asp:Label ID="lb_name_c" runat="server" SkinID="Notice"></asp:Label>  
                                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="查詢刷卡資料" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 81px" valign="top">
                                        <asp:Label ID="Label12" runat="server" SkinID="Notice" Text="刷卡時間"></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <asp:DropDownList ID="DropDownList1" runat="server">
                                            <asp:ListItem>進入</asp:ListItem>
                                            <asp:ListItem>離開</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="tb_card" runat="server" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged"
                                            Width="74px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 81px" valign="top">
                                        &nbsp;</td>
                                    <td valign="top">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 81px" valign="top">
                                        &nbsp;</td>
                                    <td valign="top">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </fieldset></contenttemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="Button2" />
                                <asp:PostBackTrigger ControlID="Button2" />
                            </Triggers>
                        </asp:UpdatePanel><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="新增刷卡資料" />
                        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="刪除刷卡資料" />
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                        <div class="SilverForm">
                            <div class="SilverFormHeader">
                                <span class="SHLeft"></span><span class="SHeader"></span> <span class="SHRight">
                                </span>
                            </div>
                            <div class="SilverFormContent" style="color: red">
                                <asp:Calendar ID="Calendar1" runat="server" BorderColor="#C1CDD8" BorderWidth="0px"
                                    CellPadding="0" CssClass="offWhtBg" NextMonthText='&gt;'
                                    OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged"
                                    OnVisibleMonthChanged="Calendar1_VisibleMonthChanged" PrevMonthText='&lt;'
                                    SelectWeekText=">>" ShowGridLines="True" Width="100%">
                                    <DayStyle BorderWidth="1px" Font-Bold="True" Font-Size="18px" ForeColor="#0000C0"
                                        Height="70px" HorizontalAlign="Right" VerticalAlign="Top" Width="10%" />
                                    <DayHeaderStyle BorderWidth="1px" CssClass="titlelistTD" />
                                    <SelectedDayStyle BackColor="#FFFAE0" ForeColor="Black" />
                                    <TitleStyle BackColor="White" BorderColor="#C1CDD8" BorderStyle="None" BorderWidth="1px"
                                        Font-Size="17pt" ForeColor="Black" Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <OtherMonthDayStyle CssClass="notCurMonDate" Font-Size="10pt" />
                                </asp:Calendar>
                                <br />
                                &nbsp;</div>
                            <div class="SilverFormFooter">
                                <span class="SFLeft"></span><span class="SFRight"></span>
                            </div>
                        </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="TextBox1" EventName="TextChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                       
                        <asp:Label ID="lb_nobr" runat="server" Visible="False"></asp:Label>
                    </div>
                    <div class="GreenFormFooter">
                        <span class="GFLeft">&nbsp;</span><span class="GFRight"></span> &nbsp;
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

