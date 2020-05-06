namespace Pandemic.Web.Data.Entities
{
    public class UserStatus
    {
        public int Id { get; set; }
        public UserEntity User { get; set; }
        public Status Status { get; set; }
    }
}
