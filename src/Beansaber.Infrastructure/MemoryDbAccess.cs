public class MemoryDbAccess : IDbAccess
{
	private readonly List<ISongModel> _songModels = new();

	public void AddSong(ISongModel song)
	{
		_songModels.Add(song);
	}

	public ISongModel? FindSong(string id)
	{
		return _songModels.FirstOrDefault(x => x.BeatSaverId == id);
	}
	public IEnumerable<ISongModel> FindSongs(IEnumerable<string> ids)
	{
		return _songModels.Where(x => ids.Contains(x.BeatSaverId));
	}

	public IEnumerable<ISongModel> GetAllSongs()
	{
		return _songModels;
	}
}
