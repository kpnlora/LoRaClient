using System.Xml.Linq;
using Xunit;

namespace Kpn.LoRa.Reader.UnitTests
{
	/// <summary>
	/// This class provides tests for the LoRaReader class.
	/// It will use the XML from TestSample.xml for the tests.
	/// </summary>
	public class LoRaReaderTest
	{
		/// <summary>
		/// The lora reader
		/// </summary>
		private LoRaReader loraReader;

		/// <summary>
		/// Initializes a new instance of the <see cref="LoRaReaderTest"/> class.
		/// </summary>
		public LoRaReaderTest()
		{
			// Create a XDocument structure from the sample XML
			var xdoc = XDocument.Load(@"TestSample.xml");

			// Initiate a new reader with the sample XML
			loraReader = new LoRaReader(xdoc);
		}

		[Fact]
		public void GetTimeTest()
		{
			// Arrange
			// Make sure this value corresponds with the value in the TestSample.xml
			var expected_result = "2015-06-04T22:25:04.417+02:00";

			// Act
			var result = loraReader.GetTime();

			// Assert
			Assert.Equal(expected_result, result);
		}

		[Fact]
		public void GetPayloadTest()
		{
			// Arrange
			// Make sure this value corresponds with the value in the TestSample.xml
			var expected_result = "Hello world";

			// Act
			var result = loraReader.GetPayload();

			// Assert
			Assert.Equal(expected_result, result);
		}

		[Fact]
		public void GetRawPayloadTest()
		{
			// Arrange
			// Make sure this value corresponds with the value in the TestSample.xml
			var expected_result = "48656c6c6f20776f726c64";

			// Act
			var result = loraReader.GetRawPayload();

			// Assert
			Assert.Equal(expected_result, result);
		}

		/// <summary>
		/// Tests the encoding of the payload.
		/// This test does NOT use the sample XML provided in the constructor.
		/// </summary>
		[Fact]
		public void EncodePayloadTest()
		{
			// Arrange
			var value_to_encode = "Hello world";
			var expected_result = "48656C6C6F20776F726C64";

			// Act
			var result = loraReader.EncodePayload(value_to_encode);

			// Assert
			Assert.Equal(expected_result, result);
		}

		/// <summary>
		/// Tests the decoding of the payload.
		/// This test does NOT use the sample XML provided in the constructor.
		/// </summary>
		[Fact]
		public void DecodePayloadTest()
		{
			// Arrange
			var value_to_decode = "48656C6C6F20776F726C64";
			var expected_result = "Hello world";

			// Act
			var result = loraReader.DecodePayload(value_to_decode);

			// Assert
			Assert.Equal(expected_result, result);
		}
	}
}
