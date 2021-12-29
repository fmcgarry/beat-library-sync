using Beansaber.Api.Interfaces;
using Beansaber.Models;

namespace Beansaber.Api.Data;

public class MemoryDbAccess : IDbAccess
{
	private readonly List<SongModel> _songModels = new();

	public void AddSong(SongModel song)
	{
		_songModels.Add(song);
	}

	public SongModel? FindSong(int id)
	{
		return _songModels.FirstOrDefault(x => x.Id == id);
	}
	public List<SongModel> FindSongs(List<int> ids)
	{
		return _songModels.Where(x => ids.Contains(x.Id)).ToList();
	}

	public List<SongModel> GetAllSongs()
	{
		return _songModels;
	}
}
