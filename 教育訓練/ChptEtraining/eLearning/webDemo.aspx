<%@ Page Language="C#" AutoEventWireup="true" CodeFile="webDemo.aspx.cs" Inherits="eLearning_webDemo" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <div class="field">
                <fieldset>
                    <legend>異動狀態</legend>
                    <asp:RadioButton ID="RadioButton1" runat="server" Text="1到職" />
                    <asp:RadioButton ID="RadioButton2" runat="server" Text="2離職" />
                    <asp:RadioButton ID="RadioButton3" runat="server" Text="3留停" />
                    <br />
                    <asp:RadioButton ID="RadioButton4" runat="server" Text="4復職" />
                    <asp:RadioButton ID="RadioButton5" runat="server" Text="5留離" />
                    <asp:RadioButton ID="RadioButton6" runat="server" Text="6留停復職" />
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                    <telerik:RadButton ID="RadButton1" runat="server" Text="新增" Skin="Windows7">
                    </telerik:RadButton>
                    &nbsp;&nbsp;
                    <telerik:RadButton ID="RadButton2" runat="server" Text="編輯" Skin="Windows7">
                    </telerik:RadButton>
                </fieldset>
            </div>
            <br />
            <br />
            <br />
            <telerik:RadGrid ID="gv" runat="server" AllowFilteringByColumn="True" Culture="zh-TW"
                Skin="Vista" CellSpacing="0" GridLines="None">
                <MasterTableView>
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                        </EditColumn>
                    </EditFormSettings>
                </MasterTableView>
                <FilterMenu EnableImageSprites="False">
                </FilterMenu>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Vista">
                </HeaderContextMenu>
            </telerik:RadGrid>
            <br />
        </div>
    </div>
    <div>
        異動狀態:到職&nbsp;&nbsp;&nbsp; 異動日期:2011/08/08</div>
    <div>
        <div style="float: left; width: 10%">
            <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1"
                Orientation="VerticalLeft" SelectedIndex="0" Skin="Telerik">
                <Tabs>
                    <telerik:RadTab runat="server" Selected="True" Text="人事資料">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="薪資資料">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
        </div>
        <div style="float: right; width: 89%">
            <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
                <telerik:RadPageView ID="RPV" runat="server">
                    <table class="style1">
                        <tr>
                            <td>
                                公司別
                            </td>
                            <td>
                                <telerik:RadTextBox ID="RadTextBox1" runat="server">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                編制部門
                            </td>
                            <td>
                                <telerik:RadTextBox ID="RadTextBox2" runat="server">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                成本部門
                            </td>
                            <td>
                                <telerik:RadTextBox ID="RadTextBox3" runat="server">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                簽核部門
                            </td>
                            <td>
                                <telerik:RadTextBox ID="RadTextBox4" runat="server">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                職稱
                            </td>
                            <td>
                                <telerik:RadTextBox ID="RadTextBox5" runat="server">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                    </table>
                </telerik:RadPageView>
            </telerik:RadMultiPage></div>
    </div>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    </form>
</body>
</html>
