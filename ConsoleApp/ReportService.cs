using System.Collections.Generic;
using System.IO;
using TemplateEngine.Docx;

namespace ConsoleApp
{
    public sealed class ReportService
    {
        public void GenerateReport(ObjectInfo companyInfo, string output = "")
        {
            if (companyInfo is null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(output))
            {
                output = Path.Combine(Directory.GetCurrentDirectory(), "ObjectReport.docx");
            }

            if (File.Exists(output))
            {
                File.Delete(output);
            }

            File.Copy(@"D:\YandexDisk\Обучение\GeekBrain\C#_U_MVC\GB_MVC\TempDoc.docx", output);

            List<TableRowContent> employeeRows = new List<TableRowContent>();

            foreach (Employee employee in companyInfo.Employees)
            {
                employeeRows.Add(new TableRowContent(new List<FieldContent>()
                {
                    new FieldContent("Employee name", employee.Name),
                    new FieldContent("Position", employee.Position)
                    
                }));
            }

            List<TableRowContent> workRows = new List<TableRowContent>();
            foreach (Work work in companyInfo.Works)
            {
                workRows.Add(new TableRowContent(new List<FieldContent>()
                {
                    new FieldContent("Work name", work.Name),
                    new FieldContent("Work value", work.Value.ToString())

                }));
            }

            var valuesToFill = new Content(
                new FieldContent("Name", companyInfo.Name),
                new FieldContent("Date", companyInfo.StartDate.ToShortDateString()),
                TableContent.Create("Employee Table", employeeRows),
                TableContent.Create("Works", workRows)

            );

            using (var outputDocument =
                new TemplateProcessor(output)
                    .SetRemoveContentControls(true))
            {
                outputDocument.FillContent(valuesToFill);
                outputDocument.SaveChanges();
            }
        }
    }
}