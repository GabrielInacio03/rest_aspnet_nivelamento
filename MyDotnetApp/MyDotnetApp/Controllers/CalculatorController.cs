using Microsoft.AspNetCore.Mvc;

namespace MyDotnetApp.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{


    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Get(string firstNumber, string secondNumber)
    {
        if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
       
        return BadRequest("Invalid Input!");
        
    }

    private bool IsNumeric(string firstNumber)
    {
        return decimal.TryParse(firstNumber, 
        System.Globalization.NumberStyles.Any, 
        System.Globalization.NumberFormatInfo.InvariantInfo,
         out _);
    }
    private decimal ConvertToDecimal(string firstNumber)
    {
        decimal decimalValue;
        if(decimal.TryParse(firstNumber,
        System.Globalization.NumberStyles.Any, 
        System.Globalization.NumberFormatInfo.InvariantInfo, out decimalValue))
        {
            return decimalValue;
        }
        return 0;
    }
}
