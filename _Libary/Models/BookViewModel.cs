using Business;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _Libary.Models
{
    public class BookViewModel/*:LoanViewModel*/
    {
        [Key]
        public int BookID { get; set; }
        [Required]
        // [StringLength(255, MinimumLength = 8, ErrorMessage = "The paasword must be at least 8 character")]
        //[MinLength(8,ErrorMessage = "The ISBN must be at least 8 character")]

       //isbn string

        public int ISBN { get; set; } 

        [Required]
        public string BookTitle { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Author { get; set; }
       

        public List<Category> Categories { get; set; }

        public BookViewModel(Book book)
        {
            this.BookID = book.BookID;
            this.ISBN = book.ISBN;
            this.BookTitle = book.BookTitle;
            this.Publisher = book.Publisher;
            this.Author = book.Author;
        }

        public BookViewModel(Book book, List<Category> categories)
        {
            this.BookID = book.BookID;
            this.ISBN = book.ISBN;
            this.BookTitle = book.BookTitle;
            this.Publisher = book.Publisher;
            this.Author = book.Author;
            this.Categories = categories;
        }


        public BookViewModel()
        {
        }
    }
}

