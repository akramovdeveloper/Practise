using ClosedXML.Excel;

namespace Practise.CombineTwoExcelFiles;
public class CombineTwoExcelSolution
{
    public static void Solution()
    {
        string firstExcelFile = @"C:\Users\User\Desktop\54554544.xlsx";
        string secondExcelFile = @"C:\Users\User\Desktop\ВИИБ_Пластик_Ноябрь_2023й_программа.xlsx";
        string newExcelFile = @"C:\Users\User\Desktop\545545.xlsx";

        using (var fs1 = new XLWorkbook(firstExcelFile))
        {

            using (var fs2 = new XLWorkbook(secondExcelFile))
            {

                using (var stw = new StreamWriter(newExcelFile))
                {

                }
            }
        }
        
    }
}
