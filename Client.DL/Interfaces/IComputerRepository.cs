using Client.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.DL.Interfaces
{
    public interface IComputerRepository
    {
        Task<Computer> Create(Computer computer);
        Task<Computer> Update(Computer computer);
        Task<Computer> GetById(int ComputerId);
        Task Delete(int ComputerId);
        Task<IEnumerable<Computer>> GetAll();
    }
}
