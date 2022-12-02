using AdventOfCode2022.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day02Tests
    {
        [Fact]
        public void Day02Part1()
        {
            var day = new Day02();
            var input = ReadInput();
            
            var result = day.Play(input, false);
            
            result.Should().Be(12645);
        }
        
        [Fact]
        public void Day02Part2()
        {
            var day = new Day02();
            var input = ReadInput();
            
            var result = day.Play(input, true);
            
            result.Should().Be(11756);
        }

        private static List<(string, string)> ReadInput()
        {
            var input = File.ReadAllLines(Environment.CurrentDirectory + "/Input/Day02Input.txt");

            var result = input.Select(s => (s.Substring(0, 1), s.Substring(2, 1))).ToList();

            return result;
        }
    }
}