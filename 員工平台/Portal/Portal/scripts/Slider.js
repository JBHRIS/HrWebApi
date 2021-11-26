(function (global) {
    function OnClientValueChanged(slider, args) {
        // Show the tooltip only while the slider handle is sliding. In case the user simply clicks on the track of the slider to change the value
        // the change will be quick and the tooltip will show and hide too quickly.
        if (!isSliding) {
            return;
        }
        var tooltip = getTooltip();
        global.setTimeout(function () {
            updateToolTipText(tooltip, slider);
        }, 30);
    }

    var isSliding = false;
    function OnClientSlideStart(slider, args) {
        isSliding = true;
        showRadToolTip(slider);
    }

    function OnClientSlide(slider, args) {
        resetToolTipLocation(getTooltip());
    }

    function OnClientSlideRangeStart(slider, args) {
        isSliding = true;
        showRadToolTip(slider);
    }

    function OnClientSlideRange(slider, args) {
        resetToolTipLocation(getTooltip());
    }

    function OnClientSlideEnd(slider, args) {
        isSliding = false;
        getTooltip().hide();
    }

    function OnClientSlideRangeEnd(slider, args) {
        isSliding = false;
        getTooltip().hide();
    }

    function showRadToolTip(slider) {
        var tooltip = getTooltip();
        tooltip.set_targetControl($get("RadSliderSelected_" + slider.get_id()));
        resetToolTipLocation(tooltip);
        global.setTimeout(function () {
            updateToolTipText(tooltip, slider);
        }, 30);
    }

    function resetToolTipLocation(tooltip) {
        if (!tooltip.isVisible()) {
            global.setTimeout(function () {
                tooltip.show();
            }, 20);
        }
        else {
            tooltip.updateLocation();
        }
    }

    function updateToolTipText(tooltip, slider) {
        var div = document.createElement("div");
        div.style.whiteSpace = "nowrap";
        if (slider.get_itemType() == Telerik.Web.UI.SliderItemType.Item) {
            div.innerHTML = (slider.get_selectedItems()[0].get_text() + " / " + slider.get_selectedItems()[1].get_text());
        }
        else {
            div.innerHTML = (slider.get_selectionStart() + " / " + slider.get_selectionEnd());
        }

        tooltip.set_contentElement(div);
    }

    global.OnClientValueChanged = OnClientValueChanged;
    global.OnClientSlideStart = OnClientSlideStart;
    global.OnClientSlide = OnClientSlide;
    global.OnClientSlideRangeStart = OnClientSlideRangeStart;
    global.OnClientSlideRange = OnClientSlideRange;
    global.OnClientSlideEnd = OnClientSlideEnd;
    global.OnClientSlideRangeEnd = OnClientSlideRangeEnd;

})(window);