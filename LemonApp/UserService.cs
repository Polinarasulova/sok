using System;
using System.Linq;

namespace LemonApp
{
    public class UserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public User GetUser(string username)
        {
            var users = _context.LoadUsers();
            var user = users.FirstOrDefault(u => u.Username == username) 
                       ?? new User { Username = username };

            if ((DateTime.UtcNow - user.LastActiveTime).TotalDays > 4)
                user.Lemons = 0;

            user.LastActiveTime = DateTime.UtcNow;

            if (users.All(u => u.Username != user.Username))
                users.Add(user);
            else
                users[users.FindIndex(u => u.Username == user.Username)] = user;

            _context.SaveUsers(users);

            return user;
        }

        public User AddLemons(string username, int lemonsToAdd)
        {
            var users = _context.LoadUsers();
            var user = users.FirstOrDefault(u => u.Username == username);

            if (user == null) throw new Exception("Пользователь не найден");

            user.Lemons += lemonsToAdd;
            _context.SaveUsers(users);
            return user;
        }

        public User AddBonuses(string username, int bonusesToAdd)
        {
            var users = _context.LoadUsers();
            var user = users.FirstOrDefault(u => u.Username == username);

            if (user == null) throw new Exception("Пользователь не найден");

            user.Bonuses += bonusesToAdd;
            _context.SaveUsers(users);
            return user;
        }
    }
}