namespace BLL.DAL
{
    public class MovieGenre
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int GenreId { get; set; }

        // Navigation Properties
        public Movie Movie { get; set; }
        public Genres Genre { get; set; }
    }
}
