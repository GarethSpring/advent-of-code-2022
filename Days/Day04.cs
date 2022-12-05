namespace AdventOfCode2022.Days
{
    public class Day04
    {
        public int Day04Part01(List<ElfPair> input)
        {
            return input.Select(ep =>
                ep.R1.Start.Value >= ep.R2.Start.Value && ep.R1.End.Value <= ep.R2.End.Value
                || ep.R2.Start.Value >= ep.R1.Start.Value && ep.R2.End.Value <= ep.R1.End.Value).Count(p => p);
        }
        
        public int Day04Part02(List<ElfPair> input)
        {
            return input.Select(ep => 
                ep.R1.End.Value >= ep.R2.Start.Value && ep.R1.End.Value <= ep.R2.End.Value
                ||  ep.R2.End.Value >= ep.R1.Start.Value && ep.R2.End.Value <= ep.R1.End.Value).Count(p => p);
        }
    }

    public class ElfPair
    {
        public Range R1 { get; init; }
        
        public Range R2 { get; init; }
    }
}