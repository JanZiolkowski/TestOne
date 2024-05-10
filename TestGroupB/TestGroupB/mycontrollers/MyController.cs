using Microsoft.AspNetCore.Mvc;
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
}