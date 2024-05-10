using TestGroupB.mymodels;

namespace TestGroupB.myrepositories;

public interface IBookRepository
{
    public Task<Book> getBookWithTitle(int idBook);
    public Task<IEnumerable<Author>> getAuthors(int idBook); 
    public Task<IEnumerable<String>> getGeneres(int idBook);
}