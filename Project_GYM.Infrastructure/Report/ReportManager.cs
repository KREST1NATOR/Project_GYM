using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project_GYM.Infrastructure.Report
{
    public class ReportManager
    {
        public byte[] GenerateReport<TEntity>(IEnumerable<TEntity> info)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var package = new ExcelPackage();
                var sheet = package.Workbook.Worksheets.Add("Отчёт");

                sheet.Cells["A1"].LoadFromCollection(info, true);

                sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

                using (var range = sheet.Cells[sheet.Dimension.Address])
                {
                    range.Style.Font.Name = "Times New Roman";
                    range.Style.Font.Size = 12;
                    range.Style.Font.Color.SetColor(System.Drawing.Color.Red);
                }

                var byteArray = package.GetAsByteArray();

                MessageBox.Show("Отчет успешно сгенерирован и сохранен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                return byteArray;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при генерации отчета: {ex.Message}");

                MessageBox.Show($"Ошибка при генерации отчета: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return null;
            }
        }
    }
}
