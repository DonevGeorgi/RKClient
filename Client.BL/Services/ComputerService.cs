using Client.BL.Interfaces;
using Client.DL.Interfaces;
using Client.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.BL.Services
{
    public class ComputerService : IComputerService
    {
        private readonly IComputerRepository _computerRepository;

        public ComputerService(IComputerRepository computerRepository)
        {
            _computerRepository = computerRepository;
        }

        public async Task<Computer> Create(Computer computer)
        {
            return await _computerRepository.Create(computer);
        }

        public async Task<Computer> Update(Computer computer)
        {
            return await _computerRepository.Update(computer);
        }

        public async Task Delete(int ComputerId)
        {
            await _computerRepository.Delete(ComputerId);
        }

        public async Task<IEnumerable<Computer>> GetAll()
        {
            return await _computerRepository.GetAll();
        }

    }
}
