function checkShowPasswordVisibility() {
    var $revealEye = $telerik.$(this).parent().find(".reveal-eye");
    if (this.value) {
        $revealEye.addClass("is-visible");
    } else {
        $revealEye.removeClass("is-visible");
    }
}
function OnLoad(sender, args) {
    pw = sender;
    pw.focus();
    pw.blur();

    var $revealEye = $telerik.$('<span class="reveal-eye"></span>')

    $telerik.$(sender.get_element()).parent().append($revealEye);
    $telerik.$(sender.get_element()).on("keyup", checkShowPasswordVisibility)

    $revealEye.on({
        mousedown: function () { sender.get_element().setAttribute("type", "text") },
        mouseup: function () { sender.get_element().setAttribute("type", "password") },
        mouseout: function () { sender.get_element().setAttribute("type", "password") }
    });
}