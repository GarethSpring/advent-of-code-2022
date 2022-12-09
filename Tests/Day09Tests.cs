using AdventOfCode2022.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day09Tests
    {
        [Fact]
        public void Day04Part1Test()
        {
            var day = new Day09();
            var input = ReadInput();
            
            var result = day.Day09Part01(input);
            
            result.Should().Be(6266);
        }
        
        [Fact]
        public void Day04Part2Test()
        {
            var day = new Day09();
            var input = ReadInput();
            
            var result = day.Day09Part02(input);
            
            result.Should().Be(2369);
        }

        private static List<RopeMove> ReadInput()
        {
            var input = File.ReadAllLines(Environment.CurrentDirectory + "/Input/Day09Input.txt");

            var moves = new List<RopeMove>();

            foreach (string line in input)
            {
                RopeMove rm = new RopeMove()
                {
                    Direction = Convert.ToChar(line.Substring(0, 1)),
                    Magnitude = Convert.ToInt32(line.Substring(2))
                };
                
                moves.Add(rm);
            }

            return moves;
        }
    }
}