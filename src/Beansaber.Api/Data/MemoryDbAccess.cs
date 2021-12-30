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

	public SongModel? FindSong(string id)
	{
		return _songModels.FirstOrDefault(x => x.BeatSaverId == id);
	}
	public IEnumerable<SongModel> FindSongs(IEnumerable<string> ids)
	{
		return _songModels.Where(x => ids.Contains(x.BeatSaverId));
	}

	public IEnumerable<SongModel> GetAllSongs()
	{
		return _songModels;
	}
}
