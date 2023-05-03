using System.ComponentModel.DataAnnotations;
namespace BookStore.Models
{
    public class Book
    {
        [Required] public int Id { get; set; }

        [Display(Name = "Title")]
        [Required][StringLength(100)] public string Title { get; set; }
        [Display(Name = "Year Published")] public int? YearPublished { get; set; }
        [Display(Name = "Number of pages")] public int? NumPages { get; set; }
        [Display(Name = "Description")] public string? Description { get; set; }
        [Display(Name = "Publisher")][StringLength(50)] public string? Publisher { get; set; }
        [Display(Name = "Front page")] public string? FrontPage { get; set; }
        [Display(Name = "Download")] public string? DownloadUrl { get; set; }
        [Required] public int AuthorId { get; set; }
        public Author Author { get; set; } //edna kniga ima eden avtor
        public ICollection<BookGenre> BookGenres { get; set; } //edna kniga moze da pripagja na povekje zanrovi
        public ICollection<Review> Reviews { get; set; } //edna kniga ima poveke reviews
        public ICollection<UserBooks> UserBooks { get; set; }//poveke korisnici moze da kupat edna kniga

        public double GetAverage() //average rating
        {
            if (Reviews.Count == 0 || Reviews == null) return 0;
            int total = 0;
            foreach (var review in Reviews)
            {
                total = (int)(total + review.Rating);
            }
            double average = total / Reviews.Count;
            return average;
        }
    }
}
