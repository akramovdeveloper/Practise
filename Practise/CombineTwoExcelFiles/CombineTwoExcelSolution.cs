using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Globalization;

namespace Practise.CombineTwoExcelFiles;
public class CombineTwoExcelSolution
{
    public static void Solution()
    {
        string firstExcelFile = @"C:\Users\User\Desktop\54554544.xlsx";
        string secondExcelFile = @"C:\Users\User\Desktop\ВИИБ_Пластик_Ноябрь_2023й_программа.xlsx";
        string newExcelFile = @"C:\Users\User\Desktop\545545.xlsx";

        using (var wb1 = new XLWorkbook(firstExcelFile))
        {
            var sheet1 = wb1.Worksheet(1);
            using (var wb2 = new XLWorkbook(secondExcelFile))
            {
                var sheet2 = wb2.Worksheet(1);
                using (var wbNew = new XLWorkbook())
                {
                    var sheetNew = wbNew.Worksheets.Add("MergedData");
                    try
                    {
                        for (int row = 2; row <= sheet1.LastRowUsed().RowNumber(); row++)
                        {
                            var pinfl = sheet1.Cell(row, 1).Value.ToString().Trim();
                            var birthDate = Convert.ToDateTime(sheet1.Cell(row, 2).Value.ToString().Trim());
                            var seriya = sheet1.Cell(row, 3).Value.ToString().Trim();
                            var seriyaNumber = sheet1.Cell(row, 4).Value.ToString().Trim();
                            var organizationInn = sheet1.Cell(row, 5).Value.ToString().Trim();
                            var str = sheet1.Cell(row, 6).Value.ToString().Trim();
                            var phoneNumber = sheet1.Cell(row, 7).Value.ToString().Trim();
                            var uzCard = sheet1.Cell(row, 8).Value.ToString().Trim();
                            var bankCodeUzCard = sheet1.Cell(row, 9).Value.ToString().Trim();
                            var humo = sheet1.Cell(row, 10).Value.ToString().Trim();
                            var bankCodeHumo = sheet1.Cell(row, 11).Value.ToString().Trim();

                            for (int row2 = 2; row2 <= sheet2.LastRowUsed().RowNumber(); row2++)
                            {
                                var pinfl2 = sheet2.Cell(row2, 13).Value.ToString().Trim();
                                var uzCard2 = sheet2.Cell(row2, 14).Value.ToString().Trim();
                                var banCode = "01054--";

                                if (pinfl == pinfl2)
                                {
                                    uzCard = uzCard2;
                                    bankCodeUzCard = banCode;
                                }
                            }

                            int newRow = row;
                            sheetNew.Row(newRow).Cell(1).Value = pinfl;
                            sheetNew.Row(newRow).Cell(2).Value = birthDate;
                            sheetNew.Row(newRow).Cell(3).Value = seriya;
                            sheetNew.Row(newRow).Cell(4).Value = seriyaNumber;
                            sheetNew.Row(newRow).Cell(5).Value = organizationInn;
                            sheetNew.Row(newRow).Cell(6).Value = str;
                            sheetNew.Row(newRow).Cell(7).Value = phoneNumber;
                            sheetNew.Row(newRow).Cell(8).Value = uzCard;
                            sheetNew.Row(newRow).Cell(9).Value = bankCodeUzCard;
                            sheetNew.Row(newRow).Cell(10).Value = humo;
                            sheetNew.Row(newRow).Cell(11).Value = bankCodeHumo;

                            Console.WriteLine($"{pinfl}: qo'shildi");
                        }

                        // Save the new workbook to the specified file
                        wbNew.SaveAs(newExcelFile);
                    }
                    catch (Exception ex)
                    {
                        // Print detailed exception information
                        Console.WriteLine($"Error: {ex.Message}");
                        Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                        Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                        // Re-throw the exception to preserve the original behavior
                        throw;
                    }
                }
            }
        }
    }

}
