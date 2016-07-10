using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Security.Cryptography;

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

        /// <summary>
        /// Reads login data from XML (stored in base64) and decrypts it to plain text login data.
        /// </summary>
        /// <returns>The method returns Secrets object containing plain text login data.</returns>
        internal static Secrets ReadSecrets()
        {
            Secrets ret = new Secrets();
            XmlDocument secrets = new XmlDocument();
            secrets.Load(Path.Combine(FolderPath, "secrets.xml"));

            XmlNode root = secrets.SelectSingleNode("Secrets");
            byte[] lol = { 0 };
            ret.email = Encoding.UTF8.GetString(ProtectedData.Unprotect(Convert.FromBase64String(root.FirstChild.InnerText), lol, DataProtectionScope.CurrentUser));
            ret.password = Encoding.UTF8.GetString(ProtectedData.Unprotect(Convert.FromBase64String(root.LastChild.InnerText), lol, DataProtectionScope.CurrentUser));
            return ret;
        }
        
        /// <summary>
        /// Encrypts login data and writes it to XML as a base64 string.
        /// </summary>
        /// <param name="secrets">Object containing plain text login data.</param>
        internal static void WriteSecrets(Secrets secrets)
        {
            byte[] lol = { 0 };
            Secrets to_write = new Secrets();

            to_write.email = Convert.ToBase64String(ProtectedData.Protect(Encoding.UTF8.GetBytes(secrets.email), lol, DataProtectionScope.CurrentUser));
            to_write.password = Convert.ToBase64String(ProtectedData.Protect(Encoding.UTF8.GetBytes(secrets.password), lol, DataProtectionScope.CurrentUser));
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Secrets));
            StreamWriter wfile = new StreamWriter(Path.Combine(FolderPath, "secrets.xml"));
            writer.Serialize(wfile, to_write);
        }
    }
}
