namespace AdventOfCode2022.Days
{
    public class Day11
    {
        private List<Monkey> _monkeys;
        
        public long Part1(List<Monkey> monkeys)
        {
            _monkeys = monkeys;
            for (int i = 0; i < 20; i++)
            {
                PlayRound(true);
            }

            var orderByDescending = _monkeys.OrderByDescending(m => m.Inspections);
            var result = orderByDescending.Take(1).First().Inspections * orderByDescending.Skip(1).Take(1).First().Inspections;
            return result;
        }
        
        public long Part2(List<Monkey> monkeys)
        {
            _monkeys = monkeys;
            
            // Least Common Multiple 
            long lcm = 13 * 7 * 3 * 19 * 5 *  2 * 11 * 17;
            
            for (int i = 0; i < 10000; i++)
            {
                PlayRound(false, lcm);
            }

            var orderByDescending = _monkeys.OrderByDescending(m => m.Inspections);
            var result = orderByDescending.Take(1).First().Inspections * orderByDescending.Skip(1).Take(1).First().Inspections;
            return result;
        }

        private void PlayRound(bool divide, long lcm = 0)
        {
            for (int m = 0; m < _monkeys.Count; m++)
            {
                for (int itemIndex = 0; itemIndex < _monkeys[m].StartingItems.Count; itemIndex++)
                {
                    _monkeys[m].Inspections++;
                    _monkeys[m].StartingItems[itemIndex] = m switch
                    {
                        0 => _monkeys[m].StartingItems[itemIndex] * 11,
                        1 => _monkeys[m].StartingItems[itemIndex] + 1,
                        2 => _monkeys[m].StartingItems[itemIndex] * _monkeys[m].StartingItems[itemIndex],
                        3 => _monkeys[m].StartingItems[itemIndex] + 2,
                        4 => _monkeys[m].StartingItems[itemIndex] + 6,
                        5 => _monkeys[m].StartingItems[itemIndex] + 7,
                        6 => _monkeys[m].StartingItems[itemIndex] * 7,
                        7 => _monkeys[m].StartingItems[itemIndex] + 8,
                        _ => throw new ArgumentOutOfRangeException()
                    };
                    
                    _monkeys[m].StartingItems[itemIndex] = divide 
                        ? Convert.ToInt64(Math.Floor((double) _monkeys[m].StartingItems[itemIndex] / 3))
                        : _monkeys[m].StartingItems[itemIndex] %= lcm;

                    // Throw
                    if (_monkeys[m].StartingItems[itemIndex] % _monkeys[m].DivisibleBy == 0)
                    {
                        _monkeys[_monkeys[m].TrueThrowIndex].StartingItems.Add(_monkeys[m].StartingItems[itemIndex]);
                    }
                    else
                    {
                        _monkeys[_monkeys[m].FalseThrowIndex].StartingItems.Add(_monkeys[m].StartingItems[itemIndex]);
                    }
                }

                _monkeys[m].StartingItems = new List<long>();
            }
        }
    }   

    public class Monkey
    {
        public int Id { get; init; }
        
        public List<long> StartingItems { get; set; }
        
        public int TrueThrowIndex { get; init; }
        
        public int FalseThrowIndex { get; init; }

        public int DivisibleBy { get; init; }
        
        public long Inspections { get; set; }
    }
}