public interface ISongModel
{
	string AddedBy { get; set; }
	string BeatSaverId { get; set; }
	DateTime DateAdded { get; }
	string Name { get; set; }
}