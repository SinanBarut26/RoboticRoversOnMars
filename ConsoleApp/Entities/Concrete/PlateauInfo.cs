using ConsoleApp.Entities.Interface;

namespace ConsoleApp.Entities.Concrete
{
    public class PlateauInfo : IPlateauInfo
    {
        public int max_x { get; set; }
        public int max_y { get; set; }
        public int min_x { get; set; }
        public int min_y { get; set; }
    }
}
