namespace AdventOfCode2022.Days
{
    public class Day09
    {
        private readonly List<Position> _tailVisits = new ();
        private readonly List<Position> _rope = new();
        
        public int Day09Part01(List<RopeMove> input)
        {
            var headPos = new Position { X = 0, Y = 0 };
            var tailPos = new Position { X = 0, Y = 0 };
            
            _tailVisits.Add(new Position { X = 0, Y = 0 });
            
            foreach (RopeMove move in input)
            {
                for (int i = 0; i < move.Magnitude; i++)
                {
                    var lastHeadPos = new Position { X = headPos.X, Y = headPos.Y }; 
                        
                    MoveRopePart(headPos, move);

                    if (TailMoveRequired(headPos, tailPos))
                    {
                        MoveTail(tailPos, lastHeadPos);
                    }
                }
            }
            
            return _tailVisits.Count;
        }

        public int Day09Part02(List<RopeMove> input)
        {
            InitRope();
            
            _tailVisits.Add(new Position { X = 0, Y = 0 });
            
            foreach (RopeMove move in input)
            {
                for (int i = 0; i < move.Magnitude; i++)
                {
                    for (int r = 0; r < _rope.Count; r++)
                    {
                        // Head always moves
                        if (r == 0)
                        {
                            MoveRopePart(_rope[0], move);
                            continue;
                        }
                        
                        if (TailMoveRequired(_rope[r - 1], _rope[r]))
                        {
                            MoveTailNew(_rope[r], _rope[r - 1], r == _rope.Count - 1);
                        }
                    }
                }
            }
            
            return _tailVisits.Count;
        }

        private void InitRope()
        {
            for (int i = 0; i < 10; i++)
            {
                _rope.Add(new Position { X = 0, Y = 0 });
            }
        }

        private void MoveTail(Position tailPos, Position lastPos)
        {
            tailPos.X = lastPos.X;
            tailPos.Y = lastPos.Y;
            
            if (!_tailVisits.Exists(p => p.X == tailPos.X && p.Y == tailPos.Y))
            {
                _tailVisits.Add(new Position { X = tailPos.X, Y = tailPos.Y });
            }
        }

        private void MoveTailNew(Position tailPos, Position aheadPos, bool isActualTail = false)
        {
            if (Math.Abs(tailPos.X - aheadPos.X) == 2 || Math.Abs(tailPos.Y - aheadPos.Y) == 2)
            {
                if (tailPos.X - aheadPos.X <= 2 && tailPos.X - aheadPos.X > 0)
                {
                    tailPos.X--;
                }
            
                if (tailPos.X - aheadPos.X >= -2 && tailPos.X - aheadPos.X < 0)
                {
                    tailPos.X++;
                }
            
                if (tailPos.Y - aheadPos.Y <= 2 && tailPos.Y - aheadPos.Y > 0)
                {
                    tailPos.Y--;
                }
            
                if (tailPos.Y - aheadPos.Y >= -2 && tailPos.Y - aheadPos.Y < 0)
                {
                    tailPos.Y++;
                }
            }

            if (!isActualTail) 
                return;
            
            if (!_tailVisits.Exists(p => p.X == tailPos.X && p.Y == tailPos.Y))
            {
                _tailVisits.Add(new Position { X = tailPos.X, Y = tailPos.Y });
            }
        }

        private bool TailMoveRequired(Position head, Position tail)
        {
            if (head.X == tail.X && head.Y == tail.Y)
            {
                return false;
            }
            
            // Top Left
            if (head.X == tail.X - 1 && head.Y == tail.Y - 1)
            {
                return false;
            }
            
            // Top Middle
            if (head.X == tail.X && head.Y == tail.Y - 1)
            {
                return false;
            }
            
            // Top Right
            if (head.X == tail.X + 1 && head.Y == tail.Y - 1)
            {
                return false;
            }
            
            // Middle Right
            if (head.X == tail.X + 1 && head.Y == tail.Y)
            {
                return false;
            }
            
            // Bottom Right
            if (head.X == tail.X + 1 && head.Y == tail.Y + 1)
            {
                return false;
            }
            
            // Bottom Middle
            if (head.X == tail.X && head.Y == tail.Y + 1)
            {
                return false;
            }
            
            // Bottom Left
            if (head.X == tail.X - 1 && head.Y == tail.Y + 1)
            {
                return false;
            }
            
            // Middle Left
            if (head.X == tail.X - 1 && head.Y == tail.Y)
            {
                return false;
            }

            return true;
        }

        private void MoveRopePart(Position ropePart, RopeMove move)
        {
            switch (move.Direction)
            {
                case 'U':
                    ropePart.Y--;
                    break;
                case 'D':
                    ropePart.Y++;
                    break;
                case 'L':
                    ropePart.X--;
                    break;
                case 'R':
                    ropePart.X++;
                    break;
            }
        }
    }

    public class RopeMove
    {
        public char Direction { get; init; }
        
        public int Magnitude { get; set; }
    }

    public class Position
    {
        public int X { get; set; }
        
        public int Y { get; set; }
        
    }
}