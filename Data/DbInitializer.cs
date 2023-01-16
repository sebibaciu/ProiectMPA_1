using Microsoft.EntityFrameworkCore;
using static NuGet.Packaging.PackagingConstants;
using static System.Reflection.Metadata.BlobBuilder;
using ProiectMPA_1.Models;

namespace ProiectMPA_1.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                context.Database.EnsureCreated();

                // Look for any books
                if (context.Books.Any())
                {
                    return; // BD a fost creata anterior (DB has been seeded)
                }

                context.Authors.AddRange(
                new Author
                {
                    FirstName = "Mihail",
                    LastName = "Sadoveanu"
                },
                new Author
                {
                    FirstName = "George",
                    LastName = "Calinescu"
                },
                new Author
                {
                    FirstName = "Mircea",
                    LastName = "Eliade"
                }
                );
                context.SaveChanges();

                //context.Books.AddRange();
                var books = new Book[]
                {
                new Book
                {
                    Title = "Baltagul",
                    Price = decimal.Parse("22"),
                    AuthorID = context.Authors.Single(author => author.LastName == "Sadoveanu").ID
                },
                new Book
                {
                    Title = "Enigma Otiliei",
                    Price = decimal.Parse("18"),
                    AuthorID = context.Authors.Single(author => author.LastName == "Calinescu").ID
                },
                new Book
                {
                    Title = "Maytrei",
                    Price = decimal.Parse("27"),
                    AuthorID = context.Authors.Single(author => author.LastName == "Eliade").ID
                }
                };
                foreach (Book b in books)
                {
                    context.Books.Add(b);
                }
                context.SaveChanges();

                //context.Customers.AddRange(
                var customers = new Customer[]
                {
                new Customer
                {
                    Name = "Popescu Marcela",
                    Adress = "Str. Plopilor, nr. 24",
                    BirthDate = DateTime.Parse("1979 - 09 - 01")
                },
                new Customer
                {
                    Name = "Mihailescu Cornel",
                    Adress = "Str. Bucuresti, nr. 45, ap. 2",
                    BirthDate = DateTime.Parse("1969 - 07 - 08")
                }
                };
                foreach (Customer t in customers)
                {
                    context.Customers.Add(t);
                }
                context.SaveChanges();

                var orders = new Order[]
                {
                    new Order
                    {
                        BookID = books.Single(g => g.Title == "Maytrei" ).ID,
                        CustomerID = customers.Single(x => x.Name == "Mihailescu Cornel" ).CustomerID,
                        OrderDate = DateTime.Parse("2021-02-25")
                    },
                    new Order
                    {
                        BookID = books.Single(g => g.Title == "Enigma Otiliei" ).ID,
                        CustomerID = customers.Single(x => x.Name == "Mihailescu Cornel" ).CustomerID,
                        OrderDate = DateTime.Parse("2021-09-28")
                    },
                    new Order
                    {
                        BookID = books.Single(g => g.Title == "Baltagul" ).ID,
                        CustomerID = customers.Single(x => x.Name == "Mihailescu Cornel" ).CustomerID,
                        OrderDate = DateTime.Parse("2021-10-28")
                    },
                    new Order
                    {
                        BookID = books.Single(g => g.Title == "Maytrei" ).ID,
                        CustomerID = customers.Single(x => x.Name == "Popescu Marcela" ).CustomerID,
                        OrderDate = DateTime.Parse("2021-09-28")
                    },
                    new Order
                    {
                        BookID = books.Single(g => g.Title == "Enigma Otiliei" ).ID,
                        CustomerID = customers.Single(x => x.Name == "Popescu Marcela" ).CustomerID,
                        OrderDate = DateTime.Parse("2021-09-28")
                    },
                    new Order {
                        BookID = books.Single(g => g.Title == "Baltagul" ).ID,
                        CustomerID = customers.Single(x => x.Name == "Popescu Marcela" ).CustomerID,
                        OrderDate = DateTime.Parse("2021-10-28")
                    }
                };
                foreach (Order e in orders)
                {
                    context.Orders.Add(e);
                }
                context.SaveChanges();

                var publishers = new Publisher[]
                {
                    new Publisher{PublisherName="Humanitas",Adress="Str. Aviatorilor, nr. 40, Bucuresti"},
                    new Publisher{PublisherName="Nemira",Adress="Str. Plopilor, nr. 35, Ploiesti"},
                    new Publisher{PublisherName="Paralela 45",Adress="Str. Cascadelor, nr. 22, Cluj-Napoca"}
                };
                foreach (Publisher p in publishers)
                {
                    context.Publishers.Add(p);
                }
                context.SaveChanges();

                var publishedbooks = new PublishedBook[]
                {
                    new PublishedBook
                    {
                        PublisherID = publishers.Single(i => i.PublisherName == "Humanitas").ID,
                        BookID = books.Single(g => g.Title == "Maytrei" ).ID
                    },
                    new PublishedBook
                    {
                        PublisherID = publishers.Single(i => i.PublisherName == "Humanitas").ID,
                        BookID = books.Single(g => g.Title == "Enigma Otiliei" ).ID
                    },
                    new PublishedBook
                    {
                        PublisherID = publishers.Single(i => i.PublisherName == "Nemira").ID,
                        BookID = books.Single(g => g.Title == "Baltagul" ).ID
                    },
                    new PublishedBook
                    {
                        PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID,
                        BookID = books.Single(g => g.Title == "Maytrei" ).ID
                    },
                    new PublishedBook
                    {
                        PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID,
                        BookID = books.Single(g => g.Title == "Enigma Otiliei" ).ID
                    },
                    new PublishedBook
                    {
                        PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID,
                        BookID = books.Single(g => g.Title == "Baltagul" ).ID
                    },
                };
                foreach (PublishedBook pb in publishedbooks)
                {
                    context.PublishedBooks.Add(pb);
                }
                context.SaveChanges();
            }
        }
    }
}
