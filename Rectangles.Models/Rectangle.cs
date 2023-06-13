using System.ComponentModel.DataAnnotations.Schema;

namespace Rectangles.Models
{
    public class Rectangle : Entity
    {
        public Rectangle()
        {
            
        }

        public Rectangle(int numberRectangle, string nameRectangle, 
                         int botLeftId, Point botLeftPoint, 
                         int topRightId, Point topRightPoint, 
                         int colorBodyRectangleId, ColorBody colorBodyRectangle, 
                         int colorLineRectangleId, ColorLine colorLineRectangle)
        {
            NumberRectangle = numberRectangle;
            NameRectangle = nameRectangle;
            BotLeftId = botLeftId;
            BotLeftPoint = botLeftPoint;
            TopRightId = topRightId;
            TopRightPoint = topRightPoint;
            ColorBodyRectangleId = colorBodyRectangleId;
            ColorBodyRectangle = colorBodyRectangle;
            ColorLineRectangleId = colorLineRectangleId;
            ColorLineRectangle = colorLineRectangle;
        }

        public int NumberRectangle { get; set; }

        public string NameRectangle { get; set; }

        
        public int BotLeftId { get; set; }
        [ForeignKey("BotLeftId")]
        public virtual Point BotLeftPoint { get; set; }

        public int TopRightId { get; set; }
        [ForeignKey("TopRightId")]
        public virtual Point TopRightPoint { get; set; }

        public int ColorBodyRectangleId { get; set; }
        [ForeignKey("ColorBodyRectangleId")]
        public virtual ColorBody ColorBodyRectangle { get; set; }

        public int ColorLineRectangleId { get; set; }
        [ForeignKey("ColorLineRectangleId")]
        public virtual ColorLine ColorLineRectangle { get; set; }

    }
}
