namespace hw_7_books_autors
{
    public partial class Form1 : Form, IBookAuthorView
    {
        public event EventHandler AuthorAdded;
        public event EventHandler AuthorUpdated;
        public event EventHandler AuthorRemoved;

        public event EventHandler BookAdded;
        public event EventHandler BookUpdated;
        public event EventHandler BookRemoved;

        public event EventHandler FilterToggle;
        public event EventHandler FilterChanged;

        public event EventHandler LoadFile;
        public event EventHandler SaveFileEvent;
        public event EventHandler ApplicationExit;

        public IAuthor CurrentAuthor => comboBox1.SelectedItem as IAuthor;

        public bool IsFilterEnabled => checkBox1.Checked;

        public string CurrentBook => listBox1.SelectedItem as string;

        public Form1()
        {
            InitializeComponent();
            ConfigureEvents();
        }

        private void ConfigureEvents()
        {
            openToolStripMenuItem.Click += (s, e) => LoadFile?.Invoke(s, e);
            saveToolStripMenuItem.Click += (s, e) => SaveFileEvent?.Invoke(s, e);
            signOutToolStripMenuItem.Click += (s, e) => ApplicationExit?.Invoke(s, e);

            addAuthorToolStripMenuItem.Click += (s, e) => AuthorAdded?.Invoke(s, e);
            editAuthorToolStripMenuItem.Click += (s, e) => AuthorUpdated?.Invoke(s, e);
            deleteAuthorToolStripMenuItem.Click += (s, e) => AuthorRemoved?.Invoke(s, e);

            addABookToolStripMenuItem.Click += (s, e) => BookAdded?.Invoke(s, e);
            editBookToolStripMenuItem.Click += (s, e) => BookUpdated?.Invoke(s, e);
            deleteABookToolStripMenuItem.Click += (s, e) => BookRemoved?.Invoke(s, e);

            comboBox1.SelectedIndexChanged += (s, e) => FilterChanged?.Invoke(s, e);
            checkBox1.CheckedChanged += (s, e) => FilterToggle?.Invoke(s, e);
        }

        public void ShowAuthors(IEnumerable<IAuthor> authors)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(authors.ToArray());
            if (authors.Any())
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        public void ShowBooks(IEnumerable<string> books)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(books.ToArray());
        }

        public string GetUserInput(string prompt, string title, string defaultValue = "")
        {
            return InputDialog.Show(prompt, title, defaultValue) ?? string.Empty;
        }

        public void DisplayMessage(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public string OpenFile(string filter, string title)
        {
            using (var dialog = new OpenFileDialog { Filter = filter, Title = title })
            {
                return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : null;
            }
        }

        public string SaveFile(string filter, string title)
        {
            using (var dialog = new SaveFileDialog { Filter = filter, Title = title })
            {
                return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : null;
            }
        }
    }

    public class AuthorBookManager
    {
        private readonly IBookAuthorView _ui;
        private readonly List<IAuthor> _data;

        public AuthorBookManager(IBookAuthorView ui)
        {
            _ui = ui;
            _data = new List<IAuthor>();

            _ui.AuthorAdded += AddAuthor;
            _ui.AuthorUpdated += UpdateAuthor;
            _ui.AuthorRemoved += RemoveAuthor;

            _ui.BookAdded += AddBook;
            _ui.BookUpdated += UpdateBook;
            _ui.BookRemoved += RemoveBook;

            _ui.FilterToggle += UpdateFilter;
            _ui.FilterChanged += RefreshBooks;

            _ui.LoadFile += LoadData;
            _ui.SaveFileEvent += SaveData;
            _ui.ApplicationExit += ExitApp;
        }

