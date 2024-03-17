using System.Collections.Generic;
using System.Threading.Tasks;

namespace _6lr
{
    public interface ICompaniesService
    {
        Task<List<Companies>> GetCompanies();
        Task AddCompany(Companies company);
        Task UpdateCompany(Companies company);
        Task DeleteCompany(int id);
    }

    public class CompaniesService : ICompaniesService
    {
        private readonly List<Companies> _companies = new List<Companies>();
        public CompaniesService()
        {
            _companies.Add(new Companies { Id = 0, Name = "Apple", Country = "USA"});
            _companies.Add(new Companies { Id = 1, Name = "Samsung", Country = "Korea" });
            _companies.Add(new Companies { Id = 2, Name = "Huawei", Country = "China" });
            _companies.Add(new Companies { Id = 3, Name = "Xiaomi", Country = "China" });
            _companies.Add(new Companies { Id = 4, Name = "Google", Country = "USA" });
            _companies.Add(new Companies { Id = 5, Name = "Honor", Country = "China" });
            _companies.Add(new Companies { Id = 6, Name = "Sony", Country = "Japan" });
            _companies.Add(new Companies { Id = 7, Name = "Realme", Country = "China" });
            _companies.Add(new Companies { Id = 8, Name = "Oppo", Country = "China" });
            _companies.Add(new Companies { Id = 9, Name = "Vivo", Country = "China" });

        }
        public async Task<List<Companies>> GetCompanies()
        {
            return _companies;
        }

        public async Task AddCompany(Companies company)
        {
            _companies.Add(company);
        }

        public async Task UpdateCompany(Companies company)
        {
            var index = _companies.FindIndex(p => p.Id == company.Id);
            if (index != -1)
            {
                _companies[index] = company;
            }
        }

        public async Task DeleteCompany(int id)
        {
            var company = _companies.FirstOrDefault(p => p.Id == id);
            if (company != null)
            {
                _companies.Remove(company);
            }
        }
    }
}
