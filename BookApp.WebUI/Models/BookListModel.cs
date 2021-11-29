﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Entities.Concrete;
using X.PagedList;


namespace BookApp.WebUI.Models
{
    public class BookListModel
    {
    
        public List<Book> Books { get; set; }
    }
}
