using AdventOfCode2022.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day07Tests
    {
        [Fact]
        public void Day07Part1Test()
        {
            var day = new Day07();
            var input = ReadInput();

            var result = day.Day07Part01(input);
            
            result.Should().Be(1648397);
        }
        
        [Fact]
        public void Day07Part2Test()
        {
            var day = new Day07();
            var input = ReadInput();

            var result = day.Day07Part02(input);
            
            result.Should().Be(1815525);
        }

        private static List<string> ReadInput()
        {
            return File.ReadAllLines(Environment.CurrentDirectory + "/Input/Day07Input.txt").ToList();
        }
    }
}