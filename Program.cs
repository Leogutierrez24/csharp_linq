static void PrintValues(IEnumerable<Book> bookList)
{
    Console.WriteLine("{0, -70} {1, 7} {2, 11}\n", "Title", "Pages", "Published Date");
    foreach(Book item in bookList)
    {
        Console.WriteLine("{0, -70} {1, 7} {2, 11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

LinqQueries queries = new();

// Getting all the collection
// PrintValues(queries.GetCollection());

// Gettin the books published after 2000's
// PrintValues(queries.GetBooksAfter2000());

// Getting by pages and title filter
PrintValues(queries.GetBooksByPagesAndTitle(250, "in Action"));

Console.WriteLine($"All the books have status: {queries.AllBooksHaveStatus()}");
Console.WriteLine($"Is there any book published on 2005?: {queries.BookPublishedOnYear(2005)}");

PrintValues(queries.GetPythonBooks());

PrintValues(queries.GetJavaBooksOrder());

PrintValues(queries.GetBooksByPagesDescending(450));