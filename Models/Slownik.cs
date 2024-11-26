[Table("Slownik")]
public class Slownik
{
	[Key]
	[Required]
	public int slownik_id { get; set; }
	[Required]
	public string kod { get; set; } = string.Empty;
	[Required]
	public string nazwa { get; set; } = string.Empty;
}
