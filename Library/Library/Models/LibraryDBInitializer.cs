using System.Data.Entity;
using System.Collections.Generic;

namespace Library.Models
{
    //Клас для ініціалізації деяких даних до БД
    public class LibraryDBInitializer : DropCreateDatabaseIfModelChanges<LibraryContex>
    {
        protected override void Seed(LibraryContex db)
        {
            Author author1 = new Author() { FirstName = "Стівен", LastName = "Кінг", Birthday = 1947 };
            Author author2 = new Author() { FirstName = "Деніел", LastName = "Кіз", Birthday = 1927 };
            Author author3 = new Author() { FirstName = "Люко", LastName = "Дашвар", Birthday = 1957 };
            Author author4 = new Author() { FirstName = "Стівен", LastName = "Поланік", Birthday = 1962 };

            db.Authors.Add(author1);
            db.Authors.Add(author2);
            db.Authors.Add(author3);
            db.Authors.Add(author4);

            db.Books.Add(new Book { Name = "Кладовище домашніх тварин", Edition = "Hemiro Ltd", Pages = 374, Authors = new List<Author>() { author1 } });
            db.Books.Add(new Book { Name = "Що впало, те пропало", Edition = "Hemiro Ltd", Pages = 434, Authors = new List<Author>() { author1 } });
            db.Books.Add(new Book { Name = "Квіти для Елджернона", Edition = "Hemiro Ltd", Pages = 304, Authors = new List<Author>() { author2 } });
            db.Books.Add(new Book { Name = "Село не люди", Edition = "Клуб сімейного дозвілля", Pages = 270, Authors = new List<Author>() { author2, author3 } });
            db.Books.Add(new Book { Name = "Створи щось", Edition = "Hemiro Ltd", Pages = 336, Authors = new List<Author>() { author4, author3 } });

            db.Users.Add(new User { Email = "ostap@test.ua", Password = "123456" });
            db.Users.Add(new User { Email = "ostap@test2.ua", Password = "aaa" });
            base.Seed(db);
        }
    }
}