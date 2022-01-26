using Microsoft.AspNetCore.Mvc;

namespace BeatLibrarySync.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class SongsController : ControllerBase
{
	private readonly IDbAccess _db;

	public SongsController(IDbAccess db)
	{
		_db = db;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<ISongModel>>> GetSongs()
	{
		IEnumerable<ISongModel> foundSongs = _db.GetAllSongs();

		if (foundSongs is not List<SongModel> songs)
		{
			return BadRequest();
		}

		return Ok(songs);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<ISongModel>> GetSong(string id)
	{
		ISongModel? foundSong = _db.FindSong(id);

		if (foundSong is not SongModel song)
		{
			return NotFound();
		}

		return Ok(song);
	}

	[HttpPost]
	public async Task<ActionResult<SongModel>> PostSong(SongModel songDTO)
	{
		SongModel song = new()
		{
			BeatSaverId = songDTO.BeatSaverId
		};

		_db.AddSong(song);

		return CreatedAtAction(nameof(GetSong), new { id = song.BeatSaverId }, song);
	}
}
