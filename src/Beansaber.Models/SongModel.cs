using Newtonsoft.Json;

namespace Beansaber.Models;

public class SongModel
{
	[JsonProperty(PropertyName = "id")]
	public string Id { get; set; } = string.Empty;

	public DateTime DateAdded { get; } = DateTime.UtcNow;

	public override bool Equals(object? obj) => obj is SongModel model && Id == model.Id;

	public override int GetHashCode() => HashCode.Combine(Id);

	public static bool operator ==(SongModel? left, SongModel? right) => EqualityComparer<SongModel>.Default.Equals(left, right);

	public static bool operator !=(SongModel? left, SongModel? right) => !(left == right);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
