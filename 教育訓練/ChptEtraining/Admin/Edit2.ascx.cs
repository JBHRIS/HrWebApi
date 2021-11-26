using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

using Telerik.Web.UI;

public partial class Admin_Edit2 : System.Web.UI.UserControl, IBindableControl
{
    #region IBindableControl Members

    public void ExtractValues(IOrderedDictionary dictionary)
    {
        //retrives all RadInputs and add thier values to the dictionary
        foreach (var input in Controls.OfType<RadInputControl>().Select(control => new { FieldName = control.ID, FieldValue = control.Text }))
            dictionary.Add(input.FieldName, input.FieldValue);
    }

    #endregion

    public object DataItem { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if ((DataItem != null) && !(DataItem is Telerik.Web.UI.GridInsertionObject))
            fv.DefaultMode = FormViewMode.Edit;
    }

    protected void fv_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        e.NewValues["sKeyMan"] = "ming";
        e.NewValues["dKeyDate"] = DateTime.Now;
    }
    protected void fv_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {

    }
    protected void fv_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        e.Values["sKeyMan"] = "ming";
        e.Values["dKeyDate"] = DateTime.Now;
    }
    protected void fv_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {

    }
    protected void fv_ItemDeleting(object sender, FormViewDeleteEventArgs e)
    {

    }
    protected void fv_ItemDeleted(object sender, FormViewDeletedEventArgs e)
    {

    }
    protected void fv_ItemCommand(object sender, FormViewCommandEventArgs e)
    {
        int A = 1;
    }
}