﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFEF.Models
{
    public class Genre : IEntity
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        public List<Book> Books { get; set; }  = new List<Book>();
    }
}
