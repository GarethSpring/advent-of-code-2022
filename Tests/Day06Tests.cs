using AdventOfCode2022.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day06Tests
    {
        [Fact]
        public void Day06Part1Test()
        {
            var day = new Day06();
            var input = ReadInput();

            var result = day.Day06Logic(input, 4);
            
            result.Should().Be(1198);
        }
        
        [Fact]
        public void Day06Part2Test()
        {
            var day = new Day06();
            var input = ReadInput();

            var result = day.Day06Logic(input, 14);
            
            result.Should().Be(3120);
        }

        private static string ReadInput()
        {
            var input = File.ReadAllLines(Environment.CurrentDirectory + "/Input/Day06Input.txt");

            return input.First();
        }
    }
}