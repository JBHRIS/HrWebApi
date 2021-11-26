<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ImportRote.aspx.cs" Inherits="Attendance_ImportRote" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <fieldset>
                <legend>
                    <asp:Label ID="lblShowHeader" runat="server" Text="匯入班表資料" meta:resourcekey="lblShowHeaderResource1"></asp:Label></legend>
                <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0" BackColor="#EFF3FB" BorderColor="#B5C7DE"
                    BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" OnActiveStepChanged="Wizard1_ActiveStepChanged"
                    meta:resourcekey="Wizard1Resource1">
                    <StepStyle Font-Size="0.8em" ForeColor="#333333" />
                    <HeaderStyle BackColor="#284E98" BorderColor="#EFF3FB" BorderStyle="Solid" BorderWidth="2px"
                        Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
                    <NavigationButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid"
                        BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
                    <SideBarButtonStyle BackColor="#507CD1" Font-Names="Verdana" ForeColor="White" />
                    <SideBarStyle BackColor="#507CD1" Font-Size="0.9em" VerticalAlign="Top" />
                    <WizardSteps>
                        <asp:WizardStep runat="server" meta:resourcekey="WizardStepResource1" Title="1.上傳員工班表">
                            &nbsp;
                            <h3>
                                <asp:Label ID="lblShowHeader1" runat="server" meta:resourcekey="lblShowHeader1Resource1"
                                    Text="上傳員工班表"></asp:Label>
                            </h3>
                            <table width="500">
                                <tr>
                                    <td colspan="2" style="height: 28px">
                                        <asp:TextBox ID="TextBox1" runat="server" EnableViewState="False" meta:resourcekey="TextBox1Resource1"
                                            ReadOnly="True" Rows="3" TextMode="MultiLine" Width="100%">1.按&quot;瀏覽&quot;，選取預上傳班表Excel檔案。
2.瀏覽完成後，再按下&quot;開始上傳&quot;，網頁會顯示&quot;上傳成功！&quot;。
3.完成上面作業，請按&quot;下一頁&quot;。</asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="color: #000000">
                                    <td style="width: 20%">
                                        <asp:FileUpload ID="txtUpload" runat="server" meta:resourcekey="txtUploadResource1" />
                                    </td>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" meta:resourcekey="Button1Resource1" OnClick="Button1_Click"
                                            Text="開始上傳" />
                                    </td>
                                </tr>
                                <tr style="color: #000000">
                                    <td style="width: 20%">
                                        <asp:Label ID="showMsg" runat="server" EnableViewState="False" meta:resourcekey="showMsgResource1"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%">
                                        <asp:Menu ID="Menu1" runat="server" meta:resourcekey="Menu1Resource1" OnMenuItemClick="Menu1_MenuItemClick"
                                            Orientation="Horizontal" Visible="False">
                                            <DynamicHoverStyle CssClass="menuPopupItem" />
                                            <DynamicMenuItemStyle CssClass="menuPopupItem" Font-Strikeout="False" />
                                            <DynamicMenuStyle CssClass="menuPopup" />
                                            <StaticHoverStyle CssClass="menuItemHover" />
                                            <StaticMenuItemStyle CssClass="menuItem" />
                                            <StaticMenuStyle CssClass="menu" />
                                            <StaticSelectedStyle CssClass="menuSelectedItem" />
                                        </asp:Menu>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="Button3" runat="server" meta:resourcekey="Button3Resource1" OnClick="Button3_Click"
                                            Text="下載員工班表" />
                                        ※可下載部門員工班表Excel檔案！
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="Button6" runat="server" meta:resourcekey="Button6Resource1" OnClick="Button6_Click"
                                            Text="下載班別對照表" />
                                        ※可下載班別代碼及名稱對應表！
                                    </td>
                                </tr>
                            </table>
                            &nbsp;
                            <br />
                            <br />
                        </asp:WizardStep>
                        <asp:WizardStep runat="server" meta:resourcekey="WizardStepResource2" Title="2.確認匯入班表年月">
                            &nbsp;
                            <h3>
                                <asp:Label ID="lblShowHeader2" runat="server" meta:resourcekey="lblShowHeader2Resource1"
                                    Text="確認匯入班表年月"></asp:Label>
                            </h3>
                            <table width="500">
                                <tr>
                                    <td style="height: 28px">
                                        <asp:TextBox ID="TextBox2" runat="server" EnableViewState="False" meta:resourcekey="TextBox2Resource1"
                                            ReadOnly="True" Rows="2" TextMode="MultiLine" Width="100%">1.確認匯入班表年月
