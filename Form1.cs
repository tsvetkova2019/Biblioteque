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
    public partial class Form1 : Form {
        BindingList<Book> Books = new BindingList<Book>();

        public Form1() {
            InitializeComponent();
            dataGridView1.DataSource = Books;
        }
        }
    }
}
