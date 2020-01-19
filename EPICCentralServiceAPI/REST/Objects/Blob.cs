using System.IO;
using EPICCentralServiceAPI.REST.Core;

namespace EPICCentralServiceAPI.REST.Objects
{
	/// <summary>
	/// Interface that defines methods for accessing a BLOB (binary large object).
	/// </summary>
	public interface IBlob
	{
		/// <summary>
		/// Get an open <code>Stream</code> for reading a binary object.
		/// The stream is guaranteed to be seekable.
		/// </summary>
		/// <returns>a <code>Stream</code> open for reading the BLOB</returns>
		Stream GetReadStream();
	}

	/// <summary>
	/// A BLOB represented as an array of bytes.
	/// </summary>
	public class ByteBlob : IBlob
	{
		/// <summary>
		/// The array of bytes that compose the BLOB.
		/// </summary>
		private readonly byte[] blob;

		/// <summary>
		/// Construct an instance initialized with the specified array of bytes.
		/// </summary>
		/// <param name="blob">an array of bytes that define a BLOB</param>
		public ByteBlob(byte[] blob)
		{
			this.blob = blob;
		}

		/// <inheritdoc />
		public Stream GetReadStream()
		{
			return new MemoryStream(blob);
		}
	}

	/// <summary>
	/// A BLOB exposed by an open <code>Stream</code>.
	/// </summary>
	public class StreamBlob : IBlob
	{
		/// <summary>
		/// The <code>Stream</code> from which the BLOB can be read.
		/// </summary>
		private Stream stream;

		/// <summary>
		/// Construct an instance initialized with the specified <code>Stream</code>.
		/// The stream must be readable.
		/// </summary>
		/// <param name="stream">a <code>Stream</code> from which a BLOB can be read</param>
		/// <exception cref="InvalidArgumentException">if the stream cannot be read</exception>
		public StreamBlob(Stream stream)
		{
			this.stream = stream;
			if (!stream.CanRead)
				throw new InvalidArgumentException("Stream cannot be read");
		}

		/// <inheritdoc />
		public Stream GetReadStream()
		{
			// If the stream isn't seekable, copy it to a memory stream. The interface needs
			// to guarantee it is seekable so it can be read at least twice.
			if (!stream.CanSeek)
			{
				Stream memStream = new MemoryStream();
				stream.CopyTo(memStream);
				memStream.Seek(0, SeekOrigin.Begin);
				stream = memStream;
			}

			return stream;
		}
	}

	/// <summary>
	/// A BLOB containing a set of images.
	/// Different from a simple BLOB because it has a GUID that uniquely identifies it.
	/// </summary>
	public class ImageSetBlob : IBlob
	{
		/// <summary>
		/// The BLOB containing the image set.
		/// </summary>
		private readonly IBlob blob;

		/// <summary>
		/// Construct an instance initialized with the specified GUID and array of bytes.
		/// </summary>
		/// <param name="guid">the unique ID of the image set</param>
		/// <param name="blob">array of bytes containing the image set</param>
		public ImageSetBlob(string guid, byte[] blob)
		{
			this.blob = new ByteBlob(blob);
			Guid = guid;
		}

		/// <summary>
		/// Construct an instance initialized with the specified GUID and initialized to
		/// read the image set from the specified <code>Stream</code>.
		/// </summary>
		/// <param name="guid">the unique ID of the image set</param>
		/// <param name="stream">a <code>Stream</code> from which the image set can be read</param>
		/// <exception cref="InvalidArgumentException">if the stream cannot be read</exception>
		public ImageSetBlob(string guid, Stream stream)
		{
			blob = new StreamBlob(stream);
			Guid = guid;
		}

		/// <inheritdoc />
		public Stream GetReadStream()
		{
			return blob.GetReadStream();
		}

		/// <summary>
		/// The unique ID of the image set assigned by the client.
		/// The GUID must be unique across the entire global system.
		/// </summary>
		public string Guid { get; private set; }
	}
}
