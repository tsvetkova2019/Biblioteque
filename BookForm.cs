using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteque {
    public partial class BookForm : Form {
        Book book;
        public BookForm(Book book) {
            InitializeComponent();
            this.book = book;
            textBox1.Text = book.Name;
            textBox2.Text = book.Author;
            textBox3.Text = book.Publisher;
            numericUpDown1.Value = book.Year;
            numericUpDown2.Value = book.Pages;
        }

        private void Button1_Click(object sender, EventArgs e) {
            book.Name = textBox1.Text;
            book.Author = textBox2.Text;
            book.Publisher = textBox3.Text;
            book.Year = (int)numericUpDown1.Value;
            book.Pages = (int)numericUpDown2.Value;
            DialogResult = DialogResult.OK;
        }
    }
}
