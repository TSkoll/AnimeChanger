using System.Xml;
using System.Drawing;
using RestSharp;
using RestSharp.Authenticators;

namespace AnimeChanger
{
    public class MalWrapper
    {
        private RestClient client = new RestClient("http://myanimelist.net/api/");
        
        public MalWrapper(string username, string password)
        {
            client.Authenticator = new HttpBasicAuthenticator(username, password);
        }

        public Bitmap GetAnimeCover(string title)
        {
            var request = new RestRequest("anime/search.xml", Method.GET);
            request.AddParameter("q", title);
            request.RootElement = "anime";

            IRestResponse resp = client.Execute(request);

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(resp.Content);
            return new Bitmap(xml.SelectSingleNode("anime/entry/image").InnerText);
        }
    }
}
