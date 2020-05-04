namespace Pandemic.Web.Data.Entities
{
    public class Cities
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Country Country { get; set; }
    }
}
