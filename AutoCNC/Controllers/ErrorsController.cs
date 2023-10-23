using Microsoft.AspNetCore.Mvc;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error() => Problem(); // return Problem method from ControllerBase. Return 500 Internal Server Error.
}