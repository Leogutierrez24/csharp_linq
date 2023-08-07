class Book
{
    private string _title = string.Empty;
    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }

    private int _pageCount;
    public int PageCount
    {
        get { return _pageCount; }
        set { _pageCount = value; }
    }

    private DateTime _publishedDate;
    public DateTime PublishedDate
    {
        get { return _publishedDate; }
        set { _publishedDate = value; }
    }

    private string _description = string.Empty;
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    private string _status = string.Empty;
    public string Status
    {
        get { return _status; }
        set { _status = value; }
    }

    private string[] _authors = new string[] { "" };
    public string[] Authors
    {
        get { return _authors; }
        set { _authors = value; }
    }

    private string[] _categories = new string[] { "" };
    public string[] Categories
    {
        get { return _categories; }
        set { _categories = value; }
    }

    public Book() { }
}