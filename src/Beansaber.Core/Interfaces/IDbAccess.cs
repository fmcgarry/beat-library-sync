public interface IDbAccess
{
	public ISongModel? FindSong(string id);

	public IEnumerable<ISongModel> FindSongs(IEnumerable<string> ids);

	public IEnumerable<ISongModel> GetAllSongs();

	public void AddSong(ISongModel song);
}
