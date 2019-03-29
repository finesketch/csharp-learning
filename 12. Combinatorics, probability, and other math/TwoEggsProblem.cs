using System;
namespace csharp_learning.Combinatoricsprobabilityandothermath
{
    public class TwoEggsProblem
    {

        /*

        Solution
               
        We'll use the first egg to get a range of possible floors that contain the highest floor an egg can be dropped from without breaking. To do this, we'll drop it from increasingly higher floors until it breaks, skipping some number of floors each time.

        When the first egg breaks, we'll use the second egg to find the exact highest floor an egg can be dropped from. We only have to drop the second egg starting from the last floor where the first egg didn't break, up to the floor where the first egg did break. But we have to drop the second egg one floor at a time.

        With the first egg, if we skip the same number of floors every time, the worst case number of drops will increase by one every time the first egg doesn't break. To counter this and keep our worst case drops constant, we decrease the number of floors we skip by one each time we drop the first egg.

        When we're choosing how many floors to skip the first time we drop the first egg, we know:

        We want to skip as few floors as possible, so if the first egg breaks right away we don't have a lot of floors to drop our second egg from.
        We always want to be able to reduce the number of floors we're skipping. We don't want to get towards the top and not be able to skip floors any more.
        Knowing this, we set up the following equation where 
        n
        n is the number of floors we skip the first time:

        n
        +
        (
        n
        −
        1
        )
        +
        (
        n
        −
        2
        )
        +
        …
        +
        1
        =
        1
        0
        0
        n+(n−1)+(n−2)+…+1=100
        This triangular series ↴ reduces to 
        n
        ∗
        (
        n
        +
        1
        )
        /
        2
        =
        1
        0
        0
        n∗(n+1)/2=100 which solves to give 
        n
        =
        1
        3
        .
        6
        5
        1
        n=13.651. We round up to 14 to be safe. So our first drop will be from the 14th floor, our second will be 13 floors higher on the 27th floor and so on until the first egg breaks. Once it breaks, we'll use the second egg to try every floor starting with the last floor where the first egg didn't break. At worst, we'll drop both eggs a combined total of 14 times.

        For example:

          Highest floor an egg won't break from
        13

        Floors we drop first egg from
        14

        Floors we drop second egg from
        1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13

        Total number of drops
        14
          Highest floor an egg won't break from
        98

        Floors we drop first egg from
        14, 27, 39, 50, 60, 69, 77, 84, 90, 95, 99

        Floors we drop second egg from
        96, 97, 98

        Total number of drops
        14


        What We Learned
               
        This is one of our most contentious questions. Some people say, "Ugh, this is useless as an interview question," while others say, "We ask this at my company, it works great."

        The bottom line is some companies do ask questions like this, so it's worth being prepared. There are a bunch of these not-exactly-programming interview questions that lean on math and logic. There are some famous ones about shuffling cards and rolling dice. If math isn't your strong suit, don't fret. It only takes a few practice problems to get the hang of these.


        */

    }
}
