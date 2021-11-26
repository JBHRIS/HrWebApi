<%@ Page Title="學員表現評分表" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="TrainingStudentScore.aspx.cs" Inherits="eTraining_Teacher_TrainingStudentScore" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        學員表現評分表<asp:Label ID="lbliClassAutokey" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblClassMsg" runat="server" ForeColor="Red"></asp:Label>
            </h2>
    <table class="tableBlue" style="border: 1px solid #cccccc">
        <tr>
            <th>
                階層
            </th>
            <td>
                <asp:Label ID="lblCate" runat="server" Text="中餐丙級"></asp:Label>
            </td>
            <th>
                課程
            </th>
            <td>
                <asp:Label ID="lblCourse" runat="server" Text="中餐丙級考照"></asp:Label>
            </td>
            <th>
                上課日期
            </th>
            <td>
                <asp:Label ID="lblClassDate" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <telerik:RadGrid ID="gv" runat="server" CellSpacing="0" Culture="zh-TW" DataSourceID="sdsGv"
        GridLines="None" Skin="Vista" Width="90%" 
        onitemdatabound="gv_ItemDataBound">
        <MasterTableView AutoGenerateColumns="False" DataSourceID="sdsGv" 
            datakeynames="iAutoKey" AllowSorting="True">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="sDeptCode" FilterControlAltText="Filter sDeptCode column"
                    HeaderText="店別" SortExpression="sDeptCode" UniqueName="sDeptCode">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                    HeaderText="姓名" SortExpression="NAME_C" UniqueName="NAME_C">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn FilterControlAltText="Filter note column" HeaderText="上課表現"
                    UniqueName="note">
                    <ItemTemplate>
                        <telerik:RadTextBox ID="txtPerformance" runat="server" Skin="Outlook" TextMode="MultiLine"
                            Width="450px" Text='<%# Bind("sNote1") %>'>
                        </telerik:RadTextBox>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn FilterControlAltText="Filter score column"
                    HeaderText="成績" UniqueName="score">
                    <ItemTemplate>
                        <telerik:RadNumericTextBox ID="txtScore" runat="server" Width="50px" 
                            Culture="zh-TW" DbValue='<%# Bind("iScore") %>' MaxValue="100" MinValue="0">
                            <NumberFormat DecimalDigits="0" />
                        </telerik:RadNumericTextBox>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="sNote3" 
                    FilterControlAltText="Filter sNote3 column" HeaderText="TR註記" 
                    UniqueName="sNote3">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="iAutoKey" 
                    FilterControlAltText="Filter iAutoKey column" UniqueName="iAutoKey" 
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="dTeacherKeyDate" EmptyDataText="" 
                    FilterControlAltText="Filter dTeacherKeyDate column" 
                    UniqueName="dTeacherKeyDate" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridCheckBoxColumn DataField="bPresence" 
                    FilterControlAltText="Filter bPresence column" HeaderText="出席" ReadOnly="True" 
                    UniqueName="bPresence">
                </telerik:GridCheckBoxColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
            </EditFormSettings>
        </MasterTableView>
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
        </HeaderContextMenu>
    </telerik:RadGrid>
    <br />
    <div style="text-align:center">
        &nbsp;&nbsp;&nbsp;
        <telerik:RadButton ID="btnSend" runat="server" Text="存檔" 
            onclick="btnSend_Click">
        </telerik:RadButton>
    &nbsp;
        <asp:HyperLink ID="hlBack" runat="server" BackColor="#CCCCCC" 
            BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Size="12pt" 
            ForeColor="Black" 
            NavigateUrl="~/eTraining/Teacher/TeacherWrite.aspx?tab=0">返回</asp:HyperLink>
    </div>
    <asp:SqlDataSource ID="sdsGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        SelectCommand="select m.iAutoKey,m.sDeptCode,b.NAME_C,sNote1,sNote3,iScore,dTeacherKeyDate,m.bPresence from trTrainingStudentM m
join BASE b on m.sNobr=b.NOBR
where m.iClassAutoKey=@iClassAutoKey">
        <SelectParameters>
            <asp:ControlParameter ControlID="lbliClassAutokey" DefaultValue="0" Name="iClassAutoKey"
                PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
</asp:Content>
