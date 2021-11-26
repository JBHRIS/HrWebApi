<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EmpSalary.aspx.cs" Inherits="Salary_EmpSalary" Title="員工薪資查詢" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="GreenForm">
        <div class="GreenFormHeader">
            <span class="GHLeft"></span><span class="GHeader">員工薪資查詢</span> <span class="GHRight">
            </span>
        </div>
        <div class="GreenFormContent">
        
    <CR:CrystalReportViewer ID="Cr_zz42" runat="server" AutoDataBind="True" ReportSourceID="CrystalReportSource1" ReuseParameterValuesOnRefresh="True"
            Visible="False" DisplayGroupTree="False" HasCrystalLogo="False" HasToggleGroupTreeButton="False"  PrintMode="ActiveX" DisplayToolbar="False"  />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server" OnUnload="CrystalReportSource1_Unload">
        </CR:CrystalReportSource>
      <asp:Panel ID="Panel1" runat="server" Width="80%">  
    <div>
        
       <fieldset>
            
            <legend>薪資資料查詢</legend>
         1.請先輸入您的身分證號碼：<asp:TextBox ID="idno" runat="server" TextMode="Password"></asp:TextBox><br />
           2.請輸入薪資密碼：<asp:TextBox ID="salPW" runat="server" TextMode="Password"></asp:TextBox>
           <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">沒有薪資密碼同仁，請按址LINK 設定！</asp:LinkButton><br />
           3.查詢薪資年月條件：
        <asp:TextBox ID="year" runat="server" MaxLength="4" Width="30px"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="年"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="year"
            Display="Dynamic" ErrorMessage="不可空白" Font-Size="XX-Small"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="year"
            Display="Dynamic" ErrorMessage="數值格式錯誤!" Font-Size="XX-Small" Operator="DataTypeCheck"
            Type="Integer"></asp:CompareValidator>&nbsp;
        <asp:TextBox ID="month" runat="server" MaxLength="2" Width="20px"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="月"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="month"
            Display="Dynamic" ErrorMessage="不可空白" Font-Size="XX-Small"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="month"
            Display="Dynamic" ErrorMessage="數值格式錯誤!" Font-Size="XX-Small" Operator="DataTypeCheck"
            Type="Integer"></asp:CompareValidator><asp:Label ID="Label3" runat="server" Text="期別" Visible="False"></asp:Label><asp:TextBox ID="sq" runat="server" MaxLength="1" Width="15px" Visible="False"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="sq"
            Display="Dynamic" ErrorMessage="不可空白" Font-Size="XX-Small"></asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="sq"
            Display="Dynamic" ErrorMessage="數值格式錯誤!" Font-Size="XX-Small" Operator="DataTypeCheck"
            Type="Integer"></asp:CompareValidator>&nbsp;
           <asp:CheckBox ID="CheckBox1" runat="server" Text="查詢獎金" Visible="False" /><br />
           4.<asp:Button ID="Button1" runat="server" Text="查詢" OnClick="Button1_Click" />
           <asp:CheckBox ID="salary_pa" runat="server"
                 Text="English version for foreign employee" Visible="False" />
           <asp:Label ID="showMeg" runat="server" ForeColor="Red"></asp:Label></fieldset>
        </div>
        </asp:Panel>

    <script language="javascript">
     <%=ScriptString%>
    </script>
   
    
         <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="重新查詢" /></div>
        <div class="GreenFormFooter">
            <span class="GFLeft"></span><span class="GFRight"></span>
        </div>
    </div>

   

</asp:Content>

