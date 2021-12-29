using Beansaber.Api.Interfaces;
using Beansaber.Api.Models;
using Beansaber.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beansaber.Api.Controllers;

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
	public async Task<ActionResult<IEnumerable<Models.SongModel>>> GetSongs()
	{
		List<Beansaber.Models.SongModel>? songs = _db.GetAllSongs().ToList();

		if (songs is null)
		{
			return BadRequest();
		}

		return Ok(songs);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Models.SongModel>> GetSong(int id)
	{
		Beansaber.Models.SongModel? song = _db.FindSong(id);

		if (song is null)
		{
			return NotFound();
		}

		return Ok(song);
	}

	[HttpPost("add")]
	public async Task<ActionResult<Models.SongModel>> AddSong(Models.SongModel songDTO)
	{
		Beansaber.Models.SongModel song = new()
		{
			Id = songDTO.Id,
			DateAdded = DateTime.Now,
		};

		_db.AddSong(song);

		return CreatedAtAction(nameof(GetSong), new { id = song.Id }, song);
	}
}
