using TestGroupB.mymodels;

namespace TestGroupB.myservices;

public interface IService
{
    public Task<Book> getBook(int idBook);
}