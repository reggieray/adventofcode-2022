namespace AdventOfCode2022.DaySix
{
    public static class TuningTrouble
    {
        public static int StartOfPacketMarker(string input) => StartOfMarker(input, marker: 4);

        public static int StartOfMessageMarker(string input) => StartOfMarker(input, marker: 14);

        private static int StartOfMarker(string input, int marker)
        {
            var array = input.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                var section = array.Take(new Range(i, i + marker));
                var distinct = section.Distinct();
                if (distinct.Count() == marker) return i + marker;
            }

            throw new Exception($"Marker not found for {marker}!");
        }
    }
}
