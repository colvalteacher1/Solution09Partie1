using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Solution09Partie1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Numero1Controller : ControllerBase
    {
        //conversion temperature Fahrenheit <-> Celsius

        [HttpGet("{sensConvert}/{tempValue}")]
        public IActionResult ConvertTemp(string sensConvert, string tempValue)
        {
            if (string.IsNullOrEmpty(sensConvert.Trim()) || (sensConvert.ToLower() != "celsius" && sensConvert.ToLower() != "fahrenheit"))
                return BadRequest("Faites attention sens de converion invalide!");

            if (!int.TryParse(tempValue, out var tempValueInt))
                return BadRequest("Faites attention il faut une valeur numérique pour la température");

            if(sensConvert.ToLower() == "fahrenheit")
            {
                var fah = (tempValueInt * 9   + 160 ) / 5;
                return Ok($"{tempValueInt} celsius => {fah} fahrenheit");
            }

            if (sensConvert.ToLower() == "celsius")
            {
                var cel = (float) (5 * (tempValueInt -32)) / 9;
                return Ok($"{tempValueInt} fahrenheit => {cel.ToString("F1")} celsius");
            }

            return BadRequest("Quelque chose va mal");

        }
        
    }
}
