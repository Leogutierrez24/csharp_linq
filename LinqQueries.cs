using System.IO.Compression;

class LinqQueries
{
    private List<Book> _booksCollection = new List<Book>();

    public LinqQueries()
    {
        using (StreamReader sr = new StreamReader("books.json"))
        {
            string json = sr.ReadToEnd();
            this._booksCollection =
            System.Text
            .Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
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

    public IEnumerable<Book> GetBooksByFilter(int booksQty, string category)
    {
        return this._booksCollection.Where(book => book.Categories.Contains(category))
        .OrderByDescending(book => book.PublishedDate)
        .Take(booksQty);
    }

    public IEnumerable<Book> UsingSkipQuery(int pagesQty) // I don't know how to name this method
    {
        return this._booksCollection.Where(book => book.PageCount > pagesQty)
        .Take(4)
        .Skip(2);
    }

    public IEnumerable<Book> GetBookTitleandPageCount()
    {
        return _booksCollection.Take(3)
        .Select(book => new Book() { Title = book.Title, PageCount = book.PageCount });
    }

    public int GetBooksQtyByPageCount(int minValue, int maxValue)
    {
        return _booksCollection.Count(book => book.PageCount >= minValue && book.PageCount <= maxValue);
    }

    public DateTime GetFirstBookPublished()
    {
        return _booksCollection.Min(book => book.PublishedDate);
    }

    public int GetBookWithMostPagesCount()
    {
        return _booksCollection.Max(book => book.PageCount);
    }

    public Book GetBookWithFewestPageCount()
    {
        return _booksCollection.Where(book => book.PageCount > 0)
        .MinBy(book => book.PageCount)!;
    }

    public Book GetNewestBook()
    {
        return _booksCollection.MaxBy(book => book.PublishedDate)!;
    }

    public int SumOfAllPageCount(int min, int max)
    {
        return _booksCollection.Where(book => book.PageCount >= min && book.PageCount <= max).Sum(book => book.PageCount);
    }

    public string BooksBeforeYear(int year)
    {
        return _booksCollection.Where(book => book.PublishedDate.Year > year)
        .Aggregate("", (bookTitle, next) =>
        {
            if (bookTitle != string.Empty)
            {
                bookTitle += Environment.NewLine + next.Title;
            }
            else
            {
                bookTitle += next.Title;
            }

            return bookTitle;
        });
    }

    public double TitlesCharAverage()
    {
        return _booksCollection.Average(book => book.Title.Length);
    }

    public IEnumerable<IGrouping<int, Book>> GetBooksBeforeYear(int year)
    {
        return _booksCollection.Where(book => book.PublishedDate.Year > year)
        .GroupBy(book => book.PublishedDate.Year);
    }

    public ILookup<char, Book> BooksDictionary()
    {
        return _booksCollection.ToLookup(book => book.Title[0], book => book);
    }

    public IEnumerable<Book> UsingJoinLinq()
    {
        IEnumerable<Book> booksAfter2005 = _booksCollection.Where(book => book.PublishedDate.Year > 2005);

        IEnumerable<Book> booksWith500Pages = _booksCollection.Where(book => book.PageCount > 500);

        return booksAfter2005.Join(booksWith500Pages, firstCollection => firstCollection.Title, secondCollection => secondCollection.Title, (firstCollection, secondCollection) => firstCollection);
    }
}