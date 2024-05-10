using Microsoft.AspNetCore.Mvc;
using TestGroupB.mymodels;
using TestGroupB.myrepositories;

namespace TestGroupB.myservices;

public class MyService : IService
{
    private IBookRepository _bookRepository;
    private IGenreRepository _genreRepository;

    public MyService(IBookRepository bookRepository, IGenreRepository genreRepository)
    {
        _bookRepository = bookRepository;
        _genreRepository = genreRepository;
    }

    public async Task<Book> getBook(int idBook)
    {
        Book book = await _bookRepository.getBookWithTitle(idBook);
        IEnumerable<Author> authors = await _bookRepository.getAuthors(idBook);
        book.authors = (List<Author>)authors;
        IEnumerable<string> generes = await _bookRepository.getGeneres(idBook);
        book.generes=(List<string>) generes;
        return book;
    }
}