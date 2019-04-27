using ConsoleApp.Entities.Interface;

namespace ConsoleApp.Entities
{
    public class PlateauInfo : IPlateauInfo
    {
        public int max_x { get; set; }
        public int max_y { get; set; }
        public int min_x { get { return 0; } }
        public int min_y { get { return 0; } }
    }
}
