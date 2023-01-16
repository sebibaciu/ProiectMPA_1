using MessagePack;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMPA_1.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? AlbumImage { get; set; }

        [Column(TypeName = "decimal(6)")]
        public decimal Price { get; set; }
        // Foreign key
        [Display(Name = "Author")]
        public int AuthorID { get; set; }
        // Navigation property. Author property holds a single Author entity (one-to-zero-or-one relationship)
        public Author? Author { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<PublishedBook>? PublishedBooks { get; set; }
    }
}
