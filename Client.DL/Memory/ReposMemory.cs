using Client.Models.Models;
using System.Collections.Generic;

namespace Client.DL.Memory
{
    public class ReposMemory
    {
        public static List<Computer> Computers { get; set; } = new List<Computer>();
        public static void Init()
        {
            //Computer
            Computers.Add(new Computer
            {
                ComputerId = 723456,
                ComputerBrand = "ALIENWARE",
                ComputerModel = "Aurora R10"
            });
        }
    }
}
