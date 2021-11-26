function CloseAndRebind(args) {
    GetRadWindow().BrowserWindow.refreshGrid(args);
    GetRadWindow().close();
}

function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow)
        oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
    else if (window.frameElement.radWindow)
        oWindow = window.frameElement.radWindow; //IE (and Moz as well)
    return oWindow;
}

function CancelEdit() {
    GetRadWindow().close();
}

function OpenAlert(msg) {
    alert(msg);
    return false;
}

//Standard Window.confirm
function DeleteConfirm(sender, args) {
    args.set_cancel(!window.confirm("是否刪除？"));
}

function ExcuteConfirm(sender, args) {
    args.set_cancel(!window.confirm("確認執行？"));
}

function ExcuteOnceOnlyConfirm(sender, args) {
    args.set_cancel(!window.confirm("只能執行一次，是否執行？"));
}

//RadConfirm
function RadConfirm(sender, args) {
    var callBackFunction = Function.createDelegate(sender, function (shouldSubmit) {
        if (shouldSubmit) {
            this.click();
        }
    });

    var text = "Are you sure you want to submit the page?";
    radconfirm(text, callBackFunction, 300, 160, null, "RadConfirm");
    args.set_cancel(true);
}

function setCustomPosition(sender, args) {
    sender.moveTo(sender.get_left(), sender.get_top());
}