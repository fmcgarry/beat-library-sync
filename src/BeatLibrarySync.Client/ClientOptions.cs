using System.ComponentModel.DataAnnotations;

public class ClientOptions
{
	[Required]
	public string BaseAddress { get; set; } = string.Empty;

	[Required]
	public string SongsUri { get; set; } = string.Empty;
}
