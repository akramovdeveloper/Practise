using ClosedXML.Excel;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Practise.BankInfoFromOracle;
public class BankInfo
{
    public static void BankInfoWithJoin()
    {
        //string oracleConnString = "Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 194.93.25.245)(PORT = 15230)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xtmbat_pdb) ) );User Id=xtmbat_adm;Password=xtmbat_adm_pass;";
        string oracleConnString = "Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.43.39)(PORT = 1521)) ) (CONNECT_DATA = (SERVICE_NAME = xtmbat) ) );User Id=XTMBAT_USER;Password=XTMBAT_USER_PASSWORD;";

        string outputPath = @$"C:\Users\User\Desktop\1.xlsx";
        string outputPath2 = @$"C:\Users\User\Desktop\script.sql";

        DataTable dataTable = new("BankInfo");
        dataTable.Columns.AddRange(new DataColumn[]
        {
            new DataColumn("Id"),
            new DataColumn("PINFL"),
            new DataColumn("Full Name"),
            new DataColumn("Passport"),
            new DataColumn("Gender"),
            new DataColumn("Birth Date"),
        });

        using (var oracleConn = new OracleConnection(oracleConnString))
        {
            oracleConn.Open();
            using (var cmd = new OracleCommand("SELECT p.id, p.pinfl, p.Full_Name, p.doc_seria, p.doc_number, g.full_name, p.BIRTH_ON FROM hrm.hl_person p join CMN.ENUM_GENDER g on g.id = p.GENDER_ID", oracleConn))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dataTable.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), $"{reader.GetString(3)} {reader.GetString(4)}", reader.GetString(5), reader.GetString(6));
                }
            }
        }

        using (XLWorkbook wb = new XLWorkbook())
        {
            var ws = wb.Worksheets.Add(dataTable);

            ws.Columns().AdjustToContents();
            ws.CellsUsed().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            using (MemoryStream stream = new MemoryStream())
            {
                wb.SaveAs(stream);
                File.WriteAllBytes(outputPath, stream.ToArray());
            }
        }

        /*List<string> pinflList = new List<string>();
        using (var oracleConn = new OracleConnection(oracleConnString))
        {
            oracleConn.Open();
            using (var cmd = new OracleCommand("select p.pinfl from hrm.hl_employee e inner join hrm.hl_person p on e.person_id = p.id where e.organization_id = 60", oracleConn))
            {
                var reader = cmd.ExecuteReader();
                using (StreamWriter sw = new StreamWriter(outputPath2))
                {
                    while (reader.Read())
                    {
                        pinflList.Add(reader.GetString(0));
                    }
                }
            }
        }
        using (var wb1 = new XLWorkbook(outputPath))
        {
            var sheet1 = wb1.Worksheet(1);
            for (int row = 4; row <= sheet1.LastRowUsed().RowNumber(); row++)
            {
                var pinfl = sheet1.Cell(row, 1).Value.ToString().Trim();
                if (pinflList.Contains(pinfl))
                {
                    sheet1.Row(row).Delete();
                    Console.WriteLine(pinfl + " o'chirildi");
                }
            }
            wb1.Save();
        }*/
    }
}
