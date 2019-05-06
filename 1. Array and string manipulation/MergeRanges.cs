using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace csharp_learning.Arrayandstringmanipulation
{
    public partial class Solution
    {
        public class Meeting
        {
            public int StartTime { get; set; }

            public int EndTime { get; set; }

            public Meeting(int startTime, int endTime)
            {
                // Number of 30 min blocks past 9:00 am
                StartTime = startTime;
                EndTime = endTime;
            }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                if (ReferenceEquals(obj, this))
                {
                    return true;
                }

                var meeting = (Meeting)obj;
                return StartTime == meeting.StartTime && EndTime == meeting.EndTime;
            }

            public override int GetHashCode()
            {
                var result = 17;
                result = result * 31 + StartTime;
                result = result * 31 + EndTime;
                return result;
            }

            public override string ToString()
            {
                return $"({StartTime}, {EndTime})";
            }
        }

        public static List<Meeting> MergeRanges(List<Meeting> meetings)
        {
            // Make a copy so we don't destroy the input, and sort by start time
            var sortedMeetings = meetings.OrderBy(m => m.StartTime).ToList();

            // Initialize mergedMeetings with the earliest meeting
            var mergedMeetings = new List<Meeting> { sortedMeetings[0] };

            foreach (var currentMeeting in sortedMeetings)
            {
                var lastMergedMeeting = mergedMeetings.Last();

                if (currentMeeting.StartTime <= lastMergedMeeting.EndTime)
                {
                    // If the current meeting overlaps with the last merged meeting, use the
                    // later end time of the two
                    lastMergedMeeting.EndTime =
                        Math.Max(lastMergedMeeting.EndTime, currentMeeting.EndTime);
                }
                else
                {
                    // Add the current meeting since it doesn't overlap
                    mergedMeetings.Add(currentMeeting);
                }
            }

            return mergedMeetings;
        }




        // Tests

        [Fact]
        public void MeetingsOverlapTest()
        {
            var meetings = new List<Meeting>()
        {
            new Meeting(1, 3), new Meeting(2, 4)
        };
            var actual = MergeRanges(meetings);
            var expected = new List<Meeting>()
        {
            new Meeting(1, 4)
        };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MeetingsTouchTest()
        {
            var meetings = new List<Meeting>()
        {
            new Meeting(5, 6), new Meeting(6, 8)
        };
            var actual = MergeRanges(meetings);
            var expected = new List<Meeting>()
        {
            new Meeting(5, 8)
        };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MeetingContainsOtherMeetingTest()
        {
            var meetings = new List<Meeting>()
        {
            new Meeting(1, 8), new Meeting(2, 5)
        };
            var actual = MergeRanges(meetings);
            var expected = new List<Meeting>()
        {
            new Meeting(1, 8)
        };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MeetingsStaySeparateTest()
        {
            var meetings = new List<Meeting>()
        {
            new Meeting(1, 3), new Meeting(4, 8)
        };
            var actual = MergeRanges(meetings);
            var expected = new List<Meeting>()
        {
            new Meeting(1, 3), new Meeting(4, 8)
        };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MultipleMergedMeetingsTest()
        {
            var meetings = new List<Meeting>()
        {
            new Meeting(1, 4), new Meeting(2, 5), new Meeting (5, 8)
        };
            var actual = MergeRanges(meetings);
            var expected = new List<Meeting>()
        {
            new Meeting(1, 8)
        };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MeetingsNotSortedTest()
        {
            var meetings = new List<Meeting>()
        {
            new Meeting(5, 8), new Meeting(1, 4), new Meeting(6, 8)
        };
            var actual = MergeRanges(meetings);
            var expected = new List<Meeting>()
        {
            new Meeting(1, 4), new Meeting(5, 8)
        };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OneLongMeetingContainsSmallerMeetingsTest()
        {
            var meetings = new List<Meeting>()
        {
            new Meeting(1, 10), new Meeting(2, 5), new Meeting(6, 8),
            new Meeting(9, 10), new Meeting(10, 12)
        };
            var actual = MergeRanges(meetings);
            var expected = new List<Meeting>()
        {
            new Meeting(1, 12)
        };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SampleInputTest()
        {
            var meetings = new List<Meeting>()
        {
            new Meeting(0, 1), new Meeting(3, 5), new Meeting(4, 8),
            new Meeting(10, 12), new Meeting(9, 10)
        };
            var actual = MergeRanges(meetings);
            var expected = new List<Meeting>()
        {
            new Meeting(0, 1), new Meeting(3, 8), new Meeting(9, 12)
        };
            Assert.Equal(expected, actual);
        }
    }
}
