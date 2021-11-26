<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FL_ABS.aspx.cs" Inherits="FEFC_FL_ABS" Title="Untitled Page" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="table1" border="1" bordercolor="#808080" cellpadding="3" cellspacing="0"
        rules="all" width="90%">
        <tbody>
            <tr>
                <td align="middle" class="titletd" colspan="4" width="100%">
                    <span><span><span><span><span><span><span><span><span style="color: #333399"><u><span
                        style="font-size: 16pt">請 &nbsp; 假 &nbsp; 申 &nbsp; 請 &nbsp; 單</span></u></span></span></span></span></span></span></span></span></span></td>
            </tr>
            <tr>
                <td class="ftd" style="width: 142px; height: 25px">
                    <span style="font-size: 12pt">請假人工號：</span></td>
                <td align="left" bgcolor="#ffffff" style="height: 25px" colspan="3">
                    <span style="color: #ff0000">F</span><asp:TextBox ID="nobr" runat="server" CssClass="text-input" Style="font-size: 12pt;
                        text-align: center" Width="56px" OnTextChanged="nobr_TextChanged" AutoPostBack="True"></asp:TextBox><span style="font-size: 12pt"></span>
                    <asp:Label ID="lb_abs_name" runat="server"></asp:Label>
                    <asp:Label ID="lb_nobr" runat="server" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td class="ftd" style="width: 142px">
                    <span style="font-size: 12pt">假 &nbsp; &nbsp; 别：</span></td>
                <td align="left" bgcolor="#ffffff" colspan="3">
                    <asp:DropDownList ID="leavecategory" runat="server" AutoPostBack="True" CssClass="NormalText"
                        DataSourceID="odsHcode" DataTextField="sHname" DataValueField="sHcode" Style="font-size: 12pt;
                        width: 136px">
                    </asp:DropDownList><asp:ObjectDataSource ID="odsHcode" runat="server" SelectMethod="HcodeByDisplay"
                        TypeName="JBHR.Dll.Att"></asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td class="ftd" style="width: 142px">
                    <span style="font-size: 12pt">請假事由：</span></td>
                <td align="left" bgcolor="#ffffff" colspan="3">
                    <asp:TextBox ID="LeaveReason" runat="server" Columns="80" Rows="4" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="ftd" style="width: 142px; height: 115px;">
                    <span style="font-size: 12pt">請假日期：</span></td>
                <td align="left" bgcolor="#ffffff" colspan="3" style="height: 115px">
                    <p>
                        <span style="font-size: 12pt; vertical-align: middle">自：<telerik:RadDatePicker ID="adate"
                            runat="server">
                            <DateInput Skin="">
                            </DateInput>
                        </telerik:RadDatePicker>
                        </span>&nbsp;&nbsp;
                        <asp:DropDownList ID="StartDay" runat="server" CssClass="NormalText" Style="font-size: 12pt;
                            text-align: center" Width="60px">
                            <asp:ListItem>00</asp:ListItem>
                            <asp:ListItem>01</asp:ListItem>
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>03</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>06</asp:ListItem>
                            <asp:ListItem Selected="True">07</asp:ListItem>
                            <asp:ListItem>08</asp:ListItem>
                            <asp:ListItem>09</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                        </asp:DropDownList>：&nbsp;<asp:DropDownList ID="StartMin" runat="server" CssClass="NormalText"
                            Style="font-size: 12pt; text-align: center" Width="60px">
                            <asp:ListItem>00</asp:ListItem>
                            <asp:ListItem Selected="True">30</asp:ListItem>
                        </asp:DropDownList></p>
                    <p>
                        <span style="font-size: 12pt">至：<telerik:RadDatePicker ID="ddate"
                            runat="server">
                            <DateInput Skin="">
                            </DateInput>
                        </telerik:RadDatePicker>
                        </span>&nbsp;
                        <asp:DropDownList ID="EndDay" runat="server" CssClass="NormalText" Style="font-size: 12pt;
                            text-align: center" Width="60px">
                            <asp:ListItem>00</asp:ListItem>
                            <asp:ListItem>01</asp:ListItem>
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>03</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>06</asp:ListItem>
                            <asp:ListItem>07</asp:ListItem>
                            <asp:ListItem>08</asp:ListItem>
                            <asp:ListItem>09</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem Selected="True">16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                        </asp:DropDownList>：<asp:DropDownList ID="EndMin" runat="server" CssClass="NormalText"
                            Style="font-size: 12pt; text-align: center" Width="60px">
                            <asp:ListItem>00</asp:ListItem>
                            <asp:ListItem Selected="True">30</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp; &nbsp;&nbsp;<span style="font-size: 12pt"><span></span></span>
                        <asp:TextBox ID="LeaveDays" runat="server" CssClass="text-input" Style="font-size: 12pt;
                            width: 54px; height: 19px; text-align: right" Visible="False"></asp:TextBox>
                        &nbsp;<asp:Label ID="DayOrHour" runat="server" Visible="False"></asp:Label>
                        &nbsp; &nbsp;
                        <asp:Button ID="check" runat="server" Font-Size="12pt" Text="確認時間" ToolTip="0"
                            ValidationGroup="Check" OnClick="check_Click" Visible="False" />&nbsp; 
                        <asp:RangeValidator ID="rvDateB" runat="server" ControlToValidate="adate" Display="None"
                            ErrorMessage="開始日期格式錯誤" MaximumValue="9999/12/31" MinimumValue="1900/1/1" SetFocusOnError="True"
                            Type="Date" ValidationGroup="Check"></asp:RangeValidator><asp:RangeValidator ID="rvDateE"
                                runat="server" ControlToValidate="ddate" Display="None" ErrorMessage="結束日期格式錯誤"
                                MaximumValue="9999/12/31" MinimumValue="1900/1/1" SetFocusOnError="True" Type="Date"
                                ValidationGroup="Check"></asp:RangeValidator><asp:RequiredFieldValidator ID="rfvDateB"
                                    runat="server" ControlToValidate="adate" Display="None" ErrorMessage="開始日期不允許空白"
                                    ValidationGroup="Check"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                        ID="rfvDateE" runat="server" ControlToValidate="ddate" Display="None" ErrorMessage="結束日期不允許空白"
                                        ValidationGroup="Check"></asp:RequiredFieldValidator><asp:CompareValidator ID="cvDate"
                                            runat="server" ControlToCompare="adate" ControlToValidate="ddate" Display="None"
                                            ErrorMessage="結束日期不可以小於開始日期" Operator="GreaterThanEqual" Type="Date" ValidationGroup="Check"></asp:CompareValidator></p>
                </td>
            </tr>
            <tr>
                <td class="ftd" style="vertical-align: middle; width: 142px" valign="center">
                    <span style="font-size: 12pt">年度假別明細：</span></td>
                <td align="left" bgcolor="#ffffff" colspan="3">
                    <p style="vertical-align: middle">
                        <asp:GridView ID="gvAbsView" runat="server" CellPadding="4" DataSourceID="odsAbsView"
                            ForeColor="#333333" GridLines="None" Style="font-size: 12pt">
                            <RowStyle BackColor="#EFF3FB" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        <span style="font-size: 12pt"></span>
                        <asp:TextBox ID="ThisYearDays" runat="server" CssClass="text-input" Enabled="False"
                            Height="19px" Style="font-size: 12pt; text-align: right" Visible="False" Width="48px"></asp:TextBox><span
                                style="font-size: 12pt"> </span>
                        <asp:ObjectDataSource ID="odsAbsView" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="AbsView" TypeName="JBHR.Dll.Att+AbsCal">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lb_nobr" Name="sNobr" PropertyName="Text" Type="String" DefaultValue="" />
                                <asp:ControlParameter ControlID="ddate" DefaultValue="2010/01/01" Name="dDate"
                                    PropertyName="SelectedDate" Type="DateTime" />
                                <asp:Parameter Name="sName" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </p>
                </td>
            </tr>
            <tr>
                <td class="ftd" style="width: 142px; height: 25px" valign="top">
                    <span style="font-size: 12pt"></span></td>
                <td align="left" bgcolor="#ffffff" colspan="3" style="height: 25px">
                    &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="儲存請假資料" /></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: right">
                    <span style="font-size: 12pt"></span></td>
            </tr>
        </tbody>
    </table>
    <asp:Literal ID="lScript" runat="server"></asp:Literal>
</asp:Content>

