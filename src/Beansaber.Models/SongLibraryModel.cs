using Newtonsoft.Json;

namespace Beansaber.Models;

public class SongLibraryModel
{
	[JsonProperty(PropertyName = "id")]
	public Guid Id { get; set; }
	public string Name { get; set; }
	public IEnumerable<SongModel> Songs { get; set; }
	public DateTime Created { get; set; }
	public DateTime LastUpdated { get; set; }

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
