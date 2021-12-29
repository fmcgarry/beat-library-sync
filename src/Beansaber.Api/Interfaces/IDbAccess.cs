using Beansaber.Models;

namespace Beansaber.Api.Interfaces;

public interface IDbAccess
{
	public SongModel? FindSong(int id);

	public IEnumerable<SongModel> FindSongs(IEnumerable<int> ids);

	public IEnumerable<SongModel> GetAllSongs();

	public void AddSong(SongModel song);
}
