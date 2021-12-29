// See https://aka.ms/new-console-template for more information

using Beansaber.Api.Client;
using Beansaber.Client;
using Beansaber.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;


Thread.Sleep(3000);

using var loggerFactory = LoggerFactory.Create(builder =>
{
	builder
		.AddFilter("Microsoft", LogLevel.Warning)
		.AddFilter("System", LogLevel.Warning)
		.AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)
		.AddSerilog(new LoggerConfiguration()
			.WriteTo.Console()
			.CreateLogger()
		);
});

var logger = loggerFactory.CreateLogger<Program>();

var options = Options.Create(new ClientOptions()
{
	BaseAddress = "",
	AddSongsUri = "https://localhost:7209/songs/add",
	GetSongsUri = "https://localhost:7209/songs/all"
});

var client = new Client(options, loggerFactory.CreateLogger<Client>());

var songs = new List<SongModel>
{
	new SongModel { Id = 1 },
	new SongModel { Id = 2 },
	new SongModel { Id = 3 },
};

var newSongs = client.SyncSongsAsync(songs);

if (!newSongs.Wait(5000))
{
	logger.LogError("failed");
}

var asdf = newSongs.Result.ToList();

// round 2 boogaloo
var songs2 = new List<SongModel>
{
	new SongModel { Id = 1 },
	new SongModel { Id = 2 },
};

var newSongs2 = client.SyncSongsAsync(songs2);

if (!newSongs2.Wait(5000))
{
	logger.LogError("failed");
}

var asdf2 = newSongs2.Result.ToList();

var fdsa = 1;