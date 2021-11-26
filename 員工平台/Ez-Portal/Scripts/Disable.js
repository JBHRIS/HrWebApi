//function click() {
//    alert('禁止左鍵複製')
//}
//function click1() {
//    if (event.button == 2) { alert('禁止右鍵') } 
//}
//function CtrlKeyDown() {
//    if (event.ctrlKey) { alert('禁止複製') }
//}
//document.onkeydown = CtrlKeyDown;
//document.onselectstart = click;
//document.onmousedown = click1;

function iEsc() { return false; }
function iRec() { return true; }
function DisableKeys() {
    if (event.ctrlKey || event.shiftKey || event.altKey) {
        window.event.returnValue = false;
        iEsc();
    }
}
document.ondragstart = iEsc;
document.onkeydown = DisableKeys;
document.oncontextmenu = iEsc;
if (typeof document.onselectstart != "undefined")
    document.onselectstart = iEsc;
else {
    document.onmousedown = iEsc;
    document.onmouseup = iRec;
}

function OnLoad() {
    Clipboard();
}

function DisableRightClick(qsyzDOTnet) {
    if (window.Event) {
        if (qsyzDOTnet.which == 2 || qsyzDOTnet.which == 3)
            iEsc();
    }
    else
        if (event.button == 2 || event.button == 3) {
            event.cancelBubble = true
            event.returnValue = false;
            iEsc();
        }
}

function Clipboard() {
    try {
        if (!(clipboardData.getData("URL") || clipboardData.getData("Text")))
            window.clipboardData.clearData();
    }
    catch (e) {
        window.clipboardData.clearData();
    }
    setTimeout(function () { clipboard(); }, 700)
}
