using Microsoft.JSInterop;
using OfficeOpenXml;
using System.Text;
using WebServer_Proof_of_concept.Components.Models;

namespace WebServer_Proof_of_concept.Components.Helpers
{
    public static class Functions
    {
        public static async Task ExportToExcel(IJSRuntime jsRuntime, int activeTab, IEnumerable<object> data)
        {
            if (data == null) return;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Data");
                var properties = data.First().GetType().GetProperties();
                for (int i = 0; i < properties.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = properties[i].Name;
                }

                var index = 2;
                foreach (var item in data)
                {
                    for (int i = 0; i < properties.Length; i++)
                    {
                        worksheet.Cells[index, i + 1].Value = properties[i].GetValue(item)?.ToString();
                    }
                    index++;
                }

                var excelData = package.GetAsByteArray();
                var fileName = activeTab == 1 ? "Users.xlsx" : "Businesses.xlsx";
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                await jsRuntime.InvokeVoidAsync("downloadFile", fileName, contentType, excelData);
            }
        }

        public static async Task ExportToCsv(IJSRuntime jsRuntime, int activeTab, IEnumerable<object> data)
        {
            if (data == null) return;

            var csvBuilder = new StringBuilder();
            var properties = data.First().GetType().GetProperties();
            csvBuilder.AppendLine(string.Join(",", properties.Select(p => p.Name)));

            foreach (var item in data)
            {
                var values = properties.Select(p => p.GetValue(item)?.ToString());
                csvBuilder.AppendLine(string.Join(",", values));
            }

            var csvData = Encoding.UTF8.GetBytes(csvBuilder.ToString());
            var fileName = activeTab == 1 ? "Users.csv" : "Businesses.csv";
            var contentType = "text/csv";

            await jsRuntime.InvokeVoidAsync("downloadFile", fileName, contentType, csvData);
        }
    }
}
