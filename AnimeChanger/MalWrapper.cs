using System;
using System.Xml;
using System.Drawing;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using System.Web;
using System.Net;
using System.IO;

namespace AnimeChanger
{
    public class MalWrapper
    {
        private RestClient client = new RestClient("http://myanimelist.net/api/");
        private WebClient dlClient = new WebClient();

        public MalWrapper(string username, string password)
        {
            client.Authenticator = new HttpBasicAuthenticator(username, password);
        }

        public void Authenticate(string username, string password)
        {
            client.Authenticator = new HttpBasicAuthenticator(username, password);
        }

        public MalReturn GetMALTitle(string title)
        {
            try
            {
                MalReturn ret = new MalReturn();

                title = title.ToLower();
                var request = new RestRequest("anime/search.xml", Method.GET);
                if (title.Contains("episode"))
                    title = title.Remove(title.IndexOf(" episode"));
                request.AddParameter("q", title);
                request.RootElement = "anime";

                var resp = client.Execute(request);

                if (string.IsNullOrEmpty(resp.Content))
                    return null;

                XmlDocument xml = new XmlDocument();
                xml.LoadXml(resp.Content);

                byte[] bytes = dlClient.DownloadData(new Uri(xml.SelectSingleNode("anime/entry/image").InnerText));

                using (MemoryStream memstream = new MemoryStream(bytes))
                {
                    ret.Cover = new Bitmap(memstream);
                }

                ret.id = xml.SelectSingleNode("anime/entry/id").InnerText;

                return ret;
            }
            catch
            {
                return null;
            }
        }
    }

    public class MalReturn
    {
        public Bitmap Cover { get; set; }
        public string id { get; set; }
    }
}
