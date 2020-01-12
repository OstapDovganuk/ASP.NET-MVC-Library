using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    //Модель таблиці Books, яка зберігає дані про книги
    public class Book
    {
        [Required]
        public int BookId { get; set; }
        [Required]
        public string Name { get; set; }  
        [Required]
        public string Edition { get; set; }
        [Required]
        public int Pages { get; set; }
      
        public virtual List<Author> Authors { get; set; }
        public Book()
        {
            Authors = new List<Author>();
        }
    }
}