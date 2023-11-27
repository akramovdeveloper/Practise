using ClosedXML.Excel;

namespace Practise.MakeInsertScript;
public class ReadFromExcel
{
    private static void ReadFromExcelMethod()
    {
        string excelFilePath = @"C:\Users\User\Desktop\enum_process.xlsx";
        string outputFilePath = @"C:\Users\User\Desktop\insert_enum_process.txt";
        int i = 1;
        using (var workbook = new XLWorkbook(excelFilePath))
        {
            var worksheet = workbook.Worksheet(1);
            int startRow = 2;
            string CodeColumnName = "Code";
            string uzbColumnName = "uzb";
            string crilColumnName = "узб";
            string enColumnName = "en";

            int CodeColumnIndex = worksheet.FirstRowUsed().CellsUsed().First(c => c.Value.ToString() == CodeColumnName).Address.ColumnNumber;
            int uzbColumnIndex = worksheet.FirstRowUsed().CellsUsed().First(c => c.Value.ToString() == uzbColumnName).Address.ColumnNumber;
            int crilColumnIndex = worksheet.FirstRowUsed().CellsUsed().First(c => c.Value.ToString() == crilColumnName).Address.ColumnNumber;
            int enColumnIndex = worksheet.FirstRowUsed().CellsUsed().First(c => c.Value.ToString() == enColumnName).Address.ColumnNumber;

            using (StreamWriter sw = new StreamWriter(outputFilePath))
            {
                for (int row = startRow; row <= worksheet.LastRowUsed().RowNumber(); row++)
                {
                    string code = worksheet.Cell(row, CodeColumnIndex).Value.ToString();
                    string uz = worksheet.Cell(row, uzbColumnIndex).Value.ToString();
                    string cril = worksheet.Cell(row, crilColumnIndex).Value.ToString();
                    string en = worksheet.Cell(row, enColumnIndex).Value.ToString();

                    sw.WriteLine(@$"INSERT INTO edoc.enum_process_translate(ownerid, languageid, columnname, translatetext)" +
                        $"VALUES ({code}, {2}, \'ShortName\', \'{uz}\');");
                    sw.WriteLine($"INSERT INTO edoc.enum_process_translate(ownerid, languageid, columnname, translatetext)" +
                        $"VALUES ({code}, {3}, \'ShortName\', \'{cril}\');");
                    sw.WriteLine($"INSERT INTO edoc.enum_process_translate(ownerid, languageid, columnname, translatetext)" +
                        $"VALUES ({code}, {4}, \'ShortName\', \'{en}\');");
                    sw.WriteLine($"INSERT INTO edoc.enum_process_translate(ownerid, languageid, columnname, translatetext)" +
                        $"VALUES ({code}, {2}, \'FullName\', \'{uz}\');");
                    sw.WriteLine($"INSERT INTO edoc.enum_process_translate(ownerid, languageid, columnname, translatetext)" +
                        $"VALUES ({code}, {3}, \'FullName\', \'{cril}\');");
                    sw.WriteLine($"INSERT INTO edoc.enum_process_translate(ownerid, languageid, columnname, translatetext)" +
                        $"VALUES ({code}, {4}, \'FullName\', \'{en}\');");
                    i++;
                }
            }
        }
    }
}
