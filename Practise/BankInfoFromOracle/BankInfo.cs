using Oracle.ManagedDataAccess.Client;

namespace Practise.BankInfoFromOracle;
public class BankInfo
{
    public static void BankInfoWithJoin()
    {
        //string oracleConnString = "Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 194.93.25.245)(PORT = 15230)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xtmbat_pdb) ) );User Id=xtmbat_adm;Password=xtmbat_adm_pass;";
        string oracleConnString = "Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.43.39)(PORT = 1521)) ) (CONNECT_DATA = (SERVICE_NAME = xtmbat) ) );User Id=XTMBAT_USER;Password=XTMBAT_USER_PASSWORD;";

        //string outputPath = @$"C:\Users\User\Desktop\BankInfo.xlsx";
        string outputPath = @$"C:\Users\User\Desktop\script.sql";

        /*DataTable dataTable = new("BankInfo");
        dataTable.Columns.AddRange(new DataColumn[]
        {
            new DataColumn("Name"),
            new DataColumn("Code"),
            new DataColumn("BankName")
        });*/

        /*using (var oracleConn = new OracleConnection(oracleConnString))
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
        }*/

        /*using (XLWorkbook wb = new XLWorkbook())
        {
            var ws = wb.Worksheets.Add(dataTable);

            ws.Columns().AdjustToContents();
            ws.CellsUsed().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            using (MemoryStream stream = new MemoryStream())
            {
                wb.SaveAs(stream);
                File.WriteAllBytes(outputPath, stream.ToArray());
            }
        }*/

        using (var oracleConn = new OracleConnection(oracleConnString))
        {
            oracleConn.Open();
            using (var cmd = new OracleCommand("select * from SALARY.INFO_CALCULATION_KIND where state_id = 1 order by id", oracleConn))
            {
                var reader = cmd.ExecuteReader();
                using (StreamWriter sw = new StreamWriter(outputPath))
                {
                    while (reader.Read())
                    {
                        sw.WriteLine(@$"insert into SALARY.INFO_CALCULATION_KIND_USED_TABLE (OWNER_ID, START_ON, END_ON, CALC_FROM_IN_SUM, FORMED_CALCULATION_KIND_ID, MINIMUM_VALUE_TYPE_ID, QUANTITY_OF_MINIMUM_VALUE)
values (42, to_date('01-01-2023', 'dd-mm-yyyy'), null, 0, {reader.GetInt32(0)}, null, 0.00);");
                    }
                }
            }
        }
    }
}
