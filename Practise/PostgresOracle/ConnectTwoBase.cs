using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Npgsql;
using Oracle.ManagedDataAccess.Client;

namespace Practise.PostgresOracle;
public class ConnectTwoBase
{
    public static void ConnectTwoBaseMethod()
    {
        //string postgresConnString = "Host=83.69.136.217;Port=6529;Username=postgres;Password=WEB@$Ef0rever;Database=sspuis3;Pooling=false;";
        string oracleConnString = "Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 194.93.25.245)(PORT = 15230)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xtmbat_pdb) ) );User Id=xtmbat_adm;Password=xtmbat_adm_pass;";

        //List<PgNationality> pgNationalityList = new List<PgNationality>();
        List<OrcNationality> orcNationalities = new List<OrcNationality>();

        /*using (var postgresConn = new NpgsqlConnection(postgresConnString))
        {
            postgresConn.Open();
            using (var cmd = new NpgsqlCommand("select * from public.info_nationality", postgresConn))
            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    pgNationalityList.Add(new PgNationality()
                    {
                        Id = reader.GetInt32(0),
                        WbCode = reader.GetString(1),
                        ShortName = reader.GetString(2),
                        FullName = reader.GetString(3),
                        StateId = reader.GetInt32(4),
                    });
                }
        }*/
        string outputFilePath = @"C:\Users\User\Desktop\alter table adm.info_nationality.sql";
        using (var oracleConn = new OracleConnection(oracleConnString))
        {
            oracleConn.Open();
            using (var cmd = new OracleCommand("select * from adm.info_nationality", oracleConn))
            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    orcNationalities.Add(new OrcNationality()
                    {
                        Id = reader.GetInt32(0),
                        Code = reader.GetString(1),
                        ShortName = reader.GetString(2),
                        FullName = reader.GetString(3),
                        StateId = reader.GetInt32(4),
                        WbCode = reader.IsDBNull(9) ? "0" : reader.GetString(9)
                    });
                    /*Console.WriteLine($"{reader.GetInt32(0)}, {reader.GetString(1)}, {reader.GetString(2)}, {reader.GetString(3)}, {reader.GetInt32(4)}");*/
                }

            using (StreamWriter sw = new StreamWriter(outputFilePath))
            {
                foreach (var item in orcNationalities)
                {
                    sw.WriteLine(@$"UPDATE ADM.INFO_NATIONALITY SET WBCODE = N'{item.WbCode}' WHERE ID = {item.Id};");
                }
            }

            /*foreach (var pgNationality in pgNationalityList)
            {
                var matchingOrcNationality = orcNationalities.FirstOrDefault(orc => orc.FullName == pgNationality.FullName);
                if (matchingOrcNationality != null)
                {
                    matchingOrcNationality.WbCode = pgNationality.WbCode;
                }
            }
            foreach (var orcNationality in orcNationalities)
            {
                using (var cmd = new OracleCommand($"UPDATE adm.info_nationality SET WbCode = :WbCode WHERE Id = :Id", oracleConn))
                {
                    cmd.Parameters.Add(new OracleParameter("WbCode", orcNationality.WbCode));
                    cmd.Parameters.Add(new OracleParameter("Id", orcNationality.Id));
                    cmd.ExecuteNonQuery();
                }
            }*/
        }
    }
}
