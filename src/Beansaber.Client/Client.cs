using Beansaber.Client;
using Beansaber.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Net.Http.Json;

namespace Beansaber.Api.Client;

public class Client
{
	private readonly static HttpClient _httpClient = new();
	private readonly ClientOptions _options;
	private readonly ILogger<Client> _logger;

	public Client(IOptions<ClientOptions> options, ILogger<Client> logger)
	{
		_options = options.Value;
		_logger = logger;

		//_httpClient.BaseAddress = new Uri(_options.BaseAddress);
	}

	public async Task<IEnumerable<SongModel>> SyncSongsAsync(IEnumerable<SongModel> localSongs)
	{
		try
		{
			List<SongModel> remoteSongs = (await GetSongsFromServer()).ToList();

			List<SongModel> newRemoteSongs = new();

			foreach (SongModel song in localSongs)
			{
				if (remoteSongs.Contains(song) == false)
				{
					newRemoteSongs.Add(song);
				}
			}

			if (newRemoteSongs.Count != 0)
			{
				bool isSuccess = await AddNewSongs(newRemoteSongs);

				if (isSuccess == false)
				{
					Debug.Assert(isSuccess);
					return new List<SongModel>();
				}
			}

			List<SongModel> newLocalSongs = new();

			if (remoteSongs.Count > 0)
			{
				foreach (SongModel songModel in remoteSongs)
				{
					if (localSongs.Contains(songModel) == false)
					{
						newLocalSongs.Add(songModel);
					}
				}
			}

			return newLocalSongs;
		}
		catch (Exception e)
		{
			Debug.Assert(false);
			_logger.LogError("Failed to sync songs with server: {e}", e);
			return new List<SongModel>();
		}
	}

	private async Task<bool> AddNewSongs(List<SongModel> songs)
	{
		try
		{
			HttpResponseMessage response = await _httpClient.PostAsJsonAsync(_options.AddSongsUri, songs);

			if (response.IsSuccessStatusCode == false)
			{
				Debug.Assert(response.IsSuccessStatusCode);
				_logger.LogError("Failed to add new songs to server: Code {code}.", response.StatusCode);
				return false;
			}

			return true;
		}
		catch (Exception e)
		{
			Debug.Assert(false);
			_logger.LogError("An exception occurred while adding new songs: {e}", e);
			return false;
		}
	}

	private async Task<IEnumerable<SongModel>> GetSongsFromServer()
	{
		try
		{
			List<SongModel>? remoteSongs = await _httpClient.GetFromJsonAsync<List<SongModel>>(_options.GetSongsUri);

			if (remoteSongs is null)
			{
				Debug.Assert(remoteSongs is not null);
				_logger.LogError("Failed to get remote songs from server.");
				return new List<SongModel>();
			}

			return remoteSongs;
		}
		catch (Exception e)
		{
			Debug.Assert(false, e.ToString());
			_logger.LogError("An unhandled exception occurred while getting songs from server: {e}", e);
			return new List<SongModel>();
		}
	}
}
