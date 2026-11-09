using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution09Partie1.Utils;
using System.Globalization;

namespace Solution09Partie1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Numero1ET2Controller : ControllerBase
    {
        //conversion temperature Fahrenheit <-> Celsius

        [HttpGet]
        [Route("num1/{sensConvert}/{tempValue}")]
        public IActionResult ConvertTemp(string sensConvert, string tempValue)
        {
            if (string.IsNullOrEmpty(sensConvert.Trim()) || (sensConvert.ToLower() != "celsius" && sensConvert.ToLower() != "fahrenheit"))
                return BadRequest("Faites attention sens de converion invalide!");

            if (!int.TryParse(tempValue, out var tempValueInt))
                return BadRequest("Faites attention il faut une valeur numérique pour la température");

            if (sensConvert.ToLower() == "fahrenheit")
            {
                var fah = (tempValueInt * 9 + 160) / 5;
                return Ok($"{tempValueInt} celsius => {fah} fahrenheit");
            }

            if (sensConvert.ToLower() == "celsius")
            {
                var cel = (float)(5 * (tempValueInt - 32)) / 9;
                return Ok($"{tempValueInt} fahrenheit => {cel.ToString("F1")} celsius");
            }

            return BadRequest("Quelque chose va mal");

        }


        [HttpGet]
        [Route("num2/{date}")]
        public IActionResult GetTempFromDate(string date)
        {
            var parseDate = Utils.Utils.ParseDateFromString(date);
            if (parseDate == null)
                return BadRequest("Faites attention le format de la date est inconnu");

            Random random = new Random();
            int currentYear = parseDate.Value.Year;
            string format = "dd-MM-yyyy";

            if (parseDate >= DateOnly.ParseExact($"22-03-{currentYear}", format, CultureInfo.InvariantCulture) && parseDate <= DateOnly.ParseExact($"21-06-{currentYear}", format, CultureInfo.InvariantCulture)) // spring
                return Ok($"Saison: printemps, Date: {parseDate} , Température en cours {random.NextInt64(5, 25)}"); ;

            if (parseDate >= DateOnly.ParseExact($"22-06-{currentYear}", format, CultureInfo.InvariantCulture) && parseDate <= DateOnly.ParseExact($"21-09-{currentYear}", format, CultureInfo.InvariantCulture)) // summer
                return Ok($"Saison: été, Date: {parseDate} , Température en cours {random.NextInt64(10, 35)}"); ;

            if (parseDate >= DateOnly.ParseExact($"22-09-{currentYear}", format, CultureInfo.InvariantCulture) && parseDate <= DateOnly.ParseExact($"21-12-{currentYear}", format, CultureInfo.InvariantCulture)) // fall
                return Ok($"Saison: automne, Date: {parseDate} , Température en cours {random.NextInt64(-10, 15)}"); ;

            // winter
                return Ok($"Saison: hiver, Date: {parseDate} , Température en cours {random.NextInt64(-20, 15)}"); ;
        }
    
    }
}
