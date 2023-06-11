using FiguresLib.Interfaces;
using FiguresLib.Exceptions;

namespace FiguresLib.Figures
{
    public class Triangle : IFigure
    {
        readonly double[] Edges  = new double[3];
        
        public Triangle(double[] edges)
        {
            if (edges.Length != 3)
                throw new WrongQuantityOfEdgesException("Wrong quantity of edges. Must be 3");

            for(int i = 0; i < edges.Length; i++)
            {
                if (edges[i] <= 0)
                    EdgeMustBePositiveException();
            }

            Edges = edges;
        }
        public Triangle(double edge1, double edge2, double edge3)
        {
            if (edge1 <= 0 || edge2 <= 0 || edge3 <= 0)
                EdgeMustBePositiveException();

            Edges[0] = edge1;
            Edges[1] = edge2;
            Edges[2] = edge3;
        }

        public double GetArea()
        {
            double p = GetPerimeter();
            return Math.Sqrt(p * (p - Edges[0]) * (p - Edges[1]) * (p - Edges[2]));
        }
        /// <summary>
        /// returns perimeter of the figure
        /// </summary>
        /// <returns></returns>
        private double GetPerimeter() => Edges.Sum();
        /// <summary>
        /// checks triangle for existanse
        /// </summary>
        /// <param name="edge1"></param>
        /// <param name="edge2"></param>
        /// <param name="edge3"></param>
        /// <returns></returns>
        
        public static bool IsExist(double edge1, double edge2, double edge3)
        {
            double[] edges = new double[] { edge1, edge2, edge3 };
            return IsExist(edges);
        }
        /// <summary>
        /// checks triangle for existanse
        /// </summary>
        /// <param name="edge1"></param>
        /// <param name="edge2"></param>
        /// <param name="edge3"></param>
        /// <returns></returns>
        public static bool IsExist(double[] edges)
        {
            double maxEdge = edges.Max();
            int maxIndex = Array.FindIndex(edges, e => e == maxEdge);
            double sum = 0;
            for (int i = 0; i < edges.Length; i++)
            {
                if (i != maxIndex)
                    sum += edges[i];
            }

            if (sum > maxEdge)
                return true;

            return false;
        }
        /// <summary>
        /// checks triangle for rectangularity by the Pythagorean formula
        /// </summary>
        /// <returns></returns>
        public bool IsRectangular()
        {
            double maxEdge = Edges.Max();
            int maxIndex = Array.FindIndex(Edges, e => e == maxEdge);
            double squareOfMaxEdge = Math.Pow(maxEdge, 2);
            double squareSum = 0;
            for(int i = 0; i < Edges.Length; i++)
            {
                if (i != maxIndex)
                    squareSum += Math.Pow(Edges[i], 2);
            }

            if (squareSum == squareOfMaxEdge)
                return true;

            return false;
        }

        /// <summary>
        /// throws exception in cases when edge is negative
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        private void EdgeMustBePositiveException() => throw new EdgeLengthException("Edge must not be negative");
    }
}
