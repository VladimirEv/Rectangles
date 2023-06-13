namespace Rectangles.Models
{
    public class Point : Entity
    {
        public Point() { }

        public Point(double xValue, double yValue)
        {
            XValue = xValue;
            YValue = yValue;
        }

        public double XValue { get; set; }
        public double YValue { get; set; }       
    }
}
