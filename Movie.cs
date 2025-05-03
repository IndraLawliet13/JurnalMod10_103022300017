namespace JurnalMod10_103022300017
{
    public class Movie
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public List<string> Stars { get; set; }
        public string Description { get; set; }
        public Movie(string title, string Director, List<string> Stars, string Description) {
            this.Title = title;
            this.Director = Director;
            this.Stars = Stars;
            this.Description = Description;
        }
    }
}
