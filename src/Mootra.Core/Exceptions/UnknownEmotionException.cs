namespace Mootra.Core.Exceptions;

/// <summary>
/// Thrown when an expected emotion is null.
/// </summary>
public class UnknownEmotionException : Exception
{
	/// <summary>
	/// Initializes a new instance of the <see cref="UnknownEmotionException"/> class.
	/// </summary>
	/// <param name="msg">The reason for the exception.</param>
	public UnknownEmotionException(string msg)
		: base(msg)
	{
	}
}
