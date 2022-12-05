using System.Text.RegularExpressions;
using AdventOfCode2022.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day04Tests
    {
        [Fact]
        public void Day04Part1Test()
        {
            var day = new Day04();
            var input = ReadInput();
            
            var result = day.Day04Part01(input);
            
            result.Should().Be(513);
        }
        
        [Fact]
        public void Day04Part2Test()
        {
            var day = new Day04();
            var input = ReadInput();
            
            var result = day.Day04Part02(input);
            
            result.Should().Be(878);
        }

        private static List<ElfPair> ReadInput()
        {
            var result = new List<ElfPair>();
            
            var input = File.ReadAllLines(Environment.CurrentDirectory + "/Input/Day04Input.txt");

            foreach (string line in input)
            {
                var regex = new Regex(@"(\d{1,2})-(\d{1,2}),(\d{1,2})-(\d{1,2})");
                
                Match? matches = regex.Match(line);

                var ep = new ElfPair
                {
                    R1 = Convert.ToInt32(matches.Groups[1].Value)..Convert.ToInt32(matches.Groups[2].Value),
                    R2 = Convert.ToInt32(matches.Groups[3].Value)..Convert.ToInt32(matches.Groups[4].Value),
                };
                
                result.Add(ep);
            }

            return result;
        }
    }
}