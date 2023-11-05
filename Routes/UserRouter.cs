using Microsoft.EntityFrameworkCore;
using SecondBrainAPI.Repositories;
using SecondBrainAPI.Models;
using SecondBrainAPI.Controllers;
using SecondBrainAPI.Exceptions;
using SecondBrainAPI.DTOs;

namespace SecondBrainAPI.Routes
{
    public class UserRouter
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/users", (User user, SecondBrainDb db) =>
            {
                try
                {
                    User newUser = UserController.CreateUser(user, db);
                    return Results.Created("/users", new { Data = newUser });
                }
                catch (Exception ex)
                {
                    return Results.UnprocessableEntity(new { Error = ex.Message });
                }

            });

            app.MapGet("/users/{id}", (ulong id, SecondBrainDb db) =>
            {
                try
                {
                    UserDTO user = UserController.GetUser(id, db);
                    return Results.Ok(new { Data = user });
                }
                catch (UserNotFoundException ex)
                {
                    return Results.NotFound(new { Error = ex.Message });
                }
                catch (Exception ex)
                {
                    return Results.UnprocessableEntity(new { Error = ex.Message });
                }
                
            });

            app.MapDelete("/users/{id}", (ulong id, SecondBrainDb db) =>
            {
                try
                {
                    UserController.DeleteUser(id, db);
                    return Results.Ok(new { Message = "User deleted." });
                }
                catch (UserNotFoundException ex)
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
