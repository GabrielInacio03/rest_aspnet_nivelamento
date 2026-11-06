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
    [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
    public IActionResult GetSubtraction(string firstNumber, string secondNumber)
    {
        if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var subtraction = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(subtraction.ToString());
        }
       
        return BadRequest("Invalid Input!");
        
        
    }

    [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
    public IActionResult GetMultiplication(string firstNumber, string secondNumber)
    {
        if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(multiplication.ToString());
        }
       
        return BadRequest("Invalid Input!");
        
        
    }
    [HttpGet("division/{firstNumber}/{secondNumber}")]
    public IActionResult GetDivision(string firstNumber, string secondNumber)
    {
        if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
            return Ok(division.ToString());
        }
       
        return BadRequest("Invalid Input!");
        
        
    }
    [HttpGet("mean/{firstNumber}/{secondNumber}")]
    public IActionResult GetMean(string firstNumber, string secondNumber)
    {
        if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var mean = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
            return Ok(mean.ToString());
        }
       
        return BadRequest("Invalid Input!");
        
        
    }
    [HttpGet("squareRoot/{firstNumber}")]
    public IActionResult GetSquareRoot(string firstNumber)
    {
        if(IsNumeric(firstNumber))
        {
            var squareRoot = Math.Sqrt((double)ConvertToDecimal(firstNumber));
            return Ok(squareRoot.ToString());
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
