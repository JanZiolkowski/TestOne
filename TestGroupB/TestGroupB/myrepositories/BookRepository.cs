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
        command.CommandText = "SELECT title FROM books";
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
}