<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SP_Rote.aspx.cs" Inherits="Attendance_SP_Rote" Title="Untitled Page" %>
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
                        <span class="BHLeft"></span><span class="BHeader">調班資料維護</span> <span class="BHRight">
                        </span>
                        <asp:ScriptManager id="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </div>
                    <div class="GreenFormContent">
                        <asp:UpdatePanel id="UpdatePanel1" runat="server">
                            <contenttemplate>
                        <fieldset>
                            <legend>調班資料</legend>
                            <table width="100%">
                                <tr>
                                    <td style="width: 81px" valign="top">
                                        <asp:Label ID="Label11" runat="server" SkinID="Notice" Text="員工工號"></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged"
                                            Width="99px"></asp:TextBox>
                                        <asp:Label ID="lb_name_c" runat="server" SkinID="Notice"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 81px" valign="top">
                                        <asp:Label ID="Label1" runat="server" SkinID="Notice" Text="調班日期"></asp:Label></td>
                                    <td valign="top">
                                        <telerik:RadDatePicker ID="ddate" runat="server" OnSelectedDateChanged="ddate_SelectedDateChanged">
                                            <DateInput Skin="">
                                            </DateInput></telerik:RadDatePicker><asp:Label id="lb_rote" runat="server" SkinID="Notice"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 81px" valign="top">
                                        <asp:Label ID="Label12" runat="server" SkinID="Notice" Text="轉調班別"></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <SafiUI:ExtendedDropDownList ID="CONT_REL1" runat="server" DataSourceID="RESqlDataSource1"
                                            DataTextField="ROTENAME" DataValueField="ROTE" 
                                            ObsoleteValueText="Item archived">
                                        </SafiUI:ExtendedDropDownList>
                                        <asp:SqlDataSource ID="RESqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                                            SelectCommand="SELECT [ROTE], [ROTENAME] FROM [ROTE]"></asp:SqlDataSource>
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
                        </asp:UpdatePanel><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="新增調班資料" />
                        &nbsp; &nbsp;&nbsp;
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

