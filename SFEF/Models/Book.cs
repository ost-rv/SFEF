
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFEF.Models
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }    
        public int YearOfIssue { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
