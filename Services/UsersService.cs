using System.Collections.Generic;
using System.Threading.Tasks;

namespace _6lr
{
    public interface IUsersService
    {
        Task<List<Users>> GetUsers();
        Task AddUser(Users user);
        Task UpdateUser(Users user);
        Task DeleteUser(int id);
    }

    public class UsersService : IUsersService
    {
        private readonly List<Users> _users = new List<Users>();
        public UsersService()
        {
            _users.Add(new Users { Id = 0, Name = "Oleg", Surname = "Oleg", PhoneBrand = "Samsung", PhoneName = "Galaxy S22" });
            _users.Add(new Users { Id = 1, Name = "Ivan", Surname = "Ivan", PhoneBrand = "Apple", PhoneName = "iPhone 14" });
            _users.Add(new Users { Id = 2, Name = "Maria", Surname = "Maria", PhoneBrand = "Xiaomi", PhoneName = "Redmi Note 11" });
            _users.Add(new Users { Id = 3, Name = "Anna", Surname = "Anna", PhoneBrand = "Honor", PhoneName = "9 Pro" });
            _users.Add(new Users { Id = 4, Name = "Pavel", Surname = "Pavel", PhoneBrand = "Google", PhoneName = "Pixel 6" });
            _users.Add(new Users { Id = 5, Name = "Olga", Surname = "Olga", PhoneBrand = "Huawei", PhoneName = "Mate 50" });
            _users.Add(new Users { Id = 6, Name = "Andrii", Surname = "Andrii", PhoneBrand = "Sony", PhoneName = "Xperia 1 III" });
            _users.Add(new Users { Id = 7, Name = "Natalia", Surname = "Natalia", PhoneBrand = "Realme", PhoneName = "8 Pro" });
            _users.Add(new Users { Id = 8, Name = "Dmitry", Surname = "Dmitry", PhoneBrand = "Oppo", PhoneName = "Find X5" });
            _users.Add(new Users { Id = 9, Name = "Svitlana", Surname = "Svitlana", PhoneBrand = "Vivo", PhoneName = "X80 Pro" });
        }
        public async Task<List<Users>> GetUsers()
        {
            return _users;
        }

        public async Task AddUser(Users user)
        {
            _users.Add(user);
        }

        public async Task UpdateUser(Users user)
        {
            var index = _users.FindIndex(p => p.Id == user.Id);
            if (index != -1)
            {
                _users[index] = user;
            }
        }

        public async Task DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(p => p.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }
    }
}
