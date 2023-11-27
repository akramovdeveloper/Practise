using ClosedXML.Excel;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Practise.BankInfoFromOracle;
public class BankInfo
{
    public static void BankInfoWithJoin()
    {
        string oracleConnString = "Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 194.93.25.245)(PORT = 15230)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xtmbat_pdb) ) );User Id=xtmbat_adm;Password=xtmbat_adm_pass;";

        string outputPath = @$"C:\Users\User\Desktop\BankInfo.xlsx";

        DataTable dataTable = new("BankInfo");
        dataTable.Columns.AddRange(new DataColumn[]
        {
            new DataColumn("Name"),
            new DataColumn("Code"),
            new DataColumn("BankName")
        });

        using (var oracleConn = new OracleConnection(oracleConnString))
        {
            oracleConn.Open();
            using (var cmd = new OracleCommand("SELECT b.Full_Name, b.Code, c.Full_Name FROM adm.info_bank b INNER JOIN adm.enum_bank_code c ON b.Bank_Code_Id = c.ID", oracleConn))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dataTable.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2));
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
    }
}
