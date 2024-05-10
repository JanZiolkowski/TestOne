using System.Data.SqlClient;
using TestGroupB.mymodels;

namespace TestGroupB.myrepositories;

public class BookRepository : IBookRepository
{
    private IConfiguration _configuration;

    public BookRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<Book> getBookWithTitle(int idBook)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();
        //===
        await using var command = new SqlCommand();
        command.Connection = con;
        command.CommandText = "SELECT title FROM books WHERE PK=@IdBook";
        command.Parameters.AddWithValue("IdBook", idBook);

        var reader = await command.ExecuteReaderAsync();
        //===
        Book returnBook = null;
        if (reader.Read())
        {
            returnBook = new Book()
            {
                IdBook = idBook,
                Title = reader["title"].ToString()
            };
        }

        return returnBook;
    }

    public async Task<IEnumerable<string>> getGeneres(int idBook)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();
        //===
        await using var command = new SqlCommand();
        command.Connection = con;
        command.CommandText = "SELECT DISTINCT name FROM genres as g, books as b, books_genres as bg WHERE b.PK=@IdBook and bg.FK_book=b.PK and g.PK=bg.FK_book";
        command.Parameters.AddWithValue("IdBook", idBook);

        var reader = await command.ExecuteReaderAsync();
        //===
        List<String> generes = new List<string>();
        while (reader.Read())
        {
            Console.Write("1");
            generes.Append(reader["name"].ToString());
        }

        return generes;
    }

    public async Task<IEnumerable<Author>> getAuthors(int idBook)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();
        //===
        await using var command = new SqlCommand();
        command.Connection = con;
        command.CommandText = "SELECT first_name,last_name FROM authors as a,books_authors as ba, books as b WHERE b.PK=@IdBook and ba.FK_book=b.PK and ba.FK_author=a.PK";
        command.Parameters.AddWithValue("IdBook", idBook);

        var reader = await command.ExecuteReaderAsync();
        //===
        List<Author> authors = new List<Author>();
        while (reader.Read())
        {
            Author author = new Author()
            {
                firstName = reader["first_name"].ToString(),
                lastName = reader["last_name"].ToString()
            };
            authors.Append(author);
        }

        return authors;
    }
}