using Microsoft.AspNetCore.Mvc;
using Numeric_base_converter.DTO;
using Numeric_base_converter.Services;

namespace Numeric_base_converter.Controllers;

[ApiController]
[Route("[controller]")]
public class ConverterController : ControllerBase
{
    protected readonly IConverter _converter;
    public ConverterController(IConverter converter)
    {
        _converter = converter;
    }

    [HttpGet]
    [Route("/Status")]
    public IActionResult Status()
    {
        return Ok("Service Online");
    }


    [HttpPost]
    public IActionResult Convert([FromBody] RequestConversion request)
    {
        var result = _converter.To(_converter.From(request.number!, request.fromBase), request.toBase);
        var response = new ConvertedDTO()
        {
            convertedBase = request.toBase,
            convertedNumber = result,
            originalBase = request.fromBase,
            originalNumber = request.number
        };
        return Ok(response);
    }
}