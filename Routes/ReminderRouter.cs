using SecondBrainAPI.Repositories;
using SecondBrainAPI.Models;
using SecondBrainAPI.Controllers;
using SecondBrainAPI.Exceptions;
using SecondBrainAPI.DTOs;

namespace SecondBrainAPI.Routes
{
    public class ReminderRouter
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/reminders", (ReminderDTO reminder, SecondBrainDb db) =>
            {
                try
                {
                    Reminder newReminder = ReminderController.CreateReminder(reminder, db);
                    return Results.Created($"/reminders", new { Data = newReminder });
                }
                catch (Exception ex)
                {
                    return Results.UnprocessableEntity(new { Error = ex.Message });
                }
            });

            app.MapGet("/reminders/{reminder_id}", (ulong reminder_id, SecondBrainDb db) =>
            {
                try
                {
                    ReminderDTO reminder = ReminderController.GetReminder(reminder_id, db);
                    return Results.Ok(new { Data = reminder });
                }
                catch (ReminderNotFoundException ex)
                {
                    return Results.NotFound(new { Error = ex.Message });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { Error = ex.Message });
                }
            });

            app.MapDelete("/reminders/{reminder_id}", (ulong reminder_id, SecondBrainDb db) =>
            {
                try
                {
                    ReminderController.DeleteReminder(reminder_id, db);
                    return Results.Ok(new { Message = "Reminder deleted." });
                }
                catch (ReminderNotFoundException ex)
                {
                    return Results.NotFound(new { Error = ex.Message });
                }
                catch (Exception ex) 
                {
                    return Results.UnprocessableEntity(new { Error = ex.Message });
                }
            });
        }
    }
}
