using MessagePack;

namespace Client.Models.Models
{ 
    [MessagePackObject]
    public class Computer
    {
        [Key(0)]
        public int ComputerId { set; get; }
        [Key(1)]
        public string ComputerBrand { set; get; }
        [Key(2)]
        public string ComputerModel { set; get; }
     
    }
}
