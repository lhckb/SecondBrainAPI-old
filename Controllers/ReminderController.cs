using SecondBrainAPI.Models;
using SecondBrainAPI.Repositories;
using SecondBrainAPI.Exceptions;
using SecondBrainAPI.DTOs;

namespace SecondBrainAPI.Controllers
{
    public class ReminderController
    {
        public static Reminder CreateReminder(ReminderDTO reminderRequest, SecondBrainDb db)
        {
            ulong userId = (ulong) reminderRequest.CreatorId;
            User user = UserController.FindUser(userId, db);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            Reminder reminder = new Reminder();
            reminder.Title = reminderRequest.Title;
            reminder.Description = reminderRequest.Description;
            reminder.CreatorId = user.Id;
            reminder.CreatedAt = DateTime.UtcNow;
            reminder.UpdatedAt = DateTime.UtcNow;

            db.Reminders.Add(reminder);
            db.SaveChanges();

            return reminder;
        }

        public static Reminder FindReminder(ulong reminder_id, SecondBrainDb db)
        {
            Reminder? reminder = db.Reminders.Find(reminder_id);
            if (reminder == null)
            {
                throw new ReminderNotFoundException();
            }

            return reminder;
        }

        public static ReminderDTO GetReminder(ulong reminder_id, SecondBrainDb db)
        {
            Reminder reminder = FindReminder(reminder_id, db);
            User user = UserController.FindUser(reminder.CreatorId, db);

            return ReminderDTO.ModelToDTO(reminder, user);
        }

        public static void DeleteReminder(ulong reminder_id, SecondBrainDb db)
        {
            Reminder reminder = FindReminder(reminder_id, db);

            db.Reminders.Remove(reminder);
            db.SaveChanges();
        }
    }
}
