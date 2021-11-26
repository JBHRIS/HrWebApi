function <FunName>() {
    var ddl = $find("<Target>");
    if (ddl) {
        var item = ddl.get_selectedItem();
        var value = "";
        if (item) {
            value = item.get_value();
            item.unselect();
            item.select();
        }
    }
}