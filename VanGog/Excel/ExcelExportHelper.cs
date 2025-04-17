using ClosedXML.Excel;
using VanGog.Storage.Core.Entities;

namespace VanGog
{
    /// <summary>
    /// Класс для экспорта событий в Excel
    /// </summary>
    public static class ExcelExportHelper
    {
        public static void ExportEventsToExcel(List<Event> events, string filePath)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("События");

                    worksheet.Cell(1, 1).Value = "ID";
                    worksheet.Cell(1, 2).Value = "Название";
                    worksheet.Cell(1, 3).Value = "Описание";
                    worksheet.Cell(1, 4).Value = "Дата";
                    worksheet.Cell(1, 5).Value = "Время";
                    worksheet.Cell(1, 6).Value = "Категория";
                    worksheet.Cell(1, 7).Value = "Создатель";

                    // стиль заголовка
                    var headerRange = worksheet.Range(1, 1, 1, 7);
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;

                    // добавление данных
                    for (int i = 0; i < events.Count; i++)
                    {
                        worksheet.Cell(i + 2, 1).Value = events[i].EventId;
                        worksheet.Cell(i + 2, 2).Value = events[i].Title;
                        worksheet.Cell(i + 2, 3).Value = events[i].Description;
                        worksheet.Cell(i + 2, 4).Value = events[i].Date.ToShortDateString();
                        worksheet.Cell(i + 2, 5).Value = events[i].Time.ToString(@"hh\:mm");
                        worksheet.Cell(i + 2, 6).Value = events[i].Category;
                        worksheet.Cell(i + 2, 7).Value = events[i].CreatorId;
                    }

                    // автоматическая ширина колонок
                    worksheet.Columns().AdjustToContents();

                    workbook.SaveAs(filePath);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при создании Excel-файла: {ex.Message}", ex);
            }
        }
    }
}
