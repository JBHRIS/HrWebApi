//Script 必須在HTML之外
//https://iamsbc.blogspot.com/2013/08/aspnet-controls.html
function toggleRadios(sender, args) {
    var radioButtons = $telerik.$(".GenderRadioButton");

    radioButtons.each(function (index, element) {
        var radioButton = element.control;

        if (radioButton !== sender) {
            radioButton.set_checked(false);
        }
    });
}