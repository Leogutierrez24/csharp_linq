static void PrintValues(IEnumerable<Book> bookList)
{
    Console.WriteLine("{0, -70} {1, 7} {2, 11}\n", "Title", "Pages", "Published Date");
    foreach (Book item in bookList)
    {
        Console.WriteLine("{0, -70} {1, 7} {2, 11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

static void PrintGroups(IEnumerable<IGrouping<int, Book>> booksList)
{
    foreach(var group in booksList)
    {
        Console.WriteLine($"\nGroup: {group.Key}");
        Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Title", "Pages", "Published Date");
        foreach(var item in group)
        {
            Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
        }
    }
}

static void PrintDictionary(ILookup<char, Book> booksList, char someChar)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Title", "Pages", "Published Date");
    foreach(var item in booksList[someChar])
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

LinqQueries queries = new();

// Getting all the collection
// PrintValues(queries.GetCollection());

// Gettin the books published after 2000's
// PrintValues(queries.GetBooksAfter2000());

// Getting by pages and title filter
PrintValues(queries.GetBooksByPagesAndTitle(250, "in Action"));

// Console.WriteLine($"All the books have status: {queries.AllBooksHaveStatus()}");
// Console.WriteLine($"Is there any book published on 2005?: {queries.BookPublishedOnYear(2005)}");

// PrintValues(queries.GetPythonBooks());

// OrderBy
// PrintValues(queries.GetJavaBooksOrder());

// OrderByDescending
// PrintValues(queries.GetBooksByPagesDescending(450));

// Take
// PrintValues(queries.GetBooksByFilter(3, "Java"));

// Skip
//PrintValues(queries.UsingSkipQuery(400));

// Select
// PrintValues(queries.GetBookTitleandPageCount());

// Count and LongCount
Console.WriteLine($"The qty of books with 200 and 500 pages are: {queries.GetBooksQtyByPageCount(200, 500)}");

// Min and Max
Console.WriteLine($"The first book published was in {queries.GetFirstBookPublished().ToShortDateString()}");

Console.WriteLine($"The book with most page count have: {queries.GetBookWithMostPagesCount()} pages");

// MinBy and MaxBy
Book bookWithFewestPages = queries.GetBookWithFewestPageCount();
Console.WriteLine($"The book with fewest page count is {bookWithFewestPages.Title} with {bookWithFewestPages.PageCount} pages.");

Book newestBook = queries.GetNewestBook();
Console.WriteLine($"{newestBook.Title}");

// Sum
Console.WriteLine($"Total pages of books with 0 and 500 pages => " + queries.SumOfAllPageCount(0, 500));

// Aggregate
Console.WriteLine(queries.BooksBeforeYear(2015));

// Average
Console.WriteLine(queries.TitlesCharAverage());

// GroupBy
PrintGroups(queries.GetBooksBeforeYear(2000));

// Lookup
PrintDictionary(queries.BooksDictionary(), 'S');

// Join
PrintValues(queries.UsingJoinLinq());