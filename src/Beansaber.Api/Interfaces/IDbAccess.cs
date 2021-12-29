using Beansaber.Models;

namespace Beansaber.Api.Interfaces;

public interface IDbAccess
{
	public SongModel? FindSong(int id);

	public List<SongModel> FindSongs(List<int> ids);

	public List<SongModel> GetAllSongs();

	public void AddSong(SongModel song);
}
