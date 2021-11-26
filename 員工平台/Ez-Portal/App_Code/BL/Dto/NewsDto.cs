using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
/// <summary>
/// 
/// </summary>

public class NewsDto
{
    public string news_id { get; set; }
    public string news_head { get; set; }
    public string news_body { get; set; }
    public DateTime post_date { get; set; }
    public DateTime post_deadline { get; set; }
    public Boolean is_on { get; set; }
    public string newsfileid { get; set; }
    public long sort { get; set; }
    public int AttachmentCount { get; set; }
    public DateTime? LatestSendMailDate { get; set; }
}