namespace TestGroupB.mymodels;

public class Book
{
    public int IdBook { set; get; }
    public string Title { set; get; }
    public IEnumerable<string> authors { get; set; }
    public IEnumerable<string> generes { get; set; }
}