namespace Pandemic.Common.Models
{
    public class CitiesResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CountryResponse Country { get; set; }
    }
}
