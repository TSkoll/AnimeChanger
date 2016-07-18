using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

using AnimeChanger.Ani.FilterTypes;

namespace AnimeChanger.Ani
{
    internal static class XML
    {
        internal static string FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DoubleKilled_AniChanger");

        /// <summary>
        /// Gets global filters from ani.xml.
        /// </summary>
        /// <returns>An array of Filter, containing filtering information.</returns>
        internal static Filter[] GetGlobalFilters()
        {
            List<Filter> retList = new List<Filter>();

            XmlDocument doc = new XmlDocument();
            doc.Load(Path.Combine(FolderPath, "ani.xml"));

            XmlNode GlobalFilterCont = doc.SelectSingleNode("/Root/GlobalFilters");

            if (GlobalFilterCont.ChildNodes == null) // If there are no Global filters
                return null;

            foreach (XmlNode n in GlobalFilterCont.ChildNodes)
            {
                if (n.Name == "Filter")
                {
                    BasicFilter filter = new BasicFilter();

                    filter.Keyword = GetAttribute(n.Attributes, "Keyword") ?? null;
                    filter.Blacklist = GetAttribute(n.Attributes, "Blacklist") ?? null;

                    filter.FilterWord = n.InnerText;

                    retList.Add(filter);
                }
                else if (n.Name == "Replace")
                {
                    Replace filter = new Replace();

                    filter.Keyword = GetAttribute(n.Attributes, "Keyword") ?? null;
                    filter.Blacklist = GetAttribute(n.Attributes, "Blacklist") ?? null;

                    filter.From = n.Attributes["From"].InnerText;
                    filter.To = n.InnerText;

                    retList.Add(filter);
                }
            }

            return retList.ToArray();
        }

        /// <summary>
        /// Gets website filters from ani.xml.
        /// </summary>
        /// <returns>An array of Website, contains filtering information for every read website filter.</returns>
        internal static Website[] GetWebsiteFilters()
        {
            List<Website> retList = new List<Website>();

            XmlDocument doc = new XmlDocument();
            doc.Load(Path.Combine(FolderPath, "ani.xml"));

            XmlNode WebsiteFilterCont = doc.SelectSingleNode("/Root/WebsiteFilters");

            if (WebsiteFilterCont.ChildNodes == null)
                return null;

            foreach (XmlNode node in WebsiteFilterCont.ChildNodes)
            {
                Website web = new Website();
                web.Keyword = node.Attributes["Keyword"].InnerText; // Must have Keyword

                if (node.Attributes["Blacklist"] != null)
                    web.Blacklist = node.Attributes["Blacklist"].InnerText;
                else
                    web.Blacklist = null;

                List<Filter> filters = new List<Filter>();
                foreach (XmlNode n in node.ChildNodes)
                {
                    if (n.Name == "Replace")
                    {
                        Replace filter = new Replace();

                        filter.Keyword = GetAttribute(n.Attributes, "Keyword") ?? null;
                        filter.Blacklist = GetAttribute(n.Attributes, "Blacklist") ?? null;

                        filter.From = n.Attributes["From"].InnerText;
                        filter.To = n.InnerText;

                        filters.Add(filter);
                    }
                    else if (n.Name == "RemoveFromStart")
                    {
                        RemoveFromStart filter = new RemoveFromStart();

                        filter.Keyword = GetAttribute(n.Attributes, "Keyword") ?? null;
                        filter.Blacklist = GetAttribute(n.Attributes, "Blacklist") ?? null;

                        filter.Char = n.InnerText.ToCharArray()[0];

                        filters.Add(filter);
                    }
                    else if (n.Name == "RemoveFromChar")
                    {
                        RemoveFromChar filter = new RemoveFromChar();

                        filter.Keyword = GetAttribute(n.Attributes, "Keyword") ?? null;
                        filter.Blacklist = GetAttribute(n.Attributes, "Blacklist") ?? null;

                        filter.Char = n.InnerText.ToCharArray()[0];

                        filters.Add(filter);
                    }
                    else if (n.Name == "RemoveInBetween")
                    {
                        RemoveInBetween filter = new RemoveInBetween();

                        filter.Keyword = GetAttribute(n.Attributes, "Keyword") ?? null;
                        filter.Blacklist = GetAttribute(n.Attributes, "Blacklist") ?? null;

                        filter.FirstChar = n.Attributes["FirstChar"].InnerText.ToCharArray()[0];
                        filter.LastChar = n.InnerText.ToCharArray()[0];

                        filters.Add(filter);
                    }
                    else if (n.Name == "Filter")
                    {
                        BasicFilter filter = new BasicFilter();

                        filter.Keyword = GetAttribute(n.Attributes, "Keyword") ?? null;
                        filter.Blacklist = GetAttribute(n.Attributes, "Blacklist") ?? null;


                        filter.FilterWord = n.InnerText;

                        filters.Add(filter);
                    }
                    else if (n.Name == "Add")
                    {
                        BasicAdd filter = new BasicAdd();

                        filter.Keyword = GetAttribute(n.Attributes, "Keyword") ?? null;
                        filter.Blacklist = GetAttribute(n.Attributes, "Blacklist") ?? null;

                        filter.AddWord = n.InnerText;

                        filters.Add(filter);
                    }
                }
                web.Filters = filters.ToArray();
                retList.Add(web);
            }

            return retList.ToArray();
        }

        /// <summary>
        /// Tries to get an attribute from XML element.
        /// </summary>
        /// <param name="AttributeCollection">Attribute collection from where the attribute is gotten.</param>
        /// <param name="Attribute">Attribute name.</param>
        /// <returns>Content of the attribute.</returns>
        private static string GetAttribute(XmlAttributeCollection AttributeCollection, string Attribute)
        {
            if (AttributeCollection != null)
            {
                if (AttributeCollection[Attribute] != null)
                {
                    return AttributeCollection[Attribute].InnerText ?? null;
                }
                else
                    return null;
            }
            else
                return null;
        }
    }
}
