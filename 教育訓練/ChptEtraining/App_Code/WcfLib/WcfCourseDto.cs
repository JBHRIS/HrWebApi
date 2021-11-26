using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// WcfCourseDto 的摘要描述
/// </summary>
[DataContract]
public class WcfCourseDto
{
    [DataMember]
    public int ClassId { get; set; }
    [DataMember]
    public string CourseCode { get; set; }
    [DataMember]
    public string CourseName { get; set; }
    [DataMember]
    public string CourseCategoryCode { get; set; }
    [DataMember]
    public string CourseCategoryName { get; set; }
    [DataMember]
    public DateTime CourseDateB { get; set; }
    [DataMember]
    public DateTime CourseDateE { get; set; }
}