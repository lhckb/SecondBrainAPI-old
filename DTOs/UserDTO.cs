using SecondBrainAPI.Models;

namespace SecondBrainAPI.DTOs
{
    public class UserDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public static UserDTO ModelToDTO(User model)
        {
            return new UserDTO { 
                FirstName = model.FirstName, 
                LastName = model.LastName, 
                Email = model.Email, 
                CreatedAt = model.CreatedAt, 
                UpdatedAt = model.UpdatedAt 
            };
        }
    }
}
