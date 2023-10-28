namespace Entity;

public class TreePath
{
  public required string FullName { get; set; }

  public string Name
  {
    get
    {
      var split = FullName.Split('/');
      return split.Last();
    }
  }

  public List<TreePath> SubPaths
  {
    get
    {
      var subpaths = new List<TreePath>();

      if (Directory.Exists(FullName))
      {
        var subdirs = new DirectoryInfo(FullName).GetDirectories();
        var files = new DirectoryInfo(FullName).GetFiles();

        foreach (var subdir in subdirs)
        {
          var subpath = new TreePath { FullName = subdir.FullName };
          subpaths.Add(subpath);
        }
        foreach (var file in files)
        {
          var subpath = new TreePath { FullName = file.FullName };
          subpaths.Add(subpath);
        }
      }
      return subpaths;
    }

  }

  public void Print(string parentPath = "")
  {
    var pathName = string.Empty;
    var split = parentPath.Split('/');

    if (parentPath != "")
    {
      pathName = Name.Replace(parentPath, "");
    }
    else
      pathName = Name;

    var spaces = new string('_', parentPath.Length);

    Console.WriteLine($"{spaces}{pathName}");

    SubPaths.ForEach(x => x.Print($"{parentPath}_{Name}"));
  }
}