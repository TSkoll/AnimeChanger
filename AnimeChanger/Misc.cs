using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;


/* <root>
 *  <website keyword="crunchyroll">
 *      <filter>crunchyroll - watch</filter>
 *      <filter> - mozilla firefox</filter>
 *  </website>
 *  <website keyword="crunchyroll">
 *      <filter>crunchyroll - watch</filter>
 *      <filter> - mozilla firefox</filter>
 *  </website>
 *  <website keyword="crunchyroll">
 *      <filter>crunchyroll - watch</filter>
 *      <filter> - mozilla firefox</filter>
 *  </website>
 *  <website keyword="crunchyroll">
 *      <filter>crunchyroll - watch</filter>
 *      <filter> - mozilla firefox</filter>
 *  </website>
 *  <website keyword="crunchyroll">
 *      <filter>crunchyroll - watch</filter>
 *      <filter> - mozilla firefox</filter>
 *  </website>
 *  <website keyword="crunchyroll">
 *      <filter>crunchyroll - watch</filter>
 *      <filter> - mozilla firefox</filter>
 *  </website>
 *  <website keyword="crunchyroll">
 *      <filter>crunchyroll - watch</filter>
 *      <filter> - mozilla firefox</filter>
 *  </website>
 * </root>
 */

namespace AnimeChanger
{
    internal static class Misc
    {
        internal static string FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DoubleKilled_AniChanger");

        internal static void CheckFolder()
        {
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
                File.WriteAllText(Path.Combine(FolderPath, "ani.xml"), "<root> \n </root>");
            }
        }


        internal static IEnumerable<Website> ReadXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Path.Combine(FolderPath, "ani.xml"));

            XmlNode root = doc.SelectSingleNode("root");
            XmlNodeList nl = root.ChildNodes;

            foreach (XmlNode n in nl)
            {
                var w = new Website();
                List<string> filters = new List<string>();

                w.Keyword = n.Attributes["keyword"].InnerText;

                XmlNodeList nl2 = n.ChildNodes;
                foreach (XmlNode n2 in nl2)
                {
                    filters.Add(n2.InnerText);
                }

                w.RemoveStrings = filters.ToArray();
                yield return w;
            }
        }
    }
}
