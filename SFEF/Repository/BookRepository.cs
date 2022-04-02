using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFEF.Models;
using Microsoft.EntityFrameworkCore;

namespace SFEF.Repository
{
    public class BookRepository : Repository<Book>
    {
        public BookRepository(SFEFContext dbContext) : base(dbContext)
        {

        }

        public void UpdateYearOfIssue(int Id, int yearOfIssue)
        {
            Book book = this.GetById(Id);
            if (book == null)
                return;

            book.YearOfIssue = yearOfIssue;
            this.Save();
        }

        public List<Book> GetBooksByGenreForPeriod(Genre genre, int startYear, int finishYear)
        {
            return _dbContext.Books.Where(b => b.Genre.Id == genre.Id
                                        && (b.YearOfIssue >= startYear && b.YearOfIssue <= finishYear)).ToList();
        }

        public int GetCountBooksByAuthor(Author author)
        {
            return _dbContext.Books.Where(b => b.Authors.Contains(author)).Count();
        }

        public int GetCountBooksByGenre(Genre genre)
        {
            return _dbContext.Books.Where(b => b.Genre.Id == genre.Id).Count();
        }

        public bool BookExist(Author author, string bookTitle)
        {
            return _dbContext.Books.Any(b => b.Authors.Contains(author) && b.Title == bookTitle);
        }

        public bool BookHaveUser(Book book)
        {
            return _dbContext.Books.Include(b => b.User).Any(b => b.Id == book.Id && b.User != null);
        }
        public int CountBookHaveUser()
        {
            return _dbContext.Books.Where(b => b.UserId.HasValue).Count();
        }

        public Book GetLastIssueBook()
        {
            return _dbContext.Books.MaxBy(b => b.YearOfIssue);
        }

        public List<Book> GetBooksOrderByTitle()
        {
            return _dbContext.Books.OrderBy(b => b.Title).ToList();
        }

        public List<Book> GetBooksOrderByDescendingByYearOfIssue()
        {
            return _dbContext.Books.OrderByDescending(b => b.YearOfIssue).ToList();
        }
    }
}
