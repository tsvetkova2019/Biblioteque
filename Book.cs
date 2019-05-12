using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteque {

    [Serializable]
    public class Book {
        [DisplayName("Название книги")]
        public string Name { get; set; }
        [DisplayName("Автор")]
        public string Author { get; set; }
        [DisplayName("Издательство")]
        public string Publisher { get; set; }
        [DisplayName("Год издания")]
        public int Year { get; set; }
        [DisplayName("Кол-во страниц")]
        public int Pages { get; set; }
    }
}
