using Beansaber.Models;

namespace Beansaber.Api.Interfaces;

public interface IDbAccess
{
	public SongModel? FindSong(string id);

	public IEnumerable<SongModel> FindSongs(IEnumerable<string> ids);

	public IEnumerable<SongModel> GetAllSongs();

	public void AddSong(SongModel song);
}
