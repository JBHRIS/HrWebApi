function OnLoad() {
    Clipboard();
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
