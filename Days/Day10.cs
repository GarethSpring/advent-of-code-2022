using System.Runtime.InteropServices;
using AdventOfCode2022.Processor;

namespace AdventOfCode2022.Days
{
    public class Day10
    {
        private readonly CPU _cpu = new();
        
        public int Part1(List<Op> ops)
        {
            _cpu.X = 1;
            
            Process(ops);

            return _cpu.SignalStrengths.Sum();
        }
        
        public void Part2(List<Op> ops)
        {
            _cpu.X = 1;
            
            Process(ops);
        }

        private void Process(List<Op> ops)
        {
            int instructionCounter = 0;
            while (instructionCounter < ops.Count)
            {
                switch (ops[instructionCounter].Instruction)
                {
                    case "noop":
                        _cpu.IncrementOpCounter();
                        _cpu.Render();
                        
                        break;
                    case "addx":
                        // begin execution
                        _cpu.IncrementOpCounter();
                        _cpu.Render();
                        _cpu.IncrementOpCounter();
                        _cpu.X += ops[instructionCounter].Value;
                        _cpu.Render();
                        break;
                }

                instructionCounter++;
            }
        }
    }

    public class Op
    {
        public string Instruction { get; set; }
        
        public int Value { get; set; }
    }
}