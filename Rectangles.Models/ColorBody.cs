namespace Rectangles.Models
{
    public class ColorBody : Entity
    {
        public ColorBody() { }

        public ColorBody(string colorBodyValue)
        {
            ColorBodyValue = colorBodyValue;
        }

        public string ColorBodyValue { get; set; }
    }
}
