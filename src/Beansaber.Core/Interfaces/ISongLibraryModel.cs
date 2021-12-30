public interface ISongLibraryModel
{
	DateTime Created { get; set; }
	Guid Id { get; set; }
	DateTime LastUpdated { get; set; }
	string Name { get; set; }
	IEnumerable<ISongModel> Songs { get; set; }
}