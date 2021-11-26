using System;
using System.Collections.Specialized;
using System.Text;
using System.Web;

public class FlexUrlEditor : UriBuilder
{
    private readonly NameValueCollection collection;

    public FlexUrlEditor(string url) : base(url)
    {
        collection = HttpUtility.ParseQueryString(new Uri(url).Query, Encoding.UTF8);
    }

    public string this[string key]
    {
        get { return collection[key]; }
        set
        {
            if (value == null && collection[key] != null)
            {
                collection.Remove(key);
            }
            else
            {
                collection[key] = value;
            }
        }
    }

    public string GenUrl()
    {
        //REF: https://goo.gl/gHmGUz
        base.Query = Uri.EscapeUriString(HttpUtility.UrlDecode(collection.ToString()));
        //remove 80/443 port for http/https
        if (base.Uri.IsDefaultPort) base.Port = -1;
        return base.ToString();
    }
}