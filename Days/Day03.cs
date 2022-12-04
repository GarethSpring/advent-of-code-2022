﻿namespace AdventOfCode2022.Days
{
    public class Day03
    {
        private List<char> Priorities;
        
        public Day03()
        {
            ConstructPriorities();
        }
        
        public int Day03Part01(List<RuckSack> input)
        {
            var matches = new List<char>();

            foreach (char c in Priorities)
            {
                foreach (var rs in input)
                {
                    if (rs.CompartmentA.Contains(c) && rs.CompartmentB.Contains(c))
                    {
                        matches.Add(c);
                    }
                }
            }

            int result = 0;
            
            foreach (char c in matches)
            {
                result += Priorities.IndexOf(c) + 1;
            }
            
            return result;
        }

        public int Day03Part02(List<RuckSack> input)
        {
            var groupMatches = new List<char>();

            for (int i = 0; i < input.Count / 3; i++)
            {
                var group = input.Skip(i * 3).Take(3);
                
                foreach (char c in Priorities)
                {
                    if (group.All(rs => rs.CompartmentA.Contains(c) || rs.CompartmentB.Contains(c)))
                    {
                        groupMatches.Add(c);
                        break;
                    }
                }
            }
            
            int result = 0;
            
            foreach (char c in groupMatches)
            {
                result += Priorities.IndexOf(c) + 1;
            }
            
            return result;
        }
        

        private void ConstructPriorities()
        {
            Priorities = new List<char>()
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u',
                'v', 'w', 'x', 'y', 'z',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U',
                'V', 'W', 'X', 'Y', 'Z'
            };
        }
    }

    public class RuckSack
    {
        public string CompartmentA { get; init; }
        
        public string CompartmentB { get; init; }
    }
}