<%@ Page Title="" Language="C#" MasterPageFile="~/mpMT0990113.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="OnLineSign_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <!------------ 插入控制碼區段開始 ------------>
            <!--將下面程式碼複製至 <body> 標籤後-->

            <script language="JavaScript">
<!--
                var TimerOrClock = "clock";

                //layer height
                var layerH = 30;  //指定這個特效的高度

                //layer width
                var layerW = 180;  //指定這個特效的寬度

                //location of the layer on the page:
                //top_left, top_right, "bottom_left", "bottom_right"
                var location = "top_right";

                //background color of the layer:
                //transparent - inherits the background of the page;
                //any color as a word or in hexadecimal
                var bgcolor = "#64D0FE";  //指定顯示背景顏色

                //font color
                var text = "#FF0000";  //指定顯示文字顏色

                //font size
                var font_size = 5;

                //font face
                var font_face = "新明細體";

                //your words
                var message = "現在時間：";

                /***************** DO NOT EDIT BELOW THIS LINE ***************/
                var layer;
                var IE = document.all;
                var updateWatch;
                var start = 0;

                function writeTime(time) {
                    var color, size, face, out;

                    color = (text) ? text : "black";
                    size = (font_size) ? font_size : 2;
                    face = (font_face) ? font_face : "Arial";

                    out = "<font face = \"" + face + "\" size = " + size + " color = \"" + color + "\">";
                    out += (message) ? message : "";

                    if (!IE)
                        out += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + time + "</font>";
                    else
                        out += time + "</font>";

                    if (IE)
                        layer.innerHTML = "<table width=\"100%\" height=\"100%\"><tr><td valign=\"middle\" align=\"center\">" + out + "</td></tr></table>";
                    else {
                        layer.document.open();
                        layer.document.write("<br> &nbsp;" + "<b>" + out + "</b>");
                        layer.document.close();
                    }
                }

                function clock() {
                    var hh, mm, ss;
                    var time, d, ampm = "am";

                    d = new Date();

                    hh = d.getHours();
                    mm = d.getMinutes();
                    ss = d.getSeconds();

                    if (hh > 12) {
                        hh -= 12;
                        ampm = "pm";
                    }

                    hh = (hh < 10) ? "0" + hh : hh;
                    mm = (mm < 10) ? "0" + mm : mm;
                    ss = (ss < 10) ? "0" + ss : ss;

                    time = hh + ":" + mm + ":" + ss + "  " + ampm;

                    writeTime(time);
                }

                function timer() {
                    var hh, mm, ss;
                    var time;

                    hh = parseInt("0" + (start / 3600), 10);
                    mm = parseInt("0" + ((start - (hh * 3600)) / 60), 10);
                    ss = start - (hh * 3600) - (mm * 60);

                    if (start < 60)
                        time = ss + " seconds ";

                    else if (start < 3600 && start > 60)
                        time = mm + " minutes " + ss + " seconds ";

                    else {
                        time = (hh == 1) ? hh + " hour " : hh + " hours ";
                        time += (mm == 1) ? mm + " minute " : mm + " minutes ";
                    }
                    writeTime(time);
                    start++;
                }

                function scroller() {
                    var docH, docW, scrollT, scrollL;

                    if (IE) {
                        layer = document.all.pane;

                        if (layerH) {
                            layer.height = layerH;
                            layer.style.height = layerH;
                        }
                        else
                            layerH = layer.height;

                        if (layerW) {
                            layer.width = layerW;
                            layer.style.width = layerW;
                        }
                        else
                            layerW = layer.width;

                        if (bgcolor)
                            layer.style.background = bgcolor;


                        docH = document.body.clientHeight;
                        docW = document.body.clientWidth;

                        scrollT = document.body.scrollTop;
                        scrollL = document.body.scrollLeft;

                        switch (location) {
                            case "top_left": layer.style.posTop = scrollT;
                                layer.style.posLeft = scrollL;
                                break;

                            case "top_right": layer.style.posTop = scrollT;
                                layer.style.posLeft = scrollL + (docW - layerW);
                                break;

                            case "bottom_left": layer.style.posTop = scrollT + (docH - layerH);
                                layer.style.posLeft = scrollL;
                                break;

                            case "bottom_right": layer.style.posTop = scrollT + (docH - layerH);
                                layer.style.posLeft = scrollL + (docW - layerW);
                                break;

                            default: layer.style.posTop = scrollT;
                                layer.style.posLeft = scrollL;
                        }
                        layer.style.visibility = "visible";
                    }
                    else {

                        layer = document.layers.pane;

                        if (!layerH)
                            layerH = 200;

                        if (!layerW)
                            layerW = 100;


                        layer.resizeTo(layerW, layerH);

                        if (bgcolor && bgcolor != "transparent")
                            layer.bgColor = bgcolor;


                        docH = window.innerHeight;
                        docW = window.innerWidth;

                        scrollT = window.pageYOffset;
                        scrollL = window.pageXOffset;

                        switch (location.toLowerCase()) {
                            case "top_left": layer.moveTo(scrollL, scrollT);
                                break;

                            case "top_right": layer.moveTo(scrollL + (docW - layerW) - 15, scrollT);
                                break;

                            case "bottom_left": layer.moveTo(scrollL, scrollT + (docH - layerH) - 15);
                                break;

                            case "bottom_right": layer.moveTo(scrollL + (docW - layerW) - 15, scrollT + (docH - layerH) - 15);
                                break;

                            default: layer.moveTo(scrollL, scrollT);
                        }

                        //make layer visible   
                        layer.visibility = "show";
                    }
                }
//-->
            </script>

            <span id="pane">
                <layer name="pane" width="&{layerW};" height="&{layerH};"></layer>
            </span>

            <script>
<!--
                setInterval("scroller();", 10);
                if (TimerOrClock.toLowerCase() == "clock")
                    setInterval("clock();", 1000);
                else
                    setInterval("timer();", 1000);
//-->
            </script>

            <!------------ 插入控制碼區段結束 ------------>
            <table class="TableFullBorder">
                <tr>
                    <td colspan="2">
                        <p>
                            員工簽到注意事項：
                            <br>
                            <font color="#cc0000">1. 請入輸您的員工工號後 ，按"簽到確認"！畫面會彈出您的簽到時間！</font><br>
                            <font color="#cc0000">2. "簽到確認"後 五分鐘內，再次簽到系統會提示錯誤！！</font></p>
                    </td>
                </tr>
                <tr>
                    <th nowrap="nowrap" width="20%">
                        簽到時間
                    </th>
                    <td>
                        <asp:Label ID="lblTime" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th nowrap="nowrap" width="20%">
                        員工工號
                    </th>
                    <td>
                        <asp:TextBox ID="txtNobr" runat="server" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="lblIP" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnSign" runat="server" Text="簽到確認" onclick="btnSign_Click" />
                        <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="Large" 
                            ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
<BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
