using FiguresLib.Interfaces;
using FiguresLib.Exceptions;

namespace FiguresLib.Figures
{
    public class Circle : IFigure
    {
        public double Radius { get; private set; }

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new RadiusLengthException("Radius must be more than 0");

            Radius = radius;
        }
        public double GetArea() => Math.PI * Math.Pow(Radius, 2);
    }
}
