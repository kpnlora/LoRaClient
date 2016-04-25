namespace Kpn.LoRa.Reader
{
	/// <summary>
	/// This interface defines the available methods for 
	/// reading data from XML provided by the LoRa network.
	/// </summary>
	public interface ILoRaReader
	{
		/// <summary>
		/// Gets the time.
		/// </summary>
		/// <returns>The complete UTC timestamp, as a string.</returns>
		string GetTime();

		/// <summary>
		/// Gets the decoded payload.
		/// </summary>
		/// <returns>The decoded payload information.</returns>
		string GetPayload();

		/// <summary>
		/// Gets the raw payload, without decoding.
		/// </summary>
		/// <returns>The encoded payload information.</returns>
		string GetRawPayload();

		/// <summary>
		/// Encodes the payload.
		/// </summary>
		/// <param name="payload">The payload.</param>
		/// <returns>The encoded payload as a hex string.</returns>
		string EncodePayload(string payload);

		/// <summary>
		/// Decodes the payload.
		/// </summary>
		/// <param name="payload">The payload.</param>
		/// <returns>The decoded payload as a string.</returns>
		string DecodePayload(string payload);
	}
}