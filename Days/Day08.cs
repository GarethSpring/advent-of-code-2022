namespace AdventOfCode2022.Days
{
    public class Day08
    {
        private int _size = 99;

        public int Day08Part01(Forest forest)
        {
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    forest.Trees[(x, y)].Visible = IsVisible(x, y, forest);
                }
            }
            
            return forest.Trees.Count(t => t.Value.Visible);
        }
        
        public long Day08Part02(Forest forest)
        {
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    SetScore(x, y, forest);
                }
            }
            
            return forest.Trees.Max(t => t.Value.Score);
        }

        private void SetScore(int x, int y, Forest forest)
        {
            // up
            var treeHeights = new List<int>();
            var score1 = 0;
            int y1 = y;
            while (y1 > 0)
            {
                treeHeights.Add( forest.Trees[(x, y1 - 1)].Height);
                y1--;
            }
            
            score1 = HowManyTrees(forest.Trees[(x, y)].Height, treeHeights);
            
            treeHeights = new List<int>();
            var score2 = 0;
            y1 = y;
            while (y1 < _size -1)
            {
                treeHeights.Add(forest.Trees[(x, y1 + 1)].Height);
                y1++;
            }
            
            score2 = HowManyTrees(forest.Trees[(x, y)].Height, treeHeights);
            
            treeHeights = new List<int>();
            var score3 = 0;
            int x1 = x;
            while (x1 > 0)
            {
                treeHeights.Add( forest.Trees[(x1 -1, y )].Height);
                x1--;
            }
            
            score3 = HowManyTrees(forest.Trees[(x, y)].Height, treeHeights);
            
            treeHeights = new List<int>();
            var score4 = 0;
            x1 = x;
            while (x1 < _size -1)
            {
                treeHeights.Add(forest.Trees[(x1 + 1, y)].Height);
                x1++;
            }
            
            score4 = HowManyTrees(forest.Trees[(x, y)].Height, treeHeights);
            
            forest.Trees[(x, y)].Score = score1 * score2 * score3 * score4;
        }

        private bool IsVisible(int x, int y, Forest forest)
        {
            if (y == 0 || y == _size - 1 || x == 0 || x == _size - 1)
            {
                // On Edge of Forest
                return true;
            }
            
            //up
            var treeHeights = new List<int>();
            int y1 = y;
            while (y1 > 0)
            {
                treeHeights.Add( forest.Trees[(x, y1 - 1)].Height);
                y1--;
            }

            if (HasLineOfSight(forest.Trees[(x, y)].Height, treeHeights))
                return true;

            // Down
            treeHeights = new List<int>();
            y1 = y;
            while (y1 < _size -1)
            {
                treeHeights.Add(forest.Trees[(x, y1 + 1)].Height);
                y1++;
            }
            
            if (HasLineOfSight(forest.Trees[(x, y)].Height, treeHeights))
                return true;
            
            // right
            treeHeights = new List<int>();
            var x1 = x;
            while (x1 > 0)
            {
                treeHeights.Add( forest.Trees[(x1 -1, y )].Height);
                x1--;
            }

            if (HasLineOfSight(forest.Trees[(x, y)].Height, treeHeights))
                return true;

            // Left
            treeHeights = new List<int>();
            x1 = x;
            while (x1 < _size -1)
            {
                treeHeights.Add(forest.Trees[(x1 + 1, y)].Height);
                x1++;
            }
            
            if (HasLineOfSight(forest.Trees[(x, y)].Height, treeHeights))
                return true;
            
            return false;
        }

        private bool HasLineOfSight(int height, List<int> trees)
        {
            foreach (int i in trees)
            {
                if (i >= height)
                {
                    return false;
                }
                    
            }
            return true;
        }
        
        private int HowManyTrees(int height, List<int> trees)
        {
            int a = 1;
            foreach (int i in trees)
            {
                if (i >= height)
                {
                    return a;
                }

                a++;

            }

            return trees.Count;
        }
    }

    public class Forest
    {
        public Dictionary<(int,int),Tree> Trees { get; set; }
        
    }

    public class Tree
    {
        public int Height { get; set; }
        
        public bool Visible { get; set; }
        
        public long Score { get; set; }
    }
}