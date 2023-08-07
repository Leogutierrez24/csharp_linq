class LinqQueries
{
    private List<Book> _booksCollection = new List<Book>();

    public LinqQueries() 
    {
        using(StreamReader sr = new StreamReader("books.json"))
        {
            string json = sr.ReadToEnd();
            this._booksCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() {PropertyNameCaseInsensitive = true})!;
        }
    }

    public IEnumerable<Book> GetCollection()
    {
        return this._booksCollection;
    }

    public IEnumerable<Book> GetBooksAfter2000()
    {
        // Extension method
        // return this._booksCollection.Where(x => x.PublishedDate.Year > 2000);

        // Query expression
        return from book in _booksCollection where book.PublishedDate.Year > 2000 select book;
    }

    public IEnumerable<Book> GetBooksByPagesAndTitle(int pages, string title)
    {
        return from book in _booksCollection 
        where book.PageCount >= pages && book.Title.Contains(title)
        select book;
    }

    public bool AllBooksHaveStatus()
    {
        return this._booksCollection.All(book => book.Status != string.Empty);
    }

    public bool BookPublishedOnYear(int year)
    {
        return this._booksCollection.Any(book => book.PublishedDate.Year == year);
    }

    public IEnumerable<Book> GetPythonBooks()
    {
        return from book in this._booksCollection
        where book.Categories.Contains("Python")
        select book;
    }

    public IEnumerable<Book> GetJavaBooksOrder()
    {
        return from book in this._booksCollection
        where book.Categories.Contains("Java")
        orderby book.Title
        select book;
    }

    public IEnumerable<Book> GetBooksByPagesDescending(int pages)
    {
        return from book in this._booksCollection
        where book.PageCount > pages
        orderby book.PageCount descending
        select book;
    }
}