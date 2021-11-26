<%@ Page Title="學員心得評分" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="ScoreStudentReport.aspx.cs" Inherits="eTraining_Teacher_ScoreStudentReport" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .RadInput_Default
        {
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput
        {
            vertical-align: middle;
        }
        
        .RadInput textarea
        {
            vertical-align: bottom;
            overflow: auto;
            resize: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        學員心得評分<asp:Label ID="lbliClassAutokey" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblClassMsg" runat="server" ForeColor="Red"></asp:Label>
    </h2>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%">
        <script type="text/javascript">
        //<![CDATA[

            //Standard Window.confirm
            function StandardConfirm(sender, args) {
                args.set_cancel(!window.confirm("確認是否退件?"));
            }
                        
        //]]>
    </script>
        <table class="tableBlue" style="border: 1px solid #cccccc">
            <tr>
                <th>
                    階層
                </th>
                <td>
                    <asp:Label ID="lblCate" runat="server"></asp:Label>
                </td>
                <th>
                    課程
                </th>
                <td>
                    <asp:Label ID="lblCourse" runat="server"></asp:Label>
                </td>
                <th>
                    上課日期
                </th>
                <td>
                    <asp:Label ID="lblClassDate" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnlView" runat="server">
            <telerik:RadGrid ID="gv" runat="server" CellSpacing="0" Culture="zh-TW"
                GridLines="None" OnItemDataBound="gv_ItemDataBound" OnSelectedIndexChanged="gv_SelectedIndexChanged"
                Skin="Vista" Width="55%" AutoGenerateColumns="False" 
                onneeddatasource="gv_NeedDataSource">
                <MasterTableView DataKeyNames="iAutoKey" AllowSorting="True">
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridButtonColumn CommandName="Select" FilterControlAltText="Filter Select column"
                            Text="選擇" UniqueName="Select">
                        </telerik:GridButtonColumn>
                        <telerik:GridBoundColumn DataField="sDeptCode" FilterControlAltText="Filter sDeptCode column"
                            HeaderText="店別" SortExpression="sDeptCode" UniqueName="sDeptCode">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                            HeaderText="姓名" SortExpression="NAME_C" UniqueName="NAME_C">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn FilterControlAltText="Filter note column" HeaderText="上課表現"
                            UniqueName="note" Visible="False">
                            <ItemTemplate>
                                <telerik:RadTextBox ID="txtPerformance" runat="server" Skin="Outlook" Text='<%# Bind("sNote1") %>'
                                    TextMode="MultiLine" Width="450px">
                                </telerik:RadTextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn FilterControlAltText="Filter score column" HeaderText="成績"
                            UniqueName="score" Visible="False">
                            <ItemTemplate>
                                <telerik:RadNumericTextBox ID="txtScore" runat="server" Culture="zh-TW" DbValue='<%# Bind("iScore") %>'
                                    MaxValue="100" MinValue="0" Width="50px">
                                    <NumberFormat DecimalDigits="0" />
                                </telerik:RadNumericTextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="sNote3" FilterControlAltText="Filter sNote3 column"
                            HeaderText="TR註記" UniqueName="sNote3" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iNote2Score" EmptyDataText="" FilterControlAltText="Filter iNote2Score column"
                            HeaderText="分數" UniqueName="iNote2Score">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iAutoKey" FilterControlAltText="Filter iAutoKey column"
                            UniqueName="iAutoKey" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dTeacherKeyDate" EmptyDataText="" FilterControlAltText="Filter dTeacherKeyDate column"
                            UniqueName="dTeacherKeyDate" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dNote2KeyDate" DataFormatString="{0:d}" EmptyDataText=""
                            FilterControlAltText="Filter dNote2KeyDate column" HeaderText="心得填寫日" UniqueName="dNote2KeyDate">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="bPresence" FilterControlAltText="Filter bPresence column"
                            HeaderText="bPresence" UniqueName="bPresence" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridCheckBoxColumn DataField="IsHired" 
                            FilterControlAltText="Filter IsHired column" HeaderText="是否在職" 
                            UniqueName="IsHired">
                        </telerik:GridCheckBoxColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                        </EditColumn>
                    </EditFormSettings>
                </MasterTableView>
                <FilterMenu EnableImageSprites="False">
                    <WebServiceSettings>
                        <ODataSettings InitialContainerName="">
                        </ODataSettings>
                    </WebServiceSettings>
                </FilterMenu>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                    <WebServiceSettings>
                        <ODataSettings InitialContainerName="">
                        </ODataSettings>
                    </WebServiceSettings>
                </HeaderContextMenu>
            </telerik:RadGrid>
            <asp:HyperLink ID="hlBack" runat="server" BackColor="#CCCCCC" BorderColor="Black"
                BorderStyle="Solid" BorderWidth="1px" Font-Size="12pt" ForeColor="Black" NavigateUrl="~/eTraining/Teacher/TeacherWrite.aspx?tab=0"
                Style="text-align: left">上一頁</asp:HyperLink>
        </asp:Panel>
        <asp:Panel ID="pnlWrite" runat="server" Visible="False">
            <table width="85%" class="Basic">
                <tr>
                <td>
                學員
                </td>
                    <td>
                        <asp:Label ID="lb_Name" runat="server"></asp:Label>
                    </td>
                    <td>
                        心得分數：<telerik:RadNumericTextBox ID="ntbScore" runat="server" MaxValue="100" MinValue="0">
                            <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                        </telerik:RadNumericTextBox>
                        <asp:Label ID="lblMsg" runat="server" ForeColor="#FF3300"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadButton ID="btnSend" runat="server" OnClick="btnSend_Click" Text="存檔">
                        </telerik:RadButton>
                                                <telerik:RadButton ID="btnReturn" runat="server" Text="返回" Skin="Black" 
                            onclick="btnReturn_Click">
                        </telerik:RadButton>
                    </td>
                    <td>
                        <telerik:RadButton ID="btnRejection" runat="server" Text="退件" ForeColor="Red" 
                            onclick="btnRejection_Click" onclientclicking="StandardConfirm">
                        </telerik:RadButton>
                    </td>
                </tr>
            </table>            
            <br />
            學員心得<br />
            <telerik:RadEditor ID="edtStudent" runat="server" EditModes="Preview" 
                Width="100%" BorderWidth="1px" ContentAreaMode="Div" 
                EnableResize="False" Skin="Telerik" ToolbarMode="ShowOnFocus" 
                ToolsFile="~/Editor/RadEditor/FullSetOfTools.xml" CssClass="lineHeight" 
                Font-Size="Medium">
            </telerik:RadEditor>
            <br />
            <hr />
            <br />
            講師評語<telerik:RadEditor ID="edtTeacher" runat="server" EditModes="Design, Preview"
                Width="100%" BorderWidth="1px" EnableResize="False" 
                ToolsFile="~/Editor/RadEditor/BasicTools.xml" CssClass="lineHeight" 
                Font-Size="Medium">
                <Content>
</Content>
                <TrackChangesSettings CanAcceptTrackChanges="False" />
            </telerik:RadEditor>
        </asp:Panel>                
        <asp:SqlDataSource ID="sdsGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
            SelectCommand="select m.iAutoKey,m.sDeptCode,m.dNote2ScoreKeyDate,m.dNote2KeyDate,m.iNote2Score,b.NAME_C,sNote1,sNote3,iScore,dTeacherKeyDate,m.bPresence from trTrainingStudentM m
join BASE b on m.sNobr=b.NOBR
where m.iClassAutoKey=@iClassAutoKey">
            <SelectParameters>
                <asp:ControlParameter ControlID="lbliClassAutokey" DefaultValue="0" Name="iClassAutoKey"
                    PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    </telerik:RadAjaxPanel>
    <br />
</asp:Content>
