using SecondBrainAPI.Models;

namespace SecondBrainAPI.DTOs
{
    public class ReminderDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public ulong? CreatorId { get; set; }
        public UserDTO? Creator { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public static ReminderDTO ModelToDTO(Reminder model, User user)
        {
            return new ReminderDTO
            {
                Title = model.Title,
                Description = model.Description,
                CreatorId = model.CreatorId,
                Creator = UserDTO.ModelToDTO(user),
                CreatedAt = model.CreatedAt,
                UpdatedAt = model.UpdatedAt
            };
        }
    }
}
