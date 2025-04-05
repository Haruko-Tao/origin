using System.Threading.Channels;

namespace F_Delegation;

public static class LinqExtensions
{
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        if (source == null)
            throw new ArgumentException();
    }
}

class Program
{
    static void Main(string[] args)
    {
        
    }

    private void DisplayLargestFilesWithLinq(string pathToDir)
    {
        new DirectoryInfo(pathToDir)
            .GetFiles()
            .OrderByDescending(file => file.Length)
            .Take(5)
            .ForEach(file => Console.WriteLine($"{file.Name} weights {file.Length}"));
    }

    private static void DisplayLargesFilesWithoutLinq(string pathToDir)
    {
        var dirInfo = new DirectoryInfo(pathToDir);
        FileInfo[] files = dirInfo.GetFiles();

        Array.Sort(files, FilesComparison);
    }

    static int FilesComparison(FileInfo x, FileInfo y)
    {
        if (x.Length == y.Length) return 0;
        if (x.Length > y.Length) return 1;
        return -1;
    }
}