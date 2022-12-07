namespace AdventOfCode2022.Days
{
    public class Day07
    {
        private Dir _root = new() { Name = "/", SubDirs = new List<Dir>(), Files = new List<ElfFile>()};
        private int _pointer;
        private List<string> _input;
        private Dir _currentDir;
        private int _sumOfSmallerDirs;
        private readonly List<int> _dirSizes = new();
        
        public int Day07Part01(List<string> input)
        {
            _input = input;
            ParseInput();
            
            AssessDirSize(_root);
            
            return _sumOfSmallerDirs;
        }
        
        public int Day07Part02(List<string> input)
        {
            _input = input;
            ParseInput();
            
            AssessDirSize(_root);
            
            _dirSizes.Sort();

            // Min space needed to free up = 1735494
            var prevVal = 0;
            foreach (int i in _dirSizes)
            {
                if (prevVal >= 1735494)
                {
                    return prevVal;
                }
               
                prevVal = i;
            }

            return -1;
        }

        private void AssessDirSize(Dir dir)
        {
            var size = dir.GetSize();
            _dirSizes.Add(size);
            if (size <= 100000)
            {
                _sumOfSmallerDirs += size;
            }

            foreach (var d in dir.SubDirs)
            {
                AssessDirSize(d);
            }
        }

        private void ParseInput()
        {
            while (_pointer < _input.Count)
            {
                if (_input[_pointer].Substring(0,1).Equals("$"))
                {
                    ParseCommand(_input[_pointer].Substring(2));

                    if (_pointer > _input.Count)
                    {
                        break;
                    }
                }
            }
        }

        private void ParseCommand(string command)
        {
            if (command.Equals("ls"))
            {
                _pointer++;

                string line = _input[_pointer];
                while (!line.Substring(0, 1).Equals("$") && _pointer < _input.Count)
                {
                    Dir tempDir = new Dir()
                    {
                        ParentDir = _currentDir, 
                        Files = new List<ElfFile>(),
                        SubDirs = new List<Dir>()
                    };
                    
                    if (line.StartsWith("dir"))
                    {
                        tempDir.Name = line.Substring(4);
                        _currentDir.SubDirs.Add(tempDir);
                    }
                    else
                    {
                        // File
                        int spaceIndex = line.IndexOf(" ");
                        string fileSize = line.Substring(0, spaceIndex);
                        string fileName = line.Substring(spaceIndex + 1);
                        _currentDir.Files.Add(new ElfFile
                        {
                            Size = Convert.ToInt32(fileSize),
                            Name = fileName
                        });
                    }

                    _pointer++;
                    if (_pointer < _input.Count)
                    {
                        line = _input[_pointer];
                    }
                }

            }

            if (command.Substring(0, 2).Equals("cd"))
            {
                _pointer++;
                
                string dirName = command.Substring(3);

                if (dirName.Equals(".."))
                {
                    _currentDir = _currentDir.ParentDir;
                }
                else if (dirName.Equals("/"))
                {
                    _currentDir = _root;
                }
                else
                {
                    _currentDir = _currentDir.SubDirs.Single(d => d.Name.Equals(dirName));
                }
            }
        }
    }

    public class Dir
    {
        public string Name { get; set; }
        
        public List<Dir> SubDirs { get; set; }

        public Dir ParentDir { get; set; }

        public List<ElfFile> Files { get; set; }

        public int GetSize()
        {
            int size = SubDirs.Sum(s => s.GetSize());

            size += Files.Sum(f => f.Size);

            return size;
        }
    }

    public class ElfFile
    {
        public int Size { get; set; }
        
        public string Name { get; set; }
    }
}