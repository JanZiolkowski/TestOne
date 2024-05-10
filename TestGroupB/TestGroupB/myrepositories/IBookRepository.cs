using TestGroupB.mymodels;

namespace TestGroupB.myrepositories;

public interface IBookRepository
{
    public Task<Book> getBookWithTitle(int idBook);
}