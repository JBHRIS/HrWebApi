using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
/// <summary>
/// 
/// </summary>
[DataContract]
public class SDeptDto
{
    [DataMember]
    public string DeptId { get; set; }
    [DataMember]
    public string DeptName { get; set; }
    [DataMember]
    public string ParentDeptId { get; set; }
}