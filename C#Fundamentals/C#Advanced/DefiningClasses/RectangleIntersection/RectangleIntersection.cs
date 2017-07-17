namespace RectangleIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RectangleIntersection
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var numberOfRectangles = inputLine[0];
            var intersectionsCount = inputLine[1];

            var rectangles = new Dictionary<string, Rectangle>();

            for (int i = 0; i < numberOfRectangles; i++)
            {
                var rectangleDetails = Console.ReadLine().Split();
                var id = rectangleDetails[0];
                var width = double.Parse(rectangleDetails[1]);
                var height = double.Parse(rectangleDetails[2]);
                var point1 = double.Parse(rectangleDetails[3]);
                var point2 = double.Parse(rectangleDetails[4]);

                rectangles.Add(rectangleDetails[0], new Rectangle(id, width, height, point1, point2));
            }

            for (int i = 0; i < intersectionsCount; i++)
            {
                var neededRectangles = Console.ReadLine().Split();
                var firstRectangle = rectangles[neededRectangles[0]];
                var secondRectangle = rectangles[neededRectangles[1]];

                var isIntersected = secondRectangle.IsIntersected(firstRectangle);

                if (isIntersected)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}