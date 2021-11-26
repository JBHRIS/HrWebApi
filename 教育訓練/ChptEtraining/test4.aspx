<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test4.aspx.cs" Inherits="test4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
        function StopAllMedia() {
            //var elements = document.getElementsByTagName("object");
            var ele = document.getElementById("Player");
            //var i = 0;
            // for (i = 0; i < elements.length; i++) {
            //    stopMedia(document.getElementById(elements[i].id));
            // }
            stopMedia(ele);
        }
        function StartMeUp() {
            var ele = document.getElementById("Player");
            var wmp = new Object();
            wmp.wmv = ele.object;
            wmp.wmv.controls.play();
            //Player.controls.play();
        }

        function ShutMeDown() {
            var ele = document.getElementById("Player");
            var wmp = new Object();
            wmp.wmv = ele.object;
            wmp.wmv.controls.pause();
            //    vid.wmv = d.getElementById('Player').object;
            //    vid.stop();
            //Player.controls.stop();
        }


        function stopMedia(mediaPlayer) {
            var wmp = new Object();
            wmp.wmv = mediaPlayer.object;
            wmp.wmv.controls.pause();
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
            <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        </telerik:RadScriptManager>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="RadScriptManager1">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RadScriptManager1" />
                            <telerik:AjaxUpdatedControl ControlID="form1" />
                            <telerik:AjaxUpdatedControl ControlID="Timer1" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RadScriptManager1" />
                            <telerik:AjaxUpdatedControl ControlID="form1" />
                            <telerik:AjaxUpdatedControl ControlID="Timer1" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>
    <div>


    <object id="audio" width="100%" height="65" classid="CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6" type="application/x-oleobject" name="mediaPlayer">
   <param name="URL" value="f641981e-4fa6-4a0b-abd1-3e11bee40fb1.wmv"/>
   <param name="SendPlayStateChangeEvents" value="true"/>
   <param name="AutoStart" value="false"/>
   <param name="PlayCount" value="1"/>
   <param name="stretchtofit" value="true"/>
   <param name="showstatusbar" value="true"/>
   <param name="enablepositioncontrols" value="true"/>
   <param name="showpositioncontrols" value="true"/>
   <param name="enabletracker" value="true"/>
   <param name="showcontrols" value="true"/>
   <param name="showaudiocontrols" value="true"/>
   <param name="enablecontextmenu" value="true"/>
</object>


<input type="BUTTON" name="BtnPlay" value="Play" OnClick="StartMeUp()">
<input type="BUTTON" name="BtnStop" value="Stop" OnClick="StopAllMedia()">


            <asp:Timer ID="Timer1" runat="server" Interval="10000" 
            ontick="Timer1_Tick" >
            </asp:Timer>
        <br />
        <br />
        <telerik:RadUpload ID="RadUpload1" Runat="server">
        </telerik:RadUpload>
    </div>

    <br />
            <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server">
            </telerik:RadAsyncUpload>
            <br />
            <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" Culture="zh-TW" 
                GridLines="None" onneeddatasource="RadGrid1_NeedDataSource">
                <ClientSettings>
                    <Selecting AllowRowSelect="True" />
                </ClientSettings>
<MasterTableView>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid>
    </form>
</body>
</html>
