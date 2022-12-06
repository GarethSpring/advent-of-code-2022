namespace AdventOfCode2022.Days
{
    public class Day06
    {
        private int _markerLength;
        
        public int Day06Logic(string input, int markerLength)
        {
            _markerLength = markerLength;
            var marker = new List<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (CheckMarker(marker, input[i]))
                {
                    return i + 1;
                }
            }

            return -1;
        }

        private bool CheckMarker(List<char> marker, char c)
        {
            if (marker.Count < _markerLength)
            {
                marker.Add(c);
                return false;
            }
            
            marker.RemoveAt(0);
            marker.Add(c);
            
            return marker.Distinct().Count() == _markerLength;
        }
    }
}