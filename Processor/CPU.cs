using System.Diagnostics;

namespace AdventOfCode2022.Processor
{
    public class CPU
    {
        /// <summary>
        /// X Register
        /// </summary>
        public int X { get; set; }
        
        /// <summary>
        /// Op Counter
        /// </summary>
        public int OpCounter { get; set; }

        /// <summary>
        /// Signal Strength
        /// </summary>
        public List<int> SignalStrengths { get; set; }
        
        public int ScanRow { get; set; }

        public CPU()
        {
            SignalStrengths = new List<int>();
        }

        public void IncrementOpCounter()
        {
            OpCounter++;

            if ((OpCounter == 20 || (OpCounter - 20) % 40 == 0) && OpCounter <= 220)
            {
                SignalStrengths.Add(X * OpCounter);
            }
        }

        public void Render()
        {
            if (OpCounter % 40 == 0)
            {
                Debug.WriteLine(DrawPixel() ? "#" : ".");
                ScanRow++;
            }
            else
            {
                Debug.Write(DrawPixel() ? "#" : ".");
            }
        }

        private bool DrawPixel()
        {
            var offset = ScanRow * 40;
            var opOffset = OpCounter - offset;
            if (opOffset == X - 1 || opOffset == X || opOffset == X + 1)
            {
                return true;
            }

            return false;
        }
    }
}