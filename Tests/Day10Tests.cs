using AdventOfCode2022.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day10Tests
    {
        [Fact]
        public void Day10Part1Test()
        {
            var day = new Day10();
            var ops = ReadInput();

            var result = day.Part1(ops);
            
            result.Should().Be(16880);
        }
        
        [Fact]
        public void Day10Part2Test()
        {
            var day = new Day10();
            var ops = ReadInput();

            Action test = () =>  day.Part2(ops);

            // Do some colouring in
            test.Should().NotThrow();
        }

        private static List<Op> ReadInput()
        {
            var ops = new List<Op>();
            var input = File.ReadAllLines(Environment.CurrentDirectory + "/Input/Day10Input.txt").ToList();

            foreach (string s in input)
            {
                var op = new Op
                {
                    Instruction = s[..4]
                };

                if (op.Instruction != "noop")
                {
                    op.Value = Convert.ToInt32(s[5..]);
                }
                
                ops.Add(op);
            }

            return ops;
        }
    }
}