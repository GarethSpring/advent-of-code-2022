namespace AdventOfCode2022.Days
{
    public class Day06
    {
        private int markerLength = 0;
        
        public int Day06Logic(string input, int markerLength)
        {
            this.markerLength = markerLength;
            var marker = new List<char>();
            var result = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (CheckMarker(marker, input[i]))
                {
                    result = i + 1;
                    break;
                }
                
            }
            
            return result;
        }

        private bool CheckMarker(List<char> marker, char c)
        {
            if (marker.Count < this.markerLength)
            {
                marker.Add(c);
                return false;
            }
            
            marker.RemoveAt(0);
            marker.Add(c);
            
            return marker.Distinct().Count() == this.markerLength;
        }
        
    }
}