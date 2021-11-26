<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CalendarTaskList.ascx.cs" Inherits="Utli_CalendarTaskList" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<div class="GreenForm">
<div class="GreenFormHeader">
<span class="GHLeft"></span>
<span class="GHeader">待辦事項行事曆</span>
<span class="GHRight"></span>
<script type="text/javascript">            
            
            function ShowNewForm(id)
            {
                  var oWindow=  window.open("../Utli/ShowTask.aspx?keyid=" + id, 'getcode','directories=Center,location=Center,menubar=no,toolbar=no,scrollbars=yes, width=680, height=500');                       
                return false;
            }           
</script>    
        
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
</telerik:RadAjaxManager>
</div>
<div class="GreenFormContent">

<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="200px" Width="97%" HorizontalAlign="NotSet" LoadingPanelID="" ScrollBars="None" EnableAJAX="False">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <asp:Calendar ID="Calendar1" runat="server" BorderColor="#C1CDD8" BorderWidth="0px"
                CellPadding="0" CssClass="offWhtBg" NextMonthText='&gt;'
                OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged"
                OnVisibleMonthChanged="Calendar1_VisibleMonthChanged" PrevMonthText='&lt;'
                SelectWeekText=">>" ShowGridLines="True" Width="80%" SkinID="Chpt">
                <SelectedDayStyle BackColor="#FFFAE0" ForeColor="Black" />
                <DayStyle BorderWidth="1px" Font-Bold="True" Font-Size="18px" ForeColor="#0000C0"
                    Height="70px" HorizontalAlign="Right" VerticalAlign="Top" Width="10%" />
                <OtherMonthDayStyle CssClass="notCurMonDate" Font-Size="10pt" />
                <DayHeaderStyle BorderWidth="1px" CssClass="titlelistTD" />
                <TitleStyle BackColor="White" BorderColor="#C1CDD8" BorderStyle="None" BorderWidth="1px"
                    Font-Size="17pt" ForeColor="Black" Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:Calendar>
          
            </asp:View>
        <asp:View ID="View2" runat="server">
            <asp:GridView ID="gv_task" runat="server" AutoGenerateColumns="False" OnRowDataBound="gv_task_RowDataBound"
                SkinID="Yahoo" DataKeyNames="id" >
               
                <Columns>                    
                    <asp:BoundField DataField="app_nobr" HeaderText="申請員工編號" />
                    <asp:BoundField DataField="app_name" HeaderText="申請員工姓名" />
                    <asp:BoundField DataField="exe_nobr" HeaderText="執行員工編號" />
                    <asp:BoundField DataField="exe_name" HeaderText="執行員工姓名" />
                    <asp:BoundField DataField="tasks" HeaderText="待辦事項" />
                    <asp:BoundField DataField="Expiredate" DataFormatString="{0:d}" HeaderText="預計日期"
                        HtmlEncode="False" />
                    <asp:BoundField DataField="type" HeaderText="型態" />
                </Columns>
            </asp:GridView>
            &nbsp;
            &nbsp;
            <asp:Button ID="Back_Button" runat="server" OnClick="Back_Button_Click" Text="回行事曆" /></asp:View>
    </asp:MultiView></telerik:RadAjaxPanel>
</div>
<div class="GreenFormFooter">
<span class="GFLeft"></span>
<span class="GFRight"></span>
</div>
</div>

