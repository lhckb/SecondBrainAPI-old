using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace SecondBrainAPI.Models
{
    public class Reminder
    {
        public ulong Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public ulong CreatorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
