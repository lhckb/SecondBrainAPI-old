namespace SecondBrainAPI.Exceptions
{
    public class ReminderNotFoundException : Exception
    {
        public ReminderNotFoundException() : base("Reminder not found")
        {

        }
    }
}
