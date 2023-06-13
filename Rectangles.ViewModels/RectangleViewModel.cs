using Rectangles.Models;

namespace Rectangles.ViewModels
{
    public class RectangleViewModel
    {
        public int Id { get; set; }

        public int NumberRectangle { get; set; }

        public string NameRectangle { get; set; }

        public double BotLeftPointX { get; set; }
        public double BotLeftPointY { get; set; }

        public double TopRightPointX { get; set; }
        public double TopRightPointY { get; set; }

        public string ColorBodyRectangle { get; set; }

        public string ColorLineRectangle { get; set; }
      
    }
}
