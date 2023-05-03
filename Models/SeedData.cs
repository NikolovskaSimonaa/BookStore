using BookStore.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<BookStoreContext>>()))
            {
                // Look for any books
                if (context.Book.Any() || context.Author.Any())
                {
                    return; // DB has been seeded
                }
                
                context.SaveChanges();


                context.Author.AddRange(
                new Author
                {
                    //Id = 1,
                    FirstName = "Joanne ",
                    LastName = "Rowling",
                    BirthDate = DateTime.Parse("1965-7-31"),
                    Nationality = "British",
                    Gender = "female",
                    Books = new List<Book>
                    {
                        new Book { 
                
                    //Id = 1,
                    Title = "Harry Potter and the Philosopher's Stone",
                    YearPublished = 1997,
                    NumPages = 223,
                    Description = "It is a story about Harry Potter, an orphan brought up by his aunt and uncle because his parents were killed when he was a baby. Harry is unloved by his uncle and aunt but everything changes when he is invited to join Hogwarts School of Witchcraft and Wizardry and he finds out he's a wizard.",
                    Publisher = "Bloomsbury",
                    FrontPage = "https://www.nzherald.co.nz/resizer/EMOphkyatSReWSs3MOw3gi_p6BI=/1200x0/smart/filters:quality(70)/arc-anglerfish-syd-prod-nzme.s3.amazonaws.com/public/EIQQ5VTKK5BC7DXNWYXZ5YPIEE.jpg",
                    DownloadUrl = "https://canonburyprimaryschool.co.uk/wp-content/uploads/2016/01/Joanne-K.-Rowling-Harry-Potter-Book-1-Harry-Potter-and-the-Philosophers-Stone-EnglishOnlineClub.com_.pdf",
                    AuthorId = 1,
                    Reviews = new List<Review>
                    {
                        new Review { BookId = 1, AppUser = "petko123@gmail.com", Comment = "Super", Rating = 9 },
                        new Review { BookId = 1, AppUser = "stanko456@gmail.com", Comment = "Amazing book", Rating = 10 }
                    },
                    UserBooks = new List<UserBooks>
                    {
                        new UserBooks { BookId = 1, AppUser = "petko123@gmail.com" },
                        new UserBooks { BookId = 1, AppUser = "stanko456@gmail.com" }
                    }
                } ,
                        new Book {
                            //Id = 2,
                            Title = "Harry Potter and the Order of the Phoenix",
                            YearPublished = 2003,
                            NumPages = 766,
                            Description = "It follows Harry Potter's struggles through his fifth year at Hogwarts School of Witchcraft and Wizardry, including the surreptitious return of the antagonist Lord Voldemort, O.W.L. exams, and an obstructive Ministry of Magic.",
                            Publisher = "Bloomsbury",
                            FrontPage = "https://upload.wikimedia.org/wikipedia/en/7/70/Harry_Potter_and_the_Order_of_the_Phoenix.jpg",
                            DownloadUrl = "https://www.oasisacademysouthbank.org/uploaded/South_Bank/Curriculum/Student_Learning/Online_Library/KS3/Harry_potter/05_Harry_Potter_and_the_Order_of_the_Phoenix_by_J.K._Rowling.pdf",
                            AuthorId = 1,
                            Reviews = new List<Review>
                    {
                        new Review { BookId = 2, AppUser = "petko123@gmail.com", Comment = "Didn't like this book very much", Rating = 5 } 
                    },
                            UserBooks = new List<UserBooks>
                    {
                        new UserBooks { BookId = 2, AppUser = "petko123@gmail.com" }
                    }
                        }

                }
                },
                new Author
                {   //Id = 2, 
                    FirstName = "Leo",
                    LastName = "Tolstoy",
                    BirthDate = DateTime.Parse("1828-9-9"),
                    Nationality = "Russian",
                    Gender = "male",
                    Books = new List<Book>
                    {
                        new Book
                {
                    //Id = 3,
                    Title = "Anna Karenina",
                    YearPublished = 1878,
                    NumPages = 864,
                    Description = "The story centers on an extramarital affair between Anna and dashing cavalry officer Count Alexei Kirillovich Vronsky that scandalizes the social circles of Saint Petersburg and forces the young lovers to flee to Italy in a search for happiness, but after they return to Russia, their lives further unravel.",
                    Publisher = "The Russian Messenger",
                    FrontPage = "~/css/book3.jpg",
                    DownloadUrl = "https://almabooks.com/wp-content/uploads/2016/10/annakarenina.pdf",
                    AuthorId = 2,

                    Reviews = new List<Review>
                    {
                        new Review { BookId = 3, AppUser = "stanko456@gmail.com", Comment = "Amazing book", Rating = 10 }
                    },
                    UserBooks = new List<UserBooks>
                    {
                        new UserBooks { BookId = 3, AppUser = "stanko456@gmail.com" }
                    }
                }
                    }
                }
                );
                context.SaveChanges();
                context.Genre.AddRange(
                new Genre { /*Id = 1, */GenreName = "fantasy", },
                new Genre { /*Id = 2, */GenreName = "adventure", },
                new Genre { /*Id = 3, */GenreName = "drama", },
                new Genre { /*Id = 4, */GenreName = "novel", }
                );
                context.SaveChanges();
                context.BookGenre.AddRange(
                new BookGenre { /*Id = 1, */ GenreId = 1 ,BookId=1 },
                new BookGenre { /*Id = 2, */ GenreId = 2, BookId = 1 },
                new BookGenre { /*Id = 3, */ GenreId = 1, BookId = 2 },
                new BookGenre { /*Id = 4, */ GenreId = 2, BookId = 2 },
                new BookGenre { /*Id = 5, */ GenreId = 3, BookId = 3 },
                new BookGenre { /*Id = 6, */ GenreId = 4, BookId = 3 }
                );
                context.SaveChanges();
            }
        }
    }
}
