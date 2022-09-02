namespace ExcelMVC.Models.DTOs
{
    public struct CountryDTO
    {
        public string Name { get; set; }
        public string Capital { get; set; }
        public double Area { get; set; }
        public List<Currency> Currencies { get; set; }
    }
}
