using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Kpn.LoRa.Reader
{
	/// <summary>
	/// This class is used to help read the XML data 
	/// received from the LoRa network.
	/// </summary>
	/// <seealso cref="Kpn.LoRa.Reader.ILoRaReader" />
	public class LoRaReader : ILoRaReader
	{
		/// <summary>
		/// This XDocument holds the XML data from the LoRa network.
		/// All information provided by the methods in this class 
		/// will be retrieved from this property.
		/// </summary>
		private XDocument xdoc;

		/// <summary>
		/// Initializes a new instance of the <see cref="LoRaReader"/> class.
		/// </summary>
		/// <param name="xml">The string with the XML data.</param>
		public LoRaReader(string xml)
		{
			xdoc = XDocument.Load(xml);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LoRaReader"/> class.
		/// </summary>
		/// <param name="xml">The XDocument with the XML data.</param>
		public LoRaReader(XDocument xml)
		{
			xdoc = xml;
		}

		/// <summary>
		/// Gets the time provided in the XML.
		/// </summary>
		/// <returns>The complete UTC timestamp, as a string.</returns>
		public string GetTime()
		{
			return xdoc.Root.Elements().First(e => e.Name.LocalName.Equals("Time")).Value;
		}

		/// <summary>
		/// Gets the decoded payload from the XML.
		/// This method internally calls both <see cref="GetRawPayload"/> and <see cref="DecodePayload(string)"/>.
		/// </summary>
		/// <returns>The decoded payload information.</returns>
		public string GetPayload()
		{
			return DecodePayload(GetRawPayload());
		}

		/// <summary>
		/// Gets the raw payload from the XML, without decoding.
		/// </summary>
		/// <returns>The encoded payload information.</returns>
		public string GetRawPayload()
		{
			return xdoc.Root.Elements().First(e => e.Name.LocalName.Equals("payload_hex")).Value;
		}

		/// <summary>
		/// Encodes the payload.
		/// </summary>
		/// <param name="payload">The payload.</param>
		/// <returns>The encoded payload as a hex string.</returns>
		public string EncodePayload(string payload)
		{
			var encodedPayload = String.Empty;
			var values = payload.ToCharArray();

			foreach (char letter in values)
			{
				int value = Convert.ToInt32(letter);
				encodedPayload += String.Format("{0:X}", value);
			}

			return encodedPayload;
		}

		/// <summary>
		/// Decodes the payload.
		/// </summary>
		/// <param name="payload">The payload.</param>
		/// <returns>The decoded payload as a string.</returns>
		public string DecodePayload(string payload)
		{
			var NumberChars = payload.Length / 2;
			var bytes = new byte[NumberChars];

			using (var sr = new StringReader(payload))
			{
				for (int i = 0; i < NumberChars; i++)
				{
					bytes[i] = Convert.ToByte(new string(new char[2] { (char)sr.Read(), (char)sr.Read() }), 16);
				}
			}

			return Encoding.UTF8.GetString(bytes);
		}
	}
}