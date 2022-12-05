using System.Text.RegularExpressions;
using AdventOfCode2022.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day05Tests
    {
        private Crane crane;

        [Fact]
        public void Day05Part1Test()
        {
            Setup();
            
            var day = new Day05();
            var moves = ReadInput();

            var result = day.Day05Part01(crane, moves);
            
            result.Should().Be("RTGWZTHLD");
        }
        
        [Fact]
        public void Day05Part2Test()
        {
            Setup();
            
            var day = new Day05();
            var moves = ReadInput();

            var result = day.Day05Part02(crane, moves);
            
            result.Should().Be("STHGRZZFR");
        }

        private void PushStack(string input, Crane crane)
        {
            var s = new Stack<string>();
            foreach (char c in input)
            {
               s.Push(c.ToString());
            }
            
            crane.Crates.Add(s);
        }

        private void Setup()
        {
            crane = new Crane
            {
                Crates = new List<Stack<string>>()
            };
            
            PushStack("NCRTMZP", crane);
            PushStack("DNTSBZ", crane);
            PushStack("MHQRFCTG", crane);
            PushStack("GRZ", crane);
            PushStack("ZNRH", crane);
            PushStack("FHSWPZLD", crane);
            PushStack("WDZRCGM", crane);
            PushStack("SJFLHWZQ", crane);
            PushStack("SQPWN", crane);
        }

        private static List<Move> ReadInput()
        {
            var moves = new List<Move>();
            var input = File.ReadAllLines(Environment.CurrentDirectory + "/Input/Day05Input.txt");

            var regex = new Regex(@"move\s(\d{1,2})\sfrom\s(\d)\sto\s(\d)");
            
            foreach (string line in input)
            {
                Match? matches = regex.Match(line);
                
                var move = new Move
                {
                    Quantity = Convert.ToInt32(matches.Groups[1].Value),
                    Source = Convert.ToInt32(matches.Groups[2].Value),
                    Destination = Convert.ToInt32(matches.Groups[3].Value)
                };
                
                moves.Add(move);
            }
            
            return moves;
        }
    }
}