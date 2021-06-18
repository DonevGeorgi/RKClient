using Client.Models.Models;
using System.Collections.Concurrent;

namespace Client.DL.Memory
{
    public static class InMemoryDb
    {
        public static ConcurrentQueue<Computer> Computers { get; set; } = new ConcurrentQueue<Computer>();

    }
}
