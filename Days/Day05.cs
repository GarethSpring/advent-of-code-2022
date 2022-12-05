namespace AdventOfCode2022.Days
{
    public class Day05
    {
        public string Day05Part01(Crane state, List<Move> moves)
        {
            foreach (Move m in moves)
            {
                for (int i = 0; i < m.Quantity; i++)
                {
                    string temp = state.Crates[m.Source - 1].Pop();
                    state.Crates[m.Destination -1].Push(temp);
                }
            }

            var result = string.Empty;
            foreach (var t in state.Crates)
            {
                result += t.Peek();
            }
            
            return result;
        }
        
        public string Day05Part02(Crane state, List<Move> moves)
        {
            foreach (Move m in moves)
            {
                var tempStack = new Stack<string>();
                
                for (int i = 0; i < m.Quantity; i++)
                {
                    tempStack.Push(state.Crates[m.Source - 1].Pop());
                }
                
                for (int i = 0; i < m.Quantity; i++)
                {
                    state.Crates[m.Destination - 1].Push(tempStack.Pop());
                }
            }

            var result = string.Empty;
            foreach (var t in state.Crates)
            {
                result += t.Peek();
            }
            
            return result;
        }
    }

    public class Crane
    {
        public List<Stack<string>> Crates { get; set; }
    }

    public class Move
    {
        public int Quantity { get; init; }
        
        public int Source { get; init; }
        
        public int Destination { get; init; }
    }
}