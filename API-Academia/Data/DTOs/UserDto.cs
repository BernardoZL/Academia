namespace API_Academia.Data.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public int IdCargo { get; set; }
        public required string Nome { get; set; }
        public required string Cargo { get; set; }
    }
}
