namespace Backend.DTOs
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class UserCreateDTO
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class UserUpdateDTO
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public required string CurrentPassword { get; set; }
        public required string NewPassword { get; set; }
    }
}