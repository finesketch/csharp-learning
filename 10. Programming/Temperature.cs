using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace csharp_learning.Programming
{
    public partial class Solution
    {
        public class TempTracker
        {
            // For mode
            private int[] _occurrences = new int[111];  // Array of 0s at indices 0..110
            private int _maxOccurrences;
            private int? _mode;

            // For mean
            private int _numberOfReadings;
            private int _totalSum;
            private double? _mean;  // Mean should be double

            // For min and max
            private int? _minTemp;
            private int? _maxTemp;

            public void Insert(int temperature)
            {
                // For mode
                _occurrences[temperature]++;
                if (_occurrences[temperature] > _maxOccurrences)
                {
                    _mode = temperature;
                    _maxOccurrences = _occurrences[temperature];
                }

                // For mean
                _numberOfReadings++;
                _totalSum += temperature;
                _mean = (double)_totalSum / _numberOfReadings;

                // For min and max
                if (_maxTemp == null || temperature > _maxTemp)
                {
                    _maxTemp = temperature;
                }

                if (_minTemp == null || temperature < _minTemp)
                {
                    _minTemp = temperature;
                }
            }

            public int? GetMax()
            {
                return _maxTemp;
            }

            public int? GetMin()
            {
                return _minTemp;
            }

            public double? GetMean()
            {
                return _mean;
            }

            public int? GetMode()
            {
                return _mode;
            }
        }



        // Tests

        [Fact]
        public void TemperatureTrackerTest()
        {
            var precision = 6;

            var t = new TempTracker();

            t.Insert(50);
            Assert.Equal(50, t.GetMax().Value);
            Assert.Equal(50, t.GetMin().Value);
            Assert.Equal(50.0, t.GetMean().Value, precision);
            Assert.Equal(50, t.GetMode().Value);

            t.Insert(80);
            Assert.Equal(80, t.GetMax().Value);
            Assert.Equal(50, t.GetMin().Value);
            Assert.Equal(65.0, t.GetMean().Value, precision);
            Assert.True(t.GetMode().Value == 50 || t.GetMode().Value == 80);

            t.Insert(80);
            Assert.Equal(80, t.GetMax().Value);
            Assert.Equal(50, t.GetMin().Value);
            Assert.Equal(70.0, t.GetMean().Value, precision);
            Assert.Equal(80, t.GetMode().Value);

            t.Insert(30);
            Assert.Equal(80, t.GetMax().Value);
            Assert.Equal(30, t.GetMin().Value);
            Assert.Equal(60.0, t.GetMean().Value, precision);
            Assert.Equal(80, t.GetMode().Value);
        }
    }
}
