namespace FiguresTests
{
    public class CircleTests
    {
        [Theory]
        [InlineData(-3.3, typeof(RadiusLengthException))]
        [InlineData(-999, typeof(RadiusLengthException))]
        [InlineData(0, typeof(RadiusLengthException))]
        public void ExceptionsTest(double radius, Type exceptionType)
        {
            Assert.Throws(exceptionType, () => new Circle(radius));
        }
        [Theory]
        [InlineData(3)]
        [InlineData(1.1)]
        [InlineData(25.55)]
        public void GetAreaTests(double radius)
        {
            double expectedArea = Math.Pow(radius, 2) * Math.PI;

            IFigure circle = new Circle(radius);
            double actualArea = circle.GetArea();

            Assert.Equal(expectedArea, actualArea);
        }
    }
}