using System;
using Xunit;

namespace csharp_learning.Programming
{
    public partial class Solution
    {
        public class RangeOverlap
        {
            public readonly int StartPoint;
            public readonly int Length;

            public RangeOverlap(int highestStartPoint, int overlapLength)
            {
                StartPoint = highestStartPoint;
                Length = overlapLength;
            }
        }

        public static RangeOverlap FindRangeOverlap(int point1, int length1, int point2, int length2)
        {
            // Find the highest start point and lowest end point.
            // The highest ("rightmost" or "upmost") start point is
            // the start point of the overlap.
            // The lowest end point is the end point of the overlap.
            int highestStartPoint = Math.Max(point1, point2);
            int lowestEndPoint = Math.Min(point1 + length1, point2 + length2);

            // Return empty overlap if there is no overlap
            if (highestStartPoint >= lowestEndPoint)
            {
                return new RangeOverlap(0, 0);
            }

            // Compute the overlap length
            int overlapLength = lowestEndPoint - highestStartPoint;

            return new RangeOverlap(highestStartPoint, overlapLength);
        }

        public class Rectangle
        {
            // Coordinates of bottom left corner
            public int LeftX { get; set; }
            public int BottomY { get; set; }

            // Dimensions
            public int Width { get; set; }
            public int Height { get; set; }

            public Rectangle() { }

            public Rectangle(int leftX, int bottomY, int width, int height)
            {
                LeftX = leftX;
                BottomY = bottomY;
                Width = width;
                Height = height;
            }

            public override string ToString()
            {
                return $"(left: {LeftX}, bottom: {BottomY},"
                       + $" width: {Width}, height: {Height})";
            }

            public override bool Equals(Object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                if (ReferenceEquals(obj, this))
                {
                    return true;
                }

                var r = (Rectangle)obj;
                return LeftX == r.LeftX && BottomY == r.BottomY
                       && Width == r.Width && Height == r.Height;
            }

            public override int GetHashCode()
            {
                var result = 17;
                result = result * 31 + LeftX;
                result = result * 31 + BottomY;
                result = result * 31 + Width;
                result = result * 31 + Height;
                return result;
            }
        }

        public static Rectangle FindRectangularOverlap(Rectangle rect1, Rectangle rect2)
        {
            // Get the x and y overlap points and lengths
            RangeOverlap xOverlap = FindRangeOverlap(rect1.LeftX, rect1.Width, rect2.LeftX, rect2.Width);
            RangeOverlap yOverlap = FindRangeOverlap(rect1.BottomY, rect1.Height, rect2.BottomY, rect2.Height);

            // Return null rectangle if there is no overlap
            if (xOverlap.Length == 0 || yOverlap.Length == 0)
            {
                return new Rectangle();
            }

            return new Rectangle(
                xOverlap.StartPoint,
                yOverlap.StartPoint,
                xOverlap.Length,
                yOverlap.Length
            );
        }

        // Tests

        [Fact]
        public void OverlapAlongBothAxesTest()
        {
            var actual = FindRectangularOverlap(new Rectangle(1, 1, 6, 3), new Rectangle(5, 2, 3, 6));
            var expected = new Rectangle(5, 2, 2, 2);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OneRectangleInsideAnotherTest()
        {
            var actual = FindRectangularOverlap(new Rectangle(1, 1, 6, 6), new Rectangle(3, 3, 2, 2));
            var expected = new Rectangle(3, 3, 2, 2);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BothRectanglesTheSameTest()
        {
            var actual = FindRectangularOverlap(new Rectangle(2, 2, 4, 4), new Rectangle(2, 2, 4, 4));
            var expected = new Rectangle(2, 2, 4, 4);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TouchOnHorizontalEdgeTest()
        {
            var actual = FindRectangularOverlap(new Rectangle(1, 2, 3, 4), new Rectangle(2, 6, 2, 2));
            var expected = new Rectangle();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TouchOnVerticalEdgeTest()
        {
            var actual = FindRectangularOverlap(new Rectangle(1, 2, 3, 4), new Rectangle(4, 3, 2, 2));
            var expected = new Rectangle();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TouchAtCornerTest()
        {
            var actual = FindRectangularOverlap(new Rectangle(1, 1, 2, 2), new Rectangle(3, 3, 2, 2));
            var expected = new Rectangle();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NoOverlapTest()
        {
            var actual = FindRectangularOverlap(new Rectangle(1, 1, 2, 2), new Rectangle(4, 6, 3, 6));
            var expected = new Rectangle();
            Assert.Equal(expected, actual);
        }
    }
}
