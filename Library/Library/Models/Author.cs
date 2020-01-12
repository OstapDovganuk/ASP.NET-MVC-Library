using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    //Модель таблиці Author, яка зберігає дані про авторів
    public class Author
    {
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Birthday { get; set; }

        public virtual List<Book> Books { get; set; }
        public Author()
        {
            Books = new List<Book>();
        }
    }
}