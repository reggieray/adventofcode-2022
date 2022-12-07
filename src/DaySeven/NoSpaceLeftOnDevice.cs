namespace AdventOfCode2022.DaySeven
{
    public static class NoSpaceLeftOnDevice
    {
        public static int TotalSizeOfDirectories(string input) => ProcessCommands(input)
                .Where(x => x.Size <= 100000)
                .Sum(y => y.Size);

        public static int TotalSizeOfDirectoryToDelete(string input)
        {
            var folders = ProcessCommands(input);
            var free = 70000000 - folders.Max(x => x.Size);
            return folders.Where(x => x.Size + free >= 30000000)
                .Min(x => x.Size);
        }

        private static List<Folder> ProcessCommands(string input)
        {
            var currentDirectory = new Stack<string>();
            var folders = new List<Folder>();

            foreach (var cmd in input.Split(Environment.NewLine))
            {

                if (cmd.StartsWith("$ cd"))
                {
                    if (cmd.Split(" ").Last().Equals(".."))
                    {
                        currentDirectory.Pop();
                    }
                    else
                    {
                        currentDirectory.Push(string.Join("", currentDirectory) + cmd.Split(" ").Last());
                    }
                }

                if (int.TryParse(cmd.Split(" ").First(), out int size))
                {
                    foreach (var dir in currentDirectory)
                    {
                        var item = folders.FirstOrDefault(x => x.Path.Equals(dir));

                        if (item != null)
                        {
                            item.Size += size;
                        }
                        else
                        {
                            folders.Add(new Folder(dir, size));
                        }
                    }
                }
            }

            return folders;
        }
    }

    internal class Folder
    {
        public string Path { get; set; }
        public int Size { get; set; }

        public Folder(string path, int size)
        {
            Path = path;
            Size = size;
        }
    }
}
