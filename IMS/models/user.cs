namespace IMS.models
{
    public class user
    {
        public string USERNAME { get; set; } = string.Empty;

        public byte[] ?PasswordHash { get; set; }

        public byte[]? PasswordSalt { get; set; }
    }
}
