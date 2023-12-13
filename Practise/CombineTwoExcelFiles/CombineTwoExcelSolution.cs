using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Globalization;

namespace Practise.CombineTwoExcelFiles;
public class CombineTwoExcelSolution
{
    public static void Solution()
    {
        string firstExcelFile = @"C:\Users\User\Desktop\1.xlsx";
        string secondExcelFile = @"C:\Users\User\Desktop\54554544.xlsx";
        string newExcelFile = @"C:\Users\User\Desktop\3.xlsx";

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
                        int count = 1;
                        for (int row = 4; row <= sheet1.LastRowUsed().RowNumber(); row++)
                        {
                            var pinfl = sheet1.Cell(row, 1).Value.ToString().Trim();
                            var birthDate = sheet1.Cell(row, 2).Value.ToString().Trim();
                            var seriya = sheet1.Cell(row, 3).Value.ToString().Trim();
                            var seriyaNumber = sheet1.Cell(row, 4).Value.ToString().Trim();
                            var organizationInn = sheet1.Cell(row, 5).Value.ToString().Trim();
                            var str = sheet1.Cell(row, 6).Value.ToString().Trim();
                            var phoneNumber = sheet1.Cell(row, 7).Value.ToString().Trim();
                            var uzCard = sheet1.Cell(row, 8).Value.ToString().Trim();
                            var bankCodeUzCard = sheet1.Cell(row, 9).Value.ToString().Trim();
                            var humo = sheet1.Cell(row, 10).Value.ToString().Trim();
                            var bankCodeHumo = sheet1.Cell(row, 11).Value.ToString().Trim();
                            var raqami = sheet1.Cell(row, 12).Value.ToString().Trim();
                            var sanasi = sheet1.Cell(row, 13).Value.ToString().Trim();
                            var holati = sheet1.Cell(row, 14).Value.ToString().Trim();
                            var yil = sheet1.Cell(row, 15).Value.ToString().Trim();
                            var oy = sheet1.Cell(row, 16).Value.ToString().Trim();
                            var kun = sheet1.Cell(row, 17).Value.ToString().Trim();
                            var bandlikTuri = sheet1.Cell(row, 18).Value.ToString().Trim();

                            for (int row2 = 2; row2 <= sheet2.LastRowUsed().RowNumber(); row2++)
                            {
                                var pinfl2 = sheet2.Cell(row2, 1).Value.ToString();
                                var birthDate2 = sheet2.Cell(row2, 2).Value.ToString();
                                var seriya2 = sheet2.Cell(row2, 3).Value.ToString();
                                var seriyaNumber2 = sheet2.Cell(row2, 4).Value.ToString();
                                var str2 = sheet2.Cell(row2, 6).Value.ToString();

                                if (pinfl == pinfl2)
                                {
                                    int x = birthDate2.IndexOf(" ");
                                    birthDate = x > 0 ? birthDate2[..x] : birthDate2;
                                    seriya = seriya2;
                                    seriyaNumber = seriyaNumber2;
                                    str = str2;
                                    break;
                                }
                            }
                            int sanx = sanasi.IndexOf(" "); 
                            int holx = holati.IndexOf(" "); 
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
                            sheetNew.Row(newRow).Cell(12).Value = raqami;
                            sheetNew.Row(newRow).Cell(13).Value = sanx > 0 ? sanasi[..sanx] : sanasi;
                            sheetNew.Row(newRow).Cell(14).Value = holx > 0 ? holati[..holx] : holati;
                            sheetNew.Row(newRow).Cell(15).Value = yil;
                            sheetNew.Row(newRow).Cell(16).Value = oy;
                            sheetNew.Row(newRow).Cell(17).Value = kun;
                            sheetNew.Row(newRow).Cell(18).Value = bandlikTuri;
                            Console.WriteLine($"{count++}. {pinfl}: qo'shildi");
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
