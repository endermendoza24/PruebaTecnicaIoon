namespace IoonSistema
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Guid CommerceId { get; set; }
        public Guid State { get; set; }
    }
}
