namespace TestGroupB.mymodels;

public class Book
{
    public int IdBook { set; get; }
    public string Title { set; get; }
    public List<Author> authors { get; set; }
    public List<string> generes { get; set; }
}