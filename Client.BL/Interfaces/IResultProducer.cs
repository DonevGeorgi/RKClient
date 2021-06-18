using Client.Models.Models;
using System.Threading.Tasks;

namespace Client.BL.Interfaces
{
    public interface IResultProducer
    {
        Task ProduceResultAsync(Computer computer);
    }
}
