using AdventOfCode2022.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day01Tests
    {
        [Fact]
        public void Day01Part1()
        {
            var day = new Day01();
            var input = ReadInput();
            
            var result = day.Day01Part01(input);
            
            result.Should().Be(69206);
        }
        
        [Fact]
        public void Day01Part2()
        {
            var day = new Day01();
            var input = ReadInput();
            
            var result = day.Day01Part02(input);

            result.Should().Be(197400);
        }

        private static List<Elf> ReadInput()
        {
            var input = File.ReadAllLines(Environment.CurrentDirectory + "/Input/Day01Input.txt");

            var result = new List<Elf>();
            var elf = new Elf { Calories = new List<int>(), Id = 0 };

            int id = 0;
            
            foreach (string s in input)
            {
                if (string.IsNullOrEmpty(s.Trim()))
                {
                    result.Add(elf);
                    id++;
                    elf = new Elf
                    {
                        Calories = new List<int>(),
                        Id = id
                    };
                }
                else 
                {
                    elf.Calories.Add(Convert.ToInt32(s));
                }
            }
            
            result.Add(elf);

            return result;
        }
    }
}