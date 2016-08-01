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

        [Obsolete("Doesn't work, user GetAnimCoverTest() instead", true)]
        public async Task<Bitmap> GetAnimeCover(string title)
        {
            var request = new RestRequest("anime/search.xml", Method.GET);
            request.AddParameter("q", title);
            request.RootElement = "anime";

            var resp = await client.ExecuteTaskAsync(request);

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(resp.Content);
            var url = (xml.SelectSingleNode("anime/entry/image").InnerText);

            Bitmap img = null;
            dlClient.DownloadDataCompleted += (s, e) =>
            {
                if (!e.Cancelled)
                    using (MemoryStream memstream = new MemoryStream(e.Result))
                    {
                        img = new Bitmap(memstream);
                    }
            };
            dlClient.DownloadDataAsync(new Uri(url));

            return img;
        }

        public MalReturn GetMALTitle(string title)
        {
            MalReturn ret = new MalReturn();

            title = title.ToLower();
            var request = new RestRequest("anime/search.xml", Method.GET);
            if (title.Contains("episode"))
                title = title.Remove(title.IndexOf(" episode"));
            request.AddParameter("q", title);
            request.RootElement = "anime";

            var resp = client.Execute(request);

            File.WriteAllText(@"C:\DKBot\resp.xml", resp.Content);

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
    }

    public class MalReturn
    {
        public Bitmap Cover { get; set; }
        public string id { get; set; }
    }
}
