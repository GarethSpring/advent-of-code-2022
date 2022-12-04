using AdventOfCode2022.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day03Tests
    {
        [Fact]
        public void Day03Part1()
        {
            var day = new Day03();
            var input = ReadInput();
            
            var result = day.Day03Part01(input);
            
            result.Should().Be(8105);
        }
        
        [Fact]
        public void Day03Part2()
        {
            var day = new Day03();
            var input = ReadInput();
            
            var result = day.Day03Part02(input);
        
            result.Should().Be(2363);
        }

        private static List<RuckSack> ReadInput()
        {
            var input = File.ReadAllLines(Environment.CurrentDirectory + "/Input/Day03Input.txt");

            var result = new List<RuckSack>();

            foreach (string s in input)
            {
                var rs = new RuckSack
                {
                    CompartmentA = s.Substring(0, s.Length / 2),
                    CompartmentB = s.Substring(s.Length / 2)
                };
                
                result.Add(rs);
            }
            
            return result;
        }
    }
}