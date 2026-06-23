namespace Matrimony.Models.DTOs.Country
{
    public class CountryDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
