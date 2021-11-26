<%@ Page Title="" Language="C#" MasterPageFile="~/mpLearningFront.master" AutoEventWireup="true" CodeFile="lnTest.aspx.cs" Inherits="eLearning_lnTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="news">
		<span style="background-color:#ffffff;height:10px;width:575px;display:block"></span>
		<h4>線上測試</h4>
		<div>
		<form method="post">
				<select name="Select1" style="width: 100px">
				<option>程式設計</option> 
				</select> <select name="Select2" style="width: 100px">
				<option>C#.net</option>
				<option>PHP</option>
				</select> <select name="Select3" style="width: 100px">
				<option>基礎認知</option>
				<option>進階認知</option>
				</select> </form>
		</div>
			<table style="width: 100%;margin:10px 0 0 0">
						
							<tr style="background-color:#B1E7F3">
								<td>試卷名稱</td>
								<td>試卷難度</td>
								<td>對應課程</td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td>C#.NET-1</td>
								<td><img alt="2" src="../IMAGES/star.png" width="20" height="20"/><img alt="2" src="../IMAGES/star.png" width="20" height="20"/></td>
								<td>程式設計-C#.NET-基礎認知</td>
								<td><a href="" style="text-decoration:underline">報名</a></td>
							</tr>
							<tr>
								<td>程式設計</td>
								<td><img alt="2" src="../IMAGES/star.png" width="20" height="20"/><img alt="2" src="../IMAGES/star.png" width="20" height="20"/><img alt="2" src="../IMAGES/star.png" width="20" height="20"/></td>
								<td>程式設計-C#.NET-進階認知</td>
								<td><a href="" style="text-decoration:underline">報名</a></td>
							</tr>
							<tr>
								<td></td>
								<td></td>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
						</table>
				<span style="background-color:#ffffff;height:10px;width:575px;display:block"></span>

</div>

</asp:Content>

