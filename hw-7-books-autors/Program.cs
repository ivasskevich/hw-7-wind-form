namespace hw_7_books_autors
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var view = new Form1();
            var manager = new AuthorBookManager(view);
            Application.Run(view);
        }
    }
}