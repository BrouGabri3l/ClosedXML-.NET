using ExcelMVC.Models.DTOs;
using Refit;
namespace ExcelMVC.Models.Interfaces
{
    public interface ICountryRepository
    {
        [Get("/all")]
        Task<IEnumerable<CountryDTO>> GetCountries();
    }
}
