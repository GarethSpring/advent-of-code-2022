using AdventOfCode2022.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day08Tests
    {
        [Fact]
        public void Day08Part1Test()
        {
            var day = new Day08();
            var forest = ReadInput();

            var result = day.Day08Part01(forest);
   
            result.Should().Be(1672);
        }
        
        [Fact]
        public void Day08Part2Test()
        {
            var day = new Day08();
            var forest = ReadInput();

            var result = day.Day08Part02(forest);
      
            result.Should().Be(327180);
        }
        
        private static Forest ReadInput()
        {
            var input = File.ReadAllLines(Environment.CurrentDirectory + "/Input/Day08Input.txt").ToList();

            var f = new Forest
            {
                Trees = new Dictionary<(int, int), Tree>()
            };

            for (int y = 0; y < input.Count; y++)
            {
                string line = input[y];
                for (int x = 0; x < input.First().Length; x++)
                {
                    f.Trees[(x, y)] = new Tree()
                    {
                        Height = Convert.ToInt32(line.Substring(x,1)),
                        Visible = false
                    };
                }
            }

            return f;
        }
    }
}