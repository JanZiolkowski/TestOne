using Microsoft.AspNetCore.Mvc;
using TestGroupB.mymodels;
using TestGroupB.myservices;

namespace TestGroupB.mycontrollers;
[ApiController]
[Route("api/books")]
public class MyController: ControllerBase
{
    private IService _service;

    public MyController(IService service)
    {
        _service = service;
    }
    
    [HttpGet("{idBook:int}")]
    public async Task<IActionResult> getBook(int idBook)
    {
        Book retrievedBook = await _service.getBook(idBook);
        if (retrievedBook == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, "The book with " + idBook + " id wasn't found!");
        }

        return Ok(retrievedBook);
    }
}    
