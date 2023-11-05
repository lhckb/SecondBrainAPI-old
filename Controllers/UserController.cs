using Microsoft.EntityFrameworkCore;
using SecondBrainAPI.Models;
using SecondBrainAPI.Repositories;
using SecondBrainAPI.Exceptions;
using SecondBrainAPI.DTOs;

namespace SecondBrainAPI.Controllers
{
    public class UserController
    {
        public static User CreateUser(User user, SecondBrainDb db)
        {
            user.CreatedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;
            db.Users.Add(user);
            db.SaveChanges();

            return user;
        }

        public static User FindUser(ulong id, SecondBrainDb db)
        {
            User? user = db.Users.Find(id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            return user;
        }

        public static UserDTO GetUser(ulong id, SecondBrainDb db)
        {
            User user = FindUser(id, db);

            return UserDTO.ModelToDTO(user);
        }

        public static void DeleteUser(ulong id, SecondBrainDb db)
        {
            User user = FindUser(id, db);

            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}
