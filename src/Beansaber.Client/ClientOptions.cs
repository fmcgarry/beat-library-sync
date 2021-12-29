using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beansaber.Client;

public class ClientOptions
{
	[Required]
	public string BaseAddress { get; set; } = string.Empty;

	[Required]
	public string AddSongsUri { get; set; } = string.Empty;

	[Required]
	public string GetSongsUri { get; set; } = string.Empty;
}
