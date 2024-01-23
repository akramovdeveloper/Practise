namespace Practise.PostgresOracle;
public class PgDistrict
{
    public int Id { get; set; }
    public string? OrderCode { get; set; } = null;
    public string? Code { get; set; } = null;
    public string Soato { get; set; }
    public string? SoatoOfMfy { get; set; } = null;
    public string? RoamingCode { get; set; } = null;    
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int? RegionId { get; set; } = null;
    public int? StateId { get; set; } = null;
    public DateTime? CreatedAt { get; set; } = null;
    public int? CreatedUserId { get; set; } = null;
    public DateTime? ModifiedAt { get; set; } = null;
    public int? ModifiedUserId { get; set; } = null;

}
