using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

using AnimeChanger.Ani.FilterTypes;

namespace AnimeChanger.Ani
{
    /*  <Root>
     *      <GlobalFilters>
     *          <Filter Type="Whitelist" Keyword="Keyword">Filterword</Filter>
     *          <Filter>Filterword</Filter>
     *      </GlobalFilters>
     *      <WebsiteFilters>
     *          <Website Keyword="Keyword">
     *              <Filter Keywords="Keyword">FilterWord</Filter>
     *              <Filter>FilterWord</Filter>
     *              <Add Where="Start">Someword</Add>
     *          </Website>
     *      </WebsiteFilters>
     *  </Root>
     */
    internal static class XML
    {
        internal static string FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DoubleKilled_AniChanger");
                               
        //                          Global or website
        //                                 \/
        internal static IEnumerable<Tuple<bool, TypeInt, object>> ReadXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Path.Combine(FolderPath, "ani.xml"));

            XmlNode root = doc.SelectSingleNode("root");
            XmlNodeList nl = root.ChildNodes;

            XmlNode GlobalFilters = root.SelectSingleNode("GlobalFilters");
            foreach (XmlNode node in GlobalFilters.ChildNodes)
            {

            }


            yield return null;
        }
    }
}
