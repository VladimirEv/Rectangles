namespace Rectangles.Models
{
    public class ColorLine : Entity
    {
        public ColorLine() { }

        public ColorLine(string colorLineValue)
        {
            ColorLineValue = colorLineValue;
        }

        public string ColorLineValue { get; set; }
    }
}
