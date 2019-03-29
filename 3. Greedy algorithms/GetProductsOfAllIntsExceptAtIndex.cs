using System;
using Xunit;

namespace csharp_learning.Greedyalgorithms
{
    public partial class Solution
    {

        public static int[] GetProductsOfAllIntsExceptAtIndex(int[] intArray)
        {
            if (intArray.Length < 2)
            {
                throw new ArgumentException(
                    "Getting the product of numbers at other indices requires at least 2 numbers",
                    nameof(intArray));
            }

            // We make an array with the length of the input array to
            // hold our products
            int[] productsOfAllIntsExceptAtIndex = new int[intArray.Length];

            // For each integer, we find the product of all the integers
            // before it, storing the total product so far each time
            int productSoFar = 1;
            for (int i = 0; i < intArray.Length; i++)
            {
                productsOfAllIntsExceptAtIndex[i] = productSoFar;
                productSoFar *= intArray[i];
            }

            // For each integer, we find the product of all the integers
            // after it. since each index in products already has the
            // product of all the integers before it, now we're storing
            // the total product of all other integers
            productSoFar = 1;
            for (int i = intArray.Length - 1; i >= 0; i--)
            {
                productsOfAllIntsExceptAtIndex[i] *= productSoFar;
                productSoFar *= intArray[i];
            }

            return productsOfAllIntsExceptAtIndex;
        }

        public static int[] GetProductsOfAllIntsExceptAtIndex2(int[] intArray)
        {
            if (intArray.Length < 2)
            {
                throw new ArgumentException(
                    "Getting the product of numbers at other indices requires at least 2 numbers",
                    nameof(intArray));
            }

            int[] productsOfAllIntsExceptAtIndex = new int[intArray.Length];
            int total = 1;
            bool hasZero = false;
            bool has2Zero = false;

            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] > 0)
                {
                    total *= intArray[i];
                }
                else if (intArray[i] == 0 && !hasZero)
                {
                    hasZero = true;
                }
                else if (intArray[i] == 0 && hasZero)
                {
                    has2Zero = true;
                }
            }

            for (int i = 0; i < intArray.Length; i++)
            {
                if (has2Zero)
                {
                    productsOfAllIntsExceptAtIndex[i] = 0;
                }
                else if (intArray[i] == 0)
                {
                    productsOfAllIntsExceptAtIndex[i] = total;
                }
                else if (intArray[i] > 0 && hasZero)
                {
                    productsOfAllIntsExceptAtIndex[i] = 0;
                }
                else if (intArray[i] > 0 && !hasZero)
                {
                    productsOfAllIntsExceptAtIndex[i] = total / intArray[i];
                }
            }

            return productsOfAllIntsExceptAtIndex;
        }




        // Tests

        [Fact]
        public void GetProductsOfAllIntsExceptAtIndex_SmallArrayInputTest()
        {
            var expected = new int[] { 6, 3, 2 };
            var actual = GetProductsOfAllIntsExceptAtIndex(new int[] { 1, 2, 3 });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetProductsOfAllIntsExceptAtIndex_LongArrayInputTest()
        {
            var expected = new int[] { 120, 480, 240, 320, 960, 192 };
            var actual = GetProductsOfAllIntsExceptAtIndex(new int[] { 8, 2, 4, 3, 1, 5 });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetProductsOfAllIntsExceptAtIndex_InputHasOneZeroTest()
        {
            var expected = new int[] { 0, 0, 36, 0 };
            var actual = GetProductsOfAllIntsExceptAtIndex(new int[] { 6, 2, 0, 3 });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetProductsOfAllIntsExceptAtIndex_InputHasTwoZerosTest()
        {
            var expected = new int[] { 0, 0, 0, 0, 0 };
            var actual = GetProductsOfAllIntsExceptAtIndex(new int[] { 4, 0, 9, 1, 0 });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetProductsOfAllIntsExceptAtIndex_InputHasOneNegativeNumberTest()
        {
            var expected = new int[] { 32, -12, -24 };
            var actual = GetProductsOfAllIntsExceptAtIndex(new int[] { -3, 8, 4 });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetProductsOfAllIntsExceptAtIndex_AllNegativesInputTest()
        {
            var expected = new int[] { -8, -56, -14, -28 };
            var actual = GetProductsOfAllIntsExceptAtIndex(new int[] { -7, -1, -4, -2 });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetProductsOfAllIntsExceptAtIndex_ExceptionWithEmptyInputTest()
        {
            Assert.Throws<ArgumentException>(() => GetProductsOfAllIntsExceptAtIndex(new int[] { }));
        }

        [Fact]
        public void GetProductsOfAllIntsExceptAtIndex_ExceptionWithOneNumberInputTest()
        {
            Assert.Throws<ArgumentException>(() => GetProductsOfAllIntsExceptAtIndex(new int[] { 1 }));
        }

        [Fact]
        public void GetProductsOfAllIntsExceptAtIndex2_SmallArrayInputTest()
        {
            var expected = new int[] { 6, 3, 2 };
            var actual = GetProductsOfAllIntsExceptAtIndex2(new int[] { 1, 2, 3 });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetProductsOfAllIntsExceptAtIndex2_LongArrayInputTest()
        {
            var expected = new int[] { 120, 480, 240, 320, 960, 192 };
            var actual = GetProductsOfAllIntsExceptAtIndex2(new int[] { 8, 2, 4, 3, 1, 5 });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetProductsOfAllIntsExceptAtIndex2_InputHasOneZeroTest()
        {
            var expected = new int[] { 0, 0, 36, 0 };
            var actual = GetProductsOfAllIntsExceptAtIndex2(new int[] { 6, 2, 0, 3 });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetProductsOfAllIntsExceptAtIndex2_InputHasTwoZerosTest()
        {
            var expected = new int[] { 0, 0, 0, 0, 0 };
            var actual = GetProductsOfAllIntsExceptAtIndex2(new int[] { 4, 0, 9, 1, 0 });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetProductsOfAllIntsExceptAtIndex2_InputHasOneNegativeNumberTest()
        {
            var expected = new int[] { 32, -12, -24 };
            var actual = GetProductsOfAllIntsExceptAtIndex2(new int[] { -3, 8, 4 });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetProductsOfAllIntsExceptAtIndex2_AllNegativesInputTest()
        {
            var expected = new int[] { -8, -56, -14, -28 };
            var actual = GetProductsOfAllIntsExceptAtIndex2(new int[] { -7, -1, -4, -2 });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetProductsOfAllIntsExceptAtIndex2_ExceptionWithEmptyInputTest()
        {
            Assert.Throws<ArgumentException>(() => GetProductsOfAllIntsExceptAtIndex2(new int[] { }));
        }

        [Fact]
        public void GetProductsOfAllIntsExceptAtIndex2_ExceptionWithOneNumberInputTest()
        {
            Assert.Throws<ArgumentException>(() => GetProductsOfAllIntsExceptAtIndex2(new int[] { 1 }));
        }
    }
}
