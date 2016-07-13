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
     *          <Filter Type="">Filterword</Filter>
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

        internal static Filter[] GetGlobalFilters()
        {
            List<Filter> retList = new List<Filter>();

            XmlDocument doc = new XmlDocument();
            doc.Load(Path.Combine(FolderPath, "ani.xml"));

            XmlNode GlobalFilterCont = doc.SelectSingleNode("/Root/GlobalFilters");
            foreach (XmlNode node in GlobalFilterCont.ChildNodes)
            {
                if (node.Name == "Filter")
                {
                    BasicFilter filter = new BasicFilter();
                    filter.Keyword = node.Attributes["Keyword"].InnerText ?? null;
                    filter.FilterWord = node.InnerText;

                    retList.Add(filter);
                }
                else if (node.Name == "Replace")
                {
                    Replace filter = new Replace();
                    filter.Keyword = node.Attributes["Keyword"].InnerText ?? null;

                    filter.From = node.Attributes["From"].InnerText;
                    filter.To = node.InnerText;

                    retList.Add(filter);
                }
            }

            return retList.ToArray();
        }

        internal static Website2[] GetWebsiteFilters()
        {
            List<Website2> retList = new List<Website2>();

            XmlDocument doc = new XmlDocument();
            doc.Load(Path.Combine(FolderPath, "ani.xml"));

            XmlNode WebsiteFilterCont = doc.SelectSingleNode("/Root/WebsiteFilters");
            foreach (XmlNode node in WebsiteFilterCont.ChildNodes)
            {
                Website2 web = new Website2();
                web.Keyword = node.Attributes["Keyword"].InnerText; // Must have Keyword

                List<Filter> filters = new List<Filter>();
                foreach (XmlNode n in node.ChildNodes)
                {
                    if (n.Name == "Replace")
                    {
                        Replace filter = new Replace();
                        filter.Keyword = n.Attributes["Keyword"].InnerText ?? null;

                        filter.From = n.Attributes["From"].InnerText;
                        filter.To = n.InnerText;

                        filters.Add(filter);
                    }
                    else if (n.Name == "RemoveFromStart")
                    {
                        RemoveFromStart filter = new RemoveFromStart();
                        filter.Keyword = n.Attributes["Keyword"].InnerText ?? null;

                        filter.Char = n.InnerText.ToCharArray()[0];

                        filters.Add(filter);
                    }
                    else if (n.Name == "RemoveFromChar")
                    {
                        RemoveFromChar filter = new RemoveFromChar();
                        filter.Keyword = n.Attributes["Keyword"].InnerText ?? null;

                        filter.Char = n.InnerText.ToCharArray()[0];

                        filters.Add(filter);
                    }
                    else if (n.Name == "RemoveInBetween")
                    {
                        RemoveInBetween filter = new RemoveInBetween();
                        filter.Keyword = n.Attributes["Keyword"].InnerText ?? null;

                        filter.FirstChar = n.Attributes["FirstChar"].InnerText.ToCharArray()[0];
                        filter.LastChar = n.InnerText.ToCharArray()[0];

                        filters.Add(filter);
                    }
                    else if (n.Name == "Filter")
                    {
                        BasicFilter filter = new BasicFilter();
                        filter.Keyword = n.Attributes["Keyword"].InnerText ?? null;

                        filter.FilterWord = n.InnerText;

                        filters.Add(filter);
                    }
                    else if (n.Name == "Add")
                    {
                        BasicAdd filter = new BasicAdd();
                        filter.Keyword = n.Attributes["Keyword"].InnerText ?? null;

                        filter.AddWord = n.InnerText;

                        filters.Add(filter);
                    }
                }
                web.Filters = filters.ToArray();
                retList.Add(web);
            }

            return retList.ToArray();
        }
    }
}
