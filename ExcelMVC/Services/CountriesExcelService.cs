using ClosedXML.Excel;
using ExcelMVC.Models;
using ExcelMVC.Models.DTOs;

namespace ExcelMVC.Services
{
    public static class CountriesExcelService
    {
        public static XLWorkbook GenerateExcel(IEnumerable<CountryDTO> data)
        {
            XLWorkbook wb = new XLWorkbook(XLEventTracking.Disabled);
            IXLWorksheet ws = wb.Worksheets.Add("Countries");
            ws.Range("A1:D1").Merge();
            ws.Cell(1, 1).SetValue("Countries List");

            var countries = data.Select(c => new { Name = c.Name ?? "-", Capital = c.Capital ?? "-", Area = c.Area, Currencies = c.Currencies != null ? String.Join(",", c.Currencies.Select(x => x.Code)) : "-" });
            var columns = countries.First().GetType().GetProperties();
            foreach (var col in Enumerable.Range(1, columns.Length))
            {
                ws.Cell(2, col).Value = columns[col - 1].Name;
            }

            ws.Row(1).Style.Font.Bold = true;
            ws.Row(1).Style.Font.FontColor = XLColor.FromHtml("#4F4F4F");
            ws.Row(1).Style.Font.FontSize = 16;
            ws.Row(1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            ws.Row(2).Style.Font.Bold = true;
            ws.Row(2).Style.Font.FontColor = XLColor.FromHtml("#808080");
            ws.Row(2).Style.Font.FontSize = 12;

            ws.Cell(3, 1).Value = countries.AsEnumerable();
            ws.Column("C").Style.NumberFormat.Format = "#,##0.00";
            ws.Columns().AdjustToContents();

            return wb;
        }
    }
}
