using Entity;
class Program
{
  static void Main(string[] args)
  {
    var path = new DirectoryInfo(".");
    TreePath tree;

    if (args.Length == 0)
    {
      tree = new TreePath { FullName = path.FullName };
      tree.Print();
      return;
    }

    switch (args.First())
    {
      case "version":
        Console.WriteLine("Version 1.0");
        break;
      case "help":
        Console.WriteLine("Usage: MyTree [path]");
        break;
      default:
        path = new DirectoryInfo(args[0]);
        tree = new TreePath { FullName = path.FullName };
        tree.Print();
        break;
    }
  }
}
