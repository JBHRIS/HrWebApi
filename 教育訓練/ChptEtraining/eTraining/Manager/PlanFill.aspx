<%@ Page Title="填寫員工年度訓練需求強度" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="PlanFill.aspx.cs" Inherits="eTraining_Manager_PlanFill" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style2
        {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $('.funcblock').corner("15px");
         //<![CDATA[

        //Standard Window.confirm
        function StandardConfirm(sender, args) {
            args.set_cancel(!window.confirm("送出後即無法修改，確認送出?"));            
        }

        //RadConfirm
        function RadConfirm(sender, args) {
            var callBackFunction = Function.createDelegate(sender, function (shouldSubmit) {
                if (shouldSubmit) {
                    this.click();
                }
            });

            var text = "Are you sure you want to submit the page?";
            radconfirm(text, callBackFunction, 300, 100, null, "RadConfirm");
            args.set_cancel(true);
        }
        //]]>    
    </script>
    <div>
        <div>
            <h2>
                填寫員工年度訓練需求強度</h2>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%">
            <div style="color: #0000FF">
                請依照您的部屬所需增加的能力，填寫需求。
共分為四大項：一般管理技能、人際關係、主管人員管理發展訓練、創造力與自主管理。
如有未包含至以上四大類的課程，可自行新增。
所需強度最強的填寫3、所需強度最弱的填寫1、如尚未需要的即不需填寫。
最低填選一個選項，不限定填選幾項。
            </div>
                <br />
                    
                <div>
                    年度<telerik:RadComboBox ID="cbxYear" runat="server" Width="70px" AutoPostBack="True"
                        OnLoad="cbxYear_Load" OnSelectedIndexChanged="cbxYear_SelectedIndexChanged">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="2011" Value="2011" />
                            <telerik:RadComboBoxItem runat="server" Text="2012" Value="2012" />
                        </Items>
                    </telerik:RadComboBox>
                </div>
                <br />
                <div style="background-color: #CDE5FF; float: left; width: 18%" class="funcblock">
                    <br />
                    <telerik:RadTreeView ID="tvDept" runat="server" CheckChildNodes="True" DataSourceID="sdsName"
                        DataTextField="NAME_C" DataValueField="NOBR" OnNodeClick="tvDept_NodeClick">
                        <Nodes>
                            <telerik:RadTreeNode runat="server" Text="五股五權店" Owner="tvDept">
                                <Nodes>
                                    <telerik:RadTreeNode runat="server" Text="員工1(1)">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="員工2">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="員工3">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="員工4(1)">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="員工5(1)">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="員工6">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="員工7">
                                    </telerik:RadTreeNode>
                                </Nodes>
                            </telerik:RadTreeNode>
                        </Nodes>
                    </telerik:RadTreeView>
                    <asp:SqlDataSource ID="sdsName" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                        SelectCommand="select dt.D_NAME,ba.NOBR,ba.NAME_C from trTrainingQuest tq
join DEPT dt on tq.sDeptCode=dt.D_NO
join BASE ba on tq.sNobr =ba.NOBR
where tq.sManage=@Manage
group by dt.D_NAME,ba.NOBR,ba.NAME_C
">
                        <SelectParameters>
                            <asp:Parameter Name="Manage" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                </div>
                <div style="float: right; width: 80%; height: 264px;">
                    <asp:Label ID="lblMsg" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                    <telerik:RadGrid ID="gvQuest" runat="server" CellSpacing="0" DataSourceID="sdsQuest"
                        GridLines="None" Skin="Outlook" OnItemDataBound="gvQuest_ItemDataBound" AutoGenerateColumns="False"
                        Culture="zh-TW">
                        <MasterTableView DataSourceID="sdsQuest" DataKeyNames="iAutoKey">
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="sNobr" FilterControlAltText="Filter sNobr column"
                                    HeaderText="工號" UniqueName="sNobr">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="catName" FilterControlAltText="Filter cateName column"
                                    HeaderText="類別" SortExpression="catName" UniqueName="catName">
                                    <HeaderStyle Width="170px" Wrap="False" />
                                    <ItemStyle Width="170px" Wrap="False" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="trCourse_sCode" FilterControlAltText="Filter trCourse_sCode column"
                                    HeaderText="編號" SortExpression="trCourse_sCode" 
                                    UniqueName="trCourse_sCode" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="courseName" FilterControlAltText="Filter courseName column"
                                    HeaderText="課程名稱" SortExpression="courseName" UniqueName="courseName">
                                    <HeaderStyle Width="180px" Wrap="False" />
                                    <ItemStyle Width="180px" Wrap="False" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="iDemandIntensityP" DataType="System.Int32" FilterControlAltText="Filter iDemandIntensityP column"
                                    HeaderText="個人需求(1-5)" SortExpression="iDemandIntensityP" UniqueName="iDemandIntensityP">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter COL_M column" HeaderText="主管需求(1-3)"
                                    UniqueName="COL_M">
                                    <ItemTemplate>
                                        <telerik:RadNumericTextBox ID="ntbM" runat="server" Culture="zh-TW" DataType="System.Int16"
                                            MaxValue="3" MinValue="0" Width="50px" 
                                            DbValue='<%# Bind("iDemandIntensityM") %>'>
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="catCode" 
                                    FilterControlAltText="Filter catCode column" HeaderText="類別代碼" 
                                    UniqueName="catCode" Visible="False">
                                </telerik:GridBoundColumn>
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
                    <div style="float: right; width: 50%">
                        <telerik:RadGrid ID="gvQuestCustom" runat="server" CellSpacing="0" DataSourceID="sdsCustom"
                            GridLines="None" OnItemDataBound="gvOtherQuest_ItemDataBound" AutoGenerateColumns="False"
                            Culture="zh-TW">
                            <MasterTableView DataKeyNames="iAutoKey" DataSourceID="sdsCustom">
                                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="sCourseName" FilterControlAltText="Filter sCourseName column"
                                        HeaderText="課程名稱" SortExpression="sCourseName" UniqueName="sCourseName">
                                        <ItemStyle Wrap="False" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="iDemandIntensityP" DataType="System.Int32" FilterControlAltText="Filter iDemandIntensityP column"
                                        HeaderText="個人需求" SortExpression="iDemandIntensityP" UniqueName="iDemandIntensityP">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn FilterControlAltText="Filter COL_M column" HeaderText="主管需求"
                                        UniqueName="COL_M">
                                        <ItemTemplate>
                                            <telerik:RadNumericTextBox ID="ntbM2" runat="server" Culture="zh-TW" DataType="System.Int16"
                                                MaxValue="3" MinValue="0" Width="30px" 
                                                DbValue='<%# Bind("iDemandIntensityM") %>'>
                                                <NumberFormat DecimalDigits="0" />
                                            </telerik:RadNumericTextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
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
                    </div>
                    <asp:SqlDataSource ID="sdsQuest" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                        SelectCommand="select tq.iAutoKey,tq.sNobr,cat.sName as catName,cat.sCode as catCode,tq.trCourse_sCode,co.sName as courseName,tq.iDemandIntensityP,tq.iDemandIntensityM
from trTrainingQuest tq
join trCourse co on tq.trCourse_sCode=co.sCode
join trRequirementTemplateCat cat on tq.sKey = cat.sCode
 WHERE tq.sNobr = @Nobr and tq.iYear=@Year
order by cat.sName" OnSelecting="sdsQuest_Selecting">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="tvDept" DefaultValue="0" Name="Nobr" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="cbxYear" DefaultValue="0" Name="Year" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <br />
                    <asp:SqlDataSource ID="sdsCustom" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                        SelectCommand="SELECT [iAutoKey], [iYear], [sCourseName], [iDemandIntensityP], [iDemandIntensityM], [iDemandIntensityPdate], [iDemandIntensityMdate], [sNobr], [sManage], [iSession], [sDeptCode] FROM [trTrainingQuestCustom] 
where sNobr=@Nobr and iYear=@Year">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="tvDept" DefaultValue="0" Name="Nobr" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="cbxYear" DefaultValue="0" Name="Year" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <table style="width: 100%">
                        <tr>
                            <td class="style2">
                                <telerik:RadButton ID="btnSave" runat="server" Text="存檔" Skin="Windows7" OnClick="btnSave_Click">
                                </telerik:RadButton>
                                <telerik:RadButton ID="btnCheck" runat="server" Text="確認送出" Skin="Windows7" 
                                    OnClick="btnCheck_Click" onclientclicking="StandardConfirm">
                                </telerik:RadButton>
                            </td>
                        </tr>
                    </table>
                </div>
            </telerik:RadAjaxPanel>
        </div>
    </div>
</asp:Content>
