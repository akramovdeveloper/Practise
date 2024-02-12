namespace Practise.PostgresOracle;
public class OrcDistrict
{
    public int Id { get; set; }
    public string? OrderCode { get; set; }
    public string? TreasCode { get; set; }
    public string? Soato { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public int CountryId { get; set; }
    public int StateId { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? CreatedUserId { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public int? ModifiedUserId { get; set; }
    public string? RoamingCode { get; set; }
    public string? Code { get; set; }


}
