using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Class1 的摘要描述
/// </summary>
public class ProductViewModel
{
    public int? ProductID { get; set; }
    public string ProductName { get; set; }
    public System.Nullable<decimal> UnitPrice { get; set; }
    public string CategoryName { get; set; }
    public int? CategoryID { get; set; }
    public int? SupplierID { get; set; }
    public bool Discontinued { get; set; }
}