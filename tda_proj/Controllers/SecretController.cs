using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api")]
public class SecretController : Controller
{
    public class SecretResponse
    {
        public string Secret { get; set; }
    }

    [HttpGet]
    public IActionResult Get()
    {
        var secretResponse = new SecretResponse
        {
            Secret = "The cake is a lie"
        };

        return Ok(secretResponse);
    }
}

