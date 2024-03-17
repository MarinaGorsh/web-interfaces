using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace _6lr
{
    public interface IPhonesService
    {
        Task<List<Phones>> GetPhones();
        Task AddPhone(Phones phone);
        Task UpdatePhone(Phones phone);
        Task DeletePhone(int id);
    }

    public class PhonesService : IPhonesService
    {
        private readonly List<Phones> _phones = new List<Phones>();
        public PhonesService()
        {
            _phones.Add(new Phones { Id = 0, Brand = "Apple", Model = "iPhone 14", Price = 5999 });
            _phones.Add(new Phones { Id = 1, Brand = "Samsung", Model = "Galaxy S22", Price = 6999 });
            _phones.Add(new Phones { Id = 2, Brand = "Xiaomi", Model = "Redmi Note 11", Price = 2999 });
            _phones.Add(new Phones { Id = 3, Brand = "Honor", Model = "9 Pro", Price = 7999 });
            _phones.Add(new Phones { Id = 4, Brand = "Google", Model = "Pixel 6", Price = 5999 });
            _phones.Add(new Phones { Id = 5, Brand = "Huawei", Model = "Mate 50", Price = 4999 });
            _phones.Add(new Phones { Id = 6, Brand = "Sony", Model = "Xperia 1 III", Price = 8999 });
            _phones.Add(new Phones { Id = 7, Brand = "Realme", Model = "8 Pro", Price = 2499 });
            _phones.Add(new Phones { Id = 8, Brand = "Oppo", Model = "Find X5", Price = 8999 });
            _phones.Add(new Phones { Id = 9, Brand = "Vivo", Model = "X80 Pro", Price = 3999 });
        }
        public async Task<List<Phones>> GetPhones()
        {
            return _phones;
        }

        public async Task AddPhone(Phones phone)
        {
            _phones.Add(phone);
        }

        public async Task UpdatePhone(Phones phone)
        {
            var index = _phones.FindIndex(p => p.Id == phone.Id);
            if (index != -1)
            {
                _phones[index] = phone;
            }
        }

        public async Task DeletePhone(int id)
        {
            var phone = _phones.FirstOrDefault(p => p.Id == id);
            if (phone != null)
            {
                _phones.Remove(phone);
            }
        }
    }
}
