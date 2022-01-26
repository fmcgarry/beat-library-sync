using Newtonsoft.Json;

namespace BeatLibrarySync.Models;

public class SongModel
{
	public string Name { get; set; } = string.Empty;
	public string BeatSaverId { get; set; } = string.Empty;
	public string AddedBy { get; set; } = string.Empty;
	public DateTime DateAdded { get; } = DateTime.MinValue;

	public override bool Equals(object? obj) => obj is SongModel model && BeatSaverId == model.BeatSaverId;

	public override int GetHashCode() => HashCode.Combine(BeatSaverId);

	public static bool operator ==(SongModel? left, SongModel? right) => EqualityComparer<SongModel>.Default.Equals(left, right);

	public static bool operator !=(SongModel? left, SongModel? right) => !(left == right);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
