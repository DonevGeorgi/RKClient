using Client.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.BL.Interfaces
{
    public interface IComputerService
    {
        Task<Computer> Create(Computer computer);
        Task<Computer> Update(Computer computer);
        Task Delete(int ComputerId);
        Task<IEnumerable<Computer>> GetAll();
    }
}
