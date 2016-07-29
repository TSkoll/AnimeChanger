using System.Xml;
using System.Drawing;
using System.Threading.Tasks;
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

        public void Authenticate(string username, string password)
        {
            client.Authenticator = new HttpBasicAuthenticator(username, password);
        }

        public async Task<Bitmap> GetAnimeCover(string title)
        {
            var request = new RestRequest("anime/search.xml", Method.GET);
            request.AddParameter("q", title);
            request.RootElement = "anime";

            var resp = await client.ExecuteTaskAsync(request);

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(resp.Content);
            return new Bitmap(xml.SelectSingleNode("anime/entry/image").InnerText);
        }
    }
}
