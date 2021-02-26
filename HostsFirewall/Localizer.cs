using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;

namespace HostsFirewall
{
	public static class Localizer
	{
		private static Dictionary<string, string> languageValuePair;

		/// <summary>
		/// Returns a localized string
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static string GetValue(string key)
		{
			if (languageValuePair.ContainsKey(key))
			{
				return languageValuePair[key];
			}
			return key;
		}

		/// <summary>
		/// Loads the language based on System language
		/// </summary>
		static Localizer()
		{
			languageValuePair = new Dictionary<string, string>();

			LoadEmbeddedLanguageResource("en_US");
			LoadEmbeddedLanguageResource(CultureInfo.CurrentUICulture.Name);
		}

		private static string TryGetXmlAttribute(XmlElement element, string attributeName)
		{
			return TryGetXmlAttribute(element, attributeName, attributeName);
		}

		private static string TryGetXmlAttribute(XmlElement element, string attributeName, string defaultValue)
		{
			if (element.HasAttribute(attributeName))
			{
				return element.Attributes[attributeName].Value;
			}
			return defaultValue;
		}

		private static void LoadEmbeddedLanguageResource(string langCode)
		{
			// Sanitize
			langCode = langCode.Replace('-', '_');
			Debug.WriteLine($"Loading embedded language \"{langCode}\"!");
			var assembly = Assembly.GetExecutingAssembly();
			string XmlText = "";
			var localizedLanguage = "HostsFirewall.Lang." + langCode + ".xml";

			foreach (string res in assembly.GetManifestResourceNames())
			{
				if (localizedLanguage == res)
				{
					// Grab the resource from the assembly
					using (Stream stream = assembly.GetManifestResourceStream(localizedLanguage))
					using (StreamReader reader = new StreamReader(stream))
					{
						XmlText = reader.ReadToEnd();
					}

					// Check if it isn't null if we somehow managed to circumvent all that null protection code
					if (XmlText.Length > 0)
					{
						// Load up the xml from the location 
						XmlDocument xml = new XmlDocument();
						xml.LoadXml(XmlText);

						// Select the language elements
						XmlNodeList xnList = xml.SelectNodes("/lang/il8n");
						foreach (XmlElement xn in xnList)
						{
							// Grab the data from the xml document
							string key = TryGetXmlAttribute(xn, "id");
							string value = xn.FirstChild.Value;

							// Update or add
							if (languageValuePair.ContainsKey(key))
							{
								languageValuePair[key] = value;
							}
							else
							{
								languageValuePair.Add(key, value);
							}
						}
					}
				}
			}
		}
	}
}
