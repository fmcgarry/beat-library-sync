using Beansaber.Api.Interfaces;
using Beansaber.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using System.Net;

namespace Beansaber.Api.Data;

public class CosmosDbAccess : IDbAccess
{
	private readonly CosmosDbAccessOptions _options;
	private readonly Container _container;
	private readonly CosmosClient _cosmosClient;

	public CosmosDbAccess(IOptions<CosmosDbAccessOptions> options)
	{
		_options = options.Value;

		_cosmosClient = new CosmosClient(_options.EndpointUri, _options.PrimaryKey);
		_container = _cosmosClient.GetContainer(_options.DatabaseId, _options.ContainerId);
	}

	public async void AddSong(SongModel song)
	{
		try
		{
			// Read the item to see if it exists.  
			ItemResponse<SongModel> andersenFamilyResponse = await _container.ReadItemAsync<SongModel>(song.Id, new PartitionKey(song.Id));
			Console.WriteLine("Item in database with id: {0} already exists\n", andersenFamilyResponse.Resource.Id);
		}
		catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
		{
			// Create an item in the container representing the Andersen family. Note we provide the value of the partition key for this item, which is "Andersen"
			ItemResponse<SongModel> andersenFamilyResponse = await _container.CreateItemAsync(song, new PartitionKey(song.Id));

			// Note that after creating the item, we can access the body of the item with the Resource property off the ItemResponse. We can also access the RequestCharge property to see the amount of RUs consumed on this request.
			Console.WriteLine("Created item in database with id: {0} Operation consumed {1} RUs.\n", andersenFamilyResponse.Resource.Id, andersenFamilyResponse.RequestCharge);
		}
	}

	public SongModel? FindSong(string id)
	{
		throw new NotImplementedException();
	}

	public IEnumerable<SongModel> FindSongs(IEnumerable<string> ids)
	{
		throw new NotImplementedException();
	}

	public IEnumerable<SongModel> GetAllSongs()
	{
		throw new NotImplementedException();
	}
}
