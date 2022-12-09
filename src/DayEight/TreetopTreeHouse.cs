namespace AdventOfCode2022.DayEight
{
    public static class TreetopTreeHouse
    {
        public static int VisibleTrees(string input)
        {
            var trees = ToTreeGrid(input.Split(Environment.NewLine));
            return GetVisibleTrees(trees);
        }

        public static int HighestScenicScore(string input)
        {
            var trees = ToTreeGrid(input.Split(Environment.NewLine));
            return GetScenicScore(trees).Max();
        }

        private static IEnumerable<int> GetScenicScore(int[,] trees)
        {
            var scenicScores = new List<int>();

            for (int i = 0; i < trees.GetLength(0); i++)
            {
                for (int j = 0; j < trees.GetLength(1); j++)
                {
                    scenicScores.Add(CalculateScenicScore(i, j, trees));
                }
            }
            return scenicScores;
        }

        private static int CalculateScenicScore(int x, int y, int[,] trees)
        {
            var horizontalTreeLine = Enumerable.Range(0, trees.GetLength(1))
                .Select(row => new { size = trees[x, row], current = row == y, left = row < y, right = row > y, position = row })
                .Where(t => !t.current)
                .ToArray();

            var verticalTreeLine = Enumerable.Range(0, trees.GetLength(0))
                .Select(col => new { size = trees[col, y], current = col == x, top = col < x, bottom = col > x, position = col })
                .Where(t => !t.current)
                .ToArray();

            var left = GetScore(horizontalTreeLine.Where(t => t.left).OrderByDescending(t => t.position).Select(t => t.size), trees[x,y]);
            var right = GetScore(horizontalTreeLine.Where(t => t.right).OrderBy(t => t.position).Select(t => t.size), trees[x, y]);
            var top = GetScore(verticalTreeLine.Where(t => t.top).OrderByDescending(t => t.position).Select(t => t.size), trees[x, y]);
            var bottom = GetScore(verticalTreeLine.Where(t => t.bottom).OrderBy(t => t.position).Select(t => t.size), trees[x, y]);

            return left * right * top * bottom;
        }

        private static int GetScore(IEnumerable<int> sizes, int tSize)
        {
            var count = 0;
            int? last = null; 
            foreach (var size in sizes)
            {
                if (last.HasValue && last > size && last > tSize) return count;

                count++;

                if (size == tSize) return count;
                if (size > tSize) return count;

                last = size;
            }
            return count;
        }

        private static int[,] ToTreeGrid(string[] input)
        {
            var size = input[0].ToCharArray().Length;
            var trees = new int[size, size];

            for (int i = 0; i < input.Length; i++)
            {
                var treeLine = input[i].ToCharArray();
                for (int j = 0; j < treeLine.Length; j++)
                {
                    trees[i, j] = int.Parse(treeLine[j].ToString());
                }
            }
            return trees;
        }

        private static int GetVisibleTrees(int[,] trees)
        {
            var count = 0;
            for (int i = 0; i < trees.GetLength(0); i++)
            {
                for (int j = 0; j < trees.GetLength(1); j++)
                {
                    if (IsVisible(i, j, trees))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private static bool IsVisible(int x, int y, int[,] trees) => IsEdge(x, y, trees.GetLength(0)) || IsVisibleHorizontally(x, y, trees) || IsVisibleVertically(x, y, trees);

        private static bool IsVisibleHorizontally(int x, int y, int[,] trees)
        {
            var treeLine = Enumerable.Range(0, trees.GetLength(1))
                .Select(row => new { size = trees[x, row], current = row == y, left = row < y, right = row > y })
                .Where(t => !t.current && t.size >= trees[x, y])
                .ToArray();

            return !treeLine.Any(x => x.left) || !treeLine.Any(x => x.right);
        }

        private static bool IsVisibleVertically(int x, int y, int[,] trees)
        {
            var treeLine = Enumerable.Range(0, trees.GetLength(0))
                .Select(col => new { size = trees[col, y], current = col == x, top = col < x, bottom = col > x })
                .Where(t => !t.current && t.size >= trees[x, y])
                .ToArray();

            return !treeLine.Any(x => x.top) || !treeLine.Any(x => x.bottom);
        }

        private static bool IsEdge(int x, int y, int size) => (x == 0 || x == size - 1) || (y == 0 || y == size - 1);
    }
}
