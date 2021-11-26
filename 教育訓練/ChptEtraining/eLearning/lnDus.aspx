<%@ Page Title="" Language="C#" MasterPageFile="~/mpLearningFront.master" AutoEventWireup="true" CodeFile="lnDus.aspx.cs" Inherits="eLearning_lnDus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="news">
		<span style="background-color:#ffffff;height:10px;width:575px;display:block"></span>
		<h4>討論區</h4>
						<table style="width: 100%">
						    <tr>
								<td style="height:50px">新開的xx課真的好棒，大家一定要去上啦!!!!</td>
							</tr>
							<tr>
								<td style="text-align:right">李正男2011/01/13</td>
							</tr>
							<tr>
								<td style="height:50px">我認同!!!真的收獲好多!!!!!!</td>
							</tr>
							<tr>
								<td style="text-align:right">李文芳2011/01/20</td>
							</tr>
							<tr>
							<td>留言
							<form method="post" style="text-align:center">
								<input name="Text1" type="text" style="width: 451px; height: 138px" /></form>
							</td>
							</tr>
							<tr>
							<td>
							<form method="post" style="text-align:center">
								<input name="Radio1" type="radio" checked="checked"/>李大同<input name="Radio1" type="radio" />匿名 <input name="Button1" type="button" value="留言" /></form>
							</td>
							</tr>
						</table>
		<span style="background-color:#ffffff;height:10px;width:575px;display:block"></span>
</div>

</asp:Content>

