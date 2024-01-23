using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Npgsql;
using Oracle.ManagedDataAccess.Client;

namespace Practise.PostgresOracle;
public class ConnectTwoBase
{
    public static void ConnectTwoBaseMethod()
    {
        string postgresConnString = "Host=83.69.136.217;Port=6529;Username=postgres;Password=WEB@$Ef0rever;Database=sspuis3;Pooling=false;";
        string oracleConnString = "Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 194.93.25.245)(PORT = 15230)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xtmbat_pdb) ) );User Id=xtmbat_adm;Password=xtmbat_adm_pass;";

        List<PgDistrict> pgDistricts = new List<PgDistrict>();
        List<OrcDistrict> orcDistricts = new List<OrcDistrict>();

        using (var postgresConn = new NpgsqlConnection(postgresConnString))
        {
            postgresConn.Open();
            using (var cmd = new NpgsqlCommand("select * from public.info_region", postgresConn))
            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    pgDistricts.Add(new PgDistrict()
                    {
                        Id = reader.GetInt32(0),
                        Code = reader.GetString(2)
                    });
                }
        }
        string outputFilePath = @"C:\Users\User\Desktop\alter table adm.info_district.sql";
        using (var oracleConn = new OracleConnection(oracleConnString))
        {
            oracleConn.Open();
            using (var cmd = new OracleCommand("select * from adm.info_region", oracleConn))
            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    orcDistricts.Add(new OrcDistrict()
                    {
                        Id = reader.GetInt32(0),
                        Code = reader.IsDBNull(13) ? null : reader.GetString(13),
                    });
                    
                }
            pgDistricts = pgDistricts.OrderBy(x => x.Id).ToList();
            orcDistricts = orcDistricts.OrderBy(x => x.Id).ToList();
            foreach (var pgDistrict in pgDistricts)
            {
                var matchingOrcDistrict = orcDistricts.FirstOrDefault(orc => orc.Id == pgDistrict.Id);
                if (matchingOrcDistrict != null)
                {
                    matchingOrcDistrict.Code = pgDistrict.Code;
                }
            }
            /*foreach (var orcDistrict in orcDistricts)
            {
                using (var cmd = new OracleCommand($"UPDATE adm.info_nationality SET WbCode = :WbCode WHERE Id = :Id", oracleConn))
                {
                    cmd.Parameters.Add(new OracleParameter("WbCode", orcDistrict.Soato));
                    cmd.Parameters.Add(new OracleParameter("Id", orcDistrict.Id));
                    cmd.ExecuteNonQuery();
                }
            }*/

            using (StreamWriter sw = new StreamWriter(outputFilePath))
            {
                foreach (var item in orcDistricts)
                {
                    sw.WriteLine(@$"UPDATE ADM.INFO_REGION SET CODE = N'{item.Code}' WHERE ID = {item.Id};");
                }
            }
        }
    }
}
