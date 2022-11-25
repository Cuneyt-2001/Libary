using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class BookDTO
    {
        public BookDTO()
        {
        }

        public BookDTO(int bookID, int iSBN, string bookTitle, string publisher, string author, bool visibility)
        {
            BookID = bookID;
            ISBN = iSBN;
            BookTitle = bookTitle;
            Publisher = publisher;
            Author = author;
            Visibility = visibility;
        }

        public int BookID { get; set; }
        public int ISBN { get; set; }
        public string BookTitle { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public bool Visibility { get; set; } = true;

    }
}
