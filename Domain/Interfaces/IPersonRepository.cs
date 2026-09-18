using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person?> GetByPersonIdAsync(int id);
        Task<Person?> GetByNationalNoAsync(string nationalNo);
        Task<IEnumerable<Person>> GetAllAsync();
        Task<int> AddAsync(Person person);
        Task<bool> UpdateAsync(Person person, int personId);
        Task<bool> DeleteAsync(int id);
        Task<bool> IsExistsAsync(int id);
        Task<bool> IsExistsAsync(string nationalNo);
    }
}
