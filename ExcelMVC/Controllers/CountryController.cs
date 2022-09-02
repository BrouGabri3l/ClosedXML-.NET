using ExcelMVC.Models.DTOs;
using ExcelMVC.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExcelMVC.Services;
namespace ExcelMVC.Controllers
{
    [Route("api/[controller]")]
    public class CountryController : Controller
    {

        // GET: CountryController
        [HttpGet]
        public FileContentResult Index([FromServices] ICountryRepository repository)
        {
            try
            {
                var countries = repository.GetCountries();
                var excel = CountriesExcelService.GenerateExcel(countries.Result);
                using (MemoryStream stream = new MemoryStream())
                {
                    excel.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Countries.xlsx");
                }
            }
            catch (Exception err)
            {
                throw new Exception("An unexpected Error has Occurred: " + err.Message);
            }


        }

    }
}
