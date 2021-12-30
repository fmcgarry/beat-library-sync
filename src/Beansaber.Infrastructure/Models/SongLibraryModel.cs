using Newtonsoft.Json;

public class SongLibraryModel : ISongLibraryModel
{
	[JsonProperty(PropertyName = "id")]
	public Guid Id { get; set; }
	public string Name { get; set; }
	public IEnumerable<ISongModel> Songs { get; set; }
	public DateTime Created { get; set; }
	public DateTime LastUpdated { get; set; }

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
