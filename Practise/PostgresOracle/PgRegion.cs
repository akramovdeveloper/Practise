namespace Practise.PostgresOracle;
public class PgRegion
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string Code { get; set; }
    public string Soato { get; set; }
    public string RoamingCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int CountryId { get; set; }
    public int StateId { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? CreatedUserId { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public int? ModifiedUserId { get; set; }

}