        private void AddAuthor(object sender, EventArgs e)
        {
            string name = _ui.GetUserInput("Enter author's name:", "Add Author");

            if (string.IsNullOrWhiteSpace(name))
            {
                _ui.DisplayMessage("Author name cannot be empty!", "Error");
                return;
            }

            if (_data.Any(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                _ui.DisplayMessage("Author already exists!", "Error");
                return;
            }

            _data.Add(new Author(name));
            _ui.ShowAuthors(_data);
        }

        private void UpdateAuthor(object sender, EventArgs e)
        {
            var selectedAuthor = _ui.CurrentAuthor;
            if (selectedAuthor == null)
            {
                _ui.DisplayMessage("No author selected!", "Error");
                return;
            }

            string newName = _ui.GetUserInput("Enter new name:", "Update Author", selectedAuthor.Name);

            if (!string.IsNullOrWhiteSpace(newName))
            {
                selectedAuthor.Name = newName;
                _ui.ShowAuthors(_data);
            }
        }

        private void RemoveAuthor(object sender, EventArgs e)
        {
            var selectedAuthor = _ui.CurrentAuthor;
            if (selectedAuthor == null)
            {
                _ui.DisplayMessage("No author selected!", "Error");
                return;
            }

            _data.Remove(selectedAuthor);
            _ui.ShowAuthors(_data);
            RefreshBooks(sender, e);
        }

        private void AddBook(object sender, EventArgs e)
        {
            var author = _ui.CurrentAuthor;
            if (author == null)
            {
                _ui.DisplayMessage("No author selected!", "Error");
                return;
            }

            string bookTitle = _ui.GetUserInput("Enter book title:", "Add Book");
            if (!string.IsNullOrWhiteSpace(bookTitle))
            {
                author.Books.Add(bookTitle);
                RefreshBooks(sender, e);
            }
        }

        private void UpdateBook(object sender, EventArgs e)
        {
            var author = _ui.CurrentAuthor;
            string selectedBook = _ui.CurrentBook;

            if (author == null || string.IsNullOrEmpty(selectedBook))
            {
                _ui.DisplayMessage("No book selected!", "Error");
                return;
            }

            string newTitle = _ui.GetUserInput("Enter new title:", "Update Book", selectedBook);
            if (!string.IsNullOrWhiteSpace(newTitle))
            {
                int index = author.Books.IndexOf(selectedBook);
                author.Books[index] = newTitle;
                RefreshBooks(sender, e);
            }
        }

        private void RemoveBook(object sender, EventArgs e)
        {
            var author = _ui.CurrentAuthor;
            string selectedBook = _ui.CurrentBook;

            if (author == null || string.IsNullOrEmpty(selectedBook))
            {
                _ui.DisplayMessage("No book selected!", "Error");
                return;
            }

            author.Books.Remove(selectedBook);
            RefreshBooks(sender, e);
        }

        private void RefreshBooks(object sender, EventArgs e)
        {
            if (_ui.CurrentAuthor != null && _ui.IsFilterEnabled)
            {
                _ui.ShowBooks(_ui.CurrentAuthor.Books);
            }
            else
            {
                var allBooks = _data.SelectMany(a => a.Books).ToList();
                _ui.ShowBooks(allBooks);
            }
        }

        private void UpdateFilter(object sender, EventArgs e)
        {
            RefreshBooks(sender, e);
        }

        private void LoadData(object sender, EventArgs e)
        {
            string filePath = _ui.OpenFile("JSON Files (*.json)|*.json|All Files (*.*)|*.*", "Load Authors and Books");
            if (!string.IsNullOrEmpty(filePath))
            {
                try
                {
                    string content = File.ReadAllText(filePath);
                    var authors = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Author>>(content);
                    _data.Clear();
                    if (authors != null) _data.AddRange(authors);

                    _ui.ShowAuthors(_data);
                    RefreshBooks(sender, e);
                }
                catch (Exception ex)
                {
                    _ui.DisplayMessage($"Error loading file: {ex.Message}", "Error");
                }
            }
        }

        private void SaveData(object sender, EventArgs e)
        {
            string filePath = _ui.SaveFile("JSON Files (*.json)|*.json|All Files (*.*)|*.*", "Save Authors and Books");
            if (!string.IsNullOrEmpty(filePath))
            {
                try
                {
                    string content = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
                    File.WriteAllText(filePath, content);
                    _ui.DisplayMessage("File saved successfully.", "Success");
                }
                catch (Exception ex)
                {
                    _ui.DisplayMessage($"Error saving file: {ex.Message}", "Error");
                }
            }
        }

        private void ExitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    public class Author : IAuthor
    {
        public string Name { get; set; }
        public List<string> Books { get; set; }

        public Author(string name)
        {
            Name = name;
            Books = new List<string>();
        }

        public override string ToString() => Name;
    }

    public interface IBookAuthorView
    {
        event EventHandler AuthorAdded;
        event EventHandler AuthorUpdated;
        event EventHandler AuthorRemoved;

        event EventHandler BookAdded;
        event EventHandler BookUpdated;
        event EventHandler BookRemoved;

        event EventHandler FilterToggle;
        event EventHandler FilterChanged;

        event EventHandler LoadFile;
        event EventHandler SaveFileEvent;
        event EventHandler ApplicationExit;

        void ShowAuthors(IEnumerable<IAuthor> authors);
        void ShowBooks(IEnumerable<string> books);

        string GetUserInput(string prompt, string title, string defaultValue = "");
        void DisplayMessage(string message, string title);
        string OpenFile(string filter, string title);
        string SaveFile(string filter, string title);

        IAuthor CurrentAuthor { get; }
        bool IsFilterEnabled { get; }
        string CurrentBook { get; }
    }

    public interface IAuthor
    {
        string Name { get; set; }
        List<string> Books { get; set; }
    }

    public static class InputDialog
    {
        public static string Show(string prompt, string title, string defaultValue = "")
        {
            using (var form = new Form())
            {
                form.Text = title;
                var label = new Label { Text = prompt, Dock = DockStyle.Top, AutoSize = true };
                var input = new TextBox { Text = defaultValue, Dock = DockStyle.Top };
                var button = new Button { Text = "OK", Dock = DockStyle.Bottom };
                button.Click += (s, e) => form.DialogResult = DialogResult.OK;

                form.Controls.Add(input);
                form.Controls.Add(label);
                form.Controls.Add(button);
                form.AcceptButton = button;

                return form.ShowDialog() == DialogResult.OK ? input.Text.Trim() : null;
            }
        }
    }
}
