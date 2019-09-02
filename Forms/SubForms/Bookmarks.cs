using ElementEditor;
using ElementEditor.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PWDataEditorPaied.helper_classes
{
    public partial class Bookmarks : Form
    {
        private BookMark book = null;
        private int profileId = -1;
        public List<BookMark> bookmarks = new List<BookMark>();
        public Bookmarks(BookMark _book, int _books)
        {
            InitializeComponent();
            book = _book;
            profileId = _books;
            bookmarks = ElementsEditor.configs.profiles[profileId].bookmarks;
            bookmarks.Add(_book);
        }

        public Bookmarks(BookMark _book, int _books, bool data)
        {
            InitializeComponent();

            profileId = _books;
            bookmarks = ElementsEditor.configs.profiles[profileId].bookmarks;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if(bookmarksList.SelectedIndex > -1)
            {
                ElementsEditor.configs.profiles[profileId].bookmarks.RemoveAt(bookmarksList.SelectedIndex);
                new SystemCacheManager().setConfigs(ElementsEditor.configs);
                bookmarks = ElementsEditor.configs.profiles[profileId].bookmarks;
                Bookmarks_Shown(null, null);
            }
        }

        private void bookmarksList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = bookmarksList.SelectedIndex;
            if(index >= 0)
            {
                nextautoIdlabel.Text = getEditorByID(bookmarks[index].editorID).ToString();
                textBox1.Text = bookmarks[index].name;
                textBox2.Text = bookmarks[index].listIndex.ToString();
                textBox3.Text = bookmarks[index].elementIndex.ToString();
                textBox4.Text = bookmarks[index].rowIndex.ToString();
            }
        }

        private string getEditorByID(int id)
        {
            if(id == Constatns.elementEditorId)
                return "Element Editor";
            if (id == Constatns.TaskEditorId)
                return "Task Editor";
            if (id == Constatns.GshopEditorId)
                return "Shop Editor";
            return "unknown";
        }

        private void Bookmarks_Shown(object sender, EventArgs e)
        {
            bookmarksList.Items.Clear();
            foreach (BookMark book in bookmarks)
            {
                bookmarksList.Items.Add(getEditorByID(book.editorID) + " - " + book.name);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ElementsEditor.configs.profiles[profileId].bookmarks[bookmarksList.SelectedIndex].name = textBox1.Text;
                bookmarksList.Items[bookmarksList.SelectedIndex] = textBox1.Text;
            }
            catch { }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ElementsEditor.configs.profiles[profileId].bookmarks[bookmarksList.SelectedIndex].listIndex = int.Parse(textBox2.Text);
            }
            catch { }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ElementsEditor.configs.profiles[profileId].bookmarks[bookmarksList.SelectedIndex].elementIndex = int.Parse(textBox3.Text);
            }
            catch { }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ElementsEditor.configs.profiles[profileId].bookmarks[bookmarksList.SelectedIndex].rowIndex = int.Parse(textBox4.Text);
            }
            catch { }
        }
    }
}
