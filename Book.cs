using System;
using System.Collections.Generic;
using System.Text;

namespace TCSA.OOP.LibraryManagementSystem
{
    internal class Book
    {
        public string Name { get; set; }
        public int Pages { get; set; }

        public Book()
        {
            Name = string.Empty;
            Pages = 0;
        }

        public Book(string name, int pages)
        {
            Name = name;
            Pages = pages;
        }
    }
}
