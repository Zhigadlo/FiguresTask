namespace FiguresTests
{
    public class TriangleTests
    {
        [Theory]
        [InlineData(new double[] { 3, 2 })]
        [InlineData(new double[] { 3 })]
        [InlineData(new double[] { })]
        [InlineData(new double[] { 1, 2, 3, 4, 5, 5 })]
        public void WrongQuantityOfEdgesExceptionTests(double[] edges)
        {
            Type exceptionType = typeof(WrongQuantityOfEdgesException);
            Assert.Throws(exceptionType, () => new Triangle(edges));
        }

        [Theory]
        [InlineData(new double[] { -3, 2.009, 1 })]
        [InlineData(new double[] { -3.3, -2, 0 })]
        [InlineData(new double[] { 0, 0, 0 })]
        [InlineData(new double[] { -1.1, -2.2, -3.1 })]
        public void EdgeLengthExceptionTests(double[] edges)
        {
            Type exceptionType = typeof(EdgeLengthException);
            Assert.Throws(exceptionType, () => new Triangle(edges));
            Assert.Throws(exceptionType, () => new Triangle(edges[0], edges[1], edges[2]));
        }

        [Theory]
        [InlineData(new double[] { 2, 1, 3 }, false)]
        [InlineData(new double[] { 2, 2, 3 }, true)]
        [InlineData(new double[] { 0.01, 3, 3 }, true)]
        [InlineData(new double[] { 0.9, 2.4, 4 }, false)]
        [InlineData(new double[] { 9, 3.6, 5.4 }, false)]
        public void IsExistTests(double[] edges, bool result)
        {
            Assert.Equal(result, Triangle.IsExist(edges));
            Assert.Equal(result, Triangle.IsExist(edges[0], edges[1], edges[2]));
        }

        [Theory]
        [InlineData(new double[] { 2, 2, 3 })]
        [InlineData(new double[] { 0.01, 3, 3 })]
        [InlineData(new double[] { 1, 1, 0.5 })]
        [InlineData(new double[] { 3, 4, 5 })]
        public void GetAreaTests(double[] edges)
        {
            double perimeter = edges.Sum();
            double expected = Math.Sqrt(perimeter * (perimeter - edges[0]) * (perimeter - edges[1]) * (perimeter - edges[2]));

            IFigure triangle = new Triangle(edges);
            double actual = triangle.GetArea();

            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(new double[] { 3, 4, 5 }, true)]
        [InlineData(new double[] { 3, 3, 5 }, false)]
        [InlineData(new double[] { 12, 13, 5 }, true)]
        [InlineData(new double[] { 3, 5, 5 }, false)]
        public void IsRectangularTests(double[] edges, bool expected)
        {
            Triangle triangle = new Triangle(edges);
            bool actual = triangle.IsRectangular();

            Assert.Equal(expected, actual);
        }
    }
}
