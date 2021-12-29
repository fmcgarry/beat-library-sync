namespace Beansaber.Models;

public class SongModel
{
	public int Id { get; set; }
	public DateTime DateAdded { get; set; }

	public override bool Equals(object? obj) => obj is SongModel model && Id == model.Id;

	public override int GetHashCode() => HashCode.Combine(Id);

	public static bool operator ==(SongModel? left, SongModel? right) => EqualityComparer<SongModel>.Default.Equals(left, right);

	public static bool operator !=(SongModel? left, SongModel? right) => !(left == right);
}