2.確認後，按&quot;下一頁</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 28px">
                                        <asp:Label ID="lblShowImportShiftYear" runat="server" meta:resourcekey="lblShowImportShiftYearResource1"
                                            Text="匯入班表年份："></asp:Label>
                                        &nbsp;<asp:DropDownList ID="ddl_year" runat="server" meta:resourcekey="ddl_yearResource1">
                                            <asp:ListItem meta:resourcekey="ListItemResource1">2010</asp:ListItem>
                                            <asp:ListItem meta:resourcekey="ListItemResource2">2011</asp:ListItem>
                                            <asp:ListItem meta:resourcekey="ListItemResource3">2012</asp:ListItem>
                                            <asp:ListItem meta:resourcekey="ListItemResource4">2013</asp:ListItem>
                                            <asp:ListItem meta:resourcekey="ListItemResource5">2014</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="color: #000000">
                                    <td>
                                        <asp:Label ID="lblShowImportShiftMonth" runat="server" meta:resourcekey="lblShowImportShiftMonthResource1"
                                            Text="匯入班表月份："></asp:Label>
                                        <asp:DropDownList ID="ddl_month" runat="server" meta:resourcekey="ddl_monthResource1">
                                            <asp:ListItem meta:resourcekey="ListItemResource6">01</asp:ListItem>
                                            <asp:ListItem meta:resourcekey="ListItemResource7">02</asp:ListItem>
                                            <asp:ListItem meta:resourcekey="ListItemResource8">03</asp:ListItem>
                                            <asp:ListItem meta:resourcekey="ListItemResource9">04</asp:ListItem>
                                            <asp:ListItem meta:resourcekey="ListItemResource10">05</asp:ListItem>
                                            <asp:ListItem meta:resourcekey="ListItemResource11">06</asp:ListItem>
                                            <asp:ListItem meta:resourcekey="ListItemResource12">07</asp:ListItem>
                                            <asp:ListItem meta:resourcekey="ListItemResource13">08</asp:ListItem>
                                            <asp:ListItem meta:resourcekey="ListItemResource14">09</asp:ListItem>
                                            <asp:ListItem meta:resourcekey="ListItemResource15">10</asp:ListItem>
                                            <asp:ListItem meta:resourcekey="ListItemResource16">11</asp:ListItem>
                                            <asp:ListItem meta:resourcekey="ListItemResource17">12</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="GridView1" runat="server" meta:resourcekey="GridView1Resource1">
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                            &nbsp;
                            <br />
                            <br />
                        </asp:WizardStep>
                        <asp:WizardStep runat="server" meta:resourcekey="WizardStepResource3" Title="3.開始匯入班表">
                            &nbsp;
                            <h3>
                                <asp:Label ID="lblShowStartToImport" runat="server" meta:resourcekey="lblShowStartToImportResource1"
                                    Text="開始匯入班表"></asp:Label>
                            </h3>
                            <table width="500">
                                <tr>
                                    <td colspan="2" style="height: 28px">
                                        <asp:TextBox ID="TextBox3" runat="server" EnableViewState="False" meta:resourcekey="TextBox3Resource1"
                                            ReadOnly="True" Rows="2" Text="1.請按下開始匯入，這樣才算完成員工班表匯入程序。" TextMode="MultiLine"
                                            Width="100%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 28px">
                                        <asp:Label ID="lblNotifyMsg" runat="server" Font-Size="Large" ForeColor="#3333CC"
                                            meta:resourcekey="lblNotifyMsgResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="color: #000000">
                                    <td style="width: 20%">
                                        <asp:Button ID="Button2" runat="server" meta:resourcekey="Button2Resource1" OnClick="Button2_Click"
                                            Text="開始匯入" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                            &nbsp;
                            <br />
                            <br />
                        </asp:WizardStep>
                    </WizardSteps>
                </asp:Wizard>
                <table id="Table4" cellspacing="1" cellpadding="1" width="100%" border="0">
                    <tr>
                        <td align="left" width="70%">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlJob" runat="server" Visible="False" meta:resourcekey="ddlJobResource1">
                            </asp:DropDownList>
                            <asp:Label ID="lab2" runat="server" Visible="False" meta:resourcekey="lab2Resource1">評等</asp:Label>
                            <asp:Label ID="Label6" runat="server" Visible="False" meta:resourcekey="Label6Resource1">工號：</asp:Label>
                            <asp:Label ID="Label2" runat="server" Visible="False" meta:resourcekey="Label2Resource1">排序</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td>
                            <asp:DropDownList ID="ddeff" runat="server" Visible="False" meta:resourcekey="ddeffResource1">
                            </asp:DropDownList>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td style="width: 71px">
                            <asp:DropDownList ID="ddorder" runat="server" Visible="False" meta:resourcekey="ddorderResource1">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;
                        </td>
                        <td style="height: 34px; width: 71px;">
                            &nbsp;
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="bottom">
                            &nbsp;
                        </td>
                        <td valign="bottom" style="width: 71px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 15px">
                        </td>
                        <td style="height: 15px">
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:View>
        <asp:View ID="View2" runat="server">
            &nbsp;<fieldset>
                <legend></legend>&nbsp;<br />
                <h3>
                    <asp:Label ID="lblShowDLShift" runat="server" Text="下載員工班表名單" meta:resourcekey="lblShowDLShiftResource1"></asp:Label>
                </h3>
                <table width="50%">
                    <tr>
                        <td style="width: 20%; height: 28px">
                            <asp:Label ID="lblShowDept" runat="server" Text="部門：" meta:resourcekey="lblShowDeptResource1"></asp:Label>
                        </td>
                        <td style="height: 28px">
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                                meta:resourcekey="DropDownList1Resource1">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="color: #000000">
                        <td style="width: 20%">
                            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="下載" meta:resourcekey="Button4Resource1" />
                        </td>
                        <td>
                            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="取消" meta:resourcekey="Button5Resource1" />
                            <asp:Label ID="lb_dept" runat="server" Visible="False" meta:resourcekey="lb_deptResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%">
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                &nbsp;
                <br />
                <br />
            </fieldset>
            <asp:SqlDataSource ID="HR_Portal_EmpInfoSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                SelectCommand="SELECT NOBR, NAME_C, INDT, DEPT, D_NAME, JOB, JOB_NAME, EMPCD, EMPDESCR, MANG, DI,NAME_E FROM HR_Portal_EmpInfo WHERE (DEPT = @Dept) ORDER BY INDT">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lb_dept" Name="Dept" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                DataKeyNames="NOBR" DataSourceID="HR_Portal_EmpInfoSqlDataSource" Visible="False"
                meta:resourcekey="GridView2Resource1">
                <Columns>
                    <asp:BoundField DataField="NOBR" HeaderText="員工工號" SortExpression="NOBR" meta:resourcekey="BoundFieldResource1" />
                    <asp:BoundField DataField="NAME_C" HeaderText="員工姓名" SortExpression="NAME_C" meta:resourcekey="BoundFieldResource2" />
                </Columns>
            </asp:GridView>
        </asp:View>
    </asp:MultiView>
</asp:Content>
