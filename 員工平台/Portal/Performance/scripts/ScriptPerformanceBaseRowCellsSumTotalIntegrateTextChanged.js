var SumInput<FunName> = 0.0;
var TempValue<FunName> = 0.0;

function Load<FunName>(sender, args) {
    SumInput<FunName> = sender;
}
function Blur<FunName>(sender, args) {
    SumInput<FunName>.set_value(TempValue<FunName> + sender.get_value());
}
function Focus<FunName>(sender, args) {
    TempValue<FunName> = SumInput<FunName>.get_value() - sender.get_value();
}