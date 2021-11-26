using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace GUI.Controls
{
    /// 
    /// Summary description for GvTemplate
    /// 
    public class GvTemplate : ITemplate
    {
        ListItemType _templateType;
        string _columnName;
        string _toolTip;
        string _itemButtonName;
        public GvTemplate(ListItemType type, string columnName, string toolTip, string itemButtonName)
        {
            _templateType = type;
            this._columnName = columnName;
            this._itemButtonName = itemButtonName;
            this._toolTip = toolTip;
        } //eof constructor


        void ITemplate.InstantiateIn(System.Web.UI.Control container)
        {
            switch (_templateType)
            {
                case ListItemType.Header:
                    Label lab = new Label();
                    lab.Text = _columnName;
                    container.Controls.Add(lab);
                    break;
                case ListItemType.Item:
                    Button but = new Button();
                    but.DataBinding += new EventHandler(butDataBinding);
                    but.ToolTip = _toolTip;
                    but.Visible = true;
                    but.Text = "Include"; //todo: parametrize 
                    container.Controls.Add(but);
                    break;
            } //eof switch _templateTyp 

        } //eof method InstantiateIn

        void butDataBinding(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            GridViewRow container = (GridViewRow)but.NamingContainer;
            object dataValue =  DataBinder.Eval(container.DataItem, _columnName);
            
            if (dataValue != null && dataValue != DBNull.Value)
            {
                but.ID = dataValue.ToString();
                but.CommandName = "selectItem"; //todo:parametrize
                but.CommandArgument = System.Convert.ToString(dataValue);
                but.Text = System.Convert.ToString(dataValue);
                but.Click += new EventHandler(ClickSelectItem);
            }


        } //eof method butDataBinding 


        protected void but_Command(Object sender, CommandEventArgs e)
        {
        }

        protected void ClickSelectItem(Object sender, EventArgs e)
        {
            Button but = (Button)sender;
            //Utils.Debugger.WriteIf("I have been clicked by " + but.ID);
            new Page().Session["global.ClickedItemId"] = but.ID;
        } //eof method edit_button_Click

    } //eof class 
} //eof namespace GUI.Controls
