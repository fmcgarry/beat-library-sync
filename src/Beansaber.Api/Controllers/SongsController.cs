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

	[HttpGet("{id}")]
	public ActionResult<SongModel> Get(int id)
	{
		SongModel? song = _db.FindSong(id);

		if (song is null)
		{
			return NotFound();
		}

		return Ok(song);
	}

	[HttpGet("all")]
	public ActionResult<List<SongModel>> GetAll()
	{
		List<SongModel>? songs = _db.GetAllSongs();

		if (songs is null)
		{
			return BadRequest("Could not find any songs");
		}

		return Ok(songs);
	}

	[HttpGet("get-multiple")]
	public ActionResult<SongModel> GetSongs(List<int> ids)
	{
		List<SongModel> song = _db.FindSongs(ids);

		if (song is null)
		{
			return NotFound();
		}

		return Ok(song);
	}

	[HttpPost("add")]
	public ActionResult<SongModel> Add(List<SongModel> songs)
	{
		List<int> ids = new();

		foreach (SongModel song in songs)
		{
			_db.AddSong(song);
			ids.Add(song.Id);
		}

		return GetSongs(ids);
	}
}
