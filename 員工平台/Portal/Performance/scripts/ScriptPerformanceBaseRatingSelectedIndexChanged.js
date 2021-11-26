function <FunName>(sender, eventArgs) {
    txtBonusDeduct = $find("<BonusDeduct>");
    txtBonusMax = $find("<BonusMax>");
    txtBonusDeduct1 = $find("<BonusDeduct1>");
    txtBonusMax1 = $find("<BonusMax1>");
    txtBonusAdjust = $find("<BonusAdjust>");
    txtBonusAdjustTemp = $find("<BonusAdjustTemp>");
    txtBonusAdjustTempText = $get("<BonusAdjustTemp>" + "_text");
    ttBonusAdjust = $find("<ttBonusAdjust>");

    if (eventArgs != null) {
        var index = eventArgs.get_index();

        if (index >= 0) {
            switch (index) {
                <Case>
                default:
                    txtBonusDeduct.set_value(0);
                    txtBonusMax.set_value(0);
                    txtBonusDeduct1.set_value(0);
                    txtBonusMax1.set_value(0);
                    txtBonusAdjust.set_maxValue(0);
                    txtBonusAdjust.set_minValue(0);
                    ttBonusAdjust.set_text("");
            }
        }
    }
}