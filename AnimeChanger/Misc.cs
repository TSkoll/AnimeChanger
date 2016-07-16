using System;
using System.Collections.Generic;
using System.Text;
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
                File.WriteAllText(Path.Combine(FolderPath, "ani.xml"), Properties.Resources.ani);
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

            try
            {
                XmlNode root = secrets.SelectSingleNode("Secrets");
                byte[] lol = { 0 };
                ret.email = Encoding.UTF8.GetString(ProtectedData.Unprotect(Convert.FromBase64String(root.FirstChild.InnerText), lol, DataProtectionScope.CurrentUser));
                ret.password = Encoding.UTF8.GetString(ProtectedData.Unprotect(Convert.FromBase64String(root.LastChild.InnerText), lol, DataProtectionScope.CurrentUser));
            }
            catch (SystemException ex)
            {
                if (ex is CryptographicException || ex is FormatException)
                {
                    System.Windows.Forms.MessageBox.Show(String.Format("(Error: {0})\nCouldn't retrieve login credentials. Please re-enter your login data.", ex.GetType().ToString()), "Error");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                ret = null;
            }

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
            using (StreamWriter wfile = new StreamWriter(Path.Combine(FolderPath, "secrets.xml")))
                writer.Serialize(wfile, to_write);
        }
    }
}
