var SumInput<FunName> = 0.0;
var TempValue<FunName> = 0.0;

function Load<FunName>(sender, args) {
    SumInput<FunName> = sender;
}
function Blur<FunName>(sender, args) {
    var BonusAdjust =  sender.get_value();          
    SumInput<FunName>.set_value(TempValue<FunName> + BonusAdjust);
    SumInput.set_value(TempValue - BonusAdjust);
}
function Focus<FunName>(sender, args) {
    var BonusAdjust =  sender.get_value();                          
    TempValue<FunName> = SumInput<FunName>.get_value() - BonusAdjust;
    TempValue = SumInput.get_value() + BonusAdjust;
}

function ValueChanged<FunName>(sender, args) {
    //debugger;
                            
    var BonusAdjust = $find("<BonusAdjust>");
    var BonusAdjustTemp = $find("<BonusAdjustTemp>");
    var BonusAdjustValue = BonusAdjust.get_value();
    BonusAdjustTemp.set_value(BonusAdjustValue);



    //var BonusAdjust = $find("<BonusAdjust>");
    //var BonusAdjustStyle = BonusAdjust._textBoxElement.style.cssText;;
    //BonusAdjust._textBoxElement.style.cssText = 'background-color:yellow;';

    //var BonusAdjustTemp = $find("<BonusAdjustTemp>");
    //var BonusDeduct1 = $find("<BonusDeduct1>");
    //var BonusMax1 = $find("<BonusMax1>");
    //var BonusAdjustStyle = BonusAdjustTemp._textBoxElement.style.cssText;;
    //var BonusAdjustStyleError = BonusAdjustStyle + 'background-color:yellow;';
    //var BonusAdjustValue = BonusAdjust.get_value();
    //var BonusDeduct1Value = BonusDeduct1.get_value();
    //var BonusMax1Value = BonusMax1.get_value();
    //if (BonusAdjustValue < BonusDeduct1Value || BonusAdjustValue > BonusMax1Value) {
    //    BonusAdjust._textBoxElement.style.cssText = BonusAdjustStyleError;
	   // for (var style in BonusAdjust.get_styles()) {
		  //  style = BonusAdjustStyleError;
	   // }
    //} else {
    //    BonusAdjust._textBoxElement.style.cssText = BonusAdjustStyle;
	   // for (var style in BonusAdjust.get_styles()) {
		  //  style = BonusAdjustStyleError;
	   // }
    //}
    //BonusAdjust.updateCssClass();
}
function Error<FunName>(sender, args) {
    debugger;                   
    var BonusAdjust = $find("<BonusAdjust>");
    var BonusAdjustTemp = $find("<BonusAdjustTemp>");
    var BonusAdjustValue = args.get_inputText();
    BonusAdjustTemp.set_value(BonusAdjustValue);
    //args.set_cancel(true);
}