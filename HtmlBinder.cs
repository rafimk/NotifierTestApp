using Microsoft.AspNetCore;

namespace NotifierTestApp
{
    public class HtmlBinder
    {
        public HtmlBinder()
        {

        }

        public string Create()
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/sample.htm")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{UserName}", "test");
            body = body.Replace("{Title}", "test-title");
            body = body.Replace("{Url}", "test-url");
            body = body.Replace("{Description}", "description");
            return body;
        }
    }
}