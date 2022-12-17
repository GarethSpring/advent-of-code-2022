using AdventOfCode2022.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day11Tests
    {
    
            [Fact]
            public void Day11Part1Test()
            {
                var day = new Day11();
                
                var result = day.Part1(InitMonkeys());
                
                result.Should().Be(66802);
            }
            
            [Fact]
            public void Day11Part2Test()
            {
                var day = new Day11();
                
                var result = day.Part2(InitMonkeys());

                result.Should().Be(21800916620);
            }
            
            private List<Monkey> InitMonkeys()
            {
                var monkeys = new List<Monkey>
                {
                    new Monkey
                    {
                        Id = 0, StartingItems = new List<long> {71, 56, 50, 73},
                        DivisibleBy = 13, TrueThrowIndex = 1,  FalseThrowIndex = 7
                    },
                    new Monkey
                    {
                        Id = 1, StartingItems = new List<long> {70, 89, 82},
                        DivisibleBy = 7, TrueThrowIndex = 3,  FalseThrowIndex = 6
                    },
                    new Monkey
                    {
                        Id = 2, StartingItems = new List<long> {52, 95},
                        DivisibleBy = 3, TrueThrowIndex = 5,  FalseThrowIndex = 4
                    },
                    new Monkey
                    {
                        Id = 3, StartingItems = new List<long> {94, 64, 69, 87, 70},
                        DivisibleBy = 19, TrueThrowIndex = 2,  FalseThrowIndex = 6
                    },
                    new Monkey
                    {
                        Id = 4, StartingItems = new List<long> {98, 72, 98, 53, 97, 51},
                        DivisibleBy = 5, TrueThrowIndex = 0,  FalseThrowIndex = 5
                    },
                    new Monkey
                    {
                        Id = 5, StartingItems = new List<long> {79},
                        DivisibleBy = 2, TrueThrowIndex = 7,  FalseThrowIndex = 0
                    },
                    new Monkey
                    {
                        Id = 6, StartingItems = new List<long> {77, 55, 63, 93, 66, 90, 88, 71},
                        DivisibleBy = 11, TrueThrowIndex = 2,  FalseThrowIndex = 4
                    },
                    new Monkey
                    {
                        Id = 7, StartingItems = new List<long> {54, 97, 87, 70, 59, 82, 59},
                        DivisibleBy = 17, TrueThrowIndex = 1,  FalseThrowIndex = 3
                    }
                };

                return monkeys;
            }
    }
}