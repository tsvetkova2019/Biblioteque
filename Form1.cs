using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Biblioteque {
    public partial class Form1 : Form {

        BindingList<Book> Books = new BindingList<Book>();

        public Form1() {
            InitializeComponent();
            LoadBooks();
            dataGridView1.DataSource = Books;
        }

        /// <summary>
        /// Добавить книгу
        /// </summary>
        private void Button1_Click(object sender, EventArgs e) {
            Book book = new Book() {
                Year = DateTime.Today.Year,
                Pages = 100
            };
            using (BookForm dlg = new BookForm(book)) {
                if (dlg.ShowDialog() == DialogResult.OK) {
                    Books.Add(book);
                    SaveBooks();
                }
            }
        }


        /// <summary>
        /// Редактировать книгу
        /// </summary>
        private void Button2_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count > 0) {
                Book book = (Book)dataGridView1.SelectedRows[0].DataBoundItem;
                using (BookForm dlg = new BookForm(book)) {
                    if (dlg.ShowDialog() == DialogResult.OK) {
                        SaveBooks();
                        Books.ResetBindings();
                    }
                }
            }
        }


        /// <summary>
        /// Удалить книгу
        /// </summary>
        private void Button3_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count > 0) {
                Book book = (Book)dataGridView1.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show("Удалить книгу?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                    Books.Remove(book);
                    SaveBooks();
                }
            }
        }

        /// <summary>
        /// Сохранение списка книг
        /// </summary>
        private void SaveBooks() {
            using (FileStream fs = new FileStream("books.xml", FileMode.Create)) {
                XmlSerializer serializer = new XmlSerializer(typeof(Book[]));
                serializer.Serialize(fs, Books.ToArray());
            }
        }

        /// <summary>
        /// Загрузка списка книг
        /// </summary>
        private void LoadBooks() {
            Books.Clear();
            if (File.Exists("books.xml")) {
                using (FileStream fs = new FileStream("books.xml", FileMode.Open)) {
                    XmlSerializer serializer = new XmlSerializer(typeof(Book[]));
                    object o = serializer.Deserialize(fs);
                    if (o != null) {
                        Book[] books = (Book[])o;
                        foreach (Book book in books) {
                            Books.Add(book);
                        }
                    }
                }
            }
        }
    }
}
